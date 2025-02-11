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
using System.Threading;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaServer;

namespace UnifiedAutomation.Demo
{
    internal partial class DemoNodeManager : ITemporaryFileTransferMethods
    {
        private Dictionary<TemporaryFile, uint> m_temporaryFiles;

        //! [TempFileTrans_SetupSpecialTemporaryFileTransfer]
        public void SetupSpecialTemporaryFileTransfer()
        {
            m_temporaryFiles = new Dictionary<TemporaryFile, uint>();

            CreateObjectSettings settings = new CreateObjectSettings()
            {
                ParentNodeId = new NodeId(Model.Objects.Demo_Files, DefaultNamespaceIndex),
                ReferenceTypeId = ReferenceTypeIds.Organizes,
                RequestedNodeId = new NodeId("Demo.Files.TempFile", DefaultNamespaceIndex),
                BrowseName = new QualifiedName("TempFile", DefaultNamespaceIndex),
                TypeDefinitionId = ObjectTypeIds.TemporaryFileTransferType,
                Description = new LocalizedText("This object can be used to generate a temporary file on the server to " +
                    "provide information to the client. The temporary file is deleted after a time period defined in " +
                    "\"ClientProcessingTimeout\" of non-use, or if the client closes the file."),
                ChildrenSettings =
                {
                    new ChildVariableSettings()
                    {
                        BrowsePath =
                        {
                            BrowseNames.GenerateFileForRead,
                            BrowseNames.InputArguments
                        },
                        Value = new Variant(new List<ExtensionObject>()
                        {
                            new ExtensionObject(new Argument()
                            {
                                Name = "GenerateOptions",
                                ValueRank = ValueRanks.Scalar,
                                DataType = DataTypeIds.String
                            })
                        })
                    }
                }
            };

            var objectNode = CreateObject(Server.DefaultRequestContext, settings);
            var objectImplementation = new TemporaryFileTransferModel();

            objectImplementation.TemporaryFileTransferMethods = this;
            objectImplementation.ClientProcessingTimeout = 10000; // important to set, if default (0) it will not work

            LinkModelToNode(objectNode.NodeId, objectImplementation, null, null, 100);
        }
        //! [TempFileTrans_SetupSpecialTemporaryFileTransfer]

        #region ISpecialTemporaryFileTransferMethods Members
        public StatusCode CloseAndCommit(RequestContext context, TemporaryFileTransferModel model, uint FileHandle, out NodeId CompletionStateMachine)
        {
            // only implement read operation, this is only needed for writing
            CompletionStateMachine = null;
            return StatusCodes.BadInvalidState;
        }

        //! [TempFileTrans_GenerateFileForRead]
        public StatusCode GenerateFileForRead(RequestContext context,
                                              TemporaryFileTransferModel model,
                                              Variant GenerateOptions,
                                              out NodeId FileNodeId,
                                              out uint FileHandle,
                                              out NodeId CompletionStateMachine)
        {
            var fileModel = CreateFile(GenerateOptions.ToString(), (int)model.ClientProcessingTimeout, context.Session, out FileNodeId);
            fileModel.Open(context, fileModel, (byte)FileAccessModes.Read, out FileHandle);
            fileModel.Timeout += FileModel_Timeout;
            fileModel.Closed += FileModel_Closed;

            CompletionStateMachine = null; // we can directly generate the file so we do not need this state machine

            m_temporaryFiles.Add(fileModel, FileHandle);

            return StatusCodes.Good;
        }
        //! [TempFileTrans_GenerateFileForRead]

        public StatusCode GenerateFileForWrite(RequestContext context, TemporaryFileTransferModel model, Variant GenerateOptions, out NodeId FileNodeId, out uint FileHandle)
        {
            // only implement read operation
            FileNodeId = null;
            FileHandle = 0;
            return StatusCodes.BadNotWritable;
        }
        #endregion

        #region Private Methods
        private TemporaryFile CreateFile(string generateOptions, int timeout, Session session, out NodeId fileId)
        {
            CreateObjectSettings settings = new CreateObjectSettings()
            {
                RequestedNodeId = new NodeId(Uuid.NewUuid(), DefaultNamespaceIndex),
                BrowseName = new QualifiedName("File", DefaultNamespaceIndex),
                TypeDefinitionId = ObjectTypeIds.FileType
            };

            ObjectNode file = CreateObject(Server.DefaultRequestContext, settings);
            fileId = file.NodeId;
            DisableWriteAttribute(fileId);

            string filename = CreateTemporaryFilename();

            System.IO.File.WriteAllText(filename, generateOptions); // here you need to generate something reasonable

            var fileModel = new TemporaryFile(timeout, session)
            {
                FileOnDisk = new System.IO.FileInfo(filename),
                UserData = fileId
            };

            LinkModelToNode(file.NodeId, fileModel, null, null, 500);
            return fileModel;
        }

        private void DisableWriteAttribute(NodeId fileId)
        {
            BrowsePathResult result = new BrowsePathResult();

            Server.InternalClient.Translate(Server.DefaultRequestContext, fileId, new RelativePath(BrowseNames.Write), 0, result);

            Server.InternalClient.WriteAttribute(
               Server.DefaultRequestContext,
               (NodeId)result.Targets[0].TargetId,
               Attributes.Executable,
               new Variant(false));
        }

