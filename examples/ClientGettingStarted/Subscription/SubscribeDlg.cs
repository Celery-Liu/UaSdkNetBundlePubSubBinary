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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.Serialization;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;

namespace UnifiedAutomation.ClientGettingStarted
{
    /// <summary>
    /// Shows a dialog which demonstrates a basic read operation.
    /// </summary>
    public partial class SubscribeDlg : Form
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicReadDlg"/> class.
        /// </summary>
        public SubscribeDlg()
        {
            InitializeComponent();
            Icon = GuiUtils.GetDefaultIcon();

            m_StatusChanged = new SubscriptionStatusChangedEventHandler(Subscription_StatusChanged);
            m_NotificationMessageReceived = new NotificationMessageReceivedEventHandler(Subscription_NotificationMessageReceived);
            m_DataChanged = new DataChangedEventHandler(Subscription_DataChanged);
            m_NewEvents = new NewEventsEventHandler(Subscription_NewEvents);
        }
        #endregion

        #region Private Fields
        private MainForm m_parent;
        private Subscription m_subscription;
        private SubscriptionStatusChangedEventHandler m_StatusChanged;
        private NotificationMessageReceivedEventHandler m_NotificationMessageReceived;
        private DataChangedEventHandler m_DataChanged;
        private NewEventsEventHandler m_NewEvents;
        #endregion

        #region Public Interface
        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public void Show(MainForm parent)
        {
            m_parent = parent;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(parent.Location.X + (parent.Width - this.Width) / 2, parent.Location.Y + (parent.Height - this.Height) / 2);
            Show();
        }
        #endregion

        #region Private Methods
        private void LogMessage(string format, params object[] args)
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

        private void AddItem(MonitoredItem monitoredItem)
        {
            ListViewItem item = new ListViewItem();

            for (int ii = 0; ii < 5; ii++)
            {
                item.SubItems.Add(String.Empty);
            }

            UpdateItem(item, monitoredItem);
            item.Tag = monitoredItem;
            MonitoredItemsLV.Items.Add(item);
        }

        private void UpdateItem(ListViewItem item, MonitoredItem monitoredItem)
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
            item.SubItems[1].Text = m_parent.Session.Cache.GetDisplayText(monitoredItem.NodeId);
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
        #endregion

