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
    internal partial class Lesson05NodeManager
    {
        /// <summary>
        /// Called when the state of a blockAddress changes.
        /// </summary>
        /// [Report Event]
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
        }
        /// [Report Event]
    }
}
