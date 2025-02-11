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
using System.Reflection;
using System.IO;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaServer;

namespace UnifiedAutomation.Demo
{
    #region ValueDataSource Class
    public class ValueDataSource
    {
        public object Lock { get { return this; } }
        public StatusCode Status;
        public bool SemanticsHaveChanged;
        public DateTime Timestamp;
        public UnifiedAutomation.UaBase.TypeInfo TypeInfo;
        public SimulationType SimulationType;
        public byte AccessLevel;
        public DataSourceMonitoredItem[] MonitoredItems;
        public int[] TriggersValueChange;
        public int[] TriggeredByValueChange;

        public virtual DataValue Read(int address)
        {
            return new DataValue(StatusCodes.BadNotReadable);
        }

        public virtual StatusCode Write(int address, Variant value, StatusCode status, DateTime timestamp)
        {
            return StatusCodes.BadNotWritable;
        }

        public virtual void GenerateRandomValue(DataGenerator generator)
        {
        }

        public virtual void GenerateNextValue(DataGenerator generator)
        {
        }

        public virtual void StartMonitoring(
            int componentIndex,
            MonitoredItemHandle itemHandle,
            string indexRange,
            QualifiedName dataEncoding,
            MonitoringMode monitoringMode,
            DataChangeTrigger dataChangeTrigger,
            DataChangeEventHandler callback)
        {
            DataSourceMonitoredItem monitoredItem = new DataSourceMonitoredItem()
            {
                ComponentIndex = componentIndex,
                ItemHandle = itemHandle,
                IndexRange = indexRange,
                DataEncoding = dataEncoding,
                MonitoringMode = monitoringMode,
                DataChangeTrigger = dataChangeTrigger,
                Callback = callback
            };

            if (MonitoredItems == null)
            {
                MonitoredItems = new DataSourceMonitoredItem[1];
            }
            else
            {
                Array.Resize(ref MonitoredItems, MonitoredItems.Length + 1);
            }

            MonitoredItems[MonitoredItems.Length - 1] = monitoredItem;
        }

        public virtual void SetMonitoringMode(int componentIndex, uint monitoredItemId, MonitoringMode monitoringMode)
        {
            if (MonitoredItems != null)
            {
                for (int ii = 0; ii < MonitoredItems.Length; ii++)
                {
                    if (MonitoredItems[ii].ComponentIndex == componentIndex && MonitoredItems[ii].ItemHandle.MonitoredItemId == monitoredItemId)
                    {
                        MonitoredItems[ii].MonitoringMode = monitoringMode;
                        break;
                    }
                }
            }
        }

        public virtual void StopMonitoring(int componentIndex, uint monitoredItemId)
        {
            if (MonitoredItems != null)
            {
                for (int ii = 0; ii < MonitoredItems.Length; ii++)
                {
                    if (MonitoredItems[ii].ComponentIndex == componentIndex && MonitoredItems[ii].ItemHandle.MonitoredItemId == monitoredItemId)
                    {
                        DataSourceMonitoredItem[] monitoredItems = null;

                        if (MonitoredItems.Length > 1)
                        {
                            monitoredItems = new DataSourceMonitoredItem[MonitoredItems.Length - 1];

                            if (ii > 0)
                            {
                                Array.Copy(MonitoredItems, 0, monitoredItems, 0, ii);
                            }

                            if (ii < MonitoredItems.Length - 1)
                            {
                                Array.Copy(MonitoredItems, ii + 1, monitoredItems, ii, monitoredItems.Length - ii);
                            }
                        }

                        MonitoredItems = monitoredItems;
                        break;
                    }
                }
            }
        }
    }
    #endregion

    #region DataSourceAddress Class
    public class DataSourceAddress
    {
        public DataSourceAddress(ValueDataSource source, int index)
        {
            Source = source;
            ComponentIndex = index;
        }

        public ValueDataSource Source { get; private set; }
        public int ComponentIndex { get; private set; }
    }
    #endregion

    #region DataSourceMonitoredItem Class
    public class DataSourceMonitoredItem
    {
        public int ComponentIndex;
        public MonitoredItemHandle ItemHandle;
        public string IndexRange;
        public QualifiedName DataEncoding;
        public MonitoringMode MonitoringMode;
        public DataChangeTrigger DataChangeTrigger;
        public DataChangeEventHandler Callback;
    }
    #endregion

    #region SimulationType Enumeration
    public enum SimulationType
    {
        None,
        Random,
        Sequence
    }
    #endregion

    #region DataVariableDataSource Class
    public class DataVariableDataSource : ValueDataSource
    {
        public Variant Value;

        public override DataValue Read(int componentIndex)
        {
            DataValue dv = new DataValue();
            dv.ServerTimestamp = DateTime.UtcNow;

            if (componentIndex == 0)
            {
                if (!Status.IsBad())
                {
                    dv.WrappedValue = Value;
                }
                dv.StatusCode = Status;
                dv.SourceTimestamp = Timestamp;
                return dv;
            }

            dv.StatusCode = StatusCodes.BadConfigurationError;
            return dv;
        }

        public override StatusCode Write(int componentIndex, Variant value, StatusCode status, DateTime timestamp)
        {
            if (timestamp == DateTime.MinValue)
            {
                timestamp = DateTime.UtcNow;
            }

            if (componentIndex == 0)
            {
                UnifiedAutomation.UaBase.TypeInfo typeInfo = TypeUtils.IsInstanceOfDataType(value, TypeInfo);

                if (typeInfo == null)
                {
                    return StatusCodes.BadTypeMismatch;
                }

                Value = value;
                Status = status;
                Timestamp = timestamp;

                return StatusCodes.Good;
            }

            return StatusCodes.Bad;
        }

