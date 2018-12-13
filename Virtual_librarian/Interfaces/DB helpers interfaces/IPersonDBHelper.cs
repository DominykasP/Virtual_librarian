using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryObjects;

namespace Interfaces
{
    public interface IPersonDBHelper
    {
        bool AddNewPerson(Person person);
        bool DeletePerson(Person person);
        bool DeletePerson(int personId);
        bool EditPerson(Person oldPerson, Person newPerson);
        bool EditPerson(int oldPersonId, Person newPerson);
        Person GetPersonByID(int id);
        Person GetPersonByNameSurnamePassword(string name, string surname, string password);
        List<Person> GetAllPersons();
        int GetNextId();
    }
}
