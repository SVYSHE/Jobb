using Jobb.Models.Implementations;
using Jobb.Models.Implementations.Jobbs;
using Jobb.Utility;

namespace Jobb {
    static class Program
    {
        static void Main()
        {
            
            _ = new EmptyDirectoryJobb("Test", new Schedule(Period.Seconds, 1), @"C:\Test");
            while (true)
            {
                // test loop
            }
        }
    }
}