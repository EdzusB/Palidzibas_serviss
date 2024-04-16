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
using System.Security.Cryptography;

namespace Palidzibas_serviss
{
    public partial class Form2 : Form
    {
        public Form2()
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

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void registreties_Click(object sender, EventArgs e)
        {
            string input = parole.Text; // Get text from TextBox
            string hashedPassword = ""; // Initialize hashed password variable

            // Hash the input password using MD5
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashedBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to a hexadecimal string
                hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }

            // Create a new instance of the 'registresana' class
            registresana registresana1 = new registresana
            {
                vards = Vards.Text,
                uzvards = Uzvards.Text,
                epasts = Epasts.Text,
                numurs = numurs.Text,
                lietotajvards = lietotajvards.Text,
                parole = hashedPassword // Store the hashed password
            };

            // Check if required fields are not empty
            if (!string.IsNullOrEmpty(registresana1.vards) &&
                !string.IsNullOrEmpty(registresana1.uzvards) &&
                !string.IsNullOrEmpty(registresana1.epasts) &&
                !string.IsNullOrEmpty(registresana1.numurs) &&
                !string.IsNullOrEmpty(registresana1.lietotajvards))
            {
                try
                {
                    using (SQLiteConnection sqlite_conn = CreateConnection())
                    {
                        using (SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand())
                        {
                            // Use parameterized query to prevent SQL injection
                            sqlite_cmd.CommandText = @"
                        INSERT INTO Lietotaja_dati (Vards, Uzvards, [E-pasts], Numurs, Lietotajvards, Parole)
                        VALUES (@vards, @uzvards, @epasts, @numurs, @lietotajvards, @parole)";

                            // Add parameters to the command
                            sqlite_cmd.Parameters.AddWithValue("@vards", registresana1.vards);
                            sqlite_cmd.Parameters.AddWithValue("@uzvards", registresana1.uzvards);
                            sqlite_cmd.Parameters.AddWithValue("@epasts", registresana1.epasts);
                            sqlite_cmd.Parameters.AddWithValue("@numurs", registresana1.numurs);
                            sqlite_cmd.Parameters.AddWithValue("@lietotajvards", registresana1.lietotajvards);
                            sqlite_cmd.Parameters.AddWithValue("@parole", registresana1.parole);

                            // Execute the SQL command
                            sqlite_cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    MessageBox.Show("Šāds lietotājvārds un/vai parole jau eksistē!!!");
                }
            }
            else
            {
                MessageBox.Show("Lūdzu aizpildiet visus ievades laukus!");
            }


        }
        private void talak_Click(object sender, EventArgs e)
        {
            string inputUsername = lietotajvards.Text; // Get username text from TextBox

            try
            {
                using (SQLiteConnection sqlite_conn = CreateConnection())
                using (SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand())
                {
                    // Use parameterized query to retrieve Datu_ID based on username
                    sqlite_cmd.CommandText = @"
                SELECT Datu_ID FROM Lietotaja_dati WHERE Lietotajvards = @lietotajvards";
                    sqlite_cmd.Parameters.AddWithValue("@lietotajvards", inputUsername);

                    // Execute the query to retrieve the Datu_ID
                    object result = sqlite_cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int datu_id = Convert.ToInt32(result);
                        MessageBox.Show($"Lietotājs atrasts ar ID: {datu_id}");

                        // Show Form1 with the retrieved datu_id
                        Form1 f1 = new Form1(datu_id); // Pass the datu_id to Form1 constructor
                        f1.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kļūda: Lietotājs nav atrasts.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kļūda: {ex.Message}");
            }
        }
    }
    class registresana //Izveido klasi ar mainīgajiem
    {
        public string vards { get; set; }
        public string uzvards { get; set; }
        public string epasts { get; set; }
        public string numurs { get; set; }
        public string lietotajvards { get; set; }
        public string parole { get; set; }
    }
}

