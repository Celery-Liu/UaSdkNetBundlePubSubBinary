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
    /// Shows a dialog which demonstrates a find servers operation.
    /// </summary>
    public partial class FindServersDlg : Form
    {
        /// <summary>
        /// Synchronously finds the servers on a host.
        /// </summary>
        private void FindServers()
        {
            try
            {
                // clear the existing servers.
                ServersLV.Items.Clear();

                // this is a blocking call so show the wait cursor.
                Cursor = Cursors.WaitCursor;

                /// [Find Servers]
                List<ApplicationDescription> servers;

                // create the object used to find servers or endpoints.
                using (Discovery discovery = new Discovery(m_parent.Application))
                {
                    // look for the LDS with the default endpoint.
                    string discoveryUrl = "opc.tcp://" + HostNameTB.Text + ":4840";
                    servers = discovery.FindServers(discoveryUrl);
                }
                /// [Find Servers]

                // update list view.
                foreach (ApplicationDescription server in servers)
                {
                    ServersLV.Items.Add(new ListViewItem(server.ApplicationName.Text) { Tag = server });
                }

                // adjust the column widths.
                foreach (ColumnHeader column in ServersLV.Columns)
                {
                    column.Width = -2;
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Asynchronously finds the servers on a host.
        /// </summary>
        private void BeginFindServers()
        {
            // create the object used to find servers or endpoints.
            Discovery discovery = new Discovery(m_parent.Application);

            try
            {
                // clear the existing servers.
                ServersLV.Items.Clear();

                // look for the LDS with the default endpoint.
                discovery.BeginFindServers(
                    "opc.tcp://" + HostNameTB.Text + ":4840",
                    OnFindServersComplete,
                    discovery);
            }
            catch (Exception exception)
            {
                discovery.Dispose();
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        /// <summary>
        /// Finishes an asynchronous find servers request.
        /// </summary>
        private void OnFindServersComplete(IAsyncResult result)
        {
            // need to make sure the results are processed on the correct thread.
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnFindServersComplete), result);
                return;
            }

            // get the object used to invoke the method.
            Discovery discovery = (Discovery)result.AsyncState;

            try
            {
                // get the results.
                List<ApplicationDescription> servers = discovery.EndFindServers(result);

                // update list view.
                foreach (ApplicationDescription server in servers)
                {
                    ServersLV.Items.Add(new ListViewItem(server.ApplicationName.Text) { Tag = server });
                }

                // adjust the column widths.
                foreach (ColumnHeader column in ServersLV.Columns)
                {
                    column.Width = -2;
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
            discovery.Dispose();
        }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FindServersDlg"/> class.
        /// </summary>
        public FindServersDlg()
        {
            InitializeComponent();
            Icon = GuiUtils.GetDefaultIcon();
            CancelButton = this.CancelBTN;

            InstructionsLB.Text =
                "The FindServers method takes a HostName and connects to the Local Discovery Server (LDS) on that host. " +
                "The Servers which are discovered are shown in the list below. " +
                "The selected Server will be returned when the dialog is closed.";
        }
        #endregion

        #region Private Fields
        private MainForm m_parent;
        #endregion

        #region Public Interface
        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public ApplicationDescription ShowDialog(MainForm parent, string defaultUrl)
        {
            m_parent = parent;
            HelpBTN.Enabled = parent != null && parent.HelpExists(GetType());

            if (Uri.IsWellFormedUriString(defaultUrl, UriKind.Absolute))
            {
                Uri url = new Uri(defaultUrl);
                HostNameTB.Text = url.DnsSafeHost;
            }

            if (String.IsNullOrEmpty(HostNameTB.Text))
            {
                if (parent != null && parent.Endpoint != null && Uri.IsWellFormedUriString(parent.Endpoint.EndpointUrl, UriKind.Absolute))
                {
                    HostNameTB.Text = new Uri(parent.Endpoint.EndpointUrl).DnsSafeHost;
                }
                else
                {
                    HostNameTB.Text = "localhost";
                }
            }

            ShowDialog();

            if (ServersLV.SelectedItems.Count > 0)
            {
                return (ApplicationDescription)ServersLV.SelectedItems[0].Tag;
            }

            return null;
        }
        #endregion

        #region Event Handlers
        private void FindServersBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UseAsynchCK.Checked)
                {
                    FindServers();
                }
                else
                {
                    BeginFindServers();
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ServersLV_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (ServersLV.SelectedItems.Count > 0)
                {
                    m_parent.ShowEditValueDialog(ServersLV.SelectedItems[0].Tag);
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
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
        #endregion
    }
}
