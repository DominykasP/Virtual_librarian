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
using Database;
using MetroFramework;
using Camera;
using LibraryObjects;

namespace Virtual_librarian
{
    public partial class UCScanBook : MetroFramework.Controls.MetroUserControl
    {
        private MainForm mainForm;
        private UCMainUserMeniu ucMainUserMeniu;

        BarcodeRecognition recognition;
        
        public UseCamera camera;
        public List<Bitmap> images;
        String[] barcode;
        Person logedInUser;

        public delegate BookService.Book Delegate(string isbn);


        public UCScanBook(MainForm mainForm, UCMainUserMeniu ucMainUserMeniu)
        {
            camera = new UseCamera();
            
            InitializeComponent();
            this.mainForm = mainForm;
            this.ucMainUserMeniu = ucMainUserMeniu;

            Delegate getBookByIsbnDel = new Delegate(mainForm.bookDBHelperByBookService.GetBookByIsbn); //REIKIA PADARYTI, KAD DELEGATAS MATYTU TIPA IS BARCODERECOGNITION
            //ServiceToLibrary.Delegate bookToLibraryObjectDel = new ServiceToLibrary.Delegate(ServiceToLibrary.BookToLibraryObject);
            //recognition = new BarcodeRecognition(cameraBox, camera, bookToLibraryObjectDel);
            recognition = new BarcodeRecognition(cameraBox, camera, new Delegate(getBookByIsbnDel));
            //recognition = new BarcodeRecognition(cameraBox, camera, getBookByIsbnDel);
            //recognition.OnBookRecognised += Recognition_OnBookRecognised;
            recognition.OnBarcodeRecognised += Recognition_OnBarcodeRecognised;
        }

        public bool setUser(Person user)
        {
            logedInUser = user;
            return true;
        }
        private void UCScanBook_Load(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            recognition.StopRecognising();
            recognition.StartRecognising();
        }

        private void Recognition_OnBarcodeRecognised(object sender, RecognisedBarcodeEventArgs e)
        {
            //Book book = e.book;
            Book book = ServiceToLibrary.BookToLibraryObject(mainForm.bookDBHelperByBookService.GetBookByIsbn(e.barcode));

            BarcodeBox1.Clear();


            if (barcode.Length != 0 && barcode[0].Length > 10)
            {

                BarcodeBox1.AppendText(e.barcode);

                bool isBookTaken = mainForm.bookDBHelperByBookService.IsBookAlreadyTaken(book.Id);

                if (isBookTaken) //Jei paimta, norim grąžinti
                {
                    DialogResult dr = MetroMessageBox.Show(this,
                                "Pavadinimas: " + book.Name + " \n" +
                                "Autorius: " + book.Author + "\n" +
                                "ISBN numeris: " + book.Isbn,
                                "Ar norite grąžinti šią knygą?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (dr == DialogResult.Yes)
                    {
                        bool arSekmingai = mainForm.bookDBHelperByBookService.ReturnBook(book.Id);
                        if (arSekmingai == true)
                        {

                            MetroMessageBox.Show(this,
                                "Pavadinimas: " + book.Name + " \n" +
                                "Autorius: " + book.Author + "\n" +
                                "ISBN numeris: " + book.Isbn,
                                "Knyga sėkmingai grąžinta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MetroMessageBox.Show(this, book.Name, "Klaida grąžinant knygą", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else //Jei nepaimta, norim pasiimti
                {
                    DialogResult dr = MetroMessageBox.Show(this,
                                "Pavadinimas: " + book.Name + " \n" +
                                "Autorius: " + book.Author + "\n" +
                                "ISBN numeris: " + book.Isbn,
                                "Ar norite pasiimti šią knygą?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (dr == DialogResult.Yes)
                    {
                        bool arSekmingai = mainForm.bookDBHelperByBookService.TakeBook(book.Id, logedInUser.Id);
                        if (arSekmingai == true)
                        {

                            MetroMessageBox.Show(this,
                                "Pavadinimas: " + book.Name + " \n" +
                                "Autorius: " + book.Author + "\n" +
                                "ISBN numeris: " + book.Isbn,
                                "Knyga sėkmingai paimta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MetroMessageBox.Show(this,
                                "Pavadinimas: " + book.Name + " \n" +
                                "Autorius: " + book.Author + "\n" +
                                "ISBN numeris: " + book.Isbn,
                                "Klaida paimant knygą", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                //Atnaujinam visų ir pasiimtų knygų sąrašus
                ucMainUserMeniu.LoadLoanPeriods();
                ucMainUserMeniu.LoadBookCatalog();
            }
        }

        public void StopRecognising()
        {
            if (camera.Camera != null)
            {
                recognition.StopRecognising();
                camera.TurnOff();
            }
        }

    }
}
