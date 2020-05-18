using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Group_Project
{
    public partial class Login : Form
    {
        Database data;

        public Login()
        {
            InitializeComponent();
            data = new Database();
        }

        private void BTNlogin_Click(object sender, EventArgs e)
        {
            LoginCheck();
        }

        private void BTNregister_Click(object sender, EventArgs e)
        {
            Global.ShowRegistration();
            this.Hide();
        }

        private void btnShortcut_Click(object sender, EventArgs e)
        {
            loadCatalog();
        }

        private void LLaboutus_Click(object sender, EventArgs e)
        {
            Global.ShowAboutUs();
            this.Hide();
        }

        private void LLcontactus_Click(object sender, EventArgs e)
        {
            Global.ShowContactUs();
            this.Hide();
        }

        private void loadCatalog()
        {
            String username = TBusername.Text;
            if (String.IsNullOrEmpty(username))
            {
                username = "Guest";
            }
            Global.ShowCatalog(username);
            this.Hide();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void LoginCheck()
        {
            if (data.Login(TBusername.Text, TBpassword.Text))
            {
                loadCatalog();
            }
            else if (TBusername.Text == "" || TBpassword.Text == "")
            {
                MessageBox.Show("Please enter a username and a password.", "Required Fields Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Invalid Account Information. Please Try Again.", "Invalid Account Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TBpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginCheck();
            }
        }
    }
}