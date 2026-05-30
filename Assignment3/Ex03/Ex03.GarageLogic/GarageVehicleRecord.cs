using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageVehicleRecord
    {
        private Vehicle m_Vehicle;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus; 


        public GarageVehicleRecord(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            m_Vehicle = i_Vehicle;
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleStatus = eVehicleStatus.InRepair;
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }

        public string OwnerName
        {
            get { return m_OwnerName; }
        }
        public string OwnerPhoneNumber
        {
            get { return m_OwnerPhoneNumber; }
        }

        public eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }

        public string GetFullDetails()
        {
            /*
            return string.Format()

            StringBuilder details = new StringBuilder();
            details.AppendLine($"Owner Name: {m_OwnerName}");
            details.AppendLine($"Owner Phone Number: {m_OwnerPhoneNumber}");
            details.AppendLine($"Vehicle Status: {m_VehicleStatus}");
            details.AppendLine($"Vehicle Model: {m_Vehicle.ModelName}");
            details.AppendLine($"Vehicle License Number: {m_Vehicle.LicenseNumber}");
            details.AppendLine($"Energy Percentage: {m_Vehicle.EnergyPercentage}%");
            // Add more vehicle details as needed
            return details.ToString();
            */

        }
}

