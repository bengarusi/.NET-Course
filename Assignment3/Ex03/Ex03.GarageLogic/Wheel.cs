using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;

        public Wheel(float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public void Initialize(string i_ManufacturerName, float i_CurrentAirPressure)
        {
            if(i_CurrentAirPressure < 0 || i_CurrentAirPressure > r_MaxAirPressure)
            {
                throw new ValueRangeException(0, r_MaxAirPressure);
            }
            m_ManufacturerName = i_ManufacturerName;
            m_CurrentAirPressure = i_CurrentAirPressure;

        }

        public string ManufacturerName
        {
            get { return m_ManufacturerName; }
            set { m_ManufacturerName = value; }
        }
        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set
            {
                if (value < 0 || value > r_MaxAirPressure)
                {
                    throw new ValueRangeException(0, r_MaxAirPressure);
                }
                m_CurrentAirPressure = value;
            }
        }
        public float MaxAirPressure
        {
            get { return r_MaxAirPressure; }
        }
        public void InflateWheel(float i_AirToAdd)
        {
            if (i_AirToAdd < 0 || m_CurrentAirPressure + i_AirToAdd > r_MaxAirPressure)
            {
                throw new ValueRangeException(0, r_MaxAirPressure - m_CurrentAirPressure);
            }
            m_CurrentAirPressure += i_AirToAdd;
        }
        public void InflateWheelToMax()
        {
            m_CurrentAirPressure = r_MaxAirPressure;
        }
    }
}
