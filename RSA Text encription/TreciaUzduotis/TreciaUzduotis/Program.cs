using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace TreciaUzduotis
{
    class Program
    {
        //https://stackoverflow.com/questions/70118328/my-rsa-algorithm-doesnt-function-fully-as-expected
        static void Main(string[] args)
        {
            Console.WriteLine("Insert first primary number:");
            int p = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Insert second primary number:");
            int q = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Insert text");
            string x = Console.ReadLine();

            List<int> valueList = new List<int>();

            byte[] ASCIIvalues = Encoding.ASCII.GetBytes(x);
            foreach (var value in ASCIIvalues)
            {
                //x = Convert.ToString((int)value);
                valueList.Add(value);
            }

            /*foreach (var value in x)
            {
                x = Convert.ToString((int)value);
            }*/

            //calculate n
            int n = p * q;

            //calculate fn
            int fn = (p - 1) * (q - 1);

            List<int> eValues = new List<int>();

            for (int i = 1; i < fn; i++)
            {
                if (Coprime(fn, i))
                {
                    eValues.Add(i);
                }
            }

            Random rn = new Random();

            int e = eValues[rn.Next(0, eValues.Count)]; //e for random number which 1 < e < fn and is co prime of fn

            // Using the extended euclidean algorithm, find 'd' which satisfies
            // where (d * e) mod fn = 1 find d
            int d = 0;

            for (int k = 1; k < n; k++)
            {
                if ((k * e) % fn == 1)
                {
                    d = k;
                    Console.WriteLine(d);
                    break;
                }
            }

            int[] public_key = new int[] { e, n }; //(e = 17, n = 3233)
            Console.WriteLine("Public key: e = " + e + " n = " + n);
            int[] private_key = new int[] { d, n }; //(d = 2753, n = 3233)
            Console.WriteLine("Private key: d = " + d + " n = " + n);

            // Given the plaintext P=123, the ciphertext C is :
            //Console.Write("Enter number to encrypt:");
            //BigInteger m = int.Parse(Console.ReadLine()); //m = message, int atm but can be string to convet to int soon

            List<string> resultList = new List<string>();
            List<int> publicKeyList = new List<int>();
            List<int> priviteKeyList = new List<int>();

            foreach (int item in valueList) // Loop through List with foreach
            {
                int c = eMod(Convert.ToInt32(item), public_key[0], n); //cipher text = (message ^ e) mod n
                publicKeyList.Add(c);
                //Console.WriteLine("Encrypted with public key: " + c);

                int f = eMod(c, private_key[0], n);
                priviteKeyList.Add(f);
                //Console.WriteLine("Decrypted with private key: Result = " + f);

                string s = Encoding.ASCII.GetString(new byte[] { (byte)f });
                resultList.Add(s);
            }

            Console.WriteLine(("Encrypted with public key: "));
            Console.WriteLine(string.Join(" ", publicKeyList));

            Console.WriteLine(("Decrypted with private key: "));
            Console.WriteLine(string.Join(" ", priviteKeyList));

            Console.WriteLine(("Your text:"));
            Console.WriteLine(string.Join("",resultList));
            //Console.WriteLine("Your text: Result = " + s);
        }

        public static bool Coprime(int value1, int value2)
        {
            return GetGCDByModulus(value1, value2) == 1;
        }

        public static int GetGCDByModulus(int value1, int value2)
        {
            while (value1 != 0 && value2 != 0)
            {
                if (value1 > value2)
                    value1 %= value2;
                else
                    value2 %= value1;
            }
            return Math.Max(value1, value2);
        }

        static int eMod(int a, int b, int c) //where a^b % c;
        {
            //base case
            if (b == 0)
            {
                return 1;
            }
            else if (b % 2 == 0)
            {
                int d = eMod(a, b / 2, c);
                //int result = d * d % c;
                return ((d * d) % c);
            }
            else
            {
                return ((a % c) * eMod(a, b - 1, c)) % c;
            }
        }
    }
}
