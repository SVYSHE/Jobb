using System.Windows.Controls;
using GUI.WPF.ViewModels;

namespace GUI.WPF.Views {
    /// <summary>
    /// Interaktionslogik für JobbsView.xaml
    /// </summary>
    public partial class JobbsView : UserControl {
        readonly JobbsViewModel jobbsViewModel;

        public JobbsView() {
            InitializeComponent();
            jobbsViewModel = new JobbsViewModel();
            DataContext = jobbsViewModel;
        }
    }
}
