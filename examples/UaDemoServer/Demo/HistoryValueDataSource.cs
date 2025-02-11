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
using System.IO;
using System.Globalization;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaServer;

namespace UnifiedAutomation.Demo
{
    /// <summary>
    /// A class that manages the access control groups.
    /// </summary>
    public class HistoryDataVariableDataSource : DataVariableDataSource
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="HistoryDataVariableDataSource"/> class.
        /// </summary>
        public HistoryDataVariableDataSource()
        {
            DataType = BuiltInType.Double;
            ValueRank = ValueRanks.Scalar;

            m_configuration = new HistoricalDataConfigurationModel();

            m_configuration.Stepped = true;
            m_configuration.StartOfArchive = DateTime.UtcNow;
            m_configuration.StartOfOnlineArchive = DateTime.UtcNow;

            m_newDataSet = new HistoryDataSet();
        }
        #endregion

        #region Public Members
        /// <summary>
        /// Gets or sets the source node id.
        /// </summary>
        /// <value>
        /// The source node id.
        /// </value>
        public NodeId SourceNodeId { get; set; }

        /// <summary>
        /// Gets or sets the source monitored item id.
        /// </summary>
        /// <value>
        /// The source monitored item id.
        /// </value>
        public uint SourceMonitoredItemId { get; set; }

        /// <summary>
        /// Gets or sets the current data type .
        /// </summary>
        /// <value>
        /// The type of the current data type.
        /// </value>
        public BuiltInType DataType { get; set; }

