using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Virtual_librarian
{
    public partial class UCRegister : MetroFramework.Controls.MetroUserControl
    {
        private MainForm mainForm;
        private Capture capture;
        

        public UCRegister(MainForm mainForma)
        {
            InitializeComponent();
            mainForm = mainForma;
        }

        private void UCRegister_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                capture.Dispose();
            }
            UCChooseLogin ucChooseLogin = new UCChooseLogin(mainForm);
            ucChooseLogin.Dock = DockStyle.Bottom;
            mainForm.Controls.Remove(this);
            mainForm.Controls.Add(ucChooseLogin);
        }

        private void btnRegistruoti_Click(object sender, EventArgs e)
        {
            DateTime gimimoData = dtpGimimoData.Value;
            if (capture != null)
            {
                capture.Dispose();
            }
            // if(String.IsNullOrEmpty(txtVardas.Text) && String.IsNullOrEmpty(txtPavarde.Text) && String.IsNullOrEmpty(txtSlaptazodis.Text) && String.IsNullOrEmpty(txtTelefonoNr.Text) && String.IsNullOrEmpty(txtEmail.Text))
            // {
            Zmogus naujasZmogus = new Zmogus(txtVardas.Text, txtPavarde.Text, txtSlaptazodis.Text, gimimoData, txtTelefonoNr.Text, txtEmail.Text);
                    mainForm.humanDBHelper.addNewZmogus(naujasZmogus);
            
                UCMainUserMeniu ucMainUserMeniu = new UCMainUserMeniu(mainForm, naujasZmogus);
                ucMainUserMeniu.Dock = DockStyle.Bottom;
                mainForm.Controls.Remove(this);
                mainForm.Controls.Add(ucMainUserMeniu);
            
            // }
        }

        private void btnTakePicture_Click(object sender, EventArgs e)
        {
            if (capture == null)
            {
                capture = new Capture(0);

            }
            capture.ImageGrabbed += Capture_ImageGrabbed;
            capture.Start();
        }

        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            try
            {

                
                //pictureBox2.Image = m.ToImage<Bgr, byte>().ToBitmap();
            }
            catch (Exception)
            {

            }
        }
    }
}
