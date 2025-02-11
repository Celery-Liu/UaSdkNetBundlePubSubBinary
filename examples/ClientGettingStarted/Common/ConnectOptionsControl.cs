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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;
using UnifiedAutomation.UaClient.Controls;

namespace UnifiedAutomation.ClientGettingStarted.Common
{
    public partial class ConnectOptionsControl : UserControl
    {
        public ConnectOptionsControl()
        {
            InitializeComponent();
            string path = "file:///" + System.Environment.CurrentDirectory + @"\html\options.html";
            ConnectBrowser.Url = new Uri(path);

            m_info = new Info[]
            {
                new Info() { Button = FindServersBTN, Type = typeof(FindServersDlg), Handler = FindServersBTN_Click},
                new Info() { Button = GetEndpointsBTN, Type = typeof(GetEndpointsDlg), Handler = GetEndpointsBTN_Click },
                new Info() { Button = CreateCertificateButton, Type = typeof(CreateCertificateDialog), Handler = CreateCertificateButton_Click },
                new Info() { Button = TrustCertificateButton, Type = typeof(TrustCertificateDialog), Handler = TrustCertificateButton_Click },
                new Info() { Button = SimpleConnectButton, Type = typeof(SimpleConnectDlg), Handler = SimpleConnectButton_Click},
                new Info() { Button = AdvancedConnectButton, Type = typeof(AdvancedConnectDialog), Handler = AdvancedConnectButton_Click},
                new Info() { Button = AuthenticationButton, Type = typeof(AuthenticationDlg), Handler = AuthenticationButton_Click},
                new Info() { Button = ReverseConnectButton, Type = typeof(ReverseConnectDialog), Handler = ReverseConnectButton_Click}
            };

#if REVERSE_CONNECT_UNSUPPORTED
            ReverseConnectButton.Enabled = false;
#endif
        }

        private Button m_selectedButton;
        private Info[] m_info;

        private class Info
        {
            public Button Button { get; set; }
            public Type Type { get; set; }
            public EventHandler Handler { get; set; }
        }

        private void ConnectCloseBTN_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            m_selectedButton = sender as Button;
            StartDemoButton.Visible = true;

            foreach (Info info in m_info.Where(i => i.Button == sender))
            {
                NameTextBox.Text = info.Button.Text;
                InstructionsLB.Text = ((MainForm)this.Parent).GetInstructions(info.Type);
                break;
            }
        }

        private void StartDemoButton_Click(object sender, EventArgs e)
        {
            foreach (Info info in m_info.Where(i => i.Button == m_selectedButton))
            {
                info.Handler(sender, e);
                break;
            }
        }

        private void FindServersBTN_Click(object sender, EventArgs e)
        {
            try
            {
                FindServersDlg dialog = new FindServersDlg();
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.ShowDialog(this.ParentForm as MainForm, null);
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void GetEndpointsBTN_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm parent = (MainForm)this.ParentForm;
                GetEndpointsDlg dialog = new GetEndpointsDlg();
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.ShowDialog(parent, null);
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void TopPN_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                NameTextBox.Text = "Click on the Buttons to the Left";
                InstructionsLB.Text = "These examples demonstrate how to discover and connect to OPC UA servers.";
                StartDemoButton.Visible = false;
            }
        }

        private void WarningLB_Click(object sender, EventArgs e)
        {
            WarningLB.Visible = false;
        }

        private void Control_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                try
                {
                    Session session = ((MainForm)this.ParentForm).Session;

                    WarningLB.Visible = (session.ConnectionStatus != ServerConnectionStatus.Connected);
                    WarningLB.Text = String.Format(System.Globalization.CultureInfo.InvariantCulture, "Cannot connect to Server! ({0})", session.ConnectionStatus);
                    // TraceClient.Info("STATUS CHECK for {1}: ServerConnectionStatus={0}", session.ConnectionStatus, this.GetType().Name);
                }
                catch (Exception)
                {
                    WarningLB.Visible = true;
                    WarningLB.Text = String.Format(System.Globalization.CultureInfo.InvariantCulture, "Cannot connect to Server! (Unknown)");
                    // TraceClient.Error(exception, "WARNING DISPLAYED: Error checking server status.");
                }
            }
        }

        private void CreateCertificateButton_Click(object sender, EventArgs e)
        {
            try
            {
                // reload the configuration so it can be updated.
                ApplicationInstance application = new ApplicationInstance();
                application.LoadConfiguration(false, false);

                CreateCertificateDialogSettings settings = new CreateCertificateDialogSettings()
                {
                    Application = application
                };

                CreateCertificateDialog dialog = new CreateCertificateDialog();
                dialog.StartPosition = FormStartPosition.CenterParent;

                ICertificate certificate = dialog.ShowDialog(this.ParentForm as MainForm, settings);

                // update application configuration.
                if (certificate != null)
                {
                    application.ApplicationSettings.ApplicationCertificate.StorePath = certificate.StorePath;
                    application.ApplicationSettings.ApplicationCertificate.SubjectName = certificate.SubjectName;
                    application.SaveConfiguration(false);

                    MessageDialog.Show(ParentForm, "The changes will have no effect until the application is restarted.");
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        /// <summary>
        /// Handles the Click event of the TrustCertificateButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TrustCertificateButton_Click(object sender, EventArgs e)
        {
            try
            {
                TrustCertificateDialog dialog = new TrustCertificateDialog();
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.ShowDialog(this.ParentForm as MainForm);
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void SimpleConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm parent = (MainForm)this.ParentForm;
                SimpleConnectDlg dialog = new SimpleConnectDlg();
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.ShowDialog(parent, null);
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void AdvancedConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm parent = (MainForm)this.ParentForm;
                AdvancedConnectDialog dialog = new AdvancedConnectDialog();
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.ShowDialog(parent, null);
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }
        private void ReverseConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm parent = (MainForm)this.ParentForm;
                ReverseConnectDialog dialog = new ReverseConnectDialog();
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.ShowDialog(parent, null);
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }
        private void AuthenticationButton_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm parent = (MainForm)this.ParentForm;
                AuthenticationDlg dialog = new AuthenticationDlg();
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.ShowDialog(parent, null);
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

    }
}
