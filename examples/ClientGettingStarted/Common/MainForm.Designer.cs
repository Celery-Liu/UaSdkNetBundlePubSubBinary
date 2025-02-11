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
            System.Windows.Forms.ColumnHeader EventTypeCH;
            System.Windows.Forms.ColumnHeader SourceCH;
            System.Windows.Forms.ColumnHeader TimeCH;
            System.Windows.Forms.ColumnHeader SeverityCH;
            System.Windows.Forms.ColumnHeader MessageCH;
            this.MainBrowser = new System.Windows.Forms.WebBrowser();
            this.LeftPN = new System.Windows.Forms.SplitContainer();
            this.MonitoredItemsPN = new System.Windows.Forms.SplitContainer();
            this.CurrentMonitoredItemsGB = new System.Windows.Forms.GroupBox();
            this.MonitoredItemsLV = new System.Windows.Forms.ListView();
            this.ClientHandleCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NodeCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AttributeCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimestampCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DataTypeCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DataValueCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EventsGB = new System.Windows.Forms.GroupBox();
            this.EventsLV = new System.Windows.Forms.ListView();
            this.NotificationMessagesGB = new System.Windows.Forms.GroupBox();
            this.LogCTRL = new System.Windows.Forms.RichTextBox();
            this.RightPN = new System.Windows.Forms.Panel();
            this.ConditionsGB = new System.Windows.Forms.GroupBox();
            this.MonitoredConditionsBTN = new System.Windows.Forms.Button();
            this.MonitoredItemsGB = new System.Windows.Forms.GroupBox();
            this.SetMonitoringModeBTN = new System.Windows.Forms.Button();
            this.DeleteMonitoredItemsBTN = new System.Windows.Forms.Button();
            this.EventMonitoredItemsGB = new System.Windows.Forms.GroupBox();
            this.ModifyEventMonitoredItemsBTN = new System.Windows.Forms.Button();
            this.CreateEventMonitoredItemsBTN = new System.Windows.Forms.Button();
            this.DataMonitoredItemsGB = new System.Windows.Forms.GroupBox();
            this.ModifyDataMonitoredItemsBTN = new System.Windows.Forms.Button();
            this.CreateDataMonitoredItemsBTN = new System.Windows.Forms.Button();
            this.ManageSubscriptionGB = new System.Windows.Forms.GroupBox();
            this.DeleteSubscriptionBTN = new System.Windows.Forms.Button();
            this.ModifySubscriptionBTN = new System.Windows.Forms.Button();
            this.CreateSubscriptionBTN = new System.Windows.Forms.Button();
            this.ConnectOptionsControl = new UnifiedAutomation.ClientGettingStarted.Common.ConnectOptionsControl();
            this.SubscriptionOptionsControl = new UnifiedAutomation.ClientGettingStarted.Common.SubscriptionOptionsControl();
            this.SessionOptionsControl = new UnifiedAutomation.ClientGettingStarted.Common.SessionOptionsControl();
            this.SelectEndpointControl = new UnifiedAutomation.UaClient.Controls.SelectEndpointCtrl();
            EventTypeCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            SourceCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            TimeCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            SeverityCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            MessageCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LeftPN.Panel1.SuspendLayout();
            this.LeftPN.Panel2.SuspendLayout();
            this.LeftPN.SuspendLayout();
            this.MonitoredItemsPN.Panel1.SuspendLayout();
            this.MonitoredItemsPN.Panel2.SuspendLayout();
            this.MonitoredItemsPN.SuspendLayout();
            this.CurrentMonitoredItemsGB.SuspendLayout();
            this.EventsGB.SuspendLayout();
            this.NotificationMessagesGB.SuspendLayout();
            this.RightPN.SuspendLayout();
            this.ConditionsGB.SuspendLayout();
            this.MonitoredItemsGB.SuspendLayout();
            this.EventMonitoredItemsGB.SuspendLayout();
            this.DataMonitoredItemsGB.SuspendLayout();
            this.ManageSubscriptionGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // EventTypeCH
            // 
            EventTypeCH.Text = "Event Type";
            EventTypeCH.Width = 150;
            // 
            // SourceCH
            // 
            SourceCH.Text = "Source";
            // 
            // TimeCH
            // 
            TimeCH.Text = "Time";
            // 
            // SeverityCH
            // 
            SeverityCH.Text = "Severity";
            // 
            // MessageCH
            // 
            MessageCH.Text = "Message";
            // 
            // MainBrowser
            // 
            this.MainBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainBrowser.Location = new System.Drawing.Point(0, 0);
            this.MainBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.MainBrowser.Name = "MainBrowser";
            this.MainBrowser.ScrollBarsEnabled = false;
            this.MainBrowser.Size = new System.Drawing.Size(784, 595);
            this.MainBrowser.TabIndex = 0;
            this.MainBrowser.Url = new System.Uri("", System.UriKind.Relative);
            this.MainBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.MainBrowser_Navigating);
            // 
            // LeftPN
            // 
            this.LeftPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftPN.Location = new System.Drawing.Point(172, 3);
            this.LeftPN.Name = "LeftPN";
            this.LeftPN.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // LeftPN.Panel1
            // 
            this.LeftPN.Panel1.Controls.Add(this.MonitoredItemsPN);
            // 
            // LeftPN.Panel2
            // 
            this.LeftPN.Panel2.Controls.Add(this.NotificationMessagesGB);
            this.LeftPN.Size = new System.Drawing.Size(601, 508);
            this.LeftPN.SplitterDistance = 361;
            this.LeftPN.TabIndex = 4;
            // 
            // MonitoredItemsPN
            // 
            this.MonitoredItemsPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MonitoredItemsPN.Location = new System.Drawing.Point(0, 0);
            this.MonitoredItemsPN.Name = "MonitoredItemsPN";
            this.MonitoredItemsPN.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MonitoredItemsPN.Panel1
            // 
            this.MonitoredItemsPN.Panel1.Controls.Add(this.CurrentMonitoredItemsGB);
            // 
            // MonitoredItemsPN.Panel2
            // 
            this.MonitoredItemsPN.Panel2.Controls.Add(this.EventsGB);
            this.MonitoredItemsPN.Size = new System.Drawing.Size(601, 361);
            this.MonitoredItemsPN.SplitterDistance = 180;
            this.MonitoredItemsPN.TabIndex = 4;
            // 
            // CurrentMonitoredItemsGB
            // 
            this.CurrentMonitoredItemsGB.Controls.Add(this.MonitoredItemsLV);
            this.CurrentMonitoredItemsGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentMonitoredItemsGB.Location = new System.Drawing.Point(0, 0);
            this.CurrentMonitoredItemsGB.Name = "CurrentMonitoredItemsGB";
            this.CurrentMonitoredItemsGB.Size = new System.Drawing.Size(601, 180);
            this.CurrentMonitoredItemsGB.TabIndex = 3;
            this.CurrentMonitoredItemsGB.TabStop = false;
            this.CurrentMonitoredItemsGB.Text = "Current Monitored Items";
            // 
            // MonitoredItemsLV
            // 
            this.MonitoredItemsLV.AllowDrop = true;
            this.MonitoredItemsLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClientHandleCH,
            this.NodeCH,
            this.AttributeCH,
            this.TimestampCH,
            this.DataTypeCH,
            this.DataValueCH});
            this.MonitoredItemsLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MonitoredItemsLV.FullRowSelect = true;
            this.MonitoredItemsLV.HideSelection = false;
            this.MonitoredItemsLV.Location = new System.Drawing.Point(3, 16);
            this.MonitoredItemsLV.Name = "MonitoredItemsLV";
            this.MonitoredItemsLV.Size = new System.Drawing.Size(595, 161);
            this.MonitoredItemsLV.TabIndex = 2;
            this.MonitoredItemsLV.UseCompatibleStateImageBehavior = false;
            this.MonitoredItemsLV.View = System.Windows.Forms.View.Details;
            // 
            // ClientHandleCH
            // 
            this.ClientHandleCH.Text = "";
            this.ClientHandleCH.Width = 11;
            // 
            // NodeCH
            // 
            this.NodeCH.Text = "Node";
            // 
            // AttributeCH
            // 
            this.AttributeCH.Text = "Attribute";
            // 
            // TimestampCH
            // 
            this.TimestampCH.Text = "Timestamp";
            this.TimestampCH.Width = 88;
            // 
            // DataTypeCH
            // 
            this.DataTypeCH.Text = "Data Type";
            this.DataTypeCH.Width = 109;
            // 
            // DataValueCH
            // 
            this.DataValueCH.Text = "Value";
            this.DataValueCH.Width = 117;
            // 
            // EventsGB
            // 
            this.EventsGB.Controls.Add(this.EventsLV);
            this.EventsGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventsGB.Location = new System.Drawing.Point(0, 0);
            this.EventsGB.Name = "EventsGB";
            this.EventsGB.Size = new System.Drawing.Size(601, 177);
            this.EventsGB.TabIndex = 4;
            this.EventsGB.TabStop = false;
            this.EventsGB.Text = "Events";
            // 
            // EventsLV
            // 
            this.EventsLV.AllowDrop = true;
            this.EventsLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            EventTypeCH,
            SourceCH,
            TimeCH,
            SeverityCH,
            MessageCH});
            this.EventsLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventsLV.FullRowSelect = true;
            this.EventsLV.HideSelection = false;
            this.EventsLV.Location = new System.Drawing.Point(3, 16);
            this.EventsLV.Name = "EventsLV";
            this.EventsLV.Size = new System.Drawing.Size(595, 158);
            this.EventsLV.TabIndex = 3;
            this.EventsLV.UseCompatibleStateImageBehavior = false;
            this.EventsLV.View = System.Windows.Forms.View.Details;
            // 
            // NotificationMessagesGB
            // 
            this.NotificationMessagesGB.Controls.Add(this.LogCTRL);
            this.NotificationMessagesGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotificationMessagesGB.Location = new System.Drawing.Point(0, 0);
            this.NotificationMessagesGB.Name = "NotificationMessagesGB";
            this.NotificationMessagesGB.Size = new System.Drawing.Size(601, 143);
            this.NotificationMessagesGB.TabIndex = 2;
            this.NotificationMessagesGB.TabStop = false;
            this.NotificationMessagesGB.Text = "Notification Messages";
            // 
            // LogCTRL
            // 
            this.LogCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogCTRL.Location = new System.Drawing.Point(3, 16);
            this.LogCTRL.Name = "LogCTRL";
            this.LogCTRL.Size = new System.Drawing.Size(595, 124);
            this.LogCTRL.TabIndex = 1;
            this.LogCTRL.Text = "";
            // 
            // RightPN
            // 
            this.RightPN.Controls.Add(this.ConditionsGB);
            this.RightPN.Controls.Add(this.MonitoredItemsGB);
            this.RightPN.Controls.Add(this.EventMonitoredItemsGB);
            this.RightPN.Controls.Add(this.DataMonitoredItemsGB);
            this.RightPN.Controls.Add(this.ManageSubscriptionGB);
            this.RightPN.Dock = System.Windows.Forms.DockStyle.Left;
            this.RightPN.Location = new System.Drawing.Point(3, 3);
            this.RightPN.Name = "RightPN";
            this.RightPN.Size = new System.Drawing.Size(169, 508);
            this.RightPN.TabIndex = 2;
            // 
            // ConditionsGB
            // 
            this.ConditionsGB.Controls.Add(this.MonitoredConditionsBTN);
            this.ConditionsGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConditionsGB.Location = new System.Drawing.Point(0, 304);
            this.ConditionsGB.Name = "ConditionsGB";
            this.ConditionsGB.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.ConditionsGB.Size = new System.Drawing.Size(169, 48);
            this.ConditionsGB.TabIndex = 17;
            this.ConditionsGB.TabStop = false;
            this.ConditionsGB.Text = "Conditions";
            // 
            // MonitoredConditionsBTN
            // 
            this.MonitoredConditionsBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.MonitoredConditionsBTN.Enabled = false;
            this.MonitoredConditionsBTN.Location = new System.Drawing.Point(6, 16);
            this.MonitoredConditionsBTN.Name = "MonitoredConditionsBTN";
            this.MonitoredConditionsBTN.Size = new System.Drawing.Size(157, 23);
            this.MonitoredConditionsBTN.TabIndex = 13;
            this.MonitoredConditionsBTN.Text = "Monitor Conditions";
            this.MonitoredConditionsBTN.UseVisualStyleBackColor = true;
            // 
            // MonitoredItemsGB
            // 
            this.MonitoredItemsGB.Controls.Add(this.SetMonitoringModeBTN);
            this.MonitoredItemsGB.Controls.Add(this.DeleteMonitoredItemsBTN);
            this.MonitoredItemsGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.MonitoredItemsGB.Location = new System.Drawing.Point(0, 234);
            this.MonitoredItemsGB.Name = "MonitoredItemsGB";
            this.MonitoredItemsGB.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.MonitoredItemsGB.Size = new System.Drawing.Size(169, 70);
            this.MonitoredItemsGB.TabIndex = 16;
            this.MonitoredItemsGB.TabStop = false;
            this.MonitoredItemsGB.Text = "Monitored Items";
            // 
            // SetMonitoringModeBTN
            // 
            this.SetMonitoringModeBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.SetMonitoringModeBTN.Enabled = false;
            this.SetMonitoringModeBTN.Location = new System.Drawing.Point(6, 39);
            this.SetMonitoringModeBTN.Name = "SetMonitoringModeBTN";
            this.SetMonitoringModeBTN.Size = new System.Drawing.Size(157, 23);
            this.SetMonitoringModeBTN.TabIndex = 11;
            this.SetMonitoringModeBTN.Text = "Set Monitoring Mode";
            this.SetMonitoringModeBTN.UseVisualStyleBackColor = true;
            // 
            // DeleteMonitoredItemsBTN
            // 
            this.DeleteMonitoredItemsBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.DeleteMonitoredItemsBTN.Enabled = false;
            this.DeleteMonitoredItemsBTN.Location = new System.Drawing.Point(6, 16);
            this.DeleteMonitoredItemsBTN.Name = "DeleteMonitoredItemsBTN";
            this.DeleteMonitoredItemsBTN.Size = new System.Drawing.Size(157, 23);
            this.DeleteMonitoredItemsBTN.TabIndex = 10;
            this.DeleteMonitoredItemsBTN.Text = "Delete Monitored Items";
            this.DeleteMonitoredItemsBTN.UseVisualStyleBackColor = true;
            // 
            // EventMonitoredItemsGB
            // 
            this.EventMonitoredItemsGB.Controls.Add(this.ModifyEventMonitoredItemsBTN);
            this.EventMonitoredItemsGB.Controls.Add(this.CreateEventMonitoredItemsBTN);
            this.EventMonitoredItemsGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.EventMonitoredItemsGB.Location = new System.Drawing.Point(0, 164);
            this.EventMonitoredItemsGB.Name = "EventMonitoredItemsGB";
            this.EventMonitoredItemsGB.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.EventMonitoredItemsGB.Size = new System.Drawing.Size(169, 70);
            this.EventMonitoredItemsGB.TabIndex = 15;
            this.EventMonitoredItemsGB.TabStop = false;
            this.EventMonitoredItemsGB.Text = "Event Monitored Items";
            // 
            // ModifyEventMonitoredItemsBTN
            // 
            this.ModifyEventMonitoredItemsBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.ModifyEventMonitoredItemsBTN.Enabled = false;
            this.ModifyEventMonitoredItemsBTN.Location = new System.Drawing.Point(6, 39);
            this.ModifyEventMonitoredItemsBTN.Name = "ModifyEventMonitoredItemsBTN";
            this.ModifyEventMonitoredItemsBTN.Size = new System.Drawing.Size(157, 23);
            this.ModifyEventMonitoredItemsBTN.TabIndex = 13;
            this.ModifyEventMonitoredItemsBTN.Text = "Modify Event Monitored Items";
            this.ModifyEventMonitoredItemsBTN.UseVisualStyleBackColor = true;
            // 
            // CreateEventMonitoredItemsBTN
            // 
            this.CreateEventMonitoredItemsBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreateEventMonitoredItemsBTN.Enabled = false;
            this.CreateEventMonitoredItemsBTN.Location = new System.Drawing.Point(6, 16);
            this.CreateEventMonitoredItemsBTN.Name = "CreateEventMonitoredItemsBTN";
            this.CreateEventMonitoredItemsBTN.Size = new System.Drawing.Size(157, 23);
            this.CreateEventMonitoredItemsBTN.TabIndex = 12;
            this.CreateEventMonitoredItemsBTN.Text = "Create Event Monitored Items";
            this.CreateEventMonitoredItemsBTN.UseVisualStyleBackColor = true;
            // 
            // DataMonitoredItemsGB
            // 
            this.DataMonitoredItemsGB.Controls.Add(this.ModifyDataMonitoredItemsBTN);
            this.DataMonitoredItemsGB.Controls.Add(this.CreateDataMonitoredItemsBTN);
            this.DataMonitoredItemsGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.DataMonitoredItemsGB.Location = new System.Drawing.Point(0, 94);
            this.DataMonitoredItemsGB.Name = "DataMonitoredItemsGB";
            this.DataMonitoredItemsGB.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.DataMonitoredItemsGB.Size = new System.Drawing.Size(169, 70);
            this.DataMonitoredItemsGB.TabIndex = 14;
            this.DataMonitoredItemsGB.TabStop = false;
            this.DataMonitoredItemsGB.Text = "Data Monitored Items";
            // 
            // ModifyDataMonitoredItemsBTN
            // 
            this.ModifyDataMonitoredItemsBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.ModifyDataMonitoredItemsBTN.Enabled = false;
            this.ModifyDataMonitoredItemsBTN.Location = new System.Drawing.Point(6, 39);
            this.ModifyDataMonitoredItemsBTN.Name = "ModifyDataMonitoredItemsBTN";
            this.ModifyDataMonitoredItemsBTN.Size = new System.Drawing.Size(157, 23);
            this.ModifyDataMonitoredItemsBTN.TabIndex = 9;
            this.ModifyDataMonitoredItemsBTN.Text = "Modify Data Monitored Items";
            this.ModifyDataMonitoredItemsBTN.UseVisualStyleBackColor = true;
            // 
            // CreateDataMonitoredItemsBTN
            // 
            this.CreateDataMonitoredItemsBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreateDataMonitoredItemsBTN.Enabled = false;
            this.CreateDataMonitoredItemsBTN.Location = new System.Drawing.Point(6, 16);
            this.CreateDataMonitoredItemsBTN.Name = "CreateDataMonitoredItemsBTN";
            this.CreateDataMonitoredItemsBTN.Size = new System.Drawing.Size(157, 23);
            this.CreateDataMonitoredItemsBTN.TabIndex = 8;
            this.CreateDataMonitoredItemsBTN.Text = "Create Data Monitored Items";
            this.CreateDataMonitoredItemsBTN.UseVisualStyleBackColor = true;
            // 
            // ManageSubscriptionGB
            // 
            this.ManageSubscriptionGB.Controls.Add(this.DeleteSubscriptionBTN);
            this.ManageSubscriptionGB.Controls.Add(this.ModifySubscriptionBTN);
            this.ManageSubscriptionGB.Controls.Add(this.CreateSubscriptionBTN);
            this.ManageSubscriptionGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.ManageSubscriptionGB.Location = new System.Drawing.Point(0, 0);
            this.ManageSubscriptionGB.Name = "ManageSubscriptionGB";
            this.ManageSubscriptionGB.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.ManageSubscriptionGB.Size = new System.Drawing.Size(169, 94);
            this.ManageSubscriptionGB.TabIndex = 13;
            this.ManageSubscriptionGB.TabStop = false;
            this.ManageSubscriptionGB.Text = "Manage Subscription";
            // 
            // DeleteSubscriptionBTN
            // 
            this.DeleteSubscriptionBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.DeleteSubscriptionBTN.Enabled = false;
            this.DeleteSubscriptionBTN.Location = new System.Drawing.Point(6, 62);
            this.DeleteSubscriptionBTN.Name = "DeleteSubscriptionBTN";
            this.DeleteSubscriptionBTN.Size = new System.Drawing.Size(157, 23);
            this.DeleteSubscriptionBTN.TabIndex = 7;
            this.DeleteSubscriptionBTN.Text = "Delete Subscription";
            this.DeleteSubscriptionBTN.UseVisualStyleBackColor = true;
            // 
            // ModifySubscriptionBTN
            // 
            this.ModifySubscriptionBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.ModifySubscriptionBTN.Enabled = false;
            this.ModifySubscriptionBTN.Location = new System.Drawing.Point(6, 39);
            this.ModifySubscriptionBTN.Name = "ModifySubscriptionBTN";
            this.ModifySubscriptionBTN.Size = new System.Drawing.Size(157, 23);
            this.ModifySubscriptionBTN.TabIndex = 6;
            this.ModifySubscriptionBTN.Text = "Modify Subscription";
            this.ModifySubscriptionBTN.UseVisualStyleBackColor = true;
            // 
            // CreateSubscriptionBTN
            // 
            this.CreateSubscriptionBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreateSubscriptionBTN.Location = new System.Drawing.Point(6, 16);
            this.CreateSubscriptionBTN.Name = "CreateSubscriptionBTN";
            this.CreateSubscriptionBTN.Size = new System.Drawing.Size(157, 23);
            this.CreateSubscriptionBTN.TabIndex = 5;
            this.CreateSubscriptionBTN.Text = "Create Subscription";
            this.CreateSubscriptionBTN.UseVisualStyleBackColor = true;
            // 
            // ConnectOptionsControl
            // 
            this.ConnectOptionsControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectOptionsControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(201)))));
            this.ConnectOptionsControl.Location = new System.Drawing.Point(0, 108);
            this.ConnectOptionsControl.Name = "ConnectOptionsControl";
            this.ConnectOptionsControl.Size = new System.Drawing.Size(784, 487);
            this.ConnectOptionsControl.TabIndex = 2;
            this.ConnectOptionsControl.Visible = false;
            // 
            // SubscriptionOptionsControl
            // 
            this.SubscriptionOptionsControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SubscriptionOptionsControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(201)))));
            this.SubscriptionOptionsControl.Location = new System.Drawing.Point(0, 108);
            this.SubscriptionOptionsControl.Name = "SubscriptionOptionsControl";
            this.SubscriptionOptionsControl.Size = new System.Drawing.Size(784, 487);
            this.SubscriptionOptionsControl.TabIndex = 4;
            this.SubscriptionOptionsControl.Visible = false;
            // 
            // SessionOptionsControl
            // 
            this.SessionOptionsControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SessionOptionsControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(201)))));
            this.SessionOptionsControl.Location = new System.Drawing.Point(0, 108);
            this.SessionOptionsControl.Name = "SessionOptionsControl";
            this.SessionOptionsControl.Size = new System.Drawing.Size(784, 487);
            this.SessionOptionsControl.TabIndex = 3;
            this.SessionOptionsControl.Visible = false;
            // 
            // SelectEndpointControl
            // 
            this.SelectEndpointControl.Application = null;
            this.SelectEndpointControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SelectEndpointControl.ConnectOnChange = true;
            this.SelectEndpointControl.Location = new System.Drawing.Point(0, 108);
            this.SelectEndpointControl.Name = "SelectEndpointControl";
            this.SelectEndpointControl.Padding = new System.Windows.Forms.Padding(3);
            this.SelectEndpointControl.PreferredLocales = null;
            this.SelectEndpointControl.SelectedEndpointIndex = -1;
            this.SelectEndpointControl.Size = new System.Drawing.Size(784, 32);
            this.SelectEndpointControl.TabIndex = 1;
            this.SelectEndpointControl.Visible = false;
            this.SelectEndpointControl.ConnectServer += new UnifiedAutomation.UaClient.Controls.ConnectServerEventHandler(this.SelectEndpointControl_ConnectServer);
            this.SelectEndpointControl.DisconnectServer += new System.EventHandler(this.SelectEndpointControl_DisconnectServer);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(784, 595);
            this.Controls.Add(this.ConnectOptionsControl);
            this.Controls.Add(this.SubscriptionOptionsControl);
            this.Controls.Add(this.SessionOptionsControl);
            this.Controls.Add(this.SelectEndpointControl);
            this.Controls.Add(this.MainBrowser);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Getting Started Client Example";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.LeftPN.Panel1.ResumeLayout(false);
            this.LeftPN.Panel2.ResumeLayout(false);
            this.LeftPN.ResumeLayout(false);
            this.MonitoredItemsPN.Panel1.ResumeLayout(false);
            this.MonitoredItemsPN.Panel2.ResumeLayout(false);
            this.MonitoredItemsPN.ResumeLayout(false);
            this.CurrentMonitoredItemsGB.ResumeLayout(false);
            this.EventsGB.ResumeLayout(false);
            this.NotificationMessagesGB.ResumeLayout(false);
            this.RightPN.ResumeLayout(false);
            this.ConditionsGB.ResumeLayout(false);
            this.MonitoredItemsGB.ResumeLayout(false);
            this.EventMonitoredItemsGB.ResumeLayout(false);
            this.DataMonitoredItemsGB.ResumeLayout(false);
            this.ManageSubscriptionGB.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser MainBrowser;
        private UnifiedAutomation.UaClient.Controls.SelectEndpointCtrl SelectEndpointControl;
        private System.Windows.Forms.SplitContainer LeftPN;
        private System.Windows.Forms.SplitContainer MonitoredItemsPN;
        private System.Windows.Forms.GroupBox CurrentMonitoredItemsGB;
        private System.Windows.Forms.ListView MonitoredItemsLV;
        private System.Windows.Forms.ColumnHeader ClientHandleCH;
        private System.Windows.Forms.ColumnHeader NodeCH;
        private System.Windows.Forms.ColumnHeader AttributeCH;
        private System.Windows.Forms.ColumnHeader TimestampCH;
        private System.Windows.Forms.ColumnHeader DataTypeCH;
        private System.Windows.Forms.ColumnHeader DataValueCH;
        private System.Windows.Forms.GroupBox EventsGB;
        private System.Windows.Forms.ListView EventsLV;
        private System.Windows.Forms.GroupBox NotificationMessagesGB;
        private System.Windows.Forms.RichTextBox LogCTRL;
        private System.Windows.Forms.Panel RightPN;
        private System.Windows.Forms.GroupBox ConditionsGB;
        private System.Windows.Forms.Button MonitoredConditionsBTN;
        private System.Windows.Forms.GroupBox MonitoredItemsGB;
        private System.Windows.Forms.Button SetMonitoringModeBTN;
        private System.Windows.Forms.Button DeleteMonitoredItemsBTN;
        private System.Windows.Forms.GroupBox EventMonitoredItemsGB;
        private System.Windows.Forms.Button ModifyEventMonitoredItemsBTN;
        private System.Windows.Forms.Button CreateEventMonitoredItemsBTN;
        private System.Windows.Forms.GroupBox DataMonitoredItemsGB;
        private System.Windows.Forms.Button ModifyDataMonitoredItemsBTN;
        private System.Windows.Forms.Button CreateDataMonitoredItemsBTN;
        private System.Windows.Forms.GroupBox ManageSubscriptionGB;
        private System.Windows.Forms.Button DeleteSubscriptionBTN;
        private System.Windows.Forms.Button ModifySubscriptionBTN;
        private System.Windows.Forms.Button CreateSubscriptionBTN;
        private UnifiedAutomation.ClientGettingStarted.Common.ConnectOptionsControl ConnectOptionsControl;
        private UnifiedAutomation.ClientGettingStarted.Common.SessionOptionsControl SessionOptionsControl;
        private UnifiedAutomation.ClientGettingStarted.Common.SubscriptionOptionsControl SubscriptionOptionsControl;
    }
}