        public override void GenerateRandomValue(DataGenerator generator)
        {
            try
            {
                if (TypeInfo.ValueRank == ValueRanks.Scalar)
                {
                    Value = generator.GetRandom(TypeInfo.BuiltInType);
                }
                else if (TypeInfo.ValueRank == ValueRanks.OneDimension)
                {
                    do
                    {
                        Value = new Variant(generator.GetRandomArray(TypeInfo.BuiltInType, false, 10, false), TypeInfo);
                    }
                    while (Value.ArrayLength < 5);
                }
                else if (TypeInfo.ValueRank > 0)
                {
                    int[] dimensions = new int[TypeInfo.ValueRank];
                    int numberOfElements = 1;
                    for (int i=0; i<TypeInfo.ValueRank; i++)
                    {
                        dimensions[i] = i + 4;
                        numberOfElements *= (i + 4);
                    }
                    Matrix matrix = new Matrix(
                        generator.GetRandomArray(TypeInfo.BuiltInType, false, numberOfElements, true),
                        TypeInfo.BuiltInType,
                        dimensions);
                    Value = new Variant(matrix, TypeInfo);
                }

                Status = StatusCodes.Good;
                Timestamp = DateTime.UtcNow;
            }
            catch (Exception)
            {
                Value = TypeUtils.GetDefaultValue(TypeInfo.BuiltInType);
            }
        }
    }
    #endregion

    public delegate void DataVariableChanged(DataVariableDataSource datasource);

    #region EnumValueDataSource Class
    public class EnumValueDataSource : ValueDataSource
    {
        public int SelectedIndex;
        public EnumValueType[] EnumValues;
        public DateTime EnumValuesTimestamp;

        public EnumValueDataSource()
        {
            TriggersValueChange = m_TriggersValueChange;
            TriggeredByValueChange = m_TriggeredByValueChange;
        }

        private static readonly int[] m_TriggersValueChange = new int[] { 1 };
        private static readonly int[] m_TriggeredByValueChange = new int[] { 2 };

        public override DataValue Read(int componentIndex)
        {
            DataValue dv = new DataValue();
            dv.ServerTimestamp = DateTime.UtcNow;

            if (SelectedIndex < 0 || SelectedIndex >= EnumValues.Length)
            {
                dv.StatusCode = StatusCodes.BadConfigurationError;
                return dv;
            }

            if (componentIndex == 0)
            {
                dv.WrappedValue = new Variant(EnumValues[SelectedIndex].Value).ConvertTo(TypeInfo.BuiltInType);
                dv.StatusCode = Status;
                dv.SourceTimestamp = Timestamp;
                return dv;
            }

            if (componentIndex == 1)
            {
                dv.WrappedValue = new Variant(EnumValues);
                dv.StatusCode = Status;
                dv.SourceTimestamp = EnumValuesTimestamp;
                return dv;
            }

            if (componentIndex == 2)
            {
                dv.WrappedValue = new Variant(EnumValues[SelectedIndex].DisplayName);
                dv.SourceTimestamp = Timestamp;
                return dv;
            }

            dv.StatusCode = StatusCodes.BadConfigurationError;
            return dv;
        }

        /// [MultiStateValueDiscretetType Example]
        public override StatusCode Write(int componentIndex, Variant value, StatusCode status, DateTime timestamp)
        {
            if (timestamp == DateTime.MinValue)
            {
                timestamp = DateTime.UtcNow;
            }

            if (componentIndex == 0)
            {
                UnifiedAutomation.UaBase.TypeInfo typeInfo = TypeUtils.IsInstanceOfDataType(value, TypeInfo);

                if (typeInfo == null)
                {
                    return StatusCodes.BadTypeMismatch;
                }

                try
                {
                    long newValue = value.ToInt64();

                    for (int ii = 0; ii < EnumValues.Length; ii++)
                    {
                        if (EnumValues[ii].Value == newValue)
                        {
                            SelectedIndex = ii;
                            Status = status;
                            Timestamp = timestamp;
                            return StatusCodes.Good;
                        }
                    }
                }
                catch (Exception)
                {
                    // assume out of range error.
                }

                return StatusCodes.BadOutOfRange;
            }
        /// [MultiStateValueDiscretetType Example]

            if (componentIndex == 1)
            {
                if (value.TypeInfo != UnifiedAutomation.UaBase.TypeInfo.Arrays.ExtensionObject)
                {
                    return StatusCodes.BadTypeMismatch;
                }

                EnumValues = ExtensionObject.GetArray<EnumValueType>((ExtensionObject[])value.Value);
                EnumValuesTimestamp = timestamp;

                bool valid = false;

                for (int ii = 0; ii < EnumValues.Length; ii++)
                {
                    if (EnumValues[ii].Value == SelectedIndex)
                    {
                        valid = true;
                        break;
                    }
                }

                if (!valid)
                {
                    SelectedIndex = 0;
                }

                SemanticsHaveChanged = true;
                return StatusCodes.Good;
            }

            if (componentIndex == 2)
            {
                return StatusCodes.BadNotWritable;
            }

            return StatusCodes.Bad;
        }

        public override void GenerateRandomValue(DataGenerator generator)
        {
            SelectedIndex = generator.GetRandomUInt16() % EnumValues.Length;
            Timestamp = DateTime.UtcNow;
        }
    }
    #endregion

