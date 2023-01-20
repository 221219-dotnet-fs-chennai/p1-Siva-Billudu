using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TData;

namespace UI_TConsole
{
    public class TContact : IMenu
    {

        private static TData.TraineeContact newUser = new TData.TraineeContact();
        static string con = "Server=tcp:associateserver.database.windows.net,1433;Initial Catalog=AssociatesDb;Persist Security Info=False;User ID=associate;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;\r\n";
        ISqlRepo newSql = new SqlRepos(con);

        public void Display()
        {

            Console.WriteLine("enter TraineeContact:TContactId,PhoneNo,Email,Address,City,state,PinCode,Website");
            Console.WriteLine("[1] TContactId :" +newUser.TContactId);
            Console.WriteLine("[2] phone :"+ newUser.PhoneNo);
            Console.WriteLine("[3]Email :" +newUser.Email);
            Console.WriteLine("[4]Address :"+ newUser.Address);
            Console.WriteLine("[5] City :" + newUser.City);
            Console.WriteLine("[6] state:" +newUser.state);
            Console.WriteLine("[7] PinCode:"+ newUser.PinCode);
            Console.WriteLine("[8] Website:"+ newUser.website);
            Console.WriteLine("[9] BACK");
            Console.WriteLine("[10] SAVE");



        }

        string IMenu.UserOption()
        {
            string ccInput = Console.ReadLine();
            switch (ccInput)
            {
                case "1":
                    Console.WriteLine("Enter TContactId:");
                    newUser.TContactId = Convert.ToInt32(Console.ReadLine());
                    return "TContact";

                case "2":
                    Console.WriteLine("Enter Trainee phoneNo:");
                    newUser.PhoneNo = Console.ReadLine();
                    return "TContact";
                case "3":
                    Console.WriteLine("Enter Trainee Email:");
                    newUser.Email = Console.ReadLine();
                    return "TContact";
                case "4":
                    Console.WriteLine("Enter Trainee Address:");
                    newUser.Address = Console.ReadLine();
                    return "TContact";
                case "5":
                    Console.WriteLine("Enter Trainee City:");
                    newUser.City = Console.ReadLine();
                    return "TContact";
                case "6":
                    Console.WriteLine("Enter state");
                    newUser.state = Console.ReadLine();
                    return "TContact";
                case "7":
                    Console.WriteLine("enter PinCode");
                    newUser.PinCode = Console.ReadLine();
                    return "TContact";
                case "8":
                    Console.WriteLine("enter website:");
                    newUser.website = Console.ReadLine();
                    return "TContact";

                case "9":
                    return "BACK";
                case "0":
                    return "Exit";
                case "10":
                    try
                    {
                        // Console.WriteLine("enter");
                        newSql.AddContact(newUser);

                        return "TContact";
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine("There is exception");
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();

                    }
                    return "TContact";


                default:
                    Console.WriteLine("Enter valid input:");
                    Console.WriteLine("To Continue,please press enter:");
                    Console.ReadLine();
                    return "TContact";


            }
        }
    }
}
