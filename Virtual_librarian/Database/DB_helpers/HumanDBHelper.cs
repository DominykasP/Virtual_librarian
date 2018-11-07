﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using FilesFunctions;
using LibraryObjects;
using Interfaces;

namespace Database
{
    public class HumanDBHelper : IPersonDBHelper
    {
        private Lazy<List<Person>> users;

        public HumanDBHelper()
        {
            users = new Lazy < List < Person >>(() => FileIO.FileRead<List<Person>>(PathsToFiles.pathToUsersFile));
            /*if (users == null)
            {
                users = new List<Person>();
            }*/
        }

        public bool AddNewPerson(Person person)
        {
            users.Value.Add(person);
            return FileIO.FileWrite<List<Person>>(PathsToFiles.pathToUsersFile, users.Value);
        }


        public bool DeletePerson(Person person)
        {
            bool isSuccessful = users.Value.Remove(person);
            if (isSuccessful == true)
            {
                return FileIO.FileWrite<List<Person>>(PathsToFiles.pathToUsersFile, users.Value);
            }
            else
            {
                return false;
            }
        }

        public bool EditPerson(Person oldPerson, Person newPerson)
        {
            bool isSuccessful = users.Value.Remove(oldPerson);
            if (isSuccessful == true)
            {
                users.Value.Add(newPerson);
            }

            return FileIO.FileWrite<List<Person>>(PathsToFiles.pathToUsersFile, users.Value);
        }

        public Person GetPersonByID(int id)
        {
            Person foundPerson = null;
            var userList = users.Value.OfType<Person>();
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
            Person foundUser = null;
            var userList = users.Value.OfType<Person>();
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
            foreach (Person person in users.Value)
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
