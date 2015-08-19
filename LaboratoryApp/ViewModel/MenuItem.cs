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
            this.Items = new ObservableCollection<MenuItem>();
        }

        private string nameOfItem;
        protected string NameOfItem
        {
            get { return nameOfItem; }
            set 
            {
                nameOfItem = value;
                OnPropertyChanged("NameOfItem");
            }
        }

        public ObservableCollection<MenuItem> Items
        { get; set; }
    }
}
