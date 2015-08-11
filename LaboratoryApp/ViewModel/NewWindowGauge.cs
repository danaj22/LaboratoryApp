using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowGauge:ObservableObject
    {
        //public View.ModalWindowProduct MWindow;
        private InformationAboutGauge aboutGauge;

        public InformationAboutGauge AboutGauge
        {
            get { return aboutGauge; }
            set 
            { 
                aboutGauge = value;
                OnPropertyChanged("AboutGauge");
            }
        }


        public NewWindowGauge()
        {
            aboutGauge = new InformationAboutGauge();
        }

        public NewWindowGauge(View.ModalWindowProduct window)//:base(window)
        {
            //LaboratoryEntities context = new LaboratoryEntities();
            //MWindow = window;
            //MWindow.infoProduct = AboutGauge = new InformationAboutGauge();

        }

    }
}
