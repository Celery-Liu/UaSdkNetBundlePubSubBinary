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
    partial class ModifyEventMonitoredItemsDlg
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
            this.EventFilterBTN = new System.Windows.Forms.Button();
            this.SelectNodeBTN = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.QueueSizeUD = new System.Windows.Forms.NumericUpDown();
            this.SamplingIntervalUD = new System.Windows.Forms.NumericUpDown();
            this.DiscardOldestCK = new System.Windows.Forms.CheckBox();
            this.MonitoredItemsLV = new System.Windows.Forms.ListView();
            this.LastErrorCH = new System.Windows.Forms.ColumnHeader();
            this.MonitoredItemPN = new System.Windows.Forms.TableLayoutPanel();
            this.DiscardOldestLB = new System.Windows.Forms.Label();
            this.CurrentQueueSizeTB = new System.Windows.Forms.TextBox();
            this.QueueSizeLB = new System.Windows.Forms.Label();
            this.SamplingIntervalLB = new System.Windows.Forms.Label();
            this.CurrentSamplingIntervalTB = new System.Windows.Forms.TextBox();
            this.CurrentDiscardOldestCK = new System.Windows.Forms.CheckBox();
            this.InstructionsGB = new System.Windows.Forms.GroupBox();
            this.TopPN = new System.Windows.Forms.Panel();
            this.HelpBTN = new System.Windows.Forms.Button();
            this.ShowCodeBTN = new System.Windows.Forms.Button();
            this.InstructionsLB = new System.Windows.Forms.Label();
            this.MonitoringParametersGB = new System.Windows.Forms.GroupBox();
            this.ItemsToModifyGB = new System.Windows.Forms.GroupBox();
            ClientHandleCH = new System.Windows.Forms.ColumnHeader();
            NodeCH = new System.Windows.Forms.ColumnHeader();
            AttributeCH = new System.Windows.Forms.ColumnHeader();
            this.BottomPN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QueueSizeUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SamplingIntervalUD)).BeginInit();
            this.MonitoredItemPN.SuspendLayout();
            this.InstructionsGB.SuspendLayout();
            this.TopPN.SuspendLayout();
            this.MonitoringParametersGB.SuspendLayout();
            this.ItemsToModifyGB.SuspendLayout();
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
            this.BottomPN.Controls.Add(this.EventFilterBTN);
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
            this.UseAsynchCK.TabIndex = 22;
            this.UseAsynchCK.Text = "Use Asynchronous Pattern";
            this.UseAsynchCK.UseVisualStyleBackColor = true;
            //
            // ModifyBTN
            //
            this.ModifyBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ModifyBTN.Enabled = false;
            this.ModifyBTN.Location = new System.Drawing.Point(3, 3);
            this.ModifyBTN.Name = "ModifyBTN";
            this.ModifyBTN.Size = new System.Drawing.Size(75, 23);
            this.ModifyBTN.TabIndex = 21;
            this.ModifyBTN.Tag = "";
            this.ModifyBTN.Text = "Modify";
            this.ModifyBTN.UseVisualStyleBackColor = true;
            this.ModifyBTN.Click += new System.EventHandler(this.ModifyBTN_Click);
            //
            // EventFilterBTN
            //
            this.EventFilterBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EventFilterBTN.Enabled = false;
            this.EventFilterBTN.Location = new System.Drawing.Point(414, 3);
            this.EventFilterBTN.Name = "EventFilterBTN";
            this.EventFilterBTN.Size = new System.Drawing.Size(84, 23);
            this.EventFilterBTN.TabIndex = 20;
            this.EventFilterBTN.Text = "Event Filter...";
            this.ToolTip.SetToolTip(this.EventFilterBTN, "Open a window to browse the address space for nodes to monitor.");
            this.EventFilterBTN.UseVisualStyleBackColor = true;
            this.EventFilterBTN.Click += new System.EventHandler(this.EventFilterBTN_Click);
            //
            // SelectNodeBTN
            //
            this.SelectNodeBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectNodeBTN.Location = new System.Drawing.Point(692, 3);
            this.SelectNodeBTN.Name = "SelectNodeBTN";
            this.SelectNodeBTN.Size = new System.Drawing.Size(84, 23);
            this.SelectNodeBTN.TabIndex = 19;
            this.SelectNodeBTN.Text = "Select Node...";
            this.ToolTip.SetToolTip(this.SelectNodeBTN, "Open a window to browse the address space for nodes to monitor.");
            this.SelectNodeBTN.UseVisualStyleBackColor = true;
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
            this.ToolTip.SetToolTip(this.QueueSizeUD, "The queue size to use when modifying the items.");
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
            this.ToolTip.SetToolTip(this.SamplingIntervalUD, "The sampling interval to use when modifying the items.");
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
            // MonitoredItemsLV
            //
            this.MonitoredItemsLV.AllowDrop = true;
            this.MonitoredItemsLV.CheckBoxes = true;
            this.MonitoredItemsLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            ClientHandleCH,
            NodeCH,
            AttributeCH,
            this.LastErrorCH});
            this.MonitoredItemsLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MonitoredItemsLV.FullRowSelect = true;
            this.MonitoredItemsLV.Location = new System.Drawing.Point(3, 16);
            this.MonitoredItemsLV.Name = "MonitoredItemsLV";
            this.MonitoredItemsLV.Size = new System.Drawing.Size(572, 309);
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
            this.MonitoredItemPN.Controls.Add(this.DiscardOldestLB, 0, 2);
            this.MonitoredItemPN.Controls.Add(this.CurrentQueueSizeTB, 2, 1);
            this.MonitoredItemPN.Controls.Add(this.QueueSizeLB, 0, 1);
            this.MonitoredItemPN.Controls.Add(this.SamplingIntervalLB, 0, 0);
            this.MonitoredItemPN.Controls.Add(this.CurrentSamplingIntervalTB, 2, 0);
            this.MonitoredItemPN.Controls.Add(this.QueueSizeUD, 1, 1);
            this.MonitoredItemPN.Controls.Add(this.SamplingIntervalUD, 1, 0);
            this.MonitoredItemPN.Controls.Add(this.DiscardOldestCK, 1, 2);
            this.MonitoredItemPN.Controls.Add(this.CurrentDiscardOldestCK, 2, 2);
            this.MonitoredItemPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MonitoredItemPN.Location = new System.Drawing.Point(3, 16);
            this.MonitoredItemPN.Name = "MonitoredItemPN";
            this.MonitoredItemPN.RowCount = 5;
            this.MonitoredItemPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MonitoredItemPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MonitoredItemPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MonitoredItemPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MonitoredItemPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MonitoredItemPN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MonitoredItemPN.Size = new System.Drawing.Size(569, 79);
            this.MonitoredItemPN.TabIndex = 1;
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
            this.InstructionsGB.TabIndex = 25;
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
            // MonitoringParametersGB
            //
            this.MonitoringParametersGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MonitoringParametersGB.Controls.Add(this.MonitoredItemPN);
            this.MonitoringParametersGB.Location = new System.Drawing.Point(3, 92);
            this.MonitoringParametersGB.Name = "MonitoringParametersGB";
            this.MonitoringParametersGB.Size = new System.Drawing.Size(575, 98);
            this.MonitoringParametersGB.TabIndex = 26;
            this.MonitoringParametersGB.TabStop = false;
            this.MonitoringParametersGB.Text = "Monitoring Parameters";
            //
            // ItemsToModifyGB
            //
            this.ItemsToModifyGB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemsToModifyGB.Controls.Add(this.MonitoredItemsLV);
            this.ItemsToModifyGB.Location = new System.Drawing.Point(3, 206);
            this.ItemsToModifyGB.Name = "ItemsToModifyGB";
            this.ItemsToModifyGB.Size = new System.Drawing.Size(578, 328);
            this.ItemsToModifyGB.TabIndex = 27;
            this.ItemsToModifyGB.TabStop = false;
            this.ItemsToModifyGB.Text = "Monitored Items to Modify";
            //
            // ModifyEventMonitoredItemsDlg
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.ItemsToModifyGB);
            this.Controls.Add(this.MonitoringParametersGB);
            this.Controls.Add(this.InstructionsGB);
            this.Controls.Add(this.BottomPN);
            this.Name = "ModifyEventMonitoredItemsDlg";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modify Event Monitored Items";
            this.BottomPN.ResumeLayout(false);
            this.BottomPN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QueueSizeUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SamplingIntervalUD)).EndInit();
            this.MonitoredItemPN.ResumeLayout(false);
            this.MonitoredItemPN.PerformLayout();
            this.InstructionsGB.ResumeLayout(false);
            this.TopPN.ResumeLayout(false);
            this.MonitoringParametersGB.ResumeLayout(false);
            this.ItemsToModifyGB.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel BottomPN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.ListView MonitoredItemsLV;
        private System.Windows.Forms.ColumnHeader LastErrorCH;
        private System.Windows.Forms.TableLayoutPanel MonitoredItemPN;
        private System.Windows.Forms.Label DiscardOldestLB;
        private System.Windows.Forms.TextBox CurrentQueueSizeTB;
        private System.Windows.Forms.Label QueueSizeLB;
        private System.Windows.Forms.Label SamplingIntervalLB;
        private System.Windows.Forms.TextBox CurrentSamplingIntervalTB;
        private System.Windows.Forms.NumericUpDown QueueSizeUD;
        private System.Windows.Forms.NumericUpDown SamplingIntervalUD;
        private System.Windows.Forms.CheckBox DiscardOldestCK;
        private System.Windows.Forms.CheckBox CurrentDiscardOldestCK;
        private System.Windows.Forms.GroupBox InstructionsGB;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Button HelpBTN;
        private System.Windows.Forms.Button ShowCodeBTN;
        private System.Windows.Forms.Label InstructionsLB;
        private System.Windows.Forms.CheckBox UseAsynchCK;
        private System.Windows.Forms.Button ModifyBTN;
        private System.Windows.Forms.Button EventFilterBTN;
        private System.Windows.Forms.Button SelectNodeBTN;
        private System.Windows.Forms.GroupBox MonitoringParametersGB;
        private System.Windows.Forms.GroupBox ItemsToModifyGB;
    }
}
