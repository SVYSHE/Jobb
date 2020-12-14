using System;
using System.IO;
using Jobb.Utility;

namespace Jobb.Models.Implementations.Jobbs {
    public class EmptyDirectoryJobb : AbstractJobb, IDisposable
    {
        public readonly EmptyDirectoryJobbParameters Parameters;

        public EmptyDirectoryJobb(EmptyDirectoryJobbParameters parameters) : base(parameters) {
            Parameters = parameters;
            Parameters.JobbType = JobbType.EmptyDirectory;
            SetTimer();
        }

        public override JobbReturnCode Execute() {
            try {
                string[] filesInDirectory = Directory.GetFiles(Parameters.TargetDirectory);
                foreach (string file in filesInDirectory) {
                    File.Delete(file);
                }

                Parameters.ReturnCode = JobbReturnCode.Success;
                return Parameters.ReturnCode;
            } catch (IOException ioEx) {
                Console.WriteLine(ioEx.Message);
                Parameters.ReturnCode = JobbReturnCode.Error;
                return Parameters.ReturnCode;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}