namespace EX2
{
    public class Game
    {
        public Board m_GameBoard;
        public ComputerPlayer m_ComputerOpponent;
        private int m_Opponent;
        private int m_OppenentScore = 0;
        private int m_PlayerScore = 0;
        public readonly static int k_ComputerPlayerNumber = 9;
        private readonly int k_HumanPlayerNumber = 2;

        public void Start()
        {
            int boardSize = 0;
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.WriteLine("Enter board size between 3 and 9:");
                string input = Console.ReadLine();

                if (int.TryParse(input, out boardSize) && boardSize >= 3 && boardSize <= 9)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 3 and 9.");
                }
            }
            m_GameBoard = new Board(boardSize);

        }

        public void ChooseOpponent()
        {
            Console.WriteLine("Play Against:");
            Console.WriteLine("1. Computer");
            Console.WriteLine("2. Another Player");
            string opponentChoice = Console.ReadLine();
            while (opponentChoice != "1" && opponentChoice != "2")
            {
                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                opponentChoice = Console.ReadLine();
            }
            m_GameBoard.PrintBoard();
            if (opponentChoice == "1")
            {
                m_ComputerOpponent = new ComputerPlayer(m_GameBoard);
                m_Opponent = k_ComputerPlayerNumber;
            }
            else
            {
                m_Opponent = 1;
            }



        }

        public bool PlayTurn(int i_playerNumber)
        {
            if (i_playerNumber == k_ComputerPlayerNumber)
            {
                m_ComputerOpponent.MakeMove();
                return false;
            }
            else
            {
                bool isValidMove = false;
                while (!isValidMove)
                {
                    if (m_GameBoard.IsBoardFull())
                    {
                        Console.WriteLine("The game is a draw!");
                        return true;
                    }

                    Console.WriteLine($"Player {i_playerNumber}'s turn. Enter your row");
                    string PlayerMoveRow = Console.ReadLine();
                    Console.WriteLine($"Player {i_playerNumber}'s turn. Enter your collumn");
                    string PlayerMoveCollumn = Console.ReadLine();
                    isValidMove = m_GameBoard.UpdateBoard(int.Parse(PlayerMoveRow), int.Parse(PlayerMoveCollumn), i_playerNumber);
                }
            }
            return false;
        }

        public void GamePlay()
        {
            int playerNumber = 1;
            bool isGameOver = false;
            bool againstComputer = m_Opponent == k_ComputerPlayerNumber;

            while (!isGameOver)
            {
                isGameOver = PlayTurn(playerNumber);
                if (m_GameBoard.CheckWin(playerNumber))
                {
                    Console.WriteLine("Game Over!\n");

                    if (playerNumber != k_ComputerPlayerNumber && playerNumber != k_HumanPlayerNumber)
                    {
                        Console.WriteLine("You win!\n");
                        m_PlayerScore++;
                    }
                    else
                    {
                        Console.WriteLine("You lose!\n");
                        m_OppenentScore++;
                    }

                    isGameOver = true;
                }

                if (playerNumber == 1)
                {
                    if (againstComputer)
                    {
                        playerNumber = k_ComputerPlayerNumber;
                    }
                    else
                    {
                        playerNumber = k_HumanPlayerNumber;
                    }
                }
                else
                {
                    playerNumber = 1;
                }
            }

            Console.WriteLine($"Player Score: {m_PlayerScore}");
            Console.WriteLine($"Opponent Score: {m_OppenentScore}\n");

            ResetGame();

        }


        public void ResetGame()
        {
            Console.WriteLine("Do you want to play again? (y/n)");
            string playAgain = Console.ReadLine();
            if (playAgain.ToLower() == "y")
            {
                m_GameBoard = new Board(m_GameBoard.GetSize());
                if (m_Opponent == k_ComputerPlayerNumber)
                {
                    m_ComputerOpponent = new ComputerPlayer(m_GameBoard);
                }

                m_GameBoard.PrintBoard();
                GamePlay();
            }
            else
            {
                Console.WriteLine("\nThanks for playing!");
            }
        }



    }
}
