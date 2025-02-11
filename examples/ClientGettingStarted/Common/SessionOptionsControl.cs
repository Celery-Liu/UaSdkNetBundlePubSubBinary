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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;

namespace UnifiedAutomation.ClientGettingStarted.Common
{
    public partial class SessionOptionsControl : UserControl
    {
        public SessionOptionsControl()
        {
            InitializeComponent();
            string path = "file:///" + System.Environment.CurrentDirectory + @"\html\options.html";
            ConnectBrowser.Url = new Uri(path);

            m_info = new Info[]
            {
                new Info() { Button = BasicReadBTN, Type = typeof(BasicReadDlg), Handler = BasicReadBTN_Click },
                new Info() { Button = ReadAttributeBTN, Type = typeof(ReadAttributeDlg), Handler = ReadAttributeBTN_Click },
                new Info() { Button = ReadWithIndexRangeBTN, Type = typeof(ReadWithIndexRangeDlg), Handler = ReadWithIndexRangeBTN_Click },
                new Info() { Button = ReadWithDataEncodingBTN, Type = typeof(ReadWithDataEncodingDlg), Handler = ReadWithDataEncodingBTN_Click },
                new Info() { Button = ReadStructure, Type = typeof(ReadStructureDlg), Handler = ReadStructure_Click },
                new Info() { Button = BasicWriteBTN, Type = typeof(BasicWriteDlg), Handler = BasicWriteBTN_Click },
                new Info() { Button = BrowseBTN, Type = typeof(BrowseDlg), Handler = BrowseBTN_Click },
                new Info() { Button = TranslateBrowsePathBTN, Type = typeof(TranslateBrowsePathsDlg), Handler = TranslateBrowsePathBTN_Click },
                new Info() { Button = CallMethodBTN, Type = typeof(CallMethodDlg), Handler = CallMethodBTN_Click },
                new Info() { Button = HistoryReadRawBTN, Type = typeof(HistoryReadRawDlg), Handler = HistoryReadRawBTN_Click },
                new Info() { Button = HistoryReadProcessedBTN, Type = typeof(HistoryReadProcessedDlg), Handler = HistoryReadProcessedBTN_Click },
                new Info() { Button = HistoryReadEventsBTN, Type = typeof(HistoryReadEventsDlg), Handler = HistoryReadEventsBTN_Click },
            };
        }

        private Button m_selectedButton;
        private Info[] m_info;

        private class Info
        {
            public Button Button { get; set; }
            public Type Type { get; set; }
            public EventHandler Handler { get; set; }
        }

        private void ConnectCloseBTN_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            m_selectedButton = sender as Button;
            StartDemoButton.Visible = true;

            foreach (Info info in m_info.Where(i => i.Button == sender))
            {
                NameTextBox.Text = info.Button.Text;
                InstructionsLB.Text = ((MainForm)this.Parent).GetInstructions(info.Type);
            }
        }

        private void StartDemoButton_Click(object sender, EventArgs e)
        {
            foreach (Info info in m_info.Where(i => i.Button == m_selectedButton))
            {
                info.Handler(sender, e);
                break;
            }
        }

