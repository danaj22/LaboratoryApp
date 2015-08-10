using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowOffice
    {
        public InformationAboutOffice AboutOffice { get; set; }
        //public View.ModalWindowOffice MWindow;

        public NewWindowOffice()
        { }

        public NewWindowOffice(View.ModalWindowOffice window)// : base(window)
        {
            //MWindow = window;
            //MWindow.infoOffice = AboutOffice = new InformationAboutOffice();
        
        }

       
    }
}
