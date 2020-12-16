using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GUI.Avalonia.Utility;
using GUI.Avalonia.Views;
using Jobb.Utility;

namespace GUI.Avalonia.ViewModels {
    public class CreateNewJobbViewModel : ViewModelBase {
        private ObservableCollection<string> parameterNames;
        public ObservableCollection<string> ParameterNames { get => parameterNames; set { parameterNames = value; OnPropertyChanged(); CreateParameterValues(); } }

        private ObservableCollection<ParameterValue> parameterValues;
        public ObservableCollection<ParameterValue> ParameterValues { get => parameterValues; set { parameterValues = value; OnPropertyChanged(); } }

        private JobbType jobbType;
        public JobbType JobbType { get => jobbType; set { jobbType = value; OnPropertyChanged(); ParameterNames = new ObservableCollection<string>(JobbFactory.GetJobbParameter(JobbType)); } }

        private readonly DelegateCommand createJobbCommand;
        public ICommand CreateJobbCommand => createJobbCommand;

        private readonly ObservableCollection<JobbViewModel> jobbViewModels;

        public CreateNewJobbViewModel(ObservableCollection<JobbViewModel> jobbViewModels) {
            createJobbCommand = new DelegateCommand(OnCreateJobb, CanCreateJobb);

            this.jobbViewModels = jobbViewModels;


            ParameterValues = new ObservableCollection<ParameterValue>();
            ParameterNames = new ObservableCollection<string>();

            JobbType = JobbType.EmptyDirectory;

            var createNewJobbView = new CreateNewJobbView {
                DataContext = this
            };
            createNewJobbView.Show();
        }

        private void CreateParameterValues() {
            ParameterValues.Clear();
            foreach (var name in ParameterNames) {
                ParameterValues.Add(new ParameterValue { Value = "" });
            }
        }

        #region commands
        private bool CanCreateJobb(object commandParameter) {
            return true;
        }

        private void OnCreateJobb(object commandParameter) {
            var valueList = new List<string>();
            foreach (var parameterValue in ParameterValues) {
                valueList.Add(parameterValue.Value);
            }
            var newJobb = JobbFactory.GetJobb(JobbType, valueList);
            jobbViewModels.Add(new JobbViewModel(newJobb));
        }
        #endregion
    }

    public class ParameterValue {
        public string Value { get; set; }
    }
}
