using System;
using System.Text;
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

        // Metode, kas izveido un atver SQLite savienojumu ar datubāzi
        static SQLiteConnection CreateConnection() // Konekcija ar datubāzi
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = new SQLiteConnection("Data Source=palidzibas_serviss.db; Version=3; New=True; Compress=True;");
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
            // Šī metode tiek izsaukta, kad Form2 tiek ielādēts.
        }

        private void registreties_Click(object sender, EventArgs e)
        {
            datu_ievade(); // Izsauc datu ievades funkciju
            Registreties(); // Izsauc reģistrācijas funkciju
        }

        private void datu_ievade()
        {
            string input = parole.Text; // Iegūst tekstu no parole TextBox
            string hashedPassword = ""; // Inicializēt hash paroli

            // Izveido hash no ievades paroles, izmantojot MD5 algoritmu
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashedBytes = md5.ComputeHash(inputBytes);

                // Konvertē baitu masīvu uz heksadecimālu virkni
                hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }

            // Izveido jaunu 'registresana' klases instanci
            registresana registresana1 = new registresana
            {
                vards = Vards.Text,
                uzvards = Uzvards.Text,
                epasts = Epasts.Text,
                numurs = numurs.Text,
                lietotajvards = lietotajvards.Text,
                parole = hashedPassword // Saglabā hash paroli
            };

            // Pārbauda vai obligātie lauki nav tukši
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
                            // Izmanto parametrizētu vaicājumu, lai novērstu SQL injekcijas
                            sqlite_cmd.CommandText = @"
                        INSERT INTO Lietotaja_dati (Vards, Uzvards, [E-pasts], Numurs, Lietotajvards, Parole)
                        VALUES (@vards, @uzvards, @epasts, @numurs, @lietotajvards, @parole)";

                            // Pievieno parametrus komandai
                            sqlite_cmd.Parameters.AddWithValue("@vards", registresana1.vards);
                            sqlite_cmd.Parameters.AddWithValue("@uzvards", registresana1.uzvards);
                            sqlite_cmd.Parameters.AddWithValue("@epasts", registresana1.epasts);
                            sqlite_cmd.Parameters.AddWithValue("@numurs", registresana1.numurs);
                            sqlite_cmd.Parameters.AddWithValue("@lietotajvards", registresana1.lietotajvards);
                            sqlite_cmd.Parameters.AddWithValue("@parole", registresana1.parole);

                            // Izpilda SQL komandu
                            sqlite_cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Kļūda: {ex.Message}");
                    MessageBox.Show("Šāds lietotājvārds un/vai parole jau eksistē!!!");
                }
            }
            else
            {
                MessageBox.Show("Lūdzu aizpildiet visus ievades laukus!");
            }
        }

        private void Registreties()
        {
            string inputUsername = lietotajvards.Text; // Iegūst lietotājvārda tekstu no TextBox

            try
            {
                using (SQLiteConnection sqlite_conn = CreateConnection())
                using (SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand())
                {
                    // Izmanto parametrizētu vaicājumu, lai iegūtu Datu_ID pēc lietotājvārda
                    sqlite_cmd.CommandText = @"
                    SELECT Datu_ID FROM Lietotaja_dati WHERE Lietotajvards = @lietotajvards";
                    sqlite_cmd.Parameters.AddWithValue("@lietotajvards", inputUsername);

                    // Izpilda vaicājumu, lai iegūtu Datu_ID
                    object result = sqlite_cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int datu_id = Convert.ToInt32(result);

                        // Parāda Form1 ar iegūto datu_id
                        Form1 f1 = new Form1(datu_id); // Padod datu_id Form1 konstruktoram
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

    // Klase, kas satur reģistrācijas lauku mainīgos
    class registresana
    {
        public string vards { get; set; }
        public string uzvards { get; set; }
        public string epasts { get; set; }
        public string numurs { get; set; }
        public string lietotajvards { get; set; }
        public string parole { get; set; }
    }
}


