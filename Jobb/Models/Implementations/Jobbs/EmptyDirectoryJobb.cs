using System;
using System.IO;
using System.Timers;
using Jobb.Utility;

namespace Jobb.Models.Implementations.Jobbs
{
    public class EmptyDirectoryJobb : AbstractJobb
    {
        public sealed override string Name { get; set; }
        
        public sealed override JobbReturnCode ReturnCode { get; set; }

        public string TargetDirectory { get; set; }

        public EmptyDirectoryJobb(string name, Schedule schedule, string targetDirectory) : base(new Timer())
        {
            Name = name;
            TargetDirectory = targetDirectory;
            ReturnCode = JobbReturnCode.Waiting;
            Schedule = schedule;
            _timer.Interval = MillisecondsCalculator.GetMilliseconds(Schedule);
            _timer.Enabled = true;
        }

        public override JobbReturnCode Execute()
        {
            try
            {
                string[] filesInDirectory = Directory.GetFiles(TargetDirectory);
                foreach (var file in filesInDirectory)
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