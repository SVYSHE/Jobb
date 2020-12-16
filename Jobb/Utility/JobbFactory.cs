using System;
using System.Collections.Generic;
using System.Data;
using Jobb.Models;
using Jobb.Models.Implementations.Jobbs;
using static Jobb.Utility.ScheduleUtility;

namespace Jobb.Utility
{
    public static class JobbFactory
    {
        public static AbstractJobb GetJobb(JobbType jobbType, List<string> parameterValues)
        {
            AbstractJobb jobbToReturn = jobbType switch
            {
                JobbType.CopyFile => CreateCopyFileJobb(parameterValues),
                JobbType.EmptyDirectory => CreateEmptyDirectoryJobb(parameterValues),
                _ => throw new InvalidOperationException()
            };
            return jobbToReturn;
        }

        public static List<string> GetJobbParameter(JobbType jobbType)
        {
            var jobbParameter = new List<string>();
            jobbParameter = AddAbstractParameter(jobbParameter);

            return jobbType switch
            {
                JobbType.CopyFile => AddCopyFileParameter(jobbParameter),
                JobbType.EmptyDirectory => AddEmptyDirectoryParameter(jobbParameter),
                _ => throw new InvalidExpressionException($"Invalid jobb type was passed. <{jobbType}>")
            };
        }

        private static List<string> AddAbstractParameter(List<string> jobbParameter)
        {
            jobbParameter.Add("Name");
            jobbParameter.Add("Period");
            jobbParameter.Add("Unit");
            return jobbParameter;
        }

        private static List<string> AddEmptyDirectoryParameter(List<string> jobbParameter)
        {
            jobbParameter.AddRange(new List<string>() {"Target Directory"});
            return jobbParameter;
        }

        private static List<string> AddCopyFileParameter(List<string> jobbParameter)
        {
            jobbParameter.AddRange(new List<string>() {"Source Directory", "Target Directory", "File Name"});
            return jobbParameter;
        }

        private static EmptyDirectoryJobb CreateEmptyDirectoryJobb(List<string> parameterValues)
        {
            var parameters = new EmptyDirectoryJobbParameters();
            parameters = (EmptyDirectoryJobbParameters) SetAbstractParameters(parameterValues, parameters);
            parameters.TargetDirectory = parameterValues[3];
            return new EmptyDirectoryJobb(parameters);
        }

        private static CopyFileJobb CreateCopyFileJobb(List<string> parameterValues)
        {
            var parameters = new CopyFileJobbParameters();
            parameters = (CopyFileJobbParameters) SetAbstractParameters(parameterValues, parameters);
            parameters.SourceDirectory = parameterValues[3];
            parameters.TargetDirectory = parameterValues[4];
            parameters.FileName = parameterValues[5];
            return new CopyFileJobb(parameters);
        }

        private static AbstractJobbParameters SetAbstractParameters(List<string> parameterValues,
            AbstractJobbParameters parameters)
        {
            parameters.Name = parameterValues[0];
            parameters.Schedule =
                GetScheduleFromString(parameterValues[1], parameterValues[2]);
            return parameters;
        }
    }
}
