using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_librarian.DB_helpers
{
    public class BookDBHelper : BookDBHelperInterface
    {
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
                    5,
                    "13644563",
                    "24954972"
                ));
            knygos.Add(new Knyga(
                    "Metro",
                    "Dimitrij Gluchovski",
                    "Zaltvykste",
                    new DateTime(2014, 6, 12),
                    5,
                    "35435534",
                    "97234594"
                ));

            return knygos;
        }

        public Knyga grazintiKnyga(int knygosID)
        {
            return new Knyga(
                    "Liūdna pasaka",
                    "Jonas Biliūnas",
                    "Alma Littera",
                    new DateTime(1980, 5, 25),
                    5,
                    "12345678",
                    "21343244"
                );
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
                    5,
                    "13644563",
                    "24954972"
                ));

            return knygos;
        }

        public bool istrintiKnyga(int knygosID)
        {
            return true;
        }

        public bool paimtiKnyga(int knygosID, int skaitytojoID)
        {
            return true;
        }

        public bool pridetiNaujaKnyga(Knyga knyga)
        {
            return true;
        }
    }
}
