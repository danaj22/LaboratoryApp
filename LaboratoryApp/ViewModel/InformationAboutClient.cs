using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaboratoryApp.View;
using System.Windows.Input;
using LaboratoryApp.ViewModel;
using System.Windows;

namespace LaboratoryApp
{
    public class InformationAboutClient : ObservableObject
    {
        public InformationAboutClient()
        {
            OfficeId = null;
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

                using (LaboratoryEntities context = new LaboratoryEntities())
                {
                    GaugeIdToAdd = (from m in context.model_of_gauges where m.model == MessageWindowGauge.AboutGauge.SelectedModel select m.model_of_gaugeId).FirstOrDefault();
                }
                gaugeToAddToDatabase.client_id = ClientId;
                gaugeToAddToDatabase.office_id = OfficeId;
                gaugeToAddToDatabase.model_of_gauge_id = GaugeIdToAdd;
                gaugeToAddToDatabase.serial_number = MessageWindowGauge.AboutGauge.SerialNumber;

                using (LaboratoryEntities context = new LaboratoryEntities())
                {
                    context.gauges.Add(gaugeToAddToDatabase);
                    context.SaveChanges();
                }
                MessageBox.Show("Miernik został dodany do bazy.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);

                //var index = AllItems.IndexOf(AllItems.Last()) + 1;
                //AllItems.Remove((client)SelectedNode);
                ////Add new client to TreeView
                //AllItems.Insert(index+1, newClient);

                MessageWindowGauge.ToConfirm = false;
                MainWindowViewModel.LoadView();
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
                LaboratoryEntities context = new LaboratoryEntities();
                //delete selected client
                var clientToDelete = (from c in context.clients
                                      where c.clientId == this.ClientId
                                      select c).FirstOrDefault();

                context.clients.Remove(clientToDelete);
                context.SaveChanges();
                MainWindowViewModel.LoadView();
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

            MessageWindowClient = new NewWindowClient() { AboutClient = new InformationAboutClient() };
            
            //create a new modal window
            //DialogWindowBase newBaseWindow = new DialogWindowBase();
            //NewWindowClient clientDialogWindow = new NewWindowClient() { AboutClient = new InformationAboutClient() };


            //filling in the data fields in new window
            MessageWindowClient.AboutClient.ClientId = ClientId;
            MessageWindowClient.AboutClient.Comment = Comment;
            MessageWindowClient.AboutClient.Name = Name;
            MessageWindowClient.AboutClient.ContactPerson = ContactPerson;
            MessageWindowClient.AboutClient.Address = Address;
            MessageWindowClient.AboutClient.Telephone = Telephone;
            MessageWindowClient.AboutClient.NIP = NIP;
            MessageWindowClient.AboutClient.Email = Email;

            //show window
            MessageWindowClient.IsOpen = true;

            if (MessageWindowClient.ToConfirm)
            {
                using (LaboratoryEntities context = new LaboratoryEntities())
                {
                    //finding selected client in database
                    var clientToEdit = (from c in context.clients
                                        where c.clientId == MessageWindowClient.AboutClient.ClientId
                                        select c).FirstOrDefault();


                    //modify data in database
                    if (MessageWindowClient.AboutClient.Name != ""
                        && MessageWindowClient.AboutClient.Address != ""
                        && MessageWindowClient.AboutClient.ContactPerson != ""
                        && MessageWindowClient.AboutClient.Email != ""
                        && MessageWindowClient.AboutClient.Telephone != ""
                        && MessageWindowClient.AboutClient.NIP != ""
                        && MessageWindowClient.AboutClient.Comment != "")
                    {

                        clientToEdit.name = MessageWindowClient.AboutClient.Name;
                        clientToEdit.adress = MessageWindowClient.AboutClient.Address;
                        clientToEdit.contact_person_name = MessageWindowClient.AboutClient.ContactPerson;
                        clientToEdit.mail = MessageWindowClient.AboutClient.Email;
                        clientToEdit.tel = MessageWindowClient.AboutClient.Telephone;
                        clientToEdit.NIP = MessageWindowClient.AboutClient.NIP;
                        clientToEdit.comments = MessageWindowClient.AboutClient.Comment;

                        context.SaveChanges();

                        //set new data in main window view
                        Name = MessageWindowClient.AboutClient.Name;
                        Address = MessageWindowClient.AboutClient.Address;
                        ContactPerson = MessageWindowClient.AboutClient.ContactPerson;
                        Email = MessageWindowClient.AboutClient.Email;
                        Telephone = MessageWindowClient.AboutClient.Telephone;
                        NIP = MessageWindowClient.AboutClient.NIP;
                        Comment = MessageWindowClient.AboutClient.Comment;
                    }
                    else
                    {
                        MessageBox.Show("Wypełnij wszystkie pola");
                    }

                }
                MessageWindowClient.ToConfirm = false;
                MainWindowViewModel.LoadView();
            }
        }

        public ICommand AddCommand
        { get { return new SimpleRelayCommand(AddOfficeExecute); } }

        private void AddOfficeExecute()
        {
            MessageWindowOffice = new NewWindowOffice() { AboutOffice = new InformationAboutOffice() };
            
            //open a new modal window
            messageWindowOffice.IsOpen = true;

            if (MessageWindowOffice.ToConfirm)
            {
                office officeToAddToDatabase = new office();
                officeToAddToDatabase.adress = MessageWindowOffice.AboutOffice.Address;
                officeToAddToDatabase.mail = MessageWindowOffice.AboutOffice.Email;
                officeToAddToDatabase.contact_person_name = MessageWindowOffice.AboutOffice.ContactPerson;
                officeToAddToDatabase.name = MessageWindowOffice.AboutOffice.Name;
                officeToAddToDatabase.tel = MessageWindowOffice.AboutOffice.Telephone;
                officeToAddToDatabase.client_id = this.ClientId;

                using (LaboratoryEntities context = new LaboratoryEntities())
                {
                    context.offices.Add(officeToAddToDatabase);
                    context.SaveChanges();
                }
                MessageBox.Show("Oddział został dodany do bazy.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);

                //var index = AllItems.IndexOf(AllItems.Last()) + 1;
                //AllItems.Remove((client)SelectedNode);
                ////Add new client to TreeView
                //AllItems.Insert(index+1, newClient);
                MainWindowViewModel.LoadView();
            }
            else
            { }

            MessageWindowOffice.ToConfirm = false;
            
        }
    }
}
