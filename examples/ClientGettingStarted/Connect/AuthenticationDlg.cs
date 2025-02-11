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
    public partial class AuthenticationDlg : Form
    {
        public AuthenticationDlg()
        {
            InitializeComponent();
            CancelButton = this.CloseButton;
            Icon = GuiUtils.GetDefaultIcon();
            AuthenticationTLP.CellPaint += tableLayoutPanel3_CellPaint;
        }

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
                InstructionsGB.Text = parent.GetInstructions(GetType());
                ConnectionSettings.Visible = true;
            }
            HelpBTN.Enabled = parent != null && parent.HelpExists(GetType());

            ServerUrl.Text = defaultUrl;

            // get default values
            if (String.IsNullOrEmpty(ServerUrl.Text))
            {
                if (parent != null && parent.Endpoint != null)
                {
                    ServerUrl.Text = parent.Endpoint.EndpointUrl;
                }
                else
                {
                    ServerUrl.Text = "opc.tcp://localhost:48030";
                }
            }

            m_session = m_parent.Session;

            //Remember UseDnsNameAndPortFromDiscoveryUrl. Reset on dialog close.
            m_useDsnOnStartup = m_session.UseDnsNameAndPortFromDiscoveryUrl;
            m_session.UseDnsNameAndPortFromDiscoveryUrl = true;

            //Buttons
            EnableConnectButtons();
            m_session.ConnectionStatusUpdate += new ServerConnectionStatusUpdateEventHandler(OnConnectionStatusUpdate);

            //Status
            ConnectionStatus.Text = m_session.ConnectionStatus.ToString();

            ShowDialog();
        }
        #endregion

        #region GUI Event Handlers
        private void Close_Click(object sender, EventArgs e)
        {
            m_session.UseDnsNameAndPortFromDiscoveryUrl = m_useDsnOnStartup;
            m_session.ConnectionStatusUpdate -= new ServerConnectionStatusUpdateEventHandler(OnConnectionStatusUpdate);
            Close();
        }

        private void tableLayoutPanel3_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row > 0)
            {
                Point TopLeft;
                if (e.Column == 0)
                {
                    TopLeft = new Point(e.CellBounds.Left + 20, e.CellBounds.Top);
                }
                else
                {
                    TopLeft = new Point(e.CellBounds.Left, e.CellBounds.Top);
                }
                Point TopRight = new Point(e.CellBounds.Right, e.CellBounds.Top);
                e.Graphics.DrawLine(new Pen(Color.Snow), TopLeft, TopRight);
            }
        }

        private void ShowCodeButton_Click(object sender, EventArgs e)
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

        private void HelpButton_Click(object sender, EventArgs e)
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

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            SetUserToken();
            try
            {
                if (m_session.ConnectionStatus != ServerConnectionStatus.Disconnected)
                {
                    m_session.Disconnect();
                }
                if (UseAsynchronous.Checked)
                {
                    m_session.BeginConnect(
                        ServerUrl.Text,
                        UseSecurity.Checked ? SecuritySelection.BestAvailable : SecuritySelection.None,
                        null,
                        RetryInitialConnect.No,
                        m_session.DefaultRequestSettings,
                        OnConnectCompleted,
                        m_session);
                }
                else
                {
                    m_session.Connect(
                        ServerUrl.Text,
                        UseSecurity.Checked ? SecuritySelection.BestAvailable : SecuritySelection.None);
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            if (UseAsynchronous.Checked)
            {
                m_session.BeginDisconnect(
                    OnDisconnectCompleted,
                    m_session);
            }
            else
            {
                m_session.Disconnect();
            }
        }

        #endregion

        #region SDK Event Handlers
        private void OnConnectionStatusUpdate(Session sender, ServerConnectionStatusUpdateEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ServerConnectionStatusUpdateEventHandler(OnConnectionStatusUpdate), sender, e);
                return;
            }
            EnableConnectButtons();
            ConnectionStatus.Text = e.Status.ToString();
        }

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

        /// [InsecureCredentials EventHandler]
        void OnInsecureCredentials(Session sender, InsecureCredentialsEventArgs e)
        {
            // need to make sure the results are processed on the correct thread.
            if (InvokeRequired)
            {
                Invoke(new InsecureCredentialsEventHandler(OnInsecureCredentials), sender, e);
                return;
            }

            InsecureCredentialsDialog dialog = new InsecureCredentialsDialog();
            dialog.ShowDialog(m_session, e);
            // Set AllowInsecureCredentials to true if the risk is accepted.
            if (dialog.DialogResult == DialogResult.OK)
            {
                e.AllowInsecureCredentials = true;
            }
            else
            {
                e.AllowInsecureCredentials = false;
            }
        }
        /// [InsecureCredentials EventHandler]
        #endregion

        #region Helpers
        private void EnableConnectButtons()
        {
            ConnectButton.Enabled = (m_session.ConnectionStatus != ServerConnectionStatus.Connected
                && m_session.ConnectionStatus != ServerConnectionStatus.Connecting);
            DisconnectButton.Enabled = m_session.ConnectionStatus != ServerConnectionStatus.Disconnected;
        }

        private void SetUserToken()
        {
            if (m_session.UserIdentity == null)
            {
                m_session.UserIdentity = new UserIdentity();
            }
            /// [Anonymous]
            if (AnonymousButton.Checked)
            {
                m_session.UserIdentity.IdentityType = UserIdentityType.Anonymous;
            }
            /// [Anonymous]
            /// [UserName]
            else if (UserNameButton.Checked)
            {
                m_session.UserIdentity.IdentityType = UserIdentityType.UserName;
                m_session.UserIdentity.UserName = UserName_Name.Text;
                m_session.UserIdentity.Password = UserName_Password.Text;
            }
            /// [UserName]
            /// [X509 (Dir)]
            else if (X509Button.Checked)
            {
                try
                {
                    // Add the certificate to the user identity.
                    m_session.UserIdentity.Certificate = Certificate.LoadPrivateKey(X509_Certificate.Text, null);

                    // Set the UserIdentityType.
                    m_session.UserIdentity.IdentityType = UserIdentityType.Certificate;
                }
                catch (Exception ex)
                {
                    ExceptionDlg.ShowInnerException(this.Text, ex);
                }
            }

            /// [X509 (Dir)]
            /// [X509 (Store)]
            else if (X509StoreButton.Checked)
            {
                try
                {
                    // Create the certificate store.
                    using (ICertificateStore store = SecurityUtils.CreateStore(m_application.SecurityProvider, X509StorePath.Text.Trim()))
                    {
                        // Load the certificate.
                        ICertificate certificate = store.Find(X509StoreCertificate.Text.Trim(), null, true);

                        // If the certificate could not be found, try to find the certificate without a
                        // private key. This allows to use a more helpful exception message.
                        if (certificate == null)
                        {
                            certificate = store.Find(X509StoreCertificate.Text.Trim(), null, false);

                            if (certificate != null)
                            {
                                throw new ArgumentException("The Certificate must have an accessible private key.");
                            }
                            else
                            {
                                throw new ArgumentException("The Certificate does not exist.");
                            }
                        }

                        // Add the certificate to the user identity.
                        m_session.UserIdentity.Certificate = certificate;

                        // Set the UserIdentityType.
                        m_session.UserIdentity.IdentityType = UserIdentityType.Certificate;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionDlg.ShowInnerException(this.Text, ex);
                }
            }
            /// [X509 (Store)]
        }

        private void BrowseCertificate_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (String.IsNullOrEmpty(X509_Certificate.Text))
            {
                dialog.InitialDirectory = m_application.ApplicationSettings.ApplicationCertificate.StorePath + "\\private";
            }
            else
            {
                string directory = X509_Certificate.Text;
                int index = directory.LastIndexOf('\\');
                directory = directory.Remove(index);
                dialog.InitialDirectory = directory;
            }
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            X509_Certificate.Text = dialog.FileName;
        }

        private void UseAsynchronous_CheckedChanged(object sender, EventArgs e)
        {
            if (UseAsynchronous.Checked)
            {
                InsecureCredicals.Enabled = true;
                UseSecurity.Enabled = true;
                UserNameButton.Enabled = true;
            }
            else
            {
                InsecureCredicals.Enabled = false;
                InsecureCredicals.Checked = false;
                UseSecurity.Enabled = false;
                UseSecurity.Checked = false;
                UserNameButton.Enabled = false;
                if (UserNameButton.Checked)
                {
                    AnonymousButton.Checked = true;
                }
            }
        }

        private void InsecureCredicals_CheckedChanged(object sender, EventArgs e)
        {
            if (InsecureCredicals.Checked)
            {
                /// [Assign InsecureCredentials]
                m_session.InsecureCredentials += OnInsecureCredentials;
                /// [Assign InsecureCredentials]
            }
            else
            {
                m_session.InsecureCredentials -= OnInsecureCredentials;
            }
        }
        #endregion

        #region Private Fields
        private MainForm m_parent;
        private Session m_session;
        private ApplicationInstance m_application;
        private bool m_useDsnOnStartup;
        #endregion

    }
}
