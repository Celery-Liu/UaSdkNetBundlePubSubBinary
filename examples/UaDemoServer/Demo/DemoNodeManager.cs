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
using System.Data;
using System.Threading;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaServer;

namespace UnifiedAutomation.Demo
{
    internal partial class DemoNodeManager : BaseNodeManager
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="HistoryDataNodeManager"/> class.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="namespaceUris">The namespace uris.</param>
        public DemoNodeManager(ServerManager server, params string[] namespaceUris) : base(server, namespaceUris)
        {
            m_datasources = new List<ValueDataSource>();
            m_historyVariables = new List<HistoryDataVariableDataSource>();
            m_historyNotifiers = new List<HistoryEventSource>();

            var dataView = new DataView();
        }
#endregion

#region IDisposable
        /// <summary>
        /// An overrideable version of the Dispose.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                if (m_animationTimer != null)
                {
                    m_animationTimer.Dispose();
                    m_animationTimer = null;
                }

                if (m_simulationTimer != null)
                {
                    m_simulationTimer.Dispose();
                    m_simulationTimer = null;
                }
            }
        }
#endregion

#region Overridden Methods
        private ushort TypeNamespaceIndex { get; set; }

        /// <summary>
        /// Called when the node manager is started.
        /// </summary>
        public override void Startup()
        {
            try
            {
                // Register types so the OPC UA stack will decode them automatically.
                // Shall be called before calling ImportUaNodeset, if the structured DataTypes within the nodeset shall be decoded.
                Model.EncodeableTypes.RegisterEncodeableTypes(Server.MessageContext);

                TypeNamespaceIndex = AddNamespaceUri(Model.Namespaces.Model);
                ImportUaNodeset(null, "demoserver.xml");

                base.Startup();

                // create a object to produce random data.
                m_generator = new DataGenerator(new RandomSource(1));
                m_generator.NamespaceUris = Server.MessageContext.NamespaceUris;
                m_generator.ServerUris = Server.MessageContext.ServerUris;
                m_generator.MaxArrayLength = 10;
                m_generator.MinArrayLength = 4;
                m_generator.MaxStringLength = 100;
                m_generator.MinStringLength = 4;

                // initialize variables.
                InitializeDataVariables(new NodeId("Demo.Static.Scalar", DefaultNamespaceIndex), SimulationType.None);
                InitializeDataVariables(new NodeId("Demo.Static.Scalar.Structures", DefaultNamespaceIndex), SimulationType.None);
                InitializeDataVariables(new NodeId("Demo.Static.Scalar.OptionSets", DefaultNamespaceIndex), SimulationType.None);
                InitializeDataVariables(new NodeId("Demo.Static.Arrays", DefaultNamespaceIndex), SimulationType.None);
                int maxArrayLength = m_generator.MaxArrayLength;
                m_generator.MaxArrayLength = 130; //increase MaxArrayLength for multidimensional arrays
                InitializeDataVariables(new NodeId("Demo.Static.Matrix", DefaultNamespaceIndex), SimulationType.None);
                InitializeDataVariables(new NodeId("Demo.CTT.Static.AllProfiles.MultiDimensionalArrays", DefaultNamespaceIndex), SimulationType.None);
                m_generator.MaxArrayLength = maxArrayLength; //decrease MaxArrayLength back to default(10)
                InitializeDataVariables(new NodeId("Demo.Dynamic.Scalar", DefaultNamespaceIndex), SimulationType.Random);
                InitializeDataVariables(new NodeId("Demo.Dynamic.Arrays", DefaultNamespaceIndex), SimulationType.Random);
                InitializeDataVariables(new NodeId("Demo.CTT.AllProfiles.Scalar", DefaultNamespaceIndex), SimulationType.None);
                InitializeDataVariables(new NodeId("Demo.CTT.AllProfiles.Arrays", DefaultNamespaceIndex), SimulationType.None);
                InitializeDataVariables(new NodeId("Demo.CTT.DAProfile.DataItem", DefaultNamespaceIndex), SimulationType.None);

                InitializeAnalogs(new NodeId("Demo.CTT.DAProfile.AnalogType", DefaultNamespaceIndex), SimulationType.None);
                InitializeAnalogs(new NodeId("Demo.CTT.DAProfile.AnalogTypeArrays", DefaultNamespaceIndex), SimulationType.None);
                InitializeMultiStates(new NodeId("Demo.CTT.DAProfile.DiscreteType", DefaultNamespaceIndex), SimulationType.None);
                InitializeTwoStates(new NodeId("Demo.CTT.DAProfile.DiscreteType", DefaultNamespaceIndex), SimulationType.None);
                InitializeMultiStateValues(new NodeId(Model.Objects.Demo_CTT_Static_DA_Profile_MultiStateValueDiscreteType, DefaultNamespaceIndex));
                InitializeAnimation();

                AddMissingNodeClassForCtt(new NodeId("Demo.CTT.NodeClasses", DefaultNamespaceIndex), "View1", NodeClass.View);
                AddMissingNodeClassForCtt(new NodeId("Demo.CTT.NodeClasses", DefaultNamespaceIndex), "View2", NodeClass.View);
                UpdateValuesForCtt();

                SetupAccessControl();

                AddMassTestValues(new NodeId("Demo.Massfolder_Static", DefaultNamespaceIndex), SimulationType.None);
                AddMassTestValues(new NodeId("Demo.Massfolder_Dynamic", DefaultNamespaceIndex), SimulationType.Random);
                SetupDataHistory(new NodeId("Demo.History", DefaultNamespaceIndex));
                SetupEventHistory(new NodeId("Demo.History", DefaultNamespaceIndex));
                SetupEvents(new NodeId("Demo.CTT.Events", DefaultNamespaceIndex), new NodeId("Demo.CTT.Events", DefaultNamespaceIndex));
                SetupEvents(new NodeId("Demo.Events", DefaultNamespaceIndex), new NodeId("Demo.Events.SampleEventNotifier", DefaultNamespaceIndex));
                SetupNodeVersioning(new NodeId("Demo.DynamicNodes", DefaultNamespaceIndex));
                SetupLocalizedVariable(new NodeId("Demo.UnicodeTest", DefaultNamespaceIndex));
                SetupSpecialDescriptionVariables();
                SetupBoiler();
                //SetupCTTScalarHistory(new NodeId("Demo.CTT.Static.HAProfile.Scalar", DefaultNamespaceIndex));

                SetupMethodDescriptions();
                SetupSimulation();
                SetupFiles();
                SetupFileDirctory();
                SetupWorkOrderModel();
                SetupGenericDataTypeNodes();
                SetupGenericDataTypeVariables();
                SetupProgramStateMachine();
                SetupSlowVariables();
                SetupSpecialTemporaryFileTransfer();
                //InitializeHistoryValuesForAggregates();
            }
            catch (Exception e)
            {
                TraceServer.Error(e, "Failed to start node manager: " + GetType().Name);
                throw new Exception("Failed to start node manager.", e);
            }
        }

        /// <summary>
        /// Called when the node manager is stopped.
        /// </summary>
        public override void Shutdown()
        {
            try
            {
                DeleteAllTemporaryTransferFiles();
                m_slowDataSourceWrapperAsync.DataSource.Dispose();
                m_slowDataSourceWrapperSync.DataSource.Dispose();
                ShutdownAllEvents();
                StopSimulation(Server.DefaultRequestContext);
                base.Shutdown();
            }
            catch (Exception e)
            {
                TraceServer.Error(e, "Failed to stop node manager: " + GetType().Name);
            }
        }

        /// <summary>
        /// Reads the attribute.
        /// </summary>
        protected override DataValue Read(
            RequestContext context,
            NodeAttributeHandle nodeHandle,
            string indexRange,
            QualifiedName dataEncoding)
        {
            SlowDataSourceWrapper slowDataSourceWrapper = nodeHandle.UserData as SlowDataSourceWrapper;
            if (slowDataSourceWrapper != null)
            {
                return ReadSlowVariables(context, nodeHandle, indexRange, dataEncoding);
            }

            // the data passed to CreateVariable is returned as the UserData in the handle.
            DataSourceAddress address = nodeHandle.UserData as DataSourceAddress;

            if (address == null)
            {
                // handle the historizing attribute.
                if (nodeHandle.AttributeId == Attributes.Historizing)
                {
                    address = nodeHandle.NodeData as DataSourceAddress;

                    if (address != null)
                    {
                        HistoryDataVariableDataSource hds = address.Source as HistoryDataVariableDataSource;

                        if (hds != null)
                        {
                            return new DataValue() { WrappedValue = hds.Historizing, ServerTimestamp = DateTime.UtcNow, SourceTimestamp = DateTime.UtcNow };
                        }
                    }
                }

                return base.Read(context, nodeHandle, indexRange, dataEncoding);
            }

            DataValue dv = null;

            // get the data source.
            ValueDataSource datasource = address.Source;

            // check general access.
            if ((datasource.AccessLevel & AccessLevels.CurrentRead) == 0)
            {
                return new DataValue(StatusCodes.BadNotReadable);
            }

            if (CannotPassNodeAccessChecks(context, nodeHandle, UserAccessMask.Read, out StatusCode statusCode))
            {
                return new DataValue(statusCode);
            }

            // read the value.
            lock (datasource.Lock)
            {
                dv = datasource.Read(address.ComponentIndex);

                if (dv.StatusCode.IsBad())
                {
                    return dv;
                }
            }

            // apply the index range.
            if (!String.IsNullOrEmpty(indexRange))
            {
                if (dv.WrappedValue.TypeInfo.ValueRank < 0 && (dv.WrappedValue.TypeInfo.BuiltInType != BuiltInType.ByteString && dv.WrappedValue.TypeInfo.BuiltInType != BuiltInType.String))
                {
                    return new DataValue() { StatusCode = StatusCodes.BadIndexRangeNoData };
                }

                return ApplyIndexRangeAndEncoding(nodeHandle, dv, indexRange, dataEncoding);
            }

            // apply the data encoding.
            if (!QualifiedName.IsNull(dataEncoding))
            {
                return ApplyIndexRangeAndEncoding(nodeHandle, dv, null, dataEncoding);
            }

            // return the raw value.
            return dv;
        }

        /// <summary>
        /// Writes the specified context.
        /// </summary>
        protected override StatusCode? Write(
            RequestContext context,
            NodeAttributeHandle nodeHandle,
            string indexRange,
            DataValue value)
        {
            SlowDataSourceWrapper slowDataSourceWrapper = nodeHandle.UserData as SlowDataSourceWrapper;
            if (slowDataSourceWrapper != null)
            {
                return WriteSlowVariables(context, nodeHandle, indexRange, value);
            }

            // the data passed to CreateVariable is returned as the UserData in the handle.
            DataSourceAddress address = nodeHandle.UserData as DataSourceAddress;

            if (address == null)
            {
                if (nodeHandle.UserData is MappedNode)
                {
                    ModelMapping mapping = (nodeHandle.UserData as MappedNode).Mapping;
                    AnalogItemModel<double> model = mapping.Instance as AnalogItemModel<double>;
                    if (model != null)
                    {
                        double dValue = value.WrappedValue.ToDouble();
                        if (model.EURange != null && (model.EURange.Low > dValue || model.EURange.High < dValue))
                        {
                            return StatusCodes.BadOutOfRange;
                        }
                    }
                }
                return base.Write(context, nodeHandle, indexRange, value);
            }

            DataValue currentValue = address.Source.Read(address.ComponentIndex);
            bool change = !Utils.IsEqual(currentValue.WrappedValue, value.WrappedValue)
                || currentValue.StatusCode != value.StatusCode;

            // TraceServer.Error("WRITE ({0}) {2}: {1}", nodeHandle.NodeId, value.WrappedValue, change);

            StatusCode error = StatusCodes.Good;

            // get the data source.
            ValueDataSource datasource = address.Source;

            // check general access.
            if ((datasource.AccessLevel & AccessLevels.CurrentWrite) == 0)
            {
                return StatusCodes.BadNotWritable;
            }

            // source timestamp writes not supported.
            if ((datasource.AccessLevel & AccessLevels.TimestampWrite) == 0
                && (value.SourceTimestamp != DateTime.MinValue || value.ServerTimestamp != DateTime.MinValue))
            {
                return StatusCodes.BadWriteNotSupported;
            }

            // writing StatusCode is not supported
            if (value.StatusCode != StatusCodes.Good)
            {
                if ((datasource.AccessLevel & AccessLevels.StatusWrite) == 0)
                {
                    return StatusCodes.BadWriteNotSupported;
                }
            }

            if (CannotPassNodeAccessChecks(context, nodeHandle, UserAccessMask.Write, out StatusCode statusCode))
            {
                return statusCode;
            }

            // write to the data.
            Variant newValue = value.WrappedValue;

            lock (datasource.Lock)
            {
                // check if index range is specified.
                if (!String.IsNullOrEmpty(indexRange))
                {
                    // get the existing value.
                    DataValue dv = datasource.Read(address.ComponentIndex);

                    if (dv.StatusCode.IsBad())
                    {
                        return StatusCodes.BadIndexRangeNoData;
                    }

                    // apply index range.
                    object target = dv.Value;
                    TypeInfo targetType = dv.WrappedValue.TypeInfo;

                    try
                    {
                        NumericRange range = NumericRange.Parse(indexRange);

                        target = TypeUtils.Clone(target);

                        error = range.UpdateRange(ref target, newValue.Value);

                        if (StatusCode.IsBad(error))
                        {
                            return error;
                        }

                        newValue = new Variant(target, targetType);
                    }
                    catch (Exception e)
                    {
                        return new StatusCode(e);
                    }
                }

                // write the new value.
                error = datasource.Write(address.ComponentIndex, newValue, value.StatusCode, value.SourceTimestamp);

                // report any change on success.
                if (error.IsGood())
                {
                    ReportChange(context, address.Source, address.ComponentIndex, false, change);
                }
            }

            return error;
        }

        /// <summary>
        /// Starts the data monitoring.
        /// </summary>
        protected override DataMonitoringResult StartDataMonitoring(
            RequestContext context,
            MonitoredItemHandle itemHandle,
            MonitoredItemCreateRequest settings,
            DataChangeEventHandler callback)
        {
            if (itemHandle.NodeHandle.UserData is SlowDataSourceWrapper)
            {
                return StartDataMonitoringSlowVariables(context, itemHandle, settings, callback);
            }

            // the data passed to CreateVariable is returned as the UserData in the handle.
            DataSourceAddress address = itemHandle.NodeHandle.UserData as DataSourceAddress;

            if (address == null)
            {
                return base.StartDataMonitoring(context, itemHandle, settings, callback);
            }

            // get the data source.
            ValueDataSource datasource = address.Source;

            /*
             * When a user adds a monitored item that the user is denied read access to, the add operation
             * for the item shall succeed and the bad status Bad_NotReadable or Bad_UserAccessDenied shall
             * be returned in the Publish response.
             */
            // check general access.
            //if ((datasource.AccessLevel & AccessLevels.CurrentRead) == 0)
            //{
            //    return new DataMonitoringResult() { StatusCode = StatusCodes.BadNotReadable };
            //}

            //// check user access.
            //if (!HasAccess(context, address, UserAccessMask.Read))
            //{
            //    return new DataMonitoringResult() { StatusCode = StatusCodes.BadUserAccessDenied };
            //}

            // TraceServer.Error("START ({0}) '{1}'", itemHandle.NodeId, settings.MonitoringMode);

            // validate request.
            DataMonitoringResult result = Server.ValidateDataMonitoringRequest(
                context,
                itemHandle.NodeHandle,
                settings.ItemToMonitor,
                settings.RequestedParameters,
                null);

            if (result.StatusCode.IsBad())
            {
                return result;
            }

            lock (address.Source.Lock)
            {
                DataChangeTrigger dataChangeTrigger = DataChangeTrigger.StatusValue;
                if (settings.RequestedParameters.Filter != null && settings.RequestedParameters.Filter.Body != null)
                {
                    DataChangeFilter dataChangeFilter = ExtensionObject.GetObject<DataChangeFilter>(settings.RequestedParameters.Filter);
                    if (dataChangeFilter != null)
                    {
                        dataChangeTrigger = dataChangeFilter.Trigger;
                    }
                }
                // start monitoring.
                datasource.StartMonitoring(
                    address.ComponentIndex,
                    itemHandle,
                    settings.ItemToMonitor.IndexRange,
                    settings.ItemToMonitor.DataEncoding,
                    settings.MonitoringMode,
                    dataChangeTrigger,
                    callback);

                // report the initial value.
                ReportChange(context, address.Source, address.ComponentIndex, true);
            }

            return result;
        }

        /// <summary>
        /// Modifies the data monitoring.
        /// </summary>
        protected override DataMonitoringResult ModifyDataMonitoring(
            RequestContext context,
            MonitoredItemHandle itemHandle,
            MonitoredItemModifyRequest settings)
        {
            if (itemHandle.NodeHandle.UserData is SlowDataSourceWrapper)
            {
                return ModifyDataMonitoringSlowVariables(context, itemHandle, settings);
            }

            // the data passed to CreateVariable is returned as the UserData in the handle.
            DataSourceAddress address = itemHandle.NodeHandle.UserData as DataSourceAddress;

            if (address == null)
            {
                return base.ModifyDataMonitoring(context, itemHandle, settings);
            }

            // validate request.
            DataMonitoringResult result = Server.ValidateDataMonitoringRequest(
                context,
                itemHandle.NodeHandle,
                null,
                settings.RequestedParameters,
                null);

            if (result.StatusCode.IsBad())
            {
                return result;
            }

            if (address.Source.MonitoredItems != null)
            {
                DataChangeTrigger trigger = DataChangeTrigger.StatusValue;
                if (settings.RequestedParameters.Filter != null
                    && settings.RequestedParameters.Filter.Body != null)
                {
                    trigger = ExtensionObject.GetObject<DataChangeFilter>(settings.RequestedParameters.Filter).Trigger;
                }
                foreach (var monitoredItem in address.Source.MonitoredItems)
                {
                    monitoredItem.DataChangeTrigger = trigger;
                }
            }

            return result;
        }

        /// <summary>
        /// Stops the data monitoring.
        /// </summary>
        protected override StatusCode? StopDataMonitoring(RequestContext context, MonitoredItemHandle itemHandle)
        {
            if (itemHandle.NodeHandle.UserData is SlowDataSourceWrapper)
            {
                return StopDataMonitoringSlowVariables(context, itemHandle);
            }

            // the data passed to CreateVariable is returned as the UserData in the handle.
            DataSourceAddress address = itemHandle.NodeHandle.UserData as DataSourceAddress;

            if (address == null)
            {
                return base.StopDataMonitoring(context, itemHandle);
            }

            // stop monitoring.
            lock (address.Source.Lock)
            {
                address.Source.StopMonitoring(address.ComponentIndex, itemHandle.MonitoredItemId);
            }

            return StatusCodes.Good;
        }

        /// <summary>
        /// Modifies the data monitoring.
        /// </summary>
        protected override StatusCode? SetDataMonitoringMode(
            RequestContext context,
            MonitoredItemHandle itemHandle,
            MonitoringMode monitoringMode,
            MonitoringParameters parameters)
        {
            if (itemHandle.NodeHandle.UserData is SlowDataSourceWrapper)
            {
                return SetDataMonitoringModeSlowVariables(context, itemHandle, monitoringMode, parameters);
            }

            // the data passed to CreateVariable is returned as the UserData in the handle.
            DataSourceAddress address = itemHandle.NodeHandle.UserData as DataSourceAddress;

            if (address == null)
            {
                return base.SetDataMonitoringMode(context, itemHandle, monitoringMode, parameters);
            }

            lock (address.Source.Lock)
            {
                address.Source.SetMonitoringMode(address.ComponentIndex, itemHandle.MonitoredItemId, monitoringMode);

                if (monitoringMode != MonitoringMode.Disabled)
                {
                    ReportChange(context, address.Source, address.ComponentIndex, true);
                }
            }

            return StatusCodes.Good;
        }

        /// <summary>
        /// Determines whether the specified context has permission to delete nodes.
        /// </summary>
        protected override bool HasAccessToDeleteNode(RequestContext context, NodeId nodeToDelete)
        {
            if (nodeToDelete == new NodeId("Demo.DynamicNodes.DynamicNode", DefaultNamespaceIndex))
            {
                return true;
            }

            return base.HasAccessToDeleteNode(context, nodeToDelete);
        }

        /// <summary>
        /// Afters the add reference.
        /// </summary>
        protected override void AfterAddReference(
            RequestContext context,
            Node node,
            NodeId referenceTypeId,
            bool isInverse,
            ExpandedNodeId targetId)
        {
            if (!UpdateNodeVersion(context, node, ModelChangeStructureVerbMask.ReferenceAdded))
            {
                base.AfterAddReference(context, node, referenceTypeId, isInverse, targetId);
            }
        }

        protected override void AfterDeleteReference(
            RequestContext context,
            Node node,
            NodeId referenceTypeId,
            bool isInverse,
            ExpandedNodeId targetId)
        {
            if (!UpdateNodeVersion(context, node, ModelChangeStructureVerbMask.ReferenceDeleted))
            {
                base.AfterDeleteReference(context, node, referenceTypeId, isInverse, targetId);
            }
        }
