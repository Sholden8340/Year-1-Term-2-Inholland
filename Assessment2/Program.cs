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
            Program SmallestBiggestNumber = new Program();
            SmallestBiggestNumber.Start();
        }

        void Start()
        {

            const int MATRIX_ROWS = 15;
            const int MATRIX_COULMNS = 20;
            int[,] matrix = new int[MATRIX_ROWS, MATRIX_COULMNS];

            FillMatrix(ref matrix);
            //DisplayMatrix(matrix);
            DisplayMatrixPositions(matrix, SearchBiggest(matrix), SearchSmallest(matrix));
            Console.ReadKey();

        }

        void DisplayPosition(string name, Position pos)
        {
            Console.WriteLine("{0}: {1,3} (row: {2,2}, column: {3,2}", name, pos.value, pos.row, pos.column);
        }

        Position SearchSmallest(int[,] matrix)
        {
            int smallest = matrix[0, 0];
            Position pos = new Position
            {
                row = 0,
                column = 0,
                value = matrix[0, 0],
            };

            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    if (matrix[x,y] < smallest)
                    {
                        pos.value = matrix[x, y];
                        pos.column = y;
                        pos.row = x;
                    }
                }
            }
            return pos;
       
        } 
        Position SearchBiggest(int[,] matrix)
        {
            int biggest = matrix[0, 0];
            Position pos = new Position
            {
                row = 0,
                column = 0,
                value = matrix[0, 0],
            };

            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    if (matrix[x,y] > biggest)
                    {
                        pos.value = matrix[x, y];
                        pos.column = y;
                        pos.row = x;
                    }
                }
            }
            return pos;
       
        }

        void FillMatrix(ref int[,] matrix)
        {
            const int MIN_NUMBER = 1;
            const int MAX_NUMBER = 201;

            Random rng = new Random();

            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    matrix[x, y] = rng.Next(MIN_NUMBER, MAX_NUMBER);
                }
            }
        }
        void DisplayMatrix(int[,] matrix)
        {

            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    Console.Write(matrix[x, y]);
                }
                Console.WriteLine();
            }
        }

        void DisplayMatrixPositions(int[,] matrix, Position Biggest, Position Smallest)
        {

            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {

                    if (matrix[x, y] == Biggest.value)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (matrix[x, y] == Smallest.value)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (x == Biggest.row || y == Biggest.column) //biggest column or row
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else if (x == Smallest.row || y == Smallest.column) //smallest column or row
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write("{0,3} ",matrix[x, y]);
                }
                Console.WriteLine();
            }

        }
        
    }
}
