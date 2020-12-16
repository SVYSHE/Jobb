using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Jobb.Models.Implementations;
using Jobb.Utility;

namespace Jobb.Models
{
    public abstract class AbstractJobbParameters : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        private Schedule _schedule;
        private JobbReturnCode _returnCode;
        private Exception _error = new Exception("");
        public JobbType JobbType { get; set; }
        
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public Schedule Schedule
        {
            get => _schedule;
            set
            {
                _schedule = value;
                OnPropertyChanged();
            }
        }

        public JobbReturnCode ReturnCode
        {
            get => _returnCode;
            set
            {
                _returnCode = value;
                OnPropertyChanged();
            }
        }

        public Exception Error
        {
            get => _error;
            set
            {
                _error = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}