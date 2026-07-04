using System;

namespace GameLogic
{
	public class GameManager
	{
		private readonly GameSettings r_Settings;
		private readonly Player r_Player1;
		private readonly Player r_Player2;
		private readonly ComputerPlayer r_ComputerPlayer = new ComputerPlayer();

		private Board m_GameBoard;
		private Player m_CurrentPlayer;

		public delegate void CellChangedEventHandler(object sender, CellChangedEventArgs e);
		public delegate void RoundEndedEventHandler(object sender, RoundEndedEventArgs e);
		public delegate void ScoreChangedEventHandler(object sender, ScoreChangedEventArgs e);

		public event CellChangedEventHandler CellChanged;
		public event RoundEndedEventHandler RoundEnded;
		public event ScoreChangedEventHandler ScoreChanged;
		public event EventHandler BoardCleared;

		public GameManager(GameSettings i_Settings)
		{
			r_Settings = i_Settings;
			r_Player1 = new Player(i_Settings.Player1Name, eSign.X, false);

			bool isPlayer2Computer = i_Settings.GameMode == eGameMode.HumanVsComputer;
			r_Player2 = new Player(i_Settings.Player2Name, eSign.O, isPlayer2Computer);

			initializeRound();
		}

		public int BoardSize
		{
			get { return r_Settings.BoardSize; }
		}

		public string Player1Name
		{
			get { return r_Player1.Name; }
		}

		public string Player2Name
		{
			get { return r_Player2.Name; }
		}

		public int Player1Score
		{
			get { return r_Player1.Score; }
		}

		public int Player2Score
		{
			get { return r_Player2.Score; }
		}

		public void PlayMove(int i_Row, int i_Col)
		{
			bool wasCellFilled = m_GameBoard.FillCell(new Move(i_Row, i_Col), m_CurrentPlayer.Sign);

			if (wasCellFilled)
			{
				OnCellChanged(i_Row, i_Col);

				if (!endRoundIfOver())
				{
					switchToNextPlayer();

					if (m_CurrentPlayer.IsComputer)
					{
						playComputerMove();
					}
				}
			}
		}

		public void StartNewRound()
		{
			initializeRound();
			OnBoardCleared();
		}

		private void initializeRound()
		{
			m_GameBoard = new Board(r_Settings.BoardSize);
			m_CurrentPlayer = r_Player1;
		}

		private void playComputerMove()
		{
			Move computerMove = r_ComputerPlayer.ChooseMove(m_GameBoard, m_CurrentPlayer.Sign);
			m_GameBoard.FillCell(computerMove, m_CurrentPlayer.Sign);
			OnCellChanged(computerMove.Row, computerMove.Col);

			if (!endRoundIfOver())
			{
				switchToNextPlayer();
			}
		}

		private bool endRoundIfOver()
		{
			bool hasRoundEnded = false;

			if (m_GameBoard.HasLosingSequence(m_CurrentPlayer.Sign))
			{
				Player winner = getOpponent(m_CurrentPlayer);
				winner.AddPoint();
				OnScoreChanged();
				OnRoundEnded(eRoundResult.Win, winner.Name);
				hasRoundEnded = true;
			}
			else if (m_GameBoard.IsFull())
			{
				OnRoundEnded(eRoundResult.Tie, string.Empty);
				hasRoundEnded = true;
			}

			return hasRoundEnded;
		}

		private void switchToNextPlayer()
		{
			m_CurrentPlayer = getOpponent(m_CurrentPlayer);
		}

		private Player getOpponent(Player i_Player)
		{
			Player opponent;

			if (i_Player == r_Player1)
			{
				opponent = r_Player2;
			}
			else
			{
				opponent = r_Player1;
			}

			return opponent;
		}

		protected virtual void OnCellChanged(int i_Row, int i_Col)
		{
			if (CellChanged != null)
			{
				eSign signAtCell = m_GameBoard.GetCell(i_Row, i_Col);
				CellChanged.Invoke(this, new CellChangedEventArgs(i_Row, i_Col, signAtCell));
			}
		}

		protected virtual void OnRoundEnded(eRoundResult i_Result, string i_WinnerName)
		{
			if (RoundEnded != null)
			{
				RoundEnded.Invoke(this, new RoundEndedEventArgs(i_Result, i_WinnerName));
			}
		}

		protected virtual void OnScoreChanged()
		{
			if (ScoreChanged != null)
			{
				ScoreChanged.Invoke(this, new ScoreChangedEventArgs(r_Player1.Score, r_Player2.Score));
			}
		}

		protected virtual void OnBoardCleared()
		{
			if (BoardCleared != null)
			{
				BoardCleared.Invoke(this, EventArgs.Empty);
			}
		}
	}
}
