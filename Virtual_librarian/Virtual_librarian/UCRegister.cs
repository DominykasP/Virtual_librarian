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
using MetroFramework;
using Virtual_librarian.Camera;

namespace Virtual_librarian
{
    public partial class UCRegister : MetroFramework.Controls.MetroUserControl
    {
        private MainForm mainForm;
        UseCamera camera;
        FaceRegistration faceRegistration;


        public UCRegister(MainForm mainForma)
        {
            InitializeComponent();
            mainForm = mainForma;

            camera = new UseCamera();
            faceRegistration = new FaceRegistration(10);

            if (camera.Camera == null)
            {
                camera.TurnOn();

                faceRegistration.Display(picCamera, camera.Camera);
            }
        }

        private void UCRegister_Load(object sender, EventArgs e)
        {
            btnTakePicture.Visible = true;
            lblTakingPictures.Visible = false;
            prbTakingPictures.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (camera.Camera != null)
            {
                camera.TurnOff();
            }
            faceRegistration.StopRecognition();

            UCChooseLogin ucChooseLogin = new UCChooseLogin(mainForm);
            ucChooseLogin.Dock = DockStyle.Bottom;
            mainForm.Controls.Remove(this);
            mainForm.Controls.Add(ucChooseLogin);
        }

        private void btnRegistruoti_Click(object sender, EventArgs e)
        {
            if (camera.Camera != null)
            {
                camera.TurnOff();
            }
            faceRegistration.StopRecognition();

            DateTime gimimoData = dtpGimimoData.Value;
            if (camera.Camera != null)
            {
                camera.TurnOff();
            }
            // if(String.IsNullOrEmpty(txtVardas.Text) && String.IsNullOrEmpty(txtPavarde.Text) && String.IsNullOrEmpty(txtSlaptazodis.Text) && String.IsNullOrEmpty(txtTelefonoNr.Text) && String.IsNullOrEmpty(txtEmail.Text))
            // {
            System.Text.RegularExpressions.Regex sablonas = new System.Text.RegularExpressions.Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"); //@, nes reikia kad būtų \. //Reikia System.Text.RegularExpressions. nes kitaip konfliktina su Emgu.cv

            if (!sablonas.IsMatch(txtEmail.Text)) //Jei neteisingas emailas
            {
                MetroMessageBox.Show(this,"Neteisingai įvestas elektroninis paštas","Klaida",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtEmail.Clear();
                txtEmail.Focus();
            }
            else
            {
                Zmogus naujasZmogus = new Zmogus(mainForm.humanDBHelper.getNextId(), txtVardas.Text, txtPavarde.Text, txtSlaptazodis.Text, gimimoData, txtTelefonoNr.Text, txtEmail.Text);
                if (mainForm.humanDBHelper.addNewZmogus(naujasZmogus) == true)
                {
                    UCMainUserMeniu ucMainUserMeniu = new UCMainUserMeniu(mainForm, naujasZmogus);
                    ucMainUserMeniu.Dock = DockStyle.Bottom;
                    mainForm.Controls.Remove(this);
                    mainForm.Controls.Add(ucMainUserMeniu);
                }
                else
                {
                    MetroMessageBox.Show(this, "Klaida sukuriant naują vartotoją. Prašome kreiptis į sistemos administratorių.", "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // }
        }

        private void btnTakePicture_Click(object sender, EventArgs e)
        {
            btnTakePicture.Visible = false;
            prbTakingPictures.Visible = true;
            lblTakingPictures.Visible = true;

            faceRegistration.saveFaceImages();
        }
    }
}
