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
    partial class DeleteReferencesDlg
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
            this.DeleteBidirectionalLB = new System.Windows.Forms.Label();
            this.DeleteBidirectionalCK = new System.Windows.Forms.CheckBox();
            this.TargetIdBTN = new System.Windows.Forms.Button();
            this.TargetIdTB = new System.Windows.Forms.TextBox();
            this.TargetIdLB = new System.Windows.Forms.Label();
            this.ReferenceTypeIdBTN = new System.Windows.Forms.Button();
            this.ReferenceTypeIdTB = new System.Windows.Forms.TextBox();
            this.ReferenceTypeIdLB = new System.Windows.Forms.Label();
            this.SourceIdBTN = new System.Windows.Forms.Button();
            this.IsForwardLB = new System.Windows.Forms.Label();
            this.SourceIdTB = new System.Windows.Forms.TextBox();
            this.SourceIdLB = new System.Windows.Forms.Label();
            this.IsForwardCK = new System.Windows.Forms.CheckBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.CancelBTN = new System.Windows.Forms.Button();
            this.ResultTB = new System.Windows.Forms.TextBox();
            this.ResultLB = new System.Windows.Forms.Label();
            this.InstructionsGB = new System.Windows.Forms.GroupBox();
            this.TopPN = new System.Windows.Forms.Panel();
            this.HelpBTN = new System.Windows.Forms.Button();
            this.ShowCodeBTN = new System.Windows.Forms.Button();
            this.InstructionsLB = new System.Windows.Forms.Label();
            this.RequestGB = new System.Windows.Forms.GroupBox();
            this.BottomPN = new System.Windows.Forms.Panel();
            this.UseAsynchCK = new System.Windows.Forms.CheckBox();
            this.DeleteReferencesBTN = new System.Windows.Forms.Button();
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
            this.RequestPN.Controls.Add(this.DeleteBidirectionalLB, 0, 5);
            this.RequestPN.Controls.Add(this.DeleteBidirectionalCK, 1, 5);
            this.RequestPN.Controls.Add(this.TargetIdBTN, 2, 4);
            this.RequestPN.Controls.Add(this.TargetIdTB, 1, 4);
            this.RequestPN.Controls.Add(this.TargetIdLB, 0, 4);
            this.RequestPN.Controls.Add(this.ReferenceTypeIdBTN, 2, 1);
            this.RequestPN.Controls.Add(this.ReferenceTypeIdTB, 1, 1);
            this.RequestPN.Controls.Add(this.ReferenceTypeIdLB, 0, 1);
            this.RequestPN.Controls.Add(this.SourceIdBTN, 2, 0);
            this.RequestPN.Controls.Add(this.IsForwardLB, 0, 2);
            this.RequestPN.Controls.Add(this.SourceIdTB, 1, 0);
            this.RequestPN.Controls.Add(this.SourceIdLB, 0, 0);
            this.RequestPN.Controls.Add(this.IsForwardCK, 1, 2);
            this.RequestPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RequestPN.Location = new System.Drawing.Point(3, 16);
            this.RequestPN.Name = "RequestPN";
            this.RequestPN.Padding = new System.Windows.Forms.Padding(3);
            this.RequestPN.RowCount = 7;
            this.RequestPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RequestPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RequestPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RequestPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RequestPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RequestPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RequestPN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RequestPN.Size = new System.Drawing.Size(566, 141);
            this.RequestPN.TabIndex = 1;
            //
            // DeleteBidirectionalLB
            //
            this.DeleteBidirectionalLB.AutoSize = true;
            this.DeleteBidirectionalLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteBidirectionalLB.Location = new System.Drawing.Point(6, 103);
            this.DeleteBidirectionalLB.Name = "DeleteBidirectionalLB";
            this.DeleteBidirectionalLB.Size = new System.Drawing.Size(98, 25);
            this.DeleteBidirectionalLB.TabIndex = 31;
            this.DeleteBidirectionalLB.Text = "Delete Bidirectional";
            this.DeleteBidirectionalLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.DeleteBidirectionalLB, " ");
            //
            // DeleteBidirectionalCK
            //
            this.DeleteBidirectionalCK.AutoSize = true;
            this.DeleteBidirectionalCK.Location = new System.Drawing.Point(110, 109);
            this.DeleteBidirectionalCK.Margin = new System.Windows.Forms.Padding(3, 6, 3, 5);
            this.DeleteBidirectionalCK.Name = "DeleteBidirectionalCK";
            this.DeleteBidirectionalCK.Size = new System.Drawing.Size(15, 14);
            this.DeleteBidirectionalCK.TabIndex = 30;
            this.DeleteBidirectionalCK.UseVisualStyleBackColor = true;
            //
            // TargetIdBTN
            //
            this.TargetIdBTN.AutoSize = true;
            this.TargetIdBTN.Location = new System.Drawing.Point(537, 79);
            this.TargetIdBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.TargetIdBTN.Name = "TargetIdBTN";
            this.TargetIdBTN.Size = new System.Drawing.Size(26, 23);
            this.TargetIdBTN.TabIndex = 28;
            this.TargetIdBTN.Text = "...";
            this.ToolTip.SetToolTip(this.TargetIdBTN, "Displays a dialog to select the target of the reference.");
            this.TargetIdBTN.UseVisualStyleBackColor = true;
            this.TargetIdBTN.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TargetIdBTN_MouseClick);
            //
            // TargetIdTB
            //
            this.TargetIdTB.AllowDrop = true;
            this.TargetIdTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TargetIdTB.Location = new System.Drawing.Point(108, 80);
            this.TargetIdTB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.TargetIdTB.Name = "TargetIdTB";
            this.TargetIdTB.Size = new System.Drawing.Size(427, 20);
            this.TargetIdTB.TabIndex = 27;
            this.ToolTip.SetToolTip(this.TargetIdTB, "The identifier for an object with methods.");
            this.TargetIdTB.TextChanged += new System.EventHandler(this.TargetIdTB_TextChanged);
            //
            // TargetIdLB
            //
            this.TargetIdLB.AutoSize = true;
            this.TargetIdLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TargetIdLB.Location = new System.Drawing.Point(6, 78);
            this.TargetIdLB.Name = "TargetIdLB";
            this.TargetIdLB.Size = new System.Drawing.Size(98, 25);
            this.TargetIdLB.TabIndex = 26;
            this.TargetIdLB.Text = "Target";
            this.TargetIdLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.TargetIdLB, " ");
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
            this.ToolTip.SetToolTip(this.ReferenceTypeIdBTN, "Displays a dialog to select the reference type for the reference.");
            this.ReferenceTypeIdBTN.UseVisualStyleBackColor = true;
            this.ReferenceTypeIdBTN.Click += new System.EventHandler(this.ReferenceTypeIdBTN_Click);
            //
            // ReferenceTypeIdTB
            //
            this.ReferenceTypeIdTB.AllowDrop = true;
            this.ReferenceTypeIdTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReferenceTypeIdTB.Location = new System.Drawing.Point(108, 30);
            this.ReferenceTypeIdTB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.ReferenceTypeIdTB.Name = "ReferenceTypeIdTB";
            this.ReferenceTypeIdTB.Size = new System.Drawing.Size(427, 20);
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
            this.ReferenceTypeIdLB.Size = new System.Drawing.Size(98, 25);
            this.ReferenceTypeIdLB.TabIndex = 23;
            this.ReferenceTypeIdLB.Text = "Reference Type";
            this.ReferenceTypeIdLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.ReferenceTypeIdLB, " ");
            //
            // SourceIdBTN
            //
            this.SourceIdBTN.AutoSize = true;
            this.SourceIdBTN.Location = new System.Drawing.Point(537, 4);
            this.SourceIdBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.SourceIdBTN.Name = "SourceIdBTN";
            this.SourceIdBTN.Size = new System.Drawing.Size(26, 23);
            this.SourceIdBTN.TabIndex = 22;
            this.SourceIdBTN.Text = "...";
            this.ToolTip.SetToolTip(this.SourceIdBTN, "Displays a dialog to select the source of the reference.");
            this.SourceIdBTN.UseVisualStyleBackColor = true;
            this.SourceIdBTN.Click += new System.EventHandler(this.SourceIdBTN_Click);
            //
            // IsForwardLB
            //
            this.IsForwardLB.AutoSize = true;
            this.IsForwardLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IsForwardLB.Location = new System.Drawing.Point(6, 53);
            this.IsForwardLB.Name = "IsForwardLB";
            this.IsForwardLB.Size = new System.Drawing.Size(98, 25);
            this.IsForwardLB.TabIndex = 2;
            this.IsForwardLB.Text = "Is Forward";
            this.IsForwardLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // SourceIdTB
            //
            this.SourceIdTB.AllowDrop = true;
            this.SourceIdTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SourceIdTB.Location = new System.Drawing.Point(108, 5);
            this.SourceIdTB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.SourceIdTB.Name = "SourceIdTB";
            this.SourceIdTB.Size = new System.Drawing.Size(427, 20);
            this.SourceIdTB.TabIndex = 1;
            this.ToolTip.SetToolTip(this.SourceIdTB, "The identifier for an object with methods.");
            this.SourceIdTB.TextChanged += new System.EventHandler(this.SourceTB_TextChanged);
            //
            // SourceIdLB
            //
            this.SourceIdLB.AutoSize = true;
            this.SourceIdLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SourceIdLB.Location = new System.Drawing.Point(6, 3);
            this.SourceIdLB.Name = "SourceIdLB";
            this.SourceIdLB.Size = new System.Drawing.Size(98, 25);
            this.SourceIdLB.TabIndex = 0;
            this.SourceIdLB.Text = "Source";
            this.SourceIdLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.SourceIdLB, " ");
            //
            // IsForwardCK
            //
            this.IsForwardCK.AutoSize = true;
            this.IsForwardCK.Location = new System.Drawing.Point(110, 59);
            this.IsForwardCK.Margin = new System.Windows.Forms.Padding(3, 6, 3, 5);
            this.IsForwardCK.Name = "IsForwardCK";
            this.IsForwardCK.Size = new System.Drawing.Size(15, 14);
            this.IsForwardCK.TabIndex = 29;
            this.IsForwardCK.UseVisualStyleBackColor = true;
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
            // ResultTB
            //
            this.ResultTB.AllowDrop = true;
            this.ResultTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultTB.Location = new System.Drawing.Point(94, 5);
            this.ResultTB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.ResultTB.Name = "ResultTB";
            this.ResultTB.Size = new System.Drawing.Size(468, 20);
            this.ResultTB.TabIndex = 1;
            this.ToolTip.SetToolTip(this.ResultTB, "The identifier for an object with methods.");
            //
            // ResultLB
            //
            this.ResultLB.AutoSize = true;
            this.ResultLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultLB.Location = new System.Drawing.Point(6, 3);
            this.ResultLB.Name = "ResultLB";
            this.ResultLB.Size = new System.Drawing.Size(84, 24);
            this.ResultLB.TabIndex = 0;
            this.ResultLB.Text = "Result";
            this.ResultLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.ResultLB, " ");
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
            this.RequestGB.Size = new System.Drawing.Size(572, 160);
            this.RequestGB.TabIndex = 20;
            this.RequestGB.TabStop = false;
            this.RequestGB.Text = "Delete References Request";
            //
            // BottomPN
            //
            this.BottomPN.Controls.Add(this.UseAsynchCK);
            this.BottomPN.Controls.Add(this.DeleteReferencesBTN);
            this.BottomPN.Controls.Add(this.CancelBTN);
            this.BottomPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPN.Location = new System.Drawing.Point(3, 319);
            this.BottomPN.Name = "BottomPN";
            this.BottomPN.Size = new System.Drawing.Size(578, 29);
            this.BottomPN.TabIndex = 0;
            //
            // UseAsynchCK
            //
            this.UseAsynchCK.AutoSize = true;
            this.UseAsynchCK.Location = new System.Drawing.Point(116, 7);
            this.UseAsynchCK.Name = "UseAsynchCK";
            this.UseAsynchCK.Size = new System.Drawing.Size(152, 17);
            this.UseAsynchCK.TabIndex = 10;
            this.UseAsynchCK.Text = "Use Asynchronous Pattern";
            this.UseAsynchCK.UseVisualStyleBackColor = true;
            //
            // DeleteReferencesBTN
            //
            this.DeleteReferencesBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteReferencesBTN.Location = new System.Drawing.Point(3, 3);
            this.DeleteReferencesBTN.Name = "DeleteReferencesBTN";
            this.DeleteReferencesBTN.Size = new System.Drawing.Size(107, 23);
            this.DeleteReferencesBTN.TabIndex = 9;
            this.DeleteReferencesBTN.Tag = "";
            this.DeleteReferencesBTN.Text = "Delete References";
            this.DeleteReferencesBTN.UseVisualStyleBackColor = true;
            this.DeleteReferencesBTN.Click += new System.EventHandler(this.DeleteReferencesBTN_Click);
            //
            // ResponseGB
            //
            this.ResponseGB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ResponseGB.Controls.Add(this.ResponsePN);
            this.ResponseGB.Location = new System.Drawing.Point(6, 257);
            this.ResponseGB.Name = "ResponseGB";
            this.ResponseGB.Size = new System.Drawing.Size(572, 59);
            this.ResponseGB.TabIndex = 21;
            this.ResponseGB.TabStop = false;
            this.ResponseGB.Text = "Delete References Response";
            //
            // ResponsePN
            //
            this.ResponsePN.AutoSize = true;
            this.ResponsePN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ResponsePN.ColumnCount = 3;
            this.ResponsePN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.ResponsePN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ResponsePN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ResponsePN.Controls.Add(this.ResultTB, 1, 0);
            this.ResponsePN.Controls.Add(this.ResultLB, 0, 0);
            this.ResponsePN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResponsePN.Location = new System.Drawing.Point(3, 16);
            this.ResponsePN.Name = "ResponsePN";
            this.ResponsePN.Padding = new System.Windows.Forms.Padding(3);
            this.ResponsePN.RowCount = 2;
            this.ResponsePN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ResponsePN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ResponsePN.Size = new System.Drawing.Size(566, 40);
            this.ResponsePN.TabIndex = 1;
            //
            // DeleteReferencesDlg
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(584, 348);
            this.Controls.Add(this.ResponseGB);
            this.Controls.Add(this.RequestGB);
            this.Controls.Add(this.InstructionsGB);
            this.Controls.Add(this.BottomPN);
            this.Name = "DeleteReferencesDlg";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Delete References Example";
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
        private System.Windows.Forms.TextBox SourceIdTB;
        private System.Windows.Forms.Label SourceIdLB;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Label IsForwardLB;
        private System.Windows.Forms.GroupBox InstructionsGB;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Button HelpBTN;
        private System.Windows.Forms.Button ShowCodeBTN;
        private System.Windows.Forms.Label InstructionsLB;
        private System.Windows.Forms.GroupBox RequestGB;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Panel BottomPN;
        private System.Windows.Forms.CheckBox UseAsynchCK;
        private System.Windows.Forms.Button DeleteReferencesBTN;
        private System.Windows.Forms.Button SourceIdBTN;
        private System.Windows.Forms.TextBox ReferenceTypeIdTB;
        private System.Windows.Forms.Label ReferenceTypeIdLB;
        private System.Windows.Forms.Button ReferenceTypeIdBTN;
        private System.Windows.Forms.Button TargetIdBTN;
        private System.Windows.Forms.TextBox TargetIdTB;
        private System.Windows.Forms.Label TargetIdLB;
        private System.Windows.Forms.GroupBox ResponseGB;
        private System.Windows.Forms.TableLayoutPanel ResponsePN;
        private System.Windows.Forms.TextBox ResultTB;
        private System.Windows.Forms.Label ResultLB;
        private System.Windows.Forms.CheckBox IsForwardCK;
        private System.Windows.Forms.Label DeleteBidirectionalLB;
        private System.Windows.Forms.CheckBox DeleteBidirectionalCK;
    }
}