    #region EnumStringDataSource Class
    public class EnumStringDataSource : ValueDataSource
    {
        public int SelectedIndex;
        public LocalizedText[] EnumStrings;
        public DateTime EnumStringsTimestamp;

        public EnumStringDataSource()
        {
            TriggersValueChange = m_TriggersValueChange;
        }

        private static readonly int[] m_TriggersValueChange = new int[] { 1 };

        public override DataValue Read(int componentIndex)
        {
            DataValue dv = new DataValue();
            dv.ServerTimestamp = DateTime.UtcNow;

            if (SelectedIndex < 0 || SelectedIndex >= EnumStrings.Length)
            {
                dv.StatusCode = StatusCodes.BadConfigurationError;
                return dv;
            }

            if (componentIndex == 0)
            {
                dv.WrappedValue = new Variant(SelectedIndex).ConvertTo(TypeInfo.BuiltInType);
                dv.StatusCode = Status;
                dv.SourceTimestamp = Timestamp;
                return dv;
            }

            if (componentIndex == 1)
            {
                dv.WrappedValue = new Variant(EnumStrings);
                dv.StatusCode = StatusCodes.Good;
                dv.SourceTimestamp = EnumStringsTimestamp;
                return dv;
            }

            dv.StatusCode = StatusCodes.BadConfigurationError;
            return dv;
        }

        /// [MultiStateDiscreteType Example]
        public override StatusCode Write(int componentIndex, Variant value, StatusCode status, DateTime timestamp)
        {
            if (timestamp == DateTime.MinValue)
            {
                timestamp = DateTime.UtcNow;
            }

            if (componentIndex == 0)
            {
                UnifiedAutomation.UaBase.TypeInfo typeInfo = TypeUtils.IsInstanceOfDataType(value, TypeInfo);

                if (typeInfo == null)
                {
                    return StatusCodes.BadTypeMismatch;
                }

                try
                {
                    int newValue = value.ToInt32();

                    if (newValue >= 0 && newValue < EnumStrings.Length)
                    {
                        SelectedIndex = newValue;
                        Status = status;
                        Timestamp = timestamp;
                        return StatusCodes.Good;
                    }
                }
                catch (Exception)
                {
                    // assume out of range error.
                }

                return StatusCodes.BadOutOfRange;
            }
        /// [MultiStateDiscreteType Example]

            if (componentIndex == 1)
            {
                if (value.TypeInfo != UnifiedAutomation.UaBase.TypeInfo.Arrays.LocalizedText)
                {
                    return StatusCodes.BadTypeMismatch;
                }

                EnumStrings = value.ToLocalizedTextArray();
                EnumStringsTimestamp = timestamp;

                if (SelectedIndex < 0 || SelectedIndex >= EnumStrings.Length)
                {
                    SelectedIndex = 0;
                }

                SemanticsHaveChanged = true;
                return StatusCodes.Good;
            }

            return StatusCodes.Bad;
        }

        public override void GenerateRandomValue(DataGenerator generator)
        {
            SelectedIndex = generator.GetRandomUInt16() % EnumStrings.Length;
            Timestamp = DateTime.UtcNow;
        }
    }
    #endregion

    #region AnalogDataSource Class
    public class AnalogDataSource : ValueDataSource
    {
        public double ScalarValue;
        public double[] ArrayValue;
        public UaBase.Range EURange;
        public UaBase.Range InstrumentRange;
        public EUInformation EngineeringUnits;

        public AnalogDataSource()
        {
            TriggersValueChange = m_TriggersValueChange;
        }

        private static readonly int[] m_TriggersValueChange = new int[] { 1, 2, 3 };

        public override DataValue Read(int componentIndex)
        {
            DataValue dv = new DataValue();
            dv.ServerTimestamp = DateTime.UtcNow;

            if (componentIndex == 0)
            {
                if (TypeInfo.ValueRank > ValueRanks.Scalar)
                {
                    dv.WrappedValue = new Variant(ArrayValue).ConvertTo(TypeInfo.BuiltInType);
                }
                else
                {
                    dv.WrappedValue = new Variant(ScalarValue).ConvertTo(TypeInfo.BuiltInType);
                }

                dv.StatusCode = Status;
                dv.SourceTimestamp = Timestamp;
                return dv;
            }

            if (componentIndex == 1)
            {
                dv.WrappedValue = new Variant(EURange);
                dv.SourceTimestamp = DateTime.UtcNow;
                return dv;
            }

            if (componentIndex == 2)
            {
                if (InstrumentRange == null)
                {
                    dv.StatusCode = StatusCodes.BadNodeIdUnknown;
                    return dv;
                }

                dv.WrappedValue = new Variant(InstrumentRange);
                dv.SourceTimestamp = DateTime.UtcNow;
                return dv;
            }

            if (componentIndex == 3)
            {
                if (EngineeringUnits == null)
                {
                    dv.StatusCode = StatusCodes.BadNodeIdUnknown;
                    return dv;
                }

                dv.WrappedValue = new Variant(EngineeringUnits);
                dv.SourceTimestamp = DateTime.UtcNow;
                return dv;
            }

            dv.StatusCode = StatusCodes.BadConfigurationError;
            return dv;
        }

