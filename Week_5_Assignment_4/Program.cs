using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Program LingoGame = new Program();
            LingoGame.Start();
        }

        void Start()
        {
            List<string>words = ReadWords();
            string lingoWord = ChooseWord(words);

            LingoGame lingoGame = new LingoGame();
            lingoGame.Init(lingoWord);



            lingoGame.PlayLingo();

            Console.ReadKey();
        }

        string ChooseWord(List<string> words)
        {
            Random rng = new Random();
            return words[rng.Next(0, words.Count)];
        }

        List<string> ReadWords()
        {

            string file = @"../../words.txt";
            List<string> words = new List<string>();
            if (File.Exists(file))
            {
                StreamReader readFile = new StreamReader(file);
                while (!readFile.EndOfStream)
                {
                    string word = readFile.ReadLine();
                    if (word.Length == 5)
                    {
                        words.Add(word);
                    }

                }
            }

            return words;
        }
    }
}
