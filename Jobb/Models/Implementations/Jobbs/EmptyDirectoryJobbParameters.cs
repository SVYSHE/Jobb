namespace Jobb.Models.Implementations.Jobbs
{
    public class EmptyDirectoryJobbParameters : AbstractJobbParameters
    {
        private string _targetDirectory;

        public string TargetDirectory
        {
            get => _targetDirectory;
            set
            {
                _targetDirectory = value;
                OnPropertyChanged();
            }
        }
    }
}