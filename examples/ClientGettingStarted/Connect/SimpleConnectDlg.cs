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
using UnifiedAutomation.UaClient;
using UnifiedAutomation.UaBase;
using System.Threading;

namespace UnifiedAutomation.ClientGettingStarted
{
    /// <summary>
    /// Shows a dialog which demonstrates how to connect to a server. It shows the usage of the
    /// simple Connect method and the usage of the EventHandlers related to connecting
    /// to a server.
    /// </summary>
    public partial class SimpleConnectDlg : Form
    {
        /// [Connect 2]
        internal class ConnectData
        {
            public Session Session;
            public string EndpointUrl;
            public SecuritySelection Security;
        }

        public delegate void ShowExceptionDelegate(string text, Exception e);

        private void ShowException(string text, Exception e)
        {
            ExceptionDlg.ShowInnerException(text, e);
        }

        private void OnConnect(object state)
        {
            if (state == null)
            {
                return;
            }
            ConnectData data = state as ConnectData;
            if (data == null)
            {
                return;
            }
            try
            {
                data.Session.Connect(data.EndpointUrl, data.Security);
            }
            catch (Exception e)
            {
                if (InvokeRequired)
                {
                    Invoke(new ShowExceptionDelegate(ShowException), this.Text, e);
                    return;
                }
                ExceptionDlg.ShowInnerException(this.Text, e);
            }
        }
        /// [Connect 2]
        /// <summary>
        /// Synchronously connects to the server
        /// </summary>
        /// [Connect]
        private void Connect()
        {
            try
            {
                // need to watch out for deadlocks if the GUI thread blocks.
                // This check is necessary if m_session.Connect is called from the GUI thread (== called in this method)
                //if (EnableUpdateEndpointEventHandler.Checked)
                //{
                //    MessageDialog.Show(this, "Cannot use synchronous calls when expecting the UpdateEndpoint callback because a deadlock occurs when the callback tries to display the dialog.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return;
                //}

                // disconnect any existing session.
                if (m_session.ConnectionStatus != ServerConnectionStatus.Disconnected)
                {
                    m_session.Disconnect();
                }

                // Call the connect method from another thread to avoid threading problems
                // Possible problems are
                // - The UpdateEndpoint EventHandler opens a dialog
                // - The UntrustedCertificate EventHandler of the ApplicationInstance opens a dialog
                Thread t = new Thread(new ParameterizedThreadStart(OnConnect));
                t.Start(new ConnectData()
                {
                    Session = m_session,
                    EndpointUrl = EndpointUrl,
                    Security = SecuritySelection
                });

                // Call Connect from the GUI thread
                //m_session.Connect(EndpointUrl, SecuritySelection);
            }
            catch (Exception e)
            {
                ExceptionDlg.ShowInnerException(this.Text, e);
            }
        }
        /// [Connect]

        /// <summary>
        /// Asynchronously connects to the server
        /// </summary>
        /// [BeginConnect]
        private void BeginConnect()
        {
            try
            {
                // disconnect any existing session.
                if (m_session.ConnectionStatus != ServerConnectionStatus.Disconnected)
                {
                    m_session.Disconnect();
                }

                m_session.BeginConnect(
                    EndpointUrl,
                    SecuritySelection,
                    null,
                    RetryInitialConnect.Yes,
                    m_session.DefaultRequestSettings,
                    OnConnectCompleted,
                    m_session);
            }
            catch (Exception e)
            {
                ExceptionDlg.ShowInnerException(this.Text, e);
            }
        }

