namespace Group_Project
{
    partial class Registration
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
            this.lbRegUser = new System.Windows.Forms.Label();
            this.lbRegPass = new System.Windows.Forms.Label();
            this.txtRegUser = new System.Windows.Forms.TextBox();
            this.txtRegPass = new System.Windows.Forms.TextBox();
            this.btnRegReg = new System.Windows.Forms.Button();
            this.btnRegCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbRegUser
            // 
            this.lbRegUser.AutoSize = true;
            this.lbRegUser.Location = new System.Drawing.Point(44, 44);
            this.lbRegUser.Name = "lbRegUser";
            this.lbRegUser.Size = new System.Drawing.Size(58, 13);
            this.lbRegUser.TabIndex = 0;
            this.lbRegUser.Text = "Username:";
            // 
            // lbRegPass
            // 
            this.lbRegPass.AutoSize = true;
            this.lbRegPass.Location = new System.Drawing.Point(44, 80);
            this.lbRegPass.Name = "lbRegPass";
            this.lbRegPass.Size = new System.Drawing.Size(56, 13);
            this.lbRegPass.TabIndex = 1;
            this.lbRegPass.Text = "Password:";
            // 
            // txtRegUser
            // 
            this.txtRegUser.Location = new System.Drawing.Point(105, 41);
            this.txtRegUser.MaxLength = 15;
            this.txtRegUser.Name = "txtRegUser";
            this.txtRegUser.Size = new System.Drawing.Size(181, 20);
            this.txtRegUser.TabIndex = 2;
            // 
            // txtRegPass
            // 
            this.txtRegPass.Location = new System.Drawing.Point(106, 77);
            this.txtRegPass.MaxLength = 16;
            this.txtRegPass.Name = "txtRegPass";
            this.txtRegPass.PasswordChar = '*';
            this.txtRegPass.Size = new System.Drawing.Size(180, 20);
            this.txtRegPass.TabIndex = 3;
            // 
            // btnRegReg
            // 
            this.btnRegReg.Location = new System.Drawing.Point(211, 112);
            this.btnRegReg.Name = "btnRegReg";
            this.btnRegReg.Size = new System.Drawing.Size(75, 23);
            this.btnRegReg.TabIndex = 4;
            this.btnRegReg.Text = "Register";
            this.btnRegReg.UseVisualStyleBackColor = true;
            this.btnRegReg.Click += new System.EventHandler(this.RegisterAccount);
            // 
            // btnRegCancel
            // 
            this.btnRegCancel.Location = new System.Drawing.Point(47, 112);
            this.btnRegCancel.Name = "btnRegCancel";
            this.btnRegCancel.Size = new System.Drawing.Size(75, 23);
            this.btnRegCancel.TabIndex = 5;
            this.btnRegCancel.Text = "Cancel";
            this.btnRegCancel.UseVisualStyleBackColor = true;
            this.btnRegCancel.Click += new System.EventHandler(this.CancelRegistration);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 177);
            this.Controls.Add(this.btnRegCancel);
            this.Controls.Add(this.btnRegReg);
            this.Controls.Add(this.txtRegPass);
            this.Controls.Add(this.txtRegUser);
            this.Controls.Add(this.lbRegPass);
            this.Controls.Add(this.lbRegUser);
            this.Name = "Registration";
            this.Text = "Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbRegUser;
        private System.Windows.Forms.Label lbRegPass;
        private System.Windows.Forms.TextBox txtRegUser;
        private System.Windows.Forms.TextBox txtRegPass;
        private System.Windows.Forms.Button btnRegReg;
        private System.Windows.Forms.Button btnRegCancel;
    }
}