using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Group_Project
{
    public partial class Main : Form
    {
        public SqlConnection conn = new SqlConnection();
        private readonly static String _CONN_STRING = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + "F:\\Database.mdf" + ";Integrated Security=True;Connect Timeout=30";

        public Main()
        {
            InitializeComponent();
        }

        public static String CONN_STRING
        {
            get { return _CONN_STRING; }
        }

        private void btnRegisterScreen_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
        }
    }
}