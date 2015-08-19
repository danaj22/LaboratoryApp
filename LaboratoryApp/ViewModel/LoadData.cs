using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LaboratoryApp.ViewModel;

namespace LaboratoryApp
{
    public class LoadData : ObservableObject
    {
        UserInput userInput;
        private LaboratoryEntities labEntities = new LaboratoryEntities();

        public LaboratoryEntities LabEntities
        {
            get { return labEntities; }
            set { labEntities = value; }
        }

        //public ObservableCollection<Clients> treeViewClass1 = new ObservableCollection<Clients>();
        //private ObservableCollection<Clients> treeOfClients = new ObservableCollection<Clients>();

        //public ObservableCollection<Clients> TreeOfClients
        //{
        //    get { return treeOfClients; }
        //    set { treeOfClients = value; }
        //}


        public LoadData(MenuItem rootItem)
        {

            
           
            /*******************************
            //trvMenu.ChildItem.Add(root);
            ********************************/
            //rootItem = new MenuItem();
            
            userInput = new UserInput();
            //Gauges g1 = new Gauges();
            //this.TreeOfClients = new ObservableCollection<Clients>();

            foreach (var t in LabEntities.clients)
            {
                rootItem.Items.Add(t);
                foreach(var g in t.gauges)
                    if(g.office_id== null)
                        rootItem.Items.Last().Items.Add(g);
                foreach (var o in t.offices)
                    rootItem.Items.Last().Items.Add(o);

                //InformationAboutClient infoClient = new InformationAboutClient();

                ///Create an instance of Clients 
                //MenuItem menuItem = new MenuItem();

                //Clients ClientTree = new Clients();
                //ClientTree.offices = new ObservableCollection<offices>();
                //ClientTree.CollectionOfGaugesInClients = new ObservableCollection<Gauges>();

                //List<int> Blabla = new List<int>();

                //menuItem.Key = t.clientId;
                //menuItem.ContactPerson = t.name;

                //ClientTree.Key = t.clientId;
                //ClientTree.ContactPerson = t.name;

                //var tmp = (from o in LabEntities.offices
                //           where ClientTree.Key == o.client_id
                //           select new
                //           {
                //               o.officeId
                //           }).ToList();

                //foreach (var e in tmp)
                //{
                //    int i;
                //    i = e.officeId;
                //    Blabla.Add(i);
                //}
                
                //foreach (var gag in LabEntities.gauges)
                //{

                //    Gauges gau = new Gauges();
                //    gau.Key = gag.gaugeId;
                //    gau.ContactPerson = gag.manufacturer_name + " " + gag.model;

                //    ClientTree.CollectionOfGaugesInClients.Add(gau);

                //}
                
                //foreach (var ofi in LabEntities.offices)
                //{
                //    offices off = new offices();
                //    off.CollectionOfGauges = new ObservableCollection<Gauges>();

                //    off.Key = ofi.officeId;
                //    off.ContactPerson = ofi.name;
                //    off.CollectionOfGauges = ClientTree.CollectionOfGaugesInClients;

                //    ClientTree.offices.Add(off);
                //}

                //treeOfClients.Add(ClientTree);
            }

        }

    }
}
