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
    public partial class addBook : UserControl
    {
        Form1 form1;

        public addBook(Form1 forma1)
        {
            form1 = forma1;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form1.Controls.Remove(this);

            mainUserScreen mainUScreen = new mainUserScreen(form1);
            form1.Controls.Add(mainUScreen);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "9 780994 234001";
            textBox2.Text = "12fda32ef";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Nekreipti demesio
        }

        private void button5_Click(object sender, EventArgs e)
        {
            form1.Controls.Remove(this);

            mainUserScreen mainUScreen = new mainUserScreen(form1);
            form1.Controls.Add(mainUScreen);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            form1.Controls.Remove(this);

            mainUserScreen mainUScreen = new mainUserScreen(form1);
            form1.Controls.Add(mainUScreen);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            button1.Visible = false;
            button5.Visible = true;
            groupBox3.Visible = false;
        }
    }
}
