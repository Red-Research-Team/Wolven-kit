using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Catel.IoC;
using CP77.CR2W;
using Microsoft.WindowsAPICodePack.Dialogs;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.TreeGrid;
using WolvenKit.Common;
using WolvenKit.Common.DDS;
using WolvenKit.Functionality.Ab4d;
using WolvenKit.Functionality.Helpers;
using WolvenKit.Functionality.WKitGlobal.Helpers;
using WolvenKit.Models;
using WolvenKit.ViewModels.Editor;
using WolvenKit.Views.Dialogs;

namespace WolvenKit.Views.Editor
{
    /// <summary>
    /// Interaction logic for ProjectExplorerView.xaml
    /// </summary>
    public partial class ProjectExplorerView
    {
        #region Constructors

        public static ProjectExplorerView GlobalPEView;

        public ProjectExplorerView()
        {
            InitializeComponent();
            GlobalPEView = this;

            TreeGrid.ItemsSourceChanged += TreeGrid_ItemsSourceChanged;
        }

        private void TreeGrid_ItemsSourceChanged(object sender, TreeGridItemsSourceChangedEventArgs e)
        {
            if (TreeGrid.View != null)
            {
                TreeGrid.View.NodeCollectionChanged += View_NodeCollectionChanged;
            }
        }

        private void View_NodeCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //if (e.NewItems != null)
            //{
            //    foreach (var nerd in e.NewItems)
            //    {
            //        Trace.WriteLine(nerd.ToString());
            //        TreeGrid.ExpandNode((TreeNode)nerd);
            //    }
            //}

            if (ViewModel is not ProjectExplorerViewModel viewModel)
            {
                return;
            }

            var rootnodes = TreeGrid.View.Nodes.RootNodes;
            foreach (var rootnode in rootnodes)
            {
                TreeGrid.ExpandNode(rootnode);
            }


            Trace.WriteLine(e.Action.ToString());
        }

        protected override void OnViewModelPropertyChanged(PropertyChangedEventArgs e)
        {
            if (ViewModel is not ProjectExplorerViewModel viewModel)
            {
                return;
            }

            var name = e.PropertyName;
            switch (name)
            {
                case nameof(viewModel.IsTreeBeingEdited):
                    if (viewModel.IsTreeBeingEdited)
                    {
                        TreeGrid.View.BeginInit(TreeViewRefreshMode.DeferRefresh);
                    }
                    else
                    {
                        TreeGrid.View.EndInit();
                    }
                    break;
            }
        }

        #endregion Constructors

        public void ExpandChildren()
        {
            if (ViewModel is not ProjectExplorerViewModel viewModel)
            {
                return;
            }

            var model = viewModel.SelectedItem;
            var node = TreeGrid.View.Nodes.GetNode(model);
            TreeGrid.ExpandAllNodes(node);
        }

        private void ExpandChildren_OnClick(object sender, RoutedEventArgs e) => ExpandChildren();

        public void CollapseChildren()
        {
            if (ViewModel is not ProjectExplorerViewModel viewModel)
            {
                return;
            }

            var model = viewModel.SelectedItem;
            var node = TreeGrid.View.Nodes.GetNode(model);
            TreeGrid.CollapseAllNodes(node);
        }

        private void CollapseChildren_OnClick(object sender, RoutedEventArgs e) => CollapseChildren();

        public void ExpandAll() => TreeGrid.ExpandAllNodes();

        public void CollapseAll() => TreeGrid.CollapseAllNodes();

        private void ExpandAll_OnClick(object sender, RoutedEventArgs e) => ExpandAll();

        private void CollapseAll_OnClick(object sender, RoutedEventArgs e) => CollapseAll();
    }
}
