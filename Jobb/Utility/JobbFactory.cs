using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Jobb.Models;
using static Jobb.Utility.ScheduleUtility;

namespace Jobb.Utility {
    public class JobbFactory {
        public static Dictionary<JobbType, JobbFactory> FactoriesDictionary { get; set; }

        static JobbFactory() {
            FactoriesDictionary= new Dictionary<JobbType, JobbFactory>();
            RegisterFactories();
        }

        private static void RegisterFactories() {
            var derrivedTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(JobbFactory)
                .IsAssignableFrom(t) && t != typeof(JobbFactory));

            foreach (var type in derrivedTypes) {
                System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(type.TypeHandle);
            }
        }

        private static JobbFactory GetFactory(JobbType jobbType) {
            FactoriesDictionary.TryGetValue(jobbType, out var factory);
            return factory;
        }

        public static AbstractJobb GetJobb(JobbType jobbType, params object[] parameterValues) {
            var jobbToReturn = GetFactory(jobbType).CreateJobb(parameterValues);
            return jobbToReturn;
        }

        public static List<string> GetJobbParameter(JobbType jobbType) {
            var jobbParameter = new List<string>();
            jobbParameter = AddAbstractParameter(jobbParameter);
            return GetFactory(jobbType).AddParameters(jobbParameter);
        }

        private static List<string> AddAbstractParameter(List<string> jobbParameter) {
            jobbParameter.Add("Name");
            jobbParameter.Add("Period");
            jobbParameter.Add("Unit");
            return jobbParameter;
        }

        public virtual List<string> AddParameters(List<string> jobbParameter) {
            throw new NotImplementedException();
        }

        protected static AbstractJobbParameters SetAbstractParameters(AbstractJobbParameters parameters, params object[] parameterValues) {
            parameters.Name = parameterValues[0].ToString();
            parameters.Schedule =
                GetScheduleFromString(parameterValues[1].ToString(), parameterValues[2].ToString());
            return parameters;
        }

        protected virtual AbstractJobb CreateJobb(params object[] parameterValues) {
            throw new NotImplementedException();
        }
    }
}
