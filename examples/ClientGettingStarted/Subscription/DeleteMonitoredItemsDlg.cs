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
    /// Shows a dialog which demonstrates a delete monitored items operation.
    /// </summary>
    public partial class DeleteMonitoredItemsDlg : Form
    {
        /// <summary>
        /// Synchronously deletes a set of monitored items.
        /// </summary>
        private void Delete()
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

                /// [Delete Monitored Items]
                // delete monitored items.
                List<StatusCode> results = m_subscription.DeleteMonitoredItems(
                    monitoredItems,
                    new RequestSettings() { OperationTimeout = 10000 });
                /// [Delete Monitored Items]

                // update results in the list.
                for (int ii = 0; ii < results.Count; ii++)
                {
                    if (StatusCode.IsGood(results[ii]))
                    {
                        items[ii].Remove();
                        continue;
                    }

                    UpdateItem((ListViewItem)monitoredItems[ii].UserData, monitoredItems[ii]);
                }

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
        /// Asynchronously deletes a set of monitored items.
        /// </summary>
        private void BeginDelete()
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

                // delete monitored items.
                m_subscription.BeginDeleteMonitoredItems(
                    monitoredItems,
                    new RequestSettings() { OperationTimeout = 10000 },
                    OnDeleteMonitoredItemsComplete,
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
        private void OnDeleteMonitoredItemsComplete(IAsyncResult result)
        {
            // need to make sure the results are processed on the correct thread.
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnDeleteMonitoredItemsComplete), result);
                return;
            }

            // get the subscription used to send the request which was passed as the userData in the Begin call.
            AsyncState state = (AsyncState)result.AsyncState;

            try
            {
                // get the results.
                List<StatusCode> results = state.Subscription.EndDeleteMonitoredItems(result);

                // don't update the controls if the subscription has changed.
                if (!Object.ReferenceEquals(state.Subscription, m_subscription))
                {
                    return;
                }

                // update results in the list.
                for (int ii = 0; ii < results.Count; ii++)
                {
                    if (StatusCode.IsGood(results[ii]))
                    {
                        state.Items[ii].Remove();
                        continue;
                    }

                    UpdateItem(state.Items[ii], state.MonitoredItems[ii]);
                }

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
        /// Initializes a new instance of the <see cref="DeleteMonitoredItemsDlg"/> class.
        /// </summary>
        public DeleteMonitoredItemsDlg()
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
        #endregion

        #region Event Handlers
        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UseAsynchCK.Checked)
                {
                    Delete();
                }
                else
                {
                    BeginDelete();
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
        #endregion
    }
}
