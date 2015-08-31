using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaboratoryApp.ViewModel
{
    public class CalibratorMultimetr :ObservableObject
    {
        private string name;

        public string Name
        {
            get { return name; }
            set 
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        private bool isChecked;

        public bool IsChecked
        {
            get { return isChecked; }
            set 
            { 
                isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }
    }
}
