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
            //--------------------------



            DatabaseWithEntity.BookDBHelper entityBookDBHelper = new DatabaseWithEntity.BookDBHelper();
            var knyga = entityBookDBHelper.GetAllBooks();
            /*
            entityBookDBHelper.EditBook(5, new LibraryObjects.Book()
            {
                Id=5,
                Name="Altoriu Šešely",
                Author="Vincas Mykolaitis Putinas",
                Publisher="Alma Littera",
                Year= new DateTime(1974,12,21),
                Pages=200,
                Isbn="34457665667536",
                Code="2345544454223",
                IsTaken=true,
                TakenAt=new DateTime(2018,12,13),
                ReturnAt=new DateTime(2019,01,10),
                ReaderId=1
            });
            */
            /*
            using (DatabaseWithEntity.biblioteka2Entities duombaze = new DatabaseWithEntity.biblioteka2Entities())
            {
                DatabaseWithEntity.users useris = duombaze.users.Where((x) => x.Name == "E").FirstOrDefault();
                MessageBox.Show(useris.Id.ToString());
            }
            */
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ucChooseLogin = new UCChooseLogin(this);
            ucChooseLogin.Dock = DockStyle.Bottom;
            this.Controls.Add(ucChooseLogin);
        }
    }
}
