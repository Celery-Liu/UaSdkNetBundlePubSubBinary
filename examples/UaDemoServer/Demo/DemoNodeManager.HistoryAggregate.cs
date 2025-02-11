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
    internal partial class DemoNodeManager
    {
        void InitializeHistoryValuesForAggregates()
        {
            NodeId folderId = new NodeId(UnifiedAutomation.Demo.Model.Objects.Demo_CTT_Static_HA_Profile_Aggregates, DefaultNamespaceIndex);
            Node folder = FindInMemoryNode(folderId);

            foreach (ReferenceNode reference in folder.FindReferences(UnifiedAutomation.UaBase.ReferenceTypeIds.HierarchicalReferences, false, true, Server.TypeManager))
            {
                VariableNode variable = FindInMemoryNode((NodeId)reference.TargetId) as VariableNode;

                if (variable == null)
                {
                    continue;
                }

                BuiltInType type = TypeUtils.GetBuiltInType(variable.DataType);

                switch (type)
                {
                    case BuiltInType.Boolean:
                    case BuiltInType.Double:
                        InitializeInMemoryDataSourceForAggregates(variable.NodeId, type);
                        break;
                    case BuiltInType.Float:
                        break;
                    case BuiltInType.Int32:
                        break;
                    case BuiltInType.String:
                        break;
                    default:
                        throw new NotImplementedException("Cannot initialize history for aggregates for variable with NodeId " + variable.NodeId);
                }

            }

        }

        void InitializeInMemoryDataSourceForAggregates(NodeId nodeId, BuiltInType type)
        {
            InMemoryHistoryDataSource history = new InMemoryHistoryDataSource();
            SetNodeUserData(nodeId, history);
            DateTime startOfArchive = new DateTime(2020, 9, 1, 0, 0, 0);
            int noOfFirstGoodData = 50;
            int noOfBadData = 20;
            int noOfSecondGoodData = 50;
            int index = 0;
            DateTime currentTime = startOfArchive;

            switch (type)
            {
                case BuiltInType.Boolean:
                    bool currentValue = false;
                    for (; index < noOfFirstGoodData; index++)
                    {
                        history.Insert(new Variant(currentValue), StatusCodes.Good, currentTime);
                        currentValue = !currentValue;
                        UpdateCurrentTimeForHistoty(ref currentTime);
                    }
                    for (; index < noOfFirstGoodData + noOfBadData; index++)
                    {
                        history.Insert(Variant.Null, StatusCodes.BadNoData, currentTime);
                        UpdateCurrentTimeForHistoty(ref currentTime);
                    }
                    for (; index < noOfFirstGoodData + noOfBadData + noOfSecondGoodData; index++)
                    {
                        history.Insert(new Variant(currentValue), StatusCodes.Good, currentTime);
                        currentValue = !currentValue;
                        UpdateCurrentTimeForHistoty(ref currentTime);
                    }
                    break;
                case BuiltInType.Double:
                    double currentDouble = 0;
                    for (; index < noOfFirstGoodData; index++)
                    {
                        history.Insert(new Variant(currentDouble), StatusCodes.Good, currentTime);
                        currentDouble += 1.0;
                        UpdateCurrentTimeForHistoty(ref currentTime);
                    }
                    for (; index < noOfFirstGoodData + noOfBadData; index++)
                    {
                        history.Insert(Variant.Null, StatusCodes.BadNoData, currentTime);
                        UpdateCurrentTimeForHistoty(ref currentTime);
                    }
                    for (; index < noOfFirstGoodData + noOfBadData + noOfSecondGoodData; index++)
                    {
                        history.Insert(new Variant(currentDouble), StatusCodes.Good, currentTime);
                        currentDouble += 1.0;
                        UpdateCurrentTimeForHistoty(ref currentTime);
                    }
                    break;
                case BuiltInType.Float:
                    break;
                case BuiltInType.Int32:
                    break;
                case BuiltInType.String:
                    break;
            }
        }

        void UpdateCurrentTimeForHistoty(ref DateTime time)
        {
            time = time.AddMinutes(10);
        }

        protected override HistoryDataReadRawContinuationPoint CreateHistoryContinuationPoint(
            RequestContext context,
            ReadRawModifiedDetails details,
            HistoryDataHandle nodeHandle,
            string indexRange,
            QualifiedName dataEncoding)
        {
            InMemoryHistoryDataSource history = nodeHandle.NodeData as InMemoryHistoryDataSource;

            if (history == null)
            {
                return base.CreateHistoryContinuationPoint(context, details, nodeHandle, indexRange, dataEncoding);
            }

            HistoryDataRawReader reader = new HistoryDataRawReader();
            reader.Initialize(context, history, details);

            HistoryDataReadRawContinuationPoint cp = new HistoryDataReadRawContinuationPoint()
            {
                Reader = reader,
                NumValuesPerNode = details.NumValuesPerNode,
                ApplyIndexRangeAndEncoding = !String.IsNullOrEmpty(indexRange) || !QualifiedName.IsNull(dataEncoding),
                IndexRange = indexRange,
                DataEncoding = dataEncoding
            };

            return cp;
        }
    }
}