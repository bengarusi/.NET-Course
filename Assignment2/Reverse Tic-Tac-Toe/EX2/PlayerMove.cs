namespace Ex02
{
    public struct PlayerMove
    {
        private int m_Row;
        private int m_Column;
        public PlayerMove(int i_Row, int i_Column)
        {
            m_Row = i_Row;
            m_Column = i_Column;
        }

        public int GetRow()
        {
            return m_Row;
        }
        public int GetColumn()
        {
            return m_Column;
        }
    }
}
