namespace Jobb.Models.Implementations.Jobbs {
    public class EmptyDirectoryJobbParameters : AbstractJobbParameters{
        private string targetDirectory;

        public string TargetDirectory { get => targetDirectory; set { targetDirectory = value; OnPropertyChanged(); } }
    }
}
