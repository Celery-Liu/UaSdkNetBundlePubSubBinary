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
    public partial class ModifyEventMonitoredItemsDlg : Form
    {
        /// <summary>
        /// Synchronously modifies a set of monitored items.
        /// </summary>
        private void Modify()
        {
            /// [Modify Event Monitored Items]
            try
            {
                // get the current session from the parent form.
                Session session = m_parent.Session;

                // nothing to do if no session.
                if (session == null)
                {
                    return;
                }

                // build list of items have been checked.
                List<ListViewItem> items = new List<ListViewItem>();
                List<MonitoredItem> monitoredItems = new List<MonitoredItem>();

                foreach (ListViewItem item in MonitoredItemsLV.Items)
                {
                    if (item.Checked)
                    {
                        MonitoredItem monitoredItem = (MonitoredItem)item.Tag;
                        monitoredItems.Add(monitoredItem);
                        items.Add(item);
                    }
                }

                // create monitored items.
                List<StatusCode> results = m_subscription.ModifyMonitoredItems(
                    monitoredItems,
                    new RequestSettings() { OperationTimeout = 10000 });

                // update results in the list.
                for (int ii = 0; ii < results.Count; ii++)
                {
                    UpdateItem(items[ii], monitoredItems[ii]);
                }

                // display current values.
                UpdateControls(monitoredItems);

                // adjust widths.
                foreach (ColumnHeader header in MonitoredItemsLV.Columns)
                {
                    header.Width = -2;
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            /// [Modify Event Monitored Items]
        }

        /// <summary>
        /// Asynchronously modifies a set of monitored items.
        /// </summary>
        private void BeginModify()
        {
            try
            {
                // get the current session from the parent form.
                Session session = m_parent.Session;

                // nothing to do if no session.
                if (session == null)
                {
                    return;
                }

                // build list of items have been checked.
                List<ListViewItem> items = new List<ListViewItem>();
                List<MonitoredItem> monitoredItems = new List<MonitoredItem>();

                foreach (ListViewItem item in MonitoredItemsLV.Items)
                {
                    if (item.Checked)
                    {
                        MonitoredItem monitoredItem = (MonitoredItem)item.Tag;
                        monitoredItems.Add(monitoredItem);
                        items.Add(item);
                    }
                }

                // modify monitored items.
                m_subscription.BeginModifyMonitoredItems(
                    monitoredItems,
                    new RequestSettings() { OperationTimeout = 10000 },
                    OnModifyMonitoredItemsComplete,
                    new AsyncState() { Subscription = m_subscription, Items = items, MonitoredItems = monitoredItems });
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        /// <summary>
        /// Finishes an asynchronous modify monitored item request.
        /// </summary>
        private void OnModifyMonitoredItemsComplete(IAsyncResult result)
        {
            // need to make sure the results are processed on the correct thread.
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnModifyMonitoredItemsComplete), result);
                return;
            }

            // get the subscription used to send the request which was passed as the userData in the Begin call.
            AsyncState state = (AsyncState)result.AsyncState;

            try
            {
                // get the results.
                List<StatusCode> results = state.Subscription.EndModifyMonitoredItems(result);

                // don't update the controls if the subscription has changed.
                if (!Object.ReferenceEquals(state.Subscription, m_subscription))
                {
                    return;
                }

                // update results in the list.
                for (int ii = 0; ii < results.Count; ii++)
                {
                    UpdateItem(state.Items[ii], state.MonitoredItems[ii]);
                }

                // display current values.
                UpdateControls(state.MonitoredItems);

                // adjust widths.
                foreach (ColumnHeader header in MonitoredItemsLV.Columns)
                {
                    header.Width = -2;
                }
            }
            catch (Exception exception)
            {
                // don't display any error if the subscription has changed.
                if (Object.ReferenceEquals(state.Subscription, m_subscription) && Visible)
                {
                    ExceptionDlg.ShowInnerException(this.Text, exception);
                }
            }
        }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ModifyEventMonitoredItemsDlg"/> class.
        /// </summary>
        public ModifyEventMonitoredItemsDlg()
        {
            InitializeComponent();
            Icon = GuiUtils.GetDefaultIcon();
            CancelButton = this.CancelBTN;
        }
        #endregion

        #region Private Fields
        private MainForm m_parent;
        private Subscription m_subscription;
        #endregion

        #region AsyncState Class
        /// <summary>
        /// A class that stores the state of the asynchronous operation.
        /// </summary>
        private class AsyncState
        {
            public Subscription Subscription { get; set; }
            public List<ListViewItem> Items { get; set; }
            public List<MonitoredItem> MonitoredItems { get; set; }
        }
        #endregion

        #region Public Interface
        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="subscription">The subscription.</param>
        /// <returns></returns>
        public bool ShowDialog(MainForm parent, Subscription subscription)
        {
            m_parent = parent;
            HelpBTN.Enabled = parent != null && parent.HelpExists(GetType());
            m_subscription = subscription;
            InstructionsLB.Text = parent.GetInstructions(this.GetType());

            // list the current items.
            foreach (MonitoredItem monitoredItem in m_subscription.MonitoredItems)
            {
                if (monitoredItem is EventMonitoredItem)
                {
                    AddItem(monitoredItem);
                }
            }

            // adjust widths.
            foreach (ColumnHeader header in MonitoredItemsLV.Columns)
            {
                header.Width = -2;
            }

            if (ShowDialog() == DialogResult.Cancel)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region Private Methods
        private ListViewItem AddItem(MonitoredItem monitoredItem)
        {
            ListViewItem item = new ListViewItem();
            item.SubItems.Add(String.Empty);
            item.SubItems.Add(String.Empty);
            item.SubItems.Add(String.Empty);
            item.Tag = monitoredItem;
            UpdateItem(item, monitoredItem);
            MonitoredItemsLV.Items.Add(item);
            ModifyBTN.Enabled = true;
            return item;
        }

        private void UpdateItem(ListViewItem item, MonitoredItem monitoredItem)
        {
            item.Text = "[" + ((monitoredItem.ServerHandle == 0) ? "---" : monitoredItem.ServerHandle.ToString("000")) + "]";
            item.SubItems[1].Text = m_subscription.Session.Cache.GetDisplayText(monitoredItem.NodeId);
            item.SubItems[2].Text = Attributes.GetDisplayText(monitoredItem.AttributeId);
            item.SubItems[3].Text = monitoredItem.LastError.ToString();
        }

        private void UpdateControls(IList<MonitoredItem> monitoredItems)
        {
            CurrentSamplingIntervalTB.Text = String.Empty;
            CurrentQueueSizeTB.Text = String.Empty;
            CurrentDiscardOldestCK.CheckState = CheckState.Indeterminate;

            // set the values for the first item.
            if (monitoredItems.Count > 0)
            {
                CurrentSamplingIntervalTB.Text = monitoredItems[0].CurrentSamplingInterval.ToString();
                CurrentQueueSizeTB.Text = monitoredItems[0].CurrentQueueSize.ToString();
                CurrentDiscardOldestCK.CheckState = (monitoredItems[0].CurrentDiscardOldest) ? CheckState.Checked : CheckState.Unchecked;
            }

            // set values to * if they are ambiguous.
            for (int ii = 1; ii < monitoredItems.Count; ii++)
            {
                if (monitoredItems[ii].CurrentSamplingInterval.ToString() != CurrentSamplingIntervalTB.Text)
                {
                    CurrentSamplingIntervalTB.Text = "*";
                }

                if (monitoredItems[ii].CurrentQueueSize.ToString() != CurrentQueueSizeTB.Text)
                {
                    CurrentQueueSizeTB.Text = "*";
                }

                if (((monitoredItems[ii].CurrentDiscardOldest) ? CheckState.Checked : CheckState.Unchecked) != CurrentDiscardOldestCK.CheckState)
                {
                    CurrentDiscardOldestCK.CheckState = CheckState.Indeterminate;
                }
            }
        }
        #endregion

        #region Event Handlers
        private void ModifyBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UseAsynchCK.Checked)
                {
                    Modify();
                }
                else
                {
                    BeginModify();
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

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

        private void MonitoredItemsLV_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                List<MonitoredItem> monitoredItems = new List<MonitoredItem>();

                foreach (ListViewItem item in MonitoredItemsLV.Items)
                {
                    if (!item.Checked)
                    {
                        continue;
                    }

                    monitoredItems.Add((MonitoredItem)item.Tag);
                }

                UpdateControls(monitoredItems);
                EventFilterBTN.Enabled = (monitoredItems.Count != 0);
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void EventFilterBTN_Click(object sender, EventArgs e)
        {
            try
            {
                List<EventMonitoredItem> monitoredItems = new List<EventMonitoredItem>();

                foreach (ListViewItem item in MonitoredItemsLV.Items)
                {
                    if (!item.Checked && item.Tag is EventMonitoredItem)
                    {
                        continue;
                    }

                    monitoredItems.Add((EventMonitoredItem)item.Tag);
                }

                if (monitoredItems.Count == 0)
                {
                    return;
                }

                EventFilterDlg dialog = new EventFilterDlg();

                dialog.ChangeSession(m_subscription.Session);
                dialog.StartPosition = FormStartPosition.Manual;
                dialog.Size = this.Size;
                dialog.Location = this.Location;

                UaClient.ItemEventFilter filter = dialog.ShowDialog(monitoredItems[0].Filter);

                if (filter != null)
                {
                    foreach (EventMonitoredItem monitoredItem in monitoredItems)
                    {
                        monitoredItem.Filter = filter;
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
