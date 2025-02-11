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
using System.Xml;
using System.Reflection;
using System.Runtime.InteropServices;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaServer;
using UnifiedAutomation.DemoServer;

namespace UnifiedAutomation.Sample
{
    internal partial class TestServerManager : ServerManager, IQueryManager
    {
        private event EventHandler<CertificateAddedEventArgs> m_CertificateCalled;

        public TestServerManager()
        {
        }

        public event EventHandler<CertificateAddedEventArgs> CertificateAdded
        {
            add
            {
                m_CertificateCalled += value;
            }

            remove
            {
                m_CertificateCalled -= value;
            }
        }

        public List<KeyValuePair<Subscription, string>> GetMonitoredItemList()
        {
            IList<Subscription> subscriptions = SubscriptionManager.GetSubscriptions(null);
            List<KeyValuePair<Subscription, string>> monitoredItemsList = new List<KeyValuePair<Subscription, string>>();

            foreach (Subscription subscription in subscriptions)
            {
                subscription.GetMonitoredItems(out uint[] serverHandles, out uint[] clientHandles);
          
                if (serverHandles.Length == 0)
                {
                    //Add node with empty value for Subscription without MonitoredItems
                    monitoredItemsList.Add(new KeyValuePair<Subscription, string>(subscription, null));
                }
                else
                {
                    foreach (uint hdl in serverHandles)
                    {
                        MonitoredItemHandle id = subscription.GetMonitoredItem(hdl);
                        monitoredItemsList.Add(new KeyValuePair<Subscription, string>(subscription, $"{id.NodeId.ToString()} ItemType: {id.ItemType.ToString()}"));
                    }
                }
            }
            return monitoredItemsList;
        }

        public uint GetMonitoredItemCount()
        {
            uint count = 0;
            IList<Subscription> subscriptions = SubscriptionManager.GetSubscriptions(null);
            foreach(Subscription subscription in subscriptions)
            {
                count += (uint)subscription.MonitoredItemCount;
            }
            return count;
        }


        protected override void OnRootNodeManagerStarted(RootNodeManager nodeManager)
        {
            new Demo.DemoNodeManager(this).Startup();

            new Demo.LargeArrayNodeManager(this).Startup();

            /// [Add IdentityValidationCompletedEventHandler]
            this.SessionManager.IdentityValidationCompleted += new IdentityValidationCompletedEventHandler(SessionManager_IdentityValidationCompleted);
            /// [Add IdentityValidationCompletedEventHandler]
        }

        /// [Add IdentityValidationCompletedEventHandler 2]
        private void SessionManager_IdentityValidationCompleted(Session session, ImpersonateEventArgs args)
        /// [Add IdentityValidationCompletedEventHandler 2]
        {
            /// [Username and password of local machine]
            UserNameIdentityToken userNameToken = args.NewIdentity as UserNameIdentityToken;
            if (userNameToken != null)
            {
                if (String.IsNullOrEmpty(userNameToken.UserName))
                {
                    return;
                }
           
                if (args.Identity == null || StatusCode.IsBad(args.IdentityValidationError))
                {
                    try
                    {
                        args.IdentityValidationError = LogonUser(userNameToken);
                        args.EffectiveIdentity = new UserIdentity(userNameToken);
                    }
                    catch (StatusException e)
                    {
                        args.IdentityValidationError = e.StatusCode;     
                    }
                }
                /// [Username and password of local machine]
                return;
            }
        }
       
        /// [Username and password of local machine 2]
        private static class Win32
        {
            [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern bool LogonUser(
                string lpszUsername,
                string lpszDomain,
                string lpszPassword,
                int dwLogonType,
                int dwLogonProvider,
                ref IntPtr phToken);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            public extern static bool CloseHandle(IntPtr handle);
        }

        /// <summary>
        /// Impersonates the windows user identified by the security token.
        /// </summary>
        private StatusCode LogonUser(UserNameIdentityToken identity)
        {
            IntPtr handle = IntPtr.Zero;

            const int LOGON32_PROVIDER_DEFAULT = 0;
            const int LOGON32_LOGON_NETWORK = 3;

            try
            {
                bool result = Win32.LogonUser(
                identity.UserName,
                String.Empty,
                identity.DecryptedPassword,
                LOGON32_LOGON_NETWORK,
                LOGON32_PROVIDER_DEFAULT,
                ref handle);

                if (!result)
                {
                    return StatusCodes.BadUserAccessDenied;
                }
                return StatusCodes.Good;
            }
            catch (Exception)
            {
                return StatusCodes.BadUserAccessDenied;
            }
            
        }
        /// [Username and password of local machine 2]

        public override void OnTrustListAddCertificate(object sender, CertificateAddedEventArgs e)
        {
            base.OnTrustListAddCertificate(sender, e);
            if (e.StatusCode.IsGood())
            {
                if (m_CertificateCalled != null)
                {
                    m_CertificateCalled(this, e);
                }
            }
        }

        /// <summary>
        /// Returns an instance of the FileBasedKeyCredentialStore.
        /// </summary>
        // [CreateKeyCredentialStore]
        protected override IKeyCredentialStore CreateKeyCredentialStore()
        {
            var settingsName = new XmlQualifiedName("KeyCredentialSettings", "http://unifiedAutomation.com/configuration/DemoServer");
            var config = Application.GetConfigurationExtension<FileBasedKeyCredentialStoreSettings>(true, settingsName);
            if (config?.FileName is string fileName)
            {
                fileName = FilePathUtils.GetAbsoluteFilePath(fileName, new FilePathSettings()
                {
                    SuppressExceptions = true,
                    ReturnValidButMissing = true,
                });

                return FileBasedKeyCredentialStore.FromFile(fileName);
            }
            else
            {
                return null;
            }
        }
        // [CreateKeyCredentialStore]

        /// <summary>
        /// Returns a handle for the query.
        /// </summary>
        protected override StatusCode GetQueryHandle(RequestContext context, ViewHandle viewHandle, out QueryHandle handle)
        {
            handle = new QueryHandle(this, RootNodeManager.CoreNodeManager, RootNodeManager.CoreNodeManager);
            return StatusCodes.Good;
        }

        /// <summary>
        /// A dummy implementation that returns an empty set and continuation point.
        /// </summary>
        public StatusCode BeginQuery(RequestContext context, QueryContinuationPoint continuationPoint, bool releaseContinuationPoint, QueryCompletedEventHandler callback, object callbackData)
        {
            var results = new ParsingResultCollection();
            bool errorsExist = false;

            for (int ii = 0; ii < continuationPoint.NodeTypes.Count; ii++)
            {
                var result = new ParsingResult();

                for (int jj = 0; jj < continuationPoint.NodeTypes[ii].DataToReturn.Count; jj++)
                {
                    if (continuationPoint.NodeTypes[ii].DataToReturn[jj].AttributeId < 1 || continuationPoint.NodeTypes[ii].DataToReturn[jj].AttributeId > Attributes.Last)
                    {
                        result.StatusCode = StatusCodes.BadAttributeIdInvalid;
                        result.DataStatusCodes.Add(StatusCodes.BadAttributeIdInvalid);
                        errorsExist = true;
                    }
                }

                results.Add(result);
            }

            ((QueryCompletedEventHandler)callback)(
                continuationPoint.QueryHandle,
                callbackData,
                new QueryDataSetCollection(),
                (releaseContinuationPoint) ? null : continuationPoint,
                (errorsExist) ? results : new ParsingResultCollection(),
                new ContentFilterResult(),
                false);

            return StatusCodes.Good;
        }
    }

}
