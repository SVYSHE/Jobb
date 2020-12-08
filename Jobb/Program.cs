using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;
using Terminal.Gui;

namespace Jobb
{
    static class Program
    {
        static void Main()
        {
            Application.Init();
            var top = Application.Top;
            
            var win = new Window("MyApp")
            {
                X = 0,
                Y = 1,

                Width = Dim.Fill(),
                Height = Dim.Fill(),
            };
            
            IList dict = new List<string>();
            dict.Add("Hello");
            dict.Add("Goodbye");
            
            win.Add(new ListView(dict));
            top.Add(win);

            Application.Run();
        }
    }
}