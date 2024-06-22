using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
    public class ParkingLot
    {
        private readonly int capacitys;
        private readonly Vehicle[] slots;

        public ParkingLot(int capacity)
        {
            capacitys = capacity; 
            slots = new Vehicle[capacitys]; 
        }

        public string ParkVehicle(Vehicle vehicle)
        {
            for (int i = 0; i < capacitys; i++) 
            {
                if (slots[i] == null) 
                {
                    slots[i] = vehicle;
                    return $"Allocated slot number: {i + 1}";
                }
            }
            return "Sorry, parking lot is full";
        }

        public string Leave(int slotNumber)
        {
            if (slotNumber <= 0 || slotNumber > capacitys)
            {
                return $"Slot number {slotNumber} is invalid";
            }
            if (slots[slotNumber - 1] == null)
            {
                return $"Slot number {slotNumber} is already free";
            }
            slots[slotNumber - 1] = null; 
            return $"Slot number {slotNumber} is free"; 
        }

        public string Status()
        {
            var status = "Slot\tNo.\t\tType\tRegistration No\tColour"; 
            for (int i = 0; i < capacitys; i++)
            {
                if (slots[i] != null)
                {
                    var vehicle = slots[i];
                    status += $"\n{i + 1}\t{vehicle.RegistrationNumber}\t{vehicle.Type}\t{vehicle.Color}";
                }
            }
            return status; 
        }

        public int CountByVehicleType(string type)
        {
            int count = 0; 
            for (int i = 0; i < slots.Length; i++)
            {
                Vehicle vehicle = slots[i]; 
                if (vehicle != null && vehicle.Type.Equals(type, StringComparison.OrdinalIgnoreCase))
                {
                    count++;
                }
            }
            return count;
        }

        // public IEnumerable<string> GetRegistrationNumbersByOddEven(bool isOdd)
        // {
        //     List<string> registrationNumbers = new List<string>(); 
        //     for (int i = 0; i < slots.Length; i++)
        //     {
        //         Vehicle vehicle = slots[i]; 
        //         if (vehicle != null)
        //         {
        //             string[] registrationParts = vehicle.RegistrationNumber.Split('-');
        //             string numberPart = registrationParts[registrationParts.Length - 1]; 

        //             int number;
        //             bool isNumeric = int.TryParse(numberPart, out number);

        //             if (isNumeric)
        //             {
        //                 bool isNumberOdd = number % 2 != 0;
        //                 if (isNumberOdd == isOdd)
        //                 {
        //                     registrationNumbers.Add(vehicle.RegistrationNumber); 
        //                 }
        //             }
        //         }
        //     }

        //     return registrationNumbers;
        // }
        public IEnumerable<string> GetRegistrationNumbersByOddEven(bool isOdd)
        {
            List<string> registrationNumbers = new List<string>();

            for (int i = 0; i < slots.Length; i++)
            {
                Vehicle vehicle = slots[i]; 

                if (vehicle != null)
                {
                    string[] registrationParts = vehicle.RegistrationNumber.Split('-');
            
                    string numberPart = registrationParts[1];

                    int number;
                    bool isNumeric = int.TryParse(numberPart, out number);

                    if (isNumeric)
                    {
                        bool isNumberOdd = number % 2 != 0;

                        if (isNumberOdd == isOdd)
                        {
                            registrationNumbers.Add(vehicle.RegistrationNumber);
                        }
                    }
                }
            }

            return registrationNumbers;
        }


        public IEnumerable<string> GetRegistrationNumbersByColor(string color)
        {
            List<string> registrationNumbers = new List<string>(); 
            for (int i = 0; i < slots.Length; i++)
            {
                Vehicle vehicle = slots[i];
                if (vehicle != null && vehicle.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
                {
                    registrationNumbers.Add(vehicle.RegistrationNumber);
                }
            }

            return registrationNumbers;
        }
        public IEnumerable<int> GetSlotNumbersByColor(string color)
        {
            List<int> slotNumbers = new List<int>(); 
            for (int i = 0; i < slots.Length; i++)
            {
                Vehicle vehicle = slots[i];

                if (vehicle != null && vehicle.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
                {
                    slotNumbers.Add(i + 1);
                }
            }

            return slotNumbers; 
        }
        public string GetSlotNumberByRegistrationNumber(string registrationNumber)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                Vehicle vehicle = slots[i]; 
                if (vehicle != null && vehicle.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase))
                {
                    return (i + 1).ToString(); 
                }
            }

            return "Not found";
        }

    }
}