        private string CreateTemporaryFilename()
        {
            string filename = "TempTransferFile_" + DateTime.Now.Ticks;
            return GetPathForFiles(filename);
        }

        private void DeleteAllTemporaryTransferFiles()
        {
            foreach (TemporaryFile model in m_temporaryFiles.Keys)
            {
                try
                {
                    model.CloseFile(Server.DefaultRequestContext, m_temporaryFiles[model]);
                    DeleteNode(Server.DefaultRequestContext, model.UserData as NodeId, true);
                    model.FileOnDisk.Delete();
                    model.Dispose();
                }
                catch { }
            }
        }

        //! [TempFileTrans_DeleteFile]
        private void DeleteFile(TemporaryFile model)
        {
            DeleteNode(Server.DefaultRequestContext, model.UserData as NodeId, true);
            m_temporaryFiles.Remove(model);
            model.FileOnDisk.Delete();
            model.Dispose();
        }
        //! [TempFileTrans_DeleteFile]

        //! [TempFileTrans_Timeout]
        private void FileModel_Timeout(TemporaryFile model, EventArgs e)
        {
            // if running into timeout, file probably needs to be closed first
            try
            {
                model.CloseFile(Server.DefaultRequestContext, m_temporaryFiles[model]);
            }
            catch (Exception) { }
            finally
            {
                DeleteFile(model);
            }
        }
        //! [TempFileTrans_Timeout]

        private void FileModel_Closed(TemporaryFile model, EventArgs e)
        {
            DeleteFile(model);
        }
        #endregion

        #region Inner Class TemporaryFile
        private class TemporaryFile : FileModel
        {
            readonly Session m_session;
            readonly int m_timeout;
            Timer m_timer;

            public event FileTimeout Timeout;
            public event FileClosed Closed;

            public delegate void FileTimeout(TemporaryFile sender, EventArgs args);
            public delegate void FileClosed(TemporaryFile sender, EventArgs args);

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="timeout">After timeout FileTimeout event is created. Every operation resets Timeout.</param>
            /// <param name="session">Session of the Tempfile. File is only valid while Session is not closing. If session is closing, Timeout event is created.</param>
            public TemporaryFile(int timeout, Session session)
            {
                m_timeout = timeout;
                m_timer = new Timer(OnTimerExpired, null, m_timeout, System.Threading.Timeout.Infinite);
                m_session = session;
                m_session.Server.SessionManager.SessionClosing += SessionManager_SessionClosing;
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    m_session.Server.SessionManager.SessionClosing -= SessionManager_SessionClosing;
                }

                base.Dispose(disposing);
            }

            private void SessionManager_SessionClosing(Session session, SessionEventReason reason)
            {
                if (session.Equals(m_session))
                {
                    // according to spec - if session disappears temporary file shall disappear
                    OnTimerExpired(null);
                }
            }

            public void OnTimerExpired(object state)
            {
                if (Timeout != null)
                {
                    Timeout(this, null);
                }

                m_timer.Dispose();
                m_timer = null;
            }

            public void ResetTimer()
            {
                if (m_timer != null)
                {
                    m_timer.Dispose();
                }

                m_timer = new Timer(OnTimerExpired, null, m_timeout, System.Threading.Timeout.Infinite);
            }

            public void CloseFile(RequestContext context, uint fileHandle)
            {
                lock (Lock)
                {
                    OpenFileHandle fh = FindHandle(context, fileHandle);
                    CloseHandle(fh);
                }
            }

            protected override bool HasAccess(RequestContext context, UserAccessMask accessMasks)
            {
                if (m_session != context.Session)
                {
                    return false;
                }
                return base.HasAccess(context, accessMasks);
            }

            public override StatusCode Close(RequestContext context, FileModel model, uint fileHandle)
            {
                ResetTimer();

                var returnValue = base.Close(context, model, fileHandle);

                if (Closed != null)
                {
                    Closed(this, null);
                }
                return returnValue;
            }

            public override StatusCode GetPosition(RequestContext context, FileModel model, uint fileHandle, out ulong position)
            {
                ResetTimer();
                return base.GetPosition(context, model, fileHandle, out position);
            }

            public override StatusCode Open(RequestContext context, FileModel model, byte mode, out uint fileHandle)
            {
                ResetTimer();
                return base.Open(context, model, mode, out fileHandle);
            }

            //! [TempFileTrans_Read]
            public override StatusCode Read(RequestContext context, FileModel model, uint fileHandle, int length, out byte[] data)
            {
                ResetTimer();
                return base.Read(context, model, fileHandle, length, out data);
            }
            //! [TempFileTrans_Read]

            public override StatusCode SetPosition(RequestContext context, FileModel model, uint fileHandle, ulong position)
            {
                ResetTimer();
                return base.SetPosition(context, model, fileHandle, position);
            }

            public override StatusCode Write(RequestContext context, FileModel model, uint fileHandle, byte[] data)
            {
                if (m_session != context.Session)
                {
                    return StatusCodes.BadUserAccessDenied;
                }

                ResetTimer();
                return base.Write(context, model, fileHandle, data);
            }
        }
        #endregion
    }
}
