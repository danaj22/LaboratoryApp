using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowModelOfGauge : ObservableObject

    {
        //public View.ModalWindowModelOfGauge MWindow;

        public InformationAboutModelOfGauge AboutModelOfGauge { get; set; }

        public NewWindowModelOfGauge()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
        }

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
        private ICommand okCommand;

        public ICommand OKCommand
        {
            get { return okCommand; }
            set
            {
                okCommand = value;
                base.OnPropertyChanged("OKCommand");
            }
        }
        private ICommand cancelCommand;

        public ICommand CancelCommand
        {
            get { return cancelCommand; }
            set
            {
                cancelCommand = value;
                base.OnPropertyChanged("CancelCommand");
            }
        }

        private bool isOpen;

        public bool IsOpen
        {
            get { return isOpen; }
            set
            {
                isOpen = value;
                base.OnPropertyChanged("IsOpen");
            }
        }

        private bool toConfirm;

        public bool ToConfirm
        {
            get { return toConfirm; }
            set
            {
                toConfirm = value;
                base.OnPropertyChanged("ToConfirm");
            }
        }

        public void Confirm()
        {
            if (this.AboutModelOfGauge.ManufacturerName != null)
            {
                var newGauge = new gauge();
                newGauge.manufacturer_name = this.AboutModelOfGauge.ManufacturerName;
                newGauge.model = this.AboutModelOfGauge.Model;
                newGauge.type_id = 1;
                newGauge.usage_id = 1;

                using (LaboratoryEntities context = new LaboratoryEntities())
                {

                    context.gauges.Add(newGauge);
                    context.SaveChanges();
                }

                IsOpen = false;
            }
            IsOpen = false;

        }
        public void Close()
        {
            IsOpen = false;
        }

    }
}
