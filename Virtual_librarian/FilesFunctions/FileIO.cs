using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FilesFunctions
{
    public static class FileIO
    {
        //To read and save information about users and books

        public static bool FileWrite<T>(string pathToFile, T objectToWrite)
        {
            try
            {
                XmlSerializer xmlSerz = new XmlSerializer(typeof(T));
                StreamWriter streamWrt = new StreamWriter(pathToFile);
                xmlSerz.Serialize(streamWrt, objectToWrite);
                streamWrt.Close();
            }
            catch (Exception exc)
            {
                SaveException(Directory.GetCurrentDirectory() + @"\errors.txt", exc.Message, exc.Source);
            }
            return File.Exists(pathToFile);
        }

        public static T FileRead<T>(string pathToFile)
        {
            Object result = default(T);

            /*
            if (File.Exists(pathToFile))
            {
                XmlSerializer xmlSerz = new XmlSerializer(typeof(T));
                StreamReader streamRead = new StreamReader(pathToFile);
                result = (T)xmlSerz.Deserialize(streamRead);
                streamRead.Close();
                return (T)result;
            }
            else
            {
                return default(T);
            }
            */
            try
            {
                XmlSerializer xmlSerz = new XmlSerializer(typeof(T));
                StreamReader streamRead = new StreamReader(pathToFile);
                result = (T)xmlSerz.Deserialize(streamRead);
                streamRead.Close();
            }
            catch (Exception exc)
            {
                SaveException(Directory.GetCurrentDirectory() + @"\errors.txt", exc.Message, exc.Source);
            }

            return (T)result;
        }

        //To read and save information about users - for face recognition

        private static List<String> userIDs;

        private static void SetUserID(string pathToFile)
        {
            try
            {
                userIDs = FileRead<List<String>>(pathToFile);
            }
            catch (Exception exc)
            {
                SaveException(Directory.GetCurrentDirectory() + @"\errors.txt", exc.Message, exc.Source);
            }

        }

        public static List<String> ReadID(string pathToFile) //"..\\..\\Faces\\faces.txt"
        {
            SetUserID(pathToFile);
            return userIDs;
        }

        public static List<Image<Gray, byte>> ReadPhotos(string pathToFolder) //"..\\..\\Faces\\"
        {
            if (userIDs == null)
            {
                return null;
            }
            List<Image<Gray, byte>> photos = new List<Image<Gray, byte>>();

            for (int i = 1; i <= userIDs.Count; i++)
            {
                try
                {
                    photos.Add(new Image<Gray, byte>(pathToFolder + "face" + i + ".bmp"));
                }
                catch (Exception exc)
                {
                    //Nenuskaicius vienos nuotraukos sugriuna visa likusiu nuotrauku tvarka, nebeimanoma vykdyti veido atpazinimo
                    userIDs.Clear();
                    photos.Clear();
                    SaveException(Directory.GetCurrentDirectory() + @"\errors.txt", exc.Message, exc.Source);
                }
            }

            return photos;

        }

        public static void WriteID(string pathToFile, int userID, int count) //"..\\..\\Faces\\Faces.txt"
        {
            for (int i = 0; i < count; i++)
            {
                FileIO.userIDs.Add(userID.ToString());
            }
            FileWrite(pathToFile, FileIO.userIDs);
        }

        public static void WritePhotos(string pathToFolder, List<Image> photoList, int userID) //"..\\..\\Faces\\face"
        {
            int photoNumber = FileIO.userIDs.Count;

            foreach (Image photo in photoList)
            {
                try
                {
                    photo.Save(pathToFolder + "face" + photoNumber-- + ".bmp");
                }
                catch (Exception exc)
                {
                    SaveException(Directory.GetCurrentDirectory() + @"\errors.txt", exc.Message, exc.Source);
                }
            }
        }

        //To save information about exceptions

        public static void SaveException(string pathToFile, string exceptionMessage, string exceptionSource)
        {
            StreamWriter writer = new StreamWriter(pathToFile, true); //True - append
            StringBuilder exceptionText = new StringBuilder();
            exceptionText.Append(DateTime.Now.ToString());
            exceptionText.Append(" in ");
            exceptionText.Append(exceptionSource);
            exceptionText.Append(" - ");
            exceptionText.Append(exceptionMessage);
            writer.WriteLine(exceptionText);
            writer.Close();
        }
    }
}
