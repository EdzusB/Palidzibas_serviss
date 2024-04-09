namespace Palidzibas_serviss
{
    partial class Form2
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
            this.registreties = new System.Windows.Forms.Button();
            this.Vards = new System.Windows.Forms.TextBox();
            this.Uzvards = new System.Windows.Forms.TextBox();
            this.Epasts = new System.Windows.Forms.TextBox();
            this.numurs = new System.Windows.Forms.TextBox();
            this.lietotajvards = new System.Windows.Forms.TextBox();
            this.parole = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // registreties
            // 
            this.registreties.Location = new System.Drawing.Point(354, 319);
            this.registreties.Name = "registreties";
            this.registreties.Size = new System.Drawing.Size(75, 23);
            this.registreties.TabIndex = 0;
            this.registreties.Text = "Reģistrēties";
            this.registreties.UseVisualStyleBackColor = true;
            this.registreties.Click += new System.EventHandler(this.registreties_Click);
            // 
            // Vards
            // 
            this.Vards.Location = new System.Drawing.Point(216, 81);
            this.Vards.Name = "Vards";
            this.Vards.Size = new System.Drawing.Size(100, 20);
            this.Vards.TabIndex = 1;
            // 
            // Uzvards
            // 
            this.Uzvards.Location = new System.Drawing.Point(216, 116);
            this.Uzvards.Name = "Uzvards";
            this.Uzvards.Size = new System.Drawing.Size(100, 20);
            this.Uzvards.TabIndex = 2;
            // 
            // Epasts
            // 
            this.Epasts.Location = new System.Drawing.Point(216, 159);
            this.Epasts.Name = "Epasts";
            this.Epasts.Size = new System.Drawing.Size(100, 20);
            this.Epasts.TabIndex = 3;
            // 
            // numurs
            // 
            this.numurs.Location = new System.Drawing.Point(470, 84);
            this.numurs.Name = "numurs";
            this.numurs.Size = new System.Drawing.Size(100, 20);
            this.numurs.TabIndex = 4;
            // 
            // lietotajvards
            // 
            this.lietotajvards.Location = new System.Drawing.Point(470, 110);
            this.lietotajvards.Name = "lietotajvards";
            this.lietotajvards.Size = new System.Drawing.Size(100, 20);
            this.lietotajvards.TabIndex = 5;
            // 
            // parole
            // 
            this.parole.Location = new System.Drawing.Point(470, 136);
            this.parole.Name = "parole";
            this.parole.Size = new System.Drawing.Size(100, 20);
            this.parole.TabIndex = 6;
            this.parole.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Vārds";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Uzvārds";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "E-pasts";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Telefona numurs";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(378, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Lietotājvārds";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(378, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Parole";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.parole);
            this.Controls.Add(this.lietotajvards);
            this.Controls.Add(this.numurs);
            this.Controls.Add(this.Epasts);
            this.Controls.Add(this.Uzvards);
            this.Controls.Add(this.Vards);
            this.Controls.Add(this.registreties);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button registreties;
        private System.Windows.Forms.TextBox Vards;
        private System.Windows.Forms.TextBox Uzvards;
        private System.Windows.Forms.TextBox Epasts;
        private System.Windows.Forms.TextBox numurs;
        private System.Windows.Forms.TextBox lietotajvards;
        private System.Windows.Forms.TextBox parole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}