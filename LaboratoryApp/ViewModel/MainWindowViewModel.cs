using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp
{
    public class MainWindowViewModel : ObservableObject
    {
        
        
        private LoadData data;

        public LoadData Data
        {
            get { return data; }
            set 
            { 
                data = value;
                OnPropertyChanged("Data");
            }
        }
        
        private UserInput userInput;

        public UserInput UserInput
        {
            get { return userInput; }
            set { userInput = value; }
        }

        private void LoadView()
        {
            data = new LoadData();

            //item1.IsExpanded = true;
        }

        public MainWindowViewModel()
        {
            userInput = new UserInput();
            LoadView();
        }
        
        private object selectedNode = 0;
        private laboratoryEntities labEntities = new laboratoryEntities();

        public laboratoryEntities LabEntities
        {
            get { return labEntities; }
            set { labEntities = value; }
        }
        
        public object SelectedNode
        {
            

            get { return selectedNode; }
            set 
            {
                selectedNode = value;
                if ((selectedNode as Clients) != null)
                {
                    Clients InstanceOfClientNode = new Clients();
                    InstanceOfClientNode = (Clients)selectedNode;

                /////////////////////////////////////////////////////////
               
                
                    //Create an instance of Clients 

                    Clients ClientTree = new Clients();
                    ClientTree = (Clients)InstanceOfClientNode;
                    ClientTree.Offices = new ObservableCollection<Offices>();
                    
                    ClientTree.Gauges = new ObservableCollection<Gauges>();


                    List<int> TemporaryListOfOfficeId = new List<int>();

                    ClientTree.Key =  InstanceOfClientNode.Key;
                    ClientTree.Name = InstanceOfClientNode.Name;

                    var tmp = (from o in LabEntities.offices
                               where InstanceOfClientNode.Key == o.client_id
                               select new
                               {
                                   o.officeId
                               }).ToList();

                    foreach (var e in tmp)
                    {
                        int i;
                        i = e.officeId;
                        TemporaryListOfOfficeId.Add(i);
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
                 }
                //////////////////////////////////////////////////


                OnPropertyChanged("SelectedNode");
            }


        }
        
    }
}
