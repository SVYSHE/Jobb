using System;
using Jobb.Utility;
using System.IO;

namespace Jobb.Models.Implementations
{
    public class EmptyDirectoryJobb : AbstractJobb
    {
        public override string Name { get; set; }
        
        public override JobbReturnCode ReturnCode { get;}

        public string TargetDirectory { get; set; }

        public EmptyDirectoryJobb(string name, string targetDirectory)
        {
            Name = name;
            TargetDirectory = targetDirectory;
            ReturnCode = JobbReturnCode.Waiting;
        }

        public override JobbReturnCode Execute()
        {
            try
            {
                string[] filesInDirectory = System.IO.Directory.GetFiles(TargetDirectory);
                foreach (var file in filesInDirectory)
                {
                    System.IO.File.Delete(file);
                }
                return JobbReturnCode.Success;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return JobbReturnCode.Error;
            }
        }
    }
}