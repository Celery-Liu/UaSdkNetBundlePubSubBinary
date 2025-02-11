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
using System.IO;
using System.Reflection;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaServer;

namespace YourCompany.GettingStarted
{
    internal partial class Lesson09NodeManager
    {
        protected override HistoryReadResult HistoryReadEvent(
            RequestContext context,
            ReadEventDetails details,
            HistoryEventHandle nodeHandle,
            ref HistoryContinuationPoint continuationPoint)
        {
            HistoryReadResult result = new HistoryReadResult();

            //HistoryReadEvent Step 2: Check if Source is valid.
            HistoryEventSource eventSource = m_historyEventManager.GetEventSource(nodeHandle.NodeId);

            if (eventSource == null)
            {
                return new HistoryReadResult() { StatusCode = StatusCodes.BadHistoryOperationUnsupported };
            }

            //HistoryReadEvent Step 3: Check if filter is valid.
            EventFilterResult filterResult = null;
            //The filter manager is created in this step, too.
            StatusCode error = Server.FilterManager.ValidateFilter(context, details.Filter, out filterResult);

            if (error.IsBad())
            {
                return new HistoryReadResult() { StatusCode = StatusCodes.BadEventFilterInvalid };
            }

            //HistoryReadEvent Step 4: Get Historical Events
            HistoricalEventFields eventFields = null;
            //If continuationPoint != null, we can use the historical events that are saved in the
            //continuationPoint
            if (continuationPoint != null)
            {
                eventFields = GetHistoricalEventFieldsFromContinationPoint(continuationPoint);

                if (eventFields == null)
                {
                    return new HistoryReadResult() { StatusCode = StatusCodes.BadContinuationPointInvalid };
                }

                continuationPoint = null;
            }

            //If continuationPoint == null, we have to get the event fields from the event source
            else
            {
                eventFields = GetHistoricalEventFieldsFromDataSource(eventSource, context, details, nodeHandle);
            }

            //HistoryReadEvent Step 5: Add the nodes to the result.
            //If there are more results that match start time, end time and the filters that NumValuesPerNode,
            //we have to use the continuationPoint
            bool useContinuationPoint;
            HistoryEvent data = eventFields.NextEventFields(details.NumValuesPerNode, out useContinuationPoint);
            result.HistoryData = new ExtensionObject(data);
            //Save the remaining results
            if (useContinuationPoint)
            {
                continuationPoint = CreateHistoryEventsContinuationPoint(eventFields);
            }

            return result;
        }

        //Step 1
        /// <summary>
        /// Sets up the address space information and managing data for HistoryReadEvents.
        /// Sets up the InternalClient for receiving the fired events.
        /// </summary>
        private void SetupEventHistory()
        {
            //Create a list of browse names. This list is used for setting up the filter for
            //the internal client and assigning the received event field values to the "data base entries".
            QualifiedNameCollection eventFieldNames = new QualifiedNameCollection();
            eventFieldNames.Add(BrowseNames.EventType);
            eventFieldNames.Add(BrowseNames.Time);
            eventFieldNames.Add(BrowseNames.ReceiveTime);
            eventFieldNames.Add(BrowseNames.EventId);
            eventFieldNames.Add(BrowseNames.SourceName);
            eventFieldNames.Add(BrowseNames.SourceNode);
            eventFieldNames.Add(BrowseNames.Severity);
            eventFieldNames.Add(BrowseNames.Message);
            eventFieldNames.Add(new QualifiedName(yourorganisation.BA.BrowseNames.State, TypeNamespaceIndex));
            eventFieldNames.Add(new QualifiedName(yourorganisation.BA.BrowseNames.Temperature, TypeNamespaceIndex));

            m_historyEventManager = new HistoryEventManager(Server, eventFieldNames);

            NodeId controllersId = new NodeId("Controllers", InstanceNamespaceIndex);
            ObjectNode controllersFolder = FindInMemoryNode(controllersId)
                as ObjectNode;
            if (controllersFolder != null)
            {
                lock (InMemoryNodeLock)
                {
                    //It is necessary to set the HistoryRead in EventNotifier. If this bit is not set,
                    //HistroryReadEvent will not be called.
                    //SubscribeToEvents hat to be set because a subscription using the InternalClient is used
                    //to collect the event data.
                    controllersFolder.EventNotifier = EventNotifiers.HistoryRead | EventNotifiers.SubscribeToEvents;
                }
            }
            HistoryEventSource eventSource = new HistoryEventSource();
            m_historyEventManager.AddEventSource(controllersId, eventSource, true);

            //Create the property that should be added to objects that provide an event history.
            CreateVariableSettings HistoricalEventFilterSettings = new CreateVariableSettings()
            {
                AccessLevel = AccessLevels.CurrentRead,
                BrowseName = BrowseNames.HistoricalEventFilter,
                DataType = DataTypeIds.EventFilter,
                Historizing = false,
                RequestedNodeId = new NodeId(BrowseNames.HistoricalEventFilter, InstanceNamespaceIndex),
                TypeDefinitionId = VariableTypeIds.PropertyType,
                ValueRank = -1,
                Value = new ExtensionObject(m_historyEventManager.EventFilter),
                ReferenceTypeId = ReferenceTypeIds.HasProperty,
                ParentNodeId = controllersFolder.NodeId
            };
            m_historicalEventFilter = CreateVariable(Server.DefaultRequestContext, HistoricalEventFilterSettings);

            foreach (BlockConfiguration block in m_system.GetBlocks())
            {
                NodeId controllerId = new NodeId(block.Name, InstanceNamespaceIndex);
                ObjectNode controllerObject = FindInMemoryNode(controllerId)
                    as ObjectNode;
                if (controllerObject != null)
                {
                    lock (InMemoryNodeLock)
                    {
                        //Set the HistoryRead bit for the controllers
                        controllerObject.EventNotifier = (byte)(controllerObject.EventNotifier|EventNotifiers.HistoryRead);
                    }
                    //Add a reference to the property. Alternatively a new variable can be created.
                    AddReference(Server.DefaultRequestContext, controllerObject.NodeId, ReferenceTypeIds.HasProperty, false, m_historicalEventFilter.NodeId, true);

                    m_historyEventManager.AddEventSource(controllerId, eventSource, false);
                }
            }
        }

