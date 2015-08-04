using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaboratoryApp.ViewModel;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowClient: ResultFromModalWindowBase
    {
        public View.ModalWindowClient MWindow;

        public InformationAboutClient AboutClient {get; set;}
        //public View.ModalWindowClient MWindow;

        public NewWindowClient(View.ModalWindowClient window) : base(window)
        {
            laboratoryEntities context = new laboratoryEntities();
            MWindow = window;
            MWindow.infoClient = AboutClient = new InformationAboutClient();

            //AboutGauge = new InformationAboutGauge();
        }
        
    }
}
