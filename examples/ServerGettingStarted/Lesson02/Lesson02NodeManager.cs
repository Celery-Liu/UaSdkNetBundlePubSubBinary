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
    /// [Properties for Namespace Indexes]
    internal class Lesson02NodeManager : BaseNodeManager
    {
        public ushort InstanceNamespaceIndex { get; set; }
        public ushort TypeNamespaceIndex { get; set; }
    /// [Properties for Namespace Indexes]

        /// <summary>
        /// Called when the node manager is started.
        /// </summary>
        /// [Assign Instance and Type Namespaces]
        public override void Startup()
        {
            try
            {
                base.Startup();

                Console.WriteLine("Starting Lesson02NodeManager.");

                // Assign namespaces for type and instance nodes to this NodeManager
                // Get namespace index for the namespaces
                TypeNamespaceIndex = AddNamespaceUri(yourorganisation.BA.Namespaces.BA);
                InstanceNamespaceIndex = AddNamespaceUri("http://yourorganisation.com/lesson02/");
                /// [Assign Instance and Type Namespaces]

                /// [Load the Model 3]
                Console.WriteLine("Loading the Controller Model.");
                ImportUaNodeset(Assembly.GetEntryAssembly(), "buildingautomation.xml");
                /// [Load the Model 3]
                /// [Load the Model Code]
                // CreateObjectTypesInCode();
                /// [Load the Model Code]

                /// [Create Instances]
                // Create a Folder for Controllers
                CreateObjectSettings settings = new CreateObjectSettings()
                {
                    ParentNodeId = ObjectIds.ObjectsFolder,
                    ReferenceTypeId = ReferenceTypeIds.Organizes,
                    RequestedNodeId = new NodeId("Controllers", InstanceNamespaceIndex),
                    BrowseName = new QualifiedName("Controllers", InstanceNamespaceIndex),
                    TypeDefinitionId = ObjectTypeIds.FolderType
                };
                ObjectNode controllersNode = CreateObject(Server.DefaultRequestContext, settings);

                // Create an Air Conditioner Controller
                settings = new CreateObjectSettings()
                {
                    ParentNodeId = controllersNode.NodeId,
                    ReferenceTypeId = ReferenceTypeIds.Organizes,
                    RequestedNodeId = new NodeId("AirConditioner1", InstanceNamespaceIndex),
                    BrowseName = new QualifiedName("AirConditioner1", InstanceNamespaceIndex),
                    TypeDefinitionId = new NodeId(yourorganisation.BA.ObjectTypes.AirConditionerControllerType, TypeNamespaceIndex)
                };
                CreateObject(Server.DefaultRequestContext, settings);

                // Create a Furnace Controller
                settings = new CreateObjectSettings()
                {
                    ParentNodeId = controllersNode.NodeId,
                    ReferenceTypeId = ReferenceTypeIds.Organizes,
                    RequestedNodeId = new NodeId("Furnace1", InstanceNamespaceIndex),
                    BrowseName = new QualifiedName("Furnace1", InstanceNamespaceIndex),
                    TypeDefinitionId = new NodeId(yourorganisation.BA.ObjectTypes.FurnaceControllerType, TypeNamespaceIndex)
                };
                CreateObject(Server.DefaultRequestContext, settings);
                /// [Create Instances]
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to start Lesson02NodeManager. " + e.Message);
            }
        }

        /// <summary>
        /// Called when the node manager is stopped.
        /// </summary>
        public override void Shutdown()
        {
            try
            {
                Console.WriteLine("Stopping Lesson02NodeManager.");

                // TBD 

                base.Shutdown();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to stop Lesson02NodeManager. " + e.Message);
            }
        }

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Lesson02NodeManager(ServerManager server) : base(server)
        {
        }
        #endregion

        #region IDisposable
        /// <summary>
        /// An overrideable version of the Dispose.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // TBD
            }
        }
        #endregion

        #region Private Methods
        /// [Create Object Types in Code]
        private void CreateObjectTypesInCode()
        {
            CreateVariableSettings variableSettings;
            CreateObjectTypeSettings objectTypeSettings;
            CreateMethodSettings methodSettings;

            /* ***************************************** */
            /* ControllerType                            */
            /* ***************************************** */

            objectTypeSettings = new CreateObjectTypeSettings()
            {
                BrowseName = new QualifiedName("ControllerType", TypeNamespaceIndex),
                DisplayName = new LocalizedText("ControllerType"),
                SuperTypeId = UnifiedAutomation.UaBase.ObjectTypeIds.BaseObjectType,
                RequestedNodeId = new NodeId(yourorganisation.BA.ObjectTypes.ControllerType, TypeNamespaceIndex)
            };
            ObjectTypeNode controllerType = CreateObjectTypeNode(Server.DefaultRequestContext, objectTypeSettings);

            variableSettings = new CreateVariableSettings()
            {
                BrowseName = new QualifiedName("PowerConsumption", TypeNamespaceIndex),
                DisplayName = new LocalizedText("PowerConsomtion"),
                ParentNodeId = controllerType.NodeId,
                ParentAsOwner = true,
                ReferenceTypeId = UnifiedAutomation.UaBase.ReferenceTypeIds.HasComponent,
                TypeDefinitionId = UnifiedAutomation.UaBase.VariableTypeIds.DataItemType,
                DataType = UnifiedAutomation.UaBase.DataTypeIds.Double,
                ModellingRuleId = UnifiedAutomation.UaBase.ObjectIds.ModellingRule_Mandatory,
                RequestedNodeId = new NodeId(yourorganisation.BA.Variables.ControllerType_PowerConsumption, TypeNamespaceIndex)
            };
            CreateVariable(Server.DefaultRequestContext, variableSettings);

            methodSettings = new CreateMethodSettings()
            {
                BrowseName = new QualifiedName("Start", TypeNamespaceIndex),
                DisplayName = new LocalizedText("Start"),
                ParentNodeId = controllerType.NodeId,
                ParentAsOwner = true,
                ReferenceTypeId = UnifiedAutomation.UaBase.ReferenceTypeIds.HasComponent,
                ModellingRuleId = UnifiedAutomation.UaBase.ObjectIds.ModellingRule_Mandatory,
                RequestedNodeId = new NodeId(yourorganisation.BA.Methods.ControllerType_Start, TypeNamespaceIndex)
            };
            CreateMethod(Server.DefaultRequestContext, methodSettings);
            /// [Create Object Types in Code]

            variableSettings = new CreateVariableSettings()
            {
                BrowseName = new QualifiedName("State", TypeNamespaceIndex),
                DisplayName = new LocalizedText("State"),
                ParentNodeId = controllerType.NodeId,
                ParentAsOwner = true,
                ReferenceTypeId = UnifiedAutomation.UaBase.ReferenceTypeIds.HasComponent,
                TypeDefinitionId = UnifiedAutomation.UaBase.VariableTypeIds.BaseDataVariableType,
                DataType = UnifiedAutomation.UaBase.DataTypeIds.UInt32,
                ModellingRuleId = UnifiedAutomation.UaBase.ObjectIds.ModellingRule_Mandatory,
                RequestedNodeId = new NodeId(yourorganisation.BA.Variables.ControllerType_State, TypeNamespaceIndex)
            };
            CreateVariable(Server.DefaultRequestContext, variableSettings);

            methodSettings = new CreateMethodSettings()
            {
                BrowseName = new QualifiedName("Stop", TypeNamespaceIndex),
                DisplayName = new LocalizedText("Stop"),
                ParentNodeId = controllerType.NodeId,
                ParentAsOwner = true,
                ReferenceTypeId = UnifiedAutomation.UaBase.ReferenceTypeIds.HasComponent,
                ModellingRuleId = UnifiedAutomation.UaBase.ObjectIds.ModellingRule_Mandatory,
                RequestedNodeId = new NodeId(yourorganisation.BA.Methods.ControllerType_Stop, TypeNamespaceIndex)
            };
            CreateMethod(Server.DefaultRequestContext, methodSettings);

            variableSettings = new CreateVariableSettings()
            {
                BrowseName = new QualifiedName("Temperature", TypeNamespaceIndex),
                DisplayName = new LocalizedText("Temperature"),
                ParentNodeId = controllerType.NodeId,
                ParentAsOwner = true,
                ReferenceTypeId = UnifiedAutomation.UaBase.ReferenceTypeIds.HasComponent,
                TypeDefinitionId = UnifiedAutomation.UaBase.VariableTypeIds.AnalogItemType,
                DataType = UnifiedAutomation.UaBase.DataTypeIds.Double,
                ModellingRuleId = UnifiedAutomation.UaBase.ObjectIds.ModellingRule_Mandatory,
                RequestedNodeId = new NodeId(yourorganisation.BA.Variables.ControllerType_Temperature, TypeNamespaceIndex)
            };
            CreateVariable(Server.DefaultRequestContext, variableSettings);

            variableSettings = new CreateVariableSettings()
            {
                BrowseName = new QualifiedName("TemperatureSetpoint", TypeNamespaceIndex),
                DisplayName = new LocalizedText("TemperatureSetpoint"),
                ParentNodeId = controllerType.NodeId,
                ParentAsOwner = true,
                ReferenceTypeId = UnifiedAutomation.UaBase.ReferenceTypeIds.HasComponent,
                TypeDefinitionId = UnifiedAutomation.UaBase.VariableTypeIds.AnalogItemType,
                DataType = UnifiedAutomation.UaBase.DataTypeIds.Double,
                ModellingRuleId = UnifiedAutomation.UaBase.ObjectIds.ModellingRule_Mandatory,
                RequestedNodeId = new NodeId(yourorganisation.BA.Variables.ControllerType_TemperatureSetPoint, TypeNamespaceIndex)
            };
            CreateVariable(Server.DefaultRequestContext, variableSettings);

            /* ***************************************** */
            /* AirConditionerControllerType              */
            /* ***************************************** */

            objectTypeSettings = new CreateObjectTypeSettings()
            {
                BrowseName = new QualifiedName("AirConditionerControllerType", TypeNamespaceIndex),
                DisplayName = new LocalizedText("AirConditionerControllerType"),
                SuperTypeId = controllerType.NodeId,
                RequestedNodeId = new NodeId(yourorganisation.BA.ObjectTypes.AirConditionerControllerType, TypeNamespaceIndex)
            };
            ObjectTypeNode airConditionerControllerType = CreateObjectTypeNode(Server.DefaultRequestContext, objectTypeSettings);

            variableSettings = new CreateVariableSettings()
            {
                BrowseName = new QualifiedName("Humidity", TypeNamespaceIndex),
                DisplayName = new LocalizedText("Humidity"),
                ParentNodeId = airConditionerControllerType.NodeId,
                ParentAsOwner = true,
                ReferenceTypeId = UnifiedAutomation.UaBase.ReferenceTypeIds.HasComponent,
                TypeDefinitionId = UnifiedAutomation.UaBase.VariableTypeIds.AnalogItemType,
                DataType = UnifiedAutomation.UaBase.DataTypeIds.Double,
                ModellingRuleId = UnifiedAutomation.UaBase.ObjectIds.ModellingRule_Mandatory,
                RequestedNodeId = new NodeId(yourorganisation.BA.Variables.AirConditionerControllerType_Humidity, TypeNamespaceIndex)
            };
            CreateVariable(Server.DefaultRequestContext, variableSettings);

            variableSettings = new CreateVariableSettings()
            {
                BrowseName = new QualifiedName("HumiditySetpoint", TypeNamespaceIndex),
                DisplayName = new LocalizedText("HumiditySetpoint"),
                ParentNodeId = airConditionerControllerType.NodeId,
                ParentAsOwner = true,
                ReferenceTypeId = UnifiedAutomation.UaBase.ReferenceTypeIds.HasComponent,
                TypeDefinitionId = UnifiedAutomation.UaBase.VariableTypeIds.AnalogItemType,
                DataType = UnifiedAutomation.UaBase.DataTypeIds.Double,
                ModellingRuleId = UnifiedAutomation.UaBase.ObjectIds.ModellingRule_Mandatory,
                RequestedNodeId = new NodeId(yourorganisation.BA.Variables.AirConditionerControllerType_HumiditySetPoint, TypeNamespaceIndex)
            };
            CreateVariable(Server.DefaultRequestContext, variableSettings);

            methodSettings = new CreateMethodSettings()
            {
                BrowseName = new QualifiedName("StartWithSetpoint", TypeNamespaceIndex),
                DisplayName = new LocalizedText("StartWithSetpoint"),
                ParentNodeId = airConditionerControllerType.NodeId,
                ParentAsOwner = true,
                ReferenceTypeId = UnifiedAutomation.UaBase.ReferenceTypeIds.HasComponent,
                ModellingRuleId = UnifiedAutomation.UaBase.ObjectIds.ModellingRule_Mandatory,
                RequestedNodeId = new NodeId(yourorganisation.BA.Methods.AirConditionerControllerType_StartWithSetPoint, TypeNamespaceIndex)
            };
            MethodNode startWithSetpointNode = CreateMethod(Server.DefaultRequestContext, methodSettings);

            IList<Argument> arguments = new List<Argument>();
            arguments.Add(new Argument()
            {
                Name = "Temperature",
                Description = "Temperature Set Point",
                DataType = UnifiedAutomation.UaBase.DataTypeIds.Double,
                ValueRank = ValueRanks.Scalar
            });
            arguments.Add(new Argument()
            {
                Name = "Humidity",
                Description = "Humidity Set Point",
                DataType = UnifiedAutomation.UaBase.DataTypeIds.Double,
                ValueRank = ValueRanks.Scalar
            });

            variableSettings = new CreateVariableSettings()
            {
                BrowseName = new QualifiedName("InputArguments", 0),
                DisplayName = new LocalizedText("InputArguments"),
                ParentNodeId = startWithSetpointNode.NodeId,
                ParentAsOwner = true,
                ReferenceTypeId = UnifiedAutomation.UaBase.ReferenceTypeIds.HasProperty,
                TypeDefinitionId = UnifiedAutomation.UaBase.VariableTypeIds.PropertyType,
                DataType = UnifiedAutomation.UaBase.DataTypeIds.Argument,
                ModellingRuleId = UnifiedAutomation.UaBase.ObjectIds.ModellingRule_Mandatory,
                RequestedNodeId = new NodeId(yourorganisation.BA.Variables.AirConditionerControllerType_StartWithSetPoint_InputArguments, TypeNamespaceIndex),
                Value = new Variant(arguments.ToArray())
            };
            CreateVariable(Server.DefaultRequestContext, variableSettings);

            /* ***************************************** */
            /* FurnanceControllerType                    */
            /* ***************************************** */

            objectTypeSettings = new CreateObjectTypeSettings()
            {
                BrowseName = new QualifiedName("FurnanceControllerType", TypeNamespaceIndex),
                DisplayName = new LocalizedText("FurnanceControllerType"),
                SuperTypeId = controllerType.NodeId,
                RequestedNodeId = new NodeId(yourorganisation.BA.ObjectTypes.FurnaceControllerType, TypeNamespaceIndex)
            };
            ObjectTypeNode furnanceControllerType = CreateObjectTypeNode(Server.DefaultRequestContext, objectTypeSettings);

            variableSettings = new CreateVariableSettings()
            {
                BrowseName = new QualifiedName("GasFlow", TypeNamespaceIndex),
                DisplayName = new LocalizedText("GasFlow"),
                ParentNodeId = furnanceControllerType.NodeId,
                ParentAsOwner = true,
                ReferenceTypeId = UnifiedAutomation.UaBase.ReferenceTypeIds.HasComponent,
                TypeDefinitionId = UnifiedAutomation.UaBase.VariableTypeIds.AnalogItemType,
                DataType = UnifiedAutomation.UaBase.DataTypeIds.Double,
                ModellingRuleId = UnifiedAutomation.UaBase.ObjectIds.ModellingRule_Mandatory,
                RequestedNodeId = new NodeId(yourorganisation.BA.Variables.FurnaceControllerType_GasFlow, TypeNamespaceIndex)
            };
            CreateVariable(Server.DefaultRequestContext, variableSettings);

            /* ***************************************** */
            /* ControllerEventType                       */
            /* ***************************************** */

            objectTypeSettings = new CreateObjectTypeSettings()
            {
                BrowseName = new QualifiedName("ControllerEventType", TypeNamespaceIndex),
                DisplayName = new LocalizedText("ControllerEventType"),
                SuperTypeId = UnifiedAutomation.UaBase.ObjectTypeIds.BaseEventType,
                RequestedNodeId = new NodeId(yourorganisation.BA.ObjectTypes.ControllerEventType, TypeNamespaceIndex)
            };
            ObjectTypeNode controllerEventType = CreateObjectTypeNode(Server.DefaultRequestContext, objectTypeSettings);

            variableSettings = new CreateVariableSettings()
            {
                BrowseName = new QualifiedName("Temperature", TypeNamespaceIndex),
                DisplayName = new LocalizedText("Temperature"),
                ParentNodeId = controllerEventType.NodeId,
                ParentAsOwner = true,
                ReferenceTypeId = UnifiedAutomation.UaBase.ReferenceTypeIds.HasProperty,
                TypeDefinitionId = UnifiedAutomation.UaBase.VariableTypeIds.PropertyType,
                DataType = UnifiedAutomation.UaBase.DataTypeIds.Double,
                ModellingRuleId = UnifiedAutomation.UaBase.ObjectIds.ModellingRule_Mandatory,
                RequestedNodeId = new NodeId(yourorganisation.BA.Variables.ControllerEventType_Temperature, TypeNamespaceIndex)
            };
            CreateVariable(Server.DefaultRequestContext, variableSettings);

            variableSettings = new CreateVariableSettings()
            {
                BrowseName = new QualifiedName("State", TypeNamespaceIndex),
                DisplayName = new LocalizedText("State"),
                ParentNodeId = controllerEventType.NodeId,
                ParentAsOwner = true,
                ReferenceTypeId = UnifiedAutomation.UaBase.ReferenceTypeIds.HasProperty,
                TypeDefinitionId = UnifiedAutomation.UaBase.VariableTypeIds.PropertyType,
                DataType = UnifiedAutomation.UaBase.DataTypeIds.UInt32,
                ModellingRuleId = UnifiedAutomation.UaBase.ObjectIds.ModellingRule_Mandatory,
                RequestedNodeId = new NodeId(yourorganisation.BA.Variables.ControllerEventType_State, TypeNamespaceIndex)
            };
            CreateVariable(Server.DefaultRequestContext, variableSettings);
        }
        #endregion

        #region Private Fields
        #endregion
    }
}
