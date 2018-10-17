using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_librarian.Objects
{
    public class Admin : Zmogus
    {
        private AdminJob Job;

        public Admin(string name, string surname, string password, DateTime birthdate, string phoneNumber, string email,AdminJob job)
        {
            Name = name;
            Surname = surname;
            Password = password;
            Birthdate = birthdate;
            PhoneNumber = phoneNumber;
            Email = email;
            Job = job;
        }

        public Admin(int id,string name, string surname, string password, DateTime birthdate, string phoneNumber, string email, AdminJob job)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Password = password;
            Birthdate = birthdate;
            PhoneNumber = phoneNumber;
            Email = email;
            Job = job;
        }

        public Admin(int id, string name, string surname, string password, DateTime birthdate, string phoneNumber, string email, AdminJob job, Bitmap image)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Password = password;
            Birthdate = birthdate;
            PhoneNumber = phoneNumber;
            Email = email;
            Job = job;
            Image = image;
        }
        public AdminJob job { get => job; private set => job = value; }
    }

    public enum AdminJob { job1, job2, job3 };
}
