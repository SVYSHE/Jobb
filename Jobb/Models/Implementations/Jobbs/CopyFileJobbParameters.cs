namespace Jobb.Models.Implementations.Jobbs
{
    public class CopyFileJobbParameters : AbstractJobbParameters
    {
        private string _sourceDirectory;
        private string _targetDirectory;
        private string _fileName;

        public string SourceDirectory
        {
            get => _sourceDirectory;
            set
            {
                _sourceDirectory = value;
                OnPropertyChanged();
            }
        }

        public string TargetDirectory
        {
            get => _targetDirectory;
            set
            {
                _targetDirectory = value;
                OnPropertyChanged();
            }
        }

        public string FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                OnPropertyChanged();
            }
        }
    }
}