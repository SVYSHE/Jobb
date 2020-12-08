using System;

namespace Jobb.Models.Implementations.Jobbs {
    public class CopyFileJobbParameters : AbstractJobbParameters, IDisposable
    {
        public string SourceDirectory { get; set; }
        public string TargetDirectory { get; set; }
        public string FileName { get; set; }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
