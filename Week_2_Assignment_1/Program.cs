using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
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
            int[,] matrix = new int[15, 15];

            InitMatrix2D(matrix);
            DisplayMatrix(matrix);

            Console.WriteLine();

            int[,] matrix2 = new int[15, 15];
            InitMatrixLinear(matrix2);
            DisplayMatrix(matrix2);

            Console.WriteLine();

            DisplayMatrixWithCross(matrix);



            Console.ReadKey();

        }

        void InitMatrix2D(int[,] matrix)
        {
            int last = 0;

            for(int row = 0; row < matrix.GetLength(0); row++)
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
            int col = 0;

            for(int count = 1; count <= matrix.Length; count++)
            {
                if (row < matrix.GetLength(0) && col < matrix.GetLength(1))
                {
                    matrix[row, col] = count;
                    col++;
                }
                else if (col == matrix.GetLength(0))
                {
                    row++;
                    col = 0;
                    count--;
                }
                

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

    }
}
