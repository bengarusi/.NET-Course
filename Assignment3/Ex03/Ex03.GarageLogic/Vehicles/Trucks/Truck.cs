using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Truck : Vehicle
    {
        private static readonly int sr_NumOfWheels = 14;   
        private static readonly float sr_MaxAirPressure = 28f;
        private bool m_IsCarryingRefrigerantCargo;
        private float m_CargoVolume;

        protected Truck( string i_ModelName, string i_LicenseNumber) :
            base(i_ModelName, i_LicenseNumber, sr_NumOfWheels, sr_MaxAirPressure)
        {
        }

        public bool IsCarryingRefrigerantCargo
        {
            get { return m_IsCarryingRefrigerantCargo; }
            set { m_IsCarryingRefrigerantCargo = value; }
        }

        public float CargoVolume
        {
            get { return m_CargoVolume; }
            set { m_CargoVolume = value; }
        }

        public override List<string> GetRequiredFields()
        {
            return new List<string>
            {
                "Carrying refrigerated cargo (true/false)",
                "Cargo volume"
            };
        }

        public override void InitializeUniqueData(List<string> i_TruckData)
        {
            m_IsCarryingRefrigerantCargo = bool.Parse(i_TruckData[0]);
            m_CargoVolume = float.Parse(i_TruckData[1]);
        }
        
        public override string ToString()
        {
            return base.ToString()
                + "Carrying cooled cargo: " + m_IsCarryingRefrigerantCargo + "\n"
                + "Cargo volume: " + m_CargoVolume + "\n";
        }

    }
}
