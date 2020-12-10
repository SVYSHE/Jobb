using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            
            var win = new Window()
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill(),
            };
            
            top.Add(win);
            IList dict = new List<string>();
            dict.Add("Hello");
            dict.Add("Goodbye");
            var jobbListFrame = new FrameView("Jobb Types") {Height = Dim.Percent(90), Width = Dim.Percent(30), X = 1, Y = 3};
            var jobbList = new ListView(dict) {Height = Dim.Fill(), Width = Dim.Fill()};
            jobbList.SelectedItemChanged += jobbList_OnSelectedChanged;
            jobbListFrame.Add(jobbList);
            win.Add(jobbListFrame);
            var jobbPropertiesFrame = new FrameView("Jobb Properties"){X = Pos.Center(), Y = 3, Height = Dim.Percent(90), Width = Dim.Fill() - 1 };
            var jobbProperties = new View(){Width = Dim.Fill(), Height = Dim.Fill()};
            jobbPropertiesFrame.Add(jobbProperties);
            //win.Add(jobbPropertiesFrame);
            
            var customScheme = new ColorScheme
            {
                Focus = Attribute.Make(Color.BrightYellow, Color.Cyan),
                HotFocus = Attribute.Make(Color.Black, Color.Cyan),
                HotNormal = Attribute.Make(Color.Gray, Color.Red),
                Normal = Attribute.Make(Color.Green, Color.Black)
            };
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