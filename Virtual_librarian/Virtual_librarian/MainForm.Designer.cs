namespace Virtual_librarian
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.btnPrisijungti = new MetroFramework.Controls.MetroTile();
            this.btnRegistruotis = new MetroFramework.Controls.MetroTile();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlChooseLogin = new MetroFramework.Controls.MetroPanel();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlChooseLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // btnPrisijungti
            // 
            this.btnPrisijungti.ActiveControl = null;
            this.btnPrisijungti.Location = new System.Drawing.Point(87, 44);
            this.btnPrisijungti.Name = "btnPrisijungti";
            this.btnPrisijungti.Size = new System.Drawing.Size(237, 102);
            this.btnPrisijungti.TabIndex = 1;
            this.btnPrisijungti.Text = "Prisijungti";
            this.btnPrisijungti.UseSelectable = true;
            this.btnPrisijungti.Click += new System.EventHandler(this.btnPrisijungti_Click);
            // 
            // btnRegistruotis
            // 
            this.btnRegistruotis.ActiveControl = null;
            this.btnRegistruotis.Location = new System.Drawing.Point(87, 152);
            this.btnRegistruotis.Name = "btnRegistruotis";
            this.btnRegistruotis.Size = new System.Drawing.Size(237, 102);
            this.btnRegistruotis.TabIndex = 1;
            this.btnRegistruotis.Text = "Registruotis";
            this.btnRegistruotis.UseSelectable = true;
            this.btnRegistruotis.Click += new System.EventHandler(this.btnRegistruotis_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Virtual_librarian.Properties.Resources.vu_logo;
            this.pictureBox1.Location = new System.Drawing.Point(443, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 215);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.Location = new System.Drawing.Point(11, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "Vilniaus Universiteto biblioteka";
            // 
            // pnlChooseLogin
            // 
            this.pnlChooseLogin.Controls.Add(this.pictureBox1);
            this.pnlChooseLogin.Controls.Add(this.btnPrisijungti);
            this.pnlChooseLogin.Controls.Add(this.btnRegistruotis);
            this.pnlChooseLogin.HorizontalScrollbarBarColor = true;
            this.pnlChooseLogin.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlChooseLogin.HorizontalScrollbarSize = 10;
            this.pnlChooseLogin.Location = new System.Drawing.Point(11, 63);
            this.pnlChooseLogin.Name = "pnlChooseLogin";
            this.pnlChooseLogin.Size = new System.Drawing.Size(683, 311);
            this.pnlChooseLogin.TabIndex = 4;
            this.pnlChooseLogin.VerticalScrollbarBarColor = true;
            this.pnlChooseLogin.VerticalScrollbarHighlightOnWheel = false;
            this.pnlChooseLogin.VerticalScrollbarSize = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 420);
            this.Controls.Add(this.pnlChooseLogin);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(8, 60, 8, 8);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlChooseLogin.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTile btnRegistruotis;
        private MetroFramework.Controls.MetroTile btnPrisijungti;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroPanel pnlChooseLogin;
    }
}