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
    internal partial class DemoNodeManager : UnifiedAutomation.Demo.Model.IBoilerMethods
    {
        #region Private Methods
        private void SetupBoiler()
        {
            NodeId boilerId = new NodeId("Demo.BoilerDemo.Boiler1", DefaultNamespaceIndex);

            m_boiler1 = new UnifiedAutomation.Demo.Model.BoilerModel()
            {
                BoilerMethods = this
            };

            LinkModelToNode(boilerId, m_boiler1, null, null, 500);

            m_boiler1.FillLevelSensor.FillLevel.Value = 15;
            m_boiler1.FillLevelSensor.FillLevel.EURange = new UaBase.Range() { High = 100, Low = 0 };
            m_boiler1.FillLevelSensor.FillLevel.EngineeringUnits = EngineeringUnits.Metre;
            m_boiler1.FillLevelSetPoint = 15;
            m_boiler1.HeaterStatus = UnifiedAutomation.Demo.Model.HeaterStatus.Off;
            m_boiler1.TemperatureSetPoint = 15;
            m_boiler1.TemperatureSensor.Temperature.Value = 15;
            m_boiler1.TemperatureSensor.Temperature.EURange = new UaBase.Range() { High = 100, Low = 0 };
            m_boiler1.TemperatureSensor.Temperature.EngineeringUnits = EngineeringUnits.Degree_Celsius;

            AddNotifier(boilerId, ObjectIds.Server);
            AddReference(Server.DefaultRequestContext, boilerId, ReferenceTypeIds.HasNotifier, true, ObjectIds.Server, true);

            lock (InMemoryNodeLock)
            {
                // need to mark the boiler as a source for events.
                var notifier = FindInMemoryNode(new NodeId("Demo.BoilerDemo.Boiler1", DefaultNamespaceIndex)) as ObjectNode;

                if (notifier != null)
                {
                    notifier.EventNotifier |= EventNotifiers.SubscribeToEvents;
                }
            }

            // add a temperature alarm.
            NodeId alarmId = new NodeId(boilerId.Identifier.ToString() + ".TemperatureAlarm", DefaultNamespaceIndex);

            CreateObjectSettings settings = new CreateObjectSettings()
            {
                ParentNodeId = boilerId,
                ReferenceTypeId = ReferenceTypeIds.HasComponent,
                RequestedNodeId = alarmId,
                BrowseName = new QualifiedName("TemperatureAlarm", DefaultNamespaceIndex),
                TypeDefinitionId = ObjectTypeIds.ExclusiveLimitAlarmType,

                // add support for confirmation to this alarm.
                // With the children settings, the type definition id and some
                // attributes can be specified. If child settings exist for
                // an optional child, the child will be instantiated.
                ChildrenSettings =
                {
                    new ChildVariableSettings() { BrowsePath = { BrowseNames.ConfirmedState } },
                    new ChildMethodSettings() { BrowsePath = { BrowseNames.Confirm } },
                }
            };

            CreateObject(Server.DefaultRequestContext, settings);

            // create an in memory object that can be used to manage the alarm.
            ExclusiveLevelAlarmModel alarm = new ExclusiveLevelAlarmModel()
            {
                NodeId = alarmId,
                EventType = ObjectTypeIds.ExclusiveLimitAlarmType,
                SourceNode = boilerId,
                SourceName = "Boiler1",
                Message = "Controller is not maintaining temperature.",
                ConditionName = "TemperatureAlarm",
                ConditionClassId = ObjectTypeIds.ProcessConditionClassType,
                ConditionClassName = BrowseNames.ProcessConditionClassType,
                ConfirmedState = new TwoStateVariableModel(),
                HighLimit = 30,
                LowLimit = 20,
                InputNode = new NodeId(boilerId.Identifier.ToString() + ".TemperatureSensor.Temperature", DefaultNamespaceIndex)
            };

            alarm.ConditionChanged += (o, e) =>
            {
                GenericEvent ev = e.CreateEvent(Server.FilterManager, true);
                ReportEvent(boilerId, ev);
            };

            using (alarm.MergeTransitions())
            {
                alarm.Enable();
                alarm.Acknowledge(alarm.EventId, null, null);
                alarm.Confirm(alarm.EventId, null, null);
            }

            LinkModelToNode(alarmId, alarm, null, null, 500);

            m_alarm1 = alarm;
        }

        public override StatusCode AddComment(RequestContext context, ConditionModel model, byte[] eventId, LocalizedText comment)
        {
            lock (model)
            {
                return model.AddComment(eventId, comment, context.UserIdentity.UserName);
            }
        }

        public override StatusCode Acknowledge(RequestContext context, AcknowledgeableConditionModel model, byte[] eventId, LocalizedText comment)
        {
            lock (model)
            {
                return model.Acknowledge(eventId, comment, context.UserIdentity.UserName);
            }
        }

        public override StatusCode Confirm(RequestContext context, AcknowledgeableConditionModel model, byte[] eventId, LocalizedText comment)
        {
            lock (model)
            {
                if (model.AckedState.Id)
                {
                    return model.Confirm(eventId, comment, context.UserIdentity.UserName);
                }
                else
                {
                    return StatusCodes.BadInvalidState;
                }
            }
        }

        public override StatusCode Disable(RequestContext context, ConditionModel model)
        {
            lock (model)
            {
                return model.Disable();
            }
        }

        public override StatusCode Enable(RequestContext context, ConditionModel model)
        {
            lock (model)
            {
                StatusCode error = model.Enable();

                if (error.IsBad())
                {
                    return error;
                }

                if (model == m_alarm1)
                {
                    double temperature = m_boiler1.TemperatureSensor.Temperature.Value;

                    m_alarm1.Evaluate(temperature);
                }
            }
            return StatusCodes.Good;
        }

        private void UpdateBoiler()
        {
            lock (m_boiler1)
            {
                double delta = m_boiler1.FillLevelSetPoint - m_boiler1.FillLevelSensor.FillLevel.Value;
                m_boiler1.FillLevelSensor.FillLevel.Value += delta / 10;

                delta = m_boiler1.TemperatureSetPoint - m_boiler1.TemperatureSensor.Temperature.Value;
                m_boiler1.TemperatureSensor.Temperature.Value += delta / 10;

                if (delta > 0)
                {
                    m_boiler1.HeaterStatus = UnifiedAutomation.Demo.Model.HeaterStatus.Heating;
                }
                else if (delta < 0)
                {
                    m_boiler1.HeaterStatus = UnifiedAutomation.Demo.Model.HeaterStatus.Cooling;
                }
                else
                {
                    m_boiler1.HeaterStatus = UnifiedAutomation.Demo.Model.HeaterStatus.Off;
                }

                double temperature = m_boiler1.TemperatureSensor.Temperature.Value;
                
                lock (m_alarm1)
                {
                    m_alarm1.Evaluate(temperature);
                }
            }
        }
        #endregion

        #region IBoilerMethods Members
        /// [Boiler InputArgumentResults]
        public StatusCode Fill(RequestContext context, UnifiedAutomation.Demo.Model.BoilerModel model, double SetPoint)
        {
            lock (model)
            {
                if (SetPoint > model.FillLevelSensor.FillLevel.EURange.High)
                {
                    throw new MethodCallArgumentException(nameof(SetPoint), "Requested SetPoint too high.");
                }
                if (SetPoint < model.FillLevelSensor.FillLevel.EURange.Low)
                {
                    throw new MethodCallArgumentException(nameof(SetPoint), "Requested SetPoint too low.");
                }
                model.FillLevelSetPoint = SetPoint;
            }

            return StatusCodes.Good;
        }
        /// [Boiler InputArgumentResults]

        public StatusCode Heat(RequestContext context, UnifiedAutomation.Demo.Model.BoilerModel model, double SetPoint)
        {
            lock (model)
            {
                if (SetPoint > model.TemperatureSensor.Temperature.EURange.High)
                {
                    throw new MethodCallArgumentException("Requested SetPoint too high.", nameof(SetPoint));
                }
                if (SetPoint < model.TemperatureSensor.Temperature.EURange.Low)
                {
                    throw new MethodCallArgumentException("Requested SetPoint too low.", nameof(SetPoint));
                }
                model.TemperatureSetPoint = SetPoint;
            }

            return StatusCodes.Good;
        }
        #endregion

        #region Private Fields
        private  UnifiedAutomation.Demo.Model.BoilerModel m_boiler1;
        private ExclusiveLevelAlarmModel m_alarm1;
        #endregion
    }

}
