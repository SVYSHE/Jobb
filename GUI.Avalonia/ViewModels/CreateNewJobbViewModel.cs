using System.Collections.ObjectModel;
using System.Windows.Input;
using GUI.Avalonia.Utility;
using GUI.Avalonia.Views;

namespace GUI.Avalonia.ViewModels {
    public class CreateNewJobbViewModel : ViewModelBase {
        private ObservableCollection<string> parameterNames;
        public ObservableCollection<string> ParameterNames { get => parameterNames; set { parameterNames = value; OnPropertyChanged(); } }

        private ObservableCollection<object> parameterValues;
        public ObservableCollection<object> ParameterValues { get => parameterValues; set { parameterValues = value; OnPropertyChanged(); } }

        // public JobbType jobbType;
        // public JobbType JobbType { get => jobbType; set { jobbType = value; OnPropertyChanged(); } }

        private readonly DelegateCommand createJobbCommand;
        public ICommand CreateJobbCommand => createJobbCommand;

        private readonly ObservableCollection<JobbViewModel> jobbViewModels;

        public CreateNewJobbViewModel(ObservableCollection<JobbViewModel> jobbViewModels) {
            createJobbCommand = new DelegateCommand(OnCreateJobb, CanCreateJobb);

            this.jobbViewModels = jobbViewModels;

            ParameterValues = new ObservableCollection<object>();
            ParameterNames = new ObservableCollection<string>();

            var createNewJobbView = new CreateNewJobbView {
                DataContext = this
            };
            createNewJobbView.Show();
        }

        #region commands
        private bool CanCreateJobb(object commandParameter) {
            return true;
        }

        private void OnCreateJobb(object commandParameter) {
            /*
            var newJobb = JobbFactory.CreateNewJobb(JobType);
            jobbViewModels.Add(newJobb);
            */
        }
        #endregion
    }
}