        /// <summary>
        /// Gets or sets the value rank.
        /// </summary>
        /// <value>
        /// The value rank.
        /// </value>
        public int ValueRank { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the variable is historizing.
        /// </summary>
        /// <value>
        ///   <c>true</c> if historizing; otherwise, <c>false</c>.
        /// </value>
        public bool Historizing { get; set; }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public HistoricalDataConfigurationModel Configuration { get { return m_configuration; } }

        public override DataValue Read(int componentIndex)
        {
            var table = GetDataView(false, componentIndex);

            if (table != null && table.Rows.Count > 0)
            {
                return (DataValue)table.Rows.Last().Value;
            }

            return base.Read(componentIndex);
        }

        public override StatusCode Write(int componentIndex, Variant value, StatusCode status, DateTime timestamp)
        {
            StatusCode error = base.Write(componentIndex, value, status, timestamp);

            if (error.IsGood())
            {
                OnDataChanged(null, new DataValue() { WrappedValue = Value, StatusCode = Status, SourceTimestamp = Timestamp }, 0);
            }

            return error;
        }

        /// <summary>
        /// Loads the data history from the stream.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="istrm">The stream.</param>
        public void Load(RequestContext context, Stream istrm)
        {
            StreamReader reader = new StreamReader(istrm);
            DateTime baseTime = new DateTime(2019, 8, 23, 14, 0, 0, DateTimeKind.Local);

            string line = reader.ReadLine();

            if (line != null)
            {
                string[] fields = line.Split(',');

                try
                {
                    DataType = (BuiltInType)Enum.Parse(typeof(BuiltInType), fields[0]);
                    Configuration.Stepped = Convert.ToBoolean(fields[1]);
                    Configuration.AggregateConfiguration.TreatUncertainAsBad = Convert.ToBoolean(fields[2]);
                    Configuration.AggregateConfiguration.UseSlopedExtrapolation = Convert.ToBoolean(fields[3]);
                    Configuration.AggregateConfiguration.PercentDataGood = Convert.ToByte(fields[4]);
                    Configuration.AggregateConfiguration.PercentDataBad = Convert.ToByte(fields[5]);
                }
                catch (Exception e)
                {
                    TraceServer.Error(e, "Could not parse history data source configuration: " + line);
                }

                line = reader.ReadLine();
            }

            while (line != null)
            {
                string[] fields = line.Split(',');

                try
                {
                    int sourceTimestamp = Convert.ToInt32(fields[0]);
                    int serverTimestamp = Convert.ToInt32(fields[1]);
                    string value = fields[2];
                    uint statusCode = Convert.ToUInt32(fields[3], 16);
                    int componentId = Convert.ToInt32(fields[4]);
                    string rowState = fields[5];

                    Variant variant = Variant.Null;

                    if (componentId == 1)
                    {
                        string[] subfields = value.Split('|');

                        string[] annotationTime = subfields[0].Split('-');
                        string userName = subfields[1];
                        string message = subfields[2];

                        variant = new ExtensionObject(new Annotation()
                        {
                            AnnotationTime = new DateTime(Convert.ToInt32(annotationTime[0]), Convert.ToInt32(annotationTime[1]), Convert.ToInt32(annotationTime[2]), Convert.ToInt32(annotationTime[3]), Convert.ToInt32(annotationTime[4]), Convert.ToInt32(annotationTime[5]), DateTimeKind.Local).ToUniversalTime(),
                            UserName = userName,
                            Message = message
                        });
                    }
                    else if (value == "null")
                    {
                            variant = new Variant(
                               null,
                               new TypeInfo(DataType, ValueRanks.Scalar));
                    }

                    else
                    {
                        variant = new Variant(
                            TypeUtils.Cast(value, UnifiedAutomation.UaBase.TypeInfo.Scalars.String, DataType),
                            new TypeInfo(DataType, ValueRanks.Scalar));
                    }
                    DataValue dv = new DataValue()
                    {
                        WrappedValue = variant,
                        SourceTimestamp = baseTime.AddSeconds(sourceTimestamp).ToUniversalTime(),
                        ServerTimestamp = baseTime.AddSeconds(serverTimestamp).ToUniversalTime(),
                        StatusCode = new StatusCode(statusCode)
                    };

                    OnDataChanged(context, dv, componentId);
                }
                catch (Exception e)
                {
                    TraceServer.Error(e, "Could not parse history data: " + line);
                }

                line = reader.ReadLine();
            }
        }

        /// <summary>
        /// Called when the source changed.
        /// </summary>
        public void OnDataChanged(
            RequestContext context,
            DataValue dataValue,
            int componentId)
        {
            lock (base.Lock)
            {
                var newRow = ActiveDataTable.NewRow();

                newRow.ComponentId = componentId;
                newRow.SourceTimestamp = dataValue.SourceTimestamp.Ticks;
                newRow.Value = dataValue;

                if (ActiveDataTable.Rows.Count >= 3600)
                {
                    ActiveDataTable.RemoveFirst();
                }
                ActiveDataTable.Add(newRow);
            }
        }

        public IDataView GetDataView(bool isModified, int componentId)
        {
            IDataTable table = isModified ? ModifiedDataTable : ActiveDataTable;

            HistoryDataView view = new HistoryDataView(table);

            foreach (var row in table.Rows)
            {
                if (row.ComponentId == componentId)
                {
                    view.Rows.Add(row);
                }
            }
            return view;
        }

        public DateTime GetSourceTimestamp(IDataView table, int index)
        {
            if (table == null || index < 0 || index >= table.Rows.Count)
            {
                return DateTime.MinValue;
            }

            return new DateTime((long)table.Rows[index].SourceTimestamp);
        }

        /// <summary>
        /// Finds the value at or before the timestamp.
        /// </summary>
        public int FindValueAtOrBefore(IDataView table, DateTime timestamp, bool ignoreBad, out bool dataIgnored)
        {
            dataIgnored = false;

            if (table.Rows.Count <= 0)
            {
                return -1;
            }

            long target = timestamp.Ticks;

            int min = 0;
            int max = table.Rows.Count;
            int position = (max - min) / 2;

            while (position >= 0 && position < table.Rows.Count)
            {
                long current = (long)table.Rows[position].SourceTimestamp;

                // check for exact match.
                if (current == target)
                {
                    // skip the first timestamp.
                    while (position > 0 && (long)table.Rows[position - 1].SourceTimestamp == target)
                    {
                        position--;
                    }

                    return position;
                }

                // move up.
                if (current < target)
                {
                    min = position + 1;
                }

                // move down.
                if (current > target)
                {
                    max = position - 1;
                }

                // not found.
                if (max < min)
                {
                    // find the value before.
                    while (position >= 0)
                    {
                        target = (long)table.Rows[position].SourceTimestamp;

                        // skip the first timestamp in group.
                        while (position > 0 && (long)table.Rows[position - 1].SourceTimestamp == target)
                        {
                            position--;
                        }

                        // ignore bad data.
                        if (ignoreBad)
                        {
                            DataValue value = (DataValue)table.Rows[position].Value;

                            if (StatusCode.IsBad(value.StatusCode))
                            {
                                position--;
                                dataIgnored = true;
                                continue;
                            }
                        }

                        break;
                    }

                    // return the position.
                    return position;
                }

                position = min + (max - min) / 2;
            }

            return -1;
        }

        /// <summary>
        /// Returns the next value after the current position.
        /// </summary>
        public int FindValueAfter(IDataView view, int position, bool ignoreBad, out bool dataIgnored)
        {
            dataIgnored = false;

            if (position < 0 || position >= view.Rows.Count)
            {
                return -1;
            }

            long timestamp = view.Rows[position].SourceTimestamp;

            // skip the current timestamp.
            while (position < view.Rows.Count && view.Rows[position].SourceTimestamp == timestamp)
            {
                position++;
            }

            if (position >= view.Rows.Count)
            {
                return -1;
            }

            // find the value after.
            while (position < view.Rows.Count)
            {
                timestamp = view.Rows[position].SourceTimestamp;

                // ignore bad data.
                if (ignoreBad)
                {
                    DataValue value = (DataValue) view.Rows[position].Value;

                    if (StatusCode.IsBad(value.StatusCode))
                    {
                        position++;
                        dataIgnored = true;
                        continue;
                    }
                }

                break;
            }

            if (position >= view.Rows.Count)
            {
                return -1;
            }

            // return the position.
            return position;
        }

        /// <summary>
        /// Deletes the data in the specified range.
        /// </summary>
        public bool DeleteData(IDataView view, DateTime startTime, DateTime endTime)
        {
            bool dataIgnored = false;

            int position = FindValueAtOrBefore(view, startTime, false, out dataIgnored);

            if (position < 0)
            {
                position = 0;
            }

            List<IDataRow> rowsToDelete = new List<IDataRow>();

            while (position >= 0 && position < view.Rows.Count)
            {
                long current = (long)view.Rows[position].SourceTimestamp;

                if (current < startTime.Ticks)
                {
                    position++;
                    continue;
                }

                if (current > startTime.Ticks && current >= endTime.Ticks)
                {
                    break;
                }

                rowsToDelete.Add(view.Rows[position++]);
            }

            if (rowsToDelete.Count == 0)
            {
                return false;
            }

            foreach (var row in rowsToDelete)
            {
                view.Rows.Remove(row);
                view.Table.Rows.Remove(row);
            }

            return true;
        }

        /// <summary>
        /// Updates the history.
        /// </summary>
        public StatusCode UpdateHistory(
            RequestContext context,
            int componentId,
            DataValue value,
            PerformUpdateType performUpdateType)
        {
            // remove not supported (restricted by specification).
            if (performUpdateType == PerformUpdateType.Remove)
            {
                return StatusCodes.BadNotSupported;
            }

            var table = GetDataView(false, componentId);

            // check for correct data type.
            TypeInfo typeInfo = value.WrappedValue.TypeInfo;

            if (StatusCode.IsNotBad(value.StatusCode))
            {
                if (typeInfo == null)
                {
                    typeInfo = TypeInfo.Construct(value.Value);
                }

                if (typeInfo == null || typeInfo.BuiltInType != DataType || typeInfo.ValueRank != ValueRank)
                {
                    return StatusCodes.BadTypeMismatch;
                }
            }

            // find any existing entry.
            var row = table.Find(value.SourceTimestamp.Ticks);

            // process replace.
            if (row != null)
            {
                if (performUpdateType == PerformUpdateType.Insert)
                {
                    return StatusCodes.BadEntryExists;
                }

                if (componentId == 0)
                {
                    // create modified row.
                    var modifiedRow = ModifiedDataTable.NewModifiedRow();

                    modifiedRow.ComponentId = row.ComponentId;
                    modifiedRow.SourceTimestamp = row.SourceTimestamp;
                    modifiedRow.Value = row.Value;
                    modifiedRow.ModificationInfo = GetModificationInfo(context, HistoryUpdateType.Replace);

                    ModifiedDataTable.Add(modifiedRow);
                }

                // modify value.
                row.Value = value;
            }

            // process insert.
            else
            {
                if (performUpdateType == PerformUpdateType.Replace)
                {
                    return StatusCodes.BadNoEntryExists;
                }

                if (componentId == 0)
                {
                    // create modified row.
                    var modifiedRow = ModifiedDataTable.NewModifiedRow();

                    modifiedRow.ComponentId = componentId;
                    modifiedRow.SourceTimestamp = value.SourceTimestamp.Ticks;
                    modifiedRow.Value = value;
                    modifiedRow.ModificationInfo = GetModificationInfo(context, HistoryUpdateType.Insert);

                    ModifiedDataTable.Add(modifiedRow);
                }

                // add new value.
                var newRow = ActiveDataTable.NewRow();

                newRow.ComponentId = componentId;
                newRow.SourceTimestamp = value.SourceTimestamp.Ticks;
                newRow.Value = value;

                ActiveDataTable.Add(newRow);
            }

            return StatusCodes.Good;
        }

        /// <summary>
        /// Updates the history.
        /// </summary>
        public StatusCode UpdateHistoryMetadata(
            IDataView view,
            RequestContext context,
            int componentId,
            DataValue value,
            PerformUpdateType performUpdateType)
        {
            // check for valid data being passed in.
            IEncodeable value1 = value.WrappedValue.GetValue<IEncodeable>(null);

            if (value1 == null)
            {
                return StatusCodes.BadTypeMismatch;
            }

            // find any existing data.
            IDataRow existingRow = null;

            foreach (var row in view.FindRows(value.SourceTimestamp.Ticks))
            {
                IEncodeable value2 = value.WrappedValue.GetValue<IEncodeable>(null);

                if (IsEqual(value1, value2))
                {
                    existingRow = row;
                    break;
                }
            }

            // check if existing data is required.
            if (existingRow == null)
            {
                if (performUpdateType == PerformUpdateType.Replace || performUpdateType == PerformUpdateType.Remove)
                {
                    return StatusCodes.BadNoEntryExists;
                }
            }

            // check if existing data is not allowed.
            else
            {
                if (performUpdateType == PerformUpdateType.Insert)
                {
                    return StatusCodes.BadEntryExists;
                }
            }

            // remove row.
            if (performUpdateType == PerformUpdateType.Remove)
            {
                view.Rows.Remove(existingRow);
                return StatusCodes.Good;
            }

            // update existing row.
            if (existingRow != null)
            {
                existingRow.Value = value;
                return StatusCodes.Good;
            }

            // add new row.
            var newRow = ActiveDataTable.NewRow();

            newRow.ComponentId = componentId;
            newRow.SourceTimestamp = value.SourceTimestamp.Ticks;
            newRow.Value = value;

            ActiveDataTable.Add(newRow);
            
            return StatusCodes.Good;
        }

        private bool IsEqual(IEncodeable encodeable1, IEncodeable encodeable2)
        {
            if (Object.ReferenceEquals(encodeable1, encodeable2))
            {
                return true;
            }

            Annotation annotation1 = encodeable1 as Annotation;
            Annotation annotation2 = encodeable2 as Annotation;

            if (annotation1 == null || annotation2 == null)
            {
                return annotation1 == annotation2;
            }

            if (annotation1.UserName != annotation2.UserName)
            {
                return false;
            }

            if (annotation1.Message != annotation2.Message)
            {
                return false;
            }

            return true;
        }

        private ModificationInfo GetModificationInfo(RequestContext context, HistoryUpdateType updateType)
        {
            ModificationInfo info = new ModificationInfo();
            info.UpdateType = updateType;
            info.ModificationTime = DateTime.UtcNow;

            if (context != null && context.UserIdentity != null)
            {
                info.UserName = context.UserIdentity.DisplayName;
            }
            else
            {
                info.UserName = "System";
            }

            return info;
        }
        #endregion

        #region Archive Access Properties
        private IDataTable ActiveDataTable
        {
            get { return m_newDataSet.Active; }
        }

        private IDataTableModified ModifiedDataTable
        {
            get { return m_newDataSet.Modified; }
        }
        #endregion

        #region Private Fields
        private IDataSet m_newDataSet;
        private HistoricalDataConfigurationModel m_configuration;
        #endregion
    }

