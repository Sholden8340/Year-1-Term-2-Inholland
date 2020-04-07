using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Program WordFinder = new Program();
            WordFinder.Start();
        }

        void Start()
        {
            string filename = @"../../tweets2018.txt";
            GetInput read = new GetInput();
            string word = read.ReadString("Enter a word to search for: "); ;

            SearchWordInFile(filename, word);
            Console.ReadLine();
        }

        bool WordInLine(string line, string word)
        {
            return line.ToUpper().Contains(word.ToUpper());
        }

        int SearchWordInFile(string filename, string word)
        {
            int count  = 0;
            StreamReader read = new StreamReader(filename);
            if (File.Exists(filename))
            {
                while (!read.EndOfStream)
                {
                    string line = read.ReadLine();
                    if(WordInLine(line, word))
                    {
                        DisplayWordInLine(line, word);
                        count++;
                    }
                }
            }
            read.Close();
            return count;
        }

        void DisplayWordInLine(string line, string word)
        {
            int wordStart = line.ToUpper().IndexOf(word.ToUpper());
            int wordEnd = line.ToUpper().IndexOf(word.ToUpper()) + word.Length;

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(line.Substring(0, wordStart));

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(line.Substring(wordStart, word.Length));

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(line.Substring(wordEnd));
            Console.WriteLine('\n');

        }

    }
}
