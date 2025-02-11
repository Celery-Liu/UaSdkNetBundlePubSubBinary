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
    partial class SessionOptionsControl
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
            this.ConnectBrowser = new System.Windows.Forms.WebBrowser();
            this.StartDemoButton = new System.Windows.Forms.Button();
            this.SessionLeftPN = new System.Windows.Forms.Panel();
            this.SessionHistoryReadPN = new System.Windows.Forms.GroupBox();
            this.HistoryReadEventsBTN = new System.Windows.Forms.Button();
            this.HistoryReadProcessedBTN = new System.Windows.Forms.Button();
            this.HistoryReadRawBTN = new System.Windows.Forms.Button();
            this.SessionBrowsePN = new System.Windows.Forms.GroupBox();
            this.TranslateBrowsePathBTN = new System.Windows.Forms.Button();
            this.BrowseBTN = new System.Windows.Forms.Button();
            this.SessionCallPN = new System.Windows.Forms.GroupBox();
            this.CallMethodBTN = new System.Windows.Forms.Button();
            this.SessionWritePN = new System.Windows.Forms.GroupBox();
            this.BasicWriteBTN = new System.Windows.Forms.Button();
            this.SessionReadPN = new System.Windows.Forms.GroupBox();
            this.ReadStructure = new System.Windows.Forms.Button();
            this.ReadWithDataEncodingBTN = new System.Windows.Forms.Button();
            this.ReadWithIndexRangeBTN = new System.Windows.Forms.Button();
            this.ReadAttributeBTN = new System.Windows.Forms.Button();
            this.BasicReadBTN = new System.Windows.Forms.Button();
            this.InstructionsLB = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.Label();
            this.TopPN = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.AddNodesBTN = new System.Windows.Forms.Button();
            this.AddReferencesBTN = new System.Windows.Forms.Button();
            this.DeleteNodesBTN = new System.Windows.Forms.Button();
            this.DeleteReferencesBTN = new System.Windows.Forms.Button();
            this.RegisterNodesBTN = new System.Windows.Forms.Button();
            this.WarningLB = new System.Windows.Forms.Label();
            this.SessionLeftPN.SuspendLayout();
            this.SessionHistoryReadPN.SuspendLayout();
            this.SessionBrowsePN.SuspendLayout();
            this.SessionCallPN.SuspendLayout();
            this.SessionWritePN.SuspendLayout();
            this.SessionReadPN.SuspendLayout();
            this.TopPN.SuspendLayout();
            this.SuspendLayout();
            //
            // ConnectBrowser
            //
            this.ConnectBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectBrowser.Location = new System.Drawing.Point(206, 45);
            this.ConnectBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.ConnectBrowser.Name = "ConnectBrowser";
            this.ConnectBrowser.ScrollBarsEnabled = false;
            this.ConnectBrowser.Size = new System.Drawing.Size(571, 430);
            this.ConnectBrowser.TabIndex = 2;
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
            this.StartDemoButton.TabIndex = 3;
            this.StartDemoButton.Text = "Show Dialog";
            this.StartDemoButton.UseVisualStyleBackColor = false;
            this.StartDemoButton.Click += new System.EventHandler(this.StartDemoButton_Click);
            //
            // SessionLeftPN
            //
            this.SessionLeftPN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(201)))));
            this.SessionLeftPN.Controls.Add(this.SessionHistoryReadPN);
            this.SessionLeftPN.Controls.Add(this.SessionBrowsePN);
            this.SessionLeftPN.Controls.Add(this.SessionCallPN);
            this.SessionLeftPN.Controls.Add(this.SessionWritePN);
            this.SessionLeftPN.Controls.Add(this.SessionReadPN);
            this.SessionLeftPN.Dock = System.Windows.Forms.DockStyle.Left;
            this.SessionLeftPN.Location = new System.Drawing.Point(0, 37);
            this.SessionLeftPN.Name = "SessionLeftPN";
            this.SessionLeftPN.Size = new System.Drawing.Size(200, 446);
            this.SessionLeftPN.TabIndex = 4;
            //
            // SessionHistoryReadPN
            //
            this.SessionHistoryReadPN.Controls.Add(this.HistoryReadEventsBTN);
            this.SessionHistoryReadPN.Controls.Add(this.HistoryReadProcessedBTN);
            this.SessionHistoryReadPN.Controls.Add(this.HistoryReadRawBTN);
            this.SessionHistoryReadPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.SessionHistoryReadPN.Location = new System.Drawing.Point(0, 345);
            this.SessionHistoryReadPN.Name = "SessionHistoryReadPN";
            this.SessionHistoryReadPN.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.SessionHistoryReadPN.Size = new System.Drawing.Size(200, 108);
            this.SessionHistoryReadPN.TabIndex = 3;
            this.SessionHistoryReadPN.TabStop = false;
            this.SessionHistoryReadPN.Text = "History Read";
            //
            // HistoryReadEventsBTN
            //
            this.HistoryReadEventsBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.HistoryReadEventsBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.HistoryReadEventsBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HistoryReadEventsBTN.ForeColor = System.Drawing.Color.White;
            this.HistoryReadEventsBTN.Location = new System.Drawing.Point(6, 72);
            this.HistoryReadEventsBTN.Name = "HistoryReadEventsBTN";
            this.HistoryReadEventsBTN.Size = new System.Drawing.Size(188, 28);
            this.HistoryReadEventsBTN.TabIndex = 14;
            this.HistoryReadEventsBTN.Text = "History Read Events";
            this.HistoryReadEventsBTN.UseVisualStyleBackColor = false;
            this.HistoryReadEventsBTN.Click += new System.EventHandler(this.MenuButton_Click);
            //
            // HistoryReadProcessedBTN
            //
            this.HistoryReadProcessedBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.HistoryReadProcessedBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.HistoryReadProcessedBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HistoryReadProcessedBTN.ForeColor = System.Drawing.Color.White;
            this.HistoryReadProcessedBTN.Location = new System.Drawing.Point(6, 44);
            this.HistoryReadProcessedBTN.Name = "HistoryReadProcessedBTN";
            this.HistoryReadProcessedBTN.Size = new System.Drawing.Size(188, 28);
            this.HistoryReadProcessedBTN.TabIndex = 13;
            this.HistoryReadProcessedBTN.Text = "History Read Processed";
            this.HistoryReadProcessedBTN.UseVisualStyleBackColor = false;
            this.HistoryReadProcessedBTN.Click += new System.EventHandler(this.MenuButton_Click);
            //
            // HistoryReadRawBTN
            //
            this.HistoryReadRawBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.HistoryReadRawBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.HistoryReadRawBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HistoryReadRawBTN.ForeColor = System.Drawing.Color.White;
            this.HistoryReadRawBTN.Location = new System.Drawing.Point(6, 16);
            this.HistoryReadRawBTN.Name = "HistoryReadRawBTN";
            this.HistoryReadRawBTN.Size = new System.Drawing.Size(188, 28);
            this.HistoryReadRawBTN.TabIndex = 12;
            this.HistoryReadRawBTN.Text = "History Read Raw";
            this.HistoryReadRawBTN.UseVisualStyleBackColor = false;
            this.HistoryReadRawBTN.Click += new System.EventHandler(this.MenuButton_Click);
            //
            // SessionBrowsePN
            //
            this.SessionBrowsePN.Controls.Add(this.TranslateBrowsePathBTN);
            this.SessionBrowsePN.Controls.Add(this.BrowseBTN);
            this.SessionBrowsePN.Dock = System.Windows.Forms.DockStyle.Top;
            this.SessionBrowsePN.Location = new System.Drawing.Point(0, 270);
            this.SessionBrowsePN.Name = "SessionBrowsePN";
            this.SessionBrowsePN.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.SessionBrowsePN.Size = new System.Drawing.Size(200, 75);
            this.SessionBrowsePN.TabIndex = 2;
            this.SessionBrowsePN.TabStop = false;
            this.SessionBrowsePN.Text = "Browse/Translate";
            //
            // TranslateBrowsePathBTN
            //
            this.TranslateBrowsePathBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.TranslateBrowsePathBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.TranslateBrowsePathBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TranslateBrowsePathBTN.ForeColor = System.Drawing.Color.White;
            this.TranslateBrowsePathBTN.Location = new System.Drawing.Point(6, 44);
            this.TranslateBrowsePathBTN.Name = "TranslateBrowsePathBTN";
            this.TranslateBrowsePathBTN.Size = new System.Drawing.Size(188, 28);
            this.TranslateBrowsePathBTN.TabIndex = 5;
            this.TranslateBrowsePathBTN.Text = "Translate Browse Paths";
            this.TranslateBrowsePathBTN.UseVisualStyleBackColor = false;
            this.TranslateBrowsePathBTN.Click += new System.EventHandler(this.MenuButton_Click);
            //
            // BrowseBTN
            //
            this.BrowseBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.BrowseBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.BrowseBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseBTN.ForeColor = System.Drawing.Color.White;
            this.BrowseBTN.Location = new System.Drawing.Point(6, 16);
            this.BrowseBTN.Name = "BrowseBTN";
            this.BrowseBTN.Size = new System.Drawing.Size(188, 28);
            this.BrowseBTN.TabIndex = 4;
            this.BrowseBTN.Text = "Browse";
            this.BrowseBTN.UseVisualStyleBackColor = false;
            this.BrowseBTN.Click += new System.EventHandler(this.MenuButton_Click);
            //
            // SessionCallPN
            //
            this.SessionCallPN.Controls.Add(this.CallMethodBTN);
            this.SessionCallPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.SessionCallPN.Location = new System.Drawing.Point(0, 219);
            this.SessionCallPN.Name = "SessionCallPN";
            this.SessionCallPN.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.SessionCallPN.Size = new System.Drawing.Size(200, 51);
            this.SessionCallPN.TabIndex = 1;
            this.SessionCallPN.TabStop = false;
            this.SessionCallPN.Text = "Call";
            //
            // CallMethodBTN
            //
            this.CallMethodBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.CallMethodBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.CallMethodBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CallMethodBTN.ForeColor = System.Drawing.Color.White;
            this.CallMethodBTN.Location = new System.Drawing.Point(6, 16);
            this.CallMethodBTN.Name = "CallMethodBTN";
            this.CallMethodBTN.Size = new System.Drawing.Size(188, 28);
            this.CallMethodBTN.TabIndex = 9;
            this.CallMethodBTN.Text = "Call Method";
            this.CallMethodBTN.UseVisualStyleBackColor = false;
            this.CallMethodBTN.Click += new System.EventHandler(this.MenuButton_Click);
            //
            // SessionWritePN
            //
            this.SessionWritePN.Controls.Add(this.BasicWriteBTN);
            this.SessionWritePN.Dock = System.Windows.Forms.DockStyle.Top;
            this.SessionWritePN.Location = new System.Drawing.Point(0, 171);
            this.SessionWritePN.Name = "SessionWritePN";
            this.SessionWritePN.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.SessionWritePN.Size = new System.Drawing.Size(200, 48);
            this.SessionWritePN.TabIndex = 1;
            this.SessionWritePN.TabStop = false;
            this.SessionWritePN.Text = "Write";
            //
            // BasicWriteBTN
            //
            this.BasicWriteBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.BasicWriteBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.BasicWriteBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BasicWriteBTN.ForeColor = System.Drawing.Color.White;
            this.BasicWriteBTN.Location = new System.Drawing.Point(6, 16);
            this.BasicWriteBTN.Name = "BasicWriteBTN";
            this.BasicWriteBTN.Size = new System.Drawing.Size(188, 28);
            this.BasicWriteBTN.TabIndex = 8;
            this.BasicWriteBTN.Text = "Basic Write";
            this.BasicWriteBTN.UseVisualStyleBackColor = false;
            this.BasicWriteBTN.Click += new System.EventHandler(this.MenuButton_Click);
            //
            // SessionReadPN
            //
            this.SessionReadPN.Controls.Add(this.ReadStructure);
            this.SessionReadPN.Controls.Add(this.ReadWithDataEncodingBTN);
            this.SessionReadPN.Controls.Add(this.ReadWithIndexRangeBTN);
            this.SessionReadPN.Controls.Add(this.ReadAttributeBTN);
            this.SessionReadPN.Controls.Add(this.BasicReadBTN);
            this.SessionReadPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.SessionReadPN.Location = new System.Drawing.Point(0, 0);
            this.SessionReadPN.Name = "SessionReadPN";
            this.SessionReadPN.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.SessionReadPN.Size = new System.Drawing.Size(200, 171);
            this.SessionReadPN.TabIndex = 1;
            this.SessionReadPN.TabStop = false;
            this.SessionReadPN.Text = "Read";
            //
            // ReadStructure
            //
            this.ReadStructure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.ReadStructure.Dock = System.Windows.Forms.DockStyle.Top;
            this.ReadStructure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadStructure.ForeColor = System.Drawing.Color.White;
            this.ReadStructure.Location = new System.Drawing.Point(6, 128);
            this.ReadStructure.Name = "ReadStructure";
            this.ReadStructure.Size = new System.Drawing.Size(188, 28);
            this.ReadStructure.TabIndex = 14;
            this.ReadStructure.Text = "Read Structure";
            this.ReadStructure.UseVisualStyleBackColor = false;
            this.ReadStructure.Click += new System.EventHandler(this.MenuButton_Click);
            //
            // ReadWithDataEncodingBTN
            //
            this.ReadWithDataEncodingBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.ReadWithDataEncodingBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.ReadWithDataEncodingBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadWithDataEncodingBTN.ForeColor = System.Drawing.Color.White;
            this.ReadWithDataEncodingBTN.Location = new System.Drawing.Point(6, 100);
            this.ReadWithDataEncodingBTN.Name = "ReadWithDataEncodingBTN";
            this.ReadWithDataEncodingBTN.Size = new System.Drawing.Size(188, 28);
            this.ReadWithDataEncodingBTN.TabIndex = 12;
            this.ReadWithDataEncodingBTN.Text = "Read With Data Encoding";
            this.ReadWithDataEncodingBTN.UseVisualStyleBackColor = false;
            this.ReadWithDataEncodingBTN.Click += new System.EventHandler(this.MenuButton_Click);
            //
            // ReadWithIndexRangeBTN
            //
            this.ReadWithIndexRangeBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.ReadWithIndexRangeBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.ReadWithIndexRangeBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadWithIndexRangeBTN.ForeColor = System.Drawing.Color.White;
            this.ReadWithIndexRangeBTN.Location = new System.Drawing.Point(6, 72);
            this.ReadWithIndexRangeBTN.Name = "ReadWithIndexRangeBTN";
            this.ReadWithIndexRangeBTN.Size = new System.Drawing.Size(188, 28);
            this.ReadWithIndexRangeBTN.TabIndex = 11;
            this.ReadWithIndexRangeBTN.Text = "Read With Index Range";
            this.ReadWithIndexRangeBTN.UseVisualStyleBackColor = false;
            this.ReadWithIndexRangeBTN.Click += new System.EventHandler(this.MenuButton_Click);
            //
            // ReadAttributeBTN
            //
            this.ReadAttributeBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.ReadAttributeBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.ReadAttributeBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadAttributeBTN.ForeColor = System.Drawing.Color.White;
            this.ReadAttributeBTN.Location = new System.Drawing.Point(6, 44);
            this.ReadAttributeBTN.Name = "ReadAttributeBTN";
            this.ReadAttributeBTN.Size = new System.Drawing.Size(188, 28);
            this.ReadAttributeBTN.TabIndex = 10;
            this.ReadAttributeBTN.Text = "Read Attribute";
            this.ReadAttributeBTN.UseVisualStyleBackColor = false;
            this.ReadAttributeBTN.Click += new System.EventHandler(this.MenuButton_Click);
            //
            // BasicReadBTN
            //
            this.BasicReadBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.BasicReadBTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.BasicReadBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BasicReadBTN.ForeColor = System.Drawing.Color.White;
            this.BasicReadBTN.Location = new System.Drawing.Point(6, 16);
            this.BasicReadBTN.Name = "BasicReadBTN";
            this.BasicReadBTN.Size = new System.Drawing.Size(188, 28);
            this.BasicReadBTN.TabIndex = 13;
            this.BasicReadBTN.Text = "Basic Read";
            this.BasicReadBTN.UseVisualStyleBackColor = false;
            this.BasicReadBTN.Click += new System.EventHandler(this.MenuButton_Click);
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
            this.InstructionsLB.TabIndex = 5;
            this.InstructionsLB.Text = "<instructions>";
            //
            // NameTextBox
            //
            this.NameTextBox.AutoSize = true;
            this.NameTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.NameTextBox.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTextBox.Location = new System.Drawing.Point(220, 50);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(127, 23);
            this.NameTextBox.TabIndex = 6;
            this.NameTextBox.Text = "Demo Name";
            //
            // TopPN
            //
            this.TopPN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(201)))));
            this.TopPN.Controls.Add(this.button1);
            this.TopPN.Controls.Add(this.label1);
            this.TopPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPN.Location = new System.Drawing.Point(0, 0);
            this.TopPN.Name = "TopPN";
            this.TopPN.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.TopPN.Size = new System.Drawing.Size(784, 37);
            this.TopPN.TabIndex = 11;
            this.TopPN.VisibleChanged += new System.EventHandler(this.TopPN_VisibleChanged);
            //
            // button1
            //
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(178)))), ((int)(((byte)(75)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(704, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.ConnectCloseBTN_Click);
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
            this.label1.Text = "Session Examples";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // AddNodesBTN
            //
            this.AddNodesBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.AddNodesBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNodesBTN.ForeColor = System.Drawing.Color.White;
            this.AddNodesBTN.Location = new System.Drawing.Point(238, 329);
            this.AddNodesBTN.Name = "AddNodesBTN";
            this.AddNodesBTN.Size = new System.Drawing.Size(127, 28);
            this.AddNodesBTN.TabIndex = 12;
            this.AddNodesBTN.Text = "Add Nodes";
            this.AddNodesBTN.UseVisualStyleBackColor = false;
            this.AddNodesBTN.Visible = false;
            this.AddNodesBTN.Click += new System.EventHandler(this.AddNodesBTN_Click);
            //
            // AddReferencesBTN
            //
            this.AddReferencesBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.AddReferencesBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddReferencesBTN.ForeColor = System.Drawing.Color.White;
            this.AddReferencesBTN.Location = new System.Drawing.Point(238, 363);
            this.AddReferencesBTN.Name = "AddReferencesBTN";
            this.AddReferencesBTN.Size = new System.Drawing.Size(127, 28);
            this.AddReferencesBTN.TabIndex = 13;
            this.AddReferencesBTN.Text = "Add References";
            this.AddReferencesBTN.UseVisualStyleBackColor = false;
            this.AddReferencesBTN.Visible = false;
            this.AddReferencesBTN.Click += new System.EventHandler(this.AddReferencesBTN_Click);
            //
            // DeleteNodesBTN
            //
            this.DeleteNodesBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.DeleteNodesBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteNodesBTN.ForeColor = System.Drawing.Color.White;
            this.DeleteNodesBTN.Location = new System.Drawing.Point(372, 329);
            this.DeleteNodesBTN.Name = "DeleteNodesBTN";
            this.DeleteNodesBTN.Size = new System.Drawing.Size(127, 28);
            this.DeleteNodesBTN.TabIndex = 14;
            this.DeleteNodesBTN.Text = "Delete Nodes";
            this.DeleteNodesBTN.UseVisualStyleBackColor = false;
            this.DeleteNodesBTN.Visible = false;
            this.DeleteNodesBTN.Click += new System.EventHandler(this.DeleteNodesBTN_Click);
            //
            // DeleteReferencesBTN
            //
            this.DeleteReferencesBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.DeleteReferencesBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteReferencesBTN.ForeColor = System.Drawing.Color.White;
            this.DeleteReferencesBTN.Location = new System.Drawing.Point(372, 363);
            this.DeleteReferencesBTN.Name = "DeleteReferencesBTN";
            this.DeleteReferencesBTN.Size = new System.Drawing.Size(127, 28);
            this.DeleteReferencesBTN.TabIndex = 15;
            this.DeleteReferencesBTN.Text = "Delete References";
            this.DeleteReferencesBTN.UseVisualStyleBackColor = false;
            this.DeleteReferencesBTN.Visible = false;
            this.DeleteReferencesBTN.Click += new System.EventHandler(this.DeleteReferencesBTN_Click);
            //
            // RegisterNodesBTN
            //
            this.RegisterNodesBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(169)))), ((int)(((byte)(40)))));
            this.RegisterNodesBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterNodesBTN.ForeColor = System.Drawing.Color.White;
            this.RegisterNodesBTN.Location = new System.Drawing.Point(505, 329);
            this.RegisterNodesBTN.Name = "RegisterNodesBTN";
            this.RegisterNodesBTN.Size = new System.Drawing.Size(127, 28);
            this.RegisterNodesBTN.TabIndex = 16;
            this.RegisterNodesBTN.Text = "Register Nodes";
            this.RegisterNodesBTN.UseVisualStyleBackColor = false;
            this.RegisterNodesBTN.Visible = false;
            this.RegisterNodesBTN.Click += new System.EventHandler(this.RegisterNodesBTN_Click);
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
            this.WarningLB.TabIndex = 17;
            this.WarningLB.Text = "Cannot connect to Server!";
            this.WarningLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.WarningLB.Visible = false;
            this.WarningLB.Click += new System.EventHandler(this.WarningLB_Click);
            //
            // SessionOptionsControl
            //
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(201)))));
            this.Controls.Add(this.WarningLB);
            this.Controls.Add(this.RegisterNodesBTN);
            this.Controls.Add(this.DeleteReferencesBTN);
            this.Controls.Add(this.DeleteNodesBTN);
            this.Controls.Add(this.AddReferencesBTN);
            this.Controls.Add(this.AddNodesBTN);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.InstructionsLB);
            this.Controls.Add(this.StartDemoButton);
            this.Controls.Add(this.ConnectBrowser);
            this.Controls.Add(this.SessionLeftPN);
            this.Controls.Add(this.TopPN);
            this.Name = "SessionOptionsControl";
            this.Size = new System.Drawing.Size(784, 483);
            this.VisibleChanged += new System.EventHandler(this.Control_VisibleChanged);
            this.SessionLeftPN.ResumeLayout(false);
            this.SessionHistoryReadPN.ResumeLayout(false);
            this.SessionBrowsePN.ResumeLayout(false);
            this.SessionCallPN.ResumeLayout(false);
            this.SessionWritePN.ResumeLayout(false);
            this.SessionReadPN.ResumeLayout(false);
            this.TopPN.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser ConnectBrowser;
        private System.Windows.Forms.Button StartDemoButton;
        private System.Windows.Forms.Panel SessionLeftPN;
        private System.Windows.Forms.GroupBox SessionHistoryReadPN;
        private System.Windows.Forms.Button HistoryReadProcessedBTN;
        private System.Windows.Forms.Button HistoryReadRawBTN;
        private System.Windows.Forms.GroupBox SessionBrowsePN;
        private System.Windows.Forms.Button TranslateBrowsePathBTN;
        private System.Windows.Forms.Button BrowseBTN;
        private System.Windows.Forms.GroupBox SessionCallPN;
        private System.Windows.Forms.Button CallMethodBTN;
        private System.Windows.Forms.GroupBox SessionWritePN;
        private System.Windows.Forms.Button BasicWriteBTN;
        private System.Windows.Forms.GroupBox SessionReadPN;
        private System.Windows.Forms.Button ReadWithDataEncodingBTN;
        private System.Windows.Forms.Button ReadWithIndexRangeBTN;
        private System.Windows.Forms.Button ReadAttributeBTN;
        private System.Windows.Forms.Button BasicReadBTN;
        private System.Windows.Forms.Label InstructionsLB;
        private System.Windows.Forms.Label NameTextBox;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddNodesBTN;
        private System.Windows.Forms.Button AddReferencesBTN;
        private System.Windows.Forms.Button DeleteNodesBTN;
        private System.Windows.Forms.Button DeleteReferencesBTN;
        private System.Windows.Forms.Button RegisterNodesBTN;
        private System.Windows.Forms.Label WarningLB;
        private System.Windows.Forms.Button HistoryReadEventsBTN;
        private System.Windows.Forms.Button ReadStructure;
    }
}
