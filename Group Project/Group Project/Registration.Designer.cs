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
            this.components = new System.ComponentModel.Container();
            this.lbRegUser = new System.Windows.Forms.Label();
            this.lbRegPass1 = new System.Windows.Forms.Label();
            this.txtRegUser = new System.Windows.Forms.TextBox();
            this.txtRegPass1 = new System.Windows.Forms.TextBox();
            this.lbRegPass2 = new System.Windows.Forms.Label();
            this.txtRegPass2 = new System.Windows.Forms.TextBox();
            this.ttRegPass = new System.Windows.Forms.ToolTip(this.components);
            this.btnRegReg = new System.Windows.Forms.Button();
            this.btnRegCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbRegUser
            // 
            this.lbRegUser.AutoSize = true;
            this.lbRegUser.Location = new System.Drawing.Point(73, 44);
            this.lbRegUser.Name = "lbRegUser";
            this.lbRegUser.Size = new System.Drawing.Size(58, 13);
            this.lbRegUser.TabIndex = 0;
            this.lbRegUser.Text = "Username:";
            // 
            // lbRegPass1
            // 
            this.lbRegPass1.AutoSize = true;
            this.lbRegPass1.Location = new System.Drawing.Point(75, 80);
            this.lbRegPass1.Name = "lbRegPass1";
            this.lbRegPass1.Size = new System.Drawing.Size(56, 13);
            this.lbRegPass1.TabIndex = 1;
            this.lbRegPass1.Text = "Password:";
            // 
            // txtRegUser
            // 
            this.txtRegUser.Location = new System.Drawing.Point(137, 41);
            this.txtRegUser.MaxLength = 25;
            this.txtRegUser.Name = "txtRegUser";
            this.txtRegUser.Size = new System.Drawing.Size(180, 20);
            this.txtRegUser.TabIndex = 2;
            // 
            // txtRegPass1
            // 
            this.txtRegPass1.Location = new System.Drawing.Point(137, 77);
            this.txtRegPass1.MaxLength = 16;
            this.txtRegPass1.Name = "txtRegPass1";
            this.txtRegPass1.PasswordChar = '*';
            this.txtRegPass1.Size = new System.Drawing.Size(180, 20);
            this.txtRegPass1.TabIndex = 3;
            // 
            // lbRegPass2
            // 
            this.lbRegPass2.AutoSize = true;
            this.lbRegPass2.Location = new System.Drawing.Point(46, 115);
            this.lbRegPass2.Name = "lbRegPass2";
            this.lbRegPass2.Size = new System.Drawing.Size(85, 13);
            this.lbRegPass2.TabIndex = 6;
            this.lbRegPass2.Text = "Verify Password:";
            // 
            // txtRegPass2
            // 
            this.txtRegPass2.Location = new System.Drawing.Point(137, 112);
            this.txtRegPass2.MaxLength = 16;
            this.txtRegPass2.Name = "txtRegPass2";
            this.txtRegPass2.PasswordChar = '*';
            this.txtRegPass2.Size = new System.Drawing.Size(180, 20);
            this.txtRegPass2.TabIndex = 7;
            // 
            // btnRegReg
            // 
            this.btnRegReg.Location = new System.Drawing.Point(242, 145);
            this.btnRegReg.Name = "btnRegReg";
            this.btnRegReg.Size = new System.Drawing.Size(75, 23);
            this.btnRegReg.TabIndex = 8;
            this.btnRegReg.Text = "Register";
            this.btnRegReg.UseVisualStyleBackColor = true;
            this.btnRegReg.Click += new System.EventHandler(this.RegisterAccount);
            // 
            // btnRegCancel
            // 
            this.btnRegCancel.Location = new System.Drawing.Point(49, 145);
            this.btnRegCancel.Name = "btnRegCancel";
            this.btnRegCancel.Size = new System.Drawing.Size(75, 23);
            this.btnRegCancel.TabIndex = 9;
            this.btnRegCancel.Text = "Cancel";
            this.btnRegCancel.UseVisualStyleBackColor = true;
            this.btnRegCancel.Click += new System.EventHandler(this.CancelRegistration);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 206);
            this.Controls.Add(this.btnRegCancel);
            this.Controls.Add(this.btnRegReg);
            this.Controls.Add(this.txtRegPass2);
            this.Controls.Add(this.lbRegPass2);
            this.Controls.Add(this.txtRegPass1);
            this.Controls.Add(this.txtRegUser);
            this.Controls.Add(this.lbRegPass1);
            this.Controls.Add(this.lbRegUser);
            this.Name = "Registration";
            this.Text = "Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbRegUser;
        private System.Windows.Forms.Label lbRegPass1;
        private System.Windows.Forms.TextBox txtRegUser;
        private System.Windows.Forms.TextBox txtRegPass1;
        private System.Windows.Forms.Label lbRegPass2;
        private System.Windows.Forms.TextBox txtRegPass2;
        private System.Windows.Forms.ToolTip ttRegPass;
        private System.Windows.Forms.Button btnRegReg;
        private System.Windows.Forms.Button btnRegCancel;
    }
}