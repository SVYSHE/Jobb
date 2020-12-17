namespace GUI.Avalonia.ViewModels {
    public class MainWindowViewModel : ViewModelBase {
        public JobbsViewModel JobbsViewModel { get; }

        public MainWindowViewModel() {
            JobbsViewModel = new JobbsViewModel();
        }
    }
}
