using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void button1_Click(object sender, EventArgs e)
        {
            var input = new ModelInput();
            input.Col0 = zina.Text; // Assuming 'zina' is a TextBox control where the user inputs data

            ModelOutput prediction = ConsumeModel.Predict(input);

            // Find the index of the maximum probability in the prediction array
            int maxIndex = 0;
            float maxProbability = prediction.Score[0];

            for (int i = 1; i < prediction.Score.Length; i++)
            {
                if (prediction.Score[i] > maxProbability)
                {
                    maxProbability = prediction.Score[i];
                    maxIndex = i+1;
                }
            }

            // Assuming maxIndex corresponds to the category label
            string predictedCategory = $"Category {maxIndex}"; // Adjust according to your category labels

            Console.WriteLine("MaxIndex: " + maxIndex);
            Console.WriteLine("Prediction Scores: " + string.Join(", ", prediction.Score));

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

            //cena.Text = predictedCategory; // Display the predicted category label
        }
    }
}