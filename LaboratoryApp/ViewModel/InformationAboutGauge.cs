using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaboratoryApp.View;
using System.Windows.Input;
using LaboratoryApp.ViewModel;
using System.Windows;
using System.Collections.ObjectModel;

namespace LaboratoryApp
{
    public class InformationAboutGauge : ObservableObject
    {
        public InformationAboutGauge()
        {
            this.Products = new ObservableCollection<product>();
        }
        
        public int GaugeId { get; set; }
        public string ManufacturerName
        {
            get;
            set;
        }
        public string Model { get; set; }
        public int UsageId { get; set; }
        public int TypeId { get; set; }
    
        public virtual type Type { get; set; }
        public virtual ObservableCollection<product> Products { get; set; }
        public virtual usage Usage { get; set; }

        private ObservableCollection<usage> collectionOfusage = new ObservableCollection<usage>();

        public ObservableCollection<usage> CollectionOfUsage
        {
            get { return collectionOfusage; }
            set
            {
                collectionOfusage = CollectionOfUsage;
                OnPropertyChanged("CollectionOfUsage");
            }
        }


        public ICommand DeleteCommand
        { get { return new SimpleRelayCommand(DeleteGauge); } }

        private void DeleteGauge()
        {
            var result = MessageBox.Show("Czy na pewno chcesz usunąć bezzwłocznie i definitywnie ten miernik?", "aaaaa", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                laboratoryEntities context = new laboratoryEntities();
                //delete selected client
                var gaugeToDelete = (from g in context.gauges
                                      where g.gaugeId == this.GaugeId
                                      select g).FirstOrDefault();

                context.gauges.Remove(gaugeToDelete);
                context.SaveChanges();
            }
        }

        public ICommand EditCommand
        { get { return new SimpleRelayCommand(EditGauge); } }

        private void EditGauge()
        {
            //create a new modal window
            InformationAboutGauge infoGauge = this;
            View.ModalWindowGauge newModal = new View.ModalWindowGauge(infoGauge);

            //set owner of this window
            newModal.Owner = Application.Current.MainWindow;
            newModal.ShowDialog();

            //if (newModal.DialogResult == true)
            //{
            //    using (laboratoryEntities context = new laboratoryEntities())
            //    {
            //        var gaugeToEdit = (from g in context.gauges
            //                            where g.gaugeId == this.GaugeId
            //                            select g).FirstOrDefault();

            //        if (ManufacturerName != "" && Address != "" && ContactPerson != "" && Email != "" && Telephone != "" && NIP != "" && Comment != "")
            //        {
            //            gaugeToEdit.name = Name;
            //            gaugeToEdit.adress = Address;
            //            gaugeToEdit.contact_person_name = ContactPerson;
            //            gaugeToEdit.mail = Email;
            //            gaugeToEdit.tel = Telephone;
            //            gaugeToEdit.NIP = NIP;
            //            gaugeToEdit.comments = Comment;

            //            context.SaveChanges();
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
