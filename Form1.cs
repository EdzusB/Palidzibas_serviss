using System;
using System.Drawing;
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
            input.Col0 = zina.Text;

            ModelOutput prediction = ConsumeModel.Predict(input);

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

            string predictedCategory = $"Category {maxIndex}";

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

            private Label messageLabel;
        private Button okButton;

        public CustomMessageBoxForm(string message)
        {
            InitializeComponent();
            this.messageLabel.Text = message;
        }

        private void InitializeComponent()
        {
            this.Size = new Size(300, 150);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.messageLabel = new Label();
            this.messageLabel.Dock = DockStyle.Fill;
            this.messageLabel.TextAlign = ContentAlignment.MiddleCenter;

            this.okButton = new Button();
            this.okButton.Text = "OK";
            this.okButton.Dock = DockStyle.Bottom;
            this.okButton.Click += (sender, e) => this.Close();

            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.okButton);
        }

        public static void Show(string message)
        {
            CustomMessageBoxForm customMessageBox = new CustomMessageBoxForm(message);
            customMessageBox.ShowDialog();
        }
    }
}