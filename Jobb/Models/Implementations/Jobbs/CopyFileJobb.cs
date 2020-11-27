using System;
using System.IO;
using Jobb.Utility;

namespace Jobb.Models.Implementations.Jobbs {
    public class CopyFileJobb : AbstractJobb
    {
        public string SourceDirectory { get; set; }
        public string TargetDirectory { get; set; }
        public string FileName { get; set; }
        
        public CopyFileJobb(string name, Schedule schedule, string sourceDirectory, string targetDirectory, string fileName) : base(name, schedule) {
            SourceDirectory = sourceDirectory;
            TargetDirectory = targetDirectory;
            FileName = fileName;
            SetTimer();
        }

        public override JobbReturnCode Execute()
        {
            try
            {
                File.Copy(Path.Combine(SourceDirectory, FileName), Path.Combine(TargetDirectory, FileName));
                ReturnCode = JobbReturnCode.Success;
                return ReturnCode;
            } catch (IOException ioEx) {
                Console.WriteLine(ioEx);
                ReturnCode = JobbReturnCode.Error;
                return ReturnCode;
            }
        }
    }
}