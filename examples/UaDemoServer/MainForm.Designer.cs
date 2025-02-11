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

namespace UnifiedAutomation.Sample
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.MainPanel = new System.Windows.Forms.TabControl();
            this.EndpointsTabPage = new System.Windows.Forms.TabPage();
            this.WarningLinkLabel = new System.Windows.Forms.LinkLabel();
            this.EndpointsListView = new System.Windows.Forms.ListView();
            this.EndpointUrlCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SecurityPolicyCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SecurityModeCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TransportProfileCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SessionsTabPage = new System.Windows.Forms.TabPage();
            this.SessionsListView = new System.Windows.Forms.ListView();
            this.SessionNameCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TransportCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SecurityProfileCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserIdentityCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ConnectTimeCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastUpdateTimeCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RejectedCertificatesTabPage = new System.Windows.Forms.TabPage();
            this.CertificateListView = new System.Windows.Forms.ListView();
            this.StatusColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DomainHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OrganizationColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OrganizationalUnitColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValidToColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CertificateMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TrustTemporarilyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TrustPermanentlyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RejectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenStoreMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserManagementTabPage = new System.Windows.Forms.TabPage();
            this.UsersTable = new System.Windows.Forms.TableLayoutPanel();
            this.UserDetailPanel = new System.Windows.Forms.Panel();
            this.UserConfigurationMaskCheckBox = new System.Windows.Forms.CheckedListBox();
            this.UserNameText = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.UserConfigurationLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.UsersTreeView = new System.Windows.Forms.TreeView();
            this.UsersLabel = new System.Windows.Forms.Label();
            this.RolesTable = new System.Windows.Forms.TableLayoutPanel();
            this.RolesTreeView = new System.Windows.Forms.TreeView();
            this.RolesLabel = new System.Windows.Forms.Label();
            this.StatisticsTabPage = new System.Windows.Forms.TabPage();
            this.StatisticsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MonitoredItemCountTextBox = new System.Windows.Forms.Label();
            this.RequestQueueSizeTextBox = new System.Windows.Forms.Label();
            this.RequestQueueSizeLabel = new System.Windows.Forms.Label();
            this.SubscriptionCountTextBox = new System.Windows.Forms.Label();
            this.SubscriptionCountLabel = new System.Windows.Forms.Label();
            this.SessionCountTextBox = new System.Windows.Forms.Label();
            this.SessionCountLabel = new System.Windows.Forms.Label();
            this.TotalThreadCountTextBox = new System.Windows.Forms.Label();
            this.TotalThreadCountLabel = new System.Windows.Forms.Label();
            this.ActiveThreadCountTextBox = new System.Windows.Forms.Label();
            this.ActiveThreadCountLabel = new System.Windows.Forms.Label();
            this.ItemTreeView = new System.Windows.Forms.TreeView();
            this.MonitoredItemCountLabel = new System.Windows.Forms.Label();
            this.TreeViewGB = new System.Windows.Forms.GroupBox();
            this.TreeViewLBL = new System.Windows.Forms.Label();
            this.EnableTreeViewCB = new System.Windows.Forms.CheckBox();
            this.CollapseTreeViewBTN = new System.Windows.Forms.Button();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.ExpandTreeViewBTN = new System.Windows.Forms.Button();
            this.UpdateTreeViewBTN = new System.Windows.Forms.Button();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.ShutdownServerButton = new System.Windows.Forms.Button();
            this.RestartServerButton = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.MainPanel.SuspendLayout();
            this.EndpointsTabPage.SuspendLayout();
            this.SessionsTabPage.SuspendLayout();
            this.RejectedCertificatesTabPage.SuspendLayout();
            this.CertificateMenuStrip.SuspendLayout();
            this.UserManagementTabPage.SuspendLayout();
            this.UsersTable.SuspendLayout();
            this.UserDetailPanel.SuspendLayout();
            this.RolesTable.SuspendLayout();
            this.StatisticsTabPage.SuspendLayout();
            this.StatisticsPanel.SuspendLayout();
            this.TreeViewGB.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Interval = 1000;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.EndpointsTabPage);
            this.MainPanel.Controls.Add(this.SessionsTabPage);
            this.MainPanel.Controls.Add(this.RejectedCertificatesTabPage);
            this.MainPanel.Controls.Add(this.UserManagementTabPage);
            this.MainPanel.Controls.Add(this.StatisticsTabPage);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.SelectedIndex = 0;
            this.MainPanel.ShowToolTips = true;
            this.MainPanel.Size = new System.Drawing.Size(1208, 830);
            this.MainPanel.TabIndex = 9;
            this.MainPanel.SelectedIndexChanged += MainPanel_SelectedIndexChanged;
            // 
            // EndpointsTabPage
            // 
            this.EndpointsTabPage.Controls.Add(this.WarningLinkLabel);
            this.EndpointsTabPage.Controls.Add(this.EndpointsListView);
            this.EndpointsTabPage.Location = new System.Drawing.Point(4, 29);
            this.EndpointsTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EndpointsTabPage.Name = "EndpointsTabPage";
            this.EndpointsTabPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EndpointsTabPage.Size = new System.Drawing.Size(1168, 786);
            this.EndpointsTabPage.TabIndex = 0;
            this.EndpointsTabPage.Text = "Endpoints";
            this.EndpointsTabPage.ToolTipText = "Overview of Endpoint descriptions provided by the server and their status.";
            this.EndpointsTabPage.UseVisualStyleBackColor = true;
            // 
            // WarningLinkLabel
            // 
            this.WarningLinkLabel.ActiveLinkColor = System.Drawing.Color.Maroon;
            this.WarningLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.WarningLinkLabel.BackColor = System.Drawing.Color.Red;
            this.WarningLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarningLinkLabel.LinkColor = System.Drawing.Color.White;
            this.WarningLinkLabel.Location = new System.Drawing.Point(564, 740);
            this.WarningLinkLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.WarningLinkLabel.Name = "WarningLinkLabel";
            this.WarningLinkLabel.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.WarningLinkLabel.Size = new System.Drawing.Size(600, 40);
            this.WarningLinkLabel.TabIndex = 16;
            this.WarningLinkLabel.TabStop = true;
            this.WarningLinkLabel.Text = "Server does not have an Application Certificate!";
            this.WarningLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.WarningLinkLabel.Visible = false;
            this.WarningLinkLabel.VisitedLinkColor = System.Drawing.Color.White;
            this.WarningLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WarningLinkLabel_LinkClicked);
            // 
            // EndpointsListView
            // 
            this.EndpointsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EndpointUrlCH,
            this.StatusCH,
            this.SecurityPolicyCH,
            this.SecurityModeCH,
            this.TransportProfileCH});
            this.EndpointsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndpointsListView.FullRowSelect = true;
            this.EndpointsListView.HideSelection = false;
            this.EndpointsListView.Location = new System.Drawing.Point(4, 5);
            this.EndpointsListView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EndpointsListView.MultiSelect = false;
            this.EndpointsListView.Name = "EndpointsListView";
            this.EndpointsListView.Size = new System.Drawing.Size(1160, 776);
            this.EndpointsListView.TabIndex = 8;
            this.EndpointsListView.UseCompatibleStateImageBehavior = false;
            this.EndpointsListView.View = System.Windows.Forms.View.Details;
            this.EndpointsListView.DoubleClick += new System.EventHandler(this.EndpointsListView_DoubleClick);
            // 
            // EndpointUrlCH
            // 
            this.EndpointUrlCH.Text = "URL";
            this.EndpointUrlCH.Width = 114;
            // 
            // StatusCH
            // 
            this.StatusCH.Text = "Status";
            // 
            // SecurityPolicyCH
            // 
            this.SecurityPolicyCH.Text = "Security Policy";
            this.SecurityPolicyCH.Width = 141;
            // 
            // SecurityModeCH
            // 
            this.SecurityModeCH.Text = "Security Mode";
            this.SecurityModeCH.Width = 136;
            // 
            // TransportProfileCH
            // 
            this.TransportProfileCH.Text = "Transport Profile";
            this.TransportProfileCH.Width = 178;
            // 
            // SessionsTabPage
            // 
            this.SessionsTabPage.Controls.Add(this.SessionsListView);
            this.SessionsTabPage.Location = new System.Drawing.Point(4, 29);
            this.SessionsTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SessionsTabPage.Name = "SessionsTabPage";
            this.SessionsTabPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SessionsTabPage.Size = new System.Drawing.Size(1756, 1227);
            this.SessionsTabPage.TabIndex = 1;
            this.SessionsTabPage.Text = "Sessions";
            this.SessionsTabPage.ToolTipText = "Overview of Sessions connected to the server";
            this.SessionsTabPage.UseVisualStyleBackColor = true;
            // 
            // SessionsListView
            // 
            this.SessionsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SessionNameCH,
            this.TransportCH,
            this.SecurityProfileCH,
            this.UserIdentityCH,
            this.ConnectTimeCH,
            this.LastUpdateTimeCH});
            this.SessionsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SessionsListView.FullRowSelect = true;
            this.SessionsListView.HideSelection = false;
            this.SessionsListView.Location = new System.Drawing.Point(4, 5);
            this.SessionsListView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SessionsListView.MultiSelect = false;
            this.SessionsListView.Name = "SessionsListView";
            this.SessionsListView.Size = new System.Drawing.Size(1748, 1217);
            this.SessionsListView.TabIndex = 9;
            this.SessionsListView.UseCompatibleStateImageBehavior = false;
            this.SessionsListView.View = System.Windows.Forms.View.Details;
            // 
            // SessionNameCH
            // 
            this.SessionNameCH.Text = "Session Name";
            this.SessionNameCH.Width = 114;
            // 
            // TransportCH
            // 
            this.TransportCH.Text = "Transport";
            // 
            // SecurityProfileCH
            // 
            this.SecurityProfileCH.Text = "Security Profile";
            this.SecurityProfileCH.Width = 115;
            // 
            // UserIdentityCH
            // 
            this.UserIdentityCH.Text = "User Identity";
            this.UserIdentityCH.Width = 110;
            // 
            // ConnectTimeCH
            // 
            this.ConnectTimeCH.Text = "Connect Time";
            this.ConnectTimeCH.Width = 81;
            // 
            // LastUpdateTimeCH
            // 
            this.LastUpdateTimeCH.Text = "Last Update Time";
            this.LastUpdateTimeCH.Width = 108;
            // 
            // RejectedCertificatesTabPage
            // 
            this.RejectedCertificatesTabPage.Controls.Add(this.CertificateListView);
            this.RejectedCertificatesTabPage.Location = new System.Drawing.Point(4, 29);
            this.RejectedCertificatesTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RejectedCertificatesTabPage.Name = "RejectedCertificatesTabPage";
            this.RejectedCertificatesTabPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RejectedCertificatesTabPage.Size = new System.Drawing.Size(1756, 1227);
            this.RejectedCertificatesTabPage.TabIndex = 2;
            this.RejectedCertificatesTabPage.Text = "Rejected Certificates";
            this.RejectedCertificatesTabPage.ToolTipText = "Overview of certificates rejected by the server";
            this.RejectedCertificatesTabPage.UseVisualStyleBackColor = true;
            // 
            // CertificateListView
            // 
            this.CertificateListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.StatusColumn,
            this.NameColumn,
            this.DomainHeader,
            this.OrganizationColumn,
            this.OrganizationalUnitColumn,
            this.ValidToColumn});
            this.CertificateListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CertificateListView.FullRowSelect = true;
            this.CertificateListView.HideSelection = false;
            this.CertificateListView.Location = new System.Drawing.Point(4, 5);
            this.CertificateListView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CertificateListView.MultiSelect = false;
            this.CertificateListView.Name = "CertificateListView";
            this.CertificateListView.Size = new System.Drawing.Size(1748, 1217);
            this.CertificateListView.TabIndex = 9;
            this.CertificateListView.UseCompatibleStateImageBehavior = false;
            this.CertificateListView.View = System.Windows.Forms.View.Details;
            this.CertificateListView.DoubleClick += new System.EventHandler(this.CertificateListView_DoubleClick);
            this.CertificateListView.MouseClick += CertificateListView_ItemMenuStrip;
            // 
            // StatusColumn
            // 
            this.StatusColumn.Text = "Status";
            this.StatusColumn.Width = 86;
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Name";
            this.NameColumn.Width = 102;
            // 
            // DomainHeader
            // 
            this.DomainHeader.Text = "Domains";
            // 
            // OrganizationColumn
            // 
            this.OrganizationColumn.Text = "Organization";
            this.OrganizationColumn.Width = 110;
            // 
            // OrganizationalUnitColumn
            // 
            this.OrganizationalUnitColumn.Text = "Organizational Unit";
            this.OrganizationalUnitColumn.Width = 136;
            // 
            // ValidToColumn
            // 
            this.ValidToColumn.Text = "ValidTo";
            this.ValidToColumn.Width = 92;
            // 
            // CertificateMenuStrip
            // 
            this.CertificateMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.CertificateMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TrustTemporarilyMenuItem,
            this.TrustPermanentlyMenuItem,
            this.RejectMenuItem,
            this.OpenStoreMenuItem});
            this.CertificateMenuStrip.Name = "CertificateMenuStrip";
            this.CertificateMenuStrip.Size = new System.Drawing.Size(246, 132);
            // 
            // TrustTemporarilyMenuItem
            // 
            this.TrustTemporarilyMenuItem.Name = "TrustTemporarilyMenuItem";
            this.TrustTemporarilyMenuItem.Size = new System.Drawing.Size(245, 32);
            this.TrustTemporarilyMenuItem.Text = "Trust Temporarily";
            this.TrustTemporarilyMenuItem.ToolTipText = "Trust Certificate until restart. Certificate will not be copied to Trusted Store";
            this.TrustTemporarilyMenuItem.Click += new System.EventHandler(this.TrustTemporarilyMenuItem_Click);
            // 
            // TrustPermanentlyMenuItem
            // 
            this.TrustPermanentlyMenuItem.Name = "TrustPermanentlyMenuItem";
            this.TrustPermanentlyMenuItem.Size = new System.Drawing.Size(245, 32);
            this.TrustPermanentlyMenuItem.Text = "Trust Permanently...";
            this.TrustPermanentlyMenuItem.ToolTipText = "Trust Certificate permanently. Certificate will be copied to Trusted Store.";
            this.TrustPermanentlyMenuItem.Click += new System.EventHandler(this.TrustPermanentlyMenuItem_Click);
            // 
            // RejectMenuItem
            // 
            this.RejectMenuItem.Name = "DeleteRejectMenuItem";
            this.RejectMenuItem.Size = new System.Drawing.Size(245, 32);
            this.RejectMenuItem.Text = "Delete from Rejected Store";
            this.RejectMenuItem.ToolTipText = "Certificate will be deleted from Rejected Store.";
            this.RejectMenuItem.Click += new System.EventHandler(this.DeleteRejectMenuItem_Click);
            // 
            // OpenStoreMenuItem
            // 
            this.OpenStoreMenuItem.Name = "OpenStoreMenuItem";
            this.OpenStoreMenuItem.Size = new System.Drawing.Size(245, 32);
            this.OpenStoreMenuItem.Text = "Open Rejected Store";
            this.OpenStoreMenuItem.ToolTipText = "Opens the Rejected Store folder. Not usable with Windows Store Type.";
            this.OpenStoreMenuItem.Click += new System.EventHandler(this.OpenStoreMenuItem_Click);
            // 
            // UserManagementTabPage
            // 
            this.UserManagementTabPage.Controls.Add(this.UsersTable);
            this.UserManagementTabPage.Controls.Add(this.RolesTable);
            this.UserManagementTabPage.Location = new System.Drawing.Point(4, 29);
            this.UserManagementTabPage.Name = "UserManagementTabPage";
            this.UserManagementTabPage.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.UserManagementTabPage.Size = new System.Drawing.Size(1756, 1227);
            this.UserManagementTabPage.TabIndex = 4;
            this.UserManagementTabPage.Text = "User Management";
            this.UserManagementTabPage.ToolTipText = "Overview of Roles and Users provided by the server.";
            this.UserManagementTabPage.UseVisualStyleBackColor = true;
            // 
            // UsersTable
            // 
            this.UsersTable.ColumnCount = 1;
            this.UsersTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.UsersTable.Controls.Add(this.UserDetailPanel, 0, 2);
            this.UsersTable.Controls.Add(this.UsersTreeView, 0, 1);
            this.UsersTable.Controls.Add(this.UsersLabel, 0, 0);
            this.UsersTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsersTable.Location = new System.Drawing.Point(335, 3);
            this.UsersTable.Name = "UsersTable";
            this.UsersTable.RowCount = 3;
            this.UsersTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.UsersTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.21053F));
            this.UsersTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.78947F));
            this.UsersTable.Size = new System.Drawing.Size(1418, 1221);
            this.UsersTable.TabIndex = 12;
            // 
            // UserDetailPanel
            // 
            this.UserDetailPanel.AutoScroll = true;
            this.UserDetailPanel.AutoScrollMargin = new System.Drawing.Size(100, 0);
            this.UserDetailPanel.BackColor = System.Drawing.SystemColors.Window;
            this.UserDetailPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserDetailPanel.Controls.Add(this.UserConfigurationMaskCheckBox);
            this.UserDetailPanel.Controls.Add(this.UserNameText);
            this.UserDetailPanel.Controls.Add(this.DescriptionLabel);
            this.UserDetailPanel.Controls.Add(this.DescriptionTextBox);
            this.UserDetailPanel.Controls.Add(this.UserConfigurationLabel);
            this.UserDetailPanel.Controls.Add(this.UsernameLabel);
            this.UserDetailPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserDetailPanel.Location = new System.Drawing.Point(3, 798);
            this.UserDetailPanel.Name = "UserDetailPanel";
            this.UserDetailPanel.Size = new System.Drawing.Size(1412, 420);
            this.UserDetailPanel.TabIndex = 11;
            // 
            // UserConfigurationMaskCheckBox
            // 
            this.UserConfigurationMaskCheckBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserConfigurationMaskCheckBox.FormattingEnabled = true;
            this.UserConfigurationMaskCheckBox.Location = new System.Drawing.Point(32, 111);
            this.UserConfigurationMaskCheckBox.Name = "UserConfigurationMaskCheckBox";
            this.UserConfigurationMaskCheckBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.UserConfigurationMaskCheckBox.Size = new System.Drawing.Size(246, 115);
            this.UserConfigurationMaskCheckBox.TabIndex = 12;
            // 
            // UserNameText
            // 
            this.UserNameText.AutoSize = true;
            this.UserNameText.Location = new System.Drawing.Point(27, 38);
            this.UserNameText.Name = "UserNameText";
            this.UserNameText.Size = new System.Drawing.Size(144, 20);
            this.UserNameText.TabIndex = 11;
            this.UserNameText.Text = "_______________";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionLabel.Location = new System.Drawing.Point(346, 15);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(105, 20);
            this.DescriptionLabel.TabIndex = 9;
            this.DescriptionLabel.Text = "Description:";
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.DescriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DescriptionTextBox.Location = new System.Drawing.Point(366, 38);
            this.DescriptionTextBox.MinimumSize = new System.Drawing.Size(200, 0);
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.ReadOnly = true;
            this.DescriptionTextBox.Size = new System.Drawing.Size(1028, 364);
            this.DescriptionTextBox.TabIndex = 6;
            // 
            // UserConfigurationLabel
            // 
            this.UserConfigurationLabel.AutoSize = true;
            this.UserConfigurationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserConfigurationLabel.Location = new System.Drawing.Point(16, 85);
            this.UserConfigurationLabel.Name = "UserConfigurationLabel";
            this.UserConfigurationLabel.Size = new System.Drawing.Size(165, 20);
            this.UserConfigurationLabel.TabIndex = 10;
            this.UserConfigurationLabel.Text = "User Configuration:";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(16, 15);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(96, 20);
            this.UsernameLabel.TabIndex = 7;
            this.UsernameLabel.Text = "Username:";
            // 
            // UsersTreeView
            // 
            this.UsersTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UsersTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsersTreeView.Location = new System.Drawing.Point(3, 34);
            this.UsersTreeView.Name = "UsersTreeView";
            this.UsersTreeView.Size = new System.Drawing.Size(1412, 758);
            this.UsersTreeView.TabIndex = 5;
            // 
            // UsersLabel
            // 
            this.UsersLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UsersLabel.AutoSize = true;
            this.UsersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsersLabel.Location = new System.Drawing.Point(3, 11);
            this.UsersLabel.Name = "UsersLabel";
            this.UsersLabel.Size = new System.Drawing.Size(56, 20);
            this.UsersLabel.TabIndex = 0;
            this.UsersLabel.Text = "Users";
            // 
            // RolesTable
            // 
            this.RolesTable.ColumnCount = 1;
            this.RolesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RolesTable.Controls.Add(this.RolesTreeView, 0, 1);
            this.RolesTable.Controls.Add(this.RolesLabel, 0, 0);
            this.RolesTable.Dock = System.Windows.Forms.DockStyle.Left;
            this.RolesTable.Location = new System.Drawing.Point(3, 3);
            this.RolesTable.Name = "RolesTable";
            this.RolesTable.RowCount = 2;
            this.RolesTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.RolesTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RolesTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RolesTable.Size = new System.Drawing.Size(332, 1221);
            this.RolesTable.TabIndex = 13;
            // 
            // RolesTreeView
            // 
            this.RolesTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RolesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RolesTreeView.Location = new System.Drawing.Point(3, 34);
            this.RolesTreeView.Name = "RolesTreeView";
            this.RolesTreeView.Size = new System.Drawing.Size(326, 1184);
            this.RolesTreeView.TabIndex = 7;
            // 
            // RolesLabel
            // 
            this.RolesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RolesLabel.AutoSize = true;
            this.RolesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RolesLabel.Location = new System.Drawing.Point(3, 11);
            this.RolesLabel.Name = "RolesLabel";
            this.RolesLabel.Size = new System.Drawing.Size(55, 20);
            this.RolesLabel.TabIndex = 0;
            this.RolesLabel.Text = "Roles";
            // 
            // StatisticsTabPage
            // 
            this.StatisticsTabPage.Controls.Add(this.StatisticsPanel);
            this.StatisticsTabPage.Location = new System.Drawing.Point(4, 29);
            this.StatisticsTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StatisticsTabPage.Name = "StatisticsTabPage";
            this.StatisticsTabPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StatisticsTabPage.Size = new System.Drawing.Size(1200, 797);
            this.StatisticsTabPage.TabIndex = 3;
            this.StatisticsTabPage.Text = "Statistics";
            this.StatisticsTabPage.ToolTipText = "Overview of serveral server statistics and MonitoredItem tree.";
            this.StatisticsTabPage.UseVisualStyleBackColor = true;
            // 
            // StatisticsPanel
            // 
            this.StatisticsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StatisticsPanel.ColumnCount = 2;
            this.StatisticsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.StatisticsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.StatisticsPanel.Controls.Add(this.MonitoredItemCountTextBox, 1, 5);
            this.StatisticsPanel.Controls.Add(this.RequestQueueSizeTextBox, 1, 2);
            this.StatisticsPanel.Controls.Add(this.RequestQueueSizeLabel, 0, 2);
            this.StatisticsPanel.Controls.Add(this.SubscriptionCountTextBox, 1, 4);
            this.StatisticsPanel.Controls.Add(this.SubscriptionCountLabel, 0, 4);
            this.StatisticsPanel.Controls.Add(this.SessionCountTextBox, 1, 3);
            this.StatisticsPanel.Controls.Add(this.SessionCountLabel, 0, 3);
            this.StatisticsPanel.Controls.Add(this.TotalThreadCountTextBox, 1, 1);
            this.StatisticsPanel.Controls.Add(this.TotalThreadCountLabel, 0, 1);
            this.StatisticsPanel.Controls.Add(this.ActiveThreadCountTextBox, 1, 0);
            this.StatisticsPanel.Controls.Add(this.ActiveThreadCountLabel, 0, 0);
            this.StatisticsPanel.Controls.Add(this.ItemTreeView, 1, 6);
            this.StatisticsPanel.Controls.Add(this.MonitoredItemCountLabel, 0, 5);
            this.StatisticsPanel.Controls.Add(this.TreeViewGB, 0, 6);
            this.StatisticsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatisticsPanel.Location = new System.Drawing.Point(4, 5);
            this.StatisticsPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StatisticsPanel.Name = "StatisticsPanel";
            this.StatisticsPanel.RowCount = 7;
            this.StatisticsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.StatisticsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.StatisticsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.StatisticsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.StatisticsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.StatisticsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.StatisticsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.StatisticsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.StatisticsPanel.Size = new System.Drawing.Size(1192, 787);
            this.StatisticsPanel.TabIndex = 0;
            // 
            // MonitoredItemCountTextBox
            // 
            this.MonitoredItemCountTextBox.AutoSize = true;
            this.MonitoredItemCountTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MonitoredItemCountTextBox.Location = new System.Drawing.Point(244, 185);
            this.MonitoredItemCountTextBox.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MonitoredItemCountTextBox.Name = "MonitoredItemCountTextBox";
            this.MonitoredItemCountTextBox.Size = new System.Drawing.Size(944, 37);
            this.MonitoredItemCountTextBox.TabIndex = 14;
            this.MonitoredItemCountTextBox.Text = "---";
            this.MonitoredItemCountTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RequestQueueSizeTextBox
            // 
            this.RequestQueueSizeTextBox.AutoSize = true;
            this.RequestQueueSizeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RequestQueueSizeTextBox.Location = new System.Drawing.Point(246, 74);
            this.RequestQueueSizeTextBox.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.RequestQueueSizeTextBox.Name = "RequestQueueSizeTextBox";
            this.RequestQueueSizeTextBox.Size = new System.Drawing.Size(940, 37);
            this.RequestQueueSizeTextBox.TabIndex = 10;
            this.RequestQueueSizeTextBox.Text = "---";
            this.RequestQueueSizeTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RequestQueueSizeLabel
            // 
            this.RequestQueueSizeLabel.AutoSize = true;
            this.RequestQueueSizeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RequestQueueSizeLabel.Location = new System.Drawing.Point(6, 74);
            this.RequestQueueSizeLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.RequestQueueSizeLabel.Name = "RequestQueueSizeLabel";
            this.RequestQueueSizeLabel.Size = new System.Drawing.Size(228, 37);
            this.RequestQueueSizeLabel.TabIndex = 9;
            this.RequestQueueSizeLabel.Text = "Request Queue Size";
            this.RequestQueueSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SubscriptionCountTextBox
            // 
            this.SubscriptionCountTextBox.AutoSize = true;
            this.SubscriptionCountTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubscriptionCountTextBox.Location = new System.Drawing.Point(246, 148);
            this.SubscriptionCountTextBox.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.SubscriptionCountTextBox.Name = "SubscriptionCountTextBox";
            this.SubscriptionCountTextBox.Size = new System.Drawing.Size(940, 37);
            this.SubscriptionCountTextBox.TabIndex = 8;
            this.SubscriptionCountTextBox.Text = "---";
            this.SubscriptionCountTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SubscriptionCountLabel
            // 
            this.SubscriptionCountLabel.AutoSize = true;
            this.SubscriptionCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubscriptionCountLabel.Location = new System.Drawing.Point(6, 148);
            this.SubscriptionCountLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.SubscriptionCountLabel.Name = "SubscriptionCountLabel";
            this.SubscriptionCountLabel.Size = new System.Drawing.Size(228, 37);
            this.SubscriptionCountLabel.TabIndex = 7;
            this.SubscriptionCountLabel.Text = "Subscription Count";
            this.SubscriptionCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SessionCountTextBox
            // 
            this.SessionCountTextBox.AutoSize = true;
            this.SessionCountTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SessionCountTextBox.Location = new System.Drawing.Point(246, 111);
            this.SessionCountTextBox.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.SessionCountTextBox.Name = "SessionCountTextBox";
            this.SessionCountTextBox.Size = new System.Drawing.Size(940, 37);
            this.SessionCountTextBox.TabIndex = 6;
            this.SessionCountTextBox.Text = "---";
            this.SessionCountTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SessionCountLabel
            // 
            this.SessionCountLabel.AutoSize = true;
            this.SessionCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SessionCountLabel.Location = new System.Drawing.Point(6, 111);
            this.SessionCountLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.SessionCountLabel.Name = "SessionCountLabel";
            this.SessionCountLabel.Size = new System.Drawing.Size(228, 37);
            this.SessionCountLabel.TabIndex = 5;
            this.SessionCountLabel.Text = "Session Count";
            this.SessionCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TotalThreadCountTextBox
            // 
            this.TotalThreadCountTextBox.AutoSize = true;
            this.TotalThreadCountTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TotalThreadCountTextBox.Location = new System.Drawing.Point(246, 37);
            this.TotalThreadCountTextBox.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.TotalThreadCountTextBox.Name = "TotalThreadCountTextBox";
            this.TotalThreadCountTextBox.Size = new System.Drawing.Size(940, 37);
            this.TotalThreadCountTextBox.TabIndex = 4;
            this.TotalThreadCountTextBox.Text = "---";
            this.TotalThreadCountTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TotalThreadCountLabel
            // 
            this.TotalThreadCountLabel.AutoSize = true;
            this.TotalThreadCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TotalThreadCountLabel.Location = new System.Drawing.Point(6, 37);
            this.TotalThreadCountLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.TotalThreadCountLabel.Name = "TotalThreadCountLabel";
            this.TotalThreadCountLabel.Size = new System.Drawing.Size(228, 37);
            this.TotalThreadCountLabel.TabIndex = 3;
            this.TotalThreadCountLabel.Text = "Total Threads";
            this.TotalThreadCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ActiveThreadCountTextBox
            // 
            this.ActiveThreadCountTextBox.AutoSize = true;
            this.ActiveThreadCountTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActiveThreadCountTextBox.Location = new System.Drawing.Point(246, 0);
            this.ActiveThreadCountTextBox.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.ActiveThreadCountTextBox.Name = "ActiveThreadCountTextBox";
            this.ActiveThreadCountTextBox.Size = new System.Drawing.Size(940, 37);
            this.ActiveThreadCountTextBox.TabIndex = 2;
            this.ActiveThreadCountTextBox.Text = "---";
            this.ActiveThreadCountTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ActiveThreadCountLabel
            // 
            this.ActiveThreadCountLabel.AutoSize = true;
            this.ActiveThreadCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActiveThreadCountLabel.Location = new System.Drawing.Point(4, 0);
            this.ActiveThreadCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ActiveThreadCountLabel.Name = "ActiveThreadCountLabel";
            this.ActiveThreadCountLabel.Size = new System.Drawing.Size(232, 37);
            this.ActiveThreadCountLabel.TabIndex = 0;
            this.ActiveThreadCountLabel.Text = "Active Threads";
            this.ActiveThreadCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ItemTreeView
            // 
            this.ItemTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemTreeView.Location = new System.Drawing.Point(244, 237);
            this.ItemTreeView.Margin = new System.Windows.Forms.Padding(4, 15, 10, 5);
            this.ItemTreeView.Name = "ItemTreeView";
            this.ItemTreeView.ShowNodeToolTips = true;
            this.ItemTreeView.Size = new System.Drawing.Size(938, 545);
            this.ItemTreeView.TabIndex = 15;
            // 
            // MonitoredItemCountLabel
            // 
            this.MonitoredItemCountLabel.AutoSize = true;
            this.MonitoredItemCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MonitoredItemCountLabel.Location = new System.Drawing.Point(6, 185);
            this.MonitoredItemCountLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.MonitoredItemCountLabel.Name = "MonitoredItemCountLabel";
            this.MonitoredItemCountLabel.Size = new System.Drawing.Size(228, 37);
            this.MonitoredItemCountLabel.TabIndex = 15;
            this.MonitoredItemCountLabel.Text = "MonitoredItem Count";
            this.MonitoredItemCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TreeViewGB
            // 
            this.TreeViewGB.Controls.Add(this.TreeViewLBL);
            this.TreeViewGB.Controls.Add(this.EnableTreeViewCB);
            this.TreeViewGB.Controls.Add(this.CollapseTreeViewBTN);
            this.TreeViewGB.Controls.Add(this.ExpandTreeViewBTN);
            this.TreeViewGB.Controls.Add(this.UpdateTreeViewBTN);
            this.TreeViewGB.Location = new System.Drawing.Point(8, 227);
            this.TreeViewGB.Margin = new System.Windows.Forms.Padding(8, 5, 4, 5);
            this.TreeViewGB.Name = "TreeViewGB";
            this.TreeViewGB.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TreeViewGB.Size = new System.Drawing.Size(228, 155);
            this.TreeViewGB.TabIndex = 16;
            this.TreeViewGB.TabStop = false;
            // 
            // TreeViewLBL
            // 
            this.TreeViewLBL.AutoSize = true;
            this.TreeViewLBL.Location = new System.Drawing.Point(45, 29);
            this.TreeViewLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TreeViewLBL.Name = "TreeViewLBL";
            this.TreeViewLBL.Size = new System.Drawing.Size(115, 20);
            this.TreeViewLBL.TabIndex = 4;
            this.TreeViewLBL.Text = "Item Tree View";
            // 
            // EnableTreeViewCB
            // 
            this.EnableTreeViewCB.AutoSize = true;
            this.EnableTreeViewCB.Location = new System.Drawing.Point(9, 28);
            this.EnableTreeViewCB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EnableTreeViewCB.Name = "EnableTreeViewCB";
            this.EnableTreeViewCB.Size = new System.Drawing.Size(22, 21);
            this.EnableTreeViewCB.TabIndex = 0;
            this.ToolTips.SetToolTip(this.EnableTreeViewCB, "Set this check box to enable an tree view of all items monitored at the server.");
            this.EnableTreeViewCB.UseVisualStyleBackColor = true;
            this.EnableTreeViewCB.CheckedChanged += new System.EventHandler(this.EnableTreeViewCB_CheckedChanged);
            // 
            // CollapseTreeViewBTN
            // 
            this.CollapseTreeViewBTN.ImageIndex = 7;
            this.CollapseTreeViewBTN.ImageList = this.ImageList;
            this.CollapseTreeViewBTN.Location = new System.Drawing.Point(148, 74);
            this.CollapseTreeViewBTN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CollapseTreeViewBTN.Name = "CollapseTreeViewBTN";
            this.CollapseTreeViewBTN.Size = new System.Drawing.Size(69, 71);
            this.CollapseTreeViewBTN.TabIndex = 3;
            this.ToolTips.SetToolTip(this.CollapseTreeViewBTN, "Collapse the tree view.");
            this.CollapseTreeViewBTN.UseVisualStyleBackColor = true;
            this.CollapseTreeViewBTN.Click += new System.EventHandler(this.CollapseTreeViewBTN_Click);
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "User");
            this.ImageList.Images.SetKeyName(1, "UserGroup");
            this.ImageList.Images.SetKeyName(2, "Certificate");
            this.ImageList.Images.SetKeyName(3, "UserApplication");
            this.ImageList.Images.SetKeyName(4, "AnonymousUser");
            this.ImageList.Images.SetKeyName(5, "");
            this.ImageList.Images.SetKeyName(6, "");
            this.ImageList.Images.SetKeyName(7, "");
            // 
            // ExpandTreeViewBTN
            // 
            this.ExpandTreeViewBTN.ImageIndex = 6;
            this.ExpandTreeViewBTN.ImageList = this.ImageList;
            this.ExpandTreeViewBTN.Location = new System.Drawing.Point(78, 74);
            this.ExpandTreeViewBTN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ExpandTreeViewBTN.Name = "ExpandTreeViewBTN";
            this.ExpandTreeViewBTN.Size = new System.Drawing.Size(69, 71);
            this.ExpandTreeViewBTN.TabIndex = 2;
            this.ToolTips.SetToolTip(this.ExpandTreeViewBTN, "Expand the tree view.");
            this.ExpandTreeViewBTN.UseVisualStyleBackColor = true;
            this.ExpandTreeViewBTN.Click += new System.EventHandler(this.ExpandTreeViewBTN_Click);
            // 
            // UpdateTreeViewBTN
            // 
            this.UpdateTreeViewBTN.ImageIndex = 5;
            this.UpdateTreeViewBTN.ImageList = this.ImageList;
            this.UpdateTreeViewBTN.Location = new System.Drawing.Point(8, 74);
            this.UpdateTreeViewBTN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UpdateTreeViewBTN.Name = "UpdateTreeViewBTN";
            this.UpdateTreeViewBTN.Size = new System.Drawing.Size(69, 71);
            this.UpdateTreeViewBTN.TabIndex = 1;
            this.ToolTips.SetToolTip(this.UpdateTreeViewBTN, "Refresh the tree view.\r\n");
            this.UpdateTreeViewBTN.UseVisualStyleBackColor = true;
            this.UpdateTreeViewBTN.Click += new System.EventHandler(this.UpdateTreeViewBTN_Click);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.InfoLabel);
            this.BottomPanel.Controls.Add(this.ShutdownServerButton);
            this.BottomPanel.Controls.Add(this.RestartServerButton);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 830);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BottomPanel.Size = new System.Drawing.Size(1208, 46);
            this.BottomPanel.TabIndex = 10;
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Location = new System.Drawing.Point(14, 12);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(37, 20);
            this.InfoLabel.TabIndex = 5;
            this.InfoLabel.Text = "Info";
            this.InfoLabel.Visible = false;
            // 
            // ShutdownServerButton
            // 
            this.ShutdownServerButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ShutdownServerButton.Location = new System.Drawing.Point(476, 5);
            this.ShutdownServerButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ShutdownServerButton.Name = "ShutdownServerButton";
            this.ShutdownServerButton.Size = new System.Drawing.Size(364, 36);
            this.ShutdownServerButton.TabIndex = 2;
            this.ShutdownServerButton.Text = "Shutdown Server (10s delay)";
            this.ToolTips.SetToolTip(this.ShutdownServerButton, "Calls the stop method at Server Manager with an 10 seconds delay. The Application" +
        " keeps alive.");
            this.ShutdownServerButton.UseVisualStyleBackColor = true;
            this.ShutdownServerButton.Click += new System.EventHandler(this.ShutdownServerButton_Click);
            // 
            // RestartServerButton
            // 
            this.RestartServerButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.RestartServerButton.Location = new System.Drawing.Point(840, 5);
            this.RestartServerButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RestartServerButton.Name = "RestartServerButton";
            this.RestartServerButton.Size = new System.Drawing.Size(364, 36);
            this.RestartServerButton.TabIndex = 3;
            this.RestartServerButton.Text = "Restart Server (10s delay)";
            this.ToolTips.SetToolTip(this.RestartServerButton, "Calls the stop method at Server Manager with an 10 seconds delay and restart flag" +
        " true.");
            this.RestartServerButton.UseVisualStyleBackColor = true;
            this.RestartServerButton.Click += new System.EventHandler(this.RestartServerButton_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "URL";
            this.columnHeader1.Width = 114;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Security Policy";
            this.columnHeader3.Width = 141;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Security Mode";
            this.columnHeader4.Width = 136;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Transport Profile";
            this.columnHeader5.Width = 178;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 876);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.BottomPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "UaNETServer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MainPanel.ResumeLayout(false);
            this.EndpointsTabPage.ResumeLayout(false);
            this.SessionsTabPage.ResumeLayout(false);
            this.RejectedCertificatesTabPage.ResumeLayout(false);
            this.CertificateMenuStrip.ResumeLayout(false);
            this.UserManagementTabPage.ResumeLayout(false);
            this.UsersTable.ResumeLayout(false);
            this.UsersTable.PerformLayout();
            this.UserDetailPanel.ResumeLayout(false);
            this.UserDetailPanel.PerformLayout();
            this.RolesTable.ResumeLayout(false);
            this.RolesTable.PerformLayout();
            this.StatisticsTabPage.ResumeLayout(false);
            this.StatisticsPanel.ResumeLayout(false);
            this.StatisticsPanel.PerformLayout();
            this.TreeViewGB.ResumeLayout(false);
            this.TreeViewGB.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.TabControl MainPanel;
        private System.Windows.Forms.TabPage EndpointsTabPage;
        private System.Windows.Forms.ListView EndpointsListView;
        private System.Windows.Forms.ColumnHeader EndpointUrlCH;
        private System.Windows.Forms.ColumnHeader StatusCH;
        private System.Windows.Forms.ColumnHeader SecurityPolicyCH;
        private System.Windows.Forms.ColumnHeader SecurityModeCH;
        private System.Windows.Forms.ColumnHeader TransportProfileCH;
        private System.Windows.Forms.TabPage SessionsTabPage;
        private System.Windows.Forms.TabPage RejectedCertificatesTabPage;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button RestartServerButton;
        private System.Windows.Forms.ListView SessionsListView;
        private System.Windows.Forms.ColumnHeader SessionNameCH;
        private System.Windows.Forms.ColumnHeader TransportCH;
        private System.Windows.Forms.ColumnHeader SecurityProfileCH;
        private System.Windows.Forms.ColumnHeader UserIdentityCH;
        private System.Windows.Forms.ColumnHeader ConnectTimeCH;
        private System.Windows.Forms.ColumnHeader LastUpdateTimeCH;
        private System.Windows.Forms.ListView CertificateListView;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.LinkLabel WarningLinkLabel;
        private System.Windows.Forms.ColumnHeader StatusColumn;
        private System.Windows.Forms.ColumnHeader ValidToColumn;
        private System.Windows.Forms.ColumnHeader OrganizationColumn;
        private System.Windows.Forms.ColumnHeader OrganizationalUnitColumn;
        private System.Windows.Forms.ContextMenuStrip CertificateMenuStrip;
        private System.Windows.Forms.ColumnHeader DomainHeader;
        private System.Windows.Forms.ToolStripMenuItem TrustTemporarilyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TrustPermanentlyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RejectMenuItem;
        private System.Windows.Forms.TabPage StatisticsTabPage;
        private System.Windows.Forms.TableLayoutPanel StatisticsPanel;
        private System.Windows.Forms.Label ActiveThreadCountTextBox;
        private System.Windows.Forms.Label ActiveThreadCountLabel;
        private System.Windows.Forms.Label TotalThreadCountTextBox;
        private System.Windows.Forms.Label TotalThreadCountLabel;
        private System.Windows.Forms.Label RequestQueueSizeTextBox;
        private System.Windows.Forms.Label RequestQueueSizeLabel;
        private System.Windows.Forms.Label SubscriptionCountTextBox;
        private System.Windows.Forms.Label SubscriptionCountLabel;
        private System.Windows.Forms.Label SessionCountTextBox;
        private System.Windows.Forms.Label SessionCountLabel;
        private System.Windows.Forms.Button ShutdownServerButton;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.TabPage UserManagementTabPage;
        private System.Windows.Forms.TreeView UsersTreeView;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.TreeView RolesTreeView;
        private System.Windows.Forms.Label UserConfigurationLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label UsersLabel;
        private System.Windows.Forms.Label RolesLabel;
        private System.Windows.Forms.Panel UserDetailPanel;
        private System.Windows.Forms.Label UserNameText;
        private System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.CheckedListBox UserConfigurationMaskCheckBox;
        private System.Windows.Forms.TableLayoutPanel UsersTable;
        private System.Windows.Forms.TableLayoutPanel RolesTable;
        private System.Windows.Forms.ToolStripMenuItem OpenStoreMenuItem;
        private System.Windows.Forms.TreeView ItemTreeView;
        private System.Windows.Forms.Label MonitoredItemCountLabel;
        private System.Windows.Forms.Label MonitoredItemCountTextBox;
        private System.Windows.Forms.GroupBox TreeViewGB;
        private System.Windows.Forms.Button CollapseTreeViewBTN;
        private System.Windows.Forms.Button ExpandTreeViewBTN;
        private System.Windows.Forms.Button UpdateTreeViewBTN;
        private System.Windows.Forms.CheckBox EnableTreeViewCB;
        private System.Windows.Forms.Label TreeViewLBL;
        private System.Windows.Forms.ToolTip ToolTips;
    }
}
