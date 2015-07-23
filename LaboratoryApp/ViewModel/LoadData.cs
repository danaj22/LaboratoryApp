using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            MenuItem root = new MenuItem() { Name = "Menu" };

            MenuItem childItem1 = new MenuItem() { Name = "Child item #1" };
            childItem1.Items.Add(new MenuItem() { Name = "Child item #1.1" });
            childItem1.Items.Add(new MenuItem() { Name = "Child item #1.2" });
            root.Items.Add(childItem1);
            root.Items.Add(new MenuItem() { Name = "Child item #2" });
            
            /*******************************
            //trvMenu.Items.Add(root);
            ********************************/

            userInput = new UserInput();
            Gauges g1 = new Gauges();
            this.TreeOfClients = new ObservableCollection<Clients>();

            foreach (var t in LabEntities.clients)
            {
                //Create an instance of Clients 
                MenuItem menuItem = new MenuItem();

                Clients ClientTree = new Clients();
                ClientTree.Offices = new ObservableCollection<Offices>();
                ClientTree.CollectionOfGaugesInClients = new ObservableCollection<Gauges>();

                List<int> Blabla = new List<int>();

                menuItem.Key = t.clientId;
                menuItem.Name = t.name;

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
                
                foreach (var gag in LabEntities.gauges)
                {

                    Gauges gau = new Gauges();
                    gau.Key = gag.gaugeId;
                    gau.Name = gag.manufacturer_name + " " + gag.model;

                    ClientTree.CollectionOfGaugesInClients.Add(gau);

                }
                
                foreach (var ofi in LabEntities.offices)
                {
                    Offices off = new Offices();
                    off.CollectionOfGauges = new ObservableCollection<Gauges>();

                    off.Key = ofi.officeId;
                    off.Name = ofi.name;
                    off.CollectionOfGauges = ClientTree.CollectionOfGaugesInClients;

                    ClientTree.Offices.Add(off);
                }

                treeOfClients.Add(ClientTree);

            }

        }

    }
}
