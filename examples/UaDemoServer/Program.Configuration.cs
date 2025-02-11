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
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaSchema;

namespace UnifiedAutomation.Sample
{
    static partial class Program
    {
        static void ConfigureOpcUaApplicationFromCode(ApplicationInstanceBase applicationInstance)
        {
            // fill in the application settings in code
            // The configuration settings are typically provided by another module
            // of the application or loaded from a data base. In this example the
            // settings are hardcoded
            var config = new ConfigurationInMemory();

            string environmentPath = "%CommonApplicationData%";
            // override path for net core on non windows platform
            if (!PlatformUtils.IsWindows()) environmentPath = "%LocalApplicationData%";

            // ***********************************************************************
            // standard configuration options

            // general application identification settings
            config.ApplicationName = "UaServerNet@localhost";
            config.ApplicationUri = "urn:localhost:UnifiedAutomation:UaServerNet";
            config.ApplicationType = UnifiedAutomation.UaSchema.ApplicationType.Server_0;
            // configure certificate stores
            config.SetSecurity(PlatformUtils.CombinePath(environmentPath, "unifiedautomation", "UaSdkNet", "pkiserver"), "CN=UaServerNet/O=UnifiedAutomation/DC=localhost");

            // configure endpoints
            config.BaseAddresses = new UnifiedAutomation.UaSchema.ListOfBaseAddresses();
            config.BaseAddresses.Add("opc.tcp://localhost:48030");

            config.SecurityProfiles = new ListOfSecurityProfiles();
            config.SecurityProfiles.Add(new SecurityProfile() { ProfileUri = SecurityProfiles.Basic256Sha256, Enabled = true });
            config.SecurityProfiles.Add(new SecurityProfile() { ProfileUri = SecurityProfiles.Aes128Sha256RsaOaep, Enabled = true });
            config.SecurityProfiles.Add(new SecurityProfile() { ProfileUri = SecurityProfiles.Aes256Sha256RsaPss, Enabled = true });
            // This SecurityProfile is enabled for testing purposes. It shall NOT be enabled in end user products.
            config.SecurityProfiles.Add(new SecurityProfile() { ProfileUri = SecurityProfiles.None, Enabled = true });

            // ***********************************************************************
            // extended configuration options

            var endpointSettings = new EndpointSettings()
            {
                Endpoint = new UaSchema.EndpointConfiguration[]
                {
                    new UaSchema.EndpointConfiguration()
                    {
                        EndpointUrl = "opc.tcp://localhost:48030",
                        EnableSignOnly = true
                    }
                }
            };
            config.EndpointSettings = endpointSettings;

            // ***********************************************************************
            // trace settings

            TraceSettings trace = new TraceSettings();

            trace.MasterTraceEnabled = false;
            trace.DefaultTraceLevel = UnifiedAutomation.UaSchema.TraceLevel.Info;
            trace.TraceFile = PlatformUtils.CombinePath(environmentPath, "unifiedautomation", "logs", "UaSdkNet", "UaServerNet.log.txt");
            trace.MaxLogFileBackups = 3;

            trace.ModuleSettings = new ModuleTraceSettings[]
                {
                    new ModuleTraceSettings() { ModuleName = "UnifiedAutomation.Stack", TraceEnabled = true },
                    new ModuleTraceSettings() { ModuleName = "UnifiedAutomation.Server", TraceEnabled = true },
                };

            config.Set<TraceSettings>(trace);

            // ***********************************************************************
            // Installation settings

            InstallationSettings installation = new InstallationSettings();

            installation.GenerateCertificateIfNone = true;
            installation.CertificateKeyLength = 2048;
            installation.CertificateHashAlgorithm = "sha256";
            installation.DeleteCertificateOnUninstall = true;

            config.Set<InstallationSettings>(installation);

            var server = new UaSchema.ServerSettings()
            {
                ProductUri = "urn:UnifiedAutomation:UaServerNet",
                ProductName = "UnifiedAutomation UaServerNet",
                AvailableLocaleIds = new string[]
                {
                    "en-US",
                    "de-DE",
                    "fr-CA"
                },
                UserIdentity = new UserIdentitySettings()
                {
                    EnableAnonymous = true,
                    EnableUserName = true,
                    EnableCertificate = true,
                    UserTrustedCertificateStore = PlatformUtils.CombinePath(environmentPath, "unifiedautomation", "UaSdkNet", "pkiuser", "trusted"),
                    UserIssuerCertificateStore = PlatformUtils.CombinePath(environmentPath, "unifiedautomation", "UaSdkNet", "pkiuser", "issuers"),
                    UserRejectedCertificateStore = PlatformUtils.CombinePath(environmentPath, "unifiedautomation", "UaSdkNet", "pkiuser", "rejected"),
                    UserManagement = new UserManagementSettings()
                    {
                        FilePath = PlatformUtils.CombinePath(environmentPath, "unifiedautomation", "UaSdkNet", "Configuration", "DemoServerUserConfiguration.xml"),
                        PasswordOptions = (uint)(PasswordOptionsMask.SupportDescriptionForUser | PasswordOptionsMask.SupportDisableDeleteForUser ),
                        HashingAlgorithm = HashingAlgorithm.SHA512
                    }
                },
                DiscoveryRegistration = new DiscoveryRegistrationSettings()
                {
                    Enabled = false,
                    RegistrationInterval = 2
                },
                Capabilities = new string[]
                {
                    "DA",
                    "HD",
                    "AC",
                    "HE"
                },
                IsAuditActivated = true,
                RoleConfigurationsFilePath = PlatformUtils.CombinePath(environmentPath, "unifiedautomation", "UaSdkNet", "Configuration", "DemoServerRoleConfiguration.xml"),
                PublishSubscribe = new PubSubSettings()
                {
                    ConfigurationFile = PlatformUtils.CombinePath(environmentPath, "unifiedautomation", "UaSdkNet", "Configuration", "pubsub.uabinary")
                }
            };
            config.ServerSettings = server;

            var sessionSettings = new UaSchema.SessionSettings()
            {
                MaxOutstandingServiceRequests = 200,
                MaxNodesPerTranslateBrowsePathsToNodeIds = 5000
            };
            config.SessionSettings = sessionSettings;

            var subscription = new UaSchema.SubscriptionSettings()
            {
                MinPublishingInterval = 50,
                PublishingIntervalResolution = 50,
                MaxSubscriptionCount = 500,
                MaxSubscriptionsPerSession = 100,
                MaxNotificationsPerPublish = 25000,
                MaxMessageQueueSize = 100
            };
            config.SubscriptionSettings = subscription;

            config.TransportSettings = new TransportSettings()
            {
                SecurityTokenLifetime = 60000,
                InactiveChannelLifetime = 60000
            };

            // ***********************************************************************
            // set the configuration for the application (must be called before start to have any effect).
            // these settings are discarded if the /configFile flag is specified on the command line.

            applicationInstance.SetApplicationSettings(config);
        }
    }
}
