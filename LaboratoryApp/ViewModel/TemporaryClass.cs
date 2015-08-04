using LaboratoryApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryApp
{
    public class TemporaryClass:ObservableObject
    {
        public bool? WindowCloseResult 
        { 
            get
            { 
                return WindowCloseResult;
            }
            set
            {
                WindowCloseResult = value;
                OnPropertyChanged("WindowCloseResult");
            }
        }

        public virtual void Cancel()
        { }
        public virtual void Confirm()
        { }
        
        public ICommand ConfirmCommand
        {
            get
            {
                return new SimpleRelayCommand(ConfirmDialog);
            }
        }
        private void ConfirmDialog()
        {
           // DialogResult = true;
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
            //DialogResult = false;
        }
    }
}
