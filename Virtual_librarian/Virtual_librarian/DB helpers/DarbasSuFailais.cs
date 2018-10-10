using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Virtual_librarian.DB_helpers
{
    public static class DarbasSuFailais
    {
        public static bool IrasytiIFaila<T>(string keliasIFaila, T objektas)
        {
            XmlSerializer xmlSerz = new XmlSerializer(typeof(T));
            StreamWriter streamWrt = new StreamWriter(keliasIFaila);
            xmlSerz.Serialize(streamWrt, objektas);
            streamWrt.Close();
            return File.Exists(keliasIFaila);
        }

        public static T NuskaitytiIsFailo<T>(string keliasIFaila)
        {
            Object rezultatas;

            if (File.Exists(keliasIFaila))
            {
                XmlSerializer xmlSerz = new XmlSerializer(typeof(T));
                StreamReader streamRead = new StreamReader(keliasIFaila);
                rezultatas = (T)xmlSerz.Deserialize(streamRead);
                streamRead.Close();
                return (T)rezultatas;
            }
            else
            {
                return default(T);
            }
        }
    }
}
