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
    partial class SimpleConnectDlg
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
            this.SimpleConnectBTN = new System.Windows.Forms.Button();
            this.TopPN = new System.Windows.Forms.Panel();
            this.HelpBTN = new System.Windows.Forms.Button();
            this.ShowCodeBTN = new System.Windows.Forms.Button();
            this.InstructionsLB = new System.Windows.Forms.Label();
            this.InstructionsGB = new System.Windows.Forms.GroupBox();
            this.UseAsynchCK = new System.Windows.Forms.CheckBox();
            this.BottomPN = new System.Windows.Forms.Panel();
            this.DisconnectBTN = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ServerUrlLB = new System.Windows.Forms.Label();
            this.EndpointUrlTB = new System.Windows.Forms.TextBox();
            this.ArgumentsGB = new System.Windows.Forms.GroupBox();
            this.MainPN = new System.Windows.Forms.TableLayoutPanel();
            this.SecurityBox = new System.Windows.Forms.CheckBox();
            this.UseDnsNameAndPortFromDiscoveryUrlBox = new System.Windows.Forms.CheckBox();
            this.EnableUpdateEndpointEventHandler = new System.Windows.Forms.CheckBox();
            this.ConnectionStateGB = new System.Windows.Forms.GroupBox();
            this.MessageSecurityModeLabel = new System.Windows.Forms.Label();
            this.EnpointUrlLabel = new System.Windows.Forms.Label();
            this.LabelConnectionState = new System.Windows.Forms.Label();
            this.SessionGB = new System.Windows.Forms.GroupBox();
            this.MiddlePN = new System.Windows.Forms.Panel();
            this.TopPN.SuspendLayout();
            this.InstructionsGB.SuspendLayout();
            this.BottomPN.SuspendLayout();
            this.ArgumentsGB.SuspendLayout();
            this.MainPN.SuspendLayout();
            this.ConnectionStateGB.SuspendLayout();
            this.SessionGB.SuspendLayout();
            this.MiddlePN.SuspendLayout();
            this.SuspendLayout();
            // 
            // SimpleConnectBTN
            // 
            this.SimpleConnectBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SimpleConnectBTN.Location = new System.Drawing.Point(4, 5);
            this.SimpleConnectBTN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SimpleConnectBTN.Name = "SimpleConnectBTN";
            this.SimpleConnectBTN.Size = new System.Drawing.Size(141, 35);
            this.SimpleConnectBTN.TabIndex = 0;
            this.SimpleConnectBTN.Text = "Simple Connect";
            this.SimpleConnectBTN.UseVisualStyleBackColor = true;
            this.SimpleConnectBTN.Click += new System.EventHandler(this.SimpleConnectBTN_Click);
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
            this.TopPN.Size = new System.Drawing.Size(838, 98);
            this.TopPN.TabIndex = 2;
            // 
            // HelpBTN
            // 
            this.HelpBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HelpBTN.Location = new System.Drawing.Point(719, 54);
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
            this.ShowCodeBTN.Location = new System.Drawing.Point(719, 9);
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
            this.InstructionsLB.Size = new System.Drawing.Size(711, 89);
            this.InstructionsLB.TabIndex = 0;
            this.InstructionsLB.Text = "<instructions>";
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
            this.InstructionsGB.Size = new System.Drawing.Size(846, 127);
            this.InstructionsGB.TabIndex = 20;
            this.InstructionsGB.TabStop = false;
            this.InstructionsGB.Text = "Instructions";
            // 
            // UseAsynchCK
            // 
            this.UseAsynchCK.AutoSize = true;
            this.UseAsynchCK.Location = new System.Drawing.Point(276, 11);
            this.UseAsynchCK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UseAsynchCK.Name = "UseAsynchCK";
            this.UseAsynchCK.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.UseAsynchCK.Size = new System.Drawing.Size(225, 24);
            this.UseAsynchCK.TabIndex = 1;
            this.UseAsynchCK.Text = "Use Asynchronous Pattern";
            this.UseAsynchCK.UseVisualStyleBackColor = true;
            // 
            // BottomPN
            // 
            this.BottomPN.Controls.Add(this.DisconnectBTN);
            this.BottomPN.Controls.Add(this.UseAsynchCK);
            this.BottomPN.Controls.Add(this.CancelBTN);
            this.BottomPN.Controls.Add(this.SimpleConnectBTN);
            this.BottomPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPN.Location = new System.Drawing.Point(0, 543);
            this.BottomPN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BottomPN.Name = "BottomPN";
            this.BottomPN.Size = new System.Drawing.Size(846, 45);
            this.BottomPN.TabIndex = 19;
            // 
            // DisconnectBTN
            // 
            this.DisconnectBTN.Location = new System.Drawing.Point(154, 5);
            this.DisconnectBTN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DisconnectBTN.Name = "DisconnectBTN";
            this.DisconnectBTN.Size = new System.Drawing.Size(112, 35);
            this.DisconnectBTN.TabIndex = 3;
            this.DisconnectBTN.Text = "Disconnect";
            this.DisconnectBTN.UseVisualStyleBackColor = true;
            this.DisconnectBTN.Click += new System.EventHandler(this.DisconnectBTN_Click);
            // 
            // CancelBTN
            // 
            this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBTN.Location = new System.Drawing.Point(729, 5);
            this.CancelBTN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(112, 35);
            this.CancelBTN.TabIndex = 2;
            this.CancelBTN.Text = "Close";
            this.CancelBTN.UseVisualStyleBackColor = true;
            this.CancelBTN.Click += new System.EventHandler(this.CancelBTN_Click);
            // 
            // ServerUrlLB
            // 
            this.ServerUrlLB.AutoSize = true;
            this.ServerUrlLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerUrlLB.Location = new System.Drawing.Point(8, 5);
            this.ServerUrlLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ServerUrlLB.Name = "ServerUrlLB";
            this.ServerUrlLB.Size = new System.Drawing.Size(110, 40);
            this.ServerUrlLB.TabIndex = 0;
            this.ServerUrlLB.Text = "Endpoint URL";
            this.ServerUrlLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.ServerUrlLB, " ");
            // 
            // EndpointUrlTB
            // 
            this.EndpointUrlTB.AllowDrop = true;
            this.MainPN.SetColumnSpan(this.EndpointUrlTB, 2);
            this.EndpointUrlTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndpointUrlTB.Location = new System.Drawing.Point(124, 10);
            this.EndpointUrlTB.Margin = new System.Windows.Forms.Padding(2, 5, 2, 6);
            this.EndpointUrlTB.Multiline = true;
            this.EndpointUrlTB.Name = "EndpointUrlTB";
            this.EndpointUrlTB.Size = new System.Drawing.Size(682, 29);
            this.EndpointUrlTB.TabIndex = 1;
            this.ToolTip.SetToolTip(this.EndpointUrlTB, "The identifier for the node to browse.");
            // 
            // ArgumentsGB
            // 
            this.ArgumentsGB.Controls.Add(this.MainPN);
            this.ArgumentsGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.ArgumentsGB.Location = new System.Drawing.Point(0, 0);
            this.ArgumentsGB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ArgumentsGB.Name = "ArgumentsGB";
            this.ArgumentsGB.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ArgumentsGB.Size = new System.Drawing.Size(820, 127);
            this.ArgumentsGB.TabIndex = 21;
            this.ArgumentsGB.TabStop = false;
            this.ArgumentsGB.Text = "Arguments";
            // 
            // MainPN
            // 
            this.MainPN.ColumnCount = 3;
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.Controls.Add(this.EndpointUrlTB, 1, 0);
            this.MainPN.Controls.Add(this.ServerUrlLB, 0, 0);
            this.MainPN.Controls.Add(this.SecurityBox, 1, 1);
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.MainPN.Location = new System.Drawing.Point(4, 24);
            this.MainPN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MainPN.Name = "MainPN";
            this.MainPN.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MainPN.RowCount = 2;
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.MainPN.Size = new System.Drawing.Size(812, 98);
            this.MainPN.TabIndex = 2;
            // 
            // SecurityBox
            // 
            this.SecurityBox.AutoSize = true;
            this.MainPN.SetColumnSpan(this.SecurityBox, 2);
            this.SecurityBox.Location = new System.Drawing.Point(126, 50);
            this.SecurityBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SecurityBox.Name = "SecurityBox";
            this.SecurityBox.Size = new System.Drawing.Size(125, 24);
            this.SecurityBox.TabIndex = 2;
            this.SecurityBox.Text = "Use Security";
            this.SecurityBox.UseVisualStyleBackColor = true;
            // 
            // UseDnsNameAndPortFromDiscoveryUrlBox
            // 
            this.UseDnsNameAndPortFromDiscoveryUrlBox.AutoSize = true;
            this.UseDnsNameAndPortFromDiscoveryUrlBox.Location = new System.Drawing.Point(14, 29);
            this.UseDnsNameAndPortFromDiscoveryUrlBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UseDnsNameAndPortFromDiscoveryUrlBox.Name = "UseDnsNameAndPortFromDiscoveryUrlBox";
            this.UseDnsNameAndPortFromDiscoveryUrlBox.Size = new System.Drawing.Size(318, 24);
            this.UseDnsNameAndPortFromDiscoveryUrlBox.TabIndex = 3;
            this.UseDnsNameAndPortFromDiscoveryUrlBox.Text = "UseDnsNameAndPortFromDiscoveryUrl";
            this.UseDnsNameAndPortFromDiscoveryUrlBox.UseVisualStyleBackColor = true;
            // 
            // EnableUpdateEndpointEventHandler
            // 
            this.EnableUpdateEndpointEventHandler.AutoSize = true;
            this.EnableUpdateEndpointEventHandler.Location = new System.Drawing.Point(14, 65);
            this.EnableUpdateEndpointEventHandler.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EnableUpdateEndpointEventHandler.Name = "EnableUpdateEndpointEventHandler";
            this.EnableUpdateEndpointEventHandler.Size = new System.Drawing.Size(307, 24);
            this.EnableUpdateEndpointEventHandler.TabIndex = 4;
            this.EnableUpdateEndpointEventHandler.Text = "Enable UpdateEndpoint EventHandler";
            this.EnableUpdateEndpointEventHandler.UseVisualStyleBackColor = true;
            this.EnableUpdateEndpointEventHandler.CheckedChanged += new System.EventHandler(this.EnableUpdateEndpointEventHandler_CheckedChanged);
            // 
            // ConnectionStateGB
            // 
            this.ConnectionStateGB.Controls.Add(this.MessageSecurityModeLabel);
            this.ConnectionStateGB.Controls.Add(this.EnpointUrlLabel);
            this.ConnectionStateGB.Controls.Add(this.LabelConnectionState);
            this.ConnectionStateGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConnectionStateGB.Location = new System.Drawing.Point(0, 261);
            this.ConnectionStateGB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ConnectionStateGB.Name = "ConnectionStateGB";
            this.ConnectionStateGB.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ConnectionStateGB.Size = new System.Drawing.Size(820, 158);
            this.ConnectionStateGB.TabIndex = 23;
            this.ConnectionStateGB.TabStop = false;
            this.ConnectionStateGB.Text = "Connection State";
            // 
            // MessageSecurityModeLabel
            // 
            this.MessageSecurityModeLabel.AutoSize = true;
            this.MessageSecurityModeLabel.Location = new System.Drawing.Point(14, 117);
            this.MessageSecurityModeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MessageSecurityModeLabel.Name = "MessageSecurityModeLabel";
            this.MessageSecurityModeLabel.Size = new System.Drawing.Size(171, 20);
            this.MessageSecurityModeLabel.TabIndex = 2;
            this.MessageSecurityModeLabel.Text = "MessageSecurityMode";
            // 
            // EnpointUrlLabel
            // 
            this.EnpointUrlLabel.AutoSize = true;
            this.EnpointUrlLabel.Location = new System.Drawing.Point(14, 78);
            this.EnpointUrlLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EnpointUrlLabel.Name = "EnpointUrlLabel";
            this.EnpointUrlLabel.Size = new System.Drawing.Size(93, 20);
            this.EnpointUrlLabel.TabIndex = 1;
            this.EnpointUrlLabel.Text = "EndpointUrl";
            this.EnpointUrlLabel.DoubleClick += new System.EventHandler(this.EnpointUrlLabel_DoubleClick);
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
            // SessionGB
            // 
            this.SessionGB.Controls.Add(this.UseDnsNameAndPortFromDiscoveryUrlBox);
            this.SessionGB.Controls.Add(this.EnableUpdateEndpointEventHandler);
            this.SessionGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.SessionGB.Location = new System.Drawing.Point(0, 127);
            this.SessionGB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SessionGB.Name = "SessionGB";
            this.SessionGB.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SessionGB.Size = new System.Drawing.Size(820, 134);
            this.SessionGB.TabIndex = 22;
            this.SessionGB.TabStop = false;
            this.SessionGB.Text = "Session";
            // 
            // MiddlePN
            // 
            this.MiddlePN.AutoScroll = true;
            this.MiddlePN.Controls.Add(this.ConnectionStateGB);
            this.MiddlePN.Controls.Add(this.SessionGB);
            this.MiddlePN.Controls.Add(this.ArgumentsGB);
            this.MiddlePN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MiddlePN.Location = new System.Drawing.Point(0, 127);
            this.MiddlePN.Name = "MiddlePN";
            this.MiddlePN.Size = new System.Drawing.Size(846, 416);
            this.MiddlePN.TabIndex = 24;
            // 
            // SimpleConnectDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 588);
            this.Controls.Add(this.MiddlePN);
            this.Controls.Add(this.BottomPN);
            this.Controls.Add(this.InstructionsGB);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SimpleConnectDlg";
            this.Text = "Simple Connect";
            this.TopPN.ResumeLayout(false);
            this.InstructionsGB.ResumeLayout(false);
            this.BottomPN.ResumeLayout(false);
            this.BottomPN.PerformLayout();
            this.ArgumentsGB.ResumeLayout(false);
            this.MainPN.ResumeLayout(false);
            this.MainPN.PerformLayout();
            this.ConnectionStateGB.ResumeLayout(false);
            this.ConnectionStateGB.PerformLayout();
            this.SessionGB.ResumeLayout(false);
            this.SessionGB.PerformLayout();
            this.MiddlePN.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Button SimpleConnectBTN;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Button HelpBTN;
        private System.Windows.Forms.Button ShowCodeBTN;
        private System.Windows.Forms.Label InstructionsLB;
        private System.Windows.Forms.GroupBox InstructionsGB;
        private System.Windows.Forms.CheckBox UseAsynchCK;
        private System.Windows.Forms.Panel BottomPN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.GroupBox ArgumentsGB;
        private System.Windows.Forms.TableLayoutPanel MainPN;
        private System.Windows.Forms.TextBox EndpointUrlTB;
        private System.Windows.Forms.Label ServerUrlLB;
        private System.Windows.Forms.CheckBox SecurityBox;
        private System.Windows.Forms.GroupBox ConnectionStateGB;
        private System.Windows.Forms.Label LabelConnectionState;
        private System.Windows.Forms.Button DisconnectBTN;
        private System.Windows.Forms.CheckBox UseDnsNameAndPortFromDiscoveryUrlBox;
        private System.Windows.Forms.Label EnpointUrlLabel;
        private System.Windows.Forms.Label MessageSecurityModeLabel;
        private System.Windows.Forms.CheckBox EnableUpdateEndpointEventHandler;
        private System.Windows.Forms.GroupBox SessionGB;
        private System.Windows.Forms.Panel MiddlePN;
    }
}