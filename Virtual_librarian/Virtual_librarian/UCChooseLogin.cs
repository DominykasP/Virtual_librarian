using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;

namespace Virtual_librarian
{
    public partial class UCChooseLogin : MetroFramework.Controls.MetroUserControl
    {
        private static MainForm mainForm;

        public UCChooseLogin(MainForm mForm)
        {
            InitializeComponent();
            mainForm = mForm;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            UCLogin ucLogin = new UCLogin(mainForm);
            ucLogin.Dock = DockStyle.Bottom;
            mainForm.Controls.Remove(this);
            mainForm.Controls.Add(ucLogin);

            //Automatinis pirmo vartotojo prijungimas
            /*
            LibraryObjects.Person loggedInPerson = ServiceToLibrary.PersonToLibraryObject(mainForm.humanDBHelperByPersonService.GetPersonByID(1));

            if (loggedInPerson != null)
            {
                UCMainUserMeniu ucMainUserMeniu = new UCMainUserMeniu(mainForm, loggedInPerson);
                ucMainUserMeniu.Dock = DockStyle.Bottom;
                mainForm.Controls.Remove(this);
                mainForm.Controls.Add(ucMainUserMeniu);
            }
            */
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            UCRegister ucRegister = new UCRegister(mainForm);
            ucRegister.Dock = DockStyle.Bottom;
            mainForm.Controls.Remove(this);
            mainForm.Controls.Add(ucRegister);
        }
    }
}
