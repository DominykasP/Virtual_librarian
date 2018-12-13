using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database;
using FilesFunctions;
using LibraryObjects;

namespace Virtual_librarian
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        /*
        public BookDBHelper bookDBHelperByBookService = new BookDBHelper();
        public HumanDBHelper humanDBHelperByPersonService = new HumanDBHelper();
        */

        public BookService.BookServiceSoapClient bookDBHelperByBookService = new BookService.BookServiceSoapClient();
        public PersonService.PersonServiceSoapClient humanDBHelperByPersonService = new PersonService.PersonServiceSoapClient();

        private CopyFiles copyFiles = new CopyFiles();

        private UCChooseLogin ucChooseLogin;

        public MainForm()
        {
            InitializeComponent();
            copyFiles.CopyFilesFromToDirectory(@"..\..\..\packages\VDK.EmguCV.x86.2.4.10\content\x86", @"x86");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ucChooseLogin = new UCChooseLogin(this);
            ucChooseLogin.Dock = DockStyle.Bottom;
            this.Controls.Add(ucChooseLogin);
            BookDBHelper b = new BookDBHelper();
            HumanDBHelper h = new HumanDBHelper();
            List<Book> books = new List<Book>();
            List<Person> people = new List<Person>();
            List<BookWithPerson> bp = new List<BookWithPerson>();
            books = b.SQLBooksRead();
            people = h.SQLPersonsRead();
            bp = b.JoinBP(people, books);
        }
    }
}
