using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Virtual_librarian.DB_helpers;

namespace Virtual_librarian
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        public BookDBHelper bookDBHelper = new BookDBHelper();
        public HumanDBHelper humanDBHelper = new HumanDBHelper();

        private UCChooseLogin ucChooseLogin;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ucChooseLogin = new UCChooseLogin(this);
            ucChooseLogin.Dock = DockStyle.Bottom;
            this.Controls.Add(ucChooseLogin);
        }
    }
}
