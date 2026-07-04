namespace GameLogic
{
	public class Board
	{
		private readonly int r_Size;
		private readonly eSign[,] r_Cells;

		private int m_FilledCellsCount = 0;

		public Board(int i_Size)
		{
			r_Size = i_Size;
			r_Cells	= new eSign[r_Size, r_Size];
		}

		public int Size
		{
			get { return r_Size; }
		}

		public eSign GetCell(int i_Row, int i_Col)
		{
			return r_Cells[i_Row, i_Col];
		}

		public bool IsCellEmpty(int i_Row, int i_Col)
		{
			return r_Cells[i_Row, i_Col] == eSign.Empty;
		}

		public bool FillCell(Move i_Move, eSign i_Sign)
		{
			bool isFilled = false;
			int	 row = i_Move.Row;
			int	 col = i_Move.Col;

			if (isInRange(row, col) && r_Cells[row, col] == eSign.Empty)
			{
				r_Cells[row, col] = i_Sign;
				m_FilledCellsCount++;
				isFilled = true;
			}

			return isFilled;
		}

		public void ClearCell(Move i_Move)
		{
			int row = i_Move.Row;
			int col = i_Move.Col;

			if (isInRange(row, col) && r_Cells[row, col] != eSign.Empty)
			{
				r_Cells[row, col] = eSign.Empty;
				m_FilledCellsCount--;
			}
		}

		public bool IsFull()
		{
			return m_FilledCellsCount == r_Size * r_Size;
		}

		public bool HasLosingSequence(eSign i_Sign)
		{
			bool hasSequence = false;

			for (int i = 0; i < r_Size && !hasSequence; i++)
			{
				bool rowComplete = true;
				bool colComplete = true;

				for (int j = 0; j < r_Size; j++)
				{
					if (r_Cells[i, j] != i_Sign)
					{
						rowComplete = false;
					}

					if (r_Cells[j, i] != i_Sign)
					{
						colComplete = false;
					}
				}

				hasSequence = rowComplete || colComplete;
			}

			if (!hasSequence)
			{
				hasSequence = hasDiagonalSequence(i_Sign);
			}

			return hasSequence;
		}

		public bool WouldCompleteSequence(Move i_Move, eSign i_Sign)
		{
			bool wouldComplete = false;
			int row = i_Move.Row;
			int col = i_Move.Col;

			if (isInRange(row, col) && r_Cells[row, col] == eSign.Empty)
			{
				bool rowComplete = wouldCompleteRow(row, col, i_Sign);
				bool colComplete = wouldCompleteColumn(row, col, i_Sign);
				bool mainDiagComplete = (row == col) && wouldCompleteMainDiagonal(row, i_Sign);
				bool antiDiagComplete = (row + col == r_Size - 1) && wouldCompleteAntiDiagonal(row, i_Sign);

				wouldComplete = rowComplete || colComplete || mainDiagComplete || antiDiagComplete;
			}

			return wouldComplete;
		}

		
		private bool wouldCompleteRow(int i_MoveRow, int i_MoveCol, eSign i_Sign)
		{
			bool isComplete = true;

			for (int col = 0; col < r_Size; col++)
			{
				if (col != i_MoveCol && r_Cells[i_MoveRow, col] != i_Sign)
				{
					isComplete = false;
				}
			}

			return isComplete;
		}

		private bool wouldCompleteColumn(int i_MoveRow, int i_MoveCol, eSign i_Sign)
		{
			bool isComplete = true;

			for (int row = 0; row < r_Size; row++)
			{
				if (row != i_MoveRow && r_Cells[row, i_MoveCol] != i_Sign)
				{
					isComplete = false;
				}
			}

			return isComplete;
		}

		private bool wouldCompleteMainDiagonal(int i_MoveIndex, eSign i_Sign)
		{
			bool isComplete = true;

			for (int i = 0; i < r_Size; i++)
			{
				if (i != i_MoveIndex && r_Cells[i, i] != i_Sign)
				{
					isComplete = false;
				}
			}

			return isComplete;
		}

		private bool wouldCompleteAntiDiagonal(int i_MoveRow, eSign i_Sign)
		{
			bool isComplete = true;

			for (int row = 0; row < r_Size; row++)
			{
				int col = r_Size - 1 - row;

				if (row != i_MoveRow && r_Cells[row, col] != i_Sign)
				{
					isComplete = false;
				}
			}

			return isComplete;
		}

		private bool hasDiagonalSequence(eSign i_Sign)
		{
			bool mainDiagonal = true;
			bool antiDiagonal = true;

			for (int i = 0; i < r_Size; i++)
			{
				if (r_Cells[i, i] != i_Sign)
				{
					mainDiagonal = false;
				}

				if (r_Cells[i, r_Size - 1 - i] != i_Sign)
				{
					antiDiagonal = false;
				}
			}

			return mainDiagonal || antiDiagonal;
		}

		private bool isInRange(int i_Row, int i_Col)
		{
			return i_Row >= 0 && i_Row < r_Size && i_Col >= 0 && i_Col < r_Size;
		}
	}
}
