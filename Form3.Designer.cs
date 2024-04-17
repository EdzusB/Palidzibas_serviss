namespace Palidzibas_serviss
{
    partial class Form3
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
            this.pieteikties = new System.Windows.Forms.Button();
            this.Parole = new System.Windows.Forms.TextBox();
            this.Lietotajvards = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.admin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pieteikties
            // 
            this.pieteikties.Location = new System.Drawing.Point(332, 284);
            this.pieteikties.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pieteikties.Name = "pieteikties";
            this.pieteikties.Size = new System.Drawing.Size(206, 28);
            this.pieteikties.TabIndex = 0;
            this.pieteikties.Text = "Pieteikties kā lietotājs";
            this.pieteikties.UseVisualStyleBackColor = true;
            this.pieteikties.Click += new System.EventHandler(this.pieteikties_Click);
            // 
            // Parole
            // 
            this.Parole.Location = new System.Drawing.Point(507, 210);
            this.Parole.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Parole.Name = "Parole";
            this.Parole.Size = new System.Drawing.Size(132, 22);
            this.Parole.TabIndex = 1;
            this.Parole.UseSystemPasswordChar = true;
            // 
            // Lietotajvards
            // 
            this.Lietotajvards.Location = new System.Drawing.Point(507, 167);
            this.Lietotajvards.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Lietotajvards.Name = "Lietotajvards";
            this.Lietotajvards.Size = new System.Drawing.Size(132, 22);
            this.Lietotajvards.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(466, 362);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Vai jums vēl nav konta?";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 175);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lietotājvārds";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(381, 219);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Parole";
            // 
            // admin
            // 
            this.admin.Location = new System.Drawing.Point(545, 284);
            this.admin.Name = "admin";
            this.admin.Size = new System.Drawing.Size(206, 28);
            this.admin.TabIndex = 6;
            this.admin.Text = "Pieteikties kā pārvaldnieks";
            this.admin.UseVisualStyleBackColor = true;
            this.admin.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.admin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lietotajvards);
            this.Controls.Add(this.Parole);
            this.Controls.Add(this.pieteikties);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pieteikties;
        private System.Windows.Forms.TextBox Parole;
        private System.Windows.Forms.TextBox Lietotajvards;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button admin;
    }
}