
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
            ((System.ComponentModel.ISupportInitialize)(this.dzesanas_tabula)).BeginInit();
            this.SuspendLayout();
            // 
            // dzesanas_izvele
            // 
            this.dzesanas_izvele.FormattingEnabled = true;
            this.dzesanas_izvele.Items.AddRange(new object[] {
            "Lietotājs",
            "Ziņa"});
            this.dzesanas_izvele.Location = new System.Drawing.Point(327, 46);
            this.dzesanas_izvele.Name = "dzesanas_izvele";
            this.dzesanas_izvele.Size = new System.Drawing.Size(121, 24);
            this.dzesanas_izvele.TabIndex = 0;
            this.dzesanas_izvele.SelectedIndexChanged += new System.EventHandler(this.dzesanas_izvele_SelectedIndexChanged);
            // 
            // dzesanas_tabula
            // 
            this.dzesanas_tabula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dzesanas_tabula.Location = new System.Drawing.Point(12, 101);
            this.dzesanas_tabula.Name = "dzesanas_tabula";
            this.dzesanas_tabula.RowHeadersWidth = 51;
            this.dzesanas_tabula.RowTemplate.Height = 24;
            this.dzesanas_tabula.Size = new System.Drawing.Size(776, 242);
            this.dzesanas_tabula.TabIndex = 1;
            // 
            // id_numurs
            // 
            this.id_numurs.Location = new System.Drawing.Point(327, 364);
            this.id_numurs.Name = "id_numurs";
            this.id_numurs.Size = new System.Drawing.Size(100, 22);
            this.id_numurs.TabIndex = 2;
            // 
            // dzesana
            // 
            this.dzesana.Location = new System.Drawing.Point(338, 392);
            this.dzesana.Name = "dzesana";
            this.dzesana.Size = new System.Drawing.Size(75, 23);
            this.dzesana.TabIndex = 3;
            this.dzesana.Text = "Dzēst";
            this.dzesana.UseVisualStyleBackColor = true;
            this.dzesana.Click += new System.EventHandler(this.dzesana_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dzesana);
            this.Controls.Add(this.id_numurs);
            this.Controls.Add(this.dzesanas_tabula);
            this.Controls.Add(this.dzesanas_izvele);
            this.Name = "Form5";
            this.Text = "Form5";
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
    }
}