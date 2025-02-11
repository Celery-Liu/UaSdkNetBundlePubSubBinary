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
    internal partial class DemoNodeManager
    {
        #region Private members
        SlowDataSourceWrapperAsynchronous m_slowDataSourceWrapperAsync;
        SlowDataSourceWrapperSynchronous m_slowDataSourceWrapperSync;
        #endregion

        private void SetupSlowVariables()
        {
            /// [Slow Variables Configuration]
            m_slowDataSourceWrapperSync = new SlowDataSourceWrapperSynchronous(new SlowDataSourceSynchronousAPI());
            SetVariableConfiguration(
                new NodeId(Demo.Model.Variables.Demo_SpecialVariables_SlowSynchronousAPI, DefaultNamespaceIndex),
                NodeHandleType.ExternalPush,
                m_slowDataSourceWrapperSync);

            m_slowDataSourceWrapperAsync = new SlowDataSourceWrapperAsynchronous(new SlowDataSourceAsynchronousAPI());
            SetVariableConfiguration(
                new NodeId(Demo.Model.Variables.Demo_SpecialVariables_SlowAsynchronousAPI, DefaultNamespaceIndex),
                NodeHandleType.ExternalPush,
                m_slowDataSourceWrapperAsync);
            /// [Slow Variables Configuration]
        }


        #region Read
        /// <summary>
        /// Is called by DemoNodeManager.Read
        /// </summary>
        private DataValue ReadSlowVariables(
            RequestContext context,
            NodeAttributeHandle nodeHandle,
            string indexRange,
            QualifiedName dataEncoding)
        {
            return null;
        }

        protected override void Read(
            RequestContext context,
            TransactionHandle transaction,
            IList<NodeAttributeOperationHandle> operationHandles,
            IList<ReadValueId> settings)
        {
            for (int ii = 0; ii < operationHandles.Count; ii++)
            {
                /// [Read Slow Variables Synchronous 1]
                if (operationHandles[ii].NodeHandle.UserData is SlowDataSourceWrapperSynchronous)
                {
                    // We have to read the value in a thread
                    DoReadInJob(
                        new ReadInJobData()
                        {
                            Context = context,
                            Transaction = transaction,
                            OperationHandle = operationHandles[ii],
                            ReadValueId = settings[ii],
                            Callback = OnReadSlowVariable
                        });
                }
                /// [Read Slow Variables Synchronous 1]
                else
                {
                    /// [Read Slow Variables Asynchronous 1]
                    var dataSourceWrapper = operationHandles[ii].NodeHandle.UserData as SlowDataSourceWrapperAsynchronous;
                    if (dataSourceWrapper != null)
                    {
                        dataSourceWrapper.DataSource.BeginRead(OnSlowAsyncReadComplete, new ReadAsyncData()
                        {
                            Transaction = transaction,
                            OperationHandle = operationHandles[ii]
                        });
                    }
                }
                /// [Read Slow Variables Asynchronous 1]
            }
        }

        #region Read Synchronous
        /// [Read Slow Variables Synchronous 2]
        private void DoReadInJob(
            ReadInJobData data
            )
        {
            Server.ThreadPool.Queue(data, OnReadInJob);
        }

        private void OnReadInJob(object state, StatusCode error)
        {
            if (error.IsBad())
            {
                return;
            }
            ReadInJobData data = state as ReadInJobData;
            DataValue dv = data.Callback(data.ReadValueId, data.OperationHandle.NodeHandle);
            ((ReadCompleteEventHandler)data.Transaction.Callback)(
                data.OperationHandle,
                data.Transaction.CallbackData,
                dv,
                false);
        }

        delegate DataValue ReadInJob(ReadValueId nodeToRead, NodeAttributeHandle nodeHandle);

        DataValue OnReadSlowVariable(ReadValueId nodeToRead, NodeAttributeHandle nodeHandle)
        {
            SlowDataSourceWrapperSynchronous dataSourceWrapper = nodeHandle.UserData as SlowDataSourceWrapperSynchronous;
            uint value = dataSourceWrapper.DataSource.ReadValue();
            return new DataValue()
            {
                WrappedValue = new Variant(value),
                SourceTimestamp = DateTime.UtcNow,
                ServerTimestamp = DateTime.UtcNow
            };
        }

        class ReadInJobData
        {
            public RequestContext Context { get; set; }
            public TransactionHandle Transaction { get; set; }
            public NodeAttributeOperationHandle OperationHandle { get; set; }
            public ReadValueId ReadValueId { get; set; }
            public ReadInJob Callback { get; set; }
        }
        /// [Read Slow Variables Synchronous 2]
        #endregion

        #region Read Asynchronous
        /// [Read Slow Variables Asynchronous 2]
        private void OnSlowAsyncReadComplete(uint value, object userData)
        {
            ReadAsyncData data = userData as ReadAsyncData;
            DataValue dv = new DataValue()
            {
                WrappedValue = new Variant(value),
                SourceTimestamp = DateTime.UtcNow,
                ServerTimestamp = DateTime.UtcNow
            };
            ((ReadCompleteEventHandler)data.Transaction.Callback)(
                 data.OperationHandle,
                 data.Transaction.CallbackData,
                 dv,
                 false);
        }

        class ReadAsyncData
        {
            public TransactionHandle Transaction { get; set; }
            public NodeAttributeOperationHandle OperationHandle { get; set; }
        }
        /// [Read Slow Variables Asynchronous 2]
        #endregion

        #endregion

        #region Write
        /// <summary>
        /// Is called by DemoNodeManager.Write
        /// </summary>
        private StatusCode? WriteSlowVariables(
            RequestContext context,
            NodeAttributeHandle nodeHandle,
            string indexRange,
            DataValue value)
        {
            if (value.WrappedValue.DataType != BuiltInType.UInt32
                || value.WrappedValue.ValueRank != ValueRanks.Scalar)
            {
                return StatusCodes.BadTypeMismatch;
            }

            if (value.ServerTimestamp != DateTime.MinValue
                || value.StatusCode != StatusCodes.Good)
            {
                return StatusCodes.BadWriteNotSupported;
            }
            return null;
        }

        protected override void Write(
            RequestContext context,
            TransactionHandle transaction,
            IList<NodeAttributeOperationHandle> operationHandles,
            IList<WriteValue> settings)
        {
            for (int ii = 0; ii < operationHandles.Count; ii++)
            {
                if (operationHandles[ii].NodeHandle.UserData is SlowDataSourceWrapperSynchronous)
                {
                    // We have to read the value in a thread
                    DoWriteInJob(
                        new WriteInJobData()
                        {
                            Context = context,
                            Transaction = transaction,
                            OperationHandle = operationHandles[ii],
                            WriteValue = settings[ii],
                            Callback = OnWriteSlowVariable
                        });
                }
                else
                {
                    var dataSourceWrapper = operationHandles[ii].NodeHandle.UserData as SlowDataSourceWrapperAsynchronous;
                    if (dataSourceWrapper != null)
                    {
                        dataSourceWrapper.DataSource.BeginWrite(settings[ii].Value.WrappedValue.ToUInt32(), OnSlowAsyncWriteComplete, new WriteAsyncData()
                        {
                            Transaction = transaction,
                            OperationHandle = operationHandles[ii]
                        });
                    }
                }
            }
        }

        #region Write Synchronous
        private void DoWriteInJob(
            WriteInJobData data
            )
        {
            Server.ThreadPool.Queue(data, OnWriteInJob);
        }

        private void OnWriteInJob(object state, StatusCode error)
        {
            if (error.IsBad())
            {
                return;
            }
            WriteInJobData data = state as WriteInJobData;
            StatusCode result = data.Callback(data.WriteValue, data.OperationHandle.NodeHandle);
            ((WriteCompleteEventHandler)data.Transaction.Callback)(
                data.OperationHandle,
                data.Transaction.CallbackData,
                result,
                false);
        }

        delegate StatusCode WriteInJob(WriteValue writeValue, NodeAttributeHandle nodeHandle);

        StatusCode OnWriteSlowVariable(WriteValue writeValue, NodeAttributeHandle nodeHandle)
        {
            SlowDataSourceWrapperSynchronous dataSourceWrapper = nodeHandle.UserData as SlowDataSourceWrapperSynchronous;
            bool succeeded = dataSourceWrapper.DataSource.WriteValue(writeValue.Value.WrappedValue.ToUInt32());
            if (succeeded)
            {
                return StatusCodes.Good;
            }
            else
            {
                return StatusCodes.Bad;
            }
        }

        class WriteInJobData
        {
            public RequestContext Context { get; set; }
            public TransactionHandle Transaction { get; set; }
            public NodeAttributeOperationHandle OperationHandle { get; set; }
            public WriteValue WriteValue { get; set; }
            public WriteInJob Callback { get; set; }
        }
        #endregion

        #region Write Asynchronous
        private void OnSlowAsyncWriteComplete(bool succeeded, object userData)
        {
            WriteAsyncData data = userData as WriteAsyncData;
            ((WriteCompleteEventHandler)data.Transaction.Callback)(
                 data.OperationHandle,
                 data.Transaction.CallbackData,
                 succeeded ? StatusCodes.Good : StatusCodes.Bad,
                 false);
        }

        class WriteAsyncData
        {
            public TransactionHandle Transaction { get; set; }
            public NodeAttributeOperationHandle OperationHandle { get; set; }
        }
        #endregion

        #endregion

        #region Monitoring
        private double ReviseSamplingInterval(double requestedSamplingInterval)
        {
            if (requestedSamplingInterval <= 250)
            {
                return 250;
            }
            if (requestedSamplingInterval <= 1000)
            {
                return 1000;
            }
            return 5000;
        }

        /// [Monitoring Slow Variables 1]
        /// <summary>
        /// Is called by DemoNodeManager.StartDataMonitoring
        /// </summary>
        private DataMonitoringResult StartDataMonitoringSlowVariables(
            RequestContext context,
            MonitoredItemHandle itemHandle,
            MonitoredItemCreateRequest settings,
            DataChangeEventHandler callback)
        {
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

            SlowDataSourceWrapper dataSourceWrapper = itemHandle.NodeHandle.UserData as SlowDataSourceWrapper;

            dataSourceWrapper.AddMonitoredItem(new SlowDataSourceWrapperMonitoredItem()
            {
                ItemHandle = itemHandle,
                MonitoringMode = settings.MonitoringMode,
                SamplingInterval = (int)settings.RequestedParameters.SamplingInterval,
                Callback = callback
            });

            result.RevisedSamplingInterval = ReviseSamplingInterval(settings.RequestedParameters.SamplingInterval);

            return result;
        }

        /// <summary>
        /// Is called by DemoNodeManager.ModifyDataMonitoring
        /// </summary>
        private DataMonitoringResult ModifyDataMonitoringSlowVariables(
            RequestContext context,
            MonitoredItemHandle itemHandle,
            MonitoredItemModifyRequest settings)
        {
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

            result.RevisedSamplingInterval = ReviseSamplingInterval(settings.RequestedParameters.SamplingInterval);

            return result;
        }

        /// <summary>
        /// Is called by DemoNodeManager.StopDataMonitoring
        /// </summary>
        private StatusCode? StopDataMonitoringSlowVariables(
            RequestContext context,
            MonitoredItemHandle itemHandle)
        {
            SlowDataSourceWrapper dataSourceWrapper = itemHandle.NodeHandle.UserData as SlowDataSourceWrapper;
            dataSourceWrapper.RemoveMonitoredItem(itemHandle);
            return StatusCodes.Good;
        }

        /// <summary>
        /// Is called by DemoNodeManager.SetDataMonitoringMode
        /// </summary>
        private StatusCode? SetDataMonitoringModeSlowVariables(
            RequestContext context,
            MonitoredItemHandle itemHandle,
            MonitoringMode monitoringMode,
            MonitoringParameters parameters)
        {
            SlowDataSourceWrapper dataSourceWrapper = itemHandle.NodeHandle.UserData as SlowDataSourceWrapper;
            dataSourceWrapper.SetMonitoringMode(itemHandle, monitoringMode, parameters);
            return StatusCodes.Good;
        }
        /// [Monitoring Slow Variables 1]
        #endregion
    }

    #region Slow Data Sources
    /// [Slow Data Sources]
    #region Base class
    internal class SlowDataSource
    {
        public SlowDataSource()
        {
            m_timer = new Timer(DoUpdate, null, 500, 500);
        }
        void DoUpdate(object state)
        {
            lock (m_lock)
            {
                m_value++;
            }
        }
        public void Dispose()
        {
            if(m_timer != null)
            {
                m_timer.Dispose();
                m_timer = null;
            }
        }

        protected int m_delay = 2000;
        protected uint m_value = 0;
        private Timer m_timer;
        protected object m_lock = new object();

    }
    #endregion

    #region Synchronous API
    internal class SlowDataSourceSynchronousAPI : SlowDataSource
    {
        public uint ReadValue()
        {
            System.Threading.Thread.Sleep(m_delay);
            uint ret;
            lock (m_lock)
            {
                ret = m_value;
            }
            return ret;
        }

        public bool WriteValue(uint value)
        {
            System.Threading.Thread.Sleep(m_delay);
            lock (m_lock)
            {
                m_value = value;
            }
            return true;
        }
    }
    #endregion

    #region Asynchronous API
    internal class SlowDataSourceAsynchronousAPI : SlowDataSource
    {
        public delegate void ReadComplete(uint value, object userData);
        public delegate void WriteComplete(bool status, object userData);

        public void BeginRead(ReadComplete callback, object userData)
        {
            ThreadPool.QueueUserWorkItem(Read, new ReadData()
            {
                Callback = callback,
                UserData = userData
            });
        }

        class ReadData
        {
            public ReadComplete Callback { get; set; }
            public object UserData { get; set; }
        }

        private void Read(object state)
        {
            System.Threading.Thread.Sleep(m_delay);
            ReadData data = state as ReadData;
            ReadComplete callback = state as ReadComplete;
            lock (m_lock)
            {
                data.Callback(m_value, data.UserData);
            }
        }

        public void BeginWrite(uint value, WriteComplete callback, object userData)
        {
            ThreadPool.QueueUserWorkItem(Write, new WriteData()
            {
                Callback = callback,
                Value = value,
                UserData = userData
            });
        }

        private void Write(object state)
        {
            System.Threading.Thread.Sleep(m_delay);
            WriteData data = state as WriteData;
            WriteComplete callback = state as WriteComplete;
            lock (m_lock)
            {
                m_value = data.Value;
            }
            data.Callback(true, data.UserData);
        }

        private class WriteData
        {
            public WriteComplete Callback { get; set; }
            public uint Value { get; set; }
            public object UserData { get; set; }
        }
    }
    #endregion
    /// [Slow Data Sources]
    #endregion

    #region Data Source Wrapper

    /// [Monitoring Slow Variables - Wrappers]
    internal abstract class SlowDataSourceWrapper
    {
        public SlowDataSourceWrapper()
        {
            m_lock = new object();
        }

        public void AddMonitoredItem(SlowDataSourceWrapperMonitoredItem monitoredItem)
        {
            lock (m_lock)
            {
                if (m_monitoredItems == null)
                {
                    m_monitoredItems = new List<SlowDataSourceWrapperMonitoredItem>();
                }
                m_monitoredItems.Add(monitoredItem);
                int lastSamplingInterval = m_currentSamplingInterval;
                UpdatePolling();
                if (m_lastValue != null && m_currentSamplingInterval == lastSamplingInterval)
                {
                    monitoredItem.Callback(null, monitoredItem.ItemHandle, m_lastValue, false);
                }
                else
                {
                    monitoredItem.Callback(null, monitoredItem.ItemHandle, new DataValue(StatusCodes.BadWaitingForInitialData), false);
                }
            }
        }

        public bool RemoveMonitoredItem(MonitoredItemHandle itemHandle)
        {
            bool itemRemoved = false;
            lock (m_lock)
            {
                if (m_monitoredItems == null)
                {
                    return false;
                }
                foreach (SlowDataSourceWrapperMonitoredItem monitoredItem in m_monitoredItems)
                {
                    if (monitoredItem.ItemHandle == itemHandle)
                    {
                        m_monitoredItems.Remove(monitoredItem);
                        itemRemoved = true;
                        break;
                    }
                }
                if (m_monitoredItems.Count == 0)
                {
                    m_timer.Dispose();
                    m_timer = null;
                    m_instance = null;
                    m_lastValue = null;
                    m_currentSamplingInterval = 0;
                }
                else
                {
                    UpdatePolling();
                }
            }
            return itemRemoved;
        }

        public bool SetMonitoringMode(
            MonitoredItemHandle itemHandle,
            MonitoringMode monitoringMode,
            MonitoringParameters parameters)
        {
            lock (m_lock)
            {
                foreach (var monitoredItem in m_monitoredItems)
                {
                    if (monitoredItem.ItemHandle == itemHandle)
                    {
                        monitoredItem.SamplingInterval = (int)parameters.SamplingInterval;
                        monitoredItem.MonitoringMode = monitoringMode;
                        UpdatePolling();
                        monitoredItem.Callback(null, monitoredItem.ItemHandle, m_lastValue, false);
                        return true;
                    }
                }
            }
            return false;
        }

        protected void UpdatePolling()
        {
            lock (m_lock)
            {
                int samplingInterval = NewSamplingInterval();
                if (samplingInterval < m_currentSamplingInterval || m_currentSamplingInterval == 0)
                {
                    if (m_timer != null)
                    {
                        m_timer.Dispose();
                        m_lastValue = null;
                    }
                    m_instance = new object();
                    m_timer = new Timer(OnPoll, m_instance, 0, samplingInterval);
                    m_currentSamplingInterval = samplingInterval;
                }
            }
        }

        protected int NewSamplingInterval()
        {
            int newSamplingInterval = 5000;
            foreach (SlowDataSourceWrapperMonitoredItem monitoredItem in m_monitoredItems)
            {
                newSamplingInterval = Math.Min(newSamplingInterval, (int)monitoredItem.SamplingInterval);
            }
            if (newSamplingInterval <= 250)
            {
                return 250;
            }
            if (newSamplingInterval <= 1000)
            {
                return 1000;
            }
            return 5000;
        }

        protected abstract void OnPoll(object state);

        protected object m_lock;
        protected object m_instance;
        protected Timer m_timer;
        protected List<SlowDataSourceWrapperMonitoredItem> m_monitoredItems;
        protected int m_currentSamplingInterval;
        protected DataValue m_lastValue;
    }

    /// [Slow Data Source Wrapper]
    internal class SlowDataSourceWrapperSynchronous : SlowDataSourceWrapper
    {
        public SlowDataSourceWrapperSynchronous(SlowDataSourceSynchronousAPI dataSource)
        {
            m_dataSource = dataSource;
        }

        public SlowDataSourceSynchronousAPI DataSource
        {
            get
            {
                return m_dataSource;
            }
        }
        /// [Slow Data Source Wrapper]

        protected override void OnPoll(object state)
        {
            uint value = m_dataSource.ReadValue();
            lock (m_lock)
            {
                if (m_instance == state)
                {
                    m_lastValue = new DataValue()
                    {
                        WrappedValue = new Variant(value),
                        SourceTimestamp = DateTime.UtcNow,
                        ServerTimestamp = DateTime.UtcNow
                    };
                    foreach (SlowDataSourceWrapperMonitoredItem monitoredItem in m_monitoredItems)
                    {
                        monitoredItem.Callback(null, monitoredItem.ItemHandle, m_lastValue, false);
                    }
                }
            }
        }

        private readonly SlowDataSourceSynchronousAPI m_dataSource;
    }

    internal class SlowDataSourceWrapperAsynchronous : SlowDataSourceWrapper
    {
        public SlowDataSourceWrapperAsynchronous(SlowDataSourceAsynchronousAPI dataSource)
        {
            m_dataSource = dataSource;
        }

        public SlowDataSourceAsynchronousAPI DataSource
        {
            get
            {
                return m_dataSource;
            }
        }

        protected override void OnPoll(object state)
        {
            m_dataSource.BeginRead(OnReadComplete, state);
        }

        void OnReadComplete(uint value, object userData)
        {
            lock (m_lock)
            {
                if (m_instance == userData)
                {
                    m_lastValue = new DataValue()
                    {
                        WrappedValue = new Variant(value),
                        SourceTimestamp = DateTime.UtcNow,
                        ServerTimestamp = DateTime.UtcNow
                    };
                    foreach (SlowDataSourceWrapperMonitoredItem monitoredItem in m_monitoredItems)
                    {
                        monitoredItem.Callback(null, monitoredItem.ItemHandle, m_lastValue, false);
                    }
                }
            }
        }

        private readonly SlowDataSourceAsynchronousAPI m_dataSource;
    }

    internal class SlowDataSourceWrapperMonitoredItem
    {
        public MonitoredItemHandle ItemHandle { get; set; }
        public MonitoringMode MonitoringMode { get; set; }
        public int SamplingInterval { get; set; }
        public DataChangeEventHandler Callback { get; set; }
    }
    /// [Monitoring Slow Variables - Wrappers]
    #endregion
}
