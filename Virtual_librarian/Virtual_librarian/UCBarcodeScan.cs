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

namespace Virtual_librarian
{
    public partial class UCBarcodeScan : UserControl
    {
        String BarcodeLocation; // String nurodantis failo vietą
        Image File;             // Kintamasis kuris saugo paveikslėlį   :    vėliau nebereikės kai bus pritaikytas skenavimas kamera
        public UCBarcodeScan()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)     // Mygtuko Skenuoti paspaudimo event
        {
            OpenFileDialog open = new OpenFileDialog();           // Atidaro dialog langa atsidaryti nuotrauką iš kompiuterio failų
            open.Filter = "JPG(*.JPG|*.jpg";                      // Folderiuose filtruoja JPG failus

            if (open.ShowDialog() == DialogResult.OK)           //Event jei mygtukas OK dialog lange buvo paspaustas
            {
                textBox1.Clear();
                File = Image.FromFile(open.FileName);
                pictureBox1.Image = File;
                BarcodeLocation = open.FileName;
                String[] Barcode = BarcodeScanner.Scan(BarcodeLocation);
                if (Barcode.Length != 0)
                    textBox1.AppendText(Barcode[0]);
                else
                    MessageBox.Show("Nepavyko aptikti barkodo");
                
            }
        }

        private void UCBarcodeScan_Load(object sender, EventArgs e)
        {

        }
    }
}
