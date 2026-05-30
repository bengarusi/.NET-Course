using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle  ///, IElectricVehicle
    {
        public ElectricMotorcycle(string i_LicenceID, string i_ModelName) :
               base(i_LicenceID, i_ModelName)
        {
            m_Engine = new ElectricEngine(3.0f);
        }

    }


}

