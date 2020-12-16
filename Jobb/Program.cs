using System.Collections.Generic;
using Jobb.Models;

namespace Jobb
{
    static class Program
    {
        static void Main()
        {
            var controller = new Controller.Controller(new List<AbstractJobb>());
            controller.Run();
        }
    }
}