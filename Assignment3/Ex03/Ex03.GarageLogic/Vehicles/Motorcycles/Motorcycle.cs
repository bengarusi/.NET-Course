using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            m_LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), (i_MotorcycleData[0])); 
            m_EngineVolume = int.Parse(i_MotorcycleData[1]);
        }

      
        public override string ToString()
        {
            return base.ToString()
                + "License type: " + m_LicenseType + "\n"
                + "Engine volume: " + m_EngineVolume + " cc" + "\n";
        }

    }
}