        #region Event Handlers
        private void MonitoredItemsLV_DragDrop(object sender, DragEventArgs e)
        {
            string xml = (string)e.Data.GetData(typeof(string));

            try
            {
                using (XmlReader reader = new XmlTextReader(new System.IO.StringReader(xml)))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(ReadValueIdCollection));
                    ReadValueIdCollection nodesToRead = (ReadValueIdCollection)serializer.ReadObject(reader);

                    foreach (ReadValueId nodeToRead in nodesToRead)
                    {
                        AddItem(new DataMonitoredItem(nodeToRead));
                    }
                }
            }
            catch
            {
                try
                {
                    using (XmlReader reader = new XmlTextReader(new System.IO.StringReader(xml)))
                    {
                        DataContractSerializer serializer = new DataContractSerializer(typeof(ReferenceDescriptionCollection));
                        ReferenceDescriptionCollection references = (ReferenceDescriptionCollection)serializer.ReadObject(reader);

                        foreach (ReferenceDescription reference in references)
                        {
                            AddItem(new DataMonitoredItem(reference));
                        }
                    }
                }
                catch
                {
                    MessageDialog.Show(this, "Do not recognize the data dropped in the control.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            foreach (ColumnHeader header in MonitoredItemsLV.Columns)
            {
                header.Width = -2;
            }
        }

        private void MonitoredItemsLV_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.Copy;
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

                LogMessage("{1:HH:mm:ss.fff}: {0}", buffer, DateTime.UtcNow.ToLocalTime());
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
                    LogMessage("{0:HH:mm:ss.fff}: KeepAlive", e.NotificationMessage.PublishTime.ToLocalTime());
                }

                if (e.Republish)
                {
                    LogMessage("{1:HH:mm:ss.fff}: Republish #{0}", e.NotificationMessage.SequenceNumber, e.NotificationMessage.PublishTime.ToLocalTime());
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
                        item.SubItems[3].Text = ((change.Value.SourceTimestamp != DateTime.MinValue) ? change.Value.SourceTimestamp: change.Value.ServerTimestamp).ToLocalTime().ToString("HH:mm:ss.fff");
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

                    item = new ListViewItem(m_parent.Session.Cache.GetDisplayText(eventType));

                    item.SubItems.Add(m_parent.Session.Cache.GetDisplayText(sourceNode));
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

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CreateSubscriptionBTN_Click(object sender, EventArgs e)
        {
            try
            {
                Subscription subscription = new CreateSubscriptionDlg().ShowDialog(m_parent);

                if (subscription != null)
                {
                    if (m_subscription != null)
                    {
                        m_subscription.StatusChanged -= m_StatusChanged;
                        m_subscription.NotificationMessageReceived -= m_NotificationMessageReceived;
                        m_subscription.DataChanged -= m_DataChanged;
                        m_subscription.NewEvents -= m_NewEvents;
                        m_subscription = null;
                    }

                    m_subscription = subscription;
                    m_subscription.StatusChanged += m_StatusChanged;
                    m_subscription.NotificationMessageReceived += m_NotificationMessageReceived;
                    m_subscription.DataChanged += m_DataChanged;
                    m_subscription.NewEvents += m_NewEvents;

                    ModifySubscriptionBTN.Enabled = true;
                    DeleteSubscriptionBTN.Enabled = true;
                    CreateDataMonitoredItemsBTN.Enabled = true;
                    CreateEventMonitoredItemsBTN.Enabled = true;
                    ModifyDataMonitoredItemsBTN.Enabled = true;
                    ModifyEventMonitoredItemsBTN.Enabled = true;
                    DeleteMonitoredItemsBTN.Enabled = true;
                    SetMonitoringModeBTN.Enabled = true;
                    MonitoredConditionsBTN.Enabled = true;
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
                if (m_subscription != null)
                {
                    new ModifySubscriptionDlg().ShowDialog(m_parent, m_subscription);
                }
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
                if (m_subscription != null)
                {
                    if (new DeleteSubscriptionDlg().ShowDialog(m_parent, m_subscription))
                    {
                        if (m_subscription.ConnectionStatus != SubscriptionConnectionStatus.Deleted)
                        {
                            return;
                        }

                        m_subscription.StatusChanged -= m_StatusChanged;
                        m_subscription.NotificationMessageReceived -= m_NotificationMessageReceived;
                        m_subscription.DataChanged -= m_DataChanged;
                        m_subscription.NewEvents -= m_NewEvents;
                        m_subscription = null;

                        MonitoredItemsLV.Items.Clear();

                        ModifySubscriptionBTN.Enabled = false;
                        DeleteSubscriptionBTN.Enabled = false;
                        CreateDataMonitoredItemsBTN.Enabled = false;
                        CreateEventMonitoredItemsBTN.Enabled = false;
                        ModifyDataMonitoredItemsBTN.Enabled = false;
                        ModifyEventMonitoredItemsBTN.Enabled = false;
                        DeleteMonitoredItemsBTN.Enabled = false;
                        SetMonitoringModeBTN.Enabled = false;
                        MonitoredConditionsBTN.Enabled = false;
                    }
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
                if (m_subscription != null)
                {
                    new CreateDataMonitoredItemsDlg().ShowDialog(m_parent, m_subscription);

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

                        AddItem(monitoredItem);
                    }

                    for (int ii = 0; ii < 3; ii++)
                    {
                        MonitoredItemsLV.Columns[ii].Width = -2;
                    }
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
                if (m_subscription != null)
                {
                    new CreateEventMonitoredItemsDlg().ShowDialog(m_parent, m_subscription);

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

                        AddItem(monitoredItem);
                    }

                    for (int ii = 0; ii < 3; ii++)
                    {
                        MonitoredItemsLV.Columns[ii].Width = -2;
                    }
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
                if (m_subscription != null)
                {
                    new ModifyDataMonitoredItemsDlg().ShowDialog(m_parent, m_subscription);

                    foreach (MonitoredItem monitoredItem in m_subscription.MonitoredItems)
                    {
                        UpdateItem(monitoredItem.UserData as ListViewItem, monitoredItem);
                    }

                    for (int ii = 0; ii < 3; ii++)
                    {
                        MonitoredItemsLV.Columns[ii].Width = -2;
                    }
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
                if (m_subscription != null)
                {
                    new ModifyEventMonitoredItemsDlg().ShowDialog(m_parent, m_subscription);

                    foreach (MonitoredItem monitoredItem in m_subscription.MonitoredItems)
                    {
                        UpdateItem(monitoredItem.UserData as ListViewItem, monitoredItem);
                    }

                    for (int ii = 0; ii < 3; ii++)
                    {
                        MonitoredItemsLV.Columns[ii].Width = -2;
                    }
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
                if (m_subscription != null)
                {
                    new DeleteMonitoredItemsDlg().ShowDialog(m_parent, m_subscription);

                    MonitoredItemsLV.Items.Clear();
                    EventsLV.Items.Clear();

                    foreach (MonitoredItem monitoredItem in m_subscription.MonitoredItems)
                    {
                        AddItem(monitoredItem);
                    }

                    for (int ii = 0; ii < 3; ii++)
                    {
                        MonitoredItemsLV.Columns[ii].Width = -2;
                    }
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
                if (m_subscription != null)
                {
                    new SetMonitoringModeDlg().ShowDialog(m_parent, m_subscription);

                    foreach (MonitoredItem monitoredItem in m_subscription.MonitoredItems)
                    {
                        UpdateItem(monitoredItem.UserData as ListViewItem, monitoredItem);
                    }

                    for (int ii = 0; ii < 3; ii++)
                    {
                        MonitoredItemsLV.Columns[ii].Width = -2;
                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void MonitoredConditionsBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_subscription.Session != null)
                {
                    new MonitorConditionsDlg().ShowDialog(m_parent, m_subscription.Session);
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }
        #endregion
    }
}
