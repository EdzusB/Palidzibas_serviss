
namespace Palidzibas_serviss
{
    partial class Form1
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
            this.nosutit = new System.Windows.Forms.Button();
            this.zina = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.atbilde = new System.Windows.Forms.TextBox();
            this.tabula = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nosutit
            // 
            this.nosutit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nosutit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.nosutit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(239)))), ((int)(((byte)(209)))));
            this.nosutit.Location = new System.Drawing.Point(315, 305);
            this.nosutit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nosutit.Name = "nosutit";
            this.nosutit.Size = new System.Drawing.Size(143, 70);
            this.nosutit.TabIndex = 0;
            this.nosutit.Text = "Nosūtīt";
            this.nosutit.UseVisualStyleBackColor = true;
            this.nosutit.Click += new System.EventHandler(this.button1_Click);
            // 
            // zina
            // 
            this.zina.BackColor = System.Drawing.Color.White;
            this.zina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zina.Location = new System.Drawing.Point(393, 202);
            this.zina.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.zina.Name = "zina";
            this.zina.Size = new System.Drawing.Size(375, 22);
            this.zina.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(239)))), ((int)(((byte)(209)))));
            this.label1.Location = new System.Drawing.Point(40, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Jūsu problēma vai informācija...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(239)))), ((int)(((byte)(209)))));
            this.label2.Location = new System.Drawing.Point(195, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(381, 40);
            this.label2.TabIndex = 3;
            this.label2.Text = "Informācijas centrs";
            // 
            // atbilde
            // 
            this.atbilde.Location = new System.Drawing.Point(393, 256);
            this.atbilde.Margin = new System.Windows.Forms.Padding(4);
            this.atbilde.Name = "atbilde";
            this.atbilde.Size = new System.Drawing.Size(375, 22);
            this.atbilde.TabIndex = 4;
            // 
            // tabula
            // 
            this.tabula.Location = new System.Drawing.Point(583, 351);
            this.tabula.Name = "tabula";
            this.tabula.Size = new System.Drawing.Size(75, 23);
            this.tabula.TabIndex = 5;
            this.tabula.Text = "Tālāk";
            this.tabula.UseVisualStyleBackColor = true;
            this.tabula.Click += new System.EventHandler(this.tabula_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(803, 453);
            this.Controls.Add(this.tabula);
            this.Controls.Add(this.atbilde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zina);
            this.Controls.Add(this.nosutit);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Klientu apkalpošana";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nosutit;
        private System.Windows.Forms.TextBox zina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox atbilde;
        private System.Windows.Forms.Button tabula;
    }
}

