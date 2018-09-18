using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Virtual_librarian
{
    public partial class mainUserScreen : UserControl
    {
        Form1 form1;

        public mainUserScreen(Form1 forma1)
        {
            form1 = forma1;
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            form1.Controls.Remove(this);

            ChooseLoginScreen chooseLoginScreen = new ChooseLoginScreen(form1);
            form1.Controls.Add(chooseLoginScreen);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1.Controls.Remove(this);

            addBook addBookScreen = new addBook(form1);
            form1.Controls.Add(addBookScreen);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form1.Controls.Remove(this);

            addBook addBookScreen = new addBook(form1);
            form1.Controls.Add(addBookScreen);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            form1.Controls.Remove(this);

            allBooks allBooksScreen = new allBooks(form1);
            form1.Controls.Add(allBooksScreen);
        }
    }
}
