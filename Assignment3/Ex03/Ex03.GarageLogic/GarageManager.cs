using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, GarageVehicleRecord> m_VehiclesInGarage;

        public GarageManager()
        {
            m_VehiclesInGarage = new Dictionary<string, GarageVehicleRecord>();
        }
        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            return m_VehiclesInGarage.ContainsKey(i_LicenseNumber);
        }
        public void AddVehicleToGarage(GarageVehicleRecord i_GarageVehicleRecord)
        {
            // implemt if
            m_VehiclesInGarage.Add(i_GarageVehicleRecord.Vehicle.LicenseNumber, i_GarageVehicleRecord);
        }
        public List<string> getLicenseIdsByStatus(eVehicleStatus i_VehicleStatus)
        {
            
        }
        public void ChangeVehicleStatus(string i_LicenseNumber, eVehicleStatus i_NewVehicleStatus)
        {
        }
        public void InflateVehicleWheelsToMax(string i_LicenseNumber)
        {
        }
        public void RefuelVehicle(string i_LicenseNumber,eFuelType i_FuelType, float i_AmountToAdd)
        {
        }

        public void RechargeVehicle(string i_LicenseNumber, float i_MinutesToAdd)
        {
        }
        public GarageVehicleRecord getFullVehicleDetails(string i_LicenseNumber)
        {
        }
    }
