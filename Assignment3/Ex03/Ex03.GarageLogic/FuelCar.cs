using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FuelCar : Car, IFuelVehicle
    {
        private readonly float r_MaxFuelAmount = 51f;
        private float m_CurrentFuelAmount;
        private readonly eFuelType m_FuelType;



        public FuelCar(string i_ModelName, string i_LicenseNumber) :
            base(i_ModelName, i_LicenseNumber)
        {
            m_FuelType = eFuelType.Octan95;

            this.CreateWheels(4, 31f);
        }

        public eFuelType GetFuelType()
        {
            return m_FuelType;
        }

        public float GetCurrentFuelAmount()
        {
            return m_CurrentFuelAmount;
        }

        public float GetMaxFuelAmount()
        {
            return r_MaxFuelAmount;
        }

        public void Refuel(float i_amountToAdd, eFuelType i_fuelType)
        {
            if (i_fuelType != m_FuelType)
            {
                throw new ArgumentException($"Invalid fuel type. Expected {m_FuelType}.");
            }

            AddEnergy(i_amountToAdd, r_MaxFuelAmount);
        }
    }
}
