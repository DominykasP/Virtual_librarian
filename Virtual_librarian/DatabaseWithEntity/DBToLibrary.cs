using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseWithEntity
{
    class DBToLibrary
    {
        //-----------------------------------
        //          Books
        //-----------------------------------
        public static LibraryObjects.Book BookToLibrary(DatabaseWithEntity.books book)
        {
            if (book == null)
            {
                return null;
            }
            else
            {
                return new LibraryObjects.Book()
                {
                    Id = book.Id,
                    Name = book.Name,
                    Author = book.Author,
                    Publisher = book.Publisher,
                    Year = book.Year != null ? DateTime.ParseExact(book.Year, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue,
                    Pages = book.Pages.Value,
                    Isbn = book.Isbn,
                    Code = book.Code,
                    IsTaken = book.IsTaken,
                    TakenAt = book.TakenAt != null ? DateTime.ParseExact(book.TakenAt, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue,
                    ReturnAt = book.ReturnAt != null ? DateTime.ParseExact(book.ReturnAt, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue,
                    ReaderId = book.UserId.Value
                };
            }
        }

        public static DatabaseWithEntity.books LibraryToBook(LibraryObjects.Book book)
        {
            if (book == null)
            {
                return null;
            }
            else
            {
                return new DatabaseWithEntity.books()
                {
                    Id = book.Id,
                    Name = book.Name,
                    Author = book.Author,
                    Publisher = book.Publisher,
                    Year = book.Year.ToShortDateString(),
                    Pages = book.Pages,
                    Isbn = book.Isbn,
                    Code = book.Code,
                    IsTaken = book.IsTaken,
                    TakenAt = book.TakenAt.ToShortDateString(),
                    ReturnAt = book.ReturnAt.ToShortDateString(),
                    UserId = book.ReaderId
                };
            }
        }

        public static List<LibraryObjects.Book> BookListToLibrary(List<DatabaseWithEntity.books> books)
        {
            if (books == null)
            {
                return null;
            }
            else
            {
                List<LibraryObjects.Book> newBooks = new List<LibraryObjects.Book>();
                foreach (var book in books)
                {
                    newBooks.Add(BookToLibrary(book));
                }
                return newBooks;
            }
        }

        //-----------------------------------
        //          Users
        //-----------------------------------
        public static LibraryObjects.Person UserToLibrary(DatabaseWithEntity.users user)
        {
            if (user == null)
            {
                return null;
            }
            else
            {
                return new LibraryObjects.Person()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Password = user.Password,
                    BirthDate = user.BirthDate != null ? DateTime.ParseExact(user.BirthDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    TypeId = user.TypeID
                };
            }
        }

        public static DatabaseWithEntity.users LibraryToUser(LibraryObjects.Person person)
        {
            if (person == null)
            {
                return null;
            }
            else
            {
                return new DatabaseWithEntity.users()
                {
                    Id = person.Id,
                    Name = person.Name,
                    Surname = person.Surname,
                    Password = person.Password,
                    BirthDate = person.BirthDate.ToShortDateString(),
                    PhoneNumber = person.PhoneNumber,
                    Email = person.Email,
                    TypeID = person.TypeId
                };
            }
        }

        public static List<LibraryObjects.Person> UserListToLibrary(List<DatabaseWithEntity.users> users)
        {
            if (users == null)
            {
                return null;
            }
            else
            {
                List<LibraryObjects.Person> newPersons = new List<LibraryObjects.Person>();
                foreach (var user in users)
                {
                    newPersons.Add(UserToLibrary(user));
                }
                return newPersons;
            }
        }
    }
}
