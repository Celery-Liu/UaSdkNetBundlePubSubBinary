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
    public partial class BasicWriteDlg : Form
    {
        /// <summary>
        /// Synchronously writes the value from the server.
        /// </summary>
        private void Write()
        {
            try
            {
                // get the current session from the parent form.
                Session session = m_parent.Session;

                // nothing to do if no session.
                if (session == null)
                {
                    return;
                }

                /// [Basic Write]
                // build a list of values to write.
                List<WriteValue> nodesToWrite = new List<WriteValue>();

                // get the first value to write.
                if (!String.IsNullOrEmpty(Node1TB.Text))
                {
                    NodeId nodeId = NodeId.Parse(Node1TB.Text);
                    VariableNode variable = Value1TB.Tag as VariableNode;

                    if (variable != null)
                    {
                        nodesToWrite.Add(new WriteValue()
                        {
                            NodeId = nodeId,
                            AttributeId = Attributes.Value,
                            Value = new DataValue() { WrappedValue = variable.Value },
                            UserData = Result1TB // the UserData can be used to store application state information.
                        });
                    }
                }

                // get the second value to write.
                if (!String.IsNullOrEmpty(Node2TB.Text))
                {
                    NodeId nodeId = NodeId.Parse(Node2TB.Text);
                    VariableNode variable = Value2TB.Tag as VariableNode;

                    if (variable != null)
                    {
                        nodesToWrite.Add(new WriteValue()
                        {
                            NodeId = nodeId,
                            AttributeId = Attributes.Value,
                            Value = new DataValue() { WrappedValue = variable.Value },
                            UserData = Result2TB // the UserData can be used to store application state information.
                        });
                    }
                }

                // this is a blocking call so show the wait cursor.
                Cursor = Cursors.WaitCursor;

                // read the value (setting a 10 second timeout).
                List<StatusCode> results = session.Write(
                    nodesToWrite,
                    new RequestSettings() { OperationTimeout = 10000 });
                /// [Basic Write]

                // update the controls.
                for (int ii = 0; ii < results.Count; ii++)
                {
                    ((TextBox)nodesToWrite[ii].UserData).Text = results[ii].ToString();
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
        /// Asynchronously writes the value to the server.
        /// </summary>
        private void BeginWrite()
        {
            try
            {
                // get the current session from the parent form.
                Session session = m_parent.Session;

                // nothing to do if no session.
                if (session == null)
                {
                    return;
                }

                // build a list of values to write.
                List<WriteValue> nodesToWrite = new List<WriteValue>();

                // get the first value to write.
                if (!String.IsNullOrEmpty(Node1TB.Text))
                {
                    NodeId nodeId = NodeId.Parse(Node1TB.Text);
                    VariableNode variable = Value1TB.Tag as VariableNode;

                    if (variable != null)
                    {
                        nodesToWrite.Add(new WriteValue()
                        {
                            NodeId = nodeId,
                            AttributeId = Attributes.Value,
                            Value = new DataValue() { WrappedValue = variable.Value },
                            UserData = Result1TB // the UserData can be used to store application state information.
                        });
                    }
                }

                // get the second value to write.
                if (!String.IsNullOrEmpty(Node2TB.Text))
                {
                    NodeId nodeId = NodeId.Parse(Node2TB.Text);
                    VariableNode variable = Value2TB.Tag as VariableNode;

                    if (variable != null)
                    {
                        nodesToWrite.Add(new WriteValue()
                        {
                            NodeId = nodeId,
                            AttributeId = Attributes.Value,
                            Value = new DataValue() { WrappedValue = variable.Value },
                            UserData = Result2TB // the UserData can be used to store application state information.
                        });
                    }
                }

                // start writing the values (setting a 10 second timeout).
                session.BeginWrite(
                    nodesToWrite,
                    new RequestSettings() { OperationTimeout = 10000 },
                    OnWriteComplete,
                    new WriteState() { Session = session, NodesToWrite = nodesToWrite });
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        /// <summary>
        /// Finishes an asynchronous read request.
        /// </summary>
        private void OnWriteComplete(IAsyncResult result)
        {
            // need to make sure the results are processed on the correct thread.
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnWriteComplete), result);
                return;
            }

            // get the session used to send the request which was passed as the userData in the Begin call.
            WriteState state = (WriteState)result.AsyncState;

            try
            {
                // get the results.
                List<StatusCode> results = state.Session.EndWrite(result);

                // don't update the controls if the session has changed.
                if (!Object.ReferenceEquals(state.Session, m_parent.Session))
                {
                    return;
                }

                // update the controls.
                for (int ii = 0; ii < results.Count; ii++)
                {
                    ((TextBox)state.NodesToWrite[ii].UserData).Text = results[ii].ToString();
                }
            }
            catch (Exception exception)
            {
                // don't display any error if the session has changed.
                if (Object.ReferenceEquals(state.Session, m_parent.Session) && Visible)
                {
                    ExceptionDlg.ShowInnerException(this.Text, exception);
                }
            }
        }

        /// <summary>
        /// A object used to pass state with an asynchronous write call.
        /// </summary>
        private class WriteState
        {
            public Session Session { get; set; }
            public List<WriteValue> NodesToWrite { get; set; }
        }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicWriteDlg"/> class.
        /// </summary>
        public BasicWriteDlg()
        {
            InitializeComponent();
            Icon = GuiUtils.GetDefaultIcon();
            CancelButton = this.CancelBTN;
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
        public void Show(MainForm parent)
        {
            m_parent = parent;
            HelpBTN.Enabled = parent != null && parent.HelpExists(GetType());
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(parent.Location.X + (parent.Width - this.Width) / 2, parent.Location.Y + (parent.Height - this.Height) / 2);
            InstructionsLB.Text = parent.GetInstructions(this.GetType());
            NodeIdTB_TextChanged(Node1TB, null);
            NodeIdTB_TextChanged(Node2TB, null);
            Show();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// A object used to pass state with an asynchronous read call.
        /// </summary>
        private class ReadState
        {
            public Session Session { get; set; }
            public Control Target { get; set; }
        }

        /// <summary>
        /// Asynchronously reads the value from the server.
        /// </summary>
        private void Read(Control source, Control target)
        {
            try
            {
                // get the current session from the parent form.
                Session session = m_parent.Session;

                // nothing to do if no session.
                if (session == null)
                {
                    return;
                }

                // build a list of values to read.
                List<ReadValueId> nodesToRead = new List<ReadValueId>();

                // parse the node id and get the selected attribute id.
                NodeId nodeId = NodeId.Parse(source.Text);

                // read the display name and the selected attribute for the node.
                nodesToRead.Add(new ReadValueId() { NodeId = nodeId, AttributeId = Attributes.Value });
                nodesToRead.Add(new ReadValueId() { NodeId = nodeId, AttributeId = Attributes.DataType });
                nodesToRead.Add(new ReadValueId() { NodeId = nodeId, AttributeId = Attributes.ValueRank });

                // start reading the value (setting a 10 second timeout).
                session.BeginRead(
                    nodesToRead,
                    0,
                    TimestampsToReturn.Both,
                    new RequestSettings() { OperationTimeout = 10000 },
                    OnReadComplete,
                    new ReadState() { Session = session, Target = target });
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
            // need to make sure the results are processed on the correct thread.
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnReadComplete), result);
                return;
            }

            // get the session used to send the request which was passed as the userData in the Begin call.
            ReadState state = (ReadState)result.AsyncState;

            try
            {
                // get the results.
                List<DataValue> results = state.Session.EndRead(result);

                // don't update the controls if the session has changed.
                if (!Object.ReferenceEquals(state.Session, m_parent.Session))
                {
                    return;
                }

                // update the controls.
                state.Target.Text = results[0].ToString();

                state.Target.Tag = new VariableNode()
                {
                    Value = results[0].WrappedValue,
                    DataType = results[1].GetValue<NodeId>(DataTypeIds.BaseDataType),
                    ValueRank = results[2].GetValue<int>(ValueRanks.Scalar)
                };
            }
            catch (Exception exception)
            {
                // don't display any error if the session has changed.
                if (Object.ReferenceEquals(state.Session, m_parent.Session) && Visible)
                {
                    ExceptionDlg.ShowInnerException(this.Text, exception);
                }
            }
        }
        #endregion

        #region Event Handlers
        private void WriteBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UseAsynchCK.Checked)
                {
                    Write();
                }
                else
                {
                    BeginWrite();
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void EditBTN_Click(object sender, EventArgs e)
        {
            Control target = (Object.ReferenceEquals(Edit1BTN, sender)) ? (Control)Value1TB : (Control)Value2TB;

            VariableNode variable = target.Tag as VariableNode;

            if (variable == null)
            {
                variable = new VariableNode();
            }

            Variant? newValue = m_parent.ShowEditValueDialog(
                variable.Value,
                variable.DataType,
                variable.ValueRank);

            if (newValue != null)
            {
                target.Tag = new VariableNode()
                {
                    Value = newValue.Value,
                    DataType = variable.DataType,
                    ValueRank = variable.ValueRank
                };

                target.Text = newValue.Value.ToString();
            }
        }

        private void NodeIdBTN_Click(object sender, EventArgs e)
        {
            TextBox target = (sender == NodeId1BTN) ? Node1TB : Node2TB;

            if (target == null)
            {
                return;
            }

            if (m_parent.OnNodeIdButtonClick(this, target))
            {
                Read(target, (sender == NodeId1BTN) ? (Control)Value1TB : (Control)Value2TB);
            }
        }

        private void NodeIdTB_TextChanged(object sender, EventArgs e)
        {
            TextBox target = sender as TextBox;

            if (target == null)
            {
                return;
            }

            m_parent.OnNodeIdTextChanged(target);
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
