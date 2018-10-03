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
        }

        private void UCMainUserMeniu_Load(object sender, EventArgs e)
        {
            lblNaudotojoVardas.Text = prisijungesZmogus.Name;
        }
    }
}
