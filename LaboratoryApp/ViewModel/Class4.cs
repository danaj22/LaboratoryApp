using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp
{
    public class TreeViewClass
    {
        public int Key { get; set; }
        public string Name { get; set; }

        public ObservableCollection<gauge1> Gauges { get; set; }
        public ObservableCollection<office1> Offices { get; set; }

    }
}
