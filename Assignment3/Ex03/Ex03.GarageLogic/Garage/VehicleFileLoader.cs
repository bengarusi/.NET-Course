using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class VehicleFileLoader
    {
        private static readonly int sr_VehicleTypeIndex = 0;
        private static readonly int sr_LicenseIDIndex = 1;
        private static readonly int sr_ModelNameIndex = 2;
        private static readonly int sr_EnergyPercentageIndex = 3;
        private static readonly int sr_WheelManufacturerIndex = 4;
        private static readonly int sr_CurrentAirPressureIndex = 5;
        private static readonly int sr_OwnerNameIndex = 6;
        private static readonly int sr_OwnerPhoneIndex = 7;
        private static readonly int sr_FirstUniqueFieldIndex = 8;
        private static readonly int sr_MinimalNumberOfFields = 8;

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

            if (fields.Length < sr_MinimalNumberOfFields)
            {
                throw new FormatException("Vehicle line has missing fields.");
            }

            NewVehicleData newVehicle = new NewVehicleData();
            newVehicle.VehicleType = fields[sr_VehicleTypeIndex];
            newVehicle.LicenseNumber = fields[sr_LicenseIDIndex];
            newVehicle.ModelName = fields[sr_ModelNameIndex];
            newVehicle.EnergyPercentage = float.Parse(fields[sr_EnergyPercentageIndex]);
            newVehicle.WheelManufacturer = fields[sr_WheelManufacturerIndex];
            newVehicle.CurrentAirPressure = float.Parse(fields[sr_CurrentAirPressureIndex]);
            newVehicle.OwnerName = fields[sr_OwnerNameIndex];
            newVehicle.OwnerPhoneNumber = fields[sr_OwnerPhoneIndex];

            List<string> uniqueFieldsForSpecificVehicle = new List<string>();
            for (int i = sr_FirstUniqueFieldIndex; i < fields.Length; i++)
            {
                uniqueFieldsForSpecificVehicle.Add(fields[i]);
            }

            newVehicle.UniqueFields = uniqueFieldsForSpecificVehicle;

            return newVehicle;
        }
    }
}