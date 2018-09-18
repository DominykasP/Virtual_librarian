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
    public partial class registerScreen : UserControl
    {
        Form1 form1;

        public registerScreen(Form1 forma1)
        {
            form1 = forma1;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1.Controls.Remove(this);

            ChooseLoginScreen chooseLoginScreen = new ChooseLoginScreen(form1);
            form1.Controls.Add(chooseLoginScreen);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Registracija sėkminga");

            form1.Controls.Remove(this);

            mainUserScreen mainUScreen = new mainUserScreen(form1);
            form1.Controls.Add(mainUScreen);
        }
    }
}
