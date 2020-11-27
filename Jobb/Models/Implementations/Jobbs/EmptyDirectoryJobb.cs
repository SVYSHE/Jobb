using System;
using System.IO;
using Jobb.Utility;

namespace Jobb.Models.Implementations.Jobbs {
    public class EmptyDirectoryJobb : AbstractJobb
    {
        public string TargetDirectory { get; set; }

        public EmptyDirectoryJobb(string name, Schedule schedule,string targetDirectory) : base(name, schedule)
        {
            TargetDirectory = targetDirectory;
            SetTimer();
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