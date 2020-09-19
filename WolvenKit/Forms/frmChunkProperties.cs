﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Dfust.Hotkeys;
using WeifenLuo.WinFormsUI.Docking;
using WolvenKit.App;
using WolvenKit.App.Commands;
using WolvenKit.App.Model;
using WolvenKit.App.ViewModels;
using WolvenKit.Common.Services;
using WolvenKit.CR2W;
using WolvenKit.CR2W.Editors;
using WolvenKit.CR2W.Reflection;
using WolvenKit.CR2W.Types;
using WolvenKit.Services;

namespace WolvenKit.Forms
{
    public partial class frmChunkProperties : DockContent, IThemedContent
    {
        private bool showOnlySerialized = true;
        private HotkeyCollection hotkeys;
        private readonly DocumentViewModel viewModel;

        public frmChunkProperties(DocumentViewModel _viewmodel)
        {
            InitializeComponent();
            ApplyCustomTheme();

            treeView.CanExpandGetter = x =>
            {
                var root = showOnlySerialized
                    ? ((IEditableVariable)x).GetEditableVariables().Where(_ => _.IsSerialized)
                    : ((IEditableVariable)x).GetEditableVariables();
                return root.Any();
            };
            treeView.ChildrenGetter = x =>
            {
                var root = showOnlySerialized
                    ? ((IEditableVariable)x).GetEditableVariables().Where(_ => _.IsSerialized)
                    : ((IEditableVariable)x).GetEditableVariables();
                return root;
            };

            toolStripButtonShowSerialized.Text = showOnlySerialized
                ? "Show all variables"
                : "Show edited variables";

            hotkeys = new HotkeyCollection(Dfust.Hotkeys.Enums.Scope.Application);
            //hotkeys.RegisterHotkey(Keys.Control | Keys.C, HKCopy, "Copy");
            //hotkeys.RegisterHotkey(Keys.Control | Keys.V, HKPaste, "Paste");

            hotkeys.RegisterHotkey(Keys.Oemplus, AddListElement, "Add Element");
            hotkeys.RegisterHotkey(Keys.Add, AddListElement, "Add Element");

            hotkeys.RegisterHotkey(Keys.OemMinus, RemoveListElement, "Add Element");
            hotkeys.RegisterHotkey(Keys.Subtract, RemoveListElement, "Add Element");
            //hotkeys.RegisterHotkey(Keys.Delete, RemoveListElement, "Add Element");

            viewModel = _viewmodel;
            viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        #region Properties
        public event EventHandler OnRequestUpdate;
        //public event EventHandler<SelectChunkArgs> OnChunkRequest;
        private CR2WExportWrapper Chunk => viewModel.SelectedChunk;

        private List<IEditableVariable> GetSelectedObjects()
        {
            return (from IEditableVariable item in treeView.SelectedObjects where item != null select item).ToList();
        }
        #endregion


        #region Hotkeys

        //private void HKCopy(HotKeyEventArgs e)
        //{
        //    if (GetSelectedObjects().Count > 0)
        //        CopyController.Source = GetSelectedObjects().First();
        //    //viewModel.CopyVariableCommand.SafeExecute();
        //}

        //private void HKPaste(HotKeyEventArgs e)
        //{
        //    if (GetSelectedObjects().Count > 0)
        //        CopyController.Target = GetSelectedObjects().First();
        //    viewModel.PasteVariableCommand.SafeExecute();
        //}

        #endregion


        #region UI Methods
        private void UpdateTreeListView()
        {
            if (Chunk == null)
            {
                treeView.Roots = null;
                return;
            }

            var root = showOnlySerialized 
                ? Chunk.GetEditableVariables().Where(_ => _.IsSerialized) 
                : Chunk.GetEditableVariables();

            treeView.Roots = root;

            // filter
            this.treeView.ModelFilter = !string.IsNullOrEmpty(toolStripSearchBox.Text.ToUpper()) 
                ? TextMatchFilter.Contains(treeView, toolStripSearchBox.Text.ToUpper()) 
                : null;

            foreach (var treeViewObject in treeView.Objects)
            {
                treeView.Expand(treeViewObject);
                treeView.RefreshObject(treeViewObject);
            }

        }
        private void treeView_CellEditStarting(object sender, CellEditEventArgs e)
        {
            //var variable = (e.RowObject as VariableListNode).Variable;
            if (e.Column.AspectName == "REDValue")
            {
                e.Control = ((IEditableVariable)e.RowObject).GetEditor();
                if (e.Control != null)
                {
                    e.Control.Location = new Point(e.CellBounds.Location.X, e.CellBounds.Location.Y - 1);
                    e.Control.Width = e.CellBounds.Width;
                    //e.Control.ForeColor = Control.Tex
                }
                e.Cancel = e.Control == null;
            }
            else if (e.Column.AspectName == "REDName")
            {
                //Normal textbox is good for this.
            }
            else
            {
                e.Cancel = true;
            }
        }


        private void treeView_CellEditFinished(object sender, CellEditEventArgs e)
        {
            /*            if (chunk.ParentPtr.Reference != null)
                            chunk.SetParentChunkId(chunk.ParentPtr.Reference.ChunkIndex + 1);*/
            //OnRequestUpdate?.Invoke(sender, e);

            // change the model's isserialized property to true when the user edits it,
            // this is to make sure only user-edited properties will get serialized
            var model = e.ListViewItem.RowObject as IEditableVariable;
            if (model is CVariable cvar)
                cvar.SetIsSerialized();

        }
        public void ApplyCustomTheme()
        {
            UIController.Get().ToolStripExtender.SetStyle(toolStrip1, VisualStudioToolStripExtender.VsVersion.Vs2015, UIController.GetTheme());
            toolStripSearchBox.BackColor = UIController.GetPalette().ToolWindowCaptionButtonInactiveHovered.Background;

            this.treeView.BackColor = UIController.GetBackColor();
            this.treeView.AlternateRowBackColor = UIController.GetPalette().OverflowButtonHovered.Background;

            this.treeView.ForeColor = UIController.GetForeColor();

            this.treeView.HeaderFormatStyle = UIController.GetHeaderFormatStyle();
            treeView.UnfocusedSelectedBackColor = UIController.GetPalette().CommandBarToolbarButtonPressed.Background;
        }
        #endregion

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(viewModel.SelectedChunk))
            {
                UpdateTreeListView();
            }
        }


