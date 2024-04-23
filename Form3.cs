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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

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

        private List<string> GetListOfUsernamesFromDatabase() //Funkcija, kas iegūst visus lietotājvārdus no datubāzes
        {
            List<string> usernameList = new List<string>(); //Ievieš jaunu mainīgo

            using (SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=palidzibas_serviss.db; Version=3; New=True; Compress=True;")) //Konektējas ar datubāzi
            {
                sqlite_conn.Open(); //Atver datubāzi

                using (SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand())
                {
                    sqlite_cmd.CommandText = "SELECT Lietotajvards FROM Lietotaja_dati"; //Izvēlas visus mainīgos no attiecīgās kollonas - Lietotajvards

                    using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                    {
                        while (sqlite_datareader.Read())
                        {
                            string username = sqlite_datareader["Lietotajvards"].ToString(); //Visus lietotajvardus ielasa sarakstā
                            usernameList.Add(username);
                        }
                    }
                }
            }

            return usernameList; //Atgriež sarakstu
        }

        private List<string> GetListOfHashedPasswordsFromDatabase() //Funkcija, kas iegūst visas paroles no datubāzes
        {
            List<string> hashedPasswordList = new List<string>(); //Ievieš jaunu mainīgo

            using (SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=palidzibas_serviss.db; Version=3; New=True; Compress=True;")) //Konektējas ar datubāzi
            {
                sqlite_conn.Open();

                using (SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand())
                {
                    sqlite_cmd.CommandText = "SELECT Parole FROM Lietotaja_dati"; //Izvēlas visus mainīgos no attiecīgās kollonas - parole

                    using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                    {
                        while (sqlite_datareader.Read())
                        {
                            string password = sqlite_datareader["Parole"].ToString(); //Visas paroles ielasa sarakstā
                            hashedPasswordList.Add(password);
                        }
                    }
                }
            }

            return hashedPasswordList; //Atgriež sarakstu
        }

        private string CalculateMD5Hash(string input) //Šifrē paroli ar MD5 hash
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
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
            int datu_id = 0; // Initialize datu_id

            // Retrieve usernames and hashed passwords from the database
            List<string> usernames = GetListOfUsernamesFromDatabase();
            List<string> hashedPasswords = GetListOfHashedPasswordsFromDatabase();

            string searchTextUsername = Lietotajvards.Text; // Get the text from TextBox for username
            string searchTextPassword = CalculateMD5Hash(Parole.Text); // Hash the password from TextBox

            // Check if the entered username and password are valid
            if (usernames.Contains(searchTextUsername) && hashedPasswords.Contains(searchTextPassword))
            {
                try
                {
                    using (SQLiteConnection sqlite_conn = CreateConnection())
                    {
                        using (SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand())
                        {
                            sqlite_cmd.CommandText = @"
                        SELECT Datu_ID FROM Lietotaja_dati WHERE Lietotajvards = @lietotajvards";
                            sqlite_cmd.Parameters.AddWithValue("@lietotajvards", searchTextUsername);

                            // Execute the query to retrieve the Datu_ID
                            object result = sqlite_cmd.ExecuteScalar();

                            if (result != null && result != DBNull.Value)
                            {
                                datu_id = Convert.ToInt32(result); // Update datu_id with retrieved ID

                                // Pass the datu_id value to Form1
                                Form1 f1 = new Form1(datu_id);
                                f1.Show(); // Show Form1
                                this.Hide(); // Hide current Form3
                            }
                            else
                            {
                                MessageBox.Show("Error: User not found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Nepareizs lietotājvārds un/vai parole!");
            }
        }

        private List<string> GetListOfUsernamesFromDatabase1() //Funkcija, kas iegūst visus lietotājvārdus no datubāzes
        {
            List<string> usernameList = new List<string>(); //Ievieš jaunu mainīgo

            using (SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=palidzibas_serviss.db; Version=3; New=True; Compress=True;")) //Konektējas ar datubāzi
            {
                sqlite_conn.Open(); //Atver datubāzi

                using (SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand())
                {
                    sqlite_cmd.CommandText = "SELECT Parvaldnieka_lietotajvards FROM Parvaldnieks"; //Izvēlas visus mainīgos no attiecīgās kollonas - Lietotajvards

                    using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                    {
                        while (sqlite_datareader.Read())
                        {
                            string username = sqlite_datareader["Parvaldnieka_lietotajvards"].ToString(); //Visus lietotajvardus ielasa sarakstā
                            usernameList.Add(username);
                        }
                    }
                }
            }

            return usernameList; //Atgriež sarakstu
        }

        private List<string> GetListOfHashedPasswordsFromDatabase1() //Funkcija, kas iegūst visas paroles no datubāzes
        {
            List<string> hashedPasswordList = new List<string>(); //Ievieš jaunu mainīgo

            using (SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=palidzibas_serviss.db; Version=3; New=True; Compress=True;")) //Konektējas ar datubāzi
            {
                sqlite_conn.Open();

                using (SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand())
                {
                    sqlite_cmd.CommandText = "SELECT Parvaldnieka_parole FROM Parvaldnieks"; //Izvēlas visus mainīgos no attiecīgās kollonas - parole

                    using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                    {
                        while (sqlite_datareader.Read())
                        {
                            string password = sqlite_datareader["Parvaldnieka_parole"].ToString(); //Visas paroles ielasa sarakstā
                            hashedPasswordList.Add(password);
                        }
                    }
                }
            }

            return hashedPasswordList; //Atgriež sarakstu
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> usernames = GetListOfUsernamesFromDatabase1(); //Izsauc funkciju, kas ielasīja lietotājvārdus sarakstā
            List<string> hashedPasswords = GetListOfHashedPasswordsFromDatabase1(); //Izsauc funkciju, kas ielasīja paroles sarakstā

            string searchTextUsername = Lietotajvards.Text; //Iegūst tekstu no TextBox
            string searchTextPassword = CalculateMD5Hash(Parole.Text); // Šifrē paroli un tad to iegūst no TextBox

            if (usernames.Contains(searchTextUsername) && hashedPasswords.Contains(searchTextPassword)) //Pārbauda vai lietotājvārds sakrīt ar attiecīgo paroli
            {
                Form5 f5 = new Form5(); //Ievieš jaunu mainīgo
                f5.Show(); //Pāiet uz Form4
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nepareizs lietotājvārds un/vai parole!"); //Izvada paziņojumu, ja lietotājvārds un/vai parole nesakrīt ar sarakstā esošajiem
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Hide();
        }
    }
}
