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
                using (SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand())
                {
                    sqlite_cmd.CommandText = @"
                        INSERT INTO Zina (Teksts)
                        VALUES (@Teksts)";
                    sqlite_cmd.Parameters.AddWithValue("@Teksts", teksts);
                    sqlite_cmd.ExecuteNonQuery();

                    MessageBox.Show("Ziņa nosūtīta veiksmīgi!");
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
            atbilde.Text = $"Jūsu ziņa nosūtīta {predictedCategory} nozarei!";
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
    }
}