        private void AddListElement(HotKeyEventArgs e)
        {
            var carray = (IEditableVariable)treeView.SelectedObject;
            if (carray == null || !carray.CanAddVariable(null) || !(carray is IArrayAccessor parentarray))
                return;

            // Create new CVariable
            CVariable newvar = CR2WTypeManager.Create(parentarray.Elementtype, "", Chunk.cr2w, carray as CVariable, false);
            switch (newvar)
            {
                case null:
                    return;
                // if a new ptr is created, auto-add new chunks
                case IPtrAccessor ptr:
                {
                    string newChunktype = "";
                    string innerParentType = parentarray.Elementtype.Substring("ptr:".Length);

                    List<string> availableTypes = CR2WManager.GetAvailableTypes(innerParentType);
                    if (availableTypes.Count <= 0)
                        return;
                
                    using (var form = new frmAddChunk(availableTypes))
                    {
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            newChunktype = form.ChunkType;
                        }
                    }

                    if (string.IsNullOrEmpty(newChunktype))
                        return;

                    ptr.Reference = newvar.cr2w.CreateChunk(newChunktype, Chunk);
                    break;
                }
                case IHandleAccessor handle:
                {
                    bool isChunkHandle = true;
                    // check if handle is supposed to be a chunkhandle
                    if (parentarray.Count > 0)
                    {
                        if (parentarray is IList il && il[0] is IHandleAccessor ih)
                        {
                            isChunkHandle = ih.ChunkHandle;
                        }
                    }
                    else
                    {
                        // ask the user?
                        switch (MessageBox.Show(
                            "Please select Yes if this a CHandle to an existing chunk, or No if it is a CHandle to an external source.",
                            "New CHandle",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            case DialogResult.No:
                            {
                                isChunkHandle = false;
                                break;
                            }
                        }
                    }

                    // it is a chunk handle, so create a new chunk
                    if (isChunkHandle)
                    {
                        string newhandletype = "";
                        string innerParentType = parentarray.Elementtype.Substring("handle:".Length);

                        List<string> availableTypes = CR2WManager.GetAvailableTypes(innerParentType);
                        if (availableTypes.Count <= 0)
                            return;

                        using (var form = new frmAddChunk(availableTypes))
                        {
                            var result = form.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                newhandletype = form.ChunkType;
                            }
                        }

                        if (string.IsNullOrEmpty(newhandletype))
                            return;

                        handle.ChunkHandle = true;
                        handle.Reference = newvar.cr2w.CreateChunk(newhandletype, Chunk);
                    }
                    
                    break;
                }
            }

