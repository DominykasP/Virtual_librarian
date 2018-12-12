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
            //users = new Lazy < List < Person >>(() => FileIO.FileRead<List<Person>>(PathsToFiles.pathToUsersFile));
            /*if (users == null)
            {
                users = new List<Person>();
            }*/
            users = new Lazy<List<Person>>(() => SQLPersonsRead());
            db = "Server=tcp:biblioteka.database.windows.net,1433;Initial Catalog=biblioteka;Persist Security Info=False;User ID='biblioteka';Password='sqlbaze1!';MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


            database = new DatabaseWithEntity.biblioteka2Entities();
        }

        public List<Person> SQLPersonsRead()
        {

            SqlConnection conn;
            //string myConnectionString = ConfigurationManager.ConnectionStrings["biblioteka"].ConnectionString;
            conn = new SqlConnection(db);
            try
            {
                //conn.ConnectionString = myConnectionString;
                conn.Open();

                Lazy<List<Person>> users = new Lazy<List<Person>>();

                SqlDataReader mySQLReader = null;
                String sqlString = "SELECT * FROM users1";
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                mySQLReader = cmd.ExecuteReader();
                while (mySQLReader.Read())
                {

                    Person user = new Person();
                    user.Id = Convert.ToInt32(mySQLReader["Id"]);
                    user.Name = mySQLReader["Name"].ToString().TrimEnd().TrimEnd();
                    user.Surname = mySQLReader["Surname"].ToString().TrimEnd();
                    user.Password = mySQLReader["Password"].ToString().TrimEnd();
                    user.BirthDate = Convert.ToDateTime(mySQLReader["BirthDate"]);
                    user.Email = mySQLReader["Email"].ToString().TrimEnd();


                    users.Value.Add(user);

                }
                return users.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool SQLPersonUpdate(Person changedUser, int changedUserId)
        {
            SqlConnection conn;
            //string myConnectionString = ConfigurationManager.ConnectionStrings["biblioteka"].ConnectionString;
            conn = new SqlConnection(db);
            try
            {
                //conn.ConnectionString = myConnectionString;
                conn.Open();

                List<Person> users = new List<Person>();


                //String sqlString = "DELETE FROM books WHERE ID = '" + changedBook.Id + "'";
                //SqlCommand cmd = new SqlCommand(sqlString, conn);
                //cmd.ExecuteNonQuery();
                String sqlString = "UPDATE users1 SET Name = @Name, Surname = @Surname, Password = @Password, BirthDate = @BirthDate, Email = @Email WHERE Id = " + changedUserId + "'";
                //sqlString += " VALUES  (@Id, @Name, @Author, @Publisher, @Year, @Pages, @Isbn, @Code, @IsTaken, @TakenAt, @ReturnAt, @UserId)";
                SqlCommand cmd2 = new SqlCommand(sqlString, conn);
                //cmd2.Parameters.AddWithValue("@Id", changedUser.Id);
                cmd2.Parameters.AddWithValue("@Name", changedUser.Name);
                cmd2.Parameters.AddWithValue("@Surname", changedUser.Surname);
                cmd2.Parameters.AddWithValue("@Password", changedUser.Password);
                cmd2.Parameters.AddWithValue("@BirthDate", changedUser.BirthDate);
                cmd2.Parameters.AddWithValue("@Email", changedUser.Email);

                cmd2.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool SQLPersonDelete(Person changedUser)
        {
            SqlConnection conn;
            //string myConnectionString = ConfigurationManager.ConnectionStrings["biblioteka"].ConnectionString;
            conn = new SqlConnection(db);
            try
            {
                //conn.ConnectionString = myConnectionString;
                conn.Open();

                String sqlString = "DELETE FROM users1 WHERE ID = '" + changedUser.Id + "'";
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool SQLPersonDeleteById(int changedUser)
        {
            SqlConnection conn;
            //string myConnectionString = ConfigurationManager.ConnectionStrings["biblioteka"].ConnectionString;
            conn = new SqlConnection(db);
            try
            {
                //conn.ConnectionString = myConnectionString;
                conn.Open();

                String sqlString = "DELETE FROM users1 WHERE ID = '" + changedUser + "'";
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool SQLPersonAdd(Person changedUser)
        {
            SqlConnection conn;
            //string myConnectionString = ConfigurationManager.ConnectionStrings["biblioteka"].ConnectionString;
            conn = new SqlConnection(db);
            try
            {
                //conn.ConnectionString = myConnectionString;
                conn.Open();

                List<Person> users = new List<Person>();


                String sqlString;
                sqlString = "INSERT INTO users1 (Id, Name, Surname, Password, BirthDate, Email)";
                sqlString += " VALUES  (@Id, @Name, @Surname, @Password, @BirthDate, @Email)";
                SqlCommand cmd2 = new SqlCommand(sqlString, conn);
                cmd2.Parameters.AddWithValue("@Id", GetNextId());
                cmd2.Parameters.AddWithValue("@Name", changedUser.Name);
                cmd2.Parameters.AddWithValue("@Surname", changedUser.Surname);
                cmd2.Parameters.AddWithValue("@Password", changedUser.Password);
                cmd2.Parameters.AddWithValue("@BirthDate", changedUser.BirthDate);
                cmd2.Parameters.AddWithValue("@Email", changedUser.Email);

                cmd2.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool AddNewPerson(Person person)
        {

            users.Value.Add(person);
            //return FileIO.FileWrite<List<Person>>(PathsToFiles.pathToUsersFile, users.Value);
            return SQLPersonAdd(person);
        }


        public bool DeletePerson(Person person)
        {
            bool isSuccessful = users.Value.Remove(person);
            if (isSuccessful == true)
            {
                //return FileIO.FileWrite<List<Person>>(PathsToFiles.pathToUsersFile, users.Value);
                return SQLPersonDelete(person);
            }
            else
            {
                return false;
            }
        }

        public bool DeletePerson(int personId)
        {
            Person personToRemove = null;
            var userList = users.Value.OfType<Person>();
            var foundUsers = from user in userList
                             where (user.Id == personId)
                             select user;
            foreach (var user in foundUsers)
            {
                personToRemove = user;
            }

            if (personToRemove == null)
            {
                return false;
            }

            bool isSuccessful = users.Value.Remove(personToRemove);
            if (isSuccessful == true)
            {
                //return FileIO.FileWrite<List<Person>>(PathsToFiles.pathToUsersFile, users.Value);
                return SQLPersonDeleteById(personId);
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

            //return FileIO.FileWrite<List<Person>>(PathsToFiles.pathToUsersFile, users.Value);
            return SQLPersonUpdate(newPerson, oldPerson.Id);
        }

        public bool EditPerson(int oldPersonId, Person newPerson)
        {
            Person oldPerson = null;
            var userList = users.Value.OfType<Person>();
            var foundUsers = from user in userList
                             where (user.Id == oldPersonId)
                             select user;
            foreach (var user in foundUsers)
            {
                oldPerson = user;
            }

            if (oldPerson == null)
            {
                return false;
            }

            oldPerson.Name = newPerson.Name;
            oldPerson.Surname = newPerson.Surname;
            oldPerson.Password = newPerson.Password;
            oldPerson.Email = newPerson.Email;
            oldPerson.PhoneNumber = newPerson.PhoneNumber;
            oldPerson.BirthDate = newPerson.BirthDate;

            //return FileIO.FileWrite<List<Person>>(PathsToFiles.pathToUsersFile, users.Value);
            return SQLPersonUpdate(newPerson, oldPersonId);
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

        public List<Person> GetAllPersons()
        {
            return users.Value;
        }

        public int GetNextId()
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
