using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Security.Cryptography;

namespace Palidzibas_serviss
{
    public partial class Form3 : Form
    {
        private string _connectionString = "Data Source=palidzibas_serviss.db; Version=3; New=True; Compress=True;";

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Šī metode tiek izsaukta, kad Form3 tiek ielādēts.
        }

        private string CalculateMD5Hash(string input) // Metode, lai ģenerētu MD5 hash vērtību no ievades teksta
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2")); // Pārvērš baitu masīvu par heksadecimālu virkni
                }
                return sb.ToString(); // Atgriež MD5 hash kā heksadecimālu virkni
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void pieteikties_Click(object sender, EventArgs e)
        {
            lietotajs_pierakstities(); // Izsauc lietotāja pieteikšanās funkciju
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pierakstities_parvaldnieks(); // Izsauc pārvaldnieka pierakstīšanās funkciju
        }

        private string CalculateMD5HashForPassword(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Pārvērš baitu masīvu par heksadecimālu virkni
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString(); // Atgriež MD5 hash kā heksadecimālu virkni
            }
        }

        private int GetUserIdByUsername(string username)
        {
            int userId = 0;

            using (SQLiteConnection sqlite_conn = new SQLiteConnection(_connectionString))
            {
                sqlite_conn.Open();

                using (SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand())
                {
                    sqlite_cmd.CommandText = @"
                        SELECT Datu_ID FROM Lietotaja_dati WHERE Lietotajvards = @lietotajvards";
                    sqlite_cmd.Parameters.AddWithValue("@lietotajvards", username);

                    // Izpilda vaicājumu, lai iegūtu Datu_ID
                    object result = sqlite_cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        userId = Convert.ToInt32(result); // Atjauno userId ar iegūto ID vērtību
                    }
                }
            }

            return userId;
        }

        private void lietotajs_pierakstities()
        {
            // Izveido Lietotaja_saraksts klasi, lai iegūtu lietotājvārdus un sakrītošās hash paroles
            Lietotaja_saraksts userManager = new Lietotaja_saraksts(_connectionString);

            List<string> usernames = userManager.GetListOfUsernamesFromDatabase();
            List<string> hashedPasswords = userManager.GetListOfHashedPasswordsFromDatabase();

            string searchTextUsername = Lietotajvards.Text; // Iegūst tekstu no lietotājvārda TextBox
            string searchTextPassword = CalculateMD5HashForPassword(Parole.Text); // Iegūst un dekripto paroli no TextBox

            if (usernames.Contains(searchTextUsername) && hashedPasswords.Contains(searchTextPassword))
            {
                int datu_id = GetUserIdByUsername(searchTextUsername); // Iegūst lietotāja ID pēc lietotājvārda

                if (datu_id > 0)
                {
                    // Padod datu_id vērtību Form1
                    Form1 f1 = new Form1(datu_id);
                    f1.Show(); // Parāda Form1
                    this.Hide(); // Paslēpj pašreizējo Form3
                }
                else
                {
                    MessageBox.Show("Kļūda: lietotāja ID nav atrasts."); //Parāda kļūdas paziņojumu, ja lietotājs nav atrasts
                }
            }
            else
            {
                MessageBox.Show("Nepareizs lietotājvārds un/vai parole!");  // Parāda kļūdas paziņojumu, ja lietotājvārds vai parole ir nepareiza
            }
        }

        public void pierakstities_parvaldnieks()
        {
            // Izveido Menedzera_saraksts klasi, lai iegūtu pārvaldnieka lietotājvārdus un sakrītošos hash paroles
            Menedzera_saraksts userManager = new Menedzera_saraksts(_connectionString);

            List<string> usernames = userManager.GetListOfUsernamesFromDatabase();
            List<string> hashedPasswords = userManager.GetListOfHashedPasswordsFromDatabase();

            string searchTextUsername = Lietotajvards.Text; // Iegūstam tekstu no lietotājvārda TextBox
            string searchTextPassword = CalculateMD5HashForPassword(Parole.Text); // Iegūst un dekripto paroli no TextBox

            if (usernames.Contains(searchTextUsername) && hashedPasswords.Contains(searchTextPassword))
            {
                // Ja lietotājvārds un hash paroles ir derīgi, parāda Form5
                Form5 f5 = new Form5();
                f5.Show();
                this.Hide(); // Paslēpj pašreizējo formu
            }
            else
            {
                MessageBox.Show("Nepareizs lietotājvārds un/vai parole!"); // Parāda kļūdas paziņojumu, ja lietotājvārds vai parole ir nepareiza
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Hide();
        }
    }

    // Klase, kas tiek izmantota, lai iegūtu lietotāju datus no Lietotaja_dati tabulas
    public class Lietotaja_saraksts
    {
        private string _connectionString;

        public Lietotaja_saraksts(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Iegūst lietotājvārdus no datubāzes
        public List<string> GetListOfUsernamesFromDatabase()
        {
            List<string> usernameList = new List<string>();

            using (SQLiteConnection sqlite_conn = new SQLiteConnection(_connectionString))
            {
                sqlite_conn.Open();

                using (SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand())
                {
                    sqlite_cmd.CommandText = "SELECT Lietotajvards FROM Lietotaja_dati";

                    using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                    {
                        while (sqlite_datareader.Read())
                        {
                            string username = sqlite_datareader["Lietotajvards"].ToString();
                            usernameList.Add(username);
                        }
                    }
                }
            }

            return usernameList;
        }

        // Iegūst hash paroles no datubāzes
        public List<string> GetListOfHashedPasswordsFromDatabase()
        {
            List<string> hashedPasswordList = new List<string>();

            using (SQLiteConnection sqlite_conn = new SQLiteConnection(_connectionString))
            {
                sqlite_conn.Open();

                using (SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand())
                {
                    sqlite_cmd.CommandText = "SELECT Parole FROM Lietotaja_dati";

                    using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                    {
                        while (sqlite_datareader.Read())
                        {
                            string password = sqlite_datareader["Parole"].ToString();
                            hashedPasswordList.Add(password);
                        }
                    }
                }
            }

            return hashedPasswordList;
        }
    }

    // Klase, kas tiek izmantota, lai iegūtu pārvaldnieka datus no Parvaldnieks tabulas
    public class Menedzera_saraksts
    {
        private string _connectionString;

        public Menedzera_saraksts(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Iegūst pārvaldnieka lietotājvārdus no datubāzes
        public List<string> GetListOfUsernamesFromDatabase()
        {
            List<string> usernameList = new List<string>();

            using (SQLiteConnection sqlite_conn = new SQLiteConnection(_connectionString))
            {
                sqlite_conn.Open();

                using (SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand())
                {
                    sqlite_cmd.CommandText = "SELECT Parvaldnieka_lietotajvards FROM Parvaldnieks";

                    using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                    {
                        while (sqlite_datareader.Read())
                        {
                            string username = sqlite_datareader["Parvaldnieka_lietotajvards"].ToString();
                            usernameList.Add(username);
                        }
                    }
                }
            }

            return usernameList;
        }

        // Iegūst pārvaldnieka paroles no datubāzes
        public List<string> GetListOfHashedPasswordsFromDatabase()
        {
            List<string> hashedPasswordList = new List<string>();

            using (SQLiteConnection sqlite_conn = new SQLiteConnection(_connectionString))
            {
                sqlite_conn.Open();

                using (SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand())
                {
                    sqlite_cmd.CommandText = "SELECT Parvaldnieka_parole FROM Parvaldnieks";

                    using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                    {
                        while (sqlite_datareader.Read())
                        {
                            string password = sqlite_datareader["Parvaldnieka_parole"].ToString();
                            hashedPasswordList.Add(password);
                        }
                    }
                }
            }

            return hashedPasswordList;
        }
    }
}
