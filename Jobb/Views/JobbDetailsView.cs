using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Jobb.Models.Implementations.Jobbs;
using Terminal.Gui;

namespace Jobb.Views
{
    public class JobbDetailsView : View
    {
        private int CurrentPropertyCount { get; set; }
        
        private List<string> CurrentProperties { get; set; }
        
        public JobbDetailsView(string selectedItem)
        {
            RetrievePropertiesFromSelectedItem(selectedItem);
        }

        private List<string> RetrievePropertiesFromSelectedItem(string selectedItem)
        {
            var properties = new List<string>();
            switch (selectedItem)
            {
                case "CopyFileJobb":
                    
                    using (var copyFileJobbParameters = new CopyFileJobbParameters())
                    {
                        using (var copyFileJobb = new CopyFileJobb(copyFileJobbParameters))
                        {
                            PropertyInfo[] propertyInfo = copyFileJobb.GetType().GetProperties();
                            properties.AddRange(propertyInfo.Select(info => info.ToString()?.Split(" ")[1]));
                        }
                    }

                    return properties;
                    
            }

            return properties;
        }
    }
}