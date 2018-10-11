﻿using System;
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
        List<Knyga> gautiZmogausKnygas(Zmogus zmogus);

        bool pridetiNaujaKnyga(Knyga knyga);
        bool istrintiKnyga(Knyga knyga);
        bool paimtiKnyga(Knyga paimamaKnyga, Zmogus skaitytojas);
        bool grazintiKnyga(Knyga grazinamaKnyga);
        bool pratestiKnyga(Knyga pratesiamaKnyga);
    }
}
