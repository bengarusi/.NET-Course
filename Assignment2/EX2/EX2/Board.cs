using System;
using System.Collections.Generic;
using System.Text;

namespace EX2
{
    internal class Board
    {
        private readonly int Size;
        private string[][] m_board;
        private int m_HowManyCellsAreFilled = 0;

        public Board(int i_size)
        {
            Size = i_size;
            m_board = new string[Size][];
            for (int i = 0; i < Size; i++)
            {
                m_board[i] = new string[Size];
            }
        }


        public void PrintBoard()
        {

            for (int i = 0; i < Size; i++)
            {
                if (i == 0)
                {
                    Console.Write("     ");
                    Console.Write(i + 1 + "   ");
                }
                else
                {
                    Console.Write(i + 1 + "   ");
                }
            }

            Console.WriteLine();

            for (int i = 0; i < Size; i++)
            {
                Console.Write(i + 1 + "  ");
                for (int j = 0; j < Size; j++)
                {
                    Console.Write("| ");
                    Console.Write(m_board[i][j] == null ? " " : m_board[i][j]);
                    Console.Write(" ");
                    if (j + 1 == Size)
                    {
                        Console.Write("|");
                    }
                }
                Console.WriteLine();
                Console.Write("   ");
                for (int j = 0; j < Size; j++)
                {
                    Console.Write("====");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public bool UpdateBoard(int i_row, int i_col, int i_player)
        {
            if (i_row < 1 || i_row > Size || i_col < 1 || i_col > Size)
            {
                Console.WriteLine("Invalid move. Row and column must be between 1 and " + Size);
                return false;
            }

            if (!IsCellEmpty(i_row - 1, i_col - 1))
            {
                Console.WriteLine("Invalid move. Cell is already occupied.");
                return false;
            }
            m_board[i_row - 1][i_col - 1] = i_player == 1 ? "X" : "O";
            m_HowManyCellsAreFilled++;
            PrintBoard();
            return true;
        }


        public bool IsBoardFull()
        {
            return m_HowManyCellsAreFilled == Size * Size;
        }

        public int GetSize()
        {
            return Size;
        }

        public bool IsCellEmpty(int i_row, int i_col)
        {
            return m_board[i_row][i_col] == null;
        }

        public bool CheckWin(int i_playerNumber)
        {
            string playerSymbol = i_playerNumber == 1 ? "X" : "O";
            // Check rows
            for (int i = 0; i < Size; i++)
            {
                bool rowWin = true;
                for (int j = 0; j < Size; j++)
                {
                    if (m_board[i][j] != playerSymbol)
                    {
                        rowWin = false;
                        break;
                    }
                }

                if (rowWin)
                {
                    return true;
                }
            }

            // Check columns
            for (int j = 0; j < Size; j++)
            {
                bool colWin = true;
                for (int i = 0; i < Size; i++)
                {
                    if (m_board[i][j] != playerSymbol)
                    {
                        colWin = false;
                        break;
                    }
                }
                if (colWin)
                {
                    return true;
                }
            }

            // Check main diagonal
            bool mainDiagonalWin = true;
            for (int i = 0; i < Size; i++)
            {
                if (m_board[i][i] != playerSymbol)
                {
                    mainDiagonalWin = false;
                    break;
                }
            }

            if (mainDiagonalWin)
            {
                return true;
            }
            // Check anti-diagonal
            bool antiDiagonalWin = true;
            for (int i = 0; i < Size; i++)
            {
                if (m_board[i][Size - 1 - i] != playerSymbol)
                {
                    antiDiagonalWin = false;
                    break;
                }
            }

            return antiDiagonalWin;
        }
    }
}