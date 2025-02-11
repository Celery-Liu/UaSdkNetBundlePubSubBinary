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

** This file is a modified, enhanced version or derived work of a file
** originally under MIT License of the OPC Foundation.
** Copyright (c) 2005-2009 The OPC Foundation, Inc. All rights reserved.
** The complete license agreement can be found here:
** http://opcfoundation.org/License/MIT/1.00/
******************************************************************************/

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using UnifiedAutomation.UaBase;

namespace UnifiedAutomation.Sample
{
#if NET
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
#endif
    /// <summary>
    /// Shows the URL for an endpoint.
    /// </summary>
    public partial class ShowEndpointUrlDlg : Form
    {
        #region Constructors
        /// <summary>
        /// Creates an empty form.
        /// </summary>
        public ShowEndpointUrlDlg()
        {
            InitializeComponent();
        }
        #endregion

        #region Public Interface
        /// <summary>
        /// Shows the dialog.
        /// </summary>
        public void ShowDialog(EndpointDescription endpoint)
        {
            EndpointUrlTB.Text = endpoint.EndpointUrl;
            base.ShowDialog();
        }
        #endregion
    }
}
