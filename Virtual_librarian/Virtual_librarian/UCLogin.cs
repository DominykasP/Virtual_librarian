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
        FaceRecognition faceRecognition;
        UseCamera camera;

        public UCLogin(MainForm mainForma)
        {
            InitializeComponent();
            mainForm = mainForma;

            faceRecognition = new FaceRecognition();
            camera = new UseCamera();
        }

        private void btnTakePicture_Click(object sender, EventArgs e)
        {
            if (camera.Camera == null)
            {
                camera.TurnOn();

                faceRecognition.Display(cameraBox, camera.Camera);

                faceRecognition.OnFoundRegisteredFace += FaceRecognition_OnFoundRegisteredFace;
            }
        }

        private void FaceRecognition_OnFoundRegisteredFace(object sender, Camera.RecognisedPersonEventArgs e) //Suveikia, kai atpažįsta žmogų iš foto
        {
            faceRecognition.StopRecognition();
            camera.TurnOff();

            int recognisedID;
            Int32.TryParse(e.recognisedID, out recognisedID);
            Person loggedInPerson = mainForm.humanDBHelper.GetPersonByID(recognisedID);

            if (loggedInPerson != null)
            {
                DialogResult dr = MetroMessageBox.Show(this, "Sėkmingai atpažintas naudotojas " + loggedInPerson.Name + " " + loggedInPerson.Surname + "\nAr tai jūs?", "Prisijungimas", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    UCMainUserMeniu ucMainUserMeniu = new UCMainUserMeniu(mainForm, loggedInPerson);
                    ucMainUserMeniu.Dock = DockStyle.Bottom;
                    mainForm.Controls.Remove(this);
                    mainForm.Controls.Add(ucMainUserMeniu);
                }
                else
                {
                    camera.TurnOn();
                    faceRecognition.ContinueRecognition(cameraBox, camera.Camera);
                }
            }
        }

        private void btnLogInWIthName_Click(object sender, EventArgs e)
        {
            Person loggedInPerson = mainForm.humanDBHelper.GetPersonByNameSurnamePassword(txtVardas.Text, txtPavarde.Text, txtSlaptazodis.Text);
            camera.TurnOff();
            faceRecognition.StopRecognition();

            if (loggedInPerson != null)
            {
                UCMainUserMeniu ucMainUserMeniu = new UCMainUserMeniu(mainForm, loggedInPerson);
                ucMainUserMeniu.Dock = DockStyle.Bottom;
                mainForm.Controls.Remove(this);
                mainForm.Controls.Add(ucMainUserMeniu);
            }
            else
            {
                MetroMessageBox.Show(this, "Neteisingai įvesti prisijungimo duomenys", "Prisijungimo klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            camera.TurnOff();
            faceRecognition.StopRecognition();

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
