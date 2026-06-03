using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, GarageVehicleRecord> r_VehiclesInGarage = new Dictionary<string, GarageVehicleRecord>();

        public void ImportVehiclesFromFile(string[] i_Lines)
        {
            List<NewVehicleData> vehiclesData = VehicleFileLoader.ParseLines(i_Lines);
            foreach (NewVehicleData data in vehiclesData)
            {
                AddNewVehicle(data);
            }
        }

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            return r_VehiclesInGarage.ContainsKey(i_LicenseNumber);
        }

        public List<string> GetRequiredFieldsForType(string i_VehicleType) 
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
                i_NewVehicleToAdd.VehicleType,
                i_NewVehicleToAdd.LicenseNumber,
                i_NewVehicleToAdd.ModelName);

            if (vehicle == null)
            {
                throw new ArgumentException("Unsupported vehicle type.");
            }

            vehicle.SetEnergyPercentage(i_NewVehicleToAdd.EnergyPercentage);
            vehicle.SetWheelsData(i_NewVehicleToAdd.WheelManufacturer, i_NewVehicleToAdd.CurrentAirPressure);
            vehicle.InitializeUniqueData(i_NewVehicleToAdd.UniqueFields);

            GarageVehicleRecord record = new GarageVehicleRecord(
                vehicle,
                i_NewVehicleToAdd.OwnerName,
                i_NewVehicleToAdd.OwnerPhoneNumber);

            r_VehiclesInGarage[vehicle.LicenseNumber] = record;
        }

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

        public void ChangeVehicleStatus(string i_LicenseNumber, eVehicleStatus i_NewVehicleStatus)
        {
            GarageVehicleRecord record = GetVehicleRecord(i_LicenseNumber);

            record.VehicleStatus = i_NewVehicleStatus;
        }

        public void InflateVehicleWheelsToMax(string i_LicenseNumber)
        {
            GarageVehicleRecord record = GetVehicleRecord(i_LicenseNumber);

            record.Vehicle.InflateAllWheelsToMax();
        }

        public void RefuelVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_AmountToAdd)
        { 
            FuelEngine engine = GetVehicleRecord(i_LicenseNumber).Vehicle.Engine as FuelEngine;

            if (engine == null)
            {
                throw new ArgumentException("This vehicle is not fuel-powered.");
            }

            engine.Refuel(i_AmountToAdd, i_FuelType);

        }

        public void RechargeVehicle(string i_LicenseNumber, float i_MinutesToAdd)
        {
            
            ElectricEngine engine = GetVehicleRecord(i_LicenseNumber).Vehicle.Engine as ElectricEngine;

            if (engine == null)
            {
                throw new ArgumentException("This vehicle is not electric.");
            }

            engine.Charge(i_MinutesToAdd / 60f);

        }

        
        public string GetFullVehicleDetails(string i_LicenseNumber)
        {
            GarageVehicleRecord record = GetVehicleRecord(i_LicenseNumber);

            return record.ToString();
        }

        
        private GarageVehicleRecord GetVehicleRecord(string i_LicenseNumber)
        {
            if (!IsVehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentException(
                    string.Format("Vehicle with license number {0} was not found in the garage.", i_LicenseNumber));
            }

            return r_VehiclesInGarage[i_LicenseNumber];
        }
        
        public List<string> GetSupportedVehicleTypes()
        {
            return VehicleCreator.SupportedTypes;
        }
    }
}