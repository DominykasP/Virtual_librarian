using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using Spire.Barcode;

namespace Virtual_librarian
{
    public partial class UCScanBook : MetroFramework.Controls.MetroUserControl
    {
        private static int nEventsFired = 0;
        private VideoCapture capture;
        private object lockobject = new object();
        public List<Bitmap> images;

        Mat m;
        public UCScanBook()
        {
            InitializeComponent();
        }

        private void UCScanBook_Load(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (capture == null)
            {
                capture = new VideoCapture(0);

            }
            images = new List<Bitmap>();
            nEventsFired = 0;
            timer1.Interval = 2000;
            timer1.Start();
            capture.ImageGrabbed += Capture_ImageGrabbed1;
            capture.Start();
        }
        private void Capture_ImageGrabbed1(object sender, EventArgs e)
        {
            try
            {

                m = new Mat();
                capture.Retrieve(m);
                pictureBox1.Image = m.ToImage<Bgr, byte>().Bitmap;
            }
            catch (Exception)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BarcodeBox1.Clear();
            //textBox1.Clear();
            capture.Retrieve(m);
            Image<Bgr, Byte> ColordImage = m.ToImage<Bgr, byte>();
            Image<Gray, Byte> grayImage = ColordImage.Convert<Gray, Byte>();
            

            String[] Barcode = BarcodeScanner.Scan(grayImage.ToBitmap());

            if (Barcode.Length != 0 && Barcode[0].Length > 10)
            {
                timer1.Stop();
                capture.Pause();
                BarcodeBox1.AppendText(Barcode[0]);

            }



            nEventsFired++;
            if (nEventsFired == 20)
            {
                timer1.Stop();
                if (capture != null)
                {
                    capture.Dispose();
                    capture = null;
                    m = null;
                }
            }
        }
    }
}
