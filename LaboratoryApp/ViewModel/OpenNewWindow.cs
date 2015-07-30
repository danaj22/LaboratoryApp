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
    public partial class OpenNewWindow
    {
        public View.ModalWindowAddClient MWindow;


        public OpenNewWindow()
        {
            //MWindow = new View.ModalWindowAddClient();
            //MWindow.Owner = Application.Current.MainWindow;
           // this.MWindow.Owner = Application.Current.MainWindow;
        }
        public OpenNewWindow(View.ModalWindowAddClient window)
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

        public TemporaryClass OpenCloseView{get; set;}

    }
}
