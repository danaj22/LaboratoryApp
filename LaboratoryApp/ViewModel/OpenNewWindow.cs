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
        public virtual void Confirm()
        { }
        public virtual void Cancel()
        { }

        public OpenNewWindow()
        {

        }
        public ICommand CancelCommand
        {
            get
            {
                return new RelayCommand(CancelDialog, CanCancelDialog);
            }
        }
        private void CancelDialog()
        {

            this.Close();

        }

        private bool CanCancelDialog()
        { return true; }
    }
}
