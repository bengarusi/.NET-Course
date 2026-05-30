using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelTruck : Truck ///, IFuelVehicle
    {
        public FuelTruck(string i_LicenseID, string i_ModelName) :
               base(i_LicenseID,i_ModelName)
        {
            m_Engine = new FuelEngine(125.0f, eFuelType.Soler);
        }

        /*
        public eFuelType GetFuelType()
        {
            return (m_Engine as FuelEngine).FuelType;
        }

        public float GetCurrentFuelAmount()
        {
            return m_Engine.CurrentEnergy;
        }

        public float GetMaxFuelAmount()
        {
            return m_Engine.MaxEnergy;
        }

        public void Refuel(float i_amountToAdd, eFuelType i_fuelType)
        {
            FuelEngine fuelEngine = m_Engine as FuelEngine;
            fuelEngine.Refuel(i_amountToAdd, i_fuelType);
        }
        */
    }
}
