using System;

namespace Ex02
{
    public class ComputerPlayer
    {
        private readonly Board r_GameBoard;

        public ComputerPlayer(Board i_GameBoard)
        {
            r_GameBoard = i_GameBoard;
        }

        public PlayerMove GetMove()
        {
            Random random = new Random();
            int boardSize = r_GameBoard.GetSize();
            int row = random.Next(1, boardSize + 1);
            int col = random.Next(1, boardSize + 1);

            while (r_GameBoard.GetCellSymbol(row - 1, col - 1) != " ")
            {
                row = random.Next(1, boardSize + 1);
                col = random.Next(1, boardSize + 1);
            }

            return new PlayerMove(row, col);
        }

        public PlayerMove GetIntelligentMove()
        {
            int size = r_GameBoard.GetSize();
            PlayerMove bestMove = new PlayerMove(-1, -1);
            PlayerMove fallbackMove = new PlayerMove(-1, -1);
            bool foundSafeMove = false;

            for (int i = 1; i <= size && !foundSafeMove; i++)
            {
                for (int j = 1; j <= size && !foundSafeMove; j++)
                {
                    if (r_GameBoard.GetCellSymbol(i - 1, j - 1) == " ")
                    {
                        PlayerMove currentMove = new PlayerMove(i, j);

                        if (fallbackMove.GetRow() == -1)
                        {
                            fallbackMove = currentMove;
                        }

                        if (!checkIfMoveLoses(currentMove))
                        {
                            bestMove = currentMove;
                            foundSafeMove = true;
                        }
                    }
                }
            }

            if (!foundSafeMove)
            {
                bestMove = fallbackMove;
            }

            return bestMove;
        }
        private bool checkIfMoveLoses(PlayerMove i_Move)
        {
            bool causesLoss = false;
            bool wasUpdated = r_GameBoard.UpdateBoard(i_Move, Game.k_ComputerPlayerNumber);

            if (wasUpdated)
            {
                causesLoss = r_GameBoard.CheckIfSequel(Game.k_ComputerPlayerNumber);
                r_GameBoard.ClearCell(i_Move);
            }
            else
            {
                causesLoss = true;
            }

            return causesLoss;
        }
    }
}