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

        BookCollection<Book> bookCollection = new BookCollection<Book>();

        public BookDBHelper()
        {
            books = FileIO.FileRead<List<Book>>(PathsToFiles.pathToBooksFile);

            foreach(Book book in books)
            {
                bookCollection.Add(book);
            }
        }

        public Book getBookByIndex(int id)
        {
            return bookCollection[id];
        }


        public Book GetBookByCode(string isbn, string code)
        {
             Book foundBook = new Book();
             var bookList = books.OfType<Book>();
             var foundBooks = from book in bookList
                                  where (book.Isbn == isbn) && (book.Code == code)
                                  select book;
             foreach(var book in foundBooks)
             {
                 foundBook = book;
             }
             return foundBook;
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public List<Book> GetReadersBooks(Person reader)
        {
            List<Book> readersBooks = new List<Book>();
            var bookList = books.OfType<Book>();
            var foundBooks = from book in bookList
                               where (book.IsTaken == true) && (book.Reader.Equals(reader))
                               orderby book
                               select book;
            foreach (var book in foundBooks)
            {
                readersBooks.Add(book);
            }


            return readersBooks;
        }

        public bool ReturnBook(Book returnedBook)
        {
            Book returned = new Book();
            var bookList = books.OfType<Book>();
            var foundBooks = from book in bookList
                               where book.Equals(returnedBook)
                               select book;
            foreach (var book in foundBooks)
            {
                returned = book;
            }
            if (returned != null)
            {
                returned.ReturnBook();

                return FileIO.FileWrite<List<Book>>(PathsToFiles.pathToBooksFile, books);
            }
            else
            {
                return false;
            }
        }

        public List<Book> Find(string search)
        {
         List<Book> correspondingBooks = new List<Book>();
                    var bookList = books.OfType<Book>();
                    var foundBooks = from book in bookList
                                       where book.Name.Contains(search) || book.Author.Contains(search)
                                       orderby book
                                       select book;

            foreach (var book in foundBooks)
            {
                correspondingBooks.Add(book);
            }


            return correspondingBooks;
        }

        public bool DeleteBook(Book book)
        {
            bool isSuccessful = books.Remove(book);
            if (isSuccessful == true)
            {
                return FileIO.FileWrite<List<Book>>(PathsToFiles.pathToBooksFile, books);
            }
            else
            {
                return false;
            }
        }

        public bool TakeBook(Book takenBook, Person reader)
        {
            Book taken = new Book();
            var bookList = books.OfType<Book>();
            var foundBooks = from book in bookList
                               where book.Equals(takenBook)
                               select book;
            foreach (var book in foundBooks)
            {
                taken = book;
            }

            taken.TakeBook(reader, DateTime.Now, DateTime.Now.AddMonths(1));

            return FileIO.FileWrite<List<Book>>(PathsToFiles.pathToBooksFile, books);
        }

        public bool AddNewBook(Book book)
        {
            books.Add(book);
            bookCollection.Add(book);
            return FileIO.FileWrite<List<Book>>(PathsToFiles.pathToBooksFile, books);
        }

        public bool RenewBook(Book renewedBook)
        {
            Book renewed = new Book();
            var bookList = books.OfType<Book>();
            var foundBooks = from book in bookList
                               where book.Equals(renewedBook)
                               select book;
            foreach (var book in foundBooks)
            {
                renewed = book;
            }

            renewed.ExtendLoanPeriod(DateTime.Now.AddMonths(1));

            return FileIO.FileWrite<List<Book>>(PathsToFiles.pathToBooksFile, books);
        }

        public bool isBookAlreadyTaken(Book bookToCheck)
        {
            Book currentBook = new Book();
            var bookList = books.OfType<Book>();
            var booksFound = from book in bookList
                               where book.Equals(bookToCheck)
                               select book;
            foreach (var book in booksFound)
            {
                currentBook = book;
            }

            return currentBook.IsTaken;
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
