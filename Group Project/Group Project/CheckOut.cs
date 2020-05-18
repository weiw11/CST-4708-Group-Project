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
    public partial class CheckOut : Form
    {

        private DataTable dt = new DataTable();
        public static String userName;
        public static String userID;
        public static String FirstName;
        public static String LastName;
        public static String CreditCard;
        public static String Total;

        public CheckOut(String username)
        {
            userName = username;
            InitializeComponent();

            Database db = new Database();
            DataTable dt = db.Profile(userName);

            userID = dt.Rows[0]["Id"].ToString();
            FirstName = dt.Rows[0]["FirstName"].ToString();
            LastName = dt.Rows[0]["LastName"].ToString();
            CreditCard = dt.Rows[0]["CreditCard"].ToString();
            Total = dt.Rows[0]["Checkout_Total"].ToString();

            tbFirstName.Text = FirstName;
            tbLastName.Text = LastName;
            tbCreditCard.Text = CreditCard;
            lbPurchaseTotal.Text = "Purchase Total: $" + String.Format("{0:0.00}", Total);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Global.ShowCatalog(userName);
            this.Hide();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.ClearCart(Catalog.userID);
            Global.ShowCatalog(userName);
            this.Close();
        }
    }
}