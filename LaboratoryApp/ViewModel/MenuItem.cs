using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp.ViewModel
{
    public class MenuItem : ObservableObject
    {

        public MenuItem()
        {
            this.Children = new ObservableCollection<MenuItem>();
           
        }

        protected virtual MenuItem parent { get; set; }

        public MenuItem Parent
        {
            get { return parent; }
            set 
            { 
                parent = value;
                OnPropertyChanged("Parent");
            }
        }

        protected virtual string nameOfItem { get; set; }
        public string NameOfItem
        {
            get { return nameOfItem; }
            set 
            {
                nameOfItem = value;
                OnPropertyChanged("NameOfItem");
            }
        }

        protected virtual ObservableCollection<MenuItem> children { get; set; }
        public ObservableCollection<MenuItem> Children
        {
            get
            { return children; }
            set
            {
                children = value;
                OnPropertyChanged("Children");
            }
        }
        protected virtual string displayImagePath { get; set; }

        public string DisplayImagePath
        {
            get { return displayImagePath; }
        }

        protected virtual bool isSelected { get; set; }
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (value != isSelected)
                {
                    isSelected = value;
                    this.OnPropertyChanged("IsSelected");
                }
            }
        }

        protected virtual bool isExpanded {get; set;}
        public bool IsExpanded
        {
            get { return true; }
            set
            {
                if (value != isExpanded)
                {
                    isExpanded = value;
                    OnPropertyChanged("IsExpanded");
                }
            }
        }
    }
}
