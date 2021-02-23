﻿using Catel;
using Catel.Data;
using Catel.Fody;
using Catel.IoC;
using Catel.MVVM;
using WolvenKit.Model.Wizards;
using WolvenKit.Services;

namespace WolvenKit.ViewModels.Wizards.WizardPages.FirstSetupWizard
{
    class LocateGameDataViewModel : ViewModelBase
    {
        #region constructors
        public LocateGameDataViewModel(IServiceLocator serviceLocator)
        {
            Argument.IsNotNull(() => serviceLocator);

            SettingsManager = serviceLocator.ResolveType<ISettingsManager>();
            FirstSetupWizardViewModel = serviceLocator.ResolveType<FirstSetupWizardViewModel>();
            FirstSetupWizardModel = serviceLocator.ResolveType<FirstSetupWizardModel>();
        }
        #endregion

        #region properties
        /// <summary>
        /// Gets or sets the SettingsManager.
        /// </summary>
        [Model]
        [Expose("DepotPath")]
        public ISettingsManager SettingsManager
        {
            get { return GetValue<ISettingsManager>(SettingsManagerProperty); }
            set { SetValue(SettingsManagerProperty, value); }
        }

        /// <summary>
        /// Gets or sets the FirstSetupWizardViewModel.
        /// </summary>
        [Model]
        [Expose("W3ExePath")]
        [Expose("WccLitePath")]
        [Expose("CP77ExePath")]
        public FirstSetupWizardViewModel FirstSetupWizardViewModel
        {
            get { return GetValue<FirstSetupWizardViewModel>(FirstSetupWizardViewModelProperty); }
            set { SetValue(FirstSetupWizardViewModelProperty, value); }
        }

        /// <summary>
        /// Gets or sets the FirstSetupWizardModel.
        /// </summary>
        [Model]
        [Expose("CreateModForW3")]
        [Expose("CreateModForCP77")]
        public FirstSetupWizardModel FirstSetupWizardModel
        {
            get { return GetValue<FirstSetupWizardModel>(ProjectWizardModelProperty); }
            set { SetValue(ProjectWizardModelProperty, value); }
        }


        /// <summary>
        /// Register the SettingsManager property so it is known in the class.
        /// </summary>
        public static readonly PropertyData SettingsManagerProperty = RegisterProperty("SettingsManager", typeof(ISettingsManager));

        /// <summary>
        /// Register the FirstSetupWizardViewModel property so it is known in the class.
        /// </summary>
        public static readonly PropertyData FirstSetupWizardViewModelProperty = RegisterProperty("FirstSetupWizardViewModel", typeof(FirstSetupWizardViewModel));

        /// <summary>
        /// Register the FirstSetupWizardModel property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ProjectWizardModelProperty = RegisterProperty("FirstSetupWizardModel", typeof(FirstSetupWizardModel));
        #endregion properties
    }
}
