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
    public partial class AddNodesDlg : Form
    {
        /// <summary>
        /// Synchronously calls a method on the server.
        /// </summary>
        private void AddNodes()
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

                // create the node to add.
                AddNodesItem nodeToAdd = new AddNodesItem()
                {
                    ParentNodeId = NodeId.Parse(ParentIdTB.Text),
                    ReferenceTypeId = NodeId.Parse(ReferenceTypeIdTB.Text),
                    NodeClass = (NodeClass)NodeClassCB.SelectedItem,
                    BrowseName = new QualifiedName(BrowseNameTB.Text, 1)
                };

                // fill in the node class specific attributes.
                switch (nodeToAdd.NodeClass)
                {
                    case NodeClass.Object:
                    {
                        nodeToAdd.TypeDefinition = NodeId.Parse(TypeDefinitionIdTB.Text);

                        nodeToAdd.NodeAttributes = new ExtensionObject(new ObjectAttributes()
                        {
                            SpecifiedAttributes = (uint)(NodeAttributesMask.DisplayName),
                            DisplayName = BrowseNameTB.Text
                        });

                        break;
                    }

                    case NodeClass.Variable:
                    {
                        nodeToAdd.TypeDefinition = NodeId.Parse(TypeDefinitionIdTB.Text);

                        nodeToAdd.NodeAttributes = new ExtensionObject(new VariableAttributes()
                        {
                            SpecifiedAttributes = (uint)(NodeAttributesMask.DataType | NodeAttributesMask.ValueRank | NodeAttributesMask.DisplayName),
                            DisplayName = BrowseNameTB.Text,
                            DataType = NodeId.Parse(DataTypeIdTB.Text),
                            ValueRank = (int)ValueRankCB.SelectedItem
                        });

                        break;
                    }
                }

                List<AddNodesItem> nodesToAdd = new List<AddNodesItem>();
                nodesToAdd.Add(nodeToAdd);

                // this is a blocking call so show the wait cursor.
                Cursor = Cursors.WaitCursor;

                // add the node.
                List<AddNodesResult> results = session.AddNodes(nodesToAdd, null);

                // display the result.
                foreach (AddNodesResult result in results)
                {
                    if (result.StatusCode.IsBad())
                    {
                        NewNodeIdTB.Text = result.StatusCode.ToString();
                    }
                    else
                    {
                        NewNodeIdTB.Text = result.AddedNodeId.ToString();
                    }
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
        private void BeginAddNodes()
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

                // create the node to add.
                AddNodesItem nodeToAdd = new AddNodesItem()
                {
                    ParentNodeId = NodeId.Parse(ParentIdTB.Text),
                    ReferenceTypeId = NodeId.Parse(ReferenceTypeIdTB.Text),
                    NodeClass = (NodeClass)NodeClassCB.SelectedItem,
                    BrowseName = new QualifiedName(BrowseNameTB.Text, 1)
                };

                // fill in the node class specific attributes.
                switch (nodeToAdd.NodeClass)
                {
                    case NodeClass.Object:
                    {
                        nodeToAdd.TypeDefinition = NodeId.Parse(TypeDefinitionIdTB.Text);

                        nodeToAdd.NodeAttributes = new ExtensionObject(new ObjectAttributes()
                        {
                            SpecifiedAttributes = (uint)(NodeAttributesMask.DisplayName),
                            DisplayName = BrowseNameTB.Text
                        });

                        break;
                    }

                    case NodeClass.Variable:
                    {
                        nodeToAdd.TypeDefinition = NodeId.Parse(TypeDefinitionIdTB.Text);

                        nodeToAdd.NodeAttributes = new ExtensionObject(new VariableAttributes()
                        {
                            SpecifiedAttributes = (uint)(NodeAttributesMask.DataType | NodeAttributesMask.ValueRank | NodeAttributesMask.DisplayName),
                            DisplayName = BrowseNameTB.Text,
                            DataType = NodeId.Parse(DataTypeIdTB.Text),
                            ValueRank = (int)ValueRankCB.SelectedItem
                        });

                        break;
                    }
                }

                List<AddNodesItem> nodesToAdd = new List<AddNodesItem>();
                nodesToAdd.Add(nodeToAdd);

                // add the node.
                session.BeginAddNodes(nodesToAdd, null, OnAddNodesComplete, session);
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        /// <summary>
        /// Finishes an asynchronous read request.
        /// </summary>
        private void OnAddNodesComplete(IAsyncResult ar)
        {
            // need to make sure the results are processed on the correct thread.
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(OnAddNodesComplete), ar);
                return;
            }

            // get the session used to send the request which was passed as the userData in the Begin call.
            Session session = (Session)ar.AsyncState;

            try
            {
                // end the request.
                List<AddNodesResult> results = session.EndAddNodes(ar);

                // don't update the controls if the session has changed.
                if (!Object.ReferenceEquals(session, m_parent.Session))
                {
                    return;
                }

                // display the result.
                foreach (AddNodesResult result in results)
                {
                    if (result.StatusCode.IsBad())
                    {
                        NewNodeIdTB.Text = result.StatusCode.ToString();
                    }
                    else
                    {
                        NewNodeIdTB.Text = result.AddedNodeId.ToString();
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

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="AddNodes"/> class.
        /// </summary>
        public AddNodesDlg()
        {
            InitializeComponent();
            Icon = GuiUtils.GetDefaultIcon();
            CancelButton = this.CancelBTN;
        }
        #endregion

        #region Private Fields
        private MainForm m_parent;

        private enum ValueRank
        {
            Scalar = UnifiedAutomation.UaBase.ValueRanks.Scalar,
            OneDimension = UnifiedAutomation.UaBase.ValueRanks.OneDimension,
            ScalarOrOneDimension = UnifiedAutomation.UaBase.ValueRanks.ScalarOrOneDimension,
            OneOrMoreDimensions = UnifiedAutomation.UaBase.ValueRanks.OneOrMoreDimensions,
            TwoDimensions = UnifiedAutomation.UaBase.ValueRanks.TwoDimensions,
            Any = UnifiedAutomation.UaBase.ValueRanks.Any
        }
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

            ParentIdTB.Text = ObjectIds.ObjectsFolder.ToString();
            ReferenceTypeIdTB.Text = ReferenceTypeIds.Organizes.ToString();
            NodeClassCB.Items.Add(NodeClass.Object);
            NodeClassCB.Items.Add(NodeClass.Variable);
            NodeClassCB.SelectedIndex = 0;
            BrowseNameTB.Text = "MyNewNode";
            TypeDefinitionIdTB.Text = ObjectTypeIds.BaseObjectType.ToString();
            DataTypeIdTB.Text = DataTypeIds.String.ToString();
            DataTypeIdTB.Enabled = false;

            foreach (ValueRank value in Enum.GetValues(typeof(ValueRank)))
            {
                ValueRankCB.Items.Add(value);
            }

            ValueRankCB.SelectedItem = ValueRank.Scalar;
            ValueRankCB.Enabled = false;

            Show();
        }
        #endregion

        #region Event Handlers
        private void AddNodesBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UseAsynchCK.Checked)
                {
                    AddNodes();
                }
                else
                {
                    BeginAddNodes();
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void ParentBTN_Click(object sender, EventArgs e)
        {
            m_parent.OnNodeIdButtonClick(this, ParentIdTB, ObjectIds.RootFolder, ReferenceTypeIds.HierarchicalReferences);
        }

        private void ParentIdTB_TextChanged(object sender, EventArgs e)
        {
            m_parent.OnNodeIdTextChanged(ParentIdTB);
            SetToolTip(ParentIdTB);
        }

        private void ReferenceTypeIdTB_TextChanged(object sender, EventArgs e)
        {
            m_parent.OnNodeIdTextChanged(ReferenceTypeIdTB);
            SetToolTip(ReferenceTypeIdTB);
        }

        private void ReferenceTypeIdBTN_Click(object sender, EventArgs e)
        {
            m_parent.OnNodeIdButtonClick(this, ReferenceTypeIdTB, ReferenceTypeIds.References, ReferenceTypeIds.HasSubtype);
        }

        private void TypeDefinitionIdTB_TextChanged(object sender, EventArgs e)
        {
            m_parent.OnNodeIdTextChanged(TypeDefinitionIdTB);
            SetToolTip(TypeDefinitionIdTB);
        }

        private void TypeDefinitionIdBTN_MouseClick(object sender, MouseEventArgs e)
        {
            if ((NodeClass)NodeClassCB.SelectedItem == NodeClass.Variable)
            {
                m_parent.OnNodeIdButtonClick(this, TypeDefinitionIdTB, VariableTypeIds.BaseDataVariableType, ReferenceTypeIds.HasSubtype);
            }
            else
            {
                m_parent.OnNodeIdButtonClick(this, TypeDefinitionIdTB, ObjectTypeIds.BaseObjectType, ReferenceTypeIds.HasSubtype);
            }
        }

        private void DataTypeIdTB_TextChanged(object sender, EventArgs e)
        {
            m_parent.OnNodeIdTextChanged(DataTypeIdTB);
            SetToolTip(DataTypeIdTB);
        }

        private void DataTypeBTN_Click(object sender, EventArgs e)
        {
            m_parent.OnNodeIdButtonClick(this, DataTypeIdTB, DataTypeIds.BaseDataType, ReferenceTypeIds.HasSubtype);
        }

        private void NodeClassCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((NodeClass)NodeClassCB.SelectedItem == NodeClass.Variable)
            {
                TypeDefinitionIdTB.Text = VariableTypeIds.BaseDataVariableType.ToString();
                DataTypeIdTB.Enabled = true;
                ValueRankCB.Enabled = true;
            }
            else
            {
                TypeDefinitionIdTB.Text = ObjectTypeIds.BaseObjectType.ToString();
                DataTypeIdTB.Enabled = false;
                ValueRankCB.Enabled = false;
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
