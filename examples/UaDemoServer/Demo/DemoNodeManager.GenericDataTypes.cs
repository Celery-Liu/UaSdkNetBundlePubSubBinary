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
using System.Data;
using System.Threading;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaServer;

namespace UnifiedAutomation.Demo
{
    internal partial class DemoNodeManager : BaseNodeManager
    {
        static class GenericStructureIdentifiers
        {
            // Identifiers for DataType and Encoding nodes. Using numeric NodeIds in this example.
            // For some use cases it is required to use string NodeIds. This is also possible but less
            // efficient.
            public const uint PersonDataTypeId = 543210;
            public const uint PersonBinaryEncodingId = 543211;
            public const uint PersonXmlEncodingId = 543212;
            public const uint GenderDataTypeId = 543220;
        }

        void SetupGenericDataTypeNodes()
        {
            var stringDefinition = GetGenericDataTypeDefinition(Server.DefaultRequestContext, DataTypeIds.String);
            var uint16Definition = GetGenericDataTypeDefinition(Server.DefaultRequestContext, DataTypeIds.UInt16);
            var floatDefinition = GetGenericDataTypeDefinition(Server.DefaultRequestContext, DataTypeIds.Float);

            var enumDefinition = new GenericEnumerationDataTypeDefinitionSettings()
            {
                DataTypeId = new NodeId(GenericStructureIdentifiers.GenderDataTypeId, DefaultNamespaceIndex),
                Name = "Gender",
            };
            enumDefinition.AddField(new GenericEnumerationField("Male", 0));
            enumDefinition.AddField(new GenericEnumerationField("Female", 1));
            enumDefinition.AddField(new GenericEnumerationField("Diverse", 2));

            CreateGenericEnumeration(Server.DefaultRequestContext, enumDefinition);

            var structureDefinition = new GenericStructuredDataTypeDefinitionSettings()
            {
                Name = "Person",
                DataTypeId = new NodeId(GenericStructureIdentifiers.PersonDataTypeId, DefaultNamespaceIndex),
                BinaryEncodingId = new NodeId(GenericStructureIdentifiers.PersonBinaryEncodingId, DefaultNamespaceIndex),
                XmlEncodingId = new NodeId(GenericStructureIdentifiers.PersonXmlEncodingId, DefaultNamespaceIndex),
            };
            structureDefinition.AddField(new GenericStructureField(stringDefinition, "Name"));
            structureDefinition.AddField(new GenericStructureField(uint16Definition, "Height"));
            structureDefinition.AddField(new GenericStructureField(floatDefinition, "Weight"));
            structureDefinition.AddField(new GenericStructureField(enumDefinition, "Gender"));

            CreateGenericStructure(Server.DefaultRequestContext, structureDefinition);

            // Register the structured DataType. Decoder will automatically decode values to GenericEncodeableStructure.
            Server.MessageContext.Factory.AddDataTypeDefinition(structureDefinition, Server.NamespaceUris);
        }

        void CreateGenericDataTypeVariable(string name, GenericEncodeableStructure encodeable)
        {
            var settings = new CreateVariableSettings()
            {
                RequestedNodeId = new NodeId(name, DefaultNamespaceIndex),
                BrowseName = new QualifiedName(name, DefaultNamespaceIndex),
                Description = new LocalizedText("Variable with a structured DataType that is created using a StructureDefinition"),
                DataType = encodeable.TypeId.ToNodeId(Server.NamespaceUris),
                AccessLevel = AccessLevels.CurrentReadOrWrite,
                ReferenceTypeId = ReferenceTypeIds.HasComponent,
                ParentNodeId = new NodeId(Demo.Model.Objects.Demo_Static_Scalar_Structures, DefaultNamespaceIndex),
                ValueRank = ValueRanks.Scalar,
                Value = encodeable
            };
            CreateVariable(Server.DefaultRequestContext, settings);
        }

        void SetupGenericDataTypeVariables()
        {
            var type = GetGenericDataTypeDefinition(Server.DefaultRequestContext, new NodeId(GenericStructureIdentifiers.PersonDataTypeId, DefaultNamespaceIndex)) as GenericStructuredDataTypeDefinition;

            // Alternatively the DataTypeDefinition can be fetched with the following code
            // type = Server.MessageContext.Factory.GetDataTypeDefinition(new ExpandedNodeId(GenericStructureIdentifiers.PersonDataTypeId, Demo.Model.Namespaces.Model));

            var eo = new GenericEncodeableStructure(type);
            eo["Name"] = "Fat Boy";
            eo["Height"] = (ushort)171;
            eo["Weight"] = 132.6f;
            eo["Gender"] = 0;

            CreateGenericDataTypeVariable("Person1", eo);

            eo = new GenericEncodeableStructure(type);
            eo["Name"] = "Long John";
            eo["Height"] = (ushort)213;
            eo["Weight"] = 82.1f;
            eo["Gender"] = 0;

            CreateGenericDataTypeVariable("Person2", eo);
        }
    }
}