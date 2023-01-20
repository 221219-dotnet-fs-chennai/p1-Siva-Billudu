using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TData;

namespace UI_TConsole
{
    internal class TCompany : IMenu
    {
        private static TData.Company newUser = new TData.Company();
        private static string con = "Server=tcp:associateserver.database.windows.net,1433;Initial Catalog=AssociatesDb;Persist Security Info=False;User ID=associate;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        ISqlRepo newSql = new SqlRepos(con);

        public void Display()
        {






            Console.WriteLine("enter TraineeCompany:Cid,Cname,Ctype,TCompanyId");
            Console.WriteLine("[1] Cid:" +newUser.Cid);
            Console.WriteLine("[2] Cname:"+ newUser.Cname);
            Console.WriteLine("[3] Ctype:"+ newUser.Ctype);
            Console.WriteLine("[4] TCompanyId:" +newUser.TCompanyId);
              Console.WriteLine("[5] BACK :" );
            Console.WriteLine("[10] SAVE");





        }
        string IMenu.UserOption()
        {

            string cInput = Console.ReadLine();
            switch (cInput)
            {
                case "1":
                    Console.WriteLine("Enter CId:");
                    newUser.Cid = Convert.ToInt32(Console.ReadLine());
                    return "TCompany";

                case "2":
                    Console.WriteLine("Enter Trainee cname:");
                    newUser.Cname = Console.ReadLine();
                    return "TCompany";
                case "3":
                    Console.WriteLine("Enter Trainee company type:");
                    newUser.Ctype = Console.ReadLine();
                    return "TCompany";
                case "4":
                    Console.WriteLine("Enter TraineeCompanyId:");
                    newUser.TCompanyId = Convert.ToInt32(Console.ReadLine());
                    return "TCompany";
                case "5":
                    
                    
                  return "BACK";
                case "6":
                    return "Menu";
                case "10":

                    try
                    {
                     // Console.WriteLine("enter");
                        newSql.AddCompany(newUser);

                     return "TCompany";
                    }

                    catch(Exception ex)
                    {
                      Console.WriteLine("There is exception");
                    Console.WriteLine(ex.Message);
                     Console.ReadLine();

                     }
                    return "TCompany";

                default:
                    Console.WriteLine("Enter valid input:");
                    Console.WriteLine("To Continue,please press enter:");
                    Console.ReadLine();
                    return "TCompany";
            }

        
        }
    }
}
