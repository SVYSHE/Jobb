using System.Collections.Generic;
using Jobb.Models;
using static Jobb.Controller.Controller;

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