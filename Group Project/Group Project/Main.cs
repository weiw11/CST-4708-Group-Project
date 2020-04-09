using System;
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

        private void btnCatalogScreen_Click(object sender, EventArgs e)
        {
            Catalog c = new Catalog();
            c.Show();
        }
    }
}