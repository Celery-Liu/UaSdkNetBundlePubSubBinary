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
    partial class HistoryReadProcessedDlg
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
            this.MaxReturnValuesNP = new System.Windows.Forms.NumericUpDown();
            this.MaxReturnValuesLB = new System.Windows.Forms.Label();
            this.NodeIdBTN = new System.Windows.Forms.Button();
            this.AggregateTypeLB = new System.Windows.Forms.Label();
            this.ProcessingIntervalLB = new System.Windows.Forms.Label();
            this.StartTimeLB = new System.Windows.Forms.Label();
            this.NodeIdTB = new System.Windows.Forms.TextBox();
            this.NodeIdLB = new System.Windows.Forms.Label();
            this.StartTimeDP = new System.Windows.Forms.DateTimePicker();
            this.ProcessingIntervalUD = new System.Windows.Forms.NumericUpDown();
            this.AggregateTypeCB = new System.Windows.Forms.ComboBox();
            this.BottomPN = new System.Windows.Forms.Panel();
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
            this.RequestGB = new System.Windows.Forms.GroupBox();
            this.ResponseGB = new System.Windows.Forms.GroupBox();
            this.ResultsDV = new System.Windows.Forms.DataGridView();
            this.SourceTimestampCH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServerTimestampCH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueCH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusCodeCH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HistoryInfoCH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateTypeCH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateTimeCH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserNameCH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateResultCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainPN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxReturnValuesNP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessingIntervalUD)).BeginInit();
            this.BottomPN.SuspendLayout();
            this.InstructionsGB.SuspendLayout();
            this.TopPN.SuspendLayout();
            this.RequestGB.SuspendLayout();
            this.ResponseGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsDV)).BeginInit();
            this.SuspendLayout();
            //
            // MainPN
            //
            this.MainPN.ColumnCount = 3;
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.Controls.Add(this.MaxReturnValuesNP, 1, 2);
            this.MainPN.Controls.Add(this.MaxReturnValuesLB, 0, 2);
            this.MainPN.Controls.Add(this.NodeIdBTN, 2, 0);
            this.MainPN.Controls.Add(this.AggregateTypeLB, 0, 4);
            this.MainPN.Controls.Add(this.ProcessingIntervalLB, 0, 3);
            this.MainPN.Controls.Add(this.StartTimeLB, 0, 1);
            this.MainPN.Controls.Add(this.NodeIdTB, 1, 0);
            this.MainPN.Controls.Add(this.NodeIdLB, 0, 0);
            this.MainPN.Controls.Add(this.StartTimeDP, 1, 1);
            this.MainPN.Controls.Add(this.ProcessingIntervalUD, 1, 3);
            this.MainPN.Controls.Add(this.AggregateTypeCB, 1, 4);
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(3, 16);
            this.MainPN.Name = "MainPN";
            this.MainPN.Padding = new System.Windows.Forms.Padding(3);
            this.MainPN.RowCount = 7;
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainPN.Size = new System.Drawing.Size(572, 126);
            this.MainPN.TabIndex = 0;
            //
            // MaxReturnValuesNP
            //
            this.MaxReturnValuesNP.Location = new System.Drawing.Point(129, 54);
            this.MaxReturnValuesNP.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.MaxReturnValuesNP.Name = "MaxReturnValuesNP";
            this.MaxReturnValuesNP.Size = new System.Drawing.Size(162, 20);
            this.MaxReturnValuesNP.TabIndex = 22;
            this.ToolTip.SetToolTip(this.MaxReturnValuesNP, "The maximum number of values to return.");
            //
            // MaxReturnValuesLB
            //
            this.MaxReturnValuesLB.AutoSize = true;
            this.MaxReturnValuesLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaxReturnValuesLB.Location = new System.Drawing.Point(6, 52);
            this.MaxReturnValuesLB.Name = "MaxReturnValuesLB";
            this.MaxReturnValuesLB.Size = new System.Drawing.Size(119, 24);
            this.MaxReturnValuesLB.TabIndex = 21;
            this.MaxReturnValuesLB.Text = "Num Values";
            this.MaxReturnValuesLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // NodeIdBTN
            //
            this.NodeIdBTN.AutoSize = true;
            this.NodeIdBTN.Location = new System.Drawing.Point(543, 4);
            this.NodeIdBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.NodeIdBTN.Name = "NodeIdBTN";
            this.NodeIdBTN.Size = new System.Drawing.Size(26, 23);
            this.NodeIdBTN.TabIndex = 20;
            this.NodeIdBTN.Text = "...";
            this.ToolTip.SetToolTip(this.NodeIdBTN, "Displays a dialog to select a history data variable.");
            this.NodeIdBTN.UseVisualStyleBackColor = true;
            this.NodeIdBTN.Click += new System.EventHandler(this.NodeIdBTN_Click);
            //
            // AggregateTypeLB
            //
            this.AggregateTypeLB.AutoSize = true;
            this.AggregateTypeLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AggregateTypeLB.Location = new System.Drawing.Point(6, 100);
            this.AggregateTypeLB.Name = "AggregateTypeLB";
            this.AggregateTypeLB.Size = new System.Drawing.Size(119, 25);
            this.AggregateTypeLB.TabIndex = 14;
            this.AggregateTypeLB.Text = "Aggregate Type";
            this.AggregateTypeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // ProcessingIntervalLB
            //
            this.ProcessingIntervalLB.AutoSize = true;
            this.ProcessingIntervalLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcessingIntervalLB.Location = new System.Drawing.Point(6, 76);
            this.ProcessingIntervalLB.Name = "ProcessingIntervalLB";
            this.ProcessingIntervalLB.Size = new System.Drawing.Size(119, 24);
            this.ProcessingIntervalLB.TabIndex = 8;
            this.ProcessingIntervalLB.Text = "Processing Interval (ms)";
            this.ProcessingIntervalLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // StartTimeLB
            //
            this.StartTimeLB.AutoSize = true;
            this.StartTimeLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartTimeLB.Location = new System.Drawing.Point(6, 28);
            this.StartTimeLB.Name = "StartTimeLB";
            this.StartTimeLB.Size = new System.Drawing.Size(119, 24);
            this.StartTimeLB.TabIndex = 2;
            this.StartTimeLB.Text = "Start Time";
            this.StartTimeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // NodeIdTB
            //
            this.NodeIdTB.AllowDrop = true;
            this.NodeIdTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodeIdTB.Location = new System.Drawing.Point(129, 5);
            this.NodeIdTB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.NodeIdTB.Name = "NodeIdTB";
            this.NodeIdTB.Size = new System.Drawing.Size(412, 20);
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
            this.NodeIdLB.Size = new System.Drawing.Size(119, 25);
            this.NodeIdLB.TabIndex = 0;
            this.NodeIdLB.Text = "Variable";
            this.NodeIdLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.NodeIdLB, " ");
            //
            // StartTimeDP
            //
            this.StartTimeDP.CustomFormat = "HH:mm:ss yyyy-MM-dd";
            this.StartTimeDP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartTimeDP.Location = new System.Drawing.Point(129, 30);
            this.StartTimeDP.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.StartTimeDP.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.StartTimeDP.Name = "StartTimeDP";
            this.StartTimeDP.Size = new System.Drawing.Size(162, 20);
            this.StartTimeDP.TabIndex = 3;
            this.ToolTip.SetToolTip(this.StartTimeDP, "The beginning of the time range to read.");
            this.StartTimeDP.ValueChanged += new System.EventHandler(this.StartTimeDP_ValueChanged);
            //
            // ProcessingIntervalUD
            //
            this.ProcessingIntervalUD.Location = new System.Drawing.Point(129, 78);
            this.ProcessingIntervalUD.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.ProcessingIntervalUD.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.ProcessingIntervalUD.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ProcessingIntervalUD.Name = "ProcessingIntervalUD";
            this.ProcessingIntervalUD.Size = new System.Drawing.Size(162, 20);
            this.ProcessingIntervalUD.TabIndex = 9;
            this.ToolTip.SetToolTip(this.ProcessingIntervalUD, "The processing interval in milliseconds.");
            this.ProcessingIntervalUD.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ProcessingIntervalUD.ValueChanged += new System.EventHandler(this.ProcessingIntervalUD_ValueChanged);
            //
            // AggregateTypeCB
            //
            this.AggregateTypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AggregateTypeCB.FormattingEnabled = true;
            this.AggregateTypeCB.Location = new System.Drawing.Point(129, 102);
            this.AggregateTypeCB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.AggregateTypeCB.Name = "AggregateTypeCB";
            this.AggregateTypeCB.Size = new System.Drawing.Size(170, 21);
            this.AggregateTypeCB.TabIndex = 15;
            this.AggregateTypeCB.SelectedIndexChanged += new System.EventHandler(this.AggregateTypeCB_SelectedIndexChanged);
            //
            // BottomPN
            //
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
            // UseAsynchCK
            //
            this.UseAsynchCK.AutoSize = true;
            this.UseAsynchCK.Location = new System.Drawing.Point(85, 7);
            this.UseAsynchCK.Name = "UseAsynchCK";
            this.UseAsynchCK.Size = new System.Drawing.Size(152, 17);
            this.UseAsynchCK.TabIndex = 6;
            this.UseAsynchCK.Text = "Use Asynchronous Pattern";
            this.UseAsynchCK.UseVisualStyleBackColor = true;
            //
            // ReadHistoryBTN
            //
            this.ReadHistoryBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ReadHistoryBTN.Location = new System.Drawing.Point(3, 3);
            this.ReadHistoryBTN.Name = "ReadHistoryBTN";
            this.ReadHistoryBTN.Size = new System.Drawing.Size(76, 23);
            this.ReadHistoryBTN.TabIndex = 5;
            this.ReadHistoryBTN.Text = "Read History";
            this.ReadHistoryBTN.UseVisualStyleBackColor = true;
            this.ReadHistoryBTN.Click += new System.EventHandler(this.ReadHistoryBTN_Click);
            //
            // ReleaseContinuationPointBTN
            //
            this.ReleaseContinuationPointBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ReleaseContinuationPointBTN.Location = new System.Drawing.Point(349, 3);
            this.ReleaseContinuationPointBTN.Name = "ReleaseContinuationPointBTN";
            this.ReleaseContinuationPointBTN.Size = new System.Drawing.Size(145, 23);
            this.ReleaseContinuationPointBTN.TabIndex = 2;
            this.ReleaseContinuationPointBTN.Text = "Release Continuation Point";
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
            this.InstructionsGB.TabIndex = 17;
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
            this.RequestGB.Location = new System.Drawing.Point(3, 91);
            this.RequestGB.Name = "RequestGB";
            this.RequestGB.Size = new System.Drawing.Size(578, 145);
            this.RequestGB.TabIndex = 18;
            this.RequestGB.TabStop = false;
            this.RequestGB.Text = "Read History Request";
            //
            // ResponseGB
            //
            this.ResponseGB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ResponseGB.Controls.Add(this.ResultsDV);
            this.ResponseGB.Location = new System.Drawing.Point(3, 241);
            this.ResponseGB.Name = "ResponseGB";
            this.ResponseGB.Size = new System.Drawing.Size(578, 289);
            this.ResponseGB.TabIndex = 19;
            this.ResponseGB.TabStop = false;
            this.ResponseGB.Text = "Read History Response";
            //
            // ResultsDV
            //
            this.ResultsDV.AllowUserToAddRows = false;
            this.ResultsDV.AllowUserToDeleteRows = false;
            this.ResultsDV.AllowUserToResizeRows = false;
            this.ResultsDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultsDV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SourceTimestampCH,
            this.ServerTimestampCH,
            this.ValueCH,
            this.StatusCodeCH,
            this.HistoryInfoCH,
            this.UpdateTypeCH,
            this.UpdateTimeCH,
            this.UserNameCH,
            this.UpdateResultCN});
            this.ResultsDV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultsDV.Location = new System.Drawing.Point(3, 16);
            this.ResultsDV.Name = "ResultsDV";
            this.ResultsDV.Size = new System.Drawing.Size(572, 270);
            this.ResultsDV.TabIndex = 14;
            //
            // SourceTimestampCH
            //
            this.SourceTimestampCH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SourceTimestampCH.DataPropertyName = "SourceTimestamp";
            this.SourceTimestampCH.HeaderText = "SourceTimestamp";
            this.SourceTimestampCH.Name = "SourceTimestampCH";
            this.SourceTimestampCH.ReadOnly = true;
            this.SourceTimestampCH.Width = 117;
            //
            // ServerTimestampCH
            //
            this.ServerTimestampCH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ServerTimestampCH.DataPropertyName = "ServerTimestamp";
            this.ServerTimestampCH.HeaderText = "ServerTimestamp";
            this.ServerTimestampCH.Name = "ServerTimestampCH";
            this.ServerTimestampCH.ReadOnly = true;
            this.ServerTimestampCH.Visible = false;
            //
            // ValueCH
            //
            this.ValueCH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ValueCH.DataPropertyName = "Value";
            this.ValueCH.HeaderText = "Value";
            this.ValueCH.Name = "ValueCH";
            this.ValueCH.ReadOnly = true;
            //
            // StatusCodeCH
            //
            this.StatusCodeCH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StatusCodeCH.DataPropertyName = "StatusCode";
            this.StatusCodeCH.HeaderText = "StatusCode";
            this.StatusCodeCH.Name = "StatusCodeCH";
            this.StatusCodeCH.ReadOnly = true;
            this.StatusCodeCH.Width = 87;
            //
            // HistoryInfoCH
            //
            this.HistoryInfoCH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.HistoryInfoCH.DataPropertyName = "HistoryInfo";
            this.HistoryInfoCH.HeaderText = "HistoryInfo";
            this.HistoryInfoCH.Name = "HistoryInfoCH";
            this.HistoryInfoCH.Width = 82;
            //
            // UpdateTypeCH
            //
            this.UpdateTypeCH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.UpdateTypeCH.DataPropertyName = "UpdateType";
            this.UpdateTypeCH.HeaderText = "UpdateType";
            this.UpdateTypeCH.Name = "UpdateTypeCH";
            this.UpdateTypeCH.ReadOnly = true;
            this.UpdateTypeCH.Visible = false;
            //
            // UpdateTimeCH
            //
            this.UpdateTimeCH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.UpdateTimeCH.DataPropertyName = "UpdateTime";
            this.UpdateTimeCH.HeaderText = "UpdateTime";
            this.UpdateTimeCH.Name = "UpdateTimeCH";
            this.UpdateTimeCH.ReadOnly = true;
            this.UpdateTimeCH.Visible = false;
            //
            // UserNameCH
            //
            this.UserNameCH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.UserNameCH.DataPropertyName = "UserName";
            this.UserNameCH.HeaderText = "UserName";
            this.UserNameCH.Name = "UserNameCH";
            this.UserNameCH.ReadOnly = true;
            this.UserNameCH.Visible = false;
            //
            // UpdateResultCN
            //
            this.UpdateResultCN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.UpdateResultCN.DataPropertyName = "UpdateResult";
            this.UpdateResultCN.HeaderText = "Update Result";
            this.UpdateResultCN.Name = "UpdateResultCN";
            this.UpdateResultCN.ReadOnly = true;
            this.UpdateResultCN.Visible = false;
            //
            // HistoryReadProcessedDlg
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.ResponseGB);
            this.Controls.Add(this.RequestGB);
            this.Controls.Add(this.InstructionsGB);
            this.Controls.Add(this.BottomPN);
            this.Name = "HistoryReadProcessedDlg";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "History Read Processed Example";
            this.MainPN.ResumeLayout(false);
            this.MainPN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxReturnValuesNP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessingIntervalUD)).EndInit();
            this.BottomPN.ResumeLayout(false);
            this.BottomPN.PerformLayout();
            this.InstructionsGB.ResumeLayout(false);
            this.TopPN.ResumeLayout(false);
            this.RequestGB.ResumeLayout(false);
            this.ResponseGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ResultsDV)).EndInit();
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
        private System.Windows.Forms.Label ProcessingIntervalLB;
        private System.Windows.Forms.DateTimePicker StartTimeDP;
        private System.Windows.Forms.NumericUpDown ProcessingIntervalUD;
        private System.Windows.Forms.Button ReleaseContinuationPointBTN;
        private System.Windows.Forms.Label AggregateTypeLB;
        private System.Windows.Forms.ComboBox AggregateTypeCB;
        private System.Windows.Forms.GroupBox InstructionsGB;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Button HelpBTN;
        private System.Windows.Forms.Button ShowCodeBTN;
        private System.Windows.Forms.Label InstructionsLB;
        private System.Windows.Forms.GroupBox RequestGB;
        private System.Windows.Forms.GroupBox ResponseGB;
        private System.Windows.Forms.DataGridView ResultsDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceTimestampCH;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerTimestampCH;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueCH;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusCodeCH;
        private System.Windows.Forms.DataGridViewTextBoxColumn HistoryInfoCH;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateTypeCH;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateTimeCH;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserNameCH;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateResultCN;
        private System.Windows.Forms.Button NodeIdBTN;
        private System.Windows.Forms.CheckBox UseAsynchCK;
        private System.Windows.Forms.Button ReadHistoryBTN;
        private System.Windows.Forms.Label MaxReturnValuesLB;
        private System.Windows.Forms.NumericUpDown MaxReturnValuesNP;
    }
}
