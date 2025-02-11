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
    public partial class ReadStructureDlg : Form
    {
        
        /// <summary>
        /// Processes the results.
        /// </summary>
        /// <param name="results">The results.</param>
        private void ProcessResults(List<DataValue> results)
        {
            // display the value in the form.
            if (results.Count > 0)
            {
                /// [Extract Extension Object]
                DataValue dv = results[0];
                Variant value = dv.WrappedValue;

                // Only ExtensionObjects are allowed for this example
                if (value.DataType != BuiltInType.ExtensionObject || value.ValueRank != ValueRanks.Scalar)
                {
                    throw new Exception("Only scalar values of structured DataTypes can be displayed in this example");
                }
                ExtensionObject e = value.ToExtensionObject();

                if (e.Encoding == ExtensionObjectEncoding.EncodeableObject)
                {
                    throw new Exception("Only values of structured DataTypes that are not registered at the stack can be shown in this example.");
                }

                // The DataManager parses the encoded data
                GenericEncodeableObject encodeable = m_dataTypeManager.ParseValue(e);
                /// [Extract Extension Object]

                // In this example there are two ways described to show the parsed value.
                // The first option is to print the data as text. This example only deals with
                // simple data types and structured data types to be clearly.
                PrintValue(encodeable);

                // The second option is to add the value to a tree view. This example is more complicated
                // and also deals with unions, enumerations and structures with optional fields.
                m_editControl.SetEncodeable(encodeable);
            }
        }

        /// [Recursive Method 1]
        private void PrintValue(GenericEncodeableObject genericValue)
        {
            m_text.Text = "";
            // Extract the data type description
            GenericStructureDataType structuredDataType = genericValue.TypeDefinition;
            // We have a structure, process structure elements
            if (structuredDataType.TypeClass == GenericDataTypeClass.Structured)
            {
                m_text.Text = structuredDataType.Name.Name;

                // Use a recursive method, because structures can be nested.
                PrintValueRec(genericValue, 1);
            }
        }

        private void PrintValueRec(GenericEncodeableObject genericValue, int depth)
        {
            /// [Recursive Method 1]
            /// [Recursive Method 2]
            GenericStructureDataType structuredDataType = genericValue.TypeDefinition;
            /// [Recursive Method 2]

            // get indentation for layout
            string intend = "";
            /// [Recursive Method 3]
            for (int i = 0; i < depth; i++)
            {
                intend += "  ";
            }
            for (int i = 0; i < structuredDataType.Count; i++)
            {
                // Get the description of the field (name, data type etc.)
                GenericStructureDataTypeField fieldDescription = structuredDataType[i];
                // Get the value of the field
                Variant fieldValue = genericValue[i];

                string fieldName = fieldDescription.Name;
                /// [Recursive Method 3]
                // In this example we take care about simple types and structures, each scalar and array.
                /// [Recursive Method 4]
                if (fieldDescription.ValueRank == -1)
                {
                    if (fieldDescription.TypeDescription.TypeClass == GenericDataTypeClass.Simple)
                    {
                        // Print the name and the value
                        string fieldValueString = fieldValue.ToString();
                        string outputString = "\r\n" + intend + fieldName + " = " + fieldValueString;
                        m_text.Text = m_text.Text += outputString;
                    }
                    else if (fieldDescription.TypeDescription.TypeClass == GenericDataTypeClass.Structured)
                    {
                        // Print the name and call this method again the child
                        string outputString = "\r\n" + intend + fieldName;
                        m_text.Text = m_text.Text += outputString;
                        PrintValueRec((GenericEncodeableObject)fieldValue.GetValue<GenericEncodeableObject>(null), depth + 1);
                    }
                }
                else if (fieldDescription.ValueRank == 1)
                {
                    // Print the fields name
                    string outputString = "\r\n" + intend + fieldName;
                    m_text.Text = m_text.Text += outputString;
                    if (fieldDescription.TypeDescription.TypeClass == GenericDataTypeClass.Simple)
                    {
                        // Print each element
                        Array array = fieldValue.Value as Array;
                        int counter = 0;
                        foreach (object element in array)
                        {
                            outputString = "\r\n" + intend + "  " + fieldDescription.TypeDescription.Name.Name + "[" + counter++ + "]: " + element.ToString();
                            m_text.Text = m_text.Text += outputString;
                        }
                    }
                    else if (fieldDescription.TypeDescription.TypeClass == GenericDataTypeClass.Structured)
                    {
                        // Call this method again for each element
                        ExtensionObjectCollection extensionObjects = fieldValue.ToExtensionObjectArray();
                        int counter = 0;
                        foreach (ExtensionObject e in extensionObjects)
                        {
                            outputString = "\r\n" + intend + "  " + fieldDescription.TypeDescription.Name.Name + "[" + counter++ + "]";
                            m_text.Text = m_text.Text += outputString;
                            PrintValueRec((GenericEncodeableObject)e.Body, depth + 2);
                        }
                    }
                }
                /// [Recursive Method 4]
            }
        }

        #region Private Fields
        private DataTypeManager m_dataTypeManager;
        private ShowStructuredValueTreeViewCtrl m_editControl;
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
            /// [Create Instance of DataTypeManager]
            m_dataTypeManager = new DataTypeManager(m_parent.Session);
            /// [Create Instance of DataTypeManager]
            m_editControl = new ShowStructuredValueTreeViewCtrl();
            m_editControl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            m_editControl.Size = TabTreeView.Size;
            TabTreeView.Controls.Add(m_editControl);
            m_text = new TextBox();
            m_text.Multiline = true;
            m_text.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            m_text.Size = TabTreeView.Size;
            TabText.Controls.Add(m_text);
            Show();
        }
        #endregion
    }
}
