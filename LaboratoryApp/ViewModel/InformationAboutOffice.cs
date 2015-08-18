using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaboratoryApp.View;
using System.Windows.Input;
using LaboratoryApp;
using System.Windows;

namespace LaboratoryApp.ViewModel
{
    public class InformationAboutOffice: ObservableObject
    {
        private int officeId;
        public int OfficeId
        {
            get { return officeId; }
            set 
            {
                officeId = value;
                OnPropertyChanged("OfficeId");
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

        private int? clientIdToAdd;

        public int? ClientIdToAdd
        {
            get { return clientIdToAdd; }
            set 
            { 
                clientIdToAdd = value;
                OnPropertyChanged("ClientIdToAdd");
            }
        }
        private int? officeIdToAdd;

        public int? OfficeIdToAdd
        {
            get { return officeIdToAdd; }
            set
            {
                officeIdToAdd = value;
                OnPropertyChanged("OfficeIdToAdd");
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

        public ICommand DeleteOfficeCommand
        { get { return new SimpleRelayCommand(DeleteOfficeExecute); } }

        private void DeleteOfficeExecute()
        {
            var result = MessageBox.Show("Czy na pewno chcesz usunąć bezzwłocznie i definitywnie ten oddział?", "Usuwanie oddziału", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                using(LaboratoryEntities context = new LaboratoryEntities())
                {
                    //delete selected client
                    var officeToDelete = (from o in context.offices
                                           where o.officeId == this.OfficeId
                                           select o).FirstOrDefault();

                    context.offices.Remove(officeToDelete);
                    context.SaveChanges();
                }
                MainWindowViewModel.LoadView();
            }
        }

        public ICommand EditOfficeCommand
        { get { return new SimpleRelayCommand(EditOfficeExecute); } }

        private void EditOfficeExecute()
        {
            MessageWindowOffice = new NewWindowOffice() { AboutOffice = new InformationAboutOffice() };
            

            MessageWindowOffice.AboutOffice.OfficeId = OfficeId;

            MessageWindowOffice.AboutOffice.Name = Name;
            MessageWindowOffice.AboutOffice.ContactPerson = ContactPerson;
            MessageWindowOffice.AboutOffice.Address = Address;
            MessageWindowOffice.AboutOffice.Telephone = Telephone;
            MessageWindowOffice.AboutOffice.Email = Email;

            MessageWindowOffice.IsOpen = true;

            if (MessageWindowOffice.ToConfirm)
            {
                using (LaboratoryEntities context = new LaboratoryEntities())
                {
                    //find selected office in database
                    var officeToEdit = (from o in context.offices
                                        where o.officeId == this.OfficeId
                                        select o).FirstOrDefault();

                    //modify data in database
                    if (Name != "" && Address != "" && ContactPerson != "" && Email != "" && Telephone != "")
                    {
                        officeToEdit.name = MessageWindowOffice.AboutOffice.Name;
                        officeToEdit.adress = MessageWindowOffice.AboutOffice.Address;
                        officeToEdit.contact_person_name = MessageWindowOffice.AboutOffice.ContactPerson;
                        officeToEdit.mail = MessageWindowOffice.AboutOffice.Email;
                        officeToEdit.tel = MessageWindowOffice.AboutOffice.Telephone;

                        context.SaveChanges();

                        //set new data in main window view
                        Name = MessageWindowOffice.AboutOffice.Name;
                        ContactPerson = MessageWindowOffice.AboutOffice.ContactPerson;
                        Address = MessageWindowOffice.AboutOffice.Address;
                        Telephone = MessageWindowOffice.AboutOffice.Telephone;
                        Email = MessageWindowOffice.AboutOffice.Email;
                    }
                    else
                    {
                        MessageBox.Show("Wypełnij wszystkie pola");
                    }

                }
                MessageWindowOffice.ToConfirm = false;
                MainWindowViewModel.LoadView();
            }


        }
    }
}
