using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KetvirtaUzduotis
{
    public partial class Login : Form
    {
        //https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.des.create?view=net-6.0
        // Create a new DES object to generate a key
        // and initialization vector (IV).  Specify one
        // of the recognized simple names for this
        // algorithm.
        //DES DESalg = DES.Create("DES");


        public Login()
        {
            InitializeComponent();

            this.FormClosed += Form1_FormClosed;
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            string FileName = @"D:\" + UserTextBox.Text + ".txt";
            string allfile = File.ReadAllText(FileName);

            //DESencript.EncryptTextToFile(allfile, FileName/*, DESencript.Key, DESencript.IV*/);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string FileName = @"D:\" + UserTextBox.Text + ".txt";
            string allfile = File.ReadAllText(FileName);

            // Decrypt the text from a file using the file name, key, and IV.
            string Final = DESencript.DecryptTextFromFile(FileName, false/*, DESencript.Key, DESencript.IV*/);
            //MessageBox.Show(Final);

            if (Final.IndexOf("#InitPassword:#") != -1)
            {
                string password = PasswordTextBox.Text;

                string FirstString = "$";
                string LastString = "$";

                int Pos1 = Final.IndexOf(FirstString) + FirstString.Length;
                int Pos2 = Final.IndexOf(LastString, Pos1);
                Final = Final.Substring(Pos1, Pos2 - Pos1);

                if (password == Final)
                {
                    //MessageBox.Show("OK");
                    Menu f2 = new Menu(FileName);
                    f2.ShowDialog(); // Shows Form2
                }
                else
                {
                    MessageBox.Show("Incorect password");
                }
            }
            
        }

        private void CreateNewButton_Click(object sender, EventArgs e)
        {
            // Create a string to encrypt.
            string sData = "#InitPassword:#" + "$" + PasswordTextBox.Text + "$";
            string FileName = @"D:\" + UserTextBox.Text + ".txt";
            // Encrypt text to a file using the file name, key, and IV.
            DESencript.EncryptTextToFile(sData, FileName/*, DESencript.Key, DESencript.IV*/);

        }

    }
}
