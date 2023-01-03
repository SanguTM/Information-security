using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KetvirtaUzduotis
{
    public partial class NewPassword : Form
    {
        //DES DESalg = DES.Create();
        string fn = "";

        public NewPassword(string fileName)
        {
            InitializeComponent();
            fn = fileName;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string Final = DESencript.DecryptTextFromFile(fn, true/*, DESencript.Key, DESencript.IV*/);

            using (FileStream fs = File.Open(fn, FileMode.OpenOrCreate))
            {
                StreamWriter write = new StreamWriter(fs);
                write.BaseStream.Seek(0, SeekOrigin.End);
                write.WriteLine("#Name:#" + NameTextBox.Text + "#Note:#" + NoteTextBox.Text + "#URL:#" + URLTextBox.Text + "$" + passwordTextBox.Text + "%");

                write.Flush();
                write.Close();
                fs.Close();
            }

            string allfile = File.ReadAllText(fn);

            DESencript.EncryptTextToFile(allfile, fn/*, DESencript.Key, DESencript.IV*/);

            if (string.IsNullOrEmpty(URLTextBox.Text))
            {
                NoteTextBox.Text = "null";
            }
            if (string.IsNullOrEmpty(URLTextBox.Text))
            {
                URLTextBox.Text = "null";
            }

            MessageBox.Show("Name: " + NameTextBox.Text + " Note: " + NoteTextBox.Text + " URL: " + URLTextBox.Text + " Password: " + passwordTextBox.Text);
            NameTextBox.Clear();
            NoteTextBox.Clear();
            URLTextBox.Clear();
            passwordTextBox.Clear();

            //string test = DESencript.DecryptTextFromFile(fn, false/*, DESencript.Key, DESencript.IV*/);
            //MessageBox.Show("Testas:" + test);
        }
    }
}
