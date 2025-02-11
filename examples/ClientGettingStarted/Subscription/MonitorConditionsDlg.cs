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
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;
using UnifiedAutomation.UaClient.Controls;

namespace UnifiedAutomation.ClientGettingStarted
{
    /// <summary>
    /// Shows a dialog which demonstrates a modify monitored items operation.
    /// </summary>
    public partial class MonitorConditionsDlg: Form
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MonitorConditionsDlg"/> class.
        /// </summary>
        public MonitorConditionsDlg()
        {
            InitializeComponent();
            Icon = GuiUtils.GetDefaultIcon();
            CancelButton = this.CancelBTN;
        }
        #endregion

        #region Private Fields
        private MainForm m_parent;
        private Subscription m_subscription;
        private EventMonitoredItem m_monitoredItem;
        #endregion

        #region ConditionState Class
        /// <summary>
        /// A class that stores the state of a condition.
        /// </summary>
        private class ConditionState
        {
            public NodeId ConditionId { get; set; }
            public bool AckRequired { get; set; }
            public NewEvent LastEvent { get; set; }
            public ListViewItem ListItem { get; set; }
        }
        #endregion

        #region Public Interface
        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="subscription">The subscription.</param>
        /// <returns></returns>
        public bool ShowDialog(MainForm parent, Session session)
        {
            m_parent = parent;
            HelpBTN.Enabled = parent != null && parent.HelpExists(GetType());

            // initialize subscription.
            m_subscription = new Subscription(session);

            m_subscription.PublishingInterval = 1000;
            m_subscription.MaxKeepAliveTime = 10000;
            m_subscription.Lifetime = 30000;
            m_subscription.MaxNotificationsPerPublish = 10000;
            m_subscription.Priority = 1;
            m_subscription.PublishingEnabled = true;
            m_subscription.NewEvents += new NewEventsEventHandler(Subscription_NewEvents);

            // create subscription.
            m_subscription.Create(new RequestSettings() { OperationTimeout = 10000 });

            // create the event item.
            m_monitoredItem = new EventMonitoredItem(ObjectIds.Server);

            m_monitoredItem.MonitoringMode = MonitoringMode.Reporting;
            m_monitoredItem.SamplingInterval = 0;
            m_monitoredItem.QueueSize = 1000;
            m_monitoredItem.DiscardOldest = true;
            m_monitoredItem.Filter = new UnifiedAutomation.UaClient.ItemEventFilter(m_subscription.Session.NamespaceUris);

            // build the filter.
            m_monitoredItem.Filter.SelectClauses.Add(ObjectTypeIds.ConditionType, (QualifiedName[])null, NodeClass.Object);
            m_monitoredItem.Filter.SelectClauses.Add(BrowseNames.EventId);
            m_monitoredItem.Filter.SelectClauses.Add(BrowseNames.EventType);
            m_monitoredItem.Filter.SelectClauses.Add(BrowseNames.ConditionName);
            m_monitoredItem.Filter.SelectClauses.Add(BrowseNames.ConditionClassId);
            m_monitoredItem.Filter.SelectClauses.Add(BrowseNames.Time);
            m_monitoredItem.Filter.SelectClauses.Add(BrowseNames.Severity);
            m_monitoredItem.Filter.SelectClauses.Add(BrowseNames.Comment);
            m_monitoredItem.Filter.SelectClauses.Add(BrowseNames.EnabledState);
            m_monitoredItem.Filter.SelectClauses.Add(AbsoluteName.ToString(BrowseNames.EnabledState, BrowseNames.Id));
            m_monitoredItem.Filter.SelectClauses.Add(BrowseNames.AckedState);
            m_monitoredItem.Filter.SelectClauses.Add(AbsoluteName.ToString(BrowseNames.AckedState, BrowseNames.Id));
            m_monitoredItem.Filter.SelectClauses.Add(BrowseNames.ActiveState);
            m_monitoredItem.Filter.SelectClauses.Add(AbsoluteName.ToString(BrowseNames.ActiveState, BrowseNames.Id));

            m_monitoredItem.Filter.WhereClauses.Add(FilterOperator.OfType, new LiteralOperand() { Value = new Variant(ObjectTypeIds.ConditionType) });

            List<MonitoredItem> monitoredItems = new List<MonitoredItem>();
            monitoredItems.Add(m_monitoredItem);

            // create monitored item.
            List<StatusCode> results = m_subscription.CreateMonitoredItems(monitoredItems, new RequestSettings() { OperationTimeout = 10000 });

            if (StatusCode.IsBad(results[0]))
            {
                MessageDialog.Show(this, results[0].ToString());
            }

            // adjust widths.
            foreach (ColumnHeader header in ConditionsLV.Columns)
            {
                header.Width = -2;
            }

            if (ShowDialog() == DialogResult.Cancel)
            {
                return false;
            }

            return true;
        }

