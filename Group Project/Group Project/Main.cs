using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Group_Project
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnRegisterScreen_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
        }
    }
}