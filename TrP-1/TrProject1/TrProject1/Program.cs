
global using Serilog;
using BusinessLogic;
using Modules;
using TEntityApi;
namespace UI_TConsole
{
    public class program
    {
        public static void Main(string[] args)
        {
            TrDetails Details = new TrDetails();
            Console.Title = "Trainer Project";
            string newpath = "../../../Database/logs.txt";
            if (!File.Exists(newpath)) File.Create(newpath);

            Log.Logger = new LoggerConfiguration()
    .WriteTo.File(newpath, rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
    .CreateLogger();

            bool repeat = true;
            IMenu newMenu = new Menu();
            while (repeat)
            {
                Console.Clear();




                newMenu.Display();
                string option = newMenu.UserOption();
                switch (option)
                {
                   case "SignUpPage":
                        Log.Information("Display signup to the Trainer");
                        newMenu = new SignUpPage();
                        break;

                    case "AddSkill":
                        Log.Information("Display TrDetails ");
                        newMenu = new AddSkillPage();
                        break;
                    default:
                        Console.WriteLine("Page does not exist!");
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                        break;


                }
            }


        }
    }
}
    