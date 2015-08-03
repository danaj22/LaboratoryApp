using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaboratoryApp.View;
using System.Windows.Input;
using LaboratoryApp.ViewModel;
using System.Windows;

namespace LaboratoryApp
{
    public class InformationAboutOffice: ObservableObject
    {
        public InformationAboutOffice(InformationAboutOfficeView model)
        {
            this.Model = model;
        }
        public InformationAboutOfficeView Model { get; set; }

        public string Name { 
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

        public ICommand DeleteCommand
        { get { return new SimpleRelayCommand(DeleteOffice); } }

        private void DeleteOffice()
        {
            var result = MessageBox.Show("Czy na pewno chcesz usunąć bezzwłocznie i definitywnie ten oddział?", "aaaaa", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                laboratoryEntities context = new laboratoryEntities();
                //delete selected office
                //context.offices.Remove();
            }
        }

        public ICommand EditCommand
        { get { return new SimpleRelayCommand(EditOffice); } }

        private void EditOffice()
        {
            //create a new modal window
            InformationAboutOffice infoOffice = this;
            View.ModalWindowOffice newModal = new View.ModalWindowOffice(infoOffice);

            //set owner of this window
            newModal.Owner = Application.Current.MainWindow;
            newModal.ShowDialog();



        }
    }
}
