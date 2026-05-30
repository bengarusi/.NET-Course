using System.Collections.Generic;

// the form the user fills out !!
namespace Ex03.GarageLogic
{
    public class NewVehicleData
    {
        private string m_VehicleType;
        private string m_LicenseNumber;
        private string m_ModelName;
        private float m_EnergyPercentage;
        private string m_WheelManufacturer;
        private float m_CurrentAirPressure;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private List<string> m_UniqueFields;

        public string VehicleType
        {
            get { return m_VehicleType; }
            set { m_VehicleType = value; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        public string ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }

        public float EnergyPercentage
        {
            get { return m_EnergyPercentage; }
            set { m_EnergyPercentage = value; }
        }

        public string WheelManufacturer
        {
            get { return m_WheelManufacturer; }
            set { m_WheelManufacturer = value; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }

        public string OwnerName
        {
            get { return m_OwnerName; }
            set { m_OwnerName = value; }
        }

        public string OwnerPhoneNumber
        {
            get { return m_OwnerPhoneNumber; }
            set { m_OwnerPhoneNumber = value; }
        }

        public List<string> UniqueFields
        {
            get { return m_UniqueFields; }
            set { m_UniqueFields = value; }
        }
    }
}