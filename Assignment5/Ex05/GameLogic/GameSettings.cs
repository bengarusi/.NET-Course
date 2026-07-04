namespace GameLogic
{
	public class GameSettings
	{
		private readonly int r_BoardSize;
		private readonly string r_Player1Name;
		private readonly string r_Player2Name;
		private readonly eGameMode r_GameMode;

		public GameSettings(int i_BoardSize, string i_Player1Name, string i_Player2Name, eGameMode i_GameMode)
		{
			r_BoardSize = i_BoardSize;
			r_Player1Name = i_Player1Name;
			r_Player2Name = i_Player2Name;
			r_GameMode = i_GameMode;
		}

		public int BoardSize
		{
			get { return r_BoardSize; }
		}

		public string Player1Name
		{
			get { return r_Player1Name; }
		}

		public string Player2Name
		{
			get { return r_Player2Name; }
		}

		public eGameMode GameMode
		{
			get { return r_GameMode; }
		}
	}
}
