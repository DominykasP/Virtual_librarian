using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Virtual_librarian
{
    public partial class UCMainUserMeniu : MetroFramework.Controls.MetroUserControl
    {
        private MainForm mainForm;
        private Person loggedInPerson;
        private BindingList<Book> manoUzklausos = new BindingList<Book>();

        public UCMainUserMeniu(MainForm mainForma, Person loggedIn)
        {
            mainForm = mainForma;
            loggedInPerson = loggedIn;

            InitializeComponent();

            pakrautiTerminus();
            pakrautiKnyguKataloga();
            pakrautiManoUzklausas();
        }

        private void UCMainUserMeniu_Load(object sender, EventArgs e)
        {
            lblNaudotojoVardas.Text = loggedInPerson.Name;
        }

        private void btnAtsijungti_Click(object sender, EventArgs e)
        {
            //Sustabdyti knygu skenavima
            if(ucScanBook1.camera != null)
            {
                ucScanBook1.timer1.Stop();
                ucScanBook1.camera.Dispose();
                ucScanBook1.Dispose();
            }
            

            mainForm.Controls.Remove(this);

            UCChooseLogin ucChooseLogin = new UCChooseLogin(mainForm);
            ucChooseLogin.Dock = DockStyle.Bottom;
            mainForm.Controls.Add(ucChooseLogin);
        }

        private void pakrautiTerminus()
        {
            BindingList<Book> manoKnygos = new BindingList<Book>(mainForm.bookDBHelper.GetReadersBooks(loggedInPerson));
            BindingSource manoKnyguSource = new BindingSource(manoKnygos, null);
            foreach (Book knyga in manoKnygos)
            {
                knyga.getRemainingTime();
            }

            grdTerminai.DataSource = manoKnyguSource;
            grdTerminai.Columns["id"].Visible = false;
            grdTerminai.Columns["Publisher"].Visible = false;
            grdTerminai.Columns["Year"].Visible = false;
            grdTerminai.Columns["Pages"].Visible = false;
        }

        private void pakrautiKnyguKataloga()
        {
            BindingList<Book> visosKnygos = new BindingList<Book>(mainForm.bookDBHelper.GetAllBooks());
            BindingSource visuKnyguSource = new BindingSource(visosKnygos, null);
            grdAllBooks.DataSource = visuKnyguSource;
            grdAllBooks.Columns["id"].Visible = false; //Paslepiu, kad vartotojas nematytu knygos id
            grdAllBooks.Columns["TakenAt"].Visible = false;
            grdAllBooks.Columns["ReturnAt"].Visible = false;
            grdAllBooks.Columns["TimeRemaining"].Visible = false;
        }

        private void pakrautiManoUzklausas()
        {
            BindingSource manoUzklausuSource = new BindingSource(manoUzklausos, null);
            grdManoUzklausos.DataSource = manoUzklausuSource;
            grdManoUzklausos.Columns["id"].Visible = false; //Paslepiu, kad vartotojas nematytu knygos id
            grdManoUzklausos.Columns["TakenAt"].Visible = false; //Paslepiu, kad vartotojas nematytu knygos id
            grdManoUzklausos.Columns["ReturnAt"].Visible = false; //Paslepiu, kad vartotojas nematytu knygos id
            grdManoUzklausos.Columns["TimeRemaining"].Visible = false; //Paslepiu, kad vartotojas nematytu knygos id
        }

        private void grdAllBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int pasirinktasIndex = grdAllBooks.Rows[e.RowIndex].Index;
            string pasirinktosKnygosISBN = grdAllBooks.Rows[e.RowIndex].Cells[6].Value.ToString(); //6 - isbn
            string pasirinktosKnygosKodas = grdAllBooks.Rows[e.RowIndex].Cells[7].Value.ToString(); //7 - mūsų kodas
            Book pasirinktaKnyga = mainForm.bookDBHelper.GetBookByCodes(pasirinktosKnygosISBN, pasirinktosKnygosKodas);

            DialogResult dr = MetroMessageBox.Show(this, "Pridėti šią knygą prie mano užklausų?", pasirinktaKnyga.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.Yes)
            {
                manoUzklausos.Add(pasirinktaKnyga);
                MetroMessageBox.Show(this, "Knyga sėkmingai pridėta prie mano užklausų", pasirinktaKnyga.Name, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void grdManoUzklausos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int pasirinktasIndex = grdManoUzklausos.Rows[e.RowIndex].Index;
            string pasirinktosKnygosISBN = grdManoUzklausos.Rows[e.RowIndex].Cells[6].Value.ToString(); //6 - isbn
            string pasirinktosKnygosKodas = grdManoUzklausos.Rows[e.RowIndex].Cells[7].Value.ToString(); //7 - mūsų kodas
            Book pasirinktaKnyga = mainForm.bookDBHelper.GetBookByCodes(pasirinktosKnygosISBN, pasirinktosKnygosKodas);

            DialogResult dr = MetroMessageBox.Show(this, "Ar norite pašalinti šią knygą iš mano užklausų?", pasirinktaKnyga.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.Yes)
            {
                manoUzklausos.RemoveAt(pasirinktasIndex);
                MetroMessageBox.Show(this, "Knyga sėkmingai pašalinta iš mano užklausų", pasirinktaKnyga.Name, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnSiustiManoUzklausas_Click(object sender, EventArgs e)
        {
            manoUzklausos.Clear();
            MetroMessageBox.Show(this, "Mano užklausų sąrašas sėkmingai išsiųstas bibliotekininkei", "Išsiųsta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void grdTerminai_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int pasirinktasIndex = grdTerminai.Rows[e.RowIndex].Index;
            string pasirinktosKnygosISBN = grdTerminai.Rows[e.RowIndex].Cells[6].Value.ToString(); //6 - isbn
            string pasirinktosKnygosKodas = grdTerminai.Rows[e.RowIndex].Cells[7].Value.ToString(); //7 - mūsų kodas
            Book pasirinktaKnyga = mainForm.bookDBHelper.GetBookByCodes(pasirinktosKnygosISBN, pasirinktosKnygosKodas);

            DialogResult dr = MetroMessageBox.Show(this, "Ar norite pratęsti šios knygos terminą vienam mėnesiui?", pasirinktaKnyga.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.Yes)
            {
                if (mainForm.bookDBHelper.RenewBook(pasirinktaKnyga) == true)
                {
                    MetroMessageBox.Show(this, "Knyga sėkmingai pratęsta", pasirinktaKnyga.Name, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MetroMessageBox.Show(this, "Klaida patęsiant knygą", "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ucScanBook1_Load(object sender, EventArgs e)
        {

        }

        private void ucScanBook1_Load_1(object sender, EventArgs e)
        {

        }

        private void grdAllBooks_KeyPress(object sender, KeyPressEventArgs e) //Šito vėliau nereikės - Paspaudus tarpą "Pasiims knygą"
        {
            if (e.KeyChar == (Char)Keys.Space)
            {
                int pasirinktaEile = grdAllBooks.CurrentRow.Index;
                string pasirinktosKnygosISBN = grdAllBooks.Rows[pasirinktaEile].Cells[6].Value.ToString(); //6 - isbn
                string pasirinktosKnygosKodas = grdAllBooks.Rows[pasirinktaEile].Cells[7].Value.ToString(); //7 - mūsų kodas
                Book pasirinktaKnyga = mainForm.bookDBHelper.GetBookByCodes(pasirinktosKnygosISBN, pasirinktosKnygosKodas);

                DialogResult dr = MetroMessageBox.Show(this, "Ar norite pasiimti šią knygą", pasirinktaKnyga.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (dr == DialogResult.Yes)
                {
                    bool arSekmingai = mainForm.bookDBHelper.TakeBook(pasirinktaKnyga, loggedInPerson);
                    if (arSekmingai == true)
                    {
                        pakrautiTerminus();
                        MetroMessageBox.Show(this, "Knyga sėkmingai paimta", pasirinktaKnyga.Name, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Klaida paimant knygą", pasirinktaKnyga.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
        }

        private void grdTerminai_KeyPress(object sender, KeyPressEventArgs e) //Šito vėliau nereikės - Paspaudus tarpą "Grąžins knygą"
        {
            if (e.KeyChar == (Char)Keys.Space)
            {
                int pasirinktaEile = grdTerminai.CurrentRow.Index;
                string pasirinktosKnygosISBN = grdTerminai.Rows[pasirinktaEile].Cells[6].Value.ToString(); //6 - isbn
                string pasirinktosKnygosKodas = grdTerminai.Rows[pasirinktaEile].Cells[7].Value.ToString(); //7 - mūsų kodas
                Book pasirinktaKnyga = mainForm.bookDBHelper.GetBookByCodes(pasirinktosKnygosISBN, pasirinktosKnygosKodas);

                DialogResult dr = MetroMessageBox.Show(this, "Ar norite grąžinti šią knygą", pasirinktaKnyga.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (dr == DialogResult.Yes)
                {
                    bool arSekmingai = mainForm.bookDBHelper.ReturnBook(pasirinktaKnyga);
                    if (arSekmingai == true)
                    {
                        pakrautiTerminus();
                        MetroMessageBox.Show(this, "Knyga sėkmingai grąžinta", pasirinktaKnyga.Name, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Klaida grąžinant knygą", pasirinktaKnyga.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
    }
}
