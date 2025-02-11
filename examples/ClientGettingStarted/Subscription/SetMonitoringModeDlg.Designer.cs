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
    partial class SetMonitoringModeDlg
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
            System.Windows.Forms.ColumnHeader ClientHandleCH;
            System.Windows.Forms.ColumnHeader NodeCH;
            System.Windows.Forms.ColumnHeader AttributeCH;
            this.BottomPN = new System.Windows.Forms.Panel();
            this.UseAsynchCK = new System.Windows.Forms.CheckBox();
            this.ModifyBTN = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.MonitoringModeCB = new System.Windows.Forms.ComboBox();
            this.MonitoredItemsLV = new System.Windows.Forms.ListView();
            this.LastErrorCH = new System.Windows.Forms.ColumnHeader();
            this.MonitoredItemPN = new System.Windows.Forms.TableLayoutPanel();
            this.MonitoringModeLB = new System.Windows.Forms.Label();
            this.CurrentMonitoringModeTB = new System.Windows.Forms.TextBox();
            this.InstructionsGB = new System.Windows.Forms.GroupBox();
            this.TopPN = new System.Windows.Forms.Panel();
            this.HelpBTN = new System.Windows.Forms.Button();
            this.ShowCodeBTN = new System.Windows.Forms.Button();
            this.InstructionsLB = new System.Windows.Forms.Label();
            this.RequestGB = new System.Windows.Forms.GroupBox();
            ClientHandleCH = new System.Windows.Forms.ColumnHeader();
            NodeCH = new System.Windows.Forms.ColumnHeader();
            AttributeCH = new System.Windows.Forms.ColumnHeader();
            this.BottomPN.SuspendLayout();
            this.MonitoredItemPN.SuspendLayout();
            this.InstructionsGB.SuspendLayout();
            this.TopPN.SuspendLayout();
            this.RequestGB.SuspendLayout();
            this.SuspendLayout();
            //
            // ClientHandleCH
            //
            ClientHandleCH.Text = "";
            ClientHandleCH.Width = 11;
            //
            // NodeCH
            //
            NodeCH.Text = "Node";
            //
            // AttributeCH
            //
            AttributeCH.Text = "Attribute";
            //
            // BottomPN
            //
            this.BottomPN.Controls.Add(this.UseAsynchCK);
            this.BottomPN.Controls.Add(this.ModifyBTN);
            this.BottomPN.Controls.Add(this.CancelBTN);
            this.BottomPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPN.Location = new System.Drawing.Point(3, 333);
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
            this.UseAsynchCK.TabIndex = 22;
            this.UseAsynchCK.Text = "Use Asynchronous Pattern";
            this.UseAsynchCK.UseVisualStyleBackColor = true;
            //
            // ModifyBTN
            //
            this.ModifyBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ModifyBTN.Location = new System.Drawing.Point(3, 3);
            this.ModifyBTN.Name = "ModifyBTN";
            this.ModifyBTN.Size = new System.Drawing.Size(75, 23);
            this.ModifyBTN.TabIndex = 21;
            this.ModifyBTN.Tag = "";
            this.ModifyBTN.Text = "Modify";
            this.ModifyBTN.UseVisualStyleBackColor = true;
            this.ModifyBTN.Click += new System.EventHandler(this.ModifyBTN_Click);
            //
            // CancelBTN
            //
            this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBTN.Location = new System.Drawing.Point(504, 3);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(70, 23);
            this.CancelBTN.TabIndex = 2;
            this.CancelBTN.Text = "Close";
            this.ToolTip.SetToolTip(this.CancelBTN, "Close the dialog.");
            this.CancelBTN.UseVisualStyleBackColor = true;
            //
            // MonitoringModeCB
            //
            this.MonitoringModeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MonitoringModeCB.FormattingEnabled = true;
            this.MonitoringModeCB.Location = new System.Drawing.Point(95, 3);
            this.MonitoringModeCB.Name = "MonitoringModeCB";
            this.MonitoringModeCB.Size = new System.Drawing.Size(100, 21);
            this.MonitoringModeCB.TabIndex = 17;
            this.ToolTip.SetToolTip(this.MonitoringModeCB, "The monitoring mode to set.");
            //
            // MonitoredItemsLV
            //
            this.MonitoredItemsLV.AllowDrop = true;
            this.MonitoredItemsLV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MonitoredItemsLV.CheckBoxes = true;
            this.MonitoredItemsLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            ClientHandleCH,
            NodeCH,
            AttributeCH,
            this.LastErrorCH});
            this.MonitoredItemPN.SetColumnSpan(this.MonitoredItemsLV, 3);
            this.MonitoredItemsLV.FullRowSelect = true;
            this.MonitoredItemsLV.Location = new System.Drawing.Point(3, 30);
            this.MonitoredItemsLV.Name = "MonitoredItemsLV";
            this.MonitoredItemsLV.Size = new System.Drawing.Size(560, 181);
            this.MonitoredItemsLV.TabIndex = 15;
            this.MonitoredItemsLV.UseCompatibleStateImageBehavior = false;
            this.MonitoredItemsLV.View = System.Windows.Forms.View.Details;
            this.MonitoredItemsLV.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.MonitoredItemsLV_ItemChecked);
            //
            // LastErrorCH
            //
            this.LastErrorCH.Text = "LastError";
            this.LastErrorCH.Width = 99;
            //
            // MonitoredItemPN
            //
            this.MonitoredItemPN.ColumnCount = 3;
            this.MonitoredItemPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MonitoredItemPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MonitoredItemPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MonitoredItemPN.Controls.Add(this.MonitoringModeLB, 0, 0);
            this.MonitoredItemPN.Controls.Add(this.CurrentMonitoringModeTB, 2, 0);
            this.MonitoredItemPN.Controls.Add(this.MonitoringModeCB, 1, 0);
            this.MonitoredItemPN.Controls.Add(this.MonitoredItemsLV, 0, 1);
            this.MonitoredItemPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MonitoredItemPN.Location = new System.Drawing.Point(3, 16);
            this.MonitoredItemPN.Name = "MonitoredItemPN";
            this.MonitoredItemPN.RowCount = 3;
            this.MonitoredItemPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MonitoredItemPN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MonitoredItemPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MonitoredItemPN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MonitoredItemPN.Size = new System.Drawing.Size(566, 214);
            this.MonitoredItemPN.TabIndex = 1;
            //
            // MonitoringModeLB
            //
            this.MonitoringModeLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.MonitoringModeLB.AutoSize = true;
            this.MonitoringModeLB.Location = new System.Drawing.Point(3, 0);
            this.MonitoringModeLB.Name = "MonitoringModeLB";
            this.MonitoringModeLB.Size = new System.Drawing.Size(86, 27);
            this.MonitoringModeLB.TabIndex = 16;
            this.MonitoringModeLB.Text = "Monitoring Mode";
            this.MonitoringModeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // CurrentMonitoringModeTB
            //
            this.CurrentMonitoringModeTB.BackColor = System.Drawing.SystemColors.Window;
            this.CurrentMonitoringModeTB.Enabled = false;
            this.CurrentMonitoringModeTB.Location = new System.Drawing.Point(201, 3);
            this.CurrentMonitoringModeTB.Name = "CurrentMonitoringModeTB";
            this.CurrentMonitoringModeTB.ReadOnly = true;
            this.CurrentMonitoringModeTB.Size = new System.Drawing.Size(100, 20);
            this.CurrentMonitoringModeTB.TabIndex = 18;
            //
            // InstructionsGB
            //
            this.InstructionsGB.BackColor = System.Drawing.Color.Transparent;
            this.InstructionsGB.Controls.Add(this.TopPN);
            this.InstructionsGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.InstructionsGB.Location = new System.Drawing.Point(3, 5);
            this.InstructionsGB.Name = "InstructionsGB";
            this.InstructionsGB.Size = new System.Drawing.Size(578, 81);
            this.InstructionsGB.TabIndex = 26;
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
            this.RequestGB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RequestGB.Controls.Add(this.MonitoredItemPN);
            this.RequestGB.Location = new System.Drawing.Point(6, 97);
            this.RequestGB.Name = "RequestGB";
            this.RequestGB.Size = new System.Drawing.Size(572, 233);
            this.RequestGB.TabIndex = 27;
            this.RequestGB.TabStop = false;
            this.RequestGB.Text = "Request Parameters";
            //
            // SetMonitoringModeDlg
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.RequestGB);
            this.Controls.Add(this.InstructionsGB);
            this.Controls.Add(this.BottomPN);
            this.Name = "SetMonitoringModeDlg";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Monitoring Mode";
            this.BottomPN.ResumeLayout(false);
            this.BottomPN.PerformLayout();
            this.MonitoredItemPN.ResumeLayout(false);
            this.MonitoredItemPN.PerformLayout();
            this.InstructionsGB.ResumeLayout(false);
            this.TopPN.ResumeLayout(false);
            this.RequestGB.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel BottomPN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.ListView MonitoredItemsLV;
        private System.Windows.Forms.ColumnHeader LastErrorCH;
        private System.Windows.Forms.TableLayoutPanel MonitoredItemPN;
        private System.Windows.Forms.Label MonitoringModeLB;
        private System.Windows.Forms.TextBox CurrentMonitoringModeTB;
        private System.Windows.Forms.ComboBox MonitoringModeCB;
        private System.Windows.Forms.GroupBox InstructionsGB;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Button HelpBTN;
        private System.Windows.Forms.Button ShowCodeBTN;
        private System.Windows.Forms.Label InstructionsLB;
        private System.Windows.Forms.GroupBox RequestGB;
        private System.Windows.Forms.CheckBox UseAsynchCK;
        private System.Windows.Forms.Button ModifyBTN;
    }
}
