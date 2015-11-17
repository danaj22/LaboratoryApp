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
        private double differenceResist10m;
        public double DifferenceResist10m
        {
            get { return differenceResist10m; }
            set 
            {
                differenceResist10m = value;
                OnPropertyChanged("DifferenceResist10m");
            }
        }

        private double differenceResist10mv2;
        public double DifferenceResist10mv2
        {
            get { return differenceResist10mv2; }
            set 
            {
                differenceResist10mv2 = value;
                OnPropertyChanged("DifferenceResist10mv2");
            }
        }

        private double measureValueTab16;
        public double MeasureValueTab16
        {
            get { return measureValueTab16; }
            set 
            {
                measureValueTab16 = value;
                OnPropertyChanged("MeasureValueTab16");
                ResistanceOfGroundv2 = this.Multiples * 10 * 2 * Math.PI;
                //dla sondy 10 m
                DifferenceResist10m = this.MeasureValueTab16 - this.ResistanceOfGroundv2;
                DifferenceResist10mv2 = this.MeasureValue25VTab16 - this.ResistanceOfGroundv2;

                this.ErrorInValuev3 = this.ResistanceOfGroundv2 * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercentv3 = ErrorInValuev3 / ResistanceOfGroundv2;
            }
        }

        private double measureValue25VTab16;
        public double MeasureValue25VTab16
        {
            get { return measureValue25VTab16; }
            set
            {
                measureValue25VTab16 = value;
                OnPropertyChanged("MeasureValue25VTab16");

                ResistanceOfGroundv2 = this.Multiples * 10 * 2 * Math.PI;
                //dla sondy 10 m
                DifferenceResist10m = this.MeasureValueTab16 - this.ResistanceOfGroundv2;
                DifferenceResist10mv2 = this.MeasureValue25VTab16 - this.ResistanceOfGroundv2;

                this.ErrorInValuev3 = this.ResistanceOfGroundv2 * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercentv3 = ErrorInValuev3 / ResistanceOfGroundv2;
            }
        }


        private double idealValue;

        public double IdealValue
        {
            get { return idealValue; }
            set
            {
                idealValue = value;
                OnPropertyChanged("IdealValue");
                Difference = this.MeasureValue - this.IdealValue;
                Difference25V = this.MeasureValue25V - this.IdealValue;
                RelativeError = this.MeasureValue * this.Percent * 0.01 + this.ImportantNumber + this.Constant;
                RelativeError25V = this.MeasureValue25V * this.Percent * 0.01 + this.ImportantNumber + this.Constant;
                
                ResistanceOfGround = this.Multiples * 1 * 2 * Math.PI;

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
                Difference25V = this.MeasureValue25V - this.IdealValue;
                RelativeError = this.MeasureValue * this.Percent * 0.01 + this.ImportantNumber + this.Constant;
                RelativeError25V = this.MeasureValue25V * this.Percent * 0.01 + this.ImportantNumber + this.Constant;
                
                ResistanceOfGround = this.Multiples * 1 * 2 * Math.PI;

                //dla sondy 1m
                DifferenceResistance = this.MeasureValue - this.ResistanceOfGround;
                DifferenceResistancev2 = this.MeasureValue25V - this.ResistanceOfGround;



                this.DownMeasureError = this.MeasureValue - this.MeasureValue * this.Percent * 0.01 - this.ImportantNumber - this.Constant;
                this.UpMeasureError = this.MeasureValue + this.MeasureValue * this.Percent * 0.01 + this.ImportantNumber + this.Constant;

                //for table 15 and 16
                this.ErrorInValuev2 = this.ResistanceOfGround * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercentv2 = ErrorInValuev2 / ResistanceOfGround;


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
                Difference25V = this.MeasureValue25V - this.IdealValue;
                RelativeError = this.MeasureValue * this.Percent * 0.01 + this.ImportantNumber + this.Constant;
                RelativeError25V = MeasureValue25V * this.Percent * 0.01 + this.ImportantNumber + this.Constant;
                ResistanceOfGround = Multiples * 1 * 2 * Math.PI; //table 15

                //dla sondy 1m
                DifferenceResistance = this.MeasureValue - this.ResistanceOfGround;
                DifferenceResistancev2 = this.MeasureValue25V - this.ResistanceOfGround;

                
                this.DownMeasureError = this.MeasureValue25V - this.MeasureValue25V * this.Percent * 0.01 - this.ImportantNumber - this.Constant;
                this.UpMeasureError = this.MeasureValue25V + this.MeasureValue25V * this.Percent * 0.01 + this.ImportantNumber + this.Constant;

                //for table 15 
                this.ErrorInValuev2 = this.ResistanceOfGround * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercentv2 = ErrorInValuev2 / ResistanceOfGround;
                
                this.ErrorInValue = this.IdealValue * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercent = ErrorInValue / IdealValue;
            }
        }

        private double errorInValuev2;

        public double ErrorInValuev2
        {
            get { return errorInValuev2; }
            set { errorInValuev2 = value; OnPropertyChanged("ErrorInValuev2"); }
        }
        private double errorInValuev3;

        public double ErrorInValuev3
        {
            get { return errorInValuev3; }
            set { errorInValuev3 = value; OnPropertyChanged("ErrorInValuev3"); }
        }
        private double errorInPercentv2;

        public double ErrorInPercentv2
        {
            get { return errorInPercentv2; }
            set { errorInPercentv2 = value; OnPropertyChanged("ErrorInPercentv2"); }
        }

        private double errorInPercentv3;

        public double ErrorInPercentv3
        {
            get { return errorInPercentv3; }
            set { errorInPercentv3 = value; OnPropertyChanged("ErrorInPercentv3"); }
        }

        private double differenceResistance;

        public double DifferenceResistance
        {
            get { return differenceResistance; }
            set 
            {
                differenceResistance = value;
                OnPropertyChanged("DifferenceResistance");
            }
        }
        private double differenceResistancev2;

        public double DifferenceResistancev2
        {
            get { return differenceResistancev2; }
            set { differenceResistancev2 = value; OnPropertyChanged("DifferenceResistancev2"); }
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
        private double multiples;

        public double Multiples
        {
            get { return multiples; }
            set {
                multiples = value; 
                OnPropertyChanged("Multiples");
                ResistanceOfGround = Multiples * 1 * 2 * Math.PI; //table 15
                ResistanceOfGroundv2 = Multiples * 10 * 2 * Math.PI; //table 16
                //for table 15 
                this.ErrorInValuev2 = this.ResistanceOfGround * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercentv2 = ErrorInValuev2 / ResistanceOfGround;
                //for table 16
                this.ErrorInValuev3 = this.ResistanceOfGroundv2 * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercentv3 = ErrorInValuev3 / ResistanceOfGroundv2;
            }
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
            set {
                resistanceOfGround = value;
                OnPropertyChanged("ResistanceOfGround");
                this.ErrorInValuev2 = this.ResistanceOfGround * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercentv2 = ErrorInValuev2 / ResistanceOfGround;
                this.ErrorInValuev3 = this.ResistanceOfGroundv2 * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercentv3 = ErrorInValuev3 / ResistanceOfGroundv2;
            }
        }
        private double resistanceOfGroundv2;

        public double ResistanceOfGroundv2
        {
            get { return resistanceOfGroundv2; }
            set { resistanceOfGroundv2 = value;
                OnPropertyChanged("ResistanceOfGroundv2");
                this.ErrorInValuev2 = this.ResistanceOfGround * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercentv2 = ErrorInValuev2 / ResistanceOfGround;
                this.ErrorInValuev3 = this.ResistanceOfGroundv2 * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercentv3 = ErrorInValuev3 / ResistanceOfGroundv2;
            }
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
            set { percentIdeal = value;
                OnPropertyChanged("PercentIdeal");
            this.ErrorInValue = this.IdealValue * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
            this.ErrorInPercent = ErrorInValue / IdealValue;
            }
        }
        private double importantNumberIdeal;

        public double ImportantNumberIdeal
        {
            get { return importantNumberIdeal; }
            set { importantNumberIdeal = value;
                OnPropertyChanged("ImportantNumberIdeal");
                this.ErrorInValue = this.IdealValue * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercent = ErrorInValue / IdealValue;
            }
        }

        private double constantIdeal;

        public double ConstantIdeal
        {
            get { return constantIdeal; }
            set { constantIdeal = value;
                OnPropertyChanged("ConstantIdeal");
                this.ErrorInValue = this.IdealValue * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercent = ErrorInValue / IdealValue;
            }
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
