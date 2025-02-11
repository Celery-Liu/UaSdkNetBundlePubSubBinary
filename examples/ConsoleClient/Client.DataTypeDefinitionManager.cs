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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;

namespace ConsoleClient
{
    partial class Client
    {
        #region Properties
        DataTypeDefinitionManager m_dataTypeDefinitionManager;
        DataTypeDefinitionManager DataTypeDefinitionManager
        {
            get
            {
                if (m_dataTypeDefinitionManager == null)
                {
                    m_dataTypeDefinitionManager = new DataTypeDefinitionManager(Session);
                }
                return m_dataTypeDefinitionManager;
            }
        }
        #endregion

        #region Write Structure
        ClientState WriteStructure()
        {
            return WriteStructureAsync().Result;
        }

        async Task<ClientState> WriteStructureAsync()
        {
            NodeId structureId = Settings.StructureToWriteId;

            //read structure type
            List<DataValue> results = null;
            try
            {
                //! [Read data type information]
                IList<ReadValueId> nodesToRead = new List<ReadValueId>
                {
                    new ReadValueId()
                    {
                        NodeId = structureId,
                        AttributeId = Attributes.DataType
                    }
                };
                results = await Session.ReadAsync(nodesToRead, 0).ConfigureAwait(false);
                //! [Read data type information]
                Output("\nWriteStructure - Read of data type succeeded");
            }
            catch (Exception e)
            {
                Output($"\nWriteStructure - Read of data type failed {e.Message}");
            }

            try
            {
                //! [Get StructureDefinition]
                NodeId dataTypeId = (NodeId)results[0].Value;
                GenericStructuredDataTypeDefinition definition = await DataTypeDefinitionManager.GetStructureDefinitionFromDataTypeIdAsync(dataTypeId).ConfigureAwait(false);
                //! [Get StructureDefinition]

                //! [write structure]
                //Create encodeable object
                var geo = DefaultStructure(definition);

                IList<WriteValue> nodesToWrite = new List<WriteValue>
                {
                    new WriteValue()
                    {
                        NodeId = structureId,
                        Value = new DataValue() { WrappedValue = geo },
                        AttributeId = Attributes.Value
                    }
                };
                List<StatusCode> res = await Session.WriteAsync(nodesToWrite).ConfigureAwait(false);
                //! [write structure]

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

        //! [Default Structure]
        GenericEncodeableStructure DefaultStructure(GenericStructuredDataTypeDefinition definition)
        {
            var geo = new GenericEncodeableStructure(definition);

            for (int i = 0; i < definition.Fields.Count; i++)
            {
                var field = definition.Fields[i];

                if (field.ValueRank == ValueRanks.Scalar)
                {
                    switch (field.BuiltInType)
                    {
                        case BuiltInType.ExtensionObject:
                            if (field.DataType is GenericStructuredDataTypeDefinition structure)
                            {
                                geo[i] = DefaultStructure(structure);
                            }
                            break;
                        case BuiltInType.Enumeration:
                            if (field.DataType is GenericEnumerationDataTypeDefinition enumeration)
                            {
                                geo[i] = new Variant(enumeration.Fields[0].Value);
                            }
                            break;
                        case BuiltInType.String:
                            geo[i] = new Variant("Generic Name");
                            break;
                        case BuiltInType.UInt16:
                            geo[i] = new Variant((UInt16)123);
                            break;
                        case BuiltInType.Float:
                            geo[i] = new Variant(13.37f);
                            break;
                        case BuiltInType.Guid:
                            geo[i] = new Variant(Uuid.NewUuid());
                            break;
                        case BuiltInType.DateTime:
                            geo[i] = new Variant(DateTime.UtcNow);
                            break;
                        case BuiltInType.LocalizedText:
                            geo[i] = new Variant(new LocalizedText("A description"));
                            break;
                    }
                }
                else if (field.ValueRank == ValueRanks.OneDimension)
                {
                    switch (field.BuiltInType)
                    {
                        case BuiltInType.ExtensionObject:
                            if (field.DataType is GenericStructuredDataTypeDefinition structure)
                            {
                                ExtensionObjectCollection eos = new ExtensionObjectCollection()
                                    {
                                        new ExtensionObject(DefaultStructure(structure)),
                                        new ExtensionObject(DefaultStructure(structure)),
                                        new ExtensionObject(DefaultStructure(structure)),
                                        new ExtensionObject(DefaultStructure(structure)),
                                    };
                                geo[i] = new Variant(eos);
                            }
                            break;
                    }
                }


            }

            return geo;
        }
        //! [Default Structure]
        #endregion

        #region Display values
        void PrintReadResults(IList<DataValue> values, IList<ReadValueId> nodes)
        {
            var task = PrintReadResultsAsync(values, nodes);
            task.Wait();
        }

        async Task PrintReadResultsAsync(IList<DataValue> values, IList<ReadValueId> nodes)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < values.Count; i++)
            {
                Variant value = values[i].WrappedValue;
                if (value.DataType != BuiltInType.ExtensionObject)
                {
                    builder.AppendLine($"[{i}] {nodes[i].NodeId}: {values[i]}");
                }
                else
                {
                    ExtensionObject e = value.ToExtensionObject();
                    if (e.Encoding != ExtensionObjectEncoding.EncodeableObject)
                    {
                        var encodeable = await DataTypeDefinitionManager.ParseValueAsync(e).ConfigureAwait(false);
                        if (encodeable is GenericEncodeableStructure structure)
                        {
                            string resultText = StructureToString(structure);
                            builder.AppendLine($"\n{resultText}");
                        }
                    }
                    else
                    {
                        builder.AppendLine($"\n{e}");
                    }
                }
            }

            lock (ConsoleLock)
            {
                Console.WriteLine(builder.ToString());
            }
        }

