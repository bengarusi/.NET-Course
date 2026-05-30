using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        
        private bool m_IsCarryingRefrigerantCargo;
        private float m_CargoVolume;

        protected Truck(string i_ModelName, string i_LicenseNumber) :
            base(i_ModelName, i_LicenseNumber)
        {
        }
    

    }
}
