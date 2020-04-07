using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_1_Assignment_0
{
    class Program
    {
        static void Main(string[] args)
        {
            Program getAge = new Program();
            getAge.Start();
        }

        void Start()
        {
            int value = ReadInt("Ebnter a value:");
            Console.WriteLine("You entered {0}", value);

            int age = ReadInt("How old are you?", 0 , 120);
            Console.WriteLine("You are {0} years old ", age);

            string name = ReadString("What is your name");
            Console.WriteLine("Nice to meet you {0}.", name);

            Console.ReadKey();
        }

        int ReadInt(string message)
        {
            Console.Write(message);
            int number = int.Parse(Console.ReadLine());

            return number;
        }

        int ReadInt(string message, int min, int max)
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

        string ReadString(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}
