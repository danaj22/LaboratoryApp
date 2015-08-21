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

        protected string nameOfItem;
        public string NameOfItem
        {
            get { return nameOfItem; }
            set 
            {
                nameOfItem = value;
                OnPropertyChanged("NameOfItem");
            }
        }

        private ObservableCollection<MenuItem> children;
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
    }
}
