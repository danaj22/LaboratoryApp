using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp
{
    public class LoadData : ObservableObject
    {
        UserInput userInput;
        private laboratoryEntities labEntities = new laboratoryEntities();

        public laboratoryEntities LabEntities
        {
            get { return labEntities; }
            set { labEntities = value; }
        }

        public ObservableCollection<TreeViewClass> treeViewClass1 = new ObservableCollection<TreeViewClass>();
        private ObservableCollection<TreeViewClass> treeOfClients = new ObservableCollection<TreeViewClass>();

        public ObservableCollection<TreeViewClass> TreeOfClients
        {
            get { return treeOfClients; }
            set { treeOfClients = value; }
        }
       


        public LoadData()
        {
            userInput = new UserInput();
            gauge1 g1 = new gauge1();

            foreach (var t in LabEntities.clients)
            {
                //Create an instance of TreeViewClass 

                TreeViewClass ClientTree = new TreeViewClass();
                ClientTree.Offices = new ObservableCollection<office1>();
                ClientTree.Gauges = new ObservableCollection<gauge1>();

                List<int> Blabla = new List<int>();

                ClientTree.Key = t.clientId;
                ClientTree.Name = t.name;

                var tmp = (from o in LabEntities.offices
                           where ClientTree.Key == o.client_id
                           select new
                           {
                               o.officeId
                           }).ToList();

                foreach (var e in tmp)
                {
                    int i;
                    i = e.officeId;
                    Blabla.Add(i);
                }

                /*var tmp2 = (from o  in LabEntities.offices
                               where  == o.client_id
                               select new
                               {
                                   o.officeId
                               }).ToList();*/

                foreach (var gag in LabEntities.gauges)
                {

                    gauge1 gau = new gauge1();
                    gau.Key = gag.gaugeId;
                    gau.Name = gag.manufacturer_name + " " + gag.model;

                    ClientTree.Gauges.Add(gau);

                }

                foreach (var ofi in LabEntities.offices)
                {
                    office1 off = new office1();
                    off.ga = new ObservableCollection<gauge1>();

                    off.Key = ofi.officeId;
                    off.Name = ofi.name;
                    off.ga = ClientTree.Gauges;

                    ClientTree.Offices.Add(off);
                }

                treeOfClients.Add(ClientTree);
            }

        }

    }
}
