using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using LibraryObjects;
using Database;

namespace Virtual_librarian
{
    public partial class UCMainUserMeniu : MetroFramework.Controls.MetroUserControl
    {
        private MainForm mainForm;
        private UCScanBook ucScanBook;
        private Person loggedInPerson;
        private BindingList<Book> myRequests = new BindingList<Book>();

        public UCMainUserMeniu(MainForm mForm, Person loggedIn)
        {
            mainForm = mForm;
            loggedInPerson = loggedIn;

            InitializeComponent();

            ucScanBook = new UCScanBook(mainForm, this);
            ucScanBook.Dock = DockStyle.Top;
            mtbPasiimti.Controls.Add(ucScanBook);
            mtbPasiimti.Leave += MtbPasiimti_Leave;

            ucScanBook.setUser(loggedIn);
            LoadLoanPeriods();
            LoadBookCatalog();
            LoadMyRequests();
            
        }

        private void MtbPasiimti_Leave(object sender, EventArgs e)
        {
            ucScanBook.StopRecognising();
        }

        private void UCMainUserMeniu_Load(object sender, EventArgs e)
        {
            lblUsername.Text = loggedInPerson.Name;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            //Sustabdyti knygu skenavima
            ucScanBook.StopRecognising();

            mainForm.Controls.Remove(this);

            UCChooseLogin ucChooseLogin = new UCChooseLogin(mainForm);
            ucChooseLogin.Dock = DockStyle.Bottom;
            mainForm.Controls.Add(ucChooseLogin);
        }

        public void LoadLoanPeriods()
        {
            BindingList<Book> myBooks = new BindingList<Book>(ServiceToLibrary.BookListToLibraryObject(mainForm.bookDBHelperByBookService.GetReadersBooks(loggedInPerson.Id)));

            BindingSource myBookSource = new BindingSource(myBooks, null);
            foreach (Book book in myBooks)
            {
                book.GetRemainingTime();
            }

            grdLoanPeriods.DataSource = myBookSource;
            grdLoanPeriods.Columns["id"].Visible = false;
            grdLoanPeriods.Columns["Publisher"].Visible = false;
            grdLoanPeriods.Columns["Year"].Visible = false;
            grdLoanPeriods.Columns["Pages"].Visible = false;
        }
        /*
        public void LoadBookCatalog()
        {
            HumanDBHelper humanDBHelper = new HumanDBHelper();
            BookDBHelper bookDBHelper = new BookDBHelper();
            
            BindingList<BookWithPerson> allBooks = new BindingList<BookWithPerson>(bookDBHelper.JoinBP(humanDBHelper.GetAllPersons(), bookDBHelper.GetAllBooks()));
            BindingSource allBookSource = new BindingSource(allBooks, null);
            var e = bookDBHelper.GroupBP(bookDBHelper.JoinBP(humanDBHelper.GetAllPersons(), bookDBHelper.GetAllBooks()));
            grdAllBooks.DataSource = allBookSource;
            grdAllBooks.Columns["id"].Visible = false; //Paslepiu, kad vartotojas nematytu knygos id
            grdAllBooks.Columns["TakenAt"].Visible = false;
            grdAllBooks.Columns["ReturnAt"].Visible = false;
            grdAllBooks.Columns["TimeRemaining"].Visible = false;
            grdAllBooks.Columns["ReaderId"].Visible = false;
        }
        */

        public void LoadBookCatalog()
        {
            BindingList<Book> allBooks = new BindingList<Book>(ServiceToLibrary.BookListToLibraryObject(mainForm.bookDBHelperByBookService.GetAllBooks()));
            BindingSource allBookSource = new BindingSource(allBooks, null);
            grdAllBooks.DataSource = allBookSource;
            grdAllBooks.Columns["id"].Visible = false; //Paslepiu, kad vartotojas nematytu knygos id
            grdAllBooks.Columns["TakenAt"].Visible = false;
            grdAllBooks.Columns["ReturnAt"].Visible = false;
            grdAllBooks.Columns["TimeRemaining"].Visible = false;
        }
        

        private void LoadMyRequests()
        {
            BindingSource myRequestSource = new BindingSource(myRequests, null);
            grdManoUzklausos.DataSource = myRequestSource;
            grdManoUzklausos.Columns["id"].Visible = false; //Paslepiu, kad vartotojas nematytu knygos id
            grdManoUzklausos.Columns["TakenAt"].Visible = false; //Paslepiu, kad vartotojas nematytu knygos id
            grdManoUzklausos.Columns["ReturnAt"].Visible = false; //Paslepiu, kad vartotojas nematytu knygos id
            grdManoUzklausos.Columns["TimeRemaining"].Visible = false; //Paslepiu, kad vartotojas nematytu knygos id
        }

        private void grdAllBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = grdAllBooks.Rows[e.RowIndex].Index;
            string selectedBookISBN = grdAllBooks.Rows[e.RowIndex].Cells[6].Value.ToString(); //6 - isbn
            string selectedBookCode = grdAllBooks.Rows[e.RowIndex].Cells[7].Value.ToString(); //7 - mūsų kodas
            Book selectedBook = ServiceToLibrary.BookToLibraryObject(mainForm.bookDBHelperByBookService.GetBookByCode(selectedBookISBN, selectedBookCode));

