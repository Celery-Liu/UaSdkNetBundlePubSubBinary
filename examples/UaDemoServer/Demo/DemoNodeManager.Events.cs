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
using System.Xml;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaServer;

namespace UnifiedAutomation.Demo
{
    internal partial class DemoNodeManager : BaseNodeManager
    {
        #region Private Methods
        /// <summary>
        /// Deletes all internal monitored items used for event triggers.
        /// </summary>
        private void ShutdownAllEvents()
        {
            Server.InternalClient.DeleteDataMonitoredItems(Server.DefaultRequestContext, m_internalMonitoredItemIds);
            m_internalMonitoredItemIds = null;
        }

        private void SetupEvents(NodeId baseId, NodeId notifierId)
        {
            // This method is called twice.
            if (m_internalMonitoredItemIds == null)
            {
                m_internalMonitoredItemIds = new List<uint>();
            }

            Node folder = FindInMemoryNode(baseId);
            List<InternalClientFastDataMonitoredItem> requests = new List<InternalClientFastDataMonitoredItem>();

            foreach (ReferenceNode reference in folder.FindReferences(UnifiedAutomation.UaBase.ReferenceTypeIds.Organizes, false, true, Server.TypeManager))
            {
                VariableNode variable = FindInMemoryNode((NodeId)reference.TargetId) as VariableNode;

                if (variable != null)
                {
                    variable.AccessLevel = AccessLevels.CurrentReadOrWrite;
                    DataVariableDataSource data = new DataVariableDataSource()
                    {
                        TypeInfo = new TypeInfo(variable.DataType, variable.ValueRank, Server.TypeManager),
                        Timestamp = DateTime.UtcNow,
                        Status = StatusCodes.Good,
                        AccessLevel = variable.AccessLevel,
                        Value = false
                    };
                    SetVariableConfiguration(variable.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(data, 0));

                    var typeReference = variable.FindReferences(UnifiedAutomation.Demo.Model.ReferenceTypeIds.TriggersEvent.ToNodeId(Server.NamespaceUris), false);

                    EventTrigger trigger = new EventTrigger()
                    {
                        NodeManager = this,
                        DataSource = data,
                        EventType = typeReference[0].TargetId,
                        TriggerSourceId = variable.NodeId,
                        TriggerNotifierId = notifierId
                    };

                    InternalClientFastDataMonitoredItem request = new InternalClientFastDataMonitoredItem();

                    request.NodeId = variable.NodeId;
                    request.AttributeId = Attributes.Value;
                    request.Callback = trigger.OnDataChanged;

                    requests.Add(request);
                }
            }

            var results = Server.InternalClient.CreateDataMonitoredItems(Server.DefaultRequestContext, requests);

            foreach (var result in results)
            {
                m_internalMonitoredItemIds.Add(result.MonitoredItemId);
            }
        }
        #endregion

        private class EventTrigger
        {
            public DemoNodeManager NodeManager;
            public DataVariableDataSource DataSource;
            public ExpandedNodeId EventType;
            public NodeId TriggerSourceId;
            public NodeId TriggerNotifierId;

            public void OnDataChanged(
                RequestContext context,
                MonitoredItemHandle itemHandle,
                DataValue dataValue,
                bool doNotBlockThread)
            {
                NodeManager.OnTriggerChanged(this, dataValue, TriggerSourceId, TriggerNotifierId);
            }
        }

        private void OnTriggerChanged(EventTrigger trigger, DataValue dataValue, NodeId sourceId, NodeId notifierId)
        {
            FireEvent((NodeId)trigger.EventType, sourceId, notifierId);
        }

