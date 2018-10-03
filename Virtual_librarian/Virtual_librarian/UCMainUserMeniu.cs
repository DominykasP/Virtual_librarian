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
        private Zmogus prisijungesZmogus;
        private BindingList<Knyga> manoUzklausos = new BindingList<Knyga>();

        public UCMainUserMeniu(MainForm mainForma, Zmogus prisijunges)
        {
            mainForm = mainForma;
            prisijungesZmogus = prisijunges;

            InitializeComponent();

            pakrautiTerminusKnyguKatalogaManoUzklausas();
        }

        private void UCMainUserMeniu_Load(object sender, EventArgs e)
        {
            lblNaudotojoVardas.Text = prisijungesZmogus.Name;
        }

        private void btnAtsijungti_Click(object sender, EventArgs e)
        {
            //Sustabdyti knygu skenavima
            ucScanBook1.timer1.Stop();
            ucScanBook1.capture.Dispose();
            ucScanBook1.Dispose();

            mainForm.Controls.Remove(this);

            UCChooseLogin ucChooseLogin = new UCChooseLogin(mainForm);
            ucChooseLogin.Dock = DockStyle.Bottom;
            mainForm.Controls.Add(ucChooseLogin);
        }

        private void pakrautiTerminusKnyguKatalogaManoUzklausas()
        {
            BindingList<Knyga> manoKnygos = new BindingList<Knyga>(mainForm.bookDBHelper.gautiZmogausKnygas(prisijungesZmogus));
            BindingSource manoKnyguSource = new BindingSource(manoKnygos, null);
            foreach (Knyga knyga in manoKnygos)
            {
                knyga.gautiLikoLaiko();
            }

            grdTerminai.DataSource = manoKnyguSource;
            grdTerminai.Columns["id"].Visible = false;
            grdTerminai.Columns["Leidykla"].Visible = false;
            grdTerminai.Columns["Metai"].Visible = false;
            grdTerminai.Columns["Puslapiai"].Visible = false;


            BindingList<Knyga> visosKnygos = new BindingList<Knyga>(mainForm.bookDBHelper.gautiVisasKnygas());
            BindingSource visuKnyguSource = new BindingSource(visosKnygos, null);
            grdAllBooks.DataSource = visuKnyguSource;
            grdAllBooks.Columns["id"].Visible = false; //Paslepiu, kad vartotojas nematytu knygos id

            BindingSource manoUzklausuSource = new BindingSource(manoUzklausos, null);
            grdManoUzklausos.DataSource = manoUzklausuSource;
            grdManoUzklausos.Columns["id"].Visible = false; //Paslepiu, kad vartotojas nematytu knygos id
        }

        private void grdAllBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int pasirinktasIndex = grdAllBooks.Rows[e.RowIndex].Index;
            string pasirinktosKnygosISBN = grdAllBooks.Rows[e.RowIndex].Cells[6].Value.ToString(); //6 - isbn
            string pasirinktosKnygosKodas = grdAllBooks.Rows[e.RowIndex].Cells[7].Value.ToString(); //7 - mūsų kodas
            Knyga pasirinktaKnyga = mainForm.bookDBHelper.gautiKnygaPagalKodus(pasirinktosKnygosISBN, pasirinktosKnygosKodas);

            DialogResult dr = MetroMessageBox.Show(this, "Pridėti šią knygą prie mano užklausų?", pasirinktaKnyga.Pavadinimas, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.Yes)
            {
                manoUzklausos.Add(pasirinktaKnyga);
                MetroMessageBox.Show(this, "Knyga sėkmingai pridėta prie mano užklausų", pasirinktaKnyga.Pavadinimas, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void grdManoUzklausos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int pasirinktasIndex = grdManoUzklausos.Rows[e.RowIndex].Index;
            string pasirinktosKnygosISBN = grdManoUzklausos.Rows[e.RowIndex].Cells[6].Value.ToString(); //6 - isbn
            string pasirinktosKnygosKodas = grdManoUzklausos.Rows[e.RowIndex].Cells[7].Value.ToString(); //7 - mūsų kodas
            Knyga pasirinktaKnyga = mainForm.bookDBHelper.gautiKnygaPagalKodus(pasirinktosKnygosISBN, pasirinktosKnygosKodas);

            DialogResult dr = MetroMessageBox.Show(this, "Ar norite pašalinti šią knygą iš mano užklausų?", pasirinktaKnyga.Pavadinimas, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.Yes)
            {
                manoUzklausos.RemoveAt(pasirinktasIndex);
                MetroMessageBox.Show(this, "Knyga sėkmingai pašalinta iš mano užklausų", pasirinktaKnyga.Pavadinimas, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
            Knyga pasirinktaKnyga = mainForm.bookDBHelper.gautiKnygaPagalKodus(pasirinktosKnygosISBN, pasirinktosKnygosKodas);

            //NEVEIKIA
            /*
            DialogResult dr = MetroMessageBox.Show(this, "Ar norite pratęsti šios knygos terminą vienam mėnesiui?", pasirinktaKnyga.Pavadinimas, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.Yes)
            {
                MessageBox.Show("Buvo: " + pasirinktaKnyga.Grazinti.ToShortDateString());
                pasirinktaKnyga.Grazinti.AddMonths(1);
                pasirinktaKnyga.gautiLikoLaiko();
                MessageBox.Show(pasirinktaKnyga.Grazinti.ToShortDateString());
                MetroMessageBox.Show(this, "Knyga sėkmingai pratęsta", pasirinktaKnyga.Pavadinimas, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            */
        }

        private void ucScanBook1_Load(object sender, EventArgs e)
        {

        }
    }
}
