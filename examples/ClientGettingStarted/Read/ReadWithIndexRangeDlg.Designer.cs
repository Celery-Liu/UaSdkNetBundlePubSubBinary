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
    partial class ReadWithIndexRangeDlg
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
            this.ReadBTN = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ViewBTN = new System.Windows.Forms.Button();
            this.ValueTB = new System.Windows.Forms.TextBox();
            this.NodeIdBTN = new System.Windows.Forms.Button();
            this.AttributeCB = new System.Windows.Forms.ComboBox();
            this.NodeIdTB = new System.Windows.Forms.TextBox();
            this.IndexRangeTB = new System.Windows.Forms.TextBox();
            this.NodeIdLB = new System.Windows.Forms.Label();
            this.InstructionsGB = new System.Windows.Forms.GroupBox();
            this.TopPN = new System.Windows.Forms.Panel();
            this.HelpBTN = new System.Windows.Forms.Button();
            this.ShowCodeBTN = new System.Windows.Forms.Button();
            this.InstructionsLB = new System.Windows.Forms.Label();
            this.ResponseGB = new System.Windows.Forms.GroupBox();
            this.ResponsePN = new System.Windows.Forms.TableLayoutPanel();
            this.ValueLB = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.RequestGB = new System.Windows.Forms.GroupBox();
            this.RequestPN = new System.Windows.Forms.TableLayoutPanel();
            this.IndexRangeLB = new System.Windows.Forms.Label();
            this.BottomPN.SuspendLayout();
            this.InstructionsGB.SuspendLayout();
            this.TopPN.SuspendLayout();
            this.ResponseGB.SuspendLayout();
            this.ResponsePN.SuspendLayout();
            this.RequestGB.SuspendLayout();
            this.RequestPN.SuspendLayout();
            this.SuspendLayout();
            //
            // BottomPN
            //
            this.BottomPN.Controls.Add(this.UseAsynchCK);
            this.BottomPN.Controls.Add(this.ReadBTN);
            this.BottomPN.Controls.Add(this.CancelBTN);
            this.BottomPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPN.Location = new System.Drawing.Point(3, 218);
            this.BottomPN.Name = "BottomPN";
            this.BottomPN.Size = new System.Drawing.Size(587, 29);
            this.BottomPN.TabIndex = 0;
            //
            // UseAsynchCK
            //
            this.UseAsynchCK.AutoSize = true;
            this.UseAsynchCK.Location = new System.Drawing.Point(84, 7);
            this.UseAsynchCK.Name = "UseAsynchCK";
            this.UseAsynchCK.Size = new System.Drawing.Size(152, 17);
            this.UseAsynchCK.TabIndex = 14;
            this.UseAsynchCK.Text = "Use Asynchronous Pattern";
            this.UseAsynchCK.UseVisualStyleBackColor = true;
            //
            // ReadBTN
            //
            this.ReadBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ReadBTN.Location = new System.Drawing.Point(3, 3);
            this.ReadBTN.Name = "ReadBTN";
            this.ReadBTN.Size = new System.Drawing.Size(75, 23);
            this.ReadBTN.TabIndex = 13;
            this.ReadBTN.Tag = "";
            this.ReadBTN.Text = "Read";
            this.ReadBTN.UseVisualStyleBackColor = true;
            this.ReadBTN.Click += new System.EventHandler(this.ReadBTN_Click);
            //
            // CancelBTN
            //
            this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBTN.Location = new System.Drawing.Point(509, 3);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelBTN.TabIndex = 2;
            this.CancelBTN.Text = "Close";
            this.CancelBTN.UseVisualStyleBackColor = true;
            this.CancelBTN.Click += new System.EventHandler(this.CancelBTN_Click);
            //
            // ViewBTN
            //
            this.ViewBTN.AutoSize = true;
            this.ViewBTN.Location = new System.Drawing.Point(554, 1);
            this.ViewBTN.Margin = new System.Windows.Forms.Padding(1);
            this.ViewBTN.Name = "ViewBTN";
            this.ViewBTN.Size = new System.Drawing.Size(26, 23);
            this.ViewBTN.TabIndex = 7;
            this.ViewBTN.Text = "...";
            this.ToolTip.SetToolTip(this.ViewBTN, "Shows the details of the value in a dialog.");
            this.ViewBTN.UseVisualStyleBackColor = true;
            this.ViewBTN.Click += new System.EventHandler(this.ViewBTN_Click);
            //
            // ValueTB
            //
            this.ValueTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ValueTB.Location = new System.Drawing.Point(41, 2);
            this.ValueTB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.ValueTB.Name = "ValueTB";
            this.ValueTB.Size = new System.Drawing.Size(511, 20);
            this.ValueTB.TabIndex = 6;
            this.ToolTip.SetToolTip(this.ValueTB, "The value of the attribute.");
            //
            // NodeIdBTN
            //
            this.NodeIdBTN.AutoSize = true;
            this.NodeIdBTN.Location = new System.Drawing.Point(552, 1);
            this.NodeIdBTN.Margin = new System.Windows.Forms.Padding(1);
            this.NodeIdBTN.Name = "NodeIdBTN";
            this.NodeIdBTN.Size = new System.Drawing.Size(28, 24);
            this.NodeIdBTN.TabIndex = 7;
            this.NodeIdBTN.Text = "...";
            this.ToolTip.SetToolTip(this.NodeIdBTN, "Displays a dialog to select the node to read.");
            this.NodeIdBTN.UseVisualStyleBackColor = true;
            this.NodeIdBTN.Click += new System.EventHandler(this.NodeIdBTN_Click);
            //
            // AttributeCB
            //
            this.AttributeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AttributeCB.FormattingEnabled = true;
            this.AttributeCB.Location = new System.Drawing.Point(54, 27);
            this.AttributeCB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.AttributeCB.Name = "AttributeCB";
            this.AttributeCB.Size = new System.Drawing.Size(160, 21);
            this.AttributeCB.TabIndex = 4;
            this.ToolTip.SetToolTip(this.AttributeCB, "The attribute to read.");
            //
            // NodeIdTB
            //
            this.NodeIdTB.AllowDrop = true;
            this.NodeIdTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodeIdTB.Location = new System.Drawing.Point(75, 2);
            this.NodeIdTB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.NodeIdTB.Name = "NodeIdTB";
            this.NodeIdTB.Size = new System.Drawing.Size(475, 20);
            this.NodeIdTB.TabIndex = 2;
            this.NodeIdTB.Text = "ns=2;s=Demo.Static.Arrays.Int32";
            this.ToolTip.SetToolTip(this.NodeIdTB, "The identifier for the node to read. ");
            //
            // IndexRangeTB
            //
            this.IndexRangeTB.AllowDrop = true;
            this.RequestPN.SetColumnSpan(this.IndexRangeTB, 2);
            this.IndexRangeTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IndexRangeTB.Location = new System.Drawing.Point(75, 29);
            this.IndexRangeTB.Margin = new System.Windows.Forms.Padding(1, 3, 1, 1);
            this.IndexRangeTB.Name = "IndexRangeTB";
            this.IndexRangeTB.Size = new System.Drawing.Size(505, 20);
            this.IndexRangeTB.TabIndex = 8;
            this.IndexRangeTB.Text = "1:2";
            this.ToolTip.SetToolTip(this.IndexRangeTB, "The index in the array using the form <first index>:<last index>");
            this.IndexRangeTB.TextChanged += new System.EventHandler(this.IndexRangeTB_TextChanged);
            //
            // NodeIdLB
            //
            this.NodeIdLB.AutoSize = true;
            this.NodeIdLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodeIdLB.Location = new System.Drawing.Point(3, 0);
            this.NodeIdLB.Name = "NodeIdLB";
            this.NodeIdLB.Size = new System.Drawing.Size(68, 26);
            this.NodeIdLB.TabIndex = 1;
            this.NodeIdLB.Text = "Node ID";
            this.NodeIdLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // InstructionsGB
            //
            this.InstructionsGB.BackColor = System.Drawing.Color.Transparent;
            this.InstructionsGB.Controls.Add(this.TopPN);
            this.InstructionsGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.InstructionsGB.Location = new System.Drawing.Point(3, 5);
            this.InstructionsGB.Name = "InstructionsGB";
            this.InstructionsGB.Size = new System.Drawing.Size(587, 81);
            this.InstructionsGB.TabIndex = 23;
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
            this.TopPN.Size = new System.Drawing.Size(581, 62);
            this.TopPN.TabIndex = 2;
            //
            // HelpBTN
            //
            this.HelpBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HelpBTN.Location = new System.Drawing.Point(502, 35);
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
            this.ShowCodeBTN.Location = new System.Drawing.Point(502, 6);
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
            this.InstructionsLB.Size = new System.Drawing.Size(496, 56);
            this.InstructionsLB.TabIndex = 0;
            this.InstructionsLB.Text = "<instructions>";
            //
            // ResponseGB
            //
            this.ResponseGB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ResponseGB.Controls.Add(this.ResponsePN);
            this.ResponseGB.Location = new System.Drawing.Point(3, 170);
            this.ResponseGB.Name = "ResponseGB";
            this.ResponseGB.Size = new System.Drawing.Size(587, 45);
            this.ResponseGB.TabIndex = 25;
            this.ResponseGB.TabStop = false;
            this.ResponseGB.Text = "Read Response";
            //
            // ResponsePN
            //
            this.ResponsePN.ColumnCount = 3;
            this.ResponsePN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ResponsePN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ResponsePN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ResponsePN.Controls.Add(this.ViewBTN, 2, 0);
            this.ResponsePN.Controls.Add(this.ValueTB, 1, 0);
            this.ResponsePN.Controls.Add(this.ValueLB, 0, 0);
            this.ResponsePN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResponsePN.Location = new System.Drawing.Point(3, 16);
            this.ResponsePN.Name = "ResponsePN";
            this.ResponsePN.RowCount = 1;
            this.ResponsePN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ResponsePN.Size = new System.Drawing.Size(581, 26);
            this.ResponsePN.TabIndex = 2;
            //
            // ValueLB
            //
            this.ValueLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ValueLB.Location = new System.Drawing.Point(3, 0);
            this.ValueLB.Name = "ValueLB";
            this.ValueLB.Size = new System.Drawing.Size(34, 27);
            this.ValueLB.TabIndex = 5;
            this.ValueLB.Text = "Value";
            this.ValueLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // tableLayoutPanel1
            //
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            //
            // tableLayoutPanel2
            //
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel2.TabIndex = 0;
            //
            // RequestGB
            //
            this.RequestGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RequestGB.Controls.Add(this.RequestPN);
            this.RequestGB.Location = new System.Drawing.Point(3, 91);
            this.RequestGB.Name = "RequestGB";
            this.RequestGB.Size = new System.Drawing.Size(587, 73);
            this.RequestGB.TabIndex = 24;
            this.RequestGB.TabStop = false;
            this.RequestGB.Text = "Read Request";
            //
            // RequestPN
            //
            this.RequestPN.ColumnCount = 3;
            this.RequestPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RequestPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RequestPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RequestPN.Controls.Add(this.IndexRangeLB, 0, 1);
            this.RequestPN.Controls.Add(this.IndexRangeTB, 1, 1);
            this.RequestPN.Controls.Add(this.NodeIdBTN, 2, 0);
            this.RequestPN.Controls.Add(this.NodeIdTB, 1, 0);
            this.RequestPN.Controls.Add(this.NodeIdLB, 0, 0);
            this.RequestPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RequestPN.Location = new System.Drawing.Point(3, 16);
            this.RequestPN.Name = "RequestPN";
            this.RequestPN.RowCount = 2;
            this.RequestPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RequestPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RequestPN.Size = new System.Drawing.Size(581, 54);
            this.RequestPN.TabIndex = 24;
            //
            // IndexRangeLB
            //
            this.IndexRangeLB.AutoSize = true;
            this.IndexRangeLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IndexRangeLB.Location = new System.Drawing.Point(3, 26);
            this.IndexRangeLB.Name = "IndexRangeLB";
            this.IndexRangeLB.Size = new System.Drawing.Size(68, 28);
            this.IndexRangeLB.TabIndex = 9;
            this.IndexRangeLB.Text = "Index Range";
            this.IndexRangeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // ReadWithIndexRangeDlg
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 247);
            this.Controls.Add(this.ResponseGB);
            this.Controls.Add(this.RequestGB);
            this.Controls.Add(this.InstructionsGB);
            this.Controls.Add(this.BottomPN);
            this.Name = "ReadWithIndexRangeDlg";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Read With Index Range Example";
            this.BottomPN.ResumeLayout(false);
            this.BottomPN.PerformLayout();
            this.InstructionsGB.ResumeLayout(false);
            this.TopPN.ResumeLayout(false);
            this.ResponseGB.ResumeLayout(false);
            this.ResponsePN.ResumeLayout(false);
            this.ResponsePN.PerformLayout();
            this.RequestGB.ResumeLayout(false);
            this.RequestPN.ResumeLayout(false);
            this.RequestPN.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BottomPN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.GroupBox InstructionsGB;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Button HelpBTN;
        private System.Windows.Forms.Button ShowCodeBTN;
        private System.Windows.Forms.Label InstructionsLB;
        private System.Windows.Forms.GroupBox ResponseGB;
        private System.Windows.Forms.TableLayoutPanel ResponsePN;
        private System.Windows.Forms.Button ViewBTN;
        private System.Windows.Forms.TextBox ValueTB;
        private System.Windows.Forms.Label ValueLB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button NodeIdBTN;
        private System.Windows.Forms.ComboBox AttributeCB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox RequestGB;
        private System.Windows.Forms.TableLayoutPanel RequestPN;
        private System.Windows.Forms.Label IndexRangeLB;
        private System.Windows.Forms.TextBox IndexRangeTB;
        private System.Windows.Forms.TextBox NodeIdTB;
        private System.Windows.Forms.Label NodeIdLB;
        private System.Windows.Forms.CheckBox UseAsynchCK;
        private System.Windows.Forms.Button ReadBTN;
    }
}
