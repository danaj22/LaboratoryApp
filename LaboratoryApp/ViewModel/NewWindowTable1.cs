using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

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
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                }
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
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                }
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
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                }
                measureValueTab16 = value;
                OnPropertyChanged("MeasureValueTab16");
                ResistanceOfGroundv2 = this.Multiples * 10 * 2 * Math.PI;
                //dla sondy 10 m
                DifferenceResist10m = this.MeasureValueTab16 - this.ResistanceOfGroundv2;
                DifferenceResist10mv2 = this.MeasureValue25VTab16 - this.ResistanceOfGroundv2;

                this.ErrorInValuev3 = this.ResistanceOfGroundv2 * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercentv3 = ErrorInValuev3 / ResistanceOfGroundv2;


                if (Math.Abs(IdealValue) > RelativeError)
                {
                    BrushConverter conv = new BrushConverter();
                    ColorResultTab16_50V = conv.ConvertFromString("LightGray") as SolidColorBrush;

                }
                else
                {
                    ColorResultTab16_50V = new SolidColorBrush();
                }
            }
        }

        private double errorRelativePercent;

        public double ErrorRelativePercent
        {
            get { return errorRelativePercent; }
            set {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                } errorRelativePercent = value; OnPropertyChanged("ErrorRelativePercent");
            }
        }

        private double measureValue25VTab16;
        public double MeasureValue25VTab16
        {
            get { return measureValue25VTab16; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                }
                measureValue25VTab16 = value;
                OnPropertyChanged("MeasureValue25VTab16");

                ResistanceOfGroundv2 = this.Multiples * 10 * 2 * Math.PI;
                //dla sondy 10 m
                DifferenceResist10m = this.MeasureValueTab16 - this.ResistanceOfGroundv2;
                DifferenceResist10mv2 = this.MeasureValue25VTab16 - this.ResistanceOfGroundv2;

                this.ErrorInValuev3 = this.ResistanceOfGroundv2 * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercentv3 = ErrorInValuev3 / ResistanceOfGroundv2;

                if(Math.Abs(IdealValue) > RelativeError25V)
                {
                     BrushConverter conv = new BrushConverter();
                    ColorResultTab16_25V = conv.ConvertFromString("LightGray") as SolidColorBrush;

                }
                else
                {
                    ColorResultTab16_25V = new SolidColorBrush();
                }

            }
        }


        private double idealValue;

        public double IdealValue
        {
            get { return idealValue; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                }
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
        private SolidColorBrush colorResult;

        public SolidColorBrush ColorResult
        {
            get { return colorResult; }
            set 
            { 
                colorResult = value;
                OnPropertyChanged("ColorResult");
            }
        }
        private SolidColorBrush colorResult2;

        public SolidColorBrush ColorResult2
        {
            get { return colorResult2; }
            set { colorResult2 = value; OnPropertyChanged("ColorResult2"); }
        }
        private SolidColorBrush colorResult3;

        public SolidColorBrush ColorResult3
        {
            get { return colorResult3; }
            set { colorResult3 = value; OnPropertyChanged("ColorResult3"); }
        }
        private SolidColorBrush colorResultTab15_50V;

        public SolidColorBrush ColorResultTab15_50V
        {
            get { return colorResultTab15_50V; }
            set { colorResultTab15_50V = value; OnPropertyChanged("ColorResultTab15_50V"); }
        }
        private SolidColorBrush colorResultTab15_25V;

        public SolidColorBrush ColorResultTab15_25V
        {
            get { return colorResultTab15_25V; }
            set { colorResultTab15_25V = value; OnPropertyChanged("ColorResultTab15_25V"); }
        }

        private SolidColorBrush colorResultTab16_50V;

        public SolidColorBrush ColorResultTab16_50V
        {
            get { return colorResultTab16_50V; }
            set { colorResultTab16_50V = value; OnPropertyChanged("ColorResultTab16_50V"); }
        }

        private SolidColorBrush colorResultTab16_25V;

        public SolidColorBrush ColorResultTab16_25V
        {
            get { return colorResultTab16_25V; }
            set 
            { colorResultTab16_25V = value; OnPropertyChanged("ColorResultTab16_25V"); }
        }

        private double measureValue;

        public double MeasureValue
        {
            get { return measureValue; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                }

                measureValue = value;
                
                OnPropertyChanged("MeasureValue");

                Difference = this.MeasureValue - this.IdealValue;
                Difference25V = this.MeasureValue25V - this.IdealValue;
                RelativeError = this.MeasureValue * this.Percent * 0.01 + this.ImportantNumber + this.Constant;
                RelativeError25V = this.MeasureValue25V * this.Percent * 0.01 + this.ImportantNumber + this.Constant;

                ErrorRelativePercent = Math.Round((IdealValue - MeasureValue)/ MeasureValue * 100,4);


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

                if(IdealValue > UpMeasureError ||  IdealValue < DownMeasureError )
                {
                    BrushConverter conv = new BrushConverter();
                    ColorResult = conv.ConvertFromString("LightGray") as SolidColorBrush;
                }
                else
                {
                    ColorResult = new SolidColorBrush();
                }

                if (IdealValue < Math.Abs(RelativeError))
                {
                    BrushConverter conv = new BrushConverter();
                    ColorResult2 = conv.ConvertFromString("LightGray") as SolidColorBrush;
                    ColorResultTab15_50V = conv.ConvertFromString("LightGray") as SolidColorBrush;
                }
                else
                {
                    ColorResult2 = new SolidColorBrush();
                    ColorResultTab15_50V = new SolidColorBrush();
                }

                if (IdealValue < Math.Abs(RelativeError25V))
                {
                    BrushConverter conv = new BrushConverter();
                    ColorResult3 = conv.ConvertFromString("LightGray") as SolidColorBrush;
                    ColorResultTab15_25V = conv.ConvertFromString("LightGray") as SolidColorBrush;
                }
                else
                {
                    ColorResult3 = new SolidColorBrush();
                    ColorResultTab15_25V = new SolidColorBrush();
                }
                
            }
        }
        private double measureValue25V;

        public double MeasureValue25V
        {
            get { return measureValue25V; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                }
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


                if (IdealValue < Math.Abs(RelativeError25V))
                {
                    BrushConverter conv = new BrushConverter();
                    ColorResult3 = conv.ConvertFromString("LightGray") as SolidColorBrush;
                    ColorResultTab15_25V = conv.ConvertFromString("LightGray") as SolidColorBrush;
                }
                else
                {
                    ColorResult3 = new SolidColorBrush();
                    ColorResultTab15_25V = new SolidColorBrush();
                }

               


            }
        }

        private double errorInValuev2;

        public double ErrorInValuev2
        {
            get { return errorInValuev2; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                } errorInValuev2 = value; OnPropertyChanged("ErrorInValuev2");
            }
        }
        private double errorInValuev3;

        public double ErrorInValuev3
        {
            get { return errorInValuev3; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                } errorInValuev3 = value; OnPropertyChanged("ErrorInValuev3");
            }
        }
        private double errorInPercentv2;

        public double ErrorInPercentv2
        {
            get { return errorInPercentv2; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                } errorInPercentv2 = value; OnPropertyChanged("ErrorInPercentv2");
            }
        }

        private double errorInPercentv3;

        public double ErrorInPercentv3
        {
            get { return errorInPercentv3; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                } errorInPercentv3 = value; OnPropertyChanged("ErrorInPercentv3");
            }
        }

        private double differenceResistance;

        public double DifferenceResistance
        {
            get { return differenceResistance; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                }
                differenceResistance = value;
                OnPropertyChanged("DifferenceResistance");
            }
        }
        private double differenceResistancev2;

        public double DifferenceResistancev2
        {
            get { return differenceResistancev2; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                } differenceResistancev2 = value; OnPropertyChanged("DifferenceResistancev2");
            }
        }

        private double symulatedResistance;

        public double SymulatedResistance
        {
            get { return symulatedResistance; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                } symulatedResistance = value; OnPropertyChanged("SymulatedResistance");
            }
        }
        private double resistanceMeasure;

        public double ResistanceMeasure
        {
            get { return resistanceMeasure; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                } resistanceMeasure = value; OnPropertyChanged("ResistanceMeasure");
            }
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
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                }
                difference = value;
                OnPropertyChanged("Difference");
            }
        }
        private double maxError;

        public double MaxError
        {
            get { return maxError; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                } maxError = value; OnPropertyChanged("MaxError");
            }
        }
        private double maxError25V;

        public double MaxError25V
        {
            get { return maxError25V; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                } maxError25V = value; OnPropertyChanged("MaxError25V");
            }
        }
        private double resistanceOfGround;

        public double ResistanceOfGround
        {
            get { return resistanceOfGround; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                }
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
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                } resistanceOfGroundv2 = value;
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
            get
            {
return difference25V;
            }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                } 
                difference25V = value;
                OnPropertyChanged("Difference25V");
            }
        }
        private double downMeasureErrorResistance;

        public double DownMeasureErrorResistance
        {
            get { return downMeasureErrorResistance; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                } downMeasureErrorResistance = value; OnPropertyChanged("DownMeasureErrorResistance");
            }
        }
        private double upMeasureErrorResistance;

        public double UpMeasureErrorResistance
        {
            get { return upMeasureErrorResistance; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                } upMeasureErrorResistance = value; OnPropertyChanged("UpMeasureErrorResistance");
            }
        }
        private double relativeError;

        public double RelativeError
        {
            get { return relativeError; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                } relativeError = value; OnPropertyChanged("RelativeError");
            }
        }
        private double relativeError25V;

        public double RelativeError25V
        {
            get { return relativeError25V; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                } relativeError25V = value; OnPropertyChanged("RelativeError25V");
            }
        }
        private double maxDifference;

        public double MaxDifference
        {
            get { return maxDifference; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                } maxDifference = value; OnPropertyChanged("MaxDifference");
            }
        }
        private string realValue="";

        public string RealValue
        {
            get { return realValue; }
            set { realValue = value; OnPropertyChanged("RealValue"); }
        }
        private string recommendValue="";

        public string RecommendValue
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
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                }
                upMeasureError = value;
                OnPropertyChanged("UpMeasureError");
            }
        }
        private double referenceVoltage;

        public double ReferenceVoltage
        {
            get { return referenceVoltage; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                } referenceVoltage = value; OnPropertyChanged("ReferenceVoltage");
            }
        }

        private double downMeasureError;

        public double DownMeasureError
        {
            get { return downMeasureError; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                }
                downMeasureError = value;
                OnPropertyChanged("DownMeasureError");
            }
        }

        private double errorInValue;

        public double ErrorInValue
        {
            get { return errorInValue; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                } errorInValue = value; OnPropertyChanged("ErrorInValue");
            }
        }
        private double errorInPercent;

        public double ErrorInPercent
        {
            get { return errorInPercent; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                } errorInPercent = value; OnPropertyChanged("ErrorInPercent");
            }
        }

        private double valueOfIsolation;

        public double ValueOfIsolation
        {
            get { return valueOfIsolation; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                } valueOfIsolation = value; OnPropertyChanged("ValueOfIsolation");
            }
        }
        private double constant;

        public double Constant
        {
            get { return constant; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                }
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
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                }
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
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                }
                percent = value;
                OnPropertyChanged("Percent");

            }
        }
        private double percentIdeal;

        public double PercentIdeal
        {
            get { return percentIdeal; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                } percentIdeal = value;
                OnPropertyChanged("PercentIdeal");
            this.ErrorInValue = this.IdealValue * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
            this.ErrorInPercent = ErrorInValue / IdealValue;
            }
        }
        private double importantNumberIdeal;

        public double ImportantNumberIdeal
        {
            get { return importantNumberIdeal; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                } importantNumberIdeal = value;
                OnPropertyChanged("ImportantNumberIdeal");
                this.ErrorInValue = this.IdealValue * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercent = ErrorInValue / IdealValue;
            }
        }

        private double constantIdeal;

        public double ConstantIdeal
        {
            get { return constantIdeal; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                } constantIdeal = value;
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
