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
using System.Globalization;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaServer;
using UnifiedAutomation.EventHistory;

namespace UnifiedAutomation.Demo
{
    /// <summary>
    /// A class that manages a source for event history.
    /// </summary>
    public class HistoryEventSource
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="HistoryEventSource"/> class.
        /// </summary>
        public HistoryEventSource()
        {
            m_dataset = new DataSet();
            m_filter = new EventFilter();
        }
        #endregion

        #region Public Members
        /// <summary>
        /// Gets the filter.
        /// </summary>
        public EventFilter Filter { get { return m_filter; } }

        /// <summary>
        /// Gets field handles
        /// </summary>
        public List<int> FieldHandles { get { return m_fieldHandles; } }

        /// <summary>
        /// Loads the events from the stream.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="istrm">The stream.</param>
        public void Load(RequestContext context, FilterManager filterManager, Stream istrm)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(EventHistoryType));
            EventHistoryType history = (EventHistoryType)serializer.Deserialize(istrm);

            NamespaceTable namespaceUris = new NamespaceTable();
            StringTable serverUris = new StringTable();

            if (history.NamespaceUri != null)
            {
                foreach (var uri in history.NamespaceUri)
                {
                    namespaceUris.Add(uri);
                }
            }

            m_fieldHandles = new List<int>();
            m_filter.SelectClauses.Clear();
            m_dataset.Tables.Clear();

            AddField(context, filterManager, null, BrowseNames.Time, namespaceUris);
            AddField(context, filterManager, null, BrowseNames.ReceiveTime, namespaceUris);
            AddField(context, filterManager, null, BrowseNames.EventId, namespaceUris);
            AddField(context, filterManager, null, BrowseNames.EventType, namespaceUris);
            AddField(context, filterManager, null, BrowseNames.SourceName, namespaceUris);
            AddField(context, filterManager, null, BrowseNames.SourceNode, namespaceUris);
            AddField(context, filterManager, null, BrowseNames.Severity, namespaceUris);
            AddField(context, filterManager, null, BrowseNames.Message, namespaceUris);

            if (history.SelectClause != null)
            {
                foreach (var clause in history.SelectClause)
                {
                    AddField(context, filterManager, clause.EventTypeId, clause.Value, namespaceUris);
                }
            }

            EventFilterResult result = null;
            StatusCode error = filterManager.ValidateFilter(context, m_filter, out result);

            if (error.IsBad())
            {
                TraceServer.Error("Unexpected error parsing SelectClause in event history file. Error={0}", error);
            }

            filterManager.UpdateReferenceCount(m_filter, true);

            DataTable table = new DataTable();
            m_dataset.Tables.Add(table);

            table.Columns.Add(BrowseNames.Time, typeof(DateTime));
            table.Columns.Add(BrowseNames.ReceiveTime, typeof(DateTime));
            table.Columns.Add(BrowseNames.EventId, typeof(string));
            table.Columns.Add(BrowseNames.EventType, typeof(string));
            table.Columns.Add("Event", typeof(GenericEvent));

            m_dataset.Tables[0].DefaultView.Sort = "Time";

            if (history.Event != null)
            {
                DateTime baseTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0, DateTimeKind.Local).ToUniversalTime();

                foreach (var instance in history.Event)
                {
                    DateTime time = baseTime.AddSeconds(instance.Time);
                    DateTime receiveTime = baseTime.AddSeconds(instance.ReceiveTime);
                    byte[] eventId = instance.EventId;

                    NodeId eventTypeId = ObjectTypeIds.BaseEventType;

                    try
                    {
                        eventTypeId = (NodeId)ExpandedNodeId.Parse(instance.EventTypeId, namespaceUris, context.NamespaceUris);
                    }
                    catch (Exception exception)
                    {
                        TraceServer.Error(exception, "Unexpected error parsing EventTypeId in event history file. EventTypeId='{0}'", instance.EventTypeId);
                        eventTypeId = ObjectTypeIds.BaseEventType;
                    }

                    string sourceName = instance.SourceName;
                    NodeId sourceNode = ObjectIds.Server;

                    try
                    {
                        sourceNode = (NodeId)ExpandedNodeId.Parse(instance.SourceNode, namespaceUris, context.NamespaceUris);
                    }
                    catch (Exception exception)
                    {
                        TraceServer.Error(exception, "Unexpected error parsing SourceNode in event history file. SourceNode='{0}'", instance.SourceNode);
                        sourceNode = ObjectIds.Server;
                    }

                    ushort severity = (ushort)instance.Severity;
                    LocalizedText message = new LocalizedText(instance.Message);

                    GenericEvent e = new GenericEvent(filterManager);

                    int ii = 0;

                    e.Set(m_fieldHandles[ii++], time);
                    e.Set(m_fieldHandles[ii++], receiveTime);
                    e.Set(m_fieldHandles[ii++], eventId);
                    e.Set(m_fieldHandles[ii++], eventTypeId);
                    e.Set(m_fieldHandles[ii++], sourceName);
                    e.Set(m_fieldHandles[ii++], sourceNode);
                    e.Set(m_fieldHandles[ii++], severity);
                    e.Set(m_fieldHandles[ii++], message);

                    if (instance.Field != null && instance.Field.Length > 0)
                    {
                        foreach (var field in instance.Field)
                        {
                            if (field == null)
                            {
                                continue;
                            }

                            try
                            {
                                using (XmlDecoder decoder = new XmlDecoder(field, context.Server.MessageContext))
                                {
                                    decoder.SetMappingTables(namespaceUris, serverUris);

                                    TypeInfo typeInfo = null;
                                    object contents = decoder.ReadVariantContents(out typeInfo);
                                    decoder.Close();

                                    e.Set(m_fieldHandles[ii++], new Variant(contents, typeInfo));
                                }
                            }
                            catch (Exception exception)
                            {
                                TraceServer.Error(exception, "Unexpected error parsing Event instance field in event history file. Value='{0}'", field.InnerXml);
                            }
                        }
                    }

                    DataRow row = m_dataset.Tables[0].NewRow();

                    row[0] = time;
                    row[1] = receiveTime;
                    row[2] = ((ByteString)eventId).ToString();
                    row[3] = eventTypeId.ToString();
                    row[4] = e;

                    m_dataset.Tables[0].Rows.Add(row);
                }
            }

            m_dataset.AcceptChanges();
        }

        public DataView GetDataView(DateTime startTime, DateTime endTime)
        {
            if (startTime == DateTime.MinValue && endTime == DateTime.MinValue)
            {
                return m_dataset.Tables[0].DefaultView;
            }

            StringBuilder filter = new StringBuilder();

            if (startTime > endTime && endTime != DateTime.MinValue)
            {
                filter.AppendFormat(CultureInfo.InvariantCulture, "(Time <= #{0}#)", startTime);

                if (endTime != DateTime.MinValue)
                {
                    filter.AppendFormat(CultureInfo.InvariantCulture, "AND (Time > #{0}#)", endTime);
                }
            }

            else if (startTime <= endTime && startTime != DateTime.MinValue)
            {
                filter.AppendFormat(CultureInfo.InvariantCulture, "(Time >= #{0}#)", startTime);

                if (endTime != DateTime.MinValue)
                {
                    filter.AppendFormat(CultureInfo.InvariantCulture, "AND (Time < #{0}#)", endTime);
                }
            }

            else if (startTime == DateTime.MinValue)
            {
                filter.AppendFormat(CultureInfo.InvariantCulture, "(Time < #{0}#)", endTime);
            }

            DataView view = new DataView(
                m_dataset.Tables[0],
                filter.ToString(),
                "Time",
                DataViewRowState.CurrentRows);

            return view;
        }

        public StatusCode Update(
            RequestContext context,
            PerformUpdateType updateType,
            ByteString targetEventId,
            GenericEvent e)
        {
            DataView view = new DataView(m_dataset.Tables[0], null, "EventId", DataViewRowState.CurrentRows);

            if (updateType == PerformUpdateType.Insert)
            {
                if (!ByteString.IsNull(e.EventId))
                {
                    if (view.Find(((ByteString)e.EventId).ToString()) >= 0)
                    {
                        return StatusCodes.BadEntryExists;
                    }
                }
            }
            else
            {
                int index = view.Find(targetEventId.ToString());

                if (index >= 0)
                {
                    DataRow row = view[index].Row;

                    row[0] = e.Time;
                    row[1] = e.Get(m_fieldHandles[1]).GetValue<DateTime>(DateTime.MinValue);
                    row[2] = ((ByteString)e.EventId).ToString();
                    row[3] = e.EventType.ToString();
                    row[4] = e;

                    m_dataset.AcceptChanges();
                    return StatusCodes.Good;
                }

                if (updateType == PerformUpdateType.Replace)
                {
                    return StatusCodes.BadNoEntryExists;
                }
            }

            e.EventId = Guid.NewGuid().ToByteArray();
            e.Set(m_fieldHandles[2], e.EventId);

            DataRow newRow = m_dataset.Tables[0].NewRow();

            newRow[0] = e.Time;
            newRow[1] = e.Get(m_fieldHandles[1]).GetValue<DateTime>(DateTime.MinValue);
            newRow[2] = ((ByteString)e.EventId).ToString();
            newRow[3] = e.EventType.ToString();
            newRow[4] = e;

            m_dataset.Tables[0].Rows.Add(newRow);
            m_dataset.AcceptChanges();

            return StatusCodes.Good;
        }

        public StatusCode Delete(
            RequestContext context,
            ByteString targetEventId)
        {
            DataView view = new DataView(m_dataset.Tables[0], null, "EventId", DataViewRowState.CurrentRows);

            int index = view.Find(targetEventId.ToString());

            if (index < 0)
            {
                return StatusCodes.BadNoEntryExists;
            }

            view[index].Row.Delete();
            m_dataset.AcceptChanges();

            return StatusCodes.Good;
        }

        private void AddField(
            RequestContext context,
            FilterManager filterManager,
            string eventType,
            string browsePath,
            NamespaceTable sourceNamespaceUris)
        {
            NodeId eventTypeId = ObjectTypeIds.BaseEventType;

            if (!String.IsNullOrEmpty(eventType))
            {
                try
                {
                    eventTypeId = (NodeId)ExpandedNodeId.Parse(eventType, sourceNamespaceUris, context.NamespaceUris);
                }
                catch (Exception e)
                {
                    TraceServer.Error(e, "Unexpected error parsing EventTypeId in event history file. EventTypeId='{0}'", eventType);
                    eventTypeId = ObjectTypeIds.BaseEventType;
                }
            }

            SimpleAttributeOperand operand = new SimpleAttributeOperand()
            {
                TypeDefinitionId = eventTypeId,
                AttributeId = (String.IsNullOrEmpty(browsePath))?Attributes.NodeId:Attributes.Value,
            };

            if (String.IsNullOrEmpty(browsePath))
            {
                operand.TypeDefinitionId = ObjectTypeIds.ConditionType;
                m_fieldHandles.Add(filterManager.CreateFieldHandle(null));
                m_filter.SelectClauses.Add(operand);
                return;
            }

            QualifiedName[] qnames = null;

            try
            {
                qnames = AbsoluteName.ToQualifiedNames(browsePath, sourceNamespaceUris, context.NamespaceUris);
                operand.BrowsePath.AddRange(qnames);

                m_fieldHandles.Add(filterManager.CreateFieldHandle(AbsoluteName.ToString(qnames)));
                m_filter.SelectClauses.Add(operand);
            }
            catch (Exception e)
            {
                TraceServer.Error(e, "Unexpected error parsing BrowsePath in event history file. BrowsePath='{0}'", browsePath);
                return;
            }
        }
        #endregion

        #region Private Fields
        private DataSet m_dataset;
        private List<int> m_fieldHandles;
        private EventFilter m_filter;
        #endregion
    }
}
