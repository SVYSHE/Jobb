namespace Jobb.UserInterface.CommandLineInterface
{
    public interface IConsoleUi
    {
        // Printing to console
        public string Print();
        public string PrintStartScreen();
        public void PrintVersion();
        public string ListJobs();
        public string PrintHelp();
        
        // Reading from console
        public string Read();
    }
}
