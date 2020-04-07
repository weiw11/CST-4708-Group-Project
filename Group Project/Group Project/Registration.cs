using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Group_Project
{
    public partial class Registration : Form
    {
        private String username, password1, password2;
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
            password1 = txtRegPass1.Text.ToString();
            password2 = txtRegPass2.Text.ToString();
            Console.WriteLine("Username: " + username + " and Password: " + password1);
            if (CheckRegister() && checkPassword())
            {
                _loggedIn = true;
                AddUser();
            }

        }

        private void CancelRegistration(object sender, EventArgs e)
        {
            this.Close();
        }

        // Checks registration against database
        private Boolean CheckRegister()
        {
            String queryString = "SELECT * FROM Customer WHERE Username=@username;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add("@username", SqlDbType.NVarChar, 15);
                    command.Parameters["@username"].Value = username;
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
        private void AddUser()
        {
            Console.WriteLine("Adding user...");
            String queryString = "INSERT INTO Customer (Username, Password) " +
                "VALUES (@username, @password);";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password1);
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

        private Boolean checkPassword()
        {
            String pwReqInfo = "Password Requirements:" + Environment.NewLine +
                "- Be a minimum of eight(8) characters in length" + Environment.NewLine +
                "- Contain at least one(1) character from three(3) of the following categories:" + Environment.NewLine +
                "* Uppercase letter(A - Z)" + Environment.NewLine +
                "* Lowercase letter(a - z)" + Environment.NewLine +
                "* Digit(0 - 9)" + Environment.NewLine +
                "* Special character(~`!@#$%^&*()+=_-{}[]\\|:;\"”’?/<>,.)";

            if (password1.Equals(password2) && IsValidPassword(password1) && password1.Length >= 8)
            {
                return true;
            } else
            {
                ttRegPass.Show(pwReqInfo, btnRegReg);
            }
            return false;
        }

        private SqlCommand SQLUserParam()
        {
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password1);
            return command;
        }

        // https://stackoverflow.com/a/3373600
        static bool IsLetter(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }

        static bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        static bool IsSymbol(char c)
        {
            return c > 32 && c < 127 && !IsDigit(c) && !IsLetter(c);
        }

        static bool IsValidPassword(String password)
        {
            return
               password.Any(c => IsLetter(c)) &&
               password.Any(c => IsDigit(c)) &&
               password.Any(c => IsSymbol(c)) &&
               password.Where(char.IsUpper).Count() > 0 &&
               password.Where(char.IsLower).Count() > 0;
        }
    }
}