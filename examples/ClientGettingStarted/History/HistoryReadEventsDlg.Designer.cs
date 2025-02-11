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
    partial class HistoryReadEventsDlg
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
            this.MaxReturnValuesCK = new System.Windows.Forms.CheckBox();
            this.EndTimeCK = new System.Windows.Forms.CheckBox();
            this.StartTimeCK = new System.Windows.Forms.CheckBox();
            this.EndTimeDP = new System.Windows.Forms.DateTimePicker();
            this.MaxReturnValuesLB = new System.Windows.Forms.Label();
            this.EndTimeLB = new System.Windows.Forms.Label();
            this.StartTimeLB = new System.Windows.Forms.Label();
            this.NodeIdTB = new System.Windows.Forms.TextBox();
            this.NodeIdLB = new System.Windows.Forms.Label();
            this.StartTimeDP = new System.Windows.Forms.DateTimePicker();
            this.MaxReturnValuesNP = new System.Windows.Forms.NumericUpDown();
            this.ResultsDV = new System.Windows.Forms.DataGridView();
            this.TimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiveTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SourceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeverityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MessageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateResultColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BottomPN = new System.Windows.Forms.Panel();
            this.EditFilterButton = new System.Windows.Forms.Button();
            this.UseAsynchCK = new System.Windows.Forms.CheckBox();
            this.ReadHistoryBTN = new System.Windows.Forms.Button();
            this.ReleaseContinuationPointBTN = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.InstructionsGB = new System.Windows.Forms.GroupBox();
            this.TopPN = new System.Windows.Forms.Panel();
            this.HelpBTN = new System.Windows.Forms.Button();
            this.ShowCodeBTN = new System.Windows.Forms.Button();
            this.InstructionsLB = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ResponseGB = new System.Windows.Forms.GroupBox();
            this.MainPN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxReturnValuesNP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsDV)).BeginInit();
            this.BottomPN.SuspendLayout();
            this.InstructionsGB.SuspendLayout();
            this.TopPN.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ResponseGB.SuspendLayout();
            this.SuspendLayout();
            //
            // MainPN
            //
            this.MainPN.ColumnCount = 3;
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.Controls.Add(this.NodeIdBTN, 2, 0);
            this.MainPN.Controls.Add(this.MaxReturnValuesCK, 2, 3);
            this.MainPN.Controls.Add(this.EndTimeCK, 2, 2);
            this.MainPN.Controls.Add(this.StartTimeCK, 2, 1);
            this.MainPN.Controls.Add(this.EndTimeDP, 1, 2);
            this.MainPN.Controls.Add(this.MaxReturnValuesLB, 0, 3);
            this.MainPN.Controls.Add(this.EndTimeLB, 0, 2);
            this.MainPN.Controls.Add(this.StartTimeLB, 0, 1);
            this.MainPN.Controls.Add(this.NodeIdTB, 1, 0);
            this.MainPN.Controls.Add(this.NodeIdLB, 0, 0);
            this.MainPN.Controls.Add(this.StartTimeDP, 1, 1);
            this.MainPN.Controls.Add(this.MaxReturnValuesNP, 1, 3);
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
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainPN.Size = new System.Drawing.Size(566, 121);
            this.MainPN.TabIndex = 0;
            //
            // NodeIdBTN
            //
            this.NodeIdBTN.AutoSize = true;
            this.NodeIdBTN.Location = new System.Drawing.Point(537, 4);
            this.NodeIdBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.NodeIdBTN.Name = "NodeIdBTN";
            this.NodeIdBTN.Size = new System.Drawing.Size(26, 23);
            this.NodeIdBTN.TabIndex = 21;
            this.NodeIdBTN.Text = "...";
            this.ToolTip.SetToolTip(this.NodeIdBTN, "Displays a dialog to select a history data variable.");
            this.NodeIdBTN.UseVisualStyleBackColor = true;
            this.NodeIdBTN.Click += new System.EventHandler(this.NodeIdBTN_Click);
            //
            // MaxReturnValuesCK
            //
            this.MaxReturnValuesCK.AutoSize = true;
            this.MaxReturnValuesCK.Checked = true;
            this.MaxReturnValuesCK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MaxReturnValuesCK.Location = new System.Drawing.Point(537, 81);
            this.MaxReturnValuesCK.Margin = new System.Windows.Forms.Padding(1, 5, 1, 5);
            this.MaxReturnValuesCK.Name = "MaxReturnValuesCK";
            this.MaxReturnValuesCK.Size = new System.Drawing.Size(15, 14);
            this.MaxReturnValuesCK.TabIndex = 10;
            this.ToolTip.SetToolTip(this.MaxReturnValuesCK, "If checked the maximum number of values is specified in the request.");
            this.MaxReturnValuesCK.UseVisualStyleBackColor = true;
            this.MaxReturnValuesCK.CheckedChanged += new System.EventHandler(this.MaxReturnValuesCK_CheckedChanged);
            //
            // EndTimeCK
            //
            this.EndTimeCK.AutoSize = true;
            this.EndTimeCK.Location = new System.Drawing.Point(537, 57);
            this.EndTimeCK.Margin = new System.Windows.Forms.Padding(1, 5, 1, 5);
            this.EndTimeCK.Name = "EndTimeCK";
            this.EndTimeCK.Size = new System.Drawing.Size(15, 14);
            this.EndTimeCK.TabIndex = 7;
            this.ToolTip.SetToolTip(this.EndTimeCK, "If checked the end time is specified in the request.");
            this.EndTimeCK.UseVisualStyleBackColor = true;
            this.EndTimeCK.CheckedChanged += new System.EventHandler(this.EndTimeCK_CheckedChanged);
            //
            // StartTimeCK
            //
            this.StartTimeCK.AutoSize = true;
            this.StartTimeCK.Checked = true;
            this.StartTimeCK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StartTimeCK.Location = new System.Drawing.Point(537, 33);
            this.StartTimeCK.Margin = new System.Windows.Forms.Padding(1, 5, 1, 5);
            this.StartTimeCK.Name = "StartTimeCK";
            this.StartTimeCK.Size = new System.Drawing.Size(15, 14);
            this.StartTimeCK.TabIndex = 4;
            this.ToolTip.SetToolTip(this.StartTimeCK, "If checked the start time is specified in the request.");
            this.StartTimeCK.UseVisualStyleBackColor = true;
            this.StartTimeCK.CheckedChanged += new System.EventHandler(this.StartTimeCK_CheckedChanged);
            //
            // EndTimeDP
            //
            this.EndTimeDP.CustomFormat = "HH:mm:ss yyyy-MM-dd";
            this.EndTimeDP.Enabled = false;
            this.EndTimeDP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndTimeDP.Location = new System.Drawing.Point(74, 54);
            this.EndTimeDP.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.EndTimeDP.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.EndTimeDP.Name = "EndTimeDP";
            this.EndTimeDP.Size = new System.Drawing.Size(162, 20);
            this.EndTimeDP.TabIndex = 6;
            this.ToolTip.SetToolTip(this.EndTimeDP, "The end of the time range to read.");
            this.EndTimeDP.ValueChanged += new System.EventHandler(this.EndTimeDP_ValueChanged);
            //
            // MaxReturnValuesLB
            //
            this.MaxReturnValuesLB.AutoSize = true;
            this.MaxReturnValuesLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaxReturnValuesLB.Location = new System.Drawing.Point(6, 76);
            this.MaxReturnValuesLB.Name = "MaxReturnValuesLB";
            this.MaxReturnValuesLB.Size = new System.Drawing.Size(64, 24);
            this.MaxReturnValuesLB.TabIndex = 8;
            this.MaxReturnValuesLB.Text = "Num Values";
            this.MaxReturnValuesLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // EndTimeLB
            //
            this.EndTimeLB.AutoSize = true;
            this.EndTimeLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndTimeLB.Location = new System.Drawing.Point(6, 52);
            this.EndTimeLB.Name = "EndTimeLB";
            this.EndTimeLB.Size = new System.Drawing.Size(64, 24);
            this.EndTimeLB.TabIndex = 5;
            this.EndTimeLB.Text = "End Time";
            this.EndTimeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // StartTimeLB
            //
            this.StartTimeLB.AutoSize = true;
            this.StartTimeLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartTimeLB.Location = new System.Drawing.Point(6, 28);
            this.StartTimeLB.Name = "StartTimeLB";
            this.StartTimeLB.Size = new System.Drawing.Size(64, 24);
            this.StartTimeLB.TabIndex = 2;
            this.StartTimeLB.Text = "Start Time";
            this.StartTimeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // NodeIdTB
            //
            this.NodeIdTB.AllowDrop = true;
            this.NodeIdTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodeIdTB.Location = new System.Drawing.Point(74, 5);
            this.NodeIdTB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.NodeIdTB.Name = "NodeIdTB";
            this.NodeIdTB.Size = new System.Drawing.Size(461, 20);
            this.NodeIdTB.TabIndex = 1;
            this.ToolTip.SetToolTip(this.NodeIdTB, "The identifier for the node to read. ");
            this.NodeIdTB.TextChanged += new System.EventHandler(this.NodeIdTB_TextChanged);
            //
            // NodeIdLB
            //
            this.NodeIdLB.AutoSize = true;
            this.NodeIdLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodeIdLB.Location = new System.Drawing.Point(6, 3);
            this.NodeIdLB.Name = "NodeIdLB";
            this.NodeIdLB.Size = new System.Drawing.Size(64, 25);
            this.NodeIdLB.TabIndex = 0;
            this.NodeIdLB.Text = "Notifier";
            this.NodeIdLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.NodeIdLB, " ");
            //
            // StartTimeDP
            //
            this.StartTimeDP.CustomFormat = "HH:mm:ss yyyy-MM-dd";
            this.StartTimeDP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartTimeDP.Location = new System.Drawing.Point(74, 30);
            this.StartTimeDP.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.StartTimeDP.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.StartTimeDP.Name = "StartTimeDP";
            this.StartTimeDP.Size = new System.Drawing.Size(162, 20);
            this.StartTimeDP.TabIndex = 3;
            this.ToolTip.SetToolTip(this.StartTimeDP, "The beginning of the time range to read.");
            this.StartTimeDP.ValueChanged += new System.EventHandler(this.StartTimeDP_ValueChanged);
            //
            // MaxReturnValuesNP
            //
            this.MaxReturnValuesNP.Location = new System.Drawing.Point(74, 78);
            this.MaxReturnValuesNP.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.MaxReturnValuesNP.Name = "MaxReturnValuesNP";
            this.MaxReturnValuesNP.Size = new System.Drawing.Size(162, 20);
            this.MaxReturnValuesNP.TabIndex = 9;
            this.ToolTip.SetToolTip(this.MaxReturnValuesNP, "The maximum number of values to return.");
            this.MaxReturnValuesNP.ValueChanged += new System.EventHandler(this.MaxReturnValuesNP_ValueChanged);
            //
            // ResultsDV
            //
            this.ResultsDV.AllowUserToAddRows = false;
            this.ResultsDV.AllowUserToDeleteRows = false;
            this.ResultsDV.AllowUserToResizeRows = false;
            this.ResultsDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultsDV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TimeColumn,
            this.ReceiveTimeColumn,
            this.EventIdColumn,
            this.EventTypeColumn,
            this.SourceColumn,
            this.SeverityColumn,
            this.MessageColumn,
            this.UpdateResultColumn});
            this.ResultsDV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultsDV.Location = new System.Drawing.Point(3, 16);
            this.ResultsDV.Name = "ResultsDV";
            this.ResultsDV.Size = new System.Drawing.Size(566, 275);
            this.ResultsDV.TabIndex = 13;
            //
            // TimeColumn
            //
            this.TimeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TimeColumn.DataPropertyName = "Time";
            this.TimeColumn.HeaderText = "Time";
            this.TimeColumn.Name = "TimeColumn";
            this.TimeColumn.ReadOnly = true;
            this.TimeColumn.Width = 55;
            //
            // ReceiveTimeColumn
            //
            this.ReceiveTimeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ReceiveTimeColumn.DataPropertyName = "ReceiveTime";
            this.ReceiveTimeColumn.HeaderText = "ReceiveTime";
            this.ReceiveTimeColumn.Name = "ReceiveTimeColumn";
            this.ReceiveTimeColumn.ReadOnly = true;
            this.ReceiveTimeColumn.Visible = false;
            //
            // EventIdColumn
            //
            this.EventIdColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.EventIdColumn.DataPropertyName = "EventId";
            this.EventIdColumn.HeaderText = "EventId";
            this.EventIdColumn.Name = "EventIdColumn";
            this.EventIdColumn.ReadOnly = true;
            this.EventIdColumn.Visible = false;
            //
            // EventTypeColumn
            //
            this.EventTypeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.EventTypeColumn.DataPropertyName = "EventType";
            this.EventTypeColumn.HeaderText = "Event Type";
            this.EventTypeColumn.Name = "EventTypeColumn";
            this.EventTypeColumn.ReadOnly = true;
            this.EventTypeColumn.Width = 87;
            //
            // SourceColumn
            //
            this.SourceColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SourceColumn.DataPropertyName = "Source";
            this.SourceColumn.HeaderText = "Source";
            this.SourceColumn.Name = "SourceColumn";
            this.SourceColumn.ReadOnly = true;
            this.SourceColumn.Width = 66;
            //
            // SeverityColumn
            //
            this.SeverityColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SeverityColumn.DataPropertyName = "Severity";
            this.SeverityColumn.HeaderText = "Severity";
            this.SeverityColumn.Name = "SeverityColumn";
            this.SeverityColumn.ReadOnly = true;
            this.SeverityColumn.Width = 70;
            //
            // MessageColumn
            //
            this.MessageColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MessageColumn.DataPropertyName = "Message";
            this.MessageColumn.HeaderText = "Message";
            this.MessageColumn.Name = "MessageColumn";
            this.MessageColumn.ReadOnly = true;
            //
            // UpdateResultColumn
            //
            this.UpdateResultColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.UpdateResultColumn.DataPropertyName = "UpdateResult";
            this.UpdateResultColumn.HeaderText = "Update Result";
            this.UpdateResultColumn.Name = "UpdateResultColumn";
            this.UpdateResultColumn.ReadOnly = true;
            //
            // BottomPN
            //
            this.BottomPN.Controls.Add(this.EditFilterButton);
            this.BottomPN.Controls.Add(this.UseAsynchCK);
            this.BottomPN.Controls.Add(this.ReadHistoryBTN);
            this.BottomPN.Controls.Add(this.ReleaseContinuationPointBTN);
            this.BottomPN.Controls.Add(this.CancelBTN);
            this.BottomPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPN.Location = new System.Drawing.Point(3, 533);
            this.BottomPN.Name = "BottomPN";
            this.BottomPN.Size = new System.Drawing.Size(578, 29);
            this.BottomPN.TabIndex = 0;
            //
            // EditFilterButton
            //
            this.EditFilterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EditFilterButton.Location = new System.Drawing.Point(405, 3);
            this.EditFilterButton.Name = "EditFilterButton";
            this.EditFilterButton.Size = new System.Drawing.Size(88, 23);
            this.EditFilterButton.TabIndex = 9;
            this.EditFilterButton.Text = "Edit Filter";
            this.ToolTip.SetToolTip(this.EditFilterButton, "Edits the event filter used.");
            this.EditFilterButton.UseVisualStyleBackColor = true;
            this.EditFilterButton.Click += new System.EventHandler(this.EditFilterButton_Click);
            //
            // UseAsynchCK
            //
            this.UseAsynchCK.AutoSize = true;
            this.UseAsynchCK.Location = new System.Drawing.Point(85, 7);
            this.UseAsynchCK.Name = "UseAsynchCK";
            this.UseAsynchCK.Size = new System.Drawing.Size(152, 17);
            this.UseAsynchCK.TabIndex = 8;
            this.UseAsynchCK.Text = "Use Asynchronous Pattern";
            this.UseAsynchCK.UseVisualStyleBackColor = true;
            //
            // ReadHistoryBTN
            //
            this.ReadHistoryBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ReadHistoryBTN.Location = new System.Drawing.Point(3, 3);
            this.ReadHistoryBTN.Name = "ReadHistoryBTN";
            this.ReadHistoryBTN.Size = new System.Drawing.Size(76, 23);
            this.ReadHistoryBTN.TabIndex = 7;
            this.ReadHistoryBTN.Text = "Read History";
            this.ReadHistoryBTN.UseVisualStyleBackColor = true;
            this.ReadHistoryBTN.Click += new System.EventHandler(this.ReadHistoryBTN_Click);
            //
            // ReleaseContinuationPointBTN
            //
            this.ReleaseContinuationPointBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ReleaseContinuationPointBTN.Location = new System.Drawing.Point(254, 3);
            this.ReleaseContinuationPointBTN.Name = "ReleaseContinuationPointBTN";
            this.ReleaseContinuationPointBTN.Size = new System.Drawing.Size(145, 23);
            this.ReleaseContinuationPointBTN.TabIndex = 2;
            this.ReleaseContinuationPointBTN.Text = "Release Continuation Point";
            this.ToolTip.SetToolTip(this.ReleaseContinuationPointBTN, "Releases the continuation point for the active read operation.");
            this.ReleaseContinuationPointBTN.UseVisualStyleBackColor = true;
            this.ReleaseContinuationPointBTN.Visible = false;
            this.ReleaseContinuationPointBTN.Click += new System.EventHandler(this.ReleaseContinuationPointBTN_Click);
            //
            // CancelBTN
            //
            this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBTN.Location = new System.Drawing.Point(500, 3);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelBTN.TabIndex = 3;
            this.CancelBTN.Text = "Close";
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
            this.InstructionsGB.TabIndex = 18;
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
            // groupBox1
            //
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.MainPN);
            this.groupBox1.Location = new System.Drawing.Point(6, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(572, 140);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "History Read Request";
            //
            // ResponseGB
            //
            this.ResponseGB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ResponseGB.Controls.Add(this.ResultsDV);
            this.ResponseGB.Location = new System.Drawing.Point(6, 236);
            this.ResponseGB.Name = "ResponseGB";
            this.ResponseGB.Size = new System.Drawing.Size(572, 294);
            this.ResponseGB.TabIndex = 20;
            this.ResponseGB.TabStop = false;
            this.ResponseGB.Text = "History Read Response";
            //
            // HistoryReadEventsDlg
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.ResponseGB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.InstructionsGB);
            this.Controls.Add(this.BottomPN);
            this.Name = "HistoryReadEventsDlg";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "History Read Events Example";
            this.MainPN.ResumeLayout(false);
            this.MainPN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxReturnValuesNP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsDV)).EndInit();
            this.BottomPN.ResumeLayout(false);
            this.BottomPN.PerformLayout();
            this.InstructionsGB.ResumeLayout(false);
            this.TopPN.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResponseGB.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainPN;
        private System.Windows.Forms.TextBox NodeIdTB;
        private System.Windows.Forms.Label NodeIdLB;
        private System.Windows.Forms.Panel BottomPN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Label StartTimeLB;
        private System.Windows.Forms.Label MaxReturnValuesLB;
        private System.Windows.Forms.Label EndTimeLB;
        private System.Windows.Forms.DateTimePicker EndTimeDP;
        private System.Windows.Forms.DateTimePicker StartTimeDP;
        private System.Windows.Forms.NumericUpDown MaxReturnValuesNP;
        private System.Windows.Forms.CheckBox MaxReturnValuesCK;
        private System.Windows.Forms.CheckBox EndTimeCK;
        private System.Windows.Forms.CheckBox StartTimeCK;
        private System.Windows.Forms.Button ReleaseContinuationPointBTN;
        private System.Windows.Forms.DataGridView ResultsDV;
        private System.Windows.Forms.GroupBox InstructionsGB;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Button HelpBTN;
        private System.Windows.Forms.Button ShowCodeBTN;
        private System.Windows.Forms.Label InstructionsLB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox ResponseGB;
        private System.Windows.Forms.Button NodeIdBTN;
        private System.Windows.Forms.CheckBox UseAsynchCK;
        private System.Windows.Forms.Button ReadHistoryBTN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiveTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeverityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateResultColumn;
        private System.Windows.Forms.Button EditFilterButton;
    }
}
