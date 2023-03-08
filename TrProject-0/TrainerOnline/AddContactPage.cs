using DataLayer;
using Serilog;

namespace TrainerOnline
{
    internal class AddContactPage : IMenu
    {
        static string constr = File.ReadAllText("../../../Database/cs.txt");
        private static readonly sql newSql = new(constr);
        private static readonly TrContact newLocation = new();
        public void Display()
        {

            Console.WriteLine($@"-------------------------Add Location-------------------------
    press [1] to enter your pincode - {newLocation.pincode}
    press [2] to enter your city name - {newLocation.city}
    press [3] to save changes
    press [b] to go back
    press [0] to exit");
        }

        public string UserOption()
        {
            string userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    Console.WriteLine("enter the pincode");
                    string pincode = Console.ReadLine();
                    if (Validation.IsValidZipcode(pincode)) {
                        newLocation.pincode = pincode;
                    }
                    else
                    {
                        newLocation.pincode = "";
                        Console.WriteLine("Invalid format, please press enter to try again");
                        Console.ReadKey(); 
                    }
                    return "AddContactPage";
                case "2":
                    Console.WriteLine("enter the city");
                    newLocation.city = Console.ReadLine();
                    return "AddContactPage";
                case "3":
                    try
                    {
                        newSql.AddNewUserLocation(UserIdPage.newUserProfile.userid, newLocation);
                        Console.WriteLine("saving...");
                        Log.Information($"trainer with id {UserIdPage.newUserProfile.userid} added new Contact detail");
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                        Log.Error($"trainer with id {UserIdPage.newUserProfile.userid} could not add Contact detail");
                    }
                    return "AddContactPage";
                case "b":
                    return "UserIdPage";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Invalid response, please enter a valid input");
                    Console.WriteLine("Please press \"Enter\" to continue");
                    Console.ReadKey();
                    return "AddContactPage";
            }
        }
    }
}
