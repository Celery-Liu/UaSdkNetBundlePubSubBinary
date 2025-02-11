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
using System.IO;
using System.Windows.Forms;
using UnifiedAutomation.UaBase;

namespace UnifiedAutomation.ClientGettingStarted
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
            Icon = GuiUtils.GetDefaultIcon();
        }

        public void Show(string filePath)
        {
            filePath = @"..\doc\html\" + filePath;

            FileInfo fileInfo = new FileInfo(filePath);

            int count = 0;
            DirectoryInfo directory = fileInfo.Directory;

            while (directory != null)
            {
                directory = directory.Parent;
                count++;
            }

            WebBrowser.Url = null;

            for (int ii = 0; ii < count; ii++)
            {
                if (fileInfo.Exists)
                {
                    WebBrowser.Url = new Uri(fileInfo.FullName);
                    break;
                }

                filePath = @"..\" + filePath;
                fileInfo = new FileInfo(filePath);
            }

            base.Show();
        }
    }
}