        public override StatusCode Write(int componentIndex, Variant value, StatusCode status, DateTime timestamp)
        {
            if (timestamp == DateTime.MinValue)
            {
                timestamp = DateTime.UtcNow;
            }

            if (componentIndex == 0)
            {
                UnifiedAutomation.UaBase.TypeInfo typeInfo = TypeUtils.IsInstanceOfDataType(value, TypeInfo);

                if (typeInfo == null)
                {
                    return StatusCodes.BadTypeMismatch;
                }

                try
                {
                    if (TypeInfo.ValueRank > ValueRanks.Scalar)
                    {
                        double[] newValue = value.ToDoubleArray();

                        bool valid = true;

                        if (newValue != null)
                        {
                            for (int ii = 0; ii < newValue.Length; ii++)
                            {
                                if (newValue[ii] < EURange.Low && newValue[ii] > EURange.High)
                                {
                                    valid = false;
                                    break;
                                }
                            }
                        }

                        if (valid)
                        {
                            ArrayValue = newValue;
                            Status = status;
                            Timestamp = timestamp;
                            return StatusCodes.Good;
                        }
                    }
                    else
                    {
                        double newValue = value.ToDouble();

                        if (newValue >= EURange.Low && newValue <= EURange.High
                            && (InstrumentRange == null || newValue >= InstrumentRange.Low && newValue <= InstrumentRange.High))
                        {
                            ScalarValue = newValue;
                            Status = status;
                            Timestamp = timestamp;
                            return StatusCodes.Good;
                        }
                    }

                }
                catch (Exception)
                {
                    // assume out of range error.
                }

                return StatusCodes.BadOutOfRange;
            }

            if (componentIndex == 1)
            {
                if (value.TypeInfo != UnifiedAutomation.UaBase.TypeInfo.Scalars.ExtensionObject)
                {
                    return StatusCodes.BadTypeMismatch;
                }

                UaBase.Range euRange = ExtensionObject.GetObject<UaBase.Range>((ExtensionObject)value.Value);

                if (euRange == null)
                {
                    return StatusCodes.BadTypeMismatch;
                }

                switch (TypeInfo.BuiltInType)
                {
                    case BuiltInType.Byte:
                        if (euRange.Low < 0 || euRange.High > byte.MaxValue)
                        {
                            return StatusCodes.BadOutOfRange;
                        }
                        break;
                    case BuiltInType.SByte:
                        if (euRange.Low < sbyte.MinValue || euRange.High > sbyte.MaxValue)
                        {
                            return StatusCodes.BadOutOfRange;
                        }
                        break;
                    case BuiltInType.Int16:
                        if (euRange.Low < short.MinValue || euRange.High > short.MaxValue)
                        {
                            return StatusCodes.BadOutOfRange;
                        }
                        break;
                    case BuiltInType.Int32:
                        if (euRange.Low < int.MinValue || euRange.High > int.MaxValue)
                        {
                            return StatusCodes.BadOutOfRange;
                        }
                        break;
                    case BuiltInType.Int64:
                        if (euRange.Low < long.MinValue || euRange.High > long.MaxValue)
                        {
                            return StatusCodes.BadOutOfRange;
                        }
                        break;
                    case BuiltInType.UInt16:
                        if (euRange.Low < 0 || euRange.High > ushort.MaxValue)
                        {
                            return StatusCodes.BadOutOfRange;
                        }
                        break;
                    case BuiltInType.UInt32:
                        if (euRange.Low < 0 || euRange.High > uint.MaxValue)
                        {
                            return StatusCodes.BadOutOfRange;
                        }
                        break;
                    case BuiltInType.UInt64:
                        if (euRange.Low < 0 || euRange.High > ulong.MaxValue)
                        {
                            return StatusCodes.BadOutOfRange;
                        }
                        break;
                }
                EURange = euRange;
                SemanticsHaveChanged = true;
                return StatusCodes.Good;
            }

            if (componentIndex == 2)
            {
                if (value.TypeInfo != UnifiedAutomation.UaBase.TypeInfo.Scalars.ExtensionObject)
                {
                    return StatusCodes.BadTypeMismatch;
                }

                UaBase.Range euRange = ExtensionObject.GetObject< UaBase.Range> ((ExtensionObject)value.Value);

                if (euRange == null)
                {
                    return StatusCodes.BadTypeMismatch;
                }

                InstrumentRange = euRange;
                SemanticsHaveChanged = true;
                return StatusCodes.Good;
            }

            if (componentIndex == 3)
            {
                if (value.TypeInfo != UnifiedAutomation.UaBase.TypeInfo.Scalars.ExtensionObject)
                {
                    return StatusCodes.BadTypeMismatch;
                }

                EUInformation euInfo = ExtensionObject.GetObject<EUInformation>((ExtensionObject)value.Value);

                if (euInfo == null)
                {
                    return StatusCodes.BadTypeMismatch;
                }

                EngineeringUnits = euInfo;
                SemanticsHaveChanged = true;
                return StatusCodes.Good;
            }

            return StatusCodes.Bad;
        }

        public override void GenerateRandomValue(DataGenerator generator)
        {
            int range = (int)Math.Abs(EURange.High - EURange.Low);

            if (TypeInfo.ValueRank < 0)
            {
                ScalarValue = range * (Math.Sin(((generator.GetRandomUInt16() % 360) * 2 * Math.PI) / 360) + 1) / 2 + EURange.Low;
            }
            else
            {
                if (ArrayValue == null)
                {
                    ArrayValue = new double[10];
                }

                for (int ii = 0; ii < ArrayValue.Length; ii++)
                {
                    ArrayValue[ii] = range * (Math.Sin(((generator.GetRandomUInt16() % 360) * 2 * Math.PI) / 360) + 1) / 2 + EURange.Low;
                }
            }

            Timestamp = DateTime.UtcNow;
        }
    }
    #endregion

