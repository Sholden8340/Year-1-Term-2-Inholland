using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class LingoGame
    {
        public enum LetterState 
        { 
            Correct,
            WrongPosition,
            Incorrect
        }
        public string SecretWord { get; set; }

        public void Init(string word)
        {

            SecretWord = word.ToLower();
        }

        public void PlayLingo()
        {
            //Console.WriteLine(SecretWord);
           
            for (int i = 0; i < 5; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("{0} guesses remaining", 5-i);
                string guess = GetWord().ToLower();


                if (guess.Equals(SecretWord))
                {
                    Console.WriteLine("You win!");
                    return;
                }
                EvaluateWord(guess);
            }
            Console.WriteLine("You lose! The Word was {0}", SecretWord);
        }

        public void EvaluateWord(string guess)
        {
            string guessedLetters = "0";
            for (int i = 0; i < guess.Length; i++)
            {
                
                LetterState letter;
                if (SecretWord.Contains(guess[i]) && !(guessedLetters.Contains(guess[i])))
                {
                    letter = LetterState.WrongPosition;
                    
                    if (SecretWord[i].Equals(guess[i]))
                    {
                        letter = LetterState.Correct;
                    }
                }
                else
                {
                    letter = LetterState.Incorrect;

                }
                DisplayLetter(letter, guess[i]);
                guessedLetters += guess[i];
            }
            Console.WriteLine();

        }

        public void DisplayLetter(LetterState state, char c)
        {

            switch (state)
            {
                case LetterState.Correct:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case LetterState.WrongPosition:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;
                case LetterState.Incorrect:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }

            Console.Write(c);
        }

        public string GetWord()
        {
            string s;
            do
            {
                Console.Write("\nEnter a 5 letter word: ");
                s = Console.ReadLine();
            } while (s.Length != 5);

            return s;
        }

    }
}