    public interface IDataRow : IComparable
    {
        int ComponentId { get; set; }
        long SourceTimestamp { get; set; }
        object Value { get; set; }
    }

    public interface IDataRowModified
        : IDataRow
    {
        ModificationInfo ModificationInfo { get; set; }
    }

    public interface IDataTable
    {
        IList<IDataRow> Rows { get; }
        IDataRow NewRow();
        void Add(IDataRow row);
        void RemoveFirst();
    }

    public interface IDataTableModified : IDataTable
    {
        IDataRowModified NewModifiedRow();
    }

    public interface IDataView
    {
        IDataTable Table { get; }
        IList<IDataRow> Rows { get; }
        IDataRow Find(long timestamp);
        IList<IDataRow> FindRows(long timestamp);
    }

    public interface IDataSet
    {
        IDataTable Active { get; }
        IDataTableModified Modified { get; }
    }

    class HistoryDataRow : IDataRow
    {
        public int ComponentId { get; set; }

        public long SourceTimestamp { get; set; }

        public object Value { get; set; }

        public int CompareTo(object obj)
        {
            if (!(obj is IDataRow))
            {
                return -1;
            }
            return (int)((obj as IDataRow).SourceTimestamp - SourceTimestamp);
        }
    }

    class HistoryDataRowModified : HistoryDataRow, IDataRowModified
    {
        public ModificationInfo ModificationInfo { get; set; }
    }

