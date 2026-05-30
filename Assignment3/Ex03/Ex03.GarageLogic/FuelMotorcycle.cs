using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : Motorcycle, IFuelVehicle
    {
        private readonly float r_MaxFuelAmount = 5.6f;
        private float m_currentFuelAmount;
        private eFuelType m_FuelType;

        public FuelMotorcycle(string i_LicenseID, string i_ModelName) :
            base(i_LicenseID, i_ModelName)
        {
            m_FuelType = eFuelType.Octan95;
        }

      




        /*
         public float EnergyPercentage
        {
            get { return m_energyPercentage; }
            set { m_energyPercentage = value; }
        }
        */





    }
