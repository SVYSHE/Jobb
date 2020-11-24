using Jobb.Models.Implementations;

namespace Jobb {
    static class Program {
        static void Main() {
            var deleteJob = new EmptyDirectoryJobb("empty directory 'test'", @"C:\Test");
            deleteJob.Execute();
        }
    }
}