using System.Timers;
using Jobb.Models.Implementations;
using Jobb.Utility;

namespace Jobb.Models
{
    public abstract class AbstractJobb
    {
        public abstract string Name { get; set; }

        public abstract JobbReturnCode ReturnCode { get; set; }

        public abstract JobbReturnCode Execute();

        protected System.Timers.Timer _timer;
        
        public Schedule Schedule { get; set; }

        protected AbstractJobb(Timer timer)
        {
            this._timer = timer;
        }
    }
}