using System.Collections.Generic;
using Jobb.Utility;

namespace Jobb.Models.Implementations.Jobbs.CopyFile {
    public class CopyFileJobbFactory : JobbFactory {
        static CopyFileJobbFactory() {
            FactoriesDictionary.Add(JobbType.CopyFile, new CopyFileJobbFactory());
        }

        protected override CopyFileJobb CreateJobb(params object[] parameterValues) {
            var parameters = new CopyFileJobbParameters();
            parameters = (CopyFileJobbParameters)SetAbstractParameters(parameters, parameterValues);
            parameters.SourceDirectory = parameterValues[3].ToString();
            parameters.TargetDirectory = parameterValues[4].ToString();
            parameters.FileName = parameterValues[5].ToString();
            return new CopyFileJobb(parameters);
        }

        public override List<string> AddParameters(List<string> jobbParameter) {
            jobbParameter.AddRange(new List<string>() { "Source Directory", "Target Directory", "File Name" });
            return jobbParameter;
        }
    }
}
