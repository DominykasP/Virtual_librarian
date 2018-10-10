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
        public bool addNewZmogus(Zmogus zmogus)
        {
            return true;
        }

        public bool deleteZmogus(Zmogus zmogus)
        {
            return true;
        }

        public bool editZmogus(Zmogus oldZmogus, Zmogus newZmogus)
        {
            return true;
        }

        public Zmogus getZmogusByID(int ID)
        {
            return new Zmogus(
                    "Vardenis",
                    "Pavardenis",
                    "Slaptazodis",
                    new DateTime(1998, 01, 01),
                    "+37012345678",
                    "vardenis.pavardenis@gmail.com"
                   );
        }

        public Zmogus getZmogusByNameSurnamePassword(string name, string surname, string password)
        {
            return new Zmogus(
                    "Vardenis",
                    "Pavardenis",
                    "Slaptazodis",
                    new DateTime(1998, 01, 01),
                    "+37012345678",
                    "vardenis.pavardenis@gmail.com"
                   );
        }
    }
}
