using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2Sane
{
    class HangmanGame
    {
        private string secretWord, guessedWord;
        private const int MAX_GUESSES = 10;

        public string SecretWord { get; set; }

        public string GuessedWord { get; set; }

        void Init(string secretWord)
        {
            SecretWord = secretWord;
            string blank = null;
            for(int i =0; i < secretWord.Length; i++)
            {
                blank += '*';
            }
            GuessedWord = blank;
        }

        public void PlayHangman()
        {
            Init(SelectWord(ListOfWords()));
            List<char> enteredLetters = new List<char>();
            int remainingGuesses = MAX_GUESSES;

            //DisplayWord(SecretWord);

            while (!Hangman())
            {
                char guess = ReadLetter(enteredLetters);
                enteredLetters.Add(guess);

                DisplayGuessedLetters(enteredLetters);
                


                if (!GuessLetter(guess))
                {
                    remainingGuesses--;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Remaining guesses: {0}", remainingGuesses);

                    if (remainingGuesses == 0)
                    {
                        
                        Console.WriteLine("You Lose!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("The Word was: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(SecretWord);
                        break;
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
                DisplayWord(GuessedWord);
                Console.WriteLine("-----------------------\n");
            }
            if (Hangman())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You Win!");
                Console.Write("The Word was: ");
                Console.WriteLine(SecretWord);

            }
            //GuessLetter(ReadLetter(enteredLetters));
        }

        bool Hangman()
        {
            return GuessedWord.Equals(SecretWord);
        }

        char ReadLetter(List<char> blacklistLetters)
        {
            GetInput input = new GetInput();

            string userLetter = null;
            do
            {
                userLetter = input.ReadString("Enter a Letter: ").ToLower().Trim();

            } while (blacklistLetters.Contains(userLetter[0]));

            return userLetter[0];
        }

        bool GuessLetter(char letter)
        {
            bool existsInWord = false;
            string word = null;

            for(int i = 0; i < SecretWord.Length; i++)
            {  
                if (letter.Equals(SecretWord[i]))
                {
                    word += letter;
                    existsInWord = true;
                }
                else if (!GuessedWord[i].Equals('*'))
                {
                    word += GuessedWord[i];
                }
                else
                {
                    word += '*';
                }
            }
            GuessedWord = word;
            return existsInWord;
        }

        void DisplayGuessedLetters(List<char> letters)
        {
            Console.Write("Entered Letters: ");
            foreach (char c in letters)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine("\n");
        }

        void DisplayWord(string word)
        {
            foreach (char c in word)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }

        List<string> ListOfWords()
        {
            List<string> words = new List<string>()
            {
                "economics",
                "love",
                "internet",
                "television",
                "science",
                "library",
                "nature",
                "fact",
                "product",
                "idea",
                "investment",
                "society",
                "activity",
                "story",
                "industry",
                "media",
                "oven",
                "community",
                "definition",
                "safety"
            };

            return words;
        }

        string SelectWord(List<string> words)
        {
            Random rng = new Random();
            return words[rng.Next(0, 20)];
        }
    }
}
