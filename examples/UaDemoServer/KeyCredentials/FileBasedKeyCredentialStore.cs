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
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaServer;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Threading;

namespace UnifiedAutomation.Sample
{
    internal class FileBasedKeyCredentialStore : IKeyCredentialStore
    {
        private readonly SemaphoreSlim m_gate;
        private readonly string m_filename;
        private readonly List<FileBasedKeyCredentialStoreItem> m_items;

        public static FileBasedKeyCredentialStore FromFile(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(FileBasedKeyCredentialStoreItems));
            FileBasedKeyCredentialStoreItem[] items;

            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    var storeItems = (FileBasedKeyCredentialStoreItems)serializer.Deserialize(fs);
                    items = storeItems.Items;
                }
            }
            catch (Exception ex)
            {
                // Trace??
                _ = ex;
                items = new FileBasedKeyCredentialStoreItem[] { };
            }

            return new FileBasedKeyCredentialStore(filename, items);
        }

        public FileBasedKeyCredentialStore(string filename, FileBasedKeyCredentialStoreItem[] items)
        {
            m_gate = new SemaphoreSlim(1);
            m_filename = filename;
            m_items = new List<FileBasedKeyCredentialStoreItem>(items);
        }

        public async Task<IKeyCredentialStoreItem> CreateItemAsync(string name, string resourceUri, string profileUri, string[] endpointUrls, CancellationToken cancellationToken)
        {
            var item = new FileBasedKeyCredentialStoreItem()
            {
                Name = name,
                ResourceUri = resourceUri,
                ProfileUri = profileUri,
                EndpointUrls = endpointUrls
            };

            await m_gate.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                m_items.Add(item);

                await SaveAsync().ConfigureAwait(false);
                return item;
            }
            finally
            {
                m_gate.Release();
            }
        }

        public async Task DeleteItemAsync(IKeyCredentialStoreItem item, CancellationToken cancellationToken)
        {
            if (!(item is FileBasedKeyCredentialStoreItem))
            {
                throw new ArgumentException(nameof(item));
            }

            await m_gate.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                m_items.Remove((FileBasedKeyCredentialStoreItem)item);
                await SaveAsync().ConfigureAwait(false);
            }
            finally
            {
                m_gate.Release();
            }
        }

        public async Task<IKeyCredentialStoreItem[]> GetItemsAsync(CancellationToken cancellationToken)
        {
            await m_gate.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                return m_items.Cast<IKeyCredentialStoreItem>().ToArray();
            }
            finally
            {
                m_gate.Release();
            }
        }

        public async Task<KeyCredential> GetKeyCredentialAsync(IKeyCredentialStoreItem item, Guid id, CancellationToken cancellationToken)
        {
            if (!(item is FileBasedKeyCredentialStoreItem fileItem))
            {
                throw new ArgumentException(nameof(item));
            }

            await m_gate.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                return new KeyCredential(
                    id,
                    fileItem.ResourceUri,
                    fileItem.ProfileUri,
                    fileItem.EndpointUrls,
                    fileItem.CredentialId,
                    fileItem.Secret);
            }
            finally
            {
                m_gate.Release();
            }
        }

        public async Task UpdateItemAsync(IKeyCredentialStoreItem item, string credentialId, byte[] secret, CancellationToken cancellationToken)
        {
            if (!(item is FileBasedKeyCredentialStoreItem fileItem))
            {
                throw new ArgumentException(nameof(item));
            }

            await m_gate.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                fileItem.CredentialId = credentialId;
                fileItem.Secret = secret;

                await SaveAsync().ConfigureAwait(false);
            }
            finally
            {
                m_gate.Release();
            }
        }

        private async Task SaveAsync()
        {
            try
            {
                await Task.Run(() =>
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(FileBasedKeyCredentialStoreItems));

                    var items = new FileBasedKeyCredentialStoreItems()
                    {
                        Items = m_items.ToArray()
                    };

                    using (var writer = new StreamWriter(m_filename))
                    {
                        serializer.Serialize(writer, items);
                    }

                }).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _ = ex;
                // trace ??
            }
        }
    }
}
