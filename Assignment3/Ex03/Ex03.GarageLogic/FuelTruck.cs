using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelTruck : Vehicle,IFuelVehicle
    {
        private readonly float r_MaxFuelAmount = 125.0f;
        private float m_CurrentFuelAmount;
        private eFuelType m_FuelType;



        public FuelTruck(string i_ModelName, string i_LicenseNumber) : 
            base(i_ModelName, i_LicenseNumber)
        {
            m_FuelType = eFuelType.Soler;
        }
}
