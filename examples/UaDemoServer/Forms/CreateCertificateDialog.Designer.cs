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

namespace UnifiedAutomation.Sample
{
    partial class CreateCertificateDialog
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
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.CloseButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.BasicButton = new System.Windows.Forms.Button();
            this.AdvancedButton = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SecurityRightsLabel = new System.Windows.Forms.Label();
            this.WarningLabel = new System.Windows.Forms.Label();
            this.InstructionsGB = new System.Windows.Forms.GroupBox();
            this.TopPN = new System.Windows.Forms.Panel();
            this.HelpBTN = new System.Windows.Forms.Button();
            this.ShowCodeBTN = new System.Windows.Forms.Button();
            this.InstructionsLB = new System.Windows.Forms.Label();
            this.OrganizationUnitTextBox = new System.Windows.Forms.TextBox();
            this.OrganizationUnitLabel = new System.Windows.Forms.Label();
            this.OrganizationNameTextBox = new System.Windows.Forms.TextBox();
            this.OrganizationNameLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.IssuerPasswordTextBox = new System.Windows.Forms.TextBox();
            this.IssuerPasswordLabel = new System.Windows.Forms.Label();
            this.StorePathButton = new System.Windows.Forms.Button();
            this.StorePathTextBox = new System.Windows.Forms.TextBox();
            this.StorePathLabel = new System.Windows.Forms.Label();
            this.IssuerKeyFileTextBox = new System.Windows.Forms.TextBox();
            this.IssuerKeyFileLabel = new System.Windows.Forms.Label();
            this.LifetimeLabel = new System.Windows.Forms.Label();
            this.HashAlgorithmLabel = new System.Windows.Forms.Label();
            this.KeySizeLabel = new System.Windows.Forms.Label();
            this.DomainNamesTextBox = new System.Windows.Forms.TextBox();
            this.DomainNamesLabel = new System.Windows.Forms.Label();
            this.SubjectNameTextBox = new System.Windows.Forms.TextBox();
            this.SubjectNameLabel = new System.Windows.Forms.Label();
            this.CommonNameLabel = new System.Windows.Forms.Label();
            this.ApplicationUriLabel = new System.Windows.Forms.Label();
            this.CommonNameTextBox = new System.Windows.Forms.TextBox();
            this.ApplicationUriTextBox = new System.Windows.Forms.TextBox();
            this.SubjectNameCheckBox = new System.Windows.Forms.CheckBox();
            this.KeySizeComboBox = new System.Windows.Forms.ComboBox();
            this.HashAlgorithmComboBox = new System.Windows.Forms.ComboBox();
            this.IssuerKeyFileButton = new System.Windows.Forms.Button();
            this.LifetimePanel = new System.Windows.Forms.Panel();
            this.LifetimeUnitsLabel = new System.Windows.Forms.Label();
            this.LifetimeUpDown = new System.Windows.Forms.NumericUpDown();
            this.PersistLabel = new System.Windows.Forms.Label();
            this.PersistConfigurationCheckBox = new System.Windows.Forms.CheckBox();
            this.ButtonsPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.InstructionsGB.SuspendLayout();
            this.TopPN.SuspendLayout();
            this.LifetimePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LifetimeUpDown)).BeginInit();
            this.SuspendLayout();
            //
            // ButtonsPanel
            //
            this.ButtonsPanel.Controls.Add(this.CloseButton);
            this.ButtonsPanel.Controls.Add(this.OkButton);
            this.ButtonsPanel.Controls.Add(this.BasicButton);
            this.ButtonsPanel.Controls.Add(this.AdvancedButton);
            this.ButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonsPanel.Location = new System.Drawing.Point(0, 515);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(551, 29);
            this.ButtonsPanel.TabIndex = 0;
            //
            // CloseButton
            //
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(473, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = true;
            //
            // OkButton
            //
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OkButton.Location = new System.Drawing.Point(3, 3);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "Create";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            //
            // BasicButton
            //
            this.BasicButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BasicButton.Location = new System.Drawing.Point(84, 3);
            this.BasicButton.Name = "BasicButton";
            this.BasicButton.Size = new System.Drawing.Size(75, 23);
            this.BasicButton.TabIndex = 3;
            this.BasicButton.Text = "Basic";
            this.BasicButton.UseVisualStyleBackColor = true;
            this.BasicButton.Click += new System.EventHandler(this.BasicButton_Click);
            //
            // AdvancedButton
            //
            this.AdvancedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AdvancedButton.Location = new System.Drawing.Point(83, 3);
            this.AdvancedButton.Name = "AdvancedButton";
            this.AdvancedButton.Size = new System.Drawing.Size(75, 23);
            this.AdvancedButton.TabIndex = 2;
            this.AdvancedButton.Text = "Advanced";
            this.AdvancedButton.UseVisualStyleBackColor = true;
            this.AdvancedButton.Click += new System.EventHandler(this.AdvancedButton_Click);
            //
            // MainPanel
            //
            this.MainPanel.AutoSize = true;
            this.MainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MainPanel.ColumnCount = 3;
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPanel.Controls.Add(this.SecurityRightsLabel, 0, 2);
            this.MainPanel.Controls.Add(this.WarningLabel, 0, 1);
            this.MainPanel.Controls.Add(this.InstructionsGB, 0, 0);
            this.MainPanel.Controls.Add(this.OrganizationUnitTextBox, 1, 5);
            this.MainPanel.Controls.Add(this.OrganizationUnitLabel, 0, 5);
            this.MainPanel.Controls.Add(this.OrganizationNameTextBox, 1, 4);
            this.MainPanel.Controls.Add(this.OrganizationNameLabel, 0, 4);
            this.MainPanel.Controls.Add(this.PasswordTextBox, 1, 12);
            this.MainPanel.Controls.Add(this.PasswordLabel, 0, 12);
            this.MainPanel.Controls.Add(this.IssuerPasswordTextBox, 1, 15);
            this.MainPanel.Controls.Add(this.IssuerPasswordLabel, 0, 15);
            this.MainPanel.Controls.Add(this.StorePathButton, 2, 13);
            this.MainPanel.Controls.Add(this.StorePathTextBox, 1, 13);
            this.MainPanel.Controls.Add(this.StorePathLabel, 0, 13);
            this.MainPanel.Controls.Add(this.IssuerKeyFileTextBox, 1, 14);
            this.MainPanel.Controls.Add(this.IssuerKeyFileLabel, 0, 14);
            this.MainPanel.Controls.Add(this.LifetimeLabel, 0, 11);
            this.MainPanel.Controls.Add(this.HashAlgorithmLabel, 0, 10);
            this.MainPanel.Controls.Add(this.KeySizeLabel, 0, 9);
            this.MainPanel.Controls.Add(this.DomainNamesTextBox, 1, 7);
            this.MainPanel.Controls.Add(this.DomainNamesLabel, 0, 7);
            this.MainPanel.Controls.Add(this.SubjectNameTextBox, 1, 8);
            this.MainPanel.Controls.Add(this.SubjectNameLabel, 0, 8);
            this.MainPanel.Controls.Add(this.CommonNameLabel, 0, 3);
            this.MainPanel.Controls.Add(this.ApplicationUriLabel, 0, 6);
            this.MainPanel.Controls.Add(this.CommonNameTextBox, 1, 3);
            this.MainPanel.Controls.Add(this.ApplicationUriTextBox, 1, 6);
            this.MainPanel.Controls.Add(this.SubjectNameCheckBox, 2, 8);
            this.MainPanel.Controls.Add(this.KeySizeComboBox, 1, 9);
            this.MainPanel.Controls.Add(this.HashAlgorithmComboBox, 1, 10);
            this.MainPanel.Controls.Add(this.IssuerKeyFileButton, 2, 14);
            this.MainPanel.Controls.Add(this.LifetimePanel, 1, 11);
            this.MainPanel.Controls.Add(this.PersistLabel, 0, 16);
            this.MainPanel.Controls.Add(this.PersistConfigurationCheckBox, 1, 16);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.RowCount = 17;
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainPanel.Size = new System.Drawing.Size(551, 515);
            this.MainPanel.TabIndex = 1;
            //
            // SecurityRightsLabel
            //
            this.SecurityRightsLabel.AutoSize = true;
            this.SecurityRightsLabel.BackColor = System.Drawing.Color.Red;
            this.MainPanel.SetColumnSpan(this.SecurityRightsLabel, 3);
            this.SecurityRightsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SecurityRightsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SecurityRightsLabel.ForeColor = System.Drawing.Color.White;
            this.SecurityRightsLabel.Location = new System.Drawing.Point(3, 134);
            this.SecurityRightsLabel.Name = "SecurityRightsLabel";
            this.SecurityRightsLabel.Padding = new System.Windows.Forms.Padding(3);
            this.SecurityRightsLabel.Size = new System.Drawing.Size(545, 19);
            this.SecurityRightsLabel.TabIndex = 53;
            this.SecurityRightsLabel.Text = "Process Does Not Have Adminstrator Rights - Operation May Fail";
            this.SecurityRightsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // WarningLabel
            //
            this.WarningLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WarningLabel.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.WarningLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainPanel.SetColumnSpan(this.WarningLabel, 3);
            this.WarningLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarningLabel.Location = new System.Drawing.Point(6, 93);
            this.WarningLabel.Margin = new System.Windows.Forms.Padding(6);
            this.WarningLabel.Name = "WarningLabel";
            this.WarningLabel.Size = new System.Drawing.Size(539, 35);
            this.WarningLabel.TabIndex = 47;
            this.WarningLabel.Text = "<instructions>";
            //
            // InstructionsGB
            //
            this.InstructionsGB.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.SetColumnSpan(this.InstructionsGB, 3);
            this.InstructionsGB.Controls.Add(this.TopPN);
            this.InstructionsGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.InstructionsGB.Location = new System.Drawing.Point(3, 3);
            this.InstructionsGB.Name = "InstructionsGB";
            this.InstructionsGB.Size = new System.Drawing.Size(545, 81);
            this.InstructionsGB.TabIndex = 46;
            this.InstructionsGB.TabStop = false;
            this.InstructionsGB.Text = "Instructions";
            this.InstructionsGB.Visible = false;
            //
            // TopPN
            //
            this.TopPN.BackColor = System.Drawing.Color.Transparent;
            this.TopPN.Controls.Add(this.HelpBTN);
            this.TopPN.Controls.Add(this.ShowCodeBTN);
            this.TopPN.Controls.Add(this.InstructionsLB);
            this.TopPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopPN.Location = new System.Drawing.Point(3, 16);
            this.TopPN.Name = "TopPN";
            this.TopPN.Padding = new System.Windows.Forms.Padding(3);
            this.TopPN.Size = new System.Drawing.Size(539, 62);
            this.TopPN.TabIndex = 2;
            //
            // HelpBTN
            //
            this.HelpBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HelpBTN.Location = new System.Drawing.Point(460, 35);
            this.HelpBTN.Name = "HelpBTN";
            this.HelpBTN.Size = new System.Drawing.Size(75, 23);
            this.HelpBTN.TabIndex = 2;
            this.HelpBTN.Text = "Help";
            this.HelpBTN.UseVisualStyleBackColor = true;
            //
            // ShowCodeBTN
            //
            this.ShowCodeBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowCodeBTN.Location = new System.Drawing.Point(460, 6);
            this.ShowCodeBTN.Name = "ShowCodeBTN";
            this.ShowCodeBTN.Size = new System.Drawing.Size(75, 23);
            this.ShowCodeBTN.TabIndex = 1;
            this.ShowCodeBTN.Text = "Show Code";
            this.ShowCodeBTN.UseVisualStyleBackColor = true;
            //
            // InstructionsLB
            //
            this.InstructionsLB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstructionsLB.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.InstructionsLB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.InstructionsLB.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsLB.Location = new System.Drawing.Point(3, 3);
            this.InstructionsLB.Margin = new System.Windows.Forms.Padding(0);
            this.InstructionsLB.Name = "InstructionsLB";
            this.InstructionsLB.Padding = new System.Windows.Forms.Padding(3);
            this.InstructionsLB.Size = new System.Drawing.Size(454, 56);
            this.InstructionsLB.TabIndex = 0;
            this.InstructionsLB.Text = "<instructions>";
            //
            // OrganizationUnitTextBox
            //
            this.OrganizationUnitTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrganizationUnitTextBox.Location = new System.Drawing.Point(112, 208);
            this.OrganizationUnitTextBox.Name = "OrganizationUnitTextBox";
            this.OrganizationUnitTextBox.Size = new System.Drawing.Size(409, 20);
            this.OrganizationUnitTextBox.TabIndex = 32;
            this.OrganizationUnitTextBox.TextChanged += new System.EventHandler(this.ApplicationNameTextBox_TextChanged);
            //
            // OrganizationUnitLabel
            //
            this.OrganizationUnitLabel.AutoSize = true;
            this.OrganizationUnitLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrganizationUnitLabel.Location = new System.Drawing.Point(3, 205);
            this.OrganizationUnitLabel.Name = "OrganizationUnitLabel";
            this.OrganizationUnitLabel.Size = new System.Drawing.Size(103, 26);
            this.OrganizationUnitLabel.TabIndex = 31;
            this.OrganizationUnitLabel.Text = "Organizational Unit";
            this.OrganizationUnitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // OrganizationNameTextBox
            //
            this.OrganizationNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrganizationNameTextBox.Location = new System.Drawing.Point(112, 182);
            this.OrganizationNameTextBox.Name = "OrganizationNameTextBox";
            this.OrganizationNameTextBox.Size = new System.Drawing.Size(409, 20);
            this.OrganizationNameTextBox.TabIndex = 30;
            this.OrganizationNameTextBox.TextChanged += new System.EventHandler(this.ApplicationNameTextBox_TextChanged);
            //
            // OrganizationNameLabel
            //
            this.OrganizationNameLabel.AutoSize = true;
            this.OrganizationNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrganizationNameLabel.Location = new System.Drawing.Point(3, 179);
            this.OrganizationNameLabel.Name = "OrganizationNameLabel";
            this.OrganizationNameLabel.Size = new System.Drawing.Size(103, 26);
            this.OrganizationNameLabel.TabIndex = 29;
            this.OrganizationNameLabel.Text = "Organization";
            this.OrganizationNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // PasswordTextBox
            //
            this.PasswordTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PasswordTextBox.Location = new System.Drawing.Point(112, 390);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(409, 20);
            this.PasswordTextBox.TabIndex = 28;
            //
            // PasswordLabel
            //
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PasswordLabel.Location = new System.Drawing.Point(3, 387);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(103, 26);
            this.PasswordLabel.TabIndex = 27;
            this.PasswordLabel.Text = "Password";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // IssuerPasswordTextBox
            //
            this.IssuerPasswordTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IssuerPasswordTextBox.Location = new System.Drawing.Point(112, 468);
            this.IssuerPasswordTextBox.Name = "IssuerPasswordTextBox";
            this.IssuerPasswordTextBox.Size = new System.Drawing.Size(409, 20);
            this.IssuerPasswordTextBox.TabIndex = 23;
            //
            // IssuerPasswordLabel
            //
            this.IssuerPasswordLabel.AutoSize = true;
            this.IssuerPasswordLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IssuerPasswordLabel.Location = new System.Drawing.Point(3, 465);
            this.IssuerPasswordLabel.Name = "IssuerPasswordLabel";
            this.IssuerPasswordLabel.Size = new System.Drawing.Size(103, 26);
            this.IssuerPasswordLabel.TabIndex = 22;
            this.IssuerPasswordLabel.Text = "Issuer Password";
            this.IssuerPasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // StorePathButton
            //
            this.StorePathButton.Location = new System.Drawing.Point(524, 415);
            this.StorePathButton.Margin = new System.Windows.Forms.Padding(0, 2, 3, 3);
            this.StorePathButton.Name = "StorePathButton";
            this.StorePathButton.Size = new System.Drawing.Size(24, 20);
            this.StorePathButton.TabIndex = 21;
            this.StorePathButton.Text = "...";
            this.StorePathButton.UseVisualStyleBackColor = true;
            this.StorePathButton.Click += new System.EventHandler(this.StorePathButton_Click);
            //
            // StorePathTextBox
            //
            this.StorePathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StorePathTextBox.Location = new System.Drawing.Point(112, 416);
            this.StorePathTextBox.Name = "StorePathTextBox";
            this.StorePathTextBox.Size = new System.Drawing.Size(409, 20);
            this.StorePathTextBox.TabIndex = 20;
            //
            // StorePathLabel
            //
            this.StorePathLabel.AutoSize = true;
            this.StorePathLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StorePathLabel.Location = new System.Drawing.Point(3, 413);
            this.StorePathLabel.Name = "StorePathLabel";
            this.StorePathLabel.Size = new System.Drawing.Size(103, 26);
            this.StorePathLabel.TabIndex = 19;
            this.StorePathLabel.Text = "Store Path";
            this.StorePathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // IssuerKeyFileTextBox
            //
            this.IssuerKeyFileTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IssuerKeyFileTextBox.Location = new System.Drawing.Point(112, 442);
            this.IssuerKeyFileTextBox.Name = "IssuerKeyFileTextBox";
            this.IssuerKeyFileTextBox.Size = new System.Drawing.Size(409, 20);
            this.IssuerKeyFileTextBox.TabIndex = 17;
            //
            // IssuerKeyFileLabel
            //
            this.IssuerKeyFileLabel.AutoSize = true;
            this.IssuerKeyFileLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IssuerKeyFileLabel.Location = new System.Drawing.Point(3, 439);
            this.IssuerKeyFileLabel.Name = "IssuerKeyFileLabel";
            this.IssuerKeyFileLabel.Size = new System.Drawing.Size(103, 26);
            this.IssuerKeyFileLabel.TabIndex = 13;
            this.IssuerKeyFileLabel.Text = "Issuer Key File";
            this.IssuerKeyFileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // LifetimeLabel
            //
            this.LifetimeLabel.AutoSize = true;
            this.LifetimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LifetimeLabel.Location = new System.Drawing.Point(3, 361);
            this.LifetimeLabel.Name = "LifetimeLabel";
            this.LifetimeLabel.Size = new System.Drawing.Size(103, 26);
            this.LifetimeLabel.TabIndex = 12;
            this.LifetimeLabel.Text = "Lifetime";
            this.LifetimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // HashAlgorithmLabel
            //
            this.HashAlgorithmLabel.AutoSize = true;
            this.HashAlgorithmLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HashAlgorithmLabel.Location = new System.Drawing.Point(3, 335);
            this.HashAlgorithmLabel.Name = "HashAlgorithmLabel";
            this.HashAlgorithmLabel.Size = new System.Drawing.Size(103, 26);
            this.HashAlgorithmLabel.TabIndex = 11;
            this.HashAlgorithmLabel.Text = "Hash Algorithm";
            this.HashAlgorithmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // KeySizeLabel
            //
            this.KeySizeLabel.AutoSize = true;
            this.KeySizeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KeySizeLabel.Location = new System.Drawing.Point(3, 309);
            this.KeySizeLabel.Name = "KeySizeLabel";
            this.KeySizeLabel.Size = new System.Drawing.Size(103, 26);
            this.KeySizeLabel.TabIndex = 10;
            this.KeySizeLabel.Text = "Key Size";
            this.KeySizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // DomainNamesTextBox
            //
            this.DomainNamesTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DomainNamesTextBox.Location = new System.Drawing.Point(112, 260);
            this.DomainNamesTextBox.Name = "DomainNamesTextBox";
            this.DomainNamesTextBox.Size = new System.Drawing.Size(409, 20);
            this.DomainNamesTextBox.TabIndex = 9;
            this.DomainNamesTextBox.TextChanged += new System.EventHandler(this.DomainNamesTextBox_TextChanged);
            //
            // DomainNamesLabel
            //
            this.DomainNamesLabel.AutoSize = true;
            this.DomainNamesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DomainNamesLabel.Location = new System.Drawing.Point(3, 257);
            this.DomainNamesLabel.Name = "DomainNamesLabel";
            this.DomainNamesLabel.Size = new System.Drawing.Size(103, 26);
            this.DomainNamesLabel.TabIndex = 7;
            this.DomainNamesLabel.Text = "DNS Names";
            this.DomainNamesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // SubjectNameTextBox
            //
            this.SubjectNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubjectNameTextBox.Enabled = false;
            this.SubjectNameTextBox.Location = new System.Drawing.Point(112, 286);
            this.SubjectNameTextBox.Name = "SubjectNameTextBox";
            this.SubjectNameTextBox.Size = new System.Drawing.Size(409, 20);
            this.SubjectNameTextBox.TabIndex = 6;
            //
            // SubjectNameLabel
            //
            this.SubjectNameLabel.AutoSize = true;
            this.SubjectNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubjectNameLabel.Location = new System.Drawing.Point(3, 283);
            this.SubjectNameLabel.Name = "SubjectNameLabel";
            this.SubjectNameLabel.Size = new System.Drawing.Size(103, 26);
            this.SubjectNameLabel.TabIndex = 5;
            this.SubjectNameLabel.Text = "Subject Name";
            this.SubjectNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // CommonNameLabel
            //
            this.CommonNameLabel.AutoSize = true;
            this.CommonNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommonNameLabel.Location = new System.Drawing.Point(3, 153);
            this.CommonNameLabel.Name = "CommonNameLabel";
            this.CommonNameLabel.Size = new System.Drawing.Size(103, 26);
            this.CommonNameLabel.TabIndex = 0;
            this.CommonNameLabel.Text = "Common Name";
            this.CommonNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // ApplicationUriLabel
            //
            this.ApplicationUriLabel.AutoSize = true;
            this.ApplicationUriLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ApplicationUriLabel.Location = new System.Drawing.Point(3, 231);
            this.ApplicationUriLabel.Name = "ApplicationUriLabel";
            this.ApplicationUriLabel.Size = new System.Drawing.Size(103, 26);
            this.ApplicationUriLabel.TabIndex = 1;
            this.ApplicationUriLabel.Text = "Application URI";
            this.ApplicationUriLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // CommonNameTextBox
            //
            this.CommonNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommonNameTextBox.Location = new System.Drawing.Point(112, 156);
            this.CommonNameTextBox.Name = "CommonNameTextBox";
            this.CommonNameTextBox.Size = new System.Drawing.Size(409, 20);
            this.CommonNameTextBox.TabIndex = 2;
            this.CommonNameTextBox.TextChanged += new System.EventHandler(this.ApplicationNameTextBox_TextChanged);
            //
            // ApplicationUriTextBox
            //
            this.ApplicationUriTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ApplicationUriTextBox.Location = new System.Drawing.Point(112, 234);
            this.ApplicationUriTextBox.Name = "ApplicationUriTextBox";
            this.ApplicationUriTextBox.Size = new System.Drawing.Size(409, 20);
            this.ApplicationUriTextBox.TabIndex = 3;
            //
            // SubjectNameCheckBox
            //
            this.SubjectNameCheckBox.AutoSize = true;
            this.SubjectNameCheckBox.Location = new System.Drawing.Point(527, 289);
            this.SubjectNameCheckBox.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.SubjectNameCheckBox.Name = "SubjectNameCheckBox";
            this.SubjectNameCheckBox.Size = new System.Drawing.Size(15, 14);
            this.SubjectNameCheckBox.TabIndex = 8;
            this.SubjectNameCheckBox.UseVisualStyleBackColor = true;
            this.SubjectNameCheckBox.CheckedChanged += new System.EventHandler(this.SubjectNameCheckBox_CheckedChanged);
            //
            // KeySizeComboBox
            //
            this.KeySizeComboBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.KeySizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KeySizeComboBox.FormattingEnabled = true;
            this.KeySizeComboBox.Location = new System.Drawing.Point(112, 312);
            this.KeySizeComboBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.KeySizeComboBox.Name = "KeySizeComboBox";
            this.KeySizeComboBox.Size = new System.Drawing.Size(121, 21);
            this.KeySizeComboBox.TabIndex = 14;
            //
            // HashAlgorithmComboBox
            //
            this.HashAlgorithmComboBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.HashAlgorithmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HashAlgorithmComboBox.FormattingEnabled = true;
            this.HashAlgorithmComboBox.Location = new System.Drawing.Point(112, 338);
            this.HashAlgorithmComboBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.HashAlgorithmComboBox.Name = "HashAlgorithmComboBox";
            this.HashAlgorithmComboBox.Size = new System.Drawing.Size(121, 21);
            this.HashAlgorithmComboBox.TabIndex = 15;
            //
            // IssuerKeyFileButton
            //
            this.IssuerKeyFileButton.Location = new System.Drawing.Point(524, 441);
            this.IssuerKeyFileButton.Margin = new System.Windows.Forms.Padding(0, 2, 3, 3);
            this.IssuerKeyFileButton.Name = "IssuerKeyFileButton";
            this.IssuerKeyFileButton.Size = new System.Drawing.Size(24, 20);
            this.IssuerKeyFileButton.TabIndex = 18;
            this.IssuerKeyFileButton.Text = "...";
            this.IssuerKeyFileButton.UseVisualStyleBackColor = true;
            this.IssuerKeyFileButton.Click += new System.EventHandler(this.IssuerKeyFileButton_Click);
            //
            // LifetimePanel
            //
            this.LifetimePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LifetimePanel.Controls.Add(this.LifetimeUnitsLabel);
            this.LifetimePanel.Controls.Add(this.LifetimeUpDown);
            this.LifetimePanel.Location = new System.Drawing.Point(109, 361);
            this.LifetimePanel.Margin = new System.Windows.Forms.Padding(0);
            this.LifetimePanel.Name = "LifetimePanel";
            this.LifetimePanel.Size = new System.Drawing.Size(415, 26);
            this.LifetimePanel.TabIndex = 26;
            //
            // LifetimeUnitsLabel
            //
            this.LifetimeUnitsLabel.Location = new System.Drawing.Point(85, 2);
            this.LifetimeUnitsLabel.Name = "LifetimeUnitsLabel";
            this.LifetimeUnitsLabel.Size = new System.Drawing.Size(100, 23);
            this.LifetimeUnitsLabel.TabIndex = 27;
            this.LifetimeUnitsLabel.Text = "months";
            this.LifetimeUnitsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // LifetimeUpDown
            //
            this.LifetimeUpDown.Location = new System.Drawing.Point(3, 4);
            this.LifetimeUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.LifetimeUpDown.Name = "LifetimeUpDown";
            this.LifetimeUpDown.Size = new System.Drawing.Size(76, 20);
            this.LifetimeUpDown.TabIndex = 26;
            //
            // PersistLabel
            //
            this.PersistLabel.AutoSize = true;
            this.PersistLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PersistLabel.Location = new System.Drawing.Point(3, 491);
            this.PersistLabel.Name = "PersistLabel";
            this.PersistLabel.Size = new System.Drawing.Size(103, 24);
            this.PersistLabel.TabIndex = 54;
            this.PersistLabel.Text = "Persist Configuration";
            this.PersistLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // PersistConfigurationCheckBox
            //
            this.PersistConfigurationCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PersistConfigurationCheckBox.AutoSize = true;
            this.PersistConfigurationCheckBox.Checked = true;
            this.PersistConfigurationCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PersistConfigurationCheckBox.Location = new System.Drawing.Point(112, 496);
            this.PersistConfigurationCheckBox.Name = "PersistConfigurationCheckBox";
            this.PersistConfigurationCheckBox.Size = new System.Drawing.Size(15, 14);
            this.PersistConfigurationCheckBox.TabIndex = 55;
            this.PersistConfigurationCheckBox.UseVisualStyleBackColor = true;
            //
            // CreateCertificateDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(551, 544);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.ButtonsPanel);
            this.Name = "CreateCertificateDialog";
            this.Text = "Create Certificate";
            this.ButtonsPanel.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.InstructionsGB.ResumeLayout(false);
            this.TopPN.ResumeLayout(false);
            this.LifetimePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LifetimeUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsPanel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.TableLayoutPanel MainPanel;
        private System.Windows.Forms.Label CommonNameLabel;
        private System.Windows.Forms.Label ApplicationUriLabel;
        private System.Windows.Forms.TextBox CommonNameTextBox;
        private System.Windows.Forms.TextBox ApplicationUriTextBox;
        private System.Windows.Forms.Label SubjectNameLabel;
        private System.Windows.Forms.TextBox DomainNamesTextBox;
        private System.Windows.Forms.Label DomainNamesLabel;
        private System.Windows.Forms.TextBox SubjectNameTextBox;
        private System.Windows.Forms.CheckBox SubjectNameCheckBox;
        private System.Windows.Forms.Label LifetimeLabel;
        private System.Windows.Forms.Label HashAlgorithmLabel;
        private System.Windows.Forms.Label KeySizeLabel;
        private System.Windows.Forms.Label IssuerKeyFileLabel;
        private System.Windows.Forms.ComboBox KeySizeComboBox;
        private System.Windows.Forms.ComboBox HashAlgorithmComboBox;
        private System.Windows.Forms.TextBox IssuerKeyFileTextBox;
        private System.Windows.Forms.Button IssuerKeyFileButton;
        private System.Windows.Forms.Label StorePathLabel;
        private System.Windows.Forms.Button StorePathButton;
        private System.Windows.Forms.TextBox StorePathTextBox;
        private System.Windows.Forms.TextBox IssuerPasswordTextBox;
        private System.Windows.Forms.Label IssuerPasswordLabel;
        private System.Windows.Forms.Button BasicButton;
        private System.Windows.Forms.Button AdvancedButton;
        private System.Windows.Forms.Panel LifetimePanel;
        private System.Windows.Forms.Label LifetimeUnitsLabel;
        private System.Windows.Forms.NumericUpDown LifetimeUpDown;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox OrganizationUnitTextBox;
        private System.Windows.Forms.Label OrganizationUnitLabel;
        private System.Windows.Forms.TextBox OrganizationNameTextBox;
        private System.Windows.Forms.Label OrganizationNameLabel;
        private System.Windows.Forms.Label WarningLabel;
        private System.Windows.Forms.GroupBox InstructionsGB;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Button HelpBTN;
        private System.Windows.Forms.Button ShowCodeBTN;
        private System.Windows.Forms.Label InstructionsLB;
        private System.Windows.Forms.Label SecurityRightsLabel;
        private System.Windows.Forms.Label PersistLabel;
        private System.Windows.Forms.CheckBox PersistConfigurationCheckBox;
    }
}