            DialogResult dr = MetroMessageBox.Show(this, "Pridėti šią knygą prie mano užklausų?", selectedBook.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.Yes)
            {
                myRequests.Add(selectedBook);
                MetroMessageBox.Show(this, "Knyga sėkmingai pridėta prie mano užklausų", selectedBook.Name, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void grdMyRequests_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = grdManoUzklausos.Rows[e.RowIndex].Index;
            string selectedBookISBN = grdManoUzklausos.Rows[e.RowIndex].Cells[6].Value.ToString(); //6 - isbn
            string selectedBookCode = grdManoUzklausos.Rows[e.RowIndex].Cells[7].Value.ToString(); //7 - mūsų kodas
            Book selectedBook = ServiceToLibrary.BookToLibraryObject(mainForm.bookDBHelperByBookService.GetBookByCode(selectedBookISBN, selectedBookCode));

            DialogResult dr = MetroMessageBox.Show(this, "Ar norite pašalinti šią knygą iš mano užklausų?", selectedBook.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.Yes)
            {
                myRequests.RemoveAt(selectedIndex);
                MetroMessageBox.Show(this, "Knyga sėkmingai pašalinta iš mano užklausų", selectedBook.Name, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnSendMyRequests_Click(object sender, EventArgs e)
        {
            myRequests.Clear();
            MetroMessageBox.Show(this, "Mano užklausų sąrašas sėkmingai išsiųstas bibliotekininkei", "Išsiųsta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void grdLoanPeriods_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = grdLoanPeriods.Rows[e.RowIndex].Index;
            string selectedBookISBN = grdLoanPeriods.Rows[e.RowIndex].Cells[6].Value.ToString(); //6 - isbn
            string selectedBookCode = grdLoanPeriods.Rows[e.RowIndex].Cells[7].Value.ToString(); //7 - mūsų kodas
            Book selectedBook = ServiceToLibrary.BookToLibraryObject(mainForm.bookDBHelperByBookService.GetBookByCode(selectedBookISBN, selectedBookCode));

            DialogResult dr = MetroMessageBox.Show(this, "Ar norite pratęsti šios knygos terminą vienam mėnesiui?", selectedBook.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.Yes)
            {
                if (mainForm.bookDBHelperByBookService.RenewBook(selectedBook.Id) == true)
                {
                    LoadLoanPeriods();
                    LoadBookCatalog();
                    MetroMessageBox.Show(this, "Knyga sėkmingai pratęsta", selectedBook.Name, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MetroMessageBox.Show(this, "Klaida patęsiant knygą", "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void grdAllBooks_KeyPress(object sender, KeyPressEventArgs e) //Šito vėliau nereikės - Paspaudus tarpą "Pasiims knygą"
        {
            if (e.KeyChar == (Char)Keys.Space)
            {
                int selectedRow = grdAllBooks.CurrentRow.Index;
                string selectedBookISBN = grdAllBooks.Rows[selectedRow].Cells[6].Value.ToString(); //6 - isbn
                string selectedBookCode = grdAllBooks.Rows[selectedRow].Cells[7].Value.ToString(); //7 - mūsų kodas
                Book selectedBook = ServiceToLibrary.BookToLibraryObject(mainForm.bookDBHelperByBookService.GetBookByCode(selectedBookISBN, selectedBookCode));

                DialogResult dr = MetroMessageBox.Show(this, "Ar norite pasiimti šią knygą", selectedBook.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (dr == DialogResult.Yes)
                {
                    bool isSuccessful = mainForm.bookDBHelperByBookService.TakeBook(selectedBook.Id, loggedInPerson.Id);
                    if (isSuccessful == true)
                    {
                        LoadLoanPeriods();
                        LoadBookCatalog();
                        MetroMessageBox.Show(this, "Knyga sėkmingai paimta", selectedBook.Name, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Klaida paimant knygą", selectedBook.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
        }

        private void grdLoanPeriods_KeyPress(object sender, KeyPressEventArgs e) //Šito vėliau nereikės - Paspaudus tarpą "Grąžins knygą"
        {
            if (e.KeyChar == (Char)Keys.Space)
            {
                int selectedRow = grdLoanPeriods.CurrentRow.Index;
                string selectedBookISBN = grdLoanPeriods.Rows[selectedRow].Cells[6].Value.ToString(); //6 - isbn
                string selectedBookCode = grdLoanPeriods.Rows[selectedRow].Cells[7].Value.ToString(); //7 - mūsų kodas
                Book selectedBook = ServiceToLibrary.BookToLibraryObject(mainForm.bookDBHelperByBookService.GetBookByCode(selectedBookISBN, selectedBookCode));

                DialogResult dr = MetroMessageBox.Show(this, "Ar norite grąžinti šią knygą", selectedBook.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (dr == DialogResult.Yes)
                {
                    bool isSuccessful = mainForm.bookDBHelperByBookService.ReturnBook(selectedBook.Id);
                    if (isSuccessful == true)
                    {
                        LoadLoanPeriods();
                        LoadBookCatalog();
                        MetroMessageBox.Show(this, "Knyga sėkmingai grąžinta", selectedBook.Name, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Klaida grąžinant knygą", selectedBook.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void grdLoanPeriods_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
