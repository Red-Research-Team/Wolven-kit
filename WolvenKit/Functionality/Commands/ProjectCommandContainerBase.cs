// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectCommandContainerBase.cs" company="WildGums">
//   Copyright (c) 2008 - 2017 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Threading.Tasks;
using Catel;
using Catel.IoC;
using Catel.MVVM;
using Catel.Services;
using Catel.Threading;
using Orc.ProjectManagement;
using Orchestra.Services;
using WolvenKit.Common.Services;
using WolvenKit.MVVM.Model.ProjectManagement.Project;

namespace WolvenKit.Functionality.Commands
{
    public abstract class ProjectCommandContainerBase : CommandContainerBase
    {
        #region Fields

        protected readonly ICommandManager _commandManager;
        protected readonly ILoggerService _logger;
        protected readonly IGrowlNotificationService _notificationService;
        protected readonly IPleaseWaitService _pleaseWaitService;
        protected readonly IProjectManager _projectManager;

        #endregion Fields

        #region Constructors

        protected ProjectCommandContainerBase(string commandName,
            ICommandManager commandManager,
            IProjectManager projectManager,
            IGrowlNotificationService notificationService,
            ILoggerService loggerService)
            : base(commandName, commandManager)
        {
            Argument.IsNotNull(() => projectManager);
            Argument.IsNotNull(() => loggerService);
            Argument.IsNotNull(() => notificationService);

            _commandManager = commandManager;
            _projectManager = projectManager;
            _logger = loggerService;
            _notificationService = notificationService;

            _pleaseWaitService = ServiceLocator.Default.ResolveType<IPleaseWaitService>();

            _projectManager.ProjectActivatedAsync += OnProjectActivatedAsync;
        }

        #endregion Constructors

        #region Methods

        protected override bool CanExecute(object parameter)
        {
            if (_projectManager.ActiveProject == null)
            {
                return false;
            }

            return base.CanExecute(parameter);
        }

        protected virtual async Task ProjectActivated(EditorProject oldEditorProject, EditorProject newEditorProject)
        {
            if (newEditorProject == null)
            {
                return;
            }

            await Task.Run(() => newEditorProject.Initialize());
        }

        private Task OnProjectActivatedAsync(object sender, ProjectUpdatedEventArgs e)
        {
            //Task.Run(() => ProjectActivated((EditorProject) e.OldProject, (EditorProject) e.NewProject));
            var asd = ProjectActivated((EditorProject)e.OldProject, (EditorProject)e.NewProject);

            //TODO: why is that here?
            _commandManager.InvalidateCommands();

            return TaskHelper.Completed;
        }

        #endregion Methods
    }
}
