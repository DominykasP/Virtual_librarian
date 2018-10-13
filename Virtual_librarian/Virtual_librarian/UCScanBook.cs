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
        public Capture camera;
        private object lockobject = new object();
        public List<Bitmap> images;
        Image<Bgr, byte> Frame;


        public UCScanBook()
        {
            InitializeComponent();
        }

        private void UCScanBook_Load(object sender, EventArgs e)
        {

        }

        public void metroTile1_Click(object sender, EventArgs e)
        {
            if(camera != null)
            {
                Application.Idle -= new EventHandler(FrameProcedure);
            }
            if (camera == null)
            {
                camera = new Capture(0);

            }
            images = new List<Bitmap>();
            nEventsFired = 0;
            timer1.Interval = 2000;
            timer1.Start();
            camera.Start();
            
            Application.Idle += new EventHandler(FrameProcedure);
        }
        private void FrameProcedure(object sender, EventArgs e)
        {
            try
            {

                Frame = camera.QueryFrame();
                cameraBox.Image = Frame.ToBitmap();
            }
            catch (Exception)
            {

            }
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            BarcodeBox1.Clear();
            
            Image<Bgr, Byte> ColordImage = Frame;
            Image<Gray, Byte> grayImage = ColordImage.Convert<Gray, Byte>();
            

            String[] Barcode = BarcodeScanner.Scan(grayImage.ToBitmap());

            if (Barcode.Length != 0 && Barcode[0].Length > 10)
            {
                Application.Idle -= new EventHandler(FrameProcedure);
                timer1.Stop();
                camera.Pause();
                BarcodeBox1.AppendText(Barcode[0]);

            }
        


            nEventsFired++;
            if (nEventsFired == 20)
            {
                timer1.Stop();
                if (camera != null)
                {
                    camera.Dispose();
                    camera = null;
                    
                }
            }
        }
        public void FaceRecognition_EventHandler_remove()
        {
            Application.Idle -= new EventHandler(FrameProcedure);
        }
    }
}
