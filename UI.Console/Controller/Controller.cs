using System;
using System.Collections.Generic;
using System.Reflection;
using Jobb.Exceptions;
using Jobb.Models;
using Jobb.Models.Implementations;
using Jobb.Models.Implementations.Jobbs.CopyFile;
using Jobb.Models.Implementations.Jobbs.EmptyDirectory;
using Jobb.Utility;
using UserInterface.SimpleUserInterface;

namespace UI.Console.Controller {
    public class Controller
    {
        private List<AbstractJobb> JobbList { get; set; }

        private bool _keepRunning = true;

        public Controller(List<AbstractJobb> jobbList)
        {
            JobbList = jobbList;
        }

        public void Run()
        {
            //TODO: LoadJobbs
            PrintStartScreen();
            while (_keepRunning)
            {
                PrintOptions();
            }
            QuitProgram();
        }
        

        private void PrintOptions()
        {
            SimpleUi.PrintWithColor("[1] - Show available Jobbs", ConsoleColor.Cyan);
            SimpleUi.PrintWithColor("[2] - Show currently active Jobbs", ConsoleColor.White);
            SimpleUi.PrintWithColor("[3] - Create new Jobb.", ConsoleColor.Cyan);
            SimpleUi.PrintWithColor("[4] - Remove Jobb", ConsoleColor.White);
            SimpleUi.PrintWithColor("[5] - Quit Program", ConsoleColor.Cyan);
            EvaluateOptionInput(SimpleUi.ReadLine());
        }

        private void EvaluateOptionInput(string optionInput)
        {
            int option = int.Parse(optionInput);
            switch (option)
            {
                case 1:
                    PrintAvailableJobbs();
                    break;
                case 2:
                    PrintCurrentlyActiveJobbs();
                    break;
                case 3:
                    CreateJobb();
                    break;
                case 4:
                    RemoveJobb();
                    break;
                case 5:
                    _keepRunning = false;
                    return;
                default:
                    throw new InvalidOperationException("Please choose a valid option between the numbers 1-5!");
            }
        }

        private void PrintCurrentlyActiveJobbs()
        {
            foreach (var jobb in JobbList)
            {
                SimpleUi.Print($"Name: {jobb.Parameters.Name}");
                SimpleUi.Print($"Time Period: {jobb.Parameters.Schedule.Period.ToString()}");
                SimpleUi.Print($"Interval: {jobb.Parameters.Schedule.Unit.ToString()}");
                SimpleUi.Print($"Current state: {jobb.Parameters.ReturnCode.ToString()}");
            }
        }

        private void RemoveJobb()
        {
            SimpleUi.PrintWithColor("Press the number of the Jobb you wish to remove: ", ConsoleColor.Green);
            for (int i = 0; i < JobbList.Count; i++)
            {
                SimpleUi.Print($"[{i}] {JobbList[i].Parameters.Name}");
            }

            string chosenJobb = SimpleUi.ReadLine();
            int chosenJobbIndex = int.Parse(chosenJobb);
            JobbList[chosenJobbIndex].StopTimer();
            JobbList.RemoveAt(chosenJobbIndex);
            SimpleUi.Print("Job removed.");
        }

        private static void QuitProgram()
        {
            //TODO: Save Jobbs.
            Environment.Exit(0);
        }

        private void PrintStartScreen()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            if (version is not null)
            {
                SimpleUi.Print($"Jobb V{version}");
            }
        }

        private void PrintAvailableJobbs()
        {
            SimpleUi.PrintWithColor("Available Jobbs are (Format: -> <JobbName> - [Parameters]):", ConsoleColor.Green);
            SimpleUi.PrintWithColor("-> EmptyDirectory - [TargetDirectory]", ConsoleColor.Green);
            SimpleUi.PrintWithColor("-> CopyFile - [SourceDirectory, TargetDirectory, FileName]", ConsoleColor.Green);
        }

        private void CreateJobb()
        {
            AbstractJobb newJobb = null;
            SimpleUi.PrintWithColor("Enter the Jobb's name you want to create:", ConsoleColor.Green);
            string jobbName = SimpleUi.ReadLine();
            jobbName = jobbName.ToLower();
            switch (jobbName)
            {
                case "copyfile":
                    newJobb = CreateCopyFileJobb();
                    break;
                case "emptydirectory":
                    newJobb = CreateEmptyDirectoryJobb();
                    break;
                default:
                    throw new InvalidOperationException(
                        "You provided an invalid Jobb name. Please see the available Jobbs for valid Jobb names.");
            }

            SimpleUi.PrintWithColor("Do you wish to execute the Jobb right now?", ConsoleColor.Green);
            if (SimpleUi.ParseYesNo(SimpleUi.ReadLine()))
            {
                newJobb?.Execute();
            }

            JobbList.Add(newJobb);
        }

        private EmptyDirectoryJobb CreateEmptyDirectoryJobb()
        {
            (string name, Period period, int unit) = ParseAbstractParameters();
            SimpleUi.PrintWithColor("Enter the directory you wish to empty:", ConsoleColor.Green);
            string targetDirectoryAsString = SimpleUi.ReadLine();
            var parameters = new EmptyDirectoryJobbParameters
            {
                Name = name, Schedule = new Schedule(period, unit), TargetDirectory = targetDirectoryAsString
            };
            return new EmptyDirectoryJobb(parameters);
        }

        private CopyFileJobb CreateCopyFileJobb()
        {
            (string name, Period period, int unit) = ParseAbstractParameters();
            SimpleUi.PrintWithColor("Enter the source directory:", ConsoleColor.Green);
            string sourceDirectoryAsString = SimpleUi.ReadLine();
            SimpleUi.PrintWithColor("Enter the target directory:", ConsoleColor.Green);
            string targetDirectoryAsString = SimpleUi.ReadLine();
            SimpleUi.PrintWithColor("Enter the new file name:", ConsoleColor.Green);
            string newFileName = SimpleUi.ReadLine();

            var parameters = new CopyFileJobbParameters
            {
                Name = name,
                Schedule = new Schedule(period, unit),
                SourceDirectory = sourceDirectoryAsString,
                TargetDirectory = targetDirectoryAsString,
                FileName = newFileName
            };
            return new CopyFileJobb(parameters);
        }

        private Tuple<string, Period, int> ParseAbstractParameters()
        {
            SimpleUi.PrintWithColor("Enter a name for your Jobb: ", ConsoleColor.Green);
            string name = SimpleUi.ReadLine();
            SimpleUi.PrintWithColor("Enter a period the job should run in: (Seconds, Minutes, Hours, ..", ConsoleColor.Green);
            string periodAsString = SimpleUi.ReadLine();
            Period period = GetPeriodFromString(periodAsString);
            SimpleUi.PrintWithColor("Enter a value how often this jobb should be triggered:", ConsoleColor.Green);
            int unit = int.Parse(SimpleUi.ReadLine());
            return new Tuple<string, Period, int>(name, period, unit);
        }

        //TODO: Extract into Utility
        private static Period GetPeriodFromString(string periodAsString)
        {
            periodAsString = periodAsString.ToLower();
            return periodAsString switch
            {
                "seconds" => Period.Seconds,
                "minutes" => Period.Minutes,
                "hours" => Period.Hours,
                "days" => Period.Days,
                "weeks" => Period.Weeks,
                "months" => Period.Months,
                "years" => Period.Years,
                _ => throw new InvalidJobbParametersException(
                    "Enter a valid period! Valid periods are: Seconds, Minutes, Hours, Days, Weeks, Months, Years.")
            };
        }
    }
}