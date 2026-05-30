using System;
using Ex02.ConsoleUtils;

namespace Ex02
{
    public class Game
    {
        private Board m_GameBoard;
        private ComputerPlayer m_ComputerOpponent;
        private int m_OpponentType;
        private int m_OpponentScore = 0;
        private int m_PlayerScore = 0;
        public const int k_ComputerPlayerNumber = 9;
 
        public void Start()
        {
            int boardSize = 0;

            Console.WriteLine("Enter board size between 3 and 9:");
            string inputBoardSize = Console.ReadLine();
            exitIfExitCommand(inputBoardSize);
            while (!int.TryParse(inputBoardSize, out boardSize) || boardSize < 3 || boardSize > 9)
            {
                Console.WriteLine("Invalid input. Please enter a number between 3 and 9.");
                inputBoardSize = Console.ReadLine();
                exitIfExitCommand(inputBoardSize);
            }

            m_GameBoard = new Board(boardSize);
            chooseOpponent();
            gamePlay();
        }

        private void chooseOpponent()
        {
            Console.WriteLine("Play Against:\n1. Computer\n2. Another Player");
            string choice = Console.ReadLine();
            exitIfExitCommand(choice);

            while (choice != "1" && choice != "2")
            {
                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                choice = Console.ReadLine();
                exitIfExitCommand(choice);
            }

            m_OpponentType = (choice == "1") ? k_ComputerPlayerNumber : 2;
            if (m_OpponentType == k_ComputerPlayerNumber)
            {
                m_ComputerOpponent = new ComputerPlayer(m_GameBoard);
            }
        }

        private void printBoard()
        {
            Screen.Clear();
            int size = m_GameBoard.GetSize();

            Console.Write("    ");
            for (int i = 1; i <= size; i++)
            {
                Console.Write(string.Format("{0}   ", i));
            }
            Console.WriteLine();

            for (int i = 0; i < size; i++)
            {
                Console.Write(string.Format("{0} |", i + 1));
                for (int j = 0; j < size; j++)
                {
                    Console.Write(string.Format(" {0} |", m_GameBoard.GetCellSymbol(i, j)));
                }

                Console.Write("\n  ");
                for (int j = 0; j < size; j++)
                {
                    Console.Write("====");
                }

                Console.Write("=\n");
               
            }
        }

        private void getAndValidateMove(int i_PlayerNumber)
        {
            bool isValidMove = false;

            while (!isValidMove)
            {
                Console.WriteLine(string.Format("Player {0}'s turn. Enter row (or Q to quit):", i_PlayerNumber));
                string rowInput = Console.ReadLine();
                exitIfExitCommand(rowInput);

                Console.WriteLine(string.Format("Player {0}'s turn. Enter column (or Q to quit):", i_PlayerNumber));
                string colInput = Console.ReadLine();
                exitIfExitCommand(colInput);

                int row, col;
                if (int.TryParse(rowInput, out row) && int.TryParse(colInput, out col))
                {
                    if (row < 1 || row > m_GameBoard.GetSize() || col < 1 || col > m_GameBoard.GetSize())
                    {
                        Console.WriteLine(string.Format("Invalid move. Row and column must be between 1 and {0}", m_GameBoard.GetSize()));
                    }
                    else if (m_GameBoard.GetCellSymbol(row - 1, col - 1) != " ")
                    {
                        Console.WriteLine("Invalid move. Cell is already occupied.");
                    }
                    else
                    {
                        isValidMove = m_GameBoard.UpdateBoard(new PlayerMove(row, col), i_PlayerNumber);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter numbers only.");
                }
            }
        }

        private void gamePlay()
        {
            int currentPlayer = 1;
            bool isGameOver = false;

            while (!isGameOver)
            {
                printBoard();
                if (currentPlayer == k_ComputerPlayerNumber)
                {
                    PlayerMove compMove = m_ComputerOpponent.GetIntelligentMove();
                    Console.WriteLine(string.Format("\nComputer player move: row {0}, column {1}\n", compMove.GetRow(), compMove.GetColumn()));
                    m_GameBoard.UpdateBoard(compMove, k_ComputerPlayerNumber);
                }
                else
                {
                    getAndValidateMove(currentPlayer);
                }

                if (!isGameOver && m_GameBoard.CheckIfSequel(currentPlayer))
                {
                    printBoard();
                    Console.WriteLine(string.Format("Game Over! Player {0} hit a sequence and LOST!", currentPlayer));
                    updateScores(currentPlayer);
                    isGameOver = true;
                }
                else if (!isGameOver && m_GameBoard.IsBoardFull())
                {
                    printBoard();
                    Console.WriteLine("The game is a draw!");
                    isGameOver = true;
                }

                currentPlayer = (currentPlayer == 1) ? m_OpponentType : 1;
            }
            resetGame();
        }

        private void updateScores(int i_LosingPlayer)
        {
            if (i_LosingPlayer == 1)
            {
                m_OpponentScore++;
            }
            else
            {
                m_PlayerScore++;
            }
        }

        private void resetGame()
        {
            Console.WriteLine(string.Format("Scores -> You: {0}, Opponent: {1}", m_PlayerScore, m_OpponentScore));
            Console.WriteLine("Do you want to play again? (y)");
            string playAgain = Console.ReadLine();
            exitIfExitCommand(playAgain);
            if (playAgain == "y" || playAgain == "Y")
            {
                m_GameBoard = new Board(m_GameBoard.GetSize());
                m_ComputerOpponent = new ComputerPlayer(m_GameBoard);
                gamePlay();
            }
            else
            {
                Console.WriteLine("\nThanks for playing!");
            }
        }

        private void exitIfExitCommand(string i_Input)
        {
            if (i_Input == "Q" || i_Input == "q")
            {
                Console.WriteLine("Exiting the game. Goodbye!");
                Environment.Exit(0);
            }

        }

    }
}