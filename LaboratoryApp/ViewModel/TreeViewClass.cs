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
        public ObservableCollection<Clients> treeViewClass1 = new ObservableCollection<Clients>();

        public void Load()
        {
            Clients t1 = new Clients() { Key = 1, Name = "klient1", Gauges = new ObservableCollection<Gauges>(), Offices = new ObservableCollection<Offices>() };
            Clients t2 = new Clients() { Key = 2, Name = "klient2", Gauges = new ObservableCollection<Gauges>(), Offices = new ObservableCollection<Offices>() };
            Clients t3 = new Clients() { Key = 3, Name = "klient3", Gauges = new ObservableCollection<Gauges>(), Offices = new ObservableCollection<Offices>() };
            Clients t4 = new Clients() { Key = 4, Name = "klient4", Gauges = new ObservableCollection<Gauges>(), Offices = new ObservableCollection<Offices>() };

            t1.Offices.Add(new Offices() { Key = 1, Name = "biuro1" });
            t1.Offices.Add(new Offices() { Key = 2, Name = "biuro2" });
            t1.Offices.Add(new Offices() { Key = 3, Name = "biuro3" });

            t2.Offices.Add(new Offices() { Key = 4, Name = "biuro4" });
            t2.Offices.Add(new Offices() { Key = 5, Name = "biuro5" });
            t2.Offices.Add(new Offices() { Key = 6, Name = "biuro6" });

            t3.Offices.Add(new Offices() { Key = 7, Name = "biuro7" });
            t3.Offices.Add(new Offices() { Key = 8, Name = "biuro8" });
            t3.Offices.Add(new Offices() { Key = 9, Name = "biuro9" });

            t1.Gauges.Add(new Gauges() { Key = 10, Name = "miernik1" });
            t1.Gauges.Add(new Gauges() { Key = 11, Name = "miernik2" });
            t3.Gauges.Add(new Gauges() { Key = 12, Name = "miernik3" });
            t3.Gauges.Add(new Gauges() { Key = 13, Name = "miernik4" });

            treeViewClass1.Add(t1);
            treeViewClass1.Add(t2);
            treeViewClass1.Add(t3);
            treeViewClass1.Add(t4);

        }

    }
     public class Offices
    {
        public int Key { get; set; }
        public string Name { get; set; }
    }
    public class Gauges
    {
        public int Key { get; set; }
        public string Name { get; set; }
    }
    public class Clients : ObservableObject
    {
        public int Key { get; set; }
        public string Name { get; set; }

        public ObservableCollection<Gauges> Gauges { get; set; }
        public ObservableCollection<Offices> Offices { get; set; }

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
