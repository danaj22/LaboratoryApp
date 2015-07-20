using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp
{
    public class Offices:ObservableObject
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Gauges> CollectionOfGauges { get; set; }
        
    }
}
