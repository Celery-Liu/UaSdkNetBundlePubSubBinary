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
    /// Shows a dialog which demonstrates a basic read operation.
    /// </summary>
    public partial class ReadStructureDlg : Form
    {
        /// <summary>
        /// Synchronously reads the value from the server.
        /// </summary>
        private void Read()
        {
            try
            {
                // get the current session from the parent form.
                Session session = m_parent.Session;

                // build a list of values to read.
                List<ReadValueId> nodesToRead = PrepareRequest(session);

                if (nodesToRead == null)
                {
                    return;
                }

                // this is a blocking call so show the wait cursor.
                Cursor = Cursors.WaitCursor;

                // read the value (setting a 10 second timeout).
                List<DataValue> results = session.Read(
                    nodesToRead,
                    0,
                    TimestampsToReturn.Both,
                    new RequestSettings() { OperationTimeout = 10000 });

                // update the controls.
                ProcessResults(results);
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
        /// Asynchronously reads the value from the server.
        /// </summary>
        private void BeginRead()
        {
            try
            {
                // get the current session from the parent form.
                Session session = m_parent.Session;

                // build a list of values to read.
                List<ReadValueId> nodesToRead = PrepareRequest(session);

                if (nodesToRead == null)
                {
                    return;
                }

                // start reading the value (setting a 10 second timeout).
                session.BeginRead(
                    nodesToRead,
                    0,
                    TimestampsToReturn.Both,
                    new RequestSettings() { OperationTimeout = 10000 },
                    OnReadComplete,
                    session);
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        /// <summary>
        /// Finishes an asynchronous read request.
        /// </summary>
        private void OnReadComplete(IAsyncResult result)
        {
            // need to make sure the results are processed on the UI thread.
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnReadComplete), result);
                return;
            }

            // get the session used to send the request which was passed as the userData in the Begin call.
            Session session = (Session)result.AsyncState;

            try
            {
                // get the results.
                List<DataValue> results = session.EndRead(result);

                // don't update the controls if the session has changed.
                if (!Object.ReferenceEquals(session, m_parent.Session))
                {
                    return;
                }

                // update the controls.
                ProcessResults(results);
            }
            catch (Exception exception)
            {
                // don't display any error if the session has changed.
                if (Object.ReferenceEquals(session, m_parent.Session) && Visible)
                {
                    ExceptionDlg.ShowInnerException(this.Text, exception);
                }
            }
        }

        /// <summary>
        /// Prepares the read request.
        /// </summary>
        /// <returns>A list of nodes to read. Null if the request cannot be initialized.</returns>
        private List<ReadValueId> PrepareRequest(Session session)
        {
            // nothing to do if no session.
            if (session == null)
            {
                return null;
            }

            // build a list of values to read.
            List<ReadValueId> nodesToRead = new List<ReadValueId>();

            // assume we are reading a variable so the default attribute is the Value attribute.
            nodesToRead.Add(new ReadValueId()
            {
                NodeId = NodeId.Parse(NodeIdTB.Text),
                AttributeId = Attributes.Value
            });

            return nodesToRead;
        }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicReadDlg"/> class.
        /// </summary>
        public ReadStructureDlg()
        {
            InitializeComponent();
            Icon = GuiUtils.GetDefaultIcon();
            CancelButton = this.CancelBTN;
        }
        #endregion

        #region Private Fields
        private MainForm m_parent;
        private TextBox m_text;
        #endregion

        #region Event Handlers
        private void ReadBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UseAsynchCK.Checked)
                {
                    Read();
                }
                else
                {
                    BeginRead();
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void NodeIdBTN_Click(object sender, EventArgs e)
        {
            m_parent.OnNodeIdButtonClick(this, NodeIdTB);
        }

        private void NodeIdTB_TextChanged(object sender, EventArgs e)
        {
            m_parent.OnNodeIdTextChanged(NodeIdTB);
        }

        private void NodeIdTB_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            Close();
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
        #endregion
    }
}