    #region TwoStateDataSource Class
    public class TwoStateDataSource : ValueDataSource
    {
        public bool State;
        public LocalizedText TrueState;
        public LocalizedText FalseState;

        public TwoStateDataSource()
        {
            TriggersValueChange = m_TriggersValueChange;
        }

        private static readonly int[] m_TriggersValueChange = new int[] { 1, 2 };

        public override DataValue Read(int componentIndex)
        {
            DataValue dv = new DataValue();
            dv.ServerTimestamp = DateTime.UtcNow;

            if (componentIndex == 0)
            {
                dv.WrappedValue = State;
                dv.StatusCode = Status;
                dv.SourceTimestamp = Timestamp;
                return dv;
            }

            if (componentIndex == 1)
            {
                dv.WrappedValue = TrueState;
                dv.SourceTimestamp = DateTime.UtcNow;
                return dv;
            }

            if (componentIndex == 2)
            {
                dv.WrappedValue = FalseState;
                dv.SourceTimestamp = DateTime.UtcNow;
                return dv;
            }

            dv.StatusCode = StatusCodes.BadConfigurationError;
            return dv;
        }

        public override StatusCode Write(int componentIndex, Variant value, StatusCode status, DateTime timestamp)
        {
            if (timestamp == DateTime.MinValue)
            {
                timestamp = DateTime.UtcNow;
            }

            if (componentIndex == 0)
            {
                UnifiedAutomation.UaBase.TypeInfo typeInfo = TypeUtils.IsInstanceOfDataType(value, TypeInfo);

                if (typeInfo == null)
                {
                    return StatusCodes.BadTypeMismatch;
                }

                try
                {
                    State = value.ToBoolean();
                    Status = status;
                    Timestamp = timestamp;
                    return StatusCodes.Good;
                }
                catch (Exception)
                {
                    // assume out of range error.
                }

                return StatusCodes.BadOutOfRange;
            }

            if (componentIndex == 1)
            {
                if (value.TypeInfo != UnifiedAutomation.UaBase.TypeInfo.Scalars.LocalizedText)
                {
                    return StatusCodes.BadTypeMismatch;
                }

                TrueState = value.ToLocalizedText();
                SemanticsHaveChanged = true;
                return StatusCodes.Good;
            }

            if (componentIndex == 2)
            {
                if (value.TypeInfo != UnifiedAutomation.UaBase.TypeInfo.Scalars.LocalizedText)
                {
                    return StatusCodes.BadTypeMismatch;
                }

                FalseState = value.ToLocalizedText();
                SemanticsHaveChanged = true;
                return StatusCodes.Good;
            }

            return StatusCodes.Bad;
        }

        public override void GenerateRandomValue(DataGenerator generator)
        {
            State = generator.GetRandomBoolean();
            Timestamp = DateTime.UtcNow;
        }
    }
    #endregion

    #region ImageDataSource class
    public class ImageDataSource : ValueDataSource
    {
        int Index = 0;

        public ImageDataSource()
        {
            m_animationImages = new List<byte[]>(30);
            for (int ii = 0; ii < 30; ii++)
            {
                m_animationImages.Add(ByteStringFromResource("Animation.animation_" + ii + ".gif"));
            }
        }

        public override DataValue Read(int address)
        {
            DataValue dv = new DataValue();
            dv.ServerTimestamp = DateTime.UtcNow;

            if (address == 0)
            {
                dv.WrappedValue = m_animationImages[Index];
                dv.StatusCode = Status;
                dv.SourceTimestamp = DateTime.UtcNow;
                return dv;
            }

            dv.StatusCode = StatusCodes.BadConfigurationError;
            return dv;
        }

        public override StatusCode Write(int address, Variant value, StatusCode status, DateTime timestamp)
        {
            return StatusCodes.BadNotWritable;
        }

        public override void GenerateNextValue(DataGenerator generator)
        {
            Index++;
            Index %= 30;
        }

        byte[] ByteStringFromResource(string name)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (string resourceName in assembly.GetManifestResourceNames())
            {
                if (resourceName.EndsWith(name, StringComparison.OrdinalIgnoreCase))
                {
                    using (Stream istrm = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                    {
                        if (istrm != null)
                        {
                            byte[] ba = new byte[istrm.Length];
                            istrm.Read(ba, 0, ba.Length);
                            return ba;
                        }
                    }
                    break;
                }
            }
            return null;
        }

        private IList<byte[]> m_animationImages;
    }
    #endregion

    #region SawToothDataSource class
    public class SawToothDataSource : ValueDataSource
    {
        byte Value = 0;
        bool Up = true;

        public SawToothDataSource()
        {
        }

        public override DataValue Read(int address)
        {
            DataValue dv = new DataValue();
            dv.ServerTimestamp = DateTime.UtcNow;

            if (address == 0)
            {
                dv.WrappedValue = new Variant(Value);
                dv.StatusCode = Status;
                dv.SourceTimestamp = DateTime.UtcNow;
                return dv;
            }

            dv.StatusCode = StatusCodes.BadConfigurationError;
            return dv;
        }

        public override StatusCode Write(int address, Variant value, StatusCode status, DateTime timestamp)
        {
            return StatusCodes.BadNotWritable;
        }

