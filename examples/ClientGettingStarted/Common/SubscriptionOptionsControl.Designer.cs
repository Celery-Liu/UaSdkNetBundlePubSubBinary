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

namespace UnifiedAutomation.ClientGettingStarted.Common
{
    partial class SubscriptionOptionsControl
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

        #region Component Designer generated code

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
            this.RightPN = new System.Windows.Forms.Panel();
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
            this.WarningLB = new System.Windows.Forms.Label();
            this.LogCTRL = new System.Windows.Forms.RichTextBox();
            this.TopPN = new System.Windows.Forms.Panel();
            this.ConnectCloseBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            EventTypeCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            SourceCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            TimeCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            SeverityCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            MessageCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RightPN.SuspendLayout();
            this.MonitoredItemsGB.SuspendLayout();
            this.EventMonitoredItemsGB.SuspendLayout();
            this.DataMonitoredItemsGB.SuspendLayout();
            this.ManageSubscriptionGB.SuspendLayout();
            this.LeftPN.Panel1.SuspendLayout();
            this.LeftPN.Panel2.SuspendLayout();
            this.LeftPN.SuspendLayout();
            this.MonitoredItemsPN.Panel1.SuspendLayout();
            this.MonitoredItemsPN.Panel2.SuspendLayout();
            this.MonitoredItemsPN.SuspendLayout();
            this.CurrentMonitoredItemsGB.SuspendLayout();
            this.EventsGB.SuspendLayout();
            this.NotificationMessagesGB.SuspendLayout();
            this.TopPN.SuspendLayout();
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
            // RightPN
            //
            this.RightPN.Controls.Add(this.MonitoredItemsGB);
            this.RightPN.Controls.Add(this.EventMonitoredItemsGB);
            this.RightPN.Controls.Add(this.DataMonitoredItemsGB);
            this.RightPN.Controls.Add(this.ManageSubscriptionGB);
            this.RightPN.Dock = System.Windows.Forms.DockStyle.Left;
            this.RightPN.Location = new System.Drawing.Point(0, 37);
            this.RightPN.Name = "RightPN";
            this.RightPN.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightPN.Size = new System.Drawing.Size(200, 446);
            this.RightPN.TabIndex = 7;
            //
            // MonitoredItemsGB
            //
            this.MonitoredItemsGB.Controls.Add(this.SetMonitoringModeBTN);
            this.MonitoredItemsGB.Controls.Add(this.DeleteMonitoredItemsBTN);
            this.MonitoredItemsGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.MonitoredItemsGB.Location = new System.Drawing.Point(0, 264);
            this.MonitoredItemsGB.Name = "MonitoredItemsGB";
            this.MonitoredItemsGB.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.MonitoredItemsGB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MonitoredItemsGB.Size = new System.Drawing.Size(200, 80);
            this.MonitoredItemsGB.TabIndex = 16;
            this.MonitoredItemsGB.TabStop = false;
            this.MonitoredItemsGB.Text = "Monitored Items";
            //
            // SetMonitoringModeBTN
            //
            this.SetMonitoringModeBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.SetMonitoringModeBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.SetMonitoringModeBTN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(178)))), ((int)(((byte)(75)))));
            this.SetMonitoringModeBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetMonitoringModeBTN.ForeColor = System.Drawing.Color.White;
            this.SetMonitoringModeBTN.Location = new System.Drawing.Point(6, 44);
            this.SetMonitoringModeBTN.Name = "SetMonitoringModeBTN";
            this.SetMonitoringModeBTN.Size = new System.Drawing.Size(188, 28);
            this.SetMonitoringModeBTN.TabIndex = 11;
            this.SetMonitoringModeBTN.Text = "Set Monitoring Mode";
            this.SetMonitoringModeBTN.UseVisualStyleBackColor = false;
            this.SetMonitoringModeBTN.Click += new System.EventHandler(this.MenuButton_Click);
            //
            // DeleteMonitoredItemsBTN
            //
            this.DeleteMonitoredItemsBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.DeleteMonitoredItemsBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.DeleteMonitoredItemsBTN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(178)))), ((int)(((byte)(75)))));
            this.DeleteMonitoredItemsBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteMonitoredItemsBTN.ForeColor = System.Drawing.Color.White;
            this.DeleteMonitoredItemsBTN.Location = new System.Drawing.Point(6, 16);
            this.DeleteMonitoredItemsBTN.Name = "DeleteMonitoredItemsBTN";
            this.DeleteMonitoredItemsBTN.Size = new System.Drawing.Size(188, 28);
            this.DeleteMonitoredItemsBTN.TabIndex = 10;
            this.DeleteMonitoredItemsBTN.Text = "Delete Monitored Items";
            this.DeleteMonitoredItemsBTN.UseVisualStyleBackColor = false;
            this.DeleteMonitoredItemsBTN.Click += new System.EventHandler(this.MenuButton_Click);
            //
            // EventMonitoredItemsGB
            //
            this.EventMonitoredItemsGB.Controls.Add(this.ModifyEventMonitoredItemsBTN);
            this.EventMonitoredItemsGB.Controls.Add(this.CreateEventMonitoredItemsBTN);
            this.EventMonitoredItemsGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.EventMonitoredItemsGB.Location = new System.Drawing.Point(0, 184);
            this.EventMonitoredItemsGB.Name = "EventMonitoredItemsGB";
            this.EventMonitoredItemsGB.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.EventMonitoredItemsGB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EventMonitoredItemsGB.Size = new System.Drawing.Size(200, 80);
            this.EventMonitoredItemsGB.TabIndex = 15;
            this.EventMonitoredItemsGB.TabStop = false;
            this.EventMonitoredItemsGB.Text = "Event Monitored Items";
            //
            // ModifyEventMonitoredItemsBTN
            //
            this.ModifyEventMonitoredItemsBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.ModifyEventMonitoredItemsBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.ModifyEventMonitoredItemsBTN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(178)))), ((int)(((byte)(75)))));
            this.ModifyEventMonitoredItemsBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifyEventMonitoredItemsBTN.ForeColor = System.Drawing.Color.White;
            this.ModifyEventMonitoredItemsBTN.Location = new System.Drawing.Point(6, 44);
            this.ModifyEventMonitoredItemsBTN.Name = "ModifyEventMonitoredItemsBTN";
            this.ModifyEventMonitoredItemsBTN.Size = new System.Drawing.Size(188, 28);
            this.ModifyEventMonitoredItemsBTN.TabIndex = 13;
            this.ModifyEventMonitoredItemsBTN.Text = "Modify Event Monitored Items";
            this.ModifyEventMonitoredItemsBTN.UseVisualStyleBackColor = false;
            this.ModifyEventMonitoredItemsBTN.Click += new System.EventHandler(this.MenuButton_Click);
            //
            // CreateEventMonitoredItemsBTN
            //
            this.CreateEventMonitoredItemsBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.CreateEventMonitoredItemsBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreateEventMonitoredItemsBTN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(178)))), ((int)(((byte)(75)))));
            this.CreateEventMonitoredItemsBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateEventMonitoredItemsBTN.ForeColor = System.Drawing.Color.White;
            this.CreateEventMonitoredItemsBTN.Location = new System.Drawing.Point(6, 16);
            this.CreateEventMonitoredItemsBTN.Name = "CreateEventMonitoredItemsBTN";
            this.CreateEventMonitoredItemsBTN.Size = new System.Drawing.Size(188, 28);
            this.CreateEventMonitoredItemsBTN.TabIndex = 12;
            this.CreateEventMonitoredItemsBTN.Text = "Create Event Monitored Items";
            this.CreateEventMonitoredItemsBTN.UseVisualStyleBackColor = false;
            this.CreateEventMonitoredItemsBTN.Click += new System.EventHandler(this.MenuButton_Click);
            //
            // DataMonitoredItemsGB
            //
            this.DataMonitoredItemsGB.Controls.Add(this.ModifyDataMonitoredItemsBTN);
            this.DataMonitoredItemsGB.Controls.Add(this.CreateDataMonitoredItemsBTN);
            this.DataMonitoredItemsGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.DataMonitoredItemsGB.Location = new System.Drawing.Point(0, 104);
            this.DataMonitoredItemsGB.Name = "DataMonitoredItemsGB";
            this.DataMonitoredItemsGB.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.DataMonitoredItemsGB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DataMonitoredItemsGB.Size = new System.Drawing.Size(200, 80);
            this.DataMonitoredItemsGB.TabIndex = 14;
            this.DataMonitoredItemsGB.TabStop = false;
            this.DataMonitoredItemsGB.Text = "Data Monitored Items";
            //
            // ModifyDataMonitoredItemsBTN
            //
            this.ModifyDataMonitoredItemsBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.ModifyDataMonitoredItemsBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.ModifyDataMonitoredItemsBTN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(178)))), ((int)(((byte)(75)))));
            this.ModifyDataMonitoredItemsBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifyDataMonitoredItemsBTN.ForeColor = System.Drawing.Color.White;
            this.ModifyDataMonitoredItemsBTN.Location = new System.Drawing.Point(6, 44);
            this.ModifyDataMonitoredItemsBTN.Name = "ModifyDataMonitoredItemsBTN";
            this.ModifyDataMonitoredItemsBTN.Size = new System.Drawing.Size(188, 28);
            this.ModifyDataMonitoredItemsBTN.TabIndex = 9;
            this.ModifyDataMonitoredItemsBTN.Text = "Modify Data Monitored Items";
            this.ModifyDataMonitoredItemsBTN.UseVisualStyleBackColor = false;
            this.ModifyDataMonitoredItemsBTN.Click += new System.EventHandler(this.MenuButton_Click);
            //
            // CreateDataMonitoredItemsBTN
            //
            this.CreateDataMonitoredItemsBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.CreateDataMonitoredItemsBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreateDataMonitoredItemsBTN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(178)))), ((int)(((byte)(75)))));
            this.CreateDataMonitoredItemsBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateDataMonitoredItemsBTN.ForeColor = System.Drawing.Color.White;
            this.CreateDataMonitoredItemsBTN.Location = new System.Drawing.Point(6, 16);
            this.CreateDataMonitoredItemsBTN.Name = "CreateDataMonitoredItemsBTN";
            this.CreateDataMonitoredItemsBTN.Size = new System.Drawing.Size(188, 28);
            this.CreateDataMonitoredItemsBTN.TabIndex = 8;
            this.CreateDataMonitoredItemsBTN.Text = "Create Data Monitored Items";
            this.CreateDataMonitoredItemsBTN.UseVisualStyleBackColor = false;
            this.CreateDataMonitoredItemsBTN.Click += new System.EventHandler(this.MenuButton_Click);
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
            this.ManageSubscriptionGB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ManageSubscriptionGB.Size = new System.Drawing.Size(200, 104);
            this.ManageSubscriptionGB.TabIndex = 13;
            this.ManageSubscriptionGB.TabStop = false;
            this.ManageSubscriptionGB.Text = "Manage Subscription";
            //
            // DeleteSubscriptionBTN
            //
            this.DeleteSubscriptionBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.DeleteSubscriptionBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.DeleteSubscriptionBTN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(178)))), ((int)(((byte)(75)))));
            this.DeleteSubscriptionBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteSubscriptionBTN.ForeColor = System.Drawing.Color.White;
            this.DeleteSubscriptionBTN.Location = new System.Drawing.Point(6, 72);
            this.DeleteSubscriptionBTN.Name = "DeleteSubscriptionBTN";
            this.DeleteSubscriptionBTN.Size = new System.Drawing.Size(188, 28);
            this.DeleteSubscriptionBTN.TabIndex = 7;
            this.DeleteSubscriptionBTN.Text = "Delete Subscription";
            this.DeleteSubscriptionBTN.UseVisualStyleBackColor = false;
            this.DeleteSubscriptionBTN.Click += new System.EventHandler(this.MenuButton_Click);
            //
            // ModifySubscriptionBTN
            //
            this.ModifySubscriptionBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.ModifySubscriptionBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.ModifySubscriptionBTN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(178)))), ((int)(((byte)(75)))));
            this.ModifySubscriptionBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifySubscriptionBTN.ForeColor = System.Drawing.Color.White;
            this.ModifySubscriptionBTN.Location = new System.Drawing.Point(6, 44);
            this.ModifySubscriptionBTN.Name = "ModifySubscriptionBTN";
            this.ModifySubscriptionBTN.Size = new System.Drawing.Size(188, 28);
            this.ModifySubscriptionBTN.TabIndex = 6;
            this.ModifySubscriptionBTN.Text = "Modify Subscription";
            this.ModifySubscriptionBTN.UseVisualStyleBackColor = false;
            this.ModifySubscriptionBTN.Click += new System.EventHandler(this.MenuButton_Click);
            //
            // CreateSubscriptionBTN
            //
            this.CreateSubscriptionBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.CreateSubscriptionBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreateSubscriptionBTN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(178)))), ((int)(((byte)(75)))));
            this.CreateSubscriptionBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateSubscriptionBTN.ForeColor = System.Drawing.Color.White;
            this.CreateSubscriptionBTN.Location = new System.Drawing.Point(6, 16);
            this.CreateSubscriptionBTN.Name = "CreateSubscriptionBTN";
            this.CreateSubscriptionBTN.Size = new System.Drawing.Size(188, 28);
            this.CreateSubscriptionBTN.TabIndex = 5;
            this.CreateSubscriptionBTN.Text = "Create Subscription";
            this.CreateSubscriptionBTN.UseVisualStyleBackColor = false;
            this.CreateSubscriptionBTN.Click += new System.EventHandler(this.MenuButton_Click);
            //
            // LeftPN
            //
            this.LeftPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftPN.Location = new System.Drawing.Point(200, 37);
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
            this.LeftPN.Size = new System.Drawing.Size(584, 446);
            this.LeftPN.SplitterDistance = 314;
            this.LeftPN.TabIndex = 8;
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
            this.MonitoredItemsPN.Size = new System.Drawing.Size(584, 314);
            this.MonitoredItemsPN.SplitterDistance = 155;
            this.MonitoredItemsPN.TabIndex = 4;
            //
            // CurrentMonitoredItemsGB
            //
            this.CurrentMonitoredItemsGB.Controls.Add(this.MonitoredItemsLV);
            this.CurrentMonitoredItemsGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentMonitoredItemsGB.Location = new System.Drawing.Point(0, 0);
            this.CurrentMonitoredItemsGB.Name = "CurrentMonitoredItemsGB";
            this.CurrentMonitoredItemsGB.Size = new System.Drawing.Size(584, 155);
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
            this.MonitoredItemsLV.Location = new System.Drawing.Point(3, 16);
            this.MonitoredItemsLV.Name = "MonitoredItemsLV";
            this.MonitoredItemsLV.Size = new System.Drawing.Size(578, 136);
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
            this.EventsGB.Size = new System.Drawing.Size(584, 155);
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
            this.EventsLV.Location = new System.Drawing.Point(3, 16);
            this.EventsLV.Name = "EventsLV";
            this.EventsLV.Size = new System.Drawing.Size(578, 136);
            this.EventsLV.TabIndex = 3;
            this.EventsLV.UseCompatibleStateImageBehavior = false;
            this.EventsLV.View = System.Windows.Forms.View.Details;
            //
            // NotificationMessagesGB
            //
            this.NotificationMessagesGB.Controls.Add(this.WarningLB);
            this.NotificationMessagesGB.Controls.Add(this.LogCTRL);
            this.NotificationMessagesGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotificationMessagesGB.Location = new System.Drawing.Point(0, 0);
            this.NotificationMessagesGB.Name = "NotificationMessagesGB";
            this.NotificationMessagesGB.Size = new System.Drawing.Size(584, 128);
            this.NotificationMessagesGB.TabIndex = 2;
            this.NotificationMessagesGB.TabStop = false;
            this.NotificationMessagesGB.Text = "Notification Messages";
            //
            // WarningLB
            //
            this.WarningLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WarningLB.BackColor = System.Drawing.Color.Red;
            this.WarningLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarningLB.ForeColor = System.Drawing.Color.White;
            this.WarningLB.Location = new System.Drawing.Point(20, 89);
            this.WarningLB.Name = "WarningLB";
            this.WarningLB.Size = new System.Drawing.Size(544, 23);
            this.WarningLB.TabIndex = 18;
            this.WarningLB.Text = "Cannot connect to Server!";
            this.WarningLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.WarningLB.Visible = false;
            this.WarningLB.Click += new System.EventHandler(this.WarningLB_Click);
            //
            // LogCTRL
            //
            this.LogCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogCTRL.Location = new System.Drawing.Point(3, 16);
            this.LogCTRL.Name = "LogCTRL";
            this.LogCTRL.Size = new System.Drawing.Size(578, 109);
            this.LogCTRL.TabIndex = 1;
            this.LogCTRL.Text = "";
            //
            // TopPN
            //
            this.TopPN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(201)))));
            this.TopPN.Controls.Add(this.ConnectCloseBTN);
            this.TopPN.Controls.Add(this.label1);
            this.TopPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPN.Location = new System.Drawing.Point(0, 0);
            this.TopPN.Name = "TopPN";
            this.TopPN.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.TopPN.Size = new System.Drawing.Size(784, 37);
            this.TopPN.TabIndex = 11;
            //
            // ConnectCloseBTN
            //
            this.ConnectCloseBTN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectCloseBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.ConnectCloseBTN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(178)))), ((int)(((byte)(75)))));
            this.ConnectCloseBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectCloseBTN.ForeColor = System.Drawing.Color.White;
            this.ConnectCloseBTN.Location = new System.Drawing.Point(704, 5);
            this.ConnectCloseBTN.Name = "ConnectCloseBTN";
            this.ConnectCloseBTN.Size = new System.Drawing.Size(75, 32);
            this.ConnectCloseBTN.TabIndex = 3;
            this.ConnectCloseBTN.Text = "Back";
            this.ConnectCloseBTN.UseVisualStyleBackColor = false;
            this.ConnectCloseBTN.Click += new System.EventHandler(this.ConnectCloseBTN_Click);
            //
            // label1
            //
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(0, 5);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(327, 32);
            this.label1.TabIndex = 10;
            this.label1.Text = "Subscription Examples";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // SubscriptionOptionsControl
            //
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(201)))));
            this.Controls.Add(this.LeftPN);
            this.Controls.Add(this.RightPN);
            this.Controls.Add(this.TopPN);
            this.Name = "SubscriptionOptionsControl";
            this.Size = new System.Drawing.Size(784, 483);
            this.VisibleChanged += new System.EventHandler(this.Control_VisibleChanged);
            this.RightPN.ResumeLayout(false);
            this.MonitoredItemsGB.ResumeLayout(false);
            this.EventMonitoredItemsGB.ResumeLayout(false);
            this.DataMonitoredItemsGB.ResumeLayout(false);
            this.ManageSubscriptionGB.ResumeLayout(false);
            this.LeftPN.Panel1.ResumeLayout(false);
            this.LeftPN.Panel2.ResumeLayout(false);
            this.LeftPN.ResumeLayout(false);
            this.MonitoredItemsPN.Panel1.ResumeLayout(false);
            this.MonitoredItemsPN.Panel2.ResumeLayout(false);
            this.MonitoredItemsPN.ResumeLayout(false);
            this.CurrentMonitoredItemsGB.ResumeLayout(false);
            this.EventsGB.ResumeLayout(false);
            this.NotificationMessagesGB.ResumeLayout(false);
            this.TopPN.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Button ConnectCloseBTN;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel RightPN;
        private System.Windows.Forms.Label WarningLB;
    }
}
