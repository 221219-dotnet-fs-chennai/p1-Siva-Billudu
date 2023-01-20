using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TData;

namespace UI_TConsole
{
    internal class TDetails : IMenu
    {
        private static TData.TraineeDetails  newUser=new TData.TraineeDetails();
        private static string ts = File.ReadAllText("C:/Users/srkri/source/repos/TProject0/UI-TConsole/TextFile/log.txt.txt");
        ISqlRepo newSql = new SqlRepos(ts);



        public void Display()
        {
            Console.WriteLine("enter TraineeDetails:TrainneId,FirstName,LastName,Age,Gender");
            Console.WriteLine("[1] TraineeId:" +newUser.TraineeId);
            Console.WriteLine("[2] FirstName:"+ newUser.FirstName);
            Console.WriteLine("[3] LastName:"+newUser.LastName);
            Console.WriteLine("[4] Age:" +newUser.Age);
            Console.WriteLine("[5] Gender:"+ newUser.Gender);
            Console.WriteLine("[6] BACK");
            Console.WriteLine("[10] SAVE");
           
        }

         string IMenu.UserOption()
        {
            string tInput=Console.ReadLine();
            switch(tInput)
            {
                case "1":
                    Console.WriteLine("Enter TraineeId:");
                    newUser.TraineeId=Convert.ToInt32(Console.ReadLine());
                    return "TDetails";

                case "2":
                    Console.WriteLine("Enter Trainee FirstName:");
                    newUser.FirstName=Console.ReadLine();
                    return "TDetails";
                case "3":
                    Console.WriteLine("Enter Trainee LastName:");
                    newUser.LastName=Console.ReadLine();
                    return "TDetails";
                case "4":
                    Console.WriteLine("Enter Trainee Age:");
                    newUser.Age=Convert.ToInt32(Console.ReadLine());
                    return "TDetails";
                case "5":
                    Console.WriteLine("Enter Trainee Gender:");
                    newUser.Gender=Console.ReadLine();
                    return "TDetails";

                case "6":
                    return "Back";
                case "7":
                    return "Exit";
                case "10":
                    try
                    {
                        // Console.WriteLine("enter");
                        newSql.AddDetails(newUser);

                        return "TDetails";
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine("There is exception");
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();

                    }
                    return "TDetails";


                default:
                    Console.WriteLine("Enter valid input:");
                    Console.WriteLine("To Continue,please press enter:");
                    Console.ReadLine();
                    return "TDetails";
            }
            
        }
    }
}
