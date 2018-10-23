using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_librarian.DB_helpers
{
    interface IBookDBHelper
    {
        List<Book> GetAllBooks();
        List<Book> Find(string search);

        Book GetBookByCode(string isbn, string code);
        List<Book> GetReadersBooks(Person reader);

        bool AddNewBook(Book book);
        bool DeleteBook(Book book);
        bool TakeBook(Book takenBook, Person reader);
        bool ReturnBook(Book returnedBook);
        bool RenewBook(Book renewedBook);
    }
}
