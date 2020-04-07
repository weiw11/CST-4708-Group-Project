using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Group_Project
{
    public partial class Registration : Form
    {
        private String firstname, lastname, creditcard, username, password1, password2;
        private String connectionString = Global.CONN_STRING;
        private static Boolean _loggedIn = false;

        public static Boolean loggedIn
        {
            get { return loggedIn; }
        }

        public Registration()
        {
            InitializeComponent();
        }

        private void RegisterAccount(object sender, EventArgs e)
        {
            firstname = txtRegisFName.Text.ToString();
            lastname = txtRegisLName.Text.ToString();
            creditcard = txtRegisCC.Text.ToString();
            username = txtRegisUser.Text.ToString();
            password1 = txtRegisPass1.Text.ToString();
            password2 = txtRegisPass2.Text.ToString();
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
                            txtRegisUser.Clear();
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
            String queryString = "INSERT INTO Customer (FirstName, LastName, CreditCard, Username, Password) " +
                "VALUES (@firstname, @lastname, @creditcard, @username, @password);";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@firstname", firstname);
                    command.Parameters.AddWithValue("@lastname", lastname);
                    command.Parameters.AddWithValue("@creditcard", creditcard);
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
                txtRegisPass1.Clear();
                txtRegisPass2.Clear();
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
        private static bool IsLetter(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }

        private static bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        private static bool IsSymbol(char c)
        {
            return c > 32 && c < 127 && !IsDigit(c) && !IsLetter(c);
        }

        private static bool IsValidPassword(String password)
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