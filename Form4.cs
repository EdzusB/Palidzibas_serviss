using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Palidzibas_serviss
{
    public partial class Form4 : Form
    {
        private int receivedValue1;

        static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = new SQLiteConnection("Data Source=Palidzibas_serviss.db; Version = 3; New = True; Compress = True; ");
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
        }

        public Form4(int receivedValue)
        {
            InitializeComponent();
            this.receivedValue1 = receivedValue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a connection to the SQLite database
                using (SQLiteConnection sqlite_conn = CreateConnection())
                {
                    if (sqlite_conn.State != ConnectionState.Open)
                        return; // Connection failed, do not proceed

                    // Create a command to execute the SQL query
                    using (SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand())
                    {
                        // Define the SQL query with a parameter for Datu_id
                        sqlite_cmd.CommandText = "SELECT Zina_ID, Teksts, Datums_laiks FROM Zina WHERE Datu_id = @Datu_id";
                        sqlite_cmd.Parameters.AddWithValue("@Datu_id", receivedValue1);

                        // Create a DataTable to store the query results
                        DataTable sTable = new DataTable();

                        // Use a DataAdapter to fill the DataTable with the query results
                        using (SQLiteDataAdapter sqlda = new SQLiteDataAdapter(sqlite_cmd))
                        {
                            sqlda.Fill(sTable); // Execute the query and fill the DataTable
                        }

                        // Bind the DataTable to the DataGridView for display
                        zinu_tabula.DataSource = sTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}");
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int datu_id = receivedValue1;
            Form1 f1 = new Form1(datu_id);
            f1.Show();
            this.Hide();

        }
    }
}