    class HistoryDataTable : IDataTable
    {
        public HistoryDataTable()
        {
            Rows = new List<IDataRow>();
        }
        public IList<IDataRow> Rows { get; private set; }

        public void Add(IDataRow row)
        {
            for (int index = 0; index < Rows.Count; index++)
            {
                IDataRow existingRow = Rows[index];
                if (existingRow.SourceTimestamp >= row.SourceTimestamp)
                {
                    Rows.Insert(index, row);
                    return;
                }
            }
            Rows.Add(row);
        }

        public IDataRow NewRow()
        {
            return new HistoryDataRow();
        }

        public void RemoveFirst()
        {
            Rows.RemoveAt(0);
        }
    }

    class HistoryDataTableModified : HistoryDataTable, IDataTableModified
    {
        public IDataRowModified NewModifiedRow()
        {
            return new HistoryDataRowModified();
        }
    }

    class HistoryDataView : IDataView
    {
        public HistoryDataView(IDataTable table)
        {
            Table = table;
            Rows = new List<IDataRow>();
        }
        public IList<IDataRow> Rows { get; private set; }
        public IDataTable Table { get; private set; }

        public IDataRow Find(long timestamp)
        {
            // ToDo: Binary search
            int index = 0;
            for (; index < Rows.Count; index++)
            {
                if (Rows[index].SourceTimestamp == timestamp)
                {
                    return Rows[index];
                }
            }
            return null;
        }

        public IList<IDataRow> FindRows(long timestamp)
        {
            ///ToDo Binary search
            List<IDataRow> ret = new List<IDataRow>();

            foreach (IDataRow row in Rows)
            {
                if (row.SourceTimestamp == timestamp)
                {
                    ret.Add(row);
                }
            }

            return ret;
        }
    }

    class HistoryDataSet : IDataSet
    {
        public HistoryDataSet()
        {
            Active = new HistoryDataTable();
            Modified = new HistoryDataTableModified();
        }

        public IDataTable Active { get; private set; }

        public IDataTableModified Modified { get; private set; }
    }
}
