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
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string NIP { get; set; }
        public string Comment { get; set; }

        public ICommand DeleteCommand
        { get { return new SimpleRelayCommand(DeleteClient); } }

        private void DeleteClient()
        {
            var result = MessageBox.Show("Czy na pewno chcesz usunąć bezzwłocznie i definitywnie tego klienta?","Usuwanie klienta",MessageBoxButton.YesNo,MessageBoxImage.Question);
            
            if(result == MessageBoxResult.Yes)
            {
                laboratoryEntities context = new laboratoryEntities();
                //delete selected client
                var clientToDelete = (from c in context.clients
                                      where c.clientId == this.ClientId
                                      select c).FirstOrDefault();

                context.clients.Remove(clientToDelete);
                context.SaveChanges();
            }
        }
        public ICommand EditCommand
        { get { return new SimpleRelayCommand(EditClient);} }

        private void EditClient()
        {
            //create a new modal window
            InformationAboutClient infoClient = this;
            View.ModalWindowClient newModal = new View.ModalWindowClient(infoClient);

            //set owner of this window
            newModal.Owner = Application.Current.MainWindow;
            newModal.ShowDialog();

            if (newModal.DialogResult == true) 
            {
                using(laboratoryEntities context = new laboratoryEntities() )
                {
                    var clientToEdit = (from c in context.clients
                                        where c.clientId == this.ClientId
                                        select c).FirstOrDefault();
                    context.clients.Attach(clientToEdit);
                    
                    if(Name != "" && Address != "" && ContactPerson != "" && Email != "" && Telephone != "" && NIP != "" && Comment != "")
                    {
                        clientToEdit.name = Name;
                        clientToEdit.adress = Address;
                        clientToEdit.contact_person_name = ContactPerson;
                        clientToEdit.mail = Email;
                        clientToEdit.tel = Telephone;
                        clientToEdit.NIP = NIP;
                        clientToEdit.comments = Comment;

                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Wypełnij wszystkie pola");
                    }

                }
            }
        }

        public ICommand AddCommand
        { get { return new SimpleRelayCommand(AddOffice); } }

        private void AddOffice()
        {
            //create a new modal window

            View.ModalWindowOffice newModal = new View.ModalWindowOffice();

            //set owner of this window
            newModal.Owner = Application.Current.MainWindow;
            newModal.ShowDialog();

            if (newModal.DialogResult == true)
            {
                MessageBox.Show(newModal.DialogResult.ToString());
                var newOffice = new office();
                newOffice.name = newModal.infoOffice.Name;
                newOffice.adress = newModal.infoOffice.Address;
                newOffice.contact_person_name = newModal.infoOffice.ContactPerson;
                newOffice.mail = newModal.infoOffice.Email;
                newOffice.tel = newModal.infoOffice.Telephone;
                newOffice.client_id = this.ClientId;

                using (laboratoryEntities context = new laboratoryEntities())
                {

                    context.offices.Add(newOffice);
                    context.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show(newModal.DialogResult.ToString());
            }
        }
    }
}
