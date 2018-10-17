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
        private int i = 0;
        //private KnyguKolekcija<Knyga> knygos;
        KnyguKolekcija<Knyga> knyguKolekcija = new KnyguKolekcija<Knyga>();

        public BookDBHelper()
        {
            knygos = DarbasSuFailais.NuskaitytiIsFailo<List<Knyga>>("..\\..\\Duomenu failai\\knygos.xml");
            while (i < knygos.Count)//pridedam knygas i indeksuota klase
            {
                knyguKolekcija.prideti(knygos[i++]);               
            }
        }

        public Knyga gautiKnygaPagalIndeksa(int id)
        {
            return knyguKolekcija[id];
        }


        public Knyga gautiKnygaPagalKodus(string isbn, string kodas)
        {
            //Knyga rastaKnyga = knygos.Find(knyga => knyga.Isbn == isbn && knyga.Kodas == kodas);
            Knyga rastaKnyga = new Knyga();
            var knyguSarasas = knygos.OfType<Knyga>();
            var rastosKnygos = from knyga in knyguSarasas
                               where (knyga.Isbn == isbn) && (knyga.Kodas == kodas)
                               select knyga;
            foreach(var knyga in rastosKnygos)
            {
                rastaKnyga = knyga;
            }
            return rastaKnyga;
        }

        public List<Knyga> gautiVisasKnygas()
        {
            return knygos;
        }

        public List<Knyga> gautiZmogausKnygas(Zmogus zmogus)
        {
            /* List<Knyga> zmogausKnygos = new List<Knyga>(
                     knygos.FindAll(knyga => knyga.ArPaimta == true && knyga.Skaitytojas.Equals(zmogus))
                 );*/
            List<Knyga> zmogausKnygos = new List<Knyga>();
            var knyguSarasas = knygos.OfType<Knyga>();
            var rastosKnygos = from knyga in knyguSarasas
                               where (knyga.ArPaimta == true) && (knyga.Skaitytojas.Equals(zmogus))
                               orderby knyga
                               select knyga;
            foreach (var knyga in rastosKnygos)
            {
                zmogausKnygos.Add(knyga);
            }


            return zmogausKnygos;
        }

        public bool grazintiKnyga(Knyga grazinamaKnyga)
        {
            //Knyga grazinama = knygos.Find(knyga => knyga.Equals(grazinamaKnyga));
            Knyga grazinama = new Knyga();
            var knyguSarasas = knygos.OfType<Knyga>();
            var rastosKnygos = from knyga in knyguSarasas
                               where knyga.Equals(grazinamaKnyga)
                               select knyga;
            foreach (var knyga in rastosKnygos)
            {
                grazinama = knyga;
            }
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
            /*List<Knyga> atitinkanciosKnygos = new List<Knyga>(
                        knygos.FindAll(knyga => knyga.Pavadinimas.Contains(search) || knyga.Autorius.Contains(search))
                    );*/
            List<Knyga> atitinkanciosKnygos = new List<Knyga>();
            var knyguSarasas = knygos.OfType<Knyga>();
            var rastosKnygos = from knyga in knyguSarasas
                               where knyga.Pavadinimas.Contains(search) || knyga.Autorius.Contains(search)
                               orderby knyga
                               select knyga;
            foreach (var knyga in rastosKnygos)
            {
                atitinkanciosKnygos.Add(knyga);
            }

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
            //Knyga paimta = knygos.Find(knyga => knyga.Equals(paimamaKnyga));
            Knyga paimta = new Knyga();
            var knyguSarasas = knygos.OfType<Knyga>();
            var rastosKnygos = from knyga in knyguSarasas
                               where knyga.Equals(paimamaKnyga)
                               select knyga;
            foreach (var knyga in rastosKnygos)
            {
                paimta = knyga;
            }
            paimta.paimtiKnyga(skaitytojas, DateTime.Now, DateTime.Now.AddMonths(1));

            return DarbasSuFailais.IrasytiIFaila<List<Knyga>>("..\\..\\Duomenu failai\\knygos.xml", knygos);
        }

        public bool pridetiNaujaKnyga(Knyga knyga)
        {
            knygos.Add(knyga);
            knyguKolekcija.prideti(knyga);//pridedam knygas i indeksuota klase
            return DarbasSuFailais.IrasytiIFaila<List<Knyga>>("..\\..\\Duomenu failai\\knygos.xml", knygos);
        }

        public bool pratestiKnyga(Knyga pratesiamaKnyga)
        {
            //Knyga pratesti = knygos.Find(knyga => knyga.Equals(pratesiamaKnyga));
            Knyga pratesti = new Knyga();
            var knyguSarasas = knygos.OfType<Knyga>();
            var rastosKnygos = from knyga in knyguSarasas
                               where knyga.Equals(pratesiamaKnyga)
                               select knyga;
            foreach (var knyga in rastosKnygos)
            {
                pratesti = knyga;
            }
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
