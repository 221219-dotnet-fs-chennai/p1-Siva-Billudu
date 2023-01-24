using DataLayer;
using Serilog;

namespace TrainerOnline
{
    internal class UpdateContact : IMenu
    {
        static string constr = File.ReadAllText("../../../Database/cs.txt");
        private static readonly sql newSql = new(constr);
        private static readonly TrContact newLocation = new();
        public void Display()
        {
            Console.WriteLine("-------------------------Location Details-------------------------");
            List<TrContact> newList = newSql.GetUserLocation(UserIdPage.newUserProfile.userid);
            if (newList.Count != 0) { 
                foreach (TrContact l in newList)
                {
                    Console.WriteLine("Current location");
                    Console.WriteLine(@$"zipcode - {l.pincode}
    city - {l.city}");
                }
                Console.WriteLine($@"
        press [1] to enter your zipcode - {newLocation.pincode}
        press [2] to enter your city name - {newLocation.city}
        press [3] to save changes
        press [b] to go back
        press [0] to exit");
            }
            else
            {
                Console.WriteLine("please add the location details first to update them, press b to go back"); 
            }
        }

        public string UserOption()
        {
            string userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    Console.WriteLine("enter the zipcode");
                    string ZipCode = Console.ReadLine();
                    if (Validation.IsValidZipcode(ZipCode)) {
                        newLocation.pincode = ZipCode;
                    }
                    else
                    {
                        newLocation.pincode = "";
                        Console.WriteLine("Invalid format, please press enter to retry");
                        Console.ReadKey();
                    }
                    return "UpdateLocationPage";
                case "2":
                    Console.WriteLine("enter the city");
                    newLocation.city = Console.ReadLine();
                    return "UpdateLocationPage";
                case "3":
                    try
                    {
                        newSql.UpdateNewUserLocation(UserIdPage.newUserProfile.userid, newLocation);
                        Console.WriteLine("saving...");
                        Log.Information($"trainer with id: {UserIdPage.newUserProfile.userid} updated location detail");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Log.Error($"trainer with id: {UserIdPage.newUserProfile.userid} could not update location detail");

                    }
                    return "UpdateLocationPage";
                case "b":
                    return "UserIdPage";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Invalid response, please enter a valid input");
                    Console.WriteLine("Please press \"Enter\" to continue");
                    Console.ReadKey();
                    return "UpdateLocationPage";
            }
        }
    }
}
