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
    internal partial class Lesson08NodeManager
    {
        /// <summary>
        /// Called when the state of a blockAddress changes.
        /// </summary>
        private void UnderlyingSystem_BlockStateChanged(int blockAddress, string blockName, int state)
        {
            // create the event.
            GenericEvent e = new GenericEvent(Server.FilterManager);

            // initialize base event type fields
            e.Initialize(
                null, // EventId created by SDK if null
                new NodeId(yourorganisation.BA.ObjectTypes.ControllerEventType, TypeNamespaceIndex), // EventType
                new NodeId(blockName, InstanceNamespaceIndex), // SourceNode
                blockName, // SourceName
                EventSeverity.Medium, // Severity
                "A controller state changed."); // Message

            // set additional event field State
            e.Set(e.ToPath(new QualifiedName(yourorganisation.BA.BrowseNames.State, TypeNamespaceIndex)), state);

            // report the event.
            ReportEvent(e.SourceNode, e);
            
            NodeId alarmId = new NodeId(blockName + "." + yourorganisation.BA.BrowseNames.StateCondition, InstanceNamespaceIndex);
            OffNormalAlarmModel alarm = (OffNormalAlarmModel)GetNodeUserData(alarmId);
            // Change state of StateCondition
            lock (alarm)
            {
                alarm.LastSeverity.Value = alarm.Severity;
                alarm.LastSeverity.SourceTimestamp = alarm.Time;
                if (state == 0)
                {
                    // Change state to active
                    alarm.Severity = (ushort)EventSeverity.High;
                    alarm.Activate();
                }
                else
                {
                    // Change state to inactive
                    alarm.Severity = (ushort)EventSeverity.Low;
                    alarm.Inactivate();
                }
            }
        }
        
        private void SetAlarmCondition(BlockConfiguration block)
        {
            NodeId alarmId = new NodeId(block.Name + "." + yourorganisation.BA.BrowseNames.StateCondition, InstanceNamespaceIndex);
            // Create off normal alarm data object
            OffNormalAlarmModel alarm = new OffNormalAlarmModel
            {
                NodeId = alarmId,
                EventType = ObjectTypeIds.OffNormalAlarmType,
                SourceNode = new NodeId(block.Name, InstanceNamespaceIndex),
                SourceName = block.Name,
                Severity = (ushort)EventSeverity.Low,
                ConditionName = "StateCondition",
                ConditionClassId = ObjectTypeIds.ProcessConditionClassType,
                ConditionClassName = BrowseNames.ProcessConditionClassType,
                Message = $"{block.Name} is off!"
            };

            // Set the default values for ActiveState, AckedState, etc.
            alarm.ActivateModel(Server.DefaultRequestContext);
            alarm.Enable();

            // Link alarm data object to nodes in address space
            LinkModelToNode(alarmId, alarm, null, null, 500);

            // When ever the condition changes we create and
            // report an event for it.
            alarm.ConditionChanged += (o, e) =>
            {
                GenericEvent ev = e.CreateEvent(Server.FilterManager, true);
                ReportEvent(alarm.SourceNode, ev);
            };
        }
        /// <summary>
        /// Acknowledges an alarm.
        /// </summary>
        public override StatusCode Acknowledge(
            RequestContext context,
            AcknowledgeableConditionModel model,
            byte[] eventId,
            LocalizedText comment)
        {
            lock (model)
            {
                return model.Acknowledge(eventId, comment, context.UserIdentity.UserName);
            }
        }

        /// <summary>
        /// Confirms an alarm.
        /// </summary>
        public override StatusCode Confirm(
            RequestContext context,
            AcknowledgeableConditionModel model,
            byte[] eventId,
            LocalizedText comment)
        {
            lock (model)
            {
                return model.Confirm(eventId, comment, context.UserIdentity.UserName);
            }
        }

        #region Private Fields
        private object m_lock = new object();
        private Timer m_alarmTimer;
        private List<ExclusiveLevelAlarmModel> m_alarms;
        #endregion
    }
}
