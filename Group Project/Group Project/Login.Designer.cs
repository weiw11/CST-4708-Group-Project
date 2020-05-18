namespace Group_Project
{
    partial class Login
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BTNregister = new System.Windows.Forms.Button();
            this.TBpassword = new System.Windows.Forms.TextBox();
            this.lbUsername = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.TBusername = new System.Windows.Forms.TextBox();
            this.BTNlogin = new System.Windows.Forms.Button();
            this.LLaboutus = new System.Windows.Forms.LinkLabel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.LLcontactus = new System.Windows.Forms.LinkLabel();
            this.LLSplitter = new System.Windows.Forms.Label();
            this.btnShortcut = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImage = global::Group_Project.Properties.Resources.Black;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.91045F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.08955F));
            this.tableLayoutPanel1.Controls.Add(this.BTNregister, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TBpassword, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbUsername, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbPassword, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TBusername, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.BTNlogin, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(274, 179);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(335, 123);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // BTNregister
            // 
            this.BTNregister.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTNregister.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BTNregister.Font = new System.Drawing.Font("Constantia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNregister.Location = new System.Drawing.Point(7, 81);
            this.BTNregister.Name = "BTNregister";
            this.BTNregister.Size = new System.Drawing.Size(113, 35);
            this.BTNregister.TabIndex = 5;
            this.BTNregister.Text = "Register";
            this.BTNregister.UseVisualStyleBackColor = false;
            this.BTNregister.Click += new System.EventHandler(this.BTNregister_Click);
            // 
            // TBpassword
            // 
            this.TBpassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TBpassword.Font = new System.Drawing.Font("Lucida Sans", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBpassword.Location = new System.Drawing.Point(130, 40);
            this.TBpassword.Name = "TBpassword";
            this.TBpassword.PasswordChar = '*';
            this.TBpassword.Size = new System.Drawing.Size(202, 31);
            this.TBpassword.TabIndex = 3;
            this.TBpassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBpassword_KeyDown);
            // 
            // lbUsername
            // 
            this.lbUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUsername.AutoSize = true;
            this.lbUsername.Font = new System.Drawing.Font("Lucida Sans", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsername.ForeColor = System.Drawing.Color.White;
            this.lbUsername.Location = new System.Drawing.Point(3, 7);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(121, 23);
            this.lbUsername.TabIndex = 0;
            this.lbUsername.Text = "Username:";
            // 
            // lbPassword
            // 
            this.lbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPassword.AutoSize = true;
            this.lbPassword.Font = new System.Drawing.Font("Lucida Sans", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassword.ForeColor = System.Drawing.Color.White;
            this.lbPassword.Location = new System.Drawing.Point(3, 44);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(121, 23);
            this.lbPassword.TabIndex = 1;
            this.lbPassword.Text = "Password:";
            // 
            // TBusername
            // 
            this.TBusername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TBusername.Font = new System.Drawing.Font("Lucida Sans", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBusername.Location = new System.Drawing.Point(130, 3);
            this.TBusername.Name = "TBusername";
            this.TBusername.Size = new System.Drawing.Size(202, 31);
            this.TBusername.TabIndex = 2;
            // 
            // BTNlogin
            // 
            this.BTNlogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTNlogin.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BTNlogin.Font = new System.Drawing.Font("Constantia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNlogin.Location = new System.Drawing.Point(156, 81);
            this.BTNlogin.Name = "BTNlogin";
            this.BTNlogin.Size = new System.Drawing.Size(149, 35);
            this.BTNlogin.TabIndex = 4;
            this.BTNlogin.Text = "Login";
            this.BTNlogin.UseVisualStyleBackColor = false;
            this.BTNlogin.Click += new System.EventHandler(this.BTNlogin_Click);
            // 
            // LLaboutus
            // 
            this.LLaboutus.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LLaboutus.AutoSize = true;
            this.LLaboutus.Font = new System.Drawing.Font("Lucida Sans", 12F);
            this.LLaboutus.Location = new System.Drawing.Point(76, 6);
            this.LLaboutus.Name = "LLaboutus";
            this.LLaboutus.Size = new System.Drawing.Size(78, 18);
            this.LLaboutus.TabIndex = 6;
            this.LLaboutus.TabStop = true;
            this.LLaboutus.Text = "About Us";
            this.LLaboutus.Click += new System.EventHandler(this.LLaboutus_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.Image = global::Group_Project.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(342, 12);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(197, 161);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 1;
            this.pbLogo.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.BackgroundImage = global::Group_Project.Properties.Resources.Black;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.LLaboutus, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.LLcontactus, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.LLSplitter, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(274, 301);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(335, 30);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // LLcontactus
            // 
            this.LLcontactus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LLcontactus.AutoSize = true;
            this.LLcontactus.BackColor = System.Drawing.Color.Transparent;
            this.LLcontactus.Font = new System.Drawing.Font("Lucida Sans", 12F);
            this.LLcontactus.LinkColor = System.Drawing.Color.Blue;
            this.LLcontactus.Location = new System.Drawing.Point(180, 6);
            this.LLcontactus.Name = "LLcontactus";
            this.LLcontactus.Size = new System.Drawing.Size(91, 18);
            this.LLcontactus.TabIndex = 7;
            this.LLcontactus.TabStop = true;
            this.LLcontactus.Text = "Contact Us";
            this.LLcontactus.Click += new System.EventHandler(this.LLcontactus_Click);
            // 
            // LLSplitter
            // 
            this.LLSplitter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LLSplitter.AutoSize = true;
            this.LLSplitter.Font = new System.Drawing.Font("Lucida Sans", 14F);
            this.LLSplitter.ForeColor = System.Drawing.Color.Black;
            this.LLSplitter.Location = new System.Drawing.Point(160, 4);
            this.LLSplitter.Name = "LLSplitter";
            this.LLSplitter.Size = new System.Drawing.Size(14, 22);
            this.LLSplitter.TabIndex = 8;
            this.LLSplitter.Text = "|";
            // 
            // btnShortcut
            // 
            this.btnShortcut.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnShortcut.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShortcut.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnShortcut.Location = new System.Drawing.Point(353, 366);
            this.btnShortcut.Name = "btnShortcut";
            this.btnShortcut.Size = new System.Drawing.Size(162, 34);
            this.btnShortcut.TabIndex = 3;
            this.btnShortcut.Text = "Guest Login";
            this.btnShortcut.UseVisualStyleBackColor = false;
            this.btnShortcut.Click += new System.EventHandler(this.btnShortcut_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Group_Project.Properties.Resources.BackgroundReduced;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(885, 511);
            this.Controls.Add(this.btnShortcut);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BTNregister;
        private System.Windows.Forms.TextBox TBpassword;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.TextBox TBusername;
        private System.Windows.Forms.Button BTNlogin;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.LinkLabel LLaboutus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.LinkLabel LLcontactus;
        private System.Windows.Forms.Label LLSplitter;
        private System.Windows.Forms.Button btnShortcut;
    }
}

