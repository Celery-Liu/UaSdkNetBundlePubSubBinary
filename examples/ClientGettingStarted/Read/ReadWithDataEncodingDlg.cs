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
    public partial class ReadWithDataEncodingDlg : Form
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
        /// Updates the controls with the available encodings.
        /// </summary>
        /// <param name="nodeId">The node id.</param>
        private bool UpdateAvailableEncodings(NodeId nodeId)
        {
            DataEncodingCB.Items.Clear();

            // get the current session from the parent form.
            Session session = m_parent.Session;

            // nothing to do if no session.
            if (session == null)
            {
                return false;
            }

            NodeId dataTypeId = session.Cache.GetAttribute<NodeId>(nodeId, Attributes.DataType, null);

            if (dataTypeId != null)
            {
                // Use all available DataEncodings in this example. The NodeIds of the available
                // encoding nodes for the DataType are added in a combo box.
                List<NodeId> dataEncodings = session.Cache.GetAvailableDataEncodings(nodeId);

                if (dataEncodings == null)
                {
                    m_parent.ShowError(this, "Only variable nodes with structured data types can have data encodings.");
                    return false;
                }

                foreach (NodeId dataEncoding in dataEncodings)
                {
                    DataEncodingCB.Items.Add(new DropDownItem(dataEncoding, session.Cache.GetDisplayText(dataEncoding)));
                }

                if (DataEncodingCB.Items.Count > 0)
                {
                    DataEncodingCB.SelectedIndex = 0;
                }
                else
                {
                    m_parent.ShowError(this, "The variable does not appear to have any data encodings associated with it.");
                    return true;
                }
            }

            return true;
        }

        /// <summary>
        /// Prepares the read request.
        /// </summary>
        /// <returns>A list of nodes to read. Null if the request cannot be initialized.</returns>
        /// [Snippet 2]
        private List<ReadValueId> PrepareRequest(Session session)
        {
            // nothing to do if no session.
            if (session == null)
            {
                return null;
            }

            // need the browse name of the encoding to pass with the request.
            QualifiedName dataEncoding = null;

            if (DataEncodingCB.SelectedIndex >= 0)
            {
                // Get the BrowseName of the selected encoding node.
                // Standard values are QualifiedName("Default Binary") and QualifiedName("Default XML").
                dataEncoding = session.Cache.GetAttribute<QualifiedName>(
                        ((DropDownItem)DataEncodingCB.SelectedItem).DataEncoding,
                        Attributes.BrowseName,
                        null);
            }

            // build a list of values to read.
            List<ReadValueId> nodesToRead = new List<ReadValueId>();

            // assume we are reading a variable so the default attribute is the Value attribute.
            nodesToRead.Add(new ReadValueId()
            {
                NodeId = NodeId.Parse(NodeIdTB.Text),
                AttributeId = Attributes.Value,
                DataEncoding = dataEncoding
            });

            return nodesToRead;
        }
        /// [Snippet 2]

        /// <summary>
        /// Processes the results.
        /// </summary>
        /// <param name="results">The results.</param>
        private void ProcessResults(List<DataValue> results)
        {
            // display the value in the form.
            if (results.Count > 0)
            {
                ValueCTRL.Tag = results[0];

                if (StatusCode.IsBad(results[0].StatusCode))
                {
                    ValueCTRL.ShowValue("Value", new Variant(results[0].StatusCode), null, true);
                }
                else
                {
                    ValueCTRL.ShowValue("Value", results[0].WrappedValue, null, true);
                }
            }
        }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicReadDlg"/> class.
        /// </summary>
        public ReadWithDataEncodingDlg()
        {
            InitializeComponent();
            Icon = GuiUtils.GetDefaultIcon();
            CancelButton = this.CancelBTN;
        }
        #endregion

        #region Private Fields
        private MainForm m_parent;
        #endregion

        #region DropDownItem Classes
        /// <summary>
        /// An item in a drop down list.
        /// </summary>
        private class DropDownItem
        {
            public DropDownItem(NodeId dataEncoding, string displayText)
            {
                DataEncoding = dataEncoding;
                DisplayText = displayText;
            }

            public NodeId DataEncoding { get; private set; }
            public string DisplayText { get; private set; }

            public override string ToString()
            {
                if (DisplayText == null)
                {
                    return String.Empty;
                }

                return DisplayText;
            }

            public override bool Equals(object obj)
            {
                DropDownItem item = obj as DropDownItem;

                if (item != null && item.DataEncoding == DataEncoding)
                {
                    return true;
                }

                return false;
            }

            public override int GetHashCode()
            {
                return DataEncoding.GetHashCode();
            }
        }
        #endregion

        #region Public Interface
        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public void Show(MainForm parent)
        {
            m_parent = parent;
            HelpBTN.Enabled = parent != null && parent.HelpExists(GetType());
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(parent.Location.X + (parent.Width - this.Width) / 2, parent.Location.Y + (parent.Height - this.Height) / 2);
            InstructionsLB.Text = parent.GetInstructions(this.GetType());
            NodeIdTB_TextChanged(this, null);
            try
            {
                UpdateAvailableEncodings(NodeId.Parse(NodeIdTB.Text));
            }
            catch (Exception)
            {
                // ignore.
            }
            Show();
        }
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
            m_parent.OnNodeIdButtonClick(this, NodeIdTB, new NodeId("Demo.Static.Scalar.Structures", 2), ReferenceTypeIds.HierarchicalReferences);

            try
            {
                UpdateAvailableEncodings(NodeId.Parse(NodeIdTB.Text));
            }
            catch (Exception)
            {
                // ignore.
            }
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
