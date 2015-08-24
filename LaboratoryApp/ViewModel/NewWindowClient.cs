using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaboratoryApp.ViewModel;
using System.Windows.Input;
using System.Windows;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowClient :ObservableObject//:DialogWindowBase
    {
        

        //public View.ModalWindowClient MWindow;

        private client aboutClient;

        public client AboutClient
        {
            get { return aboutClient; }
            set 
            { 
                aboutClient = value;
                OnPropertyChanged("AboutClient");
            }
        }
        //public View.ModalWindowClient MWindow;
        public NewWindowClient()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            AboutClient = new client();
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
            if (!ToConfirm) ToConfirm = true;
            IsOpen = false;
 
        }
        public void Close()
        {
            IsOpen = false;
        }

        
    }
}
