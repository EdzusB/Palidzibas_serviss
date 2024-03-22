
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
            this.SuspendLayout();
            // 
            // nosutit
            // 
            this.nosutit.Location = new System.Drawing.Point(359, 234);
            this.nosutit.Name = "nosutit";
            this.nosutit.Size = new System.Drawing.Size(75, 23);
            this.nosutit.TabIndex = 0;
            this.nosutit.Text = "Nosūtīt";
            this.nosutit.UseVisualStyleBackColor = true;
            this.nosutit.Click += new System.EventHandler(this.button1_Click);
            // 
            // zina
            // 
            this.zina.Location = new System.Drawing.Point(344, 149);
            this.zina.Name = "zina";
            this.zina.Size = new System.Drawing.Size(100, 22);
            this.zina.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.zina);
            this.Controls.Add(this.nosutit);
            this.Name = "Form1";
            this.Text = "Klientu apkalpošana";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nosutit;
        private System.Windows.Forms.TextBox zina;
    }
}

