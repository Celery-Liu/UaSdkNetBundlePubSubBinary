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

namespace UnifiedAutomation.ClientGettingStarted.Common
{
    partial class ConnectOptionsControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConnectLeftPN = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ReverseConnectButton = new System.Windows.Forms.Button();
            this.AuthenticationButton = new System.Windows.Forms.Button();
            this.AdvancedConnectButton = new System.Windows.Forms.Button();
            this.SimpleConnectButton = new System.Windows.Forms.Button();
            this.CertificateManagementGB = new System.Windows.Forms.GroupBox();
            this.TrustCertificateButton = new System.Windows.Forms.Button();
            this.CreateCertificateButton = new System.Windows.Forms.Button();
            this.DiscoveryGB = new System.Windows.Forms.GroupBox();
            this.GetEndpointsBTN = new System.Windows.Forms.Button();
            this.FindServersBTN = new System.Windows.Forms.Button();
            this.ConnectCloseBTN = new System.Windows.Forms.Button();
            this.ConnectBrowser = new System.Windows.Forms.WebBrowser();
            this.NameTextBox = new System.Windows.Forms.Label();
            this.InstructionsLB = new System.Windows.Forms.Label();
            this.StartDemoButton = new System.Windows.Forms.Button();
            this.TopPN = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.WarningLB = new System.Windows.Forms.Label();
            this.ConnectLeftPN.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.CertificateManagementGB.SuspendLayout();
            this.DiscoveryGB.SuspendLayout();
            this.TopPN.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConnectLeftPN
            // 
            this.ConnectLeftPN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(201)))));
            this.ConnectLeftPN.Controls.Add(this.groupBox1);
            this.ConnectLeftPN.Controls.Add(this.CertificateManagementGB);
            this.ConnectLeftPN.Controls.Add(this.DiscoveryGB);
            this.ConnectLeftPN.Dock = System.Windows.Forms.DockStyle.Left;
            this.ConnectLeftPN.Location = new System.Drawing.Point(0, 37);
            this.ConnectLeftPN.Name = "ConnectLeftPN";
            this.ConnectLeftPN.Size = new System.Drawing.Size(200, 446);
            this.ConnectLeftPN.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ReverseConnectButton);
            this.groupBox1.Controls.Add(this.AuthenticationButton);
            this.groupBox1.Controls.Add(this.AdvancedConnectButton);
            this.groupBox1.Controls.Add(this.SimpleConnectButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 171);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.groupBox1.Size = new System.Drawing.Size(200, 140);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connect";
            // 
            // ReverseConnectButton
            // 
            this.ReverseConnectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.ReverseConnectButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ReverseConnectButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(178)))), ((int)(((byte)(75)))));
            this.ReverseConnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReverseConnectButton.ForeColor = System.Drawing.Color.White;
            this.ReverseConnectButton.Location = new System.Drawing.Point(6, 100);
            this.ReverseConnectButton.Name = "ReverseConnectButton";
            this.ReverseConnectButton.Size = new System.Drawing.Size(188, 28);
            this.ReverseConnectButton.TabIndex = 9;
            this.ReverseConnectButton.Text = "Reverse Connect";
            this.ReverseConnectButton.UseVisualStyleBackColor = false;
            this.ReverseConnectButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // AuthenticationButton
            // 
            this.AuthenticationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.AuthenticationButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.AuthenticationButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(178)))), ((int)(((byte)(75)))));
            this.AuthenticationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthenticationButton.ForeColor = System.Drawing.Color.White;
            this.AuthenticationButton.Location = new System.Drawing.Point(6, 72);
            this.AuthenticationButton.Name = "AuthenticationButton";
            this.AuthenticationButton.Size = new System.Drawing.Size(188, 28);
            this.AuthenticationButton.TabIndex = 8;
            this.AuthenticationButton.Text = "Authentication";
            this.AuthenticationButton.UseVisualStyleBackColor = false;
            this.AuthenticationButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // AdvancedConnectButton
            // 
            this.AdvancedConnectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.AdvancedConnectButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.AdvancedConnectButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(178)))), ((int)(((byte)(75)))));
            this.AdvancedConnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdvancedConnectButton.ForeColor = System.Drawing.Color.White;
            this.AdvancedConnectButton.Location = new System.Drawing.Point(6, 44);
            this.AdvancedConnectButton.Name = "AdvancedConnectButton";
            this.AdvancedConnectButton.Size = new System.Drawing.Size(188, 28);
            this.AdvancedConnectButton.TabIndex = 5;
            this.AdvancedConnectButton.Text = "Advanced Connect";
            this.AdvancedConnectButton.UseVisualStyleBackColor = false;
            this.AdvancedConnectButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // SimpleConnectButton
            // 
            this.SimpleConnectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.SimpleConnectButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.SimpleConnectButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(178)))), ((int)(((byte)(75)))));
            this.SimpleConnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SimpleConnectButton.ForeColor = System.Drawing.Color.White;
            this.SimpleConnectButton.Location = new System.Drawing.Point(6, 16);
            this.SimpleConnectButton.Name = "SimpleConnectButton";
            this.SimpleConnectButton.Size = new System.Drawing.Size(188, 28);
            this.SimpleConnectButton.TabIndex = 7;
            this.SimpleConnectButton.Text = "Simple Connect";
            this.SimpleConnectButton.UseVisualStyleBackColor = false;
            this.SimpleConnectButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // CertificateManagementGB
            // 
            this.CertificateManagementGB.Controls.Add(this.TrustCertificateButton);
            this.CertificateManagementGB.Controls.Add(this.CreateCertificateButton);
            this.CertificateManagementGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.CertificateManagementGB.Location = new System.Drawing.Point(0, 83);
            this.CertificateManagementGB.Name = "CertificateManagementGB";
            this.CertificateManagementGB.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.CertificateManagementGB.Size = new System.Drawing.Size(200, 88);
            this.CertificateManagementGB.TabIndex = 1;
            this.CertificateManagementGB.TabStop = false;
            this.CertificateManagementGB.Text = "Certificate Management";
            // 
            // TrustCertificateButton
            // 
            this.TrustCertificateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.TrustCertificateButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.TrustCertificateButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(178)))), ((int)(((byte)(75)))));
            this.TrustCertificateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrustCertificateButton.ForeColor = System.Drawing.Color.White;
            this.TrustCertificateButton.Location = new System.Drawing.Point(6, 44);
            this.TrustCertificateButton.Name = "TrustCertificateButton";
            this.TrustCertificateButton.Size = new System.Drawing.Size(188, 28);
            this.TrustCertificateButton.TabIndex = 5;
            this.TrustCertificateButton.Text = "Trust Server Certificate";
            this.TrustCertificateButton.UseVisualStyleBackColor = false;
            this.TrustCertificateButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // CreateCertificateButton
            // 
            this.CreateCertificateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.CreateCertificateButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreateCertificateButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(178)))), ((int)(((byte)(75)))));
            this.CreateCertificateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateCertificateButton.ForeColor = System.Drawing.Color.White;
            this.CreateCertificateButton.Location = new System.Drawing.Point(6, 16);
            this.CreateCertificateButton.Name = "CreateCertificateButton";
            this.CreateCertificateButton.Size = new System.Drawing.Size(188, 28);
            this.CreateCertificateButton.TabIndex = 7;
            this.CreateCertificateButton.Text = "Create Certificate";
            this.CreateCertificateButton.UseVisualStyleBackColor = false;
            this.CreateCertificateButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // DiscoveryGB
            // 
            this.DiscoveryGB.Controls.Add(this.GetEndpointsBTN);
            this.DiscoveryGB.Controls.Add(this.FindServersBTN);
            this.DiscoveryGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.DiscoveryGB.Location = new System.Drawing.Point(0, 0);
            this.DiscoveryGB.Name = "DiscoveryGB";
            this.DiscoveryGB.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.DiscoveryGB.Size = new System.Drawing.Size(200, 83);
            this.DiscoveryGB.TabIndex = 1;
            this.DiscoveryGB.TabStop = false;
            this.DiscoveryGB.Text = "Discovery";
            // 
            // GetEndpointsBTN
            // 
            this.GetEndpointsBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.GetEndpointsBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.GetEndpointsBTN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(178)))), ((int)(((byte)(75)))));
            this.GetEndpointsBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetEndpointsBTN.ForeColor = System.Drawing.Color.White;
            this.GetEndpointsBTN.Location = new System.Drawing.Point(6, 44);
            this.GetEndpointsBTN.Name = "GetEndpointsBTN";
            this.GetEndpointsBTN.Size = new System.Drawing.Size(188, 28);
            this.GetEndpointsBTN.TabIndex = 9;
            this.GetEndpointsBTN.Text = "Get Endpoints";
            this.GetEndpointsBTN.UseVisualStyleBackColor = false;
            this.GetEndpointsBTN.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // FindServersBTN
            // 
            this.FindServersBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.FindServersBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.FindServersBTN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(178)))), ((int)(((byte)(75)))));
            this.FindServersBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FindServersBTN.ForeColor = System.Drawing.Color.White;
            this.FindServersBTN.Location = new System.Drawing.Point(6, 16);
            this.FindServersBTN.Name = "FindServersBTN";
            this.FindServersBTN.Size = new System.Drawing.Size(188, 28);
            this.FindServersBTN.TabIndex = 8;
            this.FindServersBTN.Text = "Find Servers";
            this.FindServersBTN.UseVisualStyleBackColor = false;
            this.FindServersBTN.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // ConnectCloseBTN
            // 
            this.ConnectCloseBTN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectCloseBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.ConnectCloseBTN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(178)))), ((int)(((byte)(75)))));
            this.ConnectCloseBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectCloseBTN.ForeColor = System.Drawing.Color.White;
            this.ConnectCloseBTN.Location = new System.Drawing.Point(704, 5);
            this.ConnectCloseBTN.Name = "ConnectCloseBTN";
            this.ConnectCloseBTN.Size = new System.Drawing.Size(75, 32);
            this.ConnectCloseBTN.TabIndex = 3;
            this.ConnectCloseBTN.Text = "Back";
            this.ConnectCloseBTN.UseVisualStyleBackColor = false;
            this.ConnectCloseBTN.Click += new System.EventHandler(this.ConnectCloseBTN_Click);
            // 
            // ConnectBrowser
            // 
            this.ConnectBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectBrowser.Location = new System.Drawing.Point(206, 45);
            this.ConnectBrowser.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.ConnectBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.ConnectBrowser.Name = "ConnectBrowser";
            this.ConnectBrowser.ScrollBarsEnabled = false;
            this.ConnectBrowser.Size = new System.Drawing.Size(571, 430);
            this.ConnectBrowser.TabIndex = 2;
            // 
            // NameTextBox
            // 
            this.NameTextBox.AutoSize = true;
            this.NameTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.NameTextBox.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTextBox.Location = new System.Drawing.Point(220, 50);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(127, 23);
            this.NameTextBox.TabIndex = 9;
            this.NameTextBox.Text = "Demo Name";
            this.NameTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InstructionsLB
            // 
            this.InstructionsLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstructionsLB.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.InstructionsLB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.InstructionsLB.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsLB.Location = new System.Drawing.Point(220, 84);
            this.InstructionsLB.Margin = new System.Windows.Forms.Padding(0);
            this.InstructionsLB.Name = "InstructionsLB";
            this.InstructionsLB.Padding = new System.Windows.Forms.Padding(3);
            this.InstructionsLB.Size = new System.Drawing.Size(544, 85);
            this.InstructionsLB.TabIndex = 8;
            this.InstructionsLB.Text = "<instructions>";
            // 
            // StartDemoButton
            // 
            this.StartDemoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.StartDemoButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(178)))), ((int)(((byte)(75)))));
            this.StartDemoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartDemoButton.ForeColor = System.Drawing.Color.White;
            this.StartDemoButton.Location = new System.Drawing.Point(220, 180);
            this.StartDemoButton.Name = "StartDemoButton";
            this.StartDemoButton.Size = new System.Drawing.Size(109, 28);
            this.StartDemoButton.TabIndex = 7;
            this.StartDemoButton.Text = "Show Dialog";
            this.StartDemoButton.UseVisualStyleBackColor = false;
            this.StartDemoButton.Click += new System.EventHandler(this.StartDemoButton_Click);
            // 
            // TopPN
            // 
            this.TopPN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(201)))));
            this.TopPN.Controls.Add(this.ConnectCloseBTN);
            this.TopPN.Controls.Add(this.label1);
            this.TopPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPN.Location = new System.Drawing.Point(0, 0);
            this.TopPN.Name = "TopPN";
            this.TopPN.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.TopPN.Size = new System.Drawing.Size(784, 37);
            this.TopPN.TabIndex = 10;
            this.TopPN.VisibleChanged += new System.EventHandler(this.TopPN_VisibleChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(0, 5);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(229, 32);
            this.label1.TabIndex = 10;
            this.label1.Text = "Connection Examples";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WarningLB
            // 
            this.WarningLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WarningLB.BackColor = System.Drawing.Color.Red;
            this.WarningLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarningLB.ForeColor = System.Drawing.Color.White;
            this.WarningLB.Location = new System.Drawing.Point(220, 439);
            this.WarningLB.Name = "WarningLB";
            this.WarningLB.Size = new System.Drawing.Size(544, 23);
            this.WarningLB.TabIndex = 12;
            this.WarningLB.Text = "Cannot connect to Server!";
            this.WarningLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.WarningLB.Visible = false;
            this.WarningLB.Click += new System.EventHandler(this.WarningLB_Click);
            // 
            // ConnectOptionsControl
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(201)))));
            this.Controls.Add(this.WarningLB);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.InstructionsLB);
            this.Controls.Add(this.StartDemoButton);
            this.Controls.Add(this.ConnectBrowser);
            this.Controls.Add(this.ConnectLeftPN);
            this.Controls.Add(this.TopPN);
            this.Name = "ConnectOptionsControl";
            this.Size = new System.Drawing.Size(784, 483);
            this.VisibleChanged += new System.EventHandler(this.Control_VisibleChanged);
            this.ConnectLeftPN.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.CertificateManagementGB.ResumeLayout(false);
            this.DiscoveryGB.ResumeLayout(false);
            this.TopPN.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ConnectLeftPN;
        private System.Windows.Forms.GroupBox CertificateManagementGB;
        private System.Windows.Forms.Button TrustCertificateButton;
        private System.Windows.Forms.GroupBox DiscoveryGB;
        private System.Windows.Forms.Button GetEndpointsBTN;
        private System.Windows.Forms.Button FindServersBTN;
        private System.Windows.Forms.WebBrowser ConnectBrowser;
        private System.Windows.Forms.Button ConnectCloseBTN;
        private System.Windows.Forms.Label NameTextBox;
        private System.Windows.Forms.Label InstructionsLB;
        private System.Windows.Forms.Button StartDemoButton;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label WarningLB;
        private System.Windows.Forms.Button CreateCertificateButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AdvancedConnectButton;
        private System.Windows.Forms.Button SimpleConnectButton;
        private System.Windows.Forms.Button AuthenticationButton;
        private System.Windows.Forms.Button ReverseConnectButton;
    }
}
