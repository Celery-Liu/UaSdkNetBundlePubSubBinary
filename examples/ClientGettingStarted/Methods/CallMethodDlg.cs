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
    public partial class CallMethodDlg : Form
    {
        /// <summary>
        /// Synchronously calls a method on the server.
        /// </summary>
        private void CallMethod()
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

                /// [Step 1]
                // parse the object id.
                NodeId objectId = NodeId.Parse(NodeIdTB.Text);

                // get the selected method id.
                NodeId methodId = (NodeId)((ReferenceDescription)MethodCB.SelectedItem).NodeId;

                // get input arguments.
                List<Variant> inputArguments = GetInputArgumentsFromGui();
                /// [Step 1]

                // this is a blocking call so show the wait cursor.
                Cursor = Cursors.WaitCursor;

                /// [Step 2]
                List<StatusCode> inputArgumentErrors = null;
                List<Variant> outputArguments = null;

                // call the method on the server.
                StatusCode error = session.Call(
                    objectId,
                    methodId,
                    inputArguments,
                    new RequestSettings() { OperationTimeout = 15000 },
                    out inputArgumentErrors,
                    out outputArguments);
                /// [Step 2]

                /// [Step 3]
                // check for error.
                // A method always returns a status code indicating success or failure
                if (StatusCode.IsBad(error))
                {
                    ShowError(error);
                    return;
                }

                // update the output arguments.
                SetOutputArgumentsToGui(outputArguments);
                /// [Step 3]

                // adjust column widths.
                foreach (ColumnHeader header in OutputArgumentsLV.Columns)
                {
                    header.Width = -2;
                }

                MessageDialog.Show(this, "Method Call Succeeded!");
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

        private void ShowError(StatusCode error)
        {
            string message = "Server returned an error while calling method: " + error.ToString();
            if (error == StatusCodes.BadInvalidArgument)
            {
                List<Variant> inputArguments = GetInputArgumentsFromGui();
                foreach (var argument in inputArguments)
                {
                    if (argument.IsNull)
                    {
                        message += Environment.NewLine + "Argument null. Note: Custom structured DataType are not supported in this example.";
                        break;
                    }
                }
            }
            m_parent.ShowError(this, message);
        }

        /// <summary>
        /// Asynchronously calls a method on a server.
        /// </summary>
        private void BeginCallMethod()
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

                // parse the object id.
                NodeId objectId = NodeId.Parse(NodeIdTB.Text);

                // get the selected method id.
                ReferenceDescription method = (ReferenceDescription)MethodCB.SelectedItem;

                // get input arguments.
                List<Variant> inputArguments = GetInputArgumentsFromGui();

                // call the method.
                session.BeginCall(
                    objectId,
                    (NodeId)method.NodeId,
                    inputArguments,
                    new RequestSettings() { OperationTimeout = 15000 },
                    OnCallMethodComplete,
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
        private void OnCallMethodComplete(IAsyncResult result)
        {
            // need to make sure the results are processed on the correct thread.
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnCallMethodComplete), result);
                return;
            }

            // get the session used to send the request which was passed as the userData in the Begin call.
            Session session = (Session)result.AsyncState;

            try
            {
                // get the results.
                List<StatusCode> inputArgumentErrors = null;
                List<Variant> outputArguments = null;

                // call the method.
                StatusCode error = session.EndCall(
                    result,
                    out inputArgumentErrors,
                    out outputArguments);

                // don't update the controls if the session has changed.
                if (!Object.ReferenceEquals(session, m_parent.Session))
                {
                    return;
                }

                // check for error.
                if (StatusCode.IsBad(error))
                {
                    ShowError(error);
                    return;
                }

                // update the output arguments.
                SetOutputArgumentsToGui(outputArguments);

                // adjust column widths.
                foreach (ColumnHeader header in OutputArgumentsLV.Columns)
                {
                    header.Width = -2;
                }

                MessageDialog.Show(this, "Method Call Succeeded!");
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
        /// Initializes a new instance of the <see cref="CallMethodDlg"/> class.
        /// </summary>
        public CallMethodDlg()
        {
            InitializeComponent();
            Icon = GuiUtils.GetDefaultIcon();
            CancelButton = this.CancelBTN;
        }
        #endregion

        #region Private Fields
        private MainForm m_parent;
        #endregion

        #region Private Methods
        /// <summary>
        /// Collects the input arguments from the input arguments tree view.
        /// </summary>
        private List<Variant> GetInputArgumentsFromGui()
        {
            List<Variant> inputArguments = new List<Variant>();

            foreach (ListViewItem item in InputArgumentsLV.Items)
            {
                if (item.Tag != null)
                {
                    inputArguments.Add(((Argument)item.Tag).Value);
                }
            }

            return inputArguments;
        }

        /// <summary>
        /// Sets the output arguments to the output arguments tree view.
        /// </summary>
        void SetOutputArgumentsToGui(List<Variant> outputArguments)
        {
            for (int ii = 0; ii < outputArguments.Count; ii++)
            {
                Argument argument = OutputArgumentsLV.Items[ii].Tag as Argument;
                // extract value from method call output argument list
                argument.Value = outputArguments[ii];
                OutputArgumentsLV.Items[ii].SubItems[1].Text = argument.Value.ToString();
            }
        }

        ///[Step 4]
        /// <summary>
        /// Starts a request to browse the methods of an object.
        /// </summary>
        private void BrowseMethods(NodeId objectId)
        {
            // get the current session from the parent form.
            Session session = m_parent.Session;

            // nothing to do if no session.
            if (session == null)
            {
                return;
            }

            BrowseDescription description = new BrowseDescription()
            {
                NodeId = objectId,
                BrowseDirection = BrowseDirection.Forward,
                ReferenceTypeId = ReferenceTypeIds.HasComponent,
                IncludeSubtypes = true,
                NodeClassMask = (uint)NodeClass.Method,
                ResultMask = (uint)(BrowseResultMask.BrowseName | BrowseResultMask.DisplayName)
            };

            List<BrowseDescription> nodesToBrowse = new List<BrowseDescription>();
            nodesToBrowse.Add(description);

            session.BeginBrowseList(
                null,
                nodesToBrowse,
                0,
                new RequestSettings() { OperationTimeout = 10000 },
                OnBrowseMethodsComplete,
                session);
        }

        /// <summary>
        /// Finishes a request to browse the methods of an object.
        /// </summary>
        private void OnBrowseMethodsComplete(IAsyncResult result)
        {
            // need to make sure the results are processed on the correct thread.
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnBrowseMethodsComplete), result);
                return;
            }

            // get the session used to send the request which was passed as the userData in the Begin call.
            Session session = (Session)result.AsyncState;

            try
            {
                // get the results.
                List<List<ReferenceDescription>> results = session.EndBrowseList(result);
                /// [Step 4]

                // don't update the controls if the session has changed.
                if (!Object.ReferenceEquals(session, m_parent.Session))
                {
                    return;
                }

                // populate list of methods.
                MethodCB.Items.Clear();

                if (results[0] != null)
                {
                    foreach (ReferenceDescription reference in results[0])
                    {
                        MethodCB.Items.Add(reference);
                    }

                    if (MethodCB.Items.Count > 0)
                    {
                        MethodCB.SelectedIndex = 0;
                    }
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
            ParseObjectAndAddMethods();
            Show();
        }
        #endregion

        #region Event Handlers
        private void CallMethodBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UseAsynchCK.Checked)
                {
                    CallMethod();
                }
                else
                {
                    BeginCallMethod();
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
            ParseObjectAndAddMethods();
        }

        private void ParseObjectAndAddMethods()
        {
            InputArgumentsLV.Items.Clear();
            OutputArgumentsLV.Items.Clear();

            try
            {
                NodeId objectId = NodeId.Parse(NodeIdTB.Text);
                BrowseMethods(objectId);
            }
            catch (Exception)
            {
                // do nothing.
            }
        }

        private void NodeIdTB_TextChanged(object sender, EventArgs e)
        {
            m_parent.OnNodeIdTextChanged(NodeIdTB);
            InputArgumentsLV.Items.Clear();
            OutputArgumentsLV.Items.Clear();
        }

        private void MethodCB_SelectedIndexChanged(object sender, EventArgs e)
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

                ReferenceDescription reference = (ReferenceDescription)MethodCB.SelectedItem;
                NodeId methodId = (NodeId)reference.NodeId;

                // fetch method description.
                ///[Step 5_1]
                session.Model.BeginGetMethodDescription(methodId, OnMethodSelectedComplete, session);
                ///[Step 5_1]
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        /// <summary>
        /// Finishes a request to browse the methods of an object.
        /// </summary>
        private void OnMethodSelectedComplete(IAsyncResult result)
        {
            // need to make sure the results are processed on the correct thread.
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnMethodSelectedComplete), result);
                return;
            }

            // get the session used to send the request which was passed as the userData in the Begin call.
            Session session = (Session)result.AsyncState;

            try
            {
                // get the results.
                ///[Step 5_2]
                MethodDescription method = session.Model.EndGetMethodDescription(result);
                ///[Step 5_2]

                // don't update the controls if the session has changed.
                if (!Object.ReferenceEquals(session, m_parent.Session))
                {
                    return;
                }

                InputArgumentsLV.Items.Clear();
                OutputArgumentsLV.Items.Clear();

                // display the input arguments.
                if (method.InputArguments != null)
                {
                    ///[Step 5_3]
                    foreach (Argument argument in method.InputArguments)
                    {
                        Variant defaultValue = TypeUtils.GetDefaultValue(argument.DataType, argument.ValueRank, session.Cache);
                        string argumentName = argument.Name;
                        ///[Step 5_3]

                        argument.Value = defaultValue;
                        ListViewItem item = new ListViewItem();
                        item.Text = argumentName;
                        item.SubItems.Add(argument.Value.ToString());
                        item.Tag = argument;

                        InputArgumentsLV.Items.Add(item);
                    }
                }
                else
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = "This method has no input arguments";
                    item.SubItems.Add(String.Empty);
                    item.ForeColor = Color.Gray;

                    InputArgumentsLV.Items.Add(item);
                }

                // adjust column widths.
                foreach (ColumnHeader header in InputArgumentsLV.Columns)
                {
                    header.Width = -2;
                }

                InputArgumentsLV.Visible = InputArgumentsLV.Items.Count > 0;

                // display the output arguments.
                if (method.OutputArguments != null)
                {
                    foreach (Argument argument in method.OutputArguments)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = argument.Name;
                        item.SubItems.Add(argument.Value.ToString());
                        item.Tag = argument;

                        OutputArgumentsLV.Items.Add(item);
                    }
                }
                else
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = "This method has no output arguments";
                    item.SubItems.Add(String.Empty);
                    item.ForeColor = Color.Gray;

                    OutputArgumentsLV.Items.Add(item);
                }

                // adjust column widths.
                foreach (ColumnHeader header in OutputArgumentsLV.Columns)
                {
                    header.Width = -2;
                }

                OutputArgumentsLV.Visible = OutputArgumentsLV.Items.Count > 0;
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

        private void InputArgumentsLV_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (InputArgumentsLV.SelectedItems.Count > 0)
                {
                    Argument argument = InputArgumentsLV.SelectedItems[0].Tag as Argument;
                    Variant? variant = m_parent.ShowEditValueDialog(argument.Value, argument.DataType, argument.ValueRank);

                    if (variant != null)
                    {
                        argument.Value = variant.Value;
                        InputArgumentsLV.SelectedItems[0].SubItems[1].Text = argument.Value.ToString();
                    }
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
