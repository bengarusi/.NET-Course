namespace EX2
{
    public class Board
    {
        private readonly int m_Size;
        private string[][] m_Board;
        private int m_HowManyCellsAreFilled = 0;

        public Board(int i_Size)
        {
            m_Size = i_Size;
            m_Board = new string[m_Size][];

            for (int i = 0; i < m_Size; i++)
            {
                m_Board[i] = new string[m_Size];
            }
        }

        public bool UpdateBoard(PlayerMove i_Move, int i_Player)
        {
            bool isUpdateSuccessful = false;
            int row = i_Move.Row - 1;
            int col = i_Move.Column - 1;

            if (row >= 0 && row < m_Size && col >= 0 && col < m_Size)
            {
                if (m_Board[row][col] == null)
                {
                    m_Board[row][col] = i_Player == 1 ? "X" : "O";
                    m_HowManyCellsAreFilled++;
                    isUpdateSuccessful = true;
                }
            }

            return isUpdateSuccessful;
        }

        public bool CheckWin(int i_PlayerNumber)
        {
            bool isWin = false;
            string playerSymbol = i_PlayerNumber == 1 ? "X" : "O";

            for (int i = 0; i < m_Size && !isWin; i++)
            {
                bool rowWin = true;
                bool colWin = true;

                for (int j = 0; j < m_Size; j++)
                {
                    if (m_Board[i][j] != playerSymbol)
                    {
                        rowWin = false;
                    }
                    if (m_Board[j][i] != playerSymbol)
                    {
                        colWin = false; 
                    }
                }

                isWin = rowWin || colWin;
            }

            if (!isWin)
            {
                isWin = checkDiagonals(playerSymbol);
            }

            return isWin;
        }

        private bool checkDiagonals(string i_PlayerSymbol)
        {
            bool mainDiag = true;
            bool antiDiag = true;

            for (int i = 0; i < m_Size; i++)
            {
                if (m_Board[i][i] != i_PlayerSymbol) 
                {
                    mainDiag = false;
                }
                if (m_Board[i][m_Size - 1 - i] != i_PlayerSymbol)
                { 
                    antiDiag = false;
                }
            }

            return mainDiag || antiDiag;
        }

        public string GetCellSymbol(int i_Row, int i_Col)
        {
            string symbol = m_Board[i_Row][i_Col] ?? " ";

            return symbol;
        }

        public bool IsBoardFull()
        {
            bool isFull = m_HowManyCellsAreFilled == m_Size * m_Size;

            return isFull;
        }

        public int GetSize()
        {
            return m_Size;
        }
    }
}