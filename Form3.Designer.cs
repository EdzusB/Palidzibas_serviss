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
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pieteikties
            // 
            this.pieteikties.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(95)))), ((int)(((byte)(45)))));
            this.pieteikties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pieteikties.Font = new System.Drawing.Font("Gabriola", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.pieteikties.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(188)))), ((int)(((byte)(98)))));
            this.pieteikties.Location = new System.Drawing.Point(69, 203);
            this.pieteikties.Name = "pieteikties";
            this.pieteikties.Size = new System.Drawing.Size(188, 33);
            this.pieteikties.TabIndex = 0;
            this.pieteikties.Text = "Pieteikties kā lietotājs";
            this.pieteikties.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.pieteikties.UseVisualStyleBackColor = true;
            this.pieteikties.Click += new System.EventHandler(this.pieteikties_Click);
            // 
            // Parole
            // 
            this.Parole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(188)))), ((int)(((byte)(98)))));
            this.Parole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Parole.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Parole.Location = new System.Drawing.Point(262, 120);
            this.Parole.Name = "Parole";
            this.Parole.Size = new System.Drawing.Size(100, 24);
            this.Parole.TabIndex = 1;
            this.Parole.UseSystemPasswordChar = true;
            // 
            // Lietotajvards
            // 
            this.Lietotajvards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(188)))), ((int)(((byte)(98)))));
            this.Lietotajvards.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lietotajvards.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Lietotajvards.Location = new System.Drawing.Point(262, 69);
            this.Lietotajvards.Name = "Lietotajvards";
            this.Lietotajvards.Size = new System.Drawing.Size(100, 24);
            this.Lietotajvards.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gabriola", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(188)))), ((int)(((byte)(98)))));
            this.label1.Location = new System.Drawing.Point(163, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "Vai jums vēl nav konta?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gabriola", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(188)))), ((int)(((byte)(98)))));
            this.label2.Location = new System.Drawing.Point(110, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 40);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lietotājvārds";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gabriola", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(188)))), ((int)(((byte)(98)))));
            this.label3.Location = new System.Drawing.Point(158, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 40);
            this.label3.TabIndex = 5;
            this.label3.Text = "Parole";
            // 
            // admin
            // 
            this.admin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.admin.Font = new System.Drawing.Font("Gabriola", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.admin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(188)))), ((int)(((byte)(98)))));
            this.admin.Location = new System.Drawing.Point(262, 203);
            this.admin.Margin = new System.Windows.Forms.Padding(2);
            this.admin.Name = "admin";
            this.admin.Size = new System.Drawing.Size(188, 33);
            this.admin.TabIndex = 6;
            this.admin.Text = "Pieteikties kā pārvaldnieks";
            this.admin.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.admin.UseVisualStyleBackColor = true;
            this.admin.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(188)))), ((int)(((byte)(98)))));
            this.label4.Location = new System.Drawing.Point(195, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 35);
            this.label4.TabIndex = 7;
            this.label4.Text = "Aizmirsi paroli?";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(95)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(512, 327);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.admin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lietotajvards);
            this.Controls.Add(this.Parole);
            this.Controls.Add(this.pieteikties);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ielogošanās";
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
        private System.Windows.Forms.Label label4;
    }
}