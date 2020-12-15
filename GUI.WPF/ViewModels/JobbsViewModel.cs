using System.Collections.ObjectModel;
using System.Windows.Input;
using GUI.WPF.Utility;
using Jobb.Models.Implementations;
using Jobb.Models.Implementations.Jobbs;
using Jobb.Utility;

namespace GUI.WPF.ViewModels {
    public class JobbsViewModel : ViewModelBase {
        private ObservableCollection<JobbViewModel> jobbs;
        public ObservableCollection<JobbViewModel> Jobbs { get => jobbs; set { jobbs = value; OnPropertyChanged(); } }

        private readonly DelegateCommand addJobbCommand;
        public ICommand AddJobbCommand => addJobbCommand;

        public JobbsViewModel() {
            Jobbs = new ObservableCollection<JobbViewModel>();

            addJobbCommand = new DelegateCommand(OnAddJobb, CanAddJobb);
        }

        #region commands
        private bool CanAddJobb(object commandParameter) {
            return true;
        }

        private void OnAddJobb(object commandParameter) {
            var job = new EmptyDirectoryJobb(new EmptyDirectoryJobbParameters { Name = "Added Jobb", Schedule = new Schedule(Period.Seconds, 3), TargetDirectory = "pseudoPath" });
            Jobbs.Add(new JobbViewModel(job));
        }
        #endregion
    }
}
