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
    partial class MonitorConditionsDlg
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
            System.Windows.Forms.ColumnHeader SourceCH;
            System.Windows.Forms.ColumnHeader TypeCH;
            System.Windows.Forms.ColumnHeader StateCH;
            System.Windows.Forms.ColumnHeader TimeCH;
            System.Windows.Forms.ColumnHeader SeverityCH;
            System.Windows.Forms.ColumnHeader ErrorCH;
            this.BottomPN = new System.Windows.Forms.Panel();
            this.AcknowledgeBTN = new System.Windows.Forms.Button();
            this.RefreshBTN = new System.Windows.Forms.Button();
            this.EventFilterBTN = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ConditionsLV = new System.Windows.Forms.ListView();
            this.InstructionsGB = new System.Windows.Forms.GroupBox();
            this.TopPN = new System.Windows.Forms.Panel();
            this.HelpBTN = new System.Windows.Forms.Button();
            this.ShowCodeBTN = new System.Windows.Forms.Button();
            this.InstructionsLB = new System.Windows.Forms.Label();
            this.ConditionsGB = new System.Windows.Forms.GroupBox();
            SourceCH = new System.Windows.Forms.ColumnHeader();
            TypeCH = new System.Windows.Forms.ColumnHeader();
            StateCH = new System.Windows.Forms.ColumnHeader();
            TimeCH = new System.Windows.Forms.ColumnHeader();
            SeverityCH = new System.Windows.Forms.ColumnHeader();
            ErrorCH = new System.Windows.Forms.ColumnHeader();
            this.BottomPN.SuspendLayout();
            this.InstructionsGB.SuspendLayout();
            this.TopPN.SuspendLayout();
            this.ConditionsGB.SuspendLayout();
            this.SuspendLayout();
            //
            // SourceCH
            //
            SourceCH.Text = "Source";
            //
            // TypeCH
            //
            TypeCH.Text = "Type";
            //
            // StateCH
            //
            StateCH.Text = "State";
            //
            // TimeCH
            //
            TimeCH.Text = "Time";
            //
            // SeverityCH
            //
            SeverityCH.Text = "Severity";
            //
            // ErrorCH
            //
            ErrorCH.Text = "Error";
            //
            // BottomPN
            //
            this.BottomPN.Controls.Add(this.AcknowledgeBTN);
            this.BottomPN.Controls.Add(this.RefreshBTN);
            this.BottomPN.Controls.Add(this.EventFilterBTN);
            this.BottomPN.Controls.Add(this.CancelBTN);
            this.BottomPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPN.Location = new System.Drawing.Point(3, 333);
            this.BottomPN.Name = "BottomPN";
            this.BottomPN.Size = new System.Drawing.Size(578, 29);
            this.BottomPN.TabIndex = 0;
            //
            // AcknowledgeBTN
            //
            this.AcknowledgeBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AcknowledgeBTN.Enabled = false;
            this.AcknowledgeBTN.Location = new System.Drawing.Point(298, 3);
            this.AcknowledgeBTN.Name = "AcknowledgeBTN";
            this.AcknowledgeBTN.Size = new System.Drawing.Size(96, 23);
            this.AcknowledgeBTN.TabIndex = 18;
            this.AcknowledgeBTN.Text = "Acknowledge...";
            this.AcknowledgeBTN.UseVisualStyleBackColor = true;
            this.AcknowledgeBTN.Click += new System.EventHandler(this.AcknowledgeBTN_Click);
            //
            // RefreshBTN
            //
            this.RefreshBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RefreshBTN.Location = new System.Drawing.Point(6, 3);
            this.RefreshBTN.Name = "RefreshBTN";
            this.RefreshBTN.Size = new System.Drawing.Size(70, 23);
            this.RefreshBTN.TabIndex = 17;
            this.RefreshBTN.Text = "Refresh";
            this.RefreshBTN.UseVisualStyleBackColor = true;
            this.RefreshBTN.Click += new System.EventHandler(this.RefreshBTN_Click);
            //
            // EventFilterBTN
            //
            this.EventFilterBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EventFilterBTN.Location = new System.Drawing.Point(400, 3);
            this.EventFilterBTN.Name = "EventFilterBTN";
            this.EventFilterBTN.Size = new System.Drawing.Size(98, 23);
            this.EventFilterBTN.TabIndex = 16;
            this.EventFilterBTN.Text = "Event Filter...";
            this.EventFilterBTN.UseVisualStyleBackColor = true;
            this.EventFilterBTN.Click += new System.EventHandler(this.FilterBTN_Click);
            //
            // CancelBTN
            //
            this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBTN.Location = new System.Drawing.Point(504, 3);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(70, 23);
            this.CancelBTN.TabIndex = 2;
            this.CancelBTN.Text = "Close";
            this.ToolTip.SetToolTip(this.CancelBTN, "Close the dialog.");
            this.CancelBTN.UseVisualStyleBackColor = true;
            //
            // ConditionsLV
            //
            this.ConditionsLV.AllowDrop = true;
            this.ConditionsLV.CheckBoxes = true;
            this.ConditionsLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            SourceCH,
            TypeCH,
            TimeCH,
            SeverityCH,
            StateCH,
            ErrorCH});
            this.ConditionsLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConditionsLV.FullRowSelect = true;
            this.ConditionsLV.Location = new System.Drawing.Point(3, 16);
            this.ConditionsLV.Name = "ConditionsLV";
            this.ConditionsLV.Size = new System.Drawing.Size(566, 214);
            this.ConditionsLV.TabIndex = 15;
            this.ConditionsLV.UseCompatibleStateImageBehavior = false;
            this.ConditionsLV.View = System.Windows.Forms.View.Details;
            this.ConditionsLV.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ConditionsLV_ItemChecked);
            //
            // InstructionsGB
            //
            this.InstructionsGB.BackColor = System.Drawing.Color.Transparent;
            this.InstructionsGB.Controls.Add(this.TopPN);
            this.InstructionsGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.InstructionsGB.Location = new System.Drawing.Point(3, 5);
            this.InstructionsGB.Name = "InstructionsGB";
            this.InstructionsGB.Size = new System.Drawing.Size(578, 81);
            this.InstructionsGB.TabIndex = 21;
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
            // ConditionsGB
            //
            this.ConditionsGB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ConditionsGB.Controls.Add(this.ConditionsLV);
            this.ConditionsGB.Location = new System.Drawing.Point(6, 97);
            this.ConditionsGB.Name = "ConditionsGB";
            this.ConditionsGB.Size = new System.Drawing.Size(572, 233);
            this.ConditionsGB.TabIndex = 22;
            this.ConditionsGB.TabStop = false;
            this.ConditionsGB.Text = "Conditions";
            //
            // MonitorConditionsDlg
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.ConditionsGB);
            this.Controls.Add(this.InstructionsGB);
            this.Controls.Add(this.BottomPN);
            this.Name = "MonitorConditionsDlg";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Monitor Conditions";
            this.BottomPN.ResumeLayout(false);
            this.InstructionsGB.ResumeLayout(false);
            this.TopPN.ResumeLayout(false);
            this.ConditionsGB.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel BottomPN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.ListView ConditionsLV;
        private System.Windows.Forms.Button EventFilterBTN;
        private System.Windows.Forms.Button RefreshBTN;
        private System.Windows.Forms.Button AcknowledgeBTN;
        private System.Windows.Forms.GroupBox InstructionsGB;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Button HelpBTN;
        private System.Windows.Forms.Button ShowCodeBTN;
        private System.Windows.Forms.Label InstructionsLB;
        private System.Windows.Forms.GroupBox ConditionsGB;
    }
}
