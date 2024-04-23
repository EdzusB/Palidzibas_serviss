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
        private int receivedValue; // Glabā saņemto vērtību (piem., datu_id)

        public Form1(int datu_id) // Konstruktors, lai saņemtu sākotnējo vērtību
        {
            InitializeComponent(); // Inicializē formu komponentes
            this.receivedValue = datu_id; // Iestata saņemto vērtību klases laukā
        }

        async Task<DateTime> GetCurrentDateTimeFromAPI()
        {
            // Asinhroni iegūst pašreizējo datumu un laiku no API
            string apiUrl = "http://worldtimeapi.org/api/ip"; // API, kas atgriež datumu un laiku atkarībā no IP adreses
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
                    throw new Exception("Neizdevās iegūt datumu un laiku no API");
                }
            }
        }

        private SQLiteConnection CreateConnection()
        {
            // Izveido un atver savienojumu ar SQLite datubāzi
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
            // Notiek teksta ievade un datu nosūtīšana
            teksta_ievade();
            datu_nosutisana();
        }

        public async void teksta_ievade()
        {
            // Iegūst tekstu no ievades lauka
            string teksts = zina.Text;

            if (string.IsNullOrEmpty(teksts))
            {
                MessageBox.Show("Lūdzu aizpildiet lauku!");
                return;
            }

            try
            {
                // Iegūst pašreizējo datumu un laiku no API
                DateTime currentDateTime = await GetCurrentDateTimeFromAPI();

                using (SQLiteConnection sqlite_conn = CreateConnection())
                {
                    using (SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand())
                    {
                        // Ievieto datus Zina tabulā
                        sqlite_cmd.CommandText = @"
                    INSERT INTO Zina (Datu_id, Teksts, Datums_laiks)
                    VALUES (@Datu_id, @Teksts, @Datums_laiks)";

                        // Piesaista parametrus ar faktiskajām vērtībām
                        sqlite_cmd.Parameters.AddWithValue("@Datu_id", receivedValue);
                        sqlite_cmd.Parameters.AddWithValue("@Teksts", teksts);
                        sqlite_cmd.Parameters.AddWithValue("@Datums_laiks", currentDateTime);

                        // Izpilda vaicājumu
                        sqlite_cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kļūda datu ievietošanā: {ex.Message}");
            }
        }

        private void datu_nosutisana()
        {
            var input = new ModelInput();
            input.Col0 = zina.Text;

            // Veic prognozi, izmantojot mašīnmācīšanās modeli
            ModelOutput prediction = ConsumeModel.Predict(input);

            // Noteik prognozēto kategoriju, balstoties uz maksimālo varbūtību
            int maxIndex = 0;
            float maxProbability = prediction.Score[0];

            for (int i = 1; i < prediction.Score.Length; i++)
            {
                if (prediction.Score[i] > maxProbability)
                {
                    maxProbability = prediction.Score[i];
                    maxIndex = i + 1; // Palielina par 1, jo kategorijas indeksi sākas no 1
                }
            }

            // Sagatavo ziņojumu par prognozēto kategoriju
            string predictedCategory = $"Kategorija {maxIndex}";

            string nozare = ""; // Deklarē `nozare` augstākā līmenī

            // Izvēlas atbilstošo nozari atkarībā no prognozētās kategorijas
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
                    // Iegūst Zina_ID, lai to izmantotu Nozare tabulas ierakstā
                    sqlite_cmd.CommandText = @"
                    SELECT Zina_ID FROM Zina WHERE Teksts = @Teksts";
                    sqlite_cmd.Parameters.AddWithValue("@Teksts", inputzina);

                    // Izpilda vaicājumu, lai iegūtu Zina_ID
                    object result = sqlite_cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int zina_id = Convert.ToInt32(result);

                        // Ievieto datus Nozare tabulā
                        sqlite_cmd.CommandText = @"
                    INSERT INTO Nozare (nozare, Datu_id, Zina_id)
                    VALUES (@Nozare, @Datu_id, @Zina_id)";

                        // Piesaista parametrus ar faktiskajām vērtībām
                        sqlite_cmd.Parameters.AddWithValue("@Nozare", nozare);
                        sqlite_cmd.Parameters.AddWithValue("@Datu_id", receivedValue);
                        sqlite_cmd.Parameters.AddWithValue("@Zina_id", zina_id);

                        // Izpilda ievietošanas vaicājumu
                        sqlite_cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private string CalculateMD5Hash(string input)
        {
            // Aprēķina MD5 kodus no ievades
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Pārvērš baitu masīvu par heksadecimālu virkni
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
            // Pāreja uz Form4, padodot saņemto vērtību
            Form4 f4 = new Form4(receivedValue);
            f4.Show(); // Parāda Form4
            this.Hide(); // Paslēpj pašreizējo formu
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Pāreja uz Form3
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide(); // Paslēpj pašreizējo formu
        }
    }
}
