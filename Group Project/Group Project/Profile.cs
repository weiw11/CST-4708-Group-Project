using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace Group_Project
{
    public partial class Profile : Form
    {
        public static String userName;
        public static String userID;
        public static String FirstName;
        public static String LastName;
        public static String CreditCard;

        public Profile(String username)
        {
            userName = username;
            InitializeComponent();

            Database db = new Database();
            DataTable dt = db.Profile(userName);

            userID = dt.Rows[0]["Id"].ToString();
            FirstName = dt.Rows[0]["FirstName"].ToString();
            LastName = dt.Rows[0]["LastName"].ToString();
            CreditCard = dt.Rows[0]["CreditCard"].ToString();

            lbID.Text = "UserID: 000" + userID;
            lbFirstName.Text = "First Name: " + FirstName;
            lbLastName.Text = "Last Name: " + LastName;

        }

        private void btnBackToCatalog_Click(object sender, EventArgs e)
        {
            Global.ShowCatalog();
            this.Close();
        }
    }
}