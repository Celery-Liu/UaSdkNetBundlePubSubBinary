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
    partial class BasicWriteDlg
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.Value2TB = new System.Windows.Forms.Label();
            this.Edit2BTN = new System.Windows.Forms.Button();
            this.NodeId2BTN = new System.Windows.Forms.Button();
            this.NodeId1BTN = new System.Windows.Forms.Button();
            this.Value21LB = new System.Windows.Forms.Label();
            this.Value1LB = new System.Windows.Forms.Label();
            this.Node2LB = new System.Windows.Forms.Label();
            this.Node2TB = new System.Windows.Forms.TextBox();
            this.Node1TB = new System.Windows.Forms.TextBox();
            this.Node1LB = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Value1TB = new System.Windows.Forms.Label();
            this.Edit1BTN = new System.Windows.Forms.Button();
            this.BottomPN = new System.Windows.Forms.Panel();
            this.UseAsynchCK = new System.Windows.Forms.CheckBox();
            this.WriteBTN = new System.Windows.Forms.Button();
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
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.RequestPN.Controls.Add(this.flowLayoutPanel2, 1, 4);
            this.RequestPN.Controls.Add(this.NodeId2BTN, 2, 3);
            this.RequestPN.Controls.Add(this.NodeId1BTN, 2, 0);
            this.RequestPN.Controls.Add(this.Value21LB, 0, 4);
            this.RequestPN.Controls.Add(this.Value1LB, 0, 1);
            this.RequestPN.Controls.Add(this.Node2LB, 0, 3);
            this.RequestPN.Controls.Add(this.Node2TB, 1, 3);
            this.RequestPN.Controls.Add(this.Node1TB, 1, 0);
            this.RequestPN.Controls.Add(this.Node1LB, 0, 0);
            this.RequestPN.Controls.Add(this.flowLayoutPanel1, 1, 1);
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
            // flowLayoutPanel2
            //
            this.flowLayoutPanel2.AutoSize = true;
            this.RequestPN.SetColumnSpan(this.flowLayoutPanel2, 2);
            this.flowLayoutPanel2.Controls.Add(this.Value2TB);
            this.flowLayoutPanel2.Controls.Add(this.Edit2BTN);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(59, 75);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.MaximumSize = new System.Drawing.Size(510, 25);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(510, 25);
            this.flowLayoutPanel2.TabIndex = 15;
            this.flowLayoutPanel2.WrapContents = false;
            //
            // Value2TB
            //
            this.Value2TB.AutoEllipsis = true;
            this.Value2TB.AutoSize = true;
            this.Value2TB.Dock = System.Windows.Forms.DockStyle.Left;
            this.Value2TB.Location = new System.Drawing.Point(1, 1);
            this.Value2TB.Margin = new System.Windows.Forms.Padding(0);
            this.Value2TB.MaximumSize = new System.Drawing.Size(484, 20);
            this.Value2TB.Name = "Value2TB";
            this.Value2TB.Size = new System.Drawing.Size(45, 20);
            this.Value2TB.TabIndex = 0;
            this.Value2TB.Text = "<value>";
            this.Value2TB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // Edit2BTN
            //
            this.Edit2BTN.AutoSize = true;
            this.Edit2BTN.Location = new System.Drawing.Point(47, 2);
            this.Edit2BTN.Margin = new System.Windows.Forms.Padding(1);
            this.Edit2BTN.Name = "Edit2BTN";
            this.Edit2BTN.Size = new System.Drawing.Size(26, 23);
            this.Edit2BTN.TabIndex = 11;
            this.Edit2BTN.Text = "...";
            this.ToolTip.SetToolTip(this.Edit2BTN, "Displays a dialog to edit the second value to write.");
            this.Edit2BTN.UseVisualStyleBackColor = true;
            this.Edit2BTN.Click += new System.EventHandler(this.EditBTN_Click);
            //
            // NodeId2BTN
            //
            this.NodeId2BTN.AutoSize = true;
            this.NodeId2BTN.Location = new System.Drawing.Point(542, 51);
            this.NodeId2BTN.Margin = new System.Windows.Forms.Padding(1);
            this.NodeId2BTN.Name = "NodeId2BTN";
            this.NodeId2BTN.Size = new System.Drawing.Size(26, 23);
            this.NodeId2BTN.TabIndex = 13;
            this.NodeId2BTN.Text = "...";
            this.ToolTip.SetToolTip(this.NodeId2BTN, "Displays a dialog to select the second variable to write.");
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
            this.ToolTip.SetToolTip(this.NodeId1BTN, "Displays a dialog to select the first variable to write.");
            this.NodeId1BTN.UseVisualStyleBackColor = true;
            this.NodeId1BTN.Click += new System.EventHandler(this.NodeIdBTN_Click);
            //
            // Value21LB
            //
            this.Value21LB.AutoSize = true;
            this.Value21LB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Value21LB.Location = new System.Drawing.Point(6, 75);
            this.Value21LB.Name = "Value21LB";
            this.Value21LB.Size = new System.Drawing.Size(50, 25);
            this.Value21LB.TabIndex = 9;
            this.Value21LB.Text = "Value #2";
            this.Value21LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // Value1LB
            //
            this.Value1LB.AutoSize = true;
            this.Value1LB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Value1LB.Location = new System.Drawing.Point(6, 25);
            this.Value1LB.Name = "Value1LB";
            this.Value1LB.Size = new System.Drawing.Size(50, 25);
            this.Value1LB.TabIndex = 2;
            this.Value1LB.Text = "Value #1";
            this.Value1LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // Node2LB
            //
            this.Node2LB.AutoSize = true;
            this.Node2LB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Node2LB.Location = new System.Drawing.Point(6, 50);
            this.Node2LB.Name = "Node2LB";
            this.Node2LB.Size = new System.Drawing.Size(50, 25);
            this.Node2LB.TabIndex = 7;
            this.Node2LB.Text = "Node #2";
            this.Node2LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // Node2TB
            //
            this.Node2TB.AllowDrop = true;
            this.Node2TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Node2TB.Location = new System.Drawing.Point(60, 52);
            this.Node2TB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.Node2TB.Name = "Node2TB";
            this.Node2TB.Size = new System.Drawing.Size(480, 20);
            this.Node2TB.TabIndex = 8;
            this.Node2TB.Text = "ns=2;s=Demo.Static.Scalar.String";
            this.ToolTip.SetToolTip(this.Node2TB, "The NodeId of the second Variable to write.");
            this.Node2TB.TextChanged += new System.EventHandler(this.NodeIdTB_TextChanged);
            //
            // Node1TB
            //
            this.Node1TB.AllowDrop = true;
            this.Node1TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Node1TB.Location = new System.Drawing.Point(60, 2);
            this.Node1TB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.Node1TB.Name = "Node1TB";
            this.Node1TB.Size = new System.Drawing.Size(480, 20);
            this.Node1TB.TabIndex = 1;
            this.Node1TB.Text = "ns=2;s=Demo.Static.Scalar.Int32";
            this.ToolTip.SetToolTip(this.Node1TB, "The NodeId of the first Variable to write.");
            this.Node1TB.TextChanged += new System.EventHandler(this.NodeIdTB_TextChanged);
            //
            // Node1LB
            //
            this.Node1LB.AutoSize = true;
            this.Node1LB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Node1LB.Location = new System.Drawing.Point(6, 0);
            this.Node1LB.Name = "Node1LB";
            this.Node1LB.Size = new System.Drawing.Size(50, 25);
            this.Node1LB.TabIndex = 0;
            this.Node1LB.Text = "Node #1";
            this.Node1LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // flowLayoutPanel1
            //
            this.flowLayoutPanel1.AutoSize = true;
            this.RequestPN.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.Value1TB);
            this.flowLayoutPanel1.Controls.Add(this.Edit1BTN);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(59, 25);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(510, 25);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(510, 25);
            this.flowLayoutPanel1.TabIndex = 14;
            this.flowLayoutPanel1.WrapContents = false;
            //
            // Value1TB
            //
            this.Value1TB.AutoEllipsis = true;
            this.Value1TB.AutoSize = true;
            this.Value1TB.Dock = System.Windows.Forms.DockStyle.Left;
            this.Value1TB.Location = new System.Drawing.Point(2, 2);
            this.Value1TB.Margin = new System.Windows.Forms.Padding(1);
            this.Value1TB.MaximumSize = new System.Drawing.Size(484, 20);
            this.Value1TB.Name = "Value1TB";
            this.Value1TB.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.Value1TB.Size = new System.Drawing.Size(45, 20);
            this.Value1TB.TabIndex = 0;
            this.Value1TB.Text = "<value>";
            this.Value1TB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // Edit1BTN
            //
            this.Edit1BTN.AutoSize = true;
            this.Edit1BTN.Location = new System.Drawing.Point(48, 1);
            this.Edit1BTN.Margin = new System.Windows.Forms.Padding(0);
            this.Edit1BTN.Name = "Edit1BTN";
            this.Edit1BTN.Size = new System.Drawing.Size(26, 23);
            this.Edit1BTN.TabIndex = 4;
            this.Edit1BTN.Text = "...";
            this.ToolTip.SetToolTip(this.Edit1BTN, "Displays a dialog to edit the first value to write.");
            this.Edit1BTN.UseVisualStyleBackColor = true;
            this.Edit1BTN.Click += new System.EventHandler(this.EditBTN_Click);
            //
            // BottomPN
            //
            this.BottomPN.Controls.Add(this.UseAsynchCK);
            this.BottomPN.Controls.Add(this.WriteBTN);
            this.BottomPN.Controls.Add(this.CancelBTN);
            this.BottomPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPN.Location = new System.Drawing.Point(3, 282);
            this.BottomPN.Name = "BottomPN";
            this.BottomPN.Size = new System.Drawing.Size(578, 29);
            this.BottomPN.TabIndex = 0;
            //
            // UseAsynchCK
            //
            this.UseAsynchCK.AutoSize = true;
            this.UseAsynchCK.Location = new System.Drawing.Point(84, 7);
            this.UseAsynchCK.Name = "UseAsynchCK";
            this.UseAsynchCK.Size = new System.Drawing.Size(152, 17);
            this.UseAsynchCK.TabIndex = 16;
            this.UseAsynchCK.Text = "Use Asynchronous Pattern";
            this.UseAsynchCK.UseVisualStyleBackColor = true;
            //
            // WriteBTN
            //
            this.WriteBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WriteBTN.Location = new System.Drawing.Point(3, 3);
            this.WriteBTN.Name = "WriteBTN";
            this.WriteBTN.Size = new System.Drawing.Size(75, 23);
            this.WriteBTN.TabIndex = 15;
            this.WriteBTN.Tag = "";
            this.WriteBTN.Text = "Write";
            this.WriteBTN.UseVisualStyleBackColor = true;
            this.WriteBTN.Click += new System.EventHandler(this.WriteBTN_Click);
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
            this.RequestGB.Text = "Write Request";
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
            this.ResponseGB.Text = "Write Response";
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
            // BasicWriteDlg
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 311);
            this.Controls.Add(this.ResponseGB);
            this.Controls.Add(this.RequestGB);
            this.Controls.Add(this.InstructionsGB);
            this.Controls.Add(this.BottomPN);
            this.MaximumSize = new System.Drawing.Size(600, 350);
            this.MinimumSize = new System.Drawing.Size(600, 350);
            this.Name = "BasicWriteDlg";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Basic Write";
            this.RequestPN.ResumeLayout(false);
            this.RequestPN.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.Button Edit1BTN;
        private System.Windows.Forms.TextBox Node1TB;
        private System.Windows.Forms.Label Node1LB;
        private System.Windows.Forms.TextBox Node2TB;
        private System.Windows.Forms.Label Node2LB;
        private System.Windows.Forms.Button Edit2BTN;
        private System.Windows.Forms.Label Value21LB;
        private System.Windows.Forms.Label Value1LB;
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
        private System.Windows.Forms.Button WriteBTN;
        private System.Windows.Forms.Button NodeId2BTN;
        private System.Windows.Forms.Button NodeId1BTN;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label Value1TB;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label Value2TB;
    }
}
