using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_librarian
{
    public class Knyga
    {
        private int id;
        private String pavadinimas;
        private String autorius;
        private String leidykla;
        private DateTime metai;
        private int puslapiai;

        private String isbn;
        private String kodas;

        private bool arPaimta;
        private Zmogus skaitytojas;
        private DateTime paimta;
        private DateTime grazinti;
        private int likoLaiko;

        public Knyga() //Reikia darbui su failais
        {

        }

        public Knyga(string pavadinimas, string autorius, string leidykla, DateTime metai, int puslapiai, string isbn, string kodas)
        {
            this.pavadinimas = pavadinimas;
            this.autorius = autorius;
            this.leidykla = leidykla;
            this.metai = metai;
            this.puslapiai = puslapiai;
            this.isbn = isbn;
            this.kodas = kodas;

            this.arPaimta = false;
            this.skaitytojas = null;
            this.paimta = default(DateTime);
            this.grazinti = default(DateTime);
        }

        public Knyga(string pavadinimas, string autorius, string leidykla, DateTime metai, int puslapiai, string isbn, string kodas, DateTime paimta, DateTime grazinti)
        {
            this.pavadinimas = pavadinimas;
            this.autorius = autorius;
            this.leidykla = leidykla;
            this.metai = metai;
            this.puslapiai = puslapiai;
            this.isbn = isbn;
            this.kodas = kodas;

            this.arPaimta = false;
            this.skaitytojas = null;
            this.paimta = paimta;
            this.grazinti = grazinti;
        }

        public int Id { get => id; }
        public string Pavadinimas { get => pavadinimas; set => pavadinimas = value; }
        public string Autorius { get => autorius; set => autorius = value; }
        public string Leidykla { get => leidykla; set => leidykla = value; }
        public DateTime Metai { get => metai; set => metai = value; }
        public int Puslapiai { get => puslapiai; set => puslapiai = value; }
        public string Isbn { get => isbn; set => isbn = value; }
        public string Kodas { get => kodas; set => kodas = value; }
        public DateTime Paimta { get => paimta; set => paimta = value; }
        public DateTime Grazinti { get => grazinti; set => grazinti = value; }
        public int LikoLaiko { get => likoLaiko; }

        public void paimtiKnyga(Zmogus skaitytojas, DateTime paimta, DateTime grazinti)
        {
            this.arPaimta = true;
            this.skaitytojas = skaitytojas;
            this.paimta = paimta;
            this.grazinti = grazinti;
        }

        public void grazintiKnyga()
        {
            this.arPaimta = false;
            this.skaitytojas = null;
            this.paimta = default(DateTime);
            this.grazinti = default(DateTime);
        }

        public void pratestiKnyga(DateTime naujaGrazinti)
        {
            this.grazinti = naujaGrazinti;
        }

        public void gautiLikoLaiko()
        {
            DateTime dabar = DateTime.Now;
            TimeSpan skirtumas = this.grazinti - dabar;
            int dienos = skirtumas.Days;
            this.likoLaiko = dienos;
        }
    }
}
