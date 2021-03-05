using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using Catel.Data;
using Catel.IoC;
using Fluent;
using Orchestra;
using Orchestra.Services;
using WolvenKit.Functionality.WKitGlobal.Helpers;
using WolvenKit.MVVM.Views.Components.Editors;
using WolvenKit.MVVM.Views.Components.Editors.VisualEditor;
using WolvenKit.MVVM.Views.Components.Tools;
using WolvenKit.MVVM.Views.Components.Tools.AudioTool;

namespace WolvenKit.MVVM.Views.Shell.Editor
{
    public partial class RibbonView
    {
        public RibbonView()
        {
            InitializeComponent();

            ribbon.AddAboutButton();

            StaticReferences.RibbonViewInstance = this;
        }

        protected override void OnViewModelChanged() => base.OnViewModelChanged();

#pragma warning disable WPF0041
        //backstageTabControl.DataContext = ViewModel;
#pragma warning restore WPF0041

        protected override void OnViewModelPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnViewModelPropertyChanged(e);

            if (e is not AdvancedPropertyChangedEventArgs property)
            {
                return;
            }

            switch (property.PropertyName)
            {
                case "SelectedTheme":
                    if (property.NewValue is Color themename)
                    {
                        //wtf is this even
                    }

                    break;

                default:
                    break;
            }
        }

        private void ShowStartScreen_OnClick(object sender, RoutedEventArgs e) // Convert me to MVVM
        {
            // Nope we dont do that here . And I am not removing this >:) lol
        }

        private void CBAssetBrowserItem_Selected(object sender, RoutedEventArgs e)
        {
        }

        private void CBCodeEditorItem_Selected(object sender, RoutedEventArgs e)
        {
            var codeeditor = new CodeEditorView();
        }

        private void CBPluginManager_Selected(object sender, RoutedEventArgs e)
        {
            var pluginmanager = new PluginManagerView();
        }

        private void CBVisualEditorItem_Selected(object sender, RoutedEventArgs e)
        {
            var visualeditor = new VisualEditorView();
        }

        private void CBAudioToolItem_Selected(object sender, RoutedEventArgs e)
        {
            var audiotool = new AudioToolView();
        }

        private void CBJournalEditorItem_Selected(object sender, RoutedEventArgs e)
        {
            //  JournalEditorView journaleditor = new JournalEditorView();
            //   journaleditor.Show();
        }

        private void Backstage_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            var serviceLocator = ServiceLocator.Default;

            var shellService = serviceLocator.ResolveType<IShellService>();

            StaticReferences.GlobalShell.DragMove();
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsVisible && IsLoaded)
            {
                DiscordHelper.SetDiscordRPCStatus("Ribbon/Backstage");
            }
        }

        private void Border_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var brush = (Brush)App.Current.FindResource("MahApps.Brushes.Accent3");

            HomeHighLighter.SetCurrentValue(System.Windows.Controls.Panel.BackgroundProperty, brush);
        }

        private void Border_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var brush = (Brush)App.Current.FindResource("MahApps.Brushes.AccentBase");

            HomeHighLighter.SetCurrentValue(System.Windows.Controls.Panel.BackgroundProperty, brush);
        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            StaticReferences.RibbonViewInstance.startScreen.SetCurrentValue(StartScreen.ShownProperty, false);
            StaticReferences.RibbonViewInstance.startScreen.SetCurrentValue(Fluent.Backstage.IsOpenProperty, true);
        }

        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            // No
        }
    }
}
