using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryObjects
{
    public class BookWithPerson
    {
        public int id;
        public String name;
        public String author;
        public String publisher;
        public DateTime year;
        public int pages;

        public String isbn;
        public String code;

        public bool isTaken;
        public int readerId;
        public DateTime takenAt;
        public DateTime returnAt;
        public int timeRemaining;
        public String personName;
        public String personSurname;

        public BookWithPerson(int id, string name, string author, string publisher, DateTime year, int pages, string isbn, string code, bool isTaken, int readerId, DateTime takenAt, DateTime returnAt, int timeRemaining, string personName, string personSurname)
        {
            this.id = id;
            this.name = name;
            this.author = author;
            this.publisher = publisher;
            this.year = year;
            this.pages = pages;
            this.isbn = isbn;
            this.code = code;
            this.isTaken = isTaken;
            this.readerId = readerId;
            this.takenAt = takenAt;
            this.returnAt = returnAt;
            this.timeRemaining = timeRemaining;
            this.personName = personName;
            this.personSurname = personSurname;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Author { get => author; set => author = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public DateTime Year { get => year; set => year = value; }
        public int Pages { get => pages; set => pages = value; }
        public string Isbn { get => isbn; set => isbn = value; }
        public string Code { get => code; set => code = value; }
        public bool IsTaken { get => isTaken; set => isTaken = value; }
        public int ReaderId { get => readerId; set => readerId = value; }
        public DateTime TakenAt { get => takenAt; set => takenAt = value; }
        public DateTime ReturnAt { get => returnAt; set => returnAt = value; }
        public int TimeRemaining { get => timeRemaining; set => timeRemaining = value; }
        public string PersonName { get => personName; set => personName = value; }
        public string PersonSurname { get => personSurname; set => personSurname = value; }
    }
}
