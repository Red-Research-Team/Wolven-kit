using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Catel.IoC;
using CP77.CR2W;
using Syncfusion.UI.Xaml.Grid;
using WolvenKit.Common;
using WolvenKit.Common.DDS;
using WolvenKit.Common.Model.Arguments;
using WolvenKit.Functionality.Ab4d;
using WolvenKit.Functionality.Helpers;
using WolvenKit.Functionality.WKitGlobal.Helpers;
using WolvenKit.Modkit.RED4;
using WolvenKit.ViewModels.Editor;
using SelectionChangedEventArgs = System.Windows.Controls.SelectionChangedEventArgs;

namespace WolvenKit.Views.Editor
{
    public partial class AssetBrowserView : INotifyPropertyChanged
    {


        public static AssetBrowserView GlobalABView;
        public AssetBrowserView()
        {
            InitializeComponent();
            NotifyPropertyChanged();
            TreeNavSF.DrillDownItems.CollectionChanged += DrillDownItems_CollectionChanged;
            VisibleBackButton.SetCurrentValue(VisibilityProperty, Visibility.Hidden);
            GlobalABView = this;


        }

        protected override void OnViewModelChanged()
        {
            if (ViewModel is AssetBrowserViewModel vm)
            {
                vm.SelectItemInTreeNavSF += (obj) =>
                {
                    TreeNavSF.SetCurrentValue(Syncfusion.Windows.Controls.Navigation.SfTreeNavigator.SelectedItemProperty, obj);
                };
                vm.GoBackInTreeNavSF += () =>
                {
                    TreeNavSF.GoBack();
                    if (TreeNavSF.DrillDownItem.Header as string == "Depot")
                    {
                        VisibleBackButton.SetCurrentValue(VisibilityProperty, Visibility.Hidden);

                    }
                };
                vm.GoToRootInTreeNavSF += () =>
                {
                    // ? :)
                };
            }
        }

        private void DrillDownItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        public new event PropertyChangedEventHandler PropertyChanged;



