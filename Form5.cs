using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Palidzibas_serviss
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        // Metode, kas izveido un atgriež SQLite savienojumu
        static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            // Izveido savienojuma virkni, norādot datu bāzes failu un citus parametrus
            sqlite_conn = new SQLiteConnection("Data Source=palidzibas_serviss.db; Version=3; New=True; Compress=True; ");
            try
            {
                sqlite_conn.Open(); // Mēģina atvērt savienojumu ar datu bāzi
            }
            catch (Exception ex)
            {
                MessageBox.Show("Konekcija neizdevās!"); // Parāda paziņojumu, ja savienojums neizdodas
            }
            return sqlite_conn; // Atgriež atvērto savienojumu
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // Notiek, kad forma tiek ielādēta
        }

        private void dzesanas_izvele_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Notiek, kad mainās dzēšanas izvēle
            paradit_tabulu(); // Izsauc funkciju, lai parādītu tabulu atkarībā no izvēles
        }

        public void paradit_tabulu()
        {
            // Parāda tabulu atkarībā no izvēlētās dzēšanas kategorijas
            if (dzesanas_izvele.SelectedItem.ToString() == "Lietotājs")
            {
                // Izveido savienojumu ar datu bāzi
                CreateConnection();
                SQLiteConnection sqlite_conn;
                sqlite_conn = CreateConnection();

                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();
                // Izvēlas visus ierakstus no Lietotaja_dati tabulas
                sqlite_cmd.CommandText = "SELECT * FROM Lietotaja_dati";

                DataTable sTable;
                SQLiteDataAdapter sqlda = new SQLiteDataAdapter(sqlite_cmd);
                using (sTable = new DataTable())
                {
                    sqlda.Fill(sTable); // Aizpilda DataTable ar rezultātiem no datu bāzes
                    dzesanas_tabula.DataSource = sTable; // Ielādē rezultātus tabulā
                }
            }
            else if (dzesanas_izvele.SelectedItem.ToString() == "Ziņa")
            {
                // Izveido savienojumu ar datu bāzi
                CreateConnection();
                SQLiteConnection sqlite_conn;
                sqlite_conn = CreateConnection();

                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();
                // Izvēlas visus ierakstus no Zina tabulas
                sqlite_cmd.CommandText = "SELECT * FROM Zina";

                DataTable sTable;
                SQLiteDataAdapter sqlda = new SQLiteDataAdapter(sqlite_cmd);
                using (sTable = new DataTable())
                {
                    sqlda.Fill(sTable); // Aizpilda DataTable ar rezultātiem no datu bāzes
                    dzesanas_tabula.DataSource = sTable; // Ielādē rezultātus tabulā
                }
            }
        }

        private void dzesana_Click(object sender, EventArgs e)
        {
            dzest(); // Izsauc funkciju, lai dzēstu ierakstu
        }

        public void dzest()
        {
            int id;

            // Mēģina pārveidot ievadīto tekstu par skaitli
            if (int.TryParse(id_numurs.Text, out id))
            {
                // Pārveidošana veiksmīga, un 'id' tagad satur pārveidoto skaitli
                // Var izmantot 'id' turpmākajā kodā
            }
            else
            {
                // Pārveidošana neveiksmīga - apstrādā nekorektu ievadi
                MessageBox.Show("Nederīgs ID. Lūdzu, ievadiet derīgu veselu skaitli.");
            }

            // Atkarībā no izvēlētās dzēšanas kategorijas veic dzēšanu
            if (dzesanas_izvele.SelectedItem.ToString() == "Lietotājs")
            {
                CreateConnection(); // Izveido savienojumu ar datu bāzi
                SQLiteConnection sqlite_conn;
                sqlite_conn = CreateConnection();

                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();
                // Izdzēš ierakstu no Lietotaja_dati tabulas pēc norādītā ID
                sqlite_cmd.CommandText = "DELETE FROM Lietotaja_dati WHERE Datu_ID = @Datu_ID";
                sqlite_cmd.Parameters.AddWithValue("@Datu_ID", id);

                DataTable sTable;
                SQLiteDataAdapter sqlda = new SQLiteDataAdapter(sqlite_cmd);
                using (sTable = new DataTable())
                {
                    sqlda.Fill(sTable); // Aizpilda DataTable ar rezultātiem no datu bāzes
                    dzesanas_tabula.DataSource = sTable; // Ielādē rezultātus tabulā
                }
            }
            else if (dzesanas_izvele.SelectedItem.ToString() == "Ziņa")
            {
                CreateConnection(); // Izveido savienojumu ar datu bāzi
                SQLiteConnection sqlite_conn;
                sqlite_conn = CreateConnection();

                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();
                // Izdzēš ierakstu no Zina tabulas pēc norādītā ID
                sqlite_cmd.CommandText = "DELETE FROM Zina WHERE Zina_ID = @Zina_ID";
                sqlite_cmd.Parameters.AddWithValue("@Zina_ID", id);

                DataTable sTable;
                SQLiteDataAdapter sqlda = new SQLiteDataAdapter(sqlite_cmd);
                using (sTable = new DataTable())
                {
                    sqlda.Fill(sTable); // Aizpilda DataTable ar rezultātiem no datu bāzes
                    dzesanas_tabula.DataSource = sTable; // Ielādē rezultātus tabulā
                }
            }

            id_numurs.Clear(); // Notīra ievades lauku pēc dzēšanas
        }

        private void id_numurs_TextChanged(object sender, EventArgs e)
        {
            // Notiek, kad mainās teksta ievades lauks
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Izveido jaunu Form3 objektu
            Form3 f3 = new Form3();
            f3.Show(); // Parāda Form3
            this.Hide(); // Paslēpj šo formu (Form5)
        }
    }
}
