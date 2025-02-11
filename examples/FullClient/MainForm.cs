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
using UnifiedAutomation.Sample.Forms;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace UnifiedAutomation.Sample
{
    /// <summary>
    /// The main form of the user interface.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Construction
        /// <summary>
        /// Initializes the controls of this form. Registers for an particular event.
        /// </summary>
        public MainForm(ApplicationInstance applicationInstance)
        {
            // Initialize controls.
            InitializeComponent();

            m_Application = applicationInstance;

            // Register for the UntrustedCertificate event. Opens trust certificate dialog to trust or reject server certificate
            m_Application.UntrustedCertificate += new UntrustedCertificateEventHandler(Application_UntrustedCertificate);

            // Register for the SelectionChanged event of BrowseControl in order to update
            // the ListView of AttributeListControl.
            browseControl.SelectionChanged += new BrowseControl.SelectionChangedEventHandler(browserControl_SelectionChanged);

            // Register for the Node Activated event of BrowseControl in order to add item for monitoring in monitoredItemsControl
            browseControl.NodeActivated += new BrowseControl.NodeActivatedEventHandler(browserControl_NodeActivated);

            // Register for the update statuslabel event of AttriuteListControl in order to update
            // the status label.
            attributeListControl.UpdateStatusLabel +=
                new AttributeListControl.UpdateStatusLabelEventHandler(UserControl_UpdateStatusLabel);

            // Register for the update statuslabel event of MonitoredItemsControl in order to update
            // the status label.
            monitoredItemsControl.UpdateStatusLabel +=
                new MonitoredItemsControl.UpdateStatusLabelEventHandler(UserControl_UpdateStatusLabel);

            DiscoveryUrlCB.Text = m_defaultDiscoveryUrl;
            DiscoveryUrlCB.TextChanged += DiscoveryUrlCB_EditingStarted;
            DiscoveryUrlCB.DropDown += DiscoveryUrlCB_EditingStarted;

            StatusLabelSTS.LayoutStyle = ToolStripLayoutStyle.Flow;

            DiscoveryTypeCB.SelectedIndex = 0;

            StartTrialTimeExpiredCheck();

            Application.ApplicationExit += Application_ApplicationExit;
        }

        private void StartTrialTimeExpiredCheck()
        {
            m_timer = new Timer();
            m_timer.Tick += new EventHandler(TimerElapsed);
            m_timer.Interval = 5000;
            m_timer.Enabled = true;
        }

        private void Server_IncomingConnectionOpened(object sender, IncomingReverseConnectionGroupUpdateEventArgs e)
        {
            if (e.ConnectionGroup.Connections.Count > 0)
            {
                DiscoveryUrl = e.ConnectionGroup.Connections[0].EndpointUrl;
            }
        }
        #endregion

        #region Fields
        /// <summary>
        /// Provides access to the OPC UA server and its services.
        /// </summary>
        private Session m_Session = null;
        /// <summary>
        /// Provides access to the OPC UA server and its services.
        /// </summary>
        private ApplicationInstance m_Application = null;
        /// <summary>
        /// Timer to monitor if the license has expired.
        /// </summary>
        private Timer m_timer = null;
        /// <summary>
        /// User identity to set at the session before connect.
        /// </summary>
        private UserIdentity m_userIdentity = null;

#if !REVERSE_CONNECT_UNSUPPORTED
        /// <summary>
        /// The default uri for reverse connect of UnifiedAutomation DemoServers.
        /// </summary>
        readonly string m_defaultClientUrl = "opc.tcp://localhost:48070";
#endif

        readonly string m_defaultDiscoveryUrl = "opc.tcp://localhost:48030";
        private object m_lock = new object();
        string m_lastClientUrlsForReverseConnect;
        #endregion

        #region Properties to access Controls
        bool IsReverseConnectSelected
        {
            get
            {
                return DiscoveryTypeCB.SelectedIndex == 1;
            }
        }

        string DiscoveryUrl
        {
            get
            {
                string url = DiscoveryUrlCB.Text;
                if (String.IsNullOrEmpty(url))
                {
                    // Set the uri of the local discovery server by default.
                    url = "opc.tcp://localhost:4840";
                }
                else
                {
                    // Has the port been entered by the user?
                    char seperator = ':';
                    string[] portCheck = url.Split(seperator);
                    if (portCheck.Length == 1)
                    {
                        url += ":4840";
                    }
                }

                return url;
            }

            set
            {
                lock (m_lock)
                {
                    if (!DiscoveryUrlCB.Items.Contains(value))
                    {
                        DiscoveryUrlCB.Invoke(new Action(() => DiscoveryUrlCB.Items.Add(value)));
                        if (DiscoveryUrlCB.Items.Count != 0)
                        {
                            DiscoveryUrlCB.Invoke(new Action(() => DiscoveryUrlCB.SelectedIndex = 0));
                        }
                    }
                }
            }
        }

        string ClientUrlForReverseConnect
        {
            get
            {
                if (IsReverseConnectSelected)
                {
                    return m_lastClientUrlsForReverseConnect;
                }
                return null;
            }
        }
        #endregion

        #region Calls to Client API
        /// <summary>
        /// Connect to server.
        /// </summary>
        private void Connect()
        {
            // Set wait cursor.
            Cursor = Cursors.WaitCursor;

            try
            {
                DisconnectIfRequired();

                // Extract Url from combobox text.
                EndpointDescription endpoint;
                IList<EndpointDescription> endpointsFromGetEndpoints;
                if (!TryGetSelectedEndpoint(out endpoint, out endpointsFromGetEndpoints))
                {
                    ConnectWithDiscoveryUrl();
                }
                else
                {
                    ConnectToSelectedEndpoint(endpoint, endpointsFromGetEndpoints);
                }
            }
            catch (Exception e)
            {
                // Update status label.
                PrintException(e, "Connect failed");
            }

            // Set default cursor.
            Cursor = Cursors.Default;
        }

        void CreateSession()
        {
            if (!IsReverseConnectSelected)
            {
                m_Session = new Session(m_Application);
            }
            else
            {
                m_Session = new Session(m_Application, ClientUrlForReverseConnect);
            }
        }

        private void ConnectToSelectedEndpoint(EndpointDescription endpoint, IList<EndpointDescription> endpointsFromGetEndpoints)
        {
            CreateSession();


            if (m_userIdentity != null)
            {
                m_Session.UserIdentity = m_userIdentity;
            }

            // Attach to events
            m_Session.ConnectionStatusUpdate += new ServerConnectionStatusUpdateEventHandler(Session_ServerConnectionStatusUpdate);

            // Call connect with endpoint
            if (!IsReverseConnectSelected)
            {
                m_Session.Connect(endpoint, (ep1, ep2) => { return ep1.IsEquivalentTo(ep2); }, endpointsFromGetEndpoints, null);
            }
            else
            {
                m_Session.ReverseConnect(endpoint, RetryInitialConnect.No, (ep1, ep2) => { return ep1.IsEquivalentTo(ep2); }, endpointsFromGetEndpoints, null);
            }
        }

        private void ConnectWithDiscoveryUrl()
        {
            CreateSession();

            if (m_userIdentity != null)
            {
                m_Session.UserIdentity = m_userIdentity;
            }

            m_Session.UseDnsNameAndPortFromDiscoveryUrl = true;
            m_Session.DefaultRequestSettings.OperationTimeout = 30000;

            // Attach to events
            m_Session.ConnectionStatusUpdate += new ServerConnectionStatusUpdateEventHandler(Session_ServerConnectionStatusUpdate);

            // Call connect with URL
            if (IsReverseConnectSelected)
            {
                m_Session.ReverseConnect(DiscoveryUrl, SecuritySelection.None);
            }
            else
            {
                m_Session.Connect(DiscoveryUrl, SecuritySelection.None);
            }
        }

        void DisconnectIfRequired()
        {
            if (m_Session != null)
            {
                Disconnect();
            }
        }

        bool TryGetSelectedEndpoint(out EndpointDescription endpoint, out IList<EndpointDescription> endpointsFromGetEndpoints)
        {
            object selectedItem = EndpointCB.SelectedItem;
            if (selectedItem == null || selectedItem.GetType() == typeof(string))
            {
                endpoint = null;
                endpointsFromGetEndpoints = null;
                return false;
            }
            endpoint = (selectedItem as EndpointWrapper).Endpoint;
            endpointsFromGetEndpoints = new List<EndpointDescription>();
            foreach (var item in EndpointCB.Items)
            {
                endpointsFromGetEndpoints.Add((item as EndpointWrapper).Endpoint);
            }
            return true;
        }

        /// <summary>
        /// Disconnect from server.
        /// </summary>
        private void Disconnect()
        {
            try
            {
                // Call the disconnect service of the server.
                m_Session.Disconnect(SubscriptionCleanupPolicy.Delete, null);
                m_Session.ConnectionStatusUpdate -= new ServerConnectionStatusUpdateEventHandler(Session_ServerConnectionStatusUpdate);
                m_Session.Dispose();
                m_Session = null;

                UpdateAfterDisconnect();
                ClearControls();
            }
            catch (Exception exception)
            {
                // Update status label.
                PrintException(exception, "Disconnect failed");
            }
        }
        /// <summary>
        /// Expands the drop down list of the ComboBox to display available servers and endpoints.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DoDiscovery(object sender, EventArgs e)
        {
            // Look for servers
            Discovery discovery = null;
            try
            {
                if (IsReverseConnectSelected)
                {
                    discovery = new Discovery(m_Application, ClientUrlForReverseConnect);
                }
                else
                {
                    discovery = new Discovery(m_Application);
                }
                List<ApplicationDescription> servers = null;
                try
                {
                    Cursor = Cursors.WaitCursor;

                    if (discovery.IsReverseConnectEnabled)
                    {
                        servers = discovery.ReverseFindServers(DiscoveryUrl);
                    }
                    else
                    {
                        servers = discovery.FindServers(DiscoveryUrl);
                    }

                }
                catch (Exception exception)
                {
                    // Update status label.
                    PrintException(exception, "FindServers failed");
                    // Set default cursor.
                    Cursor = Cursors.Default;
                    return;
                }
                finally
                {
                    Cursor = Cursors.Default;
                }

                // Populate the drop down list with the endpoints for the available servers.
                foreach (ApplicationDescription server in servers)
                {
                    if (server.ApplicationType == ApplicationType.Client || server.ApplicationType == ApplicationType.DiscoveryServer)
                    {
                        continue;
                    }

                    foreach (string discoveryUrl in server.DiscoveryUrls)
                    {
                        Uri uri = new Uri(discoveryUrl);
                        if (uri.Scheme == "opc.tcp")
                        {
                            GetEndpoints(discoveryUrl, discovery);
                        }
                    }
                }
            }
            finally
            {
                discovery.Dispose();
            }

        }


        private void GetEndpoints(string discoveryUrl, Discovery discovery)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                IList<EndpointDescription> endpoints;
                if (!IsReverseConnectSelected)
                {
                    endpoints = discovery.GetEndpoints(discoveryUrl);
                }
                else
                {
                    endpoints = discovery.ReverseGetEndpoints(discoveryUrl);
                }
                AddEndpointsToControl(endpoints);
            }
            catch (Exception e)
            {
                PrintException(e, $"GetEndpoints failed for {(discoveryUrl)}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Update controls
        private string ErrorMessage(Exception e)
        {
            Exception exception = e;
            StatusException se;

            // cannot cast to AggregateException since it is not available in Net35
            if (e.InnerException != null && e.InnerException.InnerException != null)
            {
                exception = e.InnerException.InnerException;
                se = exception as StatusException;
            }
            else
            {
                se = e as StatusException;
            }

            if (se != null)
            {
                return String.Concat("Error: [", se.StatusCode.ToString(), "] ", exception.Message);
            }

            return exception.Message;
        }

        private void PrintException(Exception e, string text)
        {
            string message = ErrorMessage(e);
            toolStripStatusLabel.Text = String.Concat(text, ": ", message);
            toolStripStatusLabel.Image = global::UnifiedAutomation.Sample.Properties.Resources.error;
        }

        void AddEndpointsToControl(IList<EndpointDescription> endpoints)
        {
            ClearEndpoints();

            foreach (EndpointDescription description in endpoints)
            {
                if (!m_Application.SecurityProvider.IsSupportedPolicy(description.SecurityPolicyUri))
                {
                    continue;
                }

                EndpointWrapper endpoint = new EndpointWrapper(description);

                if (!EndpointCB.Items.Contains(endpoint))
                {
                    EndpointCB.Items.Add(endpoint);
                }
            }
        }

        void ClearEndpoints()
        {
            // Clear all items of the ComboBox.
            EndpointCB.Items.Clear();
            EndpointCB.Text = "";
        }

        private void UpdateAfterDisconnect()
        {
            // Update Button
            ConnectDisconnectBTN.Text = "Connect";
            // Update ToolStripMenu
            connectToolStripMenuItem.Enabled = true;
            disconnectToolStripMenuItem.Enabled = false;
            authenticationToolStripMenuItem.Enabled = true;
            // Set enabled state for combobox
            EndpointCB.Enabled = true;
            DiscoveryUrlCB.Enabled = true;
            DiscoveryTypeCB.Enabled = true;
            ClientUrlTB.Enabled = IsReverseConnectSelected;
            // Update status label.
            toolStripStatusLabel.Text = "Disconnected";
            toolStripStatusLabel.Image = global::UnifiedAutomation.Sample.Properties.Resources.warning;
        }

        private void ClearControls()
        {
            // Cleanup attribute list.
            this.attributeListControl.AttributeList.Items.Clear();

            // Cleanup treeview.
            browseControl.BrowseTree.BeginUpdate();
            browseControl.BrowseTree.Nodes.Clear();
            browseControl.BrowseTree.EndUpdate();

            // Aggregate the UserControls.
            browseControl.Session = null;
            attributeListControl.Session = null;

            monitoredItemsControl.Clear();
        }
        #endregion

        #region User Actions
        /// <summary>
        /// Callback of the exception thrown event of BrowseControl and AttributeListControl.
        /// </summary>
        /// <param name="node">The source of the event.</param>
        private void UserControl_UpdateStatusLabel(string strMessage, bool bSuccess)
        {
            toolStripStatusLabel.Text = strMessage;

            if (bSuccess == true)
            {
                toolStripStatusLabel.Image = global::UnifiedAutomation.Sample.Properties.Resources.success;
            }
            else
            {
                toolStripStatusLabel.Image = global::UnifiedAutomation.Sample.Properties.Resources.error;
            }
        }

        /// <summary>
        /// Callback of the selection changed event of BrowseControl.
        /// </summary>
        /// <param name="node">The source of the event.</param>
        private void browserControl_SelectionChanged(TreeNode node)
        {
            // Read all the attributes of the selected tree node.
            attributeListControl.ReadAttributes(node);
        }

        private void browserControl_NodeActivated(NodeId activatedNode)
        {
            // Add monitored items
            monitoredItemsControl.addMonitoredItem(activatedNode);
        }

        /// <summary>
        /// Handles the connect procedure being started from the menu bar.
        /// <summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void connectDisconnectTriggered(object sender, EventArgs e)
        {
            // Currently connected -> disconnect.
            if (m_Session != null)
            {
                Disconnect();
            }
            // Currently not connected -> connect to server.
            else
            {
                Connect();
            }
        }

        /// <summary>
        // Handles the publishing interval procedure started from the menu bar.
        /// <summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void PublishingInterval_Click(object sender, EventArgs e)
        {
            if (monitoredItemsControl.Subscription != null)
            {
                PublishingIntervalDialog dlg = new PublishingIntervalDialog(monitoredItemsControl.Subscription);
                dlg.Show();
            }
        }

        /// <summary>
        /// Change the enabled state for the subscription
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void publishingEnabled_Click(object sender, EventArgs e)
        {
            monitoredItemsControl.PublishingEnabled = publishingEnabledToolStripMenuItem.Checked;
            monitoredItemsControl.UpdateSubscription();
        }
        #endregion

        #region Event Handler

        /// <summary>
        ///
        /// </summary>
        private void Session_ServerConnectionStatusUpdate(Session sender, ServerConnectionStatusUpdateEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ServerConnectionStatusUpdateEventHandler(Session_ServerConnectionStatusUpdate), sender, e);
                return;
            }

            // check that the current session matches the session that raised the event.
            if (!Object.ReferenceEquals(m_Session, sender))
            {
                return;
            }

            lock (this)
            {

                bool bClearControls = false;

                switch (e.Status)
                {
                    case ServerConnectionStatus.Disconnected:
                        UpdateAfterDisconnect();
                        bClearControls = true;
                        break;
                    case ServerConnectionStatus.Connected:
                        // Update Button
                        ConnectDisconnectBTN.Text = "Disconnect";
                        // Update ToolStripMenu
                        connectToolStripMenuItem.Enabled = false;
                        disconnectToolStripMenuItem.Enabled = true;
                        authenticationToolStripMenuItem.Enabled = false;
                        // Set enabled state for combobox
                        EndpointCB.Enabled = false;
                        DiscoveryUrlCB.Enabled = false;
                        DiscoveryTypeCB.Enabled = false;
                        ClientUrlTB.Enabled = false;

                        // Aggregate the UserControls.
                        browseControl.Session = m_Session;
                        attributeListControl.Session = m_Session;
                        monitoredItemsControl.Session = m_Session;

                        // Update status label.
                        toolStripStatusLabel.Text = "Connected to " + m_Session.EndpointDescription.EndpointUrl;
                        toolStripStatusLabel.Image = global::UnifiedAutomation.Sample.Properties.Resources.success;

                        // Browse first level.
                        browseControl.Browse(null);
                        break;
                    case ServerConnectionStatus.ConnectionWarningWatchdogTimeout:
                        // Update status label.
                        toolStripStatusLabel.Text = "Watchdog timed out";
                        toolStripStatusLabel.Image = global::UnifiedAutomation.Sample.Properties.Resources.warning;
                        break;
                    case ServerConnectionStatus.ConnectionErrorClientReconnect:
                        // Update status label.
                        toolStripStatusLabel.Text = "Trying to reconnect";
                        toolStripStatusLabel.Image = global::UnifiedAutomation.Sample.Properties.Resources.warning;
                        break;
                    case ServerConnectionStatus.ServerShutdownInProgress:
                        // Update status label.
                        toolStripStatusLabel.Text = "Server is shutting down";
                        toolStripStatusLabel.Image = global::UnifiedAutomation.Sample.Properties.Resources.warning;
                        break;
                    case ServerConnectionStatus.ServerShutdown:
                        // Update status label.
                        toolStripStatusLabel.Text = "Server has shut down";
                        toolStripStatusLabel.Image = global::UnifiedAutomation.Sample.Properties.Resources.warning;
                        break;
                    case ServerConnectionStatus.SessionAutomaticallyRecreated:
                        // Update status label.
                        toolStripStatusLabel.Text = "A new Session was created";
                        toolStripStatusLabel.Image = global::UnifiedAutomation.Sample.Properties.Resources.success;
                        // clear controls
                        bClearControls = true;
                        break;
                    case ServerConnectionStatus.Connecting:
                        // Update status label.
                        EndpointDescription endpoint;
                        string endpointUrl;
                        if (TryGetSelectedEndpoint(out endpoint, out var _))
                        {
                            endpointUrl = endpoint.EndpointUrl;
                        }
                        else
                        {
                            endpointUrl = DiscoveryUrl;
                        }
                        toolStripStatusLabel.Text = "Trying to connect to " + endpointUrl;
                        toolStripStatusLabel.Image = global::UnifiedAutomation.Sample.Properties.Resources.warning;
                        break;
                    case ServerConnectionStatus.LicenseExpired:
                        // Update status label.
                        toolStripStatusLabel.Text = "The license has expired.";
                        toolStripStatusLabel.Image = global::UnifiedAutomation.Sample.Properties.Resources.warning;
                        // disable GUI
                        serverToolStripMenuItem.Enabled = false;
                        subscriptionToolStripMenuItem.Enabled = false;
                        ConnectDisconnectBTN.Enabled = false;
                        EndpointCB.Enabled = false;
                        bClearControls = true;
                        break;
                }

                if (bClearControls)
                {
                    ClearControls();
                }
            }
        }

        private void TimerElapsed(object sender, EventArgs e)
        {
            if (m_Session != null && m_Session.ConnectionStatus == ServerConnectionStatus.LicenseExpired)
            {
                // show dialog once only - so we just stop the timer
                m_timer.Enabled = false;
                MessageBox.Show("The demo license has expired.\nRestart the application.", "License expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (m_Session != null && m_Session.ConnectionStatus == ServerConnectionStatus.Connected)
            {
                m_Session.Disconnect();
            }
        }

        public void Application_UntrustedCertificate(object sender, UntrustedCertificateEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new UntrustedCertificateEventHandler(Application_UntrustedCertificate), sender, e);
                return;
            }

            try
            {
                TrustCertificateDialogSettings settings = new TrustCertificateDialogSettings()
                {
                    Application = e.Application,
                    UntrustedCertificate = e.Certificate,
                    Issuers = e.Issuers,
                    ValidationError = e.ValidationError,
                    SaveToTrustList = false
                };

                e.Accept = TrustCertificateDialog.ShowDialog(this, settings, 30000);

                if (settings.SaveToTrustList)
                {
                    e.Persist = true;
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void DiscoveryTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientUrlTB.Enabled = DiscoveryTypeCB.SelectedIndex == 0;

            if (DiscoveryTypeCB.SelectedIndex == 0)
            {
                ClientUrlTB.Text = (string)ClientUrlTB.Tag;
                ClientUrlTB.Enabled = false;
                ClientUrlTB.LostFocus -= ClientUrlTB_EditingFinished;
                ClearUI("enter Discovery URL and click connect");
                m_Application.ReverseConnectManager.IncomingConnectionOpened -= Server_IncomingConnectionOpened;
            }
            else
            {
#if REVERSE_CONNECT_UNSUPPORTED
                MessageBox.Show("Reverse Connect not supported for this .NET Framework version.\nCompile this example with UnifiedAutomation assemblies for .NET Framework 4.5 or higher.", "Not supported", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DiscoveryTypeCB.SelectedIndex = 0;
                return;
#else
                ClientUrlTB.Tag = ClientUrlTB.Text;
                ClientUrlTB.Enabled = true;
                ClearEndpoints();
                if (String.IsNullOrEmpty(ClientUrlForReverseConnect))
                {
                    m_lastClientUrlsForReverseConnect = m_defaultClientUrl;
                }
                ClientUrlTB.Text = m_lastClientUrlsForReverseConnect;
                ClearUI("enter Client Listening URL, chose or enter Discovery URL and click connect");
                try
                {
                    m_Application.ReverseConnectManager.InitializeTransportListener(ClientUrlForReverseConnect);

                    SetDiscoveryUrlFromReverseHello();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception when starting to listen at " + ClientUrlForReverseConnect + " with message " + ex.Message + ". Check if another application binds this port",
                        "Configuration issue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ClientUrlTB.TextChanged += ClientUrlTB_EditingStarted;
#endif
            }
        }

        private void ClearUI(string statusMessage)
        {
            ClearEndpoints();
            toolStripStatusLabel.Text = statusMessage;
            toolStripStatusLabel.Image = global::UnifiedAutomation.Sample.Properties.Resources.success;
        }

        private void ClientUrlTB_EditingStarted(object sender, EventArgs e)
        {
            ClientUrlTB.TextChanged -= ClientUrlTB_EditingStarted;
            m_Application.ReverseConnectManager.IncomingConnectionOpened -= Server_IncomingConnectionOpened;
            ClientUrlTB.Leave += ClientUrlTB_EditingFinished;
        }

        private void ClientUrlTB_EditingFinished(object sender, EventArgs e)
        {
            lock (m_lock)
            {
                string newClientUrlForReverseConnect = ClientUrlTB.Text;
                if (newClientUrlForReverseConnect != m_lastClientUrlsForReverseConnect)
                {
                    DiscoveryUrlCB.Items.Clear();
                    DiscoveryUrlCB.Text = "";
                    m_Application.ReverseConnectManager.RemoveTransportListener(m_lastClientUrlsForReverseConnect);
                    m_lastClientUrlsForReverseConnect = newClientUrlForReverseConnect;
                    try
                    {
                        m_Application.ReverseConnectManager.InitializeTransportListener(ClientUrlForReverseConnect);
                        m_Application.ReverseConnectManager.IncomingConnectionOpened += Server_IncomingConnectionOpened;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Exception when starting to listen at " + ClientUrlForReverseConnect + " with message " + ex.Message + ". Check if another application binds this port",
                            "Configuration issue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void SetDiscoveryUrlFromReverseHello()
        {
            var firstConnection = m_Application.ReverseConnectManager.IncomingReverseConnections.FirstOrDefault();
            if (firstConnection != null && firstConnection.Connections.Count > 0)
            {
                DiscoveryUrl = firstConnection.Connections[0].EndpointUrl;
            }
            m_Application.ReverseConnectManager.IncomingConnectionOpened += Server_IncomingConnectionOpened;
        }

        private void DiscoveryUrlCB_EditingStarted(object sender, EventArgs e)
        {
            ClearEndpoints();
        }


        public void ShowUserIdentityDialog()
        {
            AddUserIdentityDialog testDialog = new AddUserIdentityDialog();
            testDialog.StartPosition = FormStartPosition.CenterParent;
            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {
                m_userIdentity = new UserIdentity()
                {
                    IdentityType = UserIdentityType.UserName,
                    UserName = testDialog.UserNameTB.Text,
                    Password = testDialog.PasswordTB.Text
                };
            }
            testDialog.Dispose();
        }

        private void setUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserIdentityDialog();
        }

        private void setAnonymousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Set to Anonymous?", "Set Identity", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                m_userIdentity = null;
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                //nothing to do
            }
        }
        #endregion
    }
}
