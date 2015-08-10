using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowProduct 
    {
        //public View.ModalWindowProduct MWindow;
        public InformationAboutProduct AboutProduct { get; set; }

        public NewWindowProduct(View.ModalWindowProduct window)//:base(window)
        {
            //laboratoryEntities context = new laboratoryEntities();
            //MWindow = window;
            //MWindow.infoProduct = AboutProduct = new InformationAboutProduct();

        }

    }
}
