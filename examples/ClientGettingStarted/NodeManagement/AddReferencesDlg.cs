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
    public partial class AddReferencesDlg : Form
    {
        /// <summary>
        /// Synchronously calls a method on the server.
        /// </summary>
        private void AddReferences()
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

                // create the reference to add.
                AddReferencesItem referenceToNode = new AddReferencesItem()
                {
                    SourceNodeId = NodeId.Parse(SourceIdTB.Text),
                    IsForward = IsForwardCK.Checked,
                    ReferenceTypeId = NodeId.Parse(ReferenceTypeIdTB.Text),
                    TargetNodeId = NodeId.Parse(TargetIdTB.Text)
                };

                List<AddReferencesItem> referencesToNode = new List<AddReferencesItem>();
                referencesToNode.Add(referenceToNode);

                // this is a blocking call so show the wait cursor.
                Cursor = Cursors.WaitCursor;

                // add the reference.
                List<StatusCode> results = session.AddReferences(referencesToNode, null);

                // display the result.
                foreach (StatusCode result in results)
                {
                    ResultTB.Text = result.ToString();
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
        /// Asynchronously calls a method on a server.
        /// </summary>
        private void BeginAddReferences()
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

                // create the reference to add.
                AddReferencesItem referenceToNode = new AddReferencesItem()
                {
                    SourceNodeId = NodeId.Parse(SourceIdTB.Text),
                    IsForward = IsForwardCK.Checked,
                    ReferenceTypeId = NodeId.Parse(ReferenceTypeIdTB.Text),
                    TargetNodeId = NodeId.Parse(TargetIdTB.Text)
                };

                List<AddReferencesItem> referencesToNode = new List<AddReferencesItem>();
                referencesToNode.Add(referenceToNode);

                session.BeginAddReferences(referencesToNode, null, OnAddReferencesComplete, session);
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        /// <summary>
        /// Finishes an asynchronous read request.
        /// </summary>
        private void OnAddReferencesComplete(IAsyncResult ar)
        {
            // need to make sure the results are processed on the correct thread.
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnAddReferencesComplete), ar);
                return;
            }

            // get the session used to send the request which was passed as the userData in the Begin call.
            Session session = (Session)ar.AsyncState;

            try
            {
                // add the reference.
                List<StatusCode> results = session.EndAddReferences(ar);

                // don't update the controls if the session has changed.
                if (!Object.ReferenceEquals(session, m_parent.Session))
                {
                    return;
                }

                // display the result.
                foreach (StatusCode result in results)
                {
                    ResultTB.Text = result.ToString();
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

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="AddReferencesDlg"/> class.
        /// </summary>
        public AddReferencesDlg()
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
        private void SetToolTip(TextBox textbox)
        {
            try
            {
                ToolTip.SetToolTip(textbox, m_parent.Session.Cache.GetDisplayText(NodeId.Parse(textbox.Text)));
            }
            catch (Exception)
            {
                // ignore
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
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(parent.Location.X + (parent.Width - this.Width) / 2, parent.Location.Y + (parent.Height - this.Height) / 2);
            InstructionsLB.Text = parent.GetInstructions(this.GetType());

            SourceIdTB.Text = ObjectIds.ObjectsFolder.ToString();
            ReferenceTypeIdTB.Text = ReferenceTypeIds.HasProperty.ToString();
            IsForwardCK.Checked = true;
            TargetIdTB.Text = VariableIds.Server_NamespaceArray.ToString();

            Show();
        }
        #endregion

        #region Event Handlers
        private void AddReferencesBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UseAsynchCK.Checked)
                {
                    AddReferences();
                }
                else
                {
                    BeginAddReferences();
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void SourceIdBTN_Click(object sender, EventArgs e)
        {
            m_parent.OnNodeIdButtonClick(this, SourceIdTB, ObjectIds.ObjectsFolder, ReferenceTypeIds.HierarchicalReferences);
        }

        private void SourceTB_TextChanged(object sender, EventArgs e)
        {
            m_parent.OnNodeIdTextChanged(SourceIdTB);
            SetToolTip(SourceIdTB);
        }

        private void ReferenceTypeIdTB_TextChanged(object sender, EventArgs e)
        {
            m_parent.OnNodeIdTextChanged(ReferenceTypeIdTB);
            SetToolTip(ReferenceTypeIdTB);
        }

        private void ReferenceTypeIdBTN_Click(object sender, EventArgs e)
        {
            m_parent.OnNodeIdButtonClick(this, ReferenceTypeIdTB, ReferenceTypeIds.References, ReferenceTypeIds.HierarchicalReferences);
        }

        private void TargetIdTB_TextChanged(object sender, EventArgs e)
        {
            m_parent.OnNodeIdTextChanged(TargetIdTB);
            SetToolTip(TargetIdTB);
        }

        private void TargetIdBTN_MouseClick(object sender, MouseEventArgs e)
        {
            m_parent.OnNodeIdButtonClick(this, TargetIdTB, ObjectIds.ObjectsFolder, ReferenceTypeIds.HierarchicalReferences);
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
