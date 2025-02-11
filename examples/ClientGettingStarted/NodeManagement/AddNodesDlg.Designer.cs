/******************************************************************************
** Copyright (c) 2006-2023 Unified Automation GmbH All rights reserved.
**
** Software License Agreement ("SLA") Version 2.8
**
** Unless explicitly acquired and licensed from Licensor under another
** license, the contents of this file are subject to the Software License
** Agreement ("SLA") Version 2.8, or subsequent versions
** as allowed by the SLA, and You may not copy or use this file in either
** source code or executable form, except in compliance with the terms and
** conditions of the SLA.
**
** All software distributed under the SLA is provided strictly on an
** "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED,
** AND LICENSOR HEREBY DISCLAIMS ALL SUCH WARRANTIES, INCLUDING WITHOUT
** LIMITATION, ANY WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
** PURPOSE, QUIET ENJOYMENT, OR NON-INFRINGEMENT. See the SLA for specific
** language governing rights and limitations under the SLA.
**
** Project: .NET based OPC UA Client Server SDK
**
** Description: OPC Unified Architecture Software Development Kit.
**
** The complete license agreement can be found here:
** http://unifiedautomation.com/License/SLA/2.8/
******************************************************************************/

namespace UnifiedAutomation.ClientGettingStarted
{
    partial class AddNodesDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.RequestPN = new System.Windows.Forms.TableLayoutPanel();
            this.DataTypeBTN = new System.Windows.Forms.Button();
            this.ValueRankCB = new System.Windows.Forms.ComboBox();
            this.ValueRankLB = new System.Windows.Forms.Label();
            this.DataTypeIdTB = new System.Windows.Forms.TextBox();
            this.DataTypeIdLB = new System.Windows.Forms.Label();
            this.BrowseNameTB = new System.Windows.Forms.TextBox();
            this.BrowseNameLB = new System.Windows.Forms.Label();
            this.TypeDefinitionIdBTN = new System.Windows.Forms.Button();
            this.TypeDefinitionIdTB = new System.Windows.Forms.TextBox();
            this.TypeDefinitionIdLB = new System.Windows.Forms.Label();
            this.ReferenceTypeIdBTN = new System.Windows.Forms.Button();
            this.ReferenceTypeIdTB = new System.Windows.Forms.TextBox();
            this.ReferenceTypeIdLB = new System.Windows.Forms.Label();
            this.ParentIdBTN = new System.Windows.Forms.Button();
            this.NodeClassLB = new System.Windows.Forms.Label();
            this.ParentIdTB = new System.Windows.Forms.TextBox();
            this.ParentIdLB = new System.Windows.Forms.Label();
            this.NodeClassCB = new System.Windows.Forms.ComboBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.CancelBTN = new System.Windows.Forms.Button();
            this.NewNodeIdTB = new System.Windows.Forms.TextBox();
            this.NewNodeIdLB = new System.Windows.Forms.Label();
            this.InstructionsGB = new System.Windows.Forms.GroupBox();
            this.TopPN = new System.Windows.Forms.Panel();
            this.HelpBTN = new System.Windows.Forms.Button();
            this.ShowCodeBTN = new System.Windows.Forms.Button();
            this.InstructionsLB = new System.Windows.Forms.Label();
            this.RequestGB = new System.Windows.Forms.GroupBox();
            this.BottomPN = new System.Windows.Forms.Panel();
            this.UseAsynchCK = new System.Windows.Forms.CheckBox();
            this.AddNodesBTN = new System.Windows.Forms.Button();
            this.ResponseGB = new System.Windows.Forms.GroupBox();
            this.ResponsePN = new System.Windows.Forms.TableLayoutPanel();
            this.RequestPN.SuspendLayout();
            this.InstructionsGB.SuspendLayout();
            this.TopPN.SuspendLayout();
            this.RequestGB.SuspendLayout();
            this.BottomPN.SuspendLayout();
            this.ResponseGB.SuspendLayout();
            this.ResponsePN.SuspendLayout();
            this.SuspendLayout();
            //
            // RequestPN
            //
            this.RequestPN.AutoSize = true;
            this.RequestPN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RequestPN.ColumnCount = 3;
            this.RequestPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RequestPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RequestPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RequestPN.Controls.Add(this.DataTypeBTN, 2, 6);
            this.RequestPN.Controls.Add(this.ValueRankCB, 1, 7);
            this.RequestPN.Controls.Add(this.ValueRankLB, 0, 7);
            this.RequestPN.Controls.Add(this.DataTypeIdTB, 1, 6);
            this.RequestPN.Controls.Add(this.DataTypeIdLB, 0, 6);
            this.RequestPN.Controls.Add(this.BrowseNameTB, 1, 5);
            this.RequestPN.Controls.Add(this.BrowseNameLB, 0, 5);
            this.RequestPN.Controls.Add(this.TypeDefinitionIdBTN, 2, 4);
            this.RequestPN.Controls.Add(this.TypeDefinitionIdTB, 1, 4);
            this.RequestPN.Controls.Add(this.TypeDefinitionIdLB, 0, 4);
            this.RequestPN.Controls.Add(this.ReferenceTypeIdBTN, 2, 1);
            this.RequestPN.Controls.Add(this.ReferenceTypeIdTB, 1, 1);
            this.RequestPN.Controls.Add(this.ReferenceTypeIdLB, 0, 1);
            this.RequestPN.Controls.Add(this.ParentIdBTN, 2, 0);
            this.RequestPN.Controls.Add(this.NodeClassLB, 0, 3);
            this.RequestPN.Controls.Add(this.ParentIdTB, 1, 0);
            this.RequestPN.Controls.Add(this.ParentIdLB, 0, 0);
            this.RequestPN.Controls.Add(this.NodeClassCB, 1, 3);
            this.RequestPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RequestPN.Location = new System.Drawing.Point(3, 16);
            this.RequestPN.Name = "RequestPN";
            this.RequestPN.Padding = new System.Windows.Forms.Padding(3);
            this.RequestPN.RowCount = 9;
            this.RequestPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RequestPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RequestPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RequestPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RequestPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RequestPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RequestPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RequestPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RequestPN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RequestPN.Size = new System.Drawing.Size(566, 180);
            this.RequestPN.TabIndex = 1;
            //
            // DataTypeBTN
            //
            this.DataTypeBTN.AutoSize = true;
            this.DataTypeBTN.Location = new System.Drawing.Point(537, 127);
            this.DataTypeBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.DataTypeBTN.Name = "DataTypeBTN";
            this.DataTypeBTN.Size = new System.Drawing.Size(26, 23);
            this.DataTypeBTN.TabIndex = 35;
            this.DataTypeBTN.Text = "...";
            this.ToolTip.SetToolTip(this.DataTypeBTN, "Displays a dialog to select the data type for the new variable node.");
            this.DataTypeBTN.UseVisualStyleBackColor = true;
            this.DataTypeBTN.Click += new System.EventHandler(this.DataTypeBTN_Click);
            //
            // ValueRankCB
            //
            this.ValueRankCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ValueRankCB.FormattingEnabled = true;
            this.ValueRankCB.Location = new System.Drawing.Point(94, 153);
            this.ValueRankCB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 1);
            this.ValueRankCB.Name = "ValueRankCB";
            this.ValueRankCB.Size = new System.Drawing.Size(176, 21);
            this.ValueRankCB.TabIndex = 34;
            this.ToolTip.SetToolTip(this.ValueRankCB, "The method to invoke.");
            //
            // ValueRankLB
            //
            this.ValueRankLB.AutoSize = true;
            this.ValueRankLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ValueRankLB.Location = new System.Drawing.Point(6, 151);
            this.ValueRankLB.Name = "ValueRankLB";
            this.ValueRankLB.Size = new System.Drawing.Size(84, 24);
            this.ValueRankLB.TabIndex = 33;
            this.ValueRankLB.Text = "Value Rank";
            this.ValueRankLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.ValueRankLB, " ");
            //
            // DataTypeIdTB
            //
            this.DataTypeIdTB.AllowDrop = true;
            this.DataTypeIdTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataTypeIdTB.Location = new System.Drawing.Point(94, 128);
            this.DataTypeIdTB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.DataTypeIdTB.Name = "DataTypeIdTB";
            this.DataTypeIdTB.Size = new System.Drawing.Size(441, 20);
            this.DataTypeIdTB.TabIndex = 32;
            this.ToolTip.SetToolTip(this.DataTypeIdTB, "The identifier for an object with methods.");
            this.DataTypeIdTB.TextChanged += new System.EventHandler(this.DataTypeIdTB_TextChanged);
            //
            // DataTypeIdLB
            //
            this.DataTypeIdLB.AutoSize = true;
            this.DataTypeIdLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataTypeIdLB.Location = new System.Drawing.Point(6, 126);
            this.DataTypeIdLB.Name = "DataTypeIdLB";
            this.DataTypeIdLB.Size = new System.Drawing.Size(84, 25);
            this.DataTypeIdLB.TabIndex = 31;
            this.DataTypeIdLB.Text = "Data Type";
            this.DataTypeIdLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.DataTypeIdLB, " ");
            //
            // BrowseNameTB
            //
            this.BrowseNameTB.AllowDrop = true;
            this.BrowseNameTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowseNameTB.Location = new System.Drawing.Point(94, 104);
            this.BrowseNameTB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.BrowseNameTB.Name = "BrowseNameTB";
            this.BrowseNameTB.Size = new System.Drawing.Size(441, 20);
            this.BrowseNameTB.TabIndex = 30;
            this.ToolTip.SetToolTip(this.BrowseNameTB, "The identifier for an object with methods.");
            //
            // BrowseNameLB
            //
            this.BrowseNameLB.AutoSize = true;
            this.BrowseNameLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowseNameLB.Location = new System.Drawing.Point(6, 102);
            this.BrowseNameLB.Name = "BrowseNameLB";
            this.BrowseNameLB.Size = new System.Drawing.Size(84, 24);
            this.BrowseNameLB.TabIndex = 29;
            this.BrowseNameLB.Text = "Browse Name";
            this.BrowseNameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.BrowseNameLB, " ");
            //
            // TypeDefinitionIdBTN
            //
            this.TypeDefinitionIdBTN.AutoSize = true;
            this.TypeDefinitionIdBTN.Location = new System.Drawing.Point(537, 78);
            this.TypeDefinitionIdBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.TypeDefinitionIdBTN.Name = "TypeDefinitionIdBTN";
            this.TypeDefinitionIdBTN.Size = new System.Drawing.Size(26, 23);
            this.TypeDefinitionIdBTN.TabIndex = 28;
            this.TypeDefinitionIdBTN.Text = "...";
            this.ToolTip.SetToolTip(this.TypeDefinitionIdBTN, "Displays a dialog to select the type definition for the new node.");
            this.TypeDefinitionIdBTN.UseVisualStyleBackColor = true;
            this.TypeDefinitionIdBTN.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TypeDefinitionIdBTN_MouseClick);
            //
            // TypeDefinitionIdTB
            //
            this.TypeDefinitionIdTB.AllowDrop = true;
            this.TypeDefinitionIdTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TypeDefinitionIdTB.Location = new System.Drawing.Point(94, 79);
            this.TypeDefinitionIdTB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.TypeDefinitionIdTB.Name = "TypeDefinitionIdTB";
            this.TypeDefinitionIdTB.Size = new System.Drawing.Size(441, 20);
            this.TypeDefinitionIdTB.TabIndex = 27;
            this.ToolTip.SetToolTip(this.TypeDefinitionIdTB, "The identifier for an object with methods.");
            this.TypeDefinitionIdTB.TextChanged += new System.EventHandler(this.TypeDefinitionIdTB_TextChanged);
            //
            // TypeDefinitionIdLB
            //
            this.TypeDefinitionIdLB.AutoSize = true;
            this.TypeDefinitionIdLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TypeDefinitionIdLB.Location = new System.Drawing.Point(6, 77);
            this.TypeDefinitionIdLB.Name = "TypeDefinitionIdLB";
            this.TypeDefinitionIdLB.Size = new System.Drawing.Size(84, 25);
            this.TypeDefinitionIdLB.TabIndex = 26;
            this.TypeDefinitionIdLB.Text = "Type Definition";
            this.TypeDefinitionIdLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.TypeDefinitionIdLB, " ");
            //
            // ReferenceTypeIdBTN
            //
            this.ReferenceTypeIdBTN.AutoSize = true;
            this.ReferenceTypeIdBTN.Location = new System.Drawing.Point(537, 29);
            this.ReferenceTypeIdBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.ReferenceTypeIdBTN.Name = "ReferenceTypeIdBTN";
            this.ReferenceTypeIdBTN.Size = new System.Drawing.Size(26, 23);
            this.ReferenceTypeIdBTN.TabIndex = 25;
            this.ReferenceTypeIdBTN.Text = "...";
            this.ToolTip.SetToolTip(this.ReferenceTypeIdBTN, "Displays a dialog to select the reference type from the parent to the new node.");
            this.ReferenceTypeIdBTN.UseVisualStyleBackColor = true;
            this.ReferenceTypeIdBTN.Click += new System.EventHandler(this.ReferenceTypeIdBTN_Click);
            //
            // ReferenceTypeIdTB
            //
            this.ReferenceTypeIdTB.AllowDrop = true;
            this.ReferenceTypeIdTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReferenceTypeIdTB.Location = new System.Drawing.Point(94, 30);
            this.ReferenceTypeIdTB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.ReferenceTypeIdTB.Name = "ReferenceTypeIdTB";
            this.ReferenceTypeIdTB.Size = new System.Drawing.Size(441, 20);
            this.ReferenceTypeIdTB.TabIndex = 24;
            this.ToolTip.SetToolTip(this.ReferenceTypeIdTB, "The identifier for an object with methods.");
            this.ReferenceTypeIdTB.TextChanged += new System.EventHandler(this.ReferenceTypeIdTB_TextChanged);
            //
            // ReferenceTypeIdLB
            //
            this.ReferenceTypeIdLB.AutoSize = true;
            this.ReferenceTypeIdLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReferenceTypeIdLB.Location = new System.Drawing.Point(6, 28);
            this.ReferenceTypeIdLB.Name = "ReferenceTypeIdLB";
            this.ReferenceTypeIdLB.Size = new System.Drawing.Size(84, 25);
            this.ReferenceTypeIdLB.TabIndex = 23;
            this.ReferenceTypeIdLB.Text = "Reference Type";
            this.ReferenceTypeIdLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.ReferenceTypeIdLB, " ");
            //
            // ParentIdBTN
            //
            this.ParentIdBTN.AutoSize = true;
            this.ParentIdBTN.Location = new System.Drawing.Point(537, 4);
            this.ParentIdBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.ParentIdBTN.Name = "ParentIdBTN";
            this.ParentIdBTN.Size = new System.Drawing.Size(26, 23);
            this.ParentIdBTN.TabIndex = 22;
            this.ParentIdBTN.Text = "...";
            this.ToolTip.SetToolTip(this.ParentIdBTN, "Displays a dialog to select the parent for the new node.");
            this.ParentIdBTN.UseVisualStyleBackColor = true;
            this.ParentIdBTN.Click += new System.EventHandler(this.ParentBTN_Click);
            //
            // NodeClassLB
            //
            this.NodeClassLB.AutoSize = true;
            this.NodeClassLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodeClassLB.Location = new System.Drawing.Point(6, 53);
            this.NodeClassLB.Name = "NodeClassLB";
            this.NodeClassLB.Size = new System.Drawing.Size(84, 24);
            this.NodeClassLB.TabIndex = 2;
            this.NodeClassLB.Text = "Node Class";
            this.NodeClassLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // ParentIdTB
            //
            this.ParentIdTB.AllowDrop = true;
            this.ParentIdTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParentIdTB.Location = new System.Drawing.Point(94, 5);
            this.ParentIdTB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.ParentIdTB.Name = "ParentIdTB";
            this.ParentIdTB.Size = new System.Drawing.Size(441, 20);
            this.ParentIdTB.TabIndex = 1;
            this.ToolTip.SetToolTip(this.ParentIdTB, "The identifier for an object with methods.");
            this.ParentIdTB.TextChanged += new System.EventHandler(this.ParentIdTB_TextChanged);
            //
            // ParentIdLB
            //
            this.ParentIdLB.AutoSize = true;
            this.ParentIdLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParentIdLB.Location = new System.Drawing.Point(6, 3);
            this.ParentIdLB.Name = "ParentIdLB";
            this.ParentIdLB.Size = new System.Drawing.Size(84, 25);
            this.ParentIdLB.TabIndex = 0;
            this.ParentIdLB.Text = "Parent";
            this.ParentIdLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.ParentIdLB, " ");
            //
            // NodeClassCB
            //
            this.NodeClassCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NodeClassCB.FormattingEnabled = true;
            this.NodeClassCB.Location = new System.Drawing.Point(94, 55);
            this.NodeClassCB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 1);
            this.NodeClassCB.Name = "NodeClassCB";
            this.NodeClassCB.Size = new System.Drawing.Size(176, 21);
            this.NodeClassCB.TabIndex = 3;
            this.ToolTip.SetToolTip(this.NodeClassCB, "The method to invoke.");
            this.NodeClassCB.SelectedIndexChanged += new System.EventHandler(this.NodeClassCB_SelectedIndexChanged);
            //
            // CancelBTN
            //
            this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBTN.Location = new System.Drawing.Point(500, 3);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelBTN.TabIndex = 2;
            this.CancelBTN.Text = "Close";
            this.ToolTip.SetToolTip(this.CancelBTN, "Close the dialog.");
            this.CancelBTN.UseVisualStyleBackColor = true;
            this.CancelBTN.Click += new System.EventHandler(this.CancelBTN_Click);
            //
            // NewNodeIdTB
            //
            this.NewNodeIdTB.AllowDrop = true;
            this.NewNodeIdTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewNodeIdTB.Location = new System.Drawing.Point(94, 5);
            this.NewNodeIdTB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.NewNodeIdTB.Name = "NewNodeIdTB";
            this.NewNodeIdTB.Size = new System.Drawing.Size(468, 20);
            this.NewNodeIdTB.TabIndex = 1;
            this.ToolTip.SetToolTip(this.NewNodeIdTB, "The identifier for an object with methods.");
            //
            // NewNodeIdLB
            //
            this.NewNodeIdLB.AutoSize = true;
            this.NewNodeIdLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewNodeIdLB.Location = new System.Drawing.Point(6, 3);
            this.NewNodeIdLB.Name = "NewNodeIdLB";
            this.NewNodeIdLB.Size = new System.Drawing.Size(84, 24);
            this.NewNodeIdLB.TabIndex = 0;
            this.NewNodeIdLB.Text = "New Node Id";
            this.NewNodeIdLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.NewNodeIdLB, " ");
            //
            // InstructionsGB
            //
            this.InstructionsGB.BackColor = System.Drawing.Color.Transparent;
            this.InstructionsGB.Controls.Add(this.TopPN);
            this.InstructionsGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.InstructionsGB.Location = new System.Drawing.Point(3, 5);
            this.InstructionsGB.Name = "InstructionsGB";
            this.InstructionsGB.Size = new System.Drawing.Size(578, 81);
            this.InstructionsGB.TabIndex = 19;
            this.InstructionsGB.TabStop = false;
            this.InstructionsGB.Text = "Instructions";
            //
            // TopPN
            //
            this.TopPN.BackColor = System.Drawing.Color.Transparent;
            this.TopPN.Controls.Add(this.HelpBTN);
            this.TopPN.Controls.Add(this.ShowCodeBTN);
            this.TopPN.Controls.Add(this.InstructionsLB);
            this.TopPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopPN.Location = new System.Drawing.Point(3, 16);
            this.TopPN.Name = "TopPN";
            this.TopPN.Padding = new System.Windows.Forms.Padding(3);
            this.TopPN.Size = new System.Drawing.Size(572, 62);
            this.TopPN.TabIndex = 2;
            //
            // HelpBTN
            //
            this.HelpBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HelpBTN.Location = new System.Drawing.Point(493, 35);
            this.HelpBTN.Name = "HelpBTN";
            this.HelpBTN.Size = new System.Drawing.Size(75, 23);
            this.HelpBTN.TabIndex = 2;
            this.HelpBTN.Text = "Help";
            this.HelpBTN.UseVisualStyleBackColor = true;
            this.HelpBTN.Click += new System.EventHandler(this.ShowHelpBTN_Click);
            //
            // ShowCodeBTN
            //
            this.ShowCodeBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowCodeBTN.Location = new System.Drawing.Point(493, 6);
            this.ShowCodeBTN.Name = "ShowCodeBTN";
            this.ShowCodeBTN.Size = new System.Drawing.Size(75, 23);
            this.ShowCodeBTN.TabIndex = 1;
            this.ShowCodeBTN.Text = "Show Code";
            this.ShowCodeBTN.UseVisualStyleBackColor = true;
            this.ShowCodeBTN.Click += new System.EventHandler(this.ShowCodeBTN_Click);
            //
            // InstructionsLB
            //
            this.InstructionsLB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.InstructionsLB.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.InstructionsLB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.InstructionsLB.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsLB.Location = new System.Drawing.Point(3, 3);
            this.InstructionsLB.Margin = new System.Windows.Forms.Padding(0);
            this.InstructionsLB.Name = "InstructionsLB";
            this.InstructionsLB.Padding = new System.Windows.Forms.Padding(3);
            this.InstructionsLB.Size = new System.Drawing.Size(487, 56);
            this.InstructionsLB.TabIndex = 0;
            this.InstructionsLB.Text = "<instructions>";
            //
            // RequestGB
            //
            this.RequestGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RequestGB.Controls.Add(this.RequestPN);
            this.RequestGB.Location = new System.Drawing.Point(6, 91);
            this.RequestGB.Name = "RequestGB";
            this.RequestGB.Size = new System.Drawing.Size(572, 199);
            this.RequestGB.TabIndex = 20;
            this.RequestGB.TabStop = false;
            this.RequestGB.Text = "Add Nodes Request";
            //
            // BottomPN
            //
            this.BottomPN.Controls.Add(this.UseAsynchCK);
            this.BottomPN.Controls.Add(this.AddNodesBTN);
            this.BottomPN.Controls.Add(this.CancelBTN);
            this.BottomPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPN.Location = new System.Drawing.Point(3, 356);
            this.BottomPN.Name = "BottomPN";
            this.BottomPN.Size = new System.Drawing.Size(578, 29);
            this.BottomPN.TabIndex = 0;
            //
            // UseAsynchCK
            //
            this.UseAsynchCK.AutoSize = true;
            this.UseAsynchCK.Location = new System.Drawing.Point(84, 7);
            this.UseAsynchCK.Name = "UseAsynchCK";
            this.UseAsynchCK.Size = new System.Drawing.Size(152, 17);
            this.UseAsynchCK.TabIndex = 10;
            this.UseAsynchCK.Text = "Use Asynchronous Pattern";
            this.UseAsynchCK.UseVisualStyleBackColor = true;
            //
            // AddNodesBTN
            //
            this.AddNodesBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddNodesBTN.Location = new System.Drawing.Point(3, 3);
            this.AddNodesBTN.Name = "AddNodesBTN";
            this.AddNodesBTN.Size = new System.Drawing.Size(75, 23);
            this.AddNodesBTN.TabIndex = 9;
            this.AddNodesBTN.Tag = "";
            this.AddNodesBTN.Text = "Add Nodes";
            this.AddNodesBTN.UseVisualStyleBackColor = true;
            this.AddNodesBTN.Click += new System.EventHandler(this.AddNodesBTN_Click);
            //
            // ResponseGB
            //
            this.ResponseGB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ResponseGB.Controls.Add(this.ResponsePN);
            this.ResponseGB.Location = new System.Drawing.Point(6, 296);
            this.ResponseGB.Name = "ResponseGB";
            this.ResponseGB.Size = new System.Drawing.Size(572, 61);
            this.ResponseGB.TabIndex = 21;
            this.ResponseGB.TabStop = false;
            this.ResponseGB.Text = "Add Nodes Response";
            //
            // ResponsePN
            //
            this.ResponsePN.AutoSize = true;
            this.ResponsePN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ResponsePN.ColumnCount = 3;
            this.ResponsePN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.ResponsePN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ResponsePN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ResponsePN.Controls.Add(this.NewNodeIdTB, 1, 0);
            this.ResponsePN.Controls.Add(this.NewNodeIdLB, 0, 0);
            this.ResponsePN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResponsePN.Location = new System.Drawing.Point(3, 16);
            this.ResponsePN.Name = "ResponsePN";
            this.ResponsePN.Padding = new System.Windows.Forms.Padding(3);
            this.ResponsePN.RowCount = 2;
            this.ResponsePN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ResponsePN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ResponsePN.Size = new System.Drawing.Size(566, 42);
            this.ResponsePN.TabIndex = 1;
            //
            // AddNodesDlg
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(584, 385);
            this.Controls.Add(this.ResponseGB);
            this.Controls.Add(this.RequestGB);
            this.Controls.Add(this.InstructionsGB);
            this.Controls.Add(this.BottomPN);
            this.Name = "AddNodesDlg";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Add Nodes Example";
            this.RequestPN.ResumeLayout(false);
            this.RequestPN.PerformLayout();
            this.InstructionsGB.ResumeLayout(false);
            this.TopPN.ResumeLayout(false);
            this.RequestGB.ResumeLayout(false);
            this.RequestGB.PerformLayout();
            this.BottomPN.ResumeLayout(false);
            this.BottomPN.PerformLayout();
            this.ResponseGB.ResumeLayout(false);
            this.ResponseGB.PerformLayout();
            this.ResponsePN.ResumeLayout(false);
            this.ResponsePN.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel RequestPN;
        private System.Windows.Forms.TextBox ParentIdTB;
        private System.Windows.Forms.Label ParentIdLB;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Label NodeClassLB;
        private System.Windows.Forms.ComboBox NodeClassCB;
        private System.Windows.Forms.GroupBox InstructionsGB;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Button HelpBTN;
        private System.Windows.Forms.Button ShowCodeBTN;
        private System.Windows.Forms.Label InstructionsLB;
        private System.Windows.Forms.GroupBox RequestGB;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Panel BottomPN;
        private System.Windows.Forms.CheckBox UseAsynchCK;
        private System.Windows.Forms.Button AddNodesBTN;
        private System.Windows.Forms.Button ParentIdBTN;
        private System.Windows.Forms.TextBox ReferenceTypeIdTB;
        private System.Windows.Forms.Label ReferenceTypeIdLB;
        private System.Windows.Forms.Button ReferenceTypeIdBTN;
        private System.Windows.Forms.Label ValueRankLB;
        private System.Windows.Forms.TextBox DataTypeIdTB;
        private System.Windows.Forms.Label DataTypeIdLB;
        private System.Windows.Forms.TextBox BrowseNameTB;
        private System.Windows.Forms.Label BrowseNameLB;
        private System.Windows.Forms.Button TypeDefinitionIdBTN;
        private System.Windows.Forms.TextBox TypeDefinitionIdTB;
        private System.Windows.Forms.Label TypeDefinitionIdLB;
        private System.Windows.Forms.ComboBox ValueRankCB;
        private System.Windows.Forms.GroupBox ResponseGB;
        private System.Windows.Forms.TableLayoutPanel ResponsePN;
        private System.Windows.Forms.TextBox NewNodeIdTB;
        private System.Windows.Forms.Label NewNodeIdLB;
        private System.Windows.Forms.Button DataTypeBTN;
    }
}
