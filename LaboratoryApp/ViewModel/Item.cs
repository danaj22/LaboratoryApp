using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp
{
    class Item:ObservableObject,INotifyPropertyChanged
    {
        private string name;
        private bool isExpanded;
        private bool isSelected;

        public bool IsExpanded
        {
            get { return isExpanded; }
            set 
            {
                isExpanded = value;
                OnPropertyChanged("IsSelected");            
            }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool IsSelected
        {
            get { return isSelected; }
            set 
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }
    }
}
