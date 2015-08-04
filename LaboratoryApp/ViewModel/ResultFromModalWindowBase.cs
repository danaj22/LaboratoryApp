using LaboratoryApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class ResultFromModalWindowBase : Window
    {
        public IModalWindow MWindow;
        public ICommand ConfirmCommand
        {
            get
            {
                return new SimpleRelayCommand(ConfirmDialog);
            }
        }
        private void ConfirmDialog()
        {
            // dialog result set as 'true'
            if (MWindow is ModalWindowOffice)
            {
                var t = MWindow as View.ModalWindowOffice;
                t.DialogResult = true;
            }
            else if (MWindow is ModalWindowClient)
            {
                var t = MWindow as ModalWindowClient;
                t.DialogResult = true;
            }
            else if (MWindow is ModalWindowGauge)
            {
                var t = MWindow as ModalWindowGauge;
                t.DialogResult = true;
            }
            else if (MWindow is ModalWindowProduct)
            {
                var t = MWindow as ModalWindowProduct;
                t.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Błąd. Brak takiego okna w ModalWindow.....");
            }
            
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
            
            //this = new ResultFromModalWindowBase();
            
            //dialog result as 'false'

            if(MWindow is ModalWindowOffice)
            {
                var t = MWindow as View.ModalWindowOffice;
                t.DialogResult = false;
            }
            else if(MWindow is ModalWindowClient)
            {
                var t = MWindow as ModalWindowClient;
                t.DialogResult = false;
            }
            else if (MWindow is ModalWindowGauge)
            {
                var t = MWindow as ModalWindowGauge;
                t.DialogResult = false;
            }
            else if(MWindow is ModalWindowProduct)
            {
                var t = MWindow as ModalWindowProduct;
                t.DialogResult = false;
            }
            else
            {
                MessageBox.Show("Błąd. Brak takiego okna w ModalWindow.....");
            }
            
        }


        public ResultFromModalWindowBase(IModalWindow window)
        {
            MWindow = window;

        }

        public ResultFromModalWindowBase()
        { }
    }
}
