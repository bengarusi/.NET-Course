using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// didnt use it !!!
namespace Ex03.GarageLogic
{
    public interface IFuelVehicle
    {
        eFuelType GetFuelType();
        float GetCurrentFuelAmount();
        float GetMaxFuelAmount();
        void Refuel(float i_amountToAdd, eFuelType i_fuelType);
    }
}
