using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GUI.Avalonia.Utility;
using GUI.Avalonia.Views;
using Jobb.Utility;

namespace GUI.Avalonia.ViewModels {
    public class CreateNewJobbViewModel : ViewModelBase {
        private ObservableCollection<Parameter> parameters;
        public ObservableCollection<Parameter> Parameters { get => parameters; set { parameters = value; OnPropertyChanged(); } }

        private JobbType jobbType;
        public JobbType JobbType { get => jobbType; set { if (value != 0) { jobbType = value; OnPropertyChanged(); CreateParameterValues(); } } }

        private readonly DelegateCommand createJobbCommand;
        public ICommand CreateJobbCommand => createJobbCommand;

        private readonly ObservableCollection<JobbViewModel> jobbViewModels;

        public CreateNewJobbViewModel(ObservableCollection<JobbViewModel> jobbViewModels) {
            createJobbCommand = new DelegateCommand(OnCreateJobb, CanCreateJobb);

            this.jobbViewModels = jobbViewModels;

            Parameters = new ObservableCollection<Parameter>();

            var createNewJobbView = new CreateNewJobbView {
                DataContext = this
            };
            createNewJobbView.Show();
        }

        private void CreateParameterValues() {
            Parameters.Clear();
            var jobbParameters = JobbFactory.GetJobbParameter(JobbType);
            foreach (var parameter in jobbParameters) {
                Parameters.Add(new Parameter { Name = parameter, Value = "" });
            }
        }

        #region commands
        private bool CanCreateJobb(object commandParameter) {
            return true;
        }

        private void OnCreateJobb(object commandParameter) {
            var valueList = new List<string>();
            foreach (var parameterValue in Parameters) {
                valueList.Add(parameterValue.Value);
            }
            var newJobb = JobbFactory.GetJobb(JobbType, valueList);
            jobbViewModels.Add(new JobbViewModel(newJobb));
        }
        #endregion
    }

    public class Parameter {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
