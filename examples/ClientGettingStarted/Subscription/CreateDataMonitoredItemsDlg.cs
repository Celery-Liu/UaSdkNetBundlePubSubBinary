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
    /// Shows a dialog which demonstrates a create monitored items operation.
    /// </summary>
    public partial class CreateDataMonitoredItemsDlg : Form
    {
        /// <summary>
        /// Synchronously creates the monitored items.
        /// </summary>
        private void Create()
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

                /// [Create Data Monitored Items]
                // build list of items which have not been added yet.
                List<MonitoredItem> monitoredItems = new List<MonitoredItem>();

                foreach (ListViewItem item in MonitoredItemsLV.Items)
                {
                    MonitoredItem monitoredItem = (MonitoredItem)item.Tag;

                    if (monitoredItem.ClientHandle == 0)
                    {
                        monitoredItem.UserData = item;
                        monitoredItems.Add(monitoredItem);
                    }
                }

                // create monitored items.
                List<StatusCode> results = m_subscription.CreateMonitoredItems(
                    monitoredItems,
                    new RequestSettings() { OperationTimeout = 10000 });
                /// [Create Data Monitored Items]

                // update results in the list.
                for (int ii = 0; ii < results.Count; ii++)
                {
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
        /// Asynchronously creates the monitored items.
        /// </summary>
        private void BeginCreate()
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

                // build list of items which have not been added yet.
                List<MonitoredItem> monitoredItems = new List<MonitoredItem>();

                foreach (ListViewItem item in MonitoredItemsLV.Items)
                {
                    MonitoredItem monitoredItem = (MonitoredItem)item.Tag;

                    if (monitoredItem.ClientHandle == 0)
                    {
                        monitoredItem.UserData = item;
                        monitoredItems.Add(monitoredItem);
                    }
                }

                // create monitored items.
                m_subscription.BeginCreateMonitoredItems(
                    monitoredItems,
                    new RequestSettings() { OperationTimeout = 10000 },
                    OnCreateMonitoredItemsComplete,
                    new AsyncState() { Subscription = m_subscription, MonitoredItems = monitoredItems });
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        /// <summary>
        /// Finishes an asynchronous create subscription request.
        /// </summary>
        private void OnCreateMonitoredItemsComplete(IAsyncResult result)
        {
            // need to make sure the results are processed on the correct thread.
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnCreateMonitoredItemsComplete), result);
                return;
            }

            // get the subscription used to send the request which was passed as the userData in the Begin call.
            AsyncState state = (AsyncState)result.AsyncState;

            try
            {
                // get the results.
                List<StatusCode> results = state.Subscription.EndCreateMonitoredItems(result);

                // don't update the controls if the subscription has changed.
                if (!Object.ReferenceEquals(state.Subscription, m_subscription))
                {
                    return;
                }

                // update results in the list.
                for (int ii = 0; ii < results.Count; ii++)
                {
                    UpdateItem((ListViewItem)state.MonitoredItems[ii].UserData, state.MonitoredItems[ii]);
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
        /// Initializes a new instance of the <see cref="CreateMonitoredItemsDlg"/> class.
        /// </summary>
        public CreateDataMonitoredItemsDlg()
        {
            InitializeComponent();
            Icon = GuiUtils.GetDefaultIcon();
            CancelButton = this.CancelBTN;

            MonitoringModeCB.Items.Add(MonitoringMode.Reporting);
            MonitoringModeCB.Items.Add(MonitoringMode.Sampling);
            MonitoringModeCB.Items.Add(MonitoringMode.Disabled);
            MonitoringModeCB.SelectedIndex = 0;

            DeadbandTypeCB.Items.Add(DeadbandType.None);
            DeadbandTypeCB.Items.Add(DeadbandType.Absolute);
            DeadbandTypeCB.Items.Add(DeadbandType.Percent);
            DeadbandTypeCB.SelectedIndex = 0;
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
            CreateBTN.Enabled = true;
            return item;
        }

        private ListViewItem AddItem(NodeId nodeId, uint attributeId, NodeClass nodeClass)
        {
            // select a suitable attribute if none provided.
            if (attributeId == 0)
            {
                switch (nodeClass)
                {
                    case NodeClass.Variable:
                    case NodeClass.VariableType:
                    {
                        attributeId = Attributes.Value;
                        break;
                    }

                    default:
                    {
                        attributeId = Attributes.DisplayName;
                        break;
                    }
                }
            }

            // create the data item.
            DataMonitoredItem monitoredItem = new DataMonitoredItem(nodeId, attributeId);

            monitoredItem.MonitoringMode = (MonitoringMode)MonitoringModeCB.SelectedItem;
            monitoredItem.SamplingInterval = (double)SamplingIntervalUD.Value;
            monitoredItem.QueueSize = (uint)QueueSizeUD.Value;
            monitoredItem.DiscardOldest = DiscardOldestCK.Checked;
            monitoredItem.DeadbandType = (DeadbandType)DeadbandTypeCB.SelectedItem;
            monitoredItem.Deadband = (double)DeadbandUD.Value;

           return AddItem(monitoredItem);
        }

        private void UpdateControls(IList<MonitoredItem> monitoredItems)
        {
            CurrentSamplingIntervalTB.Text = String.Empty;
            CurrentQueueSizeTB.Text = String.Empty;
            CurrentDiscardOldestCK.CheckState = CheckState.Indeterminate;
            CurrentMonitoringModeTB.Text = String.Empty;
            CurrentDeadbandTypeTB.Text = String.Empty;
            CurrentDeadbandTB.Text = String.Empty;

            // set the values for the first item.
            if (monitoredItems.Count > 0)
            {
                CurrentSamplingIntervalTB.Text = monitoredItems[0].CurrentSamplingInterval.ToString();
                CurrentQueueSizeTB.Text = monitoredItems[0].CurrentQueueSize.ToString();
                CurrentDiscardOldestCK.CheckState = (monitoredItems[0].CurrentDiscardOldest) ? CheckState.Checked : CheckState.Unchecked;
                CurrentMonitoringModeTB.Text = monitoredItems[0].CurrentMonitoringMode.ToString();

                DataMonitoredItem dataItem = monitoredItems[0] as DataMonitoredItem;

                if (dataItem != null)
                {
                    CurrentDeadbandTypeTB.Text = dataItem.CurrentDeadbandType.ToString();
                    CurrentDeadbandTB.Text = dataItem.CurrentDeadband.ToString();
                }
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

                if (monitoredItems[ii].CurrentMonitoringMode.ToString() != CurrentMonitoringModeTB.Text)
                {
                    CurrentMonitoringModeTB.Text = "*";
                }

                DataMonitoredItem dataItem = monitoredItems[ii] as DataMonitoredItem;

                if (dataItem != null)
                {
                    if (dataItem.CurrentDeadbandType.ToString() != CurrentDeadbandTypeTB.Text)
                    {
                        CurrentDeadbandTypeTB.Text = "*";
                    }

                    if (dataItem.CurrentDeadband.ToString() != CurrentDeadbandTB.Text)
                    {
                        CurrentDeadbandTB.Text = "*";
                    }
                }
            }
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
        private void CreateBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UseAsynchCK.Checked)
                {
                    Create();
                }
                else
                {
                    BeginCreate();
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

        private void SelectNodeBTN_Click(object sender, EventArgs e)
        {
            try
            {
                UnifiedAutomation.UaClient.Controls.BrowseDlg dialog = new UnifiedAutomation.UaClient.Controls.BrowseDlg();

                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.Size = new Size(this.Width, Math.Max(400, this.Height));
                dialog.Location = this.Location;

                uint nodeClassMask = (uint)(NodeClass.ObjectType | NodeClass.Variable | NodeClass.Object);
                NodeId nodeId = dialog.ShowDialog(m_parent.Session, ObjectIds.ObjectsFolder, ReferenceTypeIds.HierarchicalReferences, nodeClassMask);

                if (nodeId != null)
                {
                    AddItem(nodeId, Attributes.Value, NodeClass.Unspecified).Selected = true;

                    // adjust widths.
                    foreach (ColumnHeader header in MonitoredItemsLV.Columns)
                    {
                        header.Width = -2;
                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void MonitoredItemsLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<MonitoredItem> monitoredItems = new List<MonitoredItem>();

                foreach (ListViewItem item in MonitoredItemsLV.Items)
                {
                    if (!item.Selected)
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
