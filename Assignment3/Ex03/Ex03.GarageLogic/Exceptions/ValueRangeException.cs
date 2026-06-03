using System;

namespace Ex03.GarageLogic
{
    public class ValueRangeException : Exception
    {
        private readonly float r_MinValue;
        private readonly float r_MaxValue;

        public ValueRangeException(float i_MinValue, float i_MaxValue, string i_ErrorMessage)
            : base(string.Format("Value must be between {0} and {1}, {2}", i_MinValue, i_MaxValue, i_ErrorMessage))
        {
            r_MinValue = i_MinValue;
            r_MaxValue = i_MaxValue;
        }
        public float MinValue
        {
            get { return r_MinValue; }
        }

        public float MaxValue
        {
            get { return r_MaxValue; }
        }
    }
}