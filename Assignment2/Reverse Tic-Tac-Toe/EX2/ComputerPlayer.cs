namespace EX2
{
    internal class ComputerPlayer
    {
        Board m_GameBoard;

        public ComputerPlayer(Board i_GameBoard)
        {
            m_GameBoard = i_GameBoard;
        }

        public void MakeMove()
        {
            if (m_GameBoard.IsBoardFull())
            {
                return;
            }
            Random random = new Random();
            int row, column;
            row = random.Next(1, m_GameBoard.GetSize() + 1);
            column = random.Next(1, m_GameBoard.GetSize() + 1);

            while (!m_GameBoard.IsCellEmpty(row - 1, column - 1))
            {
                row = random.Next(1, m_GameBoard.GetSize() + 1);
                column = random.Next(1, m_GameBoard.GetSize() + 1);
            }
            Console.WriteLine("\nComputer player move: row {0}, column {1}\n", row, column);
            m_GameBoard.UpdateBoard(row, column, Game.k_ComputerPlayerNumber);
        }
    }
}
