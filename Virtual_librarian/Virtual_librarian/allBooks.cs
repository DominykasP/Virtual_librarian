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
    public partial class allBooks : UserControl
    {
        Form1 form1;

        public allBooks(Form1 forma1)
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

        private void allBooks_Load(object sender, EventArgs e)
        {
            ColumnHeader columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "Pavadinimas";
            columnHeader1.TextAlign = HorizontalAlignment.Left;
            columnHeader1.Width = 150;

            ColumnHeader columnHeader2 = new ColumnHeader();
            columnHeader2.Text = "Autorius";
            columnHeader2.TextAlign = HorizontalAlignment.Left;
            columnHeader2.Width = 140;

            ColumnHeader columnHeader3 = new ColumnHeader();
            columnHeader3.Text = "ISBN";
            columnHeader3.TextAlign = HorizontalAlignment.Left;
            columnHeader3.Width = 60;

            ColumnHeader columnHeader4 = new ColumnHeader();
            columnHeader4.Text = "Pridėti prie Mano užklausų";
            columnHeader4.TextAlign = HorizontalAlignment.Left;
            columnHeader4.Width = 100;

            listView1.Columns.Add(columnHeader1);
            listView1.Columns.Add(columnHeader2);
            listView1.Columns.Add(columnHeader3);
            listView1.Columns.Add(columnHeader4);

            ListViewItem knyga1 = new ListViewItem(new string[] {
                    "Liūdna pasaka", "Jonas Biliūnas", "237842348723", "|Mygtukas|"
                });

            listView1.Items.Add(knyga1);

            ListViewItem knyga2 = new ListViewItem(new string[] {
                    "Liūdna pasaka", "Jonas Biliūnas", "237842348723", "|Mygtukas|"
                });

            listView1.Items.Add(knyga2);

            ListViewItem knyga3 = new ListViewItem(new string[] {
                    "Liūdna pasaka", "Jonas Biliūnas", "237842348723", "|Mygtukas|"
                });

            listView1.Items.Add(knyga3);

            ListViewItem knyga4 = new ListViewItem(new string[] {
                    "Liūdna pasaka", "Jonas Biliūnas", "237842348723", "|Mygtukas|"
                });

            listView1.Items.Add(knyga4);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            form1.Controls.Remove(this);

            mainUserScreen mainUScreen = new mainUserScreen(form1);
            form1.Controls.Add(mainUScreen);
        }
    }
}
