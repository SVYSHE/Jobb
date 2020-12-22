using System.Collections.Generic;
using Jobb.Utility;

namespace Jobb.Models.Implementations.Jobbs.EmptyDirectory {
    public class EmptyDirectoryJobbFactory : JobbFactory {
        static EmptyDirectoryJobbFactory() {
            FactoriesDictionary.Add(JobbType.EmptyDirectory, new EmptyDirectoryJobbFactory());
        }

        protected override AbstractJobb CreateJobb(params object[] parameterValues) {
            var parameters = new EmptyDirectoryJobbParameters();
            parameters = (EmptyDirectoryJobbParameters)SetAbstractParameters(parameters, parameterValues);
            parameters.TargetDirectory = parameterValues[3].ToString();
            return new EmptyDirectoryJobb(parameters);
        }

        public override List<string> AddParameters(List<string> jobbParameter) {
            jobbParameter.AddRange(new List<string>() { "Target Directory" });
            return jobbParameter;
        }
    }
}
