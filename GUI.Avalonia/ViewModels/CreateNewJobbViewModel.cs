using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GUI.Avalonia.Utility;
using Jobb.Utility;

namespace GUI.Avalonia.ViewModels {
    public class CreateNewJobbViewModel : ViewModelBase {
        private ObservableCollection<Parameter> parameters;
        public ObservableCollection<Parameter> Parameters { get => parameters; set { parameters = value; OnPropertyChanged(); } }

        private JobbType selectedJobbType;
        public JobbType SelectedJobbType { get => selectedJobbType; set { if (value != 0) { selectedJobbType = value; OnPropertyChanged(); CreateParameterValues(); } } }

        private string errorMessage;
        public string ErrorMessage { get => errorMessage; set { errorMessage = value; OnPropertyChanged(); } }

        private readonly DelegateCommand createJobbCommand;
        public ICommand CreateJobbCommand => createJobbCommand;

        private readonly DelegateCommand cancelCreationCommand;
        public ICommand CancelCreationCommand => cancelCreationCommand;

        public ObservableCollection<JobbViewModel> JobbViewModels { get; set; }

        public CreateNewJobbViewModel() {
            createJobbCommand = new DelegateCommand(OnCreateJobb, CanCreateJobb);
            cancelCreationCommand = new DelegateCommand(OnCancelCreation, CanCancelCreation);

            Parameters = new ObservableCollection<Parameter>();
        }

        private void CreateParameterValues() {
            Parameters.Clear();
            var jobbParameters = JobbFactory.GetJobbParameter(SelectedJobbType);
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
            try {
                var newJobb = JobbFactory.GetJobb(SelectedJobbType, valueList.ToArray());
                JobbViewModels.Add(new JobbViewModel(newJobb));
                ErrorMessage = "Errors:";
            } catch (System.Exception ex) {
                ErrorMessage = ex.Message;
            }
        }

        private bool CanCancelCreation(object commandParameter) {
            return true;
        }

        private void OnCancelCreation(object commandParameter) {
            ErrorMessage = "Errors: aaaaaaaaaaaaaaaaaaaaaaa";
        }
        #endregion
    }

    public class Parameter {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
