using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_librarian
{
    interface IPersonDBHelper
    {
        Person GetPersonByID(int ID);
        Person GetPersonByNameSurnamePassword(string name, string surname, string password);

        bool AddNewPerson(Person person);
        bool DeletePerson(Person person);
        bool EditPerson(Person oldPerson, Person newPerson);
    }
}
