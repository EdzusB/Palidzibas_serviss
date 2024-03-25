using System;
using System.Windows.Forms;
using Palidzibas_servissML.Model;

namespace Palidzibas_serviss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Notikuma apstrāde pogai "button1" noklikšķinot
        private void button1_Click(object sender, EventArgs e)
        {
            datu_nosutisana();
        }
        private void datu_nosutisana()
        {
            // Izveido jaunu modeļa ievades objektu
            var input = new ModelInput();
            // Iestatq ievades vērtību no teksta lauka "zina"
            if (zina.Text == "")
            {
                MessageBox.Show("Lūdzu aizpildiet lauku!");
            }
            else
            {
                input.Col0 = zina.Text;



                // Izdara modeļa prognozi, izmantojot ievadi
                ModelOutput prediction = ConsumeModel.Predict(input);

                // Atrastās kategorijas noteikšana
                int maxIndex = 0;
                float maxProbability = prediction.Score[0];

                // Atrastās kategorijas noteikšana, kas atbilst vislielākajai varbūtībai
                for (int i = 1; i < prediction.Score.Length; i++)
                {
                    if (prediction.Score[i] > maxProbability)
                    {
                        maxProbability = prediction.Score[i];
                        maxIndex = i + 1; // Pievienojam 1, jo kategorijas indeksi sākas no 1
                    }
                }

                // Sagatavo ziņojumu par prognozēto kategoriju
                string predictedCategory = $"Kategorija {maxIndex}";

                // Izvada informāciju par prognozēto kategoriju un tās varbūtībām uz konsoli
                Console.WriteLine("MaxIndex: " + maxIndex);
                Console.WriteLine("Prediction Scores: " + string.Join(", ", prediction.Score));

                // Parāda atbilstošu ziņojumu, atkarībā no prognozētās kategorijas
                if (maxIndex == 0)
                {
                    MessageBox.Show("Jūsu ziņa nosūtīta IT nozarei!");
                }
                else if (maxIndex == 2)
                {
                    MessageBox.Show("Jūsu ziņa nosūtīta Finanšu nozarei!");
                }
                else if (maxIndex == 3)
                {
                    MessageBox.Show("Jūsu ziņa nosūtīta Pārdošanas nozarei!");
                }
                else if (maxIndex == 4)
                {
                    MessageBox.Show("Jūsu ziņa nosūtīta Cilvēkresursu nozarei!");
                }
                else if (maxIndex == 5)
                {
                    MessageBox.Show("Jūsu ziņa nosūtīta Mārketinga nozarei!");
                }
            }
        }
    }
}
