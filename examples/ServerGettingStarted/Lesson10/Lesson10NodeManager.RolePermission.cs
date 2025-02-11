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
        private void SetupVarialbeNodePermission()
        {
            // Creating RolePermissions
            /// [Create RolePermissionTypeCollections]
            RolePermissionTypeCollection rolePermissionTypeCollectionTemperature = new RolePermissionTypeCollection()
            {
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Operator,
                    Permissions = PermissionTypeDataType.Read | PermissionTypeDataType.Browse | PermissionTypeDataType.ReadHistory
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Observer,
                    Permissions = PermissionTypeDataType.Read | PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Anonymous,
                    Permissions = PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId= ObjectIds.WellKnownRole_SecurityAdmin,
                    Permissions = PermissionTypeDataType.Read | PermissionTypeDataType.Browse | PermissionTypeDataType.ReadRolePermissions
                }
            };

            RolePermissionTypeCollection rolePermissionTypeCollectionTemperatureSetPoint = new RolePermissionTypeCollection()
            {
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Operator,
                    Permissions = PermissionTypeDataType.ReadWrite | PermissionTypeDataType.Browse 
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Observer,
                    Permissions = PermissionTypeDataType.Read | PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Anonymous,
                    Permissions = PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId= ObjectIds.WellKnownRole_SecurityAdmin,
                    Permissions = PermissionTypeDataType.ReadWrite | PermissionTypeDataType.Browse | PermissionTypeDataType.ReadRolePermissions
                }
            };
            /// [Create RolePermissionTypeCollections]
            
            // Set the RolePermission
            foreach (BlockConfiguration block in m_system.GetBlocks())
            {
                /// [Assign Variables RolePermissions]
                NodeId parentId = new NodeId(block.Name, InstanceNamespaceIndex);

                SetNodePermissions(
                    parentId,
                    new QualifiedName("Temperature", TypeNamespaceIndex),
                    rolePermissionTypeCollectionTemperature);
                SetNodePermissions(
                    parentId,
                    new QualifiedName("TemperatureSetPoint", TypeNamespaceIndex),
                    rolePermissionTypeCollectionTemperatureSetPoint);
                /// [Assign Variables RolePermissions]
            }
        }

        private void SetupMethodNodePermission()
        {
            /// [Create Method RolePermissionCollection]
            RolePermissionTypeCollection methodRolePermission = new RolePermissionTypeCollection()
            {
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Operator,
                    Permissions = PermissionTypeDataType.ReadWrite | PermissionTypeDataType.Browse | PermissionTypeDataType.Call
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
            /// [Create Method RolePermissionCollection]

            // Set the RolePermissions
            /// [Assign Methods RolePermissions]
            foreach (BlockConfiguration block in m_system.GetBlocks())
            {
                NodeId parentId = new NodeId(block.Name, InstanceNamespaceIndex);

                SetNodePermissions(
                    parentId,
                    new QualifiedName("Start", TypeNamespaceIndex),
                    methodRolePermission);
                SetNodePermissions(
                    parentId,
                    new QualifiedName("StartWithSetPoint", TypeNamespaceIndex),
                    methodRolePermission);
                SetNodePermissions(
                    parentId,
                    new QualifiedName("Stop", TypeNamespaceIndex),
                    methodRolePermission);
            }
            /// [Assign Methods RolePermissions]
        }
    }
}