using System;

namespace ParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingLot parkingLot = null;
            string input;
            while ((input = Console.ReadLine()) != "exit")
            {
                var commands = input.Split(' ');

                if (commands.Length == 0)
                {
                    Console.WriteLine("Can not be empty");
                    continue;
                }

                if (parkingLot == null && commands[0] != "create_parking_lot")
                {
                    Console.WriteLine("The parking lot has not been created. Please create a parking spot first using the command \"create_parking_lot\"");
                    continue;
                }

                switch (commands[0])
                {
                    case "create_parking_lot":
                        if (commands.Length < 2)
                        {
                            Console.WriteLine("many parking slots are not available, please fill them");
                        }
                        else if (!int.TryParse(commands[1], out int size))
                        {
                            Console.WriteLine("the number of parking slots must be an integer");
                        }
                        else if (size <= 0)
                        {
                            Console.WriteLine("the number of parking slots must be greater than zero.");
                        }
                        else
                        {
                            parkingLot = new ParkingLot(size);
                            Console.WriteLine($"Created a parking lot with {size} slots");
                        }
                        break;

                    case "park":
                        if (commands.Length < 4 || commands.Length > 4)
                        {
                            Console.WriteLine("The data you entered is too much or too little");
                        }
                        else
                        {
                            var regNo = commands[1];
                            var color = commands[2];
                            var type = commands[3];
                            var result = parkingLot.ParkVehicle(new Vehicle { RegistrationNumber = regNo, Color = color, Type = type });
                            Console.WriteLine(result);
                        }
                        break;

                    case "leave":
                        if (commands.Length < 2 || commands.Length > 2)
                        {
                            Console.WriteLine("The data you entered is too much or too little");
                        }
                        else if (!int.TryParse(commands[1], out int slotNumber))
                        {
                            Console.WriteLine("Slot must be an integer.");
                        }
                        else
                        {
                            var leaveResult = parkingLot.Leave(slotNumber);
                            Console.WriteLine(leaveResult);
                        }
                        break;

                    case "status":
                        var status = parkingLot.Status();
                        Console.WriteLine(status);
                        break;

                    case "type_of_vehicles":
                        if (commands.Length < 2 || commands.Length > 2)
                        {
                            Console.WriteLine("The data you entered is too much or too little");
                        }
                        else
                        {
                            var vehicleType = commands[1];
                            var typeCount = parkingLot.CountByVehicleType(vehicleType);
                            Console.WriteLine(typeCount);
                        }
                        break;

                    case "registration_numbers_for_vehicles_with_ood_plate":
                        var oddNumbers = parkingLot.GetRegistrationNumbersByOddEven(true);
                        Console.WriteLine(string.Join(", ", oddNumbers));
                        break;

                    case "registration_numbers_for_vehicles_with_event_plate":
                        var evenNumbers = parkingLot.GetRegistrationNumbersByOddEven(false);
                        Console.WriteLine(string.Join(", ", evenNumbers));
                        break;

                    case "registration_numbers_for_vehicles_with_colour":
                            var searchColor = commands[1];
                            var vehiclesByColor = parkingLot.GetRegistrationNumbersByColor(searchColor);
                            Console.WriteLine(string.Join(", ", vehiclesByColor));
                        break;

                    case "slot_numbers_for_vehicles_with_colour":

                            var colorForSlots = commands[1];
                            var slotsByColor = parkingLot.GetSlotNumbersByColor(colorForSlots);
                            Console.WriteLine(string.Join(", ", slotsByColor));
                        
                        break;

                    case "slot_number_for_registration_number":
                            var searchRegNo = commands[1];
                            var slotByRegNo = parkingLot.GetSlotNumberByRegistrationNumber(searchRegNo);
                            Console.WriteLine(slotByRegNo);
                        
                        break;

                    default:
                        Console.WriteLine("Error: Invalid command.");
                        break;
                }
            }
        }
    }
}
