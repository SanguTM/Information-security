using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirmaUzduotis
{
    class Program
    {
        private static int Mod(int a, int b)
        {
            return (a % b + b) % b;
        }

        private static string Cipher(string input, string key, bool encipher)
        {
            for (int i = 0; i < key.Length; ++i)
                if (!char.IsLetter(key[i]))
                    return null; // Error

            string output = string.Empty;
            int nonAlphaCharCount = 0;

            for (int i = 0; i < input.Length; ++i)
            {
                if (char.IsLetter(input[i]))
                {
                    bool cIsUpper = char.IsUpper(input[i]);
                    char offset = cIsUpper ? 'A' : 'a';
                    int keyIndex = (i - nonAlphaCharCount) % key.Length;
                    int k = (cIsUpper ? char.ToUpper(key[keyIndex]) : char.ToLower(key[keyIndex])) - offset;
                    k = encipher ? k : -k;
                    char ch = (char)((Mod(((input[i] + k) - offset), 26)) + offset);
                    output += ch;
                }
                else
                {
                    output += input[i];
                    ++nonAlphaCharCount;
                }
            }

            return output;
        }

        public static string Encipher(string input, string key)
        {
            return Cipher(input, key, true);
        }

        public static string Decipher(string input, string key)
        {
            return Cipher(input, key, false);
        }

        static void Main(string[] args)
        {

            string imput;
            Console.WriteLine("Please choose one\n");
            Console.WriteLine("1. Cypher\n");
            Console.WriteLine("2. Decypher\n");
            imput = Console.ReadLine().ToLower();
            string caseSwitch = imput;

            switch (caseSwitch)
            {
                case "1":
                    Console.WriteLine("Insert text");
                    string text = Console.ReadLine();

                    Console.WriteLine("Insert key");
                    string key = Console.ReadLine();

                    string cipherText = Encipher(text, key);
                    string plainText = Decipher(cipherText, key);


                    Console.WriteLine("_____________________________\n");
                    Console.WriteLine("Your text:");
                    Console.WriteLine(text);
                    Console.WriteLine("_____________________________\n");
                    Console.WriteLine("Your key:");
                    Console.WriteLine(key);
                    Console.WriteLine("_____________________________\n");
                    Console.WriteLine("Your cipher text:");
                    Console.WriteLine(cipherText);
                    Console.WriteLine("_____________________________\n");

                    Console.ReadKey();
                    break;
                case "2":
                    Console.WriteLine("Insert cipher text");
                    string cipherText1 = Console.ReadLine();

                    Console.WriteLine("Insert key");
                    string key1 = Console.ReadLine();

                    string plainText1 = Decipher(cipherText1, key1);
                    //string cipherText = Encipher(text1, key1);


                    Console.WriteLine("_____________________________\n");
                    Console.WriteLine("Your text:");
                    Console.WriteLine(plainText1);
                    Console.WriteLine("_____________________________\n");
                    Console.WriteLine("Your key:");
                    Console.WriteLine(key1);
                    Console.WriteLine("_____________________________\n");
                    Console.WriteLine("Your cipher:");
                    Console.WriteLine(cipherText1);
                    Console.WriteLine("_____________________________\n");

                    Console.ReadKey();

                    break;
                default:
                   ;
                    break;
            }
        }

    }
}