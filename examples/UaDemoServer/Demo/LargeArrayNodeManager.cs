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
using System.Threading;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaServer;

namespace UnifiedAutomation.Demo
{
    public class LargeArrayNodeManager : INodeManager, IIOManager, IDisposable
    {
        #region Constructors
        public LargeArrayNodeManager(ServerManager server)
        {
            m_server = server;
            m_monitoredItems = new Dictionary<uint, DataMonitoredItem>();
        }
        #endregion

        #region Public Properties
        public ushort DefaultNamespaceIndex { get; set; }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            m_simulationTimer.Dispose();
        }
        #endregion

        #region INodeManager Members
        public void Startup()
        {
            ushort parentNamespaceIndex = (ushort)m_server.NamespaceUris.GetIndexOrAppend("http://www.unifiedautomation.com/DemoServer/");
            DefaultNamespaceIndex = m_server.RootNodeManager.AddNodeManager("http://www.unifiedautomation.com/DemoServer/MassTest", this);

            m_rootId = new NodeId("Demo.Massfolder_Static.OneMillion", parentNamespaceIndex);

            if (NodeId.IsNull(m_rootId))
            {
                TraceServer.Error("Could not find root node for LargeArrayNodeManager.");
                return;
            }

            AddNodeSettings settings = new AddNodeSettings()
            {
                ParentNodeId = new NodeId("Demo.Massfolder_Static", parentNamespaceIndex),
                ReferenceTypeId = ReferenceTypeIds.HasComponent,
                RequestedNodeId = m_rootId,
                BrowseName = new QualifiedName("OneMillion", parentNamespaceIndex),
                Attributes = new ObjectAttributes()
            };

            StatusCode error = m_server.RootNodeManager.AddNode(m_server.DefaultRequestContext, settings, out m_rootId);

            if (error.IsBad())
            {
                TraceServer.Error(error);
                return;
            }

            m_maxFolderSize = 100;
            m_server.RootNodeManager.AddCrossReference(m_rootId, this);

            const int length = 1000000;
            m_registers = new int[length];
            m_monitoredRegisters = new DataMonitoredItem[length][];

            m_simulationTimer = new Timer(DoSimulation, null, 30000, 30000);
        }

        public void Shutdown()
        {
        }

        public void SessionOpened(Session session)
        {
        }

        public void SessionActivated(Session session)
        {
        }

        public void SessionClosed(Session session)
        {
        }

        public StatusCode GetBrowseHandle(
            RequestContext context,
            ViewHandle view,
            NodeId nodeId,
            out BrowseHandle handle)
        {
            handle = null;

            if (nodeId.NamespaceIndex != DefaultNamespaceIndex)
            {
                return StatusCodes.BadNodeIdUnknown;
            }

            Identifier id = Identifier.Parse(this, nodeId);

            if (id == null)
            {
                return StatusCodes.BadNodeIdUnknown;
            }

            handle = new BrowseHandle(this, null, nodeId) { UserData = id };

            return StatusCodes.Good;
        }

        public StatusCode GetViewHandle(
            RequestContext context,
            ViewDescription view,
            out ViewHandle handle)
        {
            handle = null;

            if (view == null)
            {
                return StatusCodes.Good;
            }

            return StatusCodes.BadViewIdUnknown;
        }

        public StatusCode GetNodeHandle(
            RequestContext context,
            NodeId nodeId,
            uint attributeId,
            out NodeAttributeHandle handle)
        {
            handle = null;

            if (nodeId.NamespaceIndex != DefaultNamespaceIndex)
            {
                return StatusCodes.BadNodeIdUnknown;
            }

            Identifier id = Identifier.Parse(this, nodeId);

            if (id == null)
            {
                return StatusCodes.BadNodeIdUnknown;
            }

            handle = new NodeAttributeHandle(this, this, null, nodeId, attributeId) { UserData = id };

            return StatusCodes.Good;
        }

        public StatusCode GetNotifierHandle(
            RequestContext context,
            NodeId nodeId,
            out NotifierHandle handle)
        {
            handle = null;
            return StatusCodes.BadNodeIdUnknown;
        }

        public StatusCode GetMethodHandle(
            RequestContext context,
            NodeId objectId,
            NodeId methodId,
            out MethodHandle handle)
        {
            handle = null;
            return StatusCodes.BadNodeIdUnknown;
        }

        public StatusCode GetHistoryDataHandle(
            RequestContext context,
            NodeId variableId,
            out HistoryDataHandle handle)
        {
            handle = null;
            return StatusCodes.BadNodeIdUnknown;
        }

        public StatusCode GetHistoryEventHandle(
            RequestContext context,
            NodeId notifierId,
            out HistoryEventHandle handle)
        {
            handle = null;
            return StatusCodes.BadNodeIdUnknown;
        }

        public StatusCode BeginBrowse(
            RequestContext context,
            BrowseOperationHandle nodeToBrowse,
            ContinuationPoint continuationPoint,
            bool releaseContinuationPoint,
            Delegate callback,
            object callbackData)
        {
            if ((callback as BrowseCompletedEventHandler) == null)
            {
                throw new ArgumentNullException("callback");
            }

            // release continuation point.
            if (releaseContinuationPoint)
            {
                continuationPoint.Dispose();
                ((BrowseCompletedEventHandler)callback)(nodeToBrowse, callbackData, new BrowseResult() { StatusCode = StatusCodes.Good }, null, false);
                return StatusCodes.Good;
            }

