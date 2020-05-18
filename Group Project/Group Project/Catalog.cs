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
        private readonly String connectionString = Global.CONN_STRING;
        private readonly String DEFAULT_SEARCH_TEXT = "Enter search...";
        private readonly int IMAGE_SIZE = 200;
        private DataTable dt = new DataTable();
        public static String userName;
        public static String FirstName;
        public static String LastName;
        public static int userID;
        public static int comicID;

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
            userName = username;
            loadUser(username);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoGenerateColumns = false;
            loadData();
        }

        private void loadUser(String username)
        {
            String queryString = "SELECT * FROM Customer WHERE Username = @username;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add("@username", SqlDbType.NVarChar, 15);
                    command.Parameters["@username"].Value = username;
                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read() == true)
                        {
                            lbUsername.Text = reader[1] + " " + reader[2];
                        }
                        else
                        {
                            lbUsername.Text = "Guest";
                        }
                        connection.Close();
                    }
                }
            }
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
                    command.Parameters.AddWithValue("@search", "%" + search + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    adapter.Fill(dt);
                }
                connection.Close();
            }
        }

        // Gets image from url
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            LoadImages(e);
        }

        private void dataGridView1_RowsChanged(object sender, DataGridViewRowsAddedEventArgs e)
        {
            scrollFix();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            scrollFix();
        }

        private void LoadImages(DataGridViewCellFormattingEventArgs e)
        {
            // Column 0 is image column in datagridview1
            if (e.ColumnIndex == 0)
            {
                DataTable dt = dataGridView1.DataSource as DataTable;
                if (dt != null && dt.Rows.Count > e.RowIndex && dt.Columns.Count > e.ColumnIndex)
                {
                    String url = dt.Rows[e.RowIndex][5].ToString();
                    WebClient wc = new WebClient();
                    byte[] bytes = wc.DownloadData(url);
                    MemoryStream ms = new MemoryStream(bytes);
                    Image fullsizeImage = Image.FromStream(ms);
                    Image newImage = fullsizeImage.GetThumbnailImage(IMAGE_SIZE, IMAGE_SIZE, null, IntPtr.Zero);
                    e.Value = newImage;
                }
            }
        }


        private void scrollFix()
        {
            dataGridView1.Height = dataGridView1.ColumnHeadersHeight + dataGridView1.Rows.Cast<DataGridViewRow>().Sum(r => r.Height);
        }

        private void lbUsername_Click(object sender, EventArgs e)
        {
            Global.ShowProfile(userName);
        }

        private void lbCart_Click(object sender, EventArgs e)
        {
            Global.ShowCart(userName);
            this.Hide();
        }

        private void SearchTextClear()
        {
            if (txtSearch.Text.Equals(DEFAULT_SEARCH_TEXT))
            {
                txtSearch.Text = "";
                loadData();
            }
        }

        private void SearchTextReset()
        {
            txtSearch.Text = DEFAULT_SEARCH_TEXT;
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            SearchTextClear();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                SearchCommand();
            }
            if (e.KeyCode == Keys.Back && String.IsNullOrEmpty(txtSearch.Text))
            {
                loadData();
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            SearchTextReset();
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            SearchTextClear();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            if (userID == 0 || comicID == 0)
            {
                MessageBox.Show("This operation cannot be done.");
            }
            else
            {
                db.AddToCart(userID, comicID);
            }
            
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            Global.ShowLogin();
            this.Close();
        }

        private void Catalog_FormClosing(object sender, FormClosingEventArgs e)
        {
            // TODO: Handle opening profile/login when this closes.
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                String comicTitle = row.Cells["Column2"].Value.ToString();
                Database db = new Database();
                DataTable dt = db.FindComic(comicTitle);
                comicID = int.Parse(dt.Rows[0]["Id"].ToString());
            }
           
        }
    }
}