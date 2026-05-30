using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3
{
    public interface FuelVehicle
    {
        public void Refuel(float i_AmountOfFuelToAdd, eFuelType i_FuelType);
    }
}
