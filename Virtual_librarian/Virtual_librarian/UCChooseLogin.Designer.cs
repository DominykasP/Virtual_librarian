namespace Virtual_librarian
{
    partial class UCChooseLogin
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRegistruotis = new MetroFramework.Controls.MetroTile();
            this.btnPrisijungti = new MetroFramework.Controls.MetroTile();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRegistruotis
            // 
            this.btnRegistruotis.ActiveControl = null;
            this.btnRegistruotis.Location = new System.Drawing.Point(51, 162);
            this.btnRegistruotis.Name = "btnRegistruotis";
            this.btnRegistruotis.Size = new System.Drawing.Size(237, 102);
            this.btnRegistruotis.TabIndex = 1;
            this.btnRegistruotis.Text = "Registruotis";
            this.btnRegistruotis.UseSelectable = true;
            // 
            // btnPrisijungti
            // 
            this.btnPrisijungti.ActiveControl = null;
            this.btnPrisijungti.Location = new System.Drawing.Point(51, 54);
            this.btnPrisijungti.Name = "btnPrisijungti";
            this.btnPrisijungti.Size = new System.Drawing.Size(237, 102);
            this.btnPrisijungti.TabIndex = 1;
            this.btnPrisijungti.Text = "Prisijungti";
            this.btnPrisijungti.UseSelectable = true;
            this.btnPrisijungti.Click += new System.EventHandler(this.btnPrisijungti_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Virtual_librarian.Properties.Resources.vu_logo;
            this.pictureBox1.Location = new System.Drawing.Point(407, 64);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 215);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // UCChooseLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPrisijungti);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRegistruotis);
            this.Name = "UCChooseLogin";
            this.Size = new System.Drawing.Size(683, 345);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile btnRegistruotis;
        private MetroFramework.Controls.MetroTile btnPrisijungti;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
