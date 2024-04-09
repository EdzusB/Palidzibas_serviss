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
            List<string> usernames = GetListOfUsernamesFromDatabase(); //Izsauc funkciju, kas ielasīja lietotājvārdus sarakstā
            List<string> hashedPasswords = GetListOfHashedPasswordsFromDatabase(); //Izsauc funkciju, kas ielasīja paroles sarakstā

            string searchTextUsername = Lietotajvards.Text; //Iegūst tekstu no TextBox
            string searchTextPassword = CalculateMD5Hash(Parole.Text); // Šifrē paroli un tad to iegūst no TextBox

            if (usernames.Contains(searchTextUsername) && hashedPasswords.Contains(searchTextPassword)) //Pārbauda vai lietotājvārds sakrīt ar attiecīgo paroli
            {
                Form1 f1 = new Form1(); //Ievieš jaunu mainīgo
                f1.Show(); //Pāiet uz Form4
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nepareizs lietotājvārds un/vai parole!"); //Izvada paziņojumu, ja lietotājvārds un/vai parole nesakrīt ar sarakstā esošajiem
            }
        }
    }
}
