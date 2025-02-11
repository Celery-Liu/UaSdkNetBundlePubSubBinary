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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel1 = new System.Windows.Forms.Panel();
            groupBox4 = new System.Windows.Forms.GroupBox();
            EndpointCB = new System.Windows.Forms.ComboBox();
            groupBox3 = new System.Windows.Forms.GroupBox();
            DiscoveryUrlCB = new System.Windows.Forms.ComboBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            ClientUrlTB = new System.Windows.Forms.TextBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            DiscoveryTypeCB = new System.Windows.Forms.ComboBox();
            ConnectDisconnectBTN = new System.Windows.Forms.Button();
            MenubarMS = new System.Windows.Forms.MenuStrip();
            serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            subscriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            publishingIntervalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            publishingEnabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            authenticationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            userIdentityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            setUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            setAnonymousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            StatusLabelSTS = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            browseControl = new BrowseControl();
            attributeListControl = new AttributeListControl();
            splitContainer2 = new System.Windows.Forms.SplitContainer();
            monitoredItemsControl = new MonitoredItemsControl();
            ToolTip = new System.Windows.Forms.ToolTip(components);
            panel1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            MenubarMS.SuspendLayout();
            StatusLabelSTS.SuspendLayout();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(groupBox4);
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(ConnectDisconnectBTN);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 37);
            panel1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1578, 92);
            panel1.TabIndex = 1;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox4.Controls.Add(EndpointCB);
            groupBox4.Location = new System.Drawing.Point(783, 8);
            groupBox4.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox4.Size = new System.Drawing.Size(658, 79);
            groupBox4.TabIndex = 9;
            groupBox4.TabStop = false;
            groupBox4.Text = "EndPoints";
            // 
            // EndpointCB
            // 
            EndpointCB.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            EndpointCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            EndpointCB.FormattingEnabled = true;
            EndpointCB.Location = new System.Drawing.Point(10, 29);
            EndpointCB.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            EndpointCB.Name = "EndpointCB";
            EndpointCB.Size = new System.Drawing.Size(636, 33);
            EndpointCB.TabIndex = 3;
            ToolTip.SetToolTip(EndpointCB, "Drop down to call FindServers on the DiscoveryUrl. Shows a list of all Endpoints on all servers.");
            EndpointCB.DropDown += DoDiscovery;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(DiscoveryUrlCB);
            groupBox3.Location = new System.Drawing.Point(475, 8);
            groupBox3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox3.Size = new System.Drawing.Size(298, 79);
            groupBox3.TabIndex = 8;
            groupBox3.TabStop = false;
            groupBox3.Text = "Discovery URL";
            // 
            // DiscoveryUrlCB
            // 
            DiscoveryUrlCB.FormattingEnabled = true;
            DiscoveryUrlCB.Location = new System.Drawing.Point(10, 29);
            DiscoveryUrlCB.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            DiscoveryUrlCB.Name = "DiscoveryUrlCB";
            DiscoveryUrlCB.Size = new System.Drawing.Size(272, 33);
            DiscoveryUrlCB.TabIndex = 10;
            ToolTip.SetToolTip(DiscoveryUrlCB, "Drop down to select normal connect or reverse connect");
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ClientUrlTB);
            groupBox2.Location = new System.Drawing.Point(193, 8);
            groupBox2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox2.Size = new System.Drawing.Size(272, 79);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Client Listening URL";
            // 
            // ClientUrlTB
            // 
            ClientUrlTB.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            ClientUrlTB.Enabled = false;
            ClientUrlTB.Location = new System.Drawing.Point(10, 29);
            ClientUrlTB.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            ClientUrlTB.Name = "ClientUrlTB";
            ClientUrlTB.Size = new System.Drawing.Size(247, 31);
            ClientUrlTB.TabIndex = 1;
            ToolTip.SetToolTip(ClientUrlTB, "Url of the client used for reverse connect.");
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(DiscoveryTypeCB);
            groupBox1.Location = new System.Drawing.Point(7, 8);
            groupBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox1.Size = new System.Drawing.Size(177, 79);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Connection Type";
            // 
            // DiscoveryTypeCB
            // 
            DiscoveryTypeCB.FormattingEnabled = true;
            DiscoveryTypeCB.Items.AddRange(new object[] { "Forward", "Reverse" });
            DiscoveryTypeCB.Location = new System.Drawing.Point(13, 27);
            DiscoveryTypeCB.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            DiscoveryTypeCB.Name = "DiscoveryTypeCB";
            DiscoveryTypeCB.Size = new System.Drawing.Size(151, 33);
            DiscoveryTypeCB.TabIndex = 0;
            ToolTip.SetToolTip(DiscoveryTypeCB, "Drop down to select normal connect or reverse connect");
            DiscoveryTypeCB.SelectedIndexChanged += DiscoveryTypeCB_SelectedIndexChanged;
            // 
            // ConnectDisconnectBTN
            // 
            ConnectDisconnectBTN.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            ConnectDisconnectBTN.Location = new System.Drawing.Point(1452, 17);
            ConnectDisconnectBTN.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            ConnectDisconnectBTN.Name = "ConnectDisconnectBTN";
            ConnectDisconnectBTN.Size = new System.Drawing.Size(123, 69);
            ConnectDisconnectBTN.TabIndex = 4;
            ConnectDisconnectBTN.Text = "Connect";
            ToolTip.SetToolTip(ConnectDisconnectBTN, "Connect or Disconnect");
            ConnectDisconnectBTN.UseVisualStyleBackColor = true;
            ConnectDisconnectBTN.Click += connectDisconnectTriggered;
            // 
            // MenubarMS
            // 
            MenubarMS.ImageScalingSize = new System.Drawing.Size(24, 24);
            MenubarMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { serverToolStripMenuItem, subscriptionToolStripMenuItem, authenticationToolStripMenuItem });
            MenubarMS.Location = new System.Drawing.Point(0, 0);
            MenubarMS.Name = "MenubarMS";
            MenubarMS.Padding = new System.Windows.Forms.Padding(10, 4, 0, 4);
            MenubarMS.Size = new System.Drawing.Size(1578, 37);
            MenubarMS.TabIndex = 0;
            MenubarMS.Text = "MenuBar";
            // 
            // serverToolStripMenuItem
            // 
            serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { connectToolStripMenuItem, disconnectToolStripMenuItem });
            serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            serverToolStripMenuItem.Size = new System.Drawing.Size(77, 29);
            serverToolStripMenuItem.Text = "Server";
            // 
            // connectToolStripMenuItem
            // 
            connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            connectToolStripMenuItem.Size = new System.Drawing.Size(201, 34);
            connectToolStripMenuItem.Text = "Connect";
            connectToolStripMenuItem.Click += connectDisconnectTriggered;
            // 
            // disconnectToolStripMenuItem
            // 
            disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            disconnectToolStripMenuItem.Size = new System.Drawing.Size(201, 34);
            disconnectToolStripMenuItem.Text = "Disconnect";
            disconnectToolStripMenuItem.Click += connectDisconnectTriggered;
            // 
            // subscriptionToolStripMenuItem
            // 
            subscriptionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { publishingIntervalToolStripMenuItem, publishingEnabledToolStripMenuItem });
            subscriptionToolStripMenuItem.Name = "subscriptionToolStripMenuItem";
            subscriptionToolStripMenuItem.Size = new System.Drawing.Size(127, 29);
            subscriptionToolStripMenuItem.Text = "Subscription";
            // 
            // publishingIntervalToolStripMenuItem
            // 
            publishingIntervalToolStripMenuItem.Name = "publishingIntervalToolStripMenuItem";
            publishingIntervalToolStripMenuItem.Size = new System.Drawing.Size(264, 34);
            publishingIntervalToolStripMenuItem.Text = "Publishing Interval";
            publishingIntervalToolStripMenuItem.Click += PublishingInterval_Click;
            // 
            // publishingEnabledToolStripMenuItem
            // 
            publishingEnabledToolStripMenuItem.Checked = true;
            publishingEnabledToolStripMenuItem.CheckOnClick = true;
            publishingEnabledToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            publishingEnabledToolStripMenuItem.Name = "publishingEnabledToolStripMenuItem";
            publishingEnabledToolStripMenuItem.Size = new System.Drawing.Size(264, 34);
            publishingEnabledToolStripMenuItem.Text = "Publishing Enabled";
            publishingEnabledToolStripMenuItem.Click += publishingEnabled_Click;
            // 
            // authenticationToolStripMenuItem
            // 
            authenticationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { userIdentityToolStripMenuItem });
            authenticationToolStripMenuItem.Name = "authenticationToolStripMenuItem";
            authenticationToolStripMenuItem.Size = new System.Drawing.Size(143, 29);
            authenticationToolStripMenuItem.Text = "Authentication";
            // 
            // userIdentityToolStripMenuItem
            // 
            userIdentityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { setUserToolStripMenuItem, setAnonymousToolStripMenuItem });
            userIdentityToolStripMenuItem.Name = "userIdentityToolStripMenuItem";
            userIdentityToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            userIdentityToolStripMenuItem.Text = "User Identity";
            // 
            // setUserToolStripMenuItem
            // 
            setUserToolStripMenuItem.Name = "setUserToolStripMenuItem";
            setUserToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            setUserToolStripMenuItem.Text = "Set User";
            setUserToolStripMenuItem.Click += setUserToolStripMenuItem_Click;
            // 
            // setAnonymousToolStripMenuItem
            // 
            setAnonymousToolStripMenuItem.Name = "setAnonymousToolStripMenuItem";
            setAnonymousToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            setAnonymousToolStripMenuItem.Text = "Set Anonymous";
            setAnonymousToolStripMenuItem.Click += setAnonymousToolStripMenuItem_Click;
            // 
            // StatusLabelSTS
            // 
            StatusLabelSTS.ImageScalingSize = new System.Drawing.Size(24, 24);
            StatusLabelSTS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel });
            StatusLabelSTS.Location = new System.Drawing.Point(0, 912);
            StatusLabelSTS.Name = "StatusLabelSTS";
            StatusLabelSTS.Padding = new System.Windows.Forms.Padding(2, 0, 23, 0);
            StatusLabelSTS.ShowItemToolTips = true;
            StatusLabelSTS.Size = new System.Drawing.Size(1578, 32);
            StatusLabelSTS.TabIndex = 2;
            StatusLabelSTS.Text = "StatusLabelSTS";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Image = Properties.Resources.success;
            toolStripStatusLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            toolStripStatusLabel.Size = new System.Drawing.Size(1553, 25);
            toolStripStatusLabel.Spring = true;
            toolStripStatusLabel.Text = "enter URL and click connect";
            toolStripStatusLabel.ToolTipText = "status information";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(browseControl);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(attributeListControl);
            splitContainer1.Size = new System.Drawing.Size(1578, 382);
            splitContainer1.SplitterDistance = 603;
            splitContainer1.SplitterWidth = 7;
            splitContainer1.TabIndex = 5;
            // 
            // browseControl
            // 
            browseControl.AutoSize = true;
            browseControl.Dock = System.Windows.Forms.DockStyle.Fill;
            browseControl.Location = new System.Drawing.Point(0, 0);
            browseControl.Margin = new System.Windows.Forms.Padding(8, 12, 8, 12);
            browseControl.Name = "browseControl";
            browseControl.RebrowseOnNodeExpande = false;
            browseControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            browseControl.Session = null;
            browseControl.Size = new System.Drawing.Size(603, 382);
            browseControl.TabIndex = 0;
            // 
            // attributeListControl
            // 
            attributeListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            attributeListControl.Location = new System.Drawing.Point(0, 0);
            attributeListControl.Margin = new System.Windows.Forms.Padding(8, 12, 8, 12);
            attributeListControl.Name = "attributeListControl";
            attributeListControl.Session = null;
            attributeListControl.Size = new System.Drawing.Size(968, 382);
            attributeListControl.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer2.Location = new System.Drawing.Point(0, 129);
            splitContainer2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(monitoredItemsControl);
            splitContainer2.Size = new System.Drawing.Size(1578, 783);
            splitContainer2.SplitterDistance = 382;
            splitContainer2.SplitterWidth = 8;
            splitContainer2.TabIndex = 6;
            // 
            // monitoredItemsControl
            // 
            monitoredItemsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            monitoredItemsControl.Location = new System.Drawing.Point(0, 0);
            monitoredItemsControl.Margin = new System.Windows.Forms.Padding(8, 12, 8, 12);
            monitoredItemsControl.Name = "monitoredItemsControl";
            monitoredItemsControl.PublishingEnabled = true;
            monitoredItemsControl.PublishingInterval = 500D;
            monitoredItemsControl.Session = null;
            monitoredItemsControl.Size = new System.Drawing.Size(1578, 393);
            monitoredItemsControl.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ClientSize = new System.Drawing.Size(1578, 944);
            Controls.Add(splitContainer2);
            Controls.Add(StatusLabelSTS);
            Controls.Add(panel1);
            Controls.Add(MenubarMS);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = MenubarMS;
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            Name = "MainForm";
            Text = "Unified Automation Sample Client Full";
            panel1.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            MenubarMS.ResumeLayout(false);
            MenubarMS.PerformLayout();
            StatusLabelSTS.ResumeLayout(false);
            StatusLabelSTS.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip MenubarMS;
        private System.Windows.Forms.StatusStrip StatusLabelSTS;
        private BrowseControl browseControl;
        private AttributeListControl attributeListControl;
        private MonitoredItemsControl monitoredItemsControl;
        private System.Windows.Forms.ComboBox EndpointCB;
        private System.Windows.Forms.Button ConnectDisconnectBTN;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subscriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.TextBox ClientUrlTB;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem publishingIntervalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem publishingEnabledToolStripMenuItem;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.ComboBox DiscoveryTypeCB;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox DiscoveryUrlCB;
        private System.Windows.Forms.ToolStripMenuItem authenticationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userIdentityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAnonymousToolStripMenuItem;
    }
}
