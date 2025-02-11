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
    partial class CallMethodDlg
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
            System.Windows.Forms.ColumnHeader Parameter1CH;
            System.Windows.Forms.ColumnHeader Value1CH;
            System.Windows.Forms.ColumnHeader Parameter2CH;
            System.Windows.Forms.ColumnHeader Value2CH;
            this.MainPN = new System.Windows.Forms.TableLayoutPanel();
            this.NodeIdBTN = new System.Windows.Forms.Button();
            this.InputArgumentsLV = new System.Windows.Forms.ListView();
            this.MethodLB = new System.Windows.Forms.Label();
            this.NodeIdTB = new System.Windows.Forms.TextBox();
            this.NodeIdLB = new System.Windows.Forms.Label();
            this.MethodCB = new System.Windows.Forms.ComboBox();
            this.OutputArgumentsLV = new System.Windows.Forms.ListView();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.CancelBTN = new System.Windows.Forms.Button();
            this.InstructionsGB = new System.Windows.Forms.GroupBox();
            this.TopPN = new System.Windows.Forms.Panel();
            this.HelpBTN = new System.Windows.Forms.Button();
            this.ShowCodeBTN = new System.Windows.Forms.Button();
            this.InstructionsLB = new System.Windows.Forms.Label();
            this.RequestGB = new System.Windows.Forms.GroupBox();
            this.RespnoseGB = new System.Windows.Forms.GroupBox();
            this.BottomPN = new System.Windows.Forms.Panel();
            this.UseAsynchCK = new System.Windows.Forms.CheckBox();
            this.ReadHistoryBTN = new System.Windows.Forms.Button();
            Parameter1CH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Value1CH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Parameter2CH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Value2CH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MainPN.SuspendLayout();
            this.InstructionsGB.SuspendLayout();
            this.TopPN.SuspendLayout();
            this.RequestGB.SuspendLayout();
            this.RespnoseGB.SuspendLayout();
            this.BottomPN.SuspendLayout();
            this.SuspendLayout();
            //
            // Parameter1CH
            //
            Parameter1CH.Text = "Parameter";
            Parameter1CH.Width = 102;
            //
            // Value1CH
            //
            Value1CH.Text = "Value";
            Value1CH.Width = 104;
            //
            // Parameter2CH
            //
            Parameter2CH.Text = "Parameter";
            Parameter2CH.Width = 105;
            //
            // Value2CH
            //
            Value2CH.Text = "Value";
            Value2CH.Width = 102;
            //
            // MainPN
            //
            this.MainPN.AutoSize = true;
            this.MainPN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MainPN.ColumnCount = 3;
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.Controls.Add(this.NodeIdBTN, 2, 0);
            this.MainPN.Controls.Add(this.InputArgumentsLV, 0, 2);
            this.MainPN.Controls.Add(this.MethodLB, 0, 1);
            this.MainPN.Controls.Add(this.NodeIdTB, 1, 0);
            this.MainPN.Controls.Add(this.NodeIdLB, 0, 0);
            this.MainPN.Controls.Add(this.MethodCB, 1, 1);
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(3, 16);
            this.MainPN.Name = "MainPN";
            this.MainPN.Padding = new System.Windows.Forms.Padding(3);
            this.MainPN.RowCount = 3;
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPN.Size = new System.Drawing.Size(566, 156);
            this.MainPN.TabIndex = 1;
            //
            // NodeIdBTN
            //
            this.NodeIdBTN.AutoSize = true;
            this.NodeIdBTN.Location = new System.Drawing.Point(537, 4);
            this.NodeIdBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.NodeIdBTN.Name = "NodeIdBTN";
            this.NodeIdBTN.Size = new System.Drawing.Size(26, 23);
            this.NodeIdBTN.TabIndex = 22;
            this.NodeIdBTN.Text = "...";
            this.ToolTip.SetToolTip(this.NodeIdBTN, "Displays a dialog to select an object node with methods.");
            this.NodeIdBTN.UseVisualStyleBackColor = true;
            this.NodeIdBTN.Click += new System.EventHandler(this.NodeIdBTN_Click);
            //
            // InputArgumentsLV
            //
            this.InputArgumentsLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            Parameter1CH,
            Value1CH});
            this.MainPN.SetColumnSpan(this.InputArgumentsLV, 3);
            this.InputArgumentsLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputArgumentsLV.FullRowSelect = true;
            this.InputArgumentsLV.HideSelection = false;
            this.InputArgumentsLV.Location = new System.Drawing.Point(6, 55);
            this.InputArgumentsLV.Name = "InputArgumentsLV";
            this.InputArgumentsLV.Size = new System.Drawing.Size(554, 95);
            this.InputArgumentsLV.TabIndex = 4;
            this.InputArgumentsLV.UseCompatibleStateImageBehavior = false;
            this.InputArgumentsLV.View = System.Windows.Forms.View.Details;
            this.InputArgumentsLV.DoubleClick += new System.EventHandler(this.InputArgumentsLV_DoubleClick);
            //
            // MethodLB
            //
            this.MethodLB.AutoSize = true;
            this.MethodLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MethodLB.Location = new System.Drawing.Point(6, 28);
            this.MethodLB.Name = "MethodLB";
            this.MethodLB.Size = new System.Drawing.Size(43, 24);
            this.MethodLB.TabIndex = 2;
            this.MethodLB.Text = "Method";
            this.MethodLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // NodeIdTB
            //
            this.NodeIdTB.AllowDrop = true;
            this.NodeIdTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodeIdTB.Location = new System.Drawing.Point(53, 5);
            this.NodeIdTB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.NodeIdTB.Name = "NodeIdTB";
            this.NodeIdTB.Size = new System.Drawing.Size(482, 20);
            this.NodeIdTB.TabIndex = 1;
            this.NodeIdTB.Text = "ns=2;s=Demo.Method";
            this.ToolTip.SetToolTip(this.NodeIdTB, "The identifier for an object with methods.");
            this.NodeIdTB.TextChanged += new System.EventHandler(this.NodeIdTB_TextChanged);
            //
            // NodeIdLB
            //
            this.NodeIdLB.AutoSize = true;
            this.NodeIdLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodeIdLB.Location = new System.Drawing.Point(6, 3);
            this.NodeIdLB.Name = "NodeIdLB";
            this.NodeIdLB.Size = new System.Drawing.Size(43, 25);
            this.NodeIdLB.TabIndex = 0;
            this.NodeIdLB.Text = "Object";
            this.NodeIdLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.NodeIdLB, " ");
            //
            // MethodCB
            //
            this.MethodCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MethodCB.FormattingEnabled = true;
            this.MethodCB.Location = new System.Drawing.Point(53, 30);
            this.MethodCB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 1);
            this.MethodCB.Name = "MethodCB";
            this.MethodCB.Size = new System.Drawing.Size(176, 21);
            this.MethodCB.TabIndex = 3;
            this.ToolTip.SetToolTip(this.MethodCB, "The method to invoke.");
            this.MethodCB.SelectedIndexChanged += new System.EventHandler(this.MethodCB_SelectedIndexChanged);
            //
            // OutputArgumentsLV
            //
            this.OutputArgumentsLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            Parameter2CH,
            Value2CH});
            this.OutputArgumentsLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputArgumentsLV.FullRowSelect = true;
            this.OutputArgumentsLV.HideSelection = false;
            this.OutputArgumentsLV.Location = new System.Drawing.Point(6, 16);
            this.OutputArgumentsLV.Name = "OutputArgumentsLV";
            this.OutputArgumentsLV.Size = new System.Drawing.Size(560, 96);
            this.OutputArgumentsLV.TabIndex = 5;
            this.OutputArgumentsLV.UseCompatibleStateImageBehavior = false;
            this.OutputArgumentsLV.View = System.Windows.Forms.View.Details;
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
            this.RequestGB.Controls.Add(this.MainPN);
            this.RequestGB.Location = new System.Drawing.Point(6, 91);
            this.RequestGB.Name = "RequestGB";
            this.RequestGB.Size = new System.Drawing.Size(572, 175);
            this.RequestGB.TabIndex = 20;
            this.RequestGB.TabStop = false;
            this.RequestGB.Text = "Call Method Request";
            //
            // RespnoseGB
            //
            this.RespnoseGB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RespnoseGB.Controls.Add(this.OutputArgumentsLV);
            this.RespnoseGB.Location = new System.Drawing.Point(6, 272);
            this.RespnoseGB.Name = "RespnoseGB";
            this.RespnoseGB.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.RespnoseGB.Size = new System.Drawing.Size(572, 115);
            this.RespnoseGB.TabIndex = 21;
            this.RespnoseGB.TabStop = false;
            this.RespnoseGB.Text = "Call Method Response";
            //
            // BottomPN
            //
            this.BottomPN.Controls.Add(this.UseAsynchCK);
            this.BottomPN.Controls.Add(this.ReadHistoryBTN);
            this.BottomPN.Controls.Add(this.CancelBTN);
            this.BottomPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPN.Location = new System.Drawing.Point(3, 390);
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
            // ReadHistoryBTN
            //
            this.ReadHistoryBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ReadHistoryBTN.Location = new System.Drawing.Point(3, 3);
            this.ReadHistoryBTN.Name = "ReadHistoryBTN";
            this.ReadHistoryBTN.Size = new System.Drawing.Size(75, 23);
            this.ReadHistoryBTN.TabIndex = 9;
            this.ReadHistoryBTN.Tag = "";
            this.ReadHistoryBTN.Text = "Call";
            this.ReadHistoryBTN.UseVisualStyleBackColor = true;
            this.ReadHistoryBTN.Click += new System.EventHandler(this.CallMethodBTN_Click);
            //
            // CallMethodDlg
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(584, 419);
            this.Controls.Add(this.RespnoseGB);
            this.Controls.Add(this.RequestGB);
            this.Controls.Add(this.InstructionsGB);
            this.Controls.Add(this.BottomPN);
            this.Name = "CallMethodDlg";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Call Method Example";
            this.MainPN.ResumeLayout(false);
            this.MainPN.PerformLayout();
            this.InstructionsGB.ResumeLayout(false);
            this.TopPN.ResumeLayout(false);
            this.RequestGB.ResumeLayout(false);
            this.RequestGB.PerformLayout();
            this.RespnoseGB.ResumeLayout(false);
            this.BottomPN.ResumeLayout(false);
            this.BottomPN.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainPN;
        private System.Windows.Forms.TextBox NodeIdTB;
        private System.Windows.Forms.Label NodeIdLB;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Label MethodLB;
        private System.Windows.Forms.ComboBox MethodCB;
        private System.Windows.Forms.ListView OutputArgumentsLV;
        private System.Windows.Forms.ListView InputArgumentsLV;
        private System.Windows.Forms.GroupBox InstructionsGB;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Button HelpBTN;
        private System.Windows.Forms.Button ShowCodeBTN;
        private System.Windows.Forms.Label InstructionsLB;
        private System.Windows.Forms.GroupBox RequestGB;
        private System.Windows.Forms.GroupBox RespnoseGB;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Panel BottomPN;
        private System.Windows.Forms.CheckBox UseAsynchCK;
        private System.Windows.Forms.Button ReadHistoryBTN;
        private System.Windows.Forms.Button NodeIdBTN;
    }
}
