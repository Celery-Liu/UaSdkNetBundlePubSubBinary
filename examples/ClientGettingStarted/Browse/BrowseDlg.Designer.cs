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
    partial class BrowseDlg
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
            this.MainPN = new System.Windows.Forms.TableLayoutPanel();
            this.NodeIdBTN = new System.Windows.Forms.Button();
            this.ReferenceTypeTB = new System.Windows.Forms.TextBox();
            this.ReferenceTypeBTN = new System.Windows.Forms.Button();
            this.IncludeSubtypesCK = new System.Windows.Forms.CheckBox();
            this.IncludeSubtypesLB = new System.Windows.Forms.Label();
            this.MaxReferencesLB = new System.Windows.Forms.Label();
            this.BrowseDirectionLB = new System.Windows.Forms.Label();
            this.ReferenceTypeLB = new System.Windows.Forms.Label();
            this.NodeIdTB = new System.Windows.Forms.TextBox();
            this.NodeIdLB = new System.Windows.Forms.Label();
            this.BrowseDirectionCB = new System.Windows.Forms.ComboBox();
            this.MaxReferencesUD = new System.Windows.Forms.NumericUpDown();
            this.ReferencesLV = new System.Windows.Forms.ListView();
            this.ReferenceTypeCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TargetCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NodeClassCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TypeDefinitionCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BottomPN = new System.Windows.Forms.Panel();
            this.UseAsynchCK = new System.Windows.Forms.CheckBox();
            this.BrowseBTN = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.TopPN = new System.Windows.Forms.Panel();
            this.HelpBTN = new System.Windows.Forms.Button();
            this.ShowCodeBTN = new System.Windows.Forms.Button();
            this.InstructionsLB = new System.Windows.Forms.Label();
            this.ResponseGB = new System.Windows.Forms.GroupBox();
            this.RequestGB = new System.Windows.Forms.GroupBox();
            this.InstructionsGB = new System.Windows.Forms.GroupBox();
            this.MainPN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxReferencesUD)).BeginInit();
            this.BottomPN.SuspendLayout();
            this.TopPN.SuspendLayout();
            this.ResponseGB.SuspendLayout();
            this.RequestGB.SuspendLayout();
            this.InstructionsGB.SuspendLayout();
            this.SuspendLayout();
            //
            // MainPN
            //
            this.MainPN.ColumnCount = 3;
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.Controls.Add(this.NodeIdBTN, 3, 0);
            this.MainPN.Controls.Add(this.ReferenceTypeTB, 1, 2);
            this.MainPN.Controls.Add(this.ReferenceTypeBTN, 2, 2);
            this.MainPN.Controls.Add(this.IncludeSubtypesCK, 1, 3);
            this.MainPN.Controls.Add(this.IncludeSubtypesLB, 0, 3);
            this.MainPN.Controls.Add(this.MaxReferencesLB, 0, 4);
            this.MainPN.Controls.Add(this.BrowseDirectionLB, 0, 1);
            this.MainPN.Controls.Add(this.ReferenceTypeLB, 0, 2);
            this.MainPN.Controls.Add(this.NodeIdTB, 1, 0);
            this.MainPN.Controls.Add(this.NodeIdLB, 0, 0);
            this.MainPN.Controls.Add(this.BrowseDirectionCB, 1, 1);
            this.MainPN.Controls.Add(this.MaxReferencesUD, 1, 4);
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(3, 16);
            this.MainPN.Name = "MainPN";
            this.MainPN.Padding = new System.Windows.Forms.Padding(3);
            this.MainPN.RowCount = 6;
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainPN.Size = new System.Drawing.Size(572, 132);
            this.MainPN.TabIndex = 1;
            //
            // NodeIdBTN
            //
            this.NodeIdBTN.AutoSize = true;
            this.NodeIdBTN.Location = new System.Drawing.Point(542, 4);
            this.NodeIdBTN.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.NodeIdBTN.Name = "NodeIdBTN";
            this.NodeIdBTN.Size = new System.Drawing.Size(26, 23);
            this.NodeIdBTN.TabIndex = 12;
            this.NodeIdBTN.Text = "...";
            this.ToolTip.SetToolTip(this.NodeIdBTN, "Displays a dialog to select the node to browse.");
            this.NodeIdBTN.UseVisualStyleBackColor = true;
            this.NodeIdBTN.Click += new System.EventHandler(this.NodeIdBTN_Click);
            //
            // ReferenceTypeTB
            //
            this.ReferenceTypeTB.AllowDrop = true;
            this.ReferenceTypeTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReferenceTypeTB.Location = new System.Drawing.Point(99, 56);
            this.ReferenceTypeTB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.ReferenceTypeTB.Name = "ReferenceTypeTB";
            this.ReferenceTypeTB.Size = new System.Drawing.Size(441, 20);
            this.ReferenceTypeTB.TabIndex = 5;
            this.ToolTip.SetToolTip(this.ReferenceTypeTB, "The type of reference to return.");
            //
            // ReferenceTypeBTN
            //
            this.ReferenceTypeBTN.AutoSize = true;
            this.ReferenceTypeBTN.Location = new System.Drawing.Point(542, 55);
            this.ReferenceTypeBTN.Margin = new System.Windows.Forms.Padding(1);
            this.ReferenceTypeBTN.Name = "ReferenceTypeBTN";
            this.ReferenceTypeBTN.Size = new System.Drawing.Size(26, 23);
            this.ReferenceTypeBTN.TabIndex = 6;
            this.ReferenceTypeBTN.Text = "...";
            this.ToolTip.SetToolTip(this.ReferenceTypeBTN, "Displays a dialog to select the reference type to follow.");
            this.ReferenceTypeBTN.UseVisualStyleBackColor = true;
            this.ReferenceTypeBTN.Click += new System.EventHandler(this.ReferenceTypeBTN_Click);
            //
            // IncludeSubtypesCK
            //
            this.IncludeSubtypesCK.AutoSize = true;
            this.IncludeSubtypesCK.Checked = true;
            this.IncludeSubtypesCK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IncludeSubtypesCK.Location = new System.Drawing.Point(101, 85);
            this.IncludeSubtypesCK.Margin = new System.Windows.Forms.Padding(3, 6, 3, 5);
            this.IncludeSubtypesCK.Name = "IncludeSubtypesCK";
            this.IncludeSubtypesCK.Size = new System.Drawing.Size(15, 14);
            this.IncludeSubtypesCK.TabIndex = 8;
            this.ToolTip.SetToolTip(this.IncludeSubtypesCK, "If checked then return subtypes of the reference type.");
            this.IncludeSubtypesCK.UseVisualStyleBackColor = true;
            //
            // IncludeSubtypesLB
            //
            this.IncludeSubtypesLB.AutoSize = true;
            this.IncludeSubtypesLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IncludeSubtypesLB.Location = new System.Drawing.Point(6, 79);
            this.IncludeSubtypesLB.Name = "IncludeSubtypesLB";
            this.IncludeSubtypesLB.Size = new System.Drawing.Size(89, 25);
            this.IncludeSubtypesLB.TabIndex = 7;
            this.IncludeSubtypesLB.Text = "Include Subtypes";
            this.IncludeSubtypesLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // MaxReferencesLB
            //
            this.MaxReferencesLB.AutoSize = true;
            this.MaxReferencesLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaxReferencesLB.Location = new System.Drawing.Point(6, 104);
            this.MaxReferencesLB.Name = "MaxReferencesLB";
            this.MaxReferencesLB.Size = new System.Drawing.Size(89, 25);
            this.MaxReferencesLB.TabIndex = 9;
            this.MaxReferencesLB.Text = "Max References";
            this.MaxReferencesLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // BrowseDirectionLB
            //
            this.BrowseDirectionLB.AutoSize = true;
            this.BrowseDirectionLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowseDirectionLB.Location = new System.Drawing.Point(6, 29);
            this.BrowseDirectionLB.Name = "BrowseDirectionLB";
            this.BrowseDirectionLB.Size = new System.Drawing.Size(89, 25);
            this.BrowseDirectionLB.TabIndex = 2;
            this.BrowseDirectionLB.Text = "Browse Direction";
            this.BrowseDirectionLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // ReferenceTypeLB
            //
            this.ReferenceTypeLB.AutoSize = true;
            this.ReferenceTypeLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReferenceTypeLB.Location = new System.Drawing.Point(6, 54);
            this.ReferenceTypeLB.Name = "ReferenceTypeLB";
            this.ReferenceTypeLB.Size = new System.Drawing.Size(89, 25);
            this.ReferenceTypeLB.TabIndex = 4;
            this.ReferenceTypeLB.Text = "Reference Type";
            this.ReferenceTypeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // NodeIdTB
            //
            this.NodeIdTB.AllowDrop = true;
            this.NodeIdTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodeIdTB.Location = new System.Drawing.Point(99, 5);
            this.NodeIdTB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 0);
            this.NodeIdTB.Name = "NodeIdTB";
            this.NodeIdTB.Size = new System.Drawing.Size(441, 20);
            this.NodeIdTB.TabIndex = 1;
            this.NodeIdTB.Text = "i=2253";
            this.ToolTip.SetToolTip(this.NodeIdTB, "The identifier for the node to browse.");
            this.NodeIdTB.TextChanged += new System.EventHandler(this.NodeIdTB_TextChanged);
            //
            // NodeIdLB
            //
            this.NodeIdLB.AutoSize = true;
            this.NodeIdLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodeIdLB.Location = new System.Drawing.Point(6, 3);
            this.NodeIdLB.Name = "NodeIdLB";
            this.NodeIdLB.Size = new System.Drawing.Size(89, 26);
            this.NodeIdLB.TabIndex = 0;
            this.NodeIdLB.Text = "Node ID";
            this.NodeIdLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.NodeIdLB, " ");
            //
            // BrowseDirectionCB
            //
            this.BrowseDirectionCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BrowseDirectionCB.FormattingEnabled = true;
            this.BrowseDirectionCB.Items.AddRange(new object[] {
            "Forward"});
            this.BrowseDirectionCB.Location = new System.Drawing.Point(99, 31);
            this.BrowseDirectionCB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.BrowseDirectionCB.Name = "BrowseDirectionCB";
            this.BrowseDirectionCB.Size = new System.Drawing.Size(168, 21);
            this.BrowseDirectionCB.TabIndex = 3;
            this.ToolTip.SetToolTip(this.BrowseDirectionCB, "The direction of the references to return.");
            //
            // MaxReferencesUD
            //
            this.MaxReferencesUD.Location = new System.Drawing.Point(99, 107);
            this.MaxReferencesUD.Margin = new System.Windows.Forms.Padding(1, 3, 1, 2);
            this.MaxReferencesUD.Name = "MaxReferencesUD";
            this.MaxReferencesUD.Size = new System.Drawing.Size(120, 20);
            this.MaxReferencesUD.TabIndex = 10;
            this.ToolTip.SetToolTip(this.MaxReferencesUD, "The maximum number of references to return in a single response.");
            //
            // ReferencesLV
            //
            this.ReferencesLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ReferenceTypeCH,
            this.TargetCH,
            this.NodeClassCH,
            this.TypeDefinitionCH});
            this.ReferencesLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReferencesLV.HideSelection = false;
            this.ReferencesLV.Location = new System.Drawing.Point(3, 16);
            this.ReferencesLV.MultiSelect = false;
            this.ReferencesLV.Name = "ReferencesLV";
            this.ReferencesLV.Size = new System.Drawing.Size(572, 164);
            this.ReferencesLV.TabIndex = 11;
            this.ReferencesLV.UseCompatibleStateImageBehavior = false;
            this.ReferencesLV.View = System.Windows.Forms.View.Details;
            //
            // ReferenceTypeCH
            //
            this.ReferenceTypeCH.Text = "Reference Type";
            this.ReferenceTypeCH.Width = 97;
            //
            // TargetCH
            //
            this.TargetCH.Text = "Target";
            this.TargetCH.Width = 98;
            //
            // NodeClassCH
            //
            this.NodeClassCH.Text = "Node Class";
            this.NodeClassCH.Width = 104;
            //
            // TypeDefinitionCH
            //
            this.TypeDefinitionCH.Text = "Type Definition";
            this.TypeDefinitionCH.Width = 111;
            //
            // BottomPN
            //
            this.BottomPN.Controls.Add(this.UseAsynchCK);
            this.BottomPN.Controls.Add(this.BrowseBTN);
            this.BottomPN.Controls.Add(this.CancelBTN);
            this.BottomPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPN.Location = new System.Drawing.Point(3, 433);
            this.BottomPN.Name = "BottomPN";
            this.BottomPN.Size = new System.Drawing.Size(578, 29);
            this.BottomPN.TabIndex = 0;
            //
            // UseAsynchCK
            //
            this.UseAsynchCK.AutoSize = true;
            this.UseAsynchCK.Location = new System.Drawing.Point(87, 7);
            this.UseAsynchCK.Name = "UseAsynchCK";
            this.UseAsynchCK.Size = new System.Drawing.Size(152, 17);
            this.UseAsynchCK.TabIndex = 4;
            this.UseAsynchCK.Text = "Use Asynchronous Pattern";
            this.UseAsynchCK.UseVisualStyleBackColor = true;
            //
            // BrowseBTN
            //
            this.BrowseBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BrowseBTN.Location = new System.Drawing.Point(5, 3);
            this.BrowseBTN.Name = "BrowseBTN";
            this.BrowseBTN.Size = new System.Drawing.Size(75, 23);
            this.BrowseBTN.TabIndex = 3;
            this.BrowseBTN.Text = "Browse";
            this.BrowseBTN.UseVisualStyleBackColor = true;
            this.BrowseBTN.Click += new System.EventHandler(this.BrowseBTN_Click);
            //
            // CancelBTN
            //
            this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBTN.Location = new System.Drawing.Point(499, 3);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelBTN.TabIndex = 2;
            this.CancelBTN.Text = "Close";
            this.CancelBTN.UseVisualStyleBackColor = true;
            this.CancelBTN.Click += new System.EventHandler(this.CancelBTN_Click);
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
            // ResponseGB
            //
            this.ResponseGB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ResponseGB.Controls.Add(this.ReferencesLV);
            this.ResponseGB.Location = new System.Drawing.Point(3, 247);
            this.ResponseGB.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.ResponseGB.Name = "ResponseGB";
            this.ResponseGB.Size = new System.Drawing.Size(578, 183);
            this.ResponseGB.TabIndex = 12;
            this.ResponseGB.TabStop = false;
            this.ResponseGB.Text = "Browse Response";
            //
            // RequestGB
            //
            this.RequestGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RequestGB.Controls.Add(this.MainPN);
            this.RequestGB.Location = new System.Drawing.Point(3, 91);
            this.RequestGB.Name = "RequestGB";
            this.RequestGB.Size = new System.Drawing.Size(578, 151);
            this.RequestGB.TabIndex = 3;
            this.RequestGB.TabStop = false;
            this.RequestGB.Text = "Browse Request";
            //
            // InstructionsGB
            //
            this.InstructionsGB.BackColor = System.Drawing.Color.Transparent;
            this.InstructionsGB.Controls.Add(this.TopPN);
            this.InstructionsGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.InstructionsGB.Location = new System.Drawing.Point(3, 5);
            this.InstructionsGB.Name = "InstructionsGB";
            this.InstructionsGB.Size = new System.Drawing.Size(578, 81);
            this.InstructionsGB.TabIndex = 13;
            this.InstructionsGB.TabStop = false;
            this.InstructionsGB.Text = "Instructions";
            //
            // BrowseDlg
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 462);
            this.Controls.Add(this.RequestGB);
            this.Controls.Add(this.InstructionsGB);
            this.Controls.Add(this.ResponseGB);
            this.Controls.Add(this.BottomPN);
            this.Name = "BrowseDlg";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Browse Example";
            this.MainPN.ResumeLayout(false);
            this.MainPN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxReferencesUD)).EndInit();
            this.BottomPN.ResumeLayout(false);
            this.BottomPN.PerformLayout();
            this.TopPN.ResumeLayout(false);
            this.ResponseGB.ResumeLayout(false);
            this.RequestGB.ResumeLayout(false);
            this.InstructionsGB.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainPN;
        private System.Windows.Forms.Label ReferenceTypeLB;
        private System.Windows.Forms.TextBox NodeIdTB;
        private System.Windows.Forms.Label NodeIdLB;
        private System.Windows.Forms.Panel BottomPN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Label BrowseDirectionLB;
        private System.Windows.Forms.ComboBox BrowseDirectionCB;
        private System.Windows.Forms.Label MaxReferencesLB;
        private System.Windows.Forms.CheckBox IncludeSubtypesCK;
        private System.Windows.Forms.Label IncludeSubtypesLB;
        private System.Windows.Forms.NumericUpDown MaxReferencesUD;
        private System.Windows.Forms.TextBox ReferenceTypeTB;
        private System.Windows.Forms.Button ReferenceTypeBTN;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Button HelpBTN;
        private System.Windows.Forms.Button ShowCodeBTN;
        private System.Windows.Forms.Label InstructionsLB;
        private System.Windows.Forms.ListView ReferencesLV;
        private System.Windows.Forms.ColumnHeader ReferenceTypeCH;
        private System.Windows.Forms.ColumnHeader TargetCH;
        private System.Windows.Forms.ColumnHeader NodeClassCH;
        private System.Windows.Forms.ColumnHeader TypeDefinitionCH;
        private System.Windows.Forms.CheckBox UseAsynchCK;
        private System.Windows.Forms.Button BrowseBTN;
        private System.Windows.Forms.Button NodeIdBTN;
        private System.Windows.Forms.GroupBox ResponseGB;
        private System.Windows.Forms.GroupBox RequestGB;
        private System.Windows.Forms.GroupBox InstructionsGB;
    }
}
