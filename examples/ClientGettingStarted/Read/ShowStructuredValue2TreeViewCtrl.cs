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
using System.Windows.Forms;
using UnifiedAutomation.UaBase;

namespace UnifiedAutomation.ClientGettingStarted
{
    /// <summary>
    /// UserControl that can show a BaseGenericEncodeableObject readonly in a treeview
    /// </summary>
    public partial class ShowStructuredValue2TreeViewCtrl : UserControl
    {
        /// <summary>
        /// Creates the control.
        /// </summary>
        public ShowStructuredValue2TreeViewCtrl()
        {
            InitializeComponent();
        }

        #region Public Interface
        /// <summary>
        /// Adds the value to the tree view
        /// </summary>
        /// <param name="value"></param>
        public void SetEncodeable(BaseGenericEncodeableObject value)
        {
            treeView.BeginUpdate();
            treeView.Nodes.Clear();
            TreeNode root = new TreeNode(value.DataType.Name)
            {
                Tag = new TreeNodeData()
                {
                    DataType = value.DataType,
                }
            };

            if (value is GenericEncodeableStructure structure)
            {
                ExpandTree(root, structure);
            }
            else
            {
                AddUnionNodeContent(root, value as GenericEncodeableUnion);
            }

            treeView.Nodes.Add(root);
            treeView.EndUpdate();
        }
        #endregion

        #region Private Helpers

        private void ExpandTree(TreeNode currentNode, GenericEncodeableStructure currentValue)
        {
            GenericStructuredDataTypeDefinition structuredDataType = currentValue.DataType;
            for (int i = 0; i < structuredDataType.Fields.Count; i++)
            {
                var field = structuredDataType.Fields[i];
                Variant childValue = currentValue[i];
                AddChildValue(currentNode, structuredDataType, field, childValue);
            }
        }

        private void AddUnionNodeContent(TreeNode currentNode, GenericEncodeableUnion union)
        {
            var unionDataType = union.DataType;
            if (union.SwitchField == 0)
            {
                currentNode.Text += ": (null)";
            }
            else
            {
                AddChildValue(currentNode, union.DataType, unionDataType.Fields[(int)union.SwitchField - 1], union.Value);
            }
        }

        private string EnumString(GenericEnumerationDataTypeDefinition dataType, int value)
        {
            dataType.TryGetName(value, out string ret);
            return ret;
        }

        private string OptionSetValues(IList<string> names)
        {
            if (names.Count == 0)
            {
                return "(None)";
            }
            return $"({string.Join(" | ", names)})";
        }

        private string OptionSetValues(GenericOptionSetDataTypeDefinition dataType, Variant value)
        {
            return OptionSetValues(dataType.GetNames(value));
        }

