using Serilog;
using TrainerOnline;
using DataLayer;




Console.Title = "Trainer Project";
string newpath = "../../../Database/logs.txt";
if(!File.Exists(newpath)) File.Create(newpath);
Log.Logger = new LoggerConfiguration()
    .WriteTo.File(newpath, rollingInterval: RollingInterval.Day, rollOnFileSizeLimit:true)
    .CreateLogger();


bool repeat = true;
IMenu newMenu = new UserEnter();
while (repeat) {
    Console.Clear();
    



    newMenu.Display();
    string option = newMenu.UserOption();
    switch (option) {
        case "userEnter":
            Log.Information("Display userEnter to Trainer");
            newMenu = new UserEnter();
            break;
        case "Menu":
            Log.Information("Display Menu the Trainer");
            newMenu = new Menu();
            break;
        case "SignUpPage":
            Log.Information("Display signup to the Trainer");
            newMenu = new SignUpPage();
            break;
        case "LoginPage":
            Log.Information("Display login page to the Trainer");
            newMenu = new LoginPage();
            break;
        case "UserIdPage":
            Log.Information("Display user id page to the Trainer");
            newMenu = new UserIdPage();
            break;
        case "TrainerEdit":
            Log.Information("Display TrainerEdit");
            newMenu = new TrainerEdit();
            break;
        case "AddSkillPage":
            Log.Information("Display add skills page to the Trainer");
            newMenu = new AddSkillPage();
            break;
        case "UpdateSkillPage":
            Log.Information("Display update skills page to the Trainer");
            newMenu = new UpdateSkillPage();
            break;
        case "AddContactPage":
            Log.Information("Display add Contact page to the Trainer");
            newMenu = new AddContactPage();
            break;
        case "UpdateContactPage":
            Log.Information("Display update Contact page to the Trainer");
            newMenu = new UpdateContact();
            break;
        case "AddEducationPage":
            Log.Information("Display add education details page to the Trainer");
            newMenu = new AddEducationPage();
            break;
        case "UpdateEducationPage":
            Log.Information("Display update education details page to the Trainer");
            newMenu = new UpdateEduationPage();
            break;
        case "AddCompanyPage":
            Log.Information("Display add company details page to the Trainer");
            newMenu = new AddCompanyPage();
            break;
        case "UpdateCompanyPage":
            Log.Information("Display update company details page to the Trainer");
            newMenu = new UpdateCompanyPage();
            break;
        case "DeleteSkillsPage":
            Log.Information("Display delete skill page to the Trainer");
            newMenu = new DeleteSkillsPage();
            break;
        case "DeleteCompanyPage":
            Log.Information("Display delete skill page to the Trainer");
            newMenu = new DeleteCompanyPage();
            break;
        case "DeleteEducationPage":
            Log.Information("Display delete skill page to the Trainer");
            newMenu = new DeleteEducationPage();
            break;
        case "ViewTrainerForm":
            Log.Information("Display view Trainer Form ");
            newMenu = new ViewTrainerForm();
            break;
        case "Exit":
            Log.Information("Trainer exit  done");
            Log.CloseAndFlush();
            repeat = false;
            break;
        default:
            Console.WriteLine("Page does'nt exist");
            Console.WriteLine("Please press enter to continue");
            Console.ReadKey();
            break;
    }
}


