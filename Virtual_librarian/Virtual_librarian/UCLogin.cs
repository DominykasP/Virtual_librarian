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
using System.Reflection;
using System.IO;
using MetroFramework;

namespace Virtual_librarian
{
    public partial class UCLogin : MetroFramework.Controls.MetroUserControl
    {
        private MainForm mainForm;
        FaceRecognition faceRecognition = new FaceRecognition();
        UseCamera camera = new UseCamera();

        public UCLogin(MainForm mainForma)
        {
            InitializeComponent();
            mainForm = mainForma;
            faceRecognition.UseFaceRecognition();
        }

        private void btnTakePicture_Click(object sender, EventArgs e)
        {
            if (camera.Camera == null)
            {              
                camera.turnOn();
             
                faceRecognition.Display(cameraBox, camera.Camera);              
            }           
        }
        
        private void btnLogInWIthName_Click(object sender, EventArgs e)
        {
            Person LoggedInPerson = mainForm.humanDBHelper.getPersonByNameSurnamePassword(txtVardas.Text, txtPavarde.Text, txtSlaptazodis.Text);
            camera.TurnOff();
            faceRecognition.Display(cameraBox, camera.Camera);
            if (LoggedInPerson != null)
            {
                UCMainUserMeniu ucMainUserMeniu = new UCMainUserMeniu(mainForm, LoggedInPerson);
                ucMainUserMeniu.Dock = DockStyle.Bottom;
                mainForm.Controls.Remove(this);
                mainForm.Controls.Add(ucMainUserMeniu);
            }
            else
            {
                MetroMessageBox.Show(this,"Neteisingai įvesti prisijungimo duomenys","Prisijungimo klaida",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            camera.TurnOff();
            faceRecognition.Display(cameraBox, camera.Camera);
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
