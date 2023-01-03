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

namespace AntraUzduotis2
{
    //https://foxlearn.com/windows-forms/how-to-encrypt-and-decrypt-files-using-aes-encryption-algorithm-in-csharp-396.html
    //https://ourcodeworld.com/articles/read/471/how-to-encrypt-and-decrypt-files-using-the-aes-encryption-algorithm-in-c-sharp
    public partial class Form1 : Form
    {
        //  Call this function to remove the key from memory after use for security
        [DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(IntPtr Destination, int Length);
        public Form1()
        {
            InitializeComponent();
        }

        public static byte[] GenerateSalt()
        {
            byte[] data = new byte[32];
            using (RNGCryptoServiceProvider rgnCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rgnCryptoServiceProvider.GetBytes(data);
            }
            return data;
        }

        private void FileEncrypt(string inputFile, string password, byte[] salt, string mode)
        {
            //byte[] salt = GenerateSalt();
            byte[] passwords = Encoding.UTF8.GetBytes(password);
            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;//aes 256 bit encryption c#
            AES.BlockSize = 128;//aes 128 bit encryption c#
            AES.Padding = PaddingMode.PKCS7;
            var key = new Rfc2898DeriveBytes(passwords, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            if (mode == "CFB")
            {
                AES.Mode = CipherMode.CFB;
            }

            if (mode == "CBC")
            {
                AES.Mode = CipherMode.CFB;
            }

            if (mode == "OFB")
            {
                AES.Mode = CipherMode.OFB;
            }

            if (mode == "CFB")
            {
                AES.Mode = CipherMode.CFB;
            }


            FileStream fsCrypt = new FileStream(inputFile + ".aes", FileMode.Create);
            fsCrypt.Write(salt, 0, salt.Length);

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);

            FileStream fsIn = new FileStream(inputFile, FileMode.Open);

            byte[] buffer = new byte[1048576];
            int read;

            try
            {
                while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Application.DoEvents(); // -> for responsive GUI, using Task will be better!
                    cs.Write(buffer, 0, read);
                }

                // Close up
                fsIn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                cs.Close();
                fsCrypt.Close();
            }

        }

        private void FileDecrypt(string inputFileName, string outputFileName, string password, string mode)
        {
            byte[] passwords = Encoding.UTF8.GetBytes(password);
            byte[] salt = new byte[32];
            using (FileStream fsCrypt = new FileStream(inputFileName, FileMode.Open))
            {
                fsCrypt.Read(salt, 0, salt.Length);
                RijndaelManaged AES = new RijndaelManaged();
                AES.KeySize = 256;//aes 256 bit encryption c#
                AES.BlockSize = 128;//aes 128 bit encryption c#
                var key = new Rfc2898DeriveBytes(passwords, salt, 50000);
                AES.Key = key.GetBytes(AES.KeySize / 8);
                AES.IV = key.GetBytes(AES.BlockSize / 8);
                AES.Padding = PaddingMode.PKCS7;
                //AES.Mode = CipherMode.CFB;

                if (mode == "CFB")
                {
                    AES.Mode = CipherMode.CFB;
                }

                if (mode == "CBC")
                {
                    AES.Mode = CipherMode.CFB;
                }

                if (mode == "OFB")
                {
                    AES.Mode = CipherMode.OFB;
                }

                if (mode == "CFB")
                {
                    AES.Mode = CipherMode.CFB;
                }

                CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

                string path = @"F:\Paskaitos\Informacijos saugumas\InformacijosSaugumas\AntraUzduotis2\testas\Decript.txt";

                FileStream fsOut = new FileStream(path, FileMode.Create);

                int read;
                byte[] buffer = new byte[1048576];

                try
                {
                    while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        Application.DoEvents();
                        fsOut.Write(buffer, 0, read);
                    }
                }
                catch (CryptographicException ex_CryptographicException)
                {
                    Console.WriteLine("CryptographicException error: " + ex_CryptographicException.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                try
                {
                    cs.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error by closing CryptoStream: " + ex.Message);
                }
                finally
                {
                    fsOut.Close();
                    fsCrypt.Close();
                }
            }
        }

        private void Encript_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[32];
            using (RNGCryptoServiceProvider rgnCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rgnCryptoServiceProvider.GetBytes(data);
            }


            string mode = ModeComboBox.Text;

            string password = PasswordBox.Text;
            GCHandle gCHandle = GCHandle.Alloc(password, GCHandleType.Pinned);
            FileEncrypt(FileImputBox.Text, password, data, mode);
            ZeroMemory(gCHandle.AddrOfPinnedObject(), password.Length * 2);
            gCHandle.Free();
        }

        private void Decript_Click(object sender, EventArgs e)
        {
            string mode = ModeComboBox.Text;

            string password = PasswordBox.Text;
            GCHandle gch = GCHandle.Alloc(password, GCHandleType.Pinned);
            FileDecrypt(FileImputBox.Text, FileImputBox.Text, password, mode);
            ZeroMemory(gch.AddrOfPinnedObject(), password.Length * 2);
            gch.Free();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "All files|*.*" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                    FileImputBox.Text = ofd.FileName;
            }
        }
    }
}