        private void BasicReadBTN_Click(object sender, EventArgs e)
        {
            try
            {
                BasicReadDlg dialog = new BasicReadDlg();
                dialog.Show(this.ParentForm as MainForm);
                dialog.BringToFront();
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void ReadAttributeBTN_Click(object sender, EventArgs e)
        {
            try
            {
                ReadAttributeDlg dialog = new ReadAttributeDlg();
                dialog.Show(this.ParentForm as MainForm);
                dialog.BringToFront();
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void ReadWithIndexRangeBTN_Click(object sender, EventArgs e)
        {
            try
            {
                ReadWithIndexRangeDlg dialog = new ReadWithIndexRangeDlg();
                dialog.Show(this.ParentForm as MainForm);
                dialog.BringToFront();
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void ReadWithDataEncodingBTN_Click(object sender, EventArgs e)
        {
            try
            {
                ReadWithDataEncodingDlg dialog = new ReadWithDataEncodingDlg();
                dialog.Show(this.ParentForm as MainForm);
                dialog.BringToFront();
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void ReadStructure_Click(object sender, EventArgs e)
        {
            try
            {
                ReadStructureDlg dialog = new ReadStructureDlg();
                dialog.Show(this.ParentForm as MainForm);
                dialog.BringToFront();
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void BasicWriteBTN_Click(object sender, EventArgs e)
        {
            try
            {
                BasicWriteDlg dialog = new BasicWriteDlg();
                dialog.Show(this.ParentForm as MainForm);
                dialog.BringToFront();
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void BrowseBTN_Click(object sender, EventArgs e)
        {
            try
            {
                BrowseDlg dialog = new BrowseDlg();
                dialog.Show(this.ParentForm as MainForm);
                dialog.BringToFront();
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void TranslateBrowsePathBTN_Click(object sender, EventArgs e)
        {
            try
            {
                TranslateBrowsePathsDlg dialog = new TranslateBrowsePathsDlg();
                dialog.Show(this.ParentForm as MainForm);
                dialog.BringToFront();
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void CallMethodBTN_Click(object sender, EventArgs e)
        {
            try
            {
                CallMethodDlg dialog = new CallMethodDlg();
                dialog.Show(this.ParentForm as MainForm);
                dialog.BringToFront();
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void HistoryReadRawBTN_Click(object sender, EventArgs e)
        {
            try
            {
                HistoryReadRawDlg dialog = new HistoryReadRawDlg();
                dialog.Show(this.ParentForm as MainForm);
                dialog.BringToFront();
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void HistoryReadProcessedBTN_Click(object sender, EventArgs e)
        {
            try
            {
                HistoryReadProcessedDlg dialog = new HistoryReadProcessedDlg();
                dialog.Show(this.ParentForm as MainForm);
                dialog.BringToFront();
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void HistoryReadEventsBTN_Click(object sender, EventArgs e)
        {
            try
            {
                HistoryReadEventsDlg dialog = new HistoryReadEventsDlg();
                dialog.Show(this.ParentForm as MainForm);
                dialog.BringToFront();
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void AddNodesBTN_Click(object sender, EventArgs e)
        {
            try
            {
                AddNodesDlg dialog = new AddNodesDlg();
                dialog.Show(this.ParentForm as MainForm);
                dialog.BringToFront();
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void AddReferencesBTN_Click(object sender, EventArgs e)
        {
            try
            {
                AddReferencesDlg dialog = new AddReferencesDlg();
                dialog.Show(this.ParentForm as MainForm);
                dialog.BringToFront();
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void DeleteNodesBTN_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteNodesDlg dialog = new DeleteNodesDlg();
                dialog.Show(this.ParentForm as MainForm);
                dialog.BringToFront();
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void DeleteReferencesBTN_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteReferencesDlg dialog = new DeleteReferencesDlg();
                dialog.Show(this.ParentForm as MainForm);
                dialog.BringToFront();
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void RegisterNodesBTN_Click(object sender, EventArgs e)
        {
            try
            {
                RegisterNodesDlg dialog = new RegisterNodesDlg();
                dialog.Show(this.ParentForm as MainForm);
                dialog.BringToFront();
            }
            catch (Exception exception)
            {
                ExceptionDlg.ShowInnerException(this.Text, exception);
            }
        }

        private void TopPN_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                NameTextBox.Text = "Click on the Buttons to the Left";
                InstructionsLB.Text = "These examples demonstrate how to do basic session operations with OPC UA servers.";
                StartDemoButton.Visible = false;
            }
        }

        private void WarningLB_Click(object sender, EventArgs e)
        {
            WarningLB.Visible = false;
        }

        private void Control_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                try
                {
                    Session session = ((MainForm)this.ParentForm).Session;
                    // TraceClient.Info("STATUS CHECK for {1}: ServerConnectionStatus={0}", session.ConnectionStatus, this.GetType().Name);
                    WarningLB.Visible = (session.ConnectionStatus != ServerConnectionStatus.Connected);
                    WarningLB.Text = String.Format(System.Globalization.CultureInfo.InvariantCulture, "Cannot connect to Server! ({0})", session.ConnectionStatus);
                }
                catch (Exception)
                {
                    // TraceClient.Error(exception, "WARNING DISPLAYED: Error checking server status.");
                    WarningLB.Visible = true;
                    WarningLB.Text = String.Format(System.Globalization.CultureInfo.InvariantCulture, "Cannot connect to Server! (Unknown)");
                }
            }
        }
    }
}
