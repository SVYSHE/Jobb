using System.IO;
using System.Reflection;
using Jobb.Models.Implementations;
using Jobb.Models.Implementations.Jobbs;
using Jobb.Utility;

namespace GUI.Avalonia.ViewModels {
    public class MainWindowViewModel : ViewModelBase {
        private string resourcePath;

        public JobbsViewModel JobbsViewModel { get; }

        public MainWindowViewModel() {
            JobbsViewModel = new JobbsViewModel();

            // create test data path
            CreateTestDataFolder();

            // Test Jobbs
            var job1 = new EmptyDirectoryJobb(new EmptyDirectoryJobbParameters { Name = "Jobb 1", Schedule = new Schedule(Period.Seconds, 3), TargetDirectory = resourcePath });
            var job2 = new EmptyDirectoryJobb(new EmptyDirectoryJobbParameters { Name = "Jobb 2", Schedule = new Schedule(Period.Seconds, 6), TargetDirectory = "PseudoFilePath" });
            var job3 = new EmptyDirectoryJobb(new EmptyDirectoryJobbParameters { Name = "Jobb 3", Schedule = new Schedule(Period.Seconds, 9), TargetDirectory = "PseudoFilePath" });
            var job4 = new CopyFileJobb(new CopyFileJobbParameters { Name = "Jobb 4", Schedule = new Schedule(Period.Seconds, 9), SourceDirectory = "PseudoSource", TargetDirectory = "PseudoTarget", FileName = "GibtEsNicht.txt" });
            var job5 = new CopyFileJobb(new CopyFileJobbParameters { Name = "Jobb 5", Schedule = new Schedule(Period.Seconds, 6), SourceDirectory = "PseudoSource", TargetDirectory = "PseudoTarget", FileName = "GibtEsNicht.txt" });
            var job6 = new CopyFileJobb(new CopyFileJobbParameters { Name = "Jobb 6", Schedule = new Schedule(Period.Seconds, 3), SourceDirectory = "PseudoSource", TargetDirectory = "PseudoTarget", FileName = "GibtEsNicht.txt" });

            JobbsViewModel.Jobbs.Add(new JobbViewModel(job1));
            JobbsViewModel.Jobbs.Add(new JobbViewModel(job2));
            JobbsViewModel.Jobbs.Add(new JobbViewModel(job3));
            JobbsViewModel.Jobbs.Add(new JobbViewModel(job4));
            JobbsViewModel.Jobbs.Add(new JobbViewModel(job5));
            JobbsViewModel.Jobbs.Add(new JobbViewModel(job6));
        }

        private void CreateTestDataFolder() {
            string executionPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            resourcePath = Path.Combine(executionPath, @"resources\testdata");
            if (!Directory.Exists(resourcePath)) {
                Directory.CreateDirectory(resourcePath);
            }
        }
    }
}
