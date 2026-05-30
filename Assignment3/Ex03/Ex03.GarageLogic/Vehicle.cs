using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_modelName;
        protected readonly string r_licenseNumber;
        protected readonly List<Wheel> wheels;
       // private EnergySource m_EnergySource;
        
        protected Vehicle(string i_modelName, string i_licenseNumber)
        {
            r_modelName = i_modelName;
            r_licenseNumber = i_licenseNumber;
            wheels = new List<Wheel>();
        }

       
        public string ModelName
        {
            get { return r_modelName; }
        }
        public string LicenseNumber
        {
            get { return r_licenseNumber; }
        }
        protected void CreateWheels(int i_NumberOfWheels, float i_MaxAirPressure)
        {
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                wheels.Add(new Wheel(i_MaxAirPressure));
            }
        }
        protected void InitializeWheels(string i_ManufacturerName, float i_CurrentAirPressure)
        {
            foreach (Wheel wheel in wheels)
            {
                wheel.ManufacturerName = i_ManufacturerName;
                wheel.CurrentAirPressure = i_CurrentAirPressure;
            }
        }

    }
}
