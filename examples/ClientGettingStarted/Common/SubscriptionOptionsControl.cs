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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;

namespace UnifiedAutomation.ClientGettingStarted.Common
{
    public partial class SubscriptionOptionsControl : UserControl
    {
        public SubscriptionOptionsControl()
        {
            InitializeComponent();

            m_StatusChanged = new SubscriptionStatusChangedEventHandler(Subscription_StatusChanged);
            m_NotificationMessageReceived = new NotificationMessageReceivedEventHandler(Subscription_NotificationMessageReceived);
            m_DataChanged = new DataChangedEventHandler(Subscription_DataChanged);
            m_NewEvents = new NewEventsEventHandler(Subscription_NewEvents);

            m_info = new Info[]
            {
                new Info() { Button = CreateSubscriptionBTN, Type = typeof(CreateSubscriptionDlg), Handler = CreateSubscriptionBTN_Click },
                new Info() { Button = ModifySubscriptionBTN, Type = typeof(ModifySubscriptionDlg), Handler = ModifySubscriptionBTN_Click },
                new Info() { Button = DeleteSubscriptionBTN, Type = typeof(DeleteSubscriptionDlg), Handler = DeleteSubscriptionBTN_Click },
                new Info() { Button = CreateDataMonitoredItemsBTN, Type = typeof(CreateDataMonitoredItemsDlg), Handler = CreateDataMonitoredItemsBTN_Click },
                new Info() { Button = ModifyDataMonitoredItemsBTN, Type = typeof(ModifyDataMonitoredItemsDlg), Handler = ModifyDataMonitoredItemsBTN_Click },
                new Info() { Button = CreateEventMonitoredItemsBTN, Type = typeof(CreateEventMonitoredItemsDlg), Handler = CreateEventMonitoredItemsBTN_Click },
                new Info() { Button = ModifyEventMonitoredItemsBTN, Type = typeof(ModifyEventMonitoredItemsDlg), Handler = ModifyEventMonitoredItemsBTN_Click },
                new Info() { Button = DeleteMonitoredItemsBTN, Type = typeof(DeleteMonitoredItemsDlg), Handler = DeleteMonitoredItemsBTN_Click },
                new Info() { Button = SetMonitoringModeBTN, Type = typeof(SetMonitoringModeDlg), Handler = SetMonitoringModeBTN_Click },
                // new Info() { Button = MonitoredConditionsBTN, Type = typeof(MonitorConditionsDlg), Handler = MonitoredConditionsBTN_Click },
            };
        }

        private Info[] m_info;
        private Subscription m_subscription;
        private SubscriptionStatusChangedEventHandler m_StatusChanged;
        private NotificationMessageReceivedEventHandler m_NotificationMessageReceived;
        private DataChangedEventHandler m_DataChanged;
        private NewEventsEventHandler m_NewEvents;

        private class Info
        {
            public Button Button { get; set; }
            public Type Type { get; set; }
            public EventHandler Handler { get; set; }
        }

        private void CreateSubscriptionIfRequired()
        {
            if (m_subscription == null)
            {
                Session session = ((MainForm)this.ParentForm).Session;

                Subscription subscription = new Subscription(session);

                subscription.PublishingInterval = 1000;
                subscription.MaxKeepAliveTime = 10000;
                subscription.Lifetime = 60000;
                subscription.MaxNotificationsPerPublish = 0;
                subscription.Priority = 0;
                subscription.PublishingEnabled = true;

                // create subscription.
                subscription.Create();
                SubscriptionChanged(subscription);
            }
        }

        private void ConnectCloseBTN_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            foreach (Info info in m_info.Where(i => i.Button == sender))
            {
                info.Handler(sender, e);
                break;
            }
        }

