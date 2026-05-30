using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueRangeException : Exception
    {
        public float m_MinValue;
        public float m_MaxValue;

        public ValueRangeException(float i_MinValue, float i_MaxValue) : base($"Value must be between {i_MinValue} and {i_MaxValue}.")
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }
        // implemnt with string formnat !!!!!
    }
    
}
