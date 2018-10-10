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
    public partial class UCLogin : MetroFramework.Controls.MetroUserControl
    {
        private MainForm mainForm;
        private VideoCapture capture;
        Mat m;

        public UCLogin(MainForm mainForma)
        {
            InitializeComponent();
            mainForm = mainForma;
        }

        private void btnTakePicture_Click(object sender, EventArgs e)
        {
            if (capture == null)
            {
                capture = new VideoCapture(0);

            }
            capture.ImageGrabbed += Capture_ImageGrabbed1;
            capture.Start();
            //Veido atpažinimo kodas
        }
        private void Capture_ImageGrabbed1(object sender, EventArgs e)
        {
            try
            {

                m = new Mat();
                capture.Retrieve(m);
                pictureBox2.Image = m.ToImage<Bgr, byte>().ToBitmap();
            }
            catch (Exception)
            {

            }
        }
        private void btnLogInWIthName_Click(object sender, EventArgs e)
        {
            Zmogus prisijungesZmogus = mainForm.humanDBHelper.getZmogusByNameSurnamePassword(txtVardas.Text, txtPavarde.Text, txtSlaptazodis.Text);
            if (capture != null)
            {
                capture.Dispose();
            }
            if (prisijungesZmogus != null)
            {
                UCMainUserMeniu ucMainUserMeniu = new UCMainUserMeniu(mainForm, prisijungesZmogus);
                ucMainUserMeniu.Dock = DockStyle.Bottom;
                mainForm.Controls.Remove(this);
                mainForm.Controls.Add(ucMainUserMeniu);
            }
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void UCLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
