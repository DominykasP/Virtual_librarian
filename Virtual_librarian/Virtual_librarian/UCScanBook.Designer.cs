namespace Virtual_librarian
{
    partial class UCScanBook
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
            this.components = new System.ComponentModel.Container();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BarcodeBox1 = new MetroFramework.Controls.MetroTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(103, 43);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(117, 20);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Skanuokite knygą";
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(46, 225);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(166, 62);
            this.metroTile1.TabIndex = 1;
            this.metroTile1.Text = "Skenuoti Barkodą";
            this.metroTile1.UseSelectable = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::Virtual_librarian.Properties.Resources.icons8_barcode_64;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(46, 43);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DodgerBlue;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(354, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(472, 276);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BarcodeBox1
            // 
            // 
            // 
            // 
            this.BarcodeBox1.CustomButton.Image = null;
            this.BarcodeBox1.CustomButton.Location = new System.Drawing.Point(243, 1);
            this.BarcodeBox1.CustomButton.Name = "";
            this.BarcodeBox1.CustomButton.Size = new System.Drawing.Size(47, 47);
            this.BarcodeBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.BarcodeBox1.CustomButton.TabIndex = 1;
            this.BarcodeBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.BarcodeBox1.CustomButton.UseSelectable = true;
            this.BarcodeBox1.CustomButton.Visible = false;
            this.BarcodeBox1.Enabled = false;
            this.BarcodeBox1.Lines = new string[0];
            this.BarcodeBox1.Location = new System.Drawing.Point(46, 170);
            this.BarcodeBox1.MaxLength = 32767;
            this.BarcodeBox1.Name = "BarcodeBox1";
            this.BarcodeBox1.PasswordChar = '\0';
            this.BarcodeBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.BarcodeBox1.SelectedText = "";
            this.BarcodeBox1.SelectionLength = 0;
            this.BarcodeBox1.SelectionStart = 0;
            this.BarcodeBox1.ShortcutsEnabled = true;
            this.BarcodeBox1.Size = new System.Drawing.Size(291, 49);
            this.BarcodeBox1.TabIndex = 4;
            this.BarcodeBox1.UseSelectable = true;
            this.BarcodeBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.BarcodeBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // UCScanBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BarcodeBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.metroLabel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UCScanBook";
            this.Size = new System.Drawing.Size(867, 308);
            this.Load += new System.EventHandler(this.UCScanBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTile metroTile1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private MetroFramework.Controls.MetroTextBox BarcodeBox1;
    }
}