        private void DraggableTitleBar_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) => base.OnMouseLeftButtonDown(e);

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (DataContext is AssetBrowserViewModel vm)
            {
                vm.CurrentNode = e.NewValue as GameFileTreeNode;
                vm.CurrentNodeFiles = (e.NewValue as GameFileTreeNode)?.ToAssetBrowserData();
                //vm.NavigateTo(vm.CurrentNode.FullPath);
            }
        }

        private void ListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }


        private void SfTreeNavigator_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is AssetBrowserViewModel vm)
            {
                if (TreeNavSF.DrillDownItem.Header as string != "Depot")
                {
                    VisibleBackButton.SetCurrentValue(VisibilityProperty, Visibility.Visible);
                }

                vm.CurrentNode = TreeNavSF.SelectedItem as GameFileTreeNode;
                vm.CurrentNodeFiles = (TreeNavSF.SelectedItem as GameFileTreeNode)?.ToAssetBrowserData();
            }
        }



        private void Border_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (DataContext is AssetBrowserViewModel vm)
            {
                if (TreeNavSF.DrillDownItem.Header as string != "Depot")
                {
                    TreeNavSF.GoBack();
                    if (TreeNavSF.DrillDownItem.Header as string == "Depot")
                    {
                        vm.CurrentNode = vm.RootNode;
                        vm.CurrentNodeFiles = vm.RootNode.ToAssetBrowserData();
                        VisibleBackButton.SetCurrentValue(VisibilityProperty, Visibility.Hidden);
                    }
                    else
                    {
                        vm.CurrentNode = TreeNavSF.DrillDownItem.Header as GameFileTreeNode;
                        vm.CurrentNodeFiles = (TreeNavSF.DrillDownItem.Header as GameFileTreeNode)?.ToAssetBrowserData();
                    }
                }
            }
        }

        private void SearchBar_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (string.Equals(SBBar.Text, "Search", System.StringComparison.OrdinalIgnoreCase))
            {
                SBBar.SetCurrentValue(TextBox.TextProperty, "");
            }
        }

        private void SBBar_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (string.Equals(SBBar.Text, "Search", System.StringComparison.OrdinalIgnoreCase))
            {
                SBBar.SetCurrentValue(TextBox.TextProperty, "");
            }
        }

        static readonly int FileImportLimit = 100;
        static int idx = 0;

        private void executeFile(AssetBrowserViewModel vm, Common.Model.AssetBrowserData selectedData)
        {
            switch (selectedData.Type)
            {
                case Common.Model.EntryType.Directory:
                {
                    foreach (var data in selectedData.Children.ToAssetBrowserData())
                    {
                        executeFile(vm, data);
                    }
                    break;
                }
                case Common.Model.EntryType.File:
                {
                    if (idx >= FileImportLimit)
                        return;
                    idx++;
                    vm.SelectedNode = selectedData;
                    vm.ImportFileCommand.Execute(selectedData);
                    break;
                }
            }
        }

        public void RevampedImport()
        {

            var vm = ViewModel as AssetBrowserViewModel;
            if (vm != null)
            {
                idx = 0;
                foreach (var selectedItem in InnerList.SelectedItems)
                {
                    var selectedData = selectedItem as Common.Model.AssetBrowserData;
                    if (selectedData == null)
                        continue;
                    executeFile(vm, selectedData);
                }
            }
        }

        private void MenuItem_ImportSelected_Click(object sender, RoutedEventArgs e)
        {
            var mi = sender as MenuItem;
            if (mi?.DataContext is GridRecordContextMenuInfo gridRecordContextMenuInfo && ViewModel is AssetBrowserViewModel vm)
            {
                idx = 0;
                foreach (var selectedItem in gridRecordContextMenuInfo.DataGrid.SelectedItems)
                {
                    var selectedData = selectedItem as Common.Model.AssetBrowserData;
                    if (selectedData == null)
                        continue;
                    executeFile(vm, selectedData);
                }
            }
        }

        private async void InnerList_SelectionChanged(object sender, Syncfusion.UI.Xaml.Grid.GridSelectionChangedEventArgs e)
        {
            if (StaticReferences.GlobalPropertiesView == null)
            {
                return;
            }

            if (ViewModel is not AssetBrowserViewModel vm)
            {
                return;
            }

            var propertiesViewModel = ServiceLocator.Default.ResolveType<PropertiesViewModel>();
            propertiesViewModel.AB_SelectedItem = vm.SelectedNode;

            propertiesViewModel.AB_MeshPreviewVisible = false;
            propertiesViewModel.IsAudioPreviewVisible = false;
            propertiesViewModel.IsImagePreviewVisible = false;

            if (propertiesViewModel.AB_SelectedItem != null)
            {
                if (string.Equals(propertiesViewModel.AB_SelectedItem.GetExtension(), ERedExtension.mesh.ToString(),
                    System.StringComparison.OrdinalIgnoreCase))
                {
                    propertiesViewModel.AB_MeshPreviewVisible = true;

                    if (propertiesViewModel.AB_SelectedItem.AmbigiousFiles != null)
                    {
                        var q = propertiesViewModel.AB_SelectedItem.AmbigiousFiles.FirstOrDefault();
                        if (q != null)
                        {

                            string WKitAppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "REDModding", "WolvenKit");

                            string ManagerCacheDir = Path.Combine(WKitAppData, "Temp_Mesh");
                            Directory.CreateDirectory(ManagerCacheDir);
                            foreach (var f in Directory.GetFiles(ManagerCacheDir))
                            {
                                try
                                { File.Delete(f); }
                                catch
                                {
                                }
                            }

                            var endPath = Path.Combine(ManagerCacheDir, Path.GetFileName(q.Name));
                            var q2 = ServiceLocator.Default.ResolveType<MeshTools>().ExportMeshWithoutRigPreviewer(q, endPath);
                            if (q2.Length > 0)
                            {
                                StaticReferences.GlobalPropertiesView.LoadModel(q2);
                            }





                        }
                    }

                }

                if (string.Equals(propertiesViewModel.AB_SelectedItem.GetExtension(), ERedExtension.wem.ToString(),
                    System.StringComparison.OrdinalIgnoreCase))
                {
                    propertiesViewModel.IsAudioPreviewVisible = true;

                    if (propertiesViewModel.AB_SelectedItem.AmbigiousFiles != null)
                    {
                        var q = propertiesViewModel.AB_SelectedItem.AmbigiousFiles.FirstOrDefault();
                        if (q != null)
                        {


                            string WKitAppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "REDModding", "WolvenKit");

                            string ManagerCacheDir = Path.Combine(WKitAppData, "Temp_Audio_import");
                            string EndPath = Path.Combine(ManagerCacheDir, Path.GetFileName(q.Name));
                            Directory.CreateDirectory(ManagerCacheDir);
                            foreach (var f in Directory.GetFiles(ManagerCacheDir))
                            {
                                try
                                { File.Delete(f); }
                                catch
                                {
                                }
                            }
                            using var fs = new FileStream(EndPath, FileMode.Create, FileAccess.Write);
                            q.Extract(fs);


                            if (File.Exists(EndPath))
                            {
                                Trace.WriteLine("adding audio file");
                                propertiesViewModel.AddAudioItem(EndPath);

                            }

                        }
                    }
                }

                if (string.Equals(propertiesViewModel.AB_SelectedItem.GetExtension(), ERedExtension.xbm.ToString(),
                                            System.StringComparison.OrdinalIgnoreCase))
                {
                    propertiesViewModel.IsImagePreviewVisible = true;

                    var q = propertiesViewModel.AB_SelectedItem.AmbigiousFiles?.FirstOrDefault();
                    if (q != null)
                    {
                        var man = ServiceLocator.Default.ResolveType<ModTools>();

                        // extract cr2w to stream
                        await using var cr2wstream = new MemoryStream();
                        q.Extract(cr2wstream);

                        // convert xbm to dds stream
                        await using var ddsstream = new MemoryStream();
                        var expargs = new XbmExportArgs {Flip = false, UncookExtension = EUncookExtension.dds};
                        man.UncookXbm(cr2wstream, ddsstream, out _);

                        // try loading it in pfim
                        try
                        {
                            var qa = await ImageDecoder.RenderToBitmapSourceDds(ddsstream);
                            if (qa != null)
                            {
                                var g = BitmapFrame.Create(qa);
                                StaticReferences.GlobalPropertiesView.LoadImage(g);
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            propertiesViewModel.DecideForMeshPreview();
        }
    }
}