            newvar.IsSerialized = true;

            parentarray.AddVariable(newvar);
            treeView.RefreshObject(carray);
            OnRequestUpdate?.Invoke(null, null);
        }

        private void RemoveListElement(HotKeyEventArgs e)
        {
            // removing variables from arrays
            if (treeView.SelectedObjects.Count <= 0)
                return;

            var parentmodel = treeView.SelectedObjects.Cast<IEditableVariable>().FirstOrDefault()?.ParentVar;
            foreach (IEditableVariable node in treeView.SelectedObjects)
            {
                if (node?.ParentVar == null || !node.ParentVar.CanRemoveVariable(node)) continue;

                switch (node)
                {
                    case IPtrAccessor ptr:
                        node.cr2w.RemoveChunk(ptr.Reference);
                        break;
                    case IHandleAccessor hdl when hdl.ChunkHandle:
                        node.cr2w.RemoveChunk(hdl.Reference);
                        break;
                }

                node.ParentVar.RemoveVariable(node);
                //treeView.RefreshObject(node.ParentVar);

            }
            treeView.RefreshObject(parentmodel);
            //OnRequestUpdate?.Invoke(null, null);
        }


        #region Events
        private void addVariableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddListElement(null);
        }

        private void removeVariableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveListElement(null);
        }

        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            var selectedNodes = treeView.SelectedObjects.Cast<IEditableVariable>().ToList();
            if (selectedNodes.ToArray().Length <= 0)
            {
                e.Cancel = true;
                return;
            }

            // for carrays
            addVariableToolStripMenuItem.Enabled = selectedNodes.All(x => x.CanAddVariable(null));
            removeVariableToolStripMenuItem.Enabled = selectedNodes.All(x => x.ParentVar != null && x.ParentVar.CanRemoveVariable(x));

            //  paste variable is active if any one variable has been copied and if the one selected variable is of the same type
            pasteToolStripMenuItem.Enabled = CopyController.Source != null
                                             && CopyController.Source is CVariable ccopy
                                             && selectedNodes.Count == 1 && selectedNodes.First() is CVariable csel
                                             && csel.GetType() == ccopy.GetType();

            ptrPropertiesToolStripMenuItem.Visible = selectedNodes.All(x => x is IPtrAccessor) && selectedNodes.Count == 1;
        }

        private void clearVariableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = (IEditableVariable)treeView.SelectedObject;
            if (node == null)
            {
            }
            else
            {
                throw new NotImplementedException();
            }

        }

        private void expandAllToolStripMenuItem_Click(object sender, EventArgs e) => treeView.ExpandAll();

        private void expandAllChildrenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = (IEditableVariable) treeView.SelectedObject;
            if (node != null)
            {
                treeView.Expand(node);
            }
        }

        private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e) => treeView.CollapseAll();

        private void collapseAllChildrenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = (IEditableVariable) treeView.SelectedObject;
            if (node != null)
            {
                treeView.Collapse(node);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GetSelectedObjects().Count > 0)
                CopyController.Source = GetSelectedObjects().First();
            //viewModel.CopyVariableCommand.SafeExecute();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GetSelectedObjects().Count > 0)
                CopyController.Target = GetSelectedObjects().First();
            viewModel.PasteVariableCommand.SafeExecute();
        }

        private void treeView_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.Column == null || e.Item == null)
                return;

            if (e.ModifierKeys == Keys.Control)
            {
                if (e.Model is IPtrAccessor ptr)
                {
                    viewModel.SelectedChunk = ptr.Reference;
                    //OnChunkRequest?.Invoke(this, new SelectChunkArgs() {Chunk =  } );
                    return;
                }
            }

            //if (e.ClickCount == 2 && e.Column.AspectName == nameof(VariableListNode.Name))
            //{
            //    treeView.StartCellEdit(e.Item, 0);
            //}
            //else 
            if (e.Column.AspectName == nameof(IEditableVariable.REDValue))
            {
                treeView.StartCellEdit(e.Item, olvColumn4.Index);
            }

            
        }

        private void ptrPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = (IEditableVariable) treeView.SelectedObject;
            if ((node as IPtrAccessor)?.Reference == null)
                return;

            // TODO: with events?
            viewModel.SelectedChunk = ((IPtrAccessor) node).Reference;
        }

        private void copyTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = (IEditableVariable) treeView.SelectedObject;
            if (node?.ParentVar == null || !node.ParentVar.CanRemoveVariable(node))
                return;
            if (node.REDValue != null)
            {
                if(node.REDValue == "")
                    Clipboard.SetText(node.REDType + ":??");
                else
                    Clipboard.SetText(node.REDValue);

            }
        }

        private void treeView_ItemsChanged(object sender, ItemsChangedEventArgs e) => MainController.Get().ProjectUnsaved = true;

        private void treeView_FormatRow(object sender, FormatRowEventArgs e)
        {
            IEditableVariable model = (IEditableVariable)e.Model;
            if (model != null && (model.IsSerialized))
            {
                //if (!showOnlySerialized)
                {
                    int themeID = (int)UIController.Get().Configuration.ColorTheme;
                    var forecolor = Color.FromArgb(UIController.Get().Configuration.CustomHighlightColor[themeID]);
                    e.Item.ForeColor = forecolor;
                }
            }
            else
            {
                
            }

            // check for errors
            // do this here until we have a proper error log 
            if ((model is IPtrAccessor ptr && ptr.Reference == null) 
                || (model is IHandleAccessor handle && handle.ChunkHandle && handle.Reference == null))
            {
                e.Item.ForeColor = Color.Red;
            }
        }

        private void toolStripClearButton_Click(object sender, EventArgs e)
        {
            toolStripSearchBox.Clear();
            treeView.ModelFilter = null;
        }

        private void toolStripSearchBox_KeyUp(object sender, KeyEventArgs e)
        {
            treeView.ModelFilter = !string.IsNullOrEmpty(toolStripSearchBox.Text) 
                ? TextMatchFilter.Contains(treeView, toolStripSearchBox.Text.ToUpper()) 
                : null;
        }

        private void toolStripButtonShowSerialized_Click(object sender, EventArgs e)
        {
            // toggle
            showOnlySerialized = !showOnlySerialized;

            toolStripButtonShowSerialized.Text = showOnlySerialized
                ? "Show all variables"
                : "Show edited variables";

            UpdateTreeListView();
        }

        private void toolStripButtonColorPicker_Click(object sender, EventArgs e)
        {
            int themeID = (int)UIController.Get().Configuration.ColorTheme;
            Color forecolor = Color.FromArgb(UIController.Get().Configuration.CustomHighlightColor[themeID]);


            ColorDialog myDialog = new ColorDialog
            {
                AllowFullOpen = true,
                ShowHelp = true,
                Color = forecolor
            };

            // Update the text box color if the user clicks OK 
            if (myDialog.ShowDialog() == DialogResult.OK)
            {
                UIController.Get().Configuration.CustomHighlightColor[themeID] = myDialog.Color.ToArgb();
                UIController.Get().Configuration.Save();
            }
        }

        #endregion

        private void ExpandBTN_Click(object sender, EventArgs e) => treeView.ExpandAll();

        private void CollapseBTN_Click(object sender, EventArgs e) => treeView.CollapseAll();
    }
}