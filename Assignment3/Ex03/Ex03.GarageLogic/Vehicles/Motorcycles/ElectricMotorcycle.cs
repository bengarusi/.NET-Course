namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle  
    {
        public ElectricMotorcycle(string i_LicenceID, string i_ModelName) :
               base(i_LicenceID, i_ModelName)
        {
            m_Engine = new ElectricEngine(3.0f);
        }

    }


}

