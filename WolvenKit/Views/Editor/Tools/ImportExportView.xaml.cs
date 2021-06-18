using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using Catel.IoC;
using Syncfusion.Windows.PropertyGrid;
using WolvenKit.Common;
using WolvenKit.Common.DDS;
using WolvenKit.Common.Model.Arguments;
using WolvenKit.Functionality.Commands;
using WolvenKit.Functionality.Helpers;
using WolvenKit.RED4.CR2W.Types;
using WolvenKit.ViewModels.Editor;

namespace WolvenKit.Views.Editor
{
    public partial class ImportExportView
    {
        /// <summary>
        /// Constructor I/E Tool.
        /// </summary>
        public ImportExportView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Item Double Clicked ExportGrid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SfDataGrid_CellDoubleTapped(object sender, Syncfusion.UI.Xaml.Grid.GridCellDoubleTappedEventArgs e)
        {
            if (ViewModel is not ImportExportViewModel vm)
            {
                return;
            }
            if (vm.IsImportsSelected)
            {
                if (ImportGrid.SelectedItem is ImportExportItemViewModel selectedImport)
                {
                    if (Enum.TryParse(selectedImport.Extension.TrimStart('.'), out ERawFileFormat _))
                    {
                        XAML_AdvancedOptionsOverlay.SetCurrentValue(VisibilityProperty, System.Windows.Visibility.Visible);
                        XAML_AdvancedOptionsExtension.SetCurrentValue(System.Windows.Controls.TextBlock.TextProperty, selectedImport.Extension);
                        XAML_AdvancedOptionsFileName.SetCurrentValue(System.Windows.Controls.TextBlock.TextProperty, selectedImport.Name);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
            }
            else
            {
                if (ExportGrid.SelectedItem is ImportExportItemViewModel selectedExport)
                {
                    if (Enum.TryParse(selectedExport.Extension.TrimStart('.'), out ECookedFileFormat _))
                    {
                        XAML_AdvancedOptionsOverlay.SetCurrentValue(VisibilityProperty, System.Windows.Visibility.Visible);
                        XAML_AdvancedOptionsExtension.SetCurrentValue(System.Windows.Controls.TextBlock.TextProperty, selectedExport.Extension);
                        XAML_AdvancedOptionsFileName.SetCurrentValue(System.Windows.Controls.TextBlock.TextProperty, selectedExport.Name);
                    }
                    else
                    { throw new ArgumentOutOfRangeException(); }
                }
            }
        }

        /// <summary>
        /// Confirm Button (Advanced Options)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (ViewModel is ImportExportViewModel vm)
            {
                if (ApplyToAllCheckbox.IsChecked != null && ApplyToAllCheckbox.IsChecked.Value)
                {
                    vm.CopyArgumentsTemplateToCommand.SafeExecute("All in Grid");
                    ApplyToAllCheckbox.SetCurrentValue(System.Windows.Controls.Primitives.ToggleButton.IsCheckedProperty, false);
                }
            }
            XAML_AdvancedOptionsOverlay.SetCurrentValue(VisibilityProperty, Visibility.Collapsed);
        }

        /// <summary>
        /// Cancel Button (Select additional files)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelSelectingClick(object sender, RoutedEventArgs e) => XAML_FileSelectingOverlay.SetCurrentValue(VisibilityProperty, Visibility.Collapsed);

        private PropertyItem _propertyItem;

        /// <summary>
        /// Override PG Collection Editor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PropertyGrid_CollectionEditorOpening(object sender, Syncfusion.Windows.PropertyGrid.CollectionEditorOpeningEventArgs e)
        {
            if (ViewModel is ImportExportViewModel vm && sender is PropertyGrid pg)
            {
                _propertyItem = pg.SelectedPropertyItem;
                vm.SetCollectionCommand.SafeExecute(_propertyItem.Name);
                //if (vm.SelectedExport.Extension == nameof(ECookedFileFormat.mesh))
                //{
                //    FileSelectionDataGrid.SetCurrentValue(Syncfusion.UI.Xaml.Grid.SfDataGrid.ItemsSourceProperty, vm.MeshExportAvailableCollection);
                //    SelectedFilesGrid.SetCurrentValue(Syncfusion.UI.Xaml.Grid.SfDataGrid.ItemsSourceProperty, vm.MeshExportSelectedCollection);
                //}
                //if (vm.SelectedExport.Extension == nameof(ECookedFileFormat.opusinfo))
                //{
                //    FileSelectionDataGrid.SetCurrentValue(Syncfusion.UI.Xaml.Grid.SfDataGrid.ItemsSourceProperty, vm.OpusExportAvailableCollection);
                //    SelectedFilesGrid.SetCurrentValue(Syncfusion.UI.Xaml.Grid.SfDataGrid.ItemsSourceProperty, vm.OpusExportSelectedCollection);
                //}
            }

            e.Cancel = true;
            XAML_FileSelectingOverlay.SetCurrentValue(VisibilityProperty, Visibility.Visible);
        }

        private void Button_Click(object sender, RoutedEventArgs e) => HelpOverlay.SetCurrentValue(VisibilityProperty, Visibility.Visible);

        private void Button_Click_1(object sender, RoutedEventArgs e) => HelpOverlay.SetCurrentValue(VisibilityProperty, Visibility.Collapsed);

        private void ConfirmCollectionEditorSelection_OnClick(object sender, RoutedEventArgs e)
        {
            XAML_FileSelectingOverlay.SetCurrentValue(VisibilityProperty, Visibility.Collapsed);
            if (ViewModel is ImportExportViewModel vm)
            {
                vm.ConfirmMeshCollectionCommand.SafeExecute(_propertyItem.Name);
            }
        }

        private void AddItemsButtonClick(object sender, RoutedEventArgs e)
        {
            if (ViewModel is ImportExportViewModel vm)
            {
                vm.AddItemsCommand.SafeExecute(FileSelectionDataGrid.SelectedItems);
            }
        }

        private void RemoveItemsButtonClick(object sender, RoutedEventArgs e)
        {
            if (ViewModel is ImportExportViewModel vm)
            {
                vm.RemoveItemsCommand.SafeExecute(SelectedFilesGrid.SelectedItems);
            }
        }
    }
}
