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
        private MainForm mainForm;
        private UCMainUserMeniu ucMainUserMeniu;

        BarcodeRecognition recognition;
        
        public UseCamera camera;
        public List<Bitmap> images;
        String[] barcode;
        Person logedInUser;



        public UCScanBook(MainForm mainForm, UCMainUserMeniu ucMainUserMeniu)
        {
            camera = new UseCamera();
            
            InitializeComponent();
            this.mainForm = mainForm;
            this.ucMainUserMeniu = ucMainUserMeniu;

            recognition = new BarcodeRecognition(cameraBox, camera);
            recognition.OnBookRecognised += Recognition_OnBookRecognised;
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
            if (camera.Camera == null) //Jei kamera išjungta
            {
                camera.TurnOn();
                recognition.StartRecognising();
            }
        }

        private void Recognition_OnBookRecognised(object sender, RecognisedBookEventArgs e)
        {
            Book book = e.book;

            BarcodeBox1.Clear();

            barcode = recognition.barcode;


            if (barcode.Length != 0 && barcode[0].Length > 10)
            {

                BarcodeBox1.AppendText(barcode[0]);

                bool isBookTaken = mainForm.bookDBHelper.isBookAlreadyTaken(book);

                if (isBookTaken) //Jei paimta, norim grąžinti
                {
                    DialogResult dr = MetroMessageBox.Show(this,
                                "Pavadinimas: " + book.Name + " \n" +
                                "Autorius: " + book.Author + "\n" +
                                "ISBN numeris: " + book.Isbn,
                                "Ar norite grąžinti šią knygą?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (dr == DialogResult.Yes)
                    {
                        bool arSekmingai = mainForm.bookDBHelper.ReturnBook(book);
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
                        bool arSekmingai = mainForm.bookDBHelper.TakeBook(book, logedInUser);
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
