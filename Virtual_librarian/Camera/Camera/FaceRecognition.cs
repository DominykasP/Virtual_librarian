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
using System.Reflection;
using System.IO;
using Camera;
using Database;
using FilesFunctions;

namespace Camera
{
    public class FaceRecognition
    {
        //Webcam'o kintamieji
        Capture camera;
        PictureBox cameraBox;
        Image<Bgr, byte> currentFrame;

        //Visų naudotojų info
        int numberOfElements;
        List<Image<Gray, byte>> usersImages;
        public List<String> usersIds;

        //Face recognition'o kintamieji
        MCvFont font;
        HaarCascade faceHaarCascase;
        string pathToHaarCascade = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\..\Camera\x86\haarcascade_frontalface_default.xml");
        Image<Gray, byte> faceImage;
        Image<Gray, byte> grayFrame;

        //Event'o kintamieji
        public delegate void FoundHandler<RecognisedPersonEventArgs>(object sender, RecognisedPersonEventArgs e);
        public event FoundHandler<RecognisedPersonEventArgs> OnFoundRegisteredFace;

        public FaceRecognition()
        {
            usersImages = new List<Image<Gray, byte>>();
            usersIds = new List<String>();

            font = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_TRIPLEX, 0.6d, 0.6d);
            faceHaarCascase = new HaarCascade(pathToHaarCascade);

            GetAllRegisteredUsersInfo();
        }

        private void GetAllRegisteredUsersInfo()
        {
            usersIds = FileIO.ReadID(PathsToFiles.pathToFacesFile);
            usersImages = FileIO.ReadPhotos(PathsToFiles.pathToFacesFolder);
        }

        public void Display(PictureBox pictureBox, Capture capture)
        {
            cameraBox = pictureBox;
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
                MCvAvgComp[][] facesDetectedNow = grayFrame.DetectHaarCascade(faceHaarCascase, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
                foreach (MCvAvgComp faceData in facesDetectedNow[0])
                {
                    faceImage = currentFrame.Copy(faceData.rect).Convert<Gray, Byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    currentFrame.Draw(faceData.rect, new Bgr(Color.Green), 3);

                    //Bando detektintus veidus atpažinti
                    if (usersImages.ToArray().Length != 0)
                    {
                        MCvTermCriteria termCriterias = new MCvTermCriteria(usersImages.Count, 0.001);
                        EigenObjectRecognizer recognizer = new EigenObjectRecognizer(usersImages.ToArray(), usersIds.ToArray(), 1500, ref termCriterias);
                        EigenObjectRecognizer.RecognitionResult recognizedId = recognizer.Recognize(faceImage);

                        //Jei atpažino
                        if (recognizedId != null)
                        {
                            //currentFrame.Draw(recognizedId.Label, ref font, new Point(faceData.rect.X - 2, faceData.rect.Y - 2), new Bgr(Color.Red)); //Nereikia piesti prie zmogaus jo id, tą padarys messageboxas

                            //Šaukia event'ą FoundRegisteredFace, su kuriuo vėliau dirbs UCLogin
                            OnFoundRegisteredFace(this, new RecognisedPersonEventArgs(recognizedId.Label));
                        }

                    }
                }
                cameraBox.Image = currentFrame.ToBitmap();
            }
        }

        public void StopRecognition()
        {
            Application.Idle -= FrameProcedure;
        }

        public void ContinueRecognition(PictureBox pictureBox, Capture capture)
        {
            //GetAllRegisteredUsersInfo();
            Display(pictureBox, capture);
        }

    }
}
