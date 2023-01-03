using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KetvirtaUzduotis
{
    public partial class Menu : Form
    {
       

        string fn = "";
        public Menu(string fileName)
        {
            InitializeComponent();
            fn = fileName;
        }

        private void NewPasswordButton_Click(object sender, EventArgs e)
        {
            NewPassword f2 = new NewPassword(fn);
            f2.ShowDialog();
        }

        private void EditPasswordButton_Click(object sender, EventArgs e)
        {
            EditPassword f3 = new EditPassword(fn);
            f3.ShowDialog();
        }
    }
}
