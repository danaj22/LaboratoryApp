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
        public int OfficeId { get; set; }
        public string Name { get; set; }      
        public string Address { get; set; }        
        public string ContactPerson { get; set; }        
        public string Email { get; set; }
        public string Telephone { get; set; }
       
        public ICommand DeleteCommand
        { get { return new SimpleRelayCommand(DeleteOffice); } }

        private void DeleteOffice()
        {
            var result = MessageBox.Show("Czy na pewno chcesz usunąć bezzwłocznie i definitywnie ten oddział?", "aaaaa", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                using(laboratoryEntities context = new laboratoryEntities())
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
        { get { return new SimpleRelayCommand(EditOffice); } }

        private void EditOffice()
        {
            //create a new modal window
            InformationAboutOffice infoOffice = this;
            View.ModalWindowOffice newModal = new View.ModalWindowOffice(infoOffice);

            //set owner of this window
            newModal.Owner = Application.Current.MainWindow;
            newModal.ShowDialog();

            if(newModal.DialogResult == true)
            {
                using (laboratoryEntities context = new laboratoryEntities())
                {
                    var officeToEdit = (from o in context.offices
                                        where o.officeId == this.OfficeId
                                        select o).FirstOrDefault();

                    if (Name != "" && Address != "" && ContactPerson != "" && Email != "" && Telephone != "")
                    {
                        officeToEdit.name = Name;
                        officeToEdit.adress = Address;
                        officeToEdit.contact_person_name = ContactPerson;
                        officeToEdit.mail = Email;
                        officeToEdit.tel = Telephone;

                        context.SaveChanges();
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
