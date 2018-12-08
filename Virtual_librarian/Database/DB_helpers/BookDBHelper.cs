using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesFunctions;
using Interfaces;
using LibraryObjects;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace Database
{
    public class BookDBHelper : IBookDBHelper
    {
        private Lazy<List<Book>> books = null;
        private Lazy<List<BookWithPerson>> booksWithPersons = null;
        private string db;

        BookCollection<Book> bookCollection = new BookCollection<Book>();

        public BookDBHelper()
        {
            //books = new Lazy<List<Book>>(() => FileIO.FileRead<List<Book>>(PathsToFiles.pathToBooksFile));
            /*if (books == null)
            {
                books = new List<Book>();
            }*/
            books = new Lazy<List<Book>>(() => SQLBooksRead());
            db = "Server=tcp:biblioteka.database.windows.net,1433;Initial Catalog=biblioteka;Persist Security Info=False;User ID='biblioteka';Password='sqlbaze1!';MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        public List<BookWithPerson> JoinBP(List<Person> people, List<Book> books)
        {
            //List<BookWithPerson> newList = new List<BookWithPerson>();
            var result =
                from book in books
                where book.IsTaken = true
                join person in people on book.ReaderId equals person.Id into bwp
                from person in bwp.DefaultIfEmpty()
                select new
                {
                    id = book.Id,
                    name = book.Name,
                    author = book.Author,
                    publisher = book.Publisher,
                    year = book.Year,
                    pages = book.Pages,
                    isbn = book.Isbn,
                    code = book.Code,
                    isTaken = book.IsTaken == false ? "false" : "true",
                    readerId = book.ReaderId,
                    takenAt = book.TakenAt,
                    returnAt = book.ReturnAt,
                    timeRemaining = book.TimeRemaining,
                    personName = person.Name,
                    personSurname = person.Surname
                };

            
            List<BookWithPerson> newList = result.ToList<BookWithPerson>();
            List<BookWithPerson> sarasas = new List<BookWithPerson>(result.ToList<BookWithPerson>());
        }

        public List<Book> SQLBooksRead()
        {

            SqlConnection conn;
            //string myConnectionString = ConfigurationManager.ConnectionStrings["biblioteka"].ConnectionString;
            conn = new SqlConnection(db);
            try
            {
                //conn.ConnectionString = myConnectionString;
                conn.Open();

                List<Book> books = new List<Book>();

                SqlDataReader mySQLReader = null;
                String sqlString = "SELECT * FROM books";
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlString, conn);
                DataSet books1 = new DataSet();
                adapter.Fill(books1, "books");
                books = ConvertSet(books1);

                return books;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Book> ConvertSet(DataSet books1)
        {
            List<DataRow> list = books1.Tables["books"].AsEnumerable().ToList();
            List<Book> books = new List<Book>();
            foreach (var dr in list)
            {
                Book book = new Book
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = dr["Name"].ToString().TrimEnd(),
                    Author = dr["Author"].ToString().TrimEnd(),
                    Publisher = dr["Publisher"].ToString().TrimEnd(),
                    Pages = Convert.ToInt32(dr["Pages"]),
                    Year = Convert.ToDateTime(dr["Year"]),
                    Isbn = dr["Isbn"].ToString().TrimEnd(),
                    Code = dr["Code"].ToString().TrimEnd(),
                    IsTaken = Convert.ToBoolean(dr["IsTaken"]),
                    ReaderId = Convert.ToInt32(dr["UserId"]),
                    TakenAt = Convert.ToDateTime(dr["TakenAt"]),
                    ReturnAt = Convert.ToDateTime(dr["ReturnAt"])
                };
                books.Add(book);
            }
            return books;
        }

        public List<Book> SQLBooksRead2()
        {

            SqlConnection conn;
            //string myConnectionString = ConfigurationManager.ConnectionStrings["biblioteka"].ConnectionString;
            conn = new SqlConnection(db);
            try
            {
                //conn.ConnectionString = myConnectionString;
                conn.Open();

                List<Book> books = new List<Book>();

                SqlDataReader mySQLReader = null;
                String sqlString = "SELECT * FROM books";
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                mySQLReader = cmd.ExecuteReader();
                while (mySQLReader.Read())
                {
                    // Output results using row names
                    //Console.WriteLine($"{dataReader["ProdId"]} " +
                    // $"{dataReader["Product"]}");
                    // read.Append(($"{dataReader["Id"]} + " + $"{dataReader["Name"]}" + $"{dataReader["Author"]}" + $"{dataReader["Publisher"]}" + $"{dataReader["Year"]}" + $"{dataReader["Pages"]}" + $"{dataReader["Isbn"]}" + $"{dataReader["Code"]}" + $"{dataReader["IsTaken"]}" + $"{dataReader["TakenAt"]}" + $"{dataReader["TakenAt"]}" + $"{dataReader["ReturnAt"]}" + $"{dataReader["reader"]}"));
                    Book book = new Book();
                    book.Id = Convert.ToInt32(mySQLReader["Id"]);
                    book.Name = mySQLReader["Name"].ToString().TrimEnd();
                    book.Author = mySQLReader["Author"].ToString().TrimEnd();
                    book.Publisher = mySQLReader["Publisher"].ToString().TrimEnd();
                    book.Pages = Convert.ToInt32(mySQLReader["Pages"]);
                    book.Year = Convert.ToDateTime(mySQLReader["Year"]);
                    book.Isbn = mySQLReader["Isbn"].ToString().TrimEnd();
                    book.Code = mySQLReader["Code"].ToString().TrimEnd();
                    book.IsTaken = Convert.ToBoolean(mySQLReader["IsTaken"]);
                    book.ReaderId = Convert.ToInt32(mySQLReader["UserId"]);
                    book.TakenAt = Convert.ToDateTime(mySQLReader["TakenAt"]);
                    book.ReturnAt = Convert.ToDateTime(mySQLReader["ReturnAt"]);
                    //book.TimeRemaining = Convert.ToInt32(dataReader["Id"]);
                    books.Add(book);
                }
                return books;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool SQLBooksUpdate(Book changedBook, int changedBookId)
        {
            SqlConnection conn;
            //string myConnectionString = ConfigurationManager.ConnectionStrings["biblioteka"].ConnectionString;
            conn = new SqlConnection(db);
            try
            {
                //conn.ConnectionString = myConnectionString;
                conn.Open();

                List<Book> books = new List<Book>();
                var sqlua = new SqlDataAdapter("SELECT * FROM books", conn);


                //String sqlString = "DELETE FROM books WHERE ID = '" + changedBook.Id + "'";
                //SqlCommand cmd = new SqlCommand(sqlString, conn);
                //cmd.ExecuteNonQuery();
                Console.WriteLine(changedBook.Year);
                String sqlString = "UPDATE books SET Id = @id, Name = @Name, Author = @Author, Publisher = @Publisher, Year = @Year, Pages = @Pages, Isbn = @Isbn, Code = @Code, IsTaken = @IsTaken, TakenAt = @TakenAt, ReturnAt = @ReturnAt, UserId = @UserId WHERE ID = " + changedBookId + ";";
                //sqlString += " VALUES  (@Id, @Name, @Author, @Publisher, @Year, @Pages, @Isbn, @Code, @IsTaken, @TakenAt, @ReturnAt, @UserId)";
                SqlCommand cmd2 = new SqlCommand(sqlString, conn);
                cmd2.Parameters.AddWithValue("@Id", changedBook.Id);
                cmd2.Parameters.AddWithValue("@Name", changedBook.Name);
                cmd2.Parameters.AddWithValue("@Author", changedBook.Author);
                cmd2.Parameters.AddWithValue("@Publisher", changedBook.Publisher);
                cmd2.Parameters.AddWithValue("@Year", changedBook.Year);
                cmd2.Parameters.AddWithValue("@Pages", changedBook.Pages);
                cmd2.Parameters.AddWithValue("@Isbn", changedBook.Isbn);
                cmd2.Parameters.AddWithValue("@Code", changedBook.Code);
                cmd2.Parameters.AddWithValue("@IsTaken", changedBook.IsTaken);
                cmd2.Parameters.AddWithValue("@TakenAt", changedBook.TakenAt);
                cmd2.Parameters.AddWithValue("@ReturnAt", changedBook.ReturnAt);
                cmd2.Parameters.AddWithValue("@UserId", changedBook.ReaderId);
                sqlua.UpdateCommand = cmd2;
                sqlua.UpdateCommand.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool SQLBooksDelete(Book changedBook)
        {
            SqlConnection conn;
            //string myConnectionString = ConfigurationManager.ConnectionStrings["biblioteka"].ConnectionString;
            conn = new SqlConnection(db);
            try
            {
                //conn.ConnectionString = myConnectionString;
                conn.Open();

                List<Book> books = new List<Book>();


                String sqlString = "DELETE FROM books WHERE ID = '" + changedBook.Id + "'";
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool SQLBooksAdd(Book changedBook)
        {
            SqlConnection conn;
            //string myConnectionString = ConfigurationManager.ConnectionStrings["biblioteka"].ConnectionString;
            conn = new SqlConnection(db);
            try
            {
                //conn.ConnectionString = myConnectionString;
                conn.Open();

                List<Book> books = new List<Book>();


                String sqlString;
                sqlString = "INSERT INTO books (Id, Name, Author, Publisher, Year, Pages, Isbn, Code, IsTaken, TakenAt, ReturnAt, UserId)";
                sqlString += " VALUES  (@Id, @Name, @Author, @Publisher, @Year, @Pages, @Isbn, @Code, @IsTaken, @TakenAt, @ReturnAt, @UserId)";
                SqlCommand cmd2 = new SqlCommand(sqlString, conn);
                cmd2.Parameters.AddWithValue("@Id", GetNextId());
                cmd2.Parameters.AddWithValue("@Name", changedBook.Name);
                cmd2.Parameters.AddWithValue("@Author", changedBook.Author);
                cmd2.Parameters.AddWithValue("@Publisher", changedBook.Publisher);
                cmd2.Parameters.AddWithValue("@Year", changedBook.Year);
                cmd2.Parameters.AddWithValue("@Pages", changedBook.Pages);
                cmd2.Parameters.AddWithValue("@Isbn", changedBook.Isbn);
                cmd2.Parameters.AddWithValue("@Code", changedBook.Code);
                cmd2.Parameters.AddWithValue("@IsTaken", changedBook.IsTaken);
                cmd2.Parameters.AddWithValue("@TakenAt", changedBook.TakenAt);
                cmd2.Parameters.AddWithValue("@ReturnAt", changedBook.ReturnAt);
                cmd2.Parameters.AddWithValue("@UserId", changedBook.ReaderId);
                cmd2.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public Book GetBookById(int id)
        {
            foreach (Book book in books.Value)
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
            foreach (var book in foundBooks)
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
                             where (book.IsTaken == true) && (book.ReaderId == reader.Id)
                             orderby book
                             select book;
            foreach (var book in foundBooks)
            {
                readersBooks.Add(book);
            }


            return readersBooks;
        }

        public List<Book> GetReadersBooks(int readerId)
        {
            List<Book> readersBooks = new List<Book>();
            var bookList = books.Value.OfType<Book>();
            var foundBooks = from book in bookList
                             where (book.IsTaken == true) && (book.ReaderId == readerId)
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

                //return FileIO.FileWrite<List<Book>>(PathsToFiles.pathToBooksFile, books.Value);
                return SQLBooksUpdate(returnedBook, returnedBook.Id);
            }
            else
            {
                return false;
            }
        }

        public bool ReturnBook(int returnedBookId)
        {
            Book returned = new Book();
            var bookList = books.Value.OfType<Book>();
            var foundBooks = from book in bookList
                             where book.Id == returnedBookId
                             select book;
            foreach (var book in foundBooks)
            {
                returned = book;
            }
            if (returned != null)
            {
                returned.ReturnBook();

                //return FileIO.FileWrite<List<Book>>(PathsToFiles.pathToBooksFile, books.Value);
                return SQLBooksUpdate(returned, returnedBookId);
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
            bookToEdit.ReaderId = newBook.ReaderId;
            bookToEdit.ReturnAt = newBook.ReturnAt;
            bookToEdit.TakenAt = newBook.TakenAt;
            bookToEdit.Year = newBook.Year;

            //return FileIO.FileWrite<List<Book>>(PathsToFiles.pathToBooksFile, books.Value);
            return SQLBooksUpdate(newBook, bookId);
        }

        public bool DeleteBook(Book book)
        {
            bool isSuccessful = books.Value.Remove(book);
            if (isSuccessful == true)
            {
                //return FileIO.FileWrite<List<Book>>(PathsToFiles.pathToBooksFile, books.Value);
                return SQLBooksDelete(book);
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
                //return FileIO.FileWrite<List<Book>>(PathsToFiles.pathToBooksFile, books.Value);
                return SQLBooksDelete(bookToDelete);
            }
            else
            {
                return false;
            }
        }

        /*
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

            taken.TakeBook(reader.Id, DateTime.Now, DateTime.Now.AddMonths(1));

            return FileIO.FileWrite<List<Book>>(PathsToFiles.pathToBooksFile, books.Value);
        }
        */

        public bool TakeBook(int takenBookId, int readerId)
        {
            Book taken = new Book();
            var bookList = books.Value.OfType<Book>();
            var foundBooks = from book in bookList
                             where book.Id == takenBookId
                             select book;
            foreach (var book in foundBooks)
            {
                taken = book;
            }

            taken.TakeBook(readerId, DateTime.Now, DateTime.Now.AddMonths(1));

            //return FileIO.FileWrite<List<Book>>(PathsToFiles.pathToBooksFile, books.Value);
            return SQLBooksUpdate(taken, taken.Id);
        }

        public bool AddNewBook(Book book)
        {
            books.Value.Add(book);
            bookCollection.Add(book);
            return SQLBooksAdd(book);
            //return FileIO.FileWrite<List<Book>>(PathsToFiles.pathToBooksFile, books.Value);
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

            //return FileIO.FileWrite<List<Book>>(PathsToFiles.pathToBooksFile, books.Value);
            return SQLBooksUpdate(renewedBook, renewedBook.Id);
        }

        public bool RenewBook(int renewedBookId)
        {
            Book renewed = new Book();
            var bookList = books.Value.OfType<Book>();
            var foundBooks = from book in bookList
                             where book.Id == renewedBookId
                             select book;
            foreach (var book in foundBooks)
            {
                renewed = book;
            }

            renewed.ExtendLoanPeriod(DateTime.Now.AddMonths(1));

            //return FileIO.FileWrite<List<Book>>(PathsToFiles.pathToBooksFile, books.Value);
            return SQLBooksUpdate(renewed, renewedBookId);
        }

        public bool IsBookAlreadyTaken(Book bookToCheck)
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

        public int GetNextId()
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
