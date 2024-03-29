﻿using DataLayer;
using Serilog;

namespace TrainerOnline
{
    internal class AddCompanyPage : IMenu
    {
        static string constr = File.ReadAllText("../../../Database/cs.txt");
        readonly sql newSql = new(constr);
        internal static TCompany newCompany = new();
        public void Display()
        {
            Console.WriteLine($@"-------------------------Add Experience Details-------------------------
    press [1] - add company name - {newCompany.Cname}
    press [2] - to enter C type-{newCompany.CType}
    press [3] - to enter start year  - {newCompany.startdate} 
    press [4] - to enter end year  - {newCompany.enddate}
    press [5] - to save the changes
    press [b] - to go back
    press [0] - exit
    ");
        }

        public string UserOption()
        {
            string userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    Console.WriteLine("Enter company name");
                    newCompany.Cname = Console.ReadLine();
                    return "AddCompanyPage";
                case "2":
                    Console.WriteLine("Enter the CType");
                    newCompany.CType=Console.ReadLine();
                    return "AddCompanyPage";
                case "3":
                    Console.WriteLine("Enter the start year");
                    string StartDate = Console.ReadLine();
                    if (Validation.IsValidYear(StartDate))
                    {
                        newCompany.startdate = StartDate;
                    }
                    else {
                        newCompany.startdate = "";
                        Console.WriteLine("Invalid format, press enter to try again");
                        Console.ReadKey();
                    }
                    return "AddCompanyPage";
                case "4":
                    Console.WriteLine("Enter the end year");
                    string EndDate = Console.ReadLine();
                    if (Validation.IsValidYear(EndDate))
                    {
                        newCompany.enddate = EndDate;
                    }
                    else
                    {
                        newCompany.enddate = "";
                        Console.WriteLine("Invalid format, press enter to try again");
                        Console.ReadKey();
                    }
                    return "AddCompanyPage";
                case "5":
                    try {
                        newSql.AddCompany(UserIdPage.newUserProfile.userid, newCompany);
                        Console.WriteLine("saving...");
                        Log.Information($"trainer with id: {UserIdPage.newUserProfile.userid}, added a new experience detail");
                    }
                    catch(Exception ex) { 
                        Console.WriteLine(ex.Message);
                        Log.Error($"trainer with id: {UserIdPage.newUserProfile.userid} could not add new education detail");
                    }
                    return "AddCompanyPage";
                case "b":
                    return "UserIdPage";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine(" please enter a valid input");
                    Console.WriteLine("Please press \"Enter\" to continue");
                    Console.ReadKey();
                    return "AddCompanyPage";
            }
        }
    }
}
