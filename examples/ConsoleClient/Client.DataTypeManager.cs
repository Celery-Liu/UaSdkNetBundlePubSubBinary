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

using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;

namespace ConsoleClient
{
    partial class Client
    {
        #region Properties
        DataTypeManager m_dataTypeManager;
        DataTypeManager DataTypeManager
        {
            get
            {
                if (m_dataTypeManager == null)
                {
                    m_dataTypeManager = new DataTypeManager(Session);
                }
                return m_dataTypeManager;
            }
        }
        #endregion

        #region Write Structure
        ClientState WriteStructure()
        {
            NodeId structureId = Settings.StructureToWriteId;

            //read structure type
            List<DataValue> results = null;
            try
            {
                IList<ReadValueId> nodesToRead = new List<ReadValueId>
                {
                    new ReadValueId()
                    {
                        NodeId = structureId,
                        AttributeId = Attributes.DataType
                    }
                };
                results = Session.Read(nodesToRead);
                Output("\nWriteStructure - Read of data type succeeded");
            }
            catch (Exception e)
            {
                Output($"\nWriteStructure - Read of data type failed {e.Message}");
            }

            try
            {
                NodeId datatypeId = (NodeId)results[0].Value;
                ExpandedNodeId eNodeId = new ExpandedNodeId(datatypeId.IdType, datatypeId.Identifier, Session.NamespaceUris[datatypeId.NamespaceIndex], datatypeId.NamespaceIndex);
                GenericStructureDataType newType = DataTypeManager.NewTypeFromDataType(eNodeId, BrowseNames.DefaultBinary, true);

                //Create encodeable object
                var geo = new GenericEncodeableObject(newType);

                //set fields of encodeable object
                for (int i = 0; i < newType.Fields.Count; ++i)
                {
                    if (newType[i].TypeDescription.TypeClass == GenericDataTypeClass.Structured)
                    {
                        var subGeo = new GenericEncodeableObject(newType[i].TypeDescription);
                    }
                    if (geo[i].TypeInfo == TypeInfo.Scalars.String)
                    {
                        geo[i] = new Variant("Generic Person name");
                    }
                    else if (geo[i].TypeInfo == TypeInfo.Scalars.UInt16)
                    {
                        geo[i] = new Variant((UInt16)123);
                    }
                    else if (geo[i].TypeInfo == TypeInfo.Scalars.Float)
                    {
                        geo[i] = new Variant(13.37f);
                    }
                }

                IList<WriteValue> nodesToWrite = new List<WriteValue>
                {
                    new WriteValue()
                    {
                        NodeId = structureId,
                        Value = new DataValue() { WrappedValue = geo },
                        AttributeId = Attributes.Value
                    }
                };
                List<StatusCode> res = Session.Write(nodesToWrite);

                lock (ConsoleLock)
                {
                    Console.WriteLine("\nWriteStructure succeeded");
                    foreach (StatusCode status in res)
                    {
                        Console.WriteLine($"\nWrite result {status}");
                    }
                }
            }
            catch (Exception e)
            {
                Output($"\nWriteStructure failed with message {e.Message}");
            }

            return ClientState.Connected;
        }
        #endregion

        #region Display values
        void PrintReadResults(IList<DataValue> values, IList<ReadValueId> nodes)
        {
            lock (ConsoleLock)
            {
                for (int i = 0; i < values.Count; i++)
                {
                    Variant value = values[i].WrappedValue;
                    if (value.DataType != BuiltInType.ExtensionObject)
                    {
                        Console.WriteLine($"[{i}] {nodes[i].NodeId}: {values[i]}");
                    }
                    else
                    {
                        ExtensionObject e = value.ToExtensionObject();
                        if (e.Encoding != ExtensionObjectEncoding.EncodeableObject)
                        {
                            GenericEncodeableObject encodeable = DataTypeManager.ParseValue(e);
                            string resultText = ValueToString(encodeable);
                            Console.WriteLine($"\n{resultText}");
                        }
                        else
                        {
                            Console.WriteLine($"\n{e}");
                        }
                    }
                }
            }
        }

        static string ValueToString(GenericEncodeableObject genericValue)
        {
            string result = "";
            // Extract the data type description
            GenericStructureDataType structuredDataType = genericValue.TypeDefinition;
            // We have a structure, process structure elements
            if (structuredDataType.TypeClass == GenericDataTypeClass.Structured)
            {
                result = structuredDataType.Name.Name;

                // Use a recursive method, because structures can be nested.
                ValueToStringRec(genericValue, 1, ref result);
            }
            return result;
        }

        static void ValueToStringRec(GenericEncodeableObject genericValue, int depth, ref string result)
        {
            GenericStructureDataType structuredDataType = genericValue.TypeDefinition;

            // get indentation for layout
            string intend = "";
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
                // In this example we take care about simple types and structures, each scalar and array.
                if (fieldDescription.ValueRank == -1)
                {
                    if (fieldDescription.TypeDescription.TypeClass == GenericDataTypeClass.Simple)
                    {
                        // Print the name and the value
                        result += $"\r\n{intend}{fieldName} = {fieldValue}";
                    }
                    else if (fieldDescription.TypeDescription.TypeClass == GenericDataTypeClass.Structured)
                    {
                        // Print the name and call this method again the child
                        result += $"\r\n{intend}{fieldName}";
                        ValueToStringRec((GenericEncodeableObject)fieldValue.GetValue<GenericEncodeableObject>(null), depth + 1, ref result);
                    }
                }
                else if (fieldDescription.ValueRank == 1)
                {
                    // Print the fields name
                    result += $"\r\n{intend}{fieldName}";
                    if (fieldDescription.TypeDescription.TypeClass == GenericDataTypeClass.Simple)
                    {
                        // Print each element
                        Array array = fieldValue.Value as Array;
                        intend += "  ";
                        int counter = 0;
                        foreach (object element in array)
                        {
                            result += $"\r\n{intend}{fieldDescription.TypeDescription.Name.Name}[{counter++}]: {element}";
                        }
                    }
                    else if (fieldDescription.TypeDescription.TypeClass == GenericDataTypeClass.Structured)
                    {
                        // Call this method again for each element
                        ExtensionObjectCollection extensionObjects = fieldValue.ToExtensionObjectArray();
                        intend += "  ";
                        int counter = 0;
                        foreach (ExtensionObject e in extensionObjects)
                        {
                            result += $"\r\n{intend}{fieldDescription.TypeDescription.Name.Name}[{counter++}]";
                            ValueToStringRec((GenericEncodeableObject)e.Body, depth + 2, ref result);
                        }
                    }
                }
            }
        }
        #endregion
    }
}
