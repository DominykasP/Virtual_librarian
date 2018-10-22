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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            DateTime birthDate = dtpGimimoData.Value;
            if (capture != null)
            {
                capture.Dispose();
            }
            // if(String.IsNullOrEmpty(txtVardas.Text) && String.IsNullOrEmpty(txtPavarde.Text) && String.IsNullOrEmpty(txtSlaptazodis.Text) && String.IsNullOrEmpty(txtTelefonoNr.Text) && String.IsNullOrEmpty(txtEmail.Text))
            // {
            System.Text.RegularExpressions.Regex pattern = new System.Text.RegularExpressions.Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"); //@, nes reikia kad būtų \. //Reikia System.Text.RegularExpressions. nes kitaip konfliktina su Emgu.cv

            if (!pattern.IsMatch(txtEmail.Text)) //Jei neteisingas emailas
            {
                MetroMessageBox.Show(this,"Neteisingai įvestas elektroninis paštas","Klaida",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtEmail.Clear();
                txtEmail.Focus();
            }
            else
            {
                Person newPerson = new Person(mainForm.humanDBHelper.getNextId(), txtName.Text, txtSurname.Text, txtPassword.Text, birthDate, txtPhoneNumber.Text, txtEmail.Text);
                if (mainForm.humanDBHelper.AddNewPerson(newPerson) == true)
                {
                    UCMainUserMeniu ucMainUserMeniu = new UCMainUserMeniu(mainForm, newPerson);
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