        /// [Recursive Method 1]
        static string StructureToString(GenericEncodeableStructure genericValue)
        {
            // Extract the data type description
            GenericStructuredDataTypeDefinition structuredDataType = genericValue.DataType;

            string result = structuredDataType.Name;
            ValueToStringRec(genericValue, 1, ref result);
            return result;
        }

        static void ValueToStringRec(GenericEncodeableStructure genericValue, int depth, ref string result)
        {
            /// [Recursive Method 1]

            // get indentation for layout
            string intend = "";
            /// [Recursive Method 3]
            for (int i = 0; i < depth; i++)
            {
                intend += "  ";
            }
            foreach (var field in genericValue)
            {
                // Get the description of the field (name, data type etc.)
                var fieldDescription = field.Key;
                // Get the value of the field
                Variant fieldValue = field.Value;

                string fieldName = fieldDescription.Name;
                /// [Recursive Method 3]
                // In this example we take care about simple types and structures, each scalar and array.
                /// [Recursive Method 4]
                if (fieldDescription.ValueRank == -1)
                {
                    if (fieldDescription.BuiltInType == BuiltInType.Enumeration
                        && fieldDescription.DataType is GenericEnumerationDataTypeDefinition enumeration)
                    {
                        result += $"\r\n{intend}{fieldName} = {fieldValue.ToInt32()}";
                        if (enumeration.TryGetName(fieldValue.ToInt32(), out string name))
                        {
                            result += $" ({name})";
                        }
                    }
                    else if (fieldDescription.DataType is GenericOptionSetDataTypeDefinition optionSet)
                    {
                        IList<string> names = null;
                        switch (optionSet.BuiltInType)
                        {
                            case BuiltInType.Byte:
                                result += $"\r\n{intend}{fieldName} = {fieldValue.ToByte()}";
                                names = optionSet.GetNames(fieldValue.ToByte());
                                break;
                            case BuiltInType.UInt16:
                                result += $"\r\n{intend}{fieldName} = {fieldValue.ToUInt16()}";
                                names = optionSet.GetNames(fieldValue.ToUInt16());
                                break;
                            case BuiltInType.UInt32:
                                result += $"\r\n{intend}{fieldName} = {fieldValue.ToUInt32()}";
                                names = optionSet.GetNames(fieldValue.ToUInt32());
                                break;
                            case BuiltInType.UInt64:
                                result += $"\r\n{intend}{fieldName} = {fieldValue.ToUInt64()}";
                                names = optionSet.GetNames(fieldValue.ToUInt64());
                                break;
                            case BuiltInType.ExtensionObject:
                                var optionSetValue = ExtensionObject.GetObject<OptionSet>(fieldValue.ToExtensionObject());
                                result += $"\r\n{intend}{fieldName} = { BitConverter.ToString(optionSetValue.Value) }";
                                names = optionSet.GetNames(optionSetValue.Value);
                                break;
                        }
                        if (names.Count == 0)
                        {
                            result += " (None)";
                        }
                        else
                        {
                            result += $" ({string.Join(" | ", names)})";
                        }
                    }
                    else if (fieldDescription.BuiltInType == BuiltInType.ExtensionObject
                        && fieldDescription.DataType is GenericStructuredDataTypeDefinition)
                    {
                        // Print the name and call this method again the child
                        result += $"\r\n{intend}{fieldName}";
                        ValueToStringRec(fieldValue.GetValue<GenericEncodeableStructure>(null), depth + 1, ref result);
                    }
                    else
                    {
                        // Print the name and the value
                        result += $"\r\n{intend}{fieldName} = {fieldValue}";
                    }
                }
                else if (fieldDescription.ValueRank == 1)
                {
                    // Print the fields name
                    result += $"\r\n{intend}{fieldName}";

                    if (fieldDescription.DataType is GenericStructuredDataTypeDefinition)
                    {
                        // Call this method again for each element
                        ExtensionObjectCollection extensionObjects = fieldValue.ToExtensionObjectArray();
                        intend += "  ";
                        int counter = 0;
                        foreach (ExtensionObject e in extensionObjects)
                        {
                            result += $"\r\n{intend}{fieldDescription.DataType.Name}[{counter++}]";
                            ValueToStringRec((GenericEncodeableStructure)e.Body, depth + 2, ref result);
                        }
                    }
                    else
                    {
                        // Print each element
                        Array array = fieldValue.Value as Array;
                        intend += "  ";
                        int counter = 0;
                        foreach (object arrayElement in array)
                        {
                            result += $"\r\n{intend}{fieldDescription.DataType.Name}[{counter++}]: {arrayElement}";
                        }
                    }
                }
                /// [Recursive Method 4]
            }
        }
        #endregion
    }
}
