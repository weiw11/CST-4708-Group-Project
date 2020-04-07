using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Group_Project
{
    public partial class Registration : Form
    {
        private String username, password;
        private String connectionString = Main.CONN_STRING;
        private static Boolean _loggedIn = false;
        public static Boolean loggedIn
        {
            get { return loggedIn; }
            set { _loggedIn = loggedIn; }
        }

        public Registration()
        {
            InitializeComponent();
        }

        private void RegisterAccount(object sender, EventArgs e)
        {
            username = txtRegUser.Text.ToString();
            password = txtRegPass.Text.ToString();
            Console.WriteLine("Username: " + username + " and Password: " + password);
            if (CheckRegister(username, password))
            {
                _loggedIn = true;
                AddUser(username, password);
                // TODO: Maybe check password conditions
            }

        }

        private void CancelRegistration(object sender, EventArgs e)
        {
            this.Close();
        }

        // Checks registration against database
        private Boolean CheckRegister(String username, String password)
        {
            String queryString = "SELECT * FROM Customer WHERE Username=@username;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add("@username", SqlDbType.NVarChar, 15);
                    command.Parameters["@username"].Value = username;
                    command.Parameters.Add("@password", SqlDbType.NVarChar, 16);
                    command.Parameters["@password"].Value = password;
                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read() == false)
                        {
                            Console.WriteLine("New user detected!");
                            return true;
                        } else
                        {
                            MessageBox.Show("Username already exist!");
                            txtRegUser.Clear();
                        }
                        connection.Close();
                    }
                }
            }
            return false;
        }

        // Adds user to database
        private void AddUser(String username, String password)
        {
            Console.WriteLine("Adding user...");
            String queryString = "INSERT INTO Customer (Username, Password) " +
                "VALUES (@username, @password);";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    Console.WriteLine("Username: " + username + " added!");
                }
            }

            this.Close();
            MessageBox.Show("Registration Successful!");
            // TODO: Needs to open login screen
        }

        private SqlCommand SQLUserParam()
        {
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            return command;
        }
    }
}