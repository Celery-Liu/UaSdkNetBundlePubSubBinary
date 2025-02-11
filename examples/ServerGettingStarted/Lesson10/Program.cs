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
namespace YourCompany.GettingStarted
{
    partial class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // The license file must be loaded from an embedded resource.
                ApplicationLicenseManager.AddProcessLicenses(typeof(Program).Assembly, "License.lic");

                // Start the server.
                Console.WriteLine("Starting Server.");
                GettingStartedServerManager server = new GettingStartedServerManager();

                ApplicationInstanceBase application;

#if NETFRAMEWORK
                application = ApplicationInstance.Default;
#else
                application = ApplicationInstanceBase.Default;
                ConfigureOpcUaApplicationFromCode();
                SetUserIdentityToServerSettings();
                SetUserManagementAtUserIdentity();
                SetGdsSettings();
                application.SecurityProvider = new BouncyCastleSecurityProvider();
#endif

                application.UntrustedCertificate += Application_UntrustedCertificate;

                // Set event handler for modifying the ApplicationSettings after loading.
                application.ApplicationSettingsLoaded += Application_ApplicationSettingsLoaded;

                application.AutoCreateCertificate = true;


#if GDS_PULL
                /// [GDS Pull]
                var gdsHandler = new UnifiedAutomation.UaClient.GdsPullManagement(application);
                gdsHandler.NewCertificate += (s, e) =>
                {
                    // The new certificate will be used by the server after the transport listeners have been re-initialized.
                    server.RestartTransportListeners();
                    Console.WriteLine("Certificate signed by GDS assigned. Restarting server.");
                };
                gdsHandler.ApplicationRegistered += (s, e) =>
                {
                    Console.WriteLine($"Application registered at GDS. ApplicationId {e.ApplicationId}, Mode {e.RegisteredApplicationMode}");
                    Console.WriteLine("Check if registration must be accepted in GDS Configuration Tool.");
                };
                gdsHandler.SignCertificateFailed += (s, e) => { Console.WriteLine($"Sign certificate failed with message {e.Exception}."); };
                gdsHandler.TrustListUpdated += (s, e) => { Console.WriteLine("TrustList updated"); };
                application.GdsHandler = gdsHandler;
                /// [GDS Pull]
#else
                /// [GDS Register]
                var gdsHandler = new UnifiedAutomation.UaClient.GdsRegisterManagement(application);
                gdsHandler.ApplicationRegistered += (s, e) =>
                {
                    Console.WriteLine($"Application registered at GDS. ApplicationId {e.ApplicationId}, Mode {e.RegisteredApplicationMode}.");
                    Console.WriteLine("Check if registration must be accepted in GDS Configuration Tool and GDS Model shall be changed to \"Push Model\".");
                };
                application.GdsHandler = gdsHandler;
                /// [GDS Register]
#endif
                gdsHandler.ConnectFailed += (s, e) => { Console.WriteLine($"Connecting to GDS failed with message {e.Exception.Message}."); };

                application.Start(server, null, server);

                PrintEndpoints(server);

                // Block until the server exits.
                Console.WriteLine("Press <enter> to exit the program.");
                Console.ReadLine();

                // Stop the server.
                Console.WriteLine("Stopping Server.");
                server.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
                Console.WriteLine("Press <enter> to exit the program.");
                Console.ReadLine();
            }
        }

        private static void Application_UntrustedCertificate(object sender, UntrustedCertificateEventArgs e)
        {
            Console.WriteLine("Untrusted Certificate: {0}, {1}", e.Certificate.CommonName, e.Certificate.SubjectName);
            Console.WriteLine("Move certificate {0} [{1}].der from {2}\\certs to {3}\\certs to accept",
                e.Certificate.CommonName,
                e.Certificate.Thumbprint,
                e.Application.RejectedStore.StorePath,
                e.Application.TrustedStore.StorePath);
        }

        /// <summary>
        /// Prints the available EndpointDescriptions to the command line.
        /// </summary>
        /// <param name="server"></param>
        static void PrintEndpoints(GettingStartedServerManager server)
        {
            // print the endpoints.
            Console.WriteLine(string.Empty);
            Console.WriteLine("Listening at the following endpoints:");

            foreach (EndpointDescription endpoint in server.Application.Endpoints)
            {
                StatusCode error = server.Application.GetEndpointStatus(endpoint);
                Console.WriteLine("   {0}: Status={1}", endpoint, error.ToString(true));
            }

            Console.WriteLine(string.Empty);
        }
    }
}
