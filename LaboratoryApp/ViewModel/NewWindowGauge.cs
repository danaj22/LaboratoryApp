using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowGauge:ObservableObject
    {
        //public View.ModalWindowProduct MWindow;
        private InformationAboutGauge aboutGauge;

        public InformationAboutGauge AboutGauge
        {
            get { return aboutGauge; }
            set 
            { 
                aboutGauge = value;
                OnPropertyChanged("AboutGauge");
            }
        }


        public NewWindowGauge()
        {
            AboutGauge = new InformationAboutGauge();
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);

        }

        public NewWindowGauge(View.ModalWindowProduct window)//:base(window)
        {
            //LaboratoryEntities context = new LaboratoryEntities();
            //MWindow = window;
            //MWindow.infoProduct = AboutGauge = new InformationAboutGauge();

        }

        private ICommand okCommand;

        public ICommand OKCommand
        {
            get { return okCommand; }
            set
            {
                okCommand = value;
                base.OnPropertyChanged("OKCommand");
            }
        }
        private ICommand cancelCommand;

        public ICommand CancelCommand
        {
            get { return cancelCommand; }
            set
            {
                cancelCommand = value;
                OnPropertyChanged("CancelCommand");
            }
        }

        private bool isOpen;

        public bool IsOpen
        {
            get { return isOpen; }
            set
            {
                isOpen = value;
                base.OnPropertyChanged("IsOpen");
            }
        }

        private bool toConfirm;

        public bool ToConfirm
        {
            get { return toConfirm; }
            set
            {
                toConfirm = value;
                base.OnPropertyChanged("ToConfirm");
            }
        }

        public void Confirm()
        {
            //if (this.AboutClient.Name != null
            //    && this.AboutClient.Address != null
            //    && this.AboutClient.Email != null
            //    && this.AboutClient.Telephone != null
            //    && this.AboutClient.NIP != null
            //    && this.AboutClient.ContactPerson != null)
            //{

                
            //    using (LaboratoryEntities context = new LaboratoryEntities())
            //    {
            //        context.clients.Add(newClient);
            //        context.SaveChanges();
            //    }
            //    IsOpen = false;

            //}
            IsOpen = false;

        }
        public void Close()
        {
            IsOpen = false;
        }

    }
}
