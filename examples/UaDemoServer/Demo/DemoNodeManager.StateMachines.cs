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
using UnifiedAutomation.Sample;
using System.ComponentModel;

namespace UnifiedAutomation.Demo.Model
{
    /// [ICountdownStateMachineMethods]
    public partial class CountdownStateMachineModel : Model.ICountdownStateMachineMethods
    {
        /// [ICountdownStateMachineMethods]
        public event ProgressChangedEventHandler ProgressChanged;

        private Timer Timer { get; set; }

        /// [Switched event]
        public CountdownStateMachineModel(int startValue)
        {
            Value = startValue;

            Switched += (o, e) =>
            {
                switch (e.OldState)
                {
                    case State.Running:
                    case State.Suspended:
                        StopTimer();
                        break;
                }

                switch (e.NewState)
                {
                    case State.Ready:
                        Value = startValue;
                        RecycleCount++;
                        break;
                    case State.Running:
                        StartTimer();
                        break;
                }
            };
        }
        /// [Switched event]

        private void StartTimer()
        {
            Timer = new Timer(OnTimer, null, 100, 100);
        }

        private void StopTimer()
        {
            if (Timer != null)
            {
                Timer.Dispose();
                Timer = null;
            }
        }

        /// [OnTimer 1]
        private void OnTimer(object state)
        {
            Value--;
            if (Value == 0)
            {
                Timer.Dispose();
                Timer = null;

                SwitchToState(State.Halted);
            }
            /// [OnTimer 1]
            /// [OnTimer 2]
            if (Value % 100 == 0 && Value > 0)
            {
                RaiseProgressChanged();
            }
        }
        /// [OnTimer 2]

        protected void RaiseProgressChanged()
        {
            var handler = ProgressChanged;
            if (handler != null)
            {
                var args = new ProgressChangedEventArgs((int)(1000 - Value)/10, null);
                handler(this, args);
            }
        }

        #region IProgramStateMachineMethods
        public StatusCode Halt(RequestContext context, Model.CountdownStateMachineModel model)
        {
            if (InternalState != State.Running
                && InternalState != State.Ready
                && InternalState != State.Suspended)
            {
                return StatusCodes.BadInvalidState;
            }

            SwitchToState(State.Halted);

            return StatusCodes.Good;
        }

        public StatusCode Reset(RequestContext context, CountdownStateMachineModel model)
        {
            if (InternalState != State.Halted)
            {
                return StatusCodes.BadInvalidState;
            }

            SwitchToState(State.Ready);

            return StatusCodes.Good;
        }

        public StatusCode Resume(RequestContext context, CountdownStateMachineModel model)
        {
            if (InternalState != State.Suspended)
            {
                return StatusCodes.BadInvalidState;
            }

            SwitchToState(State.Running);

            return StatusCodes.Good;
        }

        /// [Call Method]
        public StatusCode Start(RequestContext context, CountdownStateMachineModel model)
        {
            if (InternalState != State.Ready)
            {
                return StatusCodes.BadInvalidState;
            }

            SwitchToState(State.Running);

            return StatusCodes.Good;
        }
        /// [Call Method]

        public StatusCode Suspend(RequestContext context, CountdownStateMachineModel model)
        {
            if (InternalState != State.Running)
            {
                return StatusCodes.BadInvalidState;
            }

            SwitchToState(State.Suspended);

            return StatusCodes.Good;
        }
        #endregion

    }
}

namespace UnifiedAutomation.Demo
{
    internal partial class DemoNodeManager
    {
        public NodeId HaltId { get; private set; }
        public NodeId ResetId { get; private set; }
        public NodeId ResumeId { get; private set; }
        public NodeId StartId { get; private set; }
        public NodeId SuspendId { get; private set; }

