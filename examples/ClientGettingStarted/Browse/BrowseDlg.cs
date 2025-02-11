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
    /// Shows a dialog which demonstrates a browse operation.
    /// </summary>
    public partial class BrowseDlg : Form
    {
        /// <summary>
        /// Synchronously browses the references from a node.
        /// </summary>
        private void Browse()
        {
            ///
            try
            {
                // get the current session from the parent form.
                Session session = m_parent.Session;

                // nothing to do if no session.
                if (session == null)
                {
                    return;
                }

                // clear the existing references.
                ReferencesLV.Items.Clear();

                /// [Browse 1]
                // set up the browse filters.
                BrowseContext context = new BrowseContext();

                context.BrowseDirection = (BrowseDirection)BrowseDirectionCB.SelectedItem;
                context.ReferenceTypeId = (NodeId)ReferenceTypeTB.Tag;
                context.IncludeSubtypes = IncludeSubtypesCK.Checked;
                context.MaxReferencesToReturn = (uint)MaxReferencesUD.Value;
                /// [Browse 1]

                /// [Browse 3]
                m_continueAutomatically = context.MaxReferencesToReturn <= 0;
                /// [Browse 3]

                /// [Browse 2]
                // parse the node id.
                NodeId nodeId = NodeId.Parse(NodeIdTB.Text);

                // this is a blocking call so show the wait cursor.
                Cursor = Cursors.WaitCursor;

                byte[] continuationPoint = null;

                // browse the references (setting a 10 second timeout).
                List<ReferenceDescription> references = session.Browse(
                    nodeId,
                    context,
                    new RequestSettings() { OperationTimeout = 10000 },
                    out continuationPoint);
                /// [Browse 2]

                // add references to control.
                foreach (ReferenceDescription reference in references)
                {
                    AddReference(session, reference);
                }

                // process any continuation points.
                /// [Browse 4]
                while (!ByteString.IsNull(continuationPoint))
                {
                    if (!m_continueAutomatically)
                    {
                        session.ReleaseBrowseContinuationPoint(continuationPoint);
                        break;
                    }

                    references = session.BrowseNext(new RequestSettings() { OperationTimeout = 10000 }, ref continuationPoint);
                    /// [Browse 4]

                    foreach (ReferenceDescription reference in references)
                    {
                        AddReference(session, reference);
                    }
                }

                // adjust the column widths.
                foreach (ColumnHeader column in ReferencesLV.Columns)
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
        /// Asynchronously browses the references from a node.
        /// </summary>
        private void BeginBrowse()
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

                // clear the existing references.
                ReferencesLV.Items.Clear();

                // set up the browse filters.
                BrowseContext context = new BrowseContext();

                context.BrowseDirection = (BrowseDirection)BrowseDirectionCB.SelectedItem;
                context.ReferenceTypeId = (NodeId)ReferenceTypeTB.Tag;
                context.IncludeSubtypes = IncludeSubtypesCK.Checked;
                context.MaxReferencesToReturn = (uint)MaxReferencesUD.Value;

                m_continueAutomatically = context.MaxReferencesToReturn <= 0;

                // parse the node id.
                NodeId nodeId = NodeId.Parse(NodeIdTB.Text);

                // browse the references (setting a 10 second timeout).
                session.BeginBrowse(
                    nodeId,
                    context,
                    new RequestSettings() { OperationTimeout = 10000 },
                    OnBrowseComplete,
                    session);
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        /// <summary>
        /// Finishes an asynchronous browse or browse next request.
        /// </summary>
        private void OnBrowseComplete(IAsyncResult result)
        {
            // need to make sure the results are processed on the correct thread.
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnBrowseComplete), result);
                return;
            }

            // get the session used to send the request which was passed as the userData in the Begin call.
            Session session = (Session)result.AsyncState;

            try
            {
                byte[] continuationPoint = null;

                // get the results.
                List<ReferenceDescription> references = session.EndBrowse(result, out continuationPoint);

                // don't update the controls if the session has changed.
                if (!Object.ReferenceEquals(session, m_parent.Session))
                {
                    return;
                }

                // add references to control.
                foreach (ReferenceDescription reference in references)
                {
                    AddReference(session, reference);
                }

                // request any additional references.
                if (!ByteString.IsNull(continuationPoint))
                {
                    if (m_continueAutomatically)
                    {
                        session.BeginBrowseNext(
                            continuationPoint,
                            new RequestSettings() { OperationTimeout = 10000 },
                            OnBrowseComplete,
                            session);

                        return;
                    }

                    session.ReleaseBrowseContinuationPoint(continuationPoint);
                }

                // adjust the column widths when done.
                foreach (ColumnHeader column in ReferencesLV.Columns)
                {
                    column.Width = -2;
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

        /// <summary>
        /// Adds the reference to the list view.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="reference">The reference.</param>
        private void AddReference(Session session, ReferenceDescription reference)
        {
            ListViewItem item = new ListViewItem();

            if (!reference.IsForward)
            {
                LocalizedText text = session.Cache.GetAttribute<LocalizedText>(reference.ReferenceTypeId, Attributes.InverseName, null);

                if (text != null)
                {
                    item.Text = text.ToString();
                }
            }

            if (String.IsNullOrEmpty(item.Text))
            {
                item.Text = session.Cache.GetDisplayText(reference.ReferenceTypeId);
            }

            item.SubItems.Add(session.Cache.GetDisplayText(reference.NodeId));
            item.SubItems.Add(reference.NodeClass.ToString());
            item.SubItems.Add(session.Cache.GetDisplayText(reference.TypeDefinition));
            item.Tag = reference;

            ReferencesLV.Items.Add(item);
        }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicReadDlg"/> class.
        /// </summary>
        public BrowseDlg()
        {
            InitializeComponent();
            Icon = GuiUtils.GetDefaultIcon();

            BrowseDirectionCB.Items.Clear();
            BrowseDirectionCB.Items.Add(BrowseDirection.Forward);
            BrowseDirectionCB.Items.Add(BrowseDirection.Inverse);
            BrowseDirectionCB.Items.Add(BrowseDirection.Both);
            BrowseDirectionCB.SelectedIndex = 0;
            CancelButton = this.CancelBTN;
        }
        #endregion

        #region Private Fields
        private MainForm m_parent;
        private bool m_continueAutomatically;
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
            HelpBTN.Enabled = parent != null && parent.HelpExists(GetType());
            InstructionsLB.Text = parent.GetInstructions(this.GetType());
            NodeIdTB_TextChanged(this, null);
            ReferenceTypeTB.Text = m_parent.Session.Cache.GetDisplayText(ReferenceTypeIds.References);
            ReferenceTypeTB.Tag = ReferenceTypeIds.References;
            Show();
        }
        #endregion

        #region Event Handlers
        private void BrowseBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UseAsynchCK.Checked)
                {
                    Browse();
                }
                else
                {
                    BeginBrowse();
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

        private void ViewBTN_Click(object sender, EventArgs e)
        {
            m_parent.ShowEditValueDialog(((DataValue)ReferenceTypeTB.Tag).Value);
        }

        private void ReferenceTypeBTN_Click(object sender, EventArgs e)
        {
            UnifiedAutomation.UaClient.Controls.BrowseDlg dialog = new UnifiedAutomation.UaClient.Controls.BrowseDlg();

            dialog.StartPosition = FormStartPosition.Manual;
            dialog.Size = this.Size;
            dialog.Location = this.Location;

            NodeId referenceTypeId = dialog.ShowDialog(m_parent.Session, ReferenceTypeIds.References, ReferenceTypeIds.HasSubtype, 0);

            if (referenceTypeId != null)
            {
                ReferenceTypeTB.Text = m_parent.Session.Cache.GetDisplayText(referenceTypeId);
                ReferenceTypeTB.Tag = referenceTypeId;
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
