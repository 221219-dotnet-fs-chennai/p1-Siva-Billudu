using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Modules;
using EF = TEntityApi;

namespace UI_TConsole
{
    public   class AddSkillPage : IMenu
    {
        static string constr = File.ReadAllText("../../../Database/cs.txt");
        
        private static readonly TrSkill newSkill = new TrSkill();


        ILogic repo = new Logic();
        public void Display()
        {
            Console.WriteLine("-------------------------Add skills-------------------------");
            Console.WriteLine($@"    
    press [1] - add new skill [must be atleast 3 characters long] - {newSkill.Skill}
    press [2] - to save changes
    press [b] - to go back
    press [0] - to exit");

        }

        public string UserOption()
        {
            string userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    Console.WriteLine("Enter skill name ");
                    string newSkillName = Console.ReadLine();
                    newSkill.Skill = Console.ReadLine();
                   /* if (Validation.IsValidSkillName(newSkillName))
                    {
                        newSkill.skillName = newSkillName;
                    }
                    else
                    {
                        newSkill.skillName = "";
                        Console.WriteLine("Invalid format, skill should be more than 3 characters long, press enter to try again");
                        Console.ReadKey();
                    }*/
                    return "AddSkillPage";
               /* case "2":
                    try
                    {
                        newSkill.Trskillid = UserIdPage.newUserProfile.userid;
                        newSql.AddSkills(newSkill);
                        Console.WriteLine("saving...");
                        Log.Information($"trainer with id: {UserIdPage.newUserProfile.userid} added new skill detail");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Log.Error($"trainer with id: {UserIdPage.newUserProfile.userid} could not add skill detail");

                    }
                    return "AddSkillPage";
                case "b":
                    return "UserIdPage";*/
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Invalid response, please enter a valid input");
                    Console.WriteLine("Please press \"Enter\" to continue");
                    Console.ReadKey();
                    return "AddSkillPage";
            }
        }
    }
}
    

