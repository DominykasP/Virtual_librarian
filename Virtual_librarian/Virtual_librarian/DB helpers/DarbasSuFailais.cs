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

        //----------------------------------//
        private static List<String> naudotojuID;

        private static void NustatytiNaudotojuID(string keliasIFaila)
        {
            naudotojuID = NuskaitytiIsFailo<List<String>>(keliasIFaila);
        }

        public static List<String> NuskaitytiIrasytusID(string keliasIFaila) //"..\\..\\Faces\\faces.txt"
        {
            NustatytiNaudotojuID(keliasIFaila);
            return naudotojuID;
        }

        public static List<Image<Gray, byte>> NuskaitytiIrasytasNuotraukas(string keliasIFolderi) //"..\\..\\Faces\\"
        {
            if (naudotojuID == null)
            {
                return null;
            }
            List<Image<Gray, byte>> nuotraukos = new List<Image<Gray, byte>>();

            for (int i = 1; i <= naudotojuID.Count; i++)
            {
                nuotraukos.Add(new Image<Gray, byte>(keliasIFolderi + "face" + i + ".bmp"));
            }

            return nuotraukos;

        }

        public static void IrasytiID(string keliasIFaila, int naudotojoID, int kiekKartu) //"..\\..\\Faces\\Faces.txt"
        {
            for (int i = 0; i < kiekKartu; i++)
            {
                naudotojuID.Add(naudotojoID.ToString());
            }
            IrasytiIFaila<List<String>>(keliasIFaila, naudotojuID);
        }

        public static void IrasytiNuotraukas(string keliasIFolderi, List<Image> nuotraukuSarasas, int naudotojoID) //"..\\..\\Faces\\face"
        {
            int nuotraukosNumeris = naudotojuID.Count;

            foreach (Image nuotrauka in nuotraukuSarasas)
            {
                nuotrauka.Save(keliasIFolderi + "face" + nuotraukosNumeris-- + ".bmp");
            }
        }

    }
}
