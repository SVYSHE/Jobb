namespace Jobb.Models.Implementations.Jobbs {
    public class CopyFileJobbParameters : AbstractJobbParameters {
        private string sourceDirectory;
        private string targetDirectory;
        private string fileName;

        public string SourceDirectory { get => sourceDirectory; set { sourceDirectory = value; OnPropertyChanged(); } }
        public string TargetDirectory { get => targetDirectory; set { targetDirectory = value; OnPropertyChanged(); } }
        public string FileName { get => fileName; set { fileName = value; OnPropertyChanged(); } }
    }
}
