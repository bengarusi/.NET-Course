using System;
using System.Collections.Generic;
using System.IO;
using Ex03.GarageLogic;



namespace Ex03.GarageLogic
{
    public class VehicleFileLoader
    {
        private const int k_VehicleTypeIndex = 0;
        private const int k_LicenseIDIndex = 1;
        private const int k_ModelNameIndex = 2;
        private const int k_EnergyPercentageIndex = 3;
        private const int k_WheelManufacturerIndex = 4;
        private const int k_CurrentAirPressureIndex = 5;
        private const int k_OwnerNameIndex = 6;
        private const int k_OwnerPhoneIndex = 7;
        private const int k_FirstUniqueFieldIndex = 8;
        private const int k_MinimalNumberOfFields = 8;

        public static List<NewVehicleData> ParseLines(string[] i_Lines)
        {
            List<NewVehicleData> vehicleDataList = new List<NewVehicleData>();

            foreach (string line in i_Lines)
            {

                vehicleDataList.Add(createVehicleFromLine(line));
            }

            return vehicleDataList;
        }


        private static NewVehicleData createVehicleFromLine(string i_Line)
        {
            string[] fields = i_Line.Split(',');

            if (fields.Length < k_MinimalNumberOfFields)
            {
                throw new FormatException("Vehicle line has missing fields.");
            }

            NewVehicleData newVehicle = new NewVehicleData();
            newVehicle.VehicleType = fields[k_VehicleTypeIndex];
            newVehicle.LicenseNumber = fields[k_LicenseIDIndex];
            newVehicle.ModelName = fields[k_ModelNameIndex];
            newVehicle.EnergyPercentage = float.Parse(fields[k_EnergyPercentageIndex]);
            newVehicle.WheelManufacturer = fields[k_WheelManufacturerIndex];
            newVehicle.CurrentAirPressure = float.Parse(fields[k_CurrentAirPressureIndex]);
            newVehicle.OwnerName = fields[k_OwnerNameIndex];
            newVehicle.OwnerPhoneNumber = fields[k_OwnerPhoneIndex];

            List<string> uniqueFieldsForSpecificVehicle = new List<string>();
            for (int i = k_FirstUniqueFieldIndex; i < fields.Length; i++)
            {
                uniqueFieldsForSpecificVehicle.Add(fields[i]);
            }

            newVehicle.UniqueFields = uniqueFieldsForSpecificVehicle;

            return newVehicle;
        }





     

    }
}