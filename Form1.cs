using System;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Palidzibas_servissML.Model;
using System.Net.Http;
using System.Threading.Tasks;

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
        async Task<DateTime> GetCurrentDateTimeFromAPI()
        {
            string apiUrl = "http://worldtimeapi.org/api/ip"; // Use IP-based API to get current date and time
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResult);
                    DateTime currentDateTime = result.datetime;
                    return currentDateTime;
                }
                else
                {
                    throw new Exception("Failed to retrieve date and time from API");
                }
            }
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

        private async void button1_Click(object sender, EventArgs e)
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
                DateTime currentDateTime = await GetCurrentDateTimeFromAPI();

                using (SQLiteConnection sqlite_conn = CreateConnection())
                {
                    using (SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand())
                    {
                        // Use parameterized query to avoid SQL injection and ensure correct column-value mapping
                        sqlite_cmd.CommandText = @"
                    INSERT INTO Zina (Datu_id, Teksts, Datums_laiks)
                    VALUES (@Datu_id, @Teksts, @Datums_laiks)";

                        // Bind parameters with actual values
                        sqlite_cmd.Parameters.AddWithValue("@Datu_id", receivedValue);
                        sqlite_cmd.Parameters.AddWithValue("@Teksts", teksts);
                        sqlite_cmd.Parameters.AddWithValue("@Datums_laiks", currentDateTime);

                        // Execute the query
                        sqlite_cmd.ExecuteNonQuery();
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

           string nozare = ""; // Declare `nozare` at a higher scope

            if (maxIndex == 0)
            {
                nozare = "IT";
                atbilde.Text = $"Jūsu ziņa nosūtīta IT nozarei!";
            }
            else if (maxIndex == 2)
            {
                nozare = "Finanšu";
                atbilde.Text = $"Jūsu ziņa nosūtīta Finanšu nozarei!";
            }
            else if (maxIndex == 3)
            {
                nozare = "Pārdošanas";
                atbilde.Text = $"Jūsu ziņa nosūtīta Pārdošanas nozarei!";
            }
            else if (maxIndex == 4)
            {
                nozare = "Cilvēkresursu";
                atbilde.Text = $"Jūsu ziņa nosūtīta Cilvēkresursu nozarei!";
            }
            else if (maxIndex == 5)
            {
                nozare = "Mārketinga";
                atbilde.Text = $"Jūsu ziņa nosūtīta Mārketinga nozarei!";
            }
            else if (maxIndex == 6)
            {
                nozare = "Kvalitātes kontroles";
                atbilde.Text = $"Jūsu ziņa nosūtīta Kvalitātes kontroles nozarei!";
            }

            string inputzina = zina.Text;

            using (SQLiteConnection sqlite_conn = CreateConnection())
            {
                using (SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand())
                {
                    sqlite_cmd.CommandText = @"
                    SELECT Zina_ID FROM Zina WHERE Teksts = @Teksts";
                    sqlite_cmd.Parameters.AddWithValue("@Teksts", inputzina);

                    // Execute the query to retrieve the Zina_ID
                    object result = sqlite_cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int zina_id = Convert.ToInt32(result);

                        // Now insert into Nozare table
                        sqlite_cmd.CommandText = @"
                    INSERT INTO Nozare (nozare, Datu_id, Zina_id)
                    VALUES (@Nozare, @Datu_id, @Zina_id)";

                        // Bind parameters with actual values
                        sqlite_cmd.Parameters.AddWithValue("@Nozare", nozare);
                        sqlite_cmd.Parameters.AddWithValue("@Datu_id", receivedValue);
                        sqlite_cmd.Parameters.AddWithValue("@Zina_id", zina_id);

                        // Execute the insertion query
                        sqlite_cmd.ExecuteNonQuery();
                    }
                }
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }
    }
}
