using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_librarian
{
    public class Book : IEquatable<Book>,IComparable<Book>
    {
        private int id;
        private String name;
        private String author;
        private String publisher;
        private DateTime year;
        private int pages;

        private String isbn;
        private String code;

        private bool isTaken;
        private Person reader;
        private DateTime takenAt;
        private DateTime returnAt;
        private int timeRemaining;

        public Book() //Reikia darbui su failais
        {

        }

        public Book(int id, string name, string author, string publisher, DateTime year, int pages, string isbn, string code) 
        {
            this.id = id;
            SetProperties(name, author, publisher, year, pages, isbn, code);

            this.isTaken = false;
            this.reader = null;
            this.takenAt = default(DateTime);
            this.returnAt = default(DateTime);
        }

        public Book(string name, string author, string publisher, DateTime year, int pages, string isbn, string code)
        {
            SetProperties(name, author, publisher, year, pages, isbn, code);

            this.isTaken = false;
            this.reader = null;
            this.takenAt = default(DateTime);
            this.returnAt = default(DateTime);
        }

        public Book(string name, string author, string publisher, DateTime year, int pages, string isbn, string code, Person reader, DateTime takenAt, DateTime returnAt)
        {
            SetProperties(name, author, publisher, year, pages, isbn, code);

            this.isTaken = true;
            this.reader = reader;
            this.takenAt = takenAt;
            this.returnAt = returnAt;
        }

        private void SetProperties(string name, string author, string publisher, DateTime year, int pages, string isbn, string code)
        {
            this.name = name;
            this.author = author;
            this.publisher = publisher;
            this.year = year;
            this.pages = pages;
            this.isbn = isbn;
            this.code = code;
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
        public Person Reader { get => reader; set => reader = value; }
        public DateTime TakenAt { get => takenAt; set => takenAt = value; }
        public DateTime ReturnAt { get => returnAt; set => returnAt = value; }
        public int TimeRemaining { get => timeRemaining; }

        public void TakeBook(Person reader, DateTime takenAt, DateTime returnAt)
        {
            this.isTaken = true;
            this.reader = reader;
            this.takenAt = takenAt;
            this.returnAt = returnAt;
        }

        public void ReturnBook()
        {
            this.isTaken = false;
            this.reader = null;
            this.takenAt = default(DateTime);
            this.returnAt = default(DateTime);
        }

        public void ExtendLoanPeriod(DateTime newReturnTime)
        {
            this.returnAt = newReturnTime;
        }

        public void GetRemainingTime()
        {
            DateTime now = DateTime.Now;
            TimeSpan difference = this.returnAt - now;
            int days = difference.Days;
            this.timeRemaining = days;
        }

        public bool Equals(Book other)
        {
            return (this.isbn == other.isbn) && (this.code == other.code);
        }


        public int CompareTo(Book other)
        {
            if (this.year > other.year) return 1;
            if (this.year == other.year) return 0;
            return -1;
        }

    }
}

class BookCollection<Book>
{
    private Book[] arr = new Book[100];
    int nextIndex = 0;

    // Apibreziamas indeksavima, kad butu galima kreiptis su [] kabutemis
    public Book this[int i] => arr[i];

    public void Add(Book value)
    {
        if (nextIndex >= arr.Length)
            throw new IndexOutOfRangeException($"Knygų kolekcija turi tik {arr.Length} elementų.");
        arr[nextIndex++] = value;
    }
}
