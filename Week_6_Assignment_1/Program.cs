using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program ChessGame = new Program();
            ChessGame.Start();

        }

        void Start()
        {



            ChessPiece[,] gameBoard = new ChessPiece[8, 8];
            InitChessboard(gameBoard);
            DisplayChessboard(gameBoard);
            PlayChess(gameBoard);

            Console.ReadKey();
        }

        void InitChessboard(ChessPiece[,] chessboard)
        {
            for (int i = 0; i < chessboard.GetLength(0); i++)
            {
                for (int j = 0; j < chessboard.GetLength(1); j++)
                {
                    chessboard[i,j] = null;
                }
            }

            PutChessPieces(chessboard);
        }

        void DisplayChessboard(ChessPiece[,] chessboard)
        {
            Console.WriteLine("  A  B  C  D  E  F  G  H");
            for (int i = 0; i < chessboard.GetLength(0); i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("{0} ", i+1);
                for (int j = 0; j < chessboard.GetLength(1); j++)
                {
                    if( (i + j) % 2 != 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }
                    DisplayChessPiece(chessboard[i,j]);
                }
                Console.WriteLine();
            }
        }

        void PutChessPieces(ChessPiece[,] chessboard)
        {
            PieceType[] order = { PieceType.Rook, PieceType.Knight, PieceType.Bishop, PieceType.King,
                PieceType.Queen, PieceType.Bishop, PieceType.Knight, PieceType.Rook};

            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                for (int column = 0; column < chessboard.GetLength(1); column++)
                {
                    if (row == 0)
                    {
                        chessboard[row, column] = new ChessPiece
                        {
                            Colour = PieceColour.Black,
                            Piece = order[column]
                        };
                    }
                    else if(row == 1)
                    {
                        chessboard[row, column] = new ChessPiece
                        {
                            Colour = PieceColour.Black,
                            Piece = PieceType.Pawn
                        };
                    }
                    else if(row == 6)
                    {
                        chessboard[row, column] = new ChessPiece
                        {
                            Colour = PieceColour.White,
                            Piece = PieceType.Pawn
                        };
                    }
                    else if (row == 7)
                    {
                        chessboard[row, column] = new ChessPiece
                        {
                            Colour = PieceColour.White,
                            Piece = order[column]
                        };
                    }
                }
            }

        }
        void DisplayChessPiece(ChessPiece chessPiece)
        {
            if (chessPiece == null)
            {
                Console.Write("   ");
            }
            else
            {
                if (chessPiece.Colour == PieceColour.White)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (chessPiece.Colour == PieceColour.Black)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                }


                string piece = chessPiece.Piece.ToString().ToLower().Trim();
                //Console.WriteLine(piece);

                if (chessPiece.Piece == PieceType.King || chessPiece.Piece == PieceType.Queen)
                    piece = piece.ToUpper();

                Console.Write(" {0} ", piece[0]);

            }
        }

        Position ReadPosition()
        {
            GetInput input = new GetInput();
            string userPos;
            bool validInput = false;
            int column = -1, row = -1;

            while (!validInput)
            {
                try
                {
                    userPos = input.ReadString("Enter a postion (e.g. F5): ").Trim().ToUpper();
                    
                    if (userPos[0] >= 'A' && userPos[0] <= 'H' && userPos[1] >= '1' && userPos[1] <= '8')
                    {
                        row = int.Parse(userPos[1].ToString()) - 1;
                        column = userPos[0] - 'A';
                        validInput = true;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Postion");
                }
            }

            return new Position { Row = row, Column = column };

        }

        void PlayChess(ChessPiece[,] chessboard)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;

                Console.WriteLine("Choose a Piece to move");
                Position chosesnPiece = ReadPosition();

                Console.WriteLine("Chose a place to move");
                Position moveTo = ReadPosition();

                CheckMove(chessboard, chosesnPiece, moveTo);
                //DoMove(chessboard, chosesnPiece, moveTo);

                //Console.Clear();
                //DisplayChessboard(chessboard);
            }
        }

        private void DoMove(ChessPiece[,] chessboard, Position chosesnPiece, Position moveTo)
        {
            chessboard[moveTo.Row, moveTo.Column] = chessboard[chosesnPiece.Row, chosesnPiece.Column];
            chessboard[chosesnPiece.Row, chosesnPiece.Column] = null;

            Console.Clear();
            DisplayChessboard(chessboard);
        }

        private void CheckMove(ChessPiece[,] chessboard, Position chosesnPiece, Position moveTo)
        {
            /*            -the from - position contains a chess piece;
                        -the to - position does not contain a chess piece;
                        -the move is valid for the specific chess piece(at the from - position); to check this, call method ValidMove, see
                        next*/

            try
            {
                if (chessboard[chosesnPiece.Row, chosesnPiece.Column] != null)
                {
                    if(chessboard[moveTo.Row, moveTo.Column] == null)//is empty
                    {
                        //valid
                        if (ValidMove(chessboard[chosesnPiece.Row, chosesnPiece.Column], chosesnPiece, moveTo))
                            DoMove(chessboard, chosesnPiece, moveTo);
                        else
                            throw new Exception($"This is not a valid move for a {chessboard[chosesnPiece.Row, chosesnPiece.Column].Piece.ToString()}");
                    }
                    else
                    {
                        throw new Exception("There is already a piece on this square");
                    }
                }
                else
                {
                    throw new Exception("There is no piece on this square");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private bool ValidMove(ChessPiece chessPiece, Position chosesnPiece, Position moveTo)
        {
            /*Create a method bool ValidMove(ChessPiece chessPiece, Position from, Position to).
            This method checks if the move is valid for the given chess piece. First calculate the positive horizontal
            difference (hor) and the positive vertical difference (ver). To get the positive value (>=0) use Math.Abs(...).
            In general, if both hor and ver are 0, then it’s not a valid move. Otherwise you can determine if the move is valid
            by using the following rules (use a switch to test the type of the chess piece):
             rook hor * ver = 0
             knight hor * ver = 2
             bishop hor = ver
             king hor = 1 and/or ver = 1
             queen hor * ver = 0 or hor = ver
             pawn hor = 0 and ver = 1*/

            int horizontal= Math.Abs(chosesnPiece.Row - moveTo.Row), 
                vertical = Math.Abs(chosesnPiece.Column - moveTo.Column);

            switch (chessPiece.Piece)
            {
                case PieceType.Pawn:
                    if (horizontal == 0 && vertical == 1)
                        return true;
                    break;

                case PieceType.Rook:
                    if (horizontal * vertical == 0) 
                        return true;
                    break;

                case PieceType.Knight:
                    if (horizontal * vertical == 2)
                        return true;
                    break;

                case PieceType.Bishop:
                    if (horizontal == vertical)
                        return true;
                    break;

                case PieceType.Queen:
                    if (horizontal == vertical || horizontal * vertical == 0)
                        return true;
                    break;

                case PieceType.King:
                    if (horizontal == 1 || vertical == 1)
                        return true;
                    break;
            }
            return false;


        }
    }


}
