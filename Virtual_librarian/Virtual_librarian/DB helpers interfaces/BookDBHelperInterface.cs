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

        bool pridetiNaujaKnyga(Knyga knyga);
        bool istrintiKnyga(int knygosID);
        bool paimtiKnyga(int knygosID, int skaitytojoID);
        Knyga grazintiKnyga(int knygosID);
    }
}
