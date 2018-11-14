using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesFunctions;
using Interfaces;
using LibraryObjects;
using System.Data.Common;
using System.Configuration;

namespace Database
{
    public class BookDBHelper : IBookDBHelper
    {
        private List<Book> books;

        BookCollection<Book> bookCollection = new BookCollection<Book>();

        public BookDBHelper()
        {
            //books = FileIO.FileRead<List<Book>>(PathsToFiles.pathToBooksFile);
            books =  SQLbooks();
            if (books == null)
            {
                books = new List<Book>();
            }
            foreach(Book book in books)
            {
                bookCollection.Add(book);
            }
        }

        public List<Book> SQLbooks()
        {
            string provider = ConfigurationManager.AppSettings["providerName"];

            string connectionString = ConfigurationManager.AppSettings["connectionString"];

            // DbProviderFactories generates an 
            // instance of a DbProviderFactory

            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

            // The DBConnection represents the DB connection
            using (DbConnection connection =
                factory.CreateConnection())
            {
                // Check if a connection was made
                if (connection == null)
                {
                    Console.WriteLine("Connection Error");
                    Console.ReadLine();
                    //return;
                }

                // The DB data needed to open the correct DB
                connection.ConnectionString = connectionString;

                // Open the DB connection
                connection.Open();

                // Allows you to pass queries to the DB
                DbCommand command = factory.CreateCommand();
                

                if (command == null)
                {
                    Console.WriteLine("Command Error");
                    Console.ReadLine();
                   // return;
                }

                // Set the DB connection for commands
                command.Connection = connection;

                // The query you want to issue
                command.CommandText = "Select * From books";

                // DbDataReader reads the row results
                // from the query
                //StringBuilder read = new StringBuilder();
                List<Book> books = new List<Book>();
                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    // Advance to the next results
                    while (dataReader.Read())
                    {
                        // Output results using row names
                        //Console.WriteLine($"{dataReader["ProdId"]} " +
                        // $"{dataReader["Product"]}");
                        // read.Append(($"{dataReader["Id"]} + " + $"{dataReader["Name"]}" + $"{dataReader["Author"]}" + $"{dataReader["Publisher"]}" + $"{dataReader["Year"]}" + $"{dataReader["Pages"]}" + $"{dataReader["Isbn"]}" + $"{dataReader["Code"]}" + $"{dataReader["IsTaken"]}" + $"{dataReader["TakenAt"]}" + $"{dataReader["TakenAt"]}" + $"{dataReader["ReturnAt"]}" + $"{dataReader["reader"]}"));
                        Book book = new Book();
                        book.Id = Convert.ToInt32(dataReader["Id"]);
                        book.Name = dataReader["Name"].ToString();
                        book.Author = dataReader["Author"].ToString();
                        book.Publisher = dataReader["Publisher"].ToString();
                        book.Year = Convert.ToDateTime(dataReader["Year"]);
                        book.Isbn = dataReader["Isbn"].ToString();
                        book.Code = dataReader["Code"].ToString();
                        book.IsTaken = Convert.ToBoolean(dataReader["IsTaken"]);
                        //book.Reader = Convert.ToInt32(dataReader["Id"]);
                        book.TakenAt = Convert.ToDateTime(dataReader["TakenAt"]);
                        book.ReturnAt = Convert.ToDateTime(dataReader["ReturnAt"]);
                        //book.TimeRemaining = Convert.ToInt32(dataReader["Id"]);
                        books.Add(book);
                    }
                }
                //Console.ReadLine();
                //return read;
                return books;
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

        public Book GetBookByIsbn(string isbn)
        {
            Book foundBook = null;
            var bookList = books.OfType<Book>();
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
