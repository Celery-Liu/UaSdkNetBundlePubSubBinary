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
    /// Shows a dialog which demonstrates a translate browse paths operation.
    /// </summary>
    public partial class TranslateBrowsePathsDlg : Form
    {
        /// <summary>
        /// Synchronously translate the browse paths.
        /// </summary>
        private void Translate()
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

                /// [Translate 1]
                // parse the node id.
                NodeId startingNodeId = NodeId.Parse(NodeIdTB.Text);

                // get the browse paths.
                List<BrowsePath> pathsToTranslate = new List<BrowsePath>();
                pathsToTranslate.Add(GetBrowsePath(startingNodeId, AbsoluteName.ToQualifiedNames(PathToTranslate1TB.Text)));
                pathsToTranslate.Add(GetBrowsePath(startingNodeId, AbsoluteName.ToQualifiedNames(PathToTranslate2TB.Text)));

                // this is a blocking call so show the wait cursor.
                Cursor = Cursors.WaitCursor;

                // translate the references (setting a 10 second timeout).
                List<BrowsePathResult> results = session.TranslateBrowsePath(
                    pathsToTranslate,
                    new RequestSettings() { OperationTimeout = 10000 });
                /// [Translate 1]

                // update controls.
                UpdateControl(TranslatedNode1TB, results[0]);
                UpdateControl(TranslatedNode2TB, results[1]);
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
        /// Asynchronously translates the browse path.
        /// </summary>
        private void BeginTranslate()
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

                // parse the node id.
                NodeId startingNodeId = NodeId.Parse(NodeIdTB.Text);

                // get the browse paths.
                List<BrowsePath> pathsToTranslate = new List<BrowsePath>();
                pathsToTranslate.Add(GetBrowsePath(startingNodeId, AbsoluteName.ToQualifiedNames(PathToTranslate1TB.Text)));
                pathsToTranslate.Add(GetBrowsePath(startingNodeId, AbsoluteName.ToQualifiedNames(PathToTranslate2TB.Text)));

                // translate the browse path (setting a 10 second timeout).
                session.BeginTranslateBrowsePath(
                    pathsToTranslate,
                    new RequestSettings() { OperationTimeout = 10000 },
                    OnTranslateComplete,
                    session);
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        /// <summary>
        /// Finishes an asynchronous translate browse path request.
        /// </summary>
        private void OnTranslateComplete(IAsyncResult result)
        {
            // need to make sure the results are processed on the correct thread.
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnTranslateComplete), result);
                return;
            }

            // get the session used to send the request which was passed as the userData in the Begin call.
            Session session = (Session)result.AsyncState;

            try
            {
                // get the results.
                List<BrowsePathResult> results = session.EndTranslateBrowsePath(result);

                // don't update the controls if the session has changed.
                if (!Object.ReferenceEquals(session, m_parent.Session))
                {
                    return;
                }

                // update controls.
                UpdateControl(TranslatedNode1TB, results[0]);
                UpdateControl(TranslatedNode2TB, results[1]);
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
        /// Gets the browse path from a list of browse names,.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="absoluteNames">The browse names.</param>
        /// <returns>The browse path.</returns>
        /// [Translate 2]
        private BrowsePath GetBrowsePath(NodeId startingNodeId, IList<QualifiedName> qnames)
        {
            BrowsePath browsePath = new BrowsePath();
            browsePath.StartingNode = startingNodeId;

            foreach (QualifiedName qname in qnames)
            {
                browsePath.RelativePath.Elements.Add(new RelativePathElement()
                {
                    ReferenceTypeId = ReferenceTypeIds.HierarchicalReferences,
                    IncludeSubtypes = true,
                    IsInverse = false,
                    TargetName = qname
                });
            }

            return browsePath;
        }
        /// [Translate 2]

        /// <summary>
        /// Updates the control.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="result">The result.</param>
        private void UpdateControl(TextBox control, BrowsePathResult result)
        {
            if (StatusCode.IsGood(result.StatusCode))
            {
                // where there is a match there is usually only one but if there are more the node that
                // matches the browse path the node that matches the type definition is returned first.
                BrowsePathTarget target = result.Targets[0];

                // the remaining path index is only used when a path crosses into another server.
                if (target.RemainingPathIndex < UInt32.MaxValue)
                {
                    control.Text = target.TargetId.ToString();
                }
                else
                {
                    control.Text = target.TargetId.ToString();
                }
            }

            // display any error.
            else
            {
                control.Text = result.StatusCode.ToString();
            }
        }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicReadDlg"/> class.
        /// </summary>
        public TranslateBrowsePathsDlg()
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
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(parent.Location.X + (parent.Width - this.Width) / 2, parent.Location.Y + (parent.Height - this.Height) / 2);
            HelpBTN.Enabled = parent != null && parent.HelpExists(GetType());

            InstructionsLB.Text = parent.GetInstructions(this.GetType());
            NodeIdTB.Text = ObjectIds.Server.ToString();
            PathToTranslate1TB.Text = "/0:ServerStatus/0:BuildInfo/0:ProductName";
            PathToTranslate2TB.Text = "/0:ServerStatus/0:CurrentTime";

            Show();
        }
        #endregion

        #region Event Handlers
        private void TranslateBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UseAsynchCK.Checked)
                {
                    Translate();
                }
                else
                {
                    BeginTranslate();
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

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
