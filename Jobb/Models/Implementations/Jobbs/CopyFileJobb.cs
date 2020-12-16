using System;
using System.IO;
using Jobb.Utility;

namespace Jobb.Models.Implementations.Jobbs
{
    public class CopyFileJobb : AbstractJobb
    {
        public new CopyFileJobbParameters Parameters { get; }

        public CopyFileJobb(CopyFileJobbParameters parameters) : base(parameters)
        {
            Parameters = parameters;
            Parameters.JobbType = JobbType.CopyFile;
            SetTimer();
        }

        public override JobbReturnCode Execute()
        {
            try
            {
                File.Copy(Path.Combine(Parameters.SourceDirectory, Parameters.FileName),
                    Path.Combine(Parameters.TargetDirectory, Parameters.FileName));
                Parameters.ReturnCode = JobbReturnCode.Success;
                Parameters.Error = new Exception("");
                return Parameters.ReturnCode;
            }
            catch (IOException ioEx)
            {
                Parameters.Error = ioEx;
                Console.WriteLine(ioEx);
                Parameters.ReturnCode = JobbReturnCode.Error;
                return Parameters.ReturnCode;
            }
        }
    }
}