using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_TConsole
{
    internal class Menu:IMenu
    {
        public void Display()
        {
            Console.WriteLine("WELCOME TO THE PROJECT HOME");
            Console.WriteLine("Select One Option from user");
            Console.WriteLine("[1] for SignUp");
            Console.WriteLine("[2] for TCompany");
            Console.WriteLine("[3] for TContact");
            Console.WriteLine("[4] for TDetails");
            Console.WriteLine("[5] for TEducation");
            Console.WriteLine("[6] for Skills");
            Console.WriteLine("[7] for TLogin");
            Console.WriteLine("[8] for Menu");
            Console.WriteLine("[9] for Exit");
           

        }

        public string UserOption()
        {
            string TInput = Console.ReadLine();
            switch (TInput)
            {
                case "1":
                    return "SignUp";
                case "2":
                    return "TCompany";
                case "3":
                    return "TContact";
                case "4":
                    return "TDetails";
                case "5":
                    return "TEducation";
                case "6":
                    return "Skills";
                case "7":
                    return "TLogin";
                
                case "8":
                    return "Menu";
                case "9":
                    return "Exit";

                default:
                    Console.WriteLine("Take valid input");
                    Console.WriteLine("To Contine please press enter key");
                    Console.ReadLine();
                    return "Menu";
            }
        }
    }
}

    
