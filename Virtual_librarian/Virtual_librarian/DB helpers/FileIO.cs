using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Virtual_librarian.DB_helpers
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
    }
}
