using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls; // Validation
using System.Windows.Input; // Keyboard
using LaboratoryApp;

namespace LaboratoryApp.ViewModel
{
    public partial class OpenNewWindow:Window
    {

        public View.ModalWindowAddClient MWindow;
        public bool Result { get; set; }
        
        public virtual void Cancel()
        { }
        public virtual void Confirm()
        { }

        
        //public OpenNewWindow()
        //{}

        public ICommand ConfirmCommand
        {
            get
            {
                return new SimpleRelayCommand(ConfirmDialog);
            }
        }
        private void ConfirmDialog()
        {
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
            MWindow.DialogResult = false;
        }
    }
}
