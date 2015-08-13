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

        private void InitializeCollectionOfManufacturers()
        {
            LaboratoryEntities context = new LaboratoryEntities();
            CollectionOfManufacturers = (from m in context.gauges select m.manufacturer_name).Distinct().ToList();
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

        private void InitializeCollectionOfModels()
        {
            if(SelectedManufacturer != null)
            {
                LaboratoryEntities context = new LaboratoryEntities();               
                CollectionOfModels = (from g in context.gauges where g.manufacturer_name == SelectedManufacturer select g.model).ToList(); 
            }
        }


        List<string> collectionOfModels;

        public List<string> CollectionOfModels
        {
            get { return collectionOfModels; }
          set 
          { 
              collectionOfModels = value;
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


        public ICommand DeleteGaugeCommand
        { get { return new SimpleRelayCommand(DeleteGaugeExecute); } }

        private void DeleteGaugeExecute()
        {
            var result = MessageBox.Show("Czy na pewno chcesz usunąć bezzwłocznie i definitywnie ten miernik?", "Usuwanie miernika", MessageBoxButton.YesNo, MessageBoxImage.Question);

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
        public ICommand EditGaugeCommand
        { get { return new SimpleRelayCommand(EditGaugeExecute); } }

        private void EditGaugeExecute()
        {
            MessageWindowGauge = new NewWindowGauge() { AboutGauge = new InformationAboutGauge() { Gauge = new gauge() } };

            MessageWindowGauge.AboutGauge.SerialNumber = SerialNumber;
            MessageWindowGauge.AboutGauge.SelectedManufacturer = Gauge.manufacturer_name;
            MessageWindowGauge.AboutGauge.SelectedModel = Gauge.model;


            MessageWindowGauge.IsOpen = true;


            ////create a new modal window
            //InformationAboutGauge infoProduct = this;
            //View.ModalWindowProduct newModal = new View.ModalWindowProduct(infoProduct);

            ////set owner of this window
            //newModal.Owner = Application.Current.MainWindow;
            //newModal.ShowDialog();

            //if (newModal.DialogResult == true)
            //{
            //    using (LaboratoryEntities context = new LaboratoryEntities())
            //    {
            //        var productToEdit = (from p in context.products
            //                            where p.productId == this.GaugeId
            //                            select p).FirstOrDefault();

            //        if (SerialNumber != null && Gauge != null && Office != null)
            //        {
            //            productToEdit.serial_number = SerialNumber;
            //            //productToEdit.adress = Address;
            //            //productToEdit.contact_person_name = ContactPerson;
            //            //productToEdit.mail = Email;
            //            //productToEdit.tel = Telephone;
            //            //productToEdit.NIP = NIP;
            //            //productToEdit.comments = Comment;

            //            //context.SaveChanges();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Wypełnij wszystkie pola");
            //        }

            //    }
            //}
        }
    }
}
