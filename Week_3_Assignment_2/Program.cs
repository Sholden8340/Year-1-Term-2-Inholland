using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2Sane
{
    class Program
    {
        static void Main(string[] args)
        {
            Program Hangman = new Program();
            Hangman.Start();

        }

        void Start()
        {
            HangmanGame hangman = new HangmanGame();          
            hangman.PlayHangman();
            Console.ReadKey();
        }

    }
}
