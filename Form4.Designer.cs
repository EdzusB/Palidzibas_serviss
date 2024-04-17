
namespace Palidzibas_serviss
{
    partial class Form4
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
            this.button1 = new System.Windows.Forms.Button();
            this.zinu_tabula = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.zinu_tabula)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(315, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Parādīt ziņas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // zinu_tabula
            // 
            this.zinu_tabula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.zinu_tabula.Location = new System.Drawing.Point(13, 59);
            this.zinu_tabula.Name = "zinu_tabula";
            this.zinu_tabula.RowHeadersWidth = 51;
            this.zinu_tabula.RowTemplate.Height = 24;
            this.zinu_tabula.Size = new System.Drawing.Size(775, 159);
            this.zinu_tabula.TabIndex = 1;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.zinu_tabula);
            this.Controls.Add(this.button1);
            this.Name = "Form4";
            this.Text = "paradit";
            ((System.ComponentModel.ISupportInitialize)(this.zinu_tabula)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView zinu_tabula;
    }
}