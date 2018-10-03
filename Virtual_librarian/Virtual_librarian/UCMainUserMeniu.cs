using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Virtual_librarian
{
    public partial class UCMainUserMeniu : MetroFramework.Controls.MetroUserControl
    {
        private MainForm mainForm;
        private Zmogus prisijungesZmogus;

        public UCMainUserMeniu(MainForm mainForma, Zmogus prisijunges)
        {
            mainForm = mainForma;
            prisijungesZmogus = prisijunges;

            InitializeComponent();

            pakrautiKnyguKataloga();
        }

        private void UCMainUserMeniu_Load(object sender, EventArgs e)
        {
            lblNaudotojoVardas.Text = prisijungesZmogus.Name;
        }

        private void btnAtsijungti_Click(object sender, EventArgs e)
        {
            mainForm.Controls.Remove(this);

            UCChooseLogin ucChooseLogin = new UCChooseLogin(mainForm);
            ucChooseLogin.Dock = DockStyle.Bottom;
            mainForm.Controls.Add(ucChooseLogin);
        }

        private void pakrautiKnyguKataloga()
        {
            BindingList<Knyga> visosKnygos = new BindingList<Knyga>(mainForm.bookDBHelper.gautiVisasKnygas());
            BindingSource visuKnyguSource = new BindingSource(visosKnygos, null);
            grdAllBooks.DataSource = visuKnyguSource;
            grdAllBooks.Columns["id"].Visible = false; //Paslepiu, kad vartotojas nematytu knygos id


        }
    }
}
