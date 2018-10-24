using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_librarian
{
    public class Person : IEquatable<Person>
    {
        private int id;
        private string name;
        private string surname;
        private string password;
        private DateTime birthDate;
        private string phoneNumber;
        private string email;
        private Bitmap image;

        public Person() //Reikia darbui su failais
        {

        }

        public Person(int id, string name, string surname, string password, DateTime birthDate, string phoneNumber, string email)
        {
            this.id = id;
            SetProperties(name, surname, password, birthDate, phoneNumber, email);
        }

        public Person(string name, string surname, string password, DateTime birthDate, string phoneNumber, string email)
        {
            SetProperties(name, surname, password, birthDate, phoneNumber, email);
        }

        private void SetProperties(string name, string surname, string password, DateTime birthDate, string phoneNumber, string email)
        {
            this.name = name;
            this.surname = surname;
            this.password = password;
            this.birthDate = birthDate;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Password { get => password; set => password = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }

        public bool Equals(Person other)
        {
            return (this.id == other.id);
        }

        override public String ToString()
        {
            return name;
        }
    }
}
class PersonCollection<Person>
{
    private Person[] arr = new Person[100];
    int nextIndex = 0;

    // Apibreziamas indeksavima, kad butu galima kreiptis su [] kabutemis
    public Person this[int i] => arr[i];

    public void prideti(Person value)
    {
        if (nextIndex >= arr.Length)
            throw new IndexOutOfRangeException($"Žmonių kolekcija turi tik {arr.Length} elementų.");
        arr[nextIndex++] = value;
    }
}
