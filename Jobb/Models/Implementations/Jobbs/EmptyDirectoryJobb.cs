using System;
using System.IO;
using System.Timers;
using Jobb.Utility;

namespace Jobb.Models.Implementations.Jobbs {
    public class EmptyDirectoryJobb : AbstractJobb
    {
        public sealed override string Name { get; set; }
        
        public sealed override JobbReturnCode ReturnCode { get; set; }

        public string TargetDirectory { get; set; }

        public EmptyDirectoryJobb(string name, Schedule schedule,string targetDirectory)
        {
            Name = name;
            TargetDirectory = targetDirectory;
            ReturnCode = JobbReturnCode.Waiting;
            Schedule = schedule;
            SetTimer();
        }


        public sealed override void SetTimer()
        {
            Timer = new Timer {
                Interval = MillisecondsCalculator.GetMilliseconds(Schedule),
                AutoReset = true
            };
            Timer.Elapsed += Timer_Elapsed;
            Timer.Enabled = true;
            Timer.Start();
        }

        public override JobbReturnCode Execute()
        {
            try
            {
                string[] filesInDirectory = Directory.GetFiles(TargetDirectory);
                foreach (string file in filesInDirectory)
                {
                    File.Delete(file);
                }

                ReturnCode = JobbReturnCode.Success;
                return ReturnCode;
            }
            catch (IOException ioEx)
            {
                Console.WriteLine(ioEx.Message);
                ReturnCode = JobbReturnCode.Error;
                return ReturnCode;
            }
        }
    }
}