using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryObjects
{
    public class Admin : Person
    {
        private AdminJob Job;

        public Admin(string name, string surname, string password, DateTime birthDate, string phoneNumber, string email,AdminJob job)
        {
            SetProperties(name, surname, password, birthDate, phoneNumber, email, job);

        }

        public Admin(int id,string name, string surname, string password, DateTime birthDate, string phoneNumber, string email, AdminJob job)
        {
            Id = id;
            SetProperties(name, surname, password, birthDate, phoneNumber, email, job);

        }

        private void SetProperties(string name, string surname, string password, DateTime birthDate, string phoneNumber, string email, AdminJob job)
        {
            Name = name;
            Surname = surname;
            Password = password;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Email = email;
            Job = job;
        }
        public AdminJob job { get => job; private set => job = value; }
    }

    public enum AdminJob { job1, job2, job3 };
}
