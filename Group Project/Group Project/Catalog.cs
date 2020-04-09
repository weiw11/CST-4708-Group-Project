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

        public Catalog()
        {
            InitializeComponent();

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

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text.Equals("Enter search..."))
            {
                txtSearch.Text = "";
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchCommand();
            }
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

        private void Catalog_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login l = new Login();
            l.Close();
        }
    }
}