        public override void GenerateNextValue(DataGenerator generator)
        {
            if (Up)
            {
                Value++;
                if (Value >= 100)
                {
                    Up = false;
                }
            }
            else
            {
                Value--;
                if (Value <= 0)
                {
                    Up = true;
                }
            }
        }
        public override void GenerateRandomValue(DataGenerator generator)
        {
            GenerateNextValue(generator);
        }
    }
    #endregion

    #region SineToothDataSource class
    public class SineDataSource : ValueDataSource
    {
        double Degree = 0;


        public SineDataSource()
        {
        }

        public override DataValue Read(int address)
        {
            DataValue dv = new DataValue();
            dv.ServerTimestamp = DateTime.UtcNow;

            if (address == 0)
            {
                double rad = Degree * Math.PI / 180.0;
                double sin = Math.Sin(rad);
                double value = (sin + 1.0) * 50.0;
                dv.WrappedValue = new Variant(value);
                dv.StatusCode = Status;
                dv.SourceTimestamp = DateTime.UtcNow;
                return dv;
            }

            dv.StatusCode = StatusCodes.BadConfigurationError;
            return dv;
        }
        public override void GenerateRandomValue(DataGenerator generator)
        {
            GenerateNextValue(generator);
        }

        public override StatusCode Write(int address, Variant value, StatusCode status, DateTime timestamp)
        {
            return StatusCodes.BadNotWritable;
        }

        public override void GenerateNextValue(DataGenerator generator)
        {
            Degree+=1.0;
            if (Degree >= 360.0)
            {
                Degree = 0;
            }
        }
    }
    #endregion

    #region IncrementDataSource class
    public class IncrementDataSource : ValueDataSource
    {
        uint Current = 0;

        public IncrementDataSource()
        {
        }

        public override DataValue Read(int address)
        {
            DataValue dv = new DataValue();
            dv.ServerTimestamp = DateTime.UtcNow;

            if (address == 0)
            {
                dv.WrappedValue = new Variant(Current);
                dv.StatusCode = Status;
                dv.SourceTimestamp = DateTime.UtcNow;
                return dv;
            }

            dv.StatusCode = StatusCodes.BadConfigurationError;
            return dv;
        }

        public override void GenerateRandomValue(DataGenerator generator)
        {
            GenerateNextValue(generator);
        }

        public override StatusCode Write(int address, Variant value, StatusCode status, DateTime timestamp)
        {
            if (address == 0)
            {
                if (status.IsGood())
                {
                    Current = value.ToUInt32();
                    return StatusCodes.Good;
                }
                else
                {
                    return StatusCodes.BadWriteNotSupported;
                }
            }
            else
            {
                return StatusCodes.BadConfigurationError;
            }
        }

        public override void GenerateNextValue(DataGenerator generator)
        {
            Current++;
        }
    }
    #endregion

    #region OptionSetDataSource
    public class OptionSetDataSource : ValueDataSource
    {
        Model.AccessRights Value;

        public OptionSetDataSource()
        {
            Value = new Model.AccessRights();
        }

        public override DataValue Read(int address)
        {
            DataValue dv = new DataValue();
            dv.ServerTimestamp = DateTime.UtcNow;

            if (address == 0)
            {
                dv.WrappedValue = new Variant(Value);
                dv.StatusCode = Status;
                dv.SourceTimestamp = Timestamp;
                return dv;
            }

            dv.StatusCode = StatusCodes.BadConfigurationError;
            return dv;
        }

        public override void GenerateRandomValue(DataGenerator generator)
        {
            byte bFlags = generator.GetRandomByte();
            bFlags >>= 5;
            Value.Flags = (Model.AccessRightsFlags)bFlags;
        }

        public override StatusCode Write(int address, Variant value, StatusCode status, DateTime timestamp)
        {
            if (timestamp == DateTime.MinValue)
            {
                timestamp = DateTime.UtcNow;
            }

            if (address == 0)
            {
                Model.AccessRights accessRights = value.GetValue<Model.AccessRights>(null);
                if (accessRights == null)
                {
                    return StatusCodes.BadTypeMismatch;
                }
                if (!accessRights.IsValid())
                {
                    return StatusCodes.BadOutOfRange;
                }

                Value.Apply(accessRights);

                Status = status;
                Timestamp = timestamp;

                return StatusCodes.Good;
            }

            return StatusCodes.Bad;
        }

        public override void GenerateNextValue(DataGenerator generator)
        {
            GenerateRandomValue(generator);
        }
    }

    public class OptionSetBaseDataSource : ValueDataSource
    {
        Model.OptionSetBase Value;

        public OptionSetBaseDataSource()
        {
            Value = new Model.OptionSetBase();
            Value.Flags = Model.OptionSetBaseFlags.ERROR | Model.OptionSetBaseFlags.WARNING;
        }

        public override DataValue Read(int address)
        {
            DataValue dv = new DataValue();
            dv.ServerTimestamp = DateTime.UtcNow;

            if (address == 0)
            {
                dv.WrappedValue = new Variant(Value);
                dv.StatusCode = Status;
                dv.SourceTimestamp = Timestamp;
                return dv;
            }

            dv.StatusCode = StatusCodes.BadConfigurationError;
            return dv;
        }

        public override StatusCode Write(int address, Variant value, StatusCode status, DateTime timestamp)
        {
            if (timestamp == DateTime.MinValue)
            {
                timestamp = DateTime.UtcNow;
            }

            if (address == 0)
            {
                Model.OptionSetBase optionSet = value.GetValue<Model.OptionSetBase>(null);
                if (optionSet == null)
                {
                    return StatusCodes.BadTypeMismatch;
                }
                if (!optionSet.IsValid())
                {
                    return StatusCodes.BadOutOfRange;
                }

                Value.Apply(optionSet);

                Status = status;
                Timestamp = timestamp;

                return StatusCodes.Good;
            }

            return StatusCodes.Bad;
        }
    }

