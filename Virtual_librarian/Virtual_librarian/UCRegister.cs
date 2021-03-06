﻿using System;
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
using Camera;
using Database;
using FilesFunctions;
using LibraryObjects;

namespace Virtual_librarian
{
    delegate void ErrorMessageBoxPrinter<T>(T topText, T message);
    public partial class UCRegister : MetroFramework.Controls.MetroUserControl
    {
        private MainForm mainForm;
        UseCamera camera;
        FaceRegistration faceRegistration;
        int imageCountPerPerson = 5;
        

        public UCRegister(MainForm mainForma)
        {
            InitializeComponent();
            mainForm = mainForma;

            camera = new UseCamera();
            faceRegistration = new FaceRegistration(imageCountPerPerson);

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
            faceRegistration.StopRecognition();
            if (camera.Camera != null)
            {
                camera.TurnOff();
            }

            UCChooseLogin ucChooseLogin = new UCChooseLogin(mainForm);
            ucChooseLogin.Dock = DockStyle.Bottom;
            mainForm.Controls.Remove(this);
            mainForm.Controls.Add(ucChooseLogin);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            ErrorMessageBoxPrinter<string> errorPrinter = delegate (string topText, string message)
            {
                MetroMessageBox.Show(this, topText, message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            // if(String.IsNullOrEmpty(txtVardas.Text) && String.IsNullOrEmpty(txtPavarde.Text) && String.IsNullOrEmpty(txtSlaptazodis.Text) && String.IsNullOrEmpty(txtTelefonoNr.Text) && String.IsNullOrEmpty(txtEmail.Text))
            // {
            System.Text.RegularExpressions.Regex pattern = new System.Text.RegularExpressions.Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"); //@, nes reikia kad būtų \. //Reikia System.Text.RegularExpressions. nes kitaip konfliktina su Emgu.cv

            if (!pattern.IsMatch(txtEmail.Text)) //Jei neteisingas emailas
            {
                errorPrinter("Neteisingai įvestas elektroninis paštas", "Klaida");
                txtEmail.Clear();
                txtEmail.Focus();
            }
            else if (prbTakingPictures.Value != imageCountPerPerson)
            {
                MetroMessageBox.Show(this, "Norint užsiregistruoti dar reikia nusifotografuoti", "Registracija", MessageBoxButtons.OK);
            }
            else
            {
                faceRegistration.StopRecognition();
                if (camera.Camera != null)
                {
                    camera.TurnOff();
                }

                int newID = mainForm.humanDBHelperByPersonService.getNextId();

                List<Image> userImages = faceRegistration.getFaceImages();
                FileIO.WriteID(PathsToFiles.pathToFacesFile, newID, imageCountPerPerson);
                FileIO.WritePhotos(PathsToFiles.pathToFacesFolder, userImages, newID);

                Person newPerson = new Person(newID, txtName.Text, txtSurname.Text, txtPassword.Text, dtpBirthDate.Value, txtPhoneNumber.Text, email: txtEmail.Text);

                if (mainForm.humanDBHelperByPersonService.AddNewPerson(newID, txtName.Text, txtSurname.Text, txtPassword.Text, dtpBirthDate.Value, txtPhoneNumber.Text, email: txtEmail.Text) == true)
                {
                    UCMainUserMeniu ucMainUserMeniu = new UCMainUserMeniu(mainForm, newPerson);
                    ucMainUserMeniu.Dock = DockStyle.Bottom;
                    mainForm.Controls.Remove(this);
                    mainForm.Controls.Add(ucMainUserMeniu);
                }
                else
                {
                    errorPrinter("Klaida sukuriant naują vartotoją. Prašome kreiptis į sistemos administratorių.", "Klaida");
                }
            }
            // }
        }

        private void btnTakePicture_Click(object sender, EventArgs e)
        {
            btnTakePicture.Visible = false;
            prbTakingPictures.Visible = true;
            lblTakingPictures.Visible = true;

            prbTakingPictures.Maximum = imageCountPerPerson;
            prbTakingPictures.Step = 1;

            faceRegistration.saveFaceImages();
            faceRegistration.OnPictureTaken += FaceRegistration_OnPictureTaken;
        }

        private void FaceRegistration_OnPictureTaken(object sender, EventArgs e)
        {
            prbTakingPictures.Value += prbTakingPictures.Step; //Padidinam vienu progress bar'ą
            if (prbTakingPictures.Value == imageCountPerPerson) //Jei padarė reikiamą kiekį nuotraukų
            {
                faceRegistration.StopRecognition();
                camera.TurnOff();
                picCamera.Image = Properties.Resources.avatar;
                lblTakingPictures.Text = "Nuotraukos sėkmingai išsaugotos";
            }
        }
    }
}