using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class InformationAboutGauge : ObservableObject
    {
        public int GaugeId { get; set; }
        public int SerialNumber { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<int> OfficeId { get; set; }
        public Nullable<int> ModalOfGaugeId { get; set; }

        public virtual gauge Gauge { get; set; }
        public virtual office Office { get; set; }

        List<string> collectionOfManufacturers;

        public List<string> CollectionOfManufacturers
        {
            get { return this.collectionOfManufacturers; }
            set 
            {
                collectionOfManufacturers = value;
                OnPropertyChanged("CollectionOfManufacturers");
            }

        }

        private void InitializeCollectionOfManufacturers()
        {
            LaboratoryEntities context = new LaboratoryEntities();
            collectionOfManufacturers = (from m in context.gauges select m.manufacturer_name).ToList();

        }


        private string selectedManufacturer;

        public string SelectedManufacturer
        {
            get { return selectedManufacturer; }
            set 
            { 
                selectedManufacturer = value;
                InitializeCollectionOfModels();
                OnPropertyChanged("SelectedManufacturer");
            }
        }

        public List<string> modelList;

        private void InitializeCollectionOfModels()
        {
            if(SelectedManufacturer != null)
            {
                LaboratoryEntities context = new LaboratoryEntities();
                var getManufacturer = context.gauges.FirstOrDefault( g => g.manufacturer_name == selectedManufacturer);
                modelList = (from g in context.gauges where g.gaugeId == getManufacturer.gaugeId select g.model).ToList();
                
            }
        }


        List<string> collectionOfModels;

        public List<string> CollectionOfModels
        {
          get { return modelList; }
          set 
          { 
              //collectionOfModels = value;
              InitializeCollectionOfModels();
              OnPropertyChanged("CollectionOfModels");
          }
        }
        private string selectedModel;

        public string SelectedModel
        {
            get { return selectedModel; }
            set
            {
                selectedModel = value;
                OnPropertyChanged("SelectedModel");
            }

        }


        public InformationAboutGauge()
        {
            InitializeCollectionOfManufacturers();
            //collectionOfModels = new List<string>();
            //collectionOfManufacturers = new List<string>();
        }


        public ICommand DeleteCommand
        { get { return new SimpleRelayCommand(DeleteProduct); } }

        private void DeleteProduct()
        {
            var result = MessageBox.Show("Czy na pewno chcesz usunąć bezzwłocznie i definitywnie ten produkt?", "Usuwanie produktu", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                LaboratoryEntities context = new LaboratoryEntities();
                //delete selected client
                var productToDelete = (from p in context.products
                                      where p.productId == this.GaugeId
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
            InformationAboutGauge infoProduct = this;
            View.ModalWindowProduct newModal = new View.ModalWindowProduct(infoProduct);

            //set owner of this window
            newModal.Owner = Application.Current.MainWindow;
            newModal.ShowDialog();

            if (newModal.DialogResult == true)
            {
                using (LaboratoryEntities context = new LaboratoryEntities())
                {
                    var productToEdit = (from p in context.products
                                        where p.productId == this.GaugeId
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
