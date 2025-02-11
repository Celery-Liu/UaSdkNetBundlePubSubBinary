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
    partial class SubscribeDlg
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
            System.Windows.Forms.ColumnHeader TimeCH;
            System.Windows.Forms.ColumnHeader EventTypeCH;
            System.Windows.Forms.ColumnHeader SourceCH;
            System.Windows.Forms.ColumnHeader SeverityCH;
            System.Windows.Forms.ColumnHeader MessageCH;
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.RightPN = new System.Windows.Forms.Panel();
            this.SetMonitoringModeBTN = new System.Windows.Forms.Button();
            this.DeleteMonitoredItemsBTN = new System.Windows.Forms.Button();
            this.ModifyEventMonitoredItemsBTN = new System.Windows.Forms.Button();
            this.ModifyDataMonitoredItemsBTN = new System.Windows.Forms.Button();
            this.CreateEventMonitoredItemsBTN = new System.Windows.Forms.Button();
            this.CreateDataMonitoredItemsBTN = new System.Windows.Forms.Button();
            this.DeleteSubscriptionBTN = new System.Windows.Forms.Button();
            this.ModifySubscriptionBTN = new System.Windows.Forms.Button();
            this.CreateSubscriptionBTN = new System.Windows.Forms.Button();
            this.MonitoredItemsLV = new System.Windows.Forms.ListView();
            this.ClientHandleCH = new System.Windows.Forms.ColumnHeader();
            this.NodeCH = new System.Windows.Forms.ColumnHeader();
            this.AttributeCH = new System.Windows.Forms.ColumnHeader();
            this.TimestampCH = new System.Windows.Forms.ColumnHeader();
            this.DataTypeCH = new System.Windows.Forms.ColumnHeader();
            this.DataValueCH = new System.Windows.Forms.ColumnHeader();
            this.LeftPN = new System.Windows.Forms.SplitContainer();
            this.MonitoredItemsPN = new System.Windows.Forms.SplitContainer();
            this.EventsLV = new System.Windows.Forms.ListView();
            this.LogCTRL = new System.Windows.Forms.RichTextBox();
            this.MonitoredConditionsBTN = new System.Windows.Forms.Button();
            TimeCH = new System.Windows.Forms.ColumnHeader();
            EventTypeCH = new System.Windows.Forms.ColumnHeader();
            SourceCH = new System.Windows.Forms.ColumnHeader();
            SeverityCH = new System.Windows.Forms.ColumnHeader();
            MessageCH = new System.Windows.Forms.ColumnHeader();
            this.RightPN.SuspendLayout();
            this.LeftPN.Panel1.SuspendLayout();
            this.LeftPN.Panel2.SuspendLayout();
            this.LeftPN.SuspendLayout();
            this.MonitoredItemsPN.Panel1.SuspendLayout();
            this.MonitoredItemsPN.Panel2.SuspendLayout();
            this.MonitoredItemsPN.SuspendLayout();
            this.SuspendLayout();
            //
            // TimeCH
            //
            TimeCH.Text = "Time";
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
            this.RightPN.Controls.Add(this.MonitoredConditionsBTN);
            this.RightPN.Controls.Add(this.SetMonitoringModeBTN);
            this.RightPN.Controls.Add(this.DeleteMonitoredItemsBTN);
            this.RightPN.Controls.Add(this.ModifyEventMonitoredItemsBTN);
            this.RightPN.Controls.Add(this.ModifyDataMonitoredItemsBTN);
            this.RightPN.Controls.Add(this.CreateEventMonitoredItemsBTN);
            this.RightPN.Controls.Add(this.CreateDataMonitoredItemsBTN);
            this.RightPN.Controls.Add(this.DeleteSubscriptionBTN);
            this.RightPN.Controls.Add(this.ModifySubscriptionBTN);
            this.RightPN.Controls.Add(this.CreateSubscriptionBTN);
            this.RightPN.Dock = System.Windows.Forms.DockStyle.Left;
            this.RightPN.Location = new System.Drawing.Point(0, 0);
            this.RightPN.Name = "RightPN";
            this.RightPN.Size = new System.Drawing.Size(155, 562);
            this.RightPN.TabIndex = 1;
            //
            // SetMonitoringModeBTN
            //
            this.SetMonitoringModeBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.SetMonitoringModeBTN.Enabled = false;
            this.SetMonitoringModeBTN.Location = new System.Drawing.Point(0, 184);
            this.SetMonitoringModeBTN.Name = "SetMonitoringModeBTN";
            this.SetMonitoringModeBTN.Size = new System.Drawing.Size(155, 23);
            this.SetMonitoringModeBTN.TabIndex = 9;
            this.SetMonitoringModeBTN.Text = "Set Monitoring Mode";
            this.SetMonitoringModeBTN.UseVisualStyleBackColor = true;
            this.SetMonitoringModeBTN.Click += new System.EventHandler(this.SetMonitoringModeBTN_Click);
            //
            // DeleteMonitoredItemsBTN
            //
            this.DeleteMonitoredItemsBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.DeleteMonitoredItemsBTN.Enabled = false;
            this.DeleteMonitoredItemsBTN.Location = new System.Drawing.Point(0, 161);
            this.DeleteMonitoredItemsBTN.Name = "DeleteMonitoredItemsBTN";
            this.DeleteMonitoredItemsBTN.Size = new System.Drawing.Size(155, 23);
            this.DeleteMonitoredItemsBTN.TabIndex = 8;
            this.DeleteMonitoredItemsBTN.Text = "Delete Monitored Items";
            this.DeleteMonitoredItemsBTN.UseVisualStyleBackColor = true;
            this.DeleteMonitoredItemsBTN.Click += new System.EventHandler(this.DeleteMonitoredItemsBTN_Click);
            //
            // ModifyEventMonitoredItemsBTN
            //
            this.ModifyEventMonitoredItemsBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.ModifyEventMonitoredItemsBTN.Enabled = false;
            this.ModifyEventMonitoredItemsBTN.Location = new System.Drawing.Point(0, 138);
            this.ModifyEventMonitoredItemsBTN.Name = "ModifyEventMonitoredItemsBTN";
            this.ModifyEventMonitoredItemsBTN.Size = new System.Drawing.Size(155, 23);
            this.ModifyEventMonitoredItemsBTN.TabIndex = 11;
            this.ModifyEventMonitoredItemsBTN.Text = "Modify Event Monitored Items";
            this.ModifyEventMonitoredItemsBTN.UseVisualStyleBackColor = true;
            this.ModifyEventMonitoredItemsBTN.Click += new System.EventHandler(this.ModifyEventMonitoredItemsBTN_Click);
            //
            // ModifyDataMonitoredItemsBTN
            //
            this.ModifyDataMonitoredItemsBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.ModifyDataMonitoredItemsBTN.Enabled = false;
            this.ModifyDataMonitoredItemsBTN.Location = new System.Drawing.Point(0, 115);
            this.ModifyDataMonitoredItemsBTN.Name = "ModifyDataMonitoredItemsBTN";
            this.ModifyDataMonitoredItemsBTN.Size = new System.Drawing.Size(155, 23);
            this.ModifyDataMonitoredItemsBTN.TabIndex = 7;
            this.ModifyDataMonitoredItemsBTN.Text = "Modify Data Monitored Items";
            this.ModifyDataMonitoredItemsBTN.UseVisualStyleBackColor = true;
            this.ModifyDataMonitoredItemsBTN.Click += new System.EventHandler(this.ModifyDataMonitoredItemsBTN_Click);
            //
            // CreateEventMonitoredItemsBTN
            //
            this.CreateEventMonitoredItemsBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreateEventMonitoredItemsBTN.Enabled = false;
            this.CreateEventMonitoredItemsBTN.Location = new System.Drawing.Point(0, 92);
            this.CreateEventMonitoredItemsBTN.Name = "CreateEventMonitoredItemsBTN";
            this.CreateEventMonitoredItemsBTN.Size = new System.Drawing.Size(155, 23);
            this.CreateEventMonitoredItemsBTN.TabIndex = 10;
            this.CreateEventMonitoredItemsBTN.Text = "Create Event Monitored Items";
            this.CreateEventMonitoredItemsBTN.UseVisualStyleBackColor = true;
            this.CreateEventMonitoredItemsBTN.Click += new System.EventHandler(this.CreateEventMonitoredItemsBTN_Click);
            //
            // CreateDataMonitoredItemsBTN
            //
            this.CreateDataMonitoredItemsBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreateDataMonitoredItemsBTN.Enabled = false;
            this.CreateDataMonitoredItemsBTN.Location = new System.Drawing.Point(0, 69);
            this.CreateDataMonitoredItemsBTN.Name = "CreateDataMonitoredItemsBTN";
            this.CreateDataMonitoredItemsBTN.Size = new System.Drawing.Size(155, 23);
            this.CreateDataMonitoredItemsBTN.TabIndex = 6;
            this.CreateDataMonitoredItemsBTN.Text = "Create Data Monitored Items";
            this.CreateDataMonitoredItemsBTN.UseVisualStyleBackColor = true;
            this.CreateDataMonitoredItemsBTN.Click += new System.EventHandler(this.CreateDataMonitoredItemsBTN_Click);
            //
            // DeleteSubscriptionBTN
            //
            this.DeleteSubscriptionBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.DeleteSubscriptionBTN.Enabled = false;
            this.DeleteSubscriptionBTN.Location = new System.Drawing.Point(0, 46);
            this.DeleteSubscriptionBTN.Name = "DeleteSubscriptionBTN";
            this.DeleteSubscriptionBTN.Size = new System.Drawing.Size(155, 23);
            this.DeleteSubscriptionBTN.TabIndex = 4;
            this.DeleteSubscriptionBTN.Text = "Delete Subscription";
            this.DeleteSubscriptionBTN.UseVisualStyleBackColor = true;
            this.DeleteSubscriptionBTN.Click += new System.EventHandler(this.DeleteSubscriptionBTN_Click);
            //
            // ModifySubscriptionBTN
            //
            this.ModifySubscriptionBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.ModifySubscriptionBTN.Enabled = false;
            this.ModifySubscriptionBTN.Location = new System.Drawing.Point(0, 23);
            this.ModifySubscriptionBTN.Name = "ModifySubscriptionBTN";
            this.ModifySubscriptionBTN.Size = new System.Drawing.Size(155, 23);
            this.ModifySubscriptionBTN.TabIndex = 3;
            this.ModifySubscriptionBTN.Text = "Modify Subscription";
            this.ModifySubscriptionBTN.UseVisualStyleBackColor = true;
            this.ModifySubscriptionBTN.Click += new System.EventHandler(this.ModifySubscriptionBTN_Click);
            //
            // CreateSubscriptionBTN
            //
            this.CreateSubscriptionBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreateSubscriptionBTN.Location = new System.Drawing.Point(0, 0);
            this.CreateSubscriptionBTN.Name = "CreateSubscriptionBTN";
            this.CreateSubscriptionBTN.Size = new System.Drawing.Size(155, 23);
            this.CreateSubscriptionBTN.TabIndex = 2;
            this.CreateSubscriptionBTN.Text = "Create Subscription";
            this.CreateSubscriptionBTN.UseVisualStyleBackColor = true;
            this.CreateSubscriptionBTN.Click += new System.EventHandler(this.CreateSubscriptionBTN_Click);
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
            this.MonitoredItemsLV.Location = new System.Drawing.Point(0, 0);
            this.MonitoredItemsLV.Name = "MonitoredItemsLV";
            this.MonitoredItemsLV.Size = new System.Drawing.Size(629, 200);
            this.MonitoredItemsLV.TabIndex = 2;
            this.MonitoredItemsLV.UseCompatibleStateImageBehavior = false;
            this.MonitoredItemsLV.View = System.Windows.Forms.View.Details;
            this.MonitoredItemsLV.DragDrop += new System.Windows.Forms.DragEventHandler(this.MonitoredItemsLV_DragDrop);
            this.MonitoredItemsLV.DragEnter += new System.Windows.Forms.DragEventHandler(this.MonitoredItemsLV_DragEnter);
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
            // LeftPN
            //
            this.LeftPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftPN.Location = new System.Drawing.Point(155, 0);
            this.LeftPN.Name = "LeftPN";
            this.LeftPN.Orientation = System.Windows.Forms.Orientation.Horizontal;
            //
            // LeftPN.Panel1
            //
            this.LeftPN.Panel1.Controls.Add(this.MonitoredItemsPN);
            //
            // LeftPN.Panel2
            //
            this.LeftPN.Panel2.Controls.Add(this.LogCTRL);
            this.LeftPN.Size = new System.Drawing.Size(629, 562);
            this.LeftPN.SplitterDistance = 400;
            this.LeftPN.TabIndex = 3;
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
            this.MonitoredItemsPN.Panel1.Controls.Add(this.MonitoredItemsLV);
            //
            // MonitoredItemsPN.Panel2
            //
            this.MonitoredItemsPN.Panel2.Controls.Add(this.EventsLV);
            this.MonitoredItemsPN.Size = new System.Drawing.Size(629, 400);
            this.MonitoredItemsPN.SplitterDistance = 200;
            this.MonitoredItemsPN.TabIndex = 4;
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
            this.EventsLV.Location = new System.Drawing.Point(0, 0);
            this.EventsLV.Name = "EventsLV";
            this.EventsLV.Size = new System.Drawing.Size(629, 196);
            this.EventsLV.TabIndex = 3;
            this.EventsLV.UseCompatibleStateImageBehavior = false;
            this.EventsLV.View = System.Windows.Forms.View.Details;
            //
            // LogCTRL
            //
            this.LogCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogCTRL.Location = new System.Drawing.Point(0, 0);
            this.LogCTRL.Name = "LogCTRL";
            this.LogCTRL.Size = new System.Drawing.Size(629, 158);
            this.LogCTRL.TabIndex = 1;
            this.LogCTRL.Text = "";
            //
            // MonitoredConditionsBTN
            //
            this.MonitoredConditionsBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.MonitoredConditionsBTN.Enabled = false;
            this.MonitoredConditionsBTN.Location = new System.Drawing.Point(0, 207);
            this.MonitoredConditionsBTN.Name = "MonitoredConditionsBTN";
            this.MonitoredConditionsBTN.Size = new System.Drawing.Size(155, 23);
            this.MonitoredConditionsBTN.TabIndex = 12;
            this.MonitoredConditionsBTN.Text = "Monitor Conditions";
            this.MonitoredConditionsBTN.UseVisualStyleBackColor = true;
            this.MonitoredConditionsBTN.Click += new System.EventHandler(this.MonitoredConditionsBTN_Click);
            //
            // SubscribeDlg
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.LeftPN);
            this.Controls.Add(this.RightPN);
            this.Name = "SubscribeDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Subscription";
            this.RightPN.ResumeLayout(false);
            this.LeftPN.Panel1.ResumeLayout(false);
            this.LeftPN.Panel2.ResumeLayout(false);
            this.LeftPN.ResumeLayout(false);
            this.MonitoredItemsPN.Panel1.ResumeLayout(false);
            this.MonitoredItemsPN.Panel2.ResumeLayout(false);
            this.MonitoredItemsPN.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Panel RightPN;
        private System.Windows.Forms.Button SetMonitoringModeBTN;
        private System.Windows.Forms.Button DeleteMonitoredItemsBTN;
        private System.Windows.Forms.Button ModifyDataMonitoredItemsBTN;
        private System.Windows.Forms.Button CreateDataMonitoredItemsBTN;
        private System.Windows.Forms.Button DeleteSubscriptionBTN;
        private System.Windows.Forms.Button ModifySubscriptionBTN;
        private System.Windows.Forms.Button CreateSubscriptionBTN;
        private System.Windows.Forms.ListView MonitoredItemsLV;
        private System.Windows.Forms.ColumnHeader ClientHandleCH;
        private System.Windows.Forms.ColumnHeader NodeCH;
        private System.Windows.Forms.ColumnHeader AttributeCH;
        private System.Windows.Forms.ColumnHeader TimestampCH;
        private System.Windows.Forms.ColumnHeader DataTypeCH;
        private System.Windows.Forms.ColumnHeader DataValueCH;
        private System.Windows.Forms.SplitContainer LeftPN;
        private System.Windows.Forms.RichTextBox LogCTRL;
        private System.Windows.Forms.Button CreateEventMonitoredItemsBTN;
        private System.Windows.Forms.SplitContainer MonitoredItemsPN;
        private System.Windows.Forms.ListView EventsLV;
        private System.Windows.Forms.Button ModifyEventMonitoredItemsBTN;
        private System.Windows.Forms.Button MonitoredConditionsBTN;
    }
}
