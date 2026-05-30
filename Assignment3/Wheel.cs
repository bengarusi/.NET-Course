using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3
{
    public class Wheel
    {
        public string m_Manufacturer;
        public float m_CurrentAirPressure;
        public float m_MaxAirPressure;


        public Wheel(string i_Manufacturer, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_Manufacturer = i_Manufacturer;
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public void Inflate(float i_AirToAdd)
        {
        }
    }
}
