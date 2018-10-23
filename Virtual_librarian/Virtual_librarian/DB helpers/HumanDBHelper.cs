using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Virtual_librarian.DB_helpers
{
    public class HumanDBHelper : HumanDBHelperInterface
    {
        private List<Zmogus> naudotojai;
       // ZmoniuKolekcija<Zmogus> naudotojuKl = new ZmoniuKolekcija<Zmogus>();
        private int i = 0;

        public HumanDBHelper()
        {
            //naudotojai = DarbasSuFailais.NuskaitytiIsFailo<List<Zmogus>>("..\\..\\Duomenu failai\\naudotojai.xml");
            naudotojai = DarbasSuFailais.NuskaitytiIsFailo<List<Zmogus>>(PathsToFiles.pathToUsersFile);
            /*while (i < naudotojai.Count)//pridedam knygas i indeksuota klase
            {
                naudotojuKl.prideti(naudotojai[i++]);
            }
            //naudotojaiKL = DarbasSuFailais.NuskaitytiIsFailo<ZmoniuKolekcija<Zmogus>>("..\\..\\Duomenu failai\\naudotojai.xml");*/
        }

        public bool addNewZmogus(Zmogus zmogus)
        {
            naudotojai.Add(zmogus);
           // naudotojuKl.prideti(zmogus);
           // return DarbasSuFailais.IrasytiIFaila<List<Zmogus>>("..\\..\\Duomenu failai\\naudotojai.xml", naudotojai);
            return DarbasSuFailais.IrasytiIFaila<List<Zmogus>>(PathsToFiles.pathToUsersFile, naudotojai);
        }


        public bool deleteZmogus(Zmogus zmogus)
        {
            bool arSekmingai = naudotojai.Remove(zmogus);
            if (arSekmingai == true)
            {
                return DarbasSuFailais.IrasytiIFaila<List<Zmogus>>(PathsToFiles.pathToUsersFile, naudotojai);
            }
            else
            {
                return false;
            }
        }

        public bool editZmogus(Zmogus oldZmogus, Zmogus newZmogus)
        {
            bool arSekmingai = naudotojai.Remove(oldZmogus);
            if (arSekmingai == true)
            {
                naudotojai.Add(newZmogus);
            }

            return DarbasSuFailais.IrasytiIFaila<List<Zmogus>>(PathsToFiles.pathToUsersFile, naudotojai);
        }

        public Zmogus getZmogusByID(int ID)
        {
            //Zmogus rastasZmogus = naudotojai.Find(zmogus => zmogus.Id == ID);
            Zmogus rastasNaudotojas = new Zmogus();
            var naudotojuSarasas = naudotojai.OfType<Zmogus>();
            var rastiNaudotojai = from naudotojas in naudotojuSarasas
                                  where (naudotojas.Id == ID)
                                  select naudotojas;
            foreach (var naudotojas in rastiNaudotojai)
            {
                rastasNaudotojas = naudotojas;
            }


            return rastasNaudotojas;
        }

        public Zmogus getZmogusByNameSurnamePassword(string name, string surname, string password)
        {
            //Zmogus rastasZmogus = naudotojai.Find(zmogus => zmogus.Name.Equals(name) && zmogus.Surname.Equals(surname) && zmogus.Password.Equals(password));
            Zmogus rastasNaudotojas = new Zmogus();
            var naudotojuSarasas = naudotojai.OfType<Zmogus>();
            var rastiNaudotojai = from naudotojas in naudotojuSarasas
                                  where naudotojas.Name.Equals(name) && naudotojas.Surname.Equals(surname) && naudotojas.Password.Equals(password)
                                  select naudotojas;
            foreach (var naudotojas in rastiNaudotojai)
            {
                rastasNaudotojas = naudotojas;
            }
            return rastasNaudotojas;
        }

        public int getNextId()
        {
            int maks = 0;
            foreach (Zmogus zmogus in naudotojai)
            {
                if (zmogus.Id > maks)
                {
                    maks = zmogus.Id;
                }
            }
            return maks+1;
        }
    }
}
