using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowOffice : ResultFromModalWindowBase
    {
        public InformationAboutOffice AboutOffice { get; set; }
        public View.ModalWindowOffice MWindow;

        public NewWindowOffice(View.ModalWindowOffice window)
        {
            MWindow = window;
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