            // check reference type.
            if (!NodeId.IsNull(continuationPoint.Settings.ReferenceTypeId))
            {
                if (!m_server.TypeManager.IsTypeOf(continuationPoint.Settings.ReferenceTypeId, ReferenceTypeIds.References))
                {
                    return StatusCodes.BadReferenceTypeIdInvalid;
                }
            }

            // browse for references.
            ContinuationPoint rcp = null;

            BrowseResult result = Browse(context, continuationPoint, out rcp);

            if (result == null)
            {
                return StatusCodes.BadNodeIdUnknown;
            }

            if (rcp != null)
            {
                result.ContinuationPoint = rcp.Id.ToByteArray();
            }

            // invoke callback.
            ((BrowseCompletedEventHandler)callback)(nodeToBrowse, callbackData, result, rcp, false);
            return StatusCodes.Good;
        }

        private BrowseResult Browse(
            RequestContext context,
            ContinuationPoint continuationPoint,
            out ContinuationPoint revisedContinuationPoint)
        {
            revisedContinuationPoint = null;

            BrowseHandle handle = continuationPoint.NodeToBrowse;
            List<ReferenceNode> references = continuationPoint.UnprocessedReferences;

            if (references == null)
            {
                // check if cross references are being browsed.
                if (handle.NodeId.NamespaceIndex != DefaultNamespaceIndex)
                {
                    references = BrowseFolder(context, continuationPoint);
                }
                else
                {
                    Identifier id = handle.UserData as Identifier;

                    // handle variables.
                    if (id.IdType == IdType.Variable)
                    {
                        references = BrowseVariable(context, continuationPoint);
                    }

                    // handle folders.
                    else
                    {
                        references = BrowseFolder(context, continuationPoint);
                    }
                }
            }

            // process references.
            ContinuationPoint cp = null;
            BrowseResult result = new BrowseResult();

            for (int ii = 0; ii < references.Count; ii++)
            {
                // check if a halt is required.
                cp = continuationPoint.CheckMaxReferences<ContinuationPoint>(result.References);

                if (cp != null)
                {
                    if (ii > 0)
                    {
                        references.RemoveRange(0, ii);
                    }

                    cp.UnprocessedReferences = references;
                    break;
                }

                uint mask = continuationPoint.Settings.ResultMask;

                if (!QualifiedName.IsNull(continuationPoint.TargetName))
                {
                    mask |= (uint)BrowseResultMask.BrowseName;
                }

                // get the description.
                ReferenceDescription reference = m_server.InternalClient.GetReferenceDescription(
                    context,
                    references[ii].TargetId,
                    references[ii].ReferenceTypeId,
                    !references[ii].IsInverse,
                    continuationPoint.Settings.ResultMask,
                    continuationPoint.Settings.NodeClassMask);

                // check target name.
                if (!QualifiedName.IsNull(continuationPoint.TargetName))
                {
                    if (continuationPoint.TargetName != reference.BrowseName)
                    {
                        continue;
                    }

                    if ((continuationPoint.Settings.ResultMask & (uint)BrowseResultMask.BrowseName) == 0)
                    {
                        reference.BrowseName = null;
                    }
                }

                result.References.Add(reference);
            }

            revisedContinuationPoint = cp;
            return result;
        }

        private List<ReferenceNode> BrowseVariable(
            RequestContext context,
            ContinuationPoint cp)
        {
            List<ReferenceNode> references = new List<ReferenceNode>(2);

            // parse the node id.
            Identifier id = cp.NodeToBrowse.UserData as Identifier;

            if (id == null)
            {
                return references;
            }

            // handle reference to parent folder.
            if (cp.IsReferenceSelected(context, ReferenceTypeIds.HasComponent, true))
            {
                ExpandedNodeId targetId = id.GetParentNodeId();
                references.Add(new ReferenceNode() { ReferenceTypeId = ReferenceTypeIds.Organizes, IsInverse = true, TargetId = targetId });
            }

            // handle reference to type definition.
            if (cp.IsReferenceSelected(context, ReferenceTypeIds.HasTypeDefinition, false))
            {
                references.Add(new ReferenceNode() { ReferenceTypeId = ReferenceTypeIds.HasTypeDefinition, IsInverse = false, TargetId = VariableTypeIds.BaseDataVariableType });
            }

            return references;
        }

