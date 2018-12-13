using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using FilesFunctions;
using LibraryObjects;
using Interfaces;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace DatabaseWithEntity
{
    public class HumanDBHelper : IPersonDBHelper
    {
        private Lazy<List<Person>> users;
        private string db;

        DatabaseWithEntity.biblioteka2Entities database;

        public HumanDBHelper()
        {
            database = new DatabaseWithEntity.biblioteka2Entities();
        }

        public bool AddNewPerson(Person person)
        {
            database.users.Add(DBToLibrary.LibraryToUser(person));
            database.SaveChanges();
            return true;
        }


        public bool DeletePerson(Person person)
        {
            var personToDelete = database.users.Where((personDB) => personDB.Id == person.Id).First();
            if (personToDelete == null)
            {
                return false;
            }

            database.users.Remove(personToDelete);
            database.SaveChanges();
            return true;
        }

        public bool DeletePerson(int personId)
        {
            var personToDelete = database.users.Where((person) => person.Id == personId).First();
            if (personToDelete == null)
            {
                return false;
            }

            database.users.Remove(personToDelete);
            database.SaveChanges();
            return true;
        }

        public bool EditPerson(Person oldPerson, Person newPerson)
        {
            var personToEdit = database.users.Where((person) => person.Id == oldPerson.Id).First();
            if (personToEdit == null)
            {
                return false;
            }

            database.Entry(personToEdit).CurrentValues.SetValues(DBToLibrary.LibraryToUser(newPerson));
            database.SaveChanges();
            return true;
        }

        public bool EditPerson(int oldPersonId, Person newPerson)
        {
            var personToEdit = database.users.Where((person) => person.Id == oldPersonId).First();
            if (personToEdit == null)
            {
                return false;
            }

            database.Entry(personToEdit).CurrentValues.SetValues(DBToLibrary.LibraryToUser(newPerson));
            database.SaveChanges();
            return true;
        }

        public Person GetPersonByID(int id)
        {
            var personById = database.users.Where((person) => person.Id == id).First();
            return DBToLibrary.UserToLibrary(personById);
        }

        public Person GetPersonByNameSurnamePassword(string name, string surname, string password)
        {
            var personByData = database.users.Where((person) => person.Name.Equals(name) && person.Surname.Equals(surname) && person.Password.Equals(password)).First();
            return DBToLibrary.UserToLibrary(personByData);
        }

        public List<Person> GetAllPersons()
        {
            var personsFromDB = database.users;
            return DBToLibrary.UserListToLibrary(personsFromDB.ToList<DatabaseWithEntity.users>());
        }

        public int GetNextId()
        {
            int maxId = database.users.Max((person) => person.Id);
            return maxId + 1;
        }
    }
}
