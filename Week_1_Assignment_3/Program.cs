using System;
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
            Program yahtzee = new Program();
            yahtzee.Start();
        }
        void Start()
        {
            /*            Dice d1 = new Dice();

                        do
                        {
                            d1.Throw();
                            d1.DisplayValue();

                            Console.WriteLine("\nAgain?");
                            if(!Console.ReadLine().Equals("y"))
                            {
                                break;
                            }
                        } while (true);*/

            
            /*YahtzeeGame yahtzee = new YahtzeeGame();
            yahtzee.Init();

            yahtzee.Throw();
            yahtzee.DisplayValues();
            
            Console.WriteLine();
            
            yahtzee.Throw();
            yahtzee.DisplayValues();


            Console.ReadKey();*/


            YahtzeeGame yahtzeeGame = new YahtzeeGame();
            yahtzeeGame.Init();
            PlayYahtzee(yahtzeeGame); // play the game

            Console.ReadKey();
        }

        void PlayYahtzee(YahtzeeGame game)
        {
            int nrOfAttempts = 0;
            do
            {
                game.Throw(); // throw all dices
                game.DisplayValues(); // display the thrown
                Console.WriteLine();
                nrOfAttempts++;
            } while (!game.Yahtzee());
            Console.WriteLine("Number of attempts needed (Yahtzee): {0}", nrOfAttempts);
        }
        }
    }

