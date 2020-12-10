using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Transactions;
using Jobb.Models.Implementations.Jobbs;
using Terminal.Gui;

namespace Jobb.UserInterface
{
    public class ConsoleUi
    {
        public Toplevel Top { get; set; }


        private MenuBar CreateMenuBar()
        {
            var dashboard = new MenuBarItem("Dashboard", Array.Empty<MenuItem>());
            var create = new MenuBarItem("Create", Array.Empty<MenuItem>());
            var preferences = new MenuBarItem("History", Array.Empty<MenuItem>());
            var quit = new MenuBarItem("Quit", Array.Empty<MenuItem>());
            var menu = new MenuBar(new MenuBarItem[]
            {
                dashboard,
                create,
                preferences,
                quit
            }) {X = 0, Y = 0, Width = Dim.Fill(), Height = 1};

            return menu;
        }

        private FrameView CreateJobbListView()
        {
            IList dict = new List<string>();
            dict.Add("Empty Directory");
            dict.Add("Copy File");
            var jobbListFrame = new FrameView("Jobb Types")
                {Height = Dim.Percent(90), Width = Dim.Percent(30), X = 1, Y = 3};
            var jobbList = new ListView(dict) {Height = Dim.Fill(), Width = Dim.Fill()};
            jobbList.SelectedItemChanged += jobbList_OnSelectedChanged;
            jobbListFrame.Add(jobbList);

            return jobbListFrame;
        }

        private FrameView CreateJobbPropertiesView(string selectedItem)
        {
            var jobbPropertyTopWindow = new FrameView("Jobbs Properties");

            List<string> properties = selectedItem switch
            {
                "Empty Directory" => RetrievePropertiesFromSelectedItem(selectedItem),
                "Copy File" => RetrievePropertiesFromSelectedItem(selectedItem),
                _ => throw new NotSupportedException("This item is not supported")
            };

            var jobbParameterList = new ListView(properties) {Height = Dim.Fill(), Width = Dim.Fill()};
            jobbPropertyTopWindow.Add(jobbParameterList);

            return jobbPropertyTopWindow;
        }

        private void jobbList_OnSelectedChanged(ListViewItemEventArgs e)
        {
            try
            {
                Top.RemoveAll();
            }
            catch (Exception exception)
            {
                // ignored
            }
        }

        private void OpenPreferencesView()
        {
            throw new NotImplementedException();
        }

        private void OpenHistoryView()
        {
            throw new NotImplementedException();
        }

        private void OpenCreateView()
        {
            throw new NotImplementedException();
        }

        private void OpenDashboardView(string selectedItem)
        {
            if (string.IsNullOrEmpty(selectedItem))
            {
                selectedItem = "Empty Directory";
            }

            Top.RemoveAll();
            Top.Add(CreateMenuBar());
            Top.Add(CreateJobbListView());
            Top.Add(CreateJobbPropertiesView(selectedItem));
        }

        private List<string> RetrievePropertiesFromSelectedItem(string selectedItem)
        {
            var properties = new List<string>();
            switch (selectedItem)
            {
                case "Copy File":
                    using (var copyFileJobbParameters = new CopyFileJobbParameters())
                    {
                        PropertyInfo[] propertyInfo = copyFileJobbParameters.GetType().GetProperties();
                        properties.AddRange(propertyInfo.Select(info => info.ToString()?.Split(" ")[1]));
                    }

                    return properties;
                case "Empty Directory":
                    using (var emptyDirectoryJobbParameters = new EmptyDirectoryJobbParameters())
                    {
                        PropertyInfo[] propertyInfo = emptyDirectoryJobbParameters.GetType().GetProperties();
                        properties.AddRange(propertyInfo.Select(info => info.ToString()?.Split(" ")[1]));
                    }

                    return properties;
                default:
                    MessageBox.ErrorQuery(20, 5, "Error while retrieving properties from selected Jobb",
                        $"An error occured while trying to retrieve the properties from your selected jobb '{selectedItem}'",
                        "Ok");
                    return new List<string>();
            }
        }
    }
}