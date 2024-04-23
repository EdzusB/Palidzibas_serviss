namespace Palidzibas_serviss
{
    partial class Form6
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Lietotajvards = new System.Windows.Forms.TextBox();
            this.jauna_parole1 = new System.Windows.Forms.TextBox();
            this.jauna_parole2 = new System.Windows.Forms.TextBox();
            this.paroles_maina = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lietotajvards
            // 
            this.Lietotajvards.Location = new System.Drawing.Point(380, 119);
            this.Lietotajvards.Name = "Lietotajvards";
            this.Lietotajvards.Size = new System.Drawing.Size(100, 20);
            this.Lietotajvards.TabIndex = 0;
            // 
            // jauna_parole1
            // 
            this.jauna_parole1.Location = new System.Drawing.Point(380, 164);
            this.jauna_parole1.Name = "jauna_parole1";
            this.jauna_parole1.Size = new System.Drawing.Size(100, 20);
            this.jauna_parole1.TabIndex = 1;
            // 
            // jauna_parole2
            // 
            this.jauna_parole2.Location = new System.Drawing.Point(380, 211);
            this.jauna_parole2.Name = "jauna_parole2";
            this.jauna_parole2.Size = new System.Drawing.Size(100, 20);
            this.jauna_parole2.TabIndex = 2;
            // 
            // paroles_maina
            // 
            this.paroles_maina.Location = new System.Drawing.Point(361, 283);
            this.paroles_maina.Name = "paroles_maina";
            this.paroles_maina.Size = new System.Drawing.Size(135, 23);
            this.paroles_maina.TabIndex = 3;
            this.paroles_maina.Text = "Nomainīt paroli";
            this.paroles_maina.UseVisualStyleBackColor = true;
            this.paroles_maina.Click += new System.EventHandler(this.paroles_maina_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Jūsu lietotājvārds";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Jaunā parole";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Atkārtojiet jauno paroli";
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.paroles_maina);
            this.Controls.Add(this.jauna_parole2);
            this.Controls.Add(this.jauna_parole1);
            this.Controls.Add(this.Lietotajvards);
            this.Name = "Form6";
            this.Text = "Paroles maiņa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Lietotajvards;
        private System.Windows.Forms.TextBox jauna_parole1;
        private System.Windows.Forms.TextBox jauna_parole2;
        private System.Windows.Forms.Button paroles_maina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}