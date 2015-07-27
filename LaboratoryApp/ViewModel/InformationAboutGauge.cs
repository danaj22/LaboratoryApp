using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaboratoryApp.View;

namespace LaboratoryApp
{
    class InformationAboutGauge : ObservableObject
    {
        public InformationAboutGauge(InformationAboutGaugeView model)
        {
            this.Model = model;
        }
        public InformationAboutGaugeView Model { get; set; }

        public string ModelName
        {
            get
            {
                return this.Model.ModelName;
            }
            set
            {
                this.Model.ModelName = value;
                this.OnPropertyChanged("ModelName");
            }
        }
        public string ManufacturerName
        {
            get
            {
                return this.Model.ManufacturerName;
            }
            set
            {
                this.Model.ManufacturerName = value;
                this.OnPropertyChanged("ManufacturerName");
            }
        }

        public int SerialNumber
        {
            get
            {
                return this.Model.SerialNumber;
            }
            set
            {
                this.Model.SerialNumber = value;
                this.OnPropertyChanged("SerialNumber");
            }
        }

    }
}
