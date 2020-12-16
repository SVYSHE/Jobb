using Jobb.Models;

namespace GUI.WPF.ViewModels {
    public class JobbViewModel : ViewModelBase {
        public AbstractJobbParameters Parameters { get => Jobb.Parameters; set { Jobb.Parameters = value; OnPropertyChanged(); } }

        public AbstractJobb Jobb { get; }
        public string TypeName { get; }
        public string Interval { get; }
        public string FilePath { get; }

        public JobbViewModel(AbstractJobb jobb) {
            Jobb = jobb;
            TypeName = jobb.GetType().Name;
            Interval = $"Executing every {jobb.Parameters.Schedule.Unit} {jobb.Parameters.Schedule.Period}";
        }
    }
}
