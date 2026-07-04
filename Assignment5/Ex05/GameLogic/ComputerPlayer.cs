using System;

namespace GameLogic
{
    public class ComputerPlayer
    {
        private readonly Random r_Random = new Random();

        public Move ChooseMove(Board i_Board, eSign i_Sign)
        {
            int size = i_Board.Size;
            int maxMoves = size * size;

            Move[] safeMoves = new Move[maxMoves];
            Move[] fallbackMoves = new Move[maxMoves];

            int safeMovesCount = 0;
            int fallbackMovesCount = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (i_Board.IsCellEmpty(row, col))
                    {
                        Move currentMove = new Move(row, col);

                        fallbackMoves[fallbackMovesCount] = currentMove;
                        fallbackMovesCount++;

                        if (!i_Board.WouldCompleteSequence(currentMove, i_Sign))
                        {
                            safeMoves[safeMovesCount] = currentMove;
                            safeMovesCount++;
                        }
                    }
                }
            }

            return chooseRandomMove(safeMoves, safeMovesCount, fallbackMoves, fallbackMovesCount);
        }

        private Move chooseRandomMove(Move[] i_SafeMoves, int i_SafeMovesCount, Move[] i_FallbackMoves, int i_FallbackMovesCount)
        {
            Move chosenMove;

            if (i_SafeMovesCount > 0)
            {
                chosenMove = i_SafeMoves[r_Random.Next(i_SafeMovesCount)];
            }
            else
            {
                chosenMove = i_FallbackMoves[r_Random.Next(i_FallbackMovesCount)];
            }

            return chosenMove;
        }
    }
}