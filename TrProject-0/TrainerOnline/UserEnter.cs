using Serilog;
namespace TrainerOnline
{
    internal class UserEnter : IMenu
    {
        public void Display()
        {
            try {
                Log.Information("new user entered");
                }
            catch (IOException e) {
                throw new Exception(e.Message);
            }
        }

        public string UserOption()
        {
            try {
                switch (Console.ReadKey()) {
                    case ConsoleKeyInfo:
                        return "Menu";
                }
            }
            catch (InvalidOperationException e) { 
                throw new Exception(e.Message); 
            }
        }
    }
}