        private List<ReferenceNode> BrowseFolder(
            RequestContext context,
            ContinuationPoint cp)
        {
            List<ReferenceNode> references = new List<ReferenceNode>();

            // handle browse from root.
            if (cp.NodeToBrowse.NodeId == m_rootId)
            {
                if (cp.IsReferenceSelected(context, ReferenceTypeIds.Organizes, false))
                {
                    int index = 0;
                    int cube = (int)Math.Pow(m_maxFolderSize, 2);

                    while (index * cube < m_registers.Length)
                    {
                        NodeId childId = Identifier.GetRootNodeId(index++, DefaultNamespaceIndex);
                        references.Add(new ReferenceNode() { ReferenceTypeId = ReferenceTypeIds.Organizes, IsInverse = false, TargetId = childId });
                    }
                }

                return references;
            }

            // parse the node id.
            Identifier id = cp.NodeToBrowse.UserData as Identifier;

            if (id == null)
            {
                return references;
            }

            // handle references to child folders.
            if (cp.IsReferenceSelected(context, ReferenceTypeIds.Organizes, false))
            {
                for (int ii = 0; ii < m_maxFolderSize; ii++)
                {
                    NodeId childId = id.GetChildNodeId(ii);

                    if (childId != null)
                    {
                        references.Add(new ReferenceNode() { ReferenceTypeId = ReferenceTypeIds.Organizes, IsInverse = false, TargetId = childId });
                    }
                }
            }

            // handle references to child variables.
            //if (id.IdType == 1 && cp.IsReferenceSelected(context, ReferenceTypeIds.HasComponent, false))
            //{
            //    for (int ii = 0; ii < m_maxFolderSize; ii++)
            //    {
            //        NodeId childId = id.GetChildNodeId(ii);

            //        if (childId != null)
            //        {
            //            references.Add(new ReferenceNode() { ReferenceTypeId = ReferenceTypeIds.Organizes, IsInverse = false, TargetId = childId });
            //        }
            //    }
            //}

            if (cp.IsReferenceSelected(context, ReferenceTypeIds.Organizes, true))
            {
                // handle references to parent folder.
                if (id.IdType == IdType.Folder && id.HierarchicalAddress.Length > 1)
                {
                    references.Add(new ReferenceNode() { ReferenceTypeId = ReferenceTypeIds.Organizes, IsInverse = true, TargetId = id.GetParentNodeId() });
                }

                // handle references to root folder.
                else
                {
                    references.Add(new ReferenceNode() { ReferenceTypeId = ReferenceTypeIds.Organizes, IsInverse = true, TargetId = m_rootId });
                }
            }

            // handle type definition.
            if (cp.IsReferenceSelected(context, ReferenceTypeIds.HasTypeDefinition, false))
            {
                references.Add(new ReferenceNode() { ReferenceTypeId = ReferenceTypeIds.HasTypeDefinition, IsInverse = false, TargetId = ObjectTypeIds.FolderType });
            }

            return references;
        }

        public StatusCode BeginTranslate(
            RequestContext context,
            BrowseOperationHandle nodeToBrowse,
            RelativePath relativePath,
            uint index,
            Delegate callback,
            object callbackData)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (nodeToBrowse == null)
            {
                throw new ArgumentNullException("nodeToBrowse");
            }

            if ((callback as TranslateCompletedEventHandler) == null)
            {
                throw new ArgumentNullException("callback");
            }

            BrowsePathResult result = new BrowsePathResult();

            // check relative path.
            if (relativePath == null || relativePath.Elements.Count <= index)
            {
                result.StatusCode = StatusCodes.BadNoMatch;
                ((TranslateCompletedEventHandler)callback)(nodeToBrowse, callbackData, result, false);
                return StatusCodes.Good;
            }

            StatusCode error = Translate(
                context,
                nodeToBrowse.BrowseHandle,
                relativePath,
                index,
                result);

            if (error.IsBad())
            {
                result.StatusCode = error;
                ((TranslateCompletedEventHandler)callback)(nodeToBrowse, callbackData, result, false);
                return StatusCodes.Good;
            }

