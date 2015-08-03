using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowGauge:ResultFromModalWindowBase
    {
        public View.ModalWindowGauge MWindow;

        public InformationAboutGauge AboutGauge { get; set; }

        public NewWindowGauge(View.ModalWindowGauge window)
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
