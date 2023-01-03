using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KetvirtaUzduotis
{
    class DESencript
    {
        public static byte[] Key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8};
        public static byte[] IV = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };

        //https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.des.create?view=net-6.0
        public static void EncryptTextToFile(String Data, String FileName/*, byte[] Key, byte[] IV*/)
        {
            try
            {
                // Create or open the specified file.
                FileStream fStream = File.Open(FileName, FileMode.OpenOrCreate);

                // Create a new DES object.
                DES DESalg = DES.Create();

                // Create a CryptoStream using the FileStream
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(fStream,
                    DESalg.CreateEncryptor(Key, IV),
                    CryptoStreamMode.Write);

                // Create a StreamWriter using the CryptoStream.
                StreamWriter sWriter = new StreamWriter(cStream);

                // Write the data to the stream
                // to encrypt it.
                sWriter.WriteLine(Data);

                // Close the streams and
                // close the file.
                sWriter.Close();
                cStream.Close();
                fStream.Close();
            }
            catch (CryptographicException e)
            {
                MessageBox.Show("A Cryptographic error occurred: {0}", e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                MessageBox.Show("A file error occurred: {0}", e.Message);
            }
        }

        public static string DecryptTextFromFile(String FileName, bool ToText/*, byte[] Key, byte[] IV*/)
        {
            try
            {
                // Create or open the specified file.
                FileStream fStream = File.Open(FileName, FileMode.OpenOrCreate);

                // Create a new DES object.
                DES DESalg = DES.Create();

                // Create a CryptoStream using the FileStream
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(fStream,
                    DESalg.CreateDecryptor(Key, IV),
                    CryptoStreamMode.Read);

                // Create a StreamReader using the CryptoStream.
                StreamReader sReader = new StreamReader(cStream);

                // Read the data from the stream
                // to decrypt it.
                string val = sReader.ReadToEnd();

                // Close the streams and
                // close the file.
                sReader.Close();
                cStream.Close();
                fStream.Close();

                if (ToText == true)
                {
                    using (StreamWriter writer = new StreamWriter(FileName))
                    {
                        writer.WriteLine(val);
                    }
                }

                // Return the string.
                return val;
            }
            catch (CryptographicException e)
            {
                MessageBox.Show("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
            catch (UnauthorizedAccessException e)
            {
                MessageBox.Show("A file error occurred: {0}", e.Message);
                return null;
            }
        }
        public IEnumerable<string> ReadLines(Func<Stream> streamProvider,
                                     Encoding encoding)
        {
            using (var stream = streamProvider())
            using (var reader = new StreamReader(stream, encoding))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }

}
