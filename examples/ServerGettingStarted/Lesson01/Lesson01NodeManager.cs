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
using UnifiedAutomation.UaServer;

namespace YourCompany.GettingStarted
{
    internal class Lesson01NodeManager : BaseNodeManager
    {
        /// <summary>
        /// Called when the node manager is started.
        /// </summary>
        /// [Set Namespace URI]
        public override void Startup()
        {
            try
            {
                Console.WriteLine("Starting Lesson01NodeManager.");

                base.Startup();

                AddNamespaceUri("http://yourorganisation.com/lesson01/");

                // TBD
            }
        /// [Set Namespace URI]
            catch (Exception e)
            {
                Console.WriteLine("Failed to start Lesson01NodeManager " + e.Message);
            }
        }

        /// <summary>
        /// Called when the node manager is stopped.
        /// </summary>
        public override void Shutdown()
        {
            try
            {
                Console.WriteLine("Stopping Lesson01NodeManager.");

                // TBD 

                base.Shutdown();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to stop Lesson01NodeManager " + e.Message);
            }
        }

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Lesson01NodeManager(ServerManager server) : base(server)
        {
        }
        #endregion

        #region IDisposable
        /// <summary>
        /// An overrideable version of the Dispose.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // TBD
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Private Fields
        #endregion
    }
}
