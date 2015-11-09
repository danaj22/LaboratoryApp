using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowTable1 : NewWindowTableTemplate
    {

        public NewWindowTable1()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);

        }

    }

    public class Measure1 : ObservableObject
    {
        private double idealValue;

        public double IdealValue
        {
            get { return idealValue; }
            set
            {
                idealValue = value;
                OnPropertyChanged("IdealValue");
                Difference = this.MeasureValue - this.IdealValue;
                this.DownMeasureError = this.MeasureValue - this.MeasureValue * this.Percent*0.01 - this.ImportantNumber - this.Constant;
                this.UpMeasureError = this.MeasureValue + this.MeasureValue * this.Percent*0.01 + this.ImportantNumber + this.Constant;
                this.ErrorInValue = this.IdealValue * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercent = ErrorInValue / IdealValue;
            }
        }
        private string prefix;

        public string Prefix
        {
            get { return prefix; }
            set
            {
                prefix = value;
                OnPropertyChanged("Prefix");
            }
        }

        private string prefix2;

        public string Prefix2
        {
            get { return prefix2; }
            set
            {
                prefix2 = value;
                OnPropertyChanged("Prefix2");
            }
        } 

        private double measureValue;

        public double MeasureValue
        {
            get { return measureValue; }
            set
            {

                measureValue = value;
                OnPropertyChanged("MeasureValue");
                Difference = this.MeasureValue - this.IdealValue;
                this.DownMeasureError = this.MeasureValue - this.MeasureValue * this.Percent * 0.01 - this.ImportantNumber - this.Constant;
                this.UpMeasureError = this.MeasureValue + this.MeasureValue * this.Percent * 0.01 + this.ImportantNumber + this.Constant;
                this.ErrorInValue = this.IdealValue * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercent = ErrorInValue / IdealValue;
            }
        }
        private double measureValue25V;

        public double MeasureValue25V
        {
            get { return measureValue25V; }
            set
            {

                measureValue25V = value;
                OnPropertyChanged("MeasureValue25V");
                Difference = this.MeasureValue25V - this.IdealValue;
                this.DownMeasureError = this.MeasureValue25V - this.MeasureValue25V * this.Percent * 0.01 - this.ImportantNumber - this.Constant;
                this.UpMeasureError = this.MeasureValue25V + this.MeasureValue25V * this.Percent * 0.01 + this.ImportantNumber + this.Constant;
                this.ErrorInValue = this.IdealValue * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercent = ErrorInValue / IdealValue;
            }
        }
        private double symulatedResistance;

        public double SymulatedResistance
        {
            get { return symulatedResistance; }
            set { symulatedResistance = value; OnPropertyChanged("SymulatedResistance"); }
        }
        private double resistanceMeasure;

        public double ResistanceMeasure
        {
            get { return resistanceMeasure; }
            set { resistanceMeasure = value; OnPropertyChanged("ResistanceMeasure"); }
        }
        private double difference;

        public double Difference
        {
            get { return difference; }
            set
            {
                difference = value;
                OnPropertyChanged("Difference");
            }
        }
        private double maxError;

        public double MaxError
        {
            get { return maxError; }
            set { maxError = value; OnPropertyChanged("MaxError"); }
        }
        private double maxError25V;

        public double MaxError25V
        {
            get { return maxError25V; }
            set { maxError25V = value; OnPropertyChanged("MaxError25V"); }
        }
        private double resistanceOfGround;

        public double ResistanceOfGround
        {
            get { return resistanceOfGround; }
            set { resistanceOfGround = value; OnPropertyChanged("ResistanceOfGround"); }
        }
        private double difference25V;

        public double Difference25V
        {
            get { return difference25V; }
            set
            {
                difference25V = value;
                OnPropertyChanged("Difference25V");
            }
        }
        private double downMeasureErrorResistance;

        public double DownMeasureErrorResistance
        {
            get { return downMeasureErrorResistance; }
            set { downMeasureErrorResistance = value; OnPropertyChanged("DownMeasureErrorResistance"); }
        }
        private double upMeasureErrorResistance;

        public double UpMeasureErrorResistance
        {
            get { return upMeasureErrorResistance; }
            set { upMeasureErrorResistance = value; OnPropertyChanged("UpMeasureErrorResistance"); }
        }
        private double relativeError;

        public double RelativeError
        {
            get { return relativeError; }
            set { relativeError = value; OnPropertyChanged("RelativeError"); }
        }
        private double relativeError25V;

        public double RelativeError25V
        {
            get { return relativeError25V; }
            set { relativeError25V = value; OnPropertyChanged("RelativeError25V"); }
        }
        private double maxDifference;

        public double MaxDifference
        {
            get { return maxDifference; }
            set { maxDifference = value; OnPropertyChanged("MaxDifference"); }
        }
        private double realValue;

        public double RealValue
        {
            get { return realValue; }
            set { realValue = value; OnPropertyChanged("RealValue"); }
        }
        private double recommendValue;

        public double RecommendValue
        {
            get { return recommendValue; }
            set { recommendValue = value; OnPropertyChanged("RecommendValue"); }
        }

        private double upMeasureError;

        public double UpMeasureError
        {
            get { return upMeasureError; }
            set
            {
                upMeasureError = value;
                OnPropertyChanged("UpMeasureError");
            }
        }
        private double referenceVoltage;

        public double ReferenceVoltage
        {
            get { return referenceVoltage; }
            set { referenceVoltage = value; OnPropertyChanged("ReferenceVoltage"); }
        }

        private double downMeasureError;

        public double DownMeasureError
        {
            get { return downMeasureError; }
            set
            {
                downMeasureError = value;
                OnPropertyChanged("DownMeasureError");
            }
        }

        private double errorInValue;

        public double ErrorInValue
        {
            get { return errorInValue; }
            set { errorInValue = value; OnPropertyChanged("ErrorInValue"); }
        }
        private double errorInPercent;

        public double ErrorInPercent
        {
            get { return errorInPercent; }
            set { errorInPercent = value; OnPropertyChanged("ErrorInPercent"); }
        }

        private double valueOfIsolation;

        public double ValueOfIsolation
        {
            get { return valueOfIsolation; }
            set { valueOfIsolation = value; OnPropertyChanged("ValueOfIsolation"); }
        }
        private double constant;

        public double Constant
        {
            get { return constant; }
            set
            {
                constant = value;
                OnPropertyChanged("Constant");
            }
        }
        private double importantNumber;

        public double ImportantNumber
        {
            get { return importantNumber; }
            set
            {
                importantNumber = value;
                OnPropertyChanged("ImportantNumber");

            }
        }
        private double percent;

        public double Percent
        {
            get { return percent; }
            set
            {
                percent = value;
                OnPropertyChanged("Percent");

            }
        }
        private double percentIdeal;

        public double PercentIdeal
        {
            get { return percentIdeal; }
            set { percentIdeal = value; OnPropertyChanged("PercentIdeal"); }
        }
        private double importantNumberIdeal;

        public double ImportantNumberIdeal
        {
            get { return importantNumberIdeal; }
            set { importantNumberIdeal = value; OnPropertyChanged("ImportantNumberIdeal"); }
        }

        private double constantIdeal;

        public double ConstantIdeal
        {
            get { return constantIdeal; }
            set { constantIdeal = value; OnPropertyChanged("ConstantIdeal"); }
        }
        public Measure1()
        {
            Percent = NewWindowTableTemplate.percent;
            PercentIdeal = NewWindowTableTemplate.percentIdeal;
            ImportantNumber = NewWindowTableTemplate.importantNumber;
            ImportantNumberIdeal = NewWindowTableTemplate.importantNumberIdeal;
            Constant = NewWindowTableTemplate.constant;
            ConstantIdeal = NewWindowTableTemplate.constantIdeal;


        }

    }
}
