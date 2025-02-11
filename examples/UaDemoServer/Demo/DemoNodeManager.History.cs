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
using System.Reflection;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaServer;

namespace UnifiedAutomation.Demo
{
    internal partial class DemoNodeManager : BaseNodeManager
    {
        #region Private Methods
        //Change minimum processing interval of aggregate calculations in milliseconds
        private void ChangeMinimumProcessingInterval(ServerManager server, Double value)
        {
            server.AggregateManager.MinimumProcessingInterval = value;
        }

        private void SetupCTTScalarHistory(NodeId baseId)
        {
            Node folder = FindInMemoryNode(baseId);
            VariableNode variable;
            //List<NodeId> historyNodes = new List<NodeId>();
            //historyNodes.Add(new NodeId(Model.Variables.Demo_CTT_Static_HAProfile_Scalar_Bool, DefaultNamespaceIndex));


            //foreach (NodeId nodeId in historyNodes)
            //{
            //    variable = FindInMemoryNode(nodeId) as VariableNode;

            //    if (variable == null)
            //    {
            //        continue;
            //    }

            //    lock (InMemoryNodeLock)
            //    {
            //        variable.AccessLevel |= AccessLevels.HistoryWrite;
            //    }
            //}

            foreach (ReferenceNode reference in folder.FindReferences(UnifiedAutomation.UaBase.ReferenceTypeIds.HierarchicalReferences, false, true, Server.TypeManager))
            {
                variable = FindInMemoryNode((NodeId)reference.TargetId) as VariableNode;

                if (variable == null)
                {
                    continue;
                }

                if ((variable.AccessLevel & AccessLevels.HistoryRead) == 0)
                {
                    continue;
                }

                HistoryDataVariableDataSource data = new HistoryDataVariableDataSource()
                {
                    TypeInfo = new UnifiedAutomation.UaBase.TypeInfo(variable.DataType, variable.ValueRank, Server.TypeManager),
                    Timestamp = DateTime.UtcNow,
                    Status = StatusCodes.Good,
                    AccessLevel = variable.AccessLevel
                };

                // set aggregate configuration defaults.
                AggregateConfiguration configuration = Server.AggregateManager.GetDefaultConfiguration(null);

                data.Configuration.AggregateConfiguration.PercentDataBad = configuration.PercentDataBad;
                data.Configuration.AggregateConfiguration.PercentDataGood = configuration.PercentDataGood;
                data.Configuration.AggregateConfiguration.TreatUncertainAsBad = configuration.TreatUncertainAsBad;
                data.Configuration.AggregateConfiguration.UseSlopedExtrapolation = configuration.UseSlopedExtrapolation;

                DataSourceAddress address = new DataSourceAddress(data, 0);

                // set the node data for history calls.
                SetNodeUserData(variable.NodeId, address);

                // set the variable configuration to handle current read/write calls.
                SetVariableConfiguration(variable.NodeId, NodeHandleType.ExternalPush, address);

                // create the HA configuration object.
                string parentId = variable.NodeId.Identifier as string;

                if (parentId == null)
                {
                    parentId = variable.NodeId.Identifier.ToString();
                }

                if (parentId == "Demo.CTT.Static.HAProfile.Scalar.Bool")
                {
                    LoadDataFromResource("Historian4", data);
                }
                else data.SourceNodeId = new NodeId(parentId, DefaultNamespaceIndex);



                //switch (parentId)
                //{
                //    case Model.Variables.Demo_History_ByteWithHistory:
                //        {
                //            data.SourceNodeId = new NodeId(Model.Variables.Demo_Dynamic_Scalar_Byte, DefaultNamespaceIndex);
                //            break;
                //        }

                //    case Model.Variables.Demo_History_DoubleWithHistory:
                //        {
                //            data.SourceNodeId = new NodeId(Model.Variables.Demo_Dynamic_Scalar_Double, DefaultNamespaceIndex);
                //            break;
                //        }

                //    case Model.Variables.Demo_History_Historian_1:
                //        {
                //            LoadDataFromResource("Historian1", data);
                //            break;
                //        }

                //    case Model.Variables.Demo_History_Historian_2:
                //        {
                //            LoadDataFromResource("Historian2", data);
                //            break;
                //        }

                //    case Model.Variables.Demo_History_Historian_3:
                //        {
                //            LoadDataFromResource("Historian3", data);
                //            break;
                //        }

                //    case Model.Variables.Demo_History_Historian_4:
                //        {
                //            LoadDataFromResource("Historian4", data);
                //            break;
                //        }
                //}

                NodeId configurationId = new NodeId(parentId + ".Configuration", DefaultNamespaceIndex);

                CreateObjectSettings settings2 = new CreateObjectSettings()
                {
                    ParentNodeId = variable.NodeId,
                    ReferenceTypeId = ReferenceTypeIds.HasHistoricalConfiguration,
                    RequestedNodeId = configurationId,
                    BrowseName = BrowseNames.HAConfiguration,
                    TypeDefinitionId = ObjectTypeIds.HistoricalDataConfigurationType,

                    // add optional properties.
                    // With the children settings, the type definition id and some
                    // attributes can be specified. If child settings exist for
                    // an optional child, the child will be instantiated.
                    ChildrenSettings =
                    {
                        new ChildVariableSettings()
                        {
                            BrowsePath = { BrowseNames.StartOfArchive },
                        },
                        new ChildVariableSettings()
                        {
                            BrowsePath = { BrowseNames.StartOfOnlineArchive },
                        },
                    }
                };

                CreateObject(Server.DefaultRequestContext, settings2);

                // link model to node.
                LinkModelToNode(configurationId, data.Configuration, null, null, 500);

                // add the annotations.
                NodeId annotationId = new NodeId(parentId + ".Annotations", DefaultNamespaceIndex);

                CreateVariableSettings settings3 = new CreateVariableSettings()
                {
                    ParentNodeId = variable.NodeId,
                    ReferenceTypeId = ReferenceTypeIds.HasProperty,
                    RequestedNodeId = annotationId,
                    BrowseName = BrowseNames.Annotations,
                    AccessLevel = AccessLevels.HistoryReadOrWrite,
                    DataType = DataTypeIds.Annotation,
                    ValueRank = ValueRanks.Scalar,
                    MinimumSamplingInterval = 0,
                    Historizing = false,
                    TypeDefinitionId = VariableTypeIds.PropertyType,
                    NodeData = new DataSourceAddress(data, 1)
                };

                CreateVariable(Server.DefaultRequestContext, settings3);

                // save variable.
                m_historyVariables.Add(data);

            }
        }

