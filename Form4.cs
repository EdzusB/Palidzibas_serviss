using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Palidzibas_serviss
{
    public partial class Form4 : Form
    {
        private int receivedValue1; // Glabā saņemto vērtību (piemēram, datu_id)

        public Form4(int receivedValue)
        {
            InitializeComponent();
            this.receivedValue1 = receivedValue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Izsauc metodi no ZinuParade, lai iegūtu datus un aizpildītu DataGridView
            ZinuParade.FetchDataAndPopulateGridView(receivedValue1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int datu_id = receivedValue1;
            Form1 f1 = new Form1(datu_id);
            f1.Show();
            this.Hide();
        }
    }

    public class ZinuParade
    {
        // Definē publisku statisku metodi, lai iegūtu datus no datubāzes un aizpildītu DataGridView
        public static void FetchDataAndPopulateGridView(int receivedValue1)
        {
            try
            {
                // Izveido savienojumu ar SQLite datubāzi
                using (SQLiteConnection sqlite_conn = CreateConnection())
                {
                    if (sqlite_conn.State != ConnectionState.Open)
                        return; // Savienojums neizdevās, turpināt nav iespējams

                    // Izveido komandu, lai izpildītu SQL vaicājumu
                    using (SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand())
                    {
                        // Definē SQL vaicājumu ar parametru Datu_id
                        sqlite_cmd.CommandText = "SELECT Zina_ID, Teksts, Datums_laiks FROM Zina WHERE Datu_id = @Datu_id";
                        sqlite_cmd.Parameters.AddWithValue("@Datu_id", receivedValue1);

                        // Izveido DataTable, lai saglabātu vaicājuma rezultātus
                        DataTable sTable = new DataTable();

                        // Izmanto DataAdapter, lai aizpildītu DataTable ar vaicājuma rezultātiem
                        using (SQLiteDataAdapter sqlda = new SQLiteDataAdapter(sqlite_cmd))
                        {
                            sqlda.Fill(sTable); // Izpilda vaicājumu un aizpilda DataTable
                        }

                        // Atrod DataGridView kontroli Form4 instancē
                        Form4 formInstance = Application.OpenForms["Form4"] as Form4;
                        if (formInstance != null)
                        {
                            DataGridView dataGridView = formInstance.Controls["zinu_tabula"] as DataGridView;
                            if (dataGridView != null)
                            {
                                // Piesaista DataTable DataGridView, lai parādītu datus
                                dataGridView.DataSource = sTable;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kļūda datu iegūšanā: {ex.Message}");
            }
        }

        // Palīgmetode, lai izveidotu SQLite savienojumu
        private static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = new SQLiteConnection("Data Source=Palidzibas_serviss.db; Version=3; New=True; Compress=True;");
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Konekcijas kļūda: {ex.Message}");
            }
            return sqlite_conn;
        }
    }
}
