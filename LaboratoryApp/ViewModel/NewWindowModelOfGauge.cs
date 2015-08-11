using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowModelOfGauge
    {
        //public View.ModalWindowGauge MWindow;

        public InformationAboutModelOfGauge AboutModelOfGauge { get; set; }

        public NewWindowModelOfGauge()
        { }

        public NewWindowModelOfGauge(Window window) //: base (window)
        {
            //LaboratoryEntities context = new LaboratoryEntities();
            //MWindow = window;
            //MWindow.infoGauge = AboutModelOfGauge = new InformationAboutModelOfGauge();

            //foreach(var tmp in context.usages)
            //{

            //    AboutModelOfGauge.CollectionOfUsage.Add(tmp);
            //}
            //AboutModelOfGauge = new InformationAboutModelOfGauge();
        }

    }
}
