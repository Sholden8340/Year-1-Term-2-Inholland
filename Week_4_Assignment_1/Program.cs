using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program StorePerson = new Program();
            StorePerson.Start();
        }

        void Start()
        {
            GetInput getName = new GetInput();
            string name = getName.ReadString("Enter your name: ");
           
            string filename = @"..\..\" + name + ".txt";

            if (File.Exists(filename))
            {
                Console.WriteLine("Welcome back, {0}!", name);
                Console.WriteLine("This is the information we have: ");
                DisplayPerson ( ReadPerson(filename) );
            }
            else
            {
                Console.WriteLine("Welcome {0}!", name);
                Person p = ReadPerson();
                WritePerson(p, filename);
            }
           
            Console.ReadKey();

        }

        Person ReadPerson()
        {
            GetInput g = new GetInput();
            Person p = new Person();
            string filename = @"..\..\" + ("{0}.txt", p.Name);


            p.Name = g.ReadString("Enter your name: ");
            p.Age = g.ReadInt("Enter your age: ", 0, 130);
            p.City = g.ReadString("Enter your city: ");
            return p;
        }

        void DisplayPerson(Person p)
        {
            Console.WriteLine("Name: {0}", p.Name);
            Console.WriteLine("Age:  {0}" ,p.Age);
            Console.WriteLine("City: {0}", p.City);

        }

        void WritePerson(Person p, string filename)
        {
            if (!File.Exists(filename))
            {
                StreamWriter file = new StreamWriter(filename);
                file.WriteLine($"{p.Name},{p.Age},{p.City}");
                file.Close();
                Console.WriteLine("\nWritten to file");
            }
        }

        Person ReadPerson(string filename)
        {
            Person p = new Person();
            if (File.Exists(filename))
            {
                StreamReader reader = new StreamReader(filename);
                string file = reader.ReadLine();
                string[] data = file.Split(',');

                p.Name = data[0];
                p.Age = int.Parse(data[1]);
                p.City = data[2];

                reader.Close();
            }

            
            return p;
        }
    }
}
