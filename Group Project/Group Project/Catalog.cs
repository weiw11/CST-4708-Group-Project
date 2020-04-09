using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            loadData();
        }

        private void loadData()
        {
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

            // Sets dataGridView1 height to sum of row height
            //dataGridView1.Height = dataGridView1.ColumnHeadersHeight + dataGridView1.Rows.Cast<DataGridViewRow>().Sum(r => r.Height);
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
        }
    }
}
