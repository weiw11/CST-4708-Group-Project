namespace Group_Project
{
    partial class Main
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
            this.btnRegisterScreen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRegisterScreen
            // 
            this.btnRegisterScreen.Location = new System.Drawing.Point(400, 200);
            this.btnRegisterScreen.Name = "btnRegisterScreen";
            this.btnRegisterScreen.Size = new System.Drawing.Size(75, 23);
            this.btnRegisterScreen.TabIndex = 0;
            this.btnRegisterScreen.Text = "Register";
            this.btnRegisterScreen.UseVisualStyleBackColor = true;
            this.btnRegisterScreen.Click += new System.EventHandler(this.btnRegisterScreen_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 289);
            this.Controls.Add(this.btnRegisterScreen);
            this.Name = "Main";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRegisterScreen;
    }
}

