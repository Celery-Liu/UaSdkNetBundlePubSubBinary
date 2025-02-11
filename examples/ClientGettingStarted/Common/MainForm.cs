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
using System.Linq.Expressions;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;
using UnifiedAutomation.UaClient.Controls;

namespace UnifiedAutomation.ClientGettingStarted
{
    public partial class MainForm : Form
    {
        #region Constructors
        public MainForm(ApplicationInstance application)
        {
            InitializeComponent();
            Icon = GuiUtils.GetAppIcon();

            m_application = application;
            m_application.UntrustedCertificate += new UntrustedCertificateEventHandler(Application_UntrustedCertificate);

            string path = "file:///" + System.Environment.CurrentDirectory + @"\html\index.html";
            MainBrowser.Url = new Uri(path);

            Load += new EventHandler(MainForm_Load);
        }

        /// <summary>
        /// Calls Discovery.GetEndpoints.
        /// </summary>
        /// <remarks>
        /// There are event handlers for the ApplicationInstance implemented in the MainForm class
        /// and assigned in the constructor of MainForm. So ApllicationInstance.Start must be called
        /// after the constructor of MainWindow. But calling Discovery.GetEndpoints starts
        /// Application.Default implicitly. By using this event handler the order of calling is
        /// 1. Constructor of MainForm
        /// 2. ApplicationInstance.Start
        /// 3. Discovery.GetEndpoints
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MainForm_Load(object sender, EventArgs e)
        {
            // find the default endpoint
            try
            {
                List<EndpointDescription> endpoints;
                using (Discovery discovery = new Discovery(m_application))
                {
                    endpoints = discovery.GetEndpoints("opc.tcp://localhost:48030");
                }
                foreach (EndpointDescription endpoint in endpoints)
                {
                    if (endpoint.SecurityMode == MessageSecurityMode.None
                        && endpoint.TransportProfileUri == TransportProfiles.UaTcpTransport)
                    {
                        SelectEndpointControl.Endpoints.Add(endpoint);
                        SelectEndpointControl.SelectedEndpointIndex = 0;
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                Exception innerException = exception;
                while (innerException.InnerException != null)
                {
                    innerException = innerException.InnerException;
                }

                if (innerException is System.Net.Sockets.SocketException)
                {
                    MessageBox.Show("SocketException caught. Check if Server is running.", "SocketException caught", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ExceptionDlg.Show(this.Text, innerException);
            }
        }
        #endregion

        #region Private Fields
        private ApplicationInstance m_application;
        private Session m_session;
        private HelpForm m_HelpForm;
        #endregion

        #region Public Interface
        /// <summary>
        /// Gets the endpoint.
        /// </summary>
        public EndpointDescription Endpoint
        {
            get
            {
                return SelectEndpointControl.SelectedEndpoint;
            }
        }

        /// <summary>
        /// Gets the session.
        /// </summary>
        public Session Session { get { return GetSession(); } }

        /// <summary>
        /// Gets the application.
        /// </summary>
        public ApplicationInstance Application { get { return m_application; } }

        /// <summary>
        /// Gets the session.
        /// </summary>
        /// <returns></returns>
        private Session GetSession()
        {
            if (m_session == null)
            {
                m_session = new Session(m_application);
                // m_session.UserIdentity = new UserIdentity() { IdentityType = UserIdentityType.UserName, UserName = "opciop", Password = "opciop" };
                m_session.Connect(SelectEndpointControl.SelectedEndpoint, RetryInitialConnect.Yes, null);
            }

            return m_session;
        }

        /// <summary>
        /// Shows the error.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="error">The error.</param>
        public void ShowError(Form owner, string error)
        {
            MessageDialog.Show(owner, error, owner.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Shows the edit value dialog.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="readOnly">if set to <c>true</c> [read only].</param>
        public object ShowEditValueDialog(object value)
        {
            try
            {
                return new EditComplexValueDlg().ShowDialog(
                    null,
                    value,
                    "View Value",
                    true);
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
                return null;
            }
        }

        /// <summary>
        /// Shows the edit value dialog.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="readOnly">if set to <c>true</c> [read only].</param>
        public Variant? ShowEditValueDialog(Variant value, NodeId dataTypeId, int valueRank)
        {
            try
            {
                return new EditComplexValueDlg().ShowDialog(
                    null,
                    value,
                    new UnifiedAutomation.UaBase.TypeInfo(TypeUtils.GetBuiltInType(dataTypeId, m_session.Cache), valueRank),
                    "Edit Value",
                    false);
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
                return null;
            }
        }

        /// <summary>
        /// Shows the edit value dialog.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="readOnly">if set to <c>true</c> [read only].</param>
        public NodeId ShowBrowseDialog(NodeId rootId, NodeId referenceTypeId)
        {
            try
            {
                return new UnifiedAutomation.UaClient.Controls.BrowseDlg().ShowDialog(m_session, rootId, referenceTypeId, 0);
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
                return null;
            }
        }

        /// <summary>
        /// Called when [node id button click].
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="textbox">The textbox.</param>
        public bool OnNodeIdButtonClick(Form parent, TextBox textbox)
        {
            return OnNodeIdButtonClick(parent, textbox, ObjectIds.ObjectsFolder, ReferenceTypeIds.HierarchicalReferences);
        }

        /// <summary>
        /// Called when [node id button click].
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="textbox">The textbox.</param>
        public bool OnNodeIdButtonClick(Form parent, TextBox textbox, NodeId rootId, NodeId referenceTypeId)
        {
            try
            {
                UnifiedAutomation.UaClient.Controls.BrowseDlg dialog = new UnifiedAutomation.UaClient.Controls.BrowseDlg();

                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.Size = new Size(parent.Width, Math.Max(400, parent.Height));
                dialog.Location = this.Location;

                NodeId nodeId = dialog.ShowDialog(this.Session, rootId, referenceTypeId, 0);

                if (nodeId != null)
                {
                    textbox.Text = nodeId.ToString();
                    textbox.ForeColor = Color.Empty;
                    return true;
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }

            return false;
        }

        /// <summary>
        /// Called when [node id text changed].
        /// </summary>
        /// <param name="textbox">The textbox.</param>
        public void OnNodeIdTextChanged(TextBox textbox)
        {
            try
            {
                const string defaultText = "Select a NodeId by clicking on the button to the right.";

                if (String.IsNullOrEmpty(textbox.Text))
                {
                    textbox.Text = defaultText;
                    textbox.ForeColor = Color.Gray;
                }
                else if (textbox.Text != defaultText)
                {
                    if (textbox.Text.Contains(defaultText))
                    {
                        textbox.Text = textbox.Text.Replace(defaultText, String.Empty);
                    }

                    textbox.ForeColor = Color.Empty;
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        /// <summary>
        /// Gets the dropped object.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DragEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        public object GetDroppedObject(object sender, DragEventArgs e)
        {
            try
            {
                string xml = (string)e.Data.GetData(typeof(string));

                using (XmlReader reader = new XmlTextReader(new System.IO.StringReader(xml)))
                {
                    try
                    {
                        DataContractSerializer serializer = new DataContractSerializer(typeof(ReadValueIdCollection));
                        ReadValueIdCollection nodesToRead = (ReadValueIdCollection)serializer.ReadObject(reader);

                        foreach (ReadValueId nodeToRead in nodesToRead)
                        {
                            return nodeToRead;
                        }
                    }
                    catch
                    {
                        DataContractSerializer serializer = new DataContractSerializer(typeof(ReferenceDescriptionCollection));
                        ReferenceDescriptionCollection references = (ReferenceDescriptionCollection)serializer.ReadObject(reader);

                        foreach (ReferenceDescription reference in references)
                        {
                            return reference;
                        }
                    }
                }
            }
            catch
            {
                return null;
            }

            return null;
        }

        /// <summary>
        /// Gets the instructions.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public string GetInstructions(Type type)
        {
            try
            {
                Stream strm = Assembly.GetExecutingAssembly().GetManifestResourceStream("UnifiedAutomation.ClientGettingStarted.Instructions.xml");
                XDocument document = XDocument.Load(XmlReader.Create(strm));

                var dialogs = from e in document.Descendants("Dialog")
                              where e.Attributes("Name").SingleOrDefault(i => i.Value == type.Name) != null
                              select e;

                if (dialogs.Count() == 0)
                {
                    return String.Empty;
                }

                var filePaths = from e in dialogs.First().Descendants("Instructions")
                                select e.Value;

                if (filePaths.Count() == 0)
                {
                    return String.Empty;
                }

                string[] lines = filePaths.First().Trim().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                StringBuilder buffer = new StringBuilder();

                for (int ii = 0; ii < lines.Length; ii++)
                {
                    string line = lines[ii].Trim();

                    if (ii > 0)
                    {
                        buffer.Append("\r\n");
                    }

                    buffer.Append(line);
                }

                return buffer.ToString();
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
                return String.Empty;
            }
        }

        /// <summary>
        /// Shows the code.
        /// </summary>
        /// <param name="type">The type.</param>
        public void ShowCode(Type type)
        {
            try
            {
                Stream strm = Assembly.GetExecutingAssembly().GetManifestResourceStream("UnifiedAutomation.ClientGettingStarted.Instructions.xml");

                XDocument document = XDocument.Load(XmlReader.Create(strm));

                var dialogs = from e in document.Descendants("Dialog")
                              where e.Attributes("Name").SingleOrDefault(i => i.Value == type.Name) != null
                              select e;

                if (dialogs.Count() == 0)
                {
                    return;
                }

                var filePaths = from e in dialogs.First().Descendants("FilePath")
                                select e.Value;

                if (filePaths.Count() == 0)
                {
                    return;
                }

                FileInfo exeFile = new FileInfo(System.Windows.Forms.Application.ExecutablePath);

                string directory = exeFile.Directory.Parent.FullName;
                string projectRoot = directory + @"\examples\ClientGettingStarted\";

                if (!Directory.Exists(projectRoot))
                {
                    directory = exeFile.Directory.Parent.Parent.Parent.FullName;
                    projectRoot = directory + @"\examples\ClientGettingStarted\";
                }

                // internal project structure
                if (!Directory.Exists(projectRoot))
                {
                    directory = exeFile.Directory.Parent.Parent.FullName;
                    projectRoot = directory + @"\applications\ClientGettingStarted\";
                }

                var filename = Path.Combine(projectRoot, filePaths.First());

                ProcessStartInfo psi = new ProcessStartInfo()
                {
                    FileName = filename,
                    UseShellExecute = true,
                };

                Process.Start(psi);
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        /// <summary>
        /// Shows the code.
        /// </summary>
        /// <param name="type">The type.</param>
        public void ShowHelp(Type type)
        {
            try
            {
                Stream strm = Assembly.GetExecutingAssembly().GetManifestResourceStream("UnifiedAutomation.ClientGettingStarted.Instructions.xml");

                XDocument document = XDocument.Load(XmlReader.Create(strm));

                var dialogs = from e in document.Descendants("Dialog")
                              where e.Attributes("Name").SingleOrDefault(i => i.Value == type.Name) != null
                              select e;

                if (dialogs.Count() == 0)
                {
                    return;
                }

                var filePaths = from e in dialogs.First().Descendants("HelpFilePath")
                                select e.Value;

                if (filePaths.Count() == 0)
                {
                    return;
                }

                try
                {
                    string target = filePaths.First().Trim();

                    string filePath = @"..\doc\html\" + target;

                    FileInfo fileInfo = new FileInfo(filePath);

                    int count = 0;
                    DirectoryInfo directory = fileInfo.Directory;

                    while (directory != null)
                    {
                        directory = directory.Parent;
                        count++;
                    }

                    Uri url = null;

                    for (int ii = 0; ii < count; ii++)
                    {
                        if (fileInfo.Exists)
                        {
                            url = new Uri(fileInfo.FullName);
                            break;
                        }

                        filePath = @"..\" + filePath;
                        fileInfo = new FileInfo(filePath);
                    }

                    if (url != null)
                    {
                        System.Diagnostics.Process.Start(url.ToString());
                    }
                }
                catch (System.Exception e)
                {
                    MessageDialog.Show(this, e.Message);
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        public bool HelpExists(Type type)
        {
            try
            {
                Stream strm = Assembly.GetExecutingAssembly().GetManifestResourceStream("UnifiedAutomation.ClientGettingStarted.Instructions.xml");

                XDocument document = XDocument.Load(XmlReader.Create(strm));

                var dialogs = from e in document.Descendants("Dialog")
                              where e.Attributes("Name").SingleOrDefault(i => i.Value == type.Name) != null
                              select e;

                if (dialogs.Count() == 0)
                {
                    return false;
                }

                var filePaths = from e in dialogs.First().Descendants("HelpFilePath")
                                select e.Value;

                if (filePaths.Count() == 0)
                {
                    return false;
                }

                try
                {
                    string target = filePaths.First().Trim();

                    string filePath = @"..\doc\html\" + target;

                    FileInfo fileInfo = new FileInfo(filePath);

                    int count = 0;
                    DirectoryInfo directory = fileInfo.Directory;

                    while (directory != null)
                    {
                        directory = directory.Parent;
                        count++;
                    }

                    Uri url = null;

                    for (int ii = 0; ii < count; ii++)
                    {
                        if (fileInfo.Exists)
                        {
                            url = new Uri(fileInfo.FullName);
                            break;
                        }

                        filePath = @"..\" + filePath;
                        fileInfo = new FileInfo(filePath);
                    }

                    return url != null;
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void HelpForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Object.ReferenceEquals(sender, m_HelpForm))
            {
                m_HelpForm = null;
            }
        }
        #endregion

        #region Event Handlers
        /// [Handler for Untrusted Certificates]
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

                TrustCertificateDialog dialog = new TrustCertificateDialog();
                dialog.StartPosition = FormStartPosition.CenterParent;
                e.Accept = dialog.ShowDialog(this, settings, 30000);

                if (settings.SaveToTrustList)
                {
                    e.Persist = true;
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }
        /// [Handler for Untrusted Certificates]

        private void MainBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.Fragment == "#DefaultServer")
            {
                SelectEndpointControl.Visible = true;
            }

            if (e.Url.Fragment == "#Connect")
            {
                SelectEndpointControl.Visible = false;
                ConnectOptionsControl.Visible = !ConnectOptionsControl.Visible;
            }

            if (e.Url.Fragment == "#Session")
            {
                SelectEndpointControl.Visible = false;
                SessionOptionsControl.Visible = !SessionOptionsControl.Visible;
            }

            if (e.Url.Fragment == "#Subscription")
            {
                SelectEndpointControl.Visible = false;
                SubscriptionOptionsControl.Visible = !SubscriptionOptionsControl.Visible;
            }
        }

        private void SelectEndpointControl_ConnectServer(object sender, UnifiedAutomation.UaClient.Controls.ConnectServerEventArgs e)
        {
            SelectEndpointControl.Visible = false;

            if (m_session != null)
            {
                m_session.Disconnect();
                m_session = null;
            }

            try
            {
                GetSession();

                if (m_session != null && m_session.EndpointDescription != null)
                {
                    MessageDialog.Show(this, "Connected to server at " + m_session.EndpointDescription.ToString(), "Connect Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(Text, exception);
            }
        }

        private void SelectEndpointControl_DisconnectServer(object sender, EventArgs e)
        {
            SelectEndpointControl.Visible = false;

            if (m_session != null)
            {
                m_session.Disconnect();
                m_session = null;
            }

            MessageDialog.Show(this, "Disconnected from server.", "Disconnect Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (m_session != null)
                {
                    m_session.Disconnect();
                    m_session = null;
                }
            }
            catch (Exception)
            {
                // ignore errors on form close.
            }
        }
        #endregion
    }
}
