namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : Motorcycle 
    {
        public FuelMotorcycle(string i_LicenceID, string i_ModelName) :
               base(i_LicenceID, i_ModelName)
        {
            m_Engine = new FuelEngine(5.6f, eFuelType.Octan98);
        }
    }
}
