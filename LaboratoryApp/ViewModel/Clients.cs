using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp
{
    public class Clients:ObservableObject
    {
        public int Key { get; set; }
        public string Name { get; set; }

        public ObservableCollection<Gauges> Gauges { get; set; }
        public ObservableCollection<Offices> Offices { get; set; }

    }
}
