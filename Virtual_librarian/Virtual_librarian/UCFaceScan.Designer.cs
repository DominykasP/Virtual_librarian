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
            this.label1.Location = new System.Drawing.Point(375, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Veido atpažinimas";
            // 
            // picWebCam
            // 
            this.picWebCam.Location = new System.Drawing.Point(198, 79);
            this.picWebCam.Name = "picWebCam";
            this.picWebCam.Size = new System.Drawing.Size(768, 432);
            this.picWebCam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWebCam.TabIndex = 1;
            this.picWebCam.TabStop = false;
            // 
            // pbarScanning
            // 
            this.pbarScanning.Location = new System.Drawing.Point(198, 517);
            this.pbarScanning.Name = "pbarScanning";
            this.pbarScanning.Size = new System.Drawing.Size(768, 63);
            this.pbarScanning.Step = 1;
            this.pbarScanning.TabIndex = 2;
            // 
            // UCFaceScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbarScanning);
            this.Controls.Add(this.picWebCam);
            this.Controls.Add(this.label1);
            this.Name = "UCFaceScan";
            this.Size = new System.Drawing.Size(1168, 691);
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
