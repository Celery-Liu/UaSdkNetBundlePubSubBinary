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
    public partial class RegisterNodesDlg : Form
    {
        /// <summary>
        /// Synchronously registers the nodes with the server.
        /// </summary>
        private void Register()
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

                // build a list of nodes to register.
                List<NodeId> nodesToRegister = new List<NodeId>();

                // get the first node to register.
                nodesToRegister.Add(NodeId.Parse(NodeId1TB.Text));
                nodesToRegister.Add(NodeId.Parse(NodeId2TB.Text));

                // this is a blocking call so show the wait cursor.
                Cursor = Cursors.WaitCursor;

                // register nodes.
                List<NodeId> results = session.RegisterNodes(nodesToRegister, null);

                // update the controls.
                Alias1TB.Text = results[0].ToString();
                Alias2TB.Text = results[1].ToString();

                RegisterBTN.Enabled = false;
                ReadBTN.Enabled = true;
                UnregisterBTN.Enabled = true;
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
        /// Asynchronously registers the nodes with the server.
        /// </summary>
        private void BeginRegister()
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


                // build a list of nodes to register.
                List<NodeId> nodesToRegister = new List<NodeId>();

                // get the first node to register.
                nodesToRegister.Add(NodeId.Parse(NodeId1TB.Text));
                nodesToRegister.Add(NodeId.Parse(NodeId2TB.Text));

                // start registering the nodes (setting a 10 second timeout).
                session.BeginRegisterNodes(
                    nodesToRegister,
                    new RequestSettings() { OperationTimeout = 10000 },
                    OnRegisterComplete,
                    session);
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        /// <summary>
        /// Finishes an asynchronous register nodes request.
        /// </summary>
        private void OnRegisterComplete(IAsyncResult result)
        {
            // need to make sure the results are processed on the correct thread.
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnRegisterComplete), result);
                return;
            }

            // get the session used to send the request which was passed as the userData in the Begin call.
            Session session = (Session)result.AsyncState;

            try
            {
                // get the results.
                List<NodeId> results = session.EndRegisterNodes(result);

                // don't update the controls if the session has changed.
                if (!Object.ReferenceEquals(session, m_parent.Session))
                {
                    return;
                }

                // update the controls.
                Alias1TB.Text = results[0].ToString();
                Alias2TB.Text = results[1].ToString();

                RegisterBTN.Enabled = false;
                ReadBTN.Enabled = true;
                UnregisterBTN.Enabled = true;
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
        /// Synchronously unregisters the nodes with the server.
        /// </summary>
        private void Unregister()
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

                // build a list of nodes to register.
                List<NodeId> nodesToUnregister = new List<NodeId>();

                // get the first node to register.
                nodesToUnregister.Add(NodeId.Parse(Alias1TB.Text));
                nodesToUnregister.Add(NodeId.Parse(Alias2TB.Text));

                // this is a blocking call so show the wait cursor.
                Cursor = Cursors.WaitCursor;

                // unregister nodes.
                session.UnregisterNodes(nodesToUnregister, null);

                // update the controls.
                Alias1TB.Text = String.Empty;
                Alias2TB.Text = String.Empty;

                RegisterBTN.Enabled = true;
                ReadBTN.Enabled = false;
                UnregisterBTN.Enabled = false;
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
        /// Asynchronously unregisters the nodes with the server.
        /// </summary>
        private void BeginUnregister()
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


                // build a list of nodes to register.
                List<NodeId> nodesToUnregister = new List<NodeId>();

                // get the nodes to unregister.
                nodesToUnregister.Add(NodeId.Parse(Alias1TB.Text));
                nodesToUnregister.Add(NodeId.Parse(Alias2TB.Text));

                // start unregistering the nodes (setting a 10 second timeout).
                session.BeginUnregisterNodes(
                    nodesToUnregister,
                    new RequestSettings() { OperationTimeout = 10000 },
                    OnUnregisterComplete,
                    session);
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        /// <summary>
        /// Finishes an asynchronous register nodes request.
        /// </summary>
        private void OnUnregisterComplete(IAsyncResult result)
        {
            // need to make sure the results are processed on the correct thread.
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnUnregisterComplete), result);
                return;
            }

            // get the session used to send the request which was passed as the userData in the Begin call.
            Session session = (Session)result.AsyncState;

            try
            {
                // get the results.
                session.EndUnregisterNodes(result);

                // don't update the controls if the session has changed.
                if (!Object.ReferenceEquals(session, m_parent.Session))
                {
                    return;
                }

                // update the controls.
                Alias1TB.Text = String.Empty;
                Alias2TB.Text = String.Empty;

                RegisterBTN.Enabled = true;
                ReadBTN.Enabled = false;
                UnregisterBTN.Enabled = false;
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

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterNodesDlg"/> class.
        /// </summary>
        public RegisterNodesDlg()
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

            NodeId1TB.Text = VariableIds.Server_ServerStatus_CurrentTime.ToString();
            NodeId2TB.Text = VariableIds.Server_ServerStatus_State.ToString();
            RegisterBTN.Enabled = true;
            ReadBTN.Enabled = false;
            UnregisterBTN.Enabled = false;

            Show();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Asynchronously reads the value from the server.
        /// </summary>
        private void Read()
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

                // read the values of the registered nodes.
                nodesToRead.Add(new ReadValueId() { NodeId = NodeId.Parse(Alias1TB.Text), AttributeId = Attributes.Value });
                nodesToRead.Add(new ReadValueId() { NodeId = NodeId.Parse(Alias2TB.Text), AttributeId = Attributes.Value });

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
            // need to make sure the results are processed on the correct thread.
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
                if (results[0].StatusCode.IsBad())
                {
                    Result1TB.Text = results[0].StatusCode.ToString();
                }
                else
                {
                    Result1TB.Text = results[0].WrappedValue.ToString();
                }

                if (results[1].StatusCode.IsBad())
                {
                    Result2TB.Text = results[1].StatusCode.ToString();
                }
                else
                {
                    Result2TB.Text = results[1].WrappedValue.ToString();
                }
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
        #endregion

        #region Event Handlers
        private void RegisterBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UseAsynchCK.Checked)
                {
                    Register();
                }
                else
                {
                    BeginRegister();
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void UnregisterBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UseAsynchCK.Checked)
                {
                    Unregister();
                }
                else
                {
                    BeginUnregister();
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void ReadBTN_Click(object sender, EventArgs e)
        {
            try
            {
                Read();
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void NodeIdBTN_Click(object sender, EventArgs e)
        {
            TextBox target = (sender == NodeId1BTN) ? NodeId1TB : NodeId2TB;

            if (target == null)
            {
                return;
            }

            m_parent.OnNodeIdButtonClick(this, target);
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
