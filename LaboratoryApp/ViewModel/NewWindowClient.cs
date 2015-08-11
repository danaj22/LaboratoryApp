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

        private InformationAboutClient aboutClient;

        public InformationAboutClient AboutClient
        {
            get { return aboutClient; }
            set 
            { 
                aboutClient = value;
                OnPropertyChanged("AboutClient");
            }
        }
        //public View.ModalWindowClient MWindow;
        public NewWindowClient()
        {
        }

        public NewWindowClient(View.ModalWindowClient window)// : base(window)
        {
        //    //LaboratoryEntities context = new LaboratoryEntities();
        //    //MWindow = window;
        //    //MWindow.infoClient = AboutClient = new InformationAboutClient();

        //    //AboutModelOfGauge = new InformationAboutModelOfGauge();
        }
        
    }
}
