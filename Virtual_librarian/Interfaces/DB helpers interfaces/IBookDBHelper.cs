using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryObjects;

namespace Interfaces
{
   public interface IBookDBHelper
    {
        Book GetBookById(int id);
        Book GetBookByCode(string isbn, string code);
        Book GetBookByIsbn(string isbn);
        List<Book> GetAllBooks();
        List<Book> GetReadersBooks(Person reader);
        List<Book> GetReadersBooks(int readerId);
        bool ReturnBook(Book returnedBook);
        bool ReturnBook(int returnedBookId);
        List<Book> Find(string search);
        bool EditBook(int bookId, Book newBook);
        bool DeleteBook(Book book);
        bool DeleteBook(int bookId);
        bool TakeBook(int takenBookId, int readerId);
        bool AddNewBook(Book book);
        bool RenewBook(Book renewedBook);
        bool RenewBook(int renewedBookId);
        bool IsBookAlreadyTaken(Book bookToCheck);
        int GetNextId();
    }
}
