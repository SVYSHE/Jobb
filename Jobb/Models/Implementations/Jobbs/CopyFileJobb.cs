using System;
using System.IO;
using Jobb.Utility;

namespace Jobb.Models.Implementations.Jobbs {
    public class CopyFileJobb : AbstractJobb
    {
        public readonly CopyFileJobbParameters Parameters;
        
        public CopyFileJobb(CopyFileJobbParameters parameters) : base(parameters) {
            Parameters = parameters;
            SetTimer();
        }

        public override JobbReturnCode Execute()
        {
            try
            {
                File.Copy(Path.Combine(Parameters.SourceDirectory, Parameters.FileName), Path.Combine(Parameters.TargetDirectory, Parameters.FileName));
                Parameters.ReturnCode = JobbReturnCode.Success;
                return Parameters.ReturnCode;
            } catch (IOException ioEx) {
                Console.WriteLine(ioEx);
                Parameters.ReturnCode = JobbReturnCode.Error;
                return Parameters.ReturnCode;
            }
        }
    }
}