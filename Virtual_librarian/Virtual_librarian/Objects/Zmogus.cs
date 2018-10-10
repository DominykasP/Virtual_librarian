using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_librarian
{
    public class Zmogus
    {
        private int id;
        private string name;
        private string surname;
        private string password;
        private DateTime birthdate;
        private string phoneNumber;
        private string email;
        private Bitmap image;

        public Zmogus() //Reikia darbui su failais
        {

        }

        public Zmogus(int id, string name, string surname, string password, DateTime birthdate, string phoneNumber, string email)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.password = password;
            this.birthdate = birthdate;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }

        public Zmogus(string name, string surname, string password, DateTime birthdate, string phoneNumber, string email)
        {
            this.name = name;
            this.surname = surname;
            this.password = password;
            this.birthdate = birthdate;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }

        public Zmogus(string name, string surname, string password, DateTime birthdate, string phoneNumber, string email, Bitmap image)
        {
            this.name = name;
            this.surname = surname;
            this.password = password;
            this.birthdate = birthdate;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.image = image;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Password { get => password; set => password = value; }
        public DateTime Birthdate { get => birthdate; set => birthdate = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public Bitmap Image { get => image; set => image = value; }
    }
}
