using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowGauge
    {
        //public View.ModalWindowGauge MWindow;

        public InformationAboutGauge AboutGauge { get; set; }

        public NewWindowGauge()
        { }

        public NewWindowGauge(Window window) //: base (window)
        {
            //laboratoryEntities context = new laboratoryEntities();
            //MWindow = window;
            //MWindow.infoGauge = AboutGauge = new InformationAboutGauge();

            //foreach(var tmp in context.usages)
            //{

            //    AboutGauge.CollectionOfUsage.Add(tmp);
            //}
            //AboutGauge = new InformationAboutGauge();
        }

    }
}
