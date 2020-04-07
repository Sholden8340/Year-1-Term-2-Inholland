using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        const string ALPHABET = "ABC.DEFGHIJLMNOPQRSTUVWXyZabcdefghijklmnopqrstuvwxyz?";

        static void Main(string[] args)
        {
            Program oneTimePad = new Program();
            oneTimePad.Start();
        }

        void Start()
        {
            string message = ReadTools.ReadString("Enter a message to encrpyt: ");
            string key = CreateSecretKey(40);
            try
            {
                string oneTimePad = OneTimePad(message, key);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Error Occurred, Alphabet does not contain character");
            }
            Console.WriteLine(key);
            Console.WriteLine(message);

            Console.WriteLine();
            Console.ReadKey();
        }
        string OneTimePad(string message, string key)
        {
            string result = "";

            for (int i = 0; i < message.Length; i++)
            {
                int index = ALPHABET.IndexOf(message[i]) + ALPHABET.IndexOf(key[i]);
                index %= ALPHABET.Length;
                result += ALPHABET[index];
            }

            return result;
        }

        string CreateSecretKey(int length)
        {
            Random rng = new Random();
            
            string key = "";
/*            
 *            for (int i = 0; i < length; i++)
            {
                //65 A 97 a  91 .. 96 
                char c;
                do
                {
                    c = (char)rng.Next(65, 97); 

                } while (c > 90 && c < 97);
                key += c;
            }

            return key;*/

            for (int i = 0; i < length; i++)
            {
                key += ALPHABET[rng.Next(0, ALPHABET.Length)];
            }

            return key;
        }
    }
}
