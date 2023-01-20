using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TData;

namespace UI_TConsole
{
    public class TEducation : IMenu
    {
        private static TData.TraineeEducation newUser = new TData.TraineeEducation();
        private static string te = File.ReadAllText("C:/Users/srkri/source/repos/TProject0/UI-TConsole/TextFile/log.txt.txt");
        ISqlRepo newSql = new SqlRepos(te);


        public void Display()
        {

            Console.WriteLine("enter TraineeEducation:TEducationId,University,Hdegree,YearOfStart,PassoutYear,Percentage");
            Console.WriteLine("[1] TEducationId:" +newUser.TEducationId);
            Console.WriteLine("[2] University:"+ newUser.University);
            Console.WriteLine("[3] Hdegree:" +newUser.HDegree);
            Console.WriteLine("[4] YearOfStart:" + newUser.YearOfStart);
            Console.WriteLine("[5] PassoutYear:" +newUser.PassoutYear);
            Console.WriteLine("[6] Percentage:"+ newUser.Percentage);
            Console.WriteLine("[7] BACK");
            Console.WriteLine("[10] SAVE");



        }

        string IMenu.UserOption()
        {
            string eInput = Console.ReadLine();
            switch (eInput)
            {
                case "1":
                    Console.WriteLine("Enter TEducationId:");
                    newUser.TEducationId = Convert.ToInt32(Console.ReadLine());
                    return "TEducation";

                case "2":
                    Console.WriteLine("Enter Trainee University:");
                    newUser.University = Console.ReadLine();
                    return "TEducation";
                case "3":
                    Console.WriteLine("Enter Trainee HDegree:");
                    newUser.HDegree = Console.ReadLine();
                    return "TEducation";
                case "4":
                    Console.WriteLine("Enter startYear:");
                    newUser.YearOfStart = Console.ReadLine();
                    return "TEducation";
                case "5":
                    Console.WriteLine("Enter Passout Year:");
                    newUser.PassoutYear = Console.ReadLine();
                    return "TEducation";
                case "6":
                    Console.WriteLine("Enter Percentage");
                    newUser.Percentage = Convert.ToInt32(Console.ReadLine());
                    return "TEDucation";

                case "7":
                    return "BACK";
                case "8":
                    return "Exit";
                case "10":
                    try
                    {
                        // Console.WriteLine("enter");
                        newSql.AddEducation(newUser);

                        return "TEducation";
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine("There is exception");
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();

                    }
                    return "TEducation";


                default:
                    Console.WriteLine("Enter valid input:");
                    Console.WriteLine("To Continue,please press enter:");
                    Console.ReadLine();
                    return "TEducation";
            }


        
        }
    }
}
