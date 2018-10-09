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


namespace Virtual_librarian
{
    public partial class UCLogin : MetroFramework.Controls.MetroUserControl
    {
        private MainForm mainForm;
        //Declare variables
        MCvFont font = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_TRIPLEX, 0.6d, 0.6d);
        HaarCascade faceDetected;
        Image<Bgr, byte> Frame;
        Capture camera;

        Image<Gray, byte> result;
        Image<Gray, byte> trainedFace = null;
        Image<Gray, byte> grayFace = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<String> labels = new List<String>();
        List<String> Users = new List<String>();
        int Count, NumLables, t;
        String name, names = null;


        public UCLogin(MainForm mainForma)
        {
            InitializeComponent();
            mainForm = mainForma;
            //HarrCascade is for face detection
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"x86\haarcascade_frontalface_default.xml");

            faceDetected = new HaarCascade(path);
            try
            {
                string LabelsInf = File.ReadAllText(Application.StartupPath + "Faces/Faces.txt");
                string[] Labels = LabelsInf.Split(',');
                //The first label before , will be the number of faces saved
                NumLables = Convert.ToInt16(Labels[0]);
                Count = NumLables;
                string FaceLoad;
                for (int i = 1; i < NumLables + 1; i++)
                {
                    FaceLoad = "face" + i + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/Faces/Faces.txt"));
                    labels.Add(Labels[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nothing in the database");
            }
        }

        private void btnTakePicture_Click(object sender, EventArgs e)
        {
            if (camera == null)
            {
                camera = new Capture(0);

            }
            camera.Start();
            Application.Idle += new EventHandler(FrameProcedure);
        }
        private void FrameProcedure(object sender, EventArgs e)
        {
            if (camera != null)
            {
                Users.Add("");
                Frame = camera.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                grayFace = Frame.Convert<Gray, Byte>();
                MCvAvgComp[][] facesDetectedNow = grayFace.DetectHaarCascade(faceDetected, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
                foreach (MCvAvgComp f in facesDetectedNow[0])
                {
                    result = Frame.Copy(f.rect).Convert<Gray, Byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    Frame.Draw(f.rect, new Bgr(Color.Green), 3);
                    if (trainingImages.ToArray().Length != 0)
                    {
                        MCvTermCriteria termCriterias = new MCvTermCriteria(Count, 0.001);
                        EigenObjectRecognizer recognizer = new EigenObjectRecognizer(trainingImages.ToArray(), labels.ToArray(), 1500, ref termCriterias);
                        //name = recognizer.Recognize(result);
                        //Frame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.Red));

                    }
                    //Users[t - 1] = name;
                    Users.Add("");
                }
                cameraBox.Image = Frame.ToBitmap();
                names = "";
                Users.Clear();
            }


        }
        private void btnLogInWIthName_Click(object sender, EventArgs e)
        {
            Zmogus prisijungesZmogus = mainForm.humanDBHelper.getZmogusByNameSurnamePassword(txtVardas.Text, txtPavarde.Text, txtSlaptazodis.Text);
            if (camera != null)
            {
                camera.Dispose();
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
            if (camera != null)
            {
                camera.Dispose();
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
