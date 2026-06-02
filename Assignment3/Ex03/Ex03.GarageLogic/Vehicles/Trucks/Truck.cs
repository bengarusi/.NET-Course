using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Truck : Vehicle
    {
        private static readonly int sr_NumOfWheels = 14;   
        private static readonly float sr_MaxAirPressure = 28f;
        private bool m_IsCarryingRefrigerantCargo;
        private float m_CargoVolume;

        protected Truck(string i_LicenseNumber, string i_ModelName) :
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
            if (i_TruckData == null || i_TruckData.Count != 2)
            {
                throw new System.FormatException("Truck data must contain carrying refrigerated cargo and cargo volume.");
            }
            if (!bool.TryParse(i_TruckData[0], out m_IsCarryingRefrigerantCargo))
            {
                throw new System.FormatException("Invalid value for carrying refrigerated cargo.");
            }
            if (!float.TryParse(i_TruckData[1], out m_CargoVolume))
            {
                throw new System.FormatException("Cargo volume must be a valid number.");
            }
            if (m_CargoVolume < 0)
            {
                throw new ValueRangeException(0, 100000);
            }
        }
        
        public override string ToString()
        {
            return base.ToString()
                + "Carrying cooled cargo: " + m_IsCarryingRefrigerantCargo + "\n"
                + "Cargo volume: " + m_CargoVolume + "\n";
        }

    }
}
