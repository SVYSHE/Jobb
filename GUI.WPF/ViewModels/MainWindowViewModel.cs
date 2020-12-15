using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Windows.Input;
using GUI.WPF.Utility;
using Jobb.Models.Implementations;
using Jobb.Models.Implementations.Jobbs;
using Jobb.Utility;

namespace GUI.WPF.ViewModels {
    public class MainWindowViewModel : ViewModelBase {
        private string resourcePath;

        private ObservableCollection<JobbViewModel> jobbs;
        public ObservableCollection<JobbViewModel> Jobbs { get => jobbs; set { jobbs = value; OnPropertyChanged(); } }

        private readonly DelegateCommand addJobbCommand;
        public ICommand AddJobbCommand => addJobbCommand;

        public MainWindowViewModel() {
            addJobbCommand = new DelegateCommand(OnAddJobb, CanAddJobb);

            Jobbs = new ObservableCollection<JobbViewModel>();

            // create test data path
            CreateTestDataFolder();

            // Test Jobbs
            var job1 = new EmptyDirectoryJobb(new EmptyDirectoryJobbParameters { Name = "Jobb 1", Schedule = new Schedule(Period.Seconds, 3), TargetDirectory = resourcePath });
            var job2 = new EmptyDirectoryJobb(new EmptyDirectoryJobbParameters { Name = "Jobb 2", Schedule = new Schedule(Period.Seconds, 6), TargetDirectory = "PseudoFilePath" });
            var job3 = new EmptyDirectoryJobb(new EmptyDirectoryJobbParameters { Name = "Jobb 3", Schedule = new Schedule(Period.Seconds, 9), TargetDirectory = "PseudoFilePath" });
            var job4 = new CopyFileJobb(new CopyFileJobbParameters { Name = "Jobb 4", Schedule = new Schedule(Period.Seconds, 9), SourceDirectory = "PseudoSource", TargetDirectory = "PseudoTarget", FileName = "GibtEsNicht.txt" });
            var job5 = new CopyFileJobb(new CopyFileJobbParameters { Name = "Jobb 5", Schedule = new Schedule(Period.Seconds, 6), SourceDirectory = "PseudoSource", TargetDirectory = "PseudoTarget", FileName = "GibtEsNicht.txt" });
            var job6 = new CopyFileJobb(new CopyFileJobbParameters { Name = "Jobb 6", Schedule = new Schedule(Period.Seconds, 3), SourceDirectory = "PseudoSource", TargetDirectory = "PseudoTarget", FileName = "GibtEsNicht.txt" });

            Jobbs.Add(new JobbViewModel(job1));
            Jobbs.Add(new JobbViewModel(job2));
            Jobbs.Add(new JobbViewModel(job3));
            Jobbs.Add(new JobbViewModel(job4));
            Jobbs.Add(new JobbViewModel(job5));
            Jobbs.Add(new JobbViewModel(job6));
        }

        private void CreateTestDataFolder() {
            string executionPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            resourcePath = Path.Combine(executionPath, @"resources\testdata");
            if (!Directory.Exists(resourcePath)) {
                Directory.CreateDirectory(resourcePath);
            }
        }

        #region commands
        private bool CanAddJobb(object commandParameter) {
            return true;
        }

        private void OnAddJobb(object commandParameter) {
            var job = new EmptyDirectoryJobb(new EmptyDirectoryJobbParameters { Name = "Added Jobb", Schedule = new Schedule(Period.Seconds, 3), TargetDirectory = resourcePath });
            Jobbs.Add(new JobbViewModel(job));
        }
        #endregion
    }
}
