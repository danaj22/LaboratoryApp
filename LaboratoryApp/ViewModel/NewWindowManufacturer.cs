using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowManufacturer : ObservableObject
    {
        public NewWindowManufacturer()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);

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
            if (!this.ToConfirm) ToConfirm = true;

            IsOpen = false;

        }
        public void Close()
        {
            IsOpen = false;
        }

        private string nameOfManufacturer;

        public string NameOfManufacturer
        {
            get { return nameOfManufacturer; }
            set
            {
                nameOfManufacturer = value;
                OnPropertyChanged("NameOfManufacturer");
            }
        }
    }
}