            ((TranslateCompletedEventHandler)callback)(nodeToBrowse, callbackData, result, false);
            return StatusCodes.Good;
        }

        public StatusCode Translate(
            RequestContext context,
            BrowseHandle browseHandle,
            RelativePath path,
            uint index,
            BrowsePathResult result)
        {
            // get next element to process. Check if there is more to steps to follow.
            RelativePathElement element = path.Elements[(int)index];
            index = (path.Elements.Count - 1 <= index) ? UInt32.MaxValue : index;

            // check access.
            if (browseHandle.UserAccessManager != null)
            {
                if (!browseHandle.UserAccessManager.HasAccess(context, browseHandle))
                {
                    return StatusCodes.BadUserAccessDenied;
                }
            }

            // browse references from node.
            BrowseDescription settings = new BrowseDescription();

            settings.NodeId = browseHandle.NodeId;
            settings.ReferenceTypeId = element.ReferenceTypeId;
            settings.BrowseDirection = (element.IsInverse) ? BrowseDirection.Inverse : BrowseDirection.Forward;
            settings.IncludeSubtypes = element.IncludeSubtypes;
            settings.ResultMask = (uint)BrowseResultMask.BrowseName;
            settings.NodeClassMask = 0;

            ContinuationPoint cp = new ContinuationPoint()
            {
                NodeManager = browseHandle.NodeManager,
                NodeToBrowse = browseHandle,
                Settings = settings,
                TargetName = element.TargetName
            };

            HashSet<NodeId> pathsToSearch = new HashSet<NodeId>();

            do
            {
                // check for timeout in large recursive calls.
                if (!context.IsDefaultServerContext && context.OperationDeadline < Utils.GetTickCount())
                {
                    return StatusCodes.BadTimeout;
                }

                // get next batch of references.
                List<ReferenceDescription> references = new List<ReferenceDescription>();

                ContinuationPoint cp2 = null;
                BrowseResult br = Browse(context, cp, out cp2);

                if (!Object.ReferenceEquals(cp2, cp))
                {
                    cp.Dispose();
                    cp = cp2;
                }

                // look for matches on browse name.
                foreach (ReferenceDescription reference in br.References)
                {
                    if (reference.BrowseName != element.TargetName)
                    {
                        continue;
                    }

                    // add target if it is not already in the list.
                    if (index == UInt32.MaxValue || reference.NodeId.IsAbsolute)
                    {
                        bool found = false;

                        foreach (var target in result.Targets)
                        {
                            if (target.TargetId == reference.NodeId)
                            {
                                if (index > target.RemainingPathIndex)
                                {
                                    target.RemainingPathIndex = index;
                                }

                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            result.Targets.Add(new BrowsePathTarget() { TargetId = reference.NodeId, RemainingPathIndex = index });
                        }

                        continue;
                    }

                    // add to list of paths to search later (should be a short list).
                    NodeId nextId = (NodeId)reference.NodeId;

                    if (!pathsToSearch.Contains(nextId))
                    {
                        pathsToSearch.Add(nextId);
                    }
                }
            }
            while (cp != null);

            // recursively follow the paths.
            foreach (var pathToSearch in pathsToSearch)
            {
                // check for timeout in large recursive calls.
                if (!context.IsDefaultServerContext && context.OperationDeadline < Utils.GetTickCount())
                {
                    return StatusCodes.BadTimeout;
                }

                StatusCode error = StatusCodes.Good;

                try
                {
                    // check if this is a outgoing reference.
                    if (pathToSearch.NamespaceIndex != DefaultNamespaceIndex)
                    {
                        error = m_server.InternalClient.Translate(
                            context,
                            pathToSearch,
                            path,
                            index + 1,
                            result);
                    }

                    // handle an internal reference.
                    else
                    {
                        BrowseHandle nextHandle;

                        error = GetBrowseHandle(context, null, pathToSearch, out nextHandle);

                        if (error.IsGood())
                        {
                            error = Translate(
                                context,
                                nextHandle,
                                path,
                                index + 1,
                                result);
                        }
                    }

                    // check for error code.
                    if (error == StatusCodes.BadTimeout)
                    {
                        return error;
                    }
                }
                catch (Exception e)
                {
                    var se = e as StatusException;

                    if (se != null && se.StatusCode == StatusCodes.BadTimeout)
                    {
                        return StatusCodes.BadTimeout;
                    }

                    TraceServerInternal.Error(e, "Unexpected error following browse path: " + element.TargetName);
                }
            }

            return StatusCodes.Good;
        }
        #endregion

        #region IIOManager Members
        public StatusCode BeginDataTransaction(
            RequestContext context,
            uint totalItemCountHint,
            double maxAge,
            TimestampsToReturn timestampsToReturn,
            TransactionType transactionType,
            Delegate callback,
            object callbackData,
            out TransactionHandle handle)
        {
            handle = new DataTransactionHandle(context, transactionType, callback, callbackData)
            {
                ExpectedItemCount = totalItemCountHint,
                MaxAge = maxAge,
                TimestampsToReturn = timestampsToReturn
            };

            return StatusCodes.Good;
        }

        public void FinishDataTransaction(TransactionHandle transaction)
        {
            // nothing to do.
        }

        public StatusCode BeginRead(
            NodeAttributeOperationHandle operationHandle,
            ReadValueId settings)
        {
            if (operationHandle == null)
            {
                throw new ArgumentNullException("nodeHandle");
            }

            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            if (!Object.ReferenceEquals(operationHandle.IOManager, this))
            {
                throw new ArgumentException("NodeAttributeOperationHandle passed to wrong IOManager", "operationHandle");
            }

            DataTransactionHandle transaction = operationHandle.Transaction as DataTransactionHandle;

            if (transaction == null || transaction.Done)
            {
                throw new ArgumentException("Transaction for NodeAttributeOperationHandle is not valid.", "operationHandle");
            }

            StatusCode error = FinishRead(operationHandle, settings);

            if (error.IsBad())
            {
                ((ReadCompleteEventHandler)transaction.Callback)(operationHandle, transaction.CallbackData, new DataValue(error), false);
            }

            return StatusCodes.Good;
        }

        public StatusCode BeginWrite(
            NodeAttributeOperationHandle operationHandle,
            WriteValue settings)
        {
            if (operationHandle == null)
            {
                throw new ArgumentNullException("operationHandle");
            }

            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            if (!Object.ReferenceEquals(operationHandle.IOManager, this))
            {
                throw new ArgumentException("NodeAttributeOperationHandle passed to wrong IOManager", "operationHandle");
            }

            // check for invalid attribute id.
            if (!Attributes.IsValid(settings.AttributeId))
            {
                return StatusCodes.BadAttributeIdInvalid;
            }

            DataTransactionHandle transaction = operationHandle.Transaction as DataTransactionHandle;

            if (transaction == null || transaction.Done)
            {
                throw new ArgumentException("Transaction for NodeAttributeOperationHandle is not valid.", "operationHandle");
            }

            // get the id.
            Identifier id = operationHandle.NodeHandle.UserData as Identifier;

            if (id == null)
            {
                return StatusCodes.BadNodeIdUnknown;
            }

            // only values can be written.
            if (settings.AttributeId != Attributes.Value)
            {
                return StatusCodes.BadNotWritable;
            }

            DataValue dv = settings.Value;

            // check for unsupported writes.
            if (dv.StatusCode != StatusCodes.Good || dv.SourceTimestamp != DateTime.MinValue || dv.ServerTimestamp != DateTime.MinValue)
            {
                return StatusCodes.BadWriteNotSupported;
            }

            StatusCode error = StatusCodes.BadNotWritable;

            if (id.IdType == 0)
            {
                error = WriteValue(transaction.Context, id, dv.WrappedValue);
            }

            // report result.
            ((WriteCompleteEventHandler)transaction.Callback)(operationHandle, transaction.CallbackData, error, false);

            return StatusCodes.Good;
        }

        public StatusCode BeginStartDataMonitoring(
            NodeAttributeOperationHandle operationHandle,
            uint monitoredItemId,
            MonitoredItemCreateRequest settings,
            DataChangeEventHandler callback)
        {
            if (operationHandle == null)
            {
                throw new ArgumentNullException("operationHandle");
            }

            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            if (!Object.ReferenceEquals(operationHandle.IOManager, this))
            {
                throw new ArgumentException("NodeAttributeOperationHandle passed to wrong IOManager", "operationHandle");
            }

            DataTransactionHandle transaction = operationHandle.Transaction as DataTransactionHandle;

            if (transaction == null || transaction.Done)
            {
                throw new ArgumentException("Transaction for NodeAttributeOperationHandle is not valid.", "operationHandle");
            }

            // check for invalid attribute id.
            if (!Attributes.IsValid(settings.ItemToMonitor.AttributeId))
            {
                return StatusCodes.BadAttributeIdInvalid;
            }

            // check for invalid index range.
            if (!String.IsNullOrEmpty(settings.ItemToMonitor.IndexRange))
            {
                return StatusCodes.BadIndexRangeNoData;
            }

            // check for invalid data encoding.
            if (!QualifiedName.IsNull(settings.ItemToMonitor.DataEncoding))
            {
                return StatusCodes.BadDataEncodingInvalid;
            }

            // read the value.
            Identifier id = operationHandle.NodeHandle.UserData as Identifier;

            if (id == null)
            {
                return StatusCodes.BadNodeIdUnknown;
            }

            // create the handle.
            MonitoredItemHandle itemHandle = new MonitoredItemHandle(operationHandle.NodeHandle, monitoredItemId);

            // fill in metadata to speed up processing.
            NodeMetadata metadata = new NodeMetadata()
            {
                NodeClass = (id.IdType == 0) ? NodeClass.Variable : NodeClass.Object,
                DataTypeId = (id.IdType == 0) ? DataTypeIds.Int32 : null
            };

            // validate request.
            DataMonitoringResult result = m_server.ValidateDataMonitoringRequest(
                 transaction.Context,
                 operationHandle.NodeHandle,
                 null,
                 settings.RequestedParameters,
                 metadata);

            if (result.StatusCode.IsGood())
            {
                lock (m_lock)
                {
                    DataMonitoredItem item = new DataMonitoredItem()
                    {
                        Id = id,
                        Handle = itemHandle,
                        Callback = callback,
                        VariableIndex = -1,
                        MonitoringMode = settings.MonitoringMode
                    };

                    if (id.IdType == 0 && Attributes.Value == operationHandle.AttributeId)
                    {
                        item.VariableIndex = id.VariableIndex;

                        DataMonitoredItem[] items = m_monitoredRegisters[id.VariableIndex];

                        if (items != null)
                        {
                            DataMonitoredItem[] copy = new DataMonitoredItem[items.Length + 1];
                            items.CopyTo(copy, 0);
                            items = copy;
                        }
                        else
                        {
                            items = new DataMonitoredItem[1];
                        }

                        items[items.Length - 1] = item;
                        m_monitoredRegisters[id.VariableIndex] = items;
                    }

                    m_monitoredItems[monitoredItemId] = item;
                }

                DataValue dv = null;

                if (id.IdType == 0)
                {
                    dv = ReadVariableAttribute(transaction.Context, id, operationHandle.AttributeId);
                }
                else
                {
                    dv = ReadFolderAttribute(transaction.Context, id, operationHandle.AttributeId);
                }

                if (dv.StatusCode.IsBad())
                {
                    return dv.StatusCode;
                }

                // do the initial callback.
                callback(transaction.Context, itemHandle, dv, false);
            }

            // report the results.
            ((StartDataMonitoringCompleteEventHandler)transaction.Callback)(
                operationHandle,
                transaction.CallbackData,
                itemHandle,
                result,
                false);

            return StatusCodes.Good;
        }

        public StatusCode BeginModifyDataMonitoring(
            MonitoredItemOperationHandle operationHandle,
            MonitoredItemModifyRequest settings)
        {
            if (operationHandle == null)
            {
                throw new ArgumentNullException("operationHandle");
            }

            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            if (!Object.ReferenceEquals(operationHandle.IOManager, this))
            {
                throw new ArgumentException("NodeAttributeOperationHandle passed to wrong IOManager", "operationHandle");
            }

            DataTransactionHandle transaction = operationHandle.Transaction as DataTransactionHandle;

            if (transaction == null || transaction.Done)
            {
                throw new ArgumentException("Transaction for NodeAttributeOperationHandle is not valid.", "operationHandle");
            }

            DataMonitoredItem item = null;

            lock (m_lock)
            {
                if (!m_monitoredItems.TryGetValue(operationHandle.MonitoredItemId, out item))
                {
                    return StatusCodes.BadMonitoredItemIdInvalid;
                }
            }

            // fill in metadata to speed up processing.
            NodeMetadata metadata = new NodeMetadata()
            {
                NodeClass = (item.Id.IdType == 0) ? NodeClass.Variable : NodeClass.Object,
                DataTypeId = (item.Id.IdType == 0) ? DataTypeIds.Int32 : null
            };

            // validate request.
            DataMonitoringResult result = m_server.ValidateDataMonitoringRequest(
                transaction.Context,
                operationHandle.NodeHandle,
                null,
                settings.RequestedParameters,
                null);

            // report the results.
            ((ModifyDataMonitoringCompleteEventHandler)transaction.Callback)(
                operationHandle,
                transaction.CallbackData,
                result,
                false);

            return StatusCodes.Good;
        }

        public StatusCode BeginStopDataMonitoring(
            MonitoredItemOperationHandle operationHandle)
        {
            if (operationHandle == null)
            {
                throw new ArgumentNullException("operationHandle");
            }

            if (!Object.ReferenceEquals(operationHandle.IOManager, this))
            {
                throw new ArgumentException("NodeAttributeOperationHandle passed to wrong IOManager", "operationHandle");
            }

            DataTransactionHandle transaction = operationHandle.Transaction as DataTransactionHandle;

            if (transaction == null || transaction.Done)
            {
                throw new ArgumentException("Transaction for NodeAttributeOperationHandle is not valid.", "operationHandle");
            }

            // remove item.
            lock (m_lock)
            {
                DataMonitoredItem item = null;

                if (!m_monitoredItems.TryGetValue(operationHandle.MonitoredItemId, out item))
                {
                    return StatusCodes.BadNodeIdUnknown;
                }

                m_monitoredItems.Remove(operationHandle.MonitoredItemId);
                item.Callback = null;

                if (item.VariableIndex > 0)
                {
                    DataMonitoredItem[] items = m_monitoredRegisters[item.VariableIndex];

                    if (items != null)
                    {
                        DataMonitoredItem[] copy = new DataMonitoredItem[items.Length-1];

                        int ii = 0;

                        while (ii < copy.Length)
                        {
                            if (Object.ReferenceEquals(items[ii], item))
                            {
                                break;
                            }

                            copy[ii] = items[ii];
                            ii++;
                        }

                        while (ii < copy.Length)
                        {
                            copy[ii] = items[ii+1];
                            ii++;
                        }

                        m_monitoredRegisters[item.VariableIndex] = copy;
                    }
                }
            }

            // report the results.
            ((StopMonitoringCompleteEventHandler)transaction.Callback)(
                operationHandle,
                transaction.CallbackData,
                StatusCodes.Good,
                false);

            return StatusCodes.Good;
        }

        public StatusCode BeginSetDataMonitoringMode(
            MonitoredItemOperationHandle operationHandle,
            MonitoringMode monitoringMode,
            MonitoringParameters parameters)
        {
            if (operationHandle == null)
            {
                throw new ArgumentNullException("operationHandle");
            }

            if (!Object.ReferenceEquals(operationHandle.IOManager, this))
            {
                throw new ArgumentException("NodeAttributeOperationHandle passed to wrong IOManager", "operationHandle");
            }

            DataTransactionHandle transaction = operationHandle.Transaction as DataTransactionHandle;

            if (transaction == null || transaction.Done)
            {
                throw new ArgumentException("Transaction for NodeAttributeOperationHandle is not valid.", "operationHandle");
            }

            // update item.
            DataMonitoredItem item = null;
            bool enabled = false;

            lock (m_lock)
            {
                if (!m_monitoredItems.TryGetValue(operationHandle.MonitoredItemId, out item))
                {
                    return StatusCodes.BadMonitoredItemIdInvalid;
                }

                if (item.MonitoringMode != monitoringMode)
                {
                    item.MonitoringMode = monitoringMode;
                    enabled = monitoringMode != MonitoringMode.Disabled;
                }
            }

            // report value again.
            if (enabled)
            {
                DataValue dv = null;

                if (item.Id.IdType == 0)
                {
                    dv = ReadVariableAttribute(transaction.Context, item.Id, operationHandle.NodeHandle.AttributeId);
                }
                else
                {
                    dv = ReadFolderAttribute(transaction.Context, item.Id, operationHandle.NodeHandle.AttributeId);
                }

                // do the initial callback.
                item.Callback(transaction.Context, item.Handle, dv, false);
            }

            // report the results.
            ((SetMonitoringModeCompleteEventHandler)transaction.Callback)(
                operationHandle,
                transaction.CallbackData,
                StatusCodes.Good,
                false);

            return StatusCodes.Good;
        }
        #endregion

        #region Identifier Class
        internal enum IdType
        {
            Variable,
            Folder
        }

        /// <summary>
        /// A class that stores an identifier for the node.
        /// </summary>
        private class Identifier
        {
            public IdType IdType;
            public int VariableIndex;
            public int[] HierarchicalAddress;
            // public string ComponentName;
            public LargeArrayNodeManager Manager;

            public NodeId GetNodeId()
            {
                if (IdType == 0)
                {
                    return new NodeId((uint)VariableIndex, Manager.DefaultNamespaceIndex);
                }

                StringBuilder buffer = new StringBuilder();

                if (HierarchicalAddress != null)
                {
                    for (int ii = 0; ii < HierarchicalAddress.Length; ii++)
                    {
                        if (buffer.Length > 0)
                        {
                            buffer.Append('.');
                        }

                        buffer.AppendFormat("{0:D2}", HierarchicalAddress[ii]);
                    }
                }

                return ParsedNodeId.Construct(0, buffer.ToString(), Manager.DefaultNamespaceIndex);
            }

            public NodeId GetParentNodeId()
            {
                if (IdType == 0)
                {
                    int square = Manager.m_maxFolderSize * Manager.m_maxFolderSize;

                    int level1 = VariableIndex / square;
                    int level2 = (VariableIndex - level1 * square) / Manager.m_maxFolderSize;

                    StringBuilder buffer = new StringBuilder();

                    buffer.AppendFormat("{0:D2}.", level1);
                    buffer.AppendFormat("{0:D2}.", level2);

                    return ParsedNodeId.Construct(0, buffer.ToString(), Manager.DefaultNamespaceIndex);
                }

                if (IdType == IdType.Folder)
                {
                    StringBuilder buffer = new StringBuilder();

                    for (int ii = 0; ii < HierarchicalAddress.Length - 1; ii++)
                    {
                        if (buffer.Length > 0)
                        {
                            buffer.Append('.');
                        }

                        buffer.AppendFormat("{0:D2}", HierarchicalAddress[ii]);
                    }

                    return ParsedNodeId.Construct(0, buffer.ToString(), Manager.DefaultNamespaceIndex);
                }

                return null;
            }

            public NodeId GetChildNodeId(int index)
            {
                if (index < 0 || index > Manager.m_maxFolderSize)
                {
                    return null;
                }

                if (HierarchicalAddress == null)
                {
                    return null;
                }

                if (IdType == IdType.Folder)
                {
                    if (HierarchicalAddress.Length == 2)
                    {

                        int square = Manager.m_maxFolderSize * Manager.m_maxFolderSize;

                        int id = HierarchicalAddress[0] * square;
                        id += HierarchicalAddress[1] * Manager.m_maxFolderSize;
                        id += index;

                        if (id >= Manager.m_registers.Length)
                        {
                            return null;
                        }

                        return new NodeId((uint)id, Manager.DefaultNamespaceIndex);
                    }
                    else
                    {
                        StringBuilder buffer = new StringBuilder();

                        for (int ii = 0; ii < HierarchicalAddress.Length; ii++)
                        {
                            if (buffer.Length > 0)
                            {
                                buffer.Append('.');
                            }

                            buffer.AppendFormat("{0:D2}", HierarchicalAddress[ii]);
                        }

                        buffer.AppendFormat(".{0:D2}", index);

                        return ParsedNodeId.Construct(0, buffer.ToString(), Manager.DefaultNamespaceIndex);
                    }
                }

                return null;
            }

            public QualifiedName GetBrowseName()
            {
                if (IdType == 0)
                {
                    return new QualifiedName(String.Format("{0:D2}", VariableIndex), Manager.DefaultNamespaceIndex);
                }

                if (HierarchicalAddress != null && HierarchicalAddress.Length > 0)
                {
                    return new QualifiedName(String.Format("{0:D2}", HierarchicalAddress[HierarchicalAddress.Length - 1]), Manager.DefaultNamespaceIndex);
                }

                return null;
            }

            public LocalizedText GetDisplayName()
            {
                if (IdType == 0)
                {
                    return new LocalizedText(String.Format("{0:D2}", VariableIndex));
                }

                if (HierarchicalAddress != null && HierarchicalAddress.Length > 0)
                {
                    return new LocalizedText(String.Format("{0:D2}", HierarchicalAddress[HierarchicalAddress.Length - 1]));
                }

                return null;
            }

            public static Identifier Parse(LargeArrayNodeManager manager, NodeId nodeId)
            {
                if (nodeId.IdType == UnifiedAutomation.UaBase.IdType.Numeric)
                {
                    uint index = (uint)nodeId.Identifier;

                    if (index >= manager.m_registers.Length)
                    {
                        return null;
                    }

                    return new Identifier() { VariableIndex = (int)index, Manager = manager };
                }

                ParsedNodeId pnd = ParsedNodeId.Parse(nodeId);

                if (pnd == null)
                {
                    return null;
                }

                if (pnd.BaseType != 0)
                {
                    return null;
                }

                string[] fields = pnd.BaseId.Split('.');
                int[] levels = new int[fields.Length];

                for (int ii = 0; ii < fields.Length; ii++)
                {
                    for (int jj = 0; jj < fields[ii].Length; jj++)
                    {
                        if (!Char.IsDigit(fields[ii][jj]))
                        {
                            return null;
                        }

                        levels[ii] *= 10;
                        levels[ii] += Convert.ToInt32(fields[ii][jj]) - '0';
                    }
                }

                return new Identifier() { IdType = IdType.Folder, HierarchicalAddress = levels, Manager = manager };
            }

            public static NodeId GetRootNodeId(int index, ushort namespaceIndex)
            {
                return ParsedNodeId.Construct(0, String.Format("{0:D2}", index), namespaceIndex);
            }
        }
        #endregion

        #region DataMonitoredItem Class
        private class DataMonitoredItem
        {
            public Identifier Id;
            public MonitoredItemHandle Handle;
            public DataChangeEventHandler Callback;
            public int VariableIndex;
            public MonitoringMode MonitoringMode;
        }
        #endregion

        #region Private Methods
        private DataValue ReadVariableAttribute(
            RequestContext context,
            Identifier id,
            uint attributeId)
        {
            DataValue dv = new DataValue();

            switch (attributeId)
            {
                case Attributes.NodeId: { dv.WrappedValue = id.GetNodeId(); break; }
                case Attributes.NodeClass: { dv.WrappedValue = (int)NodeClass.Variable; break; }
                case Attributes.BrowseName: { dv.WrappedValue = id.GetBrowseName(); break; }
                case Attributes.DisplayName: { dv.WrappedValue = id.GetDisplayName(); break; }
                case Attributes.WriteMask: { dv.WrappedValue = (uint)0; break; }
                case Attributes.UserWriteMask: { dv.WrappedValue = (uint)0; break; }
                case Attributes.DataType: { dv.WrappedValue = DataTypeIds.Double; break; }
                case Attributes.ValueRank: { dv.WrappedValue = ValueRanks.Scalar; break; }
                case Attributes.AccessLevel: { dv.WrappedValue = AccessLevels.CurrentReadOrWrite; break; }
                case Attributes.UserAccessLevel: { dv.WrappedValue = AccessLevels.CurrentReadOrWrite; break; }
                case Attributes.Historizing: { dv.WrappedValue = false; break; }
                case Attributes.MinimumSamplingInterval: { dv.WrappedValue = MinimumSamplingIntervals.Continuous; break; }

                case Attributes.Value:
                {
                    dv.WrappedValue = m_registers[id.VariableIndex];
                    break;
                }

                default:
                {
                    return new DataValue(StatusCodes.BadAttributeIdInvalid);
                }
            }

            dv.SourceTimestamp = DateTime.UtcNow;
            dv.ServerTimestamp = DateTime.UtcNow;

            return dv;
        }

        private StatusCode FinishRead(
            NodeAttributeOperationHandle operationHandle,
            ReadValueId settings)
        {
            DataTransactionHandle transaction = operationHandle.Transaction as DataTransactionHandle;

            // check for invalid attribute id.
            if (!Attributes.IsValid(settings.AttributeId))
            {
                return StatusCodes.BadAttributeIdInvalid;
            }

            // check for invalid index range.
            if (!String.IsNullOrEmpty(settings.IndexRange))
            {
                return StatusCodes.BadIndexRangeNoData;
            }

            // check for invalid data encoding.
            if (!QualifiedName.IsNull(settings.DataEncoding))
            {
                return StatusCodes.BadDataEncodingInvalid;
            }

            // check if read access is available.
            if (operationHandle.NodeHandle.UserAccessManager != null)
            {
                if (!operationHandle.NodeHandle.UserAccessManager.HasAccess(transaction.Context, operationHandle.NodeHandle, UserAccessMask.Read))
                {
                    return StatusCodes.BadUserAccessDenied;
                }
            }

            // read the value.
            Identifier id = operationHandle.NodeHandle.UserData as Identifier;

            if (id == null)
            {
                return StatusCodes.BadNodeIdUnknown;
            }

            DataValue dv = null;

            if (id.IdType == 0)
            {
                dv = ReadVariableAttribute(transaction.Context, id, operationHandle.AttributeId);
            }
            else
            {
                dv = ReadFolderAttribute(transaction.Context, id, operationHandle.AttributeId);
            }

            // report results.
            ((ReadCompleteEventHandler)transaction.Callback)(operationHandle, transaction.CallbackData, dv, false);

            return StatusCodes.Good;
        }

        private DataValue ReadFolderAttribute(
            RequestContext context,
            Identifier id,
            uint attributeId)
        {
            DataValue dv = new DataValue();

            int index = id.HierarchicalAddress[id.HierarchicalAddress.Length - 1];

            switch (attributeId)
            {
                case Attributes.NodeId: { dv.WrappedValue = id.GetNodeId(); break; }
                case Attributes.NodeClass: { dv.WrappedValue = (int)NodeClass.Object; break; }
                case Attributes.BrowseName: { dv.WrappedValue = id.GetBrowseName(); break; }
                case Attributes.DisplayName: { dv.WrappedValue = id.GetDisplayName(); break; }
                case Attributes.WriteMask: { dv.WrappedValue = (uint)0; break; }
                case Attributes.UserWriteMask: { dv.WrappedValue = (uint)0; break; }
                case Attributes.EventNotifier: { dv.WrappedValue = EventNotifiers.None; break; }

                default:
                {
                    return new DataValue(StatusCodes.BadAttributeIdInvalid);
                }
            }

            dv.SourceTimestamp = DateTime.UtcNow;

            return dv;
        }

        private StatusCode WriteValue(
            RequestContext context,
            Identifier id,
            Variant value)
        {
            if (value.TypeInfo == null || value.TypeInfo != TypeInfo.Scalars.Int32)
            {
                return StatusCodes.BadTypeMismatch;
            }

            m_registers[id.VariableIndex] = value.ToInt32();

            ReportDataChanges(id.VariableIndex, new DataValue() { WrappedValue = value, SourceTimestamp = DateTime.UtcNow, ServerTimestamp = DateTime.UtcNow });

            return StatusCodes.Good;
        }

        private void ReportDataChanges(int index, DataValue dataValue)
        {
            DataMonitoredItem[] items = m_monitoredRegisters[index];

            if (items != null)
            {
                for (int ii = 0; ii < items.Length; ii++)
                {
                    if (items[ii].MonitoringMode != MonitoringMode.Disabled)
                    {
                        DataChangeEventHandler callback = items[ii].Callback;

                        if (callback != null)
                        {
                            items[ii].Callback(
                                m_server.DefaultRequestContext,
                                items[ii].Handle,
                                dataValue,
                                false);
                        }
                    }
                }
            }
        }

        private void DoSimulation(object state)
        {
            try
            {
                for (int ii = 0; ii < m_registers.Length; ii++)
                {
                    int value = m_registers[ii] = m_registers[ii] + 1;
                    ReportDataChanges(ii, new DataValue() { WrappedValue = value, SourceTimestamp = DateTime.UtcNow, ServerTimestamp = DateTime.UtcNow });
                }
            }
            catch (Exception e)
            {
                TraceServer.Error(e, "Unexpected error in simulation thread.");
            }
        }
        #endregion

        #region Private Fields
        private object m_lock = new object();
        private ServerManager m_server;
        private NodeId m_rootId;
        private int[] m_registers;
        private DataMonitoredItem[][] m_monitoredRegisters;
        private int m_maxFolderSize;
        private Dictionary<uint, DataMonitoredItem> m_monitoredItems;
        private Timer m_simulationTimer;
        #endregion
    }
}
