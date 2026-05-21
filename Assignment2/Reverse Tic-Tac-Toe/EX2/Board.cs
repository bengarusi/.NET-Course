namespace Ex02
{
    public class Board
    {
        private readonly int r_Size;
        private string[,] m_Board;
        private int m_HowManyCellsAreFilled = 0;

        public Board(int i_Size)
        {
            r_Size = i_Size;
            m_Board = new string[r_Size, r_Size];
        }

        public bool UpdateBoard(PlayerMove i_Move, int i_Player)
        {
            bool isUpdateSuccessful = false;
            int row = i_Move.GetRow() - 1;
            int col = i_Move.GetColumn() - 1;

            if (row >= 0 && row < r_Size && col >= 0 && col < r_Size)
            {
                if (m_Board[row, col] == null)
                {
                    m_Board[row, col] = i_Player == 1 ? "X" : "O";
                    m_HowManyCellsAreFilled++;
                    isUpdateSuccessful = true;
                }
            }

            return isUpdateSuccessful;
        }

        public bool CheckIfSequel(int i_PlayerNumber)
        {
            bool isWin = false;
            string playerSymbol = i_PlayerNumber == 1 ? "X" : "O";

            for (int i = 0; i < r_Size && !isWin; i++)
            {
                bool rowWin = true;
                bool colWin = true;

                for (int j = 0; j < r_Size; j++)
                {
                    if (m_Board[i, j] != playerSymbol)
                    {
                        rowWin = false;
                    }
                    if (m_Board[j, i] != playerSymbol)
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

            for (int i = 0; i < r_Size; i++)
            {
                if (m_Board[i, i] != i_PlayerSymbol) 
                {
                    mainDiag = false;
                }
                if (m_Board[i, r_Size - 1 - i] != i_PlayerSymbol)
                { 
                    antiDiag = false;
                }
            }

            return mainDiag || antiDiag;
        }

        public string GetCellSymbol(int i_Row, int i_Col)
        {
            string symbol = m_Board[i_Row, i_Col] ?? " ";

            return symbol;
        }

        public bool IsBoardFull()
        {
            bool isFull = m_HowManyCellsAreFilled == r_Size * r_Size;

            return isFull;
        }

        public int GetSize()
        {
            return r_Size;
        }

        public void ClearCell(PlayerMove i_PlayerMove)
        { 
            int row = i_PlayerMove.GetRow() - 1;
            int col = i_PlayerMove.GetColumn() - 1;
            
            if (row >= 0 && row < r_Size && col >= 0 && col < r_Size)
            {
                if (m_Board[row, col] != null)
                {
                    m_Board[row, col] = null;
                    m_HowManyCellsAreFilled--;
                }
            }
        }
    }
}