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
            this.Items = new ObservableCollection<client>();
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
        private List<client> clients;

        public List<client> Clients
        {
            get { return clients; }
            set 
            { 
                clients = value;
                OnPropertyChanged("Clients");
            }
        }

        private ObservableCollection<client> items;
        public ObservableCollection<client> Items
        {
            get
            { return items; }
            set
            {
                items = value;
                OnPropertyChanged("Items");
            }
        }
    }
}
