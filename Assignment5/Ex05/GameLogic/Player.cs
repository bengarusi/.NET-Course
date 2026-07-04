namespace GameLogic
{
	public class Player
	{
		private readonly string r_Name;
		private readonly eSign r_Sign;
		private readonly bool r_IsComputer;

		private int m_Score = 0;

		public Player(string i_Name, eSign i_Sign, bool i_IsComputer)
		{
			r_Name = i_Name;
			r_Sign = i_Sign;
			r_IsComputer = i_IsComputer;
		}

		public string Name
		{
			get { return r_Name; }
		}

		public eSign Sign
		{
			get { return r_Sign; }
		}

		public bool IsComputer
		{
			get { return r_IsComputer; }
		}

		public int Score
		{
			get { return m_Score; }
		}

		public void AddPoint()
		{
			m_Score++;
		}
	}
}
