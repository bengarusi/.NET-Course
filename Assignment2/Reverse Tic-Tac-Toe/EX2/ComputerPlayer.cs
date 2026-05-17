using System;

namespace EX2
{
    public class ComputerPlayer
    {
        private Board m_GameBoard;

        public ComputerPlayer(Board i_GameBoard)
        {
            m_GameBoard = i_GameBoard;
        }

        public PlayerMove GetMove()
        {
            Random random = new Random();
            int boardSize = m_GameBoard.GetSize();
            int row = random.Next(1, boardSize + 1);
            int col = random.Next(1, boardSize + 1);

            while (m_GameBoard.GetCellSymbol(row - 1, col - 1) != " ")
            {
                row = random.Next(1, boardSize + 1);
                col = random.Next(1, boardSize + 1);
            }

            return new PlayerMove(row, col);
        }
    }
}