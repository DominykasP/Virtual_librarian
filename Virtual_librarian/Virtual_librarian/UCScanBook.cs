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

            recognition = new BarcodeRecognition(cameraBox, camera);
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
            Book scannedBook = ServiceToLibrary.BookToLibraryObject(mainForm.bookDBHelperByBookService.GetBookByIsbn(e.barcode));
            BarcodeBox1.Text = e.barcode;

            if (scannedBook == null)
            {
                scannedBook = ServiceToLibrary.BookToLibraryObject(mainForm.bookDBHelperByBookService.GetBookByIsbn(e.barcodeLonger)); //Tikrinam, gal reikia paskaičiuoti 13 skaičių
                BarcodeBox1.Text = e.barcodeLonger;
            }

            if (scannedBook != null)
            {
                bool isBookTaken = mainForm.bookDBHelperByBookService.IsBookAlreadyTaken(scannedBook.Id);

                if (isBookTaken) //Jei paimta, norim grąžinti
                {
                    DialogResult dr = MetroMessageBox.Show(this,
                                "Pavadinimas: " + scannedBook.Name + " \n" +
                                "Autorius: " + scannedBook.Author + "\n" +
                                "ISBN numeris: " + scannedBook.Isbn,
                                "Ar norite grąžinti šią knygą?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (dr == DialogResult.Yes)
                    {
                        bool arSekmingai = mainForm.bookDBHelperByBookService.ReturnBook(scannedBook.Id);
                        if (arSekmingai == true)
                        {

                            MetroMessageBox.Show(this,
                                "Pavadinimas: " + scannedBook.Name + " \n" +
                                "Autorius: " + scannedBook.Author + "\n" +
                                "ISBN numeris: " + scannedBook.Isbn,
                                "Knyga sėkmingai grąžinta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MetroMessageBox.Show(this, scannedBook.Name, "Klaida grąžinant knygą", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else //Jei nepaimta, norim pasiimti
                {
                    DialogResult dr = MetroMessageBox.Show(this,
                                "Pavadinimas: " + scannedBook.Name + " \n" +
                                "Autorius: " + scannedBook.Author + "\n" +
                                "ISBN numeris: " + scannedBook.Isbn,
                                "Ar norite pasiimti šią knygą?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (dr == DialogResult.Yes)
                    {
                        bool arSekmingai = mainForm.bookDBHelperByBookService.TakeBook(scannedBook.Id, logedInUser.Id);
                        if (arSekmingai == true)
                        {

                            MetroMessageBox.Show(this,
                                "Pavadinimas: " + scannedBook.Name + " \n" +
                                "Autorius: " + scannedBook.Author + "\n" +
                                "ISBN numeris: " + scannedBook.Isbn,
                                "Knyga sėkmingai paimta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MetroMessageBox.Show(this,
                                "Pavadinimas: " + scannedBook.Name + " \n" +
                                "Autorius: " + scannedBook.Author + "\n" +
                                "ISBN numeris: " + scannedBook.Isbn,
                                "Klaida paimant knygą", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                //Atnaujinam visų ir pasiimtų knygų sąrašus
                ucMainUserMeniu.LoadLoanPeriods();
                ucMainUserMeniu.LoadBookCatalog();
            }

            //Pasiemus/grazinus knyga tesiame skenavima
            recognition.ContinueRecognising();
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
