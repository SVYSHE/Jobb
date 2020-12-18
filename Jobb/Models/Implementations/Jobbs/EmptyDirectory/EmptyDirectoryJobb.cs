using System;
using System.IO;
using Jobb.Utility;

namespace Jobb.Models.Implementations.Jobbs.EmptyDirectory
{
    public class EmptyDirectoryJobb : AbstractJobb
    {
        public new EmptyDirectoryJobbParameters Parameters { get; }

        public EmptyDirectoryJobb(EmptyDirectoryJobbParameters parameters) : base(parameters)
        {
            Parameters = parameters;
            Parameters.JobbType = JobbType.EmptyDirectory;
            SetTimer();
        }

        public override JobbReturnCode Execute()
        {
            try
            {
                string[] filesInDirectory = Directory.GetFiles(Parameters.TargetDirectory);
                foreach (string file in filesInDirectory)
                {
                    File.Delete(file);
                }

                Parameters.ReturnCode = JobbReturnCode.Success;
                Parameters.Error = new Exception("");
                return Parameters.ReturnCode;
            }
            catch (IOException ioEx)
            {
                Parameters.Error = ioEx;
                Console.WriteLine(ioEx.Message);
                Parameters.ReturnCode = JobbReturnCode.Error;
                return Parameters.ReturnCode;
            }
        }
    }
}