// See https://aka.ms/new-console-template for more information
using System;

using Serilog;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using UI_TConsole;
using System.Data.SqlTypes;
using System.Reflection.Metadata.Ecma335;
using System.Reflection;
using TData;
using System.Diagnostics.Contracts;


class Program
{
    public static void Main(string[] args)
    {
        ISqlRepo sql = new SqlRepos("C:/Users/srkri/source/repos/TProject0/UI-TConsole/TextFile/log.txt.txt");
        sql.GetTraineeDetails();
        sql.GetTraineeDetails();
        sql.GetTraineeContact();
        sql.GetCompany();
        sql.GetTraineeEducation();
        sql.GetTraineeSkills();


        string path = ("C:/Users/srkri/source/repos/TProject0/UI-TConsole/TextFile/log.txt.txt");
        if (!File.Exists(path))
            File.Create(path);
        Log.Logger = new LoggerConfiguration()
             .WriteTo.File(path, rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
             .CreateLogger();
        Log.Logger.Information("..program starts..");
        Log.Logger.Information("...program ends..");
        bool repeat = true;
        IMenu  Menu = new Menu();
        while (repeat)
        {
            Console.Clear();
            Menu.Display();
            string s = Menu.UserOption();
            switch (s)
            {
                case "menu":
                    Log.Information("Menu Display");
                    Menu = new Menu();
                    break;
                case "TDetails":
                    Log.Information("Display TraineeDetails");
                    Menu = new TDetails();
                    break;
                case "TCompany":
                    Log.Information("Display company details");
                    Menu = new TCompany();
                    break;
                case "TEducation":
                    Log.Information("Display Trainee Education");
                    Menu = new TEducation();
                    break;
                case "TContact":
                    Log.Information("Display TraineeContact");
                    Menu = new TContact();
                    break;
                case "Skills":
                    Log.Information("Display TraineeSkills");
                    Menu = new Skills();
                    break;
                case "SignUp":
                    Log.Information("Display SignUp");
                    Menu = new SignUp();
                    break;
                case "TLogin":
                    Log.Information("Display TraineeLogin");
                    Menu = new TLogin();
                    break;

                case "Exit":
                    Log.Information("exit");
                    Log.CloseAndFlush();
                    repeat = false;
                    break;

               case "BACK":
                    Log.Information("back");
                    Menu=new Menu();
                    break;
                default:
                    Console.WriteLine("enter valid data");
                    Console.WriteLine("To Continue,plese press enter");
                    Console.ReadLine();
                    break;


            }


        }
    }
}



