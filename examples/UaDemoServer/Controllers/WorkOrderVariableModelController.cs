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
** Project: .NET OPC UA SDK information model for namespace http://www.unifiedautomation.com/DemoServer/
**
** Description: OPC Unified Architecture Software Development Kit.
**
** The complete license agreement can be found here:
** http://unifiedautomation.com/License/SLA/2.8/
**
******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaServer;

namespace UnifiedAutomation.Demo.Model
{
    public partial class WorkOrderVariableModel
    {
        #region IModelMapper Members
        // Override GetMethodHandle to assign delegates that get and set values to a single data source
        // for the root node of the instance and its children.
        public override ModelHandle GetModelHandle(StringTable namespaceUris, object instance)
        {
            //! [check arguments 2]
            m_model = instance as WorkOrderVariableModel;
            if (m_model == null)
            {
                return null;
            }
            //! [check arguments 2]

            if (m_model.Value == null)
            {
                m_model.Value = new WorkOrderType();
            }

            //! [get a default ModelHandle]
            ModelHandle handle = ModelMapper.GetModelHandle(namespaceUris, m_model);
            //! [get a default ModelHandle]

            // assign model mapping value handlers to the MapppingData
            if (handle.Mappings.Count > 0)
            {
                //! [assign custom handlers to each field 1]
                ushort nsIdx = (ushort)namespaceUris.IndexOf(Model.Namespaces.Model);
                foreach (ModelMapping mapping in handle.Mappings)
                {
                    if (mapping.BrowsePath.Length == 1)
                    {
                        if (mapping.BrowsePath[0] == new QualifiedName(BrowseNames.AssetID, nsIdx))
                        {
                            mapping.MappingData = new Delegate[] {
                                // the ModelMappingGetValueHandler shall be the first handler in the array
                                new ModelMappingGetValueHandler(GetAssetID),
                                // the ModelMappingSetValueHandler shall be the second handler in the array
                                new ModelMappingSetValueHandler(SetAssetID)
                            };
                        }
                //! [assign custom handlers to each field 1]
                        else if (mapping.BrowsePath[0] == new QualifiedName(BrowseNames.ID, nsIdx))
                        {
                            mapping.MappingData = new Delegate[] {
                                new ModelMappingGetValueHandler(GetID),
                                new ModelMappingSetValueHandler(SetID)
                            };
                        }
                        else if (mapping.BrowsePath[0] == new QualifiedName(BrowseNames.StartTime, nsIdx))
                        {
                            mapping.MappingData = new Delegate[] {
                                new ModelMappingGetValueHandler(GetStartTime),
                                new ModelMappingSetValueHandler(SetStartTime)
                            };
                        }
                        else if (mapping.BrowsePath[0] == new QualifiedName(BrowseNames.StatusComments, nsIdx))
                        {
                            mapping.MappingData = new Delegate[] {
                                new ModelMappingGetValueHandler(GetStatusComments),
                                new ModelMappingSetValueHandler(SetStatusComments)
                            };
                        }
                    }
                }
            }

            return handle;
        }
        #endregion

        #region Custom Model Handlers
        //! [assign custom handlers to each field 2]
        private DataValue GetAssetID(IMapperContext context)
        {
            return new DataValue()
            {
                WrappedValue = new Variant(m_model.Value.AssetID, TypeInfo.Scalars.String),
                SourceTimestamp = DateTime.UtcNow,
                ServerTimestamp = DateTime.UtcNow
            };
        }
        //! [assign custom handlers to each field 2]

        private DataValue GetID(IMapperContext context)
        {
            return new DataValue()
            {
                WrappedValue = new Variant(m_model.Value.ID),
                SourceTimestamp = DateTime.UtcNow,
                ServerTimestamp = DateTime.UtcNow
            };
        }

        private DataValue GetStartTime(IMapperContext context)
        {
            return new DataValue()
            {
                WrappedValue = new Variant(m_model.Value.StartTime),
                SourceTimestamp = DateTime.UtcNow,
                ServerTimestamp = DateTime.UtcNow
            };
        }

        private DataValue GetStatusComments(IMapperContext context)
        {
            return new DataValue()
            {
                WrappedValue = new Variant(m_model.Value.StatusComments.ToList(), TypeInfo.Arrays.ExtensionObject),
                SourceTimestamp = DateTime.UtcNow,
                ServerTimestamp = DateTime.UtcNow
            };
        }


        //! [assign custom handlers to each field 3]
        private void SetAssetID(IMapperContext context, DataValue AssetId)
        {
            m_model.Value.AssetID = AssetId.WrappedValue.ToString();
        }
        //! [assign custom handlers to each field 3]

        private void SetID(IMapperContext context, DataValue ID)
        {
            m_model.Value.ID = ID.WrappedValue.ToGuid();
        }

        private void SetStartTime(IMapperContext context, DataValue StartTime)
        {
            m_model.Value.StartTime = StartTime.WrappedValue.ToDateTime();
        }

        private void SetStatusComments(IMapperContext context, DataValue StatusComments)
        {
            ExtensionObject[] extensionObjects = StatusComments.WrappedValue.ToExtensionObjectArray();
            WorkOrderStatusTypeCollection values = new WorkOrderStatusTypeCollection(extensionObjects.Length);
            foreach (ExtensionObject e in extensionObjects)
            {
                WorkOrderStatusType value = ExtensionObject.GetObject<WorkOrderStatusType>(e);
                values.Add(value);
            }
            m_model.Value.StatusComments = values;
        }
        #endregion

        //! [check arguments 1]
        private WorkOrderVariableModel m_model;
        //! [check arguments 1]
    }
}
