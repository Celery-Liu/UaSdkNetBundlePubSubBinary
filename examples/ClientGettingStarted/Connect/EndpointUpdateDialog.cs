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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UnifiedAutomation.UaClient;
using UnifiedAutomation.UaBase;

namespace UnifiedAutomation.ClientGettingStarted
{
    public partial class EndpointUpdateDialog : Form
    {
        public EndpointUpdateDialog()
        {
            InitializeComponent();
            Icon = GuiUtils.GetDefaultIcon();
        }

        public void ShowDialog(Session sender, UpdateEndpointEventArgs e)
        {
            textBoxDiscoveryUrl.Text = e.DiscoveryUrl.ToString();
            textBoxEndpointUrl.Text = e.SelectedEndpoint.EndpointUrl;
            ShowDialog();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonAbort_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        public string EndpointUrl
        {
            get
            {
                return textBoxEndpointUrl.Text;
            }
        }

        public bool UseDnsNameAndPortFromDiscoveryUrl
        {
            get
            {
                return UseDns.Checked;
            }
        }
    }
}
