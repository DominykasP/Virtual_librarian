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
    public partial class UCLogin : MetroFramework.Controls.MetroUserControl
    {
        private MainForm mainForm;

        public UCLogin(MainForm mainForma)
        {
            InitializeComponent();
            mainForm = mainForma;
        }

        private void btnTakePicture_Click(object sender, EventArgs e)
        {
            //Veido atpažinimo kodas
        }

        private void btnLogInWIthName_Click(object sender, EventArgs e)
        {
            Zmogus prisijungesZmogus = mainForm.humanDBHelper.getZmogusByNameSurnamePassword(txtVardas.Text, txtPavarde.Text, txtSlaptazodis.Text);
            if (prisijungesZmogus != null)
            {
                UCMainUserMeniu ucMainUserMeniu = new UCMainUserMeniu(mainForm, prisijungesZmogus);
                ucMainUserMeniu.Dock = DockStyle.Bottom;
                mainForm.Controls.Remove(this);
                mainForm.Controls.Add(ucMainUserMeniu);
            }
        }
    }
}
