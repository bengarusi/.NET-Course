using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelCar : Car ///, IFuelVehicle
    {
        
      public FuelCar(string i_LicenceID, string i_ModelName) :
             base(i_LicenceID, i_ModelName)
        {
            m_Engine = new FuelEngine(51f, eFuelType.Octan95);
            
        }
        
    }
}
