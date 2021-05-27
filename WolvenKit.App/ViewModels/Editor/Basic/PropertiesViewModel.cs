using Catel;
using Catel.Services;
using WolvenKit.Common.Services;
using WolvenKit.Functionality.Services;
using WolvenKit.Models;


namespace WolvenKit.ViewModels.Editor
{
    public class PropertiesViewModel : ToolViewModel
    {


        private readonly ILoggerService _loggerService;
        private readonly IMessageService _messageService;
        private readonly IProjectManager _projectManager;


        public PropertiesViewModel(
            IProjectManager projectManager,
            ILoggerService loggerService,
            IMessageService messageService
        ) : base(ToolTitle)
        {
            Argument.IsNotNull(() => projectManager);
            Argument.IsNotNull(() => messageService);
            Argument.IsNotNull(() => loggerService);

            _projectManager = projectManager;
            _loggerService = loggerService;
            _messageService = messageService;

            SetupCommands();
            SetupToolDefaults();

            SetToNullAndResetVisibility();
        }


        /// <summary>
        /// Initialize commands for this window.
        /// </summary>
        private void SetupCommands()
        {
        }





        public void SetToNullAndResetVisibility()
        {

            // Asset Browser
            AB_SelectedItem = null;
            AB_FileInfoVisible = false;
            AB_MeshPreviewVisible = false;


            // Project Explorer
            PE_SelectedItem = null;
            PE_FileInfoVisible = false;
            PE_MeshPreviewVisible = false;

        }





        /// <summary>
        /// Selected Item from Project Explorer If Available.
        /// </summary>
        public FileModel PE_SelectedItem { get; set; }

        /// <summary>
        /// Selected Item from Asset Browser If Available.
        /// </summary>
        public Common.Model.AssetBrowserData AB_SelectedItem { get; set; }



        /// <summary>
        /// Decides if Asset browser Selected File info should be visible.
        /// </summary>
        public bool AB_FileInfoVisible { get; set; }

        /// <summary>
        /// Decides if Project Explorer Selected file info should be Visible.
        /// </summary>
        public bool PE_FileInfoVisible { get; set; }


        /// <summary>
        /// Decides if Asset browser Mesh preview should be visible.
        /// </summary>
        public bool AB_MeshPreviewVisible { get; set; }

        /// <summary>
        /// Decides if Project Explorer Mesh preview should be visible.
        /// </summary>
        public bool PE_MeshPreviewVisible { get; set; }


        /// <summary>
        /// Decides if the mesh previewer Tab should be visible or not.
        /// </summary>
        public bool IsMeshPreviewVisible { get; set; }


        public void DecideForMeshPreview()
        {
            if (AB_MeshPreviewVisible)
            { IsMeshPreviewVisible = true; }
            else if (PE_MeshPreviewVisible)
            { IsMeshPreviewVisible = true; }
            else
            { IsMeshPreviewVisible = false; }
        }




        #region ToolViewModel
        /// <summary>
        /// Initialize Syncfusion specific defaults that are specific to this tool window.
        /// </summary>
        private void SetupToolDefaults() => ContentId = ToolContentId;

        /// <summary>
        /// Identifies the <see ref="ContentId"/> of this tool window.
        /// </summary>
        public const string ToolContentId = "Properties_Tool";

        /// <summary>
        /// Identifies the caption string used for this tool window.
        /// </summary>
        public const string ToolTitle = "Properties";
        #endregion


    }
}
