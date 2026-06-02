namespace Ex03.GarageLogic
{
    public class FuelTruck : Truck 
    {
        public FuelTruck(string i_LicenseID, string i_ModelName) :
               base(i_LicenseID,i_ModelName)
        {
            m_Engine = new FuelEngine(125.0f, eFuelType.Soler);
        }
    }
}
