using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Program Translate = new Program();
            Translate.Start();


        }

        void Start()
        {
            string filename = @"../../dictionary.csv";
            Dictionary<string, string> words = ReadWords(filename);


            TranslateWords(words);



            Console.ReadKey();
        }

        Dictionary<string, string> ReadWords(string filename)
        {
            Dictionary<string, string>  wordList = new Dictionary<string, string>();

            StreamReader file = new StreamReader(filename);

            if (!File.Exists(filename))
            {
                Console.WriteLine("File does not exist");
                return null;

            }

            while (!file.EndOfStream)
            {
                string[] line = file.ReadLine().Split(';');
                wordList.Add(line[0], line[1]);
            }

            return wordList;
        }

        void TranslateWords(Dictionary<string, string> words)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Enter a word to Translate: ");
                string word = Console.ReadLine().Trim();

                if (word.ToLower().Trim().Equals("stop"))
                {
                    Console.WriteLine("Exiting");
                    return;
                }
                else if (word.ToLower().Trim().Equals("listallwords"))
                {
                    ListAllWords(words);
                }
                else if (words.ContainsKey(word))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0} => {1}", word, words[word]);
                }
                else
                {
                    Console.WriteLine("Word not in Dictionary");
                }

            }
        }

        void ListAllWords(Dictionary<string, string> words)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (KeyValuePair<string, string> x in words)
            {
                Console.WriteLine("{0} => {1}", x.Key, x.Value);
            }
        }
    }

}
