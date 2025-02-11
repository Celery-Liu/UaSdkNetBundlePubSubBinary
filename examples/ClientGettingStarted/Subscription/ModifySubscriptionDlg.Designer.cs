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
    partial class ModifySubscriptionDlg
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
            this.BottomPN = new System.Windows.Forms.Panel();
            this.UseAsynchCK = new System.Windows.Forms.CheckBox();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.ModifyBTN = new System.Windows.Forms.Button();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.KeepAliveTimeUD = new System.Windows.Forms.NumericUpDown();
            this.PublishingIntervalUD = new System.Windows.Forms.NumericUpDown();
            this.LifeTimeUD = new System.Windows.Forms.NumericUpDown();
            this.MaxNotificationsUD = new System.Windows.Forms.NumericUpDown();
            this.PriorityUD = new System.Windows.Forms.NumericUpDown();
            this.PublishingEnabledCK = new System.Windows.Forms.CheckBox();
            this.InstructionsGB = new System.Windows.Forms.GroupBox();
            this.TopPN = new System.Windows.Forms.Panel();
            this.HelpBTN = new System.Windows.Forms.Button();
            this.ShowCodeBTN = new System.Windows.Forms.Button();
            this.InstructionsLB = new System.Windows.Forms.Label();
            this.RequestParametersGB = new System.Windows.Forms.GroupBox();
            this.MainPN = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PriorityLB = new System.Windows.Forms.Label();
            this.MaxNotifications2LB = new System.Windows.Forms.Label();
            this.LifeTimeLB = new System.Windows.Forms.Label();
            this.CurrentKeepAliveTimeTB = new System.Windows.Forms.TextBox();
            this.KeepAliveTimeLB = new System.Windows.Forms.Label();
            this.CurrentPublishingIntervalTB = new System.Windows.Forms.TextBox();
            this.CurrentLifeTimeTB = new System.Windows.Forms.TextBox();
            this.CurrentMaxNotificationsTB = new System.Windows.Forms.TextBox();
            this.CurrentPriorityTB = new System.Windows.Forms.TextBox();
            this.PubishingEnabledLB = new System.Windows.Forms.Label();
            this.CurrentPublishingEnabledCK = new System.Windows.Forms.CheckBox();
            this.PublishingIntervalLB = new System.Windows.Forms.Label();
            this.BottomPN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KeepAliveTimeUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PublishingIntervalUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LifeTimeUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxNotificationsUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriorityUD)).BeginInit();
            this.InstructionsGB.SuspendLayout();
            this.TopPN.SuspendLayout();
            this.MainPN.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            //
            // BottomPN
            //
            this.BottomPN.Controls.Add(this.UseAsynchCK);
            this.BottomPN.Controls.Add(this.CancelBTN);
            this.BottomPN.Controls.Add(this.ModifyBTN);
            this.BottomPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPN.Location = new System.Drawing.Point(3, 275);
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
            this.UseAsynchCK.TabIndex = 20;
            this.UseAsynchCK.Text = "Use Asynchronous Pattern";
            this.UseAsynchCK.UseVisualStyleBackColor = true;
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
            // ModifyBTN
            //
            this.ModifyBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ModifyBTN.Location = new System.Drawing.Point(3, 3);
            this.ModifyBTN.Name = "ModifyBTN";
            this.ModifyBTN.Size = new System.Drawing.Size(75, 23);
            this.ModifyBTN.TabIndex = 19;
            this.ModifyBTN.Tag = "";
            this.ModifyBTN.Text = "Modify";
            this.ModifyBTN.UseVisualStyleBackColor = true;
            this.ModifyBTN.Click += new System.EventHandler(this.ModifyBTN_Click);
            //
            // KeepAliveTimeUD
            //
            this.KeepAliveTimeUD.Location = new System.Drawing.Point(106, 42);
            this.KeepAliveTimeUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.KeepAliveTimeUD.Name = "KeepAliveTimeUD";
            this.KeepAliveTimeUD.Size = new System.Drawing.Size(100, 20);
            this.KeepAliveTimeUD.TabIndex = 5;
            this.ToolTip.SetToolTip(this.KeepAliveTimeUD, "The keep alive interval to request when creating the subscription.");
            this.KeepAliveTimeUD.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            //
            // PublishingIntervalUD
            //
            this.PublishingIntervalUD.Location = new System.Drawing.Point(106, 16);
            this.PublishingIntervalUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.PublishingIntervalUD.Name = "PublishingIntervalUD";
            this.PublishingIntervalUD.Size = new System.Drawing.Size(100, 20);
            this.PublishingIntervalUD.TabIndex = 2;
            this.ToolTip.SetToolTip(this.PublishingIntervalUD, "The publishing interval to request when creating the subscription.");
            //
            // LifeTimeUD
            //
            this.LifeTimeUD.Location = new System.Drawing.Point(106, 68);
            this.LifeTimeUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.LifeTimeUD.Name = "LifeTimeUD";
            this.LifeTimeUD.Size = new System.Drawing.Size(100, 20);
            this.LifeTimeUD.TabIndex = 8;
            this.ToolTip.SetToolTip(this.LifeTimeUD, "The lifetime to request when creating the subscription.");
            this.LifeTimeUD.Value = new decimal(new int[] {
            600000,
            0,
            0,
            0});
            //
            // MaxNotificationsUD
            //
            this.MaxNotificationsUD.Location = new System.Drawing.Point(106, 94);
            this.MaxNotificationsUD.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.MaxNotificationsUD.Name = "MaxNotificationsUD";
            this.MaxNotificationsUD.Size = new System.Drawing.Size(100, 20);
            this.MaxNotificationsUD.TabIndex = 11;
            this.ToolTip.SetToolTip(this.MaxNotificationsUD, "The maximum number of notifications to return in a single message.");
            //
            // PriorityUD
            //
            this.PriorityUD.Location = new System.Drawing.Point(106, 120);
            this.PriorityUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.PriorityUD.Name = "PriorityUD";
            this.PriorityUD.Size = new System.Drawing.Size(100, 20);
            this.PriorityUD.TabIndex = 14;
            this.ToolTip.SetToolTip(this.PriorityUD, "The priority for the subscription.");
            //
            // PublishingEnabledCK
            //
            this.PublishingEnabledCK.AutoSize = true;
            this.PublishingEnabledCK.Checked = true;
            this.PublishingEnabledCK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PublishingEnabledCK.Location = new System.Drawing.Point(106, 149);
            this.PublishingEnabledCK.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.PublishingEnabledCK.Name = "PublishingEnabledCK";
            this.PublishingEnabledCK.Size = new System.Drawing.Size(15, 14);
            this.PublishingEnabledCK.TabIndex = 17;
            this.ToolTip.SetToolTip(this.PublishingEnabledCK, "Whether publishing should be enabled.");
            this.PublishingEnabledCK.UseVisualStyleBackColor = true;
            //
            // InstructionsGB
            //
            this.InstructionsGB.BackColor = System.Drawing.Color.Transparent;
            this.InstructionsGB.Controls.Add(this.TopPN);
            this.InstructionsGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.InstructionsGB.Location = new System.Drawing.Point(3, 5);
            this.InstructionsGB.Name = "InstructionsGB";
            this.InstructionsGB.Size = new System.Drawing.Size(578, 81);
            this.InstructionsGB.TabIndex = 23;
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
            // RequestParametersGB
            //
            this.RequestParametersGB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RequestParametersGB.Location = new System.Drawing.Point(0, 0);
            this.RequestParametersGB.Name = "RequestParametersGB";
            this.RequestParametersGB.Size = new System.Drawing.Size(200, 100);
            this.RequestParametersGB.TabIndex = 0;
            this.RequestParametersGB.TabStop = false;
            //
            // MainPN
            //
            this.MainPN.ColumnCount = 3;
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainPN.Controls.Add(this.label2, 2, 0);
            this.MainPN.Location = new System.Drawing.Point(0, 0);
            this.MainPN.Name = "MainPN";
            this.MainPN.RowCount = 1;
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainPN.Size = new System.Drawing.Size(200, 100);
            this.MainPN.TabIndex = 0;
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(103, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 100);
            this.label2.TabIndex = 19;
            this.label2.Text = "Revised Parameters";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(104, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Requested Parameters";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // groupBox1
            //
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(3, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(578, 184);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            //
            // tableLayoutPanel1
            //
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.PriorityLB, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.MaxNotifications2LB, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.LifeTimeLB, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.CurrentKeepAliveTimeTB, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.KeepAliveTimeLB, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.CurrentPublishingIntervalTB, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.KeepAliveTimeUD, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.PublishingIntervalUD, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.LifeTimeUD, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.CurrentLifeTimeTB, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.MaxNotificationsUD, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.CurrentMaxNotificationsTB, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.PriorityUD, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.CurrentPriorityTB, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.PubishingEnabledLB, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.PublishingEnabledCK, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.CurrentPublishingEnabledCK, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.PublishingIntervalLB, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(572, 165);
            this.tableLayoutPanel1.TabIndex = 0;
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(347, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Revised Parameters";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(106, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Requested Parameters";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // PriorityLB
            //
            this.PriorityLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.PriorityLB.AutoSize = true;
            this.PriorityLB.Location = new System.Drawing.Point(3, 117);
            this.PriorityLB.Name = "PriorityLB";
            this.PriorityLB.Size = new System.Drawing.Size(38, 26);
            this.PriorityLB.TabIndex = 13;
            this.PriorityLB.Text = "Priority";
            this.PriorityLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // MaxNotifications2LB
            //
            this.MaxNotifications2LB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.MaxNotifications2LB.AutoSize = true;
            this.MaxNotifications2LB.Location = new System.Drawing.Point(3, 91);
            this.MaxNotifications2LB.Name = "MaxNotifications2LB";
            this.MaxNotifications2LB.Size = new System.Drawing.Size(88, 26);
            this.MaxNotifications2LB.TabIndex = 10;
            this.MaxNotifications2LB.Text = "Max Notifications";
            this.MaxNotifications2LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // LifeTimeLB
            //
            this.LifeTimeLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.LifeTimeLB.AutoSize = true;
            this.LifeTimeLB.Location = new System.Drawing.Point(3, 65);
            this.LifeTimeLB.Name = "LifeTimeLB";
            this.LifeTimeLB.Size = new System.Drawing.Size(50, 26);
            this.LifeTimeLB.TabIndex = 7;
            this.LifeTimeLB.Text = "Life Time";
            this.LifeTimeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // CurrentKeepAliveTimeTB
            //
            this.CurrentKeepAliveTimeTB.Location = new System.Drawing.Point(347, 42);
            this.CurrentKeepAliveTimeTB.Name = "CurrentKeepAliveTimeTB";
            this.CurrentKeepAliveTimeTB.ReadOnly = true;
            this.CurrentKeepAliveTimeTB.Size = new System.Drawing.Size(100, 20);
            this.CurrentKeepAliveTimeTB.TabIndex = 6;
            //
            // KeepAliveTimeLB
            //
            this.KeepAliveTimeLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.KeepAliveTimeLB.AutoSize = true;
            this.KeepAliveTimeLB.Location = new System.Drawing.Point(3, 39);
            this.KeepAliveTimeLB.Name = "KeepAliveTimeLB";
            this.KeepAliveTimeLB.Size = new System.Drawing.Size(84, 26);
            this.KeepAliveTimeLB.TabIndex = 4;
            this.KeepAliveTimeLB.Text = "Keep Alive Time";
            this.KeepAliveTimeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // CurrentPublishingIntervalTB
            //
            this.CurrentPublishingIntervalTB.Location = new System.Drawing.Point(347, 16);
            this.CurrentPublishingIntervalTB.Name = "CurrentPublishingIntervalTB";
            this.CurrentPublishingIntervalTB.ReadOnly = true;
            this.CurrentPublishingIntervalTB.Size = new System.Drawing.Size(100, 20);
            this.CurrentPublishingIntervalTB.TabIndex = 3;
            //
            // CurrentLifeTimeTB
            //
            this.CurrentLifeTimeTB.Location = new System.Drawing.Point(347, 68);
            this.CurrentLifeTimeTB.Name = "CurrentLifeTimeTB";
            this.CurrentLifeTimeTB.ReadOnly = true;
            this.CurrentLifeTimeTB.Size = new System.Drawing.Size(100, 20);
            this.CurrentLifeTimeTB.TabIndex = 9;
            //
            // CurrentMaxNotificationsTB
            //
            this.CurrentMaxNotificationsTB.Location = new System.Drawing.Point(347, 94);
            this.CurrentMaxNotificationsTB.Name = "CurrentMaxNotificationsTB";
            this.CurrentMaxNotificationsTB.ReadOnly = true;
            this.CurrentMaxNotificationsTB.Size = new System.Drawing.Size(100, 20);
            this.CurrentMaxNotificationsTB.TabIndex = 12;
            //
            // CurrentPriorityTB
            //
            this.CurrentPriorityTB.Location = new System.Drawing.Point(347, 120);
            this.CurrentPriorityTB.Name = "CurrentPriorityTB";
            this.CurrentPriorityTB.ReadOnly = true;
            this.CurrentPriorityTB.Size = new System.Drawing.Size(100, 20);
            this.CurrentPriorityTB.TabIndex = 15;
            //
            // PubishingEnabledLB
            //
            this.PubishingEnabledLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.PubishingEnabledLB.AutoSize = true;
            this.PubishingEnabledLB.Location = new System.Drawing.Point(3, 143);
            this.PubishingEnabledLB.Name = "PubishingEnabledLB";
            this.PubishingEnabledLB.Size = new System.Drawing.Size(97, 26);
            this.PubishingEnabledLB.TabIndex = 16;
            this.PubishingEnabledLB.Text = "Publishing Enabled";
            this.PubishingEnabledLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // CurrentPublishingEnabledCK
            //
            this.CurrentPublishingEnabledCK.AutoSize = true;
            this.CurrentPublishingEnabledCK.Enabled = false;
            this.CurrentPublishingEnabledCK.Location = new System.Drawing.Point(347, 149);
            this.CurrentPublishingEnabledCK.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.CurrentPublishingEnabledCK.Name = "CurrentPublishingEnabledCK";
            this.CurrentPublishingEnabledCK.Size = new System.Drawing.Size(15, 14);
            this.CurrentPublishingEnabledCK.TabIndex = 0;
            this.CurrentPublishingEnabledCK.UseVisualStyleBackColor = true;
            //
            // PublishingIntervalLB
            //
            this.PublishingIntervalLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.PublishingIntervalLB.AutoSize = true;
            this.PublishingIntervalLB.Location = new System.Drawing.Point(3, 13);
            this.PublishingIntervalLB.Name = "PublishingIntervalLB";
            this.PublishingIntervalLB.Size = new System.Drawing.Size(93, 26);
            this.PublishingIntervalLB.TabIndex = 1;
            this.PublishingIntervalLB.Text = "Publishing Interval";
            this.PublishingIntervalLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // ModifySubscriptionDlg
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 304);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.InstructionsGB);
            this.Controls.Add(this.BottomPN);
            this.MaximumSize = new System.Drawing.Size(600, 342);
            this.MinimumSize = new System.Drawing.Size(600, 342);
            this.Name = "ModifySubscriptionDlg";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modify Subscription";
            this.BottomPN.ResumeLayout(false);
            this.BottomPN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KeepAliveTimeUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PublishingIntervalUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LifeTimeUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxNotificationsUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriorityUD)).EndInit();
            this.InstructionsGB.ResumeLayout(false);
            this.TopPN.ResumeLayout(false);
            this.MainPN.ResumeLayout(false);
            this.MainPN.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BottomPN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.GroupBox InstructionsGB;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Button HelpBTN;
        private System.Windows.Forms.Button ShowCodeBTN;
        private System.Windows.Forms.Label InstructionsLB;
        private System.Windows.Forms.GroupBox RequestParametersGB;
        private System.Windows.Forms.TableLayoutPanel MainPN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label PriorityLB;
        private System.Windows.Forms.Label MaxNotifications2LB;
        private System.Windows.Forms.Label LifeTimeLB;
        private System.Windows.Forms.TextBox CurrentKeepAliveTimeTB;
        private System.Windows.Forms.Label KeepAliveTimeLB;
        private System.Windows.Forms.TextBox CurrentPublishingIntervalTB;
        private System.Windows.Forms.NumericUpDown KeepAliveTimeUD;
        private System.Windows.Forms.NumericUpDown PublishingIntervalUD;
        private System.Windows.Forms.NumericUpDown LifeTimeUD;
        private System.Windows.Forms.TextBox CurrentLifeTimeTB;
        private System.Windows.Forms.NumericUpDown MaxNotificationsUD;
        private System.Windows.Forms.TextBox CurrentMaxNotificationsTB;
        private System.Windows.Forms.NumericUpDown PriorityUD;
        private System.Windows.Forms.TextBox CurrentPriorityTB;
        private System.Windows.Forms.Label PubishingEnabledLB;
        private System.Windows.Forms.CheckBox PublishingEnabledCK;
        private System.Windows.Forms.CheckBox CurrentPublishingEnabledCK;
        private System.Windows.Forms.Label PublishingIntervalLB;
        private System.Windows.Forms.CheckBox UseAsynchCK;
        private System.Windows.Forms.Button ModifyBTN;
    }
}
