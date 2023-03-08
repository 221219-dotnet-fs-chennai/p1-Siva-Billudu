using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TrainerOnline
{
    internal class ViewTrainerForm : IMenu
    {
        static string constr = File.ReadAllText("../../../Database/cs.txt");
        private static readonly sql newSql = new(constr);
        public void Display()
        {
            Console.WriteLine(@$"  
    press [1] - to view complete your profile 
    press [b] - to go back
    press [0] - to exit");
        }

        public string UserOption()
        {
            List<TrDetails> newUserList = newSql.GetUserPersonalDetails(UserIdPage.newUserProfile.userid);
            List<TrSkills> newSkillList = newSql.GetAllSkillsAsync(UserIdPage.newUserProfile.userid);
            List<TEducation> newEducationList = newSql.GetEducation(UserIdPage.newUserProfile.userid);
            List<TCompany> newCompanyList = newSql.GetCompany(UserIdPage.newUserProfile.userid);
            string userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    string newUserDetails = "";
                    foreach (var item in newUserList)
                    {
                        newUserDetails += item.ToString();
                    }
                    string newUserSkills = "";
                    foreach (var item in newSkillList) {
                        newUserSkills += item.ToString();
                    }
                    string newUserEducation = "";
                    foreach (var item in newEducationList)
                    {
                        newUserEducation += item.ToString();
                    }
                    string newUserCompany = "";
                    foreach (var item in newCompanyList)
                    {
                        newUserCompany += item.ToString();
                    }
                    Console.WriteLine("-------------------------Personal Details-------------------------\n");
                    Console.WriteLine($"\t{newUserDetails}");
                    Console.WriteLine("-------------------------Skill Details----------------------------\n");
                    Console.WriteLine($"\t{newUserSkills}");
                    Console.WriteLine("-------------------------Education Details------------------------\n");
                    Console.WriteLine($"\t{newUserEducation}");
                    Console.WriteLine("-------------------------Experience Details-----------------------\n");
                    Console.WriteLine($"\t{newUserCompany}");
                   
                    Console.ReadKey();  
                    return "ViewTrainerForm";
                case "b":
                    return "UserIdPage";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Invalid response, please press enter to try again");
                    Console.ReadKey();
                    return "ViewTrainerForm";
            }   
        }
    }
}
