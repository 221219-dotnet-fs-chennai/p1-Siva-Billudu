using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TData;
using TProjects0;

namespace UI_TConsole
{
    internal class SignUp:IMenu
    {
        private static TData.TSignUp newUser= new TData.TSignUp();
        static string con = "Server=tcp:associateserver.database.windows.net,1433;Initial Catalog=AssociatesDb;Persist Security Info=False;User ID=associate;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;\r\n";
        ISqlRepo newSql = new SqlRepos(con);
       

        public void Display()
        {
            Console.WriteLine("....");
            Console.WriteLine("Click Here TO SignUp");
            Console.WriteLine("...");
            Console.WriteLine("[1] TraineeId:"+newUser.TId);
            Console.WriteLine("[2] FName:"+newUser.FName);
            Console.WriteLine("[3] LName:"+newUser.LName);
            Console.WriteLine("[4] Email:" + newUser.TEmail);
            Console.WriteLine("[5] Password:" + newUser.TPassword);
            Console.WriteLine("[6] BACK:");
            Console.WriteLine("[10] SAVE");

        }

         string IMenu.UserOption()
        {

            string scsInput = Console.ReadLine();
            switch (scsInput)
            {
                case "1":
                    Console.WriteLine("Enter TId:");
                    newUser.TId = Convert.ToInt32(Console.ReadLine());
                    return "SignUp";

                case "2":
                    Console.WriteLine("Enter FName:");
                    newUser.FName = Console.ReadLine();
                    return "SignUp";
                case "3":
                    Console.WriteLine("Enter Trainee Lname:");
                    newUser.LName = Console.ReadLine();
                    return "SignUp";
                case "4":
                    Console.WriteLine("Enter Trainee Email:");
                    newUser.TEmail = Console.ReadLine();
                    return "SignUp";
                case "5":
                    Console.WriteLine("Enter Trainee Password:");
                    newUser.TPassword = Console.ReadLine();
                    return "SignUp";
                case "6":
                    return "BACK";
                case "10":

//                    try
  //                  {
                        //Console.WriteLine("enter");
                        newSql.AddS(newUser);

                       // return "SignUp";
                    //}

                    //catch(Exception ex)
                    //{
                      //  Console.WriteLine("There is exception");
                        //Console.WriteLine(ex.Message);
                       // Console.ReadLine();
                       
                   // }
                return "SignUp";




                default:
                    Console.WriteLine("Take valid input");
                    Console.WriteLine("To Continue please press Enter");
                    Console.ReadLine();
                    return "SignUp";
            }
        }
    }
}

    
