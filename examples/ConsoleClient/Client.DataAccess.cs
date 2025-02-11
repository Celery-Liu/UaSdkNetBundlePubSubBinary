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

using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;

namespace ConsoleClient
{
    partial class Client
    {
        #region Read
        ClientState Read()
        {
            try
            {
                IList<ReadValueId> nodesToRead = NodesToReadFromConfiguration();
                //! [Call Read]
                var results = Session.Read(nodesToRead);
                //! [Call Read]
                Output("\nRead succeeded");
                PrintReadResults(results, nodesToRead);
            }
            catch (Exception e)
            {
                Output($"\nRead failed with message {e.Message}");
            }
            return ClientState.Connected;
        }

        ClientState ReadAsync()
        {
            IList<ReadValueId> nodesToRead = NodesToReadFromConfiguration();
            try
            {
                //! [Call BeginRead]
                Session.BeginRead(nodesToRead, 0, OnReadComplete, nodesToRead);
                //! [Call BeginRead]
                Output("\nBeginRead succeeded");
            }
            catch (Exception e)
            {
                Output($"\nBeginRead failed with message {e.Message}");
            }
            return ClientState.Connected;
        }

        //! [Read callback]
        void OnReadComplete(IAsyncResult result)
        {
            try
            {
                List<DataValue> results = Session.EndRead(result);
                //! [Read callback]
                Output("\nEndRead succeeded");
                PrintReadResults(results, result.AsyncState as IList<ReadValueId>);
            }
            catch (Exception e)
            {
                Output($"\nEndRead failed with message {e.Message}");
            }
        }
        #endregion

        #region Write
        ClientState Write()
        {
            try
            {
                //! [Write call]
                IList<WriteValue> nodesToWrite = Settings.WriteVariables;

                List<StatusCode> res = Session.Write(nodesToWrite);
                //! [Write call]

                lock (ConsoleLock)
                {
                    Console.WriteLine("\nWrite succeeded");
                    foreach (StatusCode status in res)
                    {
                        Console.WriteLine($"\nWrite result {status}");
                    }
                }
            }
            catch (Exception e)
            {
                Output($"\nWrite failed with message {e.Message}");
            }
            return ClientState.Connected;
        }


        ClientState WriteAsync()
        {
            try
            {
                IList<WriteValue> nodesToWrite = Settings.WriteVariables;
                Session.BeginWrite(nodesToWrite, OnWriteComplete, null);
                Output("\nBeginWrite succeeded");
            }
            catch (Exception e)
            {
                Output($"\nBeginWrite failed with message {e.Message}");
            }
            return ClientState.Connected;
        }

        void OnWriteComplete(IAsyncResult result)
        {
            try
            {
                List<StatusCode> results = Session.EndWrite(result);
                Output("\nEndWrite succeeded");
            }
            catch (Exception e)
            {
                Output($"\nEnWrite failed with message {e.Message}");
            }
        }
        #endregion

        #region IndexRange
        ClientState ReadIndexRange()
        {
            IList<ReadValueId> nodesToRead = NodesToReadWithIndexRangeFromConfiguration();
            try
            {
                var results = Session.Read(nodesToRead);
                Output("\nRead succeeded");
                PrintReadResults(results, nodesToRead);
            }
            catch (Exception e)
            {
                Output($"\nRead failed with message {e.Message}");
            }
            return ClientState.Connected;
        }

        ClientState WriteIndexRange()
        {
            IList<WriteValue> nodeIdsToWrite = new List<WriteValue>();
            List<bool> value = new List<bool>
            {
                false
            };

            try
            {
                //! [write index]
                nodeIdsToWrite.Add(new WriteValue()
                {
                    NodeId = new NodeId("Demo.Static.Arrays.Boolean", 2),
                    Value = new DataValue() { WrappedValue = new Variant(value) },
                    AttributeId = Attributes.Value,
                    IndexRange = "0:1"
                });
                //! [write index]

                var results = Session.Write(nodeIdsToWrite);
                Output("\nWrite succeeded");
            }
            catch (Exception e)
            {
                Output($"\nWrite failed with message {e.Message}");
            }
            return ClientState.Connected;
        }
        #endregion

        #region Updating data from configuration
        IList<ReadValueId> NodesToReadFromConfiguration()
        {
            IList<NodeId> configuredVariables;
            if (RegisteredNodes != null)
            {
                // use registered nodes for read
                configuredVariables = RegisteredNodes;
            }
            else
            {
                configuredVariables = Settings.ReadVariableIds;
            }
            //! [NodesToRead from configuration]
            List<ReadValueId> readValueIds = new List<ReadValueId>();
            foreach (NodeId nodeId in configuredVariables)
            {
                readValueIds.Add(new ReadValueId()
                {
                    AttributeId = Attributes.Value,
                    NodeId = nodeId
                });
            }
            return readValueIds;
            //! [NodesToRead from configuration]
        }
        IList<ReadValueId> NodesToReadWithIndexRangeFromConfiguration()
        {
            List<ReadValueId> nodesToRead = new List<ReadValueId>();
            //! [read index]
            foreach (NodeId nodeId in Settings.ReadWithIndexRangeVariableIds)
            {
                nodesToRead.Add(new ReadValueId()
                {
                    AttributeId = Attributes.Value,
                    NodeId = nodeId,
                    IndexRange = "1:3"
                });
            }
            //! [read index]

            return nodesToRead;
        }
        #endregion
    }
}