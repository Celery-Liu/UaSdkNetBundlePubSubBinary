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

namespace UnifiedAutomation.ClientGettingStarted
{
    /// <summary>
    /// Shows a dialog which demonstrates a set monitoring mode operation.
    /// </summary>
    public partial class SetMonitoringModeDlg : Form
    {
        /// <summary>
        /// Synchronously sets monitoring mode for a set of monitored items.
        /// </summary>
        private void Modify()
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

                /// [Set Monitoring Mode]
                // create monitored items.
                List<StatusCode> results = m_subscription.SetMonitoringMode(
                    (MonitoringMode)MonitoringModeCB.SelectedItem,
                    monitoredItems,
                    new RequestSettings() { OperationTimeout = 10000 });
                /// [Set Monitoring Mode]

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
        }

        /// <summary>
        /// Asynchronously sets monitoring mode for a set of monitored items.
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

                // set the monitoring mode.
                m_subscription.BeginSetMonitoringMode(
                    (MonitoringMode)MonitoringModeCB.SelectedItem,
                    monitoredItems,
                    new RequestSettings() { OperationTimeout = 10000 },
                    OnSetMonitoringModeComplete,
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
        private void OnSetMonitoringModeComplete(IAsyncResult result)
        {
            // need to make sure the results are processed on the correct thread.
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnSetMonitoringModeComplete), result);
                return;
            }

            // get the subscription used to send the request which was passed as the userData in the Begin call.
            AsyncState state = (AsyncState)result.AsyncState;

            try
            {
                // get the results.
                List<StatusCode> results = state.Subscription.EndSetMonitoringMode(result);

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
        /// Initializes a new instance of the <see cref="SetMonitoringModeDlg"/> class.
        /// </summary>
        public SetMonitoringModeDlg()
        {
            InitializeComponent();
            Icon = GuiUtils.GetDefaultIcon();
            CancelButton = this.CancelBTN;

            MonitoringModeCB.Items.Add(MonitoringMode.Reporting);
            MonitoringModeCB.Items.Add(MonitoringMode.Sampling);
            MonitoringModeCB.Items.Add(MonitoringMode.Disabled);
            MonitoringModeCB.SelectedIndex = 0;
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
                AddItem(monitoredItem);
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
            CurrentMonitoringModeTB.Text = String.Empty;

            // set the values for the first item.
            if (monitoredItems.Count > 0)
            {
                CurrentMonitoringModeTB.Text = monitoredItems[0].CurrentMonitoringMode.ToString();
            }

            // set values to * if they are ambiguous.
            for (int ii = 1; ii < monitoredItems.Count; ii++)
            {
                if (monitoredItems[ii].CurrentMonitoringMode.ToString() != CurrentMonitoringModeTB.Text)
                {
                    CurrentMonitoringModeTB.Text = "*";
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
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }
        #endregion
    }
}
