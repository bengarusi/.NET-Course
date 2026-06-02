using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        protected eCarColor m_Color;
        protected int m_NumberOfDoors;
        private static readonly int sr_NumOfWheels = 5;
        private static readonly float sr_MaxAirPressure = 31f;

        protected Car(string i_Licence, string i_ModelName)
            : base(i_ModelName, i_Licence, sr_NumOfWheels, sr_MaxAirPressure)
        {
        }

        public eCarColor Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public int NumberOfDoors
        {
            get { return m_NumberOfDoors; }
            set { m_NumberOfDoors = value; }
        }

        public override List<string> GetRequiredFields()
        {
            return new List<string>
            {
                "Color (Red/Yellow/Black/Silver)",
                "Number of doors (2/3/4/5)"
            };
        }

        public override void InitializeUniqueData(List<string> i_CarData)
        {
            if(i_CarData == null || i_CarData.Count != 2)
            {
                throw new FormatException("Car data must contain color and number of doors.");
            }
            if (!Enum.TryParse(i_CarData[0], out m_Color))
            {
                throw new ArgumentException("Invalid car color.");
            }
            if (!int.TryParse(i_CarData[1], out m_NumberOfDoors))
            {
                throw new FormatException("Number of doors must be a valid integer.");
            }
            if (m_NumberOfDoors < 2 || m_NumberOfDoors > 5)
            {
                throw new ValueRangeException(2, 5);
            }
        }

        public override string ToString()
        {
            return base.ToString()
                + "Color: " + m_Color + "\n"
                + "Number of doors: " + m_NumberOfDoors + "\n";
        }

    }

}
