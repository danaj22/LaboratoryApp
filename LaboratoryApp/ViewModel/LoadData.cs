using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LaboratoryApp;

namespace LaboratoryApp.ViewModel
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

        public LoadData(MenuItem rootItem)
        {

            
           
            /*******************************
            //trvMenu.ChildItem.Add(root);
            ********************************/
            
            userInput = new UserInput();
            //Gauges g1 = new Gauges();
            //this.TreeOfClients = new ObservableCollection<Clients>();
            //rootItem.ListOfClient.Clear();
            try
            {

                foreach (var t in LabEntities.clients)
                {
                    //rootItem.Child.Add(t);

                    
                    rootItem.Children.Add((client)t);
                    rootItem.Children.Last().NameOfItem = t.name;
                   
                    

                    foreach (var g in t.gauges)
                    {
                        if (g.office_id == null)
                        {
                            rootItem.Children.Last().Children.Add(g);
                            rootItem.Children.Last().Children.Last().NameOfItem = g.model_of_gauges.model;
                            rootItem.Children.Last().Children.Last().Parent = t;
                        }
                    }
                    foreach (var o in t.offices)
                    {
                        rootItem.Children.Last().Children.Add(o);
                        rootItem.Children.Last().Children.Last().NameOfItem = o.name;
                        rootItem.Children.Last().Children.Last().Parent = t;
                        foreach (var g in o.gauges)
                        {
                            rootItem.Children.Last().Children.Last().Children.Add(g);
                            rootItem.Children.Last().Children.Last().Children.Last().NameOfItem = g.model_of_gauges.model;
                            rootItem.Parent = o;
                        }
                    }

                }

//                    #region comments
//                    //InformationAboutClient infoClient = new InformationAboutClient();

//                    ///Create an instance of Clients 
//                    //MenuItem menuItem = new MenuItem();

//                    //Clients ClientTree = new Clients();
//                    //ClientTree.offices = new ObservableCollection<offices>();
//                    //ClientTree.CollectionOfGaugesInClients = new ObservableCollection<Gauges>();

//                    //List<int> Blabla = new List<int>();

//                    //menuItem.Key = t.clientId;
//                    //menuItem.ContactPerson = t.name;

//                    //ClientTree.Key = t.clientId;
//                    //ClientTree.ContactPerson = t.name;

//                    //var tmp = (from o in LabEntities.offices
//                    //           where ClientTree.Key == o.client_id
//                    //           select new
//                    //           {
//                    //               o.officeId
//                    //           }).ToList();

//                    //foreach (var e in tmp)
//                    //{
//                    //    int i;
//                    //    i = e.officeId;
//                    //    Blabla.Add(i);
//                    //}

//                    //foreach (var gag in LabEntities.gauges)
//                    //{

//                    //    Gauges gau = new Gauges();
//                    //    gau.Key = gag.gaugeId;
//                    //    gau.ContactPerson = gag.manufacturer_name + " " + gag.model;

//                    //    ClientTree.CollectionOfGaugesInClients.Add(gau);

//                    //}

//                    //foreach (var ofi in LabEntities.offices)
//                    //{
//                    //    offices off = new offices();
//                    //    off.CollectionOfGauges = new ObservableCollection<Gauges>();

//                    //    off.Key = ofi.officeId;
//                    //    off.ContactPerson = ofi.name;
//                    //    off.CollectionOfGauges = ClientTree.CollectionOfGaugesInClients;

//                    //    ClientTree.offices.Add(off);
//                    //}

//                    //treeOfClients.Add(ClientTree);
//#endregion comments
//                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

    }
}
