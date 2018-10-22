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

        public HumanDBHelper()
        {
            naudotojai = DarbasSuFailais.NuskaitytiIsFailo<List<Zmogus>>(PathsToFiles.pathToUsersFile);
        }

        public bool addNewZmogus(Zmogus zmogus)
        {
            naudotojai.Add(zmogus);

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
            Zmogus rastasZmogus = naudotojai.Find(zmogus => zmogus.Id == ID);

            return rastasZmogus;
        }

        public Zmogus getZmogusByNameSurnamePassword(string name, string surname, string password)
        {
            Zmogus rastasZmogus = naudotojai.Find(zmogus => zmogus.Name.Equals(name) && zmogus.Surname.Equals(surname) && zmogus.Password.Equals(password));
            
            return rastasZmogus;
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
