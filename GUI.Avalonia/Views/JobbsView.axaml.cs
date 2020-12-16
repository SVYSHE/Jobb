using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace GUI.Avalonia.Views {
    public class JobbsView : UserControl {
        public JobbsView() {
            this.InitializeComponent();
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
