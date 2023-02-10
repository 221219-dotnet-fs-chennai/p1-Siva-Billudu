using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Modules;
using EF = TEntityApi;

namespace UI_TConsole
{
    public class SignUpPage : IMenu
    {


        static string constr = File.ReadAllText("../../../Database/cs.txt");
        private static readonly TrDetails trdetails = new TrDetails();
        ILogic repo = new Logic();
        public void Display()
        {
            try
            {
                Console.WriteLine("-------------------------Sign Up-------------------------");
                Console.WriteLine("Please enter the details");
                Console.WriteLine("\t -Press [1] \tto enter your email-"+trdetails.Email);
                Console.WriteLine("\t -Press [2] \tto enter your password" + " " +trdetails.Password);
                Console.WriteLine("\t -Press [4] \tto enter your user id" + " " +trdetails.TrId );
                Console.WriteLine("\t -Press [3] \tto to save");
                Console.WriteLine("\t -Press [b] \tto go back to the main page");
            }
            catch (IOException e)
            {
                throw new IOException(e.Message);
            }
        }


        public string UserOption()
        {
            string userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    Console.WriteLine("please enter email");
                    trdetails.Email = Console.ReadLine();
                    return "SignUpPage";
                case "2":
                    Console.WriteLine("please enter password");
                    trdetails.Password = Console.ReadLine();
                    return "SignUpPage";
                case "4":
                    Console.WriteLine("enter id");
                    int TrId = Convert.ToInt32(Console.ReadLine());
                    string Trid = TrId.ToString();


                    trdetails.TrId = TrId;
                    return "SignUpPage";
                 case "3":
                    repo.AddTrDetails(trdetails);
                    Console.WriteLine("saved");
                        return "save";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine(" please enter a valid input");
                    Console.WriteLine("Please press \"Enter\" to continue");
                    Console.ReadKey();
                    return "SignUpPage";

            }

        }

    }
}



