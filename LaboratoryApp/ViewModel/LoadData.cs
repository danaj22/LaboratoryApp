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

        public ObservableCollection<Clients> treeViewClass1 = new ObservableCollection<Clients>();
        private ObservableCollection<Clients> treeOfClients = new ObservableCollection<Clients>();

        public ObservableCollection<Clients> TreeOfClients
        {
            get { return treeOfClients; }
            set { treeOfClients = value; }
        }
       


        public LoadData()
        {
            userInput = new UserInput();
            Gauges g1 = new Gauges();

            foreach (var t in LabEntities.clients)
            {
                //Create an instance of Clients 

                Clients ClientTree = new Clients();
                ClientTree.Offices = new ObservableCollection<Offices>();
                ClientTree.Gauges = new ObservableCollection<Gauges>();

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

                    Gauges gau = new Gauges();
                    gau.Key = gag.gaugeId;
                    gau.Name = gag.manufacturer_name + " " + gag.model;

                    ClientTree.Gauges.Add(gau);

                }

                foreach (var ofi in LabEntities.offices)
                {
                    Offices off = new Offices();
                    off.CollectionOfGauges = new ObservableCollection<Gauges>();

                    off.Key = ofi.officeId;
                    off.Name = ofi.name;
                    off.CollectionOfGauges = ClientTree.Gauges;

                    ClientTree.Offices.Add(off);
                }

                treeOfClients.Add(ClientTree);
            }

        }

    }
}
