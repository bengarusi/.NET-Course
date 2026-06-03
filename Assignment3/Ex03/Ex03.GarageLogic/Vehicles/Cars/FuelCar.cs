namespace Ex03.GarageLogic
{
    public class FuelCar : Car 
    {
        
      public FuelCar(string i_LicenceID, string i_ModelName) 
            : base(i_LicenceID, i_ModelName)
        {
            m_Engine = new FuelEngine(51f, eFuelType.Octan95);
            
        } 
    }
}
