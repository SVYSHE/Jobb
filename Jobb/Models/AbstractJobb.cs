using System.Timers;
using Jobb.Exceptions;
using Jobb.Utility;

namespace Jobb.Models {
    public abstract class AbstractJobb
    {
        public AbstractJobbParameters Parameters { get; set; }

        protected Timer Timer;

        protected AbstractJobb(AbstractJobbParameters parameters)
        {
            if (parameters is null)
            {
                throw new InvalidJobbParametersException("Parameters are null! Instantiate them first.");
            }
            if (!AreParametersValid(parameters))
            {
                throw new InvalidJobbParametersException("JobbParameters cannot be null or empty!");
            }
            Parameters = parameters;
            parameters.ReturnCode = JobbReturnCode.Waiting;
        }

        /// <summary>
        /// Special constructor, used to extract property names and
        /// file name of the extending jobb.
        /// </summary>
        protected AbstractJobb()
        {
            Parameters = new AbstractJobbParameters();
        }

        public abstract JobbReturnCode Execute();

        public virtual void SetTimer() {
            Timer = new Timer {
                Interval = MillisecondsCalculator.GetMilliseconds(Parameters.Schedule),
                AutoReset = true
            };
            Timer.Elapsed += Timer_Elapsed;
            Timer.Enabled = true;
            Timer.Start();
        }

        public void StopTimer()
        {
            Timer.Enabled = false;
        }

        protected virtual void Timer_Elapsed(object source, ElapsedEventArgs e)
        {
            Execute();
        }

        protected static bool AreParametersValid(object obj) {
            foreach (var pi in obj.GetType().GetProperties()) {
                var value = pi.GetValue(obj);
                // extend tested values as needed
                if (value is null) {
                    return false;
                }
                if (value is string && string.IsNullOrWhiteSpace(value as string)) {
                    return false;
                }
            }
            return true;
        }
    }
}