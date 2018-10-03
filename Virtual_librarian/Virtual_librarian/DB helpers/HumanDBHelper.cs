using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_librarian.DB_helpers
{
    class HumanDBHelper : HumanDBHelperInterface
    {
        public bool addNewZmogus(Zmogus zmogus)
        {
            throw new NotImplementedException();
        }

        public bool deleteZmogusByID(int ID)
        {
            throw new NotImplementedException();
        }

        public bool editZmogus(int oldID, Zmogus newZmogus)
        {
            throw new NotImplementedException();
        }

        public Zmogus getZmogusByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Zmogus getZmogusByNameSurnamePassword(string name, string surname, string password)
        {
            throw new NotImplementedException();
        }
    }
}
