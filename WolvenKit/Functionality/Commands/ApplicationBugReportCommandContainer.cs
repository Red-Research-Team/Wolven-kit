using System;
using Catel;
using Catel.MVVM;
using Catel.Services;
using Orc.ProjectManagement;
using Orchestra.Services;
using WolvenKit.Common.Services;
using WolvenKit.Functionality.WKitGlobal;
using WolvenKit.MVVM.ViewModels.Others;
using WolvenKit.MVVM.Views.Components.Wizards;
using WolvenKit.ViewModels;

namespace WolvenKit.Functionality.Commands
{
    public class ApplicationBugReportCommandContainer : CommandContainerBase
    {
        #region Fields

        private readonly ILoggerService _loggerService;
        private readonly IMessageService _messageService;
        private readonly INavigationService _navigationService;
        private readonly ISaveFileService _saveFileService;
        private readonly IUIVisualizerService _uIVisualizerService;
        private readonly IViewModelFactory _viewModelFactory;

        #endregion Fields

        #region Constructors

        public ApplicationBugReportCommandContainer(
            ICommandManager commandManager,
            INavigationService navigationService,
            IProjectManager projectManager,
            ISaveFileService saveFileService,
            IGrowlNotificationService notificationService,
            IUIVisualizerService uIVisualizerService,
            IViewModelFactory viewModelFactory,
            IMessageService messageService,
            ILoggerService loggerService)
            : base(AppCommands.Application.BugReport, commandManager)
        {
            Argument.IsNotNull(() => navigationService);
            Argument.IsNotNull(() => loggerService);
            Argument.IsNotNull(() => saveFileService);

            _navigationService = navigationService;
            _loggerService = loggerService;
            _saveFileService = saveFileService;
            _uIVisualizerService = uIVisualizerService;
            _viewModelFactory = viewModelFactory;
            _messageService = messageService;
        }

        #endregion Constructors

        #region Methods

        protected override bool CanExecute(object parameter) => true;

        protected override async void Execute(object parameter)
        {
            try
            {
                var vm = new UserControlHostWindowViewModel(new BugReportWizard(), 600, 1000);

                var result = await _uIVisualizerService.ShowDialogAsync(vm);
            }
            catch (Exception ex)
            {
                _loggerService.LogString(ex.Message, Logtype.Error);
                _loggerService.LogString("Failed to create new project.", Logtype.Error);
            }
        }

        #endregion Methods
    }
}
