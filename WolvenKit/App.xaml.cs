using System.Windows;
using Catel.Logging;
using NodeNetwork;
using WolvenKit.Functionality.WKitGlobal.Helpers;

namespace WolvenKit
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region constructors

        // Main Constructor
        static App()
        {
        }

        // Alternative Constructor
        public App()
        {
        }

        #endregion constructors

        // Get Logger.
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        protected override async void OnStartup(StartupEventArgs e)
        {
#if DEBUG
            LogManager.AddDebugListener();
#endif
            Log.Info("Starting application");
            Log.Info("Initializing MVVM");
            await AppHelper.InitializeMVVM();
            Log.Info("Initializing Theme Helper");
            ThemeHelper.InitializeThemeHelper();
            Log.Info("Initializing Shell");
            await AppHelper.InitializeShell();
            AppHelper.ShowFirstTimeSetup();
            Log.Info("Initializing Discord RPC");
            DiscordHelper.InitializeDiscordRPC();
            Log.Info("Initializing Github");
            GithubHelper.InitializeGitHub();
            Log.Info("Calling base.OnStartup");
            base.OnStartup(e);
            Log.Info("Initializing NodeNetwork");
            NNViewRegistrar.RegisterSplat();
            NotificationHelper.InitializeNotificationHelper();

            // Temp Fix for MainViewModel.OnClosing
            if (MainWindow != null)
            {
                MainWindow.Closing += OnClosing;
            }
        }

        // TODO: add closing logic here for now since MainViewModel.OnClosing isn't realiable. Investigate this
        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e) => StaticReferences.MainView.OnSaveLayout();
    }
}
