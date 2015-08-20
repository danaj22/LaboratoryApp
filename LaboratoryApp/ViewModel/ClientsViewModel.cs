using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp.ViewModel
{
    public class ClientsViewModel:ObservableObject
    {
        public int Key { get; set; }
        public string Name { get; set; }

        private ObservableCollection<OfficesViewModel> children = new ObservableCollection<OfficesViewModel>();
        public ObservableCollection<OfficesViewModel> Children { get { return children; } }
        
    }
}
