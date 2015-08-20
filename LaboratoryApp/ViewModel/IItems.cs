using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp.ViewModel
{
    public class Items
    {
        
        public string Name { get; set; }
        ObservableCollection<Items> Children { get; set; }

        void GetContent() { }
    }
}
