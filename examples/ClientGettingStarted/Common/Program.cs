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
using System.Configuration;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using UnifiedAutomation.UaBase;

namespace UnifiedAutomation.ClientGettingStarted
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // applications without a UnifiedAutomation license embedded as a resource will stop working after 1 hour.
                ApplicationLicenseManager.AddProcessLicenses(System.Reflection.Assembly.GetExecutingAssembly(), "UnifiedAutomation.ClientGettingStarted.License.License.lic");

                // start the application.
                /// [AutoCreateCertificate]
                ApplicationInstance.Default.AutoCreateCertificate = true;
                /// [AutoCreateCertificate]
                /// [CertificateNotFound]
                ApplicationInstance.Default.CertificateNotFound += new EventHandler<CreateCertificateEventArgs>(Application_CertificateNotFound);
                /// [CertificateNotFound]
                ApplicationInstance.Default.ConfigurationChanged += Application_ConfigurationChanged;
                ApplicationInstance.Default.Start(Program.Run, ApplicationInstance.Default);
            }
            catch (Exception e)
            {
                ExceptionDlg.ShowInnerException(null, e);
                return;
            }
        }

        /// <summary>
        /// Creates and shows the form.
        /// </summary>
        [STAThread]
        static void Run(object userState)
        {
            ApplicationInstance applicationInstance = userState as ApplicationInstance;
            System.Windows.Forms.Application.Run(new MainForm(applicationInstance));
        }

        /// [CertificateNotFound Callback]
        static private void Application_CertificateNotFound(object sender, CreateCertificateEventArgs e)
        {
            try
            {
                // let the application create a suitable default if no user interaction allowed.
                if (e.Silent)
                {
                    return;
                }

                CreateCertificateDialog dialog = new CreateCertificateDialog();

                ICertificate certificate = dialog.ShowDialog(null, new CreateCertificateDialogSettings()
                {
                    Application = e.Application,
                    Instructions = "The application does not have a certificate assigned.\r\nPlease specify the parameters for a new certificate."
                });

                if (certificate != null)
                {
                    e.NewCertificate = certificate;
                    e.UpdateConfiguration = dialog.PersistConfiguration;
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException("", exception);
            }
        }

        static private void Application_ConfigurationChanged(object sender, EventArgs e)
        {
            try
            {
                ApplicationInstance.Default.SaveConfiguration(false);
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException("", exception);
            }
        }
        /// [CertificateNotFound Callback]
    }
}