        #region private methods
        /// [LinkModelToNode]
        private void SetupProgramStateMachine()
        {
            NodeId programId = new NodeId(Demo.Model.Objects.Demo_StateMachines_Program, DefaultNamespaceIndex);
            string programName = "Program";

            var program = new Demo.Model.CountdownStateMachineModel(1000);
            program.SwitchToState(ProgramStateMachineModel.State.Ready);

            LinkModelToNode(
                programId,
                program,
                null,
                null,
                0);
            /// [LinkModelToNode]

            /// [Method Ids]
            StartId = GetMethodId(programId, new QualifiedName(BrowseNames.Start));
            SuspendId = GetMethodId(programId, new QualifiedName(BrowseNames.Suspend));
            HaltId = GetMethodId(programId, new QualifiedName(BrowseNames.Halt));
            ResetId = GetMethodId(programId, new QualifiedName(BrowseNames.Reset));
            ResumeId = GetMethodId(programId, new QualifiedName(BrowseNames.Resume));
            /// [Method Ids]

            SetExecutable(ResetId, false);
            SetExecutable(ResumeId, false);
            SetExecutable(SuspendId, false);

            /// [Model event 1]
            program.Switched += (o, e) =>
            {
                var ev = new ProgramTransitionEventModel()
                {
                    Time = DateTime.UtcNow,
                    IntermediateResult = program.Value,
                    SourceNode = programId,
                    SourceName = programName,
                    Severity = (ushort) EventSeverity.Medium,
                    EventType = ObjectTypeIds.ProgramTransitionEventType,
                    Message = new LocalizedText("Transition"),
                };
                /// [Model event 1]

                if (e.Transition.HasValue)
                {
                    var transition = e.Transition.Value;
                    ev.Transition = new TransitionVariableModel()
                    {
                        Value = ProgramStateMachineModel.GetLocalizedText(transition),
                        Id = ProgramStateMachineModel.GetNodeId(transition),
                    };
                }

                if (e.OldState.HasValue)
                {
                    var state = e.OldState.Value;
                    ev.FromState = new StateVariableModel()
                    {
                        Value = ProgramStateMachineModel.GetLocalizedText(state),
                        Id = ProgramStateMachineModel.GetNodeId(state),
                    };
                }

                if (e.NewState.HasValue)
                {
                    var state = e.NewState.Value;
                    ev.ToState = new StateVariableModel()
                    {
                        Value = ProgramStateMachineModel.GetLocalizedText(state),
                        Id = ProgramStateMachineModel.GetNodeId(state),
                    };
                }

                /// [Model event 2]
                GenericEvent ge = ev.CreateEvent(Server.FilterManager, true);
                ReportEvent(programId, ge);
                /// [Model event 2]

                /// [Update Executable]
                switch (e.Transition)
                {
                    case ProgramStateMachineModel.Transition.HaltedToReady:
                        SetExecutable(ResetId, false);
                        SetExecutable(StartId, true);
                        break;
                    case ProgramStateMachineModel.Transition.ReadyToHalted:
                        SetExecutable(HaltId, false);
                        SetExecutable(ResetId, true);
                        break;
                    /// [Update Executable]
                    case ProgramStateMachineModel.Transition.ReadyToRunning:
                        SetExecutable(StartId, false);
                        SetExecutable(SuspendId, true);
                        break;

                    case ProgramStateMachineModel.Transition.RunningToHalted:
                        SetExecutable(SuspendId, false);
                        SetExecutable(ResetId, true);
                        SetExecutable(HaltId, false);
                        break;
                    case ProgramStateMachineModel.Transition.RunningToReady:
                        SetExecutable(SuspendId, false);
                        SetExecutable(StartId, true);
                        break;
                    case ProgramStateMachineModel.Transition.RunningToSuspended:
                        SetExecutable(SuspendId, false);
                        SetExecutable(ResumeId, true);
                        break;
                    case ProgramStateMachineModel.Transition.SuspendedToHalted:
                        SetExecutable(ResetId, true);
                        SetExecutable(HaltId, false);
                        break;
                    case ProgramStateMachineModel.Transition.SuspendedToReady:
                        SetExecutable(ResumeId, false);
                        SetExecutable(StartId, true);
                        break;
                    case ProgramStateMachineModel.Transition.SuspendedToRunning:
                        SetExecutable(ResumeId, false);
                        SetExecutable(SuspendId, true);
                        break;
                    case null:
                        break;
                }
            };

            /// [Generic event]
            program.ProgressChanged += (o, e) =>
            {
                GenericEvent ev = new GenericEvent(Server.FilterManager);
                ev.Initialize(
                    null,
                    ObjectTypeIds.ProgressEventType,
                    programId,
                    programName,
                    EventSeverity.Medium,
                    new LocalizedText("Progress"));
                ev.Set(BrowseNames.Context, programId);
                ev.Set(BrowseNames.Progress, (ushort)e.ProgressPercentage);

                ReportEvent(programId, ev);
            };
            /// [Generic event]
        }
        #endregion

        #region helpers

        /// [GetMethodId]
        private NodeId GetMethodId(NodeId programId, QualifiedName methodName)
        {
            var result = new BrowsePathResult();
            Server.InternalClient.Translate(
                Server.DefaultRequestContext,
                programId,
                new RelativePath(methodName),
                0,
                result);
            return (NodeId)result.Targets[0].TargetId;
        }
        /// [GetMethodId]

        /// [SetExecutable]
        void SetExecutable(NodeId nodeId, bool value)
        {
            Server.InternalClient.WriteAttribute(
                Server.DefaultRequestContext,
                nodeId,
                Attributes.Executable,
                new Variant(value));
        }
        /// [SetExecutable]

        #endregion
    }
}