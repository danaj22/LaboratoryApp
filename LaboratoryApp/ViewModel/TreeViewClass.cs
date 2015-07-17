using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaboratoryApp;

namespace LaboratoryApp.ViewModel
{/*
    public class TestData : ObservableObject
    {
        public ObservableCollection<TreeViewClass> treeViewClass1 = new ObservableCollection<TreeViewClass>();

        public void Load()
        {
            TreeViewClass t1 = new TreeViewClass() { Key = 1, Name = "klient1", Gauges = new ObservableCollection<gauge1>(), Offices = new ObservableCollection<office1>() };
            TreeViewClass t2 = new TreeViewClass() { Key = 2, Name = "klient2", Gauges = new ObservableCollection<gauge1>(), Offices = new ObservableCollection<office1>() };
            TreeViewClass t3 = new TreeViewClass() { Key = 3, Name = "klient3", Gauges = new ObservableCollection<gauge1>(), Offices = new ObservableCollection<office1>() };
            TreeViewClass t4 = new TreeViewClass() { Key = 4, Name = "klient4", Gauges = new ObservableCollection<gauge1>(), Offices = new ObservableCollection<office1>() };

            t1.Offices.Add(new office1() { Key = 1, Name = "biuro1" });
            t1.Offices.Add(new office1() { Key = 2, Name = "biuro2" });
            t1.Offices.Add(new office1() { Key = 3, Name = "biuro3" });

            t2.Offices.Add(new office1() { Key = 4, Name = "biuro4" });
            t2.Offices.Add(new office1() { Key = 5, Name = "biuro5" });
            t2.Offices.Add(new office1() { Key = 6, Name = "biuro6" });

            t3.Offices.Add(new office1() { Key = 7, Name = "biuro7" });
            t3.Offices.Add(new office1() { Key = 8, Name = "biuro8" });
            t3.Offices.Add(new office1() { Key = 9, Name = "biuro9" });

            t1.Gauges.Add(new gauge1() { Key = 10, Name = "miernik1" });
            t1.Gauges.Add(new gauge1() { Key = 11, Name = "miernik2" });
            t3.Gauges.Add(new gauge1() { Key = 12, Name = "miernik3" });
            t3.Gauges.Add(new gauge1() { Key = 13, Name = "miernik4" });

            treeViewClass1.Add(t1);
            treeViewClass1.Add(t2);
            treeViewClass1.Add(t3);
            treeViewClass1.Add(t4);

        }

    }
     public class office1
    {
        public int Key { get; set; }
        public string Name { get; set; }
    }
    public class gauge1
    {
        public int Key { get; set; }
        public string Name { get; set; }
    }
    public class TreeViewClass : ObservableObject
    {
        public int Key { get; set; }
        public string Name { get; set; }

        public ObservableCollection<gauge1> Gauges { get; set; }
        public ObservableCollection<office1> Offices { get; set; }

        public ObservableCollection<object> Items
        {
            get
            {
                ObservableCollection<object> childNodes = new ObservableCollection<object>();

                foreach (var o in this.Offices)
                    childNodes.Add(o);
                foreach (var g in this.Gauges)
                    childNodes.Add(g);

                return childNodes;
            }
        }


    }*/
}
