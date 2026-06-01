using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        protected eCarColor m_Color;
        protected int m_NumberOfDoors;
        private static readonly int sr_NumOfWheels = 5;
        private static readonly float sr_MaxAirPressure = 31f;

        protected Car(string i_ModelName, string i_Licence)
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
            m_Color = (eCarColor)Enum.Parse(typeof(eCarColor), (i_CarData[0])); 
            m_NumberOfDoors = int.Parse(i_CarData[1]);
        }

        public override string ToString()
        {
            return base.ToString()
                + "Color: " + m_Color + "\n"
                + "Number of doors: " + m_NumberOfDoors + "\n";
        }

    }

}
