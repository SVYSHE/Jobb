using System.Timers;
using Jobb.Utility;

namespace Jobb.Models {
    public abstract class AbstractJobb
    {
        private readonly AbstractJobbParameters parameters;

        protected Timer Timer;

        protected AbstractJobb(AbstractJobbParameters parameters)
        {
            if (parameters is null)
                throw new System.ArgumentNullException(nameof(parameters));
            this.parameters = parameters;
            parameters.ReturnCode = JobbReturnCode.Waiting;
        }

        public abstract JobbReturnCode Execute();

        public virtual void SetTimer() {
            Timer = new Timer {
                Interval = MillisecondsCalculator.GetMilliseconds(parameters.Schedule),
                AutoReset = true
            };
            Timer.Elapsed += Timer_Elapsed;
            Timer.Enabled = true;
            Timer.Start();
        }

        protected virtual void Timer_Elapsed(object source, ElapsedEventArgs e)
        {
            Execute();
        }
        
    }
}