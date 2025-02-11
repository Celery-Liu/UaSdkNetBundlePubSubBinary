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
    internal partial class Lesson09NodeManager
    {
        enum BlockMethod
        {
            Start = 1,
            Stop = 2,
            StartWithSetpoint = 3
        }

        private void SetMethodUserData(BlockConfiguration block)
        {
            // set addressing information for method nodes that allows them to be called.
            SetChildUserData(
                new NodeId(block.Name, InstanceNamespaceIndex),
                new QualifiedName(yourorganisation.BA.BrowseNames.Start, TypeNamespaceIndex),
                new SystemFunction() { Address = block.Address, Function = BlockMethod.Start });

            SetChildUserData(
                new NodeId(block.Name, InstanceNamespaceIndex),
                new QualifiedName(yourorganisation.BA.BrowseNames.Stop, TypeNamespaceIndex),
                new SystemFunction() { Address = block.Address, Function = BlockMethod.Stop });

            SetChildUserData(
                new NodeId(block.Name, InstanceNamespaceIndex),
                new QualifiedName(yourorganisation.BA.BrowseNames.StartWithSetPoint, TypeNamespaceIndex),
                new SystemFunction() { Address = block.Address, Function = BlockMethod.StartWithSetpoint });
        }

        /// <summary>
        /// Gets the method dispatcher.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="methodHandle">The method handle.</param>
        /// <returns></returns>
        protected override CallMethodEventHandler GetMethodDispatcher(
            RequestContext context,
            MethodHandle methodHandle)
        {
            if (methodHandle.MethodData is SystemFunction)
            {
                return DispatchControllerMethod;
            }

            return null;
        }

        /// <summary>
        /// Dispatches a method to the controller.
        /// </summary>
        private StatusCode DispatchControllerMethod(
            RequestContext context,
            MethodHandle methodHandle,
            IList<Variant> inputArguments,
            List<StatusCode> inputArgumentResults,
            List<Variant> outputArguments)
        {
            SystemFunction data = methodHandle.MethodData as SystemFunction;

            if (data != null)
            {
                switch (data.Function)
                {
                    case BlockMethod.Start:
                    {
                        return m_system.Start(data.Address);
                    }

                    case BlockMethod.Stop:
                    {
                        return m_system.Stop(data.Address);
                    }

                    case BlockMethod.StartWithSetpoint:
                    {
                        return m_system.StartWithSetPoint(data.Address, inputArguments[0].ToDouble(), inputArguments[1].ToDouble());
                    }
                }
            }

            return StatusCodes.BadNotImplemented;
        }

        #region SystemFunction Class
        private class SystemFunction
        {
            public int Address;
            public BlockMethod Function;
        }
        #endregion
    }
}
