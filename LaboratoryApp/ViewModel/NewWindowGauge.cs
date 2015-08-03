using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowGauge:ObservableObject
    {
        public View.ModalWindowGauge MWindow;

        public InformationAboutGauge AboutGauge { get; set; }

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


        public NewWindowGauge(View.ModalWindowGauge window)
        {
            laboratoryEntities context = new laboratoryEntities();
            MWindow = window;
            MWindow.infoGauge = AboutGauge = new InformationAboutGauge();

            foreach(var tmp in context.usages)
            {

                CollectionOfUsage.Add(tmp);
            }
            //AboutGauge = new InformationAboutGauge();
        }

        public ICommand ConfirmCommand
        {
            get
            {
                return new SimpleRelayCommand(ConfirmDialog);
            }
        }
        private void ConfirmDialog()
        {
            //dialog result set as 'true'
            MWindow.DialogResult = true;
        }

        public ICommand CancelCommand
        {
            get
            {
                return new SimpleRelayCommand(CancelDialog);
            }
        }

        public void CancelDialog()
        {
            //dialog result as 'false'
            MWindow.DialogResult = false;

        }


    }
}