        /// <summary>
        /// Finishes an asynchronous connect request.
        /// </summary>
        private void OnConnectCompleted(IAsyncResult result)
        {
            // need to make sure the results are processed on the correct thread.
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnConnectCompleted), result);
                return;
            }

            // get the session used to send the request which was passed as the userData in the Begin call.
            Session session = (Session)result.AsyncState;

            try
            {
                session.EndConnect(result);
            }
            catch (Exception e)
            {
                ExceptionDlg.ShowInnerException(this.Text, e);
            }
        }
        /// [BeginConnect]

        /// <summary>
        /// Synchronously disconnects from the server
        /// </summary>
        private void Disconnect()
        {
            try
            {
                m_session.Disconnect();
            }
            catch (Exception e)
            {
                ExceptionDlg.ShowInnerException(this.Text, e);
            }
        }

        /// <summary>
        /// Asynchronously disconnects from the server
        /// </summary>
        private void BeginDisconnect()
        {
            try
            {
                m_session.BeginDisconnect(OnDisconnectCompleted, m_session);
            }
            catch (Exception e)
            {
                ExceptionDlg.ShowInnerException(this.Text, e);
            }
        }
        /// <summary>
        /// Finishes an asynchronous disconnect request.
        /// </summary>
        private void OnDisconnectCompleted(IAsyncResult result)
        {
            // need to make sure the results are processed on the correct thread.
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnDisconnectCompleted), result);
                return;
            }

            // get the session used to send the request which was passed as the userData in the Begin call.
            Session session = (Session)result.AsyncState;

            try
            {
                session.EndDisconnect(result);
            }
            catch (Exception e)
            {
                ExceptionDlg.ShowInnerException(this.Text, e);
            }
        }

        /// <summary>
        /// EventHandler for connection status update. Updated the labels for the connection.
        /// </summary>
        /// <param name="sender">The session with the updated ConnectionState</param>
        /// <param name="e">The transition of the SessionStatus</param>
        /// [Event Handlers]
        private void OnServerConnectionStatusUpdate(Session sender, ServerConnectionStatusUpdateEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ServerConnectionStatusUpdateEventHandler(OnServerConnectionStatusUpdate), sender, e);
                return;
            }
            switch (e.Status)
            {
                case ServerConnectionStatus.Connected:
                case ServerConnectionStatus.Connecting:
                case ServerConnectionStatus.SessionAutomaticallyRecreated:
                case ServerConnectionStatus.ConnectionErrorClientReconnect:
                    SimpleConnectBTN.Enabled = false;
                    DisconnectBTN.Enabled = true;
                    break;
                case ServerConnectionStatus.LicenseExpired:
                    SimpleConnectBTN.Enabled = false;
                    DisconnectBTN.Enabled = false;
                    break;
                default:
                    SimpleConnectBTN.Enabled = true;
                    DisconnectBTN.Enabled = false;
                    break;
            }

            LabelConnectionState.Text = e.Status.ToString();
            SetEndpointUrl();
        }

        /// <summary>
        /// Shows a dialog that allows updating the EndpointUrl that is returned by GetEndpoints.
        /// </summary>
        /// <param name="sender">The session</param>
        /// <param name="e">Information about the selected endpoint, available endpoints and the
        /// discovery url</param>
        private void OnUpdateEndpoint(Session sender, UpdateEndpointEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new UpdateEndpointEventHandler(OnUpdateEndpoint), sender, e);
                return;
            }

            if (!e.DiscoveryUrl.Equals(e.SelectedEndpoint.EndpointUrl))
            {
                EndpointUpdateDialog dlg = new EndpointUpdateDialog();
                dlg.ShowDialog(sender, e);
                if (dlg.DialogResult == DialogResult.OK)
                {
                    e.SelectedEndpoint.EndpointUrl = dlg.EndpointUrl;
                    e.UseDnsNameAndPortFromDiscoveryUrl = dlg.UseDnsNameAndPortFromDiscoveryUrl;
                }
            }
        }
        /// [Event Handlers]

        #region Constructors
        public SimpleConnectDlg()
        {
            Icon = GuiUtils.GetDefaultIcon();
            InitializeComponent();
            CancelButton = this.CancelBTN;
            Closing += Form_Closing;
            DisconnectBTN.Enabled = false;
        }
        #endregion

        #region Public Interface
        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="defaultUrl">The default EndpointUrl used for GetEndpoints. If null,
        /// the EndpointUrl specified in the parent is used. If this is also null,
        /// "opc.tcp://localhost:48030" is used. </param>
        public void ShowDialog(MainForm parent, string defaultUrl)
        {
            m_parent = parent;
            m_application = parent.Application;

            if (parent != null)
            {
                InstructionsLB.Text = parent.GetInstructions(GetType());
                InstructionsGB.Visible = true;
            }
            HelpBTN.Enabled = parent != null && parent.HelpExists(GetType());

            EndpointUrlTB.Text = defaultUrl;

            // get default values
            if (String.IsNullOrEmpty(EndpointUrlTB.Text))
            {
                if (parent != null && parent.Endpoint != null)
                {
                    EndpointUrlTB.Text = parent.Endpoint.EndpointUrl;
                }
                else
                {
                    EndpointUrlTB.Text = "opc.tcp://localhost:48030";
                }
            }

            m_session = m_parent.Session;
            m_session = new Session(m_application);
            LabelConnectionState.Text = m_session.ConnectionStatus.ToString();
            UseDnsNameAndPortFromDiscoveryUrlBox.Checked = m_session.UseDnsNameAndPortFromDiscoveryUrl;
            SetEndpointUrl();

            // Add EventHandlers
            // note these handlers must not be static because this code is running in a model dialog.
            /// [Add Event Handlers]
            m_session.ConnectionStatusUpdate += OnServerConnectionStatusUpdate;
            /// [Add Event Handlers]

            ShowDialog();
        }
        #endregion

        #region Private Fields
        private MainForm m_parent;
        private Session m_session;
        private ApplicationInstance m_application;
        #endregion

        #region Helpers for access to the GUI
        private string EndpointUrl
        {
            get
            {
                return EndpointUrlTB.Text;
            }
        }

        private SecuritySelection SecuritySelection
        {
            get
            {
                if (SecurityBox.Checked)
                {
                    return SecuritySelection.BestAvailable;
                }
                else
                {
                    return SecuritySelection.None;
                }
            }
        }

        private void SetEndpointUrl()
        {
            if (m_session.EndpointDescription != null)
            {
                EnpointUrlLabel.Text = "EndpointUrl: " + m_session.EndpointDescription.EndpointUrl;
                MessageSecurityModeLabel.Text = "SecurityMode: " + m_session.EndpointDescription.SecurityMode;
            }
            else
            {
                EnpointUrlLabel.Text = "";
                MessageSecurityModeLabel.Text = "";
            }
        }
        #endregion

        #region EventHandlers
        private void CancelBTN_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DisconnectBTN_Click(object sender, EventArgs e)
        {
            if (UseAsynchCK.Checked)
            {
                BeginDisconnect();
            }
            else
            {
                Disconnect();
            }
        }

        private void SimpleConnectBTN_Click(object sender, EventArgs e)
        {
            m_session.UseDnsNameAndPortFromDiscoveryUrl = UseDnsNameAndPortFromDiscoveryUrlBox.Checked;

            if (UseAsynchCK.Checked)
            {
                BeginConnect();
            }
            else
            {
                Connect();
            }
        }

        private void HelpBTN_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Removes the event handlers
        /// </summary>
        private void Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            m_session.Disconnect();
            m_session.Dispose();
        }

        /// <summary>
        /// Shows the content of the current Endpoint of the session.
        /// </summary>
        private void EnpointUrlLabel_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (m_session.EndpointDescription != null)
                {
                    m_parent.ShowEditValueDialog(m_session.EndpointDescription);
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void EnableUpdateEndpointEventHandler_CheckedChanged(object sender, EventArgs e)
        {
            if (EnableUpdateEndpointEventHandler.Checked)
            {
                m_session.UpdateEndpoint += OnUpdateEndpoint;
            }
            else
            {
                m_session.UpdateEndpoint -= OnUpdateEndpoint;
            }
        }
        #endregion
    }
}
