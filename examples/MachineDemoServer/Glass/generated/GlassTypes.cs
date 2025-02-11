/******************************************************************************
**
** <auto-generated>
**     This code was generated by a tool: UaModeler
**     Runtime Version: 1.7.0, using .NET Server 4.1.0 template (version 0)
**
**     Changes to this file may cause incorrect behavior and will be lost if
**     the code is regenerated.
** </auto-generated>
**
** Copyright (c) 2006-2024 Unified Automation GmbH All rights reserved.
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
** Project: .NET OPC UA SDK information model for namespace http://opcfoundation.org/UA/Glass/Flat/
**
** Description: OPC Unified Architecture Software Development Kit.
**
** The complete license agreement can be found here:
** http://unifiedautomation.com/License/SLA/2.8/
**
******************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Xml;
using System.Linq;
using System.Runtime.Serialization;
using UnifiedAutomation.UaBase;
using System.Diagnostics;

namespace OpcUa.Glass
{
    #region CoatingClassEnumeration
    /// <summary>
    /// https://reference.opcfoundation.org/v104/Glass/Flat/v100/docs/9.6
    /// </summary>
    [DataContract(Namespace = OpcUa.Glass.Namespaces.GlassXsd)]
    public enum CoatingClassEnumeration
    {
        [EnumMember(Value = "HardCoating_0")]
        HardCoating = 0,
        [EnumMember(Value = "SoftCoating_1")]
        SoftCoating = 1,
        [EnumMember(Value = "CoatedWithFoilProtection_2")]
        CoatedWithFoilProtection = 2,
        [EnumMember(Value = "UserDefined_3")]
        UserDefined = 3,
    }

    #region CoatingClassEnumerationCollection Class
    /// <summary>
    /// A collection of CoatingClassEnumeration objects.
    /// </summary>
    [CollectionDataContract]
    public partial class CoatingClassEnumerationCollection : List<CoatingClassEnumeration>, ICloneable
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public CoatingClassEnumerationCollection() { }

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public CoatingClassEnumerationCollection(int capacity) : base(capacity) { }

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public CoatingClassEnumerationCollection(IEnumerable<CoatingClassEnumeration> collection) : base(collection) { }
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator CoatingClassEnumerationCollection(CoatingClassEnumeration[] values)
        {
            if (values != null)
            {
                return new CoatingClassEnumerationCollection(values);
            }

            return new CoatingClassEnumerationCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator CoatingClassEnumeration[](CoatingClassEnumerationCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            CoatingClassEnumerationCollection clone = new CoatingClassEnumerationCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((CoatingClassEnumeration)TypeUtils.Clone(this[ii]));
            }

            return clone;
        }
        #endregion
    }
    #endregion

    #endregion

    #region CoordinateSystemEnumeration
    /// <summary>
    /// https://reference.opcfoundation.org/v104/Glass/Flat/v100/docs/9.8
    /// </summary>
    [DataContract(Namespace = OpcUa.Glass.Namespaces.GlassXsd)]
    public enum CoordinateSystemEnumeration
    {
        [EnumMember(Value = "Unknown_0")]
        Unknown = 0,
        [EnumMember(Value = "System1_1")]
        System1 = 1,
        [EnumMember(Value = "System2_2")]
        System2 = 2,
        [EnumMember(Value = "System3_3")]
        System3 = 3,
        [EnumMember(Value = "System4_4")]
        System4 = 4,
        [EnumMember(Value = "System5_5")]
        System5 = 5,
        [EnumMember(Value = "System6_6")]
        System6 = 6,
        [EnumMember(Value = "System7_7")]
        System7 = 7,
        [EnumMember(Value = "System8_8")]
        System8 = 8,
    }

    #region CoordinateSystemEnumerationCollection Class
    /// <summary>
    /// A collection of CoordinateSystemEnumeration objects.
    /// </summary>
    [CollectionDataContract]
    public partial class CoordinateSystemEnumerationCollection : List<CoordinateSystemEnumeration>, ICloneable
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public CoordinateSystemEnumerationCollection() { }

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public CoordinateSystemEnumerationCollection(int capacity) : base(capacity) { }

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public CoordinateSystemEnumerationCollection(IEnumerable<CoordinateSystemEnumeration> collection) : base(collection) { }
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator CoordinateSystemEnumerationCollection(CoordinateSystemEnumeration[] values)
        {
            if (values != null)
            {
                return new CoordinateSystemEnumerationCollection(values);
            }

            return new CoordinateSystemEnumerationCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator CoordinateSystemEnumeration[](CoordinateSystemEnumerationCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            CoordinateSystemEnumerationCollection clone = new CoordinateSystemEnumerationCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((CoordinateSystemEnumeration)TypeUtils.Clone(this[ii]));
            }

            return clone;
        }
        #endregion
    }
    #endregion

    #endregion

    #region SignificantSideEnumeration
    /// <summary>
    /// https://reference.opcfoundation.org/v104/Glass/Flat/v100/docs/9.4
    /// </summary>
    [DataContract(Namespace = OpcUa.Glass.Namespaces.GlassXsd)]
    public enum SignificantSideEnumeration
    {
        [EnumMember(Value = "Indifferent_0")]
        Indifferent = 0,
        [EnumMember(Value = "Top_1")]
        Top = 1,
        [EnumMember(Value = "Down_2")]
        Down = 2,
    }

    #region SignificantSideEnumerationCollection Class
    /// <summary>
    /// A collection of SignificantSideEnumeration objects.
    /// </summary>
    [CollectionDataContract]
    public partial class SignificantSideEnumerationCollection : List<SignificantSideEnumeration>, ICloneable
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public SignificantSideEnumerationCollection() { }

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public SignificantSideEnumerationCollection(int capacity) : base(capacity) { }

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public SignificantSideEnumerationCollection(IEnumerable<SignificantSideEnumeration> collection) : base(collection) { }
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator SignificantSideEnumerationCollection(SignificantSideEnumeration[] values)
        {
            if (values != null)
            {
                return new SignificantSideEnumerationCollection(values);
            }

            return new SignificantSideEnumerationCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator SignificantSideEnumeration[](SignificantSideEnumerationCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            SignificantSideEnumerationCollection clone = new SignificantSideEnumerationCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((SignificantSideEnumeration)TypeUtils.Clone(this[ii]));
            }

            return clone;
        }
        #endregion
    }
    #endregion

    #endregion

    #region SpacerMaterialClass
    /// <summary>
    /// https://reference.opcfoundation.org/v104/Glass/Flat/v100/docs/9.3
    /// </summary>
    [DataContract(Namespace = OpcUa.Glass.Namespaces.GlassXsd)]
    public enum SpacerMaterialClass
    {
        [EnumMember(Value = "Other_0")]
        Other = 0,
        [EnumMember(Value = "Metalic_1")]
        Metalic = 1,
        [EnumMember(Value = "TPS_2")]
        TPS = 2,
        [EnumMember(Value = "Plastic_3")]
        Plastic = 3,
        [EnumMember(Value = "Elastic_4")]
        Elastic = 4,
    }

    #region SpacerMaterialClassCollection Class
    /// <summary>
    /// A collection of SpacerMaterialClass objects.
    /// </summary>
    [CollectionDataContract]
    public partial class SpacerMaterialClassCollection : List<SpacerMaterialClass>, ICloneable
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public SpacerMaterialClassCollection() { }

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public SpacerMaterialClassCollection(int capacity) : base(capacity) { }

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public SpacerMaterialClassCollection(IEnumerable<SpacerMaterialClass> collection) : base(collection) { }
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator SpacerMaterialClassCollection(SpacerMaterialClass[] values)
        {
            if (values != null)
            {
                return new SpacerMaterialClassCollection(values);
            }

            return new SpacerMaterialClassCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator SpacerMaterialClass[](SpacerMaterialClassCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            SpacerMaterialClassCollection clone = new SpacerMaterialClassCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((SpacerMaterialClass)TypeUtils.Clone(this[ii]));
            }

            return clone;
        }
        #endregion
    }
    #endregion

    #endregion

    #region StructureAlignmentEnumeration
    /// <summary>
    /// https://reference.opcfoundation.org/v104/Glass/Flat/v100/docs/9.5
    /// </summary>
    [DataContract(Namespace = OpcUa.Glass.Namespaces.GlassXsd)]
    public enum StructureAlignmentEnumeration
    {
        [EnumMember(Value = "Indifferent_0")]
        Indifferent = 0,
        [EnumMember(Value = "Longitudinal_1")]
        Longitudinal = 1,
        [EnumMember(Value = "Transverse_2")]
        Transverse = 2,
    }

    #region StructureAlignmentEnumerationCollection Class
    /// <summary>
    /// A collection of StructureAlignmentEnumeration objects.
    /// </summary>
    [CollectionDataContract]
    public partial class StructureAlignmentEnumerationCollection : List<StructureAlignmentEnumeration>, ICloneable
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public StructureAlignmentEnumerationCollection() { }

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public StructureAlignmentEnumerationCollection(int capacity) : base(capacity) { }

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public StructureAlignmentEnumerationCollection(IEnumerable<StructureAlignmentEnumeration> collection) : base(collection) { }
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator StructureAlignmentEnumerationCollection(StructureAlignmentEnumeration[] values)
        {
            if (values != null)
            {
                return new StructureAlignmentEnumerationCollection(values);
            }

            return new StructureAlignmentEnumerationCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator StructureAlignmentEnumeration[](StructureAlignmentEnumerationCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            StructureAlignmentEnumerationCollection clone = new StructureAlignmentEnumerationCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((StructureAlignmentEnumeration)TypeUtils.Clone(this[ii]));
            }

            return clone;
        }
        #endregion
    }
    #endregion

    #endregion

    #region FileFormatType Class
    /// <summary>
    /// https://reference.opcfoundation.org/v104/Glass/Flat/v100/docs/9.2
    /// </summary>
    [DataContract(Namespace = OpcUa.Glass.Namespaces.GlassXsd)]
    public partial class FileFormatType : IEncodeable
    {
        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public FileFormatType()
        {
            Initialize();
        }

        [OnDeserializing]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }

        private void Initialize()
        {
            m_Name = null;
            m_FileExtension = null;
            m_Version = null;
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// </summary>
        [DataMember(Name = "Name", IsRequired = false, Order = 1)]
        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }

        /// <summary>
        /// </summary>
        [DataMember(Name = "FileExtension", IsRequired = false, Order = 2)]
        public string FileExtension
        {
            get
            {
                return m_FileExtension;
            }
            set
            {
                m_FileExtension = value;
            }
        }

        /// <summary>
        /// </summary>
        [DataMember(Name = "Version", IsRequired = false, Order = 3)]
        public string Version
        {
            get
            {
                return m_Version;
            }
            set
            {
                m_Version = value;
            }
        }

        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId
        {
            get { return OpcUa.Glass.DataTypeIds.FileFormatType; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId
        {
            get { return OpcUa.Glass.ObjectIds.FileFormatType_Encoding_DefaultBinary; }
        }
        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId
        {
            get { return OpcUa.Glass.ObjectIds.FileFormatType_Encoding_DefaultXml; }
        }

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(OpcUa.Glass.Namespaces.GlassXsd);

            encoder.WriteString("Name", Name);
            encoder.WriteString("FileExtension", FileExtension);
            encoder.WriteString("Version", Version);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(OpcUa.Glass.Namespaces.GlassXsd);
            Name = decoder.ReadString("Name");
            FileExtension = decoder.ReadString("FileExtension");
            Version = decoder.ReadString("Version");

            decoder.PopNamespace();
        }

        /// <summary cref="EncodeableObject.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            FileFormatType value = encodeable as FileFormatType;

            if (value == null)
            {
                return false;
            }
            if (!TypeUtils.IsEqual(m_Name, value.m_Name)) return false;
            if (!TypeUtils.IsEqual(m_FileExtension, value.m_FileExtension)) return false;
            if (!TypeUtils.IsEqual(m_Version, value.m_Version)) return false;

            return true;
        }

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            FileFormatType clone = (FileFormatType)this.MemberwiseClone();

            clone.m_Name = (string)TypeUtils.Clone(this.m_Name);
            clone.m_FileExtension = (string)TypeUtils.Clone(this.m_FileExtension);
            clone.m_Version = (string)TypeUtils.Clone(this.m_Version);

            return clone;
        }
        #endregion

        #region Private Fields
        private string m_Name;
        private string m_FileExtension;
        private string m_Version;
        #endregion
    }

    #region FileFormatTypeCollection class
    /// <summary>
    /// A collection of FileFormatType objects.
    /// </summary>
    [CollectionDataContract(Name = "ListOfFileFormatType", Namespace = OpcUa.Glass.Namespaces.Glass, ItemName = "FileFormatType")]
    public partial class FileFormatTypeCollection : List<FileFormatType>, ICloneable
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public FileFormatTypeCollection() { }

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public FileFormatTypeCollection(int capacity) : base(capacity) { }

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public FileFormatTypeCollection(IEnumerable<FileFormatType> collection) : base(collection) { }
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator FileFormatTypeCollection(FileFormatType[] values)
        {
            if (values != null)
            {
                return new FileFormatTypeCollection(values);
            }

            return new FileFormatTypeCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator FileFormatType[](FileFormatTypeCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            FileFormatTypeCollection clone = new FileFormatTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((FileFormatType)TypeUtils.Clone(this[ii]));
            }

            return clone;
        }
        #endregion
    }
    #endregion
    #endregion

    #region UserProfileType Class
    /// <summary>
    /// https://reference.opcfoundation.org/v104/Glass/Flat/v100/docs/9.1
    /// </summary>
    [DataContract(Namespace = OpcUa.Glass.Namespaces.GlassXsd)]
    public partial class UserProfileType : IEncodeable
    {
        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public UserProfileType()
        {
            Initialize();
        }

        [OnDeserializing]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }

        private void Initialize()
        {
            m_Name = null;
            m_LoginTime = DateTime.MinValue;
            m_Language = null;
            m_MeasurementFormat = null;
            m_AccessLevel = null;
            m_OpcUaUser = false;
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// </summary>
        [DataMember(Name = "Name", IsRequired = false, Order = 1)]
        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }

        /// <summary>
        /// </summary>
        [DataMember(Name = "LoginTime", IsRequired = false, Order = 2)]
        public DateTime LoginTime
        {
            get
            {
                return m_LoginTime;
            }
            set
            {
                m_LoginTime = value;
            }
        }

        /// <summary>
        /// </summary>
        [DataMember(Name = "Language", IsRequired = false, Order = 3)]
        public string Language
        {
            get
            {
                return m_Language;
            }
            set
            {
                m_Language = value;
            }
        }

        /// <summary>
        /// </summary>
        [DataMember(Name = "MeasurementFormat", IsRequired = false, Order = 4)]
        public string MeasurementFormat
        {
            get
            {
                return m_MeasurementFormat;
            }
            set
            {
                m_MeasurementFormat = value;
            }
        }

        /// <summary>
        /// </summary>
        [DataMember(Name = "AccessLevel", IsRequired = false, Order = 5)]
        public string AccessLevel
        {
            get
            {
                return m_AccessLevel;
            }
            set
            {
                m_AccessLevel = value;
            }
        }

        /// <summary>
        /// </summary>
        [DataMember(Name = "OpcUaUser", IsRequired = false, Order = 6)]
        public bool OpcUaUser
        {
            get
            {
                return m_OpcUaUser;
            }
            set
            {
                m_OpcUaUser = value;
            }
        }

        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId
        {
            get { return OpcUa.Glass.DataTypeIds.UserProfileType; }
        }

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId
        {
            get { return OpcUa.Glass.ObjectIds.UserProfileType_Encoding_DefaultBinary; }
        }
        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId
        {
            get { return OpcUa.Glass.ObjectIds.UserProfileType_Encoding_DefaultXml; }
        }

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(OpcUa.Glass.Namespaces.GlassXsd);

            encoder.WriteString("Name", Name);
            encoder.WriteDateTime("LoginTime", LoginTime);
            encoder.WriteString("Language", Language);
            encoder.WriteString("MeasurementFormat", MeasurementFormat);
            encoder.WriteString("AccessLevel", AccessLevel);
            encoder.WriteBoolean("OpcUaUser", OpcUaUser);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(OpcUa.Glass.Namespaces.GlassXsd);
            Name = decoder.ReadString("Name");
            LoginTime = decoder.ReadDateTime("LoginTime");
            Language = decoder.ReadString("Language");
            MeasurementFormat = decoder.ReadString("MeasurementFormat");
            AccessLevel = decoder.ReadString("AccessLevel");
            OpcUaUser = decoder.ReadBoolean("OpcUaUser");

            decoder.PopNamespace();
        }

        /// <summary cref="EncodeableObject.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            UserProfileType value = encodeable as UserProfileType;

            if (value == null)
            {
                return false;
            }
            if (!TypeUtils.IsEqual(m_Name, value.m_Name)) return false;
            if (!TypeUtils.IsEqual(m_LoginTime, value.m_LoginTime)) return false;
            if (!TypeUtils.IsEqual(m_Language, value.m_Language)) return false;
            if (!TypeUtils.IsEqual(m_MeasurementFormat, value.m_MeasurementFormat)) return false;
            if (!TypeUtils.IsEqual(m_AccessLevel, value.m_AccessLevel)) return false;
            if (!TypeUtils.IsEqual(m_OpcUaUser, value.m_OpcUaUser)) return false;

            return true;
        }

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            UserProfileType clone = (UserProfileType)this.MemberwiseClone();

            clone.m_Name = (string)TypeUtils.Clone(this.m_Name);
            clone.m_LoginTime = (DateTime)TypeUtils.Clone(this.m_LoginTime);
            clone.m_Language = (string)TypeUtils.Clone(this.m_Language);
            clone.m_MeasurementFormat = (string)TypeUtils.Clone(this.m_MeasurementFormat);
            clone.m_AccessLevel = (string)TypeUtils.Clone(this.m_AccessLevel);
            clone.m_OpcUaUser = (bool)TypeUtils.Clone(this.m_OpcUaUser);

            return clone;
        }
        #endregion

        #region Private Fields
        private string m_Name;
        private DateTime m_LoginTime;
        private string m_Language;
        private string m_MeasurementFormat;
        private string m_AccessLevel;
        private bool m_OpcUaUser;
        #endregion
    }

    #region UserProfileTypeCollection class
    /// <summary>
    /// A collection of UserProfileType objects.
    /// </summary>
    [CollectionDataContract(Name = "ListOfUserProfileType", Namespace = OpcUa.Glass.Namespaces.Glass, ItemName = "UserProfileType")]
    public partial class UserProfileTypeCollection : List<UserProfileType>, ICloneable
    {
        #region Constructors
        /// <summary>
        /// Initializes the collection with default values.
        /// </summary>
        public UserProfileTypeCollection() { }

        /// <summary>
        /// Initializes the collection with an initial capacity.
        /// </summary>
        public UserProfileTypeCollection(int capacity) : base(capacity) { }

        /// <summary>
        /// Initializes the collection with another collection.
        /// </summary>
        public UserProfileTypeCollection(IEnumerable<UserProfileType> collection) : base(collection) { }
        #endregion

        #region Static Operators
        /// <summary>
        /// Converts an array to a collection.
        /// </summary>
        public static implicit operator UserProfileTypeCollection(UserProfileType[] values)
        {
            if (values != null)
            {
                return new UserProfileTypeCollection(values);
            }

            return new UserProfileTypeCollection();
        }

        /// <summary>
        /// Converts a collection to an array.
        /// </summary>
        public static explicit operator UserProfileType[](UserProfileTypeCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #region ICloneable Methods
        /// <summary>
        /// Creates a deep copy of the collection.
        /// </summary>
        public object Clone()
        {
            UserProfileTypeCollection clone = new UserProfileTypeCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((UserProfileType)TypeUtils.Clone(this[ii]));
            }

            return clone;
        }
        #endregion
    }
    #endregion
    #endregion


    #region EncodeableTypes
    /// <summary>
    /// Contains a method for registering all encodeable types of the namespace.
    /// </summary>
    public class EncodeableTypes
    {
        /// <summary>
        /// Register all encodeable types of the namespace at the communication stack.
        /// The Decoder will decode the registered types.
        /// </summary>
        public static void RegisterEncodeableTypes(MessageContext context)
        {
            context.Factory.AddEncodeableType(typeof(OpcUa.Glass.FileFormatType));
            context.Factory.AddEncodeableType(typeof(OpcUa.Glass.UserProfileType));
        }
    }
    #endregion
}
