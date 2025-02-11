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
    partial class CreateDataMonitoredItemsDlg
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
            this.CreateBTN = new System.Windows.Forms.Button();
            this.SelectNodeBTN = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.DeadbandTypeCB = new System.Windows.Forms.ComboBox();
            this.DeadbandUD = new System.Windows.Forms.NumericUpDown();
            this.QueueSizeUD = new System.Windows.Forms.NumericUpDown();
            this.SamplingIntervalUD = new System.Windows.Forms.NumericUpDown();
            this.DiscardOldestCK = new System.Windows.Forms.CheckBox();
            this.MonitoringModeCB = new System.Windows.Forms.ComboBox();
            this.MonitoredItemsLV = new System.Windows.Forms.ListView();
            this.LastErrorCH = new System.Windows.Forms.ColumnHeader();
            this.MonitoredItemPN = new System.Windows.Forms.TableLayoutPanel();
            this.CurrentDeadbandTB = new System.Windows.Forms.TextBox();
            this.DeadbandTypeLB = new System.Windows.Forms.Label();
            this.MonitoringModeLB = new System.Windows.Forms.Label();
            this.DiscardOldestLB = new System.Windows.Forms.Label();
            this.CurrentQueueSizeTB = new System.Windows.Forms.TextBox();
            this.QueueSizeLB = new System.Windows.Forms.Label();
            this.SamplingIntervalLB = new System.Windows.Forms.Label();
            this.CurrentSamplingIntervalTB = new System.Windows.Forms.TextBox();
            this.CurrentMonitoringModeTB = new System.Windows.Forms.TextBox();
            this.CurrentDeadbandTypeTB = new System.Windows.Forms.TextBox();
            this.DeadbandLB = new System.Windows.Forms.Label();
            this.CurrentDiscardOldestCK = new System.Windows.Forms.CheckBox();
            this.InstructionsGB = new System.Windows.Forms.GroupBox();
            this.TopPN = new System.Windows.Forms.Panel();
            this.HelpBTN = new System.Windows.Forms.Button();
            this.ShowCodeBTN = new System.Windows.Forms.Button();
            this.InstructionsLB = new System.Windows.Forms.Label();
            this.ParametersGB = new System.Windows.Forms.GroupBox();
            this.MonitoredItemsGB = new System.Windows.Forms.GroupBox();
            ClientHandleCH = new System.Windows.Forms.ColumnHeader();
            NodeCH = new System.Windows.Forms.ColumnHeader();
            AttributeCH = new System.Windows.Forms.ColumnHeader();
            this.BottomPN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeadbandUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueueSizeUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SamplingIntervalUD)).BeginInit();
            this.MonitoredItemPN.SuspendLayout();
            this.InstructionsGB.SuspendLayout();
            this.TopPN.SuspendLayout();
            this.ParametersGB.SuspendLayout();
            this.MonitoredItemsGB.SuspendLayout();
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
            this.BottomPN.Controls.Add(this.CreateBTN);
            this.BottomPN.Controls.Add(this.SelectNodeBTN);
            this.BottomPN.Controls.Add(this.CancelBTN);
            this.BottomPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPN.Location = new System.Drawing.Point(3, 533);
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
            this.UseAsynchCK.TabIndex = 16;
            this.UseAsynchCK.Text = "Use Asynchronous Pattern";
            this.UseAsynchCK.UseVisualStyleBackColor = true;
            //
            // CreateBTN
            //
            this.CreateBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CreateBTN.Enabled = false;
            this.CreateBTN.Location = new System.Drawing.Point(3, 3);
            this.CreateBTN.Name = "CreateBTN";
            this.CreateBTN.Size = new System.Drawing.Size(75, 23);
            this.CreateBTN.TabIndex = 15;
            this.CreateBTN.Tag = "";
            this.CreateBTN.Text = "Create";
            this.CreateBTN.UseVisualStyleBackColor = true;
            this.CreateBTN.Click += new System.EventHandler(this.CreateBTN_Click);
            //
            // SelectNodeBTN
            //
            this.SelectNodeBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectNodeBTN.Location = new System.Drawing.Point(402, 3);
            this.SelectNodeBTN.Name = "SelectNodeBTN";
            this.SelectNodeBTN.Size = new System.Drawing.Size(96, 23);
            this.SelectNodeBTN.TabIndex = 2;
            this.SelectNodeBTN.Text = "Select Node...";
            this.ToolTip.SetToolTip(this.SelectNodeBTN, "Open a window to browse the address space for nodes to monitor.");
            this.SelectNodeBTN.UseVisualStyleBackColor = true;
            this.SelectNodeBTN.Click += new System.EventHandler(this.SelectNodeBTN_Click);
            //
            // CancelBTN
            //
            this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBTN.Location = new System.Drawing.Point(504, 3);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(70, 23);
            this.CancelBTN.TabIndex = 3;
            this.CancelBTN.Text = "Close";
            this.ToolTip.SetToolTip(this.CancelBTN, "Close the dialog.");
            this.CancelBTN.UseVisualStyleBackColor = true;
            //
            // DeadbandTypeCB
            //
            this.DeadbandTypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeadbandTypeCB.FormattingEnabled = true;
            this.DeadbandTypeCB.Location = new System.Drawing.Point(97, 108);
            this.DeadbandTypeCB.Name = "DeadbandTypeCB";
            this.DeadbandTypeCB.Size = new System.Drawing.Size(100, 21);
            this.DeadbandTypeCB.TabIndex = 13;
            this.ToolTip.SetToolTip(this.DeadbandTypeCB, "The deadband type to use when creating the items.");
            //
            // DeadbandUD
            //
            this.DeadbandUD.Location = new System.Drawing.Point(97, 135);
            this.DeadbandUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.DeadbandUD.Name = "DeadbandUD";
            this.DeadbandUD.Size = new System.Drawing.Size(100, 20);
            this.DeadbandUD.TabIndex = 16;
            this.ToolTip.SetToolTip(this.DeadbandUD, "The  deadband to use when creating the items.");
            //
            // QueueSizeUD
            //
            this.QueueSizeUD.Location = new System.Drawing.Point(97, 29);
            this.QueueSizeUD.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.QueueSizeUD.Name = "QueueSizeUD";
            this.QueueSizeUD.Size = new System.Drawing.Size(100, 20);
            this.QueueSizeUD.TabIndex = 4;
            this.ToolTip.SetToolTip(this.QueueSizeUD, "The queue size to use when creating the items.");
            this.QueueSizeUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            //
            // SamplingIntervalUD
            //
            this.SamplingIntervalUD.Location = new System.Drawing.Point(97, 3);
            this.SamplingIntervalUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.SamplingIntervalUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.SamplingIntervalUD.Name = "SamplingIntervalUD";
            this.SamplingIntervalUD.Size = new System.Drawing.Size(100, 20);
            this.SamplingIntervalUD.TabIndex = 1;
            this.ToolTip.SetToolTip(this.SamplingIntervalUD, "The sampling interval to use when creating the items.");
            this.SamplingIntervalUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            //
            // DiscardOldestCK
            //
            this.DiscardOldestCK.AutoSize = true;
            this.DiscardOldestCK.Checked = true;
            this.DiscardOldestCK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DiscardOldestCK.Location = new System.Drawing.Point(97, 58);
            this.DiscardOldestCK.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.DiscardOldestCK.Name = "DiscardOldestCK";
            this.DiscardOldestCK.Size = new System.Drawing.Size(15, 14);
            this.DiscardOldestCK.TabIndex = 7;
            this.ToolTip.SetToolTip(this.DiscardOldestCK, "Whether to discard the oldest values when the queue overflows.");
            this.DiscardOldestCK.UseVisualStyleBackColor = true;
            //
            // MonitoringModeCB
            //
            this.MonitoringModeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MonitoringModeCB.FormattingEnabled = true;
            this.MonitoringModeCB.Location = new System.Drawing.Point(97, 81);
            this.MonitoringModeCB.Name = "MonitoringModeCB";
            this.MonitoringModeCB.Size = new System.Drawing.Size(100, 21);
            this.MonitoringModeCB.TabIndex = 10;
            this.ToolTip.SetToolTip(this.MonitoringModeCB, "The monitoring mode to use when creating the items.");
            //
            // MonitoredItemsLV
            //
            this.MonitoredItemsLV.AllowDrop = true;
            this.MonitoredItemsLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            ClientHandleCH,
            NodeCH,
            AttributeCH,
            this.LastErrorCH});
            this.MonitoredItemsLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MonitoredItemsLV.FullRowSelect = true;
            this.MonitoredItemsLV.Location = new System.Drawing.Point(3, 16);
            this.MonitoredItemsLV.Name = "MonitoredItemsLV";
            this.MonitoredItemsLV.Size = new System.Drawing.Size(572, 235);
            this.MonitoredItemsLV.TabIndex = 20;
            this.MonitoredItemsLV.UseCompatibleStateImageBehavior = false;
            this.MonitoredItemsLV.View = System.Windows.Forms.View.Details;
            this.MonitoredItemsLV.SelectedIndexChanged += new System.EventHandler(this.MonitoredItemsLV_SelectedIndexChanged);
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
            this.MonitoredItemPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MonitoredItemPN.Controls.Add(this.CurrentDeadbandTB, 2, 5);
            this.MonitoredItemPN.Controls.Add(this.DeadbandTypeCB, 1, 4);
            this.MonitoredItemPN.Controls.Add(this.DeadbandUD, 1, 5);
            this.MonitoredItemPN.Controls.Add(this.DeadbandTypeLB, 0, 4);
            this.MonitoredItemPN.Controls.Add(this.MonitoringModeLB, 0, 3);
            this.MonitoredItemPN.Controls.Add(this.DiscardOldestLB, 0, 2);
            this.MonitoredItemPN.Controls.Add(this.CurrentQueueSizeTB, 2, 1);
            this.MonitoredItemPN.Controls.Add(this.QueueSizeLB, 0, 1);
            this.MonitoredItemPN.Controls.Add(this.SamplingIntervalLB, 0, 0);
            this.MonitoredItemPN.Controls.Add(this.CurrentSamplingIntervalTB, 2, 0);
            this.MonitoredItemPN.Controls.Add(this.QueueSizeUD, 1, 1);
            this.MonitoredItemPN.Controls.Add(this.SamplingIntervalUD, 1, 0);
            this.MonitoredItemPN.Controls.Add(this.CurrentMonitoringModeTB, 2, 3);
            this.MonitoredItemPN.Controls.Add(this.CurrentDeadbandTypeTB, 2, 4);
            this.MonitoredItemPN.Controls.Add(this.DeadbandLB, 0, 5);
            this.MonitoredItemPN.Controls.Add(this.DiscardOldestCK, 1, 2);
            this.MonitoredItemPN.Controls.Add(this.CurrentDiscardOldestCK, 2, 2);
            this.MonitoredItemPN.Controls.Add(this.MonitoringModeCB, 1, 3);
            this.MonitoredItemPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MonitoredItemPN.Location = new System.Drawing.Point(3, 16);
            this.MonitoredItemPN.Name = "MonitoredItemPN";
            this.MonitoredItemPN.RowCount = 8;
            this.MonitoredItemPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MonitoredItemPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MonitoredItemPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MonitoredItemPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MonitoredItemPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MonitoredItemPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MonitoredItemPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MonitoredItemPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MonitoredItemPN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MonitoredItemPN.Size = new System.Drawing.Size(572, 160);
            this.MonitoredItemPN.TabIndex = 0;
            //
            // CurrentDeadbandTB
            //
            this.CurrentDeadbandTB.Enabled = false;
            this.CurrentDeadbandTB.Location = new System.Drawing.Point(203, 135);
            this.CurrentDeadbandTB.Name = "CurrentDeadbandTB";
            this.CurrentDeadbandTB.Size = new System.Drawing.Size(100, 20);
            this.CurrentDeadbandTB.TabIndex = 17;
            //
            // DeadbandTypeLB
            //
            this.DeadbandTypeLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.DeadbandTypeLB.AutoSize = true;
            this.DeadbandTypeLB.Location = new System.Drawing.Point(3, 105);
            this.DeadbandTypeLB.Name = "DeadbandTypeLB";
            this.DeadbandTypeLB.Size = new System.Drawing.Size(84, 27);
            this.DeadbandTypeLB.TabIndex = 12;
            this.DeadbandTypeLB.Text = "Deadband Type";
            this.DeadbandTypeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // MonitoringModeLB
            //
            this.MonitoringModeLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.MonitoringModeLB.AutoSize = true;
            this.MonitoringModeLB.Location = new System.Drawing.Point(3, 78);
            this.MonitoringModeLB.Name = "MonitoringModeLB";
            this.MonitoringModeLB.Size = new System.Drawing.Size(86, 27);
            this.MonitoringModeLB.TabIndex = 9;
            this.MonitoringModeLB.Text = "Monitoring Mode";
            this.MonitoringModeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // DiscardOldestLB
            //
            this.DiscardOldestLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.DiscardOldestLB.AutoSize = true;
            this.DiscardOldestLB.Location = new System.Drawing.Point(3, 52);
            this.DiscardOldestLB.Name = "DiscardOldestLB";
            this.DiscardOldestLB.Size = new System.Drawing.Size(76, 26);
            this.DiscardOldestLB.TabIndex = 6;
            this.DiscardOldestLB.Text = "Discard Oldest";
            this.DiscardOldestLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // CurrentQueueSizeTB
            //
            this.CurrentQueueSizeTB.Enabled = false;
            this.CurrentQueueSizeTB.Location = new System.Drawing.Point(203, 29);
            this.CurrentQueueSizeTB.Name = "CurrentQueueSizeTB";
            this.CurrentQueueSizeTB.Size = new System.Drawing.Size(100, 20);
            this.CurrentQueueSizeTB.TabIndex = 5;
            //
            // QueueSizeLB
            //
            this.QueueSizeLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.QueueSizeLB.AutoSize = true;
            this.QueueSizeLB.Location = new System.Drawing.Point(3, 26);
            this.QueueSizeLB.Name = "QueueSizeLB";
            this.QueueSizeLB.Size = new System.Drawing.Size(62, 26);
            this.QueueSizeLB.TabIndex = 3;
            this.QueueSizeLB.Text = "Queue Size";
            this.QueueSizeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // SamplingIntervalLB
            //
            this.SamplingIntervalLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.SamplingIntervalLB.AutoSize = true;
            this.SamplingIntervalLB.Location = new System.Drawing.Point(3, 0);
            this.SamplingIntervalLB.Name = "SamplingIntervalLB";
            this.SamplingIntervalLB.Size = new System.Drawing.Size(88, 26);
            this.SamplingIntervalLB.TabIndex = 0;
            this.SamplingIntervalLB.Text = "Sampling Interval";
            this.SamplingIntervalLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // CurrentSamplingIntervalTB
            //
            this.CurrentSamplingIntervalTB.Enabled = false;
            this.CurrentSamplingIntervalTB.Location = new System.Drawing.Point(203, 3);
            this.CurrentSamplingIntervalTB.Name = "CurrentSamplingIntervalTB";
            this.CurrentSamplingIntervalTB.Size = new System.Drawing.Size(100, 20);
            this.CurrentSamplingIntervalTB.TabIndex = 2;
            //
            // CurrentMonitoringModeTB
            //
            this.CurrentMonitoringModeTB.Enabled = false;
            this.CurrentMonitoringModeTB.Location = new System.Drawing.Point(203, 81);
            this.CurrentMonitoringModeTB.Name = "CurrentMonitoringModeTB";
            this.CurrentMonitoringModeTB.Size = new System.Drawing.Size(100, 20);
            this.CurrentMonitoringModeTB.TabIndex = 11;
            //
            // CurrentDeadbandTypeTB
            //
            this.CurrentDeadbandTypeTB.Enabled = false;
            this.CurrentDeadbandTypeTB.Location = new System.Drawing.Point(203, 108);
            this.CurrentDeadbandTypeTB.Name = "CurrentDeadbandTypeTB";
            this.CurrentDeadbandTypeTB.Size = new System.Drawing.Size(100, 20);
            this.CurrentDeadbandTypeTB.TabIndex = 14;
            //
            // DeadbandLB
            //
            this.DeadbandLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.DeadbandLB.AutoSize = true;
            this.DeadbandLB.Location = new System.Drawing.Point(3, 132);
            this.DeadbandLB.Name = "DeadbandLB";
            this.DeadbandLB.Size = new System.Drawing.Size(57, 26);
            this.DeadbandLB.TabIndex = 15;
            this.DeadbandLB.Text = "Deadband";
            this.DeadbandLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // CurrentDiscardOldestCK
            //
            this.CurrentDiscardOldestCK.AutoSize = true;
            this.CurrentDiscardOldestCK.Enabled = false;
            this.CurrentDiscardOldestCK.Location = new System.Drawing.Point(203, 58);
            this.CurrentDiscardOldestCK.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.CurrentDiscardOldestCK.Name = "CurrentDiscardOldestCK";
            this.CurrentDiscardOldestCK.Size = new System.Drawing.Size(15, 14);
            this.CurrentDiscardOldestCK.TabIndex = 8;
            this.CurrentDiscardOldestCK.UseVisualStyleBackColor = true;
            //
            // InstructionsGB
            //
            this.InstructionsGB.BackColor = System.Drawing.Color.Transparent;
            this.InstructionsGB.Controls.Add(this.TopPN);
            this.InstructionsGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.InstructionsGB.Location = new System.Drawing.Point(3, 5);
            this.InstructionsGB.Name = "InstructionsGB";
            this.InstructionsGB.Size = new System.Drawing.Size(578, 81);
            this.InstructionsGB.TabIndex = 22;
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
            // ParametersGB
            //
            this.ParametersGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ParametersGB.Controls.Add(this.MonitoredItemPN);
            this.ParametersGB.Location = new System.Drawing.Point(3, 91);
            this.ParametersGB.Name = "ParametersGB";
            this.ParametersGB.Size = new System.Drawing.Size(578, 179);
            this.ParametersGB.TabIndex = 23;
            this.ParametersGB.TabStop = false;
            this.ParametersGB.Text = "Monitoring Parameters";
            //
            // MonitoredItemsGB
            //
            this.MonitoredItemsGB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MonitoredItemsGB.Controls.Add(this.MonitoredItemsLV);
            this.MonitoredItemsGB.Location = new System.Drawing.Point(3, 276);
            this.MonitoredItemsGB.Name = "MonitoredItemsGB";
            this.MonitoredItemsGB.Size = new System.Drawing.Size(578, 254);
            this.MonitoredItemsGB.TabIndex = 24;
            this.MonitoredItemsGB.TabStop = false;
            this.MonitoredItemsGB.Text = "Monitored Items to Create";
            //
            // CreateDataMonitoredItemsDlg
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.MonitoredItemsGB);
            this.Controls.Add(this.ParametersGB);
            this.Controls.Add(this.InstructionsGB);
            this.Controls.Add(this.BottomPN);
            this.Name = "CreateDataMonitoredItemsDlg";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Data Monitored Items Example";
            this.BottomPN.ResumeLayout(false);
            this.BottomPN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeadbandUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueueSizeUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SamplingIntervalUD)).EndInit();
            this.MonitoredItemPN.ResumeLayout(false);
            this.MonitoredItemPN.PerformLayout();
            this.InstructionsGB.ResumeLayout(false);
            this.TopPN.ResumeLayout(false);
            this.ParametersGB.ResumeLayout(false);
            this.MonitoredItemsGB.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BottomPN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.ListView MonitoredItemsLV;
        private System.Windows.Forms.ColumnHeader LastErrorCH;
        private System.Windows.Forms.TableLayoutPanel MonitoredItemPN;
        private System.Windows.Forms.TextBox CurrentDeadbandTB;
        private System.Windows.Forms.ComboBox DeadbandTypeCB;
        private System.Windows.Forms.NumericUpDown DeadbandUD;
        private System.Windows.Forms.Label DeadbandTypeLB;
        private System.Windows.Forms.Label MonitoringModeLB;
        private System.Windows.Forms.Label DiscardOldestLB;
        private System.Windows.Forms.TextBox CurrentQueueSizeTB;
        private System.Windows.Forms.Label QueueSizeLB;
        private System.Windows.Forms.Label SamplingIntervalLB;
        private System.Windows.Forms.TextBox CurrentSamplingIntervalTB;
        private System.Windows.Forms.NumericUpDown QueueSizeUD;
        private System.Windows.Forms.NumericUpDown SamplingIntervalUD;
        private System.Windows.Forms.TextBox CurrentMonitoringModeTB;
        private System.Windows.Forms.TextBox CurrentDeadbandTypeTB;
        private System.Windows.Forms.Label DeadbandLB;
        private System.Windows.Forms.CheckBox DiscardOldestCK;
        private System.Windows.Forms.CheckBox CurrentDiscardOldestCK;
        private System.Windows.Forms.ComboBox MonitoringModeCB;
        private System.Windows.Forms.Button SelectNodeBTN;
        private System.Windows.Forms.GroupBox InstructionsGB;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Button HelpBTN;
        private System.Windows.Forms.Button ShowCodeBTN;
        private System.Windows.Forms.Label InstructionsLB;
        private System.Windows.Forms.GroupBox ParametersGB;
        private System.Windows.Forms.GroupBox MonitoredItemsGB;
        private System.Windows.Forms.CheckBox UseAsynchCK;
        private System.Windows.Forms.Button CreateBTN;
    }
}
