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
        {   }

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
            }
        }
        public ICommand EditCommand
        { get { return new SimpleRelayCommand(EditClientExecute);} }

        private void EditClientExecute()
        {
            //create a new modal window
            DialogWindowBase newBaseWindow = new DialogWindowBase();
            NewWindowClient clientDialogWindow = new NewWindowClient() { AboutClient = new InformationAboutClient() };


            //filling in the data fields in new window
            clientDialogWindow.AboutClient.Comment = Comment;
            clientDialogWindow.AboutClient.Name = Name;
            clientDialogWindow.AboutClient.ContactPerson = ContactPerson;
            clientDialogWindow.AboutClient.Address = Address;
            clientDialogWindow.AboutClient.Telephone = Telephone;
            clientDialogWindow.AboutClient.NIP = NIP;
            clientDialogWindow.AboutClient.Email = Email;

            //filling the window contents
            newBaseWindow.BaseContent = clientDialogWindow;

            WindowService w = new WindowService();
            w.DataContext = newBaseWindow;
            w.Owner = Application.Current.MainWindow;
            w.ShowDialog();

            if (w.DialogResult == true)
            {
                using (LaboratoryEntities context = new LaboratoryEntities())
                {
                    //finding selected client in database
                    var clientToEdit = (from c in context.clients
                                        where c.clientId == this.ClientId
                                        select c).FirstOrDefault();
                    

                    //modify data in database
                    if (clientDialogWindow.AboutClient.Name != ""
                        && clientDialogWindow.AboutClient.Address != ""
                        && clientDialogWindow.AboutClient.ContactPerson != ""
                        && clientDialogWindow.AboutClient.Email != ""
                        && clientDialogWindow.AboutClient.Telephone != ""
                        && clientDialogWindow.AboutClient.NIP != ""
                        && clientDialogWindow.AboutClient.Comment != "")
                    {
                        
                        clientToEdit.name = clientDialogWindow.AboutClient.Name;
                        clientToEdit.adress = clientDialogWindow.AboutClient.Address;
                        clientToEdit.contact_person_name = clientDialogWindow.AboutClient.ContactPerson;
                        clientToEdit.mail = clientDialogWindow.AboutClient.Email;
                        clientToEdit.tel = clientDialogWindow.AboutClient.Telephone;
                        clientToEdit.NIP = clientDialogWindow.AboutClient.NIP;
                        clientToEdit.comments = clientDialogWindow.AboutClient.Comment;

                        context.SaveChanges();

                        //set new data in main window view
                        Name = clientDialogWindow.AboutClient.Name;
                        Address = clientDialogWindow.AboutClient.Address;
                        ContactPerson = clientDialogWindow.AboutClient.ContactPerson;
                        Email = clientDialogWindow.AboutClient.Email;
                        Telephone = clientDialogWindow.AboutClient.Telephone;
                        NIP = clientDialogWindow.AboutClient.NIP;
                        Comment = clientDialogWindow.AboutClient.Comment;
                    }
                    else
                    {
                        MessageBox.Show("Wypełnij wszystkie pola");
                    }

                }
            }


            //View.ModalWindowClient newModal = new View.ModalWindowClient(infoClient);

            ////set owner of this window
            //newModal.Owner = Application.Current.MainWindow;
            //newModal.ShowDialog();

            //if (newModal.DialogResult == true) 
            //{
            //    using(LaboratoryEntities context = new LaboratoryEntities() )
            //    {
            //        var clientToEdit = (from c in context.clients
            //                            where c.clientId == this.ClientId
            //                            select c).FirstOrDefault();
            //        context.clients.Attach(clientToEdit);
                    
            //        if(Name != "" && Address != "" && ContactPerson != "" && Email != "" && Telephone != "" && NIP != "" && Comment != "")
            //        {
            //            clientToEdit.name = Name;
            //            clientToEdit.adress = Address;
            //            clientToEdit.contact_person_name = ContactPerson;
            //            clientToEdit.mail = Email;
            //            clientToEdit.tel = Telephone;
            //            clientToEdit.NIP = NIP;
            //            clientToEdit.comments = Comment;

            //            context.SaveChanges();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Wypełnij wszystkie pola");
            //        }

            //    }
            //}
        }

        public ICommand AddCommand
        { get { return new SimpleRelayCommand(AddOfficeExecute); } }

        private void AddOfficeExecute()
        {
            //create a new modal window

            DialogWindowBase newBaseWindow = new DialogWindowBase();
            NewWindowOffice officeDialogWindow = new NewWindowOffice() { AboutOffice = new InformationAboutOffice() };

            newBaseWindow.BaseContent = officeDialogWindow;

            WindowService w = new WindowService();
            w.DataContext = newBaseWindow;
            w.Owner = Application.Current.MainWindow;
            w.ShowDialog();
            bool? result = w.DialogResult;
            
            if (result == true)
            {
                office officeToAddToDatabase = new office();
                officeToAddToDatabase.adress = officeDialogWindow.AboutOffice.Address;
                officeToAddToDatabase.mail = officeDialogWindow.AboutOffice.Email;
                officeToAddToDatabase.contact_person_name = officeDialogWindow.AboutOffice.ContactPerson;
                officeToAddToDatabase.name = officeDialogWindow.AboutOffice.Name;
                officeToAddToDatabase.tel = officeDialogWindow.AboutOffice.Telephone;
                officeToAddToDatabase.client_id = this.ClientId;

                using(LaboratoryEntities context = new LaboratoryEntities())
                {
                    context.offices.Add(officeToAddToDatabase);
                    context.SaveChanges();
                }
                MessageBox.Show("Oddział został dodany do bazy.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {

            }
            
        }
    }
}
