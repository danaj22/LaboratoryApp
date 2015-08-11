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

        public ICommand AddCommand
        { get { return new SimpleRelayCommand(AddExecute); } }

        private void AddExecute()
        {
            DialogWindowBase newBaseWindow = new DialogWindowBase();
            NewWindowGauge gaugeDialogWindow = new NewWindowGauge() { AboutGauge = new  InformationAboutGauge() };

            newBaseWindow.BaseContent = gaugeDialogWindow;

            WindowService w = new WindowService();
            w.DataContext = newBaseWindow;
            w.Owner = Application.Current.MainWindow;
            w.ShowDialog();
        }

        public ICommand DeleteCommand
        { get { return new SimpleRelayCommand(DeleteOfficeExecute); } }

        private void DeleteOfficeExecute()
        {
            var result = MessageBox.Show("Czy na pewno chcesz usunąć bezzwłocznie i definitywnie ten oddział?", "Usuwanie", MessageBoxButton.YesNo, MessageBoxImage.Question);
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
            }
        }

        public ICommand EditCommand
        { get { return new SimpleRelayCommand(EditOfficeExecute); } }

        private void EditOfficeExecute()
        {
            DialogWindowBase newBaseWindow = new DialogWindowBase();
            NewWindowOffice officeDialogWindow = new NewWindowOffice() { AboutOffice = new InformationAboutOffice() };

            
            officeDialogWindow.AboutOffice.Name = Name;
            officeDialogWindow.AboutOffice.ContactPerson = ContactPerson;
            officeDialogWindow.AboutOffice.Address = Address;
            officeDialogWindow.AboutOffice.Telephone = Telephone;
            officeDialogWindow.AboutOffice.Email = Email;
            

            newBaseWindow.BaseContent = officeDialogWindow;

            WindowService w = new WindowService();
            w.DataContext = newBaseWindow;
            w.Owner = Application.Current.MainWindow;
            w.ShowDialog();

            if(w.DialogResult == true)
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
                        officeToEdit.name = officeDialogWindow.AboutOffice.Name;
                        officeToEdit.adress = officeDialogWindow.AboutOffice.Address;
                        officeToEdit.contact_person_name = officeDialogWindow.AboutOffice.ContactPerson;
                        officeToEdit.mail = officeDialogWindow.AboutOffice.Email;
                        officeToEdit.tel = officeDialogWindow.AboutOffice.Telephone;

                        context.SaveChanges();

                        //set new data in main window view
                        Name = officeDialogWindow.AboutOffice.Name;
                        ContactPerson = officeDialogWindow.AboutOffice.ContactPerson;
                        Address = officeDialogWindow.AboutOffice.Address;
                        Telephone = officeDialogWindow.AboutOffice.Telephone;
                        Email = officeDialogWindow.AboutOffice.Email;
                    }
                    else
                    {
                        MessageBox.Show("Wypełnij wszystkie pola");
                    }

                }

            }


        }
    }
}
