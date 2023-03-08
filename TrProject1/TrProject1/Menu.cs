using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_TConsole
{
    internal class Menu : IMenu
    {
        public void Display()
        {

            try
            {
                Console.WriteLine("Welcome to Trainee");
                Console.WriteLine("Please Signup/Login");
                Console.WriteLine("\t Press [s]-\tto SingUp");
                Console.WriteLine("\t Press [l]-\tto Login");
                Console.WriteLine("\t Press [m]-\tto Menu");
                Console.WriteLine("\t Press [0]-\tExit");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

        }

         string IMenu.UserOption()
        {
            

            
            try
            {
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        return "Exit";
                    case "s":
                        return "SignUpPage";
                    case "l":
                        return "LoginPage";
                    case "m":
                        return "Menu";
                    default:
                        Console.WriteLine("Please input a valid response");
                        Console.WriteLine("Please press \"Enter\" to continue");
                        Console.ReadLine();
                        return "Menu";
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OutOfMemoryException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            return "Menu";
        }
    }

    
}
