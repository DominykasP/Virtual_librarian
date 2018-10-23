using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_librarian.Camera
{
    class RecognisedBookEventArgs : EventArgs
    {
        public Knyga book { get; private set; }

        public RecognisedBookEventArgs(Knyga book)
        {
            this.book = book;
        }
    }
}
