namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxBatteryHours)
            : base(i_MaxBatteryHours)
        {
        }

        public void Charge(float i_HoursToAdd)
        {
            AddEnergy(i_HoursToAdd);
        }

        public override string ToString()
        {
            return string.Format("Electric: {0:F2} / {1:F2} hours", CurrentEnergy, MaxEnergy);
        }
    }
}