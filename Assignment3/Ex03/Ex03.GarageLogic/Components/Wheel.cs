using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly float r_MaxAirPressure;
        private string m_ManufacturerName; // should be readonly
        private float m_CurrentAirPressure;

        public Wheel(float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public string ManufacturerName
        {
            get { return m_ManufacturerName; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
        }

        public float MaxAirPressure
        {
            get { return r_MaxAirPressure; }
        }

        public void SetWheelDetails(string i_ManufacturerName, float i_CurrentAirPressure)
        {
            if (i_CurrentAirPressure > r_MaxAirPressure)
            {
                throw new ValueRangeException(0, r_MaxAirPressure);
            }

            m_ManufacturerName = i_ManufacturerName;
            m_CurrentAirPressure = i_CurrentAirPressure;
        }

        public void Inflate(float i_AirToAdd)
        {
            if (m_CurrentAirPressure + i_AirToAdd > r_MaxAirPressure)
            {
                throw new ValueRangeException(0, r_MaxAirPressure);
            }

            m_CurrentAirPressure += i_AirToAdd;
        }

        public void InflateToMax()
        {
            m_CurrentAirPressure = r_MaxAirPressure;
        }

    }
}
