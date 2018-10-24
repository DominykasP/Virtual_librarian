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
using Virtual_librarian.Camera;

namespace Virtual_librarian
{
    public partial class UCScanBook : MetroFramework.Controls.MetroUserControl
    {
        BarcodeRecognition recognition;
        
        public UseCamera camera;
        private object lockobject = new object();
        public List<Bitmap> images;
        String[] barcode;
        Person logedInUser;



        public UCScanBook()
        {
            camera = new UseCamera();
            
            InitializeComponent();
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
            
            camera.TurnOn();
            recognition = new BarcodeRecognition(cameraBox, camera, mainForm.bookDBHelper);
            recognition.StartRecognising();

            recognition.OnBookRecognised += Recognition_OnBookRecognised;

           
        }

        private void Recognition_OnBookRecognised(object sender, RecognisedBookEventArgs e)
        {
            Book book = e.book;

            BarcodeBox1.Clear();

            barcode = recognition.barcode;


            if (barcode.Length != 0 && barcode[0].Length > 10)
            {

                BarcodeBox1.AppendText(barcode[0]);
                DialogResult dr = MetroMessageBox.Show(this, "Book Author: " + book.Author + "\n" +
                                "Book Name: " + book.Name + " \n" +
                                "Book ISBN: " + book.Isbn + "\n" +
                                "Do you want to take this book? ", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (dr == DialogResult.Yes)
                {
                    bool isSuccessful = bookDBHelper.TakeBook(book, logedInUser);
                    if (isSuccessful == true)
                    {

                        MetroMessageBox.Show(this, "Knyga sėkmingai paimta", book.Name, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Klaida paimant knygą", book.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}
