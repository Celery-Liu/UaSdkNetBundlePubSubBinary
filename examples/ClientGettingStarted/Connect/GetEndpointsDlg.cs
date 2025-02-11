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
    /// Shows a dialog which demonstrates a get endpoints operation.
    /// </summary>
    public partial class GetEndpointsDlg : Form
    {
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

                // clear the existing servers.
                EndpointsLV.Items.Clear();

                // this is a blocking call so show the wait cursor.
                Cursor = Cursors.WaitCursor;

                /// [Get Endpoints]
                List<EndpointDescription> endpoints;

                // create the object used to find servers or endpoints.
                using (Discovery discovery = new Discovery(m_parent.Application))
                {
                    // get the discoverUrl from the gui
                    string discoveryUrl = ServerUrlTB.Text;

                    // look for the LDS with the default endpoint.
                    endpoints = discovery.GetEndpoints(discoveryUrl);
                }
                /// [Get Endpoints]

                // update list view.
                foreach (EndpointDescription endpoint in endpoints)
                {
                    ListViewItem item = new ListViewItem();

                    item.Text = endpoint.EndpointUrl;
                    item.SubItems.Add(endpoint.SecurityMode.ToString());
                    item.SubItems.Add(SecurityProfiles.GetDisplayName(endpoint.SecurityPolicyUri));
                    item.Tag = endpoint;

                    EndpointsLV.Items.Add(item);
                }

                // adjust the column widths.
                foreach (ColumnHeader column in EndpointsLV.Columns)
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
                    OnGetEndpointsComplete,
                    discovery);
            }
            catch (Exception exception)
            {
                discovery.Dispose();
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        /// <summary>
        /// Finishes an asynchronous get endpoints request.
        /// </summary>
        private void OnGetEndpointsComplete(IAsyncResult result)
        {
            // need to make sure the results are processed on the correct thread.
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnGetEndpointsComplete), result);
                return;
            }

            // get the object used to invoke the method.
            Discovery discovery = (Discovery)result.AsyncState;

            try
            {
                // get the results.
                List<EndpointDescription> endpoints = discovery.EndGetEndpoints(result);

                // update list view.
                foreach (EndpointDescription endpoint in endpoints)
                {
                    ListViewItem item = new ListViewItem();

                    item.Text = endpoint.EndpointUrl;
                    item.SubItems.Add(endpoint.SecurityMode.ToString());
                    item.SubItems.Add(SecurityProfiles.GetDisplayName(endpoint.SecurityPolicyUri));
                    item.Tag = endpoint;

                    EndpointsLV.Items.Add(item);
                }

                // adjust the column widths.
                foreach (ColumnHeader column in EndpointsLV.Columns)
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
        /// Initializes a new instance of the <see cref="GetEndpointsDlg"/> class.
        /// </summary>
        public GetEndpointsDlg()
        {
            InitializeComponent();
            Icon = GuiUtils.GetDefaultIcon();
            CancelButton = this.CancelBTN;

            InstructionsLB.Text =
                "The GetEndpoints method takes an Endpoint URL and connects to the Server and fetches all endpoints supported by the server. " +
                "The Endpoints which are discovered are shown in the list below. " +
                "The selected Endpoint will be used when the dialog is closed.";
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
        public EndpointDescription ShowDialog(MainForm parent, string defaultUrl)
        {
            m_parent = parent;
            ServerUrlTB.Text = defaultUrl;
            HelpBTN.Enabled = parent != null && parent.HelpExists(GetType());

            if (String.IsNullOrEmpty(ServerUrlTB.Text))
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

            ShowDialog();

            if (EndpointsLV.SelectedItems.Count > 0)
            {
                return (EndpointDescription)EndpointsLV.SelectedItems[0].Tag;
            }

            return null;
        }
        #endregion

        #region Event Handlers
        private void GetEndpointsBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UseAsynchCK.Checked)
                {
                    GetEndpoints();
                }
                else
                {
                    BeginGetEndpoints();
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
