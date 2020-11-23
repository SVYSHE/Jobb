using Jobb.Utility;

namespace Jobb.Models
{
    public abstract class AbstractJobb
    {
        public abstract string Name { get; set; }

        public abstract JobbReturnCode ReturnCode { get; }

        public abstract JobbReturnCode Execute();
    }
}