        //HistoryReadEvent Step 4: Get Historical Events
        /// <summary>
        /// This method reads the Events from the event source.
        /// It evaluates the start and end time and evaluates the SelectClause and the WhereClause.
        /// </summary>
        private HistoricalEventFields GetHistoricalEventFieldsFromDataSource(
            HistoryEventSource eventSource,
            RequestContext context,
            ReadEventDetails details,
            HistoryEventHandle nodeHandle)
        {
            // evaluate the start and end time
            DateTime startTime;
            DateTime endTime;
            bool timeFlowsBackward;
            if (details.EndTime == DateTime.MinValue
                || (details.EndTime.CompareTo(details.StartTime) >= 0)
                    && details.StartTime != DateTime.MinValue)
            {
                startTime = details.StartTime;
                endTime = details.EndTime;
                timeFlowsBackward = false;
            }
            else
            {
                startTime = details.EndTime;
                endTime = details.StartTime;
                timeFlowsBackward = true;
            }
            //Get all events within the specified time space of the specified node
            //On some systems there will be database queries to get this information
            System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.DateTime, HistoryEventData>> result
                = eventSource.Events.Where(
                        e => e.Key.CompareTo(startTime) >= 0
                        && (endTime == DateTime.MinValue || e.Key.CompareTo(endTime) <= 0)
                        && (e.Value.SourceNode == nodeHandle.NodeId || nodeHandle.NodeId == new NodeId("Controllers", InstanceNamespaceIndex)));

            //Returned events are sorted by Date.
            //If time flows backward the event fields have to be returned backward
            if (timeFlowsBackward)
            {
                result = result.Reverse();
            }

            HistoricalEventFields ret = new HistoricalEventFields();
            try
            {
                Server.FilterManager.UpdateReferenceCount(details.Filter, true);
                foreach (KeyValuePair<DateTime, HistoryEventData> element in result)
                {
                    // Create a GenericEvent from the data that is saved in the event source.
                    // We can use filter functionality of SDK in this case.
                    // If the event history is saved in memory, the event source can save GenericEvents
                    // directly to get a better performance. But in most use cases, the historical event
                    // data is saved in a data base.
                    GenericEvent genericEvent = element.Value.ToGenericEvent(Server.FilterManager);

                    // apply the filter.
                    if (!FilterManager.Evaluate(context, details.Filter.WhereClause, genericEvent))
                    {
                        continue;
                    }

                    // fetch the event fields.
                    HistoryEventFieldList fields = new HistoryEventFieldList();

                    foreach (SimpleAttributeOperand clause in details.Filter.SelectClauses)
                    {
                        // get the value of the attribute (apply localization).
                        Variant value = genericEvent.Get(clause);

                        // add value.
                        fields.EventFields.Add(value);
                    }
                    ret.Data.Add(fields);
                }
            }
            finally
            {
                Server.FilterManager.UpdateReferenceCount(details.Filter, false);
            }

            return ret;
        }

