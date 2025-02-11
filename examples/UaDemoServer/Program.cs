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

// uncomment this line to enable a wrapper that can be used to debug a service.
// #define ENABLE_SERVICE_DEBUGGING

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.IO;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaServer;
#if !NET35 && !NET40 && !NET45
using UnifiedAutomation.UaPubSub;
#endif

namespace UnifiedAutomation.Sample
{
#if NET
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
#endif
    static partial class Program
    {
        /// <summary>
        /// The default trace settings
        /// </summary>
        static readonly UaSchema.TraceSettings DefaultTraceSettings = new UaSchema.TraceSettings()
        {
            MasterTraceEnabled = true,
            DefaultTraceLevel = UaSchema.TraceLevel.Info,
            ModuleSettings = new UaSchema.ModuleTraceSettings[]
            {
                new UaSchema.ModuleTraceSettings() { ModuleName = "UnifiedAutomation.Stack", TraceEnabled = true, TraceLevel = UaSchema.TraceLevel.Info },
                new UaSchema.ModuleTraceSettings() { ModuleName = "UnifiedAutomation.Client", TraceEnabled = true, TraceLevel = UaSchema.TraceLevel.Info },
                new UaSchema.ModuleTraceSettings() { ModuleName = "UnifiedAutomation.Server", TraceEnabled = true, TraceLevel = UaSchema.TraceLevel.Info }
            }
        };

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
#if ENABLE_SERVICE_DEBUGGING

        [STAThread]
        static void Main()
        {
            if (!Environment.UserInteractive)
            {
                System.ServiceProcess.ServiceBase.Run(new WindowsService());
                return;
            }

            WrappedMain();
        }

        static void WrappedMain()
#else

        [STAThread]
        static void Main()

#endif
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // TraceSettings affect all applications in a process. The ApplyGlobalSettings gives developers control over the TraceSettings
                // independently from TraceSettings specified in ApplicationSettings for each Application running inside the process.
                // This is a useful feature when developing applications which are both Clients and Servers.
                // TraceBase.ApplyGlobalSettings(DefaultTraceSettings, true);

                // applications without a UnifiedAutomation license embedded as a resource will stop working after 1 hour.
                // developers can use the same mechanisms to license products they build with the UnifiedAutomation SDK.
                ApplicationLicenseManager.AddProcessLicenses(System.Reflection.Assembly.GetExecutingAssembly(), "License.lic");

                var application = new ApplicationInstance();

                // With the following method, the application uses an in-memory configuration instead of the app.config file.
                // If you enable this method, an existing app.config is ignored.
                ///ConfigureOpcUaApplicationFromCode(application);

                // Setting this flag will create the certificate automatically if it does not already exist,
                // however, the process must be running with administrative privileges. If this flag is false
                // the certificate has to be created manually by another tool or by running this process once
                // with administrative privileges and the /install argument.
                application.AutoCreateCertificate = true;

                // To activate pub-sub support, a pub-sub connection provider is assigned to the application instance.
                // The server will then add the PublishSubscribe object to the Server object.
                /// [AssignPubSubConnectionProvider]
                application.PubSubConnectionProvider = new PubSubConnectionProvider()
                    .AddMqttJsonProfile()
                    .AddMqttUadpProfile();

                /// [AssignPubSubConnectionProvider]

                /// [AssignSecurityGroupProviderService]
                application.SecurityGroupProviderService = new UaClient.RemoteSecurityGroupProviderService();
                /// [AssignSecurityGroupProviderService]

                application.CertificateNotFound += new EventHandler<CreateCertificateEventArgs>(Application_CertificateNotFound);
                application.ConfigurationChanged += new EventHandler(Application_ConfigurationChanged);

