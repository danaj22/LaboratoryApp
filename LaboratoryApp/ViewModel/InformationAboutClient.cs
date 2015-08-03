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
        public InformationAboutClient(InformationAboutClientView model)
        {
            this.Model = model;
        }
        public InformationAboutClientView Model { get; set; }
        public string Name 
        {
            get
            {
                return this.Model.Name;
            }
            set
            {
                this.Model.Name = value;
                this.OnPropertyChanged("Name");
            }
        }
        public string Address
        {
            get
            {
                return this.Model.Address;
            }
            set
            {
                this.Model.Address = value;
                this.OnPropertyChanged("Address");
            }
        }
        public string ContactPerson
        {
            get
            {
                return this.Model.ContactPerson;
            }
            set
            {
                this.Model.ContactPerson = value;
                this.OnPropertyChanged("ContactPerson");
            }
        }
        public string Email
        {
            get
            {
                return this.Model.Email;
            }
            set
            {
                this.Model.Email = value;
                this.OnPropertyChanged("Email");
            }
        }
        public string Telephone
        {
            get
            {
                return this.Model.Telephone;
            }
            set
            {
                this.Model.Telephone = value;
                this.OnPropertyChanged("Telephone");
            }
        }
        public string NIP
        {
            get
            {
                return this.Model.NIP;
            }
            set
            {
                this.Model.NIP = value;
                this.OnPropertyChanged("NIP");
            }
        }
        public string Comment
        {
            get
            {
                return this.Model.Comment;
            }
            set
            {
                this.Model.Comment = value;
                this.OnPropertyChanged("Comment");
            }
        }

        public ICommand DeleteCommand
        { get { return new SimpleRelayCommand(DeleteClient); } }

        private void DeleteClient()
        {
            var result = MessageBox.Show("Czy na pewno chcesz usunąć bezzwłocznie i definitywnie tego klienta?","aaaaa",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if(result == MessageBoxResult.No)
            {
                laboratoryEntities context = new laboratoryEntities();
                //delete selected client
                //context.clients.Remove();
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



        }

    }
}