        private HistoricalEventFields GetHistoricalEventFieldsFromContinationPoint(HistoryContinuationPoint continuationPoint)
        {
            return continuationPoint as HistoricalEventFields;
        }

        private HistoryContinuationPoint CreateHistoryEventsContinuationPoint(HistoricalEventFields events)
        {
            return events;
        }

        #region Private fields
        private VariableNode m_historicalEventFilter;
        private HistoryEventManager m_historyEventManager;
        #endregion
    }

    //HistoryReadEvent Step 1: Specify nodes with Event history.
    #region HistoryEventSource class
    internal class HistoryEventSource
    {
        public HistoryEventSource()
        {
            m_events = new SortedList<DateTime, HistoryEventData>();
        }

        #region public properties
        public SortedList<DateTime, HistoryEventData > Events
        {
            get
            {
                return m_events;
            }
        }
        #endregion

        #region public interface
        /// <summary>
        /// Adds the event to the data base.
        /// </summary>
        /// <remarks>
        /// In this example the event data is stored in memory. On most systems a
        /// data base will be used for storing data.
        /// </remarks>
        public void AddEvent(NodeId nodeId, HistoryEventData e)
        {
            m_events.Add(e.Time, e);
        }
        #endregion

        #region private fields
        private SortedList<DateTime, HistoryEventData> m_events;
        #endregion
    }
    #endregion

    #region HistoryEventData
    /// <summary>
    /// Stores the data of a historical event.
    /// </summary>
    internal class HistoryEventData
    {
        public HistoryEventData()
        {
            // This class uses key value pairs to store the data.
            // Storing the data in lists would be more efficient.
            Data = new Dictionary<QualifiedName,Variant>();
        }

        #region Public Interface
        public void AddEventField(QualifiedName browseName, Variant value)
        {
            if (browseName == "Time")
            {
                Time = value.ToDateTime();
            }
            else if (browseName == "SourceNode")
            {
                SourceNode = value.ToNodeId();
            }
            Data.Add(browseName, value);
        }

        public GenericEvent ToGenericEvent(FilterManager filterManager)
        {
            GenericEvent ret = new GenericEvent(filterManager)
            {
                Time = Time,
                SourceNode = SourceNode
            };
            // If the data is stored in a list (i.e. if a more efficient implementation is used),
            // GenericEvent.Set(int handle, Variant value) has to be used. This method is more efficient.
            foreach (KeyValuePair<QualifiedName,Variant> pair in Data)
            {
                ret.Set(AbsoluteName.ToString(pair.Key), pair.Value);
            }

            return ret;
        }
        #endregion

        #region Public Properties
        public DateTime Time { get; internal set;}
        public NodeId SourceNode { get; internal set;}
        public Dictionary<QualifiedName, Variant> Data { get; internal set;}
        #endregion
    }
    #endregion

    //HistoryReadEvent Step 4: Get Historical Events
    //Create a class that contains all data that is requested. The amount of data can be too big,
    //so this class can be used for the continuation point.
    #region HistoricalEventFields class
    internal class HistoricalEventFields : HistoryContinuationPoint
    {
        public HistoricalEventFields()
        {
            Data = new HistoryEventFieldListCollection();
        }

        #region Public Properties
        public HistoryEventFieldListCollection Data { get; set; }
        #endregion

        //HistoryReadEvent Step 5: Add the nodes to the result.
        /// <summary>
        /// Takes the next NumValuesPerNode and removes them. EventsRemaining indicates whether
        /// events are still available.
        /// </summary>
        public HistoryEvent NextEventFields(uint NumValuesPerNode, out bool EventsRemaining)
        {
            HistoryEvent ret = new HistoryEvent();
            EventsRemaining = false;
            int iIndex = 0;
            for (; (iIndex < NumValuesPerNode || NumValuesPerNode == 0) && Data.Count > 0; iIndex++)
            {
                ret.Events.Add(Data.First());
                Data.RemoveAt(0);
            }
            if (Data.Count > 0)
            {
                EventsRemaining = true;
            }
            return ret;
        }
    }
    #endregion

    #region HistoryEventManager
    /// <summary>
    /// Links EventSources to nodes. Sets up ServerInternalClient to write events to the event Source.
    /// </summary>
    internal class HistoryEventManager
    {
        #region Constructor
        public HistoryEventManager(ServerManager server, QualifiedNameCollection browseNames)
        {
            m_filterManager = server.FilterManager;
            RegisterEventFields(browseNames);
            m_client = server.InternalClient;
            m_requestContext = server.DefaultRequestContext;
            m_sources = new Dictionary<NodeId, HistoryEventSource>();
        }
        #endregion

