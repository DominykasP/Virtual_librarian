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
            books = DarbasSuFailais.NuskaitytiIsFailo<List<Book>>(PathsToFiles.pathToBooksFile);

            foreach(Book book in books)
            {
                bookCollection.add(book);
            }
        }

        public Book getBookByIndex(int id)
        {
            return bookCollection[id];
        }


        public Book GetBookByCode(string isbn, string code)
        {
             Book rastaKnyga = new Book();
             var knyguSarasas = books.OfType<Book>();
             var rastosKnygos = from knyga in knyguSarasas
                                  where (knyga.Isbn == isbn) && (knyga.Code == code)
                                  select knyga;
             foreach(var knyga in rastosKnygos)
             {
                 rastaKnyga = knyga;
             }
             return rastaKnyga;
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public List<Book> GetReadersBooks(Person reader)
        {
            List<Book> zmogausKnygos = new List<Book>();
            var knyguSarasas = books.OfType<Book>();
            var rastosKnygos = from knyga in knyguSarasas
                               where (knyga.IsTaken == true) && (knyga.Reader.Equals(reader))
                               orderby knyga
                               select knyga;
            foreach (var knyga in rastosKnygos)
            {
                zmogausKnygos.Add(knyga);
            }


            return zmogausKnygos;
        }

        public bool ReturnBook(Book returnedBook)
        {
            Book grazinama = new Book();
            var knyguSarasas = books.OfType<Book>();
            var rastosKnygos = from knyga in knyguSarasas
                               where knyga.Equals(returnedBook)
                               select knyga;
            foreach (var knyga in rastosKnygos)
            {
                grazinama = knyga;
            }
            if (grazinama != null)
            {
                grazinama.ReturnBook();

                return DarbasSuFailais.IrasytiIFaila<List<Book>>("..\\..\\Duomenu failai\\knygos.xml", books);
            }
            else
            {
                return false;
            }
        }

        public List<Book> Find(string search)
        {
         List<Book> atitinkanciosKnygos = new List<Book>();
                    var knyguSarasas = books.OfType<Book>();
                    var rastosKnygos = from knyga in knyguSarasas
                                       where knyga.Name.Contains(search) || knyga.Author.Contains(search)
                                       orderby knyga
                                       select knyga;

            foreach (var knyga in rastosKnygos)
            {
                atitinkanciosKnygos.Add(knyga);
            }


            return atitinkanciosKnygos;
        }

        public bool DeleteBook(Book book)
        {
            bool isSuccessful = books.Remove(book);
            if (isSuccessful == true)
            {
                return DarbasSuFailais.IrasytiIFaila<List<Book>>("..\\..\\Duomenu failai\\knygos.xml", books);
            }
            else
            {
                return false;
            }
        }

        public bool TakeBook(Book takenBook, Person reader)
        {
            Book paimta = new Book();
            var knyguSarasas = books.OfType<Book>();
            var rastosKnygos = from knyga in knyguSarasas
                               where knyga.Equals(takenBook)
                               select knyga;
            foreach (var knyga in rastosKnygos)
            {
                paimta = knyga;
            }

            paimta.TakeBook(reader, DateTime.Now, DateTime.Now.AddMonths(1));

            return DarbasSuFailais.IrasytiIFaila<List<Book>>("..\\..\\Duomenu failai\\knygos.xml", books);
        }

        public bool AddNewBook(Book book)
        {
            books.Add(book);
            bookCollection.add(book);
            return DarbasSuFailais.IrasytiIFaila<List<Book>>("..\\..\\Duomenu failai\\knygos.xml", books);
        }

        public bool RenewBook(Book renewedBook)
        {
            Book pratesti = new Book();
            var knyguSarasas = books.OfType<Book>();
            var rastosKnygos = from knyga in knyguSarasas
                               where knyga.Equals(renewedBook)
                               select knyga;
            foreach (var knyga in rastosKnygos)
            {
                pratesti = knyga;
            }

            pratesti.ExtendLoanPeriod(DateTime.Now.AddMonths(1));

            return DarbasSuFailais.IrasytiIFaila<List<Book>>("..\\..\\Duomenu failai\\knygos.xml", books);
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
