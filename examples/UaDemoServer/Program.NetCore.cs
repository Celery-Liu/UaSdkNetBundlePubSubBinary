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
using UnifiedAutomation.UaPubSub;
using UnifiedAutomation.UaSchema;

namespace UnifiedAutomation.Sample
{
    static partial class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                // TraceSettings affect all applications in a process. The ApplyGlobalSettings gives developers control over the TraceSettings
                // independently from TraceSettings specified in ApplicationSettings for each Application running inside the process.
                // This is a useful feature when developing applications which are both Clients and Servers.
                // TraceBase.ApplyGlobalSettings(DefaultTraceSettings, true);

                // applications without a UnifiedAutomation license embedded as a resource will stop working after 1 hour.
                // developers can use the same mechanisms to license products they build with the UnifiedAutomation SDK.
                ApplicationLicenseManager.AddProcessLicenses(System.Reflection.Assembly.GetExecutingAssembly(), "License.lic");

                var application = new ApplicationInstanceBase();
                // Setting the SecurityProvider is required to be able to create certificates.
                application.SecurityProvider = new BouncyCastleSecurityProvider();

                // With the following method, the application uses an in-memory configuration instead of the app.config file.
                // If you enable this method, an existing app.config is ignored.
                ///ConfigureOpcUaApplicationFromCode(application);

                // setting this flag will create the certificate automatically if it does not already exist,
                // however, the process must be running with administrative privileges. If this flag is false
                // the certificate has to be created manually by another tool or by running this process once
                // with administrative privileges and the /install argument.
                application.AutoCreateCertificate = true;

                // PubSub
                application.PubSubConnectionProvider = new PubSubConnectionProvider()
                    .AddMqttUadpProfile()
                    .AddMqttJsonProfile();

                application.SecurityGroupProviderService = new UaClient.RemoteSecurityGroupProviderService();

                application.UntrustedCertificate += Application_UntrustedCertificate;
                application.CertificateNotFound += new EventHandler<CreateCertificateEventArgs>(Application_CertificateNotFound);

                var server = new TestServerManager();
                application.Start(server, Run, server);
            }
            catch (Exception exception)
            {
                PrintException(exception);
            }
        }

        private static void Application_UntrustedCertificate(object sender, UntrustedCertificateEventArgs e)
        {
            if (e.ValidationError == StatusCodes.BadCertificateUntrusted)
            {
                Console.WriteLine("Rejected certificate {0} added to {1}",
                    e.Certificate.ToString(),
                    e.Application.RejectedStore);
            }
        }

        [STAThread]
        static void Run(object state)
        {
            try
            {
                var server = (TestServerManager)state;

                // Set console title
                if (!String.IsNullOrEmpty(server.Application.ApplicationName))
                {
                    Console.Title = server.Application.ApplicationName;
                }                

                PrintEndpoints(server);

                Console.WriteLine("Press <enter> to exit the program.");
                Console.ReadLine();

                // Stop the server.
                Console.WriteLine("Stopping Server.");
                server.Stop();
            }
            catch (Exception exception)
            {
                PrintException(exception);
            }
        }

        private static void Application_CertificateNotFound(object sender, CreateCertificateEventArgs e)
        {
            Console.WriteLine($"Certificate with {e.Settings.SubjectName} could not be found.");
            if (e.Application.AutoCreateCertificate)
            {
                Console.WriteLine("Certificate will automatically be created");
            }
        }

        static void PrintException(Exception e)
        {
            Console.WriteLine("Exception occurred: {0}", e.Message);
        }

        /// <summary>
        /// Prints the available EndpointDescriptions to the command line.
        /// </summary>
        /// <param name="server"></param>
        static void PrintEndpoints(TestServerManager server)
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
