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
    public partial class Catalog : Form
    {
        private String connectionString = Global.CONN_STRING;
        private DataTable dt = new DataTable();
        private Boolean userClosing;

        public Catalog()
        {
            InitializeComponent();

            dataGridView1.DataSource = dt;
            dataGridView1.AutoGenerateColumns = false;

            loadData();
        }

        public Catalog(String username)
        {
            InitializeComponent();

            lbUsername.Text = username;

            dataGridView1.DataSource = dt;
            dataGridView1.AutoGenerateColumns = false;

            loadData();
        }

        private void loadData()
        {
            dt.Clear();
            String queryString = "SELECT * FROM Comic_Info;";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    adapter.Fill(dt);
                    connection.Close();
                }
            }
        }

        private void SearchCommand()
        {
            dt.Clear();
            String search = txtSearch.Text;
            if (String.IsNullOrEmpty(search))
            {
                loadData();
            }
            if (search.Contains("$"))
            {
                search = search.Replace("$", "");
            }
            String queryString = "SELECT * FROM Comic_Info WHERE Publisher LIKE @search OR Title LIKE @search OR Author LIKE @search OR Description LIKE @search OR Price LIKE @search;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@search" , "%"+search+"%");
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    adapter.Fill(dt);
                }
                connection.Close();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Column 4 is image column in datagridview1
            if (e.ColumnIndex == 4)
            {
                DataTable dt = dataGridView1.DataSource as DataTable;
                if (dt != null && dt.Rows.Count > e.RowIndex && dt.Columns.Count > e.ColumnIndex)
                {
                    String url = dt.Rows[e.RowIndex][5].ToString();
                    WebClient wc = new WebClient();
                    byte[] bytes = wc.DownloadData(url);
                    MemoryStream ms = new MemoryStream(bytes);
                    e.Value = Image.FromStream(ms);
                }
            }
            if (e.ColumnIndex == 5)
            {
                e.Value = "$" + e.Value;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchCommand();
            }
            if (e.KeyCode == Keys.Back && String.IsNullOrEmpty(txtSearch.Text))
            {
                loadData();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSearch.Text))
            {
                loadData();
            }
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtSearch.Text.Equals("Enter search..."))
            {
                txtSearch.Text = "";
                loadData();
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            SearchCommand();
        }

        // HACKED scroll fix for DataGridView
        private void scrollFix()
        {
            dataGridView1.Height = dataGridView1.ColumnHeadersHeight + dataGridView1.Rows.Cast<DataGridViewRow>().Sum(r => r.Height);
        }

        private void dataGridView1_RowsChanged(object sender, DataGridViewRowsAddedEventArgs e)
        {
            scrollFix();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            scrollFix();
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.Text = "Enter search...";
        }

        private void lbCart_Click(object sender, EventArgs e)
        {
            // TODO: Add Cart menu
            //Cart cart = new Cart();
            //cart.Show();
        }

        private void lbUsername_Click(object sender, EventArgs e)
        {
            // TODO: Add user profile menu?
            //Profile p = new Profile;
            //p.Show();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            // TODO: Add stuff to cart
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            userClosing = true;
            this.Close();
        }

        private void ShowLogin()
        {
            Login l = new Login();
            l.Visible = true;
            Console.WriteLine("Login screen unhid");
        }

        private void Catalog_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.ApplicationExitCall:
                    Application.Exit();
                    break;
                case CloseReason.FormOwnerClosing:
                    Application.Exit();
                    break;
                case CloseReason.MdiFormClosing:
                    Application.Exit();
                    break;
                case CloseReason.None:
                    Application.Exit();
                    break;
                case CloseReason.TaskManagerClosing:
                    Application.Exit();
                    break;
                case CloseReason.UserClosing:
                    if (userClosing)
                    {
                        ShowLogin();
                    } else
                    {
                        Application.Exit();
                    }
                    break;
                case CloseReason.WindowsShutDown:
                    Application.Exit();
                    break;
                default:
                    Application.Exit();
                    break;
            }
        }
    }
}