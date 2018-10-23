using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_librarian.Camera
{
    class RecognisedBookEventArgs : EventArgs
    {
        public Book book { get; private set; }

        public RecognisedBookEventArgs(Book book)
        {
            this.book = book;
        }
    }
}
