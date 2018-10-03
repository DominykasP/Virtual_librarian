using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_librarian.DB_helpers
{
    interface BookDBHelperInterface
    {
        List<Knyga> gautiVisasKnygas();
        List<Knyga> ieskoti(string search);

        Knyga gautiKnygaPagalKodus(string isbn, string kodas);

        bool pridetiNaujaKnyga(Knyga knyga);
        bool istrintiKnyga(Knyga knyga);
        bool paimtiKnyga(Knyga knyga, Zmogus skaitytojas);
        bool grazintiKnyga(Knyga knyga);
    }
}
