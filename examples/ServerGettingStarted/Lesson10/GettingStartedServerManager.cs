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
using UnifiedAutomation.UaServer;
using UnifiedAutomation.UaSchema;

namespace YourCompany.GettingStarted
{
    internal class GettingStartedServerManager : ServerManager
    {
        protected override void OnRootNodeManagerStarted(RootNodeManager nodeManager)
        {
            Console.WriteLine("Creating Node Managers.");

            Lesson10NodeManager lesson10 = new Lesson10NodeManager(this);
            lesson10.Startup();
        }

#if !NETFRAMEWORK || NET && WINDOWS
        /// [Set RoleConfiguration in Memory]
        protected override UnifiedAutomation.UaSchema.RoleConfigurations LoadRoleConfigurations()
        {
            var inMemoryRoleConfig = new UnifiedAutomation.UaSchema.RoleConfigurations()
            {
                NamespaceTable = new string[]
                {
                    "http://opcfoundation.org/UA/"
                },
                Roles = new RoleType[]
                {
                    new RoleType()
                    {
                        Name = "Observer",
                        NodeId ="i=15668",
                        Identities = new IdentityType[]
                        {
                            new IdentityType()
                            {
                                CriteriaType = CriteriaType.AuthenticatedUser
                            }
                        }
                    },
                    new RoleType()
                    {
                        Name = "Operator",
                        NodeId ="i=15680",
                        Identities = new IdentityType[]
                        {
                            new IdentityType()
                            {
                                CriteriaType = CriteriaType.UserName,
                                Value = "john"
                            }
                        }
                    },
                    new RoleType()
                    {
                        Name = "SecurityAdmin",
                        NodeId ="i=15704",
                        Identities = new IdentityType[]
                        {
                            new IdentityType()
                            {
                                CriteriaType = CriteriaType.UserName,
                                Value = "joe"
                            }
                        }
                    }
                }
            };
            return inMemoryRoleConfig;
        }
        /// [Set RoleConfiguration in Memory]
#endif
    }
}
