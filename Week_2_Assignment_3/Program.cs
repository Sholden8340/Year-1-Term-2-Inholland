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


            Program CandyCrush = new Program();
            CandyCrush.Start();
        }

        void Start()
        {
            const int GRID_SIZE = 8;


            RegularCandies[,] columnTest = { 
                { RegularCandies.Gum_Square, RegularCandies.JellyBean }, 
                { RegularCandies.Lozenge, RegularCandies.Lozenge} ,
                { RegularCandies.Gum_Square, RegularCandies.JellyBean }
            };


            RegularCandies[,] playingField = new RegularCandies[GRID_SIZE, GRID_SIZE];
            InitCandies(playingField);

            DisplayCandies(playingField);

            if (ScoreRowPresent(playingField))
            {
                Console.ResetColor();
                Console.WriteLine("\nRow score!!");
            }
            if (ScoreColumnPresent(playingField))
            {
                Console.ResetColor();
                Console.WriteLine("\nColumn score!!");
            }



/*            DisplayCandies(columnTest);
            if (ScoreColumnPresent(columnTest))
            {
                Console.ResetColor();
                Console.WriteLine("\nColumn score!!");
            }*/


            Console.ReadKey();


        }

        void InitCandies(RegularCandies [,] field)
        {
            Random rng = new Random();

            for(int x = 0; x < field.GetLength(0); x++)
            {
                for (int y = 0; y < field.GetLength(1); y++)
                {
                    field[x, y] = (RegularCandies)rng.Next(0,6);
                }
            }
        }

        void DisplayCandies(RegularCandies [,] field)
        {

            for (int x = 0; x < field.GetLength(0); x++)
            {
                for (int y = 0; y < field.GetLength(1); y++)
                {
                    switch (field[x, y])
                    {
                        case (RegularCandies.JellyBean):
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("#");
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Write(' ');
                            break;

                        case (RegularCandies.Lozenge):
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write("#");
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Write(' ');
                            break;

                        case (RegularCandies.LemonDrop):
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.Write("#");
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Write(' ');
                            break;

                        case (RegularCandies.Gum_Square):
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write("#");
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Write(' ');
                            break;

                        case (RegularCandies.LollipopHead):
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("#");
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Write(' ');
                            break;

                        case (RegularCandies.Jujube_Cluster):
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.Write("#");
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Write(' ');
                            break;

                        default:
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        bool ScoreRowPresent(RegularCandies[,] field)
        {
            
            for (int x = 0; x < field.GetLength(0); x++)
            {
                RegularCandies last = field[x,0];
                int count = 1;
                for (int y = 0; y < field.GetLength(1); y++)
                {
                    
                    if (field[x, y] == last)
                    {
                        count++;
                    }
                    else
                    {
                        count = 1;
                    }
                    if (count == 3)
                        return true;
                }
            }
            return false;
        }

        bool ScoreColumnPresent(RegularCandies[,] field)
        {
           
            for (int y = 0; y < field.GetLength(1); y++)
            {
                RegularCandies last = field[0, y];
                int count = 1;

                for (int x = 0; x < field.GetLength(0); x++)
                {

                    if (field[x, y] == last)
                    {
                        count++;
                    }
                    else
                    {
                        count = 1;
                    }
                    if (count == 3)
                        return true;
                }
            }
            return false;
        }


        enum RegularCandies
        {
            JellyBean,//red 
            Lozenge, //orange
            LemonDrop, //yellow
            Gum_Square, //gree
            LollipopHead, //blue
            Jujube_Cluster //purple
        };
    }
}
