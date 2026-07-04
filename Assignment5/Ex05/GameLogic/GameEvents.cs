using System;

namespace GameLogic
{
	public class CellChangedEventArgs : EventArgs
	{
		private readonly int r_Row;
		private readonly int r_Col;
		private readonly eSign r_Sign;

		public CellChangedEventArgs(int i_Row, int i_Col, eSign i_Sign)
		{
			r_Row = i_Row;
			r_Col = i_Col;
			r_Sign = i_Sign;
		}

		public int Row
		{
			get { return r_Row; }
		}

		public int Col
		{
			get { return r_Col; }
		}

		public eSign Sign
		{
			get { return r_Sign; }
		}
	}

	public class RoundEndedEventArgs : EventArgs
	{
		private readonly eRoundResult r_Result;
		private readonly string r_WinnerName;

		public RoundEndedEventArgs(eRoundResult i_Result, string i_WinnerName)
		{
			r_Result = i_Result;
			r_WinnerName = i_WinnerName;
		}

		public eRoundResult Result
		{
			get { return r_Result; }
		}

		public string WinnerName
		{
			get { return r_WinnerName; }
		}
	}

	public class ScoreChangedEventArgs : EventArgs
	{
		private readonly int r_Player1Score;
		private readonly int r_Player2Score;

		public ScoreChangedEventArgs(int i_Player1Score, int i_Player2Score)
		{
			r_Player1Score = i_Player1Score;
			r_Player2Score = i_Player2Score;
		}

		public int Player1Score
		{
			get { return r_Player1Score; }
		}

		public int Player2Score
		{
			get { return r_Player2Score; }
		}
	}
}
