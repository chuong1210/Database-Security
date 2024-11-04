namespace QLSInhVien.GUI
{
    partial class frmtest
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
            this.txtplain = new System.Windows.Forms.TextBox();
            this.txtencrypt = new System.Windows.Forms.TextBox();
            this.txtdecrypt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtplain
            // 
            this.txtplain.Location = new System.Drawing.Point(284, 118);
            this.txtplain.Name = "txtplain";
            this.txtplain.Size = new System.Drawing.Size(381, 22);
            this.txtplain.TabIndex = 0;
            // 
            // txtencrypt
            // 
            this.txtencrypt.Location = new System.Drawing.Point(284, 231);
            this.txtencrypt.Name = "txtencrypt";
            this.txtencrypt.Size = new System.Drawing.Size(381, 22);
            this.txtencrypt.TabIndex = 1;
            // 
            // txtdecrypt
            // 
            this.txtdecrypt.Location = new System.Drawing.Point(284, 320);
            this.txtdecrypt.Name = "txtdecrypt";
            this.txtdecrypt.Size = new System.Drawing.Size(381, 22);
            this.txtdecrypt.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(142, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "encrypt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(128, 231);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "decrypt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmtest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtdecrypt);
            this.Controls.Add(this.txtencrypt);
            this.Controls.Add(this.txtplain);
            this.Name = "frmtest";
            this.Text = "frmtest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtplain;
        private System.Windows.Forms.TextBox txtencrypt;
        private System.Windows.Forms.TextBox txtdecrypt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}