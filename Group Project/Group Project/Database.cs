using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    public class Database
    {
        readonly SqlConnection connection;
        readonly SqlDataAdapter adapter;

        public Database()
        {
            String connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"" + System.IO.Directory.GetCurrentDirectory() + "\\Comics.mdf\";Integrated Security=True;Connect Timeout=30";
            connection = new SqlConnection
            {
                ConnectionString = connectionString
            };
            adapter = new SqlDataAdapter();
        }

        public bool Login(String user, String pass)
        {
            SqlCommand select = new SqlCommand
            {
                CommandText = "Select * From Customer Where Username = @user AND Password = @pass;"
            };
            select.Parameters.Add("@user", SqlDbType.VarChar);
            select.Parameters["@user"].Value = user;
            select.Parameters.Add("@pass", SqlDbType.VarChar);
            select.Parameters["@pass"].Value = pass;
            select.Connection = connection;
            DataTable dt = new DataTable();
            connection.Open();
            adapter.SelectCommand = select;
            adapter.Fill(dt);
            connection.Close();

            if (dt.Rows.Count < 1)
            {
                return false;
            }
            else
            {
                foreach (DataRow row in dt.Rows)
                {
                    Group_Project.Profile.FirstName = row["FirstName"].ToString();
                    Group_Project.Profile.LastName = row["LastName"].ToString();
                    Group_Project.Profile.CreditCard = row["CreditCard"].ToString();
                    Catalog.FirstName = row["FirstName"].ToString();
                    Catalog.LastName = row["LastName"].ToString();
                    Catalog.userName = row["Username"].ToString();
                    Catalog.userID = int.Parse(row["Id"].ToString());
                    Cart.FirstName = row["FirstName"].ToString();
                    Cart.LastName = row["LastName"].ToString();
                    Cart.userName = row["Username"].ToString();
                    CheckOut.FirstName = row["FirstName"].ToString();
                    CheckOut.LastName = row["LastName"].ToString();
                    CheckOut.CreditCard = row["CreditCard"].ToString();
                    //Profile.id = int.Parse(row["id"].ToString());
                }
                return true;
            }

        }

        public DataTable PopulateComics()
        {

            SqlCommand select = new SqlCommand
            {
                CommandText = "select * from Comic_info",
                Connection = connection
            };
            DataTable dt = new DataTable();
            connection.Open();
            adapter.SelectCommand = select;
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }

        public DataTable PopulateComics(String input)
        {

            SqlCommand select = new SqlCommand
            {
                CommandText = "select * from Comic_info where Title = '" + input + "';",
                Connection = connection
            };
            DataTable dt = new DataTable();
            connection.Open();
            adapter.SelectCommand = select;
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }

        public DataTable Profile(String user)
        {
            SqlCommand select = new SqlCommand
            {
                CommandText = "select * from Customer where Username = '" + user + "';",
                Connection = connection
            };
            DataTable dt = new DataTable();
            connection.Open();
            adapter.SelectCommand = select;
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }

        public DataTable FindComic(String title)
        {
            SqlCommand select = new SqlCommand
            {
                CommandText = "select * from Comic_Info where Title = '" + title + "';",
                Connection = connection
            };
            DataTable dt = new DataTable();
            connection.Open();
            adapter.SelectCommand = select;
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }

        public void AddToCart(int userID, int comicID)
        {
            SqlCommand insert = new SqlCommand
            {
                CommandText = "INSERT INTO Cart (UserID, ComicID) VALUES (" + userID + ",  " + comicID + ");",
                Connection = connection
            };
            connection.Open();
            insert.ExecuteNonQuery();
            connection.Close();
        }


        public DataTable PopulateCart(int userID)
        {
            SqlCommand select = new SqlCommand
            {
                CommandText = "select Comic_Info.Id, Comic_Info.Title, Comic_Info.Price, Comic_Info.Link from  Comic_Info INNER JOIN Cart ON  Comic_Info.Id =  Cart.ComicID where Cart.UserID = " + userID + ";",
                Connection = connection
            };
            DataTable dt = new DataTable();
            connection.Open();
            adapter.SelectCommand = select;
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }

        public void ClearCart(int userID)
        {
            SqlCommand delete = new SqlCommand
            {
                CommandText = "Delete FROM Cart where UserID = " + userID,
                Connection = connection
            };
            connection.Open();
            delete.ExecuteNonQuery();
            connection.Close();
        }

        public void Register(String username, String password, String fname, String lname, String cc)
        {
            SqlCommand insert = new SqlCommand
            {
                CommandText = "INSERT INTO Customer (Username, Password, FirstName, LastName, CreditCard ) VALUES ('" + username + "',  '" + password + "',  '" + fname + "',  '" + lname + "', '" + cc + "');",
                Connection = connection
            };
            connection.Open();
            insert.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateTotal(int userID, Double amount)
        {
            SqlCommand updateAmt = new SqlCommand
            {
                CommandText = "Update Customer Set Checkout_Total='" + amount + "' Where Id=" + userID + ";",
                Connection = connection
            };
            connection.Open();
            updateAmt.ExecuteNonQuery();
            connection.Close();
        }

    }
}
