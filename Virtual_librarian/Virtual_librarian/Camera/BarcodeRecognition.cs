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
using System.Threading;


namespace Virtual_librarian.Camera
{
    class BarcodeRecognition
    {
        Zmogus logedInUser;
        private object lockobject = new object();
        public List<Bitmap> images;
        Image<Bgr, byte> frame;
        BookDBHelper bookDBHelper = new BookDBHelper();
        private BindingList<Knyga> manoUzklausos = new BindingList<Knyga>();
        BindingList<Knyga> visosKnygos;
        public String[] barcode;
        private static int nEventsFired = 0;
        UseCamera camera;
        PictureBox cameraBox;
        Knyga knyga;
        //Image<Gray, Byte> grayImage;

        private System.Windows.Forms.Timer aTimer;

        //Evento kintamieji
        public delegate void RecognisedHandler(object sender, RecognisedBookEventArgs e);
        public event RecognisedHandler OnBookRecognised;
        //-----------------------------------------------
        //--------------Public Methods-------------------
        //-----------------------------------------------
        public BarcodeRecognition(PictureBox cameraBox,UseCamera camera)
        {
            this.cameraBox = cameraBox;
            this.camera = camera;
            aTimer = new System.Windows.Forms.Timer();
        }

        public bool setUser(Zmogus user)
        {
            logedInUser = user;
            return true;
        }
        //------------------------------------------------
        //------------Start Book Recognising--------------
        //------------------------------------------------
        public void startRecognising()
        {
            visosKnygos = new BindingList<Knyga>(bookDBHelper.gautiVisasKnygas());
            BindingSource visuKnyguSource = new BindingSource(visosKnygos, null);
            images = new List<Bitmap>();
            nEventsFired = 0;
            useTimer();
            camera.TurnOn();
            Application.Idle += new EventHandler(FrameProcedure);
            aTimer.Tick += ATimer_Tick;
            
            
        }
        //------------------------------------------------------------
        //-------Convert Barcodes from image to string----------------
        //------------------------------------------------------------
        public String[] getBarcodesString(Image<Gray, Byte> grayImage)
        {
            
            String[] barcodes = BarcodeScanner.Scan(grayImage.ToBitmap());
            
            return barcodes;
        }
        //-----------------------------------------------------------
        //------------------Private Methods--------------------------
        //-----------------------------------------------------------
        //--------------------Timer Event----------------------------
        //-----------------------------------------------------------
        private void ATimer_Tick(object sender, EventArgs e)
        {

            nEventsFired++;

            Image<Bgr, Byte> ColordImage = frame;
            Image<Gray, Byte> grayImage = ColordImage.Convert<Gray, Byte>();

            aTimer.Stop();
            barcode = getBarcodesString(grayImage);
            
            knyga = recogniseBookBarcode();

            if (knyga != null)
            {
                OnBookRecognised(this, new RecognisedBookEventArgs(knyga));
            }
            else
            {
                aTimer.Start();
            }

            if (nEventsFired == 20)
            {

                aTimer.Stop();
                if (camera != null)
                {
                    camera.TurnOff();

                }
            }
        }
        
        //------------------------------------------------------
        //-----------Display images to camera Event-------------
        //------------------------------------------------------
        private void FrameProcedure(object sender, EventArgs e)
        {
            try
            {
                frame = camera.Camera.QueryFrame();
                cameraBox.Image = frame.ToBitmap();
                if(knyga != null)
                {
                    Application.Idle -= new EventHandler(FrameProcedure);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Test");
            }
        }
        //------------------------------------------
        //-------------Turn on camera---------------
        //------------------------------------------
        private void useTimer()
        {
            aTimer.Interval = 2000;
            aTimer.Start();
        }
        //------------------------------------------
        //-------Convert image to gray image--------
        //------------------------------------------
        private Image<Gray,Byte> ImageToGray()
        {
            Image<Bgr, Byte> ColordImage = frame;
            Image<Gray, Byte> grayImage = ColordImage.Convert<Gray, Byte>();

            return grayImage;
        }
        
        //--------------------------------------------------------------------------
        //-----------------Get knyga if barcode recognised--------------------------
        //--------------------------------------------------------------------------
        private Knyga recogniseBookBarcode()
        {
            /*if (barcode.Length != 0)                                  //12 to 13 barcode numbers
            {
                
                char[] BarcodeNumbersChar = barcode[0].ToCharArray();
                int[] BNr = Array.ConvertAll(BarcodeNumbersChar, c => (int)Char.GetNumericValue(c));
                int LastNumber = 10 - (BNr[0] + BNr[1] * 3 + BNr[2] + BNr[3] * 3 + BNr[4] + BNr[5] * 3 + BNr[6] + BNr[7] * 3 + BNr[8] + BNr[9] * 3 + BNr[10] + BNr[11] * 3 ) % 10;
                Array.Resize(ref BNr, 13);
                BNr[12] = LastNumber;
                string result = string.Join("", BNr);
                MessageBox.Show(result);

            }*/
            if (barcode.Length != 0 && barcodesRecognisedCorect(10,16,barcode[0]))
            {
                
                aTimer.Stop();
                camera.Camera.Pause();               
                Knyga knyga = ContainsBook();
                
                return knyga;              
            }
            return null;
        }
      
        //------------------------------------------
        //---Check if barcode contains format-------
        //------------------------------------------
        private bool barcodesRecognisedCorect(int moreSimbolsThan,int lessSimbolsThan,String Barcode)
        {
            if (moreSimbolsThan < Barcode.Length && lessSimbolsThan > Barcode.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //--------------------------------------------------------------
        //-------------Check if xml file conatains book-----------------
        //--------------------------------------------------------------
        private Knyga ContainsBook()
        {
            bool contains = false;
            Knyga knyga = null;
            try
            {               
                knyga = visosKnygos.SingleOrDefault(k => k.Isbn == barcode[0]); //KREIPTIS PER BOOKDBHELPER
            }
            catch (Exception ex)
            {

            }
            if (knyga != null)
            {
                contains = true;
            }
            return knyga;
        }


    }
}
