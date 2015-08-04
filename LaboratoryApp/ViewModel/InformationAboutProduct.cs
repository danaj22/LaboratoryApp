using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class InformationAboutProduct : ObservableObject
    {
        public int ProductId { get; set; }
        public int SerialNumber { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<int> OfficeId { get; set; }
        public Nullable<int> GaugeId { get; set; }

        public virtual gauge Gauge { get; set; }
        public virtual office Office { get; set; }

        public InformationAboutProduct()
        { }


        public ICommand DeleteCommand
        { get { return new SimpleRelayCommand(DeleteProduct); } }

        private void DeleteProduct()
        {
            var result = MessageBox.Show("Czy na pewno chcesz usunąć bezzwłocznie i definitywnie ten produkt?", "Usuwanie produktu", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                laboratoryEntities context = new laboratoryEntities();
                //delete selected client
                var productToDelete = (from p in context.products
                                      where p.productId == this.ProductId
                                      select p).FirstOrDefault();

                context.products.Remove(productToDelete);
                context.SaveChanges();
            }
        }
        public ICommand EditCommand
        { get { return new SimpleRelayCommand(EditProduct); } }

        private void EditProduct()
        {
            //create a new modal window
            InformationAboutProduct infoProduct = this;
            View.ModalWindowProduct newModal = new View.ModalWindowProduct(infoProduct);

            //set owner of this window
            newModal.Owner = Application.Current.MainWindow;
            newModal.ShowDialog();

            if (newModal.DialogResult == true)
            {
                using (laboratoryEntities context = new laboratoryEntities())
                {
                    var productToEdit = (from p in context.products
                                        where p.productId == this.ProductId
                                        select p).FirstOrDefault();

                    if (SerialNumber != null && Gauge != null && Office != null)
                    {
                        productToEdit.serial_number = SerialNumber;
                        //productToEdit.adress = Address;
                        //productToEdit.contact_person_name = ContactPerson;
                        //productToEdit.mail = Email;
                        //productToEdit.tel = Telephone;
                        //productToEdit.NIP = NIP;
                        //productToEdit.comments = Comment;

                        //context.SaveChanges();
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
