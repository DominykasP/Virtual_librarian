using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Virtual_librarian
{
    public partial class Form1 : Form
    {
        private UCFaceScan faceScanControl;
        private UCBarcodeScan barcodeScanControl;
        private UCBarcodeGenerate barcodeGenerateControl;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnFace_Click(object sender, EventArgs e)
        {
            if(this.Controls.Contains(barcodeScanControl))
            {
                this.Controls.Remove(barcodeScanControl);
            }

                if (this.Controls.Contains(barcodeGenerateControl))
                {
                    this.Controls.Remove(barcodeScanControl);
                }

            faceScanControl = new UCFaceScan();
            this.Controls.Add(faceScanControl);
        }

        private void btnBarcodeScan_Click(object sender, EventArgs e)
        {
            if (this.Controls.Contains(faceScanControl))
            {
                faceScanControl.tmrForVideo.Stop();
                faceScanControl.tmrForCapure.Stop();
                faceScanControl.capture.Stop();
                faceScanControl.capture.Dispose();
                faceScanControl.images.Clear();
                this.Controls.Remove(faceScanControl);
            }

                if (this.Controls.Contains(barcodeGenerateControl))
                {
                    this.Controls.Remove(barcodeScanControl);
                }

            barcodeScanControl = new UCBarcodeScan();
            this.Controls.Add(barcodeScanControl);
        }

        private void btnBarcodeGen_Click(object sender, EventArgs e)
        {
            if (this.Controls.Contains(faceScanControl))
            {
                faceScanControl.tmrForVideo.Stop();
                faceScanControl.tmrForCapure.Stop();
                faceScanControl.capture.Stop();
                faceScanControl.capture.Dispose();
                faceScanControl.images.Clear();
                this.Controls.Remove(faceScanControl);
            }

                if (this.Controls.Contains(barcodeScanControl))
                {
                    this.Controls.Remove(barcodeScanControl);
                }
           
            barcodeGenerateControl = new UCBarcodeGenerate();
            
            this.Controls.Add(barcodeGenerateControl);
            
        }
    }
}
