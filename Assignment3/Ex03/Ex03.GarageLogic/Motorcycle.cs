using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        protected eLicenseType m_licenseType;
        protected int m_engineVolume;

       public Motorcycle(string i_Licence, string i_ModelName) :
            base(i_Licence, i_ModelName)
        { 
        }
        
}
