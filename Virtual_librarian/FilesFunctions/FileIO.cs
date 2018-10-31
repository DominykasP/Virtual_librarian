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
        public static bool FileWrite<T>(string pathToFile, T objectToWrite)
        {
            XmlSerializer xmlSerz = new XmlSerializer(typeof(T));
            StreamWriter streamWrt = new StreamWriter(pathToFile);
            xmlSerz.Serialize(streamWrt, objectToWrite);
            streamWrt.Close();
            return File.Exists(pathToFile);
        }

        public static T FileRead<T>(string pathToFile)
        {
            Object result;

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
        }

        private static List<String> userID;

        private static void SetUserID(string pathToFile)
        {
            userID = FileRead<List<String>>(pathToFile);
        }

        public static List<String> ReadID(string pathToFile) //"..\\..\\Faces\\faces.txt"
        {
            SetUserID(pathToFile);
            return userID;
        }

        public static List<Image<Gray, byte>> ReadPhotos(string pathToFolder) //"..\\..\\Faces\\"
        {
            if (userID == null)
            {
                return null;
            }
            List<Image<Gray, byte>> photos = new List<Image<Gray, byte>>();

            for (int i = 1; i <= userID.Count; i++)
            {
                photos.Add(new Image<Gray, byte>(pathToFolder + "face" + i + ".bmp"));
            }

            return photos;

        }

        public static void WriteID(string pathToFile, int userID, int count) //"..\\..\\Faces\\Faces.txt"
        {
            for (int i = 0; i < count; i++)
            {
                FileIO.userID.Add(userID.ToString());
            }
            FileWrite(pathToFile, FileIO.userID);
        }

        public static void WritePhotos(string pathToFolder, List<Image> photoList, int userID) //"..\\..\\Faces\\face"
        {
            int photoNumber = FileIO.userID.Count;

            foreach (Image photo in photoList)
            {
                photo.Save(pathToFolder + "face" + photoNumber-- + ".bmp");
            }
        }
    }
}
