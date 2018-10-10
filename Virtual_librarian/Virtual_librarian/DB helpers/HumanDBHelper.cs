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
            naudotojai = DarbasSuFailais.NuskaitytiIsFailo<List<Zmogus>>("..\\..\\Duomenu failai\\naudotojai.xml");
        }

        public bool addNewZmogus(Zmogus zmogus)
        {
            naudotojai.Add(zmogus);

            return DarbasSuFailais.IrasytiIFaila<List<Zmogus>>("..\\..\\Duomenu failai\\naudotojai.xml", naudotojai);
        }

        public bool deleteZmogus(Zmogus zmogus)
        {
            bool arSekmingai = naudotojai.Remove(zmogus);
            if (arSekmingai == true)
            {
                return DarbasSuFailais.IrasytiIFaila<List<Zmogus>>("..\\..\\Duomenu failai\\naudotojai.xml", naudotojai);
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

            return DarbasSuFailais.IrasytiIFaila<List<Zmogus>>("..\\..\\Duomenu failai\\naudotojai.xml", naudotojai);
        }

        public Zmogus getZmogusByID(int ID)
        {
            foreach (Zmogus zmogus in naudotojai)
            {
                if (zmogus.Id == ID)
                {
                    return zmogus;
                }
            }

            return null;
        }

        public Zmogus getZmogusByNameSurnamePassword(string name, string surname, string password)
        {
            foreach (Zmogus zmogus in naudotojai)
            {
                if (zmogus.Name.Equals(name) && zmogus.Surname.Equals(surname) && zmogus.Password.Equals(password))
                {
                    return zmogus;
                }
            }

            return null;
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
