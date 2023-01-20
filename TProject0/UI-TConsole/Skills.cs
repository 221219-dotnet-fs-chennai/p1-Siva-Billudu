using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TData;

namespace UI_TConsole
{
    public class Skills : IMenu
    {

        private static TData.TraineeSkills newUser = new TData.TraineeSkills();
        private static string tss = File.ReadAllText("C:/Users/srkri/source/repos/TProject0/UI-TConsole/TextFile/log.txt.txt");
        ISqlRepo newSql = new SqlRepos(tss);

        public void Display()
        {

            Console.WriteLine("enter TraineeSkills:SkillId,SkillName,Experience,TSkillsId");
            Console.WriteLine("[1]SkillId :" +newUser.SkillId);
            Console.WriteLine("[2]SkillName :"+ newUser.SkillName);
            Console.WriteLine("[3]Experience :"+ newUser.Experience);
            Console.WriteLine("[4] TSkillsId"+newUser.TSkillsId);
            Console.WriteLine("[5] BACK");
            Console.WriteLine("[10] SAVE");


        }

        string IMenu.UserOption()
        {
            string tsInput = Console.ReadLine();
            switch (tsInput)
            {
                case "1":
                    Console.WriteLine("Enter SkillId:");
                    newUser.SkillId = Convert.ToInt32(Console.ReadLine());
                    return "Skills";

                case "2":
                    Console.WriteLine("Enter Trainee SkillName:");
                    newUser.SkillName = Console.ReadLine();
                    return "Skills";
                case "3":
                    Console.WriteLine("Enter Trainee Experience:");
                    newUser.Experience = Console.ReadLine();
                    return "Skills";
                case "4":
                    Console.WriteLine("Enter Trainee TSkillsId:");
                    newUser.TSkillsId = Convert.ToInt32(Console.ReadLine());
                    return "Skills";
               

                case "5":
                    return "BACK";
                case "6":
                    return "Exit";
                case "10":

                    try
                    {
                        // Console.WriteLine("enter");
                        newSql.AddSkills(newUser);

                        return "Skills";
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine("There is exception");
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();

                    }
                    return "Skills";




                default:
                    Console.WriteLine("Enter valid input:");
                    Console.WriteLine("To Continue,please press enter:");
                    Console.ReadLine();
                    return "Skills";

            }
        }
    }
}
