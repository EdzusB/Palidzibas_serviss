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

        // Metode, kas izveido un atgriež SQLite savienojumu
        static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=palidzibas_serviss.db; Version=3; New=True; Compress=True;");
            try
            {
                sqlite_conn.Open(); // Mēģina atvērt savienojumu ar datu bāzi
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Konekcija neizdevās! {ex.Message}"); // Parāda paziņojumu, ja savienojums neizdodas
            }
            return sqlite_conn; // Atgriež atvērto savienojumu
        }

        // Notikums, kas tiek aktivizēts, kad tiek noklikšķināts uz pogas "Mainīt paroli"
        private void paroles_maina_Click(object sender, EventArgs e)
        {
            mainit_paroli(); // Izsauc funkciju, lai mainītu paroli
        }

        // Metode, kas veic paroles maiņu datubāzē
        public void mainit_paroli()
        {
            string lietotajvards = Lietotajvards.Text;
            string parole1 = jauna_parole1.Text;
            string parole2 = jauna_parole2.Text;

            // Pārbauda, vai ievadītās jaunās paroles sakrīt
            if (parole1 == parole2)
            {
                // Izveic paroles hešēšanu, izmantojot SHA-256 (drošāk nekā MD5)
                string hashedPassword;
                using (MD5 md5 = MD5.Create())
                {
                    byte[] inputBytes = Encoding.UTF8.GetBytes(parole1);
                    byte[] hashedBytes = md5.ComputeHash(inputBytes);
                    hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                }

                try
                {
                    // Izveido un atver jaunu SQLite savienojumu, izmantojot definēto metodi
                    using (SQLiteConnection sqlite_conn = CreateConnection())
                    using (SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand())
                    {
                        // Izveido SQL komandu, lai atjaunotu paroli datubāzē
                        sqlite_cmd.CommandText = @"
                            UPDATE Lietotaja_dati
                            SET Parole = @parole
                            WHERE Lietotajvards = @lietotajvards";

                        // Pievieno parametrus SQL komandai
                        sqlite_cmd.Parameters.AddWithValue("@parole", hashedPassword);
                        sqlite_cmd.Parameters.AddWithValue("@lietotajvards", lietotajvards);

                        // Izpilda SQL komandu un atgriež skaitu rediģēto rindiņu
                        int rowsUpdated = sqlite_cmd.ExecuteNonQuery();

                        // Paziņo par rezultātu lietotājam
                        if (rowsUpdated > 0)
                        {
                            MessageBox.Show("Parole veiksmīgi nomainīta!");
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
                MessageBox.Show("Paroles nesakrīt!"); // Parāda paziņojumu, ja ievadītās paroles nesakrīt
            }
        }

        // Notikums, kas tiek aktivizēts, kad tiek noklikšķināts uz pogas "Atpakaļ uz sākumu"
        private void atgriezties_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show(); // Parāda Form3
            this.Hide(); // Paslēpj šo formu (Form6)
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // Notiek, kad forma tiek ielādēta
        }
    }
}
