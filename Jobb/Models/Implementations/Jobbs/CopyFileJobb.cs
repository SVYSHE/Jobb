using System;
using System.IO;
using System.Timers;
using Jobb.Utility;

namespace Jobb.Models.Implementations.Jobbs
{
    public class CopyFileJobb : AbstractJobb
    {
        

        public sealed override string Name { get; set; }
        public string SourceDirectory { get; set; }
        public string TargetDirectory { get; set; }
        public string FileName { get; set; }
        public sealed override JobbReturnCode ReturnCode { get; set; }
        
        public CopyFileJobb(string name, Schedule schedule, string sourceDirectory, string targetDirectory, string fileName)
        {
            ReturnCode = JobbReturnCode.Waiting;
            Name = name;
            SourceDirectory = sourceDirectory;
            TargetDirectory = targetDirectory;
            FileName = fileName;
            Schedule = schedule;
            SetTimer();
        }

        public sealed override void SetTimer()
        {
            Timer = new Timer();
            Timer.Interval = MillisecondsCalculator.GetMilliseconds(Schedule);
            Timer.AutoReset = true;
            Timer.Elapsed += Timer_Elapsed;
            Timer.Enabled = true;
            Timer.Start();
        }

        public override JobbReturnCode Execute()
        {
            try
            {
                File.Copy(Path.Combine(SourceDirectory, FileName), Path.Combine(TargetDirectory, FileName));
                ReturnCode = JobbReturnCode.Success;
                return ReturnCode;
            }
            catch (IOException ioEx)
            {
                Console.WriteLine(ioEx);
                ReturnCode = JobbReturnCode.Error;
                return ReturnCode;
            }
        }
    }
}