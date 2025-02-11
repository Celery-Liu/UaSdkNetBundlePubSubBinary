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
        #region Helper
        private string GetPathForFiles(string name)
        {
            string fileName = null;
            // Try to set the file location relative to the certificate directory
            if (Server.Application.ApplicationCertificate != null)
            {
                if (System.IO.Path.IsPathRooted(Server.Application.ApplicationCertificate.StorePath))
                {
                    var pathArray = Server.Application.ApplicationCertificate.StorePath.Split(System.IO.Path.DirectorySeparatorChar);
                    var list = pathArray.ToList();
                    list.RemoveRange(list.Count - 2, 2);
                    list.Add(name);
                    fileName = String.Join($"{System.IO.Path.DirectorySeparatorChar}", list.ToArray());
                }
            }
            // Fallback to CommonApplicationData
            if (fileName == null)
            {
                fileName = PlatformUtils.CombinePath(
                    Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                    "unifiedautomation",
                    "UaSdkNet",
                    name);
            }
            return fileName;
        }
        #endregion

        #region Create File
        /// <summary>
        /// Sets up the folder that includes file objects.
        /// </summary>
        /// <returns></returns>
        public void SetupFiles()
        {
            string filePath = GetDemoFilename();

            SetupFileObject(new NodeId(Model.Objects.Demo_Files, DefaultNamespaceIndex), "TextFile", filePath, "This file can be used for reading and writing");
        }

        /// <summary>
        /// The file on disk for the FileType example is located next to the pki store of the server.
        /// </summary>
        /// <returns></returns>
        string GetDemoFilename()
        {
            return GetPathForFiles("demo.txt");
        }

        /// <summary>
        /// Sets up a file object.
        /// </summary>
        public NodeId SetupFileObject(NodeId parentId, string browseName, string filePath)
        {
            return SetupFileObject(parentId, browseName, filePath, null);
        }

        /// <summary>
        /// Creates a new File object.
        /// </summary>
        /// <param name="parentId">The NodeId of the parent node. The created File object will be
        /// referenced by an Organizes reference.</param>
        /// <param name="browseName">The browse name of the new File object. The browseName is also used
        /// to create the NodeId of the File object.</param>
        /// <param name="filePath">The file path on the disk.</param>
        /// <param name="description">used for the description attribute of the new File object.</param>
        public NodeId SetupFileObject(NodeId parentId, string browseName, string filePath, string description)
        {
            /// [Create OPC UA nodes]
            NodeId objectId = new NodeId("Demo.Files." + browseName, DefaultNamespaceIndex);

            CreateObjectSettings settings = new CreateObjectSettings()
            {
                ParentNodeId = parentId,
                ReferenceTypeId = ReferenceTypeIds.Organizes,
                RequestedNodeId = objectId,
                BrowseName = new QualifiedName(browseName, DefaultNamespaceIndex),
                TypeDefinitionId = ObjectTypeIds.FileType
            };
            if (description != null)
            {
                settings.Description = new LocalizedText(description);
            }

            CreateObject(Server.DefaultRequestContext, settings);
            /// [Create OPC UA nodes]

            /// [Create model class]
            FileModel file = new FileModel();
            /// [Create model class]

            /// [Set FileModel properties]
            file.Writable = true;
            file.UserWritable = true;
            file.MaxFileSize = 10000;
            file.FileOnDisk = new System.IO.FileInfo(filePath);
            /// [Set FileModel properties]

            /// [Create default file]
            if (!file.FileOnDisk.Exists)
            {
                using (var ostrm = file.FileOnDisk.Open(System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None))
                {
                    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(
                       "This file is used for demonstrating the OPC UA FileType.\n"
                     + "You can call the Open method of the TextFile object with Mode argument 1 for ReadOnly.\n"
                     + "You have to remember the returned FileHandle argument.\n"
                     + "This FileHandle can be used for reading the file by calling the Read method and closing\n"
                     + "the file by calling the Close method.");
                    ostrm.Write(bytes, 0, bytes.Length);
                }
                file.FileOnDisk.Refresh();
            }
            /// [Create default file]

            // Sets the initial value of the File object.
            /// [Set file size]
            file.Size = (ulong)file.FileOnDisk.Length;
            /// [Set file size]

            /// [LinkModelToNode]
            LinkModelToNode(objectId, file, null, null, 500);
            /// [LinkModelToNode]

            return objectId;
        }
        #endregion

        #region Create Directory

        // map of all directories
        // needed to get the target of move or copy calls
        Dictionary<NodeId, FileDirectoryModel> m_fileSystem;

        string GetFileDirectoryName()
        {
            return GetPathForFiles("FileSystem");
        }

        public void SetupFileDirctory()
        {
            m_fileSystem = new Dictionary<NodeId, FileDirectoryModel>();

            string directoryName = "FileSystem";
            string directoryAbsolut = GetFileDirectoryName();

            // create the FileSystem entry point on disk
            System.IO.DirectoryInfo directoryInfo;
            if (!System.IO.Directory.Exists(directoryAbsolut))
            {
                directoryInfo = System.IO.Directory.CreateDirectory(directoryAbsolut);
            }
            else
            {
                directoryInfo = new System.IO.DirectoryInfo(directoryAbsolut);
            }

            // and create the node in address space
            FileDirectoryModel directory = CreateDirectoryNodes(directoryName, null, 0);
            directory.DirectoryOnDisk = directoryInfo;

            m_fileSystem.Add(directory.NodeId, directory);

            // Add the existing directories and files recursively
            AddExistingEntries(directory);
        }

        private void AddExistingEntries(FileDirectoryModel directory)
        {
            Dictionary<NodeId, BaseObjectModel> children = new Dictionary<NodeId, BaseObjectModel>();

            System.IO.DirectoryInfo directoryInfo = directory.DirectoryOnDisk;
            IEnumerable<System.IO.FileInfo> existingFiles = directoryInfo.GetFiles();
            foreach (System.IO.FileInfo fileInfo in existingFiles)
            {
                NodeId fileId;
                FileModel file = CreateFileModelNodes(directory, fileInfo.Name, out fileId);
                file.Size = (ulong) fileInfo.Length;
                file.FileOnDisk = fileInfo;

                children.Add(fileId, file);
            }

            IEnumerable<System.IO.DirectoryInfo> existingDirectories = directoryInfo.GetDirectories();
            foreach (System.IO.DirectoryInfo subDirectoryInfo in existingDirectories)
            {
                FileDirectoryModel fileDirectory = CreateDirectoryNodes(subDirectoryInfo.Name, directory);
                fileDirectory.DirectoryOnDisk = subDirectoryInfo;
                children.Add(fileDirectory.NodeId, fileDirectory);
                m_fileSystem.Add(fileDirectory.NodeId, fileDirectory);
                AddExistingEntries(fileDirectory);
            }
            directory.UserData = children;
        }

        private void File_CreateFileRequest(object sender, CreateFileRequestEventArgs e)
        {
            FileDirectoryModel fileDirectory = sender as FileDirectoryModel;

            uint fileHandle = 0;
            string name = e.NewName;
            bool openFile = e.OpenFile;

            // create the file on disc
            string fileName = fileDirectory.DirectoryOnDisk.FullName + "\\" + name;
            System.IO.FileInfo fileOnDisc = new System.IO.FileInfo(fileName);
            if (!fileOnDisc.Exists && !System.IO.Directory.Exists(fileName))
            {
                var ostrm = fileOnDisc.Open(System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None);
                ostrm.Flush();
                ostrm.Close();
            }
            else
            {
                e.StatusCode = StatusCodes.BadBrowseNameDuplicated;
                return;
            }

            NodeId fileId;
            FileModel file = CreateFileModelNodes(fileDirectory, name, out fileId);
            file.FileOnDisk = fileOnDisc;

            if (openFile)
            {
                var result = file.Open(e.Context, file, (byte)(OpenFileMode.Write | OpenFileMode.EraseExisting), out fileHandle);

                if (!result.IsGood())
                {
                    fileHandle = 0;
                }
            }

            Dictionary<NodeId, BaseObjectModel> children = (Dictionary<NodeId, BaseObjectModel>)fileDirectory.UserData;
            children.Add(fileId, file);

            e.NewNodeId = fileId;
            e.FileHandle = fileHandle;

            UpdateDirectoryNodeVersion(fileDirectory.NodeId, DirectoryModification.Add);
        }

        private void File_DeleteRequest(object sender, DeleteFileRequestEventArgs e)
        {
            FileDirectoryModel fileDirectory = (FileDirectoryModel)sender;
            Dictionary<NodeId, BaseObjectModel> children = (Dictionary<NodeId, BaseObjectModel>)fileDirectory.UserData;

            BaseObjectModel model;
            if (children.TryGetValue(e.FileToDelete, out model))
            {
                try
                {
                    FileDirectoryModel directory = model as FileDirectoryModel;
                    if (directory != null)
                    {
                        DeleteDirectory(directory);
                        children.Remove(e.FileToDelete);
                    }
                    FileModel file = model as FileModel;
                    if (file != null)
                    {
                        DeleteFile(file, e.FileToDelete);
                        children.Remove(e.FileToDelete);
                    }
                    UpdateDirectoryNodeVersion(fileDirectory.NodeId, DirectoryModification.Delete);
                }
                catch (Exception exception)
                {
                    e.StatusCode = new StatusCode(exception);
                }
            }
            else
            {
                e.StatusCode = StatusCodes.BadNodeIdUnknown;
            }
        }

        private void File_CreateDirectoryRequest(object sender, CreateDirectoryRequestEventArgs e)
        {
            FileDirectoryModel parent = sender as FileDirectoryModel;
            string directoryName = e.NewName;

            FileDirectoryModel newDirectory = CreateDirectory(directoryName, parent);
            UpdateDirectoryNodeVersion(parent.NodeId, DirectoryModification.Add);
            e.NewNodeId = newDirectory.NodeId;
        }

        private void File_MoveOrCopy(object sender, MoveFileRequestEventArgs e)
        {
            FileDirectoryModel directory = sender as FileDirectoryModel;

            var children = (Dictionary<NodeId, BaseObjectModel>)directory.UserData;

            BaseObjectModel model;
            if (!children.TryGetValue(e.FileToMove, out model))
            {
                e.StatusCode = new StatusCode(StatusCodes.BadNotFound, "Source not found in source directory.");
                return;
            }

            FileDirectoryModel targetDirectoryModel = null;

            if (!m_fileSystem.TryGetValue(e.TargetDirectory, out targetDirectoryModel))
            {
                e.StatusCode = new StatusCode(StatusCodes.BadNotFound, "Target directory not found.");
                return;
            }

            var targetChildren = (Dictionary<NodeId, BaseObjectModel>)targetDirectoryModel.UserData;

            FileModel file = model as FileModel;
            if (file != null)
            {
                string sName = String.IsNullOrEmpty(e.NewName) ? file.FileOnDisk.Name : e.NewName;
                string targetFileName = targetDirectoryModel.DirectoryOnDisk.FullName + "\\" + sName;
                if (System.IO.File.Exists(targetFileName) || System.IO.Directory.Exists(targetFileName))
                {
                    e.StatusCode = new StatusCode(StatusCodes.BadBrowseNameDuplicated);
                    return;
                }

                System.IO.FileInfo fileOnDisc = file.FileOnDisk;
                try
                {
                    if (e.MakeCopy)
                    {
                        fileOnDisc = file.FileOnDisk.CopyTo(targetFileName);
                    }
                    else
                    {
                        file.FileOnDisk.MoveTo(targetFileName);
                    }
                }
                catch (Exception)
                {
                    e.StatusCode = new StatusCode(StatusCodes.BadInvalidState, "Could not move file");
                    return;
                }

                NodeId newFileId = null;
                FileModel newFileModel = CreateFileModelNodes(targetDirectoryModel, sName, out newFileId);
                newFileModel.FileOnDisk = fileOnDisc;
                newFileModel.Size = (ulong)newFileModel.FileOnDisk.Length;
                e.NewNodeId = newFileId;
                targetChildren.Add(newFileId, file);
                UpdateDirectoryNodeVersion(targetDirectoryModel.NodeId, DirectoryModification.Add);
                if (!e.MakeCopy)
                {
                    UnlinkModelFromNode(e.FileToMove, file.ModelHandle);
                    lock (InMemoryNodeLock)
                    {
                        DeleteNode(Server.DefaultRequestContext, e.FileToMove, true);
                    }
                    children.Remove(e.FileToMove);
                    UpdateDirectoryNodeVersion(directory.NodeId, DirectoryModification.Delete);
                }
            }

            FileDirectoryModel directoryToMove = model as FileDirectoryModel;
            if (directoryToMove != null)
            {
                var entries = (Dictionary<NodeId, BaseObjectModel>)directoryToMove.UserData;
                if (entries.Count > 0)
                {
                    e.StatusCode = new StatusCode(StatusCodes.BadNotImplemented, "Moving or renaming directories that are not empty is not supported.");
                    return;
                }
                string sName = String.IsNullOrEmpty(e.NewName) ? directoryToMove.DirectoryOnDisk.Name : e.NewName;

                FileDirectoryModel newDirectory = CreateDirectory(sName, targetDirectoryModel);
                e.NewNodeId = newDirectory.NodeId;
                UpdateDirectoryNodeVersion(targetDirectoryModel.NodeId, DirectoryModification.Add);

                if (!e.MakeCopy)
                {
                    DeleteDirectory(directoryToMove);
                    UpdateDirectoryNodeVersion(directory.NodeId, DirectoryModification.Delete);
                }
            }
        }

        FileDirectoryModel CreateDirectory(string directoryName, FileDirectoryModel parent)
        {
            // Create the full name and the parent node id
            string fullDirectoryName = parent.DirectoryOnDisk.FullName + "\\" + directoryName;

            // Create the directory on disc
            System.IO.DirectoryInfo directoryInfo;
            if (!System.IO.Directory.Exists(fullDirectoryName) && !System.IO.File.Exists(fullDirectoryName))
            {
                directoryInfo = System.IO.Directory.CreateDirectory(fullDirectoryName);
            }
            else
            {
                throw new StatusException(StatusCodes.BadBrowseNameDuplicated);
            }

            FileDirectoryModel directory = CreateDirectoryNodes(directoryName, parent);
            directory.DirectoryOnDisk = directoryInfo;

            Dictionary<NodeId, BaseObjectModel> children = (Dictionary<NodeId, BaseObjectModel>)parent.UserData;
            children.Add(directory.NodeId, directory);
            m_fileSystem.Add(directory.NodeId, directory);

            directory.UserData = new Dictionary<NodeId, BaseObjectModel>();

            return directory;
        }

        FileDirectoryModel CreateDirectoryNodes(string directoryName, FileDirectoryModel parent)
        {
            return CreateDirectoryNodes(directoryName, parent, DefaultNamespaceIndex);
        }

        RolePermissionTypeCollection GetDirectoryPermissions()
        {
            return new RolePermissionTypeCollection()
            {
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Engineer,
                    Permissions = PermissionTypeDataType.Call | PermissionTypeDataType.Browse
                },
                new RolePermissionType()
                {
                    RoleId = ObjectIds.WellKnownRole_Anonymous,
                    Permissions = PermissionTypeDataType.Browse
                }
            };
        }

        FileDirectoryModel CreateDirectoryNodes(string directoryName, FileDirectoryModel parent, ushort browseNameIndex)
        {
            // Create the parent node id
            NodeId parentId;
            if (parent != null)
            {
                parentId = parent.NodeId;
            }
            else
            {
                parentId = new NodeId(Model.Objects.Demo_Files, DefaultNamespaceIndex);
            }

            // create the directory nodes
            CreateObjectSettings settings = new CreateObjectSettings()
            {
                BrowseName = new QualifiedName(directoryName, browseNameIndex),
                DisplayName = new LocalizedText(directoryName),
                ParentNodeId = parentId,
                ReferenceTypeId = ReferenceTypeIds.Organizes,
                RequestedNodeId = new NodeId(parentId.Identifier.ToString() + "." + directoryName, DefaultNamespaceIndex),
                TypeDefinitionId = ObjectTypeIds.FileDirectoryType,
                RolePermissions = GetDirectoryPermissions()
            };

            /// [Create Directory]
            ObjectNode directoryNode;
            lock (InMemoryNodeLock)
            {
                directoryNode = CreateObject(Server.DefaultRequestContext, settings);

                if (Server.IsRunning)
                {
                    directoryNode.IRolePermissions = ConvertRolePermissions(settings.RolePermissions);
                }
            }
            /// [Create Directory]

            // and the model
            FileDirectoryModel directory = new FileDirectoryModel();

            // set the event handlers
            directory.CreateFileRequest += File_CreateFileRequest;
            directory.DeleteFileRequest += File_DeleteRequest;
            directory.CreateDirectoryRequest += File_CreateDirectoryRequest;
            directory.MoveFileRequest += File_MoveOrCopy;

            //set the NodeId
            directory.NodeId = directoryNode.NodeId;

            ModelHandle modelHandle = LinkModelToNode(directoryNode.NodeId, directory, null, null, 500);
            directory.ModelHandle = modelHandle;

            // Set NodeVersion
            // NodeVersion property is not needed if ModelChangeEvents are fired
            // It is not required to fire ModelChangeEvents when adding or deleting files or directories.
            // In this example we fire the events to get an updated address space view in UaExpert.
            CreateVariableSettings nodeVersion = new CreateVariableSettings()
            {
                AccessLevel = AccessLevels.CurrentRead,
                BrowseName = BrowseNames.NodeVersion,
                DataType = DataTypeIds.String,
                DisplayName = BrowseNames.NodeVersion,
                ParentAsOwner = true,
                ParentNodeId = directory.NodeId,
                ReferenceTypeId = ReferenceTypeIds.HasProperty,
                TypeDefinitionId = VariableTypeIds.PropertyType,
                Value = new Variant("0")
            };
            lock (InMemoryNodeLock)
            {
                CreateVariable(Server.DefaultRequestContext, nodeVersion);
            }

            return directory;
        }

        FileModel CreateFileModelNodes(FileDirectoryModel directory, string name, out NodeId newNodeId)
        {
            string fullFileName = directory.DirectoryOnDisk.FullName + "\\" + name;
            var settings = new CreateObjectSettings()
            {
                ParentNodeId = directory.NodeId,
                ParentAsOwner = true,
                ReferenceTypeId = ReferenceTypeIds.HasComponent,
                RequestedNodeId = new NodeId(directory.NodeId.Identifier.ToString() + "." + name, DefaultNamespaceIndex),
                BrowseName = new QualifiedName(name, DefaultNamespaceIndex),
                DisplayName = name,
                TypeDefinitionId = ObjectTypeIds.FileType
            };
            ObjectNode node;
            lock (InMemoryNodeLock)
            {
                node = CreateObject(Server.DefaultRequestContext, settings);
            }

            newNodeId = node.NodeId;

            // Model
            FileModel file = new FileModel();

            file.Writable = true;
            file.UserWritable = true;
            file.MaxFileSize = 10000;
            file.Size = 0;

            ModelHandle handle = LinkModelToNode(node.NodeId, file, null, null, 500);
            file.ModelHandle = handle;

            return file;
        }

        void DeleteFile(FileModel file, NodeId fileId)
        {
            System.IO.File.Delete(file.FileOnDisk.FullName);
            UnlinkModelFromNode(fileId, file.ModelHandle);
            lock (InMemoryNodeLock)
            {
                DeleteNode(Server.DefaultRequestContext, fileId, true);
            }
        }

        void DeleteDirectory(FileDirectoryModel directory)
        {
            Dictionary<NodeId, BaseObjectModel> children = (Dictionary<NodeId, BaseObjectModel>)directory.UserData;
            foreach (KeyValuePair<NodeId, BaseObjectModel> entry in children)
            {
                FileDirectoryModel childDirectory = entry.Value as FileDirectoryModel;
                if (childDirectory != null)
                {
                    DeleteDirectory(childDirectory);
                }
                else
                {
                    FileModel file = entry.Value as FileModel;
                    if (file != null)
                    {
                        DeleteFile(file, entry.Key);
                    }
                }
            }
            System.IO.Directory.Delete(directory.DirectoryOnDisk.FullName);
            m_fileSystem.Remove(directory.NodeId);
            UnlinkModelFromNode(directory.NodeId, directory.ModelHandle);
            lock (InMemoryNodeLock)
            {
                DeleteNode(Server.DefaultRequestContext, directory.NodeId, true);
            }
        }

        enum DirectoryModification
        {
            Add = ModelChangeStructureVerbMask.ReferenceAdded,
            Delete = ModelChangeStructureVerbMask.ReferenceDeleted
        }

        void UpdateDirectoryNodeVersion(NodeId directoryId, DirectoryModification action)
        {
            VariableNode nodeVersion = FindInMemoryNode(
                directoryId,
                ReferenceTypeIds.HasProperty,
                false,
                BrowseNames.NodeVersion) as VariableNode;

            if (nodeVersion == null)
            {
                return;
            }

            int version = nodeVersion.Value.ToInt32();
            version++;
            lock (InMemoryNodeLock)
            {
                nodeVersion.Value = new Variant(version.ToString());
                NodeAttributeHandle handle;
                GetNodeHandle(Server.DefaultRequestContext, nodeVersion.NodeId, Attributes.Value, out handle);
                ReportDataChanges(Server.DefaultRequestContext, handle);
            }

            // create model change event.
            GenericEvent e = new GenericEvent(Server.FilterManager);

            e.Initialize(
                null,
                ObjectTypeIds.GeneralModelChangeEventType,
                ObjectIds.Server,
                BrowseNames.Server,
                EventSeverity.Low,
                "The address space has changed.");

            ModelChangeStructureDataType[] changes = new ModelChangeStructureDataType[1];

            changes[0] = new ModelChangeStructureDataType();
            changes[0].Affected = directoryId;
            changes[0].AffectedType = ObjectTypeIds.FileDirectoryType;
            changes[0].Verb = (byte) action;

            e.Set(BrowseNames.Changes, new Variant(changes));

            // report the event.
            Server.ReportEvent(e);
        }
        #endregion
    }
}
