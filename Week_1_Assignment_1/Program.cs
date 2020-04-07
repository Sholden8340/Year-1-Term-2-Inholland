using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_1_Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program month = new Program();
            month.Start();
        }

        void Start()
        {
            PrintMonths();

            Month month = (Month)ReadInt("Enter a month number: ", 1, 12);
            PrintMonth(month);

            PrintMonth(ReadMonth("Enter a Month Number: "));
            Console.ReadKey();
        }

        Month ReadMonth(string message)
        {
            int userMonth;
            do
            {
                userMonth = ReadInt(message);

                if (!Enum.IsDefined(typeof(Month), userMonth)) 
                    Console.WriteLine("Enter a number between 1 and 12");


            }while (!Enum.IsDefined ( typeof(Month), userMonth));

            return (Month)userMonth;    

            /*return (Month)ReadInt(message, 1, 12);*/

        }

        void PrintMonth(Month month)
        {
            Console.WriteLine(month);
        }

        void PrintMonths()
        {
            Month month;
            for(int i = 1; i <=12; i++)
            {
                month = (Month)i;
                Console.WriteLine("{0,3}. {1}", i, month);
            }
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
    }
}
