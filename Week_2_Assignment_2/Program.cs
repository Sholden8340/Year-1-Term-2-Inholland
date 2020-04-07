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
            Program matrix = new Program();
            matrix.Start();
        }

        void Start()
        {
            int[,] matrix = new int[5, 5];
            InitMatrixRandom(matrix, 0, 9);

            DisplayMatrix(matrix);

            Console.Write("Enter a number to searh: ");
            int search = int.Parse(Console.ReadLine());

            Position location = SearchNumber(matrix, search);

            Console.WriteLine("\nLocation +1 for legibility \n");
            Console.WriteLine("Location is [{0},{1}]\n", location.Row + 1, location.Column + 1);

            Position location2 = SearchNumberBackwards(matrix, search);
            Console.WriteLine("Location Backwards is [{0},{1}]", location2.Row + 1, location2.Column + 1);

            Console.ReadKey();

        }

        void InitMatrix2D(int[,] matrix)
        {
            int last = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = ++last;

                }
            }
        }

        void DisplayMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,3} ", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        void InitMatrixLinear(int[,] matrix)
        {
            int row = 0;
            int count = 0;
            for (int col = 0; col < matrix.GetLength(0) - 1; col++)
            {
                if (col + 1 == matrix.GetLength(0))
                {
                    row++;
                    col = 0;
                }

                matrix[row, col] = ++count;
            }
        }

        void DisplayMatrixWithCross(int[,] matrix)
        {
            /*This method displays the numbers at one main diagonal red
            (foreground color) and the numbers at the other main diagonal
            yellow(background color). All other numbers are white.
            Use a nested for-loop, and use the loop-variables(row and column)
            to determine the color to use(with either
            Console.ForegroundColor or Console.BackgroundColor).
            The standard Console color can be reset with
            Console.ResetColor().*/

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int count = matrix.GetLength(0);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    count--;
                    Console.ResetColor();
                    if (row == col)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    if (count == row)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }



                    Console.Write("{0,3} ", matrix[row, col]);

                }
                Console.WriteLine();
            }
        }

        void InitMatrixRandom(int[,] matrix, int min, int max)
        {
            Random rng = new Random();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rng.Next(min, max+1);
                }
            }
        }


        Position SearchNumber(int[,] matrix, int number)
        {
            Position position = new Position();
            
            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col] == number)
                    {
                        position.Row = row;
                        position.Column = col;
                        return position;
                    }
                }
            }

            return null;
        }


        Position SearchNumberBackwards(int[,] matrix, int number)
        {
            Position position = new Position();

            for (int row = matrix.GetLength(0)-1; row >= 0; row--)
            {
                for (int col = matrix.GetLength(1)-1; col >0 ; col--)
                {
                    if (matrix[row, col] == number)
                    {
                        position.Row = row;
                        position.Column = col;
                        return position;
                    }
                }
            }

            return null;
        }
    }
}
