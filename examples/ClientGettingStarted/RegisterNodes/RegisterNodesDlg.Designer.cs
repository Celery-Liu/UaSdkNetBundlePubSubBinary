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
    partial class RegisterNodesDlg
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
            this.RequestPN = new System.Windows.Forms.TableLayoutPanel();
            this.NodeId2BTN = new System.Windows.Forms.Button();
            this.NodeId1BTN = new System.Windows.Forms.Button();
            this.Alias2LB = new System.Windows.Forms.Label();
            this.Alias1LB = new System.Windows.Forms.Label();
            this.NodeId2LB = new System.Windows.Forms.Label();
            this.Alias2TB = new System.Windows.Forms.TextBox();
            this.NodeId2TB = new System.Windows.Forms.TextBox();
            this.Alias1TB = new System.Windows.Forms.TextBox();
            this.NodeId1TB = new System.Windows.Forms.TextBox();
            this.NodeId1LB = new System.Windows.Forms.Label();
            this.BottomPN = new System.Windows.Forms.Panel();
            this.ReadBTN = new System.Windows.Forms.Button();
            this.UnregisterBTN = new System.Windows.Forms.Button();
            this.UseAsynchCK = new System.Windows.Forms.CheckBox();
            this.RegisterBTN = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.Result1TB = new System.Windows.Forms.TextBox();
            this.Result2TB = new System.Windows.Forms.TextBox();
            this.InstructionsGB = new System.Windows.Forms.GroupBox();
            this.TopPN = new System.Windows.Forms.Panel();
            this.HelpBTN = new System.Windows.Forms.Button();
            this.ShowCodeBTN = new System.Windows.Forms.Button();
            this.InstructionsLB = new System.Windows.Forms.Label();
            this.RequestGB = new System.Windows.Forms.GroupBox();
            this.ResponseGB = new System.Windows.Forms.GroupBox();
            this.ResponsePN = new System.Windows.Forms.TableLayoutPanel();
            this.Result2LB = new System.Windows.Forms.Label();
            this.Result1LB = new System.Windows.Forms.Label();
            this.RequestPN.SuspendLayout();
            this.BottomPN.SuspendLayout();
            this.InstructionsGB.SuspendLayout();
            this.TopPN.SuspendLayout();
            this.RequestGB.SuspendLayout();
            this.ResponseGB.SuspendLayout();
            this.ResponsePN.SuspendLayout();
            this.SuspendLayout();
            //
            // RequestPN
            //
            this.RequestPN.ColumnCount = 4;
            this.RequestPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RequestPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RequestPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RequestPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RequestPN.Controls.Add(this.NodeId2BTN, 2, 3);
            this.RequestPN.Controls.Add(this.NodeId1BTN, 2, 0);
            this.RequestPN.Controls.Add(this.Alias2LB, 0, 4);
            this.RequestPN.Controls.Add(this.Alias1LB, 0, 1);
            this.RequestPN.Controls.Add(this.NodeId2LB, 0, 3);
            this.RequestPN.Controls.Add(this.Alias2TB, 1, 4);
            this.RequestPN.Controls.Add(this.NodeId2TB, 1, 3);
            this.RequestPN.Controls.Add(this.Alias1TB, 1, 1);
            this.RequestPN.Controls.Add(this.NodeId1TB, 1, 0);
            this.RequestPN.Controls.Add(this.NodeId1LB, 0, 0);
            this.RequestPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RequestPN.Location = new System.Drawing.Point(3, 16);
            this.RequestPN.Name = "RequestPN";
            this.RequestPN.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.RequestPN.RowCount = 7;
            this.RequestPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RequestPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RequestPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RequestPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RequestPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RequestPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RequestPN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RequestPN.Size = new System.Drawing.Size(572, 99);
            this.RequestPN.TabIndex = 1;
            //
            // NodeId2BTN
            //
            this.NodeId2BTN.AutoSize = true;
            this.NodeId2BTN.Location = new System.Drawing.Point(542, 50);
            this.NodeId2BTN.Margin = new System.Windows.Forms.Padding(1);
            this.NodeId2BTN.Name = "NodeId2BTN";
            this.NodeId2BTN.Size = new System.Drawing.Size(26, 23);
            this.NodeId2BTN.TabIndex = 13;
            this.NodeId2BTN.Text = "...";
            this.ToolTip.SetToolTip(this.NodeId2BTN, "Displays a dialog to select the second node to register.");
            this.NodeId2BTN.UseVisualStyleBackColor = true;
            this.NodeId2BTN.Click += new System.EventHandler(this.NodeIdBTN_Click);
            //
            // NodeId1BTN
            //
            this.NodeId1BTN.AutoSize = true;
            this.NodeId1BTN.Location = new System.Drawing.Point(542, 1);
            this.NodeId1BTN.Margin = new System.Windows.Forms.Padding(1);
            this.NodeId1BTN.Name = "NodeId1BTN";
            this.NodeId1BTN.Size = new System.Drawing.Size(26, 23);
            this.NodeId1BTN.TabIndex = 12;
            this.NodeId1BTN.Text = "...";
            this.ToolTip.SetToolTip(this.NodeId1BTN, "Displays a dialog to select the first node to register.");
            this.NodeId1BTN.UseVisualStyleBackColor = true;
            this.NodeId1BTN.Click += new System.EventHandler(this.NodeIdBTN_Click);
            //
            // Alias2LB
            //
            this.Alias2LB.AutoSize = true;
            this.Alias2LB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Alias2LB.Location = new System.Drawing.Point(6, 74);
            this.Alias2LB.Name = "Alias2LB";
            this.Alias2LB.Size = new System.Drawing.Size(49, 24);
            this.Alias2LB.TabIndex = 9;
            this.Alias2LB.Text = "Alias #2";
            this.Alias2LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // Alias1LB
            //
            this.Alias1LB.AutoSize = true;
            this.Alias1LB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Alias1LB.Location = new System.Drawing.Point(6, 25);
            this.Alias1LB.Name = "Alias1LB";
            this.Alias1LB.Size = new System.Drawing.Size(49, 24);
            this.Alias1LB.TabIndex = 2;
            this.Alias1LB.Text = "Alias #1";
            this.Alias1LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // NodeId2LB
            //
            this.NodeId2LB.AutoSize = true;
            this.NodeId2LB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodeId2LB.Location = new System.Drawing.Point(6, 49);
            this.NodeId2LB.Name = "NodeId2LB";
            this.NodeId2LB.Size = new System.Drawing.Size(49, 25);
            this.NodeId2LB.TabIndex = 7;
            this.NodeId2LB.Text = "Node #2";
            this.NodeId2LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // Alias2TB
            //
            this.Alias2TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Alias2TB.Location = new System.Drawing.Point(59, 77);
            this.Alias2TB.Margin = new System.Windows.Forms.Padding(1, 3, 1, 1);
            this.Alias2TB.Name = "Alias2TB";
            this.Alias2TB.ReadOnly = true;
            this.Alias2TB.Size = new System.Drawing.Size(481, 20);
            this.Alias2TB.TabIndex = 10;
            this.ToolTip.SetToolTip(this.Alias2TB, "The value to write.");
            //
            // NodeId2TB
            //
            this.NodeId2TB.AllowDrop = true;
            this.NodeId2TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodeId2TB.Location = new System.Drawing.Point(59, 51);
            this.NodeId2TB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.NodeId2TB.Name = "NodeId2TB";
            this.NodeId2TB.Size = new System.Drawing.Size(481, 20);
            this.NodeId2TB.TabIndex = 8;
            this.ToolTip.SetToolTip(this.NodeId2TB, "The NodeId of the second Variable to write.");
            this.NodeId2TB.TextChanged += new System.EventHandler(this.NodeIdTB_TextChanged);
            //
            // Alias1TB
            //
            this.Alias1TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Alias1TB.Location = new System.Drawing.Point(59, 28);
            this.Alias1TB.Margin = new System.Windows.Forms.Padding(1, 3, 1, 1);
            this.Alias1TB.Name = "Alias1TB";
            this.Alias1TB.ReadOnly = true;
            this.Alias1TB.Size = new System.Drawing.Size(481, 20);
            this.Alias1TB.TabIndex = 3;
            this.ToolTip.SetToolTip(this.Alias1TB, "The value to write.");
            //
            // NodeId1TB
            //
            this.NodeId1TB.AllowDrop = true;
            this.NodeId1TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodeId1TB.Location = new System.Drawing.Point(59, 2);
            this.NodeId1TB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.NodeId1TB.Name = "NodeId1TB";
            this.NodeId1TB.Size = new System.Drawing.Size(481, 20);
            this.NodeId1TB.TabIndex = 1;
            this.ToolTip.SetToolTip(this.NodeId1TB, "The NodeId of the first Variable to write.");
            this.NodeId1TB.TextChanged += new System.EventHandler(this.NodeIdTB_TextChanged);
            //
            // NodeId1LB
            //
            this.NodeId1LB.AutoSize = true;
            this.NodeId1LB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodeId1LB.Location = new System.Drawing.Point(6, 0);
            this.NodeId1LB.Name = "NodeId1LB";
            this.NodeId1LB.Size = new System.Drawing.Size(49, 25);
            this.NodeId1LB.TabIndex = 0;
            this.NodeId1LB.Text = "Node #1";
            this.NodeId1LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // BottomPN
            //
            this.BottomPN.Controls.Add(this.ReadBTN);
            this.BottomPN.Controls.Add(this.UnregisterBTN);
            this.BottomPN.Controls.Add(this.UseAsynchCK);
            this.BottomPN.Controls.Add(this.RegisterBTN);
            this.BottomPN.Controls.Add(this.CancelBTN);
            this.BottomPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPN.Location = new System.Drawing.Point(3, 283);
            this.BottomPN.Name = "BottomPN";
            this.BottomPN.Size = new System.Drawing.Size(578, 29);
            this.BottomPN.TabIndex = 0;
            //
            // ReadBTN
            //
            this.ReadBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ReadBTN.Location = new System.Drawing.Point(165, 3);
            this.ReadBTN.Name = "ReadBTN";
            this.ReadBTN.Size = new System.Drawing.Size(75, 23);
            this.ReadBTN.TabIndex = 18;
            this.ReadBTN.Tag = "";
            this.ReadBTN.Text = "Read";
            this.ReadBTN.UseVisualStyleBackColor = true;
            this.ReadBTN.Click += new System.EventHandler(this.ReadBTN_Click);
            //
            // UnregisterBTN
            //
            this.UnregisterBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UnregisterBTN.Location = new System.Drawing.Point(84, 3);
            this.UnregisterBTN.Name = "UnregisterBTN";
            this.UnregisterBTN.Size = new System.Drawing.Size(75, 23);
            this.UnregisterBTN.TabIndex = 17;
            this.UnregisterBTN.Tag = "";
            this.UnregisterBTN.Text = "Unregister";
            this.UnregisterBTN.UseVisualStyleBackColor = true;
            this.UnregisterBTN.Click += new System.EventHandler(this.UnregisterBTN_Click);
            //
            // UseAsynchCK
            //
            this.UseAsynchCK.AutoSize = true;
            this.UseAsynchCK.Location = new System.Drawing.Point(246, 6);
            this.UseAsynchCK.Name = "UseAsynchCK";
            this.UseAsynchCK.Size = new System.Drawing.Size(152, 17);
            this.UseAsynchCK.TabIndex = 16;
            this.UseAsynchCK.Text = "Use Asynchronous Pattern";
            this.UseAsynchCK.UseVisualStyleBackColor = true;
            //
            // RegisterBTN
            //
            this.RegisterBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RegisterBTN.Location = new System.Drawing.Point(3, 3);
            this.RegisterBTN.Name = "RegisterBTN";
            this.RegisterBTN.Size = new System.Drawing.Size(75, 23);
            this.RegisterBTN.TabIndex = 15;
            this.RegisterBTN.Tag = "";
            this.RegisterBTN.Text = "Register";
            this.RegisterBTN.UseVisualStyleBackColor = true;
            this.RegisterBTN.Click += new System.EventHandler(this.RegisterBTN_Click);
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
            this.CancelBTN.UseVisualStyleBackColor = true;
            this.CancelBTN.Click += new System.EventHandler(this.CancelBTN_Click);
            //
            // Result1TB
            //
            this.Result1TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Result1TB.Location = new System.Drawing.Point(60, 3);
            this.Result1TB.Margin = new System.Windows.Forms.Padding(1, 3, 1, 1);
            this.Result1TB.Name = "Result1TB";
            this.Result1TB.ReadOnly = true;
            this.Result1TB.Size = new System.Drawing.Size(511, 20);
            this.Result1TB.TabIndex = 7;
            this.ToolTip.SetToolTip(this.Result1TB, "The result of the first write operation.");
            //
            // Result2TB
            //
            this.Result2TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Result2TB.Location = new System.Drawing.Point(60, 27);
            this.Result2TB.Margin = new System.Windows.Forms.Padding(1, 3, 1, 1);
            this.Result2TB.Name = "Result2TB";
            this.Result2TB.ReadOnly = true;
            this.Result2TB.Size = new System.Drawing.Size(511, 20);
            this.Result2TB.TabIndex = 14;
            this.ToolTip.SetToolTip(this.Result2TB, "The result of the second write operation.");
            //
            // InstructionsGB
            //
            this.InstructionsGB.BackColor = System.Drawing.Color.Transparent;
            this.InstructionsGB.Controls.Add(this.TopPN);
            this.InstructionsGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.InstructionsGB.Location = new System.Drawing.Point(3, 5);
            this.InstructionsGB.Name = "InstructionsGB";
            this.InstructionsGB.Size = new System.Drawing.Size(578, 81);
            this.InstructionsGB.TabIndex = 24;
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
            this.RequestGB.Controls.Add(this.RequestPN);
            this.RequestGB.Location = new System.Drawing.Point(3, 91);
            this.RequestGB.Name = "RequestGB";
            this.RequestGB.Size = new System.Drawing.Size(578, 118);
            this.RequestGB.TabIndex = 25;
            this.RequestGB.TabStop = false;
            this.RequestGB.Text = "Register/Read Request";
            //
            // ResponseGB
            //
            this.ResponseGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ResponseGB.Controls.Add(this.ResponsePN);
            this.ResponseGB.Location = new System.Drawing.Point(3, 214);
            this.ResponseGB.Name = "ResponseGB";
            this.ResponseGB.Size = new System.Drawing.Size(578, 69);
            this.ResponseGB.TabIndex = 26;
            this.ResponseGB.TabStop = false;
            this.ResponseGB.Text = "Read Response";
            //
            // ResponsePN
            //
            this.ResponsePN.ColumnCount = 2;
            this.ResponsePN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ResponsePN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ResponsePN.Controls.Add(this.Result2TB, 1, 1);
            this.ResponsePN.Controls.Add(this.Result2LB, 0, 1);
            this.ResponsePN.Controls.Add(this.Result1TB, 1, 0);
            this.ResponsePN.Controls.Add(this.Result1LB, 0, 0);
            this.ResponsePN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResponsePN.Location = new System.Drawing.Point(3, 16);
            this.ResponsePN.Name = "ResponsePN";
            this.ResponsePN.RowCount = 3;
            this.ResponsePN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ResponsePN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ResponsePN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ResponsePN.Size = new System.Drawing.Size(572, 50);
            this.ResponsePN.TabIndex = 0;
            //
            // Result2LB
            //
            this.Result2LB.AutoSize = true;
            this.Result2LB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Result2LB.Location = new System.Drawing.Point(3, 24);
            this.Result2LB.Name = "Result2LB";
            this.Result2LB.Size = new System.Drawing.Size(53, 24);
            this.Result2LB.TabIndex = 13;
            this.Result2LB.Text = "Result #2";
            this.Result2LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // Result1LB
            //
            this.Result1LB.AutoSize = true;
            this.Result1LB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Result1LB.Location = new System.Drawing.Point(3, 0);
            this.Result1LB.Name = "Result1LB";
            this.Result1LB.Size = new System.Drawing.Size(53, 24);
            this.Result1LB.TabIndex = 6;
            this.Result1LB.Text = "Result #1";
            this.Result1LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // RegisterNodesDlg
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 312);
            this.Controls.Add(this.ResponseGB);
            this.Controls.Add(this.RequestGB);
            this.Controls.Add(this.InstructionsGB);
            this.Controls.Add(this.BottomPN);
            this.MaximumSize = new System.Drawing.Size(600, 350);
            this.MinimumSize = new System.Drawing.Size(600, 350);
            this.Name = "RegisterNodesDlg";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Register/Unregister Nodes";
            this.RequestPN.ResumeLayout(false);
            this.RequestPN.PerformLayout();
            this.BottomPN.ResumeLayout(false);
            this.BottomPN.PerformLayout();
            this.InstructionsGB.ResumeLayout(false);
            this.TopPN.ResumeLayout(false);
            this.RequestGB.ResumeLayout(false);
            this.ResponseGB.ResumeLayout(false);
            this.ResponsePN.ResumeLayout(false);
            this.ResponsePN.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel RequestPN;
        private System.Windows.Forms.Panel BottomPN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.TextBox Alias1TB;
        private System.Windows.Forms.TextBox NodeId1TB;
        private System.Windows.Forms.Label NodeId1LB;
        private System.Windows.Forms.TextBox Alias2TB;
        private System.Windows.Forms.TextBox NodeId2TB;
        private System.Windows.Forms.Label NodeId2LB;
        private System.Windows.Forms.Label Alias2LB;
        private System.Windows.Forms.Label Alias1LB;
        private System.Windows.Forms.GroupBox InstructionsGB;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Button HelpBTN;
        private System.Windows.Forms.Button ShowCodeBTN;
        private System.Windows.Forms.Label InstructionsLB;
        private System.Windows.Forms.GroupBox RequestGB;
        private System.Windows.Forms.GroupBox ResponseGB;
        private System.Windows.Forms.TableLayoutPanel ResponsePN;
        private System.Windows.Forms.TextBox Result1TB;
        private System.Windows.Forms.Label Result1LB;
        private System.Windows.Forms.TextBox Result2TB;
        private System.Windows.Forms.Label Result2LB;
        private System.Windows.Forms.CheckBox UseAsynchCK;
        private System.Windows.Forms.Button RegisterBTN;
        private System.Windows.Forms.Button NodeId2BTN;
        private System.Windows.Forms.Button NodeId1BTN;
        private System.Windows.Forms.Button ReadBTN;
        private System.Windows.Forms.Button UnregisterBTN;
    }
}
