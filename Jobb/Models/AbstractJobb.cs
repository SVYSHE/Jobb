using System.Timers;
using Jobb.Models.Implementations;
using Jobb.Utility;

namespace Jobb.Models
{
    public abstract class AbstractJobb
    {
        public string Name { get; set; }
        public JobbReturnCode ReturnCode { get; set; }
        protected Schedule Schedule { get; set; }

        protected Timer Timer;

        protected AbstractJobb(string name, Schedule schedule)
        {
            Name = name;
            Schedule = schedule;
            ReturnCode = JobbReturnCode.Waiting;
        }

        public abstract JobbReturnCode Execute();

        public virtual void SetTimer() {
            Timer = new Timer {
                Interval = MillisecondsCalculator.GetMilliseconds(Schedule),
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