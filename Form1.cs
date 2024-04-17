using System;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Palidzibas_servissML.Model;

namespace Palidzibas_serviss
{
    public partial class Form1 : Form
    {
        private int receivedValue; // Store received value (e.g., datu_id)

        public Form1(int datu_id) // Constructor to receive an initial value
        {
            InitializeComponent(); // Initialize form components
            this.receivedValue = datu_id; // Set received value to the class field
        }

        private SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=palidzibas_serviss.db; Version=3; New=True; Compress=True;");
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

        private void button1_Click(object sender, EventArgs e)
        {
            string teksts = zina.Text;

            if (string.IsNullOrEmpty(teksts))
            {
                MessageBox.Show("Lūdzu aizpildiet lauku!");
                return;
            }

            // Insert data into the Zina table
            try
            {
                using (SQLiteConnection sqlite_conn = CreateConnection())
                {
                    using (SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand())
                    {
                        // Use parameterized query to avoid SQL injection and ensure correct column-value mapping
                        sqlite_cmd.CommandText = @"
                    INSERT INTO Zina (Datu_id, Teksts)
                    VALUES (@Datu_id, @Teksts)";

                        // Bind parameters with actual values
                        sqlite_cmd.Parameters.AddWithValue("@Datu_id", receivedValue);
                        sqlite_cmd.Parameters.AddWithValue("@Teksts", teksts);

                        // Execute the query
                        sqlite_cmd.ExecuteNonQuery();

                        MessageBox.Show("Ziņa nosūtīta veiksmīgi!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kļūda datu ievietošanā: {ex.Message}");
            }

            // Perform data submission logic
            datu_nosutisana();
        }

        private void datu_nosutisana()
        {
            var input = new ModelInput();
            input.Col0 = zina.Text;

            // Perform prediction using the machine learning model
            ModelOutput prediction = ConsumeModel.Predict(input);

            // Determine the predicted category based on the max probability
            int maxIndex = 0;
            float maxProbability = prediction.Score[0];

            for (int i = 1; i < prediction.Score.Length; i++)
            {
                if (prediction.Score[i] > maxProbability)
                {
                    maxProbability = prediction.Score[i];
                    maxIndex = i + 1; // Increment by 1 because category indices start from 1
                }
            }

            // Prepare the message for the predicted category
            string predictedCategory = $"Kategorija {maxIndex}";

            if (maxIndex == 0)
            {
                atbilde.Text = $"Jūsu ziņa nosūtīta IT nozarei!";
            }
            else if (maxIndex == 2)
            {
                atbilde.Text = $"Jūsu ziņa nosūtīta Finanšu nozarei!";
            }
            else if (maxIndex == 3)
            {
                atbilde.Text = $"Jūsu ziņa nosūtīta Pārdošanas nozarei!";
            }
            else if (maxIndex == 4)
            {
                atbilde.Text = $"Jūsu ziņa nosūtīta Cilvēkresursu nozarei!";
            }
            else if (maxIndex == 5)
            {
                atbilde.Text = $"Jūsu ziņa nosūtīta Mārketinga nozarei!";
            }
            else if (maxIndex == 6)
            {
                atbilde.Text = $"Jūsu ziņa nosūtīta Kvalitātes kontroles nozarei!";
            }

        }

        private string CalculateMD5Hash(string input)
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

        private void tabula_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(receivedValue);
            f4.Show(); // Show Form1
            this.Hide();
        }
    }
}
