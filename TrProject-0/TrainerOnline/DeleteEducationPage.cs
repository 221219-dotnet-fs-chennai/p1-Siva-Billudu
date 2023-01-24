using DataLayer;
using Serilog;

namespace TrainerOnline
{
    internal class DeleteEducationPage : IMenu
    {
        static string constr = File.ReadAllText("../../../Database/cs.txt");
        readonly sql newSql = new(constr);
        private static readonly TEducation newEducation = new();
        public void Display()
        {
            List<TEducation> list = new List<TEducation>();
            list = newSql.GetEducation(UserIdPage.newUserProfile.userid);
            int j = 0;
            Console.WriteLine("-------------------------Education Details-------------------------");
            foreach (TEducation i in list)
            {
                Console.WriteLine($"No. {j}");
                Console.WriteLine($@"
    institute name: {i.TUniversity}
    degree name: {i.HdegreeName}
    gpa: {i.Cgpa}
    start date: {i.startDate}
    end date: {i.endDate}
    ------------------------");
                j++;
            }
            Console.WriteLine(@"
    press [1] - to enter the start year of the education detail that you want to delete
    press [2] - to delete the education detail
    press [b] - to go back
    press [0] - exit");
        }


        public string UserOption()
        {
            string userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    Console.WriteLine("enter the start year of any one of the education details");
                    string StartYear = Console.ReadLine();  
                    if (Validation.IsValidYear(StartYear)) {
                        newEducation.startDate = StartYear;
                    }
                    else
                    {
                        newEducation.startDate = "";
                        Console.WriteLine("invalid format, please press enter to try again");
                        Console.ReadKey();
                    }
                    return "DeleteEducationPage";
                case "2":
                    try
                    {
                        newSql.DeleteEducation(UserIdPage.newUserProfile.userid,newEducation.startDate);
                        Console.WriteLine("deleting...");
                        Log.Information($"trainer with id: {UserIdPage.newUserProfile.userid} deleted one education detail");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Log.Error($"trainer with id: {UserIdPage.newUserProfile.userid} could not delete education detail");
                    }
                    return "DeleteEducationPage";
                case "b":
                    return "UserIdPage";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Invalid response, please enter a valid input");
                    Console.WriteLine("Please press \"Enter\" to continue");
                    Console.ReadKey();
                    return "DeleteEducationPage";
            }
        }
    }
}

