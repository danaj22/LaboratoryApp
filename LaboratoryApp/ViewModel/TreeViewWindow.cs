using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace LaboratoryApp
{
    public class TreeViewWindow
    {
        public ObservableCollection<TreeViewWindow> Items { get; set; }

        public TreeViewWindow()
        {
            this.Items = new ObservableCollection<TreeViewWindow>();
        }

        public int Key { get; set; }
        public string Name { get; set; }

    }
}
