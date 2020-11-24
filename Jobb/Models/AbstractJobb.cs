using System.Timers;
using Jobb.Models.Implementations;
using Jobb.Utility;

namespace Jobb.Models
{
    public abstract class AbstractJobb
    {
        public abstract string Name { get; set; }

        public abstract JobbReturnCode ReturnCode { get; set; }

        public abstract void SetTimer();

        public abstract JobbReturnCode Execute();

        protected Timer Timer;

        protected Schedule Schedule { get; set; }

        protected AbstractJobb()
        {
            
        }

        protected virtual void Timer_Elapsed(object source, ElapsedEventArgs e)
        {
            Execute();
        }
        
    }
}