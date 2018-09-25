namespace Virtual_librarian
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
            this.btnFace = new System.Windows.Forms.Button();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFace
            // 
            this.btnFace.Location = new System.Drawing.Point(148, 710);
            this.btnFace.Name = "btnFace";
            this.btnFace.Size = new System.Drawing.Size(365, 77);
            this.btnFace.TabIndex = 1;
            this.btnFace.Text = "Veido skenavimas";
            this.btnFace.UseVisualStyleBackColor = true;
            this.btnFace.Click += new System.EventHandler(this.btnFace_Click);
            // 
            // btnBarcode
            // 
            this.btnBarcode.Location = new System.Drawing.Point(675, 710);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(365, 77);
            this.btnBarcode.TabIndex = 2;
            this.btnBarcode.Text = "Barkodo skenavimas";
            this.btnBarcode.UseVisualStyleBackColor = true;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 821);
            this.Controls.Add(this.btnBarcode);
            this.Controls.Add(this.btnFace);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnFace;
        private System.Windows.Forms.Button btnBarcode;
    }
}

