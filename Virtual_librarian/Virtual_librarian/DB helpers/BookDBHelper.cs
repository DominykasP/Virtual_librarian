using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_librarian.DB_helpers
{
    public class BookDBHelper : BookDBHelperInterface
    {
        private List<Knyga> knygos;

        public BookDBHelper()
        {
            knygos = DarbasSuFailais.NuskaitytiIsFailo<List<Knyga>>("..\\..\\Duomenu failai\\knygos.xml");
        }

        public Knyga gautiKnygaPagalKodus(string isbn, string kodas)
        {
            Knyga rastaKnyga = knygos.Find(knyga => knyga.Isbn == isbn && knyga.Kodas == kodas);
            return rastaKnyga;
        }

        public List<Knyga> gautiVisasKnygas()
        {
            
            return knygos;

        }

        public List<Knyga> gautiZmogausKnygas(Zmogus zmogus)
        {
            List<Knyga> zmogausKnygos = new List<Knyga>(
                    knygos.FindAll(knyga => knyga.ArPaimta == true && knyga.Skaitytojas.Equals(zmogus))
                );

            return zmogausKnygos;
        }

        public bool grazintiKnyga(Knyga grazinamaKnyga)
        {
            Knyga grazinama = knygos.Find(knyga => knyga.Equals(grazinamaKnyga));
            if (grazinama != null)
            {
                grazinama.grazintiKnyga();

                return DarbasSuFailais.IrasytiIFaila<List<Knyga>>("..\\..\\Duomenu failai\\knygos.xml", knygos);
            }
            else
            {
                return false;
            }
        }

        public List<Knyga> ieskoti(string search)
        {
            List<Knyga> atitinkanciosKnygos = new List<Knyga>(
                        knygos.FindAll(knyga => knyga.Pavadinimas.Contains(search) || knyga.Autorius.Contains(search))
                    );

            return atitinkanciosKnygos;
        }

        public bool istrintiKnyga(Knyga knyga)
        {
            bool arSekmingai = knygos.Remove(knyga);
            if (arSekmingai == true)
            {
                return DarbasSuFailais.IrasytiIFaila<List<Knyga>>("..\\..\\Duomenu failai\\knygos.xml", knygos);
            }
            else
            {
                return false;
            }
        }

        public bool paimtiKnyga(Knyga paimamaKnyga, Zmogus skaitytojas)
        {
            Knyga paimta = knygos.Find(knyga => knyga.Equals(paimamaKnyga));
            paimta.paimtiKnyga(skaitytojas, DateTime.Now, DateTime.Now.AddMonths(1));

            return DarbasSuFailais.IrasytiIFaila<List<Knyga>>("..\\..\\Duomenu failai\\knygos.xml", knygos);
        }

        public bool pridetiNaujaKnyga(Knyga knyga)
        {
            knygos.Add(knyga);

            return DarbasSuFailais.IrasytiIFaila<List<Knyga>>("..\\..\\Duomenu failai\\knygos.xml", knygos);
        }

        public bool pratestiKnyga(Knyga pratesiamaKnyga)
        {
            Knyga pratesti = knygos.Find(knyga => knyga.Equals(pratesiamaKnyga));
            pratesti.pratestiKnyga(DateTime.Now.AddMonths(1));

            return DarbasSuFailais.IrasytiIFaila<List<Knyga>>("..\\..\\Duomenu failai\\knygos.xml", knygos);
        }

        public int getNextId()
        {
            int maks = 0;
            foreach (Knyga knyga in knygos)
            {
                if (knyga.Id > maks)
                {
                    maks = knyga.Id;
                }
            }
            return maks + 1;
        }
    }
}
