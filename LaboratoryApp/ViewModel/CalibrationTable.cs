using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp.ViewModel
{
    public class CalibrationTable : ObservableObject
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

        private string typeOfWindow;
        public string TypeOfWindow
        {
            get { return typeOfWindow; }
            set 
            {
                typeOfWindow = value;
                OnPropertyChanged("TypeOfWindow");
            }
        }
        
    }
}
