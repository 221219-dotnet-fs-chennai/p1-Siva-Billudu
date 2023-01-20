using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TData;

namespace UI_TConsole
{
    internal class TLogin : IMenu
    {

        private static TData.TraineeLogin newUser = new TData.TraineeLogin();
        private static string tl = File.ReadAllText("C:/Users/srkri/source/repos/TProject0/UI-TConsole/TextFile/log.txt.txt");
        ISqlRepo newSql = new SqlRepos(tl);

        public void Display()
        {

            Console.WriteLine("enter TraineeLogin:Id,Email,Password");
            Console.WriteLine("[1] Id:" +newUser.Id);
            Console.WriteLine("[2] Email:"+ newUser.Email);
            Console.WriteLine("[3] password:"+ newUser.password);
            Console.WriteLine("[4] BACK");
            Console.WriteLine("[10] SAVE");
            


        }

         string IMenu.UserOption()
        {
            string lInput = Console.ReadLine();
            switch (lInput)
            {
                case "1":
                    Console.WriteLine("Enter Id:");
                    newUser.Id = Convert.ToInt32(Console.ReadLine());
                    return "TLogin";

                case "2":
                    Console.WriteLine("Enter Trainee Email:");
                    newUser.Email = Console.ReadLine();
                    return "TLogin";
                case "3":
                    Console.WriteLine("Enter Trainee password:");
                    newUser.password = Console.ReadLine();
                    return "TLogin";

                case "4":
                    return "BACK";
                case "7":
                    return "Exit";
                case "10":
                    try
                    {
                        // Console.WriteLine("enter");
                        newSql.AddLogin(newUser);

                        return "TLogin";
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine("There is exception");
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();

                    }
                    return "TLogin";



                default:
                    Console.WriteLine("Enter valid input:");
                    Console.WriteLine("To Continue,please press enter:");
                    Console.ReadLine();
                    return "TLogin";
            }


        }
        }
}