#endregion

#region Private Methods
        private void SetupLocalizedVariable(NodeId parentId)
        {
            // add translations (can be loaded from a file).
            // translations require a complete locale with region to be specified here, however,
            // the SDK will match on the language if a region specific translation is not found.
            // i.e. a client that specifies de-AT will get de-DE translations.
            /// [LocalizedData Example]
            Server.ResourceManager.Add("IDS_HELLO_WORLD", "en-US", "Hello World");
            Server.ResourceManager.Add("IDS_HELLO_WORLD", "de-DE", "Hallo Welt");
            Server.ResourceManager.Add("IDS_HELLO_WORLD", "fr-CA", "Bonjour tout le monde");
            Server.ResourceManager.Add("IDS_LIGHT_RED", "en-US", "Red");
            Server.ResourceManager.Add("IDS_LIGHT_RED", "de-DE", "Rot");
            Server.ResourceManager.Add("IDS_LIGHT_RED", "fr-CA", "Rouge");
            Server.ResourceManager.Add("IDS_LIGHT_GREEN", "en-US", "Green");
            Server.ResourceManager.Add("IDS_LIGHT_GREEN", "de-DE", "Grün");
            Server.ResourceManager.Add("IDS_LIGHT_GREEN", "fr-CA", "Verte");
            /// [LocalizedData Example]

            // initialize the text with the KEY that is used to look up translations.
            // the default text is the fallback for unsupported locales.
            // in this example, the KEY is repeated so it is clear in testing when the default text is returned.
            var text = new LocalizedText("IDS_HELLO_WORLD", "", "IDS_HELLO_WORLD");

            CreateVariableSettings settings = new CreateVariableSettings()
            {
                ParentNodeId = parentId,
                ReferenceTypeId = ReferenceTypeIds.HasComponent,
                RequestedNodeId = new NodeId(parentId.Identifier.ToString() + ".IDS_HELLO_WORLD", DefaultNamespaceIndex),
                BrowseName = new QualifiedName("IDS_HELLO_WORLD", DefaultNamespaceIndex),
                DisplayName = text,
                Description = text,
                DataType = DataTypeIds.LocalizedText,
                ValueRank = ValueRanks.OneDimension,
                Value = new LocalizedText[] { new LocalizedText("IDS_LIGHT_RED", "", "IDS_LIGHT_RED"), new LocalizedText("IDS_LIGHT_GREEN", "", "IDS_LIGHT_GREEN") }
            };

            CreateVariable(Server.DefaultRequestContext, settings);
        }

        private void SetupSpecialDescriptionVariables()
        {
            // LongDescription
            Node node = FindInMemoryNode(new NodeId(Model.Variables.Demo_UnicodeTest_LongDescription, DefaultNamespaceIndex));
            if (node != null)
            {
                lock (InMemoryNodeLock)
                {
                    int length = 80 * 1024;
                    char[] content = new char[length];
                    int a = 'a';
                    for (int i=0; i<length; i++)
                    {
                        content[i] = (char)((a + (i % 26)));
                    }

                    LocalizedText description = new LocalizedText(new string(content));
                    node.Description = description;
                }
            }

            node = FindInMemoryNode(new NodeId(Model.Variables.Demo_UnicodeTest_MultiLingualDescription, DefaultNamespaceIndex));
            if (node != null)
            {
                Server.ResourceManager.Add("MULTILINGUAL_SECRIPTION", "en-US", "English Description");
                Server.ResourceManager.Add("MULTILINGUAL_SECRIPTION", "de-DE", "Deutsche Bescreibung");
                lock (InMemoryNodeLock)
                {
                    LocalizedText description = new LocalizedText("MULTILINGUAL_SECRIPTION", null, "MULTILINGUAL_SECRIPTION");
                    node.Description = description;
                }
            }
        }

        private void AddMissingNodeClassForCtt(NodeId baseId, string newNodeName, NodeClass newNodeClass)
        {
            object[] MissingNodeClassNodes = new object[]
            {
                newNodeName, newNodeClass,
            };

            LocalizedText description = new LocalizedText("This node is added for the Compliance Test Tool of OPC foundation");
            for (int ii = 0; ii < MissingNodeClassNodes.Length; ii += 2)
            {
                string name = (string)MissingNodeClassNodes[ii];
                NodeClass nodeClass = (NodeClass)MissingNodeClassNodes[ii + 1];
                NodeId nodeId = new NodeId(baseId.Identifier.ToString() + "." + name, baseId.NamespaceIndex);

                switch (nodeClass)
                {
                    case NodeClass.Object:
                    {
                        CreateObjectSettings settings = new CreateObjectSettings()
                        {
                            ParentNodeId = baseId,
                            ReferenceTypeId = ReferenceTypeIds.Organizes,
                            RequestedNodeId = nodeId,
                            BrowseName = new QualifiedName(name, DefaultNamespaceIndex),
                            DisplayName = name
                        };

                        CreateObject(Server.DefaultRequestContext, settings);
                        break;
                    }

                    case NodeClass.Variable:
                    {
                        CreateVariableSettings settings = new CreateVariableSettings()
                        {
                            ParentNodeId = baseId,
                            ReferenceTypeId = ReferenceTypeIds.Organizes,
                            RequestedNodeId = nodeId,
                            BrowseName = new QualifiedName(name, DefaultNamespaceIndex),
                            DisplayName = name,
                            Description = description,
                            AccessLevel = AccessLevels.CurrentReadOrWrite,
                            DataType = DataTypeIds.BaseDataType,
                            ValueRank = ValueRanks.Scalar,
                            MinimumSamplingInterval = 0,
                            Historizing = false,
                            TypeDefinitionId = VariableTypeIds.BaseDataVariableType
                        };

                        CreateVariable(Server.DefaultRequestContext, settings);
                        break;
                    }

                    case NodeClass.Method:
                    {
                        CreateMethodSettings settings = new CreateMethodSettings()
                        {
                            ParentNodeId = baseId,
                            ReferenceTypeId = ReferenceTypeIds.Organizes,
                            RequestedNodeId = nodeId,
                            BrowseName = new QualifiedName(name, DefaultNamespaceIndex),
                            DisplayName = name,
                            Description = description
                        };

                        CreateMethod(Server.DefaultRequestContext, settings);
                        break;
                    }

                    case NodeClass.View:
                    {
                        CreateViewSettings settings2 = new CreateViewSettings()
                        {
                            ParentNodeId = ObjectIds.ViewsFolder,
                            ReferenceTypeId = ReferenceTypeIds.Organizes,
                            RequestedNodeId = nodeId,
                            BrowseName = new QualifiedName(name, DefaultNamespaceIndex),
                            DisplayName = name,
                            Description = description
                        };

                        CreateView(Server.DefaultRequestContext, settings2);
                        AddReference(Server.DefaultRequestContext, baseId, ReferenceTypeIds.Organizes, false, nodeId, true);
                        break;
                    }

                    case NodeClass.ObjectType:
                    {
                        CreateObjectTypeSettings settings2 = new CreateObjectTypeSettings()
                        {
                            ParentNodeId = ObjectTypeIds.BaseObjectType,
                            ReferenceTypeId = ReferenceTypeIds.HasSubtype,
                            RequestedNodeId = nodeId,
                            BrowseName = new QualifiedName(name, DefaultNamespaceIndex),
                            DisplayName = name,
                            Description = description,
                            IsAbstract = false
                        };

                        CreateObjectTypeNode(Server.DefaultRequestContext, settings2);
                        AddReference(Server.DefaultRequestContext, baseId, ReferenceTypeIds.Organizes, false, nodeId, true);
                        break;
                    }

                    case NodeClass.VariableType:
                    {
                        CreateVariableTypeSettings settings2 = new CreateVariableTypeSettings()
                        {
                            ParentNodeId = VariableTypeIds.BaseDataVariableType,
                            ReferenceTypeId = ReferenceTypeIds.HasSubtype,
                            RequestedNodeId = nodeId,
                            BrowseName = new QualifiedName(name, DefaultNamespaceIndex),
                            DisplayName = name,
                            Description = description,
                            IsAbstract = false,
                            DataType = DataTypeIds.BaseDataType,
                            ValueRank = ValueRanks.Scalar
                        };

                        CreateVariableTypeNode(Server.DefaultRequestContext, settings2);
                        AddReference(Server.DefaultRequestContext, baseId, ReferenceTypeIds.Organizes, false, nodeId, true);
                        break;
                    }

                    case NodeClass.DataType:
                    {
                        CreateDataTypeSettings settings2 = new CreateDataTypeSettings()
                        {
                            ParentNodeId = DataTypeIds.BaseDataType,
                            ReferenceTypeId = ReferenceTypeIds.HasSubtype,
                            RequestedNodeId = nodeId,
                            BrowseName = new QualifiedName(name, DefaultNamespaceIndex),
                            DisplayName = name,
                            Description = description,
                            IsAbstract = false
                        };

                        CreateDataTypeNode(Server.DefaultRequestContext, settings2);
                        AddReference(Server.DefaultRequestContext, baseId, ReferenceTypeIds.Organizes, false, nodeId, true);
                        break;
                    }

                    case NodeClass.ReferenceType:
                    {
                        CreateReferenceTypeSettings settings = new CreateReferenceTypeSettings()
                        {
                            ParentNodeId = ReferenceTypeIds.NonHierarchicalReferences,
                            ReferenceTypeId = ReferenceTypeIds.HasSubtype,
                            RequestedNodeId = nodeId,
                            BrowseName = new QualifiedName(name, DefaultNamespaceIndex),
                            DisplayName = name,
                            Description = description,
                            IsAbstract = false,
                            Symmetric = true,
                            InverseName = null
                        };

                        CreateReferenceTypeNode(Server.DefaultRequestContext, settings);
                        AddReference(Server.DefaultRequestContext, baseId, ReferenceTypeIds.Organizes, false, nodeId, true);
                        break;
                    }
                }
            }
        }

        private void UpdateValuesForCtt()
        {
            // The test scripts in CTT have some issues. We need to update some variable values.
            // After the scripts have been fixed, these workoraunds will be removed.
            NodeAttributeHandle handle;
            GetNodeHandle(
                Server.DefaultRequestContext,
                Demo.Model.VariableIds.Demo_CTT_Static_All_Profiles_Arrays_Float.ToNodeId(Server.NamespaceUris),
                Attributes.Value,
                out handle);
            var dsa = handle.UserData as DataSourceAddress;
            DataVariableDataSource ds = dsa.Source as DataVariableDataSource;
            float[] floats = ds.Value.ToFloatArray();
            floats[0] = 10;
            ds.Value = new Variant(floats);

            // And a workaround for a bug that came in ctt 1.2.336.256
            GetNodeHandle(
                Server.DefaultRequestContext,
                Demo.Model.VariableIds.Demo_CTT_Static_All_Profiles_Scalar_Float.ToNodeId(Server.NamespaceUris),
                Attributes.Value,
                out handle);
            dsa = handle.UserData as DataSourceAddress;
            ds = dsa.Source as DataVariableDataSource;
            ds.Value = new Variant((float) 0);

            // Workaround for issue with matrix values with big integers, Monitored Item Services > Monitor Value Change > 042.js
            var results = Server.InternalClient.Write(Server.DefaultRequestContext, new List<WriteValue>()
            {
                new WriteValue()
                {
                    NodeId = Demo.Model.VariableIds.Demo_CTT_Static_All_Profiles_MultiDimensionalArrays_Int64.ToNodeId(Server.NamespaceUris),
                    AttributeId = Attributes.Value,
                    IndexRange = "1,1,1",
                    Value = new DataValue()
                    {
                        Value = new Matrix(new long[] {1000000000000000}, BuiltInType.Int64, 1, 1, 1)
                    }
                },
                new WriteValue()
                {
                    NodeId = Demo.Model.VariableIds.Demo_CTT_Static_All_Profiles_MultiDimensionalArrays_UInt64.ToNodeId(Server.NamespaceUris),
                    AttributeId = Attributes.Value,
                    IndexRange = "1,1,1",
                    Value = new DataValue()
                    {
                        Value = new Matrix(new ulong[] {1000000000000000}, BuiltInType.UInt64, 1, 1, 1)
                    }
                },
                new WriteValue()
                {
                    NodeId = Demo.Model.VariableIds.Demo_CTT_Static_All_Profiles_MultiDimensionalArrays_Double.ToNodeId(Server.NamespaceUris),
                    AttributeId = Attributes.Value,
                    IndexRange = "1,1,1",
                    Value = new DataValue()
                    {
                        Value = new Matrix(new double[] {12}, BuiltInType.Double, 1, 1, 1)
                    }
                },
                new WriteValue()
                {
                    NodeId = Demo.Model.VariableIds.Demo_CTT_Static_All_Profiles_MultiDimensionalArrays_Variant.ToNodeId(Server.NamespaceUris),
                    AttributeId = Attributes.Value,
                    IndexRange = "1,1,1",
                    Value = new DataValue()
                    {
                        Value = new Matrix(new Variant[] {new Variant(12.0)}, BuiltInType.Variant, 1, 1, 1)
                    }
                },
            });
        }

        private void InitializeDataVariables(NodeId baseId, SimulationType simulationType)
        {
            Node folder = FindInMemoryNode(baseId);

            foreach (ReferenceNode reference in folder.FindReferences(UnifiedAutomation.UaBase.ReferenceTypeIds.HierarchicalReferences, false, true, Server.TypeManager))
            {
                VariableNode variable = FindInMemoryNode((NodeId)reference.TargetId) as VariableNode;

                if (variable == null)
                {
                    continue;
                }

                if (variable.NodeId.IdType == IdType.String &&
                    simulationType != SimulationType.None &&
                    ((string)variable.NodeId.Identifier).StartsWith("Demo.Dynamic.Scalar"))
                {
                    // The next 2 variables are simulating a sawtooth and a sine. The values are also
                    // used for ByteWithHistory and DoubleWithHistory.
                    if (variable.NodeId == new NodeId(Model.Variables.Demo_Dynamic_Scalar_Byte, DefaultNamespaceIndex))
                    {
                        SawToothDataSource sawTooth = new SawToothDataSource()
                        {
                            TypeInfo = new TypeInfo(variable.DataType, variable.ValueRank, Server.TypeManager),
                            Timestamp = DateTime.UtcNow,
                            Status = StatusCodes.Good,
                            SimulationType = simulationType,
                            AccessLevel = variable.AccessLevel
                        };
                        m_datasources.Add(sawTooth);
                        SetVariableConfiguration(variable.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(sawTooth, 0));
                        continue;
                    }
                    else if (variable.NodeId == new NodeId(Model.Variables.Demo_Dynamic_Scalar_Double, DefaultNamespaceIndex))
                    {
                        SineDataSource sine = new SineDataSource()
                        {
                            TypeInfo = new TypeInfo(variable.DataType, variable.ValueRank, Server.TypeManager),
                            Timestamp = DateTime.UtcNow,
                            Status = StatusCodes.Good,
                            SimulationType = simulationType,
                            AccessLevel = variable.AccessLevel
                        };
                        m_datasources.Add(sine);
                        SetVariableConfiguration(variable.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(sine, 0));
                        continue;
                    }
                    else if (variable.NodeId == new NodeId(Model.Variables.Demo_Dynamic_Scalar_UInt32, DefaultNamespaceIndex))
                    {
                        IncrementDataSource increment = new IncrementDataSource()
                        {
                            TypeInfo = new TypeInfo(variable.DataType, variable.ValueRank, Server.TypeManager),
                            Timestamp = DateTime.UtcNow,
                            Status = StatusCodes.Good,
                            SimulationType = simulationType,
                            AccessLevel = variable.AccessLevel
                        };
                        m_datasources.Add(increment);
                        SetVariableConfiguration(variable.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(increment, 0));
                        continue;
                    }
                    // Different status codes for DataValues
                    else if (variable.NodeId == new NodeId(Model.Variables.Demo_Dynamic_Scalar_Quality_StaticValue, DefaultNamespaceIndex))
                    {
                        QualityDataSourceStaticValue quality = new QualityDataSourceStaticValue()
                        {
                            TypeInfo = new TypeInfo(variable.DataType, variable.ValueRank, Server.TypeManager),
                            Timestamp = DateTime.UtcNow,
                            Status = StatusCodes.Good,
                            SimulationType = simulationType,
                            AccessLevel = variable.AccessLevel
                        };
                        m_datasources.Add(quality);
                        quality.Value = new Variant((double)47.11);
                        SetVariableConfiguration(variable.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(quality, 0));
                        continue;
                    }
                    else if (variable.NodeId == new NodeId(Model.Variables.Demo_Dynamic_Scalar_Quality_DynamicValue, DefaultNamespaceIndex))
                    {
                        QualityDataSourceDynamicValue quality = new QualityDataSourceDynamicValue()
                        {
                            TypeInfo = new TypeInfo(variable.DataType, variable.ValueRank, Server.TypeManager),
                            Timestamp = DateTime.UtcNow,
                            Status = StatusCodes.Good,
                            SimulationType = simulationType,
                            AccessLevel = variable.AccessLevel
                        };
                        m_datasources.Add(quality);
                        SetVariableConfiguration(variable.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(quality, 0));
                        continue;
                    }
                }

                DataVariableDataSource data = new DataVariableDataSource()
                {
                    TypeInfo = new TypeInfo(variable.DataType, variable.ValueRank, Server.TypeManager),
                    Timestamp = DateTime.UtcNow,
                    Status = StatusCodes.Good,
                    SimulationType = simulationType,
                    AccessLevel = variable.AccessLevel
                };

                // skipping image variables and ServerState enum. Value from XML file is used.
                if (variable.DataType.NamespaceIndex == 0)
                {
                    bool skip = false;

                    switch ((uint)variable.DataType.Identifier)
                    {
                        case DataTypes.Image:
                        case DataTypes.ImageBMP:
                        case DataTypes.ImageGIF:
                        case DataTypes.ImageJPG:
                        case DataTypes.ImagePNG:
                        case DataTypes.ServerState:
                            data.Value = variable.Value;
                            SetVariableConfiguration(variable.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(data, 0));
                            skip = true;
                            break;
                    }

                    if (skip)
                    {
                        continue;
                    }
                }

                // simulation of structure and enum values
                if (variable.DataType.NamespaceIndex == TypeNamespaceIndex || variable.DataType == DataTypeIds.Structure)
                {
                    InitializeCustomDataTypes(variable, simulationType);
                    continue;
                }

                data.GenerateRandomValue(m_generator);

                // add variable to simulation list.
                if (simulationType != SimulationType.None)
                {
                    lock (m_datasources)
                    {
                        m_datasources.Add(data);
                    }
                }

                SetVariableConfiguration(variable.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(data, 0));
            }
        }

        private void InitializeCustomDataTypes(VariableNode variable, SimulationType simulationType)
        {
            if (variable.DataType.Identifier.Equals(Model.DataTypes.WorkOrderType) || variable.DataType == DataTypeIds.Structure)
            {
                var wo = new Model.WorkOrderType()
                {
                    ID = Guid.NewGuid(),
                    AssetID = Guid.NewGuid().ToString(),
                    StartTime = DateTime.UtcNow,
                    StatusComments = new Model.WorkOrderStatusTypeCollection()
                };

                wo.StatusComments.Add(new Model.WorkOrderStatusType()
                {
                    Actor = m_generator.GetRandomString(),
                    Comment = m_generator.GetRandomLocalizedText(),
                    Timestamp = DateTime.UtcNow
                });

                wo.StatusComments.Add(new Model.WorkOrderStatusType()
                {
                    Actor = m_generator.GetRandomString(),
                    Comment = m_generator.GetRandomLocalizedText(),
                    Timestamp = DateTime.UtcNow
                });

                wo.StatusComments.Add(new Model.WorkOrderStatusType()
                {
                    Actor = m_generator.GetRandomString(),
                    Comment = m_generator.GetRandomLocalizedText(),
                    Timestamp = DateTime.UtcNow
                });

                if (variable.ValueRank == ValueRanks.Scalar)
                {
                    variable.Value = new Variant(new ExtensionObject(wo));
                }
                else if (variable.ValueRank == ValueRanks.OneDimension)
                {
                    int size = 5;
                    ExtensionObjectCollection extensionObjets = new ExtensionObjectCollection(size);
                    for (int i = 0; i < size; i++)
                    {
                        extensionObjets.Add(new ExtensionObject(wo));
                    }
                    variable.Value = new Variant(extensionObjets);
                }
            }

            else if (variable.DataType.Identifier.Equals(Model.DataTypes.Vector))
            {
                var vector = new Model.Vector()
                {
                    X = 1.11,
                    Y = 2.22,
                    Z = 3.33
                };

                if (variable.ValueRank == ValueRanks.Scalar)
                {
                    variable.Value = new Variant(new ExtensionObject(vector));
                }
                else if (variable.ValueRank == ValueRanks.OneDimension)
                {
                    int size = 5;
                    ExtensionObjectCollection extensionObjets = new ExtensionObjectCollection(size);
                    for (int i=0; i<size; i++)
                    {
                        extensionObjets.Add(new ExtensionObject(vector));
                    }
                    variable.Value = new Variant(extensionObjets);
                }
            }

            else if (variable.DataType.Identifier.Equals(Model.DataTypes.UnionTest))
            {
                var union = new Model.UnionTest();
                union.String = "StringValue";
                if (variable.ValueRank == ValueRanks.Scalar)
                {
                    variable.Value = new Variant(new ExtensionObject(union));
                }
                else if (variable.ValueRank == ValueRanks.OneDimension)
                {
                    int size = 5;
                    ExtensionObjectCollection extensionObjets = new ExtensionObjectCollection(size);
                    for (int i = 0; i < size; i++)
                    {
                        extensionObjets.Add(new ExtensionObject(union));
                    }
                    variable.Value = new Variant(extensionObjets);
                }
            }

            else if (variable.DataType.Identifier.Equals(Model.DataTypes.StructureWithOptionalFields))
            {
                int size = 5;
                var structure = new Model.StructureWithOptionalFields();
                structure.MandatoryInt32 = m_generator.GetRandomInt32();
                structure.MandatoryStringArray = new StringCollection(size);
                for (int i = 0; i < size; i++)
                {
                    structure.MandatoryStringArray.Add(m_generator.GetRandomString());
                }
                structure.OptionalStringArray = new StringCollection(size);
                for (int i = 0; i < size; i++)
                {
                    structure.OptionalStringArray.Add(m_generator.GetRandomString());
                }
                if (variable.ValueRank == ValueRanks.Scalar)
                {
                    variable.Value = new Variant(new ExtensionObject(structure));
                }
                else if (variable.ValueRank == ValueRanks.OneDimension)
                {
                    ExtensionObjectCollection extensionObjets = new ExtensionObjectCollection(size);
                    for (int i = 0; i < size; i++)
                    {
                        extensionObjets.Add(new ExtensionObject(structure));
                    }
                    variable.Value = new Variant(extensionObjets);
                }
            }
            else if (variable.DataType.Identifier.Equals(Model.DataTypes.HeaterStatus))
            {
                if (variable.ValueRank == ValueRanks.Scalar)
                {
                    variable.Value = new Variant((int)Model.HeaterStatus.Heating);
                }
                else if (variable.ValueRank == ValueRanks.OneDimension)
                {
                    int size = 5;
                    List<int> values = new List<int>(size);
                    for (int i = 0; i < size; i++)
                    {
                        values.Add((int)Model.HeaterStatus.Cooling);
                    }
                    variable.Value = new Variant(values);
                }
            }
            else if (variable.DataType.Identifier.Equals(Model.DataTypes.Priority))
            {
                if (variable.ValueRank == ValueRanks.Scalar)
                {
                    variable.Value = new Variant((int)Model.Priority.High);
                }
                else if (variable.ValueRank == ValueRanks.OneDimension)
                {
                    int size = 5;
                    List<int> values = new List<int>(size);
                    for (int i = 0; i < size; i++)
                    {
                        values.Add((int)Model.Priority.Immediate);
                    }
                    variable.Value = new Variant(values);
                }
            }
            else if (variable.DataType.Identifier.Equals(Model.DataTypes.AccessRights))
            {
                OptionSetDataSource data = new OptionSetDataSource()
                {
                    TypeInfo = new TypeInfo(variable.DataType, variable.ValueRank, Server.TypeManager),
                    Timestamp = DateTime.UtcNow,
                    Status = StatusCodes.Good,
                    SimulationType = simulationType,
                    AccessLevel = variable.AccessLevel
                };

                data.GenerateRandomValue(m_generator);

                // add variable to simulation list.
                if (simulationType != SimulationType.None)
                {
                    lock (m_datasources)
                    {
                        m_datasources.Add(data);
                    }
                }

                SetVariableConfiguration(variable.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(data, 0));

                data.Read(0);
            }
            else if (variable.DataType.Identifier.Equals(Model.DataTypes.OptionSetByte))
            {
                OptionSetByteDataSource data = new OptionSetByteDataSource()
                {
                    TypeInfo = new TypeInfo(variable.DataType, variable.ValueRank, Server.TypeManager),
                    Timestamp = DateTime.UtcNow,
                    Status = StatusCodes.Good,
                    SimulationType = simulationType,
                    AccessLevel = variable.AccessLevel
                };
                SetVariableConfiguration(variable.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(data, 0));
            }
            else if (variable.DataType.Identifier.Equals(Model.DataTypes.OptionSetUInt16))
            {
                OptionSetUInt16DataSource data = new OptionSetUInt16DataSource()
                {
                    TypeInfo = new TypeInfo(variable.DataType, variable.ValueRank, Server.TypeManager),
                    Timestamp = DateTime.UtcNow,
                    Status = StatusCodes.Good,
                    SimulationType = simulationType,
                    AccessLevel = variable.AccessLevel
                };
                SetVariableConfiguration(variable.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(data, 0));
            }
            else if (variable.DataType.Identifier.Equals(Model.DataTypes.OptionSetUInt32))
            {
                OptionSetUInt32DataSource data = new OptionSetUInt32DataSource()
                {
                    TypeInfo = new TypeInfo(variable.DataType, variable.ValueRank, Server.TypeManager),
                    Timestamp = DateTime.UtcNow,
                    Status = StatusCodes.Good,
                    SimulationType = simulationType,
                    AccessLevel = variable.AccessLevel
                };
                SetVariableConfiguration(variable.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(data, 0));
            }
            else if (variable.DataType.Identifier.Equals(Model.DataTypes.OptionSetUInt64))
            {
                OptionSetUInt64DataSource data = new OptionSetUInt64DataSource()
                {
                    TypeInfo = new TypeInfo(variable.DataType, variable.ValueRank, Server.TypeManager),
                    Timestamp = DateTime.UtcNow,
                    Status = StatusCodes.Good,
                    SimulationType = simulationType,
                    AccessLevel = variable.AccessLevel
                };
                SetVariableConfiguration(variable.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(data, 0));
            }
            else if (variable.DataType.Identifier.Equals(Model.DataTypes.OptionSetBase))
            {
                OptionSetBaseDataSource data = new OptionSetBaseDataSource()
                {
                    TypeInfo = new TypeInfo(variable.DataType, variable.ValueRank, Server.TypeManager),
                    Timestamp = DateTime.UtcNow,
                    Status = StatusCodes.Good,
                    SimulationType = simulationType,
                    AccessLevel = variable.AccessLevel
                };
                SetVariableConfiguration(variable.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(data, 0));
            }
            else if (variable.DataType.Identifier.Equals(Model.DataTypes.StructureWithAbstractBaseTypes))
            {
                SetVariableDefaultValue(
                    variable.NodeId,
                    new Variant(new Model.StructureWithAbstractBaseTypes()
                    {
                        Base1 = new Model.ExtendedSubType(),
                        Base2 = new Model.ExtendedSubType(),
                        Number = new Variant(12)
                    }));
            }
            else if (variable.DataType.Identifier.Equals(Model.DataTypes.StructureWithAllowSubtypes))
            {
                SetVariableDefaultValue(
                    variable.NodeId,
                    new Variant(new Model.StructureWithAllowSubtypes()
                    {
                        Base1 = new Model.ExtendedSubType(),
                        Base2 = new Model.ExtendedSubType()
                    }));
            }
        }

        private void InitializeAnalogs(NodeId baseId, SimulationType simulationType)
        {
            Node folder = FindInMemoryNode(baseId);

            foreach (ReferenceNode reference in folder.FindReferences(UnifiedAutomation.UaBase.ReferenceTypeIds.HierarchicalReferences, false, true, Server.TypeManager))
            {
                VariableNode variable = FindInMemoryNode((NodeId)reference.TargetId) as VariableNode;

                if (variable == null)
                {
                    continue;
                }

                VariableNode euRange = null;
                VariableNode instrumentRange = null;
                VariableNode engineeringUnits = null;

                foreach (ReferenceNode reference2 in variable.FindReferences(UnifiedAutomation.UaBase.ReferenceTypeIds.HasProperty, false, true, Server.TypeManager))
                {
                    VariableNode property = FindInMemoryNode((NodeId)reference2.TargetId) as VariableNode;

                    if (property != null)
                    {
                        if (property.BrowseName == BrowseNames.EURange)
                        {
                            euRange = property;
                            property.AccessLevel = AccessLevels.CurrentReadOrWrite;
                            continue;
                        }

                        if (property.BrowseName == BrowseNames.InstrumentRange)
                        {
                            instrumentRange = property;
                            property.AccessLevel = AccessLevels.CurrentReadOrWrite;
                            continue;
                        }

                        if (property.BrowseName == BrowseNames.EngineeringUnits)
                        {
                            engineeringUnits = property;
                            property.AccessLevel = AccessLevels.CurrentReadOrWrite;
                            continue;
                        }
                    }
                }

                if (euRange == null)
                {
                    continue;
                }

                if (euRange.Value.TypeInfo != TypeInfo.Arrays.LocalizedText)
                {
                    euRange.Value = new Variant(new UaBase.Range() { Low = 0, High = 100 });
                }

                if (engineeringUnits == null)
                {
                    CreateVariableSettings settings = new CreateVariableSettings()
                    {
                        ParentNodeId = variable.NodeId,
                        ReferenceTypeId = ReferenceTypeIds.HasProperty,
                        RequestedNodeId = new NodeId(variable.NodeId.Identifier.ToString() + "EngineeringUnits", DefaultNamespaceIndex),
                        BrowseName = BrowseNames.EngineeringUnits,
                        DisplayName = BrowseNames.EngineeringUnits,
                        AccessLevel = AccessLevels.CurrentReadOrWrite,
                        DataType = DataTypeIds.EUInformation,
                        ValueRank = ValueRanks.Scalar,
                        MinimumSamplingInterval = 0,
                        Historizing = false,
                        TypeDefinitionId = VariableTypeIds.PropertyType,
                        Value = new ExtensionObject(EngineeringUnits.Metre_Per_Second)
                    };

                    engineeringUnits = CreateVariable(Server.DefaultRequestContext, settings);
                }

                UaBase.Range euRangeValue = euRange.Value.GetValue<UaBase.Range>(null);
                UaBase.Range instrumentRangeValue = (instrumentRange != null) ? instrumentRange.Value.GetValue<UaBase.Range>(null) : null;
                EUInformation engineeringUnitsValue = (engineeringUnits != null) ? engineeringUnits.Value.GetValue<EUInformation>(null) : null;

                AnalogDataSource data = new AnalogDataSource()
                {
                    TypeInfo = new TypeInfo(variable.DataType, variable.ValueRank, Server.TypeManager),
                    Timestamp = DateTime.UtcNow,
                    Status = StatusCodes.Good,
                    SimulationType = simulationType,
                    AccessLevel = variable.AccessLevel,
                    EURange = euRangeValue,
                    InstrumentRange = instrumentRangeValue,
                    EngineeringUnits = engineeringUnitsValue
                };

                data.GenerateRandomValue(m_generator);

                SetVariableConfiguration(variable.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(data, 0));
                SetVariableConfiguration(euRange.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(data, 1));

                if (instrumentRange != null)
                {
                    SetVariableConfiguration(instrumentRange.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(data, 2));
                }

                if (engineeringUnits != null)
                {
                    SetVariableConfiguration(engineeringUnits.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(data, 3));
                }
            }
        }

        private void InitializeMultiStates(NodeId baseId, SimulationType simulationType)
        {
            NodeId[] dataTypes = new NodeId[]
            {
                DataTypeIds.Byte,
                DataTypeIds.UInt16,
                DataTypeIds.UInt32,
                DataTypeIds.UInt64
            };

            LocalizedText[] defaultEnumStrings = new LocalizedText[]
            {
                new LocalizedText("Red"),
                new LocalizedText("Yellow"),
                new LocalizedText("Green"),
                new LocalizedText("Blue"),
                new LocalizedText("Purple")
            };

            int counter = 0;

            Node folder = FindInMemoryNode(baseId);

            foreach (ReferenceNode reference in folder.FindReferences(UnifiedAutomation.UaBase.ReferenceTypeIds.HierarchicalReferences, false, true, Server.TypeManager))
            {
                VariableNode variable = FindInMemoryNode((NodeId)reference.TargetId) as VariableNode;

                if (variable == null)
                {
                    continue;
                }

                VariableNode enumStrings = null;

                foreach (ReferenceNode reference2 in variable.FindReferences(UnifiedAutomation.UaBase.ReferenceTypeIds.HasProperty, false, true, Server.TypeManager))
                {
                    VariableNode property = FindInMemoryNode((NodeId)reference2.TargetId) as VariableNode;

                    if (property != null)
                    {
                        if (property.BrowseName == BrowseNames.EnumStrings)
                        {
                            enumStrings = property;
                            property.AccessLevel = AccessLevels.CurrentReadOrWrite;
                            break;
                        }
                    }
                }

                if (enumStrings == null)
                {
                    continue;
                }

                variable.DataType = dataTypes[counter % dataTypes.Length];
                counter++;

                if (enumStrings.Value.TypeInfo != TypeInfo.Arrays.LocalizedText)
                {
                    enumStrings.Value = defaultEnumStrings;
                }

                LocalizedText[] strings = enumStrings.Value.ToLocalizedTextArray();

                EnumStringDataSource data = new EnumStringDataSource()
                {
                    TypeInfo = new TypeInfo(variable.DataType, Server.TypeManager),
                    Timestamp = DateTime.UtcNow,
                    Status = StatusCodes.Good,
                    SimulationType = simulationType,
                    AccessLevel = variable.AccessLevel,
                    EnumStrings = strings,
                    EnumStringsTimestamp = DateTime.UtcNow
                };

                data.GenerateRandomValue(m_generator);

                SetVariableConfiguration(variable.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(data, 0));
                SetVariableConfiguration(enumStrings.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(data, 1));
            }
        }

        private void InitializeTwoStates(NodeId baseId, SimulationType simulationType)
        {
            Node folder = FindInMemoryNode(baseId);

            foreach (ReferenceNode reference in folder.FindReferences(UnifiedAutomation.UaBase.ReferenceTypeIds.HierarchicalReferences, false, true, Server.TypeManager))
            {
                VariableNode variable = FindInMemoryNode((NodeId)reference.TargetId) as VariableNode;

                if (variable == null)
                {
                    continue;
                }

                VariableNode trueState = null;
                VariableNode falseState = null;

                foreach (ReferenceNode reference2 in variable.FindReferences(UnifiedAutomation.UaBase.ReferenceTypeIds.HasProperty, false, true, Server.TypeManager))
                {
                    VariableNode property = FindInMemoryNode((NodeId)reference2.TargetId) as VariableNode;

                    if (property != null)
                    {
                        if (property.BrowseName == BrowseNames.TrueState)
                        {
                            trueState = property;
                            property.AccessLevel = AccessLevels.CurrentReadOrWrite;
                        }
                        else if (property.BrowseName == BrowseNames.FalseState)
                        {
                            falseState = property;
                            property.AccessLevel = AccessLevels.CurrentReadOrWrite;
                        }
                    }
                }

                if (trueState == null || falseState == null)
                {
                    continue;
                }

                if (variable.Value.TypeInfo != TypeInfo.Scalars.Boolean)
                {
                    trueState.Value = true;
                }

                if (trueState.Value.TypeInfo != TypeInfo.Scalars.LocalizedText)
                {
                    trueState.Value = new LocalizedText("ON");
                }

                if (falseState.Value.TypeInfo != TypeInfo.Scalars.LocalizedText)
                {
                    falseState.Value = new LocalizedText("OFF");
                }

                TwoStateDataSource data = new TwoStateDataSource()
                {
                    TypeInfo = new TypeInfo(variable.DataType, Server.TypeManager),
                    Timestamp = DateTime.UtcNow,
                    Status = StatusCodes.Good,
                    SimulationType = simulationType,
                    AccessLevel = variable.AccessLevel,
                    State = variable.Value.ToBoolean(),
                    TrueState = trueState.Value.ToLocalizedText(),
                    FalseState = falseState.Value.ToLocalizedText()
                };

                data.GenerateRandomValue(m_generator);

                SetVariableConfiguration(variable.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(data, 0));
                SetVariableConfiguration(trueState.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(data, 1));
                SetVariableConfiguration(falseState.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(data, 2));
            }
        }

        private void InitializeMultiStateValues(NodeId baseId)
        {
            NodeId[] dataTypes = new NodeId[]
            {
                DataTypeIds.SByte,
                DataTypeIds.Byte,
                DataTypeIds.Int16,
                DataTypeIds.UInt16,
                DataTypeIds.Int32,
                DataTypeIds.UInt32,
                DataTypeIds.Int64,
                DataTypeIds.UInt64
            };

            EnumValueType[] defaultValue = new EnumValueType[]
            {
                new EnumValueType() { DisplayName = "Red", Description = "A red value.", Value = 10 },
                new EnumValueType() { DisplayName = "Yellow", Description = "A yellow value.", Value = 20 },
                new EnumValueType() { DisplayName = "Green", Description = "A green value.", Value = 30 },
                new EnumValueType() { DisplayName = "Blue", Description = "A blue value.", Value = 40 },
                new EnumValueType() { DisplayName = "Purple", Description = "A purple value.", Value = 50 },
            };

            int counter = 0;

            Node folder = FindInMemoryNode(baseId);

            foreach (ReferenceNode reference in folder.FindReferences(UnifiedAutomation.UaBase.ReferenceTypeIds.HierarchicalReferences, false, true, Server.TypeManager))
            {
                VariableNode variable = FindInMemoryNode((NodeId)reference.TargetId) as VariableNode;

                if (variable == null)
                {
                    continue;
                }

                VariableNode enumValues = null;
                VariableNode valueAsText = null;

                foreach (ReferenceNode reference2 in variable.FindReferences(UnifiedAutomation.UaBase.ReferenceTypeIds.HasProperty, false, true, Server.TypeManager))
                {
                    VariableNode property = FindInMemoryNode((NodeId)reference2.TargetId) as VariableNode;

                    if (property != null)
                    {
                        if (property.BrowseName == BrowseNames.EnumValues)
                        {
                            enumValues = property;
                            property.AccessLevel = AccessLevels.CurrentReadOrWrite;
                        }

                        if (property.BrowseName == BrowseNames.ValueAsText)
                        {
                            valueAsText = property;
                        }
                    }
                }

                if (enumValues == null)
                {
                    continue;
                }

                variable.DataType = dataTypes[counter % dataTypes.Length];
                counter++;

                EnumValueDataSource data = new EnumValueDataSource()
                {
                    TypeInfo = new TypeInfo(variable.DataType, Server.TypeManager),
                    Timestamp = DateTime.UtcNow,
                    Status = StatusCodes.Good,
                    EnumValues = defaultValue,
                    EnumValuesTimestamp = DateTime.UtcNow,
                    AccessLevel = AccessLevels.CurrentReadOrWrite
                };

                data.GenerateRandomValue(m_generator);

                SetVariableConfiguration(variable.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(data, 0));
                SetVariableConfiguration(enumValues.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(data, 1));
                SetVariableConfiguration(valueAsText.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(data, 2));
            }
        }

        private ImageDataSource m_imageDataSource;

        private void InitializeAnimation()
        {
            NodeId animationNodeId = new NodeId("Demo.Dynamic.Scalar.ImageGIF", DefaultNamespaceIndex);

            m_imageDataSource = new ImageDataSource()
            {
                TypeInfo = new TypeInfo(DataTypeIds.ImageGIF, Server.TypeManager),
                Timestamp = DateTime.UtcNow,
                Status = StatusCodes.Good,
                AccessLevel = AccessLevels.CurrentRead
            };

            SetVariableConfiguration(animationNodeId, NodeHandleType.ExternalPush, new DataSourceAddress(m_imageDataSource, 0));
        }

        private void AddMassTestValues(NodeId baseId, SimulationType simulationType)
        {
            string prefix = baseId.Identifier as string;
            prefix += ".";

            for (int ii = 0; ii < 1000; ii++)
            {
                string name = "Variable" + ii.ToString("D3");

                var data = new IncrementDataSource()
                {
                    TypeInfo = TypeInfo.Scalars.UInt32,
                    Timestamp = DateTime.UtcNow,
                    Status = StatusCodes.Good,
                    SimulationType = simulationType,
                    AccessLevel = AccessLevels.CurrentReadOrWrite
                };

                data.GenerateRandomValue(m_generator);

                CreateVariableSettings settings = new CreateVariableSettings()
                {
                    ParentNodeId = baseId,
                    ReferenceTypeId = ReferenceTypeIds.HasComponent,
                    RequestedNodeId = new NodeId(prefix + name, DefaultNamespaceIndex),
                    BrowseName = new QualifiedName(name, DefaultNamespaceIndex),
                    DisplayName = name,
                    AccessLevel = AccessLevels.CurrentReadOrWrite,
                    DataType = DataTypeIds.UInt32,
                    ValueRank = ValueRanks.Scalar,
                    MinimumSamplingInterval = 0,
                    Historizing = false,
                    TypeDefinitionId = VariableTypeIds.BaseDataVariableType,
                    ValueType = NodeHandleType.ExternalPush,
                    ValueData = new DataSourceAddress(data, 0)
                };

                CreateVariable(Server.DefaultRequestContext, settings);

                // add variable to simulation list.
                if (simulationType != SimulationType.None)
                {
                    lock (m_datasources)
                    {
                        m_datasources.Add(data);
                    }
                }
            }
        }

        private void SetupNodeVersioning(NodeId nodeId)
        {
            VariableNode variable = FindInMemoryNode(
                nodeId,
                ReferenceTypeIds.HasProperty,
                false,
                new QualifiedName(BrowseNames.NodeVersion, 0)) as VariableNode;

            if (variable == null)
            {
                return;
            }

            variable.AccessLevel = AccessLevels.CurrentRead;

            DataVariableDataSource data = new DataVariableDataSource()
            {
                TypeInfo = new TypeInfo(variable.DataType, variable.ValueRank, Server.TypeManager),
                Timestamp = DateTime.UtcNow,
                Status = StatusCodes.Good,
                AccessLevel = variable.AccessLevel,
                Value = "1"
            };

            DataSourceAddress address = new DataSourceAddress(data, 0);
            SetVariableConfiguration(variable.NodeId, NodeHandleType.ExternalPush, address);
            SetNodeUserData(nodeId, new NodeWithVersioning(data));
        }

        private bool UpdateNodeVersion(RequestContext context, Node node, ModelChangeStructureVerbMask verb)
        {
            // check if it is a node being tracked.
            /// [Check UserData]
            NodeWithVersioning data = node.UserData as NodeWithVersioning;

            if (data == null)
            {
                return false;
            }
            /// [Check UserData]

            // increment version.
            /// [Update node version]
            lock (m_datasources)
            {
                DataVariableDataSource datasource = data.Source;

                int version = datasource.Value.ToInt32();
                version++;
                datasource.Value = version.ToString();

                ReportChange(context, datasource, 0);
            }
            /// [Update node version]

            InstanceNode instance = node as InstanceNode;

            // create model change event.
            /// [Fire model change event]
            GenericEvent e = new GenericEvent(Server.FilterManager);

            e.Initialize(
                null,
                ObjectTypeIds.GeneralModelChangeEventType,
                ObjectIds.Server,
                BrowseNames.Server,
                EventSeverity.Low,
                "The address space has changed.");

            ModelChangeStructureDataType[] changes = new ModelChangeStructureDataType[1];

            changes[0] = new ModelChangeStructureDataType();
            changes[0].Affected = node.NodeId;
            changes[0].AffectedType = (instance != null) ? instance.TypeDefinitionId : null;
            changes[0].Verb = (byte)verb;

            e.Set(BrowseNames.Changes, new Variant(changes));

            // report the event.
            Server.ReportEvent(e);
            /// [Fire model change event]

            return true;
        }

        private void SetupSimulation()
        {
            VariableNode variable = FindInMemoryNode(new NodeId("Demo.SimulationActive", DefaultNamespaceIndex)) as VariableNode;

            if (variable != null)
            {
                DataVariableDataSource data = new SimulationActiveDataSource(this)
                {
                    TypeInfo = new TypeInfo(variable.DataType, variable.ValueRank, Server.TypeManager),
                    Timestamp = DateTime.UtcNow,
                    Status = StatusCodes.Good,
                    AccessLevel = variable.AccessLevel,
                    Value = true
                };

                SetVariableConfiguration(variable.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(data, 0));
                m_simulationActive = data;
            }

            variable = FindInMemoryNode(new NodeId("Demo.SimulationSpeed", DefaultNamespaceIndex)) as VariableNode;

            if (variable != null)
            {
                DataVariableDataSource data = new SimulationSpeedDataSource(this)
                {
                    TypeInfo = new TypeInfo(variable.DataType, variable.ValueRank, Server.TypeManager),
                    Timestamp = DateTime.UtcNow,
                    Status = StatusCodes.Good,
                    AccessLevel = variable.AccessLevel,
                    Value = (uint) 250
                };

                SetVariableConfiguration(variable.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(data, 0));
                m_simulationSpeed = data;
            }

            // start the simulation.
            m_simulationTimer = new Timer(DoSimulation, null, 250, 250);
            m_animationTimer = new Timer(DoAnimation, null, 50, 50);
        }

        //! [set up work order model]
        private void SetupWorkOrderModel()
        {
            NodeId WorkOrderId = new NodeId(Model.Variables.Demo_WorkOrder_WorkOrderVariable, DefaultNamespaceIndex);
            Model.WorkOrderType value = new Model.WorkOrderType();
            SetVariableDefaultValue(WorkOrderId, new Variant(value));
            Model.WorkOrderVariableModel model = new Model.WorkOrderVariableModel()
            {
                Value = value
            };
            LinkModelToNode(WorkOrderId, model, null, null, 0);

            WorkOrderId = new NodeId(Model.Variables.Demo_WorkOrder_WorkOrderVariable2, DefaultNamespaceIndex);
            value = new Model.WorkOrderType();
            SetVariableDefaultValue(WorkOrderId, new Variant(value));
            model = new Model.WorkOrderVariableModel()
            {
                Value = value
            };
            LinkModelToNode(WorkOrderId, model, null, null, 0);
        }
        //! [set up work order model]

        private void ReportChange(RequestContext context, ValueDataSource datasource, int componentIndex, bool initialDataChange = false, bool valueModified = true)
        {
            lock (datasource.Lock)
            {
                // check for monitored items.
                DataSourceMonitoredItem[] monitoredItems = datasource.MonitoredItems;

                if (monitoredItems == null)
                {
                    return;
                }

                DataValue canonicalDv = null;

                for (int ii = 0; ii < monitoredItems.Length; ii++)
                {
                    DataSourceMonitoredItem monitoredItem = monitoredItems[ii];

                    // skip items for a different component.
                    if (monitoredItem.ComponentIndex != componentIndex)
                    {
                        continue;
                    }

                    // skip items which are disable.
                    if (monitoredItem.MonitoringMode == MonitoringMode.Disabled)
                    {
                        continue;
                    }

                    if (!valueModified && !initialDataChange && monitoredItem.DataChangeTrigger != DataChangeTrigger.StatusValueTimestamp)
                    {
                        continue;
                    }

                    DataValue dv = null;

                    // check general access.
                    if (componentIndex == 0)
                    {
                        StatusCode errorCode = StatusCodes.Good;
                        if ((datasource.AccessLevel & AccessLevels.CurrentRead) == 0)
                        {
                            errorCode = StatusCodes.BadNotReadable;
                        }
                        else if (CannotPassNodeAccessChecks(context, monitoredItem.ItemHandle.NodeHandle, UserAccessMask.Read, out StatusCode statusCode))
                        {
                            errorCode = statusCode;
                        }
                        if (errorCode.IsBad())
                        {
                            monitoredItem.Callback(
                                context,
                                monitoredItem.ItemHandle,
                                new DataValue(errorCode),
                                true);

                            continue;
                        }
                    }

                    // read the value again if the index range or encoding are specified for the item.
                    if (!String.IsNullOrEmpty(monitoredItem.IndexRange) || !QualifiedName.IsNull(monitoredItem.DataEncoding))
                    {
                        dv = Read(context, monitoredItem.ItemHandle.NodeHandle, monitoredItem.IndexRange, monitoredItem.DataEncoding);
                    }

                    // use the canonical value for all items.
                    if (dv == null)
                    {
                        if (canonicalDv == null)
                        {
                            canonicalDv = datasource.Read(monitoredItem.ComponentIndex);
                        }

                        dv = canonicalDv;
                    }

                    // check if a semantic change has to be reported.
                    if (!initialDataChange && componentIndex == 0 && datasource.SemanticsHaveChanged)
                    {
                        dv.StatusCode = dv.StatusCode.SetSemanticsChanged(true);
                    }

                    // TraceServer.Error("REPORT ({0}): {1} {2}", monitoredItem.ItemHandle.NodeId, dv.StatusCode, dv.WrappedValue);

                    // report the change.
                    monitoredItem.Callback(
                        context,
                        monitoredItem.ItemHandle,
                        dv,
                        true);
                }

                // clear the semantic change bit.
                if (componentIndex == 0)
                {
                    datasource.SemanticsHaveChanged = false;
                }

                bool valueChanged = false;

                // now check if a change to a component triggers a value change.
                if (datasource.TriggersValueChange != null && componentIndex != 0)
                {
                    for (int ii = 0; ii < datasource.TriggersValueChange.Length; ii++)
                    {
                        if (datasource.TriggersValueChange[ii] == componentIndex)
                        {
                            ReportChange(context, datasource, 0);
                            valueChanged = true;
                            break;
                        }
                    }
                }

                // now check if a change to the value triggers a component change.
                if (datasource.TriggeredByValueChange != null && (componentIndex == 0 || valueChanged))
                {
                    for (int ii = 0; ii < datasource.TriggeredByValueChange.Length; ii++)
                    {
                        ReportChange(context, datasource, datasource.TriggeredByValueChange[ii]);
                    }
                }
            }
        }

        private void ReportChangeStatus(RequestContext context, ValueDataSource datasource, int componentIndex, StatusCode status)
        {
            lock (datasource.Lock)
            {
                // check for monitored items.
                DataSourceMonitoredItem[] monitoredItems = datasource.MonitoredItems;

                if (monitoredItems == null)
                {
                    return;
                }

                for (int ii = 0; ii < monitoredItems.Length; ii++)
                {
                    DataSourceMonitoredItem monitoredItem = monitoredItems[ii];

                    // skip items for a different component.
                    if (monitoredItem.ComponentIndex != componentIndex)
                    {
                        continue;
                    }

                    // skip items which are disable.
                    if (monitoredItem.MonitoringMode == MonitoringMode.Disabled)
                    {
                        continue;
                    }

                    StatusCode statusCode = status;

                    if (componentIndex == 0)
                    {
                        StatusCode errorCode = StatusCodes.Good;
                        if ((datasource.AccessLevel & AccessLevels.CurrentRead) == 0)
                        {
                            statusCode = StatusCodes.BadNotReadable;
                        }
                        else if (CannotPassNodeAccessChecks(context, monitoredItem.ItemHandle.NodeHandle, UserAccessMask.Read, out StatusCode error))
                        {
                            statusCode = error;
                        }
                    }

                    // report the change.
                    monitoredItem.Callback(
                        context,
                        monitoredItem.ItemHandle,
                        new DataValue(statusCode),
                        true);
                }

            }
        }

        private void DoSimulation(object state)
        {
            try
            {
                lock (m_datasources)
                {
                    for (int ii = 0; ii < m_datasources.Count; ii++)
                    {
                        m_datasources[ii].GenerateRandomValue(m_generator);
                        ReportChange(Server.DefaultRequestContext, m_datasources[ii], 0);
                    }
                }

                UpdateBoiler();

                if (m_counter%5 == 0)
                {
                    GenericEvent e = new GenericEvent(Server.FilterManager);

                    e.Initialize(
                        null,
                        ObjectTypeIds.SystemEventType,
                        ObjectIds.Server,
                        "System",
                        (m_counter % 2 == 0) ? EventSeverity.MediumHigh : EventSeverity.MediumLow,
                        new LocalizedText("A system event occurred."));

                    Server.ReportEvent(e);
                }

                m_counter++;
            }
            catch (Exception e)
            {
                TraceServer.Error(e, "Failed run simulation.");
            }
        }

        private void DoAnimation(object state)
        {
            try
            {
                m_imageDataSource.GenerateNextValue(null);
                ReportChange(Server.DefaultRequestContext, m_imageDataSource, 0);
            }
            catch (Exception e)
            {
                TraceServer.Error(e, "Failed run animation.");
            }
        }
#endregion

#region NodeWithVersioning Class
        private class NodeWithVersioning
        {
            public NodeWithVersioning(DataVariableDataSource source)
            {
                Source = source;
            }

            public DataVariableDataSource Source { get; private set; }
        }
#endregion

#region Private Fields
        private DataGenerator m_generator;
        private List<ValueDataSource> m_datasources;
        private Timer m_simulationTimer;
        private Timer m_animationTimer;
        private int m_counter;
        private List<uint> m_internalMonitoredItemIds;
        #endregion
    }
}
