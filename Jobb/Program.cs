using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Loader;
using System.Threading.Tasks.Dataflow;
using Terminal.Gui;
using Attribute = Terminal.Gui.Attribute;
using Color = Terminal.Gui.Color;

namespace Jobb
{
    static class Program
    {
        static void Main()
        {
            Application.Init();
            var menu = new MenuBar(new MenuBarItem[]
            {
                new MenuBarItem("Dashboard", Array.Empty<MenuItem>())
                {
                    Action = OpenDashboardView,
                }, 
                new MenuBarItem("Create", Array.Empty<MenuItem>())
                {
                    Action = OpenCreateView
                },
                new MenuBarItem("History", Array.Empty<MenuItem>())
                {
                    Action = OpenHistoryView
                },
                new MenuBarItem("Preferences", Array.Empty<MenuItem>())
                {
                    Action = OpenPreferencesView
                },
                new MenuBarItem("Quit", Array.Empty<MenuItem>())
                {
                    Action = Application.RequestStop
                }, 
            });
            
            menu.X = 0;
            menu.Y = 0;
            menu.Width = Dim.Fill();
            menu.Height = 1;
            var top = Application.Top;
            top.Add(menu);
            
            var win = new Window("MyApp")
            {
                X = 1,
                Y = 2,
                Width = Dim.Fill() - 1,
                Height = Dim.Fill() - 1,
            };
            top.Add(win);
            IList dict = new List<string>();
            dict.Add("Hello");
            dict.Add("Goodbye");
            var jobbList = new ListView(dict) {Height = 20, Width = 80};
            jobbList.SelectedItemChanged += jobbList_OnSelectedChanged;

            win.Add(jobbList);
            ColorScheme customScheme = new ColorScheme();
            customScheme.Focus = Attribute.Make(Color.BrightYellow,Color.Cyan);
            customScheme.HotFocus = Attribute.Make(Color.Black, Color.Cyan);
            customScheme.HotNormal = Attribute.Make(Color.Gray, Color.Red);
            customScheme.Normal = Attribute.Make(Color.Green, Color.Black);
            win.ColorScheme = customScheme;
            Application.Run();
        }

        // X1: Methods that will be called from Menu
        private static void OpenPreferencesView()
        {
            throw new NotImplementedException();
        }

        private static void OpenHistoryView()
        {
            throw new NotImplementedException();
        }

        private static void OpenCreateView()
        {
            throw new NotImplementedException();
        }

        private static void OpenDashboardView()
        {
            throw new NotImplementedException();
        }
        // X1: Methods that will be called from Menu
        
        // X2: Handle for Selected Item in JobbListView

        private static void jobbList_OnSelectedChanged(ListViewItemEventArgs e)
        {
            
        }
        
        
        
        static void Test()
        {
        }
    }
}