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

        KnyguKolekcija<Book> knyguKolekcija = new KnyguKolekcija<Book>();

        public BookDBHelper()
        {
            books = DarbasSuFailais.NuskaitytiIsFailo<List<Knyga>>(PathsToFiles.pathToBooksFile);

            foreach(Book book in books)
            {
                knyguKolekcija.prideti(book);
            }
        }

        public Book getBookByIndex(int id)
        {
            return knyguKolekcija[id];
        }


        public Book GetBookByCode(string isbn, string code)
        {
             Book rastaKnyga = new Book();
             var knyguSarasas = knygos.OfType<Book>();
             var rastosKnygos = from knyga in knyguSarasas
                                  where (knyga.Isbn == isbn) && (knyga.Kodas == kodas)
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
            var knyguSarasas = knygos.OfType<Book>();
            var rastosKnygos = from knyga in knyguSarasas
                               where (knyga.ArPaimta == true) && (knyga.Skaitytojas.Equals(zmogus))
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
            var knyguSarasas = knygos.OfType<Book>();
            var rastosKnygos = from knyga in knyguSarasas
                               where knyga.Equals(grazinamaKnyga)
                               select knyga;
            foreach (var knyga in rastosKnygos)
            {
                grazinama = knyga;
            }
            if (grazinama != null)
            {
                grazinama.ReturnBook();

                return DarbasSuFailais.IrasytiIFaila<List<Book>>("..\\..\\Duomenu failai\\knygos.xml", knygos);
            }
            else
            {
                return false;
            }
        }

        public List<Book> Find(string search)
        {
         List<Book> atitinkanciosKnygos = new List<Book>();
                    var knyguSarasas = knygos.OfType<Book>();
                    var rastosKnygos = from knyga in knyguSarasas
                                       where knyga.Pavadinimas.Contains(search) || knyga.Autorius.Contains(search)
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
                return DarbasSuFailais.IrasytiIFaila<List<Knyga>>("..\\..\\Duomenu failai\\knygos.xml", knygos);
            }
            else
            {
                return false;
            }
        }

        public bool TakeBook(Book takenBook, Person reader)
        {
            Book paimta = new Book();
            var knyguSarasas = knygos.OfType<Book>();
            var rastosKnygos = from knyga in knyguSarasas
                               where knyga.Equals(paimamaKnyga)
                               select knyga;
            foreach (var knyga in rastosKnygos)
            {
                paimta = knyga;
            }

            paimta.paimtiKnyga(skaitytojas, DateTime.Now, DateTime.Now.AddMonths(1));

            return DarbasSuFailais.IrasytiIFaila<List<Knyga>>("..\\..\\Duomenu failai\\knygos.xml", knygos);
        }

        public bool AddNewBook(Book book)
        {
            books.Add(book);
            knyguKolekcija.prideti(book);
            return DarbasSuFailais.IrasytiIFaila<List<Knyga>>("..\\..\\Duomenu failai\\knygos.xml", knygos);
        }

        public bool RenewBook(Book renewedBook)
        {
            Book pratesti = new Book();
            var knyguSarasas = knygos.OfType<Book>();
            var rastosKnygos = from knyga in knyguSarasas
                               where knyga.Equals(pratesiamaKnyga)
                               select knyga;
            foreach (var knyga in rastosKnygos)
            {
                pratesti = knyga;
            }

            pratesti.pratestiKnyga(DateTime.Now.AddMonths(1));

            return DarbasSuFailais.IrasytiIFaila<List<Knyga>>("..\\..\\Duomenu failai\\knygos.xml", knygos);
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
