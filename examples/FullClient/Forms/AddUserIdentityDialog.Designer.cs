namespace UnifiedAutomation.Sample.Forms
{
    partial class AddUserIdentityDialog
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
            SetBTN = new System.Windows.Forms.Button();
            UserNameTB = new System.Windows.Forms.TextBox();
            PasswordTB = new System.Windows.Forms.TextBox();
            UserNameLBL = new System.Windows.Forms.Label();
            UserPasswordLBL = new System.Windows.Forms.Label();
            CancelBTN = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // SetBTN
            // 
            SetBTN.Location = new System.Drawing.Point(12, 107);
            SetBTN.Name = "SetBTN";
            SetBTN.Size = new System.Drawing.Size(112, 40);
            SetBTN.TabIndex = 3;
            SetBTN.Text = "Set Identity";
            SetBTN.UseVisualStyleBackColor = true;
            SetBTN.Click += SetBTN_Click;
            // 
            // UserNameTB
            // 
            UserNameTB.Location = new System.Drawing.Point(121, 12);
            UserNameTB.Name = "UserNameTB";
            UserNameTB.Size = new System.Drawing.Size(291, 31);
            UserNameTB.TabIndex = 0;
            // 
            // PasswordTB
            // 
            PasswordTB.Location = new System.Drawing.Point(121, 52);
            PasswordTB.Name = "PasswordTB";
            PasswordTB.PasswordChar = '*';
            PasswordTB.Size = new System.Drawing.Size(291, 31);
            PasswordTB.TabIndex = 1;
            // 
            // UserNameLBL
            // 
            UserNameLBL.AutoSize = true;
            UserNameLBL.Location = new System.Drawing.Point(12, 15);
            UserNameLBL.Name = "UserNameLBL";
            UserNameLBL.Size = new System.Drawing.Size(94, 25);
            UserNameLBL.TabIndex = 3;
            UserNameLBL.Text = "UserName";
            // 
            // UserPasswordLBL
            // 
            UserPasswordLBL.AutoSize = true;
            UserPasswordLBL.Location = new System.Drawing.Point(12, 55);
            UserPasswordLBL.Name = "UserPasswordLBL";
            UserPasswordLBL.Size = new System.Drawing.Size(87, 25);
            UserPasswordLBL.TabIndex = 4;
            UserPasswordLBL.Text = "Password";
            // 
            // CancelBTN
            // 
            CancelBTN.Location = new System.Drawing.Point(146, 107);
            CancelBTN.Name = "CancelBTN";
            CancelBTN.Size = new System.Drawing.Size(112, 40);
            CancelBTN.TabIndex = 4;
            CancelBTN.Text = "Cancel";
            CancelBTN.UseVisualStyleBackColor = true;
            CancelBTN.Click += CancelBTN_Click;
            // 
            // AddUserIdentityDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(429, 159);
            Controls.Add(CancelBTN);
            Controls.Add(UserPasswordLBL);
            Controls.Add(UserNameLBL);
            Controls.Add(PasswordTB);
            Controls.Add(UserNameTB);
            Controls.Add(SetBTN);
            Name = "AddUserIdentityDialog";
            Text = "AddUserIdentityDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button SetBTN;
        public System.Windows.Forms.TextBox UserNameTB;
        public System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.Label UserNameLBL;
        private System.Windows.Forms.Label UserPasswordLBL;
        private System.Windows.Forms.Button CancelBTN;
    }
}