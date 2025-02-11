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
    /// Shows a dialog which demonstrates how to connect to a server. It shows sequence of
    /// calling GetEndpoints and Connect and the usage of the EventHandlers related to connecting
    /// to a server.
    /// </summary>
    public partial class AdvancedConnectDialog : Form
    {
        /// <summary>
        /// EventHandler for connection status update. Updated the labels for the connection.
        /// </summary>
        /// <param name="sender">The session with the updated ConnectionState</param>
        /// <param name="e">The transition of the SessionStatus</param>
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
                    ConnectBTN.Enabled = false;
                    DisconnectBTN.Enabled = true;
                    break;
                case ServerConnectionStatus.LicenseExpired:
                    ConnectBTN.Enabled = false;
                    DisconnectBTN.Enabled = false;
                    break;
                default:
                    ConnectBTN.Enabled = true;
                    DisconnectBTN.Enabled = false;
                    break;
            }

            LabelConnectionState.Text = e.Status.ToString();
            UpdateAfterConnectStateChange();
        }

        /// <summary>
        /// Synchronously gets the endpoints for a server.
        /// </summary>
        private void GetEndpoints()
        {
            try
            {

                // validate the URL.
                if (!Uri.IsWellFormedUriString(ServerUrlTB.Text, UriKind.Absolute))
                {
                    throw new ArgumentException("The URL is not valid", "ServerUrl");
                }

                // this is a blocking call so show the wait cursor.
                Cursor = Cursors.WaitCursor;

                // clear the existing servers.
                EndpointsLV.Items.Clear();

                // create the object used to find servers or endpoints
                // and look for the LDS with the default endpoint.
                List<EndpointDescription> endpoints;
                using (Discovery discovery = new Discovery(m_parent.Application))
                {
                    endpoints = discovery.GetEndpoints(ServerUrlTB.Text);
                }

                // update endpoints
                SetEndpoints(endpoints);
            }
            catch (Exception e)
            {
                ExceptionDlg.ShowInnerException(this.Text, e);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Asynchronously gets the endpoints for a server.
        /// </summary>
        private void BeginGetEndpoints()
        {
            // create the object used to find servers or endpoints.
            Discovery discovery = new Discovery(m_parent.Application);

            try
            {
                // validate the URL.
                if (!Uri.IsWellFormedUriString(ServerUrlTB.Text, UriKind.Absolute))
                {
                    throw new ArgumentException("The URL is not valid", "ServerUrl");
                }

                // clear the existing servers.
                EndpointsLV.Items.Clear();

                // look for the LDS with the default endpoint.
                discovery.BeginGetEndpoints(
                    ServerUrlTB.Text,
                    OnGetEndpointsCompleted,
                    discovery);
            }
            catch (Exception e)
            {
                discovery.Dispose();
                ExceptionDlg.ShowInnerException(this.Text, e);
            }
        }

        /// <summary>
        /// Finishes an asynchronous get endpoints request.
        /// </summary>
        /// <param name="result"></param>
        private void OnGetEndpointsCompleted(IAsyncResult result)
        {
            // need to make sure the results are processed on the correct thread.
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnGetEndpointsCompleted), result);
                return;
            }

            // get the object used to invoke the method.
            using (Discovery discovery = (Discovery)result.AsyncState)
            {
                try
                {
                    // get the results.
                    List<EndpointDescription> endpoints = discovery.EndGetEndpoints(result);
                    SetEndpoints(endpoints);
                }
                catch (Exception exception)
                {
                    ExceptionDlg.ShowInnerException(this.Text, exception);
                }
            }
        }

        /// <summary>
        /// Synchronously connects to the selected Endpoint
        /// </summary>
        private void Connect()
        {
            try
            {
                // this is a blocking call so show the wait cursor.
                Cursor = Cursors.WaitCursor;

                /// [Use Returned Endpoint Connect]
                m_session.Connect(SelectedEndpoint, (ep1, ep2) => { return ep1.IsEquivalentTo(ep2); }, Endpoints, m_session.DefaultRequestSettings);
                /// [Use Returned Endpoint Connect]
            }
            catch (Exception e)
            {
                ExceptionDlg.ShowInnerException(this.Text, e);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Asynchronously connects to the selected Endpoint
        /// </summary>
        /// [Use Returned Endpoint BeginConnect]
        private void BeginConnect()
        {
            try
            {
                m_session.BeginConnect(
                    SelectedEndpoint,
                    RetryInitialConnect.Yes,
                    (ep1, ep2) => { return ep1.IsEquivalentTo(ep2); },
                    Endpoints,
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
        /// <param name="result"></param>
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
        /// [Use Returned Endpoint BeginConnect]

        /// <summary>
        /// Synchronously disconnects from the server
        /// </summary>
        private void Disconnect()
        {
            try
            {
                // this is a blocking call so show the wait cursor.
                Cursor = Cursors.WaitCursor;
                m_session.Disconnect();
            }
            catch (Exception e)
            {
                ExceptionDlg.ShowInnerException(this.Text, e);
            }
            finally
            {
                Cursor = Cursors.Default;
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
        /// <param name="result"></param>
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

        #region Constructors
        public AdvancedConnectDialog()
        {
            Icon = GuiUtils.GetDefaultIcon();
            InitializeComponent();
            Closing += Form_Closing;
            CancelButton = this.CancelBTN;
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
            if (parent != null)
            {
                InstructionsLB.Text = parent.GetInstructions(GetType());
                InstructionsLB.Visible = true;
            }
            HelpBTN.Enabled = parent != null && parent.HelpExists(GetType());
            ServerUrlTB.Text = defaultUrl;

            // get default values.
            if (String.IsNullOrEmpty(defaultUrl))
            {
                if (parent != null && parent.Endpoint != null)
                {
                    ServerUrlTB.Text = parent.Endpoint.EndpointUrl;
                }
                else
                {
                    ServerUrlTB.Text = "opc.tcp://localhost:48030";
                }
            }

            m_session = new Session(m_parent.Application);
            LabelConnectionState.Text = m_session.ConnectionStatus.ToString();
            UpdateAfterConnectStateChange();
            // Add EventHandlers
            m_session.ConnectionStatusUpdate += OnServerConnectionStatusUpdate;
            ShowDialog();
        }
        #endregion

        #region Private Fields
        private MainForm m_parent;
        private Session m_session;
        #endregion

        #region Helpers for access to the gui
        private string ServerUrl
        {
            get
            {
                return ServerUrlTB.Text;
            }
        }

        private void SetEndpoints(IList<EndpointDescription> endpoints)
        {
            Endpoints = endpoints;

            // update list view.
            foreach (EndpointDescription endpoint in endpoints)
            {
                ListViewItem item = new ListViewItem();

                item.Text = endpoint.EndpointUrl;
                item.SubItems.Add(endpoint.SecurityMode.ToString());
                item.SubItems.Add(SecurityProfiles.GetDisplayName(endpoint.SecurityPolicyUri));
                item.SubItems.Add(endpoint.TransportProfileUri);
                item.Tag = endpoint;

                EndpointsLV.Items.Add(item);
            }

            // adjust the column widths.
            foreach (ColumnHeader column in EndpointsLV.Columns)
            {
                column.Width = -2;
            }
        }

        public IList<EndpointDescription> Endpoints { get; private set; }

        public EndpointDescription SelectedEndpoint
        {
            get
            {
                ListView.SelectedListViewItemCollection selectedItems = EndpointsLV.SelectedItems;
                if (selectedItems.Count == 1 && selectedItems[0].Tag != null)
                {
                    return (EndpointDescription)selectedItems[0].Tag;
                }
                return null;
            }
        }

        /// <summary>
        /// Updated the EndpointUrl label
        /// </summary>
        void UpdateAfterConnectStateChange()
        {
            if (m_session.EndpointDescription != null)
            {
                LabelEndpointUrl.Text = "EndpointUrl = " + m_session.EndpointDescription.EndpointUrl;
            }
            else
            {
                LabelEndpointUrl.Text = "";
            }
        }
        #endregion

        #region Event Handlers
        private void CancelBTN_Click(object sender, EventArgs e)
        {
            Close();
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

        private void GetEndpointsBTN_Click(object sender, EventArgs e)
        {
            if (UseAsynchCK.Checked)
            {
                BeginGetEndpoints();
            }
            else
            {
                GetEndpoints();
            }
        }

        private void ConnectBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (EndpointsLV.SelectedItems.Count == 0)
                {
                    if (EndpointsLV.Items.Count == 0)
                    {
                        throw new ArgumentException("Endpoints are not available. Call GetEndpoints before calling Connect.");
                    }
                    else
                    {
                        throw new ArgumentException("No Endpoint selected. Select an Endpoint before calling Connect.");
                    }
                }
                if (UseAsyncConnectCK.Checked)
                {
                    BeginConnect();
                }
                else
                {
                    Connect();
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void DisconnectBTN_Click_1(object sender, EventArgs e)
        {
            if (UseAsyncConnectCK.Checked)
            {
                BeginDisconnect();
            }
            else
            {
                Disconnect();
            }
        }


        /// <summary>
        /// Opens a dialog to the content of the selected EndpointDescription
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndpointsLV_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (EndpointsLV.SelectedItems.Count > 0)
                {
                    m_parent.ShowEditValueDialog(EndpointsLV.SelectedItems[0].Tag);
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        /// <summary>
        /// EventHandler for closing form. Removes the EventHandlers from the Session
        /// </summary>
        private void Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            m_session.Disconnect();
            m_session.Dispose();
        }
        #endregion
    }
}
