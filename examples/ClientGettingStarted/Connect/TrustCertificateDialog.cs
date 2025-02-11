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
using System.IO;
using System.Threading;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;

namespace UnifiedAutomation.ClientGettingStarted
{
    /// <summary>
    /// A dialog that allows a user to review and accept or reject an untrusted certificate.
    /// </summary>
    public partial class TrustCertificateDialog : Form
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TrustCertificateDialog"/> class.
        /// </summary>
        public TrustCertificateDialog()
        {
            InitializeComponent();
            Icon = GuiUtils.GetDefaultIcon();
            this.CancelButton = this.CloseButton;
            SecurityRightsLabel.Visible = !SecurityUtils.CheckIfProcessHasAdminRights();
        }
        #endregion

        #region Private Fields
        private MainForm m_parent;
        private TrustCertificateDialogSettings m_settings;
        private int m_counter;
        #endregion

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public void ShowDialog(MainForm parent)
        {
            try
            {
                HelpBTN.Enabled = parent != null && parent.HelpExists(GetType());
                // fetch the certificate from the current endpoint.
                EndpointDescription endpoint;
                using (Discovery discovery = new Discovery(ApplicationInstanceBase.Default))
                {
                    endpoint = discovery.GetMostSecureEndpoint(parent.Endpoint.EndpointUrl);
                }

                ICertificate certificate = SecurityUtils.LoadCertificate(endpoint.ServerCertificate);

                if (certificate == null)
                {
                    MessageDialog.Show(this, "No server has been selected.");
                    return;
                }

                // launch the trust dialog.
                TrustCertificateDialogSettings settings = new TrustCertificateDialogSettings()
                {
                    Application = parent.Application,
                    UntrustedCertificate = certificate
                };

                bool trust = ShowDialog(parent, settings, 0);

                if (trust)
                {
                    // note that this code does not to enable 'temporary trust'.

                    // the ApplicationInstance.UntrustedCertificate event is raised when a new secure channel
                    // is created. Trapping this event allows you to temporarily ignore trust errors.

                    // save trusted certificate to store if requested.
                    if (settings.SaveToTrustList)
                    {
                        parent.Application.TrustedStore.Add(settings.UntrustedCertificate, true, false);
                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                // set the flag indicating whether it is permanent.
                m_settings.SaveToTrustList = PermanentCheckBox.Checked;

                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        #region Public Interface
        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>The new certificate.</returns>
        /// [Trust Certificate]
        public bool ShowDialog(MainForm owner, TrustCertificateDialogSettings settings, int timeout)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            if (owner.InvokeRequired)
            {
                ManualResetEvent e = new ManualResetEvent(false);
                bool? result = owner.Invoke(new ShowDialogEventHandler(ShowDialog), owner, settings, e) as bool?;

                if (!e.WaitOne(timeout))
                {
                    return false;
                }

                return (result != null) ? result.Value : false;
            }

            m_settings = settings;
            m_parent = owner as MainForm;

            if (timeout != 0)
            {
                m_counter = timeout / 1000 + 1;
                TimeoutTimer.Enabled = true;
                CountdownLabel.Visible = true;
            }

            InstructionsGB.Visible = false;
            WarningLabel.Visible = false;

            if (m_parent != null)
            {
                InstructionsLB.Text = m_parent.GetInstructions(GetType());
                InstructionsGB.Visible = true;
            }

            if (settings.ValidationError.IsBad())
            {
                WarningLabel.Text = "This certificate is not trusted ({0}).\r\nPlease review and decide if you would like to trust it.";
                WarningLabel.Text = String.Format(WarningLabel.Text, settings.ValidationError);
            }

            WarningLabel.Visible = settings.ValidationError.IsBad();

            ICertificate certificate = settings.UntrustedCertificate;

            if (certificate != null)
            {
                Update(certificate);
            }

            if (base.ShowDialog(owner) != DialogResult.OK)
            {
                return false;
            }

            return true;
        }
        /// [Trust Certificate]
        #endregion

        #region Private Methods
        private delegate bool ShowDialogEventHandler(MainForm owner, TrustCertificateDialogSettings settings, int timeout, ManualResetEvent e);

        private static bool ShowDialog(MainForm owner, TrustCertificateDialogSettings settings, int timeout, ManualResetEvent e)
        {
            TrustCertificateDialog dialog = new TrustCertificateDialog();
            dialog.StartPosition = FormStartPosition.CenterParent;

            bool result = dialog.ShowDialog(owner, settings, timeout);

            if (e != null)
            {
                e.Set();

                if (!dialog.IsDisposed)
                {
                    dialog.Close();
                }
            }

            return result;
        }

        private void Update(ICertificate certificate)
        {
            SubjectNameTextBox.Text = certificate.SubjectName;
            IssuerNameTextBox.Text = certificate.IssuerName;
            ApplicationNameTextBox.Text = null;
            OrganizationNameTextBox.Text = null;
            OrganizationUnitTextBox.Text = null;

            if (certificate.IsCertificateAuthority)
            {
                ApplicationNameLabel.Text = "Authority Name";
            }
            else
            {
                ApplicationNameLabel.Text = "Application Name";
            }

            List<string> fields = SecurityUtils.ParseDistinguishedName(certificate.SubjectName);

            foreach (string field in fields)
            {
                if (field.StartsWith("CN=", StringComparison.OrdinalIgnoreCase))
                {
                    ApplicationNameTextBox.Text = field.Substring(3);
                }

                else if (field.StartsWith("O=", StringComparison.OrdinalIgnoreCase))
                {
                    OrganizationNameTextBox.Text = field.Substring(2);
                }

                else if (field.StartsWith("OU=", StringComparison.OrdinalIgnoreCase))
                {
                    OrganizationUnitTextBox.Text = field.Substring(3);
                }
            }

            OrganizationNameTextBox.Visible = !String.IsNullOrEmpty(OrganizationNameTextBox.Text);
            OrganizationNameLabel.Visible = !String.IsNullOrEmpty(OrganizationNameTextBox.Text);
            OrganizationUnitTextBox.Visible = !String.IsNullOrEmpty(OrganizationUnitTextBox.Text);
            OrganizationUnitLabel.Visible = !String.IsNullOrEmpty(OrganizationUnitTextBox.Text);

            ApplicationUriTextBox.Text = SecurityUtils.GetApplicationUriFromCertficate(certificate.InternalCertificate);

            if (!certificate.IsCertificateAuthority)
            {
                IList<string> domains = SecurityUtils.GetDomainsFromCertficate(certificate.InternalCertificate);

                foreach (string domain in domains)
                {
                    if (!String.IsNullOrEmpty(DomainNamesTextBox.Text))
                    {
                        DomainNamesTextBox.Text += ", ";
                    }

                    DomainNamesTextBox.Text += domain;
                }
            }

            ValidFromTextBox.Text = certificate.ValidFrom.ToString("yyyy-MM-dd");
            ValidToTextBox.Text = certificate.ValidTo.ToString("yyyy-MM-dd");
            ThumbprintTextBox.Text = certificate.Thumbprint;

            KeySizeTextBox.Text += "RSA ";
            KeySizeTextBox.Text += PlatformUtils.GetPublicKeySize(certificate).ToString();
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

        private void TimeoutTimer_Tick(object sender, EventArgs e)
        {
            if (m_counter == 0)
            {
                DialogResult = DialogResult.Cancel;
                return;
            }

            CountdownLabel.Text = String.Format("Reject in {0}s", m_counter--);
        }
        #endregion
    }

    /// <summary>
    /// The settings used to initialize a TrustCertificateDialog.
    /// </summary>
    public class TrustCertificateDialogSettings
    {
        /// <summary>
        /// Gets or sets the application instance.
        /// </summary>
        /// <value>
        /// The application instance.
        /// </value>
        public ApplicationInstanceBase Application { get; set; }

        /// <summary>
        /// Gets or sets the untrusted certificate.
        /// </summary>
        /// <value>
        /// The untrusted certificate.
        /// </value>
        public ICertificate UntrustedCertificate { get; set; }

        /// <summary>
        /// Gets or sets the issuer certificates included with the certificate.
        /// </summary>
        /// <value>
        /// The issuer certificates included with the certificate.
        /// </value>
        public IList<ICertificate> Issuers { get; set; }

        /// <summary>
        /// Gets or sets the certificate validation error.
        /// </summary>
        /// <value>
        /// The certificate validation error.
        /// </value>
        public StatusCode ValidationError { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether save the certificate to the application trust list.
        /// </summary>
        /// <value>
        /// <c>true</c> if certificate should be saved to the application trust list; otherwise, <c>false</c>.
        /// </value>
        public bool SaveToTrustList { get; set; }
    }
}