        void FireEvent(NodeId eventTypeId, NodeId sourceId, NodeId notifierId, string message = null, uint? value = null)
        {
            GenericEvent e = new GenericEvent(Server.FilterManager);

            if (eventTypeId == ObjectTypeIds.SystemEventType)
            {
                e.Initialize(
                    null,
                    ObjectTypeIds.SystemEventType,
                    sourceId,
                    FindInMemoryNode(sourceId).DisplayName.ToString(),
                    EventSeverity.Medium,
                    new LocalizedText(message ?? "A system event."));
            }
            else
            {
                e.Initialize(
                    null,
                    new NodeId(1005, DefaultNamespaceIndex),
                    sourceId,
                    FindInMemoryNode(sourceId).DisplayName.ToString(),
                    EventSeverity.Medium,
                    new LocalizedText(message ?? "A sample event."));

                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.Boolean, DefaultNamespaceIndex)), m_generator.GetRandom<bool>(false));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.SByte, DefaultNamespaceIndex)), value != null ? (sbyte)value : m_generator.GetRandom<sbyte>(false));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.Byte, DefaultNamespaceIndex)), value != null ? (byte)value : m_generator.GetRandom<byte>(false));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.Int16, DefaultNamespaceIndex)), value != null ? (short)value : m_generator.GetRandom<short>(false));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.UInt16, DefaultNamespaceIndex)), value != null ? (ushort)value : m_generator.GetRandom<ushort>(false));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.Int32, DefaultNamespaceIndex)), value != null ? (int) value : m_generator.GetRandom<int>(false));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.UInt32, DefaultNamespaceIndex)), value ?? m_generator.GetRandom<uint>(false));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.Int64, DefaultNamespaceIndex)), value != null ? (long)value : m_generator.GetRandom<long>(false));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.UInt64, DefaultNamespaceIndex)), value != null ? (ulong)value : m_generator.GetRandom<ulong>(false));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.Float, DefaultNamespaceIndex)), m_generator.GetRandom<float>(false));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.Double, DefaultNamespaceIndex)), m_generator.GetRandom<double>(false));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.String, DefaultNamespaceIndex)), m_generator.GetRandom<string>(false));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.ByteString, DefaultNamespaceIndex)), m_generator.GetRandom<byte[]>(false));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.DateTime, DefaultNamespaceIndex)), m_generator.GetRandom<DateTime>(false));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.Guid, DefaultNamespaceIndex)), m_generator.GetRandom<Uuid>(false));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.NodeId, DefaultNamespaceIndex)), m_generator.GetRandom<NodeId>(false));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.ExpandedNodeId, DefaultNamespaceIndex)), m_generator.GetRandom<ExpandedNodeId>(false));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.QualifiedName, DefaultNamespaceIndex)), m_generator.GetRandom<QualifiedName>(false));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.LocalizedText, DefaultNamespaceIndex)), m_generator.GetRandom<LocalizedText>(false));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.StatusCode, DefaultNamespaceIndex)), m_generator.GetRandom<StatusCode>(false));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.XmlElement, DefaultNamespaceIndex)), m_generator.GetRandom<XmlString>(false));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.Enumeration, DefaultNamespaceIndex)), new Variant((int)Model.HeaterStatus.Heating));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.OptionSetBase, DefaultNamespaceIndex)), new Model.OptionSetBase()
                {
                    Flags = Model.OptionSetBaseFlags.ERROR | Model.OptionSetBaseFlags.WARNING
                });
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.OptionSetBaseArray, DefaultNamespaceIndex)), new Variant(
                    new List<Model.OptionSetBase>()
                    {
                    new Model.OptionSetBase() { Flags = Model.OptionSetBaseFlags.INFO| Model.OptionSetBaseFlags.DEBUG },
                    new Model.OptionSetBase() { Flags = Model.OptionSetBaseFlags.ERROR | Model.OptionSetBaseFlags.SYSTEM }
                    },
                    null));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.OptionSetByte, DefaultNamespaceIndex)), new Variant((byte)(Model.OptionSetByte.INFO | Model.OptionSetByte.SYSTEM | Model.OptionSetByte.WARNING)));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.OptionSetUInt16, DefaultNamespaceIndex)), new Variant((ushort)(Model.OptionSetUInt16.ERROR | Model.OptionSetUInt16.SYSTEM | Model.OptionSetUInt16.WARNING)));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.OptionSetUInt16Array, DefaultNamespaceIndex)), new Variant(
                    new ushort[]
                    {
                    (ushort) (Model.OptionSetUInt16.ERROR|Model.OptionSetUInt16.SYSTEM),
                    (ushort) (Model.OptionSetUInt16.WARNING|Model.OptionSetUInt16.SYSTEM),
                    }
                    ));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.OptionSetUInt32, DefaultNamespaceIndex)), new Variant((uint)(Model.OptionSetUInt32.INFO | Model.OptionSetUInt32.SYSTEM)));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.OptionSetUInt64, DefaultNamespaceIndex)), new Variant((ulong)(Model.OptionSetUInt64.AA | Model.OptionSetUInt64.ZZ | Model.OptionSetUInt64.GG)));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.Structure, DefaultNamespaceIndex)), new Model.Vector() { X = 1.11, Y = 2.22, Z = 3.33 });
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.StructureArray, DefaultNamespaceIndex)), new Variant(
                    new List<Model.Vector>()
                    {
                    new Model.Vector() { X = 1.11, Y = 2.22, Z = 3.33 },
                    new Model.Vector() { X = 2.22, Y = 3.33, Z = 4.44 }
                    },
                    null));
                e.Set(AbsoluteName.ToString(new QualifiedName(Model.BrowseNames.StructureWithAbstractBaseTypes, DefaultNamespaceIndex)), new Model.StructureWithAbstractBaseTypes()
                {
                    Base1 = new Model.ConcreteSubType(),
                    Base2 = new Model.ExtendedSubType()
                });
            }
            ReportEvent(notifierId, e);
        }
    }
}
