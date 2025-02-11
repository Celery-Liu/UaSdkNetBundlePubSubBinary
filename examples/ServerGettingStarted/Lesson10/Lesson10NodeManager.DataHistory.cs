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
    internal partial class Lesson10NodeManager
    {
        /// [Step 3]
        private CreateObjectSettings AddHistorySettings(CreateObjectSettings settings, BlockConfiguration block, BlockProperty property, VariableNode variable)
        {
            if (property.History != null)
            {
                // enable historical access.
                variable.AccessLevel |= AccessLevels.HistoryRead;

                // this ensures the address is passed in history handles.
                SetNodeUserData(variable.NodeId, new SystemAddress() { Address = block.Address, Offset = property.Offset });

                NodeId configurationId = new NodeId(block.Name + "." + property.Name + "." + BrowseNames.HAConfiguration, InstanceNamespaceIndex);

                // create historical configuration object.
                settings = new CreateObjectSettings()
                {
                    ParentNodeId = variable.NodeId,
                    ReferenceTypeId = ReferenceTypeIds.HasHistoricalConfiguration,
                    RequestedNodeId = configurationId,
                    BrowseName = BrowseNames.HAConfiguration,
                    TypeDefinitionId = UnifiedAutomation.UaBase.ObjectTypeIds.HistoricalDataConfigurationType,

                    // add optional properties.
                    // With the children settings, the type definition id and some
                    // attributes can be specified. If child settings exist for
                    // an optional child, the child will be instantiated.
                    ChildrenSettings =
                    {
                        new ChildInstanceSettings()
                        {
                            BrowsePath = { BrowseNames.StartOfArchive }
                        },
                        new ChildInstanceSettings()
                        {
                            BrowsePath = { BrowseNames.StartOfOnlineArchive }
                        }
                    }
                };

                CreateObject(Server.DefaultRequestContext, settings);

                // link model to node.
                LinkModelToNode(configurationId, property.HistoryConfiguration, null, null, 500);
            }

            return settings;
        }
        /// [Step 3]

        /// [Step 4]
        protected override HistoryDataReadRawContinuationPoint CreateHistoryContinuationPoint(
            RequestContext context,
            ReadRawModifiedDetails details,
            HistoryDataHandle nodeHandle,
            TimestampsToReturn timestampsToReturn,
            string indexRange,
            QualifiedName dataEncoding)
        {
            // the data passed to SetNodeUserData is returned as the NodeData in the handle.
            SystemAddress address = nodeHandle.NodeData as SystemAddress;

            if (address == null)
            {
                return null;
            }

            IHistoryDataSource datasource = m_system.GetHistoryDataSource(address.Address, address.Offset);

            if (datasource == null)
            {
                return null;
            }

            HistoryDataRawReader reader = new HistoryDataRawReader();
            reader.Initialize(context, datasource, details);

            HistoryDataReadRawContinuationPoint cp = new HistoryDataReadRawContinuationPoint()
            {
                Reader = reader,
                NumValuesPerNode = details.NumValuesPerNode,
                TimestampsToReturn = timestampsToReturn,
                ApplyIndexRangeAndEncoding = !String.IsNullOrEmpty(indexRange) || !QualifiedName.IsNull(dataEncoding),
                IndexRange = indexRange,
                DataEncoding = dataEncoding
            };

            return cp;
        }
        /// [Step 4]
    }
}
