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

namespace UnifiedAutomation.ClientGettingStarted
{
    partial class AdvancedConnectDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ColumnHeader EndpointUrlCH;
            this.UseAsynchCK = new System.Windows.Forms.CheckBox();
            this.EndpointsLV = new System.Windows.Forms.ListView();
            this.SecurityModeCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SecurityProfileCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TransportProfileUriCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TopPN = new System.Windows.Forms.Panel();
            this.HelpBTN = new System.Windows.Forms.Button();
            this.ShowCodeBTN = new System.Windows.Forms.Button();
            this.InstructionsLB = new System.Windows.Forms.Label();
            this.RequestGB = new System.Windows.Forms.GroupBox();
            this.MainPN = new System.Windows.Forms.TableLayoutPanel();
            this.ServerUrlTB = new System.Windows.Forms.TextBox();
            this.ServerUrlLB = new System.Windows.Forms.Label();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.InstructionsGB = new System.Windows.Forms.GroupBox();
            this.BottomPN = new System.Windows.Forms.Panel();
            this.DisconnectBTN = new System.Windows.Forms.Button();
            this.UseAsyncConnectCK = new System.Windows.Forms.CheckBox();
            this.ConnectBTN = new System.Windows.Forms.Button();
            this.GetEndpointsBTN = new System.Windows.Forms.Button();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ConnectionStateGB = new System.Windows.Forms.GroupBox();
            this.LabelEndpointUrl = new System.Windows.Forms.Label();
            this.LabelConnectionState = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.CallGetEndpointsGB = new System.Windows.Forms.GroupBox();
            this.ResponseGB = new System.Windows.Forms.GroupBox();
            EndpointUrlCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TopPN.SuspendLayout();
            this.RequestGB.SuspendLayout();
            this.MainPN.SuspendLayout();
            this.InstructionsGB.SuspendLayout();
            this.BottomPN.SuspendLayout();
            this.ConnectionStateGB.SuspendLayout();
            this.CallGetEndpointsGB.SuspendLayout();
            this.ResponseGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // EndpointUrlCH
            // 
            EndpointUrlCH.Text = "Endpoint URL";
            EndpointUrlCH.Width = 97;
            // 
            // UseAsynchCK
            // 
            this.UseAsynchCK.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.UseAsynchCK.AutoSize = true;
            this.UseAsynchCK.Location = new System.Drawing.Point(158, 38);
            this.UseAsynchCK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UseAsynchCK.Name = "UseAsynchCK";
            this.UseAsynchCK.Size = new System.Drawing.Size(225, 24);
            this.UseAsynchCK.TabIndex = 1;
            this.UseAsynchCK.Text = "Use Asynchronous Pattern";
            this.UseAsynchCK.UseVisualStyleBackColor = true;
            // 
            // EndpointsLV
            // 
            this.EndpointsLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            EndpointUrlCH,
            this.SecurityModeCH,
            this.SecurityProfileCH,
            this.TransportProfileUriCH});
            this.EndpointsLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndpointsLV.FullRowSelect = true;
            this.EndpointsLV.HideSelection = false;
            this.EndpointsLV.Location = new System.Drawing.Point(3, 22);
            this.EndpointsLV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EndpointsLV.MultiSelect = false;
            this.EndpointsLV.Name = "EndpointsLV";
            this.EndpointsLV.Size = new System.Drawing.Size(870, 274);
            this.EndpointsLV.TabIndex = 2;
            this.EndpointsLV.UseCompatibleStateImageBehavior = false;
            this.EndpointsLV.View = System.Windows.Forms.View.Details;
            this.EndpointsLV.DoubleClick += new System.EventHandler(this.EndpointsLV_DoubleClick);
            // 
            // SecurityModeCH
            // 
            this.SecurityModeCH.Text = "Security Mode";
            this.SecurityModeCH.Width = 103;
            // 
            // SecurityProfileCH
            // 
            this.SecurityProfileCH.Text = "Security Profile";
            this.SecurityProfileCH.Width = 118;
            // 
            // TransportProfileUriCH
            // 
            this.TransportProfileUriCH.Text = "Transport Profile Uri";
            this.TransportProfileUriCH.Width = 200;
            // 
            // TopPN
            // 
            this.TopPN.BackColor = System.Drawing.Color.Transparent;
            this.TopPN.Controls.Add(this.HelpBTN);
            this.TopPN.Controls.Add(this.ShowCodeBTN);
            this.TopPN.Controls.Add(this.InstructionsLB);
            this.TopPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopPN.Location = new System.Drawing.Point(4, 24);
            this.TopPN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TopPN.Name = "TopPN";
            this.TopPN.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TopPN.Size = new System.Drawing.Size(868, 96);
            this.TopPN.TabIndex = 2;
            // 
            // HelpBTN
            // 
            this.HelpBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HelpBTN.Location = new System.Drawing.Point(749, 54);
            this.HelpBTN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HelpBTN.Name = "HelpBTN";
            this.HelpBTN.Size = new System.Drawing.Size(112, 35);
            this.HelpBTN.TabIndex = 2;
            this.HelpBTN.Text = "Help";
            this.HelpBTN.UseVisualStyleBackColor = true;
            this.HelpBTN.Click += new System.EventHandler(this.HelpBTN_Click);
            // 
            // ShowCodeBTN
            // 
            this.ShowCodeBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowCodeBTN.Location = new System.Drawing.Point(749, 9);
            this.ShowCodeBTN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ShowCodeBTN.Name = "ShowCodeBTN";
            this.ShowCodeBTN.Size = new System.Drawing.Size(112, 35);
            this.ShowCodeBTN.TabIndex = 1;
            this.ShowCodeBTN.Text = "Show Code";
            this.ShowCodeBTN.UseVisualStyleBackColor = true;
            this.ShowCodeBTN.Click += new System.EventHandler(this.ShowCodeBTN_Click);
            // 
            // InstructionsLB
            // 
            this.InstructionsLB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstructionsLB.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.InstructionsLB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.InstructionsLB.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsLB.Location = new System.Drawing.Point(4, 5);
            this.InstructionsLB.Margin = new System.Windows.Forms.Padding(0);
            this.InstructionsLB.Name = "InstructionsLB";
            this.InstructionsLB.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InstructionsLB.Size = new System.Drawing.Size(741, 87);
            this.InstructionsLB.TabIndex = 0;
            this.InstructionsLB.Text = "<instructions>";
            // 
            // RequestGB
            // 
            this.RequestGB.Controls.Add(this.MainPN);
            this.RequestGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.RequestGB.Location = new System.Drawing.Point(0, 125);
            this.RequestGB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RequestGB.Name = "RequestGB";
            this.RequestGB.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RequestGB.Size = new System.Drawing.Size(876, 77);
            this.RequestGB.TabIndex = 21;
            this.RequestGB.TabStop = false;
            this.RequestGB.Text = "Get Endpoints Request";
            // 
            // MainPN
            // 
            this.MainPN.ColumnCount = 3;
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.Controls.Add(this.ServerUrlTB, 1, 0);
            this.MainPN.Controls.Add(this.ServerUrlLB, 0, 0);
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(4, 24);
            this.MainPN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MainPN.Name = "MainPN";
            this.MainPN.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MainPN.RowCount = 2;
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPN.Size = new System.Drawing.Size(868, 48);
            this.MainPN.TabIndex = 2;
            // 
            // ServerUrlTB
            // 
            this.ServerUrlTB.AllowDrop = true;
            this.MainPN.SetColumnSpan(this.ServerUrlTB, 2);
            this.ServerUrlTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerUrlTB.Location = new System.Drawing.Point(106, 10);
            this.ServerUrlTB.Margin = new System.Windows.Forms.Padding(2, 5, 2, 6);
            this.ServerUrlTB.Name = "ServerUrlTB";
            this.ServerUrlTB.Size = new System.Drawing.Size(756, 26);
            this.ServerUrlTB.TabIndex = 1;
            this.ToolTip.SetToolTip(this.ServerUrlTB, "The identifier for the node to browse.");
            // 
            // ServerUrlLB
            // 
            this.ServerUrlLB.AutoSize = true;
            this.ServerUrlLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerUrlLB.Location = new System.Drawing.Point(8, 5);
            this.ServerUrlLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ServerUrlLB.Name = "ServerUrlLB";
            this.ServerUrlLB.Size = new System.Drawing.Size(92, 37);
            this.ServerUrlLB.TabIndex = 0;
            this.ServerUrlLB.Text = "Server URL";
            this.ServerUrlLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.ServerUrlLB, " ");
            // 
            // CancelBTN
            // 
            this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBTN.Location = new System.Drawing.Point(759, 5);
            this.CancelBTN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(112, 35);
            this.CancelBTN.TabIndex = 2;
            this.CancelBTN.Text = "Close";
            this.CancelBTN.UseVisualStyleBackColor = true;
            // 
            // InstructionsGB
            // 
            this.InstructionsGB.BackColor = System.Drawing.Color.Transparent;
            this.InstructionsGB.Controls.Add(this.TopPN);
            this.InstructionsGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.InstructionsGB.Location = new System.Drawing.Point(0, 0);
            this.InstructionsGB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InstructionsGB.Name = "InstructionsGB";
            this.InstructionsGB.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InstructionsGB.Size = new System.Drawing.Size(876, 125);
            this.InstructionsGB.TabIndex = 20;
            this.InstructionsGB.TabStop = false;
            this.InstructionsGB.Text = "Instructions";
            // 
            // BottomPN
            // 
            this.BottomPN.Controls.Add(this.DisconnectBTN);
            this.BottomPN.Controls.Add(this.UseAsyncConnectCK);
            this.BottomPN.Controls.Add(this.ConnectBTN);
            this.BottomPN.Controls.Add(this.CancelBTN);
            this.BottomPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPN.Location = new System.Drawing.Point(0, 704);
            this.BottomPN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BottomPN.Name = "BottomPN";
            this.BottomPN.Size = new System.Drawing.Size(876, 45);
            this.BottomPN.TabIndex = 19;
            // 
            // DisconnectBTN
            // 
            this.DisconnectBTN.Location = new System.Drawing.Point(126, 5);
            this.DisconnectBTN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DisconnectBTN.Name = "DisconnectBTN";
            this.DisconnectBTN.Size = new System.Drawing.Size(112, 35);
            this.DisconnectBTN.TabIndex = 25;
            this.DisconnectBTN.Text = "Disconnect";
            this.DisconnectBTN.UseVisualStyleBackColor = true;
            this.DisconnectBTN.Click += new System.EventHandler(this.DisconnectBTN_Click_1);
            // 
            // UseAsyncConnectCK
            // 
            this.UseAsyncConnectCK.AutoSize = true;
            this.UseAsyncConnectCK.Location = new System.Drawing.Point(248, 11);
            this.UseAsyncConnectCK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UseAsyncConnectCK.Name = "UseAsyncConnectCK";
            this.UseAsyncConnectCK.Size = new System.Drawing.Size(225, 24);
            this.UseAsyncConnectCK.TabIndex = 24;
            this.UseAsyncConnectCK.Text = "Use Asynchronous Pattern";
            this.UseAsyncConnectCK.UseVisualStyleBackColor = true;
            // 
            // ConnectBTN
            // 
            this.ConnectBTN.Location = new System.Drawing.Point(4, 5);
            this.ConnectBTN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ConnectBTN.Name = "ConnectBTN";
            this.ConnectBTN.Size = new System.Drawing.Size(112, 35);
            this.ConnectBTN.TabIndex = 3;
            this.ConnectBTN.Text = "Connect";
            this.ConnectBTN.UseVisualStyleBackColor = true;
            this.ConnectBTN.Click += new System.EventHandler(this.ConnectBTN_Click);
            // 
            // GetEndpointsBTN
            // 
            this.GetEndpointsBTN.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.GetEndpointsBTN.Location = new System.Drawing.Point(9, 29);
            this.GetEndpointsBTN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GetEndpointsBTN.Name = "GetEndpointsBTN";
            this.GetEndpointsBTN.Size = new System.Drawing.Size(123, 40);
            this.GetEndpointsBTN.TabIndex = 0;
            this.GetEndpointsBTN.Text = "Get Endpoints";
            this.GetEndpointsBTN.UseVisualStyleBackColor = true;
            this.GetEndpointsBTN.Click += new System.EventHandler(this.GetEndpointsBTN_Click);
            // 
            // ConnectionStateGB
            // 
            this.ConnectionStateGB.Controls.Add(this.LabelEndpointUrl);
            this.ConnectionStateGB.Controls.Add(this.LabelConnectionState);
            this.ConnectionStateGB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ConnectionStateGB.Location = new System.Drawing.Point(0, 584);
            this.ConnectionStateGB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ConnectionStateGB.Name = "ConnectionStateGB";
            this.ConnectionStateGB.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ConnectionStateGB.Size = new System.Drawing.Size(876, 120);
            this.ConnectionStateGB.TabIndex = 23;
            this.ConnectionStateGB.TabStop = false;
            this.ConnectionStateGB.Text = "Connection State";
            // 
            // LabelEndpointUrl
            // 
            this.LabelEndpointUrl.AutoSize = true;
            this.LabelEndpointUrl.Location = new System.Drawing.Point(14, 78);
            this.LabelEndpointUrl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelEndpointUrl.Name = "LabelEndpointUrl";
            this.LabelEndpointUrl.Size = new System.Drawing.Size(93, 20);
            this.LabelEndpointUrl.TabIndex = 1;
            this.LabelEndpointUrl.Text = "EndpointUrl";
            // 
            // LabelConnectionState
            // 
            this.LabelConnectionState.AutoSize = true;
            this.LabelConnectionState.Location = new System.Drawing.Point(14, 38);
            this.LabelConnectionState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelConnectionState.Name = "LabelConnectionState";
            this.LabelConnectionState.Size = new System.Drawing.Size(87, 20);
            this.LabelConnectionState.TabIndex = 0;
            this.LabelConnectionState.Text = "Connected";
            // 
            // CallGetEndpointsGB
            // 
            this.CallGetEndpointsGB.Controls.Add(this.GetEndpointsBTN);
            this.CallGetEndpointsGB.Controls.Add(this.UseAsynchCK);
            this.CallGetEndpointsGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.CallGetEndpointsGB.Location = new System.Drawing.Point(0, 202);
            this.CallGetEndpointsGB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CallGetEndpointsGB.Name = "CallGetEndpointsGB";
            this.CallGetEndpointsGB.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CallGetEndpointsGB.Size = new System.Drawing.Size(876, 83);
            this.CallGetEndpointsGB.TabIndex = 24;
            this.CallGetEndpointsGB.TabStop = false;
            this.CallGetEndpointsGB.Text = "Call Get Endpoints";
            // 
            // ResponseGB
            // 
            this.ResponseGB.Controls.Add(this.EndpointsLV);
            this.ResponseGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResponseGB.Location = new System.Drawing.Point(0, 285);
            this.ResponseGB.Name = "ResponseGB";
            this.ResponseGB.Size = new System.Drawing.Size(876, 299);
            this.ResponseGB.TabIndex = 25;
            this.ResponseGB.TabStop = false;
            this.ResponseGB.Text = "Get Endpoints Response";
            // 
            // AdvancedConnectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 749);
            this.Controls.Add(this.ResponseGB);
            this.Controls.Add(this.ConnectionStateGB);
            this.Controls.Add(this.BottomPN);
            this.Controls.Add(this.CallGetEndpointsGB);
            this.Controls.Add(this.RequestGB);
            this.Controls.Add(this.InstructionsGB);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AdvancedConnectDialog";
            this.Text = "Advanced Connect";
            this.TopPN.ResumeLayout(false);
            this.RequestGB.ResumeLayout(false);
            this.MainPN.ResumeLayout(false);
            this.MainPN.PerformLayout();
            this.InstructionsGB.ResumeLayout(false);
            this.BottomPN.ResumeLayout(false);
            this.BottomPN.PerformLayout();
            this.ConnectionStateGB.ResumeLayout(false);
            this.ConnectionStateGB.PerformLayout();
            this.CallGetEndpointsGB.ResumeLayout(false);
            this.CallGetEndpointsGB.PerformLayout();
            this.ResponseGB.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox UseAsynchCK;
        private System.Windows.Forms.ListView EndpointsLV;
        private System.Windows.Forms.ColumnHeader SecurityModeCH;
        private System.Windows.Forms.ColumnHeader SecurityProfileCH;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Button HelpBTN;
        private System.Windows.Forms.Button ShowCodeBTN;
        private System.Windows.Forms.Label InstructionsLB;
        private System.Windows.Forms.GroupBox RequestGB;
        private System.Windows.Forms.TableLayoutPanel MainPN;
        private System.Windows.Forms.TextBox ServerUrlTB;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Label ServerUrlLB;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.GroupBox InstructionsGB;
        private System.Windows.Forms.Panel BottomPN;
        private System.Windows.Forms.Button GetEndpointsBTN;
        private System.Windows.Forms.GroupBox ConnectionStateGB;
        private System.Windows.Forms.Label LabelConnectionState;
        private System.Windows.Forms.CheckBox UseAsyncConnectCK;
        private System.Windows.Forms.Button ConnectBTN;
        private System.Windows.Forms.ColumnHeader TransportProfileUriCH;
        private System.Windows.Forms.Button DisconnectBTN;
        private System.Windows.Forms.Label LabelEndpointUrl;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox CallGetEndpointsGB;
        private System.Windows.Forms.GroupBox ResponseGB;
    }
}