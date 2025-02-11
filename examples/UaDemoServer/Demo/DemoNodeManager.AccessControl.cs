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
        #region Private Methods
        private void SetupAccessControl()
        {
            //Access_All
            SetupAccessControl(Model.VariableIds.Demo_AccessRights_Access_All_All_RO.ToNodeId(Server.NamespaceUris), null);
            SetupAccessControl(Model.VariableIds.Demo_AccessRights_Access_All_All_RW.ToNodeId(Server.NamespaceUris), null);
            SetupAccessControl(Model.VariableIds.Demo_AccessRights_Access_All_All_WO.ToNodeId(Server.NamespaceUris), null);

            //Access_John
            /// [Create RolePermissionTypeCollection]
            var rolePermissions = new RolePermissionTypeCollection()
            {
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Engineer,
                    Permissions = PermissionTypeDataType.Read | PermissionTypeDataType.Write | PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Anonymous,
                    Permissions = PermissionTypeDataType.Read | PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_SecurityAdmin,
                    Permissions = PermissionTypeDataType.ReadRolePermissions
                }
            };
            /// [Create RolePermissionTypeCollection]
            SetupAccessControl(Model.VariableIds.Demo_AccessRights_Access_John_All_RO_John_RW.ToNodeId(Server.NamespaceUris), rolePermissions);

            rolePermissions = new RolePermissionTypeCollection()
            {
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Engineer,
                    Permissions = PermissionTypeDataType.Read | PermissionTypeDataType.Write | PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Anonymous,
                    Permissions = PermissionTypeDataType.Write | PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_SecurityAdmin,
                    Permissions = PermissionTypeDataType.ReadRolePermissions
                }
            };
            SetupAccessControl(Model.VariableIds.Demo_AccessRights_Access_John_All_WO_John_RW.ToNodeId(Server.NamespaceUris), rolePermissions);

            rolePermissions = new RolePermissionTypeCollection()
            {
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Engineer,
                    Permissions = PermissionTypeDataType.Read | PermissionTypeDataType.Write | PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Anonymous,
                    Permissions = PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_SecurityAdmin,
                    Permissions = PermissionTypeDataType.ReadRolePermissions
                }
            };

            SetupAccessControl(Model.VariableIds.Demo_AccessRights_Access_John_John_RO.ToNodeId(Server.NamespaceUris), rolePermissions);
            SetupAccessControl(Model.VariableIds.Demo_AccessRights_Access_John_John_WO.ToNodeId(Server.NamespaceUris), rolePermissions);
            SetupAccessControl(Model.VariableIds.Demo_AccessRights_Access_John_John_RW.ToNodeId(Server.NamespaceUris), rolePermissions);

            //Access_Operators
            rolePermissions = new RolePermissionTypeCollection()
            {
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Operator,
                    Permissions = PermissionTypeDataType.Read | PermissionTypeDataType.Write | PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Anonymous,
                    Permissions = PermissionTypeDataType.Read | PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_SecurityAdmin,
                    Permissions = PermissionTypeDataType.ReadRolePermissions
                }
            };
            SetupAccessControl(Model.VariableIds.Demo_AccessRights_Access_Operators_All_RO_Operators_RW.ToNodeId(Server.NamespaceUris), rolePermissions);

            rolePermissions = new RolePermissionTypeCollection()
            {
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Operator,
                    Permissions = PermissionTypeDataType.Read | PermissionTypeDataType.Write | PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Anonymous,
                    Permissions = PermissionTypeDataType.Write | PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_SecurityAdmin,
                    Permissions = PermissionTypeDataType.ReadRolePermissions
                }
            };
            SetupAccessControl(Model.VariableIds.Demo_AccessRights_Access_Operators_All_WO_Operators_RW.ToNodeId(Server.NamespaceUris), rolePermissions);

            rolePermissions = new RolePermissionTypeCollection()
            {
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Operator,
                    Permissions = PermissionTypeDataType.Read | PermissionTypeDataType.Write | PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Anonymous,
                    Permissions = PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_SecurityAdmin,
                    Permissions = PermissionTypeDataType.ReadRolePermissions
                }
            };

            SetupAccessControl(Model.VariableIds.Demo_AccessRights_Access_Operators_Operators_RO.ToNodeId(Server.NamespaceUris), rolePermissions);
            SetupAccessControl(Model.VariableIds.Demo_AccessRights_Access_Operators_Operators_WO.ToNodeId(Server.NamespaceUris), rolePermissions);
            SetupAccessControl(Model.VariableIds.Demo_AccessRights_Access_Operators_Operators_RW.ToNodeId(Server.NamespaceUris), rolePermissions);

            // Browse
            rolePermissions = new RolePermissionTypeCollection()
            {
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Anonymous,
                    Permissions = PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_SecurityAdmin,
                    Permissions = PermissionTypeDataType.ReadRolePermissions
                }
            };
            SetupAccessControl(Model.ObjectIds.Demo_AccessRights_Browse_All.ToNodeId(Server.NamespaceUris), rolePermissions);

            rolePermissions = new RolePermissionTypeCollection()
            {
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Engineer,
                    Permissions = PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_SecurityAdmin,
                    Permissions = PermissionTypeDataType.ReadRolePermissions
                }
            };
            SetupAccessControl(Model.ObjectIds.Demo_AccessRights_Browse_John.ToNodeId(Server.NamespaceUris), rolePermissions);

            rolePermissions = new RolePermissionTypeCollection()
            {
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Operator,
                    Permissions = PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_SecurityAdmin,
                    Permissions = PermissionTypeDataType.ReadRolePermissions
                }
            };
            SetupAccessControl(Model.ObjectIds.Demo_AccessRights_Browse_Operators.ToNodeId(Server.NamespaceUris), rolePermissions);


            // CTT
            rolePermissions = new RolePermissionTypeCollection()
            {
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Engineer,
                    Permissions = PermissionTypeDataType.Read | PermissionTypeDataType.Write | PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Anonymous,
                    Permissions = PermissionTypeDataType.Read | PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_SecurityAdmin,
                    Permissions = PermissionTypeDataType.ReadRolePermissions
                }
            };
            SetupAccessControl(Model.VariableIds.Demo_CTT_SecurityAccess_AccessLevel_CurrentRead_NotCurrentWrite.ToNodeId(Server.NamespaceUris), rolePermissions);

            rolePermissions = new RolePermissionTypeCollection()
            {
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_ConfigureAdmin,
                    Permissions = PermissionTypeDataType.Write | PermissionTypeDataType.Browse | PermissionTypeDataType.Read
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Anonymous,
                    Permissions = PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_SecurityAdmin,
                    Permissions = PermissionTypeDataType.ReadRolePermissions
                }
            };
            SetupAccessControl(Model.VariableIds.Demo_CTT_SecurityAccess_AccessLevel_CurrentRead_NotUser.ToNodeId(Server.NamespaceUris), rolePermissions);

            rolePermissions = new RolePermissionTypeCollection()
            {
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Engineer,
                    Permissions = PermissionTypeDataType.Read | PermissionTypeDataType.Write | PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Anonymous,
                    Permissions = PermissionTypeDataType.Write | PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_SecurityAdmin,
                    Permissions = PermissionTypeDataType.ReadRolePermissions
                }
            };
            SetupAccessControl(Model.VariableIds.Demo_CTT_SecurityAccess_AccessLevel_CurrentWrite_NotCurrentRead.ToNodeId(Server.NamespaceUris), rolePermissions);

            rolePermissions = new RolePermissionTypeCollection()
            {
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_ConfigureAdmin,
                    Permissions = PermissionTypeDataType.Read | PermissionTypeDataType.Write | PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Anonymous,
                    Permissions = PermissionTypeDataType.Read | PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_SecurityAdmin,
                    Permissions = PermissionTypeDataType.ReadRolePermissions
                }
            };
            SetupAccessControl(Model.VariableIds.Demo_CTT_SecurityAccess_AccessLevel_CurrentWrite_NotUser.ToNodeId(Server.NamespaceUris), rolePermissions);

            rolePermissions = new RolePermissionTypeCollection()
            {
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Anonymous,
                    Permissions = PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_SecurityAdmin,
                    Permissions = PermissionTypeDataType.ReadRolePermissions
                }
            };
            SetupAccessControl(Model.VariableIds.Demo_CTT_Static_HA_Profile_AccessRights_UserAccessLevel_None.ToNodeId(Server.NamespaceUris), rolePermissions);

            rolePermissions = new RolePermissionTypeCollection()
            {
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Anonymous,
                    Permissions = PermissionTypeDataType.Browse | PermissionTypeDataType.Read | PermissionTypeDataType.ReadHistory
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_SecurityAdmin,
                    Permissions = PermissionTypeDataType.ReadRolePermissions
                }
            };
            SetupAccessControl(Model.VariableIds.Demo_CTT_Static_HA_Profile_AccessRights_UserAccessLevel_ReadOnly.ToNodeId(Server.NamespaceUris), rolePermissions);

            rolePermissions = new RolePermissionTypeCollection()
            {
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Anonymous,
                    Permissions = PermissionTypeDataType.Browse | PermissionTypeDataType.Write | PermissionTypeDataType.InsertHistory | PermissionTypeDataType.ModifyHistory
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_SecurityAdmin,
                    Permissions = PermissionTypeDataType.ReadRolePermissions
                }
            };
            SetupAccessControl(Model.VariableIds.Demo_CTT_Static_HA_Profile_AccessRights_UserAccessLevel_WriteOnly.ToNodeId(Server.NamespaceUris), rolePermissions);
        }

        private void SetupAccessControl(NodeId nodeId, RolePermissionTypeCollection rolePermissions)
        {
            Node node = FindInMemoryNode(nodeId);

            if (node == null)
            {
                return;
            }

            if (rolePermissions != null)
            {
                /// [Set RolePermissions]
                node.RolePermissions = rolePermissions;
                /// [Set RolePermissions]
            }

            if (node.NodeClass == NodeClass.Variable)
            {
                var variable = node as VariableNode;
                DataVariableDataSource data = new DataVariableDataSource()
                {
                    TypeInfo = new TypeInfo(variable.DataType, variable.ValueRank, Server.TypeManager),
                    Timestamp = DateTime.UtcNow,
                    Status = StatusCodes.Good,
                    SimulationType = SimulationType.None,
                    AccessLevel = variable.AccessLevel
                };

                data.GenerateRandomValue(m_generator);

                SetVariableConfiguration(variable.NodeId, NodeHandleType.ExternalPush, new DataSourceAddress(data, 0));
            }
        }
        #endregion
    }

}
