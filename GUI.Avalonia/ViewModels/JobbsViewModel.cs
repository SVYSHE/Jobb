using System.Collections.ObjectModel;
using System.Windows.Input;
using GUI.Avalonia.Utility;

namespace GUI.Avalonia.ViewModels {
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
            var model = new CreateNewJobbViewModel() { JobbViewModels = Jobbs };
            model.CreateView();
        }
        #endregion
    }
}
