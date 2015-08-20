using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp.ViewModel
{
    public class OfficesViewModel:ObservableObject
    {
        public int Key { get; set; }
        public string Name { get; set; }

        private ObservableCollection<GaugesViewModel> children = new ObservableCollection<GaugesViewModel>();
        public ObservableCollection<GaugesViewModel> Children { get { return children; } }
        
    }
}
