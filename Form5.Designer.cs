
namespace Palidzibas_serviss
{
    partial class Form5
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
            this.dzesanas_izvele = new System.Windows.Forms.ComboBox();
            this.dzesanas_tabula = new System.Windows.Forms.DataGridView();
            this.id_numurs = new System.Windows.Forms.TextBox();
            this.dzesana = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dzesanas_tabula)).BeginInit();
            this.SuspendLayout();
            // 
            // dzesanas_izvele
            // 
            this.dzesanas_izvele.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(188)))), ((int)(((byte)(98)))));
            this.dzesanas_izvele.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.dzesanas_izvele.FormattingEnabled = true;
            this.dzesanas_izvele.Items.AddRange(new object[] {
            "Lietotājs",
            "Ziņa"});
            this.dzesanas_izvele.Location = new System.Drawing.Point(329, 64);
            this.dzesanas_izvele.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dzesanas_izvele.Name = "dzesanas_izvele";
            this.dzesanas_izvele.Size = new System.Drawing.Size(148, 32);
            this.dzesanas_izvele.TabIndex = 0;
            this.dzesanas_izvele.SelectedIndexChanged += new System.EventHandler(this.dzesanas_izvele_SelectedIndexChanged);
            // 
            // dzesanas_tabula
            // 
            this.dzesanas_tabula.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(188)))), ((int)(((byte)(98)))));
            this.dzesanas_tabula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dzesanas_tabula.Location = new System.Drawing.Point(12, 101);
            this.dzesanas_tabula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dzesanas_tabula.Name = "dzesanas_tabula";
            this.dzesanas_tabula.RowHeadersWidth = 51;
            this.dzesanas_tabula.RowTemplate.Height = 24;
            this.dzesanas_tabula.Size = new System.Drawing.Size(776, 242);
            this.dzesanas_tabula.TabIndex = 1;
            // 
            // id_numurs
            // 
            this.id_numurs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(188)))), ((int)(((byte)(98)))));
            this.id_numurs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_numurs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.id_numurs.Location = new System.Drawing.Point(352, 348);
            this.id_numurs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.id_numurs.Name = "id_numurs";
            this.id_numurs.Size = new System.Drawing.Size(101, 29);
            this.id_numurs.TabIndex = 2;
            this.id_numurs.TextChanged += new System.EventHandler(this.id_numurs_TextChanged);
            // 
            // dzesana
            // 
            this.dzesana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dzesana.Font = new System.Drawing.Font("Gabriola", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.dzesana.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(188)))), ((int)(((byte)(98)))));
            this.dzesana.Location = new System.Drawing.Point(352, 384);
            this.dzesana.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dzesana.Name = "dzesana";
            this.dzesana.Size = new System.Drawing.Size(101, 53);
            this.dzesana.TabIndex = 3;
            this.dzesana.Text = "Dzēst";
            this.dzesana.UseVisualStyleBackColor = true;
            this.dzesana.Click += new System.EventHandler(this.dzesana_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Gabriola", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(188)))), ((int)(((byte)(98)))));
            this.button1.Location = new System.Drawing.Point(650, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 52);
            this.button1.TabIndex = 4;
            this.button1.Text = "Atgriezties";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(95)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dzesana);
            this.Controls.Add(this.id_numurs);
            this.Controls.Add(this.dzesanas_tabula);
            this.Controls.Add(this.dzesanas_izvele);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datu pārvalde";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dzesanas_tabula)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox dzesanas_izvele;
        private System.Windows.Forms.DataGridView dzesanas_tabula;
        private System.Windows.Forms.TextBox id_numurs;
        private System.Windows.Forms.Button dzesana;
        private System.Windows.Forms.Button button1;
    }
}