        private void CreateSubscriptionBTN_Click(object sender, EventArgs e)
        {
            try
            {
                Session session = ((MainForm)this.ParentForm).Session;

                CreateSubscriptionDlg dialog = new CreateSubscriptionDlg();
                dialog.StartPosition = FormStartPosition.CenterParent;
                Subscription subscription = dialog.ShowDialog(this.ParentForm as MainForm);

                if (subscription != null)
                {
                    SubscriptionChanged(subscription);
                }

            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void ModifySubscriptionBTN_Click(object sender, EventArgs e)
        {
            try
            {
                CreateSubscriptionIfRequired();
                ModifySubscriptionDlg dialog = new ModifySubscriptionDlg();
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.ShowDialog(this.ParentForm as MainForm, m_subscription);
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void DeleteSubscriptionBTN_Click(object sender, EventArgs e)
        {
            try
            {
                CreateSubscriptionIfRequired();
                DeleteSubscriptionDlg dialog = new DeleteSubscriptionDlg();
                dialog.StartPosition = FormStartPosition.CenterParent;

                if (dialog.ShowDialog(this.ParentForm as MainForm, m_subscription))
                {
                    SubscriptionChanged(null);
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void CreateDataMonitoredItemsBTN_Click(object sender, EventArgs e)
        {
            try
            {
                CreateSubscriptionIfRequired();
                CreateDataMonitoredItemsDlg dialog = new CreateDataMonitoredItemsDlg();
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.ShowDialog(this.ParentForm as MainForm, m_subscription);

                foreach (MonitoredItem monitoredItem in m_subscription.MonitoredItems)
                {
                    ListViewItem item = monitoredItem.UserData as ListViewItem;

                    if (item != null)
                    {
                        if (Object.ReferenceEquals(item.ListView, MonitoredItemsLV))
                        {
                            continue;
                        }
                    }

                    AddMonitoredItem(monitoredItem);
                }

                for (int ii = 0; ii < 3; ii++)
                {
                    MonitoredItemsLV.Columns[ii].Width = -2;
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void ModifyDataMonitoredItemsBTN_Click(object sender, EventArgs e)
        {
            try
            {
                CreateSubscriptionIfRequired();
                ModifyDataMonitoredItemsDlg dialog = new ModifyDataMonitoredItemsDlg();
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.ShowDialog(this.ParentForm as MainForm, m_subscription);

                foreach (MonitoredItem monitoredItem in m_subscription.MonitoredItems)
                {
                    UpdateMonitoredItem(monitoredItem.UserData as ListViewItem, monitoredItem);
                }

                for (int ii = 0; ii < 3; ii++)
                {
                    MonitoredItemsLV.Columns[ii].Width = -2;
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void CreateEventMonitoredItemsBTN_Click(object sender, EventArgs e)
        {
            try
            {
                CreateSubscriptionIfRequired();
                CreateEventMonitoredItemsDlg dialog = new CreateEventMonitoredItemsDlg();
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.ShowDialog(this.ParentForm as MainForm, m_subscription);

                foreach (MonitoredItem monitoredItem in m_subscription.MonitoredItems)
                {
                    ListViewItem item = monitoredItem.UserData as ListViewItem;

                    if (item != null)
                    {
                        if (Object.ReferenceEquals(item.ListView, MonitoredItemsLV))
                        {
                            continue;
                        }
                    }

                    AddMonitoredItem(monitoredItem);
                }

                for (int ii = 0; ii < 3; ii++)
                {
                    MonitoredItemsLV.Columns[ii].Width = -2;
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void ModifyEventMonitoredItemsBTN_Click(object sender, EventArgs e)
        {
            try
            {
                CreateSubscriptionIfRequired();
                ModifyEventMonitoredItemsDlg dialog = new ModifyEventMonitoredItemsDlg();
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.ShowDialog(this.ParentForm as MainForm, m_subscription);

                foreach (MonitoredItem monitoredItem in m_subscription.MonitoredItems)
                {
                    UpdateMonitoredItem(monitoredItem.UserData as ListViewItem, monitoredItem);
                }

                for (int ii = 0; ii < 3; ii++)
                {
                    MonitoredItemsLV.Columns[ii].Width = -2;
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void SetMonitoringModeBTN_Click(object sender, EventArgs e)
        {
            try
            {
                CreateSubscriptionIfRequired();
                SetMonitoringModeDlg dialog = new SetMonitoringModeDlg();
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.ShowDialog(this.ParentForm as MainForm, m_subscription);

                foreach (MonitoredItem monitoredItem in m_subscription.MonitoredItems)
                {
                    UpdateMonitoredItem(monitoredItem.UserData as ListViewItem, monitoredItem);
                }

                for (int ii = 0; ii < 3; ii++)
                {
                    MonitoredItemsLV.Columns[ii].Width = -2;
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void DeleteMonitoredItemsBTN_Click(object sender, EventArgs e)
        {
            try
            {
                CreateSubscriptionIfRequired();
                new DeleteMonitoredItemsDlg().ShowDialog(this.ParentForm as MainForm, m_subscription);

                MonitoredItemsLV.Items.Clear();

                foreach (MonitoredItem monitoredItem in m_subscription.MonitoredItems)
                {
                    AddMonitoredItem(monitoredItem);
                }

                for (int ii = 0; ii < 3; ii++)
                {
                    MonitoredItemsLV.Columns[ii].Width = -2;
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void AddMonitoredItem(MonitoredItem monitoredItem)
        {
            ListViewItem item = new ListViewItem();

            for (int ii = 0; ii < 5; ii++)
            {
                item.SubItems.Add(String.Empty);
            }

            UpdateMonitoredItem(item, monitoredItem);
            item.Tag = monitoredItem;
            MonitoredItemsLV.Items.Add(item);
        }

        private void UpdateMonitoredItem(ListViewItem item, MonitoredItem monitoredItem)
        {
            string index = null;

            if (monitoredItem.ClientHandle == 0)
            {
                index = "[---]";
            }
            else
            {
                index = String.Format("[{0:D3}]", monitoredItem.ClientHandle);
            }

            DataMonitoredItem dataItem = monitoredItem as DataMonitoredItem;

            item.SubItems[0].Text = index;
            item.SubItems[1].Text = m_subscription.Session.Cache.GetDisplayText(monitoredItem.NodeId);
            item.SubItems[2].Text = Attributes.GetDisplayText(monitoredItem.AttributeId);
            item.SubItems[3].Text = String.Empty;
            item.SubItems[4].Text = String.Empty;
            item.SubItems[5].Text = String.Empty;

            item.Tag = monitoredItem;
            monitoredItem.UserData = item;

            if (StatusCode.IsBad(monitoredItem.LastError))
            {
                item.SubItems[5].Text = monitoredItem.LastError.ToString();
                item.ForeColor = Color.Red;
            }
            else
            {
                if (dataItem != null && dataItem.LastValue != null)
                {
                    item.SubItems[3].Text = ((dataItem.LastValue.SourceTimestamp != DateTime.MinValue) ? dataItem.LastValue.SourceTimestamp : dataItem.LastValue.ServerTimestamp).ToLocalTime().ToString("HH:mm:ss.fff");
                    item.SubItems[4].Text = dataItem.LastValue.WrappedValue.TypeInfo.ToString();
                    item.SubItems[5].Text = dataItem.LastValue.WrappedValue.ToString();
                }

                item.ForeColor = Color.Empty;
            }
        }

        private void SubscriptionChanged(Subscription subscription)
        {
            if (m_subscription != null)
            {
                m_subscription.StatusChanged -= m_StatusChanged;
                m_subscription.NotificationMessageReceived -= m_NotificationMessageReceived;
                m_subscription.DataChanged -= m_DataChanged;
                m_subscription.NewEvents -= m_NewEvents;
                m_subscription = null;

                MonitoredItemsLV.Items.Clear();
                EventsLV.Items.Clear();

                // ModifySubscriptionBTN.Enabled = false;
                // DeleteSubscriptionBTN.Enabled = false;
                // CreateDataMonitoredItemsBTN.Enabled = false;
                // CreateEventMonitoredItemsBTN.Enabled = false;
                // ModifyDataMonitoredItemsBTN.Enabled = false;
                // ModifyEventMonitoredItemsBTN.Enabled = false;
                // DeleteMonitoredItemsBTN.Enabled = false;
                // SetMonitoringModeBTN.Enabled = false;
                // MonitoredConditionsBTN.Enabled = false;
            }

            if (subscription != null)
            {
                m_subscription = subscription;
                m_subscription.StatusChanged += m_StatusChanged;
                m_subscription.NotificationMessageReceived += m_NotificationMessageReceived;
                m_subscription.DataChanged += m_DataChanged;
                m_subscription.NewEvents += m_NewEvents;

                // ModifySubscriptionBTN.Enabled = true;
                // DeleteSubscriptionBTN.Enabled = true;
                // CreateDataMonitoredItemsBTN.Enabled = true;
                // CreateEventMonitoredItemsBTN.Enabled = true;
                // ModifyDataMonitoredItemsBTN.Enabled = true;
                // ModifyEventMonitoredItemsBTN.Enabled = true;
                // DeleteMonitoredItemsBTN.Enabled = true;
                // SetMonitoringModeBTN.Enabled = true;
                // MonitoredConditionsBTN.Enabled = true;
            }
        }

        private void LogSubscriptionMessage(string format, params object[] args)
        {
            if (args != null && args.Length > 0)
            {
                format = String.Format(System.Globalization.CultureInfo.CurrentCulture, format, args);
            }

            int start = LogCTRL.SelectionStart;
            int length = LogCTRL.SelectionLength;

            LogCTRL.AppendText(format + "\r\n");

            if (length > 0)
            {
                LogCTRL.SelectionStart = start;
                LogCTRL.SelectionLength = length;
            }
            else
            {
                LogCTRL.ScrollToCaret();
            }
        }

        private void Subscription_StatusChanged(Subscription subscription, SubscriptionStatusChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(m_StatusChanged, subscription, e);
                return;
            }

            try
            {
                if (!Object.ReferenceEquals(subscription, m_subscription))
                {
                    return;
                }

                StringBuilder buffer = new StringBuilder();

                if (e.CurrentStatus != SubscriptionConnectionStatus.Created)
                {
                    buffer.Append(e.CurrentStatus);
                }
                else
                {
                    buffer.Append((subscription.CurrentPublishingEnabled) ? "Enabled" : "Disabled");
                }

                if (StatusCode.IsNotGood(e.Error))
                {
                    buffer.Append(" [");
                    buffer.Append(e.Error);
                    buffer.Append("]");
                }

                LogSubscriptionMessage("{1:HH:mm:ss.fff}: {0}", buffer, DateTime.UtcNow.ToLocalTime());
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void Subscription_NotificationMessageReceived(Subscription subscription, NotificationMessageReceivedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(m_NotificationMessageReceived, subscription, e);
                return;
            }

            try
            {
                if (!Object.ReferenceEquals(subscription, m_subscription))
                {
                    return;
                }

                if (e.NotificationMessage.NotificationData == null || e.NotificationMessage.NotificationData.Count == 0)
                {
                    LogSubscriptionMessage("{0:HH:mm:ss.fff}: KeepAlive", e.NotificationMessage.PublishTime.ToLocalTime());
                }

                if (e.Republish)
                {
                    LogSubscriptionMessage("{1:HH:mm:ss.fff}: Republish #{0}", e.NotificationMessage.SequenceNumber, e.NotificationMessage.PublishTime.ToLocalTime());
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void Subscription_DataChanged(Subscription subscription, DataChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(m_DataChanged, subscription, e);
                return;
            }

            try
            {
                if (!Object.ReferenceEquals(subscription, m_subscription))
                {
                    return;
                }

                foreach (DataChange change in e.DataChanges)
                {
                    ListViewItem item = change.MonitoredItem.UserData as ListViewItem;

                    if (item != null && item.SubItems.Count >= 5)
                    {
                        item.SubItems[3].Text = ((change.Value.SourceTimestamp != DateTime.MinValue) ? change.Value.SourceTimestamp : change.Value.ServerTimestamp).ToLocalTime().ToString("HH:mm:ss.fff");
                        item.SubItems[4].Text = change.Value.WrappedValue.TypeInfo.ToString();
                        item.SubItems[5].Text = change.Value.WrappedValue.ToString();
                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void Subscription_NewEvents(Subscription subscription, NewEventsEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(m_NewEvents, subscription, e);
                return;
            }

            try
            {
                if (!Object.ReferenceEquals(subscription, m_subscription))
                {
                    return;
                }

                foreach (NewEvent anEvent in e.Events)
                {
                    ListViewItem item = anEvent.MonitoredItem.UserData as ListViewItem;
                    UaClient.ItemEventFilter filter = anEvent.MonitoredItem.Filter;

                    NodeId eventType = filter.GetValue<NodeId>(anEvent.Event, BrowseNames.EventType, NodeId.Null);
                    NodeId sourceNode = filter.GetValue<NodeId>(anEvent.Event, BrowseNames.SourceNode, NodeId.Null);
                    DateTime time = filter.GetValue<DateTime>(anEvent.Event, BrowseNames.Time, DateTime.MinValue);
                    DateTime receiveTime = filter.GetValue<DateTime>(anEvent.Event, BrowseNames.ReceiveTime, DateTime.MinValue);
                    ushort severity = filter.GetValue<ushort>(anEvent.Event, BrowseNames.Severity, 0);
                    LocalizedText message = filter.GetValue<LocalizedText>(anEvent.Event, BrowseNames.Message, LocalizedText.Null);

                    if (item != null && item.SubItems.Count >= 5)
                    {
                        item.SubItems[3].Text = ((time != DateTime.MinValue) ? time : receiveTime).ToLocalTime().ToString("HH:mm:ss.fff");
                    }

                    item = new ListViewItem(m_subscription.Session.Cache.GetDisplayText(eventType));

                    item.SubItems.Add(m_subscription.Session.Cache.GetDisplayText(sourceNode));
                    item.SubItems.Add(time.ToLocalTime().ToString("HH:mm:ss.fff"));
                    item.SubItems.Add(severity.ToString());
                    item.SubItems.Add(message.ToString());

                    item.Tag = anEvent;

                    EventsLV.Items.Insert(0, item);
                }

                foreach (ColumnHeader header in EventsLV.Columns)
                {
                    header.Width = -2;
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void WarningLB_Click(object sender, EventArgs e)
        {
            WarningLB.Visible = false;
        }

        private void Control_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                try
                {
                    Session session = ((MainForm)this.ParentForm).Session;
                    // TraceClient.Info("STATUS CHECK for {1}: ServerConnectionStatus={0}", session.ConnectionStatus, this.GetType().Name);
                    WarningLB.Visible = (session.ConnectionStatus != ServerConnectionStatus.Connected);
                    WarningLB.Text = String.Format(System.Globalization.CultureInfo.InvariantCulture, "Cannot connect to Server! ({0})", session.ConnectionStatus);
                }
                catch (Exception)
                {
                    // TraceClient.Error(exception, "WARNING DISPLAYED: Error checking server status.");
                    WarningLB.Visible = true;
                    WarningLB.Text = String.Format(System.Globalization.CultureInfo.InvariantCulture, "Cannot connect to Server! (Unknown)");
                }
            }
        }
    }
}
