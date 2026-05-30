using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle, IElectricVehicle
    {
        private readonly float r_MaxBatteryTime = 3.0f;
        private float m_currentBatteryTime;

        public ElectricMotorcycle(string i_LicenseID, string i_ModelName) :
            base(i_LicenseID, i_ModelName)
        {
        }



}


/*
 *  string i_modelName
            , string i_licenseNumber
            , float i_energyPercentage
            , List<Wheel> i_wheels
            , eLicenseType i_licenseType
            , int i_engineVolume
*/