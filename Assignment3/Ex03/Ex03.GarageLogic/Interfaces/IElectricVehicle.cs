using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// didnt use it !!!
namespace Ex03.GarageLogic
{
    public interface IElectricVehicle
    {
        float GetCurrentBatteryTime();
        float GetMaxBatteryTime();
        void Recharge(float i_timeToAdd);
    }
}
