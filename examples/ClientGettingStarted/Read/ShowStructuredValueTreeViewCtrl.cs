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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UnifiedAutomation.UaBase;

namespace UnifiedAutomation.ClientGettingStarted
{
    /// <summary>
    /// UserControl that can show a GenericEncodeableObject readonly in a treeview
    /// </summary>
    public partial class ShowStructuredValueTreeViewCtrl : UserControl
    {
        /// <summary>
        /// Creates the control.
        /// </summary>
        public ShowStructuredValueTreeViewCtrl()
        {
            InitializeComponent();
        }

        #region Public Interface
        /// <summary>
        /// Adds the value to the tree view
        /// </summary>
        /// <param name="value"></param>
        public void SetEncodeable(GenericEncodeableObject value)
        {
            treeView.BeginUpdate();
            treeView.Nodes.Clear();
            TreeNode root = new TreeNode(value.TypeDefinition.Name.Name);
            root.Tag = new TreeNodeData()
            {
                DataType = value.TypeDefinition,
                ValueRank = -1
            };
            if (!(value.TypeDefinition is GenericUnionDataType))
            {
                ExpandTree(root, value);
            }
            else
            {
                AddUnionNodeContent(root, value);
            }
            treeView.Nodes.Add(root);
            treeView.EndUpdate();
        }
        #endregion

        #region Private Helpers

        private void ExpandTree(TreeNode currentNode, GenericEncodeableObject currentValue)
        {
            GenericStructureDataType structuredDataType = currentValue.TypeDefinition;
            for (int i = 0; i < structuredDataType.Count; i++)
            {
                if (i == 0 && structuredDataType is GenericOptionalFieldListDataType)
                {
                    //do not show encoding mask
                    continue;
                }

                GenericStructureDataTypeField field = structuredDataType[i];

                Variant childValue = currentValue[i];
                AddChildValue(currentNode, structuredDataType, field, childValue);
            }
        }

        private void AddUnionNodeContent(TreeNode currentNode, GenericEncodeableObject union)
        {
            GenericUnionDataType unionDataType = union.TypeDefinition as GenericUnionDataType;
            string currentFieldName;
            if (unionDataType.TryGetSwitchField(union.SwitchValue, out currentFieldName))
            {
                Variant currentValue = union[currentFieldName];
                AddChildValue(currentNode, union.TypeDefinition, unionDataType[currentFieldName], currentValue);
            }
            else if (union.SwitchValue == 0)
            {
                currentNode.Text += ": (null)";
            }
        }

        private string EnumString(GenericEnumeratedDataType dataType, int value)
        {
            string ret;
            dataType.TryGetValue(value, out ret);
            return ret;
        }

        private bool IsOptional(GenericStructureDataType dataType, GenericStructureDataTypeField field)
        {
            GenericOptionalFieldListDataType optionalFieldList = dataType as GenericOptionalFieldListDataType;
            if (optionalFieldList != null)
            {
                return optionalFieldList.IsFieldOptional(field.Name);
            }
            return false;
        }

        private void AddChildValue(TreeNode currentNode, GenericStructureDataType structuredDataType, GenericStructureDataTypeField field, Variant childValue)
        {
            string childName = field.Name;
            string dataTypeName = field.TypeDescription.Name.Name;
            string isOptional = IsOptional(structuredDataType, field) ? ", optional" : "";

            if (field.ValueRank == -1)
            {
                childName += "[" + dataTypeName + isOptional + "]";
                TreeNode node = new TreeNode(childName);
                node.Tag = new TreeNodeData()
                {
                    DataType = field.TypeDescription,
                    ValueRank = field.ValueRank,
                    IsOptional = IsOptional(structuredDataType, field)
                };
                currentNode.Nodes.Add(node);

                if (childValue.IsNull)
                {
                    node.Text += ": (null)";
                    return;
                }

                switch (field.TypeDescription.TypeClass)
                {
                    case GenericDataTypeClass.Structured:
                    case GenericDataTypeClass.OptionalField:
                        ExpandTree(node, (GenericEncodeableObject)childValue.GetValue<GenericEncodeableObject>(null));
                        break;
                    case GenericDataTypeClass.Union:
                        AddUnionNodeContent(node, (GenericEncodeableObject)childValue.GetValue<GenericEncodeableObject>(null));
                        break;
                    case GenericDataTypeClass.Simple:
                        node.Text = node.Text + ": " + childValue;
                        break;
                    case GenericDataTypeClass.Enumerated:
                    case GenericDataTypeClass.OptionSet:
                        node.Text = node.Text + ": " + EnumString((GenericEnumeratedDataType)field.TypeDescription, childValue.ToInt32());
                        break;
                }
            }
            else if (field.ValueRank == 1)
            {
                childName += "[ArrayOf" + dataTypeName + isOptional + "]";
                TreeNode node;
                node = new TreeNode(childName);
                node.Tag = new TreeNodeData()
                {
                    DataType = field.TypeDescription,
                    ValueRank = field.ValueRank
                };
                currentNode.Nodes.Add(node);
                if (childValue.Value == null)
                {
                    node.Text += ": (null)";
                    return;
                }

                TreeNodeData dataArrayElement = new TreeNodeData()
                {
                    ValueRank = -1,
                    DataType = field.TypeDescription
                };
                int counter = 0;
                switch (field.TypeDescription.TypeClass)
                {
                    case GenericDataTypeClass.Structured:
                    case GenericDataTypeClass.OptionalField:
                        {
                            ExtensionObjectCollection extensionObjects = childValue.ToExtensionObjectArray();
                            foreach (ExtensionObject e in extensionObjects)
                            {
                                TreeNode arrayChild = new TreeNode(dataTypeName + " [" + counter++ + "]");
                                arrayChild.Tag = dataArrayElement;
                                node.Nodes.Add(arrayChild);
                                ExpandTree(arrayChild, (GenericEncodeableObject)e.Body);
                            }
                        }
                        break;
                    case GenericDataTypeClass.Union:
                        {
                            ExtensionObjectCollection extensionObjects = childValue.ToExtensionObjectArray();
                            foreach (ExtensionObject e in extensionObjects)
                            {
                                TreeNode arrayChild = new TreeNode(dataTypeName + " [" + counter++ + "]");
                                arrayChild.Tag = dataArrayElement;
                                node.Nodes.Add(arrayChild);
                                AddUnionNodeContent(arrayChild, (GenericEncodeableObject)e.Body);
                            }
                        }
                        break;
                    case GenericDataTypeClass.Simple:
                        {
                            Array array = childValue.Value as Array;
                            foreach (object element in array)
                            {
                                TreeNode arrayChild = new TreeNode(dataTypeName + " [" + counter++ + "]" + ": " + element.ToString());
                                arrayChild.Tag = dataArrayElement;
                                node.Nodes.Add(arrayChild);
                            }
                        }
                        break;
                    case GenericDataTypeClass.Enumerated:
                    case GenericDataTypeClass.OptionSet:
                        {
                            int[] values = childValue.ToInt32Array();
                            foreach (int element in values)
                            {
                                TreeNode arrayChild = new TreeNode(dataTypeName + " [" + counter++ + "]" + ": " + EnumString((GenericEnumeratedDataType)field.TypeDescription, element));
                                arrayChild.Tag = dataArrayElement;
                                node.Nodes.Add(arrayChild);
                            }
                        }
                        break;
                }
            }
        }

        #endregion

        private class TreeNodeData
        {
            public GenericDataType DataType { get; set; }
            public int ValueRank { get; set; }
            public bool IsOptional { get; set; }
        }
    }
}
