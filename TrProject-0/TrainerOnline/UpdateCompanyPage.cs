using DataLayer;
using Serilog;

namespace TrainerOnline
{
    internal class UpdateCompanyPage : IMenu
    {
        static string constr = File.ReadAllText("../../../Database/cs.txt");
        readonly sql newSql = new(constr);
        internal static TCompany newCompany = new();
        static string oldCname= "";
        static string newCname= "";
        static string oldCType = "";
        static string newCType = "";
        static string oldStartDate = "";
        static string newStartDate = "";
        static string oldEndDate = "";
        static string NewEndDate = "";
        public void Display()
        {
            List<TCompany> list = newSql.GetCompany(UserIdPage.newUserProfile.userid);
            int j = 0;
            Console.WriteLine("-------------------------Experience Details-------------------------");
            if (list.Count != 0) {
                foreach (TCompany i in list) {
                    Console.WriteLine($"No. {j}");
                    Console.WriteLine($@"
        company name: {i.Cname}
        title: {i.CType}
        start date: {i.startdate}
        end date: {i.enddate}
        -------------------------");
                    j++;
                }
            }
            else
            {
                Console.WriteLine("your experience details are empty please add the experience details first before updating them, press b to go back");
            }
            Console.WriteLine(@$"
    press [1] - update company name - {newCname}
    press [2] - update title name - {newCType}
    press [3] - update start date - {newStartDate}
    press [4] - update end date - {NewEndDate}
    press [5] - save changes
    press [b] - go back
    press [0] - to exit");
        }

        public string UserOption()
        {
            string userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    Console.WriteLine("enter old company name");
                    oldCname= Console.ReadLine();
                    Console.WriteLine("enter new company name");
                    newCname= Console.ReadLine();
                    return "UpdateCompanyPage";
                case "2":
                    Console.WriteLine("enter old title");
                    oldCType = Console.ReadLine();
                    Console.WriteLine("enter new title");
                    newCType = Console.ReadLine();
                    return "UpdateCompanyPage";
                case "3":
                    Console.WriteLine("enter old start year");
                    string Oldyear = Console.ReadLine();
                    if (Validation.IsValidYear(Oldyear)) {
                        oldStartDate = Oldyear;
                    }
                    else
                    {
                        oldStartDate = "";
                        Console.WriteLine("invalid format, please press enter to try again");
                        Console.ReadKey();
                    }
                    Console.WriteLine("enter new start year");
                    string Newyear = Console.ReadLine();
                    if (Validation.IsValidYear(Newyear))
                    {
                        newStartDate = Newyear;
                    }
                    else
                    {
                        newStartDate = "";
                        Console.WriteLine("invalid format, please press enter to try again");
                        Console.ReadKey();
                    }
                    newStartDate = Console.ReadLine();
                    return "UpdateCompanyPage";
                case "4":
                    Console.WriteLine("enter old end year");
                    string OldEndYear = Console.ReadLine();
                    if (Validation.IsValidYear(OldEndYear)) {
                        oldEndDate = OldEndYear;
                    }
                    else {
                        oldEndDate = "";
                        Console.WriteLine("invalid format, please press enter to try again");
                        Console.ReadKey();
                    }
                    Console.WriteLine("enter new end year");
                    //NewEndDate = Console.ReadLine();
                    string newEndYear = Console.ReadLine();
                    if (Validation.IsValidYear(newEndYear)) {
                        NewEndDate = newEndYear;
                    }
                    else
                    {
                        NewEndDate = "";
                        Console.WriteLine("Invalid format, please press enter to try again");
                        Console.ReadKey();
                    }
                    return "UpdateCompanyPage";
                case "5":
                    try
                    {
                        newSql.UpdateCompany(UserIdPage.newUserProfile.userid, oldCname,newCname,oldCType, newCType, oldStartDate, newStartDate, oldEndDate, NewEndDate);
                        Console.WriteLine("saving...");
                        Log.Information($"trainer with id: {UserIdPage.newUserProfile.userid} updated experience detail");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Log.Error($"trainer with id: {UserIdPage.newUserProfile.userid} could not update experience detail");
                    }
                    
                    return "UpdateCompanyPage";
                case "b":
                    return "UserIdPage";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Invalid response, please enter a valid input");
                    Console.WriteLine("Please press \"Enter\" to continue");
                    Console.ReadKey();
                    return "AddCompanyPage";
            }
        }
    }
}
