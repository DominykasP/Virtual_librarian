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
using Virtual_librarian.DB_helpers;
using MetroFramework;
using Virtual_librarian.Camera;

namespace Virtual_librarian
{
    public partial class UCScanBook : MetroFramework.Controls.MetroUserControl
    {
        BarcodeRecognition recognition;
        private static int nEventsFired = 0;
        public UseCamera camera;
        private object lockobject = new object();
        public List<Bitmap> images;
        Image<Bgr, byte> frame;
        BookDBHelper bookDBHelper = new BookDBHelper();
        private BindingList<Knyga> manoUzklausos = new BindingList<Knyga>();
        BindingList<Knyga> visosKnygos;
        String[] barcode;
        Zmogus logedInUser;



        public UCScanBook()
        {
            camera = new UseCamera();
            
            InitializeComponent();
        }
        public bool setUser(Zmogus user)
        {
            logedInUser = user;
            return true;
        }
        private void UCScanBook_Load(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            
            camera.turnOn();
            recognition = new BarcodeRecognition(cameraBox, camera);
            recognition.startRecognising();

            recognition.OnBookRecognised += Recognition_OnBookRecognised;

            //timer1.Interval = 2000;
            //timer1.Start();
            /* visosKnygos = new BindingList<Knyga>(bookDBHelper.gautiVisasKnygas());
             BindingSource visuKnyguSource = new BindingSource(visosKnygos, null);
             images = new List<Bitmap>();
             nEventsFired = 0;


             Application.Idle += new EventHandler(FrameProcedure);*/
        }

        private void Recognition_OnBookRecognised(object sender, RecognisedBookEventArgs e)
        {
            Knyga knyga = e.book;

            BarcodeBox1.Clear();

            barcode = recognition.barcode;


            if (barcode.Length != 0 && barcode[0].Length > 10)
            {

                BarcodeBox1.AppendText(barcode[0]);
                DialogResult dr = MetroMessageBox.Show(this, "Book Author: " + knyga.Autorius + "\n" +
                                "Book Name: " + knyga.Pavadinimas + " \n" +
                                "Book ISBN: " + knyga.Isbn + "\n" +
                                "Do you want to take this book? ", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (dr == DialogResult.Yes)
                {
                    bool arSekmingai = bookDBHelper.paimtiKnyga(knyga, logedInUser);
                    if (arSekmingai == true)
                    {

                        MetroMessageBox.Show(this, "Knyga sėkmingai paimta", knyga.Pavadinimas, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Klaida paimant knygą", knyga.Pavadinimas, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }




        /* public Knyga ContainsBook()
         {
             bool contains = false;
             Knyga knyga = null;
             try
             {
                 knyga = visosKnygos.SingleOrDefault(k => k.Isbn == barcode[0]);
             }
             catch (Exception ex)
             {

             }
             if (knyga != null)
             {
                 contains = true;
             }
             return knyga;
         }*/
        /* private void FrameProcedure(object sender, EventArgs e)
         {
             try
             {

                 frame = camera.Camera.QueryFrame();
                 cameraBox.Image = frame.ToBitmap();
             }
             catch (Exception)
             {

             }
         }*/

            /*
        private void timer1_Tick(object sender, EventArgs e)
        {
            BarcodeBox1.Clear();

            Image<Bgr, Byte> ColordImage = frame;
            Image<Gray, Byte> grayImage = ColordImage.Convert<Gray, Byte>();


            barcode = recognition.getBarcodesString();


            if (barcode.Length != 0 && barcode[0].Length > 10)
            {

                BarcodeBox1.AppendText(barcode[0]);

                if (knyga != null)
                {
                    MetroMessageBox.Show(this, "Book exists");
                    DialogResult dr = MetroMessageBox.Show(this, "Book Author: " + knyga.Autorius + "\n" +
                                    "Book Name: " + knyga.Pavadinimas + " \n" +
                                    "Book ISBN: " + knyga.Isbn + "\n" +
                                    "Do you want to take this book? ", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MetroMessageBox.Show(this, "Not Exist");
                }
                bool arSekmingai = bookDBHelper.paimtiKnyga(knyga, logedInUser);
                if (arSekmingai == true)
                {

                    MetroMessageBox.Show(this, "Knyga sėkmingai paimta", knyga.Pavadinimas, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MetroMessageBox.Show(this, "Klaida paimant knygą", knyga.Pavadinimas, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


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
        */

    }
}
