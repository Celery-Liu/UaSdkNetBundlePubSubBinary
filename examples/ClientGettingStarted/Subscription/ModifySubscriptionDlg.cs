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
    /// Shows a dialog which demonstrates a modify subscription operation.
    /// </summary>
    public partial class ModifySubscriptionDlg : Form
    {
        /// <summary>
        /// Synchronously modifies a subscription.
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

                /// [Modify Subscription]
                // initialize subscription.
                m_subscription.PublishingInterval = (double)PublishingIntervalUD.Value;
                m_subscription.MaxKeepAliveTime = (double)KeepAliveTimeUD.Value;
                m_subscription.Lifetime = (double)LifeTimeUD.Value;
                m_subscription.MaxNotificationsPerPublish = (uint)MaxNotificationsUD.Value;
                m_subscription.Priority = (byte)PriorityUD.Value;
                m_subscription.PublishingEnabled = PublishingEnabledCK.Checked;

                // modify subscription.
                m_subscription.Modify(new RequestSettings() { OperationTimeout = 10000 });

                // update controls.
                CurrentPublishingIntervalTB.Text = m_subscription.CurrentPublishingInterval.ToString();
                CurrentKeepAliveTimeTB.Text = m_subscription.CurrentMaxKeepAliveTime.ToString();
                CurrentLifeTimeTB.Text = m_subscription.CurrentLifetime.ToString();
                CurrentMaxNotificationsTB.Text = m_subscription.CurrentMaxNotificationsPerPublish.ToString();
                CurrentPriorityTB.Text = m_subscription.CurrentPriority.ToString();
                CurrentPublishingEnabledCK.Checked = m_subscription.CurrentPublishingEnabled;
                /// [Modify Subscription]
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
        /// Asynchronously modifies a subscription.
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

                // initialize subscription.
                m_subscription.PublishingInterval = (double)PublishingIntervalUD.Value;
                m_subscription.MaxKeepAliveTime = (double)KeepAliveTimeUD.Value;
                m_subscription.Lifetime = (double)LifeTimeUD.Value;
                m_subscription.MaxNotificationsPerPublish = (uint)MaxNotificationsUD.Value;
                m_subscription.Priority = (byte)PriorityUD.Value;
                m_subscription.PublishingEnabled = PublishingEnabledCK.Checked;

                // modify subscription.
                m_subscription.BeginModify(
                    new RequestSettings() { OperationTimeout = 10000 },
                    OnModifySubscriptionComplete,
                    m_subscription);
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        /// <summary>
        /// Finishes an asynchronous modify subscription request.
        /// </summary>
        private void OnModifySubscriptionComplete(IAsyncResult result)
        {
            // need to make sure the results are processed on the correct thread.
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnModifySubscriptionComplete), result);
                return;
            }

            // get the subscription used to send the request which was passed as the userData in the Begin call.
            Subscription subscription = (Subscription)result.AsyncState;

            try
            {
                // get the results.
                subscription.EndModify(result);

                // don't update the controls if the subscription has changed.
                if (!Object.ReferenceEquals(subscription, m_subscription))
                {
                    return;
                }

                // update controls.
                CurrentPublishingIntervalTB.Text = m_subscription.CurrentPublishingInterval.ToString();
                CurrentKeepAliveTimeTB.Text = m_subscription.CurrentMaxKeepAliveTime.ToString();
                CurrentLifeTimeTB.Text = m_subscription.CurrentLifetime.ToString();
                CurrentMaxNotificationsTB.Text = m_subscription.CurrentMaxKeepAliveTime.ToString();
                CurrentPriorityTB.Text = m_subscription.CurrentPriority.ToString();
                CurrentPublishingEnabledCK.Checked = m_subscription.CurrentPublishingEnabled;
            }
            catch (Exception exception)
            {
                // don't display any error if the subscription has changed.
                if (Object.ReferenceEquals(subscription, m_subscription) && Visible)
                {
                    ExceptionDlg.ShowInnerException(this.Text, exception);
                }
            }
        }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ModifySubscriptionDlg"/> class.
        /// </summary>
        public ModifySubscriptionDlg()
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

        #region Public Interface
        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public bool ShowDialog(MainForm parent, Subscription subscription)
        {
            m_parent = parent;
            HelpBTN.Enabled = parent != null && parent.HelpExists(GetType());
            m_subscription = subscription;

            InstructionsLB.Text = parent.GetInstructions(this.GetType());

            // initialize controls.
            PublishingIntervalUD.Value = (decimal)m_subscription.CurrentPublishingInterval;
            KeepAliveTimeUD.Value = (decimal)m_subscription.CurrentMaxKeepAliveTime;
            LifeTimeUD.Value = (decimal)m_subscription.CurrentLifetime;
            MaxNotificationsUD.Value = (decimal)m_subscription.MaxNotificationsPerPublish;
            PriorityUD.Value = m_subscription.CurrentPriority;
            PublishingEnabledCK.Checked = m_subscription.PublishingEnabled;

            CurrentPublishingIntervalTB.Text = m_subscription.CurrentPublishingInterval.ToString();
            CurrentKeepAliveTimeTB.Text = m_subscription.CurrentMaxKeepAliveTime.ToString();
            CurrentLifeTimeTB.Text = m_subscription.CurrentLifetime.ToString();
            CurrentMaxNotificationsTB.Text = m_subscription.MaxNotificationsPerPublish.ToString();
            CurrentPriorityTB.Text = m_subscription.CurrentPriority.ToString();
            CurrentPublishingEnabledCK.Checked = m_subscription.CurrentPublishingEnabled;

            base.ShowDialog();
            return true;
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
        #endregion
    }
}