        private void SetupDataHistory(NodeId baseId)
        {
            Node folder = FindInMemoryNode(baseId);

            VariableNode variable = FindInMemoryNode(new NodeId("Demo.History.DataLoggerActive", DefaultNamespaceIndex)) as VariableNode;

            if (variable != null)
            {
                variable.AccessLevel = AccessLevels.CurrentRead;

                DataVariableDataSource data = new DataVariableDataSource()
                {
                    TypeInfo = new UnifiedAutomation.UaBase.TypeInfo(variable.DataType, variable.ValueRank, Server.TypeManager),
                    Timestamp = DateTime.UtcNow,
                    Status = StatusCodes.Good,
                    AccessLevel = variable.AccessLevel,
                    Value = false
                };

                SetVariableConfiguration(variable.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(data, 0));
                m_dataLoggerActive = data;
            }

            List<NodeId> historyNodes = new List<NodeId>();
            historyNodes.Add(new NodeId(Model.Variables.Demo_History_Historian_1, DefaultNamespaceIndex));
            historyNodes.Add(new NodeId(Model.Variables.Demo_History_Historian_2, DefaultNamespaceIndex));
            historyNodes.Add(new NodeId(Model.Variables.Demo_History_Historian_3, DefaultNamespaceIndex));
            historyNodes.Add(new NodeId(Model.Variables.Demo_History_Historian_4, DefaultNamespaceIndex));

            foreach (NodeId nodeId in historyNodes)
            {
                variable = FindInMemoryNode(nodeId) as VariableNode;

                if (variable == null)
                {
                    continue;
                }

                lock (InMemoryNodeLock)
                {
                    variable.AccessLevel |= AccessLevels.HistoryWrite;
                }
            }

            foreach (ReferenceNode reference in folder.FindReferences(UnifiedAutomation.UaBase.ReferenceTypeIds.HierarchicalReferences, false, true, Server.TypeManager))
            {
                variable = FindInMemoryNode((NodeId)reference.TargetId) as VariableNode;

                if (variable == null)
                {
                    continue;
                }

                if ((variable.AccessLevel & AccessLevels.HistoryRead) == 0)
                {
                    continue;
                }

                HistoryDataVariableDataSource data = new HistoryDataVariableDataSource()
                {
                    TypeInfo = new UnifiedAutomation.UaBase.TypeInfo(variable.DataType, variable.ValueRank, Server.TypeManager),
                    Timestamp = DateTime.UtcNow,
                    Status = StatusCodes.Good,
                    AccessLevel = variable.AccessLevel
                };

                // set aggregate configuration defaults.
                AggregateConfiguration configuration = Server.AggregateManager.GetDefaultConfiguration(null);

                data.Configuration.AggregateConfiguration.PercentDataBad = configuration.PercentDataBad;
                data.Configuration.AggregateConfiguration.PercentDataGood = configuration.PercentDataGood;
                data.Configuration.AggregateConfiguration.TreatUncertainAsBad = configuration.TreatUncertainAsBad;
                data.Configuration.AggregateConfiguration.UseSlopedExtrapolation = configuration.UseSlopedExtrapolation;

                DataSourceAddress address = new DataSourceAddress(data, 0);

                // set the node data for history calls.
                SetNodeUserData(variable.NodeId, address);

                // set the variable configuration to handle current read/write calls.
                SetVariableConfiguration(variable.NodeId, NodeHandleType.ExternalPush, address);

                // create the HA configuration object.
                string parentId = variable.NodeId.Identifier as string;

                if (parentId == null)
                {
                    parentId = variable.NodeId.Identifier.ToString();
                }

                switch (parentId)
                {
                    case Model.Variables.Demo_History_ByteWithHistory:
                    {
                        data.SourceNodeId = new NodeId(Model.Variables.Demo_Dynamic_Scalar_Byte, DefaultNamespaceIndex);
                        break;
                    }

                    case Model.Variables.Demo_History_DoubleWithHistory:
                    {
                        data.SourceNodeId = new NodeId(Model.Variables.Demo_Dynamic_Scalar_Double, DefaultNamespaceIndex);
                        break;
                    }

                    case Model.Variables.Demo_History_Historian_1:
                    {
                        LoadDataFromResource("Historian1", data);
                        break;
                    }

                    case Model.Variables.Demo_History_Historian_2:
                    {
                        LoadDataFromResource("Historian2", data);
                        break;
                    }

                    case Model.Variables.Demo_History_Historian_3:
                    {
                        LoadDataFromResource("Historian3", data);
                        break;
                    }

                    case Model.Variables.Demo_History_Historian_4:
                    {
                        LoadDataFromResource("Historian4", data);
                        break;
                    }
                }

                NodeId configurationId = new NodeId(parentId + ".Configuration", DefaultNamespaceIndex);

                CreateObjectSettings settings2 = new CreateObjectSettings()
                {
                    ParentNodeId = variable.NodeId,
                    ReferenceTypeId = ReferenceTypeIds.HasHistoricalConfiguration,
                    RequestedNodeId = configurationId,
                    BrowseName = BrowseNames.HAConfiguration,
                    TypeDefinitionId = ObjectTypeIds.HistoricalDataConfigurationType,

                    // add optional properties.
                    ChildrenSettings =
                    {
                        new ChildVariableSettings() { BrowsePath = { BrowseNames.StartOfArchive } },
                        new ChildVariableSettings() { BrowsePath = { BrowseNames.StartOfOnlineArchive } },
                    }
                };

                CreateObject(Server.DefaultRequestContext, settings2);

                // link model to node.
                LinkModelToNode(configurationId, data.Configuration, null, null, 500);

                // add the annotations.
                NodeId annotationId = new NodeId(parentId + ".Annotations", DefaultNamespaceIndex);

                CreateVariableSettings settings3 = new CreateVariableSettings()
                {
                    ParentNodeId = variable.NodeId,
                    ReferenceTypeId = ReferenceTypeIds.HasProperty,
                    RequestedNodeId = annotationId,
                    BrowseName = BrowseNames.Annotations,
                    AccessLevel = AccessLevels.HistoryReadOrWrite,
                    DataType = DataTypeIds.Annotation,
                    ValueRank = ValueRanks.Scalar,
                    MinimumSamplingInterval = 0,
                    Historizing = false,
                    TypeDefinitionId = VariableTypeIds.PropertyType,
                    NodeData = new DataSourceAddress(data, 1)
                };

                CreateVariable(Server.DefaultRequestContext, settings3);

                // save variable.
                m_historyVariables.Add(data);
            }

            // start logging.
            // StartLogging(Server.DefaultRequestContext);
        }

        private void SetupEventHistory(NodeId baseId)
        {
            m_filterManager = new FilterManager(Server);

            HistoryEventSource data = new HistoryEventSource();
            LoadEventsFromResource("NotifierWithHistory", data);

            // create notifier.
            NodeId notifierId = new NodeId("Demo.History.NotifierWithHistory", DefaultNamespaceIndex);

            CreateObjectSettings settings = new CreateObjectSettings()
            {
                ParentNodeId = baseId,
                ReferenceTypeId = ReferenceTypeIds.Organizes,
                RequestedNodeId = notifierId,
                BrowseName = "NotifierWithHistory",
                EventNotifier = EventNotifiers.HistoryRead | EventNotifiers.HistoryWrite,
                NotifierParent = ObjectIds.Server,
                TypeDefinitionId = ObjectTypeIds.BaseObjectType,
                NodeData = data
            };

            CreateObject(Server.DefaultRequestContext, settings);

            // add the historical filter property.
            CreateVariableSettings settings2 = new CreateVariableSettings()
            {
                ParentNodeId = notifierId,
                ReferenceTypeId = ReferenceTypeIds.HasProperty,
                RequestedNodeId = new NodeId("Demo.History.NotifierWithHistory.Filter", DefaultNamespaceIndex),
                BrowseName = BrowseNames.HistoricalEventFilter,
                AccessLevel = AccessLevels.CurrentRead,
                DataType = DataTypeIds.EventFilter,
                ValueRank = ValueRanks.Scalar,
                MinimumSamplingInterval = 0,
                Historizing = false,
                TypeDefinitionId = VariableTypeIds.PropertyType,
                Value = new Variant(data.Filter)
            };

            CreateVariable(Server.DefaultRequestContext, settings2);

            // save notifier.
            m_historyNotifiers.Add(data);
        }
        #endregion

        #region Historian Functions
        private void LoadDataFromResource(string sourceName, HistoryDataVariableDataSource datasource)
        {
            try
            {
                sourceName += ".txt";
                Stream istrm = null;

                foreach (string resourceName in Assembly.GetExecutingAssembly().GetManifestResourceNames())
                {
                    if (resourceName.EndsWith(sourceName, StringComparison.OrdinalIgnoreCase))
                    {
                        istrm = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
                        break;
                    }
                }

                if (istrm != null)
                {
                    using (istrm)
                    {
                        datasource.Load(Server.DefaultRequestContext, istrm);
                    }
                }

            }
            catch (Exception e)
            {
                TraceServer.Error(e, "Unexpected error loading historical data from file.");
            }
        }

