using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaboratoryApp.ViewModel;
using System.Windows.Input;
using System.Windows;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowClient :ObservableObject//:DialogWindowBase
    {
        

        //public View.ModalWindowClient MWindow;

        public InformationAboutClient AboutClient = null; //{get; set;}
        //public View.ModalWindowClient MWindow;
        public NewWindowClient()
        { }

        public NewWindowClient(View.ModalWindowClient window)// : base(window)
        {
        //    //laboratoryEntities context = new laboratoryEntities();
        //    //MWindow = window;
        //    //MWindow.infoClient = AboutClient = new InformationAboutClient();

        //    //AboutGauge = new InformationAboutGauge();
        }
        
    }
}
