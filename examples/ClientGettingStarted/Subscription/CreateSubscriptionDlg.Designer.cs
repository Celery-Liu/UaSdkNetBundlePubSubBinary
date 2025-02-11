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
    partial class CreateSubscriptionDlg
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
            this.CreateBTN = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.KeepAliveTimeUD = new System.Windows.Forms.NumericUpDown();
            this.PublishingIntervalUD = new System.Windows.Forms.NumericUpDown();
            this.LifeTimeUD = new System.Windows.Forms.NumericUpDown();
            this.MaxNotificationsUD = new System.Windows.Forms.NumericUpDown();
            this.PriorityUD = new System.Windows.Forms.NumericUpDown();
            this.PublishingEnabledCK = new System.Windows.Forms.CheckBox();
            this.MainPN = new System.Windows.Forms.TableLayoutPanel();
            this.RevisedParametersLB = new System.Windows.Forms.Label();
            this.RequestedParametersLB = new System.Windows.Forms.Label();
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
            this.InstructionsGB = new System.Windows.Forms.GroupBox();
            this.TopPN = new System.Windows.Forms.Panel();
            this.HelpBTN = new System.Windows.Forms.Button();
            this.ShowCodeBTN = new System.Windows.Forms.Button();
            this.InstructionsLB = new System.Windows.Forms.Label();
            this.RequestParametersGB = new System.Windows.Forms.GroupBox();
            this.BottomPN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KeepAliveTimeUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PublishingIntervalUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LifeTimeUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxNotificationsUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriorityUD)).BeginInit();
            this.MainPN.SuspendLayout();
            this.InstructionsGB.SuspendLayout();
            this.TopPN.SuspendLayout();
            this.RequestParametersGB.SuspendLayout();
            this.SuspendLayout();
            //
            // BottomPN
            //
            this.BottomPN.Controls.Add(this.UseAsynchCK);
            this.BottomPN.Controls.Add(this.CreateBTN);
            this.BottomPN.Controls.Add(this.CancelBTN);
            this.BottomPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPN.Location = new System.Drawing.Point(3, 298);
            this.BottomPN.Name = "BottomPN";
            this.BottomPN.Size = new System.Drawing.Size(578, 29);
            this.BottomPN.TabIndex = 1;
            //
            // UseAsynchCK
            //
            this.UseAsynchCK.AutoSize = true;
            this.UseAsynchCK.Location = new System.Drawing.Point(84, 7);
            this.UseAsynchCK.Name = "UseAsynchCK";
            this.UseAsynchCK.Size = new System.Drawing.Size(152, 17);
            this.UseAsynchCK.TabIndex = 18;
            this.UseAsynchCK.Text = "Use Asynchronous Pattern";
            this.UseAsynchCK.UseVisualStyleBackColor = true;
            //
            // CreateBTN
            //
            this.CreateBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CreateBTN.Location = new System.Drawing.Point(3, 3);
            this.CreateBTN.Name = "CreateBTN";
            this.CreateBTN.Size = new System.Drawing.Size(75, 23);
            this.CreateBTN.TabIndex = 17;
            this.CreateBTN.Tag = "";
            this.CreateBTN.Text = "Create";
            this.CreateBTN.UseVisualStyleBackColor = true;
            this.CreateBTN.Click += new System.EventHandler(this.CreateBTN_Click);
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
            // KeepAliveTimeUD
            //
            this.KeepAliveTimeUD.Location = new System.Drawing.Point(106, 54);
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
            this.PublishingIntervalUD.Location = new System.Drawing.Point(106, 28);
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
            this.LifeTimeUD.Location = new System.Drawing.Point(106, 80);
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
            this.MaxNotificationsUD.Location = new System.Drawing.Point(106, 106);
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
            this.PriorityUD.Location = new System.Drawing.Point(106, 132);
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
            this.PublishingEnabledCK.Location = new System.Drawing.Point(106, 161);
            this.PublishingEnabledCK.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.PublishingEnabledCK.Name = "PublishingEnabledCK";
            this.PublishingEnabledCK.Size = new System.Drawing.Size(15, 14);
            this.PublishingEnabledCK.TabIndex = 17;
            this.ToolTip.SetToolTip(this.PublishingEnabledCK, "Whether publishing should be enabled.");
            this.PublishingEnabledCK.UseVisualStyleBackColor = true;
            //
            // MainPN
            //
            this.MainPN.ColumnCount = 5;
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainPN.Controls.Add(this.RevisedParametersLB, 3, 0);
            this.MainPN.Controls.Add(this.RequestedParametersLB, 1, 0);
            this.MainPN.Controls.Add(this.PriorityLB, 0, 5);
            this.MainPN.Controls.Add(this.MaxNotifications2LB, 0, 4);
            this.MainPN.Controls.Add(this.LifeTimeLB, 0, 3);
            this.MainPN.Controls.Add(this.CurrentKeepAliveTimeTB, 3, 2);
            this.MainPN.Controls.Add(this.KeepAliveTimeLB, 0, 2);
            this.MainPN.Controls.Add(this.CurrentPublishingIntervalTB, 3, 1);
            this.MainPN.Controls.Add(this.KeepAliveTimeUD, 1, 2);
            this.MainPN.Controls.Add(this.PublishingIntervalUD, 1, 1);
            this.MainPN.Controls.Add(this.LifeTimeUD, 1, 3);
            this.MainPN.Controls.Add(this.CurrentLifeTimeTB, 3, 3);
            this.MainPN.Controls.Add(this.MaxNotificationsUD, 1, 4);
            this.MainPN.Controls.Add(this.CurrentMaxNotificationsTB, 3, 4);
            this.MainPN.Controls.Add(this.PriorityUD, 1, 5);
            this.MainPN.Controls.Add(this.CurrentPriorityTB, 3, 5);
            this.MainPN.Controls.Add(this.PubishingEnabledLB, 0, 6);
            this.MainPN.Controls.Add(this.PublishingEnabledCK, 1, 6);
            this.MainPN.Controls.Add(this.CurrentPublishingEnabledCK, 3, 6);
            this.MainPN.Controls.Add(this.PublishingIntervalLB, 0, 1);
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(3, 16);
            this.MainPN.Name = "MainPN";
            this.MainPN.RowCount = 8;
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.Size = new System.Drawing.Size(572, 180);
            this.MainPN.TabIndex = 0;
            //
            // RevisedParametersLB
            //
            this.RevisedParametersLB.AutoSize = true;
            this.RevisedParametersLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RevisedParametersLB.Location = new System.Drawing.Point(347, 0);
            this.RevisedParametersLB.Name = "RevisedParametersLB";
            this.RevisedParametersLB.Size = new System.Drawing.Size(102, 25);
            this.RevisedParametersLB.TabIndex = 19;
            this.RevisedParametersLB.Text = "Revised Parameters";
            this.RevisedParametersLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // RequestedParametersLB
            //
            this.RequestedParametersLB.AutoSize = true;
            this.RequestedParametersLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RequestedParametersLB.Location = new System.Drawing.Point(106, 0);
            this.RequestedParametersLB.Name = "RequestedParametersLB";
            this.RequestedParametersLB.Size = new System.Drawing.Size(115, 25);
            this.RequestedParametersLB.TabIndex = 18;
            this.RequestedParametersLB.Text = "Requested Parameters";
            this.RequestedParametersLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // PriorityLB
            //
            this.PriorityLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.PriorityLB.AutoSize = true;
            this.PriorityLB.Location = new System.Drawing.Point(3, 129);
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
            this.MaxNotifications2LB.Location = new System.Drawing.Point(3, 103);
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
            this.LifeTimeLB.Location = new System.Drawing.Point(3, 77);
            this.LifeTimeLB.Name = "LifeTimeLB";
            this.LifeTimeLB.Size = new System.Drawing.Size(50, 26);
            this.LifeTimeLB.TabIndex = 7;
            this.LifeTimeLB.Text = "Life Time";
            this.LifeTimeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // CurrentKeepAliveTimeTB
            //
            this.CurrentKeepAliveTimeTB.BackColor = System.Drawing.SystemColors.Window;
            this.CurrentKeepAliveTimeTB.Location = new System.Drawing.Point(347, 54);
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
            this.KeepAliveTimeLB.Location = new System.Drawing.Point(3, 51);
            this.KeepAliveTimeLB.Name = "KeepAliveTimeLB";
            this.KeepAliveTimeLB.Size = new System.Drawing.Size(84, 26);
            this.KeepAliveTimeLB.TabIndex = 4;
            this.KeepAliveTimeLB.Text = "Keep Alive Time";
            this.KeepAliveTimeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // CurrentPublishingIntervalTB
            //
            this.CurrentPublishingIntervalTB.BackColor = System.Drawing.SystemColors.Window;
            this.CurrentPublishingIntervalTB.Location = new System.Drawing.Point(347, 28);
            this.CurrentPublishingIntervalTB.Name = "CurrentPublishingIntervalTB";
            this.CurrentPublishingIntervalTB.ReadOnly = true;
            this.CurrentPublishingIntervalTB.Size = new System.Drawing.Size(100, 20);
            this.CurrentPublishingIntervalTB.TabIndex = 3;
            //
            // CurrentLifeTimeTB
            //
            this.CurrentLifeTimeTB.BackColor = System.Drawing.SystemColors.Window;
            this.CurrentLifeTimeTB.Location = new System.Drawing.Point(347, 80);
            this.CurrentLifeTimeTB.Name = "CurrentLifeTimeTB";
            this.CurrentLifeTimeTB.ReadOnly = true;
            this.CurrentLifeTimeTB.Size = new System.Drawing.Size(100, 20);
            this.CurrentLifeTimeTB.TabIndex = 9;
            //
            // CurrentMaxNotificationsTB
            //
            this.CurrentMaxNotificationsTB.BackColor = System.Drawing.SystemColors.Window;
            this.CurrentMaxNotificationsTB.Location = new System.Drawing.Point(347, 106);
            this.CurrentMaxNotificationsTB.Name = "CurrentMaxNotificationsTB";
            this.CurrentMaxNotificationsTB.ReadOnly = true;
            this.CurrentMaxNotificationsTB.Size = new System.Drawing.Size(100, 20);
            this.CurrentMaxNotificationsTB.TabIndex = 12;
            //
            // CurrentPriorityTB
            //
            this.CurrentPriorityTB.BackColor = System.Drawing.SystemColors.Window;
            this.CurrentPriorityTB.Location = new System.Drawing.Point(347, 132);
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
            this.PubishingEnabledLB.Location = new System.Drawing.Point(3, 155);
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
            this.CurrentPublishingEnabledCK.Location = new System.Drawing.Point(347, 161);
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
            this.PublishingIntervalLB.Location = new System.Drawing.Point(3, 25);
            this.PublishingIntervalLB.Name = "PublishingIntervalLB";
            this.PublishingIntervalLB.Size = new System.Drawing.Size(93, 26);
            this.PublishingIntervalLB.TabIndex = 1;
            this.PublishingIntervalLB.Text = "Publishing Interval";
            this.PublishingIntervalLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.RequestParametersGB.Controls.Add(this.MainPN);
            this.RequestParametersGB.Location = new System.Drawing.Point(3, 91);
            this.RequestParametersGB.Name = "RequestParametersGB";
            this.RequestParametersGB.Size = new System.Drawing.Size(578, 199);
            this.RequestParametersGB.TabIndex = 24;
            this.RequestParametersGB.TabStop = false;
            //
            // CreateSubscriptionDlg
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 327);
            this.Controls.Add(this.RequestParametersGB);
            this.Controls.Add(this.InstructionsGB);
            this.Controls.Add(this.BottomPN);
            this.Name = "CreateSubscriptionDlg";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Subscription";
            this.BottomPN.ResumeLayout(false);
            this.BottomPN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KeepAliveTimeUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PublishingIntervalUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LifeTimeUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxNotificationsUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriorityUD)).EndInit();
            this.MainPN.ResumeLayout(false);
            this.MainPN.PerformLayout();
            this.InstructionsGB.ResumeLayout(false);
            this.TopPN.ResumeLayout(false);
            this.RequestParametersGB.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BottomPN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.TableLayoutPanel MainPN;
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
        private System.Windows.Forms.Label RevisedParametersLB;
        private System.Windows.Forms.Label RequestedParametersLB;
        private System.Windows.Forms.GroupBox InstructionsGB;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Button HelpBTN;
        private System.Windows.Forms.Button ShowCodeBTN;
        private System.Windows.Forms.Label InstructionsLB;
        private System.Windows.Forms.GroupBox RequestParametersGB;
        private System.Windows.Forms.CheckBox UseAsynchCK;
        private System.Windows.Forms.Button CreateBTN;
    }
}
