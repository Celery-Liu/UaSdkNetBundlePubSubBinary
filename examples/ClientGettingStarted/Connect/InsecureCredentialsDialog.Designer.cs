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
    partial class InsecureCredentialsDialog
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
            this.GlobalDescription = new System.Windows.Forms.Label();
            this.DetailedDescription = new System.Windows.Forms.Label();
            this.Accept = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // GlobalDescription
            //
            this.GlobalDescription.AutoSize = true;
            this.GlobalDescription.Location = new System.Drawing.Point(13, 13);
            this.GlobalDescription.Name = "GlobalDescription";
            this.GlobalDescription.Size = new System.Drawing.Size(209, 13);
            this.GlobalDescription.TabIndex = 0;
            this.GlobalDescription.Text = "Insecure Credicals for encrypting password";
            //
            // DetailedDescription
            //
            this.DetailedDescription.AutoSize = true;
            this.DetailedDescription.Location = new System.Drawing.Point(13, 30);
            this.DetailedDescription.MaximumSize = new System.Drawing.Size(0, 100);
            this.DetailedDescription.Name = "DetailedDescription";
            this.DetailedDescription.Size = new System.Drawing.Size(39, 13);
            this.DetailedDescription.TabIndex = 1;
            this.DetailedDescription.Text = "Details";
            //
            // Accept
            //
            this.Accept.Location = new System.Drawing.Point(16, 119);
            this.Accept.Name = "Accept";
            this.Accept.Size = new System.Drawing.Size(100, 23);
            this.Accept.TabIndex = 2;
            this.Accept.Text = "Accept risk";
            this.Accept.UseVisualStyleBackColor = true;
            this.Accept.Click += new System.EventHandler(this.Accept_Click);
            //
            // Cancel
            //
            this.Cancel.Location = new System.Drawing.Point(151, 119);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(100, 23);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "Do not connect";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            //
            // InsecureCredentialsDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 160);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Accept);
            this.Controls.Add(this.DetailedDescription);
            this.Controls.Add(this.GlobalDescription);
            this.Name = "InsecureCredentialsDialog";
            this.Text = "Insecure Credentials";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GlobalDescription;
        private System.Windows.Forms.Label DetailedDescription;
        private System.Windows.Forms.Button Accept;
        private System.Windows.Forms.Button Cancel;
    }
}