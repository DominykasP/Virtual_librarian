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
            this.cameraBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BarcodeBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraBox)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(67, 35);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(183, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Nuskanuokite knygos barkodą";
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(24, 67);
            this.metroTile1.Margin = new System.Windows.Forms.Padding(2);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(226, 41);
            this.metroTile1.TabIndex = 1;
            this.metroTile1.Text = "Įjungti kamerą";
            this.metroTile1.UseSelectable = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::Virtual_librarian.Properties.Resources.icons8_barcode_64;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(24, 35);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // cameraBox
            // 
            this.cameraBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cameraBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cameraBox.Location = new System.Drawing.Point(291, 35);
            this.cameraBox.Margin = new System.Windows.Forms.Padding(2);
            this.cameraBox.Name = "cameraBox";
            this.cameraBox.Size = new System.Drawing.Size(342, 197);
            this.cameraBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cameraBox.TabIndex = 2;
            this.cameraBox.TabStop = false;
            // 
            // BarcodeBox1
            // 
            // 
            // 
            // 
            this.BarcodeBox1.CustomButton.Image = null;
            this.BarcodeBox1.CustomButton.Location = new System.Drawing.Point(188, 2);
            this.BarcodeBox1.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.BarcodeBox1.CustomButton.Name = "";
            this.BarcodeBox1.CustomButton.Size = new System.Drawing.Size(35, 35);
            this.BarcodeBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.BarcodeBox1.CustomButton.TabIndex = 1;
            this.BarcodeBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.BarcodeBox1.CustomButton.UseSelectable = true;
            this.BarcodeBox1.CustomButton.Visible = false;
            this.BarcodeBox1.Enabled = false;
            this.BarcodeBox1.Lines = new string[0];
            this.BarcodeBox1.Location = new System.Drawing.Point(24, 192);
            this.BarcodeBox1.Margin = new System.Windows.Forms.Padding(2);
            this.BarcodeBox1.MaxLength = 32767;
            this.BarcodeBox1.Name = "BarcodeBox1";
            this.BarcodeBox1.PasswordChar = '\0';
            this.BarcodeBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.BarcodeBox1.SelectedText = "";
            this.BarcodeBox1.SelectionLength = 0;
            this.BarcodeBox1.SelectionStart = 0;
            this.BarcodeBox1.ShortcutsEnabled = true;
            this.BarcodeBox1.Size = new System.Drawing.Size(226, 40);
            this.BarcodeBox1.TabIndex = 4;
            this.BarcodeBox1.UseSelectable = true;
            this.BarcodeBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.BarcodeBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(24, 165);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(127, 19);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Atpažintas barkodas";
            // 
            // UCScanBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.BarcodeBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.cameraBox);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.metroLabel1);
            this.Name = "UCScanBook";
            this.Size = new System.Drawing.Size(650, 258);
            this.Load += new System.EventHandler(this.UCScanBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTile metroTile1;
        private System.Windows.Forms.PictureBox cameraBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private MetroFramework.Controls.MetroTextBox BarcodeBox1;
        public System.Windows.Forms.Timer timer1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
    }
}
