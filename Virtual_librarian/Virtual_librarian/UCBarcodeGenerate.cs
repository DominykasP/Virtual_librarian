using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Barcode;
using Spire.Barcode.Forms;

namespace Virtual_librarian
{
    public partial class UCBarcodeGenerate : UserControl
    {
        String barcodeCombination;
        string barcodePicName;
        int BarcodePicIndex = 0;
        BarCodeControl BarcodePicture = new BarCodeControl("12569852");
        Image barcode;

        public UCBarcodeGenerate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            barcode = BarcodePicture.GenerateImage();

            //save the barcode as an image
            pictureBox1.Image = barcode;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            barcodeCombination = textBox1.Text;
            BarcodePicture = new BarCodeControl(barcodeCombination);
        }
    }
}
