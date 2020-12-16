using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace GUI.Avalonia.Views {
    public class CreateNewJobbView : Window {
        public CreateNewJobbView() {
            InitializeComponent();
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
