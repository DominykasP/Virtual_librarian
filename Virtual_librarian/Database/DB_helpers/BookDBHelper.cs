using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesFunctions;
using Interfaces;
using LibraryObjects;

namespace Database
{
    public class BookDBHelper : IBookDBHelper
    {
        private Lazy<List<Book>> books = null;

        BookCollection<Book> bookCollection = new BookCollection<Book>();

        public BookDBHelper()
        {
            books = new Lazy<List<Book>>(() => FileIO.FileRead<List<Book>>(PathsToFiles.pathToBooksFile));
            /*if (books == null)
            {
                books = new List<Book>();
            }*/
            
        }

        public Book GetBookById(int id)
        {
            foreach(Book book in books.Value)
            {
                bookCollection.Add(book);
            }
            return bookCollection[id];
        }


        public Book GetBookByCode(string isbn, string code)
        {
             Book foundBook = new Book();
             var bookList = books.Value.OfType<Book>();
             var foundBooks = from book in bookList
                                  where (book.Isbn == isbn) && (book.Code == code)
                                  select book;
             foreach(var book in foundBooks)
             {
                 foundBook = book;
             }
             return foundBook;
        }

        public Book GetBookByIsbn(string isbn)
        {
            Book foundBook = null;
            var bookList = books.Value.OfType<Book>();
            var foundBooks = from book in bookList
                             where book.Isbn == isbn
                             select book;
            foreach (var book in foundBooks)
            {
                foundBook = book;
            }
            return foundBook;
        }

        public List<Book> GetAllBooks()
        {
            return books.Value;
        }

        public List<Book> GetReadersBooks(Person reader)
        {
            List<Book> readersBooks = new List<Book>();
            var bookList = books.Value.OfType<Book>();
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
            var bookList = books.Value.OfType<Book>();
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

                return FileIO.FileWrite<List<Book>>(PathsToFiles.pathToBooksFile, books.Value);
            }
            else
            {
                return false;
            }
        }

        public List<Book> Find(string search)
        {
         List<Book> correspondingBooks = new List<Book>();
                    var bookList = books.Value.OfType<Book>();
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

        public bool EditBook(int bookId, Book newBook)
        {
            Book bookToEdit = null;
            var bookList = books.Value.OfType<Book>();
            var foundBooks = from book in bookList
                             where book.Id == bookId
                             select book;
            foreach (var book in foundBooks)
            {
                bookToEdit = book;
            }

            if (bookToEdit == null)
            {
                return false;
            }

            bookToEdit.Author = newBook.Author;
            bookToEdit.Code = newBook.Code;
            bookToEdit.Isbn = newBook.Isbn;
            bookToEdit.IsTaken = newBook.IsTaken;
            bookToEdit.Name = newBook.Name;
            bookToEdit.Pages = newBook.Pages;
            bookToEdit.Publisher = newBook.Publisher;
            bookToEdit.Reader = newBook.Reader;
            bookToEdit.ReturnAt = newBook.ReturnAt;
            bookToEdit.TakenAt = newBook.TakenAt;
            bookToEdit.Year = newBook.Year;

            return FileIO.FileWrite<List<Book>>(PathsToFiles.pathToBooksFile, books.Value);
        }

        public bool DeleteBook(Book book)
        {
            bool isSuccessful = books.Value.Remove(book);
            if (isSuccessful == true)
            {
                return FileIO.FileWrite<List<Book>>(PathsToFiles.pathToBooksFile, books.Value);
            }
            else
            {
                return false;
            }
        }

        public bool DeleteBook(int bookId)
        {
            Book bookToDelete = null;
            var bookList = books.Value.OfType<Book>();
            var foundBooks = from book in bookList
                             where book.Id == bookId
                             select book;
            foreach (var book in foundBooks)
            {
                bookToDelete = book;
            }

            if (bookToDelete == null)
            {
                return false;
            }

            bool isSuccessful = books.Value.Remove(bookToDelete);
            if (isSuccessful == true)
            {
                return FileIO.FileWrite<List<Book>>(PathsToFiles.pathToBooksFile, books.Value);
            }
            else
            {
                return false;
            }
        }

        public bool TakeBook(Book takenBook, Person reader)
        {
            Book taken = new Book();
            var bookList = books.Value.OfType<Book>();
            var foundBooks = from book in bookList
                               where book.Equals(takenBook)
                               select book;
            foreach (var book in foundBooks)
            {
                taken = book;
            }

            taken.TakeBook(reader, DateTime.Now, DateTime.Now.AddMonths(1));

            return FileIO.FileWrite<List<Book>>(PathsToFiles.pathToBooksFile, books.Value);
        }

        public int AddNewBook(Book book)
        {
            books.Value.Add(book);
            bookCollection.Add(book);
            FileIO.FileWrite<List<Book>>(PathsToFiles.pathToBooksFile, books.Value);
            return book.Id;
        }

        public bool RenewBook(Book renewedBook)
        {
            Book renewed = new Book();
            var bookList = books.Value.OfType<Book>();
            var foundBooks = from book in bookList
                               where book.Equals(renewedBook)
                               select book;
            foreach (var book in foundBooks)
            {
                renewed = book;
            }

            renewed.ExtendLoanPeriod(DateTime.Now.AddMonths(1));

            return FileIO.FileWrite<List<Book>>(PathsToFiles.pathToBooksFile, books.Value);
        }

        public bool isBookAlreadyTaken(Book bookToCheck)
        {
            Book currentBook = new Book();
            var bookList = books.Value.OfType<Book>();
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
            foreach (Book book in books.Value)
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
