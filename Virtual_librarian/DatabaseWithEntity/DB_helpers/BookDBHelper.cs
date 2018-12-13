using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesFunctions;
using Interfaces;
using LibraryObjects;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace DatabaseWithEntity
{
    public class BookDBHelper : IBookDBHelper
    {
        DatabaseWithEntity.biblioteka2Entities database;

        public BookDBHelper()
        {
            database = new DatabaseWithEntity.biblioteka2Entities();
        }

        public Book GetBookById(int id)
        {
            var bookById = database.books.Where((book) => book.Id == id).First();
            return DBToLibrary.BookToLibrary(bookById);
        }


        public Book GetBookByCode(string isbn, string code)
        {
            var bookByCode = database.books.Where((book) => book.Isbn == isbn && book.Code == code).First();
            return DBToLibrary.BookToLibrary(bookByCode);
        }

        public Book GetBookByIsbn(string isbn)
        {
            var bookByIsbn = database.books.Where((book) => book.Isbn == isbn).First();
            return DBToLibrary.BookToLibrary(bookByIsbn);
        }

        public List<Book> GetAllBooks()
        {
            var booksFromDB = database.books;
            return DBToLibrary.BookListToLibrary(booksFromDB.ToList<DatabaseWithEntity.books>());
        }

        public List<Book> GetReadersBooks(Person reader)
        {
            var readersBooks = database.books.Where((book) => book.IsTaken == true && book.UserId == reader.Id);
            return DBToLibrary.BookListToLibrary(readersBooks.ToList<DatabaseWithEntity.books>());
        }

        public List<Book> GetReadersBooks(int readerId)
        {
            var readersBooks = database.books.Where((book) => book.IsTaken == true && book.UserId == readerId);
            return DBToLibrary.BookListToLibrary(readersBooks.ToList<DatabaseWithEntity.books>());
        }

        public bool ReturnBook(Book returnedBook)
        {
            var returned = database.books.Where((book) => book.Id == returnedBook.Id).First();
            if (returned == null)
            {
                return false;
            }

            returned.ReturnBook();
            database.SaveChanges();
            return true;
        }

        public bool ReturnBook(int returnedBookId)
        {
            var returned = database.books.Where((book) => book.Id == returnedBookId).First();
            if (returned == null)
            {
                return false;
            }

            returned.ReturnBook();
            database.SaveChanges();
            return true;
        }

        public List<Book> Find(string search)
        {
            var booksFound = database.books.Where((book) => book.Name.Contains(search) || book.Author.Contains(search));
            return DBToLibrary.BookListToLibrary(booksFound.ToList<DatabaseWithEntity.books>());
        }

        public bool EditBook(int bookId, Book newBook)
        {
            var bookToEdit = database.books.Where((book) => book.Id == bookId).First();
            if (bookToEdit == null)
            {
                return false;
            }

            database.Entry(bookToEdit).CurrentValues.SetValues(DBToLibrary.LibraryToBook(newBook));
            database.SaveChanges();
            return true;
        }

        public bool DeleteBook(Book book)
        {
            var bookToDelete = database.books.Where((bookDB) => bookDB.Id == book.Id).First();
            if (bookToDelete == null)
            {
                return false;
            }

            database.books.Remove(bookToDelete);
            database.SaveChanges();
            return true;
        }

        public bool DeleteBook(int bookId)
        {
            var bookToDelete = database.books.Where((book) => book.Id == bookId).First();
            if (bookToDelete == null)
            {
                return false;
            }

            database.books.Remove(bookToDelete);
            database.SaveChanges();
            return true;
        }

        public bool TakeBook(int takenBookId, int readerId)
        {
            var taken = database.books.Where((book) => book.Id == takenBookId).First();
            if (taken == null)
            {
                return false;
            }

            taken.TakeBook(readerId, DateTime.Now, DateTime.Now.AddMonths(1));
            database.SaveChanges();
            return true;
        }

        public bool AddNewBook(Book book)
        {
            database.books.Add(DBToLibrary.LibraryToBook(book));
            database.SaveChanges();
            return true;
        }

        public bool RenewBook(Book renewedBook)
        {
            var renewed = database.books.Where((book) => book.Id == renewedBook.Id).First();
            if (renewed == null)
            {
                return false;
            }

            renewed.ExtendLoanPeriod(DateTime.Now.AddMonths(1));
            database.SaveChanges();
            return true;
        }

        public bool RenewBook(int renewedBookId)
        {
            var renewed = database.books.Where((book) => book.Id == renewedBookId).First();
            if (renewed == null)
            {
                return false;
            }
            
            renewed.ExtendLoanPeriod(DateTime.Now.AddMonths(1));
            database.SaveChanges();
            return true;
        }

        public bool IsBookAlreadyTaken(Book bookToCheck)
        {
            var bookFromDB = database.books.Where((book) => book.Id == bookToCheck.Id).First();
            if (bookFromDB == null)
            {
                return false;
            }
            return bookFromDB.IsTaken;
        }

        public int GetNextId()
        {
            int maxId = database.books.Max((book) => book.Id);
            return maxId + 1;
        }
    }
}
