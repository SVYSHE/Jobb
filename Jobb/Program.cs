using Jobb.Models.Implementations;
using Jobb.Models.Implementations.Jobbs;
using Jobb.Utility;

namespace Jobb {
    static class Program {
        static void Main() {
            var parameters = new EmptyDirectoryJobbParameters {
                Name = "Test",
                Schedule = new Schedule(Period.Seconds, 1),
                TargetDirectory = @"C:\Test"
            };
            _ = new EmptyDirectoryJobb(parameters);
            while (true) {
                // test loop
            }
        }
    }
}