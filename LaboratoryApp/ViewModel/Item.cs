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
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
