using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using LibraryObjects;
using DatabaseWithEntity;

/// <summary>
/// Summary description for BookService
/// </summary>
[WebService(Namespace = "api/BookService")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class BookService : System.Web.Services.WebService
{
    BookDBHelper bookDBHelper = new BookDBHelper();

    public BookService()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent();
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public Book GetBookById(int id)
    {
        return bookDBHelper.GetBookById(id);
    }

    [WebMethod]
    public Book GetBookByCode(string isbn, string code)
    {
        return bookDBHelper.GetBookByCode(isbn, code);
    }

    [WebMethod]
    public Book GetBookByIsbn(string isbn)
    {
        return bookDBHelper.GetBookByIsbn(isbn);
    }

    [WebMethod]
    public List<Book> GetAllBooks()
    {
        return bookDBHelper.GetAllBooks();
    }

    [WebMethod]
    public List<Book> GetReadersBooks(int readerId)
    {
        return bookDBHelper.GetReadersBooks(readerId);
    }

    [WebMethod]
    public bool ReturnBook(int returnedBookId)
    {
        return bookDBHelper.ReturnBook(returnedBookId);
    }

    [WebMethod]
    public List<Book> Find(string search)
    {
        return bookDBHelper.Find(search);
    }

    [WebMethod]
    public bool EditBook(int bookId, Book newBook)
    {
        return bookDBHelper.EditBook(bookId, newBook);
    }

    [WebMethod]
    public bool DeleteBook(Book book)
    {
        return bookDBHelper.DeleteBook(book);
    }

    [WebMethod]
    public bool TakeBook(int takenBookId, int readerId)
    {
        return bookDBHelper.TakeBook(takenBookId, readerId);
    }

    [WebMethod]
    public bool AddNewBook(Book book)
    {
        return bookDBHelper.AddNewBook(book);
    }

    [WebMethod]
    public bool RenewBook(int renewedBookId)
    {
        return bookDBHelper.RenewBook(renewedBookId);
    }

    [WebMethod]
    public bool IsBookAlreadyTaken(int bookToCheckId)
    {
        Book book = GetBookById(bookToCheckId);
        return bookDBHelper.IsBookAlreadyTaken(book);
    }

    [WebMethod]
    public int GetNextId()
    {
        return bookDBHelper.GetNextId();
    }


}
