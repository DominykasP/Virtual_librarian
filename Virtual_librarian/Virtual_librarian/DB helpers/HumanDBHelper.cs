using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Virtual_librarian.DB_helpers
{
    public class HumanDBHelper : IPersonDBHelper
    {
        private List<Person> users;

        public HumanDBHelper()
        {
            users = FileIO.FileRead<List<Person>>("..\\..\\Duomenu failai\\naudotojai.xml");
        }

        public bool AddNewPerson(Person person)
        {
            users.Add(person);

            return FileIO.FileWrite<List<Person>>("..\\..\\Duomenu failai\\naudotojai.xml", users);
        }

        public bool DeletePerson(Person person)
        {
            bool isSuccessful = users.Remove(person);
            if (isSuccessful == true)
            {
                return FileIO.FileWrite<List<Person>>("..\\..\\Duomenu failai\\naudotojai.xml", users);
            }
            else
            {
                return false;
            }
        }

        public bool EditPerson(Person oldPerson, Person newPerson)
        {
            bool isSuccessful = users.Remove(oldPerson);
            if (isSuccessful == true)
            {
                users.Add(newPerson);
            }

            return FileIO.FileWrite<List<Person>>("..\\..\\Duomenu failai\\naudotojai.xml", users);
        }

        public Person GetPersonByID(int id)
        {
            Person foundPerson = users.Find(person => person.Id == id);

            return foundPerson;
        }

        public Person getPersonByNameSurnamePassword(string name, string surname, string password)
        {
            Person foundPerson = users.Find(person => person.Name.Equals(name) && person.Surname.Equals(surname) && person.Password.Equals(password));
            
            return foundPerson;
        }

        public int getNextId()
        {
            int max = 0;
            foreach (Person person in users)
            {
                if (person.Id > max)
                {
                    max = person.Id;
                }
            }
            return max+1;
        }
    }
}