        private void AddChildValue(TreeNode currentNode, GenericStructuredDataTypeDefinition structuredDataType, GenericStructureField field, Variant childValue)
        {
            string childName = field.Name;
            string dataTypeName = field.DataType.Name;
            string isOptional = field.IsOptional ? ", optional" : "";

            if (field.ValueRank == ValueRanks.Scalar)
            {
                childName += $"[{dataTypeName}{isOptional}]";
                TreeNode node = new TreeNode(childName);
                node.Tag = new TreeNodeData()
                {
                    DataType = field.DataType,
                    ValueRank = field.ValueRank,
                    IsOptional = field.IsOptional
                };
                currentNode.Nodes.Add(node);

                if (childValue.IsNull)
                {
                    node.Text += ": (null)";
                    return;
                }

                if (field.DataType is GenericStructuredDataTypeDefinition structure)
                {
                    switch (structure.StructureType)
                    {
                        case StructureType.Structure:
                        case StructureType.StructureWithSubtypedValues:
                        case StructureType.StructureWithOptionalFields:
                            ExpandTree(node, childValue.GetValue<GenericEncodeableStructure>(null));
                            break;
                        case StructureType.Union:
                        case StructureType.UnionWithSubtypedValues:
                            AddUnionNodeContent(node, childValue.GetValue<GenericEncodeableUnion>(null));
                            break;
                    }
                }
                else if (field.DataType is GenericSimpleDataTypeDefinition)
                {
                    node.Text = $"{node.Text}: {childValue}";
                }
                else if (field.DataType is GenericEnumerationDataTypeDefinition enumeration)
                {
                    node.Text = $"{node.Text}: {EnumString(enumeration, childValue.ToInt32())}";
                }
                else if (field.DataType is GenericOptionSetDataTypeDefinition optionSet)
                {
                    node.Text = $"{node.Text}: {OptionSetValues(optionSet, childValue)}";
                }
            }
            else if (field.ValueRank == ValueRanks.OneDimension)
            {
                childName += $"[ArrayOf{dataTypeName}{isOptional}]";
                TreeNode node;
                node = new TreeNode(childName);
                node.Tag = new TreeNodeData()
                {
                    DataType = field.DataType,
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
                    DataType = field.DataType
                };
                int counter = 0;

                if (field.DataType is GenericStructuredDataTypeDefinition structure)
                {
                    ExtensionObjectCollection extensionObjects = childValue.ToExtensionObjectArray();
                    switch (structure.StructureType)
                    {
                        case StructureType.Structure:
                        case StructureType.StructureWithSubtypedValues:
                        case StructureType.StructureWithOptionalFields:
                            foreach (ExtensionObject e in extensionObjects)
                            {
                                TreeNode arrayChild = new TreeNode($"{dataTypeName} [{counter++}]");
                                arrayChild.Tag = dataArrayElement;
                                node.Nodes.Add(arrayChild);
                                ExpandTree(arrayChild, (GenericEncodeableStructure)e.Body);
                            }
                            break;
                        case StructureType.Union:
                        case StructureType.UnionWithSubtypedValues:
                            foreach (ExtensionObject e in extensionObjects)
                            {
                                TreeNode arrayChild = new TreeNode($"{dataTypeName} [{counter++}]");
                                arrayChild.Tag = dataArrayElement;
                                node.Nodes.Add(arrayChild);
                                AddUnionNodeContent(arrayChild, (GenericEncodeableUnion)e.Body);
                            }
                            break;
                    }
                }
                else if (field.DataType is GenericSimpleDataTypeDefinition)
                {
                    Array array = childValue.Value as Array;
                    foreach (object element in array)
                    {
                        TreeNode arrayChild = new TreeNode($"{dataTypeName} [{counter++}]: {element}");
                        arrayChild.Tag = dataArrayElement;
                        node.Nodes.Add(arrayChild);
                    }
                }
                else if (field.DataType is GenericEnumerationDataTypeDefinition enumeration)
                {
                    int[] values = childValue.ToInt32Array();
                    foreach (int element in values)
                    {
                        TreeNode arrayChild = new TreeNode($"{dataTypeName} [{counter++}]: {EnumString(enumeration, element)}");
                        arrayChild.Tag = dataArrayElement;
                        node.Nodes.Add(arrayChild);
                    }
                }
                else if (field.DataType is GenericOptionSetDataTypeDefinition optionSet)
                {
                    var namesList = optionSet.GetListOfNames(childValue);
                    foreach (var optionSetValues in namesList)
                    {
                        TreeNode arrayChild = new TreeNode($"{dataTypeName} [{counter++}]: {OptionSetValues(optionSetValues)}");
                        arrayChild.Tag = dataArrayElement;
                        node.Nodes.Add(arrayChild);
                    }
                }
            }
        }

        #endregion

        private class TreeNodeData
        {
            public GenericDataTypeDefinition DataType { get; set; }
            public int ValueRank { get; set; } = ValueRanks.Scalar;
            public bool IsOptional { get; set; }
        }
    }
}
