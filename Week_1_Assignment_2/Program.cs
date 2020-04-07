using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program structures = new Program();
            structures.Start();
        }

        void Start()
        {
            Person[] people = new Person[3];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = ReadPerson();
                Console.WriteLine("------------------------\n"); 
            }
            
            foreach(Person p in people)
            {
                PrintPerson(p);
            }

            CelebrateBirthday(ref people[0]);
            PrintPerson(people[0]);
            Console.ReadKey();
        }

        void CelebrateBirthday(ref Person p) 
        {
            p.Age++;
        }

        void PrintPerson(Person p)
        {
            Console.WriteLine("Name: {0} {1}", p.FirstName, p.LastName);
            Console.WriteLine("Age : {0}", p.Age);
            Console.WriteLine("City: {0}", p.City);
            Console.Write("Gender: ");
            PrintGender(p.Gender);
            Console.WriteLine("\n");

        }

        void PrintGender(GenderType g)
        {
            if (g.Equals(GenderType.Female))
            {
                Console.Write("f");
            }
            else
            {
                Console.Write("m");
            }
        }

        Person ReadPerson()
        {
            Person newPerson;

            newPerson.FirstName = ReadString("Enter your first name: ");
            newPerson.LastName = ReadString("Enter your last name: ");
            newPerson.Age = ReadInt("Enter your age: ", 0, 130);
            newPerson.City = ReadString("Enter your city: ");
            newPerson.Gender = ReadGender("Enter your gender: ");

            return newPerson;
        }

        GenderType ReadGender(string question)
        {
            string userInput;
            GenderType output = GenderType.Male;
            do
            {
                userInput = ReadString(question).ToLower().Trim();
               
                if (userInput.Equals("m") || userInput.Equals("male"))
                {
                    output = GenderType.Male;
                    break;
                }
                else if (userInput.Equals("f") || userInput.Equals("female"))
                {
                    output = GenderType.Female;
                    break;
                }

            } while (true);

            return output;
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
