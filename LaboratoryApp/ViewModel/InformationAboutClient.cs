using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaboratoryApp.View;
using System.Windows.Input;
using LaboratoryApp;
using System.Windows;

namespace LaboratoryApp.ViewModel
{
    public class InformationAboutClient : ObservableObject
    {
        #region
        public InformationAboutClient(MenuItem SelectedNode)
        {
            OfficeId = null;
            sel = SelectedNode;
            
        }
        public InformationAboutClient()
        {

        }

        private MenuItem sel;
        private int clientId;
        public int ClientId
        {
            get { return clientId; }
            set 
            { 
                clientId = value;
                OnPropertyChanged("ClientId");
            }
        }
        private int? officeId;
        public int? OfficeId
        {
            get { return officeId; }
            set
            {
                officeId = value;
                OnPropertyChanged("OfficeId");
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set 
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set 
            { 
                address = value;
                OnPropertyChanged("Address");
            }
        }
        private string contactPerson;
        public string ContactPerson
        {
            get { return contactPerson; }
            set 
            { 
                contactPerson = value;
                OnPropertyChanged("ContactPerson");
            }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set
            { 
                email = value;
                OnPropertyChanged("Email");
            }
        }
        private string telephone;
        public string Telephone
        {
            get { return telephone; }
            set 
            {
                telephone = value;
                OnPropertyChanged("Telephone");
            }
        }
        private string nIP;
        public string NIP
        {
            get { return nIP; }
            set 
            { 
                nIP = value;
                OnPropertyChanged("NIP");
            }
        }
        private string comment;
        public string Comment
        {
            get { return comment; }
            set 
            { 
                comment = value;
                OnPropertyChanged("Comment");
            }
        }
        private int gaugeIdToAdd;
        public int GaugeIdToAdd
        {
            get { return gaugeIdToAdd; }
            set
            {
                gaugeIdToAdd = value;
                OnPropertyChanged("GaugeIdToAdd");
            }
        }

        private model_of_gauges modelOfGauge;
        public model_of_gauges ModelOfGauge
        {
            get { return modelOfGauge; }
            set
            {
                modelOfGauge = value;
                OnPropertyChanged("ModelOfGauge");
            }
        }
        #endregion

        private NewWindowOffice messageWindowOffice;
        public NewWindowOffice MessageWindowOffice
        {
            get { return messageWindowOffice; }
            set 
            {
                messageWindowOffice = value;
                OnPropertyChanged("MessageWindowOffice");
            }
        }

        private NewWindowGauge messageWindowGauge;

        public NewWindowGauge MessageWindowGauge
        {
            get { return messageWindowGauge; }
            set
            {
                messageWindowGauge = value;
                OnPropertyChanged("MessageWindowGauge");
            }
        }

        public ICommand AddGaugeCommand
        { get { return new SimpleRelayCommand(AddGaugeExecute); } }

        private void AddGaugeExecute()
        {
            MessageWindowGauge = new NewWindowGauge() { AboutGauge = new InformationAboutGauge() };
            MessageWindowGauge.IsOpen = true;

            if (MessageWindowGauge.ToConfirm)
            {
                gauge gaugeToAddToDatabase = new gauge();
                ModelOfGauge = new model_of_gauges();

                using (LaboratoryEntities context = new LaboratoryEntities())
                {
                    GaugeIdToAdd = (from m in context.model_of_gauges where m.model == MessageWindowGauge.AboutGauge.SelectedModel select m.model_of_gaugeId).FirstOrDefault();

                    //nie mogę pobrać całego rekordu
                    ModelOfGauge = (from m in context.model_of_gauges where m.model_of_gaugeId == GaugeIdToAdd select m).FirstOrDefault();


                    //GaugeIdToAdd = (from m in context.model_of_gauges where m.model == MessageWindowGauge.AboutGauge.SelectedModel select m.model_of_gaugeId).FirstOrDefault();

                
                gaugeToAddToDatabase.client_id = ClientId;
                gaugeToAddToDatabase.model_of_gauges = ModelOfGauge;
                gaugeToAddToDatabase.serial_number = MessageWindowGauge.AboutGauge.SerialNumber;
                

                    

                    //if (gaugeToAddToDatabase)
                    {
                        client SelectedClient = new client();

                        SelectedClient = (client)MainWindowViewModel.selectedNode;

                        int index = MainWindowViewModel.rootElement.Children.IndexOf(SelectedClient);

                        //MainWindowViewModel.rootElement.Children[index].Children.Add(gaugeToAddToDatabase);


                        context.gauges.Add(gaugeToAddToDatabase);
                        context.SaveChanges();
                    }


                    //var r = MainWindowViewModel.rootElement.Items.IndexOf((client)MainWindowViewModel.selectedNode);
                    //MainWindowViewModel.rootElement.Items[r].Items.Add(gaugeToAddToDatabase);
                }
                MessageBox.Show("Miernik został dodany do bazy.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);

                //var index = AllItems.IndexOf(AllItems.Last()) + 1;
                //AllItems.Remove((client)SelectedNode);
                ////Add new client to TreeView
                //AllItems.Insert(index+1, newClient);

                MessageWindowGauge.ToConfirm = false;
                //MainWindowViewModel.LoadView();
            }
            else
            {

            }

        }
        
        public ICommand DeleteCommand
        { get { return new SimpleRelayCommand(DeleteClientExecute); } }

        private void DeleteClientExecute()
        {
            var result = MessageBox.Show("Czy na pewno chcesz usunąć bezzwłocznie i definitywnie tego klienta?","Usuwanie klienta",MessageBoxButton.YesNo,MessageBoxImage.Question);
            
            if(result == MessageBoxResult.Yes)
            {
                try
                {
                    
                    //var r = MainWindowViewModel.rootElement.Items.IndexOf((client)MainWindowViewModel.selectedNode);
                    //MainWindowViewModel.rootElement.Items.Remove(clientToDelete);
                    //MainWindowViewModel.rootElement.Items[r].Items.Clear();
                    //MainWindowViewModel.rootElement.Items.RemoveAt(r);
                    //MainWindowViewModel.LoadView();



                    LaboratoryEntities context = new LaboratoryEntities();
                    //delete selected client
                    var clientToDelete = (from c in context.clients
                                          where c.clientId == this.ClientId
                                          select c).FirstOrDefault();
                    //context.clients.

                    client klientka = (client) MainWindowViewModel.selectedNode;

                    MainWindowViewModel.rootElement.Children.Remove(MainWindowViewModel.selectedNode);


                    //context.gauges.Select( x )
                   
                    var lista = (from g in context.gauges where g.client_id == klientka.clientId select g).ToList();
                    foreach(gauge l in lista)
                    {
                        context.gauges.Remove(l);
                    }
                   
                   // {
                     //   List<gauge> gaugeToRemove = (from )
                    //}
                    context.clients.Remove(clientToDelete);
                    context.SaveChanges();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }

        private NewWindowClient messageWindowClient;

        public NewWindowClient MessageWindowClient
        {
            get { return messageWindowClient; }
            set
            {
                messageWindowClient = value;
                OnPropertyChanged("MessageWindowClient");
            }
        }

        public ICommand EditCommand
        { get { return new SimpleRelayCommand(EditClientExecute);} }


        private void EditClientExecute()
        {

            MessageWindowClient = new NewWindowClient();
           
            //filling in the data fields in new window
            //MessageWindowClient.AboutClient.clientId = ClientId;
            //MessageWindowClient.AboutClient.comments = Comment;
            //MessageWindowClient.AboutClient.name = Name;
            //MessageWindowClient.AboutClient.contact_person_name = ContactPerson;
            //MessageWindowClient.AboutClient.adress = Address;
            //MessageWindowClient.AboutClient.tel = Telephone;
            //MessageWindowClient.AboutClient.NIP = NIP;
            //MessageWindowClient.AboutClient.mail = Email;



            messageWindowClient.AboutClient = (client) sel;

            //show window
            MessageWindowClient.IsOpen = true;

            if (MessageWindowClient.ToConfirm)
            {
                using (LaboratoryEntities context = new LaboratoryEntities())
                {
                    //finding selected client in database
                    var clientToEdit = (from c in context.clients
                                        where c.clientId == MessageWindowClient.AboutClient.clientId
                                        select c).FirstOrDefault();


                    //modify data in database
                    if (MessageWindowClient.AboutClient.name != ""
                        && MessageWindowClient.AboutClient.adress != ""
                        && MessageWindowClient.AboutClient.contact_person_name != ""
                        && MessageWindowClient.AboutClient.mail != ""
                        && MessageWindowClient.AboutClient.tel != ""
                        && MessageWindowClient.AboutClient.NIP != ""
                        && MessageWindowClient.AboutClient.comments != "")
                    {

                        clientToEdit.name = MessageWindowClient.AboutClient.name;
                        clientToEdit.adress = MessageWindowClient.AboutClient.name;
                        clientToEdit.contact_person_name = MessageWindowClient.AboutClient.contact_person_name;
                        clientToEdit.mail = MessageWindowClient.AboutClient.mail;
                        clientToEdit.tel = MessageWindowClient.AboutClient.tel;
                        clientToEdit.NIP = MessageWindowClient.AboutClient.NIP;
                        clientToEdit.comments = MessageWindowClient.AboutClient.comments;

                        context.SaveChanges();

                        //client SelectedClient = new client();
                        
                        //SelectedClient = (client)MainWindowViewModel.selectedNode;

                        //int index = MainWindowViewModel.rootElement.Children.IndexOf(SelectedClient);

                        //MainWindowViewModel.rootElement.Children[index] = clientToEdit;
                        
                        //MainWindowViewModel.LoadView();

                        //var r = MainWindowViewModel.rootElement.Items.IndexOf((client)MainWindowViewModel.selectedNode);
                        //MainWindowViewModel.rootElement.Items[r] = clientToEdit;

                        //set new data in main window view
                        Name = MessageWindowClient.AboutClient.name;
                        Address = MessageWindowClient.AboutClient.adress;
                        ContactPerson = MessageWindowClient.AboutClient.contact_person_name;
                        Email = MessageWindowClient.AboutClient.mail;
                        Telephone = MessageWindowClient.AboutClient.tel;
                        NIP = MessageWindowClient.AboutClient.NIP;
                        Comment = MessageWindowClient.AboutClient.comments;

                        MainWindowViewModel.selectedNode.NameOfItem = Name;
                    }
                    else
                    {
                        MessageBox.Show("Wypełnij wszystkie pola");
                    }

                }
                MessageWindowClient.ToConfirm = false;
                //MainWindowViewModel.LoadView();
            }
        }

        public ICommand AddCommand
        { get { return new SimpleRelayCommand(AddOfficeExecute); } }

        private void AddOfficeExecute()
        {
            MessageWindowOffice = new NewWindowOffice() { AboutOffice = new InformationAboutOffice() };
            
            //open a new modal window
            messageWindowOffice.IsOpen = true;
            office officeToAddToDatabase;
            
            if (MessageWindowOffice.ToConfirm)
            {
                officeToAddToDatabase = new office();
                officeToAddToDatabase.adress = MessageWindowOffice.AboutOffice.Address;
                officeToAddToDatabase.mail = MessageWindowOffice.AboutOffice.Email;
                officeToAddToDatabase.contact_person_name = MessageWindowOffice.AboutOffice.ContactPerson;
                officeToAddToDatabase.name = MessageWindowOffice.AboutOffice.Name;
                officeToAddToDatabase.tel = MessageWindowOffice.AboutOffice.Telephone;
                officeToAddToDatabase.client_id = this.ClientId;

                using (LaboratoryEntities context = new LaboratoryEntities())
                {

                    

                    client SelectedClient = new client();

                    SelectedClient = (client)MainWindowViewModel.selectedNode;

                    int index = MainWindowViewModel.rootElement.Children.IndexOf(SelectedClient);

                    //MainWindowViewModel.rootElement.Children[index].Children.Add(officeToAddToDatabase);

                    context.offices.Add(officeToAddToDatabase);
                    context.SaveChanges();

                    //var r = MainWindowViewModel.rootElement.Items.IndexOf((client)MainWindowViewModel.selectedNode);
                    //MainWindowViewModel.rootElement.Items[r].Items.Add(officeToAddToDatabase);

                    //MainWindowViewModel.rootElement.Items.[ind].Items.Add(officeToAddToDatabase);
                     
                }
                MainWindowViewModel.selectedNode.Children.Add(officeToAddToDatabase);
                MainWindowViewModel.selectedNode.Children.Last().NameOfItem = officeToAddToDatabase.name;
                MessageBox.Show("Oddział został dodany do bazy.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);

                //var index = AllItems.IndexOf(AllItems.Last()) + 1;
                //AllItems.Remove((client)SelectedNode);
                ////Add new client to TreeView
                //AllItems.Insert(index+1, newClient);
                //MainWindowViewModel.LoadView();
                
                //int ind = MainWindowViewModel.rootElement.Items[this.ClientId];
                
                //(client)MainWindowViewModel.selectedNode;
                //client temporaryClient = (client)MainWindowViewModel.selectedNode;
                
                //MainWindowViewModel.rootElement.Items.[ind].Items.Add(officeToAddToDatabase);
            }
            else
            { }

            MessageWindowOffice.ToConfirm = false;
            
        }
    }
}
