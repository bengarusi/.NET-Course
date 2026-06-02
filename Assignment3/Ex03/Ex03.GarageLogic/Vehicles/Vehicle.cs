using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_ModelName;
        protected readonly string r_LicenseNumber;
        protected readonly List<Wheel> r_Wheels;
        protected Engine m_Engine;
        protected Vehicle(string i_ModelName, string i_LicenseNumber, int i_NumberOfWheels, float i_MaxAirPressure)
        {
            r_ModelName = i_ModelName;
            r_LicenseNumber = i_LicenseNumber;

            r_Wheels = new List<Wheel>();
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                r_Wheels.Add(new Wheel(i_MaxAirPressure));
            }
        }
       
        public Engine Engine
        {
            get { return m_Engine; }
        }

        public string ModelName
        {
            get { return r_ModelName; }
        }

        public string LicenseNumber
        {
            get { return r_LicenseNumber; }
        }

        public List<Wheel> Wheels
        {
            get { return r_Wheels; }
        }

        public void SetEnergyPercentage(float i_Percentage)
        {
            m_Engine.SetEnergyByPercentage(i_Percentage);
        }

        public void SetWheelsData(string i_ManufacturerName, float i_CurrentAirPressure)
        {
            foreach (Wheel wheel in r_Wheels)
            {
                wheel.SetWheelDetails(i_ManufacturerName, i_CurrentAirPressure);
            }
        }

        public void InflateAllWheelsToMax()
        {
            foreach (Wheel wheel in r_Wheels)
            {
                wheel.InflateToMax();
            }
        }

        public abstract List<string> GetRequiredFields();

        public abstract void InitializeUniqueData(List<string> i_UniqueData);

        public override string ToString()
        {
            StringBuilder details = new StringBuilder(); 

            details.AppendLine("License: " + r_LicenseNumber);
            details.AppendLine("Model: " + r_ModelName);
            details.AppendLine(m_Engine.ToString());
            foreach (Wheel wheel in r_Wheels)
            {
                details.AppendLine(string.Format(
                    "Wheel - {0}, pressure {1:F1} / {2:F1}", wheel.ManufacturerName, wheel.CurrentAirPressure, wheel.MaxAirPressure));
            }

            return details.ToString();
        }

    }
}
