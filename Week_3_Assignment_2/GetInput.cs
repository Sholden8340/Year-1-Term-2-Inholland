using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2Sane
{
    class GetInput
    {
        public int ReadInt(string message)
        {
            Console.Write(message);
            int number = int.Parse(Console.ReadLine());

            return number;
        }

        public int ReadInt(string message, int min, int max)
        {
            int number;

            do
            {
                Console.Write(message);
                number = int.Parse(Console.ReadLine());

                if (number < min || number > max)
                    Console.WriteLine("Enter a number between {0} and {1}", min, max);

            } while (number < min || number > max);


            return number;
        }

        public string ReadString(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}
