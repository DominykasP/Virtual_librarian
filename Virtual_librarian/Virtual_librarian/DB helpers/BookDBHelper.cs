using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_librarian.DB_helpers
{
    public class BookDBHelper : BookDBHelperInterface
    {
        public Knyga gautiKnygaPagalKodus(string isbn, string kodas)
        {
            /*return new Knyga(
                    "Liūdna pasaka",
                    "Jonas Biliūnas",
                    "Alma Littera",
                    new DateTime(1980, 5, 25),
                    5,
                    "12345678",
                    "21343244"
                );*/

            List<Knyga> visosKnygos = new List<Knyga>(this.gautiVisasKnygas());
            Knyga rastaKnyga = visosKnygos.Find(knyga => knyga.Isbn == isbn && knyga.Kodas == kodas);
            return rastaKnyga;
        }

        public List<Knyga> gautiVisasKnygas()
        {
            List<Knyga> knygos = new List<Knyga>();
            knygos.Add(new Knyga(
                    "Liūdna pasaka",
                    "Jonas Biliūnas",
                    "Alma Littera",
                    new DateTime(1980, 5, 25),
                    5,
                    "12345678",
                    "21343244"
                ));
            knygos.Add(new Knyga(
                    "Karlsonas",
                    "Astrida Lindgren",
                    "Alma Littera",
                    new DateTime(1996, 4, 15),
                    500,
                    "13644563",
                    "24954972"
                ));
            knygos.Add(new Knyga(
                    "Metro",
                    "Dimitrij Gluchovski",
                    "Zaltvykste",
                    new DateTime(2014, 6, 12),
                    700,
                    "35435534",
                    "97234594"
                ));

            return knygos;
        }

        public List<Knyga> gautiZmogausKnygas(Zmogus zmogus)
        {
            List<Knyga> knygos = new List<Knyga>();
            knygos.Add(new Knyga(
                    "Liūdna pasaka",
                    "Jonas Biliūnas",
                    "Alma Littera",
                    new DateTime(1980, 5, 25),
                    5,
                    "12345678",
                    "21343244",
                    new DateTime(2018,10,01),
                    new DateTime(2018,11,01)
                ));
            knygos.Add(new Knyga(
                    "Karlsonas",
                    "Astrida Lindgren",
                    "Alma Littera",
                    new DateTime(1996, 4, 15),
                    500,
                    "13644563",
                    "24954972",
                    new DateTime(2018, 09, 14),
                    new DateTime(2018, 12, 23)
                ));

            return knygos;
        }

        public bool grazintiKnyga(Knyga knyga)
        {
            return true;
        }

        public List<Knyga> ieskoti(string search)
        {
            List<Knyga> knygos = new List<Knyga>();
            knygos.Add(new Knyga(
                    "Liūdna pasaka",
                    "Jonas Biliūnas",
                    "Alma Littera",
                    new DateTime(1980, 5, 25),
                    5,
                    "12345678",
                    "21343244"
                ));
            knygos.Add(new Knyga(
                    "Karlsonas",
                    "Astrida Lindgren",
                    "Alma Littera",
                    new DateTime(1996, 4, 15),
                    500,
                    "13644563",
                    "24954972"
                ));

            return knygos;
        }

        public bool istrintiKnyga(Knyga knyga)
        {
            return true;
        }

        public bool paimtiKnyga(Knyga knyga, Zmogus skaitytojas)
        {
            return true;
        }

        public bool pridetiNaujaKnyga(Knyga knyga)
        {
            return true;
        }
    }
}
