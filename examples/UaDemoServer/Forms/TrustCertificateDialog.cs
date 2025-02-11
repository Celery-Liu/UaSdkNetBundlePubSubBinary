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

namespace UnifiedAutomation.Sample
{
#if NET
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
#endif
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
            SecurityRightsLabel.Visible = !SecurityUtils.CheckIfProcessHasAdminRights();
        }
        #endregion

        #region Private Fields
        private TrustCertificateDialogSettings m_settings;
        #endregion

        #region Public Interface
        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>True if the certificate should be trusted.</returns>
        public static DialogResult ShowDialog(Form owner, TrustCertificateDialogSettings settings, int timeout)
        {
            if (owner != null && owner.InvokeRequired)
            {
                ManualResetEvent e = new ManualResetEvent(false);
                var result = owner.Invoke(new ShowDialogEventHandler(ShowDialog), owner, settings, e) as DialogResult?;

                if (!e.WaitOne(timeout, false))
                {
                    return DialogResult.Cancel;
                }

                return (result != null) ? result.Value : DialogResult.Cancel;
            }

            return ShowDialog(owner, settings, null);
        }

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>The new certificate.</returns>
        public DialogResult ShowDialog(IWin32Window owner, TrustCertificateDialogSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            m_settings = settings;

            InstructionsTextBox.Text = "This certificate is not valid ({0}).\r\nPlease review and decide if you would like to use it anyways.";
            InstructionsTextBox.Text = String.Format(InstructionsTextBox.Text, settings.ValidationError);

            if (settings.IsHttpsCertificate)
            {
                PermanentCheckBox.Visible = false;
                ApplicationNameLabel.Text = "Domain Name";
                ApplicationUriLabel.Visible = false;
                ApplicationUriTextBox.Visible = false;
                DomainNamesLabel.Visible = false;
                DomainNamesTextBox.Visible = false;
            }

            ICertificate certificate = settings.UntrustedCertificate;

            if (certificate != null)
            {
                Update(certificate);
            }

            return base.ShowDialog(owner);

        }
        #endregion

        #region Private Methods
        private delegate DialogResult ShowDialogEventHandler(Form owner, TrustCertificateDialogSettings settings, ManualResetEvent e);

        private static DialogResult ShowDialog(IWin32Window owner, TrustCertificateDialogSettings settings, ManualResetEvent e)
        {
            TrustCertificateDialog dialog = new TrustCertificateDialog();
            dialog.StartPosition = FormStartPosition.CenterParent;

            var result = dialog.ShowDialog(owner, settings);

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
                ApplicationNameLabel.Text = "CertificateGroup Name";
            }
            else
            {
                ApplicationNameLabel.Text = "Common Name";
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

            if (m_settings.ValidationError != StatusCodes.BadCertificateUntrusted)
            {
                Text = "ValidationError: " + m_settings.ValidationError;
                OkButton.Text = "Continue";
            }

            if (m_settings.ValidationError.Flattened.Count > 1)
            {
                InstructionsTextBox.Height += 12 * m_settings.ValidationError.Flattened.Count;
                InstructionsTextBox.Text = InstructionsTextBox.Text + "\r\nAdditional Validation Errors: ";
                for (int ii = 1; ii < m_settings.ValidationError.Flattened.Count; ii++)
                {
                    InstructionsTextBox.Text = InstructionsTextBox.Text + "\r\n - " + m_settings.ValidationError.Flattened[ii];
                    switch (m_settings.ValidationError.Flattened[ii].CodeBits)
                    {
                        case StatusCodes.BadCertificateTimeInvalid:
                            ValidToTextBox.BackColor = Color.Orange;
                            break;
                        case StatusCodes.BadCertificateHostNameInvalid:
                            DomainNamesTextBox.BackColor = Color.Orange;
                            break;
                        case StatusCodes.BadCertificateUriInvalid:
                            ApplicationUriTextBox.BackColor = Color.Orange;
                            break;
                    }
                }
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                m_settings.SaveToTrustList = PermanentCheckBox.Checked;
                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
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
        public ICertificate[] Issuers { get; set; }

        /// <summary>
        /// Gets or sets the certificate validation error.
        /// </summary>
        /// <value>
        /// The certificate validation error.
        /// </value>
        public StatusCode ValidationError { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the untrusted certificate is an HTTPS certificate.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the certificate is an HTTPS certificate; otherwise, <c>false</c>.
        /// </value>
        public bool IsHttpsCertificate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether save the certificate to the application trust list.
        /// </summary>
        /// <value>
        /// <c>true</c> if certificate should be saved to the application trust list; otherwise, <c>false</c>.
        /// </value>
        public bool SaveToTrustList { get; set; }
    }
}
