using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_librarian.Objects
{
    public class Admin : Zmogus
    {
        private Enum Job;

        public Admin(string name, string surname, string password, DateTime birthdate, string phoneNumber, string email,Enum job)
        {
            Name = name;
            Surname = surname;
            Password = password;
            Birthdate = birthdate;
            PhoneNumber = phoneNumber;
            Email = email;
            Job = job;
        }
        public string Job{ get => job; set => job = value; }

    }

    public enum job { job1, job2, job3 };
}
