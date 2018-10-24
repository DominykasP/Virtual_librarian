﻿using System;
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
        BookDBHelper bookDBHelper;
        private BindingList<Book> myRequests = new BindingList<Book>();
        BindingList<Book> allBooks;
        public String[] barcode;
        private static int nEventsFired = 0;
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
        public BarcodeRecognition(PictureBox cameraBox,UseCamera camera, BookDBHelper bookDBHelper)
        {
            this.cameraBox = cameraBox;
            this.camera = camera;
            aTimer = new System.Windows.Forms.Timer();
            this.bookDBHelper = bookDBHelper;
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
            nEventsFired = 0;
            UseTimer();
            camera.TurnOn();
            Application.Idle += new EventHandler(FrameProcedure);
            aTimer.Tick += ATimer_Tick;
            
            
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

            nEventsFired++;

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
        //-------------Turn on camera---------------
        //------------------------------------------
        private void UseTimer()
        {
            aTimer.Interval = 2000;
            aTimer.Start();
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
            String BarcodeNew = Convert12to13(barcode);
            if (barcode.Length != 0 && BarcodesRecognisedCorect(10,16,barcode[0]))
            {
                
                aTimer.Stop();
                camera.Camera.Pause();               
                Book book = ContainsBook(barcode[0]);
                if(book == null)
                {
                    book = ContainsBook(BarcodeNew);
                }
                
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
        private Book ContainsBook(String Isbn)
        {
            
            Book knyga = null;
            //knyga = allBooks.SingleOrDefault(k => k.Isbn == barcode[0]); //KREIPTIS PER BOOKDBHELPER
            knyga = bookDBHelper.GetBookByIsbn(Isbn);
            
            return knyga;
        }
        //--------------------------------------------------------------
        //-----Convert barcode from 12 to 13 numbers when scanning------
        //--------------------------------------------------------------
        private String Convert12to13(String[] barcode)
        {
            String NewBarcode=null;

            if (barcode.Length != 0 && BarcodesRecognisedCorect(11, 13, barcode[0])&& ExtensionMethods.IsDigitsOnly(barcode[0]))                                  //12 to 13 barcode numbers
            {

                char[] BarcodeNumbersChar = barcode[0].ToCharArray();
                int[] BNr = Array.ConvertAll(BarcodeNumbersChar, c => (int)Char.GetNumericValue(c));
                int LastNumber = 10 - (BNr[0] + BNr[1] * 3 + BNr[2] + BNr[3] * 3 + BNr[4] + BNr[5] * 3 + BNr[6] + BNr[7] * 3 + BNr[8] + BNr[9] * 3 + BNr[10] + BNr[11] * 3) % 10;
                Array.Resize(ref BNr, 13);
                BNr[12] = LastNumber;
                char[] newBarcodeArray = new char[13];
                for (int i = 0; i < BNr.Length; i++)
                {
                    char[] convertedInt = BNr[i].ToString().ToCharArray();
                    newBarcodeArray[i] = convertedInt[0];
                }
                NewBarcode = new String(newBarcodeArray);
               

            }
            return NewBarcode;
        }
        //--------------------------------------------------------------
        //-----------Check if barcode only contains digits--------------
        //--------------------------------------------------------------
        

    }
}
