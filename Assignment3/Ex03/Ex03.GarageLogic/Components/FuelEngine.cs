using System;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        private readonly eFuelType r_FuelType;

        public FuelEngine(float i_MaxFuel, eFuelType i_FuelType) : base(i_MaxFuel)
        {
            r_FuelType = i_FuelType;
        }

        public eFuelType FuelType
        {
            get { return r_FuelType; }
        }

        public void Refuel(float i_LitersToAdd, eFuelType i_FuelType)
        {
            if (i_FuelType != r_FuelType)
            {
                throw new ArgumentException("Wrong fuel type for this vehicle.");
            }

            AddEnergy(i_LitersToAdd);
        }

        public override string ToString()
        {
            return string.Format("Fuel ({0}): {1:F2} / {2:F2} liters", r_FuelType, CurrentEnergy, MaxEnergy);
        }
    }
}