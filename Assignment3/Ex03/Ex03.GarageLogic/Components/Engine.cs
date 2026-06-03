using System;
namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private readonly float r_MaxEnergy;
        private float m_CurrentEnergy;

        protected Engine(float i_MaxEnergy)
        {
            r_MaxEnergy = i_MaxEnergy;
        }

        public float CurrentEnergy
        {
            get { return m_CurrentEnergy; }
        }

        public float MaxEnergy
        {
            get { return r_MaxEnergy; }
        }

        public float GetEnergyPercentage()
        {
            return (m_CurrentEnergy / r_MaxEnergy) * 100f; 
        }

        public void SetEnergyByPercentage(float i_Percentage)
        {
            if (i_Percentage < 0 || i_Percentage > 100)
            {
                throw new ValueRangeException(0, 100, "Invalid energy percentage.");
            }

            m_CurrentEnergy = (i_Percentage / 100f) * r_MaxEnergy;
        }

        protected void AddEnergy(float i_Amount, string i_Message)
        {
            if (i_Amount < 0 || m_CurrentEnergy + i_Amount > r_MaxEnergy)
            {
                throw new ValueRangeException(0, r_MaxEnergy, i_Message);
            }

            m_CurrentEnergy += i_Amount;
        }

        public abstract override string ToString();
    }
}