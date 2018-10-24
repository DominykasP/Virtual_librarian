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
        Person loggedInUser;
        private object lockObject = new object();
        public List<Bitmap> images;
        Image<Bgr, byte> frame;
        BookDBHelper bookDBHelper = new BookDBHelper();
        private BindingList<Book> myRequests = new BindingList<Book>();
        BindingList<Book> allBooks;
        public String[] barcode;
        UseCamera camera;
        PictureBox cameraBox;
        Book book;
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
            aTimer.Tick += ATimer_Tick;
        }

        public bool SetUser(Person user)
        {
            loggedInUser = user;
            return true;
        }
        //------------------------------------------------
        //------------Start Book Recognising--------------
        //------------------------------------------------
        public void StartRecognising()
        {
            allBooks = new BindingList<Book>(bookDBHelper.GetAllBooks());
            BindingSource allBookSource = new BindingSource(allBooks, null);
            images = new List<Bitmap>();
            aTimer.Interval = 2000;
            aTimer.Start();
            camera.TurnOn();
            Application.Idle += FrameProcedure;
        }
        //------------------------------------------------
        //-------------Stop Book Recognition--------------
        //------------------------------------------------
        public void StopRecognising()
        {
            aTimer.Stop();
            if (camera.Camera != null)
            {
                camera.TurnOff();
            }
            Application.Idle -= FrameProcedure;
        }
        //------------------------------------------------------------
        //-------Convert Barcodes from image to string----------------
        //------------------------------------------------------------
        public String[] GetBarcodesString(Image<Gray, Byte> grayImage)
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
            Image<Bgr, Byte> ColordImage = frame;
            Image<Gray, Byte> grayImage = ColordImage.Convert<Gray, Byte>();

            aTimer.Stop();
            barcode = GetBarcodesString(grayImage);
            
            book = RecogniseBookBarcode();

            if (book != null)
            {
                OnBookRecognised(this, new RecognisedBookEventArgs(book));
            }
            else
            {
                aTimer.Start();
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
                if(book != null)
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
        //-------Convert image to gray image--------
        //------------------------------------------
        private Image<Gray,Byte> ImageToGray()
        {
            Image<Bgr, Byte> ColoredImage = frame;
            Image<Gray, Byte> grayImage = ColoredImage.Convert<Gray, Byte>();

            return grayImage;
        }
        
        //--------------------------------------------------------------------------
        //-----------------Get knyga if barcode recognised--------------------------
        //--------------------------------------------------------------------------
        private Book RecogniseBookBarcode()
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
            if (barcode.Length != 0 && BarcodesRecognisedCorect(10,16,barcode[0]))
            {
                
                aTimer.Stop();
                camera.Camera.Pause();               
                Book book = ContainsBook();
                
                return book;              
            }
            return null;
        }
      
        //------------------------------------------
        //---Check if barcode contains format-------
        //------------------------------------------
        private bool BarcodesRecognisedCorect(int moreSimbolsThan,int lessSimbolsThan,String Barcode)
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
        private Book ContainsBook()
        {
            bool contains = false;
            Book knyga = null;
            try
            {               
                knyga = allBooks.SingleOrDefault(k => k.Isbn == barcode[0]); //KREIPTIS PER BOOKDBHELPER
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
