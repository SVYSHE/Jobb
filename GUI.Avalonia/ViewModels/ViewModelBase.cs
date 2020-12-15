using System.ComponentModel;
using System.Runtime.CompilerServices;
using ReactiveUI;

namespace GUI.Avalonia.ViewModels {
    public class ViewModelBase : ReactiveObject {
        new public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
