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
            users = DarbasSuFailais.NuskaitytiIsFailo<List<Zmogus>>(PathsToFiles.pathToUsersFile);
        }

        public bool AddNewPerson(Person person)
        {
            users.Add(person);
            return DarbasSuFailais.IrasytiIFaila<List<Zmogus>>(PathsToFiles.pathToUsersFile, naudotojai);
        }


        public bool DeletePerson(Person person)
        {
            bool isSuccessful = users.Remove(person);
            if (isSuccessful == true)
            {
                return DarbasSuFailais.IrasytiIFaila<List<Zmogus>>(PathsToFiles.pathToUsersFile, naudotojai);
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

            return DarbasSuFailais.IrasytiIFaila<List<Zmogus>>(PathsToFiles.pathToUsersFile, naudotojai);
        }

        public Person GetPersonByID(int id)
        {
            Person foundPerson = new Person();
            var naudotojuSarasas = naudotojai.OfType<Person>();
            var rastiNaudotojai = from naudotojas in naudotojuSarasas
                                  where (naudotojas.Id == ID)
                                  select naudotojas;
            foreach (var naudotojas in rastiNaudotojai)
            {
                foundPerson = naudotojas;
            }


            return foundPerson;
        }

        public Person getPersonByNameSurnamePassword(string name, string surname, string password)
        {
            Person rastasNaudotojas = new Person();
            var naudotojuSarasas = naudotojai.OfType<Person>();
            var rastiNaudotojai = from naudotojas in naudotojuSarasas
                                  where naudotojas.Name.Equals(name) && naudotojas.Surname.Equals(surname) && naudotojas.Password.Equals(password)
                                  select naudotojas;
            foreach (var naudotojas in rastiNaudotojai)
            {
                rastasNaudotojas = naudotojas;
            }
            return rastasNaudotojas;
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