    public class OptionSetByteDataSource : ValueDataSource
    {
        Model.OptionSetByte Value = Model.OptionSetByte.ERROR | Model.OptionSetByte.WARNING;

        public override DataValue Read(int address)
        {
            DataValue dv = new DataValue();
            dv.ServerTimestamp = DateTime.UtcNow;

            if (address == 0)
            {
                dv.WrappedValue = new Variant((byte) Value);
                dv.StatusCode = Status;
                dv.SourceTimestamp = Timestamp;
                return dv;
            }

            dv.StatusCode = StatusCodes.BadConfigurationError;
            return dv;
        }

        public override StatusCode Write(int address, Variant value, StatusCode status, DateTime timestamp)
        {
            if (timestamp == DateTime.MinValue)
            {
                timestamp = DateTime.UtcNow;
            }

            if (address == 0)
            {
                if (value.DataType != BuiltInType.Byte || value.ValueRank != ValueRanks.Scalar)
                {
                    return StatusCodes.BadTypeMismatch;
                }

                var byteValue = value.ToByte();

                if (byteValue >= (byte)Model.OptionSetByte.CONTENT * 2)
                {
                    return StatusCodes.BadOutOfRange;
                }

                Value = (Model.OptionSetByte)byteValue;

                Status = status;
                Timestamp = timestamp;

                return StatusCodes.Good;
            }

            return StatusCodes.Bad;
        }
    }

    public class OptionSetUInt16DataSource : ValueDataSource
    {
        Model.OptionSetUInt16 Value = Model.OptionSetUInt16.ERROR | Model.OptionSetUInt16.WARNING | Model.OptionSetUInt16.INFO;

        public override DataValue Read(int address)
        {
            DataValue dv = new DataValue();
            dv.ServerTimestamp = DateTime.UtcNow;

            if (address == 0)
            {
                dv.WrappedValue = new Variant((ushort)Value);
                dv.StatusCode = Status;
                dv.SourceTimestamp = Timestamp;
                return dv;
            }

            dv.StatusCode = StatusCodes.BadConfigurationError;
            return dv;
        }

        public override StatusCode Write(int address, Variant value, StatusCode status, DateTime timestamp)
        {
            if (timestamp == DateTime.MinValue)
            {
                timestamp = DateTime.UtcNow;
            }

            if (address == 0)
            {
                if (value.DataType != BuiltInType.UInt16 || value.ValueRank != ValueRanks.Scalar)
                {
                    return StatusCodes.BadTypeMismatch;
                }

                var uint16Value = value.ToUInt16();

                if (uint16Value >= (ushort)Model.OptionSetUInt16.CONTENT * 2)
                {
                    return StatusCodes.BadOutOfRange;
                }

                Value = (Model.OptionSetUInt16)uint16Value;

                Status = status;
                Timestamp = timestamp;

                return StatusCodes.Good;
            }

            return StatusCodes.Bad;
        }
    }

    public class OptionSetUInt32DataSource : ValueDataSource
    {
        Model.OptionSetUInt32 Value = Model.OptionSetUInt32.ERROR | Model.OptionSetUInt32.WARNING | Model.OptionSetUInt32.INFO;

        public override DataValue Read(int address)
        {
            DataValue dv = new DataValue();
            dv.ServerTimestamp = DateTime.UtcNow;

            if (address == 0)
            {
                dv.WrappedValue = new Variant((uint)Value);
                dv.StatusCode = Status;
                dv.SourceTimestamp = Timestamp;
                return dv;
            }

            dv.StatusCode = StatusCodes.BadConfigurationError;
            return dv;
        }

        public override StatusCode Write(int address, Variant value, StatusCode status, DateTime timestamp)
        {
            if (timestamp == DateTime.MinValue)
            {
                timestamp = DateTime.UtcNow;
            }

            if (address == 0)
            {
                if (value.DataType != BuiltInType.UInt32 || value.ValueRank != ValueRanks.Scalar)
                {
                    return StatusCodes.BadTypeMismatch;
                }

                var uint32Value = value.ToUInt32();

                if (uint32Value >= (uint)Model.OptionSetUInt32.CONTENT * 2)
                {
                    return StatusCodes.BadOutOfRange;
                }

                Value = (Model.OptionSetUInt32)uint32Value;

                Status = status;
                Timestamp = timestamp;

                return StatusCodes.Good;
            }

            return StatusCodes.Bad;
        }
    }


    public class OptionSetUInt64DataSource : ValueDataSource
    {
        Model.OptionSetUInt64 Value = Model.OptionSetUInt64.UU | Model.OptionSetUInt64.ZZ | Model.OptionSetUInt64.BBBB;

        public override DataValue Read(int address)
        {
            DataValue dv = new DataValue();
            dv.ServerTimestamp = DateTime.UtcNow;

            if (address == 0)
            {
                dv.WrappedValue = new Variant((ulong)Value);
                dv.StatusCode = Status;
                dv.SourceTimestamp = Timestamp;
                return dv;
            }

            dv.StatusCode = StatusCodes.BadConfigurationError;
            return dv;
        }

