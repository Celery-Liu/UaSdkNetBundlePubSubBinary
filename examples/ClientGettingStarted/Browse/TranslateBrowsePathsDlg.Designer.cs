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
    partial class TranslateBrowsePathsDlg
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
            this.BottomPN = new System.Windows.Forms.Panel();
            this.UseAsynchCK = new System.Windows.Forms.CheckBox();
            this.TranslateBTN = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.NodeIdLB = new System.Windows.Forms.Label();
            this.NodeIdTB = new System.Windows.Forms.TextBox();
            this.PathToTranslate1TB = new System.Windows.Forms.TextBox();
            this.PathToTranslate2TB = new System.Windows.Forms.TextBox();
            this.TranslatedNode2TB = new System.Windows.Forms.TextBox();
            this.TranslatedNode1TB = new System.Windows.Forms.TextBox();
            this.NodeIdBTN = new System.Windows.Forms.Button();
            this.PathToTranslate1LB = new System.Windows.Forms.Label();
            this.MainPN = new System.Windows.Forms.TableLayoutPanel();
            this.PathToTranslate2LB = new System.Windows.Forms.Label();
            this.InstructionsGB = new System.Windows.Forms.GroupBox();
            this.TopPN = new System.Windows.Forms.Panel();
            this.HelpBTN = new System.Windows.Forms.Button();
            this.ShowCodeBTN = new System.Windows.Forms.Button();
            this.InstructionsLB = new System.Windows.Forms.Label();
            this.RequestGB = new System.Windows.Forms.GroupBox();
            this.ResponseGB = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TranslatedNode2LB = new System.Windows.Forms.Label();
            this.TranslatedNode1LB = new System.Windows.Forms.Label();
            this.BottomPN.SuspendLayout();
            this.MainPN.SuspendLayout();
            this.InstructionsGB.SuspendLayout();
            this.TopPN.SuspendLayout();
            this.RequestGB.SuspendLayout();
            this.ResponseGB.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            //
            // BottomPN
            //
            this.BottomPN.Controls.Add(this.UseAsynchCK);
            this.BottomPN.Controls.Add(this.TranslateBTN);
            this.BottomPN.Controls.Add(this.CancelBTN);
            this.BottomPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPN.Location = new System.Drawing.Point(3, 275);
            this.BottomPN.Name = "BottomPN";
            this.BottomPN.Size = new System.Drawing.Size(578, 29);
            this.BottomPN.TabIndex = 0;
            //
            // UseAsynchCK
            //
            this.UseAsynchCK.AutoSize = true;
            this.UseAsynchCK.Location = new System.Drawing.Point(85, 7);
            this.UseAsynchCK.Name = "UseAsynchCK";
            this.UseAsynchCK.Size = new System.Drawing.Size(152, 17);
            this.UseAsynchCK.TabIndex = 6;
            this.UseAsynchCK.Text = "Use Asynchronous Pattern";
            this.UseAsynchCK.UseVisualStyleBackColor = true;
            //
            // TranslateBTN
            //
            this.TranslateBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TranslateBTN.Location = new System.Drawing.Point(3, 3);
            this.TranslateBTN.Name = "TranslateBTN";
            this.TranslateBTN.Size = new System.Drawing.Size(75, 23);
            this.TranslateBTN.TabIndex = 5;
            this.TranslateBTN.Text = "Translate";
            this.TranslateBTN.UseVisualStyleBackColor = true;
            this.TranslateBTN.Click += new System.EventHandler(this.TranslateBTN_Click);
            //
            // CancelBTN
            //
            this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBTN.Location = new System.Drawing.Point(500, 3);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelBTN.TabIndex = 2;
            this.CancelBTN.Text = "Close";
            this.ToolTip.SetToolTip(this.CancelBTN, "Close the dialog.");
            this.CancelBTN.UseVisualStyleBackColor = true;
            this.CancelBTN.Click += new System.EventHandler(this.CancelBTN_Click);
            //
            // NodeIdLB
            //
            this.NodeIdLB.AutoSize = true;
            this.NodeIdLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodeIdLB.Location = new System.Drawing.Point(6, 3);
            this.NodeIdLB.Name = "NodeIdLB";
            this.NodeIdLB.Size = new System.Drawing.Size(97, 26);
            this.NodeIdLB.TabIndex = 0;
            this.NodeIdLB.Text = "Node ID";
            this.NodeIdLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.NodeIdLB, " ");
            //
            // NodeIdTB
            //
            this.NodeIdTB.AllowDrop = true;
            this.NodeIdTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodeIdTB.Location = new System.Drawing.Point(107, 5);
            this.NodeIdTB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 0);
            this.NodeIdTB.Name = "NodeIdTB";
            this.NodeIdTB.Size = new System.Drawing.Size(433, 20);
            this.NodeIdTB.TabIndex = 1;
            this.ToolTip.SetToolTip(this.NodeIdTB, "The identifier for an instance of ServerType.");
            this.NodeIdTB.TextChanged += new System.EventHandler(this.NodeIdTB_TextChanged);
            //
            // PathToTranslate1TB
            //
            this.PathToTranslate1TB.AllowDrop = true;
            this.PathToTranslate1TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PathToTranslate1TB.Location = new System.Drawing.Point(107, 33);
            this.PathToTranslate1TB.Margin = new System.Windows.Forms.Padding(1, 4, 1, 3);
            this.PathToTranslate1TB.Name = "PathToTranslate1TB";
            this.PathToTranslate1TB.Size = new System.Drawing.Size(433, 20);
            this.PathToTranslate1TB.TabIndex = 3;
            this.ToolTip.SetToolTip(this.PathToTranslate1TB, "The identifier for the node to read. ");
            //
            // PathToTranslate2TB
            //
            this.PathToTranslate2TB.AllowDrop = true;
            this.PathToTranslate2TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PathToTranslate2TB.Location = new System.Drawing.Point(107, 60);
            this.PathToTranslate2TB.Margin = new System.Windows.Forms.Padding(1, 4, 1, 3);
            this.PathToTranslate2TB.Name = "PathToTranslate2TB";
            this.PathToTranslate2TB.Size = new System.Drawing.Size(433, 20);
            this.PathToTranslate2TB.TabIndex = 5;
            this.ToolTip.SetToolTip(this.PathToTranslate2TB, "The identifier for the node to read. ");
            //
            // TranslatedNode2TB
            //
            this.TranslatedNode2TB.AllowDrop = true;
            this.TranslatedNode2TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TranslatedNode2TB.Location = new System.Drawing.Point(105, 34);
            this.TranslatedNode2TB.Margin = new System.Windows.Forms.Padding(1, 4, 1, 3);
            this.TranslatedNode2TB.Name = "TranslatedNode2TB";
            this.TranslatedNode2TB.ReadOnly = true;
            this.TranslatedNode2TB.Size = new System.Drawing.Size(463, 20);
            this.TranslatedNode2TB.TabIndex = 5;
            this.ToolTip.SetToolTip(this.TranslatedNode2TB, "The identifier for the node to read. ");
            //
            // TranslatedNode1TB
            //
            this.TranslatedNode1TB.AllowDrop = true;
            this.TranslatedNode1TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TranslatedNode1TB.Location = new System.Drawing.Point(105, 7);
            this.TranslatedNode1TB.Margin = new System.Windows.Forms.Padding(1, 4, 1, 3);
            this.TranslatedNode1TB.Name = "TranslatedNode1TB";
            this.TranslatedNode1TB.ReadOnly = true;
            this.TranslatedNode1TB.Size = new System.Drawing.Size(463, 20);
            this.TranslatedNode1TB.TabIndex = 3;
            this.ToolTip.SetToolTip(this.TranslatedNode1TB, "The identifier for the node to read. ");
            //
            // NodeIdBTN
            //
            this.NodeIdBTN.AutoSize = true;
            this.NodeIdBTN.Location = new System.Drawing.Point(542, 4);
            this.NodeIdBTN.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.NodeIdBTN.Name = "NodeIdBTN";
            this.NodeIdBTN.Size = new System.Drawing.Size(26, 23);
            this.NodeIdBTN.TabIndex = 13;
            this.NodeIdBTN.Text = "...";
            this.ToolTip.SetToolTip(this.NodeIdBTN, "Displays a dialog to select the starting node for the translate operation.");
            this.NodeIdBTN.UseVisualStyleBackColor = true;
            this.NodeIdBTN.Click += new System.EventHandler(this.NodeIdBTN_Click);
            //
            // PathToTranslate1LB
            //
            this.PathToTranslate1LB.AutoSize = true;
            this.PathToTranslate1LB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PathToTranslate1LB.Location = new System.Drawing.Point(6, 29);
            this.PathToTranslate1LB.Name = "PathToTranslate1LB";
            this.PathToTranslate1LB.Size = new System.Drawing.Size(97, 27);
            this.PathToTranslate1LB.TabIndex = 2;
            this.PathToTranslate1LB.Text = "Path to Translate 1";
            this.PathToTranslate1LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // MainPN
            //
            this.MainPN.ColumnCount = 3;
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainPN.Controls.Add(this.NodeIdBTN, 2, 0);
            this.MainPN.Controls.Add(this.PathToTranslate2TB, 1, 2);
            this.MainPN.Controls.Add(this.PathToTranslate2LB, 0, 2);
            this.MainPN.Controls.Add(this.PathToTranslate1TB, 1, 1);
            this.MainPN.Controls.Add(this.PathToTranslate1LB, 0, 1);
            this.MainPN.Controls.Add(this.NodeIdTB, 1, 0);
            this.MainPN.Controls.Add(this.NodeIdLB, 0, 0);
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(3, 16);
            this.MainPN.Name = "MainPN";
            this.MainPN.Padding = new System.Windows.Forms.Padding(3);
            this.MainPN.RowCount = 4;
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainPN.Size = new System.Drawing.Size(572, 81);
            this.MainPN.TabIndex = 1;
            //
            // PathToTranslate2LB
            //
            this.PathToTranslate2LB.AutoSize = true;
            this.PathToTranslate2LB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PathToTranslate2LB.Location = new System.Drawing.Point(6, 56);
            this.PathToTranslate2LB.Name = "PathToTranslate2LB";
            this.PathToTranslate2LB.Size = new System.Drawing.Size(97, 27);
            this.PathToTranslate2LB.TabIndex = 4;
            this.PathToTranslate2LB.Text = "Path to Translate 2";
            this.PathToTranslate2LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // InstructionsGB
            //
            this.InstructionsGB.BackColor = System.Drawing.Color.Transparent;
            this.InstructionsGB.Controls.Add(this.TopPN);
            this.InstructionsGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.InstructionsGB.Location = new System.Drawing.Point(3, 5);
            this.InstructionsGB.Name = "InstructionsGB";
            this.InstructionsGB.Size = new System.Drawing.Size(578, 81);
            this.InstructionsGB.TabIndex = 14;
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
            this.TopPN.Location = new System.Drawing.Point(3, 16);
            this.TopPN.Name = "TopPN";
            this.TopPN.Padding = new System.Windows.Forms.Padding(3);
            this.TopPN.Size = new System.Drawing.Size(572, 62);
            this.TopPN.TabIndex = 2;
            //
            // HelpBTN
            //
            this.HelpBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HelpBTN.Location = new System.Drawing.Point(493, 35);
            this.HelpBTN.Name = "HelpBTN";
            this.HelpBTN.Size = new System.Drawing.Size(75, 23);
            this.HelpBTN.TabIndex = 2;
            this.HelpBTN.Text = "Help";
            this.HelpBTN.UseVisualStyleBackColor = true;
            this.HelpBTN.Click += new System.EventHandler(this.ShowHelpBTN_Click);
            //
            // ShowCodeBTN
            //
            this.ShowCodeBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowCodeBTN.Location = new System.Drawing.Point(493, 6);
            this.ShowCodeBTN.Name = "ShowCodeBTN";
            this.ShowCodeBTN.Size = new System.Drawing.Size(75, 23);
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
            this.InstructionsLB.Location = new System.Drawing.Point(3, 3);
            this.InstructionsLB.Margin = new System.Windows.Forms.Padding(0);
            this.InstructionsLB.Name = "InstructionsLB";
            this.InstructionsLB.Padding = new System.Windows.Forms.Padding(3);
            this.InstructionsLB.Size = new System.Drawing.Size(487, 56);
            this.InstructionsLB.TabIndex = 0;
            this.InstructionsLB.Text = "<instructions>";
            //
            // RequestGB
            //
            this.RequestGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RequestGB.Controls.Add(this.MainPN);
            this.RequestGB.Location = new System.Drawing.Point(3, 91);
            this.RequestGB.Name = "RequestGB";
            this.RequestGB.Size = new System.Drawing.Size(578, 100);
            this.RequestGB.TabIndex = 15;
            this.RequestGB.TabStop = false;
            this.RequestGB.Text = "Translate Request";
            //
            // ResponseGB
            //
            this.ResponseGB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ResponseGB.Controls.Add(this.tableLayoutPanel1);
            this.ResponseGB.Location = new System.Drawing.Point(3, 196);
            this.ResponseGB.Name = "ResponseGB";
            this.ResponseGB.Size = new System.Drawing.Size(578, 76);
            this.ResponseGB.TabIndex = 16;
            this.ResponseGB.TabStop = false;
            this.ResponseGB.Text = "Translate Response";
            //
            // tableLayoutPanel1
            //
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.TranslatedNode2TB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.TranslatedNode2LB, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TranslatedNode1TB, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TranslatedNode1LB, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(572, 57);
            this.tableLayoutPanel1.TabIndex = 1;
            //
            // TranslatedNode2LB
            //
            this.TranslatedNode2LB.AutoSize = true;
            this.TranslatedNode2LB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TranslatedNode2LB.Location = new System.Drawing.Point(6, 30);
            this.TranslatedNode2LB.Name = "TranslatedNode2LB";
            this.TranslatedNode2LB.Size = new System.Drawing.Size(95, 27);
            this.TranslatedNode2LB.TabIndex = 4;
            this.TranslatedNode2LB.Text = "Translated Node 2";
            this.TranslatedNode2LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // TranslatedNode1LB
            //
            this.TranslatedNode1LB.AutoSize = true;
            this.TranslatedNode1LB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TranslatedNode1LB.Location = new System.Drawing.Point(6, 3);
            this.TranslatedNode1LB.Name = "TranslatedNode1LB";
            this.TranslatedNode1LB.Size = new System.Drawing.Size(95, 27);
            this.TranslatedNode1LB.TabIndex = 2;
            this.TranslatedNode1LB.Text = "Translated Node 1";
            this.TranslatedNode1LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // TranslateBrowsePathsDlg
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 304);
            this.Controls.Add(this.ResponseGB);
            this.Controls.Add(this.RequestGB);
            this.Controls.Add(this.InstructionsGB);
            this.Controls.Add(this.BottomPN);
            this.MaximumSize = new System.Drawing.Size(600, 342);
            this.MinimumSize = new System.Drawing.Size(600, 342);
            this.Name = "TranslateBrowsePathsDlg";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Translate Browse Path Example";
            this.BottomPN.ResumeLayout(false);
            this.BottomPN.PerformLayout();
            this.MainPN.ResumeLayout(false);
            this.MainPN.PerformLayout();
            this.InstructionsGB.ResumeLayout(false);
            this.TopPN.ResumeLayout(false);
            this.RequestGB.ResumeLayout(false);
            this.ResponseGB.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BottomPN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Label NodeIdLB;
        private System.Windows.Forms.TextBox NodeIdTB;
        private System.Windows.Forms.Label PathToTranslate1LB;
        private System.Windows.Forms.TextBox PathToTranslate1TB;
        private System.Windows.Forms.TableLayoutPanel MainPN;
        private System.Windows.Forms.TextBox PathToTranslate2TB;
        private System.Windows.Forms.Label PathToTranslate2LB;
        private System.Windows.Forms.GroupBox InstructionsGB;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Button HelpBTN;
        private System.Windows.Forms.Button ShowCodeBTN;
        private System.Windows.Forms.Label InstructionsLB;
        private System.Windows.Forms.GroupBox RequestGB;
        private System.Windows.Forms.GroupBox ResponseGB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox TranslatedNode2TB;
        private System.Windows.Forms.Label TranslatedNode2LB;
        private System.Windows.Forms.TextBox TranslatedNode1TB;
        private System.Windows.Forms.Label TranslatedNode1LB;
        private System.Windows.Forms.Button NodeIdBTN;
        private System.Windows.Forms.CheckBox UseAsynchCK;
        private System.Windows.Forms.Button TranslateBTN;
    }
}
