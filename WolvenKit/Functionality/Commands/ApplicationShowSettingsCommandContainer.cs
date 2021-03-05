using Catel.MVVM;
using WolvenKit.Functionality.WKitGlobal;
using WolvenKit.Functionality.WKitGlobal.Helpers;
using WolvenKit.MVVM.ViewModels.Shell.HomePage;
using WolvenKit.MVVM.Views.Shell.HomePage;

namespace WolvenKit.Functionality.Commands
{
    internal class ApplicationShowSettingsCommandContainer : Catel.MVVM.CommandContainerBase
    {
        #region Constructors

        public ApplicationShowSettingsCommandContainer(ICommandManager commandManager)
            : base(AppCommands.Application.ShowSettings, commandManager)
        {
        }

        #endregion Constructors

        #region Methods

        protected override void Execute(object parameter)
        {
            StaticReferences.RibbonViewInstance.startScreen.SetCurrentValue(Fluent.Backstage.IsOpenProperty, false);
            StaticReferences.RibbonViewInstance.startScreen.SetCurrentValue(Fluent.StartScreen.ShownProperty, false);
            StaticReferences.RibbonViewInstance.startScreen.SetCurrentValue(Fluent.Backstage.IsOpenProperty, true);
            HomePageView.GlobalHomePage.PageViewGrid.Children.Clear();
            HomePageView.GlobalHomePage.PageViewGrid.Children.Add(HomePageViewModel.GlobalHomePageVM.SettingsPV);
        }

        #endregion Methods
    }
}
