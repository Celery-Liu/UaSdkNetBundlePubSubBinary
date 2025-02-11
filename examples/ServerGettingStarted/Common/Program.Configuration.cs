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
/// [Configuration Options 1]
using UnifiedAutomation.UaSchema;
/// [Configuration Options 1]
namespace YourCompany.GettingStarted
{
    partial class Program
    {
        /// [Configuration Options 2]
        static void ConfigureOpcUaApplicationFromCode()
        {
            // fill in the application settings in code
            // The configuration settings are typically provided by another module
            // of the application or loaded from a data base. In this example the
            // settings are hardcoded
            var configuration = new ConfigurationInMemory();

            string environmentPath = "%CommonApplicationData%";
            // override path for net core on non windows platform
            if (!PlatformUtils.IsWindows()) environmentPath = "%LocalApplicationData%";

            // ***********************************************************************
            // standard configuration options

            // general application identification settings
            configuration.ApplicationName = "UnifiedAutomation GettingStartedServer";
            configuration.ApplicationUri = "urn:localhost:UnifiedAutomation:GettingStartedServer";
            configuration.ApplicationType = UnifiedAutomation.UaSchema.ApplicationType.Server_0;
            configuration.ProductName = "UnifiedAutomation GettingStartedServer";

            // configure application certificate and paths to the certificate stores
            configuration.SetSecurity(PlatformUtils.CombinePath(environmentPath, "unifiedautomation", "UaSdkNet", "pki"), "CN=GettingStartedServer/O=UnifiedAutomation/DC=localhost");

            // configure endpoints
            configuration.BaseAddresses = new UnifiedAutomation.UaSchema.ListOfBaseAddresses();
            configuration.BaseAddresses.Add("opc.tcp://localhost:48030");

            configuration.SecurityProfiles = new ListOfSecurityProfiles();
            configuration.SecurityProfiles.Add(new SecurityProfile() { ProfileUri = SecurityProfiles.Basic256Sha256, Enabled = true });
            configuration.SecurityProfiles.Add(new SecurityProfile() { ProfileUri = SecurityProfiles.Aes128Sha256RsaOaep, Enabled = true });
            configuration.SecurityProfiles.Add(new SecurityProfile() { ProfileUri = SecurityProfiles.Aes256Sha256RsaPss, Enabled = true });
            // This SecurityProfile is enabled for testing purposes. It shall NOT be enabled in end user products.
            configuration.SecurityProfiles.Add(new SecurityProfile() { ProfileUri = SecurityProfiles.None, Enabled = true });

            // ***********************************************************************
            // extended configuration options

            // trace settings
            TraceSettings trace = new TraceSettings();

            trace.MasterTraceEnabled = false;
            trace.DefaultTraceLevel = UnifiedAutomation.UaSchema.TraceLevel.Info;
            trace.TraceFile = PlatformUtils.CombinePath(environmentPath, "unifiedautomation", "UaSdkNet", "logs", FilePathUtils.MakeValidFileName(configuration.ApplicationName) + ".log.txt");
            trace.MaxLogFileBackups = 3;

            trace.ModuleSettings = new ModuleTraceSettings[]
                {
                    new ModuleTraceSettings() { ModuleName = "UnifiedAutomation.Stack", TraceEnabled = true },
                    new ModuleTraceSettings() { ModuleName = "UnifiedAutomation.Server", TraceEnabled = true },
                };

            configuration.Set<TraceSettings>(trace);

            // Installation settings
            InstallationSettings installation = new InstallationSettings();

            installation.GenerateCertificateIfNone = true;
            installation.DeleteCertificateOnUninstall = true;

            configuration.Set<InstallationSettings>(installation);

            configuration.ServerSettings = new ServerSettings()
            {
                ProductName = "UnifiedAutomation GettingStartedServer",
                DiscoveryRegistration = new DiscoveryRegistrationSettings()
                {
                    Enabled = false
                },
                Capabilities = new string[]
                {
                    "DA"
                },
                ProductUri  = "urn:unifiedautomation.gettingstarted"
            };

            // ***********************************************************************
            // set the configuration for the application (must be called before start to have any effect).
            // these settings are discarded if the /configFile flag is specified on the command line.
            ApplicationInstanceBase.Default.SetApplicationSettings(configuration);
        }
        /// [Configuration Options 2]

        /// <summary>
        /// Disables the SecurityProfiles.Aes256Sha256RsaPss if the SecurityProvider does not support it.
        /// </summary>
        /// <remarks>
        /// The SecurityProfiles.Aes256Sha256RsaPss is supported in UnifiedAutomation assemblies built
        /// with .NET Framework 4.8 and .NET standard.
        /// </remarks>
        private static void Application_ApplicationSettingsLoaded(object sender, EventArgs e)
        {
            ApplicationInstanceBase application = sender as ApplicationInstanceBase;
            ISecurityProvider securityProvider = application.SecurityProvider;
            try
            {
                using (var cryptoProvider = securityProvider.CreateCryptoProvider(
                    new CryptoProviderSettings()
                    {
                        SecurityProfileUri = SecurityProfiles.Aes256Sha256RsaPss
                    }))
                {
                }
            }
            catch (Exception)
            {
                application.ApplicationSettings.SecurityProfiles[2].Enabled = false;
            }
        }


        static void SetUserIdentityToServerSettings()
        {
            var application = ApplicationInstanceBase.Default.ApplicationSettings;

            application.ServerSettings.UserIdentity = new UserIdentitySettings()
            {
                EnableAnonymous = true,
                EnableUserName = true
            };
        }

        static void SetUserManagementAtUserIdentity()
        {
            var application = ApplicationInstanceBase.Default.ApplicationSettings;

            if (application.ServerSettings.UserIdentity != null)
            {
                application.ServerSettings.UserIdentity.UserManagement = new UserManagementSettings()
                {
                    FilePath = "UaGettingStartedUserConfiguration.xml",
                    PasswordOptions = (uint)PasswordOptionsMask.SupportDescriptionForUser,
                    MinPasswordLength = 3
                };
            }

        }

        static void SetGdsSettings()
        {
            var application = ApplicationInstanceBase.Default.ApplicationSettings;

            application.Set<GdsSettings>(new GdsSettings()
            {
                GdsDiscoveryUrl = "opc.tcp://localhost:48060"
            });
        }
    }
}
