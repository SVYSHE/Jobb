using System;
using System.Collections.Generic;
using System.Reflection;
using Jobb.Exceptions;
using Jobb.Models;
using Jobb.Models.Implementations;
using Jobb.Models.Implementations.Jobbs;
using Jobb.UserInterface.SimpleUserInterface;
using Jobb.Utility;
using static Jobb.Utility.ConsoleUtility;

namespace Jobb.Controller
{
    public class Controller
    {
        private SimpleUi Ui { get; set; }
        private List<AbstractJobb> JobbList { get; set; }

        private bool _keepRunning = true;

        public Controller(List<AbstractJobb> jobbList)
        {
            JobbList = jobbList;
            Ui = new SimpleUi();
        }

        public void Run()
        {
            DeleteHeaderBarOfConsole();
            //TODO: LoadJobbs
            PrintStartScreen();
            while (_keepRunning)
            {
                PrintOptions();
            }

            //MinimizeProgram();
            QuitProgram();
        }

        private void MinimizeProgram()
        {
            //TODO
            
        }

        private void DeleteHeaderBarOfConsole()
        {
            //TODO: Remove because it will fail under any other OS than windows.
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, MY_BFCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MINIMIZE, MY_BFCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MAXIMIZE, MY_BFCOMMAND);
        }

        private void PrintOptions()
        {
            Ui.PrintWithColor("[1] - Show available Jobbs", ConsoleColor.Cyan);
            Ui.PrintWithColor("[2] - Show currently active Jobbs", ConsoleColor.White);
            Ui.PrintWithColor("[3] - Create new Jobb.", ConsoleColor.Cyan);
            Ui.PrintWithColor("[4] - Remove Jobb", ConsoleColor.White);
            Ui.PrintWithColor("[5] - Quit Program", ConsoleColor.Cyan);
            EvaluateOptionInput(Ui.ReadLine());
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
                Ui.Print($"Name: {jobb.Parameters.Name}");
                Ui.Print($"Time Period: {jobb.Parameters.Schedule.Period.ToString()}");
                Ui.Print($"Interval: {jobb.Parameters.Schedule.Unit.ToString()}");
                Ui.Print($"Current state: {jobb.Parameters.ReturnCode.ToString()}");
            }
        }

        private void RemoveJobb()
        {
            Ui.PrintWithColor("Press the number of the Jobb you wish to remove: ", ConsoleColor.Green);
            for (int i = 0; i < JobbList.Count; i++)
            {
                Ui.Print($"[{i}] {JobbList[i].Parameters.Name}");
            }

            string chosenJobb = Ui.ReadLine();
            int chosenJobbIndex = int.Parse(chosenJobb);
            JobbList[chosenJobbIndex].StopTimer();
            JobbList.RemoveAt(chosenJobbIndex);
            Ui.Print("Job removed.");
        }

        private void QuitProgram()
        {
            //TODO: Save Jobbs.
            Environment.Exit(0);
        }

        private void PrintStartScreen()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            if (version is not null)
            {
                Ui.Print($"Jobb V{version}");
            }
        }

        private void PrintAvailableJobbs()
        {
            Ui.PrintWithColor("Available Jobbs are (Format: -> <JobbName> - [Parameters]):", ConsoleColor.Green);
            Ui.PrintWithColor("-> EmptyDirectory - [TargetDirectory]", ConsoleColor.Green);
            Ui.PrintWithColor("-> CopyFile - [SourceDirectory, TargetDirectory, FileName]", ConsoleColor.Green);
        }

        private void CreateJobb()
        {
            AbstractJobb newJobb = null;
            Ui.PrintWithColor("Enter the Jobb's name you want to create:", ConsoleColor.Green);
            string jobbName = Ui.ReadLine();
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

            Ui.PrintWithColor("Do you wish to execute the Jobb right now?", ConsoleColor.Green);
            if (Ui.ParseYesNo(Ui.ReadLine()))
            {
                newJobb?.Execute();
            }

            JobbList.Add(newJobb);
        }

        private EmptyDirectoryJobb CreateEmptyDirectoryJobb()
        {
            (string name, Period period, int unit) = ParseAbstractParameters();
            Ui.PrintWithColor("Enter the directory you wish to empty:", ConsoleColor.Green);
            string targetDirectoryAsString = Ui.ReadLine();
            var parameters = new EmptyDirectoryJobbParameters
            {
                Name = name, Schedule = new Schedule(period, unit), TargetDirectory = targetDirectoryAsString
            };
            return new EmptyDirectoryJobb(parameters);
        }

        private CopyFileJobb CreateCopyFileJobb()
        {
            (string name, Period period, int unit) = ParseAbstractParameters();
            Ui.PrintWithColor("Enter the source directory:", ConsoleColor.Green);
            string sourceDirectoryAsString = Ui.ReadLine();
            Ui.PrintWithColor("Enter the target directory:", ConsoleColor.Green);
            string targetDirectoryAsString = Ui.ReadLine();
            Ui.PrintWithColor("Enter the new file name:", ConsoleColor.Green);
            string newFileName = Ui.ReadLine();

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
            Ui.PrintWithColor("Enter a name for your Jobb: ", ConsoleColor.Green);
            string name = Ui.ReadLine();
            Ui.PrintWithColor("Enter a period the job should run in: (Seconds, Minutes, Hours, ..", ConsoleColor.Green);
            string periodAsString = Ui.ReadLine();
            Period period = GetPeriodFromString(periodAsString);
            Ui.PrintWithColor("Enter a value how often this jobb should be triggered:", ConsoleColor.Green);
            int unit = int.Parse(Ui.ReadLine());
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