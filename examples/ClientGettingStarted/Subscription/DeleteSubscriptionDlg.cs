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
    /// Shows a dialog which demonstrates a create subscription operation.
    /// </summary>
    public partial class DeleteSubscriptionDlg : Form
    {
        /// <summary>
        /// Synchronously deletes a subscription.
        /// </summary>
        private void Delete()
        {
            /// [Delete Subscription]
            try
            {
                // get the current session from the parent form.
                Session session = m_parent.Session;

                // nothing to do if no session.
                if (session == null)
                {
                    return;
                }

                // delete subscription (10s timeout).
                m_subscription.Delete(new RequestSettings() { OperationTimeout = 10000 });

                // up date display.
                CurrentStateTB.Text = m_subscription.ConnectionStatus.ToString();
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            /// [Delete Subscription]
        }

        /// <summary>
        /// Asynchronously deletes a subscription.
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

                // delete subscription (10s timeout).
                m_subscription.BeginDelete(
                    new RequestSettings() { OperationTimeout = 10000 },
                    OnDeleteSubscriptionComplete,
                    m_subscription);
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        /// <summary>
        /// Finishes an asynchronous delete subscription request.
        /// </summary>
        private void OnDeleteSubscriptionComplete(IAsyncResult result)
        {
            // need to make sure the results are processed on the correct thread.
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnDeleteSubscriptionComplete), result);
                return;
            }

            // get the subscription used to send the request which was passed as the userData in the Begin call.
            Subscription subscription = (Subscription)result.AsyncState;

            try
            {
                // get the results.
                subscription.EndDelete(result);

                // don't update the controls if the subscription has changed.
                if (!Object.ReferenceEquals(subscription, m_subscription))
                {
                    return;
                }

                // up date display.
                CurrentStateTB.Text = m_subscription.ConnectionStatus.ToString();
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
        /// Initializes a new instance of the <see cref="DeleteSubscriptionDlg"/> class.
        /// </summary>
        public DeleteSubscriptionDlg()
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
            CurrentStateTB.Text = m_subscription.ConnectionStatus.ToString();
            base.ShowDialog();
            return true;
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
