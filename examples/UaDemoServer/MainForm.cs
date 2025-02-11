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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaServer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace UnifiedAutomation.Sample
{
#if NET
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
#endif
    public partial class MainForm : Form
    {
        private TestServerManager m_server;

        internal MainForm(TestServerManager server)
        {
            InitializeComponent();
            if (!String.IsNullOrEmpty(server.Application.ApplicationName))
            {
                this.Text = server.Application.ApplicationName;
            }
            
            Icon = GuiUtils.GetAppIcon();       

            m_server = server;
            m_server.Application.UntrustedCertificate += new UntrustedCertificateEventHandler(Application_UntrustedCertificate);

            m_server.ServerStarted += Server_ServerStarted;
            m_server.ServerStopped += new EventHandler(Server_ServerStopped);
            m_server.ServerStateChanged += new ServerStateChangedEventHandler(ServerManager_ServerStateChanged);

            m_server.SessionManager.SessionActivated += new SessionEventHandler(SessionManager_SessionActivated);
            m_server.SessionManager.SessionCreated += new SessionEventHandler(SessionManager_SessionCreated);
            m_server.SessionManager.SessionClosing += new SessionEventHandler(SessionManager_SessionClosing);
            m_server.SessionManager.IdentityValidationCompleted += new IdentityValidationCompletedEventHandler(SessionManager_IdentityValidationCompleted);

            Initialize(server);

            m_server.CertificateAdded += Server_CertificateAdded;

            InitializeUserManagementTapComponents();
            if (m_server.UserManagementModel != null)
            {
                m_server.UserManager.UsersChanged += UserManagementModel_UsersChangedEvent;
            }
        }

        private void Initialize(TestServerManager server)
        {
            // populate the  endpoint list.
            foreach (EndpointDescription endpoint in server.Application.Endpoints)
            {
                ListViewItem item = new ListViewItem();

                StatusCode error = server.Application.GetEndpointStatus(endpoint);

                item.Text = endpoint.EndpointUrl;
                item.SubItems.Add(error.ToString(true));
                item.SubItems.Add(SecurityProfiles.GetDisplayName(endpoint.SecurityPolicyUri));
                item.SubItems.Add(endpoint.SecurityMode.ToString());
                item.SubItems.Add(TransportProfiles.GetDisplayName(endpoint.TransportProfileUri));

                if (error.IsBad())
                {
                    item.ForeColor = Color.Red;
                }

                item.Tag = endpoint;

                EndpointsListView.Items.Add(item);
            }

            if (m_server.UserManagementModel != null)
            {
                UpdateUsersTreeView();
            }
            UpdateRolesTreeView();

            // adjust column widths.
            foreach (ColumnHeader header in EndpointsListView.Columns)
            {
                if (header.Text != "Status")
                {
                    header.Width = -2;
                }
            }

            WarningLinkLabel.Visible = (server.Application.ApplicationCertificate == null);

            UpdateTimer.Tag = 0;
            UpdateTimer.Enabled = true;
            RestartServerButton.Enabled = true;

            // populate the list view.
            if (server.Application.RejectedStore != null)
            {
                foreach (var certificate in server.Application.RejectedStore)
                {
                    AddRejectedCertificate(
                        this,
                        new RejectedCertificateEventArgs()
                        {
                            Certificate = certificate,
                            ValidationError = StatusCodes.BadCertificateUntrusted,
                            TrustedStore = m_server.Application.TrustedStore
                        });
                }
            }
        }

        #region Events
        #region RejectedCertificateEventArgs Class
        private class RejectedCertificateEventArgs : EventArgs
        {
            public RejectedCertificateEventArgs()
            {
            }

            public RejectedCertificateEventArgs(UntrustedCertificateEventArgs e)
            {
                Certificate = e.Certificate;
                CertificateValidator = e.CertificateValidator;
                ValidationError = e.ValidationError;
                EndpointUrl = e.EndpointUrl;
                if (EndpointUrl != null)
                {
                    EndpointUrl = EndpointUrl.Replace(System.Net.Dns.GetHostName(), "localhost");
                }
                TrustedStore = e.TrustedStore;
                IssuerStore = e.IssuerStore;
            }

            public ICertificate Certificate;
            public ICertificateValidator CertificateValidator;
            public StatusCode ValidationError;
            public string EndpointUrl;
            public ICertificateStore TrustedStore;
            public ICertificateStore IssuerStore;
        }
        #endregion
        private void UserManagementModel_UsersChangedEvent(object model, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => UserManagementModel_UsersChangedEvent(model, e)));
                return;
            }
            UpdateUsersTreeView();
        }

        private void SessionManager_IdentityValidationCompleted(Session session, ImpersonateEventArgs args)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => SessionManager_IdentityValidationCompleted(session, args)));
                return;
            }
            UserNameIdentityToken userNameToken = args.NewIdentity as UserNameIdentityToken;
            if (userNameToken != null && StatusCode.IsBad(args.IdentityValidationError))
            {
                InfoLabel.Visible = true;
                InfoLabel.Text = $"{DateTime.UtcNow.ToLocalTime()} Connect failed for user: {userNameToken.UserName}";
            }
            
        }


        private void Application_UntrustedCertificate(object sender, UntrustedCertificateEventArgs e)
        {
            // automatically reject but log error.
            e.Accept = false;
            e.Persist = false;
            BeginInvoke(new EventHandler<RejectedCertificateEventArgs>(AddRejectedCertificate), this, new RejectedCertificateEventArgs(e));
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                int count = (int)UpdateTimer.Tag;

                if (count % 5 == 0)
                {
                    UpdateSelectedTabPage();
                }

                UpdateTimer.Tag = ++count;
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void MainPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateSelectedTabPage();
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void UpdateSelectedTabPage()
        {
            switch (MainPanel.SelectedIndex)
            {
                case 0: //Endpoints
                    UpdateEndpointStatus();
                    break;
                case 1: //Sessions
                    foreach (ListViewItem item in SessionsListView.Items)
                    {
                        Session session = (Session)item.Tag;

                        lock (session.DiagnosticsLock)
                        {
                            item.SubItems[5].Text = session.SessionDiagnostics.SessionDiagnostics.ClientLastContactTime.ToLocalTime().ToString("HH:mm:ss");
                        }
                    }
                    break;
                case 2: //RejectedCertificates
                    UpdateRejectedCertificateListView();
                    break;
                // case 3: User Management Tab will be updated by an event handler
                case 4: //Statistics
                    ActiveThreadCountTextBox.Text = m_server.ThreadPool.ActiveThreadCount.ToString();
                    TotalThreadCountTextBox.Text = m_server.ThreadPool.TotalThreadCount.ToString();
                    RequestQueueSizeTextBox.Text = m_server.ThreadPool.QueueLength.ToString();
                    UpdateStatistics();
                    break;
            }
        }

        private void CertificateListView_ItemMenuStrip(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ListView tmp_SenderListView = sender as ListView;
            if (e.Button == MouseButtons.Right)
            {
                if (tmp_SenderListView.SelectedItems != null)
                {
                    CertificateMenuStrip.Show(tmp_SenderListView, e.Location);
                }
            }
        }
        #endregion

        #region MainForm
        private void RestartServerButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_server != null)
                {
                    RestartServerButton.Enabled = false;
                    ShutdownServerButton.Enabled = false;
                    m_server.Stop(10, "Server restarted by Administrator.", true);
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void ShutdownServerButton_Click(object sender, EventArgs e)
        {
            StopServer(10);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopServer();

            // Ensure the completion of the shutdown process
            using (var mre = new ManualResetEvent(false))
            {
                m_server.ServerStopped += (o, x) =>
                {
                    mre.Set();
                };

                mre.WaitOne(10000);
            }
        }

        private void StopServer(uint seconds = 0)
        {
            try
            {
                if (m_server != null)
                {
                    RestartServerButton.Enabled = false;
                    ShutdownServerButton.Enabled = false;
                    m_server.Stop(seconds, "Server shutdown by Administrator.", false);
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void Server_ServerStarted(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler(Server_ServerStarted), sender, e);
                return;
            }

            try
            {
                m_server.SessionManager.SessionActivated += new SessionEventHandler(SessionManager_SessionActivated);
                m_server.SessionManager.SessionCreated += new SessionEventHandler(SessionManager_SessionCreated);
                m_server.SessionManager.SessionClosing += new SessionEventHandler(SessionManager_SessionClosing);

                WarningLinkLabel.Visible = (m_server.Application.ApplicationCertificate == null);

                UpdateTimer.Tag = 0;
                UpdateTimer.Enabled = true;
                RestartServerButton.Enabled = true;
                ShutdownServerButton.Enabled = true;
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void Server_ServerStopped(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler(Server_ServerStopped), sender, e);
                return;
            }

            try
            {
                SessionsListView.Items.Clear();
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
        }

        public void ServerManager_ServerStateChanged(object sender, ServerStateChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => ServerManager_ServerStateChanged(sender, e)));
                return;
            }
            InfoLabel.Visible = true;
            InfoLabel.Text = $"Server state changed to {e.State.ToString()}.";                
        }
        #endregion

        #region Endpoints Tab
        private void UpdateEndpointStatus()
        {
            foreach (ListViewItem item in EndpointsListView.Items)
            {
                var status = m_server.Application.GetEndpointStatus((EndpointDescription)item.Tag);
                item.SubItems[1].Text = status.ToString(true);
                if (status.IsBad())
                {
                    item.ForeColor = Color.Red;
                }
                else
                {
                    item.ForeColor = Color.Black;
                }
            }
        }

        private void EndpointsListView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (EndpointsListView.SelectedItems.Count > 0)
                {
                    new ShowEndpointUrlDlg().ShowDialog((EndpointDescription)EndpointsListView.SelectedItems[0].Tag);
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void WarningLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                ApplicationInstance application = new ApplicationInstance();
                application.LoadConfiguration(false, true);

                CreateCertificateDialog dialog = new CreateCertificateDialog();

                ICertificate certificate = dialog.ShowDialog(new CreateCertificateDialogSettings()
                {
                    Application = application
                });

                if (certificate != null)
                {
                    UaSchema.IConfiguration settings = application.ApplicationSettings;

                    settings.ApplicationCertificate = new UnifiedAutomation.UaSchema.CertificateIdentifier()
                    {
                        StoreType = (SecurityUtils.IsWindowStorePath(certificate.StorePath)) ? CertificateStoreType.Windows : CertificateStoreType.Directory,
                        StorePath = certificate.StorePath,
                        SubjectName = certificate.SubjectName
                    };

                    settings.ApplicationName = certificate.CommonName;
                    settings.ApplicationUri = certificate.ApplicationUri;

                    application.SaveConfiguration(false);
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show("Missing Application Certificate", exception);
            }
        }
        #endregion

        #region Sessions Tab
        private void SessionManager_SessionClosing(Session session, SessionEventReason reason)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SessionEventHandler(SessionManager_SessionClosing), session, reason);
                return;
            }

            try
            {
                foreach (ListViewItem item in SessionsListView.Items)
                {
                    if (Object.ReferenceEquals(session, item.Tag))
                    {
                        item.Remove();
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void SessionManager_SessionCreated(Session session, SessionEventReason reason)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SessionEventHandler(SessionManager_SessionCreated), session, reason);
                return;
            }

            try
            {
                ListViewItem item = new ListViewItem();

                lock (session.DiagnosticsLock)
                {
                    SessionDiagnosticsObjectModel model = session.SessionDiagnostics;

                    item.Text = model.SessionDiagnostics.SessionName;

                    item.SubItems.Add(model.SessionSecurityDiagnostics.TransportProtocol);

                    item.SubItems.Add(String.Concat(
                        SecurityProfiles.GetDisplayName(model.SessionSecurityDiagnostics.SecurityPolicyUri),
                        " ",
                        model.SessionSecurityDiagnostics.SecurityMode.ToString()));

                    item.SubItems.Add(String.Empty);
                    item.SubItems.Add(String.Empty);
                    item.SubItems.Add(String.Empty);

                    item.SubItems[4].Text = model.SessionDiagnostics.ClientConnectionTime.ToLocalTime().ToString("HH:mm:ss");
                    item.SubItems[5].Text = "Not Activated";

                    item.Tag = session;
                }

                SessionsListView.Items.Add(item);

                // adjust column widths.
                Size currentSize = TextRenderer.MeasureText(item.Text, item.Font);
                if (currentSize.Width + 5 > SessionsListView.Columns[0].Width)
                {
                    SessionsListView.Columns[0].Width = currentSize.Width + 5;
                }
                currentSize = TextRenderer.MeasureText(item.SubItems[2].Text, item.Font);
                if (currentSize.Width + 5 > SessionsListView.Columns[2].Width)
                {
                    SessionsListView.Columns[2].Width = currentSize.Width + 5;
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void SessionManager_SessionActivated(Session session, SessionEventReason reason)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SessionEventHandler(SessionManager_SessionActivated), session, reason);
                return;
            }

            try
            {
                foreach (ListViewItem item in SessionsListView.Items)
                {
                    if (Object.ReferenceEquals(session, item.Tag))
                    {
                        item.SubItems[3].Text = (session.Identity != null) ? session.Identity.DisplayName : "<unknown>";

                        // adjust column widths.
                        Size currentSize = TextRenderer.MeasureText(item.SubItems[3].Text, item.Font);
                        if (currentSize.Width + 5 > SessionsListView.Columns[3].Width)
                        {
                            SessionsListView.Columns[3].Width = currentSize.Width + 5;
                        }
                        break;
                    }
                }

            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
        }
        #endregion

        #region Certificates Tab
        private void AddRejectedCertificate(object sender, RejectedCertificateEventArgs args)
        {
            try
            {
                // prevent duplicates from getting added to the list.
                foreach (ListViewItem current in CertificateListView.Items)
                {
                    RejectedCertificateEventArgs tag = (RejectedCertificateEventArgs)current.Tag;

                    if (String.Compare(args.Certificate.Thumbprint, tag.Certificate.Thumbprint, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        current.Tag = args;
                        return;
                    }
                }

                // get the fields to display.
                List<string> fields = SecurityUtils.ParseDistinguishedName(args.Certificate.SubjectName);

                string commonName = null;
                string organization = null;
                string organizationalUnit = null;

                foreach (string field in fields)
                {
                    if (field.StartsWith("CN="))
                    {
                        commonName = field.Substring(3);
                        continue;
                    }

                    if (field.StartsWith("O="))
                    {
                        organization = field.Substring(2);
                        continue;
                    }

                    if (field.StartsWith("OU="))
                    {
                        organizationalUnit = field.Substring(3);
                        continue;
                    }
                }

                IList<string> domainNames = SecurityUtils.GetDomainsFromCertficate(args.Certificate.InternalCertificate);

                StringBuilder domains = new StringBuilder();

                foreach (string domainName in domainNames)
                {
                    if (domains.Length > 0)
                    {
                        domains.Append(", ");
                    }

                    domains.Append(domainName);
                }

                // add to list.
                ListViewItem item = new ListViewItem();
                item.Text = "Rejected (" + args.ValidationError.ToString(false) + ")";
                item.ForeColor = Color.Empty;
                item.SubItems.Add(commonName);
                item.SubItems.Add(domains.ToString());
                item.SubItems.Add(organization);
                item.SubItems.Add(organizationalUnit);
                item.SubItems.Add(args.Certificate.ValidTo.ToString("yyyy-MM-dd"));
                item.Tag = args;

                CertificateListView.Items.Add(item);

                foreach (ColumnHeader header in CertificateListView.Columns)
                {
                    header.Width = -2;
                }

                MainPanel.SelectedTab = RejectedCertificatesTabPage;
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void Server_CertificateAdded(object sender, CertificateAddedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => Server_CertificateAdded(sender, e)));
                return;
            }

            if (e.IsTrusted)
            {
                foreach (ListViewItem certificate in CertificateListView.Items)
                {
                    RejectedCertificateEventArgs args = certificate.Tag as RejectedCertificateEventArgs;
                    if (args.Certificate.Thumbprint == e.Certificate.Thumbprint)
                    {
                        certificate.Remove();
                        break;
                    }
                }
            }
        }

        private void CertificateListView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (CertificateListView.SelectedItems.Count != 1)
                {
                    return;
                }

                RejectedCertificateEventArgs args = (RejectedCertificateEventArgs)CertificateListView.SelectedItems[0].Tag;

                TrustCertificateDialogSettings settings = new TrustCertificateDialogSettings()
                {
                    Application = m_server.Application,
                    UntrustedCertificate = args.Certificate,
                    Issuers = null,
                    ValidationError = args.ValidationError,
                    SaveToTrustList = true
                };

                var result = TrustCertificateDialog.ShowDialog(this, settings, 0);

                if (result == DialogResult.Cancel)
                {
                    return;
                }

                if (result == DialogResult.OK)
                {
                    var validator = m_server.Application.FindCertificateValidator(args.EndpointUrl);
                    validator.Accept(args.Certificate, args.ValidationError);

                    if (settings.SaveToTrustList)
                    {
                        args.TrustedStore.Add(args.Certificate, true, false);
                    }
                }
                
                if (m_server.Application.RejectedStore != null)
                {
                    m_server.Application.RejectedStore.Remove(args.Certificate.Thumbprint);
                }

                CertificateListView.SelectedItems[0].Remove();
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void UpdateRejectedCertificateListView()
        {
            if (CertificateListView.Items.Count == 0)
            {
                return;
            }

            if (m_server.Application.RejectedStore.StoreType == CertificateStoreType.Directory)
            {
                foreach (ListViewItem certificate in CertificateListView.Items)
                {
                    bool found = false;
                    try
                    {
                        RejectedCertificateEventArgs args = (RejectedCertificateEventArgs)certificate.Tag;
                        string[] files = Directory.GetFiles(PlatformUtils.CombinePath(m_server.Application.RejectedStore.StorePath, "certs"), "*.der");

                        foreach (string file in files)
                        {
                            string fileName = Path.GetFileName(file);

                            if (fileName.Contains(args.Certificate.Thumbprint))
                            {
                                found = true;
                                continue;
                            }
                        }
                        if (!found)
                        {
                            certificate.Remove();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Update CertificateListView failed" + ex.Message);
                    }
                }
            }
        }

        private void DeleteRejectedCertificates()
        {
            if (CertificateListView.SelectedItems.Count == 0)
            {
                return;
            }

            List<ListViewItem> itemsToDeleted = new List<ListViewItem>();

            foreach (ListViewItem item in CertificateListView.SelectedItems)
            {
                RejectedCertificateEventArgs args = (RejectedCertificateEventArgs)item.Tag;
                itemsToDeleted.Add(item);

                if (m_server.Application.RejectedStore != null)
                {
                    m_server.Application.RejectedStore.Remove(args.Certificate.Thumbprint);
                }
            }

            foreach (ListViewItem item in itemsToDeleted)
            {
                item.Remove();
            }
        }

        private void TrustTemporarilyMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CertificateListView.SelectedItems.Count == 0)
                {
                    return;
                }

                foreach (ListViewItem item in CertificateListView.SelectedItems)
                {
                    RejectedCertificateEventArgs args = (RejectedCertificateEventArgs)item.Tag;
                    var validator = args.CertificateValidator ?? m_server.Application.CertificateValidator;
                    validator.Accept(args.Certificate, args.ValidationError);
                }

                DeleteRejectedCertificates();
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show("Trust Temporarily", exception);
            }
        }

        private void TrustPermanentlyMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CertificateListView.SelectedItems.Count == 0)
                {
                    return;
                }

                var result = MessageDialog.Show(
                    Parent,
                    "Are you sure you want to permanently trust the certificate?",
                    "Trust Permanently",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                foreach (ListViewItem item in CertificateListView.SelectedItems)
                {
                    RejectedCertificateEventArgs args = (RejectedCertificateEventArgs)item.Tag;
                    var validator = args.CertificateValidator ?? m_server.Application.CertificateValidator;
                    validator.Accept(args.Certificate, args.ValidationError);

                    if (m_server.Application.TrustedStore != null)
                    {
                        m_server.Application.TrustedStore.Add(args.Certificate, true, false);
                    }
                }

                DeleteRejectedCertificates();
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show("Trust Permanently", exception);
            }
        }

        private void DeleteRejectMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRejectedCertificates();
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show("Trust Permanently", exception);
            }
        }

        private void OpenStoreMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CertificateListView.SelectedItems.Count == 0)
                {
                    return;
                }

                foreach (ListViewItem item in CertificateListView.SelectedItems)
                {
                    RejectedCertificateEventArgs args = (RejectedCertificateEventArgs)item.Tag;
                    string storePath;
                    if (String.IsNullOrEmpty(args.Certificate.StorePath))
                    {
                        storePath = PlatformUtils.CombinePath(m_server.Application.RejectedStore.StorePath, "certs");
                    }
                    else
                    {
                        storePath = PlatformUtils.CombinePath(args.Certificate.StorePath, "certs");
                    }

                    if (!String.IsNullOrEmpty(storePath) && !SecurityUtils.IsWindowStorePath(storePath))
                    {
                        Process.Start("explorer.exe", storePath);
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("The Windows Certificate Store cannot be opened from this Application.", "Show Certificate Store", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show("Open Certificate Store", exception);
            }
        }
        #endregion

        #region UserManagement Tab
        private void InitializeUserManagementTapComponents()
        {
            this.UsersTreeView.AfterSelect += UsersTreeView_AfterSelect;
            this.UsersTreeView.Leave += UsersTreeView_Leave;
            this.UsersTreeView.ImageList = ImageList;
            this.RolesTreeView.ImageList = ImageList;
            UserConfigurationMaskCheckBox.Items.Clear();
            UserConfigurationMaskCheckBox.Items.Add("Disabled", false);
            UserConfigurationMaskCheckBox.Items.Add("No Change By User", false);
            UserConfigurationMaskCheckBox.Items.Add("User Must Change Password", false);
            UserConfigurationMaskCheckBox.Items.Add("No Delete", false);
            UpdateUsersTreeView();
            UpdateRolesTreeView();
        }

        private void UsersTreeView_Leave(object sender, EventArgs e)
        {
            UserNameText.Text = "";
            DescriptionTextBox.Text = "";
            UserConfigurationMaskCheckBox.SetItemChecked(0, false);
            UserConfigurationMaskCheckBox.SetItemChecked(1, false);
            UserConfigurationMaskCheckBox.SetItemChecked(2, false);
            UserConfigurationMaskCheckBox.SetItemChecked(3, false);
        }
        private void UpdateUsersTreeView()
        {
            UsersTreeView.Nodes.Clear();
            UsersTreeView.BeginUpdate();
            if (m_server.UserManagementModel == null)
            {
                TreeNode userNode = new TreeNode("UserManagement Not Implemented");
                UsersTreeView.Nodes.Add(userNode);
            }
            else
            {
                foreach (var user in m_server.UserManagementModel.Users)
                {
                    TreeNode userNode = new TreeNode(user.UserName);
                    userNode.Tag = user;
                    UsersTreeView.Nodes.Add(userNode);
                }
            }   
            UsersTreeView.EndUpdate();
        }

        private void UpdateRolesTreeView()
        {
            RolesTreeView.Nodes.Clear();
            RolesTreeView.BeginUpdate();
            if (m_server.RoleConfigurations == null)
            {
                TreeNode roleNode = new TreeNode("RoleConfiguration Not Implemented");
                RolesTreeView.Nodes.Add(roleNode);
            }
            else
            {
                foreach (var role in m_server.RoleConfigurations.Roles)
                {
                    TreeNode userNode;
                    if (role.Identities?.Length > 0)
                    {
                        List<TreeNode> identities = new List<TreeNode>();
                        foreach (var identity in role.Identities)
                        {
                            switch (identity.CriteriaType)
                            {
                                case UaSchema.CriteriaType.Anonymous:
                                    identities.Add(new TreeNode(identity.CriteriaType.ToString(), ImageList.Images.IndexOfKey("AnonymousUser"), ImageList.Images.IndexOfKey("AnonymousUser")));
                                    break;
                                case UaSchema.CriteriaType.UserName:
                                    identities.Add(new TreeNode(identity.Value, ImageList.Images.IndexOfKey("User"), ImageList.Images.IndexOfKey("User")));
                                    break;
                                case UaSchema.CriteriaType.AuthenticatedUser:
                                    identities.Add(new TreeNode(identity.CriteriaType.ToString(), ImageList.Images.IndexOfKey("UserGroup"), ImageList.Images.IndexOfKey("UserGroup")));
                                    break;
                                case UaSchema.CriteriaType.X509Subject:
                                    identities.Add(new TreeNode(identity.Value, ImageList.Images.IndexOfKey("Certificate"), ImageList.Images.IndexOfKey("Certificate")));
                                    break;
                                case UaSchema.CriteriaType.Thumbprint:
                                    identities.Add(new TreeNode(identity.Value, ImageList.Images.IndexOfKey("Certificate"), ImageList.Images.IndexOfKey("Certificate")));
                                    break;
                                case UaSchema.CriteriaType.Application:
                                    identities.Add(new TreeNode(identity.Value, ImageList.Images.IndexOfKey("UserApplication"), ImageList.Images.IndexOfKey("UserApplication")));
                                    break;
                                case UaSchema.CriteriaType.GroupId:
                                    identities.Add(new TreeNode(identity.Value, ImageList.Images.IndexOfKey("UserGroup"), ImageList.Images.IndexOfKey("UserGroup")));
                                    break;

                            }
                        }
                        userNode = new TreeNode(role.Name, 1, 1, identities.ToArray());
                    }
                    else
                    {
                        userNode = new TreeNode(role.Name);
                    }
                    RolesTreeView.Nodes.Add(userNode);
                }
            }
            RolesTreeView.EndUpdate();
        }
        private void UsersTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                UserManagementDataType user = e.Node.Tag as UserManagementDataType;
                UserNameText.Text = user.UserName;
                DescriptionTextBox.Text = user.Description;

                if(PlatformUtils.HasFlag(user.UserConfiguration, UserConfigurationMask.Disabled))
                {
                    UserConfigurationMaskCheckBox.SetItemChecked(0, true);
                }
                else
                {
                    UserConfigurationMaskCheckBox.SetItemChecked(0, false);
                }
                    
                if (PlatformUtils.HasFlag(user.UserConfiguration, UserConfigurationMask.NoChangeByUser))
                {
                    UserConfigurationMaskCheckBox.SetItemChecked(1, true);
                }
                else
                {
                    UserConfigurationMaskCheckBox.SetItemChecked(1, false);
                }
                    
                if (PlatformUtils.HasFlag(user.UserConfiguration, UserConfigurationMask.MustChangePassword))
                {
                    UserConfigurationMaskCheckBox.SetItemChecked(2, true);
                }
                else
                {
                    UserConfigurationMaskCheckBox.SetItemChecked(2, false);
                }

                if (PlatformUtils.HasFlag(user.UserConfiguration, UserConfigurationMask.NoDelete))
                {
                    UserConfigurationMaskCheckBox.SetItemChecked(3, true);
                }
                else
                {
                    UserConfigurationMaskCheckBox.SetItemChecked(3, false);
                }
                
            }
        }
        #endregion  

        #region Statistics Tab
        private void UpdateStatistics()
        {
            lock (m_server.DiagnosticsLock)
            {
                var previousSessionCountValue = SessionCountTextBox.Text;
                var newSessionCountValue = m_server.ServerDiagnostics.ServerDiagnosticsSummary.CurrentSessionCount.ToString();
                SessionCountTextBox.Text = newSessionCountValue;

                var previousSubCountValue = SubscriptionCountTextBox.Text;
                var newSubCountValue = m_server.ServerDiagnostics.ServerDiagnosticsSummary.CurrentSubscriptionCount.ToString();
                SubscriptionCountTextBox.Text = newSubCountValue;

                var previousItemCountValue = MonitoredItemCountTextBox.Text;
                var newItemCountValue = m_server.GetMonitoredItemCount().ToString();
                MonitoredItemCountTextBox.Text = newItemCountValue;

                if (EnableTreeViewCB.Checked)
                {
                    if (newItemCountValue != previousItemCountValue ||
                        newSubCountValue != previousSubCountValue ||
                        newSessionCountValue != previousSessionCountValue ||
                        ItemTreeView.Nodes.Count == 0)
                    {
                        UpdateItemTree();
                    }
                    UpdateTreeViewBTN.Enabled = true;
                    ExpandTreeViewBTN.Enabled = true;
                    CollapseTreeViewBTN.Enabled = true;
                }
                else
                {
                    UpdateTreeViewBTN.Enabled = false;
                    ExpandTreeViewBTN.Enabled = false;
                    CollapseTreeViewBTN.Enabled = false;
                    ItemTreeView.BeginUpdate();
                    ItemTreeView.Nodes.Clear();
                    ItemTreeView.EndUpdate();
                }
            }
        }
        private void UpdateItemTree()
        {
            var itemList = m_server.GetMonitoredItemList();

            ItemTreeView.BeginUpdate();
            ItemTreeView.Nodes.Clear();

            var serverNode = ItemTreeView.Nodes.Add("Server");

            foreach (var item in itemList)
            {
                //create TreeViewNodes out of item
                var newSessionNode = new TreeNode($"SessionId: {item.Key.Session.Id} ({item.Key.Session.SessionName})");
                var newSubscriptionNode = new TreeNode("SubscriptionId: " + item.Key.Id.ToString());
                var newMonItemNode = new TreeNode(item.Value);

                bool newSessionNodeExits = false;

                foreach (TreeNode sessionNode in serverNode.Nodes)
                {
                    if (sessionNode.Text == newSessionNode.Text)
                    {
                        newSessionNodeExits = true;
                        bool newSubscriptionNodeExits = false;
                        foreach (TreeNode subscriptionNode in sessionNode.Nodes)
                        {
                            if (subscriptionNode.Text == newSubscriptionNode.Text)
                            {
                                newSubscriptionNodeExits = true;
                                if (!String.IsNullOrEmpty(newMonItemNode.Text))
                                {
                                    subscriptionNode.Nodes.Add(newMonItemNode);
                                }                              
                                subscriptionNode.ToolTipText = $"Monitored Item Count: {subscriptionNode.Nodes.Count}";
                                break;
                            }
                        }
                        if (!newSubscriptionNodeExits)
                        {
                            if (!String.IsNullOrEmpty(newMonItemNode.Text))
                            {
                                newSubscriptionNode.Nodes.Add(newMonItemNode);
                            }
                            newSubscriptionNode.ToolTipText = $"Monitored Item Count: {newSubscriptionNode.Nodes.Count}";
                            sessionNode.Nodes.Add(newSubscriptionNode);
                        }
                        break;
                    }
                }
                if (!newSessionNodeExits)
                {
                    if (!String.IsNullOrEmpty(newMonItemNode.Text))
                    {
                        newSubscriptionNode.Nodes.Add(newMonItemNode);
                    }
                    newSubscriptionNode.ToolTipText = $"Monitored Item Count: {newSubscriptionNode.Nodes.Count}";
                    newSessionNode.Nodes.Add(newSubscriptionNode);
                    serverNode.Nodes.Add(newSessionNode);
                }
            }
            //Add Nodes for Sessions without subscription
            var sessions = m_server.SessionManager.GetSessions(null);
            foreach (var session in m_server.SessionManager.GetSessions(null))
            {
                foreach (TreeNode sessionNode in serverNode.Nodes)
                {
                    if (sessionNode.Text.Contains(session.Id.ToString()))
                    {
                        sessions.Remove(session);
                    }
                }             
            }
            foreach (var sessionToAdd in sessions)
            {
                serverNode.Nodes.Add(new TreeNode($"SessionId: {sessionToAdd.Id} ({sessionToAdd.SessionName})"));
            }
         
            ItemTreeView.ExpandAll();
            ItemTreeView.EndUpdate();
        }

        private void UpdateTreeViewBTN_Click(object sender, EventArgs e)
        {
            lock (m_server.DiagnosticsLock)
            {

                UpdateItemTree();
               
            }
        }

        private void ExpandTreeViewBTN_Click(object sender, EventArgs e)
        {
            ItemTreeView.ExpandAll();
        }

        private void CollapseTreeViewBTN_Click(object sender, EventArgs e)
        {
            ItemTreeView.CollapseAll();
        }

        private void EnableTreeViewCB_CheckedChanged(object sender, EventArgs e)
        {
            if (EnableTreeViewCB.Checked)
            {
                UpdateItemTree();
            }
            else
            {
                ItemTreeView.BeginUpdate();
                ItemTreeView.Nodes.Clear();
                ItemTreeView.EndUpdate();
            }
        }
        #endregion
    }
}