        private void LoadEventsFromResource(string sourceName, HistoryEventSource eventsource)
        {
            try
            {
                sourceName += ".xml";
                Stream istrm = null;

                foreach (string resourceName in Assembly.GetExecutingAssembly().GetManifestResourceNames())
                {
                    if (resourceName.EndsWith(sourceName, StringComparison.OrdinalIgnoreCase))
                    {
                        istrm = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
                        break;
                    }
                }

                if (istrm != null)
                {
                    using (istrm)
                    {
                        eventsource.Load(Server.DefaultRequestContext, m_filterManager, istrm);
                    }
                }
            }
            catch (Exception e)
            {
                TraceServer.Error(e, "Unexpected error loading historical events from file.");
            }
        }

        private StatusCode StartLogging(RequestContext context)
        {
            if (m_dataLoggerActive.Value.ToBoolean())
            {
                return StatusCodes.BadInvalidState;
            }

            List<InternalClientFullDataMonitoredItem> requests = new List<InternalClientFullDataMonitoredItem>();

            lock (m_historyVariables)
            {
                for (int ii = 0; ii < m_historyVariables.Count; ii++)
                {
                    InternalClientFullDataMonitoredItem request = new InternalClientFullDataMonitoredItem();

                    request.NodeId = m_historyVariables[ii].SourceNodeId;
                    request.AttributeId = Attributes.Value;
                    request.SamplingInterval = 1000;
                    request.Callback = OnDataChanged;
                    request.CallbackData = m_historyVariables[ii];

                    requests.Add(request);
                }
            }

            List<MonitoredItemCreateResult> results = Server.InternalClient.CreateDataMonitoredItems(context, requests);

            lock (m_historyVariables)
            {
                for (int ii = 0; ii < m_historyVariables.Count; ii++)
                {
                    if (results[ii].StatusCode.IsGood())
                    {
                        m_historyVariables[ii].Historizing = true;
                        m_historyVariables[ii].SourceMonitoredItemId = results[ii].MonitoredItemId;
                    }
                }
            }

            lock (m_dataLoggerActive.Lock)
            {
                m_dataLoggerActive.Value = true;
                ReportChange(context, m_dataLoggerActive, 0);
            }

            return StatusCodes.Good;
        }

        private StatusCode StopLogging(RequestContext context)
        {
            if (!m_dataLoggerActive.Value.ToBoolean())
            {
                return StatusCodes.BadInvalidState;
            }

            List<uint> monitoredItemIds = new List<uint>();

            lock (m_historyVariables)
            {
                for (int ii = 0; ii < m_historyVariables.Count; ii++)
                {
                    monitoredItemIds.Add(m_historyVariables[ii].SourceMonitoredItemId);
                }
            }

            List<StatusCode> results = Server.InternalClient.DeleteDataMonitoredItems(context, monitoredItemIds);

            lock (m_historyVariables)
            {
                for (int ii = 0; ii < m_historyVariables.Count; ii++)
                {
                    if (results[ii].IsGood())
                    {
                        m_historyVariables[ii].SourceMonitoredItemId = 0;
                    }

                    m_historyVariables[ii].Historizing = false;
                }
            }

            lock (m_dataLoggerActive.Lock)
            {
                m_dataLoggerActive.Value = false;
                ReportChange(context, m_dataLoggerActive, 0);
            }

            return StatusCodes.Good;
        }

        private void OnDataChanged(
            RequestContext context,
            MonitoredItemHandle itemHandle,
            MonitoredItemNotification dataChange,
            object callbackData)
        {
            try
            {
                HistoryDataVariableDataSource datasource = callbackData as HistoryDataVariableDataSource;

                if (datasource != null)
                {
                    datasource.OnDataChanged(context, dataChange.Value, 0);
                    ReportChange(context, datasource, 0);
                }
            }
            catch (Exception e)
            {
                TraceServer.Error(e, "Unexpected error handling data update.");
            }
        }

        /// <summary>
        /// Stores a read history request.
        /// </summary>
        private class HistoryReadRequest : HistoryContinuationPoint
        {
            public HistoryDataVariableDataSource DataSource;
            public LinkedList<DataValue> Values;
            public LinkedList<ModificationInfo> ModificationInfos;
            public uint NumValuesPerNode;
            public AggregateFilter Filter;
        }

        #region Read Raw
        protected override HistoryReadResult HistoryReadRaw(
            RequestContext context,
            ReadRawModifiedDetails details,
            HistoryDataHandle nodeHandle,
            TimestampsToReturn timestampsToReturn,
            string indexRange,
            QualifiedName dataEncoding,
            ref HistoryContinuationPoint continuationPoint)
        {
            HistoryReadResult result = new HistoryReadResult();

            try
            {
                DataSourceAddress address = nodeHandle.NodeData as DataSourceAddress;

                if (address == null)
                {
                    return base.HistoryReadRaw(context, details, nodeHandle, timestampsToReturn, indexRange, dataEncoding, ref continuationPoint);
                }

                HistoryDataVariableDataSource datasource = address.Source as HistoryDataVariableDataSource;

                if (datasource == null)
                {
                    return new HistoryReadResult() { StatusCode = StatusCodes.BadHistoryOperationUnsupported };
                }

                // load an existing request.
                HistoryReadRequest request = null;

                if (continuationPoint != null)
                {
                    request = continuationPoint as HistoryReadRequest;

                    if (request == null)
                    {
                        return new HistoryReadResult() { StatusCode = StatusCodes.BadContinuationPointInvalid };
                    }

                    continuationPoint = null;
                }

                // create a new request.
                else
                {
                    request = CreateHistoryReadRequest(
                        context,
                        datasource,
                        address.ComponentIndex,
                        details,
                        nodeHandle,
                        timestampsToReturn,
                        indexRange,
                        dataEncoding);
                }

                // process values until the max is reached.
                HistoryData data = (details.IsReadModified) ? new HistoryModifiedData() : new HistoryData();
                HistoryModifiedData modifiedData = data as HistoryModifiedData;

                while (request.NumValuesPerNode == 0 || data.DataValues.Count < request.NumValuesPerNode)
                {
                    if (request.Values.Count == 0)
                    {
                        break;
                    }

                    DataValue value = request.Values.First.Value;
                    request.Values.RemoveFirst();
                    data.DataValues.Add(value);

                    if (modifiedData != null)
                    {
                        ModificationInfo modificationInfo = null;

                        if (request.ModificationInfos != null && request.ModificationInfos.Count > 0)
                        {
                            modificationInfo = request.ModificationInfos.First.Value;
                            request.ModificationInfos.RemoveFirst();
                        }

                        modifiedData.ModificationInfos.Add(modificationInfo);
                    }
                }

                if (request.Values.Count > 0)
                {
                    continuationPoint = request;
                }

                // return the data.
                result.HistoryData = new ExtensionObject(data);
            }
            catch (Exception e)
            {
                new HistoryReadResult() { StatusCode = new StatusCode(e) };
            }

            return result;
        }

