using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Catel;
using Catel.IoC;
using Catel.Services;
using HandyControl.Data;
using Orc.ProjectManagement;
using Orchestra.Services;
using WolvenKit.Common;
using WolvenKit.Common.Model;
using WolvenKit.Common.Services;
using WolvenKit.Functionality.Commands;
using WolvenKit.Functionality.Controllers;
using WolvenKit.MVVM.Model.ProjectManagement.Project;
using WolvenKit.MVVM.ViewModels.Shell.Editor;

namespace WolvenKit.MVVM.ViewModels.Components.Tools
{
    public class AssetBrowserViewModel : ToolViewModel
    {
        #region constants

        /// <summary>
        /// Identifies the <see ref="ContentId"/> of this tool window.
        /// </summary>
        public const string ToolContentId = "AssetBrowser_Tool";

        /// <summary>
        /// Identifies the caption string used for this tool window.
        /// </summary>
        public const string ToolTitle = "Asset Browser";

        #endregion constants

        #region fields

        private readonly ILoggerService _loggerService;
        private readonly IMessageService _messageService;
        private readonly IGrowlNotificationService _notificationService;
        private readonly IProjectManager _projectManager;
        private List<IGameArchiveManager> Managers { get; set; }

        #endregion fields

        #region properties

        public List<string> Classes { get; set; }
        public GameFileTreeNode CurrentNode { get; set; } = new GameFileTreeNode();
        public List<AssetBrowserData> CurrentNodeFiles { get; set; } = new List<AssetBrowserData>();
        public List<string> Extensions { get; set; }
        public string Folder { get; set; }
        public ImageSource Image { get; set; }
        public bool IsLoaded { get; set; }

        // binding properties. do not make private
        // ReSharper disable MemberCanBePrivate.Global
        public bool PreviewVisible { get; set; }

        public System.Windows.GridLength PreviewWidth { get; set; } = new(0, System.Windows.GridUnitType.Pixel);
        public GameFileTreeNode RootNode { get; set; }

        public string SelectedClass { get; set; }
        public string SelectedExtension { get; set; }
        public List<IGameFile> SelectedFiles { get; set; }
        public AssetBrowserData SelectedNode { get; set; }
        public List<AssetBrowserData> SelectedNodes { get; set; }
        // ReSharper restore MemberCanBePrivate.Global

        #endregion properties

        #region ctor

        public AssetBrowserViewModel(
            IProjectManager projectManager,
            ILoggerService loggerService,
            IMessageService messageService,
            IGrowlNotificationService notificationService
        ) : base(ToolTitle)
        {
            Argument.IsNotNull(() => projectManager);
            Argument.IsNotNull(() => messageService);
            Argument.IsNotNull(() => loggerService);
            Argument.IsNotNull(() => notificationService);
            _projectManager = projectManager;
            _loggerService = loggerService;
            _messageService = messageService;
            _notificationService = notificationService;

            SearchStartedCommand = new DelegateCommand<object>(ExecuteSearchStartedCommand, CanSearchStartedCommand);
            TogglePreviewCommand = new RelayCommand(ExecuteTogglePreview, CanTogglePreview);
            ImportFileCommand = new RelayCommand(ExecuteImportFile, CanImportFile);
            HomeCommand = new RelayCommand(ExecuteHome, CanHome);

            SetupToolDefaults();
            ReInit();
        }

        #endregion ctor

        #region commands

        public ICommand HomeCommand { get; private set; }

        public ICommand ImportFileCommand { get; private set; }

        public ICommand SearchStartedCommand { get; private set; }

        public ICommand TogglePreviewCommand { get; private set; }

        private bool CanHome() => true;

        private bool CanImportFile() => SelectedNode != null;

        private bool CanSearchStartedCommand(object arg) => true;

        private bool CanTogglePreview() => true;

        private void ExecuteHome()
        {
            CurrentNode = RootNode;
            CurrentNodeFiles = RootNode.ToAssetBrowserData();
        }

        private void ExecuteImportFile() => ImportFile(SelectedNode);

        private void ExecuteSearchStartedCommand(object arg)
        {
            if (arg is FunctionEventArgs<string> e)
            {
                PerformSearch(e.Info);
            }
        }

        private void ExecuteTogglePreview()
        {
            if (PreviewWidth.GridUnitType != System.Windows.GridUnitType.Pixel)
            {
                PreviewWidth = new System.Windows.GridLength(0, System.Windows.GridUnitType.Pixel);
                PreviewVisible = true;
            }
            else
            {
                PreviewWidth = new System.Windows.GridLength(1, System.Windows.GridUnitType.Star);
                PreviewVisible = false;
            }
        }

        #endregion commands

        #region methods

