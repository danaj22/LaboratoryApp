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
using System.Data.Entity.Validation;
using LaboratoryApp.Models;

namespace LaboratoryApp.ViewModel
{
    public class InformationAboutClient : ObservableObject
    {
        #region
        public InformationAboutClient(MenuItem SelectedNode)
        {
            OfficeId = null;
            SelectedClient = (client)SelectedNode;
            Address = SelectedClient.adress;
            Name = SelectedClient.name;
            ContactPerson = SelectedClient.contact_person_name;
            Email = SelectedClient.mail;
            Telephone = SelectedClient.tel;
            NIP = SelectedClient.NIP;
            Comment = SelectedClient.comments;
        }

        public InformationAboutClient()
        {

        }
        #region
        private client selectedClient;

        public client SelectedClient
        {
            get { return selectedClient; }
            set
            {
                selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }
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
        #endregion

        public ICommand AddGaugeCommand
        { get { return new SimpleRelayCommand(AddGaugeExecute); } }

        private void AddGaugeExecute()
        {
            MessageWindowGauge = new NewWindowGauge() { AboutGauge = new gauge() };

            MessageWindowGauge.IsOpen = true;

            if (MessageWindowGauge.ToConfirm)
            {
                gauge gaugeToAddToDatabase = new gauge();
                gaugeToAddToDatabase.serial_number = MessageWindowGauge.AboutGauge.serial_number;
                //gaugeToAddToDatabase.model_of_gauges.model = MessageWindowGauge.SelectedModel;
                //gaugeToAddToDatabase.model_of_gauges.manufacturer_name = MessageWindowGauge.Manufacturer;


                LaboratoryEntities context = new LaboratoryEntities();
                {
                    GaugeIdToAdd = (from m in context.model_of_gauges where m.model == MessageWindowGauge.SelectedModel select m.model_of_gaugeId).FirstOrDefault();

                    //nie mogę pobrać całego rekordu
                    model_of_gauges ModelOfGauge = (from m in context.model_of_gauges where m.model_of_gaugeId == GaugeIdToAdd select m).FirstOrDefault();


                    //GaugeIdToAdd = (from m in context.model_of_gauges where m.model == MessageWindowGauge.AboutGauge.SelectedModel select m.model_of_gaugeId).FirstOrDefault();


                    gaugeToAddToDatabase.client_id = SelectedClient.clientId;
                    //gaugeToAddToDatabase.client.NIP = SelectedClient.NIP;
                    //gaugeToAddToDatabase.client.name = SelectedClient.name;

                    //gaugeToAddToDatabase.model_of_gauges = ModelOfGauge;

                    gaugeToAddToDatabase.model_of_gauge_id = ModelOfGauge.model_of_gaugeId;
                    gaugeToAddToDatabase.model_of_gauges = ModelOfGauge;
                    //gaugeToAddToDatabase.client = SelectedClient;

                    //gaugeToAddToDatabase.model_of_gauges.model = ModelOfGauge.model;
                    //gaugeToAddToDatabase.model_of_gauges.manufacturer_name = ModelOfGauge.manufacturer_name;

                    gaugeToAddToDatabase.serial_number = MessageWindowGauge.AboutGauge.serial_number;


                    //office of = new office();
                    //of.adress = "df";
                    //of.name = "aaaa";
                    //of.mail = "dfadfadfa";
                    //of.tel = "1212";
                    //of.contact_person_name = "fdsafsd";
                    //of.client_id = 1043;



                    //gaugeToAddToDatabase.office = of;


                    //if (gaugeToAddToDatabase)
                    {
                        //client SelectedClient = new client();

                        //SelectedClient = (client)MainWindowViewModel.selectedNode;

                        int index = MainWindowViewModel.rootElement.Children.IndexOf(SelectedClient);

                        //MainWindowViewModel.rootElement.Children[index].Children.Add(gaugeToAddToDatabase);

                        try
                        {
                            context.gauges.Add(gaugeToAddToDatabase);
                            context.SaveChanges();

                            gauge GaugeToAddToList = gaugeToAddToDatabase;
                            GaugeToAddToList.client = SelectedClient;

                            MainWindowViewModel.selectedNode.Children.Add(GaugeToAddToList);
                            MainWindowViewModel.selectedNode.Children.Last().NameOfItem = MessageWindowGauge.SelectedModel +" ["+MessageWindowGauge.AboutGauge.serial_number+"]";
                            MainWindowViewModel.selectedNode.Children.Last().Parent = SelectedClient;

                            MessageBox.Show("Miernik został dodany do bazy.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                            
                            MainWindowViewModel.selectedNode.Children.Last().IsSelected = true;
                               // SelectedClient.gauges.Last().IsSelected = true;

                        }
                        catch (DbEntityValidationException e)
                        {
                            foreach (var eve in e.EntityValidationErrors)
                            {
                                 MainWindowViewModel.FileLog.WriteLine(String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                    eve.Entry.Entity.GetType().Name, eve.Entry.State));
                                foreach (var ve in eve.ValidationErrors)
                                {
                                     MainWindowViewModel.FileLog.WriteLine(String.Format("- Property: \"{0}\", Error: \"{1}\"",
                                        ve.PropertyName, ve.ErrorMessage));
                                }
                            }
                        }
                        catch (Exception e)
                        { 
                            MessageBox.Show("Błąd w dodawaniu miernika.");
                            MainWindowViewModel.FileLog.WriteLine(e.ToString());
                        }
                    }


                    //var r = MainWindowViewModel.rootElement.Items.IndexOf((client)MainWindowViewModel.selectedNode);
                    //MainWindowViewModel.rootElement.Items[r].Items.Add(gaugeToAddToDatabase);
                }

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
            var result = MessageBox.Show("Czy na pewno chcesz usunąć bezzwłocznie i definitywnie tego klienta?", "Usuwanie klienta", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {

                    LaboratoryEntities context = new LaboratoryEntities();
                    {
                        //delete selected client
                        var clientToDelete = (from c in context.clients
                                              where c.clientId == SelectedClient.clientId
                                              select c).FirstOrDefault();

                        try
                        {
                            client ClientToDelete = (client)MainWindowViewModel.selectedNode;

                            var lista = (from g in context.gauges where g.client_id == ClientToDelete.clientId select g).ToList();
                            foreach (gauge l in lista)
                            {
                                context.gauges.Remove(l);
                            }

                            context.clients.Remove(clientToDelete);
                            context.SaveChanges();

                            MainWindowViewModel.rootElement.Children.Remove(MainWindowViewModel.selectedNode);
                            MessageBox.Show("Usunięto klienta.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch
                        {
                            MessageBox.Show("Nie udało się usunąć klienta. Sprawdź połączenie.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd w usuwaniu klienta.");
                    MainWindowViewModel.FileLog.WriteLine(ex.ToString());
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
        { get { return new SimpleRelayCommand(EditClientExecute); } }


        private void EditClientExecute()
        {

            MessageWindowClient = new NewWindowClient();

            MessageWindowClient.AboutClient = (client)SelectedClient;

            //show window
            MessageWindowClient.IsOpen = true;

            if (MessageWindowClient.ToConfirm)
            {
                LaboratoryEntities context = new LaboratoryEntities();
                {
                    //finding selected client in database
                    var clientToEdit = (from c in context.clients
                                        where c.clientId == MessageWindowClient.AboutClient.clientId
                                        select c).FirstOrDefault();


                    //modify data in database
                    if (!string.IsNullOrEmpty(MessageWindowClient.AboutClient.name) && !string.IsNullOrEmpty(MessageWindowClient.AboutClient.NIP))
                    {

                        clientToEdit.name = MessageWindowClient.AboutClient.name;
                        clientToEdit.adress = MessageWindowClient.AboutClient.adress;
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

                        MainWindowViewModel.selectedNode.NameOfItem = MessageWindowClient.AboutClient.name;
                        MainWindowViewModel.selectedNode = SelectedClient;
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
            MessageWindowOffice = new NewWindowOffice() { AboutOffice = new office() };

            //open a new modal window
            messageWindowOffice.IsOpen = true;
            office officeToAddToDatabase;

            if (MessageWindowOffice.ToConfirm)
            {
                officeToAddToDatabase = new office();
                officeToAddToDatabase.adress = MessageWindowOffice.AboutOffice.adress;
                officeToAddToDatabase.mail = MessageWindowOffice.AboutOffice.mail;
                officeToAddToDatabase.contact_person_name = MessageWindowOffice.AboutOffice.contact_person_name;
                officeToAddToDatabase.name = MessageWindowOffice.AboutOffice.name;
                officeToAddToDatabase.tel = MessageWindowOffice.AboutOffice.tel;
                officeToAddToDatabase.client_id = SelectedClient.clientId;

                LaboratoryEntities context = new LaboratoryEntities();
                {



                    //client SelectedClient = new client();

                    //SelectedClient = (client)MainWindowViewModel.selectedNode;

                    //int index = MainWindowViewModel.rootElement.Children.IndexOf(SelectedClient);

                    //MainWindowViewModel.rootElement.Children[index].Children.Add(officeToAddToDatabase);

                    context.offices.Add(officeToAddToDatabase);
                    context.SaveChanges();


                    //var r = MainWindowViewModel.rootElement.Items.IndexOf((client)MainWindowViewModel.selectedNode);
                    //MainWindowViewModel.rootElement.Items[r].Items.Add(officeToAddToDatabase);

                    //MainWindowViewModel.rootElement.Items.[ind].Items.Add(officeToAddToDatabase);
                    office OfficeToAddToList = officeToAddToDatabase;
                    OfficeToAddToList.client = SelectedClient;

                }
                MainWindowViewModel.selectedNode.Children.Add(officeToAddToDatabase);
                MainWindowViewModel.selectedNode.Children.Last().NameOfItem = officeToAddToDatabase.name;
                MainWindowViewModel.selectedNode.Children.Last().Parent = SelectedClient;

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