                var server = new TestServerManager();
                application.Start(server, Run, server);
            }
            catch (Exception e)
            {
                if (Environment.UserInteractive)
                {
                    ExceptionDlg.Show("Error starting UaServerNET.", e);
                }
            }
        }

        [STAThread]
        static void Run(object state)
        {
            try
            {
                var server = (TestServerManager)state;

                if (System.Environment.UserInteractive)
                {
                    System.Windows.Forms.Application.Run(new MainForm(server));
                }
                else
                {
                    NotifyIcon trayIcon = new NotifyIcon();
                    trayIcon.Icon = GuiUtils.GetAppIcon();
                    trayIcon.Visible = true;
                    
                    ContextMenuStrip contextMenu = new ContextMenuStrip();
                    contextMenu.Items.Add("Shutdown Server", null, OnShutdown);
                    
                    trayIcon.ContextMenuStrip = contextMenu;
                    
                    System.Windows.Forms.Application.Run();
                }
            }
            catch (Exception e)
            {
                if (System.Environment.UserInteractive)
                {
                    ExceptionDlg.Show("Error starting UaServerNET.", e);
                }
            }
        }
        static void OnShutdown(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private static void Application_ConfigurationChanged(object sender, EventArgs e)
        {
            try
            {
                var application = (ApplicationInstanceBase)sender;

                // Do not store the Thumbprint of the ApplicationInstance certificate.
                // If the server is managed by a GDS, the thumbprint may only be saved in the install process if the application
                // has access rights to write configurtion also when running normally.
                application.ApplicationSettings.ApplicationCertificate.Thumbprint = null;

                application.SaveConfiguration(false);
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(null, exception);
            }
        }

        private static void Application_CertificateNotFound(object sender, CreateCertificateEventArgs e)
        {
            try
            {
                // let the application create a suitablable default if no user interaction allowed.
                if (e.Silent || !Environment.UserInteractive)
                {
                    return;
                }

                CreateCertificateDialog dialog = new CreateCertificateDialog();

                var settings = new CreateCertificateDialogSettings()
                {
                    Application = e.Application,
                    StorePath = (e.Settings != null) ? e.Settings.StorePath : null,
                    Instructions = "The application does not have a certificate assigned.\r\nPlease specify the parameters for a new certificate.",
                    SubjectName = (e.Settings != null) ? e.Settings.SubjectName : null,
                    DomainNames = e.DomainNames
                };

                ICertificate certificate = dialog.ShowDialog(settings);

                if (certificate != null)
                {
                    e.NewCertificate = certificate;
                    e.UpdateConfiguration = dialog.PersistConfiguration;
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show("Missing Application Certificate", exception);
            }
        }

#if ENABLE_SERVICE_DEBUGGING

        /// <summary>
        /// A wrapper that launches a service and then waits for the debugger to attach before executing the application code.
        /// </summary>
        public class WindowsService : System.ServiceProcess.ServiceBase
        {
            #region Constructors
            public WindowsService()
            {
            }
            #endregion

            #region Overridden Methods
            /// <summary>
            /// Starts the server in a background thread.
            /// </summary>
            protected override void OnStart(string[] args)
            {
                System.Threading.Thread thread = new System.Threading.Thread(OnBackgroundStart);
                thread.IsBackground = true;
                thread.Start(null);
            }

            /// <summary>
            /// Stops the server so the service can shutdown.
            /// </summary>
            protected override void OnStop()
            {
            }
            #endregion

            #region Private Methods
            /// <summary>
            /// Runs the service in a background thread.
            /// </summary>
            private void OnBackgroundStart(object state)
            {
                try
                {
                    while (!System.Diagnostics.Debugger.IsAttached)
                    {
                        System.Threading.Thread.Sleep(1000);
                    }

                    System.Threading.Thread.Sleep(10000);

                    Program.WrappedMain();
                }
                catch (Exception e)
                {
                    StatusCode error = new StatusCode(e, StatusCodes.BadConfigurationError, "Could not start UA Service.");
                    this.EventLog.WriteEntry(error.Message, System.Diagnostics.EventLogEntryType.Error);
                    TraceStack.Error(error);
                }
            }
            #endregion

            #region Private Fields
            #endregion
        }

#endif

    }
}