        /// <summary>
        /// Initializes the Asset Browser and populates the data nodes.
        /// </summary>
        public void ReInit()
        {
            SelectedFiles = new List<IGameFile>();
            Managers = MainController.Get().GetManagers(true);

            CurrentNode = new GameFileTreeNode(EArchiveType.ANY) { Name = "Depot" };
            foreach (var mngr in Managers)
            {
                if (mngr.RootNode != null)
                {
                    mngr.RootNode.Parent = CurrentNode;
                    CurrentNode.Directories.Add(mngr.TypeName.ToString(), mngr.RootNode);
                }
            }

            CurrentNodeFiles = CurrentNode.ToAssetBrowserData();
            RootNode = CurrentNode;
            Extensions = MainController.Get().GetManagers(true).SelectMany(x => x.Extensions).ToList();
            Classes = MainController.GetGame().GetAvaliableClasses();
            PreviewVisible = false;

            IsLoaded = true;
            if (MainController.GetGame() is not MockGameController)
            {
                _notificationService.Success($"Asset Browser is initialized");
            }
        }

        protected override Task CloseAsync() =>
            // TODO: Unsubscribe from events

            base.CloseAsync();

        protected override async Task InitializeAsync() => await base.InitializeAsync();// TODO: Write initialization code here and subscribe to events

        private static void AddToMod(IGameFile file)
        {
            var pm = ServiceLocator.Default.ResolveType<IProjectManager>();
            var project = (EditorProject)pm.ActiveProject;
            switch (project.GameType)
            {
                case GameType.Witcher3:
                {
                    if (project is Tw3Project witcherProject)
                    {
                        var diskPathInfo = new FileInfo(Path.Combine(witcherProject.ModCookedDirectory, file.Name));
                        if (diskPathInfo.Directory == null)
                        {
                            break;
                        }

                        Directory.CreateDirectory(diskPathInfo.Directory.FullName);
                        using var fs = new FileStream(diskPathInfo.FullName, FileMode.Create);
                        file.Extract(fs);
                    }
                    break;
                }
                case GameType.Cyberpunk2077:
                {
                    if (project is Cp77Project cyberpunkProject)
                    {
                        var diskPathInfo = new FileInfo(Path.Combine(cyberpunkProject.ModDirectory, file.Name));
                        if (diskPathInfo.Directory == null)
                        {
                            break;
                        }

                        Directory.CreateDirectory(diskPathInfo.Directory.FullName);
                        using var fs = new FileStream(diskPathInfo.FullName, FileMode.Create);
                        file.Extract(fs);
                    }

                    break;
                }
                default:
                    break;
            }
        }

        private static IEnumerable<IGameFile> CollectFiles(string searchkeyword, IGameArchiveManager root)
        {
            var ret = new Dictionary<string, IGameFile>();
            foreach (var f in root.FileList)
            {
                if (f.Name.Contains(searchkeyword, StringComparison.OrdinalIgnoreCase))
                {
                    if (!ret.ContainsKey(f.Name))
                    {
                        ret.TryAdd(f.Name, f);
                    }
                }
            }
            return ret.Values.ToList();
        }

        private void ImportFile(AssetBrowserData item)
        {
            switch (item.Type)
            {
                case EntryType.Directory:
                {
                    CurrentNode = item.Children;
                    CurrentNode.Parent = item.This;
                    CurrentNodeFiles = item.Children.ToAssetBrowserData();
                    break;
                }
                case EntryType.File:
                {
                    Task.Run(new Action(() => AddToMod(item.This.Files.First(x => x.Key == item.Name).Value.First())));
                    _notificationService.Info($"Importing file: {item.Name}");

                    break;
                }
                case EntryType.MoveUP:
                {
                    if (item.Parent != null)
                    {
                        CurrentNode = item.Parent;
                        CurrentNodeFiles = item.Parent.ToAssetBrowserData();
                    }
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void PerformSearch(string query)
        {
            var newnode = new GameFileTreeNode()
            {
                Name = "",
                Parent = CurrentNode,
                Directories = new Dictionary<string, GameFileTreeNode>(),
                Files = new Dictionary<string, List<IGameFile>>()
            };
            newnode.Files = Managers.
                SelectMany(_ => CollectFiles(query, _))
                .GroupBy(x => x.Name)
                .Select(x => x.First())
                .Select(f => new KeyValuePair<string, List<IGameFile>>(f.Name, new List<IGameFile>() { f }))
                .ToDictionary(x => x.Key, x => x.Value);
            CurrentNode = newnode;
            CurrentNodeFiles = CurrentNode.ToAssetBrowserData();
        }

        private void SetupToolDefaults() => ContentId = ToolContentId;           // Define a unique contentid for this toolwindow//BitmapImage bi = new BitmapImage();  // Define an icon for this toolwindow//bi.BeginInit();//bi.UriSource = new Uri("pack://application:,,/Resources/Media/Images/property-blue.png");//bi.EndInit();//IconSource = bi;

        #endregion methods
    }

    public class FolderItem
    {
        #region Constructors

        public FolderItem()
            : base()
        {
        }

        #endregion Constructors

        #region Properties

        public string Folder { get; set; }
        public ImageSource Image { get; set; }

        #endregion Properties
    }
}
