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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        static SQLiteConnection CreateConnection() //Konekcija ar datubāzi
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = new SQLiteConnection("Data Source=palidzibas_serviss.db; Version = 3; New = True; Compress = True; ");
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Konekcija neizdevās!");
            }
            return sqlite_conn;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void dzesanas_izvele_SelectedIndexChanged(object sender, EventArgs e)
        {
            paradit_tabulu();
        }

        public void paradit_tabulu()
        {
            if (dzesanas_izvele.SelectedItem.ToString() == "Lietotājs")
            {
                CreateConnection();
                SQLiteConnection sqlite_conn;
                sqlite_conn = CreateConnection();

                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM Lietotaja_dati";


                DataTable sTable;
                SQLiteDataAdapter sqlda = new SQLiteDataAdapter(sqlite_cmd);
                using (sTable = new DataTable())
                {
                    sqlda.Fill(sTable);
                    dzesanas_tabula.DataSource = sTable;
                }
            }
            else if (dzesanas_izvele.SelectedItem.ToString() == "Ziņa")
            {
                CreateConnection();
                SQLiteConnection sqlite_conn;
                sqlite_conn = CreateConnection();

                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM Zina";


                DataTable sTable;
                SQLiteDataAdapter sqlda = new SQLiteDataAdapter(sqlite_cmd);
                using (sTable = new DataTable())
                {
                    sqlda.Fill(sTable);
                    dzesanas_tabula.DataSource = sTable;
                }
            }
            /*else if (dzesanas_izvele.SelectedItem.ToString() == "Veidošanas Losjoni")
            {
                CreateConnection();
                SQLiteConnection sqlite_conn;
                sqlite_conn = CreateConnection();

                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM Prece WHERE Preces_veids = 'Veidošanas Losjoni'";


                DataTable sTable;
                SQLiteDataAdapter sqlda = new SQLiteDataAdapter(sqlite_cmd);
                using (sTable = new DataTable())
                {
                    sqlda.Fill(sTable);
                    dzesanas_tabula.DataSource = sTable;
                }
            }*/
        }

        private void dzesana_Click(object sender, EventArgs e)
        {
            int id;

            // Attempt to parse the text from the text box to an integer
            if (int.TryParse(id_numurs.Text, out id))
            {
                // Parsing was successful, and 'id' now holds the parsed integer value
                // You can use 'id' in your code for further operations
            }
            else
            {
                // Parsing failed - handle the invalid input scenario
                MessageBox.Show("Invalid ID. Please enter a valid integer.");
            }

            if (dzesanas_izvele.SelectedItem.ToString() == "Lietotājs")
            {
                CreateConnection();
                SQLiteConnection sqlite_conn;
                sqlite_conn = CreateConnection();

                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "DELETE FROM Lietotaja_dati WHERE Datu_ID = @Datu_ID";
                sqlite_cmd.Parameters.AddWithValue("@Datu_ID", id);


                DataTable sTable;
                SQLiteDataAdapter sqlda = new SQLiteDataAdapter(sqlite_cmd);
                using (sTable = new DataTable())
                {
                    sqlda.Fill(sTable);
                    dzesanas_tabula.DataSource = sTable;
                }
            }
            else if (dzesanas_izvele.SelectedItem.ToString() == "Ziņa")
            {
                CreateConnection();
                SQLiteConnection sqlite_conn;
                sqlite_conn = CreateConnection();

                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "Delete FROM Zina WHERE Zina_ID = @Zina_ID";
                sqlite_cmd.Parameters.AddWithValue("@Zina_ID", id);


                DataTable sTable;
                SQLiteDataAdapter sqlda = new SQLiteDataAdapter(sqlite_cmd);
                using (sTable = new DataTable())
                {
                    sqlda.Fill(sTable);
                    dzesanas_tabula.DataSource = sTable;
                }
            }

            id_numurs.Clear();
        }

        private void id_numurs_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }
    }
}