        private HistoryReadRequest CreateHistoryReadRequest(
            RequestContext context,
            HistoryDataVariableDataSource datasource,
            int componentId,
            ReadRawModifiedDetails details,
            HistoryDataHandle handle,
            TimestampsToReturn timestampsToReturn,
            string indexRange,
            QualifiedName dataEncoding)
        {
            bool sizeLimited = (details.StartTime == DateTime.MinValue || details.EndTime == DateTime.MinValue);
            bool applyIndexRangeOrEncoding = (String.IsNullOrEmpty(indexRange) || !QualifiedName.IsNull(dataEncoding));
            bool returnBounds = !details.IsReadModified && details.ReturnBounds;
            bool timeFlowsBackward = (details.StartTime == DateTime.MinValue) || (details.EndTime != DateTime.MinValue && details.EndTime < details.StartTime);

            LinkedList<DataValue> values = new LinkedList<DataValue>();
            LinkedList<ModificationInfo> modificationInfos = null;

            if (details.IsReadModified)
            {
                modificationInfos = new LinkedList<ModificationInfo>();
            }

            // read history.
            lock (datasource)
            {
                var view = datasource.GetDataView(details.IsReadModified, componentId);

                int startBound = -1;
                int endBound = -1;
                int ii = timeFlowsBackward ? view.Rows.Count - 1 : 0;
                
                
                while (ii >= 0 && ii < view.Rows.Count)
                {
                    try
                    {
                        DateTime timestamp = datasource.GetSourceTimestamp(view, ii);

                        // check if looking for start of data.
                        if (values.Count == 0)
                        {
                            if (timeFlowsBackward)
                            {
                                if ((details.StartTime != DateTime.MinValue && timestamp >= details.StartTime) || (details.StartTime == DateTime.MinValue && timestamp >= details.EndTime))
                                {
                                    startBound = ii;

                                    if (timestamp > details.StartTime)
                                    {
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                if (timestamp <= details.StartTime)
                                {
                                    startBound = ii;

                                    if (timestamp < details.StartTime)
                                    {
                                        continue;
                                    }
                                }
                            }
                        }

                        // check if absolute max values specified.
                        if (sizeLimited)
                        {
                            if (details.NumValuesPerNode > 0 && details.NumValuesPerNode <= values.Count)
                            {
                                break;
                            }
                        }

                        // check for end bound.
                        if (details.EndTime != DateTime.MinValue && timestamp >= details.EndTime)
                        {
                            if (timeFlowsBackward)
                            {
                                if (timestamp <= details.EndTime)
                                {
                                    endBound = ii;
                                    break;
                                }
                            }
                            else
                            {
                                if (timestamp >= details.EndTime)
                                {
                                    endBound = ii;
                                    break;
                                }
                            }
                        }

                        // check if the start bound needs to be returned.
                        if (returnBounds && values.Count == 0 && startBound != ii && details.StartTime != DateTime.MinValue)
                        {
                            // add start bound.
                            if (startBound == -1)
                            {
                                values.AddLast(GetBadNotFound(timestampsToReturn, details.StartTime));
                            }
                            else
                            {
                                values.AddLast(RowToDataValue(context, timestampsToReturn, indexRange, dataEncoding, view.Rows[startBound], applyIndexRangeOrEncoding));
                            }

                            // check if absolute max values specified.
                            if (sizeLimited)
                            {
                                if (details.NumValuesPerNode > 0 && details.NumValuesPerNode <= values.Count)
                                {
                                    break;
                                }
                            }
                        }

                        // add value.
                        var row = view.Rows[ii];
                        if (row.ComponentId == componentId)
                        {
                            values.AddLast(RowToDataValue(context, timestampsToReturn, indexRange, dataEncoding, row, applyIndexRangeOrEncoding));

                            if (modificationInfos != null)
                            {
                                modificationInfos.AddLast((row as IDataRowModified).ModificationInfo);
                            }
                        }
                    }
                    finally
                    {
                        if (timeFlowsBackward)
                        {
                            ii--;
                        }
                        else
                        {
                            ii++;
                        }
                    }
                }

                // add late bound.
                while (returnBounds && details.EndTime != DateTime.MinValue)
                {
                    // add start bound.
                    if (values.Count == 0)
                    {
                        if (startBound == -1)
                        {
                            values.AddLast(GetBadNotFound(timestampsToReturn, details.StartTime));
                        }
                        else
                        {
                            values.AddLast(RowToDataValue(context, timestampsToReturn, indexRange, dataEncoding, view.Rows[startBound], applyIndexRangeOrEncoding));
                        }
                    }

                    // check if absolute max values specified.
                    if (sizeLimited)
                    {
                        if (details.NumValuesPerNode > 0 && details.NumValuesPerNode <= values.Count)
                        {
                            break;
                        }
                    }

                    // add end bound.
                    if (endBound == -1)
                    {
                        values.AddLast(GetBadNotFound(timestampsToReturn, details.EndTime));
                    }
                    else
                    {
                        values.AddLast(RowToDataValue(context, timestampsToReturn, indexRange, dataEncoding, view.Rows[endBound], applyIndexRangeOrEncoding));
                    }

                    break;
                }
            }

            HistoryReadRequest request = new HistoryReadRequest();
            request.DataSource = datasource;
            request.Values = values;
            request.ModificationInfos = modificationInfos;
            request.NumValuesPerNode = details.NumValuesPerNode;
            request.Filter = null;
            return request;
        }
        #endregion

        #region Read Processed
        protected override HistoryReadResult HistoryReadProcessed(
            RequestContext context,
            ReadProcessedDetails details,
            HistoryDataHandle nodeHandle,
            TimestampsToReturn timestampsToReturn,
            NodeId aggregateId,
            string indexRange,
            QualifiedName dataEncoding,
            ref HistoryContinuationPoint continuationPoint)
        {
            HistoryReadResult result = new HistoryReadResult();

            try
            {
                DataSourceAddress address = nodeHandle.NodeData as DataSourceAddress;

                if (address == null)
                {
                    return base.HistoryReadProcessed(context, details, nodeHandle, timestampsToReturn, aggregateId, indexRange, dataEncoding, ref continuationPoint);
                }

                HistoryDataVariableDataSource datasource = address.Source as HistoryDataVariableDataSource;

                if (datasource == null)
                {
                    return new HistoryReadResult() { StatusCode = StatusCodes.BadHistoryOperationUnsupported };
                }

                // load an existing request.
                HistoryReadRequest request = null;

                if (continuationPoint != null)
                {
                    request = continuationPoint as HistoryReadRequest;

                    if (request == null)
                    {
                        return new HistoryReadResult() { StatusCode = StatusCodes.BadContinuationPointInvalid };
                    }

                    continuationPoint = null;
                }

                // create a new request.
                else
                {
                    request = CreateHistoryReadRequest(
                        context,
                        datasource,
                        address.ComponentIndex,
                        details,
                        nodeHandle,
                        timestampsToReturn,
                        indexRange,
                        dataEncoding,
                        aggregateId);
                }

                // process values until the max is reached.
                HistoryData data = new HistoryData();

                while (request.NumValuesPerNode == 0 || data.DataValues.Count < request.NumValuesPerNode)
                {
                    if (request.Values.Count == 0)
                    {
                        break;
                    }

                    DataValue value = request.Values.First.Value;
                    request.Values.RemoveFirst();
                    data.DataValues.Add(value);

                    // MaxHistroyDataValuesPerRead limits check
                    if (data.DataValues.Count >= Server.SessionManager.SessionLimits.MaxHistoryDataValuesPerRead)
                    {
                        break;
                    }
                }

                if (request.Values.Count > 0)
                {
                    continuationPoint = request;
                }

                // return the data.
                result.HistoryData = new ExtensionObject(data);
            }
            catch (Exception e)
            {
                new HistoryReadResult() { StatusCode = new StatusCode(e) };
            }

            return result;
        }

        private HistoryReadRequest CreateHistoryReadRequest(
            RequestContext context,
            HistoryDataVariableDataSource datasource,
            int componentId,
            ReadProcessedDetails details,
            HistoryDataHandle handle,
            TimestampsToReturn timestampsToReturn,
            string indexRange,
            QualifiedName dataEncoding,
            NodeId aggregateId)
        {
            bool sizeLimited = (details.StartTime == DateTime.MinValue || details.EndTime == DateTime.MinValue);
            bool applyIndexRangeOrEncoding = (!String.IsNullOrEmpty(indexRange) || !QualifiedName.IsNull(dataEncoding));
            bool timeFlowsBackward = (details.StartTime == DateTime.MinValue) || (details.EndTime != DateTime.MinValue && details.EndTime < details.StartTime);

            LinkedList<DataValue> values = new LinkedList<DataValue>();

            // read history.
            lock (datasource)
            {
                // choose the aggregate configuration.
                AggregateConfiguration configuration = (AggregateConfiguration)details.AggregateConfiguration.Clone();
                ReviseAggregateConfiguration(context, datasource, configuration);

                double processingInterval = details.ProcessingInterval;
                int maxSlices = 1000000;
                if (((details.EndTime - details.StartTime).TotalMilliseconds / processingInterval) > maxSlices)
                {
                    processingInterval = (details.EndTime - details.StartTime).TotalMilliseconds / maxSlices;
                }

                // create the aggregate calculator.
                IAggregateCalculator calculator = Server.AggregateManager.CreateCalculator(
                    aggregateId,
                    details.StartTime,
                    details.EndTime,
                    processingInterval,
                    datasource.Configuration.Stepped,
                    configuration);
                
                var table = datasource.GetDataView(false, componentId);

                int ii = (timeFlowsBackward) ? table.Rows.Count - 1 : 0;

                while (ii >= 0 && ii < table.Rows.Count)
                {
                    try
                    {
                        DataValue value = (DataValue)table.Rows[ii].Value;
                        calculator.QueueRawValue(value);

                        // queue any processed values.
                        QueueProcessedValues(
                            context,
                            calculator,
                            timestampsToReturn,
                            indexRange,
                            dataEncoding,
                            applyIndexRangeOrEncoding,
                            false,
                            values);
                    }
                    finally
                    {
                        if (timeFlowsBackward)
                        {
                            ii--;
                        }
                        else
                        {
                            ii++;
                        }
                    }
                }

                // queue any processed values beyond the end of the data.
                QueueProcessedValues(
                    context,
                    calculator,
                    timestampsToReturn,
                    indexRange,
                    dataEncoding,
                    applyIndexRangeOrEncoding,
                    true,
                    values);
            }

            HistoryReadRequest request = new HistoryReadRequest();
            request.DataSource = datasource;
            request.Values = values;
            request.NumValuesPerNode = 0;
            request.Filter = null;
            return request;
        }

        private void ReviseAggregateConfiguration(
            RequestContext context,
            HistoryDataVariableDataSource datasource,
            AggregateConfiguration configurationToUse)
        {
            // set configuration from defaults.
            if (configurationToUse.UseServerCapabilitiesDefaults)
            {
                configurationToUse.UseSlopedExtrapolation = datasource.Configuration.AggregateConfiguration.UseSlopedExtrapolation;
                configurationToUse.TreatUncertainAsBad = datasource.Configuration.AggregateConfiguration.TreatUncertainAsBad;
                configurationToUse.PercentDataBad = datasource.Configuration.AggregateConfiguration.PercentDataBad;
                configurationToUse.PercentDataGood = datasource.Configuration.AggregateConfiguration.PercentDataGood;
            }

            // override configuration when it does not make sense for the item.
            configurationToUse.UseServerCapabilitiesDefaults = false;

            if (datasource.Configuration.Stepped)
            {
                configurationToUse.UseSlopedExtrapolation = false;
            }
        }

        private void QueueProcessedValues(
            RequestContext context,
            IAggregateCalculator calculator,
            TimestampsToReturn timestampsToReturn,
            string indexRange,
            QualifiedName dataEncoding,
            bool applyIndexRangeOrEncoding,
            bool returnPartial,
            LinkedList<DataValue> values)
        {
            DataValue proccessedValue = calculator.GetProcessedValue(returnPartial);

            while (proccessedValue != null)
            {
                // apply any index range or encoding.
                if (applyIndexRangeOrEncoding)
                {
                    proccessedValue = ApplyIndexRangeAndEncoding(proccessedValue, indexRange, dataEncoding);
                }

                proccessedValue = RemoveTimestampsIfRequired(proccessedValue, timestampsToReturn);

                // queue the result.
                values.AddLast(proccessedValue);
                proccessedValue = calculator.GetProcessedValue(returnPartial);
            }
        }
        #endregion

        #region Read AtTime
        protected override HistoryReadResult HistoryReadAtTime(
            RequestContext context,
            ReadAtTimeDetails details,
            HistoryDataHandle nodeHandle,
            TimestampsToReturn timestampsToReturn,
            string indexRange,
            QualifiedName dataEncoding,
            ref HistoryContinuationPoint continuationPoint)
        {
            HistoryReadResult result = new HistoryReadResult();

            try
            {
                DataSourceAddress address = nodeHandle.NodeData as DataSourceAddress;

                if (address == null)
                {
                    return new HistoryReadResult() { StatusCode = StatusCodes.BadHistoryOperationUnsupported };
                }

                HistoryDataVariableDataSource datasource = address.Source as HistoryDataVariableDataSource;

                if (datasource == null)
                {
                    return new HistoryReadResult() { StatusCode = StatusCodes.BadHistoryOperationUnsupported };
                }

                // load an existing request.
                HistoryReadRequest request = null;

                if (continuationPoint != null)
                {
                    request = continuationPoint as HistoryReadRequest;

                    if (request == null)
                    {
                        return new HistoryReadResult() { StatusCode = StatusCodes.BadContinuationPointInvalid };
                    }

                    continuationPoint = null;
                }

                // create a new request.
                else
                {
                    request = CreateHistoryReadRequest(
                        context,
                        datasource,
                        address.ComponentIndex,
                        details,
                        nodeHandle,
                        timestampsToReturn,
                        indexRange,
                        dataEncoding);
                }

                // process values until the max is reached.
                HistoryData data = new HistoryData();

                while (request.NumValuesPerNode == 0 || data.DataValues.Count < request.NumValuesPerNode)
                {
                    if (request.Values.Count == 0)
                    {
                        break;
                    }

                    DataValue value = request.Values.First.Value;
                    request.Values.RemoveFirst();
                    data.DataValues.Add(value);
                }

                if (request.Values.Count > 0)
                {
                    continuationPoint = request;
                }

                // return the data.
                result.HistoryData = new ExtensionObject(data);
            }
            catch (Exception e)
            {
                new HistoryReadResult() { StatusCode = new StatusCode(e) };
            }

            return result;
        }

        private HistoryReadRequest CreateHistoryReadRequest(
            RequestContext context,
            HistoryDataVariableDataSource datasource,
            int componentId,
            ReadAtTimeDetails details,
            HistoryDataHandle handle,
            TimestampsToReturn timestampsToReturn,
            string indexRange,
            QualifiedName dataEncoding)
        {
            bool applyIndexRangeOrEncoding = (String.IsNullOrEmpty(indexRange) || !QualifiedName.IsNull(dataEncoding));

            LinkedList<DataValue> values = new LinkedList<DataValue>();

            // read history.
            lock (datasource)
            {
                // find the start and end times.
                DateTime startTime = DateTime.MaxValue;
                DateTime endTime = DateTime.MinValue;

                for (int ii = 0; ii < details.ReqTimes.Count; ii++)
                {
                    if (startTime > details.ReqTimes[ii])
                    {
                        startTime = details.ReqTimes[ii];
                    }

                    if (endTime < details.ReqTimes[ii])
                    {
                        endTime = details.ReqTimes[ii];
                    }
                }
                
                var view = datasource.GetDataView(false, componentId);

                for (int ii = 0; ii < details.ReqTimes.Count; ii++)
                {
                    bool dataBeforeIgnored = false;
                    bool dataAfterIgnored = false;

                    // find the value at the time.
                    int index = datasource.FindValueAtOrBefore(view, details.ReqTimes[ii], !details.UseSimpleBounds, out dataBeforeIgnored);

                    if (index < 0)
                    {
                        values.AddLast(new DataValue()
                        {
                            StatusCode = StatusCodes.BadNoData,
                            ServerTimestamp = (timestampsToReturn == TimestampsToReturn.Both || timestampsToReturn == TimestampsToReturn.Server) ?  details.ReqTimes[ii] : DateTime.MinValue,
                            SourceTimestamp = (timestampsToReturn == TimestampsToReturn.Both || timestampsToReturn == TimestampsToReturn.Source) ? details.ReqTimes[ii] : DateTime.MinValue
                        });
                        continue;
                    }

                    DataValue value;

                    // nothing more to do if a raw value exists.
                    if (datasource.GetSourceTimestamp(view, index) == details.ReqTimes[ii])
                    {
                        value = (DataValue)view.Rows[index].Value;
                        value = RemoveTimestampsIfRequired(value, timestampsToReturn);
                        values.AddLast(value);
                        continue;
                    }

                    DataValue before = (DataValue)view.Rows[index].Value;

                    // find the value after the time.
                    int afterIndex = datasource.FindValueAfter(view, index, !details.UseSimpleBounds, out dataAfterIgnored);

                    if (afterIndex < 0)
                    {
                        // use stepped interpolation if no end bound exists.
                        value = AggregateCalculator.SteppedInterpolate(details.ReqTimes[ii], before);

                        if (StatusCode.IsNotBad(value.StatusCode) && dataBeforeIgnored)
                        {
                            value.StatusCode = value.StatusCode.SetCodeBits(StatusCodes.UncertainDataSubNormal);
                        }

                        value = RemoveTimestampsIfRequired(value, timestampsToReturn);

                        values.AddLast(value);
                        continue;
                    }

                    // use stepped or slopped interpolation depending on the value.
                    if (datasource.Configuration.Stepped)
                    {
                        value = AggregateCalculator.SteppedInterpolate(details.ReqTimes[ii], before);

                        if (StatusCode.IsNotBad(value.StatusCode) && dataBeforeIgnored)
                        {
                            value.StatusCode = value.StatusCode.SetCodeBits(StatusCodes.UncertainDataSubNormal);
                        }
                    }
                    else
                    {
                        value = AggregateCalculator.SlopedInterpolate(details.ReqTimes[ii], before, (DataValue)view.Rows[afterIndex].Value);

                        if (StatusCode.IsNotBad(value.StatusCode) && (dataBeforeIgnored || dataAfterIgnored))
                        {
                            value.StatusCode = value.StatusCode.SetCodeBits(StatusCodes.UncertainDataSubNormal);
                        }
                    }

                    value = RemoveTimestampsIfRequired(value, timestampsToReturn);

                    values.AddLast(value);
                }
            }

            HistoryReadRequest request = new HistoryReadRequest();
            request.Values = values;
            request.NumValuesPerNode = 0;
            request.Filter = null;
            return request;
        }
        #endregion

        #region Update Data
        protected override HistoryUpdateResult HistoryUpdateData(
            RequestContext context,
            HistoryDataHandle nodeHandle,
            UpdateDataDetails details)
        {
            try
            {
                DataSourceAddress address = nodeHandle.NodeData as DataSourceAddress;

                if (address == null)
                {
                    return new HistoryUpdateResult() { StatusCode = StatusCodes.BadHistoryOperationUnsupported };
                }

                HistoryDataVariableDataSource datasource = address.Source as HistoryDataVariableDataSource;

                if (datasource == null)
                {
                    return new HistoryUpdateResult() { StatusCode = StatusCodes.BadHistoryOperationUnsupported };
                }

                // process each item.
                HistoryUpdateResult result = new HistoryUpdateResult();

                lock (datasource)
                {
                    for (int ii = 0; ii < details.UpdateValues.Count; ii++)
                    {
                        StatusCode error = datasource.UpdateHistory(context, address.ComponentIndex, details.UpdateValues[ii], details.PerformInsertReplace);
                        result.OperationResults.Add(error);
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                return new HistoryUpdateResult() { StatusCode = new StatusCode(e) };
            }
        }
        #endregion

        #region Update Structure Data
        protected override HistoryUpdateResult HistoryUpdateStructureData(
            RequestContext context,
            HistoryDataHandle nodeHandle,
            UpdateStructureDataDetails details)
        {
            try
            {
                DataSourceAddress address = nodeHandle.NodeData as DataSourceAddress;

                if (address == null)
                {
                    return new HistoryUpdateResult() { StatusCode = StatusCodes.BadHistoryOperationUnsupported };
                }

                HistoryDataVariableDataSource datasource = address.Source as HistoryDataVariableDataSource;

                if (datasource == null)
                {
                    return new HistoryUpdateResult() { StatusCode = StatusCodes.BadHistoryOperationUnsupported };
                }

                // process each item.
                HistoryUpdateResult result = new HistoryUpdateResult();

                lock (datasource)
                {
                    var view = datasource.GetDataView(false, address.ComponentIndex);

                    for (int ii = 0; ii < details.UpdateValues.Count; ii++)
                    {
                        StatusCode error = datasource.UpdateHistoryMetadata(view, context, address.ComponentIndex, details.UpdateValues[ii], details.PerformInsertReplace);
                        result.OperationResults.Add(error);
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                return new HistoryUpdateResult() { StatusCode = new StatusCode(e) };
            }
        }
        #endregion

        #region Delete Raw
        protected override HistoryUpdateResult HistoryDeleteRaw(
            RequestContext context,
            HistoryDataHandle nodeHandle,
            DeleteRawModifiedDetails details)
        {
            try
            {
                DataSourceAddress address = nodeHandle.NodeData as DataSourceAddress;

                if (address == null)
                {
                    return new HistoryUpdateResult() { StatusCode = StatusCodes.BadHistoryOperationUnsupported };
                }

                HistoryDataVariableDataSource datasource = address.Source as HistoryDataVariableDataSource;

                if (datasource == null)
                {
                    return new HistoryUpdateResult() { StatusCode = StatusCodes.BadHistoryOperationUnsupported };
                }

                if (details.StartTime == DateTime.MinValue || details.EndTime == DateTime.MinValue || details.StartTime > details.EndTime)
                {
                    return new HistoryUpdateResult() { StatusCode = StatusCodes.BadInvalidArgument };
                }

                lock (datasource)
                {
                    var view = datasource.GetDataView(details.IsDeleteModified, address.ComponentIndex);

                    if (!datasource.DeleteData(view, details.StartTime, details.EndTime))
                    {
                        return new HistoryUpdateResult() { StatusCode = StatusCodes.BadNoEntryExists };
                    }
                }

                return new HistoryUpdateResult() { StatusCode = StatusCodes.Good };
            }
            catch (Exception e)
            {
                return new HistoryUpdateResult() { StatusCode = new StatusCode(e) };
            }
        }
        #endregion

        #region Delete At Time
        protected override HistoryUpdateResult HistoryDeleteAtTime(
            RequestContext context,
            HistoryDataHandle nodeHandle,
            DeleteAtTimeDetails details)
        {
            try
            {
                DataSourceAddress address = nodeHandle.NodeData as DataSourceAddress;

                if (address == null)
                {
                    return new HistoryUpdateResult() { StatusCode = StatusCodes.BadHistoryOperationUnsupported };
                }

                HistoryDataVariableDataSource datasource = address.Source as HistoryDataVariableDataSource;

                if (datasource == null)
                {
                    return new HistoryUpdateResult() { StatusCode = StatusCodes.BadHistoryOperationUnsupported };
                }

                HistoryUpdateResult result = new HistoryUpdateResult();

                lock (datasource)
                {
                    var table = datasource.GetDataView(false, address.ComponentIndex);

                    for (int ii = 0; ii < details.ReqTimes.Count; ii++)
                    {
                        if (!datasource.DeleteData(table, details.ReqTimes[ii], details.ReqTimes[ii]))
                        {
                            result.OperationResults.Add(StatusCodes.BadNoEntryExists);
                            continue;
                        }

                        result.OperationResults.Add(StatusCodes.Good);
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                return new HistoryUpdateResult() { StatusCode = new StatusCode(e) };
            }
        }
        #endregion

        #region ReadEvent
        protected override HistoryReadResult HistoryReadEvent(
            RequestContext context,
            ReadEventDetails details,
            HistoryEventHandle nodeHandle,
            ref HistoryContinuationPoint continuationPoint)
        {
            HistoryReadResult result = new HistoryReadResult();

            try
            {
                // check for valid source.
                HistoryEventSource source = nodeHandle.NodeData as HistoryEventSource;

                if (source == null)
                {
                    return new HistoryReadResult() { StatusCode = StatusCodes.BadHistoryOperationUnsupported };
                }

                // validate the filter.
                EventFilterResult filterResult = null;
                StatusCode error = m_filterManager.ValidateFilter(context, details.Filter, out filterResult);

                if (error.IsBad())
                {
                    return new HistoryReadResult() { StatusCode = StatusCodes.BadEventFilterInvalid };
                }

                // load an existing request.
                HistoryEventReadRequest request = null;

                if (continuationPoint != null)
                {
                    request = continuationPoint as HistoryEventReadRequest;

                    if (request == null)
                    {
                        return new HistoryReadResult() { StatusCode = StatusCodes.BadContinuationPointInvalid };
                    }

                    continuationPoint = null;
                }

                // create a new request.
                else
                {
                    try
                    {
                        m_filterManager.UpdateReferenceCount(details.Filter, true);

                        request = CreateHistoryReadRequest(
                            context,
                            source,
                            details,
                            nodeHandle);
                    }
                    finally
                    {
                        m_filterManager.UpdateReferenceCount(details.Filter, false);
                    }
                }

                // process values until the max is reached.
                HistoryEvent data = new HistoryEvent();

                while (request.NumValuesPerNode == 0 || data.Events.Count < request.NumValuesPerNode)
                {
                    if (request.Events.Count == 0)
                    {
                        break;
                    }

                    HistoryEventFieldList e = request.Events.First.Value;
                    request.Events.RemoveFirst();
                    data.Events.Add(e);
                }

                if (request.Events.Count > 0)
                {
                    continuationPoint = request;
                }

                // return the events.
                result.HistoryData = new ExtensionObject(data);
            }
            catch (Exception e)
            {
                return new HistoryReadResult() { StatusCode = new StatusCode(e) };
            }

            return result;
        }

        private HistoryEventReadRequest CreateHistoryReadRequest(
            RequestContext context,
            HistoryEventSource source,
            ReadEventDetails details,
            HistoryEventHandle handle)
        {
            bool sizeLimited = (details.StartTime == DateTime.MinValue || details.EndTime == DateTime.MinValue);
            bool timeFlowsBackward = (details.StartTime == DateTime.MinValue) || (details.EndTime != DateTime.MinValue && details.EndTime < details.StartTime);

            LinkedList<HistoryEventFieldList> events = new LinkedList<HistoryEventFieldList>();

            lock (source)
            {
                DataView view = source.GetDataView(details.StartTime, details.EndTime);

                int ii = (timeFlowsBackward) ? view.Count - 1 : 0;

                while (ii >= 0 && ii < view.Count)
                {
                    try
                    {
                        // get the event.
                        GenericEvent e = (GenericEvent)view[ii].Row[4];

                        // apply the filter.
                        if (!FilterManager.Evaluate(context, details.Filter.WhereClause, e))
                        {
                            continue;
                        }

                        // check if absolute max values specified.
                        if (sizeLimited)
                        {
                            if (details.NumValuesPerNode > 0 && details.NumValuesPerNode <= events.Count)
                            {
                                break;
                            }
                        }

                        // get the selected fields.
                        HistoryEventFieldList fields = GetEventFields(context, details.Filter, e);

                        // add to list.
                        events.AddLast(fields);
                    }
                    finally
                    {
                        if (timeFlowsBackward)
                        {
                            ii--;
                        }
                        else
                        {
                            ii++;
                        }
                    }
                }
            }

            HistoryEventReadRequest request = new HistoryEventReadRequest();
            request.Source = source;
            request.Events = events;
            request.NumValuesPerNode = details.NumValuesPerNode;
            return request;
        }

        private class HistoryEventReadRequest : HistoryContinuationPoint
        {
            public HistoryEventSource Source;
            public LinkedList<HistoryEventFieldList> Events;
            public uint NumValuesPerNode;
        }

        private HistoryEventFieldList GetEventFields(RequestContext context, EventFilter filter, GenericEvent e)
        {
            // fetch the event fields.
            HistoryEventFieldList fields = new HistoryEventFieldList();

            foreach (SimpleAttributeOperand clause in filter.SelectClauses)
            {
                // get the value of the attribute (apply localization).
                Variant value = e.Get(clause);

                // add value.
                fields.EventFields.Add(value);
            }

            return fields;
        }
        #endregion

        #region UpdateEvent
        protected override HistoryUpdateResult HistoryUpdateEvent(
            RequestContext context,
            HistoryEventHandle nodeHandle,
            UpdateEventDetails details)
        {
            try
            {
                // check for valid source.
                HistoryEventSource source = nodeHandle.NodeData as HistoryEventSource;

                if (source == null)
                {
                    return new HistoryUpdateResult() { StatusCode = StatusCodes.BadHistoryOperationUnsupported };
                }

                // validate the filter.
                EventFilterResult filterResult = null;
                StatusCode error = m_filterManager.ValidateFilter(context, details.Filter, out filterResult);

                if (error.IsBad())
                {
                    return new HistoryUpdateResult() { StatusCode = StatusCodes.BadEventFilterInvalid };
                }

                // check where clause.
                byte[] targetEventId = null;

                if (details.PerformInsertReplace == PerformUpdateType.Insert)
                {
                    if (details.Filter.WhereClause != null && details.Filter.WhereClause.Elements.Count > 0)
                    {
                        return new HistoryUpdateResult() { StatusCode = StatusCodes.BadContentFilterInvalid };
                    }
                }
                else if (details.PerformInsertReplace == PerformUpdateType.Replace || details.PerformInsertReplace == PerformUpdateType.Update)
                {
                    if (details.Filter.WhereClause == null || details.Filter.WhereClause.Elements.Count != 1)
                    {
                        return new HistoryUpdateResult() { StatusCode = StatusCodes.BadContentFilterInvalid };
                    }

                    if (details.Filter.WhereClause.Elements[0].FilterOperator != FilterOperator.Equals || details.Filter.WhereClause.Elements[0].FilterOperands.Count != 2)
                    {
                        return new HistoryUpdateResult() { StatusCode = StatusCodes.BadContentFilterInvalid };
                    }

                    SimpleAttributeOperand field = null;
                    LiteralOperand target = ExtensionObject.GetObject<LiteralOperand>(details.Filter.WhereClause.Elements[0].FilterOperands[0]);

                    if (target == null)
                    {
                        target = ExtensionObject.GetObject<LiteralOperand>(details.Filter.WhereClause.Elements[0].FilterOperands[1]);
                        field = ExtensionObject.GetObject<SimpleAttributeOperand>(details.Filter.WhereClause.Elements[0].FilterOperands[0]);
                    }
                    else
                    {
                        field = ExtensionObject.GetObject<SimpleAttributeOperand>(details.Filter.WhereClause.Elements[0].FilterOperands[1]);
                    }

                    if (target == null || field == null)
                    {
                        return new HistoryUpdateResult() { StatusCode = StatusCodes.BadContentFilterInvalid };
                    }

                    if (!String.IsNullOrEmpty(field.IndexRange) || field.AttributeId != Attributes.Value || field.TypeDefinitionId != ObjectTypeIds.BaseEventType)
                    {
                        return new HistoryUpdateResult() { StatusCode = StatusCodes.BadContentFilterInvalid };
                    }

                    if (field.BrowsePath == null || field.BrowsePath.Count != 1 || field.BrowsePath[0] != BrowseNames.EventId)
                    {
                        return new HistoryUpdateResult() { StatusCode = StatusCodes.BadContentFilterInvalid };
                    }

                    targetEventId = target.Value.GetValue<byte[]>(ByteString.Null);
                }

                List<int> availableHandles = source.FieldHandles;

                // the mappings store the index in the incoming select clause that maps onto the available handle.
                int[] mappings = new int[availableHandles.Count];

                for (int ii = 0; ii < mappings.Length; ii++)
                {
                    mappings[ii] = -1;
                }

                // validate the select clause.
                HistoryUpdateResult result = new HistoryUpdateResult();

                for (int ii = 0; ii < details.Filter.SelectClauses.Count; ii++)
                {
                    if (!String.IsNullOrEmpty(details.Filter.SelectClauses[ii].IndexRange))
                    {
                        return new HistoryUpdateResult() { StatusCode = StatusCodes.BadInvalidArgument };
                    }

                    if (details.Filter.SelectClauses[ii].AttributeId != Attributes.Value)
                    {
                        return new HistoryUpdateResult() { StatusCode = StatusCodes.BadInvalidArgument };
                    }

                    if (details.Filter.SelectClauses[ii].BrowsePath == null || details.Filter.SelectClauses[ii].BrowsePath.Count == 0)
                    {
                        return new HistoryUpdateResult() { StatusCode = StatusCodes.BadInvalidArgument };
                    }

                    int handle = m_filterManager.GetFieldHandle(AbsoluteName.ToString(details.Filter.SelectClauses[ii].BrowsePath));

                    bool found = false;

                    for (int jj = 0; jj < availableHandles.Count; jj++)
                    {
                        if (availableHandles[jj] == handle)
                        {
                            mappings[jj] = ii;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        result.StatusCode = StatusCodes.GoodDataIgnored;
                    }
                }

                try
                {
                    m_filterManager.UpdateReferenceCount(details.Filter, true);

                    lock (source)
                    {
                        foreach (var e in details.EventData)
                        {
                            StatusCode operationResult = ProcessUpdateRequest(
                                context,
                                source,
                                details.PerformInsertReplace,
                                e,
                                mappings,
                                targetEventId);

                            result.OperationResults.Add(operationResult);
                        }
                    }
                }
                finally
                {
                    m_filterManager.UpdateReferenceCount(details.Filter, false);
                }

                return result;
            }
            catch (Exception e)
            {
                return new HistoryUpdateResult() { StatusCode = new StatusCode(e) };
            }
        }

        private T GetFieldValue<T>(HistoryEventFieldList fields, int[] mappings, int index, T defaultValue)
        {
            if (index < 0 || index >= mappings.Length || mappings[index] < 0)
            {
                return defaultValue;
            }

            return fields.EventFields[mappings[index]].GetValue<T>(defaultValue);
        }

        private StatusCode ProcessUpdateRequest(
            RequestContext context,
            HistoryEventSource source,
            PerformUpdateType updateType,
            HistoryEventFieldList fields,
            int[] mappings,
            byte[] targetEventId)
        {
            int index = 0;

            DateTime time = GetFieldValue<DateTime>(fields, mappings, index++, DateTime.MinValue);
            DateTime receiveTime = GetFieldValue<DateTime>(fields, mappings, index++, DateTime.MinValue);
            byte[] eventId = GetFieldValue<byte[]>(fields, mappings, index++, ByteString.Null);
            NodeId eventTypeId = GetFieldValue<NodeId>(fields, mappings, index++, NodeId.Null);
            string sourceName = GetFieldValue<string>(fields, mappings, index++, String.Empty);
            NodeId sourceNode = GetFieldValue<NodeId>(fields, mappings, index++, NodeId.Null);
            ushort severity = GetFieldValue<ushort>(fields, mappings, index++, 0);
            LocalizedText message = GetFieldValue<LocalizedText>(fields, mappings, index++, LocalizedText.Null);

            if (time == DateTime.MinValue || NodeId.IsNull(eventTypeId) || LocalizedText.IsNullOrEmpty(message))
            {
                return StatusCodes.BadArgumentsMissing;
            }

            if (!Server.TypeManager.IsTypeOf(eventTypeId, ObjectTypeIds.BaseEventType))
            {
                return StatusCodes.BadTypeDefinitionInvalid;
            }

            if (receiveTime == DateTime.MinValue)
            {
                receiveTime = time;
            }

            if (String.IsNullOrEmpty(sourceName))
            {
                sourceName = BrowseNames.Server;
            }

            if (NodeId.IsNull(sourceNode))
            {
                sourceNode = ObjectIds.Server;
            }

            if (severity == 0)
            {
                severity = 500;
            }

            index = 0;

            // create event.
            GenericEvent e = new GenericEvent(m_filterManager);

            e.EventId = eventId;
            e.EventType = eventTypeId;
            e.Time = time;
            e.SourceNode = sourceNode;

            e.Set(source.FieldHandles[index++], time);
            e.Set(source.FieldHandles[index++], receiveTime);
            e.Set(source.FieldHandles[index++], eventId);
            e.Set(source.FieldHandles[index++], eventTypeId);
            e.Set(source.FieldHandles[index++], sourceName);
            e.Set(source.FieldHandles[index++], sourceNode);
            e.Set(source.FieldHandles[index++], severity);
            e.Set(source.FieldHandles[index++], message);

            for (int ii = index; ii < source.FieldHandles.Count; ii++)
            {
                if (mappings[index] >= 0)
                {
                    e.Set(source.FieldHandles[ii], fields.EventFields[mappings[index]]);
                }
            }

            return source.Update(context, updateType, (ByteString)targetEventId, e);
        }
        #endregion

        #region DeleteEvent
        protected override HistoryUpdateResult HistoryDeleteEvent(
            RequestContext context,
            HistoryEventHandle nodeHandle,
            DeleteEventDetails details)
        {
            try
            {
                // check for valid source.
                HistoryEventSource source = nodeHandle.NodeData as HistoryEventSource;

                if (source == null)
                {
                    return new HistoryUpdateResult() { StatusCode = StatusCodes.BadHistoryOperationUnsupported };
                }

                HistoryUpdateResult result = new HistoryUpdateResult();

                lock (source)
                {
                    foreach (byte[] eventId in details.EventIds)
                    {
                        StatusCode error = source.Delete(context, (ByteString)eventId);
                        result.OperationResults.Add(error);
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                return new HistoryUpdateResult() { StatusCode = new StatusCode(e) };
            }
        }
        #endregion

        /// <summary>
        /// Creates a new history request.
        /// </summary>
        private DataValue RowToDataValue(
            RequestContext context,
            TimestampsToReturn timestampsToReturn,
            string indexRange,
            QualifiedName dataEncoding,
            IDataRow row,
            bool applyIndexRangeOrEncoding)
        {
            DataValue value = (DataValue)row.Value;

            value = RemoveTimestampsIfRequired(value, timestampsToReturn);

            // apply any index range or encoding.
            if (applyIndexRangeOrEncoding)
            {
                value = ApplyIndexRangeAndEncoding(value, indexRange, dataEncoding);
            }

            return value;
        }

        private DataValue GetBadNotFound(TimestampsToReturn timestampsToReturn, DateTime time)
        {
            return new DataValue()
            {
                StatusCode = StatusCodes.BadBoundNotFound,
                ServerTimestamp = (timestampsToReturn == TimestampsToReturn.Both || timestampsToReturn == TimestampsToReturn.Server) ? time : DateTime.MinValue,
                SourceTimestamp = (timestampsToReturn == TimestampsToReturn.Both || timestampsToReturn == TimestampsToReturn.Source) ? time : DateTime.MinValue
            };
        }

        DataValue RemoveTimestampsIfRequired(DataValue value, TimestampsToReturn timestampsToReturn)
        {
            switch (timestampsToReturn)
            {
                case TimestampsToReturn.Both:
                    break;
                case TimestampsToReturn.Source:
                    if (value.ServerTimestamp != DateTime.MinValue)
                    {
                        return new DataValue()
                        {
                            Value = value.Value,
                            StatusCode = value.StatusCode,
                            SourceTimestamp = value.SourceTimestamp
                        };
                    }
                    break;
                case TimestampsToReturn.Server:
                    if (value.SourceTimestamp != DateTime.MinValue)
                    {
                        return new DataValue()
                        {
                            Value = value.Value,
                            StatusCode = value.StatusCode,
                            ServerTimestamp = value.ServerTimestamp
                        };
                    }
                    break;
                default:
                    break;
            }
            return value;
        }
        #endregion

        #region Private Fields
        private List<HistoryDataVariableDataSource> m_historyVariables;
        private List<HistoryEventSource> m_historyNotifiers;
        private FilterManager m_filterManager;
#endregion
    }
}
