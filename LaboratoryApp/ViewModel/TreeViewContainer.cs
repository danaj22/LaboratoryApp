using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp.ViewModel
{
    class TreeViewContainer : ObservableObject
    {
        private string title;

        public string Title
        {
            get { return title; }
            set 
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        ObservableCollection<client> Items
        { get; set; }
    }
}
