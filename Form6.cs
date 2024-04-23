using System;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Palidzibas_serviss
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=palidzibas_serviss.db; Version=3; New=True; Compress=True;");
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Konekcija neizdevās! {ex.Message}");
            }
            return sqlite_conn;
        }

        private void paroles_maina_Click(object sender, EventArgs e)
        {
            string lietotajvards = Lietotajvards.Text;
            string parole1 = jauna_parole1.Text;
            string parole2 = jauna_parole2.Text;

            if (parole1 == parole2)
            {
                // Hash the password using SHA-256 (more secure than MD5)
                string hashedPassword;
                using (MD5 md5 = MD5.Create())
                {
                    byte[] inputBytes = Encoding.UTF8.GetBytes(parole1);
                    byte[] hashedBytes = md5.ComputeHash(inputBytes);
                    hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                }

                try
                {
                    using (SQLiteConnection sqlite_conn = CreateConnection())
                    using (SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand())
                    {
                        sqlite_cmd.CommandText = @"
                            UPDATE Lietotaja_dati
                            SET Parole = @parole
                            WHERE Lietotajvards = @lietotajvards";

                        sqlite_cmd.Parameters.AddWithValue("@parole", hashedPassword);
                        sqlite_cmd.Parameters.AddWithValue("@lietotajvards", lietotajvards);

                        int rowsUpdated = sqlite_cmd.ExecuteNonQuery();

                        if (rowsUpdated > 0)
                        {
                            MessageBox.Show("Parole veiksmīgi mainīta!");
                        }
                        else
                        {
                            MessageBox.Show("Lietotājs nav atrasts!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    MessageBox.Show($"Kļūda veicot darbību ar datubāzi! {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Paroles nesakrīt!");
            }
        }
    }
}