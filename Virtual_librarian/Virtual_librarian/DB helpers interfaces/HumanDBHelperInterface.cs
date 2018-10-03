﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_librarian
{
    interface HumanDBHelperInterface
    {
        Zmogus getZmogusByID(int ID);
        Zmogus getZmogusByNameSurnamePassword(string name, string surname, string password);
        bool addNewZmogus(Zmogus zmogus);
        bool deleteZmogusByID(int ID);

        bool editZmogus(int oldID, Zmogus newZmogus);
    }
}
