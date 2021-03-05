using System.Collections.ObjectModel;
using System.Windows.Controls;
using Catel.MVVM;
using WolvenKit.MVVM.Views.Components.Dialogs;
using WolvenKit.MVVM.Views.Components.Editors;
using WolvenKit.MVVM.Views.Components.Tools;

namespace WolvenKit.MVVM.ViewModels.Shell.HomePage.Pages
{
    public class DebugPageViewModel : ViewModelBase
    {
        #region Fields

        public static ObservableCollection<UserControl> _DialogsUC = new ObservableCollection<UserControl>();
        public static ObservableCollection<UserControl> _EditorsUC = new ObservableCollection<UserControl>();
        public static ObservableCollection<UserControl> _ToolsUC = new ObservableCollection<UserControl>();
        public static ObservableCollection<UserControl> _WizardsUC = new ObservableCollection<UserControl>();

        #endregion Fields

        #region Constructors

        public DebugPageViewModel()
        {
            InitThis();
        }

        #endregion Constructors

        #region Properties

        public ObservableCollection<UserControl> DialogsUC => _DialogsUC;
        public ObservableCollection<UserControl> EditorsUC => _EditorsUC;
        public ObservableCollection<UserControl> ToolsUC => _ToolsUC;
        public ObservableCollection<UserControl> WizardsUC => _WizardsUC;

        #endregion Properties

        #region Methods

        public void InitThis()
        {
            _DialogsUC.Add(new AddChunkDialog());
            _DialogsUC.Add(new ExtractAmbigiousDialog());
            _DialogsUC.Add(new RenameDialog());
            _DialogsUC.Add(new StringsGUIImporterIDDialog());
            _DialogsUC.Add(new StringsGuiScriptsPrefixDialog());
            _EditorsUC.Add(new BulkEditorView());
            _EditorsUC.Add(new CsvEditorView());
            _EditorsUC.Add(new ArrayEditorView());
            _EditorsUC.Add(new ByteArrayEditorView());
            _EditorsUC.Add(new IdTagEditorView());
            _EditorsUC.Add(new PtrEditorView());
            _EditorsUC.Add(new JournalEditorView());
            _ToolsUC.Add(new AnimsView());
            _ToolsUC.Add(new MimicsView());
            _ToolsUC.Add(new CR2WToTextToolView());
            _ToolsUC.Add(new GameDebuggerToolView());
            _ToolsUC.Add(new ImporterToolView());
            _ToolsUC.Add(new MenuCreatorToolView());
            _ToolsUC.Add(new RadishToolView());
            _ToolsUC.Add(new WccToolView());
        }

        #endregion Methods
    }
}
