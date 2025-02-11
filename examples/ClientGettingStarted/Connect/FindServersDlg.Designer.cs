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
    partial class FindServersDlg
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
            System.Windows.Forms.ColumnHeader ServerNameCH;
            System.Windows.Forms.ColumnHeader FillerCH;
            this.MainPN = new System.Windows.Forms.TableLayoutPanel();
            this.HostNameTB = new System.Windows.Forms.TextBox();
            this.HostNameLB = new System.Windows.Forms.Label();
            this.BottomPN = new System.Windows.Forms.Panel();
            this.UseAsynchCK = new System.Windows.Forms.CheckBox();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.FindServersBTN = new System.Windows.Forms.Button();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.InstructionsGB = new System.Windows.Forms.GroupBox();
            this.TopPN = new System.Windows.Forms.Panel();
            this.HelpBTN = new System.Windows.Forms.Button();
            this.ShowCodeBTN = new System.Windows.Forms.Button();
            this.InstructionsLB = new System.Windows.Forms.Label();
            this.ServersLV = new System.Windows.Forms.ListView();
            this.RequestGB = new System.Windows.Forms.GroupBox();
            this.ResponseGB = new System.Windows.Forms.GroupBox();
            ServerNameCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            FillerCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MainPN.SuspendLayout();
            this.BottomPN.SuspendLayout();
            this.InstructionsGB.SuspendLayout();
            this.TopPN.SuspendLayout();
            this.RequestGB.SuspendLayout();
            this.ResponseGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // ServerNameCH
            // 
            ServerNameCH.Text = "Server Name";
            ServerNameCH.Width = 207;
            // 
            // FillerCH
            // 
            FillerCH.Text = "";
            // 
            // MainPN
            // 
            this.MainPN.ColumnCount = 3;
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.Controls.Add(this.HostNameTB, 1, 0);
            this.MainPN.Controls.Add(this.HostNameLB, 0, 0);
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(4, 24);
            this.MainPN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MainPN.Name = "MainPN";
            this.MainPN.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MainPN.RowCount = 2;
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.MainPN.Size = new System.Drawing.Size(860, 46);
            this.MainPN.TabIndex = 2;
            // 
            // HostNameTB
            // 
            this.HostNameTB.AllowDrop = true;
            this.MainPN.SetColumnSpan(this.HostNameTB, 2);
            this.HostNameTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HostNameTB.Location = new System.Drawing.Point(103, 10);
            this.HostNameTB.Margin = new System.Windows.Forms.Padding(2, 5, 2, 6);
            this.HostNameTB.Name = "HostNameTB";
            this.HostNameTB.Size = new System.Drawing.Size(751, 26);
            this.HostNameTB.TabIndex = 1;
            this.ToolTip.SetToolTip(this.HostNameTB, "The identifier for the node to browse.");
            // 
            // HostNameLB
            // 
            this.HostNameLB.AutoSize = true;
            this.HostNameLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HostNameLB.Location = new System.Drawing.Point(8, 5);
            this.HostNameLB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HostNameLB.Name = "HostNameLB";
            this.HostNameLB.Size = new System.Drawing.Size(89, 37);
            this.HostNameLB.TabIndex = 0;
            this.HostNameLB.Text = "Host Name";
            this.HostNameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.HostNameLB, " ");
            // 
            // BottomPN
            // 
            this.BottomPN.Controls.Add(this.UseAsynchCK);
            this.BottomPN.Controls.Add(this.CancelBTN);
            this.BottomPN.Controls.Add(this.FindServersBTN);
            this.BottomPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPN.Location = new System.Drawing.Point(4, 512);
            this.BottomPN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BottomPN.Name = "BottomPN";
            this.BottomPN.Size = new System.Drawing.Size(868, 45);
            this.BottomPN.TabIndex = 0;
            // 
            // UseAsynchCK
            // 
            this.UseAsynchCK.AutoSize = true;
            this.UseAsynchCK.Location = new System.Drawing.Point(126, 11);
            this.UseAsynchCK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UseAsynchCK.Name = "UseAsynchCK";
            this.UseAsynchCK.Size = new System.Drawing.Size(225, 24);
            this.UseAsynchCK.TabIndex = 1;
            this.UseAsynchCK.Text = "Use Asynchronous Pattern";
            this.UseAsynchCK.UseVisualStyleBackColor = true;
            // 
            // CancelBTN
            // 
            this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBTN.Location = new System.Drawing.Point(751, 5);
            this.CancelBTN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(112, 35);
            this.CancelBTN.TabIndex = 2;
            this.CancelBTN.Text = "Close";
            this.CancelBTN.UseVisualStyleBackColor = true;
            this.CancelBTN.Click += new System.EventHandler(this.CancelBTN_Click);
            // 
            // FindServersBTN
            // 
            this.FindServersBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FindServersBTN.Location = new System.Drawing.Point(4, 5);
            this.FindServersBTN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FindServersBTN.Name = "FindServersBTN";
            this.FindServersBTN.Size = new System.Drawing.Size(112, 35);
            this.FindServersBTN.TabIndex = 0;
            this.FindServersBTN.Text = "Find Servers";
            this.FindServersBTN.UseVisualStyleBackColor = true;
            this.FindServersBTN.Click += new System.EventHandler(this.FindServersBTN_Click);
            // 
            // InstructionsGB
            // 
            this.InstructionsGB.BackColor = System.Drawing.Color.Transparent;
            this.InstructionsGB.Controls.Add(this.TopPN);
            this.InstructionsGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.InstructionsGB.Location = new System.Drawing.Point(4, 8);
            this.InstructionsGB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InstructionsGB.Name = "InstructionsGB";
            this.InstructionsGB.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InstructionsGB.Size = new System.Drawing.Size(868, 125);
            this.InstructionsGB.TabIndex = 15;
            this.InstructionsGB.TabStop = false;
            this.InstructionsGB.Text = "Instructions";
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
            this.TopPN.Size = new System.Drawing.Size(860, 96);
            this.TopPN.TabIndex = 2;
            // 
            // HelpBTN
            // 
            this.HelpBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HelpBTN.Location = new System.Drawing.Point(742, 54);
            this.HelpBTN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HelpBTN.Name = "HelpBTN";
            this.HelpBTN.Size = new System.Drawing.Size(112, 35);
            this.HelpBTN.TabIndex = 2;
            this.HelpBTN.Text = "Help";
            this.HelpBTN.UseVisualStyleBackColor = true;
            this.HelpBTN.Click += new System.EventHandler(this.ShowHelpBTN_Click);
            // 
            // ShowCodeBTN
            // 
            this.ShowCodeBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowCodeBTN.Location = new System.Drawing.Point(742, 9);
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
            this.InstructionsLB.Size = new System.Drawing.Size(732, 87);
            this.InstructionsLB.TabIndex = 0;
            this.InstructionsLB.Text = "<instructions>";
            // 
            // ServersLV
            // 
            this.ServersLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            ServerNameCH,
            FillerCH});
            this.ServersLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServersLV.FullRowSelect = true;
            this.ServersLV.HideSelection = false;
            this.ServersLV.Location = new System.Drawing.Point(4, 24);
            this.ServersLV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ServersLV.MultiSelect = false;
            this.ServersLV.Name = "ServersLV";
            this.ServersLV.Size = new System.Drawing.Size(860, 275);
            this.ServersLV.TabIndex = 16;
            this.ServersLV.UseCompatibleStateImageBehavior = false;
            this.ServersLV.View = System.Windows.Forms.View.Details;
            // 
            // RequestGB
            // 
            this.RequestGB.Controls.Add(this.MainPN);
            this.RequestGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.RequestGB.Location = new System.Drawing.Point(4, 133);
            this.RequestGB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RequestGB.Name = "RequestGB";
            this.RequestGB.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RequestGB.Size = new System.Drawing.Size(868, 75);
            this.RequestGB.TabIndex = 17;
            this.RequestGB.TabStop = false;
            this.RequestGB.Text = "Find Servers Request";
            // 
            // ResponseGB
            // 
            this.ResponseGB.Controls.Add(this.ServersLV);
            this.ResponseGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResponseGB.Location = new System.Drawing.Point(4, 208);
            this.ResponseGB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ResponseGB.Name = "ResponseGB";
            this.ResponseGB.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ResponseGB.Size = new System.Drawing.Size(868, 304);
            this.ResponseGB.TabIndex = 18;
            this.ResponseGB.TabStop = false;
            this.ResponseGB.Text = "Find Servers Response";
            // 
            // FindServersDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 557);
            this.Controls.Add(this.ResponseGB);
            this.Controls.Add(this.BottomPN);
            this.Controls.Add(this.RequestGB);
            this.Controls.Add(this.InstructionsGB);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FindServersDlg";
            this.Padding = new System.Windows.Forms.Padding(4, 8, 4, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Find Servers Example";
            this.MainPN.ResumeLayout(false);
            this.MainPN.PerformLayout();
            this.BottomPN.ResumeLayout(false);
            this.BottomPN.PerformLayout();
            this.InstructionsGB.ResumeLayout(false);
            this.TopPN.ResumeLayout(false);
            this.RequestGB.ResumeLayout(false);
            this.ResponseGB.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainPN;
        private System.Windows.Forms.TextBox HostNameTB;
        private System.Windows.Forms.Label HostNameLB;
        private System.Windows.Forms.Panel BottomPN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Button FindServersBTN;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.CheckBox UseAsynchCK;
        private System.Windows.Forms.GroupBox InstructionsGB;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Button HelpBTN;
        private System.Windows.Forms.Button ShowCodeBTN;
        private System.Windows.Forms.Label InstructionsLB;
        private System.Windows.Forms.ListView ServersLV;
        private System.Windows.Forms.GroupBox RequestGB;
        private System.Windows.Forms.GroupBox ResponseGB;
    }
}
