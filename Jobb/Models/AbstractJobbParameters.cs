using Jobb.Models.Implementations;
using Jobb.Utility;

namespace Jobb.Models {
    public class AbstractJobbParameters {
        public string Name { get; set; }
        public Schedule Schedule { get; set; }
        public JobbReturnCode ReturnCode { get; set; }
    }
}
