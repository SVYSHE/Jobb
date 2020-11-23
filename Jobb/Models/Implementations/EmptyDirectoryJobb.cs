using System;
using Jobb.Utility;
using System.IO;

namespace Jobb.Models.Implementations
{
    public class EmptyDirectoryJobb : AbstractJobb
    {
        public override string Name { get; set; }
        
        public override JobbReturnCode ReturnCode { get; set; }

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