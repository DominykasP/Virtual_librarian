using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Reflection;
using System.IO;
using Virtual_librarian.Camera;
using System.Drawing;
using Virtual_librarian.DB_helpers;

namespace Virtual_librarian.Camera
{
    class FaceRegistration
    {
        //Webcam'o kintamieji
        Capture camera;
        PictureBox picCamera;
        PictureBox picFace;
        Image<Bgr, byte> currentFrame;

        //Visų naudotojų info
        int numberOfElements;
        List<Image> usersImages;
        List<String> usersIds;

        //Face recognition'o kintamieji
        MCvFont font;
        HaarCascade faceHaarCascase;
        string pathToHaarCascade = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"x86\haarcascade_frontalface_default.xml");
        Image<Gray, byte> faceImage;
        Image<Gray, byte> grayFrame;
        MCvAvgComp[][] facesDetectedNow;
        public int howManyImagesOfOnePerson;
        Timer timer;

        //Event'o kintamieji
        public event EventHandler OnPictureTaken;

        public FaceRegistration(int howManyImagesOfOnePerson)
        {
            picFace = new PictureBox();

            usersImages = new List<Image>();
            usersIds = new List<String>();

            font = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_TRIPLEX, 0.6d, 0.6d);
            faceHaarCascase = new HaarCascade(pathToHaarCascade);
            timer = new Timer();

            this.howManyImagesOfOnePerson = howManyImagesOfOnePerson;

            GetRegisteredUsersCount();
        }

        private void GetRegisteredUsersCount()
        {
            try
            {
                usersIds = DarbasSuFailais.NuskaitytiIrasytusID(PathsToFiles.pathToFacesFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Klaida pasiekiant veidų failus", "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Display(PictureBox pictureBox, Capture capture)
        {
            picCamera = pictureBox;
            camera = capture;

            if (camera != null)
            {
                Application.Idle += new EventHandler(FrameProcedure);
            }
        }

        private void FrameProcedure(object sender, EventArgs e)
        {
            if (camera != null)
            {
                //Paima iš kameros frame ir padaro jį juodai baltą
                currentFrame = camera.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                grayFrame = currentFrame.Convert<Gray, Byte>();

                //Detektina veidus frame
                facesDetectedNow = grayFrame.DetectHaarCascade(faceHaarCascase, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
                foreach (MCvAvgComp faceData in facesDetectedNow[0])
                {
                    faceImage = currentFrame.Copy(faceData.rect).Convert<Gray, Byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    currentFrame.Draw(faceData.rect, new Bgr(Color.Green), 3);
                    picFace.Image = faceImage.ToBitmap();
                }
                picCamera.Image = currentFrame.ToBitmap();
            }
        }

        public void saveFaceImages()
        {
            timer.Interval = 500;
            timer.Enabled = true;

            timer.Tick += Timer_Tick;
        }

        public List<Image> getFaceImages()
        {
            return usersImages;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (facesDetectedNow[0].Count() >= 1) //Jei aptiktas bent vienas veidas
            {
                usersImages.Add(picFace.Image);
                OnPictureTaken(this, EventArgs.Empty);
            }

            if (usersImages.Count == howManyImagesOfOnePerson)
            {
                timer.Enabled = false;
            }
        }

        public void StopRecognition()
        {
            Application.Idle -= FrameProcedure;
            timer.Enabled = false;
        }

        public void ContinueRecognition(PictureBox pictureBox, Capture capture)
        {
            //GetRegisteredUsersCount();
            Display(pictureBox, capture);
        }

    }
}
