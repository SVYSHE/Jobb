using System;

namespace Jobb.Models.Implementations.Jobbs {
    public class EmptyDirectoryJobbParameters : AbstractJobbParameters, IDisposable
    {
        public string TargetDirectory { get; set; }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