        public override StatusCode Write(int address, Variant value, StatusCode status, DateTime timestamp)
        {
            if (timestamp == DateTime.MinValue)
            {
                timestamp = DateTime.UtcNow;
            }

            if (address == 0)
            {
                if (value.DataType != BuiltInType.UInt64 || value.ValueRank != ValueRanks.Scalar)
                {
                    return StatusCodes.BadTypeMismatch;
                }

                var uint64Value = value.ToUInt64();

                if (uint64Value >= (ulong)Model.OptionSetUInt64.GGG * 2)
                {
                    return StatusCodes.BadOutOfRange;
                }

                Value = (Model.OptionSetUInt64)uint64Value;

                Status = status;
                Timestamp = timestamp;

                return StatusCodes.Good;
            }

            return StatusCodes.Bad;
        }
    }

    #endregion

    #region QualityHelper
    public class QualityHelper
    {
        int index = 0;
        uint[] m_usedStatusCodes = new uint[]
        {
            StatusCodes.Good,
            StatusCodes.GoodClamped,
            StatusCodes.GoodDataIgnored,
            StatusCodes.GoodMoreData,
            StatusCodes.GoodNonCriticalTimeout,
            StatusCodes.GoodCompletesAsynchronously,
            StatusCodes.GoodNoData,
            StatusCodes.GoodResultsMayBeIncomplete,
            StatusCodes.Uncertain,
            StatusCodes.UncertainDataSubNormal,
            StatusCodes.UncertainDominantValueChanged,
            StatusCodes.UncertainDependentValueChanged,
            StatusCodes.UncertainLastUsableValue,
            StatusCodes.UncertainSensorNotAccurate,
            StatusCodes.UncertainSubNormal,
            StatusCodes.UncertainSubstituteValue,
            StatusCodes.Bad,
            StatusCodes.BadAttributeIdInvalid,
            StatusCodes.BadAttributeIdInvalid,
            StatusCodes.BadCommunicationError,
            StatusCodes.BadDataEncodingInvalid,
            StatusCodes.BadEncodingError,
            StatusCodes.BadInternalError,
            StatusCodes.BadNoData
        };

        public StatusCode NextStatusCode()
        {
            index++;
            index %= m_usedStatusCodes.Length;
            return m_usedStatusCodes[index];
        }
    }
    #endregion

    #region QualityDataSourceDynamicValue
    class QualityDataSourceDynamicValue : DataVariableDataSource
    {
        QualityHelper helper = new QualityHelper();

        public override void GenerateRandomValue(DataGenerator generator)
        {
            try
            {
                base.GenerateRandomValue(generator);
                Status = helper.NextStatusCode();
            }
            catch (Exception)
            {
            }
        }
    }
    #endregion

    #region QualityDataSourceStaticValue
    class QualityDataSourceStaticValue : DataVariableDataSource
    {
        QualityHelper helper = new QualityHelper();

        public override void GenerateRandomValue(DataGenerator generator)
        {
            try
            {
                Status = helper.NextStatusCode();
                Timestamp = DateTime.UtcNow;
            }
            catch (Exception)
            {
            }
        }
    }
    #endregion

    #region SimulationActiveDataSource
    class SimulationActiveDataSource : DataVariableDataSource
    {
        DemoNodeManager NodeManager;
        public SimulationActiveDataSource(DemoNodeManager nm)
        {
            NodeManager = nm;
        }

        public override StatusCode Write(int componentIndex, Variant value, StatusCode status, DateTime timestamp)
        {
            if (componentIndex == 0)
            {
                if (value.DataType != BuiltInType.Boolean || value.ValueRank != ValueRanks.Scalar)
                {
                    return StatusCodes.BadTypeMismatch;
                }

                if (status != Status)
                {
                    return StatusCodes.BadWriteNotSupported;
                }

                if (timestamp == DateTime.MinValue)
                {
                    timestamp = DateTime.UtcNow;
                }

                if (value.ToBoolean() != Value.ToBoolean())
                {
                    if (value.ToBoolean())
                    {
                        status = NodeManager.StartSimulation(NodeManager.Server.DefaultRequestContext);
                    }
                    else
                    {
                        status = NodeManager.StopSimulation(NodeManager.Server.DefaultRequestContext);
                    }
                }
                if (status.IsGood())
                {
                    Value = value;
                    Timestamp = timestamp;
                }

                return status;
            }

            return StatusCodes.BadConfigurationError;
        }
    }
    #endregion

    #region SimulationSpeedDataSource
    class SimulationSpeedDataSource : DataVariableDataSource
    {
        DemoNodeManager NodeManager;
        public SimulationSpeedDataSource(DemoNodeManager nm)
        {
            NodeManager = nm;
        }

        public override StatusCode Write(int componentIndex, Variant value, StatusCode status, DateTime timestamp)
        {
            if (componentIndex == 0)
            {
                if (value.DataType != BuiltInType.UInt32 || value.ValueRank != ValueRanks.Scalar)
                {
                    return StatusCodes.BadTypeMismatch;
                }

                if (status != Status)
                {
                    return StatusCodes.BadWriteNotSupported;
                }

                if (timestamp == DateTime.MinValue)
                {
                    timestamp = DateTime.UtcNow;
                }

                if (value.ToUInt32() != Value.ToUInt32())
                {
                    status = NodeManager.SetSimulationSpeed(
                        NodeManager.Server.DefaultRequestContext,
                        value.ToUInt32());
                }

                if (status.IsGood())
                {
                    Value = value;
                    Timestamp = timestamp;
                }

                return status;
            }

            return StatusCodes.BadConfigurationError;
        }
    }
    #endregion
}
