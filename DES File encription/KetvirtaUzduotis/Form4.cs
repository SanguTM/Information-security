using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KetvirtaUzduotis
{
    public partial class EditPassword : Form
    {
        string fn = "";
       
        public EditPassword(string fileName)
        {
            InitializeComponent();
            fn = fileName;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            string Final = DESencript.DecryptTextFromFile(fn, true/*, DESencript.Key, DESencript.IV*/);
            string result = "";

            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                MessageBox.Show("Name not found");
            }
            else
            {
                string FirstString = "#Name:#";
                string LastString = "#Note:#";

                string name;

                int Pos1 = Final.IndexOf(FirstString) + FirstString.Length;
                int Pos2 = Final.IndexOf(LastString, Pos1);
                name = Final.Substring(Pos1, Pos2 - Pos1);

                if (NameTextBox.Text != name)
                {
                    MessageBox.Show("Name not found");
                }
                else
                {
                    FirstString = "#Name:#" + NameTextBox.Text + "#Note:#";
                    LastString = "#";

                    string note;

                    Pos1 = Final.IndexOf(FirstString) + FirstString.Length;
                    Pos2 = Final.IndexOf(LastString, Pos1);
                    note = Final.Substring(Pos1, Pos2 - Pos1);
                    
                    FirstString = "#Name:#" + NameTextBox.Text + "#Note:#" + note + "#URL:#";
                    LastString = "$";

                    string URL;

                    Pos1 = Final.IndexOf(FirstString) + FirstString.Length;
                    Pos2 = Final.IndexOf(LastString, Pos1);
                    URL = Final.Substring(Pos1, Pos2 - Pos1);

                    string password;

                    FirstString = "#Name:#" + NameTextBox.Text + "#Note:#" + note + "#URL:#" + URL + "$";
                    LastString = "%";

                    Pos1 = Final.IndexOf(FirstString) + FirstString.Length;
                    Pos2 = Final.IndexOf(LastString, Pos1);
                    password = Final.Substring(Pos1, Pos2 - Pos1);

                    result = "#Name:#" + NameTextBox.Text + "#Note:#" + note + "#URL:#" + URL + "$" + password + "%";   
                }
            }
            if (string.IsNullOrEmpty(URLTextBox.Text))
            {
                NoteTextBox.Text = "null";
            }
            if (string.IsNullOrEmpty(URLTextBox.Text))
            {
                URLTextBox.Text = "null";
            }

            string NewImput = "#Name:#" + NameTextBox.Text + "#Note:#" + NoteTextBox.Text + "#URL:#" + URLTextBox.Text + "$" + passwordTextBox.Text + "%";

            string str = File.ReadAllText(fn);
            str = str.Replace(result, NewImput);
            File.WriteAllText(fn, str);

            MessageBox.Show("Name: " + NameTextBox.Text + " Note: " + NoteTextBox.Text + " URL: " + URLTextBox.Text + " Password: " + passwordTextBox.Text);

            NameTextBox.Clear();
            NoteTextBox.Clear();
            URLTextBox.Clear();
            passwordTextBox.Clear();

            string allfile = File.ReadAllText(fn);
            DESencript.EncryptTextToFile(allfile, fn/*, DESencript.Key, DESencript.IV*/); 
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            FindFields();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string result = FindFields();
            string Final = DESencript.DecryptTextFromFile(fn, true/*, DESencript.Key, DESencript.IV*/);

            var Lines = File.ReadAllLines(fn);
            var newLines = Lines.Where(line => !line.Contains(result));
            File.WriteAllLines(fn, newLines);

            string allfile = File.ReadAllText(fn);

           // MessageBox.Show(allfile);

            DESencript.EncryptTextToFile(allfile, fn/*, DESencript.Key, DESencript.IV*/);

            Final = DESencript.DecryptTextFromFile(fn, false/*, DESencript.Key, DESencript.IV*/);
           // MessageBox.Show(Final);
        }

        private string FindFields()
        {
            string Final = DESencript.DecryptTextFromFile(fn, true/*, DESencript.Key, DESencript.IV*/);

            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                if (string.IsNullOrEmpty(NoteTextBox.Text))
                {
                    if (string.IsNullOrEmpty(URLTextBox.Text))
                    {
                        MessageBox.Show("All fields are empty");
                    }
                    else
                    {
                        string FirstString = "#URL:#";
                        string LastString = "$";

                        string URL;

                        int Pos1 = Final.IndexOf(FirstString) + FirstString.Length;
                        int Pos2 = Final.IndexOf(LastString, Pos1);
                        URL = Final.Substring(Pos1, Pos2 - Pos1);

                        /*if (URLTextBox.Text != URL)
                        {
                            MessageBox.Show("URL not found");
                        }
                        else
                        {*/
                            FirstString = "#Note:#";
                            LastString = "#URL:#" + URLTextBox.Text;

                            string note;

                            Pos1 = Final.IndexOf(FirstString) + FirstString.Length;
                            Pos2 = Final.IndexOf(LastString, Pos1);
                            note = Final.Substring(Pos1, Pos2 - Pos1);
                            NoteTextBox.Text = note;

                            FirstString = "#Name:#";
                            LastString = "#Note:#" + NoteTextBox.Text;

                            string name;

                            Pos1 = Final.IndexOf(FirstString) + FirstString.Length;
                            Pos2 = Final.IndexOf(LastString, Pos1);
                            name = Final.Substring(Pos1, Pos2 - Pos1);
                            NameTextBox.Text = name;

                            string password;

                            FirstString = "#Name:#" + NameTextBox.Text + "#Note:#" + NoteTextBox.Text + "#URL:#" + URLTextBox.Text + "$";
                            LastString = "%";

                            Pos1 = Final.IndexOf(FirstString) + FirstString.Length;
                            Pos2 = Final.IndexOf(LastString, Pos1);
                            password = Final.Substring(Pos1, Pos2 - Pos1);
                            passwordTextBox.Text = password;
                        //}
                    }
                }
                else
                {
                    string FirstString = "#Note:#";
                    string LastString = "#URL:#";

                    string note;

                    int Pos1 = Final.IndexOf(FirstString) + FirstString.Length;
                    int Pos2 = Final.IndexOf(LastString, Pos1);
                    note = Final.Substring(Pos1, Pos2 - Pos1);

                    /*if (NoteTextBox.Text != note)
                    {
                        MessageBox.Show("Note not found");
                    }
                    else
                    {*/
                        FirstString = "#Name:#";
                        LastString = "#Note:#" + NoteTextBox.Text;

                        string name;

                        Pos1 = Final.IndexOf(FirstString) + FirstString.Length;
                        Pos2 = Final.IndexOf(LastString, Pos1);
                        name = Final.Substring(Pos1, Pos2 - Pos1);
                        NameTextBox.Text = name;

                        FirstString = "#Name:#" + NameTextBox.Text + "#Note:#" + NoteTextBox.Text + "#URL:#";
                        LastString = "$";
                        string URL;

                        Pos1 = Final.IndexOf(FirstString) + FirstString.Length;
                        Pos2 = Final.IndexOf(LastString, Pos1);
                        URL = Final.Substring(Pos1, Pos2 - Pos1);
                        URLTextBox.Text = URL;

                        string password;

                        FirstString = "#Name:#" + NameTextBox.Text + "#Note:#" + NoteTextBox.Text + "#URL:#" + URLTextBox.Text + "$";
                        LastString = "%";

                        Pos1 = Final.IndexOf(FirstString) + FirstString.Length;
                        Pos2 = Final.IndexOf(LastString, Pos1);
                        password = Final.Substring(Pos1, Pos2 - Pos1);
                        passwordTextBox.Text = password;
                    //}
                }
            }
            else
            {
                //MessageBox.Show(Final);

                string FirstString = "#Name:#";
                string LastString = "#Note:#";

                string name = "" ;

                /*int Pos1 = Final.IndexOf(FirstString) + FirstString.Length;
                int Pos2 = Final.IndexOf(LastString, Pos1);
                name = Final.Substring(Pos1, Pos2 - Pos1);*/

                

                int pos = Final.IndexOf(FirstString + NameTextBox.Text);
                if (pos < 0)
                {
                    MessageBox.Show("Name not found");
                }
               

                /*if (!NameTextBox.Text.Equals(name))
                {
                    MessageBox.Show("Name not found");
                }*/
                else
                {
                    
                    int Pos1;
                    int Pos2;

                    FirstString = "#Name:#" + NameTextBox.Text + "#Note:#";
                    LastString = "#";

                    string note;

                    Pos1 = Final.IndexOf(FirstString) + FirstString.Length;
                    Pos2 = Final.IndexOf(LastString, Pos1);
                    note = Final.Substring(Pos1, Pos2 - Pos1);
                    NoteTextBox.Text = note;

                    FirstString = "#Name:#" + NameTextBox.Text + "#Note:#" + NoteTextBox.Text + "#URL:#";
                    LastString = "$";

                    string URL;

                    Pos1 = Final.IndexOf(FirstString) + FirstString.Length;
                    Pos2 = Final.IndexOf(LastString, Pos1);
                    URL = Final.Substring(Pos1, Pos2 - Pos1);
                    URLTextBox.Text = URL;

                    string password;

                    FirstString = "#Name:#" + NameTextBox.Text + "#Note:#" + NoteTextBox.Text + "#URL:#" + URLTextBox.Text + "$";
                    LastString = "%";

                    Pos1 = Final.IndexOf(FirstString) + FirstString.Length;
                    Pos2 = Final.IndexOf(LastString, Pos1);
                    password = Final.Substring(Pos1, Pos2 - Pos1);
                    passwordTextBox.Text = password;
               }
            }

            //MessageBox.Show("Name: " + NameTextBox.Text + " Note: " + note + " URL: " + URL + " Password: " + password);
            string allfile = File.ReadAllText(fn);
            DESencript.EncryptTextToFile(allfile, fn/*, DESencript.Key, DESencript.IV*/);

            string oldstring = "#Name:#" + NameTextBox.Text + "#Note:#" + NoteTextBox.Text + "#URL:#" + URLTextBox.Text + "$" + passwordTextBox.Text + "%";

            return oldstring;
        }
    }
}
