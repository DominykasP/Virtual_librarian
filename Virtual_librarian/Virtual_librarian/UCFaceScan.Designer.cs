namespace Virtual_librarian
{
    partial class UCFaceScan
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
            this.label1 = new System.Windows.Forms.Label();
            this.picWebCam = new System.Windows.Forms.PictureBox();
            this.pbarScanning = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.picWebCam)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.Location = new System.Drawing.Point(141, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Veido atpažinimas";
            // 
            // picWebCam
            // 
            this.picWebCam.Location = new System.Drawing.Point(74, 33);
            this.picWebCam.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.picWebCam.Name = "picWebCam";
            this.picWebCam.Size = new System.Drawing.Size(288, 181);
            this.picWebCam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWebCam.TabIndex = 1;
            this.picWebCam.TabStop = false;
            // 
            // pbarScanning
            // 
            this.pbarScanning.Location = new System.Drawing.Point(74, 217);
            this.pbarScanning.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.pbarScanning.Name = "pbarScanning";
            this.pbarScanning.Size = new System.Drawing.Size(288, 26);
            this.pbarScanning.Step = 1;
            this.pbarScanning.TabIndex = 2;
            // 
            // UCFaceScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbarScanning);
            this.Controls.Add(this.picWebCam);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "UCFaceScan";
            this.Size = new System.Drawing.Size(438, 290);
            this.Load += new System.EventHandler(this.UCFaceScan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picWebCam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picWebCam;
        private System.Windows.Forms.ProgressBar pbarScanning;
    }
}
