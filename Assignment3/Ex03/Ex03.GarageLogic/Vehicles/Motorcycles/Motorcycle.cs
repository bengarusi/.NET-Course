using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        protected eLicenseType m_LicenseType;
        protected int m_EngineVolume;
        private static readonly int sr_NumOfWheels = 2;
        private static readonly float sr_MaxAirPressure = 30f;

        public Motorcycle(string i_Licence, string i_ModelName) :
             base(i_ModelName, i_Licence, sr_NumOfWheels, sr_MaxAirPressure)
        {
        }

        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public int EngineVolume
        {
            get { return m_EngineVolume; }
            set { m_EngineVolume = value; }

        }

        public override List<string> GetRequiredFields()
        {
            return new List<string>
            {
                "License type (A/A2/B1/AB)",
                "Engine volume (cc)"
            };
        }

        public override void InitializeUniqueData(List<string> i_MotorcycleData)
        {
            if(i_MotorcycleData == null ||i_MotorcycleData.Count != 2)
            {
                throw new FormatException("Motorcycle data must contain license type and engine volume.");
            }
            if(!Enum.TryParse(i_MotorcycleData[0], out m_LicenseType))
            {
                throw new ArgumentException("Invalid license type.");
            }
            if(!int.TryParse(i_MotorcycleData[1], out m_EngineVolume))
            {
                throw new FormatException("Engine volume must be a valid integer.");
            }
            if (m_EngineVolume < 0)
            {
                throw new ValueRangeException(0, 1500000);
            }
        }

      
        public override string ToString()
        {
            return base.ToString()
                + "License type: " + m_LicenseType + "\n"
                + "Engine volume: " + m_EngineVolume + " cc" + "\n";
        }
    }
}