using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, GarageVehicleRecord> r_VehiclesInGarage =new Dictionary<string, GarageVehicleRecord>();

        // ----- Operation 1: load the system from the DB file -----
        public void ImportVehiclesFromFile(string[] i_Lines)
        {
            List<NewVehicleData> vehiclesData = VehicleFileLoader.ParseLines(i_Lines);
            foreach (NewVehicleData data in vehiclesData)
            {
                AddNewVehicle(data);
            }
        }

        // ----- Operation 2 -----
        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            return r_VehiclesInGarage.ContainsKey(i_LicenseNumber);
        }

        public List<string> GetRequiredFieldsForType(string i_VehicleType) // maybe not needed, just to tell the user what to enter for each type of vehicle
        {
            Vehicle vehicle = VehicleCreator.CreateVehicle(i_VehicleType, null, null);
            if (vehicle == null)
            {
                throw new ArgumentException("Unsupported vehicle type.");
            }

            return vehicle.GetRequiredFields();
        }

        public void AddNewVehicle(NewVehicleData i_NewVehicleToAdd)
        {
            Vehicle vehicle = VehicleCreator.CreateVehicle(
                i_NewVehicleToAdd.VehicleType, i_NewVehicleToAdd.LicenseNumber, i_NewVehicleToAdd.ModelName);
            if (vehicle == null)
            {
                throw new ArgumentException("Unsupported vehicle type.");
            }

            vehicle.SetEnergyPercentage(i_NewVehicleToAdd.EnergyPercentage);
            vehicle.SetWheelsData(i_NewVehicleToAdd.WheelManufacturer, i_NewVehicleToAdd.CurrentAirPressure);
            vehicle.InitializeUniqueData(i_NewVehicleToAdd.UniqueFields);

            GarageVehicleRecord record = new GarageVehicleRecord(
                vehicle, i_NewVehicleToAdd.OwnerName, i_NewVehicleToAdd.OwnerPhoneNumber);

            r_VehiclesInGarage[vehicle.LicenseNumber] = record;
        }

        // ----- Operation 3 -----
        public List<string> GetAllLicenseIds()
        {
            return new List<string>(r_VehiclesInGarage.Keys);
        }
        public List<string> GetLicenseIdsByStatus(eVehicleStatus i_VehicleStatus)
        {
            List<string> licenseIds = new List<string>();

            foreach (GarageVehicleRecord record in r_VehiclesInGarage.Values)
            {
                if (record.VehicleStatus == i_VehicleStatus)
                {
                    licenseIds.Add(record.Vehicle.LicenseNumber);
                }
            }

            return licenseIds;
        }

        // ----- Operation 4 -----
        public void ChangeVehicleStatus(string i_LicenseNumber, eVehicleStatus i_NewVehicleStatus)
        {
            GarageVehicleRecord record = getVehicleRecord(i_LicenseNumber);

            record.VehicleStatus = i_NewVehicleStatus;
        }
        // ----- Operation 5 -----
        public void InflateVehicleWheelsToMax(string i_LicenseNumber)
        {
            GarageVehicleRecord record = getVehicleRecord(i_LicenseNumber);

            record.Vehicle.InflateAllWheelsToMax();
        }

        // ----- Operation 6 -----
        public void RefuelVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_AmountToAdd)
        {
            //!!!!!! need to do - this is not generic maybe can do it better way !!!!!!
            FuelEngine engine = getVehicleRecord(i_LicenseNumber).Vehicle.Engine as FuelEngine;
            if (engine == null)
            {
                throw new ArgumentException("This vehicle is not fuel-powered.");
            }
            engine.Refuel(i_AmountToAdd, i_FuelType);
        }

        // ----- Operation 7 (input is minutes; the model stores hours) -----
        public void RechargeVehicle(string i_LicenseNumber, float i_MinutesToAdd)
        {
            //!!!!!! need to do - this is not generic maybe can do it better way !!!!!!
            ElectricEngine engine = getVehicleRecord(i_LicenseNumber).Vehicle.Engine as ElectricEngine;
            if (engine == null)
            {
                throw new ArgumentException("This vehicle is not electric.");
            }
            engine.Charge(i_MinutesToAdd / 60f);
        }

        // ----- Operation 8 -----
        public string GetFullVehicleDetails(string i_LicenseNumber)
        {
            GarageVehicleRecord record = getVehicleRecord(i_LicenseNumber);

            return record.ToString();
        }

        // ----- Utils -----
        private GarageVehicleRecord getVehicleRecord(string i_LicenseNumber)
        {
            if (!IsVehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentException(
                    string.Format("Vehicle with license number {0} was not found in the garage.", i_LicenseNumber));
            }

            return r_VehiclesInGarage[i_LicenseNumber];
        }

        
       
       
        
       
        
      
        

        


    }

}