        #region Public Properties
        public QualifiedNameCollection EventFieldBrowseNames
        {
            get
            {
                return m_eventFieldBrowseNames;
            }
        }

        public EventFilter EventFilter
        {
            get
            {
                return m_eventFilter;
            }
        }
        #endregion

        #region Public Interface
        /// <summary>
        /// Adds the event source to the HistoryEventManager.
        /// </summary>
        /// <param name="nodeId"></param>
        /// <param name="eventSource"></param>
        /// <param name="createSubsricption">If true, an internal subscription is created
        /// to receive event fields.</param>
        public void AddEventSource(NodeId nodeId, HistoryEventSource eventSource, bool createSubsricption)
        {
            if (createSubsricption)
            {
                CreateEventSubscription(nodeId, eventSource, m_eventFilter);
            }
            m_sources.Add(nodeId, eventSource);
        }

        /// <summary>
        /// Uses ServerManager.InternalClient to create a subscription for events.
        /// The received event fields will be stored.
        /// </summary>
        private void CreateEventSubscription(NodeId nodeId, HistoryEventSource eventSource, EventFilter eventFilter)
        {
            List<InternalClientFullEventMonitoredItem> montoredItmes
                = new List<InternalClientFullEventMonitoredItem>();
            InternalClientFullEventMonitoredItem eventMonitoredItem = new InternalClientFullEventMonitoredItem()
            {
                NodeId = nodeId,
                Filter = eventFilter
            };

            eventMonitoredItem.Callback = OnInternalClientEventEvent;
            eventMonitoredItem.CallbackData = eventSource;

            montoredItmes.Add(eventMonitoredItem);
            m_client.CreateEventMonitoredItems(
                m_requestContext,
                montoredItmes);
        }

        public HistoryEventSource GetEventSource(NodeId nodeId)
        {
            HistoryEventSource ret;
            if (m_sources.TryGetValue(nodeId, out ret))
            {
                return ret;
            }
            return null;
        }

        #endregion

        #region Helpers
        private void RegisterEventFields(QualifiedNameCollection browseNames)
        {
            m_eventFieldBrowseNames = browseNames;
            m_eventFilter = new EventFilter();

            if (m_eventFieldBrowseNames == null)
            {
                m_eventFieldBrowseNames = new QualifiedNameCollection();
            }

            foreach (QualifiedName browseName in m_eventFieldBrowseNames)
            {
                m_filterManager.CreateFieldHandle(AbsoluteName.ToString(browseName));
                SelectEventField(m_eventFilter, browseName);
            }
        }

        private void SelectEventField(
            EventFilter filter,
            QualifiedName browseName)
        {
            SimpleAttributeOperand eventField = new SimpleAttributeOperand()
            {
                TypeDefinitionId = ObjectTypeIds.BaseEventType,
                AttributeId = Attributes.Value,
                BrowsePath = new QualifiedNameCollection(new QualifiedName[] { browseName })
            };
            filter.SelectClauses.Add(eventField);
        }

        /// <summary>
        /// The callback for the InternalClient
        /// </summary>
        private void OnInternalClientEventEvent(
            RequestContext context,
            MonitoredItemHandle itemHandle,
            EventFieldList eventFields,
            object callbackData)
        {
            HistoryEventSource eventSource = callbackData as HistoryEventSource;
            AddEventFieldsToEventSource(eventSource, itemHandle.NodeId, eventFields);
        }

        /// <summary>
        /// Merges the eventFields to a data class and adds this to the eventSource.
        /// </summary>
        private void AddEventFieldsToEventSource(HistoryEventSource eventSource, NodeId sourceNodeId, EventFieldList eventFields)
        {
            HistoryEventData data = new HistoryEventData();
            if (eventFields.EventFields.Count == m_eventFieldBrowseNames.Count)
            {
                //Collect the received event fields and add it to a data structure.
                for (int i = 0; i < m_eventFieldBrowseNames.Count; i++)
                {
                    try
                    {
                        data.AddEventField(m_eventFieldBrowseNames[i], eventFields.EventFields[i]);
                    }
                    catch (Exception)
                    {
                        // ToDo: Error handling
                    }
                }
                //Add the event to the data base.
                eventSource.AddEvent(sourceNodeId, data);
            }
        }

        #endregion

        #region private fields
        Dictionary<NodeId, HistoryEventSource> m_sources;
        QualifiedNameCollection m_eventFieldBrowseNames;
        EventFilter m_eventFilter;
        FilterManager m_filterManager;
        ServerInternalClient m_client;
        RequestContext m_requestContext;
        #endregion

    }
    #endregion
}