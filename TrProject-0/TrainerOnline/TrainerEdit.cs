using DataLayer;
using System.Collections.Generic;
using Serilog;

namespace TrainerOnline
{
    internal class TrainerEdit : IMenu
    {
        static string constr = File.ReadAllText("../../../Database/cs.txt");
        internal static TrDetails userUpdate = new();
        private readonly sql newSql = new sql(constr);
        public void Display()
        {
            try
            {
                Console.WriteLine("-------------------------User Profile-------------------------");
                Console.WriteLine($@"
    Edit your profile

    press [1] - to edit Fullname: {userUpdate.Fullname}
    press [2] - to edit Phone: {userUpdate.phone}
    press [3] - to edit Website: {userUpdate.website}
    
    press [4] - to edit Gender: {userUpdate.gender}
    press [5] - to enter to save the changes
    press [0] - to exit
    press [b] - to go back");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public string UserOption()
        {

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Enter your full name [required]");
                    userUpdate.Fullname = Console.ReadLine();
                    return "TrainerEdit";
                case "2":
                    Console.WriteLine("Enter your phone number [must contain 10 digits]");
                    string newPhone = Console.ReadLine();
                    if (Validation.IsValidPhone(newPhone))
                    {
                        userUpdate.phone = newPhone;
                    }
                    else
                    {
                        userUpdate.phone = "";
                        Console.WriteLine("Invalid format, please press enter to try again");
                        Console.ReadKey();
                    }
                    return "TrainerEdit";
                case "3":
                    Console.WriteLine("Enter your website url");
                    string newWebsite = Console.ReadLine();
                    if (Validation.IsValidWebsite(newWebsite))
                    {
                        userUpdate.website = newWebsite;
                    }
                    else
                    {
                        userUpdate.website = "";
                        Console.WriteLine("Invalid format, please press enter to try again");
                        Console.ReadKey();
                    }
                    return "TrainerEdit";
                case "4":
                    Console.WriteLine("Enter your gender");
                    string NewGender = Console.ReadLine();
                    if (Validation.IsValidGender(NewGender))
                    {
                        userUpdate.gender = NewGender;
                    }
                    else
                    {
                        userUpdate.gender = "";
                        Console.WriteLine("Invalid format, please press enter to try again\r");
                        Console.ReadKey();
                    }
                    return "TrainerEdit";
                case "6":
                    try
                    {
                        Console.WriteLine("saving changes...");
                        newSql.AddOtherDetails(UserIdPage.newUserProfile.userid, userUpdate);
                        Log.Information($"trainer with id: {UserIdPage.newUserProfile.userid} updated their personal details");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Log.Error($"trainer with id: {UserIdPage.newUserProfile.userid} could not update their personal details");

                    }
                    return "TrainerEdit";
                case "b":
                    return "UserIdPage";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Invalid response, please enter a valid input");
                    Console.WriteLine("Please press \"Enter\" to continue");
                    Console.ReadKey();
                    return "TrainerEdit";
            }
        }
    }
}
