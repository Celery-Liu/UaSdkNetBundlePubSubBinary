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
        #region Members
        object m_dynamicNodeLock = new object();
        #endregion

        private void SetupMethodDescriptions()
        {
            NodeId argumentsNodeId;

            argumentsNodeId = new NodeId(Model.Variables.Demo_SetSimulationSpeed_InputArguments, DefaultNamespaceIndex);
            VariableNode simulationSpeedInput = FindInMemoryNode(argumentsNodeId) as VariableNode;
            if (simulationSpeedInput != null)
            {
                Variant value = simulationSpeedInput.Value;
                Argument[] arguments = value.GetValue<Argument[]>(null);
                if (arguments != null && arguments.Length > 0)
                {
                    Argument argument = arguments[0];
                    argument.Description = new LocalizedText("en-US", "Simulation interval [ms]. Must be greater than 250.");
                }
            }

            argumentsNodeId = new NodeId(Model.Variables.Demo_Images_Dynamic_SetAnimationSpeed_InputArguments, DefaultNamespaceIndex);
            VariableNode animationSpeedInput = FindInMemoryNode(argumentsNodeId) as VariableNode;
            if (animationSpeedInput != null)
            {
                Variant value = animationSpeedInput.Value;
                Argument[] arguments = value.GetValue<Argument[]>(null);
                if (arguments != null && arguments.Length > 0)
                {
                    Argument argument = arguments[0];
                    argument.Description = new LocalizedText("en-US", "Animation simulation interval [ms]. Must be greater than 30.");
                }
            }

        }

        #region Overridden Methods
        /// <summary>
        /// Gets the method handler.
        /// </summary>
        protected override CallMethodEventHandler GetMethodDispatcher(RequestContext context, MethodHandle methodHandle)
        {
            if (methodHandle.MethodId == new NodeId(Model.Methods.Demo_Events_TriggerMultipleEvents, DefaultNamespaceIndex))
            {
                return DoTriggerMultipleEvents;
            }

            if (methodHandle.MethodId == new NodeId(Model.Methods.Demo_Method_DoSomethingAfter10s, DefaultNamespaceIndex))
            {
                return DoSomethingAfter10ms;
            }

            if (methodHandle.MethodId == new NodeId(Model.Methods.Demo_Method_EnumTest, DefaultNamespaceIndex))
            {
                return DoEnumTest;
            }

            if (methodHandle.MethodId == new NodeId(Model.Methods.Demo_Method_Multiply, DefaultNamespaceIndex))
            {
                return DoMultiply;
            }

            if (methodHandle.MethodId == new NodeId(Model.Methods.Demo_Method_VectorAdd, DefaultNamespaceIndex))
            {
                return DoVectorAdd;
            }

            if (methodHandle.MethodId == new NodeId(Model.Methods.Demo_Method_OptionSetBaseTest, DefaultNamespaceIndex))
            {
                return DoOptionSetBaseTest;
            }

            if (methodHandle.MethodId == new NodeId(Model.Methods.Demo_Method_OptionSetByteTest, DefaultNamespaceIndex))
            {
                return DoOptionSetByteTest;
            }

            if (methodHandle.MethodId == new NodeId(Model.Methods.Demo_Method_OptionSetUInt16Test, DefaultNamespaceIndex))
            {
                return DoOptionSetUInt16Test;
            }

            if (methodHandle.MethodId == new NodeId(Model.Methods.Demo_Method_OptionSetUInt32Test, DefaultNamespaceIndex))
            {
                return DoOptionSetUInt32Test;
            }

            if (methodHandle.MethodId == new NodeId(Model.Methods.Demo_Method_OptionSetUInt64Test, DefaultNamespaceIndex))
            {
                return DoOptionSetUInt64Test;
            }

            if (methodHandle.MethodId == new NodeId(Model.Methods.Demo_Method_StructureWithAbstractBaseTypesTest, DefaultNamespaceIndex))
            {
                return DoStructureWithAbstractBaseTypesTest;
            }

            if (methodHandle.MethodId == new NodeId(Model.Methods.Demo_Method_StructureWithDerivedStructuresTest, DefaultNamespaceIndex))
            {
                return DoStructureWithDerivedStructuresTest;
            }

            if (methodHandle.MethodId == new NodeId(Model.Methods.Demo_Method_StructureWithDifferentDataTypesTest, DefaultNamespaceIndex))
            {
                return DoStructureWithDifferentDataTypesTest;
            }

            if (methodHandle.MethodId == new NodeId(Model.Methods.Demo_StartSimulation, DefaultNamespaceIndex))
            {
                return DoStartSimulation;
            }

            if (methodHandle.MethodId == new NodeId(Model.Methods.Demo_StopSimulation, DefaultNamespaceIndex))
            {
                return DoStopSimulation;
            }

            if (methodHandle.MethodId == new NodeId(Model.Methods.Demo_SetSimulationSpeed, DefaultNamespaceIndex))
            {
                return DoSetSimulationSpeed;
            }

            if (methodHandle.MethodId == new NodeId(Model.Methods.Demo_Images_Dynamic_SetAnimationSpeed, DefaultNamespaceIndex))
            {
                return DoSetAnimationSpeed;
            }

            if (methodHandle.MethodId == new NodeId(Model.Methods.Demo_History_StartLogging, DefaultNamespaceIndex))
            {
                return DoStartLogging;
            }

            if (methodHandle.MethodId == new NodeId(Model.Methods.Demo_History_StopLogging, DefaultNamespaceIndex))
            {
                return DoStopLogging;
            }

            if (methodHandle.MethodId == new NodeId(Model.Methods.Demo_DynamicNodes_CreateDynamicNode, DefaultNamespaceIndex))
            {
                return DoCreateDynamicNode;
            }

            if (methodHandle.MethodId == new NodeId(Model.Methods.Demo_DynamicNodes_DeleteDynamicNode, DefaultNamespaceIndex))
            {
                return DoDeleteDynamicNode;
            }

            if (methodHandle.MethodId == new NodeId(Model.Methods.Demo_CTT_Methods_MethodIO, DefaultNamespaceIndex))
            {
                return DoMethodIO;
            }

            if (methodHandle.MethodId == new NodeId(Model.Methods.Demo_CTT_Methods_MethodI, DefaultNamespaceIndex))
            {
                return DoMethodI;
            }

            if (methodHandle.MethodId == new NodeId(Model.Methods.Demo_CTT_Methods_MethodO, DefaultNamespaceIndex))
            {
                return DoMethodO;
            }

            if (methodHandle.MethodId == new NodeId(Model.Methods.Demo_CTT_Methods_MethodNoArgs, DefaultNamespaceIndex))
            {
                return DoMethodNoArgs;
            }

            return base.GetMethodDispatcher(context, methodHandle);
        }

        #endregion

        #region Private Methods
        private StatusCode DoTriggerMultipleEvents(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            //The SDK guarantees for correct input arguments of known data types.
            //Only inner ExtensionObjects must be checked by the application.

            uint numberOfEvents = (uint)inputArguments[0].Value;
            NodeId eventTypeId = new NodeId(UnifiedAutomation.Demo.Model.ObjectTypes.SampleEventType, DefaultNamespaceIndex);
            NodeId sourceId = new NodeId(Model.Methods.Demo_Events_TriggerMultipleEvents, DefaultNamespaceIndex);
            NodeId notifierId = new NodeId(Model.Objects.Demo_Events_SampleEventNotifier, DefaultNamespaceIndex);

            for (uint i = 0; i < numberOfEvents; i++)
            {
                FireEvent(
                    eventTypeId,
                    sourceId,
                    notifierId,
                    $"Event {i + 1} of {numberOfEvents}",
                    i);
            }
            return StatusCodes.Good;
        }

        private StatusCode DoSomethingAfter10ms(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            TimeSpan delay = TimeSpan.FromMilliseconds(10000);
#if NET35 || NET40
            Thread.Sleep(delay);
#else
            // We make the method cancellable by using the
            // cancellation token of the request context.
            // If the delay task is cancelled the GetResult()
            // method will throw a OperationCanceledException.
            System.Threading.Tasks.Task
                .Delay(delay, context.CancellationToken)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
#endif
            return StatusCodes.Good;
        }

        private StatusCode DoEnumTest(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            Model.HeaterStatus HeaterStatus;
            Model.Priority Priority;
            Model.HeaterStatus RetHeaterStatus;
            Model.Priority RetPriority;

            HeaterStatus = (Model.HeaterStatus)inputArguments[0].GetValue<int>((int)Model.HeaterStatus.Off);
            Priority = (Model.Priority)inputArguments[1].GetValue<int>((int)Model.Priority.Low);

            RetHeaterStatus = HeaterStatus;
            RetPriority = Priority;

            outputArguments[0] = new Variant((int)RetHeaterStatus);
            outputArguments[1] = new Variant((int)RetPriority);

            return StatusCodes.Good;
        }

        private StatusCode DoMethodNoArgs(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            return StatusCodes.Good;
        }

        private StatusCode DoMethodIO(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            uint Summand1 = inputArguments[0].GetValue<uint>(0);
            uint Summand2 = inputArguments[1].GetValue<uint>(0);
            outputArguments[0] = new Variant(Summand1 + Summand2);
            return StatusCodes.Good;
        }

        private StatusCode DoMethodI(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            uint input1 = inputArguments[0].GetValue<uint>(0);
            uint input2 = inputArguments[1].GetValue<uint>(0);
            return StatusCodes.Good;
        }

        private StatusCode DoMethodO(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            uint uInt1 = 123;
            uint uInt2 = 456;
            outputArguments[0] = uInt1;
            outputArguments[1] = uInt2;
            return StatusCodes.Good;
        }

        private StatusCode DoMultiply(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            double x = inputArguments[0].ToDouble();
            double y = inputArguments[1].ToDouble();

            outputArguments[0] = x * y;

            return StatusCodes.Good;
        }

        private StatusCode DoVectorAdd(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            Model.Vector a = ExtensionObject.GetObject<Model.Vector>(inputArguments[0].ToExtensionObject());
            Model.Vector b = ExtensionObject.GetObject<Model.Vector>(inputArguments[1].ToExtensionObject());

            Model.Vector c = new Model.Vector();

            c.X = a.X + b.X;
            c.Y = a.Y + b.Y;
            c.Z = a.Z + b.Z;

            outputArguments[0] = new ExtensionObject(c);

            return StatusCodes.Good;
        }

        private StatusCode DoOptionSetBaseTest(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            Model.OptionSetBase InOptionSetBase = ExtensionObject.GetObject<Model.OptionSetBase>(inputArguments[0].ToExtensionObject());

            if (!InOptionSetBase.IsValid())
            {
                inputArgumentResults[0] = StatusCodes.BadOutOfRange;
                return StatusCodes.BadInvalidArgument;
            }

            Model.OptionSetBase OutOptionSetBase = new Model.OptionSetBase();
            OutOptionSetBase.SetValidBits(InOptionSetBase.ValidFlags | Model.OptionSetBaseFlags.CONTENT);
            OutOptionSetBase.Flags = InOptionSetBase.Flags | Model.OptionSetBaseFlags.CONTENT;
            outputArguments[0] = new Variant(new ExtensionObject(OutOptionSetBase));
            return StatusCodes.Good;
        }

        /// [Methods InputArgumentResults]
        private StatusCode DoOptionSetByteTest(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            byte inOptionSetByte = inputArguments[0].ToByte();

            if (inOptionSetByte >=  ((byte) Model.OptionSetByte.CONTENT) * 2)
            {
                inputArgumentResults[0] = StatusCodes.BadOutOfRange;
                return StatusCodes.BadInvalidArgument;
            }
            /// [Methods InputArgumentResults]

            Model.OptionSetByte InOptionSetByte = (Model.OptionSetByte)inputArguments[0].ToByte();
            Model.OptionSetByte OutOptionSetByte = InOptionSetByte | Model.OptionSetByte.INFO;
            outputArguments[0] = new Variant((byte)OutOptionSetByte);
            return StatusCodes.Good;
        }

        private StatusCode DoOptionSetUInt16Test(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            UInt16 inOptionSetUInt16 = inputArguments[0].ToUInt16();

            if (inOptionSetUInt16 >= ((UInt16)Model.OptionSetUInt16.CONTENT) * 2)
            {
                inputArgumentResults[0] = StatusCodes.BadOutOfRange;
                return StatusCodes.BadInvalidArgument;
            }

            Model.OptionSetUInt16 InOptionSetUInt16 = (Model.OptionSetUInt16)inputArguments[0].ToUInt16();
            Model.OptionSetUInt16 OutOptionSetUInt16 = InOptionSetUInt16 | Model.OptionSetUInt16.INFO;
            outputArguments[0] = new Variant((UInt16)OutOptionSetUInt16);
            return StatusCodes.Good;
        }

        private StatusCode DoOptionSetUInt32Test(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            UInt32 inOptionSetUInt32 = inputArguments[0].ToUInt32();

            if (inOptionSetUInt32 >= ((UInt32)Model.OptionSetUInt32.CONTENT) * 2)
            {
                inputArgumentResults[0] = StatusCodes.BadOutOfRange;
                return StatusCodes.BadInvalidArgument;
            }

            Model.OptionSetUInt32 InOptionSetUInt32 = (Model.OptionSetUInt32)inputArguments[0].ToUInt32();
            Model.OptionSetUInt32 OutOptionSetUInt32 = InOptionSetUInt32 | Model.OptionSetUInt32.INFO;
            outputArguments[0] = new Variant((UInt32)OutOptionSetUInt32);
            return StatusCodes.Good;
        }

        private StatusCode DoOptionSetUInt64Test(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            UInt64 inOptionSetUInt64 = inputArguments[0].ToUInt64();

            if (inOptionSetUInt64 >= ((UInt64)Model.OptionSetUInt64.GGG) * 2)
            {
                inputArgumentResults[0] = StatusCodes.BadOutOfRange;
                return StatusCodes.BadInvalidArgument;
            }

            Model.OptionSetUInt64 InOptionSetUInt64 = (Model.OptionSetUInt64)inputArguments[0].ToUInt64();
            Model.OptionSetUInt64 OutOptionSetUInt64 = InOptionSetUInt64 | Model.OptionSetUInt64.AA;
            outputArguments[0] = new Variant((UInt64)OutOptionSetUInt64);
            return StatusCodes.Good;
        }

        private StatusCode DoStructureWithAbstractBaseTypesTest(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            Model.StructureWithAbstractBaseTypes Input = ExtensionObject.GetObject<Model.StructureWithAbstractBaseTypes>(inputArguments[0].ToExtensionObject());

            if (Input.Base1 == null || Input.Base2 == null)
            {
                inputArgumentResults[0] = StatusCodes.BadTypeMismatch;
                return StatusCodes.BadInvalidArgument;
            }

            Model.ConcreteSubType outAbstractBaseValue = new Model.ConcreteSubType();
            var inBase1 = Input.Base1 as Model.ConcreteSubType;
            var inBase2 = Input.Base2 as Model.ConcreteSubType;

            if (inBase1 == null || inBase2 == null)
            {
                inputArgumentResults[0] = StatusCodes.BadTypeMismatch;
                return StatusCodes.BadInvalidArgument;
            }

            outAbstractBaseValue.Double = inBase1.Double + inBase2.Double;
            outAbstractBaseValue.Int16 = (short)(inBase1.Int16 + inBase2.Int16);
            outAbstractBaseValue.UInt32 = inBase1.UInt32 + inBase2.UInt32;
            outAbstractBaseValue.String = inBase1.String + inBase2.String;
            Model.StructureWithAbstractBaseTypes Output = new Model.StructureWithAbstractBaseTypes();
            Output.Base1 = outAbstractBaseValue;
            Output.Base2 = outAbstractBaseValue;
            outputArguments[0] = new Variant(new ExtensionObject(Output));
            return StatusCodes.Good;
        }

        private StatusCode DoStructureWithDerivedStructuresTest(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            Model.StructureWithDerivedStructures Input = ExtensionObject.GetObject<Model.StructureWithDerivedStructures>(inputArguments[0].ToExtensionObject());

            var outBuildInfo = Input.BuildInfo;
            var outVector = Input.Vector;

            outBuildInfo.BuildDate = outBuildInfo.BuildDate.AddHours(1);
            outBuildInfo.BuildNumber += "_Method";
            outBuildInfo.ManufacturerName += "_Method";
            outBuildInfo.ProductName += "_Method";
            outBuildInfo.ProductUri += "_Method";
            outBuildInfo.SoftwareVersion += "_Method";

            outVector.X *= 3;
            outVector.Y += 2;
            outVector.Z -= 1;

            Model.StructureWithDerivedStructures Output = new Model.StructureWithDerivedStructures();
            Output.BuildInfo = outBuildInfo;
            Output.Vector = outVector;
            outputArguments[0] = new Variant(new ExtensionObject(Output));
            return StatusCodes.Good;
        }

        private StatusCode DoStructureWithDifferentDataTypesTest(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            Model.StructureWithDifferentDataTypes Input = ExtensionObject.GetObject<Model.StructureWithDifferentDataTypes>(inputArguments[0].ToExtensionObject());

            if (!Enum.IsDefined(typeof(Model.HeaterStatus),Input.EnumerationType))
            {
                inputArgumentResults[0] = StatusCodes.BadOutOfRange;
                return StatusCodes.BadInvalidArgument;
            }

            var outOptionSet = Input.OptionSetType;
            var outStructure = Input.StructureType;
            var outEnumType = Input.EnumerationType;

            outOptionSet.SetInvalidBits(Model.OptionSetBaseFlags.ERROR);
            outOptionSet.Flags = Input.OptionSetType.Flags | Model.OptionSetBaseFlags.SYSTEM;

            outStructure.X *= 3;
            outStructure.Y += 2;
            outStructure.Z -= 1;

            Model.StructureWithDifferentDataTypes Output = new Model.StructureWithDifferentDataTypes();
            Output.OptionSetType = outOptionSet;
            Output.StructureType = outStructure;
            Output.EnumerationType = outEnumType;
            outputArguments[0] = new Variant(new ExtensionObject(Output));
            return StatusCodes.Good;
        }

        internal StatusCode StartSimulation(RequestContext context)
        {
            lock (m_datasources)
            {
                if (m_simulationTimer != null)
                {
                    return StatusCodes.BadInvalidState;
                }

                uint simulationSpeed = m_simulationSpeed.Value.ToUInt32();
                m_simulationTimer = new Timer(DoSimulation, null, simulationSpeed, simulationSpeed);
                m_animationTimer = new Timer(DoAnimation, null, 50, 50);

                m_simulationActive.Value = true;
                ReportChange(context, m_simulationActive, 0);
                return StatusCodes.Good;
            }
        }

        private StatusCode DoStartSimulation(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            return StartSimulation(context);
        }

        internal StatusCode StopSimulation(RequestContext context)
        {
            lock (m_datasources)
            {
                if (m_simulationTimer == null)
                {
                    return StatusCodes.BadInvalidState;
                }

                m_simulationTimer.Dispose();
                m_simulationTimer = null;

                m_animationTimer.Dispose();
                m_animationTimer = null;

                m_simulationActive.Value = false;
                ReportChange(context, m_simulationActive, 0);
            }
            return StatusCodes.Good;
        }

        private StatusCode DoStopSimulation(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            return StopSimulation(context);
        }

        internal StatusCode SetSimulationSpeed(
            RequestContext context,
            uint simulationSpeed)
        {
            lock (m_datasources)
            {
                if (simulationSpeed < 250)
                {
                    return new StatusCode(StatusCodes.BadOutOfRange, "The simulation speed must be greater than 250ms.");
                }

                if (m_simulationTimer != null)
                {
                    m_simulationTimer.Dispose();
                    m_simulationTimer = new Timer(DoSimulation, null, simulationSpeed, simulationSpeed);
                }

                m_simulationSpeed.Value = simulationSpeed;
                ReportChange(context, m_simulationSpeed, 0);
            }

            return StatusCodes.Good;
        }

        private StatusCode DoSetSimulationSpeed(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            uint simulationSpeed = inputArguments[0].ToUInt32();
            StatusCode statusCode = SetSimulationSpeed(context, simulationSpeed);
            if (statusCode.IsBad())
            {
                inputArgumentResults[0] = statusCode;
                return StatusCodes.BadInvalidArgument;
            }
            return StatusCodes.Good;
        }

        internal StatusCode SetAnimationSpeed(
            RequestContext context,
            uint animationSpeed)
        {
            lock (m_datasources)
            {
                if (animationSpeed != 0)
                {
                    if (animationSpeed < 30)
                    {
                        return new StatusCode(StatusCodes.BadInvalidArgument, "The animation speed must be greater than 30.");
                    }

                    if (m_animationTimer != null)
                    {
                        m_animationTimer.Dispose();
                        m_animationTimer = new Timer(DoAnimation, null, animationSpeed, animationSpeed);
                    }
                }
            }
            return StatusCodes.Good;
        }

        private StatusCode DoSetAnimationSpeed(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            uint animationSpeed = inputArguments[0].ToUInt32();
            return SetAnimationSpeed(context, animationSpeed);
        }
        
        private StatusCode DoStartLogging(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            return StartLogging(context);
        }

        private StatusCode DoStopLogging(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            return StopLogging(context);
        }

        private StatusCode DoCreateDynamicNode(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            lock (m_dynamicNodeLock)
            {
                lock (m_datasources)
                {
                    if (m_dynamicNode != null && m_dynamicNode.Status == StatusCodes.Good)
                    {
                        return StatusCodes.BadInvalidState;
                    }

                    if (m_dynamicNode == null)
                    {
                        m_dynamicNode = new DataVariableDataSource()
                        {
                            TypeInfo = TypeInfo.Scalars.UInt32,
                            Timestamp = DateTime.UtcNow,
                            Status = StatusCodes.Good,
                            SimulationType = SimulationType.Random,
                            AccessLevel = AccessLevels.CurrentReadOrWrite,
                            Value = (uint)0
                        };

                        m_dynamicNode.GenerateRandomValue(m_generator);
                        m_dynamicNodeAddress = new DataSourceAddress(m_dynamicNode, 0);
                    }
                    else
                    {
                        m_dynamicNode.Status = StatusCodes.Good;
                        m_dynamicNode.SimulationType = SimulationType.Random;
                    }
                }

                /// [Add dynamic node]
                string name = "DynamicNode";

                CreateVariableSettings settings = new CreateVariableSettings()
                {
                    ParentNodeId = new NodeId("Demo.DynamicNodes", DefaultNamespaceIndex),
                    ReferenceTypeId = ReferenceTypeIds.HasComponent,
                    RequestedNodeId = new NodeId("Demo.DynamicNodes." + name, DefaultNamespaceIndex),
                    BrowseName = new QualifiedName(name, DefaultNamespaceIndex),
                    DisplayName = name,
                    AccessLevel = AccessLevels.CurrentReadOrWrite,
                    DataType = DataTypeIds.UInt32,
                    ValueRank = ValueRanks.Scalar,
                    MinimumSamplingInterval = 0,
                    Historizing = false,
                    TypeDefinitionId = VariableTypeIds.BaseDataVariableType
                };

                VariableNode parentNode = CreateVariable(Server.DefaultRequestContext, settings);
                /// [Add dynamic node]

                SetVariableConfiguration(parentNode.NodeId, NodeHandleType.ExternalPush, m_dynamicNodeAddress);
                ReportChange(context, m_dynamicNode, 0);

                name = name + ".Property";
                CreateVariableSettings variableSettings = new CreateVariableSettings()
                {
                    ParentNodeId = parentNode.NodeId,
                    ReferenceTypeId = ReferenceTypeIds.HasComponent,
                    RequestedNodeId = new NodeId("Demo.DynamicNodes." + name, DefaultNamespaceIndex),
                    BrowseName = new QualifiedName("Property", DefaultNamespaceIndex),
                    DisplayName = "Property",
                    AccessLevel = AccessLevels.CurrentReadOrWrite,
                    DataType = DataTypeIds.UInt32,
                    ValueRank = ValueRanks.Scalar,
                    MinimumSamplingInterval = 0,
                    Historizing = false,
                    TypeDefinitionId = VariableTypeIds.PropertyType,
                    ParentAsOwner = true
                };
                var property = CreateVariable(Server.DefaultRequestContext, variableSettings);

                // Report DataChanges for in memory node
                // The SDK does not report the DataChanges for added nodes, so we report the
                // explicitly here.
                // In most use cases the address space does not change or add nodes are not added again.
                // So calling ReportDataChanges only slow down adding nodes.
                NodeAttributeHandle nodeHandle;
                GetNodeHandle(context, property.NodeId, Attributes.Value, out nodeHandle);
                ReportDataChanges(context, nodeHandle);

                return StatusCodes.Good;
            }
        }

        private StatusCode DoDeleteDynamicNode(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            lock (m_dynamicNodeLock)
            {
                lock (m_datasources)
                {
                    if (m_dynamicNode == null || m_dynamicNode.Status.IsBad())
                    {
                        return StatusCodes.BadInvalidState;
                    }

                    m_dynamicNode.SimulationType = SimulationType.None;
                    m_dynamicNode.Status = StatusCodes.Bad;
                }

                StatusCode ret = DeleteNode(context, new NodeId("Demo.DynamicNodes.DynamicNode", DefaultNamespaceIndex), true);

                ReportChangeStatus(context, m_dynamicNode, 0, StatusCodes.BadNodeIdUnknown);

                return ret;
            }
        }
#endregion

#region Private Fields
        private DataVariableDataSource m_simulationActive;
        private DataVariableDataSource m_dataLoggerActive;
        private DataVariableDataSource m_simulationSpeed;
        private DataVariableDataSource m_dynamicNode;
        private DataSourceAddress m_dynamicNodeAddress;
#endregion
    }
}
