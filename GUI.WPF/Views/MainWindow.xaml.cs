using System.Windows;
using GUI.WPF.ViewModels;

namespace GUI.WPF.Views {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        readonly MainWindowViewModel mainWindowViewModel;

        public MainWindow() {
            InitializeComponent();
            mainWindowViewModel = new MainWindowViewModel();
            DataContext = mainWindowViewModel;
        }
    }
}
