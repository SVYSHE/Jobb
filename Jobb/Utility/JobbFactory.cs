using System;
using System.Collections.Generic;
using System.Data;
using Jobb.Models;
using Jobb.Models.Implementations.Jobbs;
using static Jobb.Utility.ScheduleUtility;

namespace Jobb.Utility
{
    public class JobbFactory
    {
        public static AbstractJobb GetJobb(JobbType jobbType, params object[] parameterValues)
        {
            AbstractJobb jobbToReturn = jobbType switch
            {
                JobbType.CopyFile => CreateCopyFileJobb(parameterValues),
                JobbType.EmptyDirectory => CreateEmptyDirectoryJobb(parameterValues),
                _ => throw new InvalidOperationException()
            };
            SetAbstractParameters(parameterValues, jobbToReturn);
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

        private static EmptyDirectoryJobb CreateEmptyDirectoryJobb(IReadOnlyList<object> parameterValues)
        {
            var jobb = new EmptyDirectoryJobb(new EmptyDirectoryJobbParameters());
            jobb.Parameters.TargetDirectory = parameterValues[3].ToString();
            return jobb;
        }

        private static CopyFileJobb CreateCopyFileJobb(IReadOnlyList<object> parameterValues)
        {
            var jobb = new CopyFileJobb(new CopyFileJobbParameters());
            jobb.Parameters.SourceDirectory = parameterValues[3].ToString();
            jobb.Parameters.TargetDirectory = parameterValues[4].ToString();
            jobb.Parameters.FileName = parameterValues[5].ToString();
            return jobb;
        }

        private static void SetAbstractParameters(IReadOnlyList<object> parameterValues, AbstractJobb jobbToReturn)
        {
            jobbToReturn.Parameters.Name = parameterValues[0].ToString();
            jobbToReturn.Parameters.Schedule =
                GetScheduleFromString(parameterValues[1].ToString(), parameterValues[2].ToString());
        }
        
        
    }
}
