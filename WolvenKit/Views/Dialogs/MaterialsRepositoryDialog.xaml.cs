using Catel.IoC;
using CP77.CR2W;
using Microsoft.WindowsAPICodePack.Dialogs;
using WolvenKit.Functionality.Services;
using ModTools = WolvenKit.Modkit.RED4.ModTools;

namespace WolvenKit.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for MaterialsRepositoryDialog.xaml
    /// </summary>
    public partial class MaterialsRepositoryDialog : HandyControl.Controls.Window
    {
        public MaterialsRepositoryDialog()
        {
            InitializeComponent();
            if (ServiceLocator.Default.ResolveType<ISettingsManager>().MaterialRepositoryPath != "")
            {
                archivestext.Text = ServiceLocator.Default.ResolveType<ISettingsManager>().MaterialRepositoryPath;

            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ServiceLocator.Default.ResolveType<ISettingsManager>().MaterialRepositoryPath = archivestext.Text;
            var modTools = ServiceLocator.Default.ResolveType<ModTools>();
            modTools.GenerateMaterialRepo(new System.IO.DirectoryInfo(archivestext.Text), new System.IO.DirectoryInfo(Materialsrepotext.Text), Common.DDS.EUncookExtension.dds);
        }

        private void GenerateMaterials(object obj)
        {
        }

        private void matsbutton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Materialsrepotext.SetCurrentValue(System.Windows.Controls.TextBox.TextProperty, dialog.FileName);
            }
        }

        private void archivespathbutt_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                archivestext.SetCurrentValue(System.Windows.Controls.TextBox.TextProperty, dialog.FileName);
            }
        }
    }
}
