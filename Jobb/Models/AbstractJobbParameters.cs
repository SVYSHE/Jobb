using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Jobb.Models.Implementations;
using Jobb.Utility;

namespace Jobb.Models {
    public class AbstractJobbParameters {
        public string Name { get; set; }
        public Schedule Schedule { get; set; }
        public JobbReturnCode ReturnCode { get; set; }
        
        public JobbType JobbType { get; set; }
        public class AbstractJobbParameters : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;
        private Schedule schedule;
        private JobbReturnCode returnCode;
        private Exception error = new Exception("");

        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        public Schedule Schedule { get => schedule; set { schedule = value; OnPropertyChanged(); } }
        public JobbReturnCode ReturnCode { get => returnCode; set { returnCode = value; OnPropertyChanged(); } }
        public Exception Error { get => error; set { error = value; OnPropertyChanged(); } }

        protected void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
