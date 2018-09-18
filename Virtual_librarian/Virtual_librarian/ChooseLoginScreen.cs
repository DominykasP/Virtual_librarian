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
    public partial class ChooseLoginScreen : UserControl
    {
        private Form1 form1;

        public ChooseLoginScreen(Form1 forma1)
        {
            form1 = forma1;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1.Controls.Remove(this);

            loginFace loginFaceScreen = new loginFace(form1);
            form1.Controls.Add(loginFaceScreen);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form1.Controls.Remove(this);

            registerScreen registerScreen = new registerScreen(form1);
            form1.Controls.Add(registerScreen);
        }
    }
}
