using DataLayer;
using Serilog;

namespace TrainerOnline
{
    internal class AddEducationPage : IMenu
    {
        static string constr = File.ReadAllText("../../../Database/cs.txt");
        readonly sql newSql = new(constr);
        internal static TEducation newEducation = new();
        public void Display()
        {
            Console.WriteLine($@"-------------------------Add Education-------------------------
    Press [1] - to add institute name - {newEducation.TUniversity}
    Press [2] - to add degree name - {newEducation.HdegreeName}
    Press [3] - to add gpa [eg: 8.2, 9.0, 5.6] - {newEducation.Cgpa}
    Press [4] - to add start year [format: yyyy] - {newEducation.startDate}
    Press [5] - to add end year [format: yyyy] - {newEducation.endDate}
    Press [6] - to add save changes
    Press [b] - to go back
    Press [0] - to exit");
        }

        public string UserOption()
        {
            string userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    Console.WriteLine("enter your institute name");
                    newEducation.TUniversity=Console.ReadLine();
                    return "AddEducationPage";
                case "2":
                    Console.WriteLine("enter your degree name");
                    newEducation.HdegreeName=Console.ReadLine();
                    return "AddEducationPage";
                case "3":
                    Console.WriteLine("enter your gpa");
                    string Cgpa= Console.ReadLine();    
                    if (Validation.IsValidGpa(Cgpa)){
                        newEducation.Cgpa = Cgpa;
                    }
                    else
                    {
                        newEducation.Cgpa= "";
                        Console.WriteLine("Invalid format, press enter to try again");
                        Console.ReadKey();
                    }
                    return "AddEducationPage";
                case "4":
                    Console.WriteLine("enter your start year");
                    string StartYear = Console.ReadLine();
                    if (Validation.IsValidYear(StartYear)) { 
                        newEducation.startDate = StartYear;
                    }
                    else
                    {
                        newEducation.startDate = "";
                        Console.WriteLine("Invalid format, press enter to try again");
                        Console.ReadKey();
                    }
                    return "AddEducationPage";
                case "5":
                    Console.WriteLine("enter your end year");
                    string EndYear = Console.ReadLine();
                    if (Validation.IsValidYear(EndYear))
                    {
                        newEducation.endDate = EndYear;
                    }
                    else
                    {
                        newEducation.endDate = "";
                        Console.WriteLine("Invalid format, press enter to try again");
                        Console.ReadKey();
                    }
                    return "AddEducationPage";
                case "6":
                    try { 
                        newSql.AddEducation(UserIdPage.newUserProfile.userid, newEducation);
                        Console.WriteLine("saving...");
                        Log.Information($"trainer with id: {UserIdPage.newUserProfile.userid} add a new education detail");
                    }catch(Exception ex) { 
                        Console.WriteLine(ex.Message);
                        Log.Error($"trainer with id: {UserIdPage.newUserProfile.userid} cound not add new education detail");
                    }
                    return "AddEducationPage";
                case "b":
                    return "UserIdPage";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Invalid response, please enter a valid input");
                    Console.WriteLine("Please press \"Enter\" to continue");
                    Console.ReadKey();
                    return "AddEducationPage";
            }
        }
    }
}
