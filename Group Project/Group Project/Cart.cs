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
    public partial class Cart : Form
    {
        private DataTable users = new DataTable();
        private DataTable allComics;
        public double[] price;
        public double[] total;
        public double[] tax;
        public static String userName;
        public static String FirstName;
        public static String LastName;
        public static int userID;

        public Cart(String username)
        {
            userName = username;
            Database db = new Database();
            DataTable dt = db.Profile(userName);
            FirstName = dt.Rows[0]["FirstName"].ToString();
            LastName = dt.Rows[0]["LastName"].ToString();
            userID = int.Parse(dt.Rows[0]["Id"].ToString());
            InitializeComponent();
            populateCart();
        }

        private void populateCart()
        {

            allComics = new DataTable();
            Database db = new Database();
            allComics = db.PopulateCart(Catalog.userID);

            Panel[] panelArray = new Panel[allComics.Rows.Count];
            Label[] labelArray = new Label[allComics.Rows.Count];
            Label[] priceArray = new Label[allComics.Rows.Count];
            PictureBox[] picBoxArray = new PictureBox[allComics.Rows.Count];

            CartPanel.Controls.Clear();

            for (int i = 0; i < allComics.Rows.Count; i++)
            {
                panelArray[i] = new Panel();
                panelArray[i].BackColor = Color.White;
                panelArray[i].Location = new Point(20, (i) * 120);
                panelArray[i].Size = new Size(800, 100);

                labelArray[i] = new Label();
                labelArray[i].Text = allComics.Rows[i]["Title"].ToString();
                labelArray[i].Font = new Font("Constantia", 20.0f, FontStyle.Bold);
                labelArray[i].Location = new Point(250, 40);
                labelArray[i].Size = new Size(300, 50);

                priceArray[i] = new Label();
                priceArray[i].Text = "$" + allComics.Rows[i]["Price"].ToString();
                priceArray[i].Font = new Font("Constantia", 18.0f, FontStyle.Bold);
                priceArray[i].Location = new Point(650, 40);
                priceArray[i].Size = new Size(200, 50);
                priceArray[i].Name = allComics.Rows[i]["Id"].ToString();

                WebClient wc = new WebClient();
                picBoxArray[i] = new PictureBox();
                String link = allComics.Rows[i]["Link"].ToString();
                byte[] bytes = wc.DownloadData(link);
                MemoryStream ms = new MemoryStream(bytes);
                Image fullsizeImage = Image.FromStream(ms);
                picBoxArray[i].Image = fullsizeImage.GetThumbnailImage(400, 400, null, IntPtr.Zero);
                picBoxArray[i].Location = new Point(0, 0);
                picBoxArray[i].Size = new Size(200, 200);
                picBoxArray[i].SizeMode = PictureBoxSizeMode.StretchImage;

                panelArray[i].Controls.Add(labelArray[i]);
                panelArray[i].Controls.Add(priceArray[i]);
                panelArray[i].Controls.Add(picBoxArray[i]);

                CartPanel.Controls.Add(panelArray[i]);
            }
            cartUpdate();
        }

        private void cartUpdate()
        {
            double sumPrice = 0;
            double sumTax = 0;
            double sumTotal = 0;

            price = new double[allComics.Rows.Count];
            tax = new double[allComics.Rows.Count];
            total = new double[allComics.Rows.Count];

            for (int i = 0; i < allComics.Rows.Count; i++)
            {

                price[i] = double.Parse(allComics.Rows[i]["Price"].ToString());
                tax[i] = Math.Round(price[i] * 0.0825, 2);
                total[i] = price[i] + tax[i];
                sumPrice += price[i];
                sumTax += tax[i];
                sumTotal += total[i];
            }

            lbUserName.Text = FirstName + " " + LastName;
            lbTax.Text = "Tax: $" + String.Format("{0:0.00}", sumTax);
            lbTotalAmt.Text = "Total: $" + String.Format("{0:0.00}", sumTotal);

            Database db = new Database();
            db.UpdateTotal(userID,sumTotal);
        }

        private void lbUsername_Click(object sender, EventArgs e)
        {
            Global.ShowProfile(userName);
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            Global.ShowCheckOut(userName);
            this.Hide();
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.ClearCart(Catalog.userID);
            populateCart();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Global.ShowCatalog(userName);
            this.Hide();
        }
    }
}