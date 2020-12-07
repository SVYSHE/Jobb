namespace Jobb.Models.Implementations.Jobbs {
    public class CopyFileJobbParameters : AbstractJobbParameters {
        public string SourceDirectory { get; set; }
        public string TargetDirectory { get; set; }
        public string FileName { get; set; }
    }
}
