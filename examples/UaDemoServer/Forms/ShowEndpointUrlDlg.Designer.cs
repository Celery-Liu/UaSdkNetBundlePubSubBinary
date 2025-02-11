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

** This file is a modified, enhanced version or derived work of a file
** originally under MIT License of the OPC Foundation.
** Copyright (c) 2005-2009 The OPC Foundation, Inc. All rights reserved.
** The complete license agreement can be found here:
** http://opcfoundation.org/License/MIT/1.00/
******************************************************************************/

namespace UnifiedAutomation.Sample
{
    partial class ShowEndpointUrlDlg
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
            this.CancelBTN = new System.Windows.Forms.Button();
            this.BottomPN = new System.Windows.Forms.Panel();
            this.MainPN = new System.Windows.Forms.TableLayoutPanel();
            this.EndpointUrlLB = new System.Windows.Forms.Label();
            this.EndpointUrlTB = new System.Windows.Forms.TextBox();
            this.BottomPN.SuspendLayout();
            this.MainPN.SuspendLayout();
            this.SuspendLayout();
            //
            // CancelBTN
            //
            this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBTN.Location = new System.Drawing.Point(163, 4);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelBTN.TabIndex = 0;
            this.CancelBTN.Text = "Close";
            this.CancelBTN.UseVisualStyleBackColor = true;
            //
            // BottomPN
            //
            this.BottomPN.Controls.Add(this.CancelBTN);
            this.BottomPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPN.Location = new System.Drawing.Point(0, 25);
            this.BottomPN.Name = "BottomPN";
            this.BottomPN.Size = new System.Drawing.Size(401, 30);
            this.BottomPN.TabIndex = 0;
            //
            // MainPN
            //
            this.MainPN.AutoSize = true;
            this.MainPN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MainPN.ColumnCount = 2;
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainPN.Controls.Add(this.EndpointUrlLB, 0, 0);
            this.MainPN.Controls.Add(this.EndpointUrlTB, 1, 0);
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(0, 0);
            this.MainPN.Name = "MainPN";
            this.MainPN.RowCount = 2;
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.Size = new System.Drawing.Size(401, 25);
            this.MainPN.TabIndex = 0;
            //
            // EndpointUrlLB
            //
            this.EndpointUrlLB.AutoSize = true;
            this.EndpointUrlLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndpointUrlLB.Location = new System.Drawing.Point(3, 0);
            this.EndpointUrlLB.Name = "EndpointUrlLB";
            this.EndpointUrlLB.Size = new System.Drawing.Size(74, 24);
            this.EndpointUrlLB.TabIndex = 5;
            this.EndpointUrlLB.Text = "Endpoint URL";
            this.EndpointUrlLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // EndpointUrlTB
            //
            this.EndpointUrlTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.EndpointUrlTB.Location = new System.Drawing.Point(82, 2);
            this.EndpointUrlTB.Margin = new System.Windows.Forms.Padding(2);
            this.EndpointUrlTB.Name = "EndpointUrlTB";
            this.EndpointUrlTB.Size = new System.Drawing.Size(317, 20);
            this.EndpointUrlTB.TabIndex = 6;
            //
            // ShowEndpointUrlDlg
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.CancelBTN;
            this.ClientSize = new System.Drawing.Size(401, 55);
            this.Controls.Add(this.MainPN);
            this.Controls.Add(this.BottomPN);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 93);
            this.MinimumSize = new System.Drawing.Size(417, 93);
            this.Name = "ShowEndpointUrlDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View Endpoint URL";
            this.BottomPN.ResumeLayout(false);
            this.MainPN.ResumeLayout(false);
            this.MainPN.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Panel BottomPN;
        private System.Windows.Forms.TextBox EndpointUrlTB;
        private System.Windows.Forms.TableLayoutPanel MainPN;
        private System.Windows.Forms.Label EndpointUrlLB;
    }
}
