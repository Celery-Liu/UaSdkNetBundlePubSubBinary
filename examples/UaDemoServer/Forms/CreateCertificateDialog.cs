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
    /// A dialog that allows a user to create a new application certificate.
    /// </summary>
    public partial class CreateCertificateDialog : Form
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCertificateDialog"/> class.
        /// </summary>
        public CreateCertificateDialog()
        {
            InitializeComponent();

            SecurityRightsLabel.Visible = !SecurityUtils.CheckIfProcessHasAdminRights();

            foreach (object value in Enum.GetValues(typeof(KeySize)))
            {
                KeySizeComboBox.Items.Add(value);
            }

            KeySizeComboBox.SelectedIndex = 1;

            foreach (object value in Enum.GetValues(typeof(HashAlgorithm)))
            {
                HashAlgorithmComboBox.Items.Add(value);
            }

            HashAlgorithmComboBox.SelectedIndex = 0;

            BasicButton_Click(this, null);
        }
        #endregion

        #region Private Fields
        private ICertificate m_certificate;
        private string m_lastFolder;
        private bool m_isHttpsCertificate;
        private ApplicationInstanceBase m_application;
        #endregion

        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                CreateCertificateSettings settings = new CreateCertificateSettings()
                {
                    CommonName = CommonNameTextBox.Text.Trim(),
                    ApplicationUri = ApplicationUriTextBox.Text.Trim(),
                    SubjectName = SubjectNameTextBox.Text.Trim(),
                };

                // get the path to the store where the new certificate will be placed.
                string storePath = StorePathTextBox.Text.Trim();

                if (String.IsNullOrEmpty(storePath))
                {
                    throw new ArgumentException("Please specify a path to the certificate store.", "StorePath");
                }

                // get the path to the certificate (if provided) that will be used to sign the certificate.
                string issuerKeyFile = IssuerKeyFileTextBox.Text.Trim();

                if (!String.IsNullOrEmpty(issuerKeyFile))
                {
                    string issuerPassword = IssuerPasswordTextBox.Text.Trim();

                    if (!File.Exists(issuerKeyFile))
                    {
                        throw new ArgumentException("Please specify a valid path to an issuer key file.", "IssuerKeyFile");
                    }

                    try
                    {
                        X509Certificate2 certificate = null;

                        if (String.IsNullOrEmpty(issuerPassword))
                        {
                            certificate = new X509Certificate2(issuerKeyFile);
                        }
                        else
                        {
                            certificate = new X509Certificate2(issuerKeyFile, issuerPassword);
                        }
                    }
                    catch (CryptographicException exception)
                    {
                        throw new ArgumentException("Could not open the key file.", "IssuerKeyFile", exception);
                    }

                    byte[] bytes = File.ReadAllBytes(issuerKeyFile);

                    settings.Issuer = new CertificateKeyPair()
                    {
                        Certificate = new Certificate(bytes, issuerPassword),
                        PrivateKey = bytes,
                        PrivateKeyFormat = PrivateKeyFormats.PFX,
                        PrivateKeyPassword = issuerPassword
                    };
                }

                // the name of the application.
                if (String.IsNullOrEmpty(settings.CommonName))
                {
                    throw new ArgumentException("Please specify an application name.", "ApplicationName");
                }

                // the name of application uri.
                if (!m_isHttpsCertificate)
                {
                    if (String.IsNullOrEmpty(settings.ApplicationUri))
                    {
                        throw new ArgumentException("Please specify an application URI.", "ApplicationUri");
                    }

                    if (!Uri.IsWellFormedUriString(settings.ApplicationUri, UriKind.Absolute))
                    {
                        throw new ArgumentException("Please specify a valid URI for the application URI.", "ApplicationUri");
                    }

                    // parse the subject name.
                    List<string> fields = SecurityUtils.ParseDistinguishedName(settings.SubjectName);

                    StringBuilder buffer = new StringBuilder();

                    foreach (string field in fields)
                    {
                        if (buffer.Length > 0)
                        {
                            buffer.Append("/");
                        }

                        buffer.Append(field);
                    }

                    settings.SubjectName = buffer.ToString();

                    // get the domains.
                    string[] domainNames = DomainNamesTextBox.Text.Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int ii = 0; ii < domainNames.Length; ii++)
                    {
                        domainNames[ii] = domainNames[ii].Trim();
                    }

                    settings.DomainNames = domainNames;
                }

                // get the key size.
                switch ((KeySize)KeySizeComboBox.SelectedItem)
                {
                    case KeySize.Rsa1024: { settings.KeySize = 1024; break; }
                    case KeySize.Rsa2048: { settings.KeySize = 2048; break; }
                    case KeySize.Rsa3072: { settings.KeySize = 3072; break; }
                    case KeySize.Rsa4096: { settings.KeySize = 4096; break; }
                }

                // get the hash algorithm.
                switch ((HashAlgorithm)HashAlgorithmComboBox.SelectedItem)
                {
                    case HashAlgorithm.Sha1: { settings.HashSizeInBits = 160; break; }
                    case HashAlgorithm.Sha256: { settings.HashSizeInBits = 256; break; }
                }

                settings.LifetimeInMonths = (ushort)LifetimeUpDown.Value;

                if (!String.IsNullOrEmpty(PasswordTextBox.Text))
                {
                    settings.PrivateKeyPassword = PasswordTextBox.Text;
                    MessageBox.Show(
                        "A password cannot be stored in the configuration of the ApplicationCertificate."
                        + " To use the certificate you have to remove the ApplicationCertificate section from the configuration"
                        + " and load the certificate manually:\n"
                        + "Use DirectoryCertificateStore.Find to assign the certificate to ApplicationInstance.ApplicationCertificate.",
                        "Password used to save private key file.");
                }

                // create the new certificate.
                var certificateFactory = m_application.SecurityProvider.CreateCertificateFactory();
                if (certificateFactory == null)
                {
                    throw new Exception("The used SecurityProvider does not return a CertificateFactory.");
                }
                m_certificate = certificateFactory.CreateCertificate(storePath, settings);

                Cursor = Cursors.Default;

                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                Cursor = Cursors.Default;

                ExceptionDlg.Show(this.Text, exception);
            }
        }

        #region Public Interface
        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>
        /// The new certificate.
        /// </returns>
        public ICertificate ShowDialog(CreateCertificateDialogSettings settings)
        {
            WarningLabel.Visible = false;

            if (!String.IsNullOrEmpty(settings.Instructions))
            {
                WarningLabel.Text = settings.Instructions;
                WarningLabel.Visible = true;
            }

            m_application = settings.Application as ApplicationInstanceBase;

            if (m_application == null)
            {
                m_application = ApplicationInstanceBase.Default;
            }

            string hostName = System.Net.Dns.GetHostName();

            UaSchema.IConfiguration configuration = m_application.ApplicationSettings;

            m_lastFolder = Environment.CurrentDirectory;

            // get the default store path.
            if (String.IsNullOrEmpty(settings.StorePath))
            {
                if (configuration.ApplicationCertificate != null)
                {
                    settings.StorePath = configuration.ApplicationCertificate.StorePath;
                }
            }

            m_lastFolder = StorePathTextBox.Text = settings.StorePath;

            // get the default application URI.
            string applicationUri = configuration.ApplicationUri.Replace("localhost", hostName);

            // get the domains.
            if (settings.DomainNames == null || settings.DomainNames.Count == 0)
            {
                settings.DomainNames = new List<string>();
                settings.DomainNames.Add(hostName);
            }

            if (String.IsNullOrEmpty(settings.SubjectName))
            {
                if (configuration.ApplicationCertificate != null)
                {
                    settings.SubjectName = configuration.ApplicationCertificate.SubjectName.Replace("localhost", settings.DomainNames[0]);
                }
            }

            // update settings from template if specified.
            if (settings.Template != null)
            {
                if (!String.IsNullOrEmpty(settings.Template.StorePath))
                {
                    m_lastFolder = StorePathTextBox.Text = settings.Template.StorePath;
                }

                settings.SubjectName = settings.Template.SubjectName;

                applicationUri = SecurityUtils.GetApplicationUriFromCertficate(settings.Template.InternalCertificate);

                var templateDomains = SecurityUtils.GetDomainsFromCertficate(settings.Template.InternalCertificate);

                if (templateDomains != null && templateDomains.Count > 0)
                {
                    settings.DomainNames = templateDomains;
                }
            }

            // build list of domains.
            StringBuilder domainNames = new StringBuilder();

            foreach (var domainName in settings.DomainNames)
            {
                if (domainNames.Length > 0)
                {
                    domainNames.Append(",");
                }

                domainNames.Append(domainName);
            }

            CommonNameTextBox.Text = configuration.ApplicationName.Replace("localhost", hostName);
            ApplicationUriTextBox.Text = applicationUri;
            DomainNamesTextBox.Text = domainNames.ToString();
            OrganizationUnitTextBox.Text = null;
            OrganizationNameTextBox.Text = null;
            LifetimeUpDown.Value = 60;
            SubjectNameTextBox.Text = null;
            SubjectNameCheckBox.Checked = false;
            IssuerKeyFileTextBox.Text = settings.IssuerKeyFilePath;

            if (settings.IsHttpsCertificate)
            {
                m_isHttpsCertificate = true;
                CommonNameTextBox.Text = settings.HttpsDomainName;
                DomainNamesLabel.Visible = false;
                DomainNamesTextBox.Visible = false;
                ApplicationUriLabel.Visible = false;
                ApplicationUriTextBox.Visible = false;
                ApplicationUriTextBox.Text = "";
                CommonNameLabel.Text = "Domain Name";
            }

            if (!settings.IsHttpsCertificate && !String.IsNullOrEmpty(settings.SubjectName))
            {
                ExtractFieldsFromSubjectName(settings.SubjectName);
                UpdateSubjectName();

                if (SubjectNameTextBox.Text != settings.SubjectName)
                {
                    SubjectNameTextBox.Text = settings.SubjectName;
                    SubjectNameCheckBox.Checked = true;
                }
            }

            // Use KeySize and HashAlgorithm from InsatllationSettings if available
            UaSchema.InstallationSettings installationSettings = m_application.GetConfigurationExtension<UaSchema.InstallationSettings>(true);

            if (installationSettings != null)
            {
                if (installationSettings.CertificateKeyLength != 0
                        && installationSettings.CertificateKeyLength % 1024 == 0
                        && installationSettings.CertificateKeyLength <= 4096)
                {
                    KeySizeComboBox.SelectedIndex = installationSettings.CertificateKeyLength / 1024 - 1;
                }
                if (!String.IsNullOrEmpty(installationSettings.CertificateHashAlgorithm))
                {
                    switch (installationSettings.CertificateHashAlgorithm)
                    {
                        case "sha1":
                            HashAlgorithmComboBox.SelectedIndex = 1;
                            break;
                        case "sha256":
                            HashAlgorithmComboBox.SelectedIndex = 0;
                            break;
                        default:
                            break;
                    }
                }
            }

            ApplicationNameTextBox_TextChanged(this, null);

            if (base.ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            return m_certificate;
        }

        public bool PersistConfiguration
        {
            get
            {
                return PersistConfigurationCheckBox.Checked;
            }
        }
        #endregion

        #region PublicKeyAlgorithm Enumeration
        private enum KeySize
        {
            Rsa1024,
            Rsa2048,
            Rsa3072,
            Rsa4096
        }
        #endregion

        #region HashAlgorithm Enumeration
        private enum HashAlgorithm
        {
            Sha256,
            Sha1
        }
        #endregion

        #region Private Methods
        private void AppendField(StringBuilder buffer, string name, string value)
        {
            string text = value.Trim();

            if (!String.IsNullOrEmpty(value))
            {
                bool quotes = text.Contains('/') || text.Contains('=');

                if (buffer.Length > 0)
                {
                    buffer.Append("/");
                }

                buffer.Append(name);
                buffer.Append("=");

                if (quotes)
                {
                    buffer.Append("\"");
                }

                buffer.Append(text);

                if (quotes)
                {
                    buffer.Append("\"");
                }
            }
        }

        private void ExtractFieldsFromSubjectName(string subjectName)
        {
            List<string> fields = SecurityUtils.ParseDistinguishedName(subjectName);

            string compositeDomainName = String.Empty;

            foreach (string field in fields)
            {
                if (field.StartsWith("CN=", StringComparison.OrdinalIgnoreCase))
                {
                    CommonNameTextBox.Text = field.Substring(3);
                }
                else if (field.StartsWith("O=", StringComparison.OrdinalIgnoreCase))
                {
                    OrganizationNameTextBox.Text = field.Substring(2);
                }
                else if (field.StartsWith("OU=", StringComparison.OrdinalIgnoreCase))
                {
                    OrganizationUnitTextBox.Text = field.Substring(3);
                }
                else if (field.StartsWith("DC=", StringComparison.OrdinalIgnoreCase))
                {
                    string domainName = field.Substring(3);

                    if (compositeDomainName.Length > 0)
                    {
                        compositeDomainName += ".";
                    }

                    compositeDomainName += domainName;
                }
            }

            var domains = DomainNamesTextBox.Text.Split(',');

            foreach (var domain in domains)
            {
                if (String.Compare(domain, compositeDomainName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    return;
                }
            }

            if (DomainNamesTextBox.Text.Length > 0)
            {
                DomainNamesTextBox.Text += ",";
            }

            DomainNamesTextBox.Text += compositeDomainName;
        }

        private void UpdateSubjectName()
        {
            StringBuilder buffer = new StringBuilder();

            AppendField(buffer, "CN", CommonNameTextBox.Text);
            AppendField(buffer, "OU", OrganizationUnitTextBox.Text);
            AppendField(buffer, "O", OrganizationNameTextBox.Text);

            string[] domainNames = DomainNamesTextBox.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int ii = 0; ii < domainNames.Length; )
            {
                AppendField(buffer, "DC", domainNames[ii]);
                break;
            }

            SubjectNameTextBox.Text = buffer.ToString();
        }

        private void ApplicationNameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (SubjectNameCheckBox.Checked)
                {
                    return;
                }

                UpdateSubjectName();
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void DomainNamesTextBox_TextChanged(object sender, EventArgs e)
        {
            ApplicationNameTextBox_TextChanged(sender, e);
        }

        private void StorePathButton_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.ShowNewFolderButton = true;
                dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                dialog.SelectedPath = StorePathTextBox.Text;

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                StorePathTextBox.Text = dialog.SelectedPath;
                m_lastFolder = dialog.SelectedPath;
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void IssuerKeyFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(IssuerKeyFileTextBox.Text))
                {
                    m_lastFolder = new FileInfo(IssuerKeyFileTextBox.Text).Directory.FullName;
                }

                OpenFileDialog dialog = new OpenFileDialog();

                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.DefaultExt = "*.pfx";
                dialog.Filter = "PFX Files (*.pfx)|*.pfx|All Files (*.*)|*.*";
                dialog.Multiselect = false;
                dialog.ValidateNames = true;
                dialog.FileName = IssuerKeyFileTextBox.Text;
                dialog.InitialDirectory = m_lastFolder;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                IssuerKeyFileTextBox.Text = dialog.FileName;
                m_lastFolder = new FileInfo(dialog.FileName).Directory.FullName;
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void BasicButton_Click(object sender, EventArgs e)
        {
            try
            {
                BasicButton.Visible = false;
                AdvancedButton.Visible = true;
                KeySizeLabel.Visible = false;
                KeySizeComboBox.Visible = false;
                HashAlgorithmLabel.Visible = false;
                HashAlgorithmComboBox.Visible = false;
                LifetimeLabel.Visible = false;
                LifetimePanel.Visible = false;
                PasswordLabel.Visible = false;
                PasswordTextBox.Visible = false;
                IssuerKeyFileLabel.Visible = false;
                IssuerKeyFileTextBox.Visible = false;
                IssuerKeyFileButton.Visible = false;
                IssuerPasswordLabel.Visible = false;
                IssuerPasswordTextBox.Visible = false;
                StorePathButton.Visible = false;
                StorePathLabel.Visible = false;
                StorePathTextBox.Visible = false;
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void AdvancedButton_Click(object sender, EventArgs e)
        {
            try
            {
                BasicButton.Visible = true;
                AdvancedButton.Visible = false;
                KeySizeLabel.Visible = true;
                KeySizeComboBox.Visible = true;
                HashAlgorithmLabel.Visible = true;
                HashAlgorithmComboBox.Visible = true;
                LifetimeLabel.Visible = true;
                LifetimePanel.Visible = true;
                PasswordLabel.Visible = true;
                PasswordTextBox.Visible = true;
                IssuerKeyFileLabel.Visible = true;
                IssuerKeyFileTextBox.Visible = true;
                IssuerKeyFileButton.Visible = true;
                IssuerPasswordLabel.Visible = true;
                IssuerPasswordTextBox.Visible = true;
                StorePathButton.Visible = true;
                StorePathLabel.Visible = true;
                StorePathTextBox.Visible = true;
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void SubjectNameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SubjectNameTextBox.Enabled = SubjectNameCheckBox.Checked;
            CommonNameTextBox.Enabled = !SubjectNameCheckBox.Checked;
            OrganizationNameTextBox.Enabled = !SubjectNameCheckBox.Checked;
            OrganizationUnitTextBox.Enabled = !SubjectNameCheckBox.Checked;
        }
        #endregion
    }

    /// <summary>
    /// The settings used to initialize a CreateCertificateDialog.
    /// </summary>
    public class CreateCertificateDialogSettings
    {
        /// <summary>
        /// Gets or sets the instructions.
        /// </summary>
        /// <value>
        /// The instructions.
        /// </value>
        public string Instructions { get; set; }

        /// <summary>
        /// Gets or sets the application instance.
        /// </summary>
        /// <value>
        /// The application instance.
        /// </value>
        public ApplicationInstanceBase Application { get; set; }

        /// <summary>
        /// Gets or sets the store path.
        /// </summary>
        /// <value>
        /// The store path.
        /// </value>
        public string StorePath { get; set; }

        /// <summary>
        /// Gets or sets the issuer key file path.
        /// </summary>
        /// <value>
        /// The issuer key file path.
        /// </value>
        public string IssuerKeyFilePath { get; set; }

        /// <summary>
        /// Gets or sets the certificate distinguished subject name.
        /// </summary>
        /// <value>
        /// The certificate distinguished subject name.
        /// </value>
        public string SubjectName { get; set; }

        /// <summary>
        /// Gets or sets the domain names.
        /// </summary>
        /// <value>
        /// The domain names.
        /// </value>
        public IList<string> DomainNames { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether an HTTP certificate is being created.
        /// </summary>
        /// <value>
        /// <c>true</c> if an HTTP certificate is being created; otherwise, <c>false</c>.
        /// </value>
        public bool IsHttpsCertificate { get; set; }

        /// <summary>
        /// Gets or sets the HTTPS domain name.
        /// </summary>
        /// <value>
        /// The HTTPS domain names.
        /// </value>
        public string HttpsDomainName
        {
            get
            {
                if (DomainNames != null && DomainNames.Count > 0)
                {
                    return DomainNames[0];
                }

                return null;
            }

            set
            {
                if (DomainNames != null && DomainNames.Count > 0)
                {
                    DomainNames[0] = value;
                }

                DomainNames = new List<string>();
                DomainNames.Add(value);
            }
        }

        /// <summary>
        /// Gets or sets the exsiting certificate or a template to copy.
        /// </summary>
        /// <value>
        /// The exsiting certificate or a template to copy.
        /// </value>
        public ICertificate Template { get; set; }
    }
}
