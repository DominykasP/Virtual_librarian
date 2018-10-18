using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_librarian.DB_helpers
{
    public class BookDBHelper : IBookDBHelper
    {
        private List<Book> books;

        public BookDBHelper()
        {
            books = FileIO.ReadFromFile<List<Book>>("..\\..\\Duomenu failai\\knygos.xml");
        }

        public Book GetBookByCodes(string isbn, string code)
        {
            Book foundBook = books.Find(book => book.Isbn == isbn && book.Code == code);
            return foundBook;
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public List<Book> GetReadersBooks(Person reader)
        {
            List<Book> readersBooks = new List<Book>(
                    books.FindAll(book => book.IsTaken == true && book.Reader.Equals(reader))
                );

            return readersBooks;
        }

        public bool ReturnBook(Book returnedBook)
        {
            Book returned = books.Find(book => book.Equals(returnedBook));
            if (returned != null)
            {
                returned.ReturnBook();

                return FileIO.FileWrite<List<Book>>("..\\..\\Duomenu failai\\knygos.xml", books);
            }
            else
            {
                return false;
            }
        }

        public List<Book> Find(string search)
        {
            List<Book> correspondingBooks = new List<Book>(
                        books.FindAll(book => book.Name.Contains(search) || book.Author.Contains(search))
                    );

            return correspondingBooks;
        }

        public bool DeleteBook(Book book)
        {
            bool isSuccessful = books.Remove(book);
            if (isSuccessful == true)
            {
                return FileIO.FileWrite<List<Book>>("..\\..\\Duomenu failai\\knygos.xml", books);
            }
            else
            {
                return false;
            }
        }

        public bool TakeBook(Book takenBook, Person reader)
        {
            Book taken = books.Find(book => book.Equals(takenBook));
            taken.TakeBook(reader, DateTime.Now, DateTime.Now.AddMonths(1));

            return FileIO.FileWrite<List<Book>>("..\\..\\Duomenu failai\\knygos.xml", books);
        }

        public bool AddNewBook(Book book)
        {
            books.Add(book);

            return FileIO.FileWrite<List<Book>>("..\\..\\Duomenu failai\\knygos.xml", books);
        }

        public bool RenewBook(Book renewedBook)
        {
            Book renew = books.Find(book => book.Equals(renewedBook));
            renew.ExtendLoanPeriod(DateTime.Now.AddMonths(1));

            return FileIO.FileWrite<List<Book>>("..\\..\\Duomenu failai\\knygos.xml", books);
        }

        public int getNextId()
        {
            int max = 0;
            foreach (Book book in books)
            {
                if (book.Id > max)
                {
                    max = book.Id;
                }
            }
            return max + 1;
        }
    }
}
