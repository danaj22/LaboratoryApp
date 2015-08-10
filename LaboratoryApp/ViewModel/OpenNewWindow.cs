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
        //public View.ModalWindowClient MWindow;
        //public View.ModalWindowClient MEditWindow;


        public OpenNewWindow()
        {
            //MWindow = new View.ModalWindowClient();
            //MWindow.Owner = Application.Current.MainWindow;
           // this.MWindow.Owner = Application.Current.MainWindow;
        }
        //public OpenNewWindow(View.ModalWindowClient window)
        //{
        //    MWindow = window;
        //}

        //public InformationAboutClient Cli { get; set; }

        //public ICommand ConfirmCommand
        //{
        //    get
        //    {
        //        return new SimpleRelayCommand(ConfirmDialog);
        //    }
        //}
        //private void ConfirmDialog()
        //{
        //    MWindow.DialogResult = true;
        //}

        //public ICommand CancelCommand
        //{
        //    get
        //    {
        //        return new SimpleRelayCommand(CancelDialog);
        //    }
        //}

        //public void CancelDialog()
        //{
        //    MWindow.DialogResult = false;
            
        //}
    }
}