        private void Subscription_NewEvents(Subscription subscription, NewEventsEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new NewEventsEventHandler(Subscription_NewEvents), subscription, e);
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
                    ConditionState condition = null;

                    NodeId conditionId = anEvent.MonitoredItem.Filter.GetValue<NodeId>(anEvent.Event, (QualifiedName)null, NodeId.Null);

                    if (NodeId.IsNull(conditionId))
                    {
                        NodeId eventType = anEvent.MonitoredItem.Filter.GetValue<NodeId>(anEvent.Event, BrowseNames.EventType, NodeId.Null);

                        if (eventType == ObjectTypeIds.RefreshStartEventType)
                        {
                            ConditionsLV.Items.Clear();
                        }

                        continue;
                    }

                    foreach (ListViewItem listItem in ConditionsLV.Items)
                    {
                        condition = (ConditionState)listItem.Tag;

                        if (condition.ConditionId == conditionId)
                        {
                            condition.LastEvent = anEvent;
                            UpdateItem(listItem, condition);
                            break;
                        }

                        condition = null;
                    }

                    if (condition == null)
                    {
                        AddItem(new ConditionState() { ConditionId = conditionId, LastEvent = anEvent });
                    }
                }

                foreach (ColumnHeader header in ConditionsLV.Columns)
                {
                    header.Width = -2;
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }
        #endregion

        #region Private Methods
        private ListViewItem AddItem(ConditionState e)
        {
            ListViewItem item = new ListViewItem();
            item.SubItems.Add(String.Empty);
            item.SubItems.Add(String.Empty);
            item.SubItems.Add(String.Empty);
            item.SubItems.Add(String.Empty);
            item.SubItems.Add(String.Empty);
            item.Tag = e;
            e.ListItem = item;
            UpdateItem(item, e);
            ConditionsLV.Items.Add(item);
            return item;
        }

        private void UpdateItem(ListViewItem item, ConditionState e)
        {
            UaClient.ItemEventFilter filter = e.LastEvent.MonitoredItem.Filter;

            string conditionName = filter.GetValue<string>(e.LastEvent.Event, BrowseNames.ConditionName, String.Empty);
            NodeId eventType = filter.GetValue<NodeId>(e.LastEvent.Event, BrowseNames.EventType, NodeId.Null);
            NodeId conditionClass = filter.GetValue<NodeId>(e.LastEvent.Event, BrowseNames.ConditionClassId, NodeId.Null);
            DateTime time = filter.GetValue<DateTime>(e.LastEvent.Event, BrowseNames.Time, DateTime.MinValue);
            ushort severity = filter.GetValue<ushort>(e.LastEvent.Event, BrowseNames.Severity, 0);
            LocalizedText comment = filter.GetValue<LocalizedText>(e.LastEvent.Event, BrowseNames.Comment, LocalizedText.Null);

            LocalizedText state = null;

            bool enabledState = filter.GetValue<bool>(e.LastEvent.Event, AbsoluteName.ToString(BrowseNames.EnabledState, BrowseNames.Id), false);
            bool ackState = filter.GetValue<bool>(e.LastEvent.Event, AbsoluteName.ToString(BrowseNames.AckedState, BrowseNames.Id), false);
            bool activeState = filter.GetValue<bool>(e.LastEvent.Event, AbsoluteName.ToString(BrowseNames.ActiveState, BrowseNames.Id), false);

            if (!enabledState)
            {
                state = filter.GetValue<LocalizedText>(e.LastEvent.Event, BrowseNames.EnabledState, LocalizedText.Null);
            }
            else
            {
                if (!ackState)
                {
                    state = filter.GetValue<LocalizedText>(e.LastEvent.Event, BrowseNames.AckedState, LocalizedText.Null);
                }
                else
                {
                    state = filter.GetValue<LocalizedText>(e.LastEvent.Event, BrowseNames.ActiveState, LocalizedText.Null);
                }
            }

            item.Text = conditionName;

            item.SubItems[1].Text = m_parent.Session.Cache.GetDisplayText(eventType);
            item.SubItems[2].Text = time.ToLocalTime().ToString("HH:mm:ss.fff");
            item.SubItems[3].Text = severity.ToString();
            item.SubItems[4].Text = state.ToString();
            item.SubItems[5].Text = comment.ToString();

            e.AckRequired = !ackState;
        }
        #endregion

        #region Event Handlers
        private void ShowCodeBTN_Click(object sender, EventArgs e)
        {
            try
            {
                m_parent.ShowCode(this.GetType());
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void ShowHelpBTN_Click(object sender, EventArgs e)
        {
            try
            {
                m_parent.ShowHelp(this.GetType());
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void FilterBTN_Click(object sender, EventArgs e)
        {
            try
            {
                EventFilterDlg dialog = new EventFilterDlg();

                dialog.ChangeSession(m_subscription.Session);
                dialog.StartPosition = FormStartPosition.Manual;
                dialog.Size = this.Size;
                dialog.Location = this.Location;

                UaClient.ItemEventFilter filter = dialog.ShowDialog(m_monitoredItem.Filter);

                if (filter != null)
                {
                    m_monitoredItem.Filter = filter;
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void RefreshBTN_Click(object sender, EventArgs e)
        {
            try
            {
                List<Variant> inputArguments = new List<Variant>();
                inputArguments.Add(new Variant(m_subscription.SubscriptionId));

                List<StatusCode> inputArgumentErrors;
                List<Variant> outputArguments;

                m_subscription.Session.Call(
                    ObjectTypeIds.ConditionType,
                    MethodIds.ConditionType_ConditionRefresh,
                    inputArguments,
                    null,
                    out inputArgumentErrors,
                    out outputArguments);
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void ConditionsLV_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                foreach (ListViewItem item in ConditionsLV.Items)
                {
                    if (item.Checked)
                    {
                        ConditionState state = (ConditionState)item.Tag;

                        if (state.AckRequired)
                        {
                            AcknowledgeBTN.Enabled = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void AcknowledgeBTN_Click(object sender, EventArgs e)
        {
            try
            {
                List<ConditionState> conditions = new List<ConditionState>();

                foreach (ListViewItem item in ConditionsLV.Items)
                {
                    if (item.Checked)
                    {
                        conditions.Add((ConditionState)item.Tag);
                    }
                }

                if (conditions.Count == 0)
                {
                    return;
                }

                object value = new EditComplexValueDlg().ShowDialog("Comment", new LocalizedText(), "Acknowledge Conditions", false);

                if (value == null)
                {
                    return;
                }

                List<CallMethodRequest> requests = new List<CallMethodRequest>();

                foreach (ConditionState condition in conditions)
                {
                    CallMethodRequest request = new CallMethodRequest()
                    {
                        ObjectId = condition.ConditionId,
                        MethodId = MethodIds.AcknowledgeableConditionType_Acknowledge,
                    };

                    request.InputArguments.Add(new Variant(condition.LastEvent.Event.EventId, TypeInfo.Scalars.ByteString));
                    request.InputArguments.Add(new Variant(value, TypeInfo.Scalars.LocalizedText));

                    requests.Add(request);
                }

                List<CallMethodResult> results = m_subscription.Session.CallList(requests, new RequestSettings() { OperationTimeout = 10000 });

                for (int ii = 0; ii < results.Count; ii++)
                {
                    if (StatusCode.IsBad(results[ii].StatusCode))
                    {
                        conditions[ii].ListItem.SubItems[5].Text = results[ii].StatusCode.ToString();
                    }
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
