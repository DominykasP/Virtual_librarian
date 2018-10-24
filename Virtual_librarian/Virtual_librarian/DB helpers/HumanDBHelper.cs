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
            users = FileIO.FileRead<List<Person>>(PathsToFiles.pathToUsersFile);
        }

        public bool AddNewPerson(Person person)
        {
            users.Add(person);
            return FileIO.FileWrite<List<Person>>(PathsToFiles.pathToUsersFile, users);
        }


        public bool DeletePerson(Person person)
        {
            bool isSuccessful = users.Remove(person);
            if (isSuccessful == true)
            {
                return FileIO.FileWrite<List<Person>>(PathsToFiles.pathToUsersFile, users);
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

            return FileIO.FileWrite<List<Person>>(PathsToFiles.pathToUsersFile, users);
        }

        public Person GetPersonByID(int id)
        {
            Person foundPerson = new Person();
            var userList = users.OfType<Person>();
            var foundUsers = from user in userList
                                  where (user.Id == id)
                                  select user;
            foreach (var user in foundUsers)
            {
                foundPerson = user;
            }


            return foundPerson;
        }

        public Person GetPersonByNameSurnamePassword(string name, string surname, string password)
        {
            Person foundUser = new Person();
            var userList = users.OfType<Person>();
            var foundUsers = from user in userList
                                  where user.Name.Equals(name) && user.Surname.Equals(surname) && user.Password.Equals(password)
                                  select user;
            foreach (var user in foundUsers)
            {
                foundUser = user;
            }
            return foundUser;
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
