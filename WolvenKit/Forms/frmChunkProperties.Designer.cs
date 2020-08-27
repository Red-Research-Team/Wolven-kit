﻿using System.ComponentModel;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace WolvenKit
{
    partial class frmChunkProperties
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChunkProperties));
            this.treeView = new BrightIdeasSoftware.TreeListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.expandAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandAllChildrenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collapseAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collapseAllChildrenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.addVariableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeVariableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSplitPtr = new System.Windows.Forms.ToolStripSeparator();
            this.ptrPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSearchBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripClearButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonShowSerialized = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearVariableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.treeView)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.AllColumns.Add(this.olvColumn1);
            this.treeView.AllColumns.Add(this.olvColumn2);
            this.treeView.AllColumns.Add(this.olvColumn4);
            this.treeView.AlternateRowBackColor = System.Drawing.Color.LightCyan;
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.BackColor = System.Drawing.SystemColors.Window;
            this.treeView.CellEditUseWholeCell = false;
            this.treeView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn4});
            this.treeView.ContextMenuStrip = this.contextMenu;
            this.treeView.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeView.FullRowSelect = true;
            this.treeView.HideSelection = false;
            this.treeView.Location = new System.Drawing.Point(0, 34);
            this.treeView.Name = "treeView";
            this.treeView.ShowGroups = false;
            this.treeView.Size = new System.Drawing.Size(813, 459);
            this.treeView.TabIndex = 1;
            this.treeView.UseAlternatingBackColors = true;
            this.treeView.UseCompatibleStateImageBehavior = false;
            this.treeView.View = System.Windows.Forms.View.Details;
            this.treeView.VirtualMode = true;
            this.treeView.CellEditFinished += new BrightIdeasSoftware.CellEditEventHandler(this.treeView_CellEditFinished);
            this.treeView.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.treeView_CellEditStarting);
            this.treeView.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.treeView_CellClick);
            this.treeView.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.treeView_FormatRow);
            this.treeView.ItemsChanged += new System.EventHandler<BrightIdeasSoftware.ItemsChangedEventArgs>(this.treeView_ItemsChanged);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Name";
            this.olvColumn1.IsEditable = false;
            this.olvColumn1.Text = "Name";
            this.olvColumn1.Width = 200;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Type";
            this.olvColumn2.IsEditable = false;
            this.olvColumn2.Text = "Type";
            this.olvColumn2.Width = 100;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "Value";
            this.olvColumn4.FillsFreeSpace = true;
            this.olvColumn4.Text = "Value";
            this.olvColumn4.Width = 200;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expandAllToolStripMenuItem,
            this.expandAllChildrenToolStripMenuItem,
            this.collapseAllToolStripMenuItem,
            this.collapseAllChildrenToolStripMenuItem,
            this.toolStripSeparator1,
            this.clearVariableToolStripMenuItem,
            this.toolStripMenuItem1,
            this.addVariableToolStripMenuItem,
            this.removeVariableToolStripMenuItem,
            this.toolStripMenuItem2,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.copyTextToolStripMenuItem,
            this.toolSplitPtr,
            this.ptrPropertiesToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(185, 292);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // expandAllToolStripMenuItem
            // 
            this.expandAllToolStripMenuItem.Name = "expandAllToolStripMenuItem";
            this.expandAllToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.expandAllToolStripMenuItem.Text = "Expand All";
            this.expandAllToolStripMenuItem.Click += new System.EventHandler(this.expandAllToolStripMenuItem_Click);
            // 
            // expandAllChildrenToolStripMenuItem
            // 
            this.expandAllChildrenToolStripMenuItem.Name = "expandAllChildrenToolStripMenuItem";
            this.expandAllChildrenToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.expandAllChildrenToolStripMenuItem.Text = "Expand All Children";
            this.expandAllChildrenToolStripMenuItem.Click += new System.EventHandler(this.expandAllChildrenToolStripMenuItem_Click);
            // 
            // collapseAllToolStripMenuItem
            // 
            this.collapseAllToolStripMenuItem.Name = "collapseAllToolStripMenuItem";
            this.collapseAllToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.collapseAllToolStripMenuItem.Text = "Collapse All";
            this.collapseAllToolStripMenuItem.Click += new System.EventHandler(this.collapseAllToolStripMenuItem_Click);
            // 
            // collapseAllChildrenToolStripMenuItem
            // 
            this.collapseAllChildrenToolStripMenuItem.Name = "collapseAllChildrenToolStripMenuItem";
            this.collapseAllChildrenToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.collapseAllChildrenToolStripMenuItem.Text = "Collapse All Children";
            this.collapseAllChildrenToolStripMenuItem.Click += new System.EventHandler(this.collapseAllChildrenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 6);
            // 
            // addVariableToolStripMenuItem
            // 
            this.addVariableToolStripMenuItem.Name = "addVariableToolStripMenuItem";
            this.addVariableToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.addVariableToolStripMenuItem.Text = "Add List Element";
            this.addVariableToolStripMenuItem.Click += new System.EventHandler(this.addVariableToolStripMenuItem_Click);
            // 
            // removeVariableToolStripMenuItem
            // 
            this.removeVariableToolStripMenuItem.Name = "removeVariableToolStripMenuItem";
            this.removeVariableToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.removeVariableToolStripMenuItem.Text = "Remove List Element";
            this.removeVariableToolStripMenuItem.Click += new System.EventHandler(this.removeVariableToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(181, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.copyToolStripMenuItem.Text = "Copy Variable";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.pasteToolStripMenuItem.Text = "Paste Variable";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // copyTextToolStripMenuItem
            // 
            this.copyTextToolStripMenuItem.Name = "copyTextToolStripMenuItem";
            this.copyTextToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.copyTextToolStripMenuItem.Text = "Copy Text";
            this.copyTextToolStripMenuItem.Click += new System.EventHandler(this.copyTextToolStripMenuItem_Click);
            // 
            // toolSplitPtr
            // 
            this.toolSplitPtr.Name = "toolSplitPtr";
            this.toolSplitPtr.Size = new System.Drawing.Size(181, 6);
            // 
            // ptrPropertiesToolStripMenuItem
            // 
            this.ptrPropertiesToolStripMenuItem.Name = "ptrPropertiesToolStripMenuItem";
            this.ptrPropertiesToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.ptrPropertiesToolStripMenuItem.Text = "Ptr Properties";
            this.ptrPropertiesToolStripMenuItem.Click += new System.EventHandler(this.ptrPropertiesToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSearchBox,
            this.toolStripClearButton,
            this.toolStripButtonShowSerialized});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(813, 31);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(39, 28);
            this.toolStripLabel1.Text = "Filter: ";
            // 
            // toolStripSearchBox
            // 
            this.toolStripSearchBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripSearchBox.Name = "toolStripSearchBox";
            this.toolStripSearchBox.Size = new System.Drawing.Size(122, 31);
            this.toolStripSearchBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.toolStripSearchBox_KeyUp);
            // 
            // toolStripClearButton
            // 
            this.toolStripClearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripClearButton.Image = global::WolvenKit.Properties.Resources.ExitIcon;
            this.toolStripClearButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripClearButton.Name = "toolStripClearButton";
            this.toolStripClearButton.Size = new System.Drawing.Size(28, 28);
            this.toolStripClearButton.Text = "Clear";
            this.toolStripClearButton.Click += new System.EventHandler(this.toolStripClearButton_Click);
            // 
            // toolStripButtonShowSerialized
            // 
            this.toolStripButtonShowSerialized.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonShowSerialized.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonShowSerialized.Image")));
            this.toolStripButtonShowSerialized.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowSerialized.Name = "toolStripButtonShowSerialized";
            this.toolStripButtonShowSerialized.Size = new System.Drawing.Size(149, 28);
            this.toolStripButtonShowSerialized.Text = "Show all editable variables";
            this.toolStripButtonShowSerialized.Click += new System.EventHandler(this.toolStripButtonShowSerialized_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // clearVariableToolStripMenuItem
            // 
            this.clearVariableToolStripMenuItem.Name = "clearVariableToolStripMenuItem";
            this.clearVariableToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.clearVariableToolStripMenuItem.Text = "Clear Variable";
            this.clearVariableToolStripMenuItem.Click += new System.EventHandler(this.clearVariableToolStripMenuItem_Click);
            // 
            // frmChunkProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 493);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.treeView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChunkProperties";
            this.Text = "Properties";
            this.Shown += new System.EventHandler(this.frmChunkProperties_Shown);
            this.Resize += new System.EventHandler(this.frmChunkProperties_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.treeView)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TreeListView treeView;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem addVariableToolStripMenuItem;
        private ToolStripMenuItem removeVariableToolStripMenuItem;
        private ToolStripMenuItem expandAllToolStripMenuItem;
        private ToolStripMenuItem expandAllChildrenToolStripMenuItem;
        private ToolStripMenuItem collapseAllToolStripMenuItem;
        private ToolStripMenuItem collapseAllChildrenToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator toolSplitPtr;
        private ToolStripMenuItem ptrPropertiesToolStripMenuItem;
        private ToolStripMenuItem copyTextToolStripMenuItem;
        private OLVColumn olvColumn1;
        private OLVColumn olvColumn2;
        private OLVColumn olvColumn4;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox toolStripSearchBox;
        private ToolStripButton toolStripClearButton;
        private ToolStripButton toolStripButtonShowSerialized;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem clearVariableToolStripMenuItem;
    }
}