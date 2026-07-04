namespace GameLogic
{
	public class ComputerPlayer
	{
		public Move ChooseMove(Board i_Board, eSign i_Sign)
		{
			int size = i_Board.Size;
			Move chosenMove = new Move(-1, -1);
			Move fallbackMove = new Move(-1, -1);
			bool foundFallback = false;
			bool foundSafeMove = false;

			for (int row = 0; row < size && !foundSafeMove; row++)
			{
				for (int col = 0; col < size && !foundSafeMove; col++)
				{
					if (i_Board.IsCellEmpty(row, col))
					{
						Move currentMove = new Move(row, col);

						if (!foundFallback)
						{
							fallbackMove = currentMove;
							foundFallback = true;
						}

						if (!i_Board.WouldCompleteSequence(currentMove, i_Sign))
						{
							chosenMove = currentMove;
							foundSafeMove = true;
						}
					}
				}
			}

			if (!foundSafeMove)
			{
				chosenMove = fallbackMove;
			}

			return chosenMove;
		}
	}
}
