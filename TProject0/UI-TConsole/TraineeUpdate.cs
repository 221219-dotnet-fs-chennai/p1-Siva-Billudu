using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TData;
/*
namespace UI_TConsole
{
    internal class TraineeUpdate : IMenu
    {
        private static string con = "Server=tcp:associateserver.database.windows.net,1433;Initial Catalog=AssociatesDb;Persist Security Info=False;User ID=associate;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        ISqlRepo newSql = new SqlRepos(con);

        public void Display()
        {
            Console.Clear();
          Console.WriteLine("\nUpdate option\n");
          Console.WriteLine("[0] Back");
            Console.WriteLine("[1] );
            Console.WriteLine("[2] );
            Console.WriteLine("[3] );
            Console.WriteLine("[4]  );
            Console.WriteLine("[5] );
            Console.WriteLine("[6] );
            Console.WriteLine("[7] );
            Console.WriteLine("[8]);
            Console.WriteLine("[9]);
            Console.WriteLine("[10] );

        }

        public string UserOption()
        {
          case "0":
                    return "Menu";
                case "1":
                    System.Console.Write("Enter your Password to update: ");
                    string pattern1 = @"^.* (?=.{ 8,})(?=.\d)(?=.[a - z])(?=.[A - Z])(?=.[!@#$%^&+=]).$";

                    string Password = System.Console.ReadLine();

                    if (Regex.IsMatch(Password, pattern1))
                    {
                        TraineeLogin.Password = Password;
                    }
                    else
                    {
                        System.Console.WriteLine("Wrong pattern try again...");
                        System.Console.ReadLine();
                    }
                    repo.UpdateTrainer("Trainer_Detailes", "Password", details.Password, details.user_id);
                    return "TrainerUpdate";
                case "2":
                    System.Console.Write("Enter your Fullname to update: ");
                    details.Full_name = System.Console.ReadLine();
                    repo.UpdateTrainer("Trainer_Detailes", "Full_name", details.Full_name, details.user_id);
                    return "TrainerUpdate";
                case "3":
                    try
                    {
                        System.Console.Write("Enter your Age to update: ");
                        details.Age = Convert.ToInt32(System.Console.ReadLine());
                        repo.UpdateTrainer("Trainer_Detailes", "Age", Convert.ToString(details.Age), details.user_id);
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Age should be in numbers!!");
                        System.Console.WriteLine(ex.Message);
                        System.Console.ReadLine();
                    }
                    return "TrainerUpdate";
                case "4":
                    System.Console.Write("Enter your Gender: ");
                    details.Gender = System.Console.ReadLine();
                    repo.UpdateTrainer("Trainer_Detailes", "Gender", details.Gender, details.user_id);
                    return "TrainerUpdate";

                case "5":
                    System.Console.Write("Enter your Mobile number to update: ");
                    string pattern = @"\(?\d{3}\)?(-|.|\s)?\d{3}(-|.)?\d{4}";

                    string phone_number = System.Console.ReadLine();

                    if (Regex.IsMatch(phone_number, pattern))
                    {
                        details.Mobile_number = phone_number;
                    }
                    else
                    {
                        System.Console.WriteLine("Wrong pattern try again...");
                        System.Console.ReadLine();
                    }
                    repo.UpdateTrainer("Trainer_Detailes", "Mobile_number", details.Mobile_number, details.user_id);
                    return "TrainerUpdate";

            
        }
    }
} */


