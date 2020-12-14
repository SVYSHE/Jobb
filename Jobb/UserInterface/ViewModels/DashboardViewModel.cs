﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using ReactiveUI;

namespace Jobb.UserInterface.ViewModels
{
    [DataContract]
    public class DashboardViewModel : ReactiveObject
    {
        private readonly ObservableAsPropertyHelper<string> _selectedItem;

        public DashboardViewModel()
        {
            // var addisSoos = this.WhenAnyValue(
            //     x => x._selectedItem,
            //     _selectedItem
            // );
        }
        
        [IgnoreDataMember]
        public List<string> JobbList { get; set; }
        
        
    }
}