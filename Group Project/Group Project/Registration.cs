using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Group_Project
{
    public partial class Registration : Form
    {
        private readonly String connectionString = Global.CONN_STRING;
        private static Boolean _loggedIn = false;

        public static Boolean loggedIn
        {
            get { return _loggedIn; }
        }

        public Registration()
        {
            InitializeComponent();
        }

        private void RegisterAccount(object sender, EventArgs e)
        {
            Console.WriteLine("Username: " + txtRegisUser.Text + " and Password: " + txtRegisPass1.Text);
            if (CheckDatabase() && CheckRegistration())
            {
                _loggedIn = true;
                AddUser();
                // TODO: Return to login or straight to catalog?
                ReturnToLogin();
            }
        }

        private void btnRegCancelClick(object sender, EventArgs e)
        {
            ReturnToLogin();
        }

        private void ReturnToLogin()
        {
            Global.ShowLogin();
            this.Close();
        }

        // Checks registration against database
        private Boolean CheckDatabase()
        {
            String queryString = "SELECT * FROM Customer WHERE Username=@username;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add("@username", SqlDbType.NVarChar, 15);
                    command.Parameters["@username"].Value = txtRegisUser.Text;
                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read() == false)
                        {
                            Console.WriteLine("New user detected!");
                            return true;
                        }
                        else
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
                    command.Parameters.AddWithValue("@firstname", txtRegisFName.Text);
                    command.Parameters.AddWithValue("@lastname", txtRegisLName.Text);
                    command.Parameters.AddWithValue("@creditcard", txtRegisCC.Text);
                    command.Parameters.AddWithValue("@username", txtRegisUser.Text);
                    command.Parameters.AddWithValue("@password", txtRegisPass2.Text);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    Console.WriteLine("Username: " + txtRegisUser.Text + " added!");
                }
            }

            this.Close();
            MessageBox.Show("Registration Successful!");
            // TODO: Needs to open login screen
        }

        private Boolean CheckRegistration()
        {
            if (string.IsNullOrEmpty(txtRegisFName.Text) || string.IsNullOrEmpty(txtRegisLName.Text) || string.IsNullOrEmpty(txtRegisCC.Text) || string.IsNullOrEmpty(txtRegisUser.Text) || string.IsNullOrEmpty(txtRegisPass1.Text) || string.IsNullOrEmpty(txtRegisPass2.Text))
            {
                ttRegPass.Show("Please fill out all required fields.", btnRegisReg);
                //MessageBox.Show("Please fill out all required fields.", "Required Fields Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Please fill out all required fields.");
                return false;
            }
            else if (txtRegisCC.Text.Length < 19)
            {
                ttRegPass.Show("Credit card number cannot contain less than 16 digits.", btnRegisReg);
                //MessageBox.Show("Credit card number cannot contain less than 16 digits.", "Invalid Credit Card Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Credit card number cannot contain less than 16 digits.");
                return false;
            }
            else if (txtRegisPass1.Text.Equals(txtRegisPass2.Text) && IsValidPassword(txtRegisPass1.Text) && txtRegisPass1.Text.Length >= 8)
            {
                Console.WriteLine("Both passwords are correct.");
                return true;
            }
            else
            {
                txtRegisPass1.Clear();
                txtRegisPass2.Clear();
                ttRegPass.Show("Password Requirements:" + Environment.NewLine +
                "- Be a minimum of eight(8) characters in length" + Environment.NewLine +
                "- Contain at least one(1) character from three(3) of the following categories:" + Environment.NewLine +
                "* Uppercase letter(A - Z)" + Environment.NewLine +
                "* Lowercase letter(a - z)" + Environment.NewLine +
                "* Digit(0 - 9)" + Environment.NewLine +
                "* Special character(~`!@#$%^&*()+=_-{}[]\\|:;\"”’?/<>,.)", btnRegisReg);
                //MessageBox.Show("Verify Password Does Not Match.", "Passwords Do Not Match", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Please make sure you entered the same password.");
            }
            return false;
        }

        private void txtRegisCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Credit card number cannot contain letters.", "Invalid Credit Card Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (txtRegisCC.Text.Replace("-", "").Length % 4 == 0 && txtRegisCC.Text.Length != 0 && txtRegisCC.Text.Substring(txtRegisCC.Text.Length - 1) != "-")
            {
                if (txtRegisCC.TextLength < 19)
                {
                    this.txtRegisCC.Text = this.txtRegisCC.Text + "-";
                    this.txtRegisCC.Select(this.txtRegisCC.Text.Length, 1);
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtRegisFName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("First name cannot contain digits.", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRegisLName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Last name cannot contain digits.", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private SqlCommand SQLUserParam()
        {
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@username", txtRegisUser.Text);
            command.Parameters.AddWithValue("@password", txtRegisPass1.Text);
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