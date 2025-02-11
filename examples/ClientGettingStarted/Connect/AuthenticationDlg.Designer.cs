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
    partial class AuthenticationDlg
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
            System.Windows.Forms.ColumnHeader EndpointUrlCH;
            this.TopPN = new System.Windows.Forms.Panel();
            this.InstructionsGB = new System.Windows.Forms.Label();
            this.BottomPN = new System.Windows.Forms.Panel();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.ServerUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MainPN = new System.Windows.Forms.TableLayoutPanel();
            this.Instructions = new System.Windows.Forms.GroupBox();
            this.InstructionsPN = new System.Windows.Forms.Panel();
            this.HelpBTN = new System.Windows.Forms.Button();
            this.ShowCodeButton = new System.Windows.Forms.Button();
            this.ConnectionSettings = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.UseSecurity = new System.Windows.Forms.CheckBox();
            this.InsecureCredicals = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.AuthenticationSettings = new System.Windows.Forms.GroupBox();
            this.AuthenticationTLP = new System.Windows.Forms.TableLayoutPanel();
            this.X509StoreButton = new System.Windows.Forms.RadioButton();
            this.AnonymousButton = new System.Windows.Forms.RadioButton();
            this.UserNameButton = new System.Windows.Forms.RadioButton();
            this.UserNameTLP = new System.Windows.Forms.TableLayoutPanel();
            this.UserName_Password = new System.Windows.Forms.TextBox();
            this.UserName_Name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CertificateDirTLP = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.X509_Certificate = new System.Windows.Forms.TextBox();
            this.BrowseCertificate = new System.Windows.Forms.Button();
            this.CertificateStoreTLP = new System.Windows.Forms.TableLayoutPanel();
            this.X509StoreCertificate = new System.Windows.Forms.TextBox();
            this.X509StorePath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.X509Button = new System.Windows.Forms.RadioButton();
            this.ConnecitonStatus = new System.Windows.Forms.GroupBox();
            this.ConnectionStatus = new System.Windows.Forms.Label();
            this.BottomP = new System.Windows.Forms.Panel();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.UseAsynchronous = new System.Windows.Forms.CheckBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.Middle = new System.Windows.Forms.Panel();
            EndpointUrlCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BottomPN.SuspendLayout();
            this.Instructions.SuspendLayout();
            this.InstructionsPN.SuspendLayout();
            this.ConnectionSettings.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.AuthenticationSettings.SuspendLayout();
            this.AuthenticationTLP.SuspendLayout();
            this.UserNameTLP.SuspendLayout();
            this.CertificateDirTLP.SuspendLayout();
            this.CertificateStoreTLP.SuspendLayout();
            this.ConnecitonStatus.SuspendLayout();
            this.BottomP.SuspendLayout();
            this.Middle.SuspendLayout();
            this.SuspendLayout();
            // 
            // EndpointUrlCH
            // 
            EndpointUrlCH.Text = "Endpoint URL";
            EndpointUrlCH.Width = 97;
            // 
            // TopPN
            // 
            this.TopPN.BackColor = System.Drawing.Color.Transparent;
            this.TopPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopPN.Location = new System.Drawing.Point(3, 16);
            this.TopPN.Name = "TopPN";
            this.TopPN.Padding = new System.Windows.Forms.Padding(3);
            this.TopPN.Size = new System.Drawing.Size(595, 62);
            this.TopPN.TabIndex = 2;
            // 
            // InstructionsGB
            // 
            this.InstructionsGB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstructionsGB.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.InstructionsGB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.InstructionsGB.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsGB.Location = new System.Drawing.Point(4, 5);
            this.InstructionsGB.Margin = new System.Windows.Forms.Padding(0);
            this.InstructionsGB.Name = "InstructionsGB";
            this.InstructionsGB.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InstructionsGB.Size = new System.Drawing.Size(764, 101);
            this.InstructionsGB.TabIndex = 0;
            this.InstructionsGB.Text = "<instructions>";
            // 
            // BottomPN
            // 
            this.BottomPN.Controls.Add(this.CancelBTN);
            this.BottomPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPN.Location = new System.Drawing.Point(0, 422);
            this.BottomPN.Name = "BottomPN";
            this.BottomPN.Size = new System.Drawing.Size(601, 29);
            this.BottomPN.TabIndex = 25;
            // 
            // CancelBTN
            // 
            this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBTN.Location = new System.Drawing.Point(523, 3);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelBTN.TabIndex = 2;
            this.CancelBTN.Text = "Close";
            this.CancelBTN.UseVisualStyleBackColor = true;
            // 
            // ServerUrl
            // 
            this.ServerUrl.AllowDrop = true;
            this.ServerUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerUrl.Location = new System.Drawing.Point(135, 10);
            this.ServerUrl.Margin = new System.Windows.Forms.Padding(2, 5, 2, 6);
            this.ServerUrl.Name = "ServerUrl";
            this.ServerUrl.Size = new System.Drawing.Size(753, 26);
            this.ServerUrl.TabIndex = 1;
            this.ServerUrl.Text = "opc.tcp://localhost:48030";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(8, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 37);
            this.label2.TabIndex = 0;
            this.label2.Text = "Server URL";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "Server URL";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 292);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(601, 78);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connection State";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // MainPN
            // 
            this.MainPN.ColumnCount = 3;
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(0, 0);
            this.MainPN.Name = "MainPN";
            this.MainPN.RowCount = 2;
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainPN.Size = new System.Drawing.Size(200, 100);
            this.MainPN.TabIndex = 0;
            // 
            // Instructions
            // 
            this.Instructions.BackColor = System.Drawing.Color.Transparent;
            this.Instructions.Controls.Add(this.InstructionsPN);
            this.Instructions.Dock = System.Windows.Forms.DockStyle.Top;
            this.Instructions.Location = new System.Drawing.Point(0, 0);
            this.Instructions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Instructions.Name = "Instructions";
            this.Instructions.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Instructions.Size = new System.Drawing.Size(902, 139);
            this.Instructions.TabIndex = 21;
            this.Instructions.TabStop = false;
            this.Instructions.Text = "Instructions";
            // 
            // InstructionsPN
            // 
            this.InstructionsPN.BackColor = System.Drawing.Color.Transparent;
            this.InstructionsPN.Controls.Add(this.HelpBTN);
            this.InstructionsPN.Controls.Add(this.ShowCodeButton);
            this.InstructionsPN.Controls.Add(this.InstructionsGB);
            this.InstructionsPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InstructionsPN.Location = new System.Drawing.Point(4, 24);
            this.InstructionsPN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InstructionsPN.Name = "InstructionsPN";
            this.InstructionsPN.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InstructionsPN.Size = new System.Drawing.Size(894, 110);
            this.InstructionsPN.TabIndex = 2;
            // 
            // HelpBTN
            // 
            this.HelpBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HelpBTN.Location = new System.Drawing.Point(773, 51);
            this.HelpBTN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HelpBTN.Name = "HelpBTN";
            this.HelpBTN.Size = new System.Drawing.Size(112, 35);
            this.HelpBTN.TabIndex = 2;
            this.HelpBTN.Text = "Help";
            this.HelpBTN.UseVisualStyleBackColor = true;
            this.HelpBTN.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // ShowCodeButton
            // 
            this.ShowCodeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowCodeButton.Location = new System.Drawing.Point(773, 9);
            this.ShowCodeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ShowCodeButton.Name = "ShowCodeButton";
            this.ShowCodeButton.Size = new System.Drawing.Size(112, 35);
            this.ShowCodeButton.TabIndex = 1;
            this.ShowCodeButton.Text = "Show Code";
            this.ShowCodeButton.UseVisualStyleBackColor = true;
            this.ShowCodeButton.Click += new System.EventHandler(this.ShowCodeButton_Click);
            // 
            // ConnectionSettings
            // 
            this.ConnectionSettings.Controls.Add(this.tableLayoutPanel1);
            this.ConnectionSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConnectionSettings.Location = new System.Drawing.Point(0, 0);
            this.ConnectionSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ConnectionSettings.Name = "ConnectionSettings";
            this.ConnectionSettings.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ConnectionSettings.Size = new System.Drawing.Size(902, 117);
            this.ConnectionSettings.TabIndex = 22;
            this.ConnectionSettings.TabStop = false;
            this.ConnectionSettings.Text = "Connection Settings";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.ServerUrl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.UseSecurity, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.InsecureCredicals, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(894, 88);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // UseSecurity
            // 
            this.UseSecurity.AutoSize = true;
            this.UseSecurity.Enabled = false;
            this.UseSecurity.Location = new System.Drawing.Point(8, 47);
            this.UseSecurity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UseSecurity.Name = "UseSecurity";
            this.UseSecurity.Size = new System.Drawing.Size(121, 24);
            this.UseSecurity.TabIndex = 2;
            this.UseSecurity.Text = "Use Security";
            this.UseSecurity.UseVisualStyleBackColor = true;
            // 
            // InsecureCredicals
            // 
            this.InsecureCredicals.AutoSize = true;
            this.InsecureCredicals.Enabled = false;
            this.InsecureCredicals.Location = new System.Drawing.Point(137, 47);
            this.InsecureCredicals.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InsecureCredicals.Name = "InsecureCredicals";
            this.InsecureCredicals.Size = new System.Drawing.Size(292, 24);
            this.InsecureCredicals.TabIndex = 3;
            this.InsecureCredicals.Text = "Use InsecureCredicals EventHandler";
            this.InsecureCredicals.UseVisualStyleBackColor = true;
            this.InsecureCredicals.CheckedChanged += new System.EventHandler(this.InsecureCredicals_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 100);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // AuthenticationSettings
            // 
            this.AuthenticationSettings.Controls.Add(this.AuthenticationTLP);
            this.AuthenticationSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.AuthenticationSettings.Location = new System.Drawing.Point(0, 117);
            this.AuthenticationSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AuthenticationSettings.Name = "AuthenticationSettings";
            this.AuthenticationSettings.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AuthenticationSettings.Size = new System.Drawing.Size(902, 320);
            this.AuthenticationSettings.TabIndex = 23;
            this.AuthenticationSettings.TabStop = false;
            this.AuthenticationSettings.Text = "Authentication Settings";
            // 
            // AuthenticationTLP
            // 
            this.AuthenticationTLP.ColumnCount = 2;
            this.AuthenticationTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.AuthenticationTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 930F));
            this.AuthenticationTLP.Controls.Add(this.X509StoreButton, 0, 3);
            this.AuthenticationTLP.Controls.Add(this.AnonymousButton, 0, 0);
            this.AuthenticationTLP.Controls.Add(this.UserNameButton, 0, 1);
            this.AuthenticationTLP.Controls.Add(this.UserNameTLP, 1, 1);
            this.AuthenticationTLP.Controls.Add(this.CertificateDirTLP, 1, 2);
            this.AuthenticationTLP.Controls.Add(this.CertificateStoreTLP, 1, 3);
            this.AuthenticationTLP.Controls.Add(this.X509Button, 0, 2);
            this.AuthenticationTLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AuthenticationTLP.Location = new System.Drawing.Point(4, 24);
            this.AuthenticationTLP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AuthenticationTLP.Name = "AuthenticationTLP";
            this.AuthenticationTLP.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AuthenticationTLP.RowCount = 4;
            this.AuthenticationTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.AuthenticationTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.AuthenticationTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.AuthenticationTLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.AuthenticationTLP.Size = new System.Drawing.Size(894, 291);
            this.AuthenticationTLP.TabIndex = 2;
            // 
            // X509StoreButton
            // 
            this.X509StoreButton.AutoSize = true;
            this.X509StoreButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.X509StoreButton.Location = new System.Drawing.Point(8, 195);
            this.X509StoreButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.X509StoreButton.Name = "X509StoreButton";
            this.X509StoreButton.Size = new System.Drawing.Size(121, 86);
            this.X509StoreButton.TabIndex = 5;
            this.X509StoreButton.Text = "X509 (Store)";
            this.X509StoreButton.UseVisualStyleBackColor = true;
            // 
            // AnonymousButton
            // 
            this.AnonymousButton.AutoSize = true;
            this.AnonymousButton.Checked = true;
            this.AnonymousButton.Location = new System.Drawing.Point(8, 10);
            this.AnonymousButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AnonymousButton.Name = "AnonymousButton";
            this.AnonymousButton.Size = new System.Drawing.Size(114, 24);
            this.AnonymousButton.TabIndex = 0;
            this.AnonymousButton.TabStop = true;
            this.AnonymousButton.Text = "Anonymous";
            this.AnonymousButton.UseVisualStyleBackColor = true;
            // 
            // UserNameButton
            // 
            this.UserNameButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.UserNameButton.AutoSize = true;
            this.UserNameButton.Enabled = false;
            this.UserNameButton.Location = new System.Drawing.Point(8, 77);
            this.UserNameButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UserNameButton.Name = "UserNameButton";
            this.UserNameButton.Size = new System.Drawing.Size(106, 24);
            this.UserNameButton.TabIndex = 1;
            this.UserNameButton.TabStop = true;
            this.UserNameButton.Text = "UserName";
            this.UserNameButton.UseVisualStyleBackColor = true;
            // 
            // UserNameTLP
            // 
            this.UserNameTLP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.UserNameTLP.ColumnCount = 2;
            this.UserNameTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.UserNameTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 626F));
            this.UserNameTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.UserNameTLP.Controls.Add(this.UserName_Password, 1, 1);
            this.UserNameTLP.Controls.Add(this.UserName_Name, 1, 0);
            this.UserNameTLP.Controls.Add(this.label4, 0, 0);
            this.UserNameTLP.Controls.Add(this.label5, 0, 1);
            this.UserNameTLP.Location = new System.Drawing.Point(137, 56);
            this.UserNameTLP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UserNameTLP.Name = "UserNameTLP";
            this.UserNameTLP.RowCount = 2;
            this.UserNameTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.UserNameTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.UserNameTLP.Size = new System.Drawing.Size(746, 67);
            this.UserNameTLP.TabIndex = 3;
            // 
            // UserName_Password
            // 
            this.UserName_Password.Location = new System.Drawing.Point(124, 38);
            this.UserName_Password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UserName_Password.Name = "UserName_Password";
            this.UserName_Password.Size = new System.Drawing.Size(526, 26);
            this.UserName_Password.TabIndex = 4;
            this.UserName_Password.Text = "master";
            // 
            // UserName_Name
            // 
            this.UserName_Name.Location = new System.Drawing.Point(124, 5);
            this.UserName_Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UserName_Name.Name = "UserName_Name";
            this.UserName_Name.Size = new System.Drawing.Size(526, 26);
            this.UserName_Name.TabIndex = 0;
            this.UserName_Name.Text = "john";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "User Name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 40);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Password";
            // 
            // CertificateDirTLP
            // 
            this.CertificateDirTLP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CertificateDirTLP.ColumnCount = 3;
            this.CertificateDirTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.CertificateDirTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 540F));
            this.CertificateDirTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.CertificateDirTLP.Controls.Add(this.label6, 0, 0);
            this.CertificateDirTLP.Controls.Add(this.X509_Certificate, 1, 0);
            this.CertificateDirTLP.Controls.Add(this.BrowseCertificate, 2, 0);
            this.CertificateDirTLP.Location = new System.Drawing.Point(137, 140);
            this.CertificateDirTLP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CertificateDirTLP.Name = "CertificateDirTLP";
            this.CertificateDirTLP.RowCount = 1;
            this.CertificateDirTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CertificateDirTLP.Size = new System.Drawing.Size(746, 37);
            this.CertificateDirTLP.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 8);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Certificate";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // X509_Certificate
            // 
            this.X509_Certificate.Location = new System.Drawing.Point(124, 5);
            this.X509_Certificate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.X509_Certificate.Name = "X509_Certificate";
            this.X509_Certificate.Size = new System.Drawing.Size(526, 26);
            this.X509_Certificate.TabIndex = 4;
            // 
            // BrowseCertificate
            // 
            this.BrowseCertificate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BrowseCertificate.Location = new System.Drawing.Point(675, 2);
            this.BrowseCertificate.Margin = new System.Windows.Forms.Padding(0);
            this.BrowseCertificate.Name = "BrowseCertificate";
            this.BrowseCertificate.Size = new System.Drawing.Size(56, 32);
            this.BrowseCertificate.TabIndex = 5;
            this.BrowseCertificate.Text = "...";
            this.BrowseCertificate.UseVisualStyleBackColor = true;
            this.BrowseCertificate.Click += new System.EventHandler(this.BrowseCertificate_Click);
            // 
            // CertificateStoreTLP
            // 
            this.CertificateStoreTLP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CertificateStoreTLP.ColumnCount = 2;
            this.CertificateStoreTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.CertificateStoreTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 626F));
            this.CertificateStoreTLP.Controls.Add(this.X509StoreCertificate, 1, 1);
            this.CertificateStoreTLP.Controls.Add(this.X509StorePath, 1, 0);
            this.CertificateStoreTLP.Controls.Add(this.label8, 0, 0);
            this.CertificateStoreTLP.Controls.Add(this.label9, 0, 1);
            this.CertificateStoreTLP.Location = new System.Drawing.Point(137, 196);
            this.CertificateStoreTLP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CertificateStoreTLP.Name = "CertificateStoreTLP";
            this.CertificateStoreTLP.RowCount = 2;
            this.CertificateStoreTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CertificateStoreTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CertificateStoreTLP.Size = new System.Drawing.Size(746, 83);
            this.CertificateStoreTLP.TabIndex = 6;
            // 
            // X509StoreCertificate
            // 
            this.X509StoreCertificate.Location = new System.Drawing.Point(124, 46);
            this.X509StoreCertificate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.X509StoreCertificate.Name = "X509StoreCertificate";
            this.X509StoreCertificate.Size = new System.Drawing.Size(526, 26);
            this.X509StoreCertificate.TabIndex = 4;
            this.X509StoreCertificate.Text = "GettingStartedClient";
            // 
            // X509StorePath
            // 
            this.X509StorePath.Location = new System.Drawing.Point(124, 5);
            this.X509StorePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.X509StorePath.Name = "X509StorePath";
            this.X509StorePath.Size = new System.Drawing.Size(526, 26);
            this.X509StorePath.TabIndex = 0;
            this.X509StorePath.Text = "LocalMachine\\My";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 10);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Store Path";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 52);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 20);
            this.label9.TabIndex = 3;
            this.label9.Text = "Certificate";
            // 
            // X509Button
            // 
            this.X509Button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.X509Button.AutoSize = true;
            this.X509Button.Location = new System.Drawing.Point(8, 147);
            this.X509Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.X509Button.Name = "X509Button";
            this.X509Button.Size = new System.Drawing.Size(102, 24);
            this.X509Button.TabIndex = 2;
            this.X509Button.Text = "X509 (Dir)";
            this.X509Button.UseVisualStyleBackColor = true;
            // 
            // ConnecitonStatus
            // 
            this.ConnecitonStatus.Controls.Add(this.ConnectionStatus);
            this.ConnecitonStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConnecitonStatus.Location = new System.Drawing.Point(0, 437);
            this.ConnecitonStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ConnecitonStatus.Name = "ConnecitonStatus";
            this.ConnecitonStatus.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ConnecitonStatus.Size = new System.Drawing.Size(902, 82);
            this.ConnecitonStatus.TabIndex = 24;
            this.ConnecitonStatus.TabStop = false;
            this.ConnecitonStatus.Text = "Connection Status";
            // 
            // ConnectionStatus
            // 
            this.ConnectionStatus.AutoSize = true;
            this.ConnectionStatus.Location = new System.Drawing.Point(15, 31);
            this.ConnectionStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ConnectionStatus.Name = "ConnectionStatus";
            this.ConnectionStatus.Size = new System.Drawing.Size(107, 20);
            this.ConnectionStatus.TabIndex = 0;
            this.ConnectionStatus.Text = "Disconnected";
            // 
            // BottomP
            // 
            this.BottomP.Controls.Add(this.DisconnectButton);
            this.BottomP.Controls.Add(this.UseAsynchronous);
            this.BottomP.Controls.Add(this.CloseButton);
            this.BottomP.Controls.Add(this.ConnectButton);
            this.BottomP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomP.Location = new System.Drawing.Point(0, 659);
            this.BottomP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BottomP.Name = "BottomP";
            this.BottomP.Size = new System.Drawing.Size(902, 45);
            this.BottomP.TabIndex = 25;
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Location = new System.Drawing.Point(135, 5);
            this.DisconnectButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(112, 35);
            this.DisconnectButton.TabIndex = 3;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // UseAsynchronous
            // 
            this.UseAsynchronous.AutoSize = true;
            this.UseAsynchronous.Location = new System.Drawing.Point(276, 11);
            this.UseAsynchronous.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UseAsynchronous.Name = "UseAsynchronous";
            this.UseAsynchronous.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.UseAsynchronous.Size = new System.Drawing.Size(221, 24);
            this.UseAsynchronous.TabIndex = 1;
            this.UseAsynchronous.Text = "Use Asynchronous Pattern";
            this.UseAsynchronous.UseVisualStyleBackColor = true;
            this.UseAsynchronous.CheckedChanged += new System.EventHandler(this.UseAsynchronous_CheckedChanged);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(777, 5);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(112, 35);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.Close_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ConnectButton.Location = new System.Drawing.Point(4, 5);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(122, 35);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.91348F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.08652F));
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "User Name";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Middle
            // 
            this.Middle.AutoScroll = true;
            this.Middle.Controls.Add(this.ConnecitonStatus);
            this.Middle.Controls.Add(this.AuthenticationSettings);
            this.Middle.Controls.Add(this.ConnectionSettings);
            this.Middle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Middle.Location = new System.Drawing.Point(0, 139);
            this.Middle.Name = "Middle";
            this.Middle.Size = new System.Drawing.Size(902, 520);
            this.Middle.TabIndex = 26;
            // 
            // AuthenticationDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 704);
            this.Controls.Add(this.Middle);
            this.Controls.Add(this.BottomP);
            this.Controls.Add(this.Instructions);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AuthenticationDlg";
            this.Text = "Authentication";
            this.BottomPN.ResumeLayout(false);
            this.Instructions.ResumeLayout(false);
            this.InstructionsPN.ResumeLayout(false);
            this.ConnectionSettings.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.AuthenticationSettings.ResumeLayout(false);
            this.AuthenticationTLP.ResumeLayout(false);
            this.AuthenticationTLP.PerformLayout();
            this.UserNameTLP.ResumeLayout(false);
            this.UserNameTLP.PerformLayout();
            this.CertificateDirTLP.ResumeLayout(false);
            this.CertificateDirTLP.PerformLayout();
            this.CertificateStoreTLP.ResumeLayout(false);
            this.CertificateStoreTLP.PerformLayout();
            this.ConnecitonStatus.ResumeLayout(false);
            this.ConnecitonStatus.PerformLayout();
            this.BottomP.ResumeLayout(false);
            this.BottomP.PerformLayout();
            this.Middle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Panel BottomPN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.TableLayoutPanel MainPN;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox Instructions;
        private System.Windows.Forms.Panel InstructionsPN;
        private System.Windows.Forms.Button HelpBTN;
        private System.Windows.Forms.Button ShowCodeButton;
        private System.Windows.Forms.Label InstructionsGB;
        private System.Windows.Forms.GroupBox ConnectionSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox ServerUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox AuthenticationSettings;
        private System.Windows.Forms.TableLayoutPanel AuthenticationTLP;
        private System.Windows.Forms.RadioButton AnonymousButton;
        private System.Windows.Forms.RadioButton UserNameButton;
        private System.Windows.Forms.RadioButton X509Button;
        private System.Windows.Forms.TableLayoutPanel UserNameTLP;
        private System.Windows.Forms.TextBox UserName_Name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel CertificateDirTLP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox X509_Certificate;
        private System.Windows.Forms.GroupBox ConnecitonStatus;
        private System.Windows.Forms.CheckBox UseSecurity;
        private System.Windows.Forms.Label ConnectionStatus;
        private System.Windows.Forms.Panel BottomP;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.CheckBox UseAsynchronous;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.TextBox UserName_Password;
        private System.Windows.Forms.Button BrowseCertificate;
        private System.Windows.Forms.RadioButton X509StoreButton;
        private System.Windows.Forms.TableLayoutPanel CertificateStoreTLP;
        private System.Windows.Forms.TextBox X509StoreCertificate;
        private System.Windows.Forms.TextBox X509StorePath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox InsecureCredicals;
        private System.Windows.Forms.Panel Middle;
    }
}