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
        
        public int gaugeId { get; set; }
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
         

        //public string ModelName
        //{
        //    get
        //    {
        //        return this.Model.ModelName;
        //    }
        //    set
        //    {
        //        this.Model.ModelName = value;
        //        this.OnPropertyChanged("ModelName");
        //    }
        //}
        //public string ManufacturerName
        //{
        //    get
        //    {
        //        return this.Model.ManufacturerName;
        //    }
        //    set
        //    {
        //        this.Model.ManufacturerName = value;
        //        this.OnPropertyChanged("ManufacturerName");
        //    }
        //}

        //public int SerialNumber
        //{
        //    get
        //    {
        //        return this.Model.SerialNumber;
        //    }
        //    set
        //    {
        //        this.Model.SerialNumber = value;
        //        this.OnPropertyChanged("SerialNumber");
        //    }
        //}


        public ICommand DeleteCommand
        { get { return new SimpleRelayCommand(DeleteGauge); } }

        private void DeleteGauge()
        {
            var result = MessageBox.Show("Czy na pewno chcesz usunąć bezzwłocznie i definitywnie ten miernik?", "aaaaa", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                laboratoryEntities context = new laboratoryEntities();
                //delete selected Gauge
                //context.gauges.Remove();
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



        }
        
    }
}
