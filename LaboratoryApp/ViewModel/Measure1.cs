using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LaboratoryApp.ViewModel
{
    [Serializable()]
    public class Measure1 : ObservableObject, ISerializable
    {

        //Deserialization constructor.
        public Measure1(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            IdealValue = (string)info.GetValue("IdealVal", typeof(string));
            Prefix = (string)info.GetValue("Pref", typeof(string));
            Prefix2 = (string)info.GetValue("Pref2", typeof(string));
            ReferenceVoltage = (double)info.GetValue("RefVolt", typeof(double));
            ResistanceMeasure = (double)info.GetValue("ResistMeas", typeof(double));
            SymulatedResistance = (double)info.GetValue("SymResist", typeof(double));
            Multiples = (double)info.GetValue("Multi", typeof(double));
            Percent = (double)info.GetValue("Perc", typeof(double));
            PercentIdeal = (double)info.GetValue("PercI", typeof(double));
            ImportantNumber = (double)info.GetValue("ImpNum", typeof(double));
            ImportantNumberIdeal = (double)info.GetValue("ImpNumI", typeof(double));
            Constant = (double)info.GetValue("Cons", typeof(double));
            ConstantIdeal = (double)info.GetValue("ConsI", typeof(double));

            //table 11
            IdealValueTab11Rezystancja = (string)info.GetValue("IdealValRezystancja", typeof(string));
            IdealValueTab11Reaktancja = (string)info.GetValue("IdealValReaktancja", typeof(string));

            //table 20
            AdmissibleDiffrentOfPressures = (double)info.GetValue("AdmissDiffOfPress", typeof(double));


        }

        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"

            
            info.AddValue("IdealVal", IdealValue);
            info.AddValue("Pref", Prefix);
            info.AddValue("Pref2", Prefix2);
            info.AddValue("RefVolt", ReferenceVoltage);
            info.AddValue("ResistMeas", ResistanceMeasure);
            info.AddValue("SymResist", SymulatedResistance);
            info.AddValue("Multi", Multiples);
            info.AddValue("Perc", Percent);
            info.AddValue("PercI", PercentIdeal);
            info.AddValue("ImpNum", ImportantNumber);
            info.AddValue("ImpNumI", ImportantNumberIdeal); 
            info.AddValue("Cons", Constant);
            info.AddValue("ConsI", ConstantIdeal);

            //table 11 
            info.AddValue("IdealValRezystancja", IdealValueTab11Rezystancja);
            info.AddValue("IdealValReaktancja", IdealValueTab11Reaktancja);

            //table 20
            info.AddValue("AdmissDiffOfPress", AdmissibleDiffrentOfPressures);

        }
        #region

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

        private string measureValueTab16;
        public string MeasureValueTab16
        {
            get { return measureValueTab16; }
            set
            {

                measureValueTab16 = value;
                OnPropertyChanged("MeasureValueTab16");

                string tmpResOfGndv2 = (Multiples * 10 * 2 * Math.PI).ToString();
                if (tmpResOfGndv2.Contains(","))
                {
                    int index = tmpResOfGndv2.IndexOf(",");
                    ResistanceOfGroundv2 = tmpResOfGndv2.Substring(0, index + 3);
                }

                double resGndv2 = 0;
                try
                {
                    resGndv2 = Convert.ToDouble(this.ResistanceOfGroundv2.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }
                double measValTab16 = 0;
                try
                {
                    measValTab16 = Convert.ToDouble(this.MeasureValueTab16.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }
                double measVal25VTab16 = 0;
                try
                {
                    measVal25VTab16 = Convert.ToDouble(this.MeasureValue25VTab16.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }
                //dla sondy 10 m
                DifferenceResist10m = measValTab16 - resGndv2;
                DifferenceResist10mv2 = measVal25VTab16 - resGndv2;

                RelativeErrorTab16 = measValTab16 * this.Percent * 0.01 + this.ImportantNumber + this.Constant;

                this.ErrorInValuev3 = resGndv2 * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercentv3 = ErrorInValuev3 / resGndv2 * 100;
                BrushConverter conv = new BrushConverter();

                if (resGndv2 > Math.Abs(RelativeErrorTab16) + measValTab16 || resGndv2 < measValTab16 - Math.Abs(RelativeErrorTab16))
                {

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
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                }
                errorRelativePercent = value; OnPropertyChanged("ErrorRelativePercent");
            }
        }

        private string measureValue25VTab16;
        public string MeasureValue25VTab16
        {
            get { return measureValue25VTab16; }
            set
            {

                measureValue25VTab16 = value;
                OnPropertyChanged("MeasureValue25VTab16");

                string tmpResOfGndv2 = (Multiples * 10 * 2 * Math.PI).ToString();
                if (tmpResOfGndv2.Contains(","))
                {
                    int index = tmpResOfGndv2.IndexOf(",");
                    ResistanceOfGroundv2 = tmpResOfGndv2.Substring(0, index + 3);
                }

                double resGndv2 = 0;
                try
                {
                    resGndv2 = Convert.ToDouble(this.ResistanceOfGroundv2.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }
                double measValTab16 = 0;
                try
                {
                    measValTab16 = Convert.ToDouble(this.MeasureValueTab16.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }
                double measVal25VTab16 = 0;
                try
                {
                    measVal25VTab16 = Convert.ToDouble(this.MeasureValue25VTab16.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }

                RelativeError25VTab16 = measVal25VTab16 * this.Percent * 0.01 + this.ImportantNumber + this.Constant;

                //dla sondy 10 m
                DifferenceResist10m = measValTab16 - resGndv2;
                DifferenceResist10mv2 = measVal25VTab16 - resGndv2;

                this.ErrorInValuev3 = resGndv2 * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercentv3 = ErrorInValuev3 / resGndv2 * 100;
                BrushConverter conv = new BrushConverter();
                if (resGndv2 > Math.Abs(RelativeError25VTab16) + measVal25VTab16 || resGndv2 < measVal25VTab16 - Math.Abs(RelativeError25VTab16))
                {

                    ColorResultTab16_25V = conv.ConvertFromString("LightGray") as SolidColorBrush;

                }
                else
                {
                    ColorResultTab16_25V = new SolidColorBrush();
                }

            }
        }


        private string idealValue;

        public string IdealValue
        {
            get { return idealValue; }
            set
            {
               // double number;
                //if (value is string)
                {
                   // number = (double)Convert.ToDouble(value.Replace(".",","));
                   // number = Math.Round(number, 4);
                   // value = number.ToString();
                }

                idealValue = value;
                OnPropertyChanged("IdealValue");

                //
                //tymczasowe wartości dla konwersji słowa na liczbę
                double measVal = 0;
                double idealVal = 0;
                double measVal25V = 0;
                try
                {
                    measVal = Convert.ToDouble(this.MeasureValue.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }
                try
                {
                    idealVal = Convert.ToDouble(this.IdealValue.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }
                try
                {
                    measVal25V = Convert.ToDouble(this.MeasureValue25V.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }

                //
                // aktualizacja wszystkich pól
                //
                #region
                Difference = measVal - idealVal;
                Difference25V = measVal25V - idealVal;
                //dla tab 11
                RelativeErrorTab11Impedancja = Math.Abs(measVal - idealVal);

                RelativeError = measVal * this.Percent * 0.01 + this.ImportantNumber + this.Constant;
                RelativeError25V = measVal25V * this.Percent * 0.01 + this.ImportantNumber + this.Constant;

                string tmpResOfGnd = (Multiples * 1 * 2 * Math.PI).ToString(); //table 15
                if (tmpResOfGnd.Contains(","))
                {
                    int index = tmpResOfGnd.IndexOf(",");
                    ResistanceOfGround = tmpResOfGnd.Substring(0, index + 3);
                }

                this.DownMeasureError = measVal - measVal * this.Percent * 0.01 - this.ImportantNumber - this.Constant;
                this.UpMeasureError = measVal + measVal * this.Percent * 0.01 + this.ImportantNumber + this.Constant;


                this.ErrorInValue = idealVal * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercent = ErrorInValue / idealVal * 100;
                #endregion
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
        private SolidColorBrush colorResult = new SolidColorBrush();

        public SolidColorBrush ColorResult
        {
            get { return colorResult; }
            set
            {
                colorResult = value;
                OnPropertyChanged("ColorResult");
            }
        }

        private SolidColorBrush colorResult2 = new SolidColorBrush();

        public SolidColorBrush ColorResult2
        {
            get { return colorResult2; }
            set { colorResult2 = value; OnPropertyChanged("ColorResult2"); }
        }
        private SolidColorBrush colorResult3 = new SolidColorBrush();

        public SolidColorBrush ColorResult3
        {
            get { return colorResult3; }
            set { colorResult3 = value; OnPropertyChanged("ColorResult3"); }
        }

        private SolidColorBrush colorResult4 = new SolidColorBrush();

        public SolidColorBrush ColorResult4
        {
            get { return colorResult4; }
            set
            {
                colorResult4 = value;
                OnPropertyChanged("ColorResult4");
            }
        }
        private SolidColorBrush colorResultTab15_50V = new SolidColorBrush();

        public SolidColorBrush ColorResultTab15_50V
        {
            get { return colorResultTab15_50V; }
            set { colorResultTab15_50V = value; OnPropertyChanged("ColorResultTab15_50V"); }
        }
        private SolidColorBrush colorResultTab15_25V = new SolidColorBrush();

        public SolidColorBrush ColorResultTab15_25V
        {
            get { return colorResultTab15_25V; }
            set { colorResultTab15_25V = value; OnPropertyChanged("ColorResultTab15_25V"); }
        }

        private SolidColorBrush colorResultTab16_50V = new SolidColorBrush();

        public SolidColorBrush ColorResultTab16_50V
        {
            get { return colorResultTab16_50V; }
            set { colorResultTab16_50V = value; OnPropertyChanged("ColorResultTab16_50V"); }
        }

        private SolidColorBrush colorResultTab16_25V = new SolidColorBrush();

        public SolidColorBrush ColorResultTab16_25V
        {
            get { return colorResultTab16_25V; }
            set
            { colorResultTab16_25V = value; OnPropertyChanged("ColorResultTab16_25V"); }
        }

        private string measureValue;

        public string MeasureValue
        {
            get { return measureValue; }
            set
            {
                //double number;
                //if (value is double)
                //{
                //    number = (double)value;
                //    number = Math.Round(number, 4);
                //    value = number;
                //}


                measureValue = value;

                OnPropertyChanged("MeasureValue");

                //
                //tymczasowe wartości do konwersji słowa na liczbę
                double measVal = 0;
                double idealVal = 0;
                double measVal25V = 0;
                double resGnd = 0;

                try
                {
                    measVal = Convert.ToDouble(this.MeasureValue.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }
                try
                {
                    idealVal = Convert.ToDouble(this.IdealValue.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }
                try
                {
                    measVal25V = Convert.ToDouble(this.MeasureValue25V.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }
                ///
                ///aktualizacja wszytkich pól
                ///
                #region 
                { 
                Difference = measVal - idealVal;
                Difference25V = measVal25V - idealVal;

                RelativeError = measVal * this.Percent * 0.01 + this.ImportantNumber + this.Constant;
                RelativeError25V = measVal25V * this.Percent * 0.01 + this.ImportantNumber + this.Constant;

                ErrorRelativePercent = Math.Round((idealVal - measVal) / measVal * 100, 4);
}
                //dla tabeli 11 
                RelativeErrorTab11Impedancja = Math.Abs(measVal - idealVal);
                this.MaxError = measVal * this.Percent * 0.01 + this.ImportantNumber + this.Constant;
                this.ErrorInValue = idealVal * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercent = ErrorInValue / idealVal *100;

                string tmpResOfGnd = (Multiples * 1 * 2 * Math.PI).ToString(); //table 15
                if (tmpResOfGnd.Contains(","))
                {
                    int index = tmpResOfGnd.IndexOf(",");
                    ResistanceOfGround = tmpResOfGnd.Substring(0, index + 3);
                }

                try
                {
                    resGnd = Convert.ToDouble(this.ResistanceOfGround.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }
                //dla sondy 1m
                DifferenceResistance = measVal - resGnd;
                DifferenceResistancev2 = measVal25V - resGnd;



                this.DownMeasureError = measVal - measVal * this.Percent * 0.01 - this.ImportantNumber - this.Constant;
                this.UpMeasureError = measVal + measVal * this.Percent * 0.01 + this.ImportantNumber + this.Constant;

                //for table 15 and 16
                this.ErrorInValuev2 = resGnd * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercentv2 = ErrorInValuev2 / resGnd * 100;


                this.ErrorInValue = idealVal * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercent = ErrorInValue / idealVal * 100;

                BrushConverter conv = new BrushConverter();

                if (idealVal > UpMeasureError || idealVal < DownMeasureError)
                {
                    conv = new BrushConverter();
                    ColorResult = conv.ConvertFromString("LightGray") as SolidColorBrush;
                }
                else
                {
                    ColorResult = new SolidColorBrush();
                }

                if (idealVal > Math.Abs(RelativeError) + measVal || idealVal < measVal - Math.Abs(RelativeError))
                {
                    conv = new BrushConverter();
                    ColorResult2 = conv.ConvertFromString("LightGray") as SolidColorBrush;

                }
                else
                {
                    ColorResult2 = new SolidColorBrush();
                }

                if (idealVal > Math.Abs(RelativeError25V) + measVal25V || idealVal < measVal25V - Math.Abs(RelativeError25V))
                {
                    conv = new BrushConverter();
                    ColorResult3 = conv.ConvertFromString("LightGray") as SolidColorBrush;

                }
                else
                {
                    ColorResult3 = new SolidColorBrush();
                }


                if (resGnd > Math.Abs(RelativeError25V) + measVal25V || resGnd < measVal25V - Math.Abs(RelativeError25V))
                {
                    conv = new BrushConverter();

                    ColorResultTab15_25V = conv.ConvertFromString("LightGray") as SolidColorBrush;
                }
                else
                {
                    ColorResultTab15_25V = new SolidColorBrush();
                }

                if (resGnd > Math.Abs(RelativeError) + measVal || resGnd < measVal - Math.Abs(RelativeError))
                {
                    conv = new BrushConverter();
                    ColorResultTab15_50V = conv.ConvertFromString("LightGray") as SolidColorBrush;
                }
                else
                {
                    ColorResultTab15_50V = new SolidColorBrush();
                }
                #endregion

            }
        }


        private string relativeErrorTab11Rezystancja;
        public string RelativeErrorTab11Rezystancja
        {
            get
            {
                return relativeErrorTab11Rezystancja;
            }

            set
            {
                relativeErrorTab11Rezystancja = value;
                OnPropertyChanged("RelativeErrorTab11Rezystancja");

                if (IdealValueTab11Rezystancja.Contains("x"))
                {
                    if (RelativeErrorTab11Impedancja > MaxError ||
                    RelativeErrorTab11Reaktancja != null && !RelativeErrorTab11Reaktancja.Contains("x") && Double.Parse(RelativeErrorTab11Reaktancja) > MaxError ||
                    RelativeErrorTab11Rezystancja != null && !RelativeErrorTab11Rezystancja.Contains("x") && Double.Parse(RelativeErrorTab11Rezystancja) > MaxError)
                    {
                        BrushConverter conv = new BrushConverter();

                        conv = new BrushConverter();
                        ColorResult4 = conv.ConvertFromString("LightGray") as SolidColorBrush;
                    }
                    else
                    {
                        ColorResult4 = new SolidColorBrush();
                    }
                }
            }
        }

        private double relativeErrorTab11Impedancja;
        public double RelativeErrorTab11Impedancja
        {
            get
            {
                return relativeErrorTab11Impedancja;
            }

            set
            {
                relativeErrorTab11Impedancja = value;
                OnPropertyChanged("RelativeErrorTab11Impedancja");

                
                if (RelativeErrorTab11Impedancja > MaxError ||
                    RelativeErrorTab11Reaktancja != null && !RelativeErrorTab11Reaktancja.Contains("x") && Double.Parse(RelativeErrorTab11Reaktancja) > MaxError ||
                    RelativeErrorTab11Rezystancja != null && !RelativeErrorTab11Rezystancja.Contains("x") && Double.Parse(RelativeErrorTab11Rezystancja) > MaxError)
                {
                    BrushConverter conv = new BrushConverter();

                    conv = new BrushConverter();
                    ColorResult4 = conv.ConvertFromString("LightGray") as SolidColorBrush;
                }
                else
                {
                    ColorResult4 = new SolidColorBrush();
                }
            }
        }

        private string relativeErrorTab11Reaktancja;
        public string RelativeErrorTab11Reaktancja
        {
            get
            {
                return relativeErrorTab11Reaktancja;
            }

            set
            {
                relativeErrorTab11Reaktancja = value;
                OnPropertyChanged("RelativeErrorTab11Reaktancja");


                if (!IdealValueTab11Reaktancja.Contains("x"))
                {
                    if (RelativeErrorTab11Impedancja > MaxError ||
                    RelativeErrorTab11Reaktancja != null && !RelativeErrorTab11Reaktancja.Contains("x") && Double.Parse(RelativeErrorTab11Reaktancja) > MaxError ||
                    RelativeErrorTab11Rezystancja != null && !RelativeErrorTab11Rezystancja.Contains("x") && Double.Parse(RelativeErrorTab11Rezystancja) > MaxError)
                    {
                        BrushConverter conv = new BrushConverter();

                        conv = new BrushConverter();
                        ColorResult4 = conv.ConvertFromString("LightGray") as SolidColorBrush;
                    }
                    else
                    {
                        ColorResult4 = new SolidColorBrush();
                    }
                }
            }
        }

        private string measureValueTab11Rezystancja;
        public string MeasureValueTab11Rezystancja
        {
            get
            {
                return measureValueTab11Rezystancja;
            }

            set
            {
                measureValueTab11Rezystancja = value;
                OnPropertyChanged("MeasureValueTab11Rezystancja");
            }
        }

        private string measureValueTab11Reaktancja;
        public string MeasureValueTab11Reaktancja
        {
            get
            {
                return measureValueTab11Reaktancja;
            }

            set
            {
                measureValueTab11Reaktancja = value;
                OnPropertyChanged("MeasureValueTab11Reaktancja");
               
            }
        }

        private string idealValueTab11Rezystancja;
        public string IdealValueTab11Rezystancja
        {
            get
            {
                return idealValueTab11Rezystancja;
            }

            set
            {
                idealValueTab11Rezystancja = value;
                OnPropertyChanged("IdealValueTab11Rezystancja");

                if (idealValueTab11Rezystancja != null && idealValueTab11Rezystancja.Contains("x"))
                {
                    MeasureValueTab11Rezystancja = "xxxx";
                    RelativeErrorTab11Rezystancja = "xxxx";
                }
                else if (MeasureValueTab11Reaktancja != null && MeasureValueTab11Rezystancja != null)
                {
                    RelativeErrorTab11Rezystancja = Math.Abs(Double.Parse(this.MeasureValueTab11Rezystancja.Replace(".", ",")) - Double.Parse(IdealValueTab11Rezystancja.Replace(".", ","))).ToString();
                }
            }
        }
        private string idealValueTab11Reaktancja;
        public string IdealValueTab11Reaktancja
        {
            get
            {
                return idealValueTab11Reaktancja;
            }

            set
            {
                idealValueTab11Reaktancja = value;
                OnPropertyChanged("IdealValueTab11Reaktancja");

                if (idealValueTab11Reaktancja != null && idealValueTab11Reaktancja.Contains("x"))
                {
                    MeasureValueTab11Reaktancja = "xxxx";
                    RelativeErrorTab11Reaktancja = "xxxx";
                }
                else if(MeasureValueTab11Reaktancja != null && MeasureValueTab11Rezystancja != null)
                {

                    RelativeErrorTab11Reaktancja = Math.Abs(Double.Parse(this.MeasureValueTab11Reaktancja.Replace(".",",")) - Double.Parse(IdealValueTab11Reaktancja.Replace(".",","))).ToString();
                }
            }
        }

        private string measureValue25V;

        public string MeasureValue25V
        {
            get { return measureValue25V; }
            set
            {
                
                measureValue25V = value;
                OnPropertyChanged("MeasureValue25V");

                double measVal = 0;
                double idealVal = 0;
                double measVal25V = 0;
                double resGnd = 0;
                try
                {
                    measVal = Convert.ToDouble(this.MeasureValue.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }
                try
                {
                    idealVal = Convert.ToDouble(this.IdealValue.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }
                try
                {
                    measVal25V = Convert.ToDouble(this.MeasureValue25V.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }


                Difference = measVal25V - idealVal;
                Difference25V = measVal25V - idealVal;
                RelativeError = measVal * this.Percent * 0.01 + this.ImportantNumber + this.Constant;
                RelativeError25V = measVal25V * this.Percent * 0.01 + this.ImportantNumber + this.Constant;
                string tmpResOfGnd = (Multiples * 1 * 2 * Math.PI).ToString(); //table 15
                if (tmpResOfGnd.Contains(","))
                {
                    int index = tmpResOfGnd.IndexOf(",");
                    ResistanceOfGround = tmpResOfGnd.Substring(0, index + 3);
                }

                try
                {
                    resGnd = Convert.ToDouble(this.ResistanceOfGround.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }

                //dla sondy 1m
                DifferenceResistance = measVal - resGnd;
                DifferenceResistancev2 = measVal25V - resGnd;


                this.DownMeasureError = measVal25V - measVal25V * this.Percent * 0.01 - this.ImportantNumber - this.Constant;
                this.UpMeasureError = measVal25V + measVal25V * this.Percent * 0.01 + this.ImportantNumber + this.Constant;

                //for table 15 
                this.ErrorInValuev2 = resGnd * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercentv2 = ErrorInValuev2 / resGnd * 100;

                this.ErrorInValue = idealVal * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercent = ErrorInValue / idealVal * 100;

                BrushConverter conv = new BrushConverter();

                if (idealVal < Math.Abs(RelativeError25V))
                {
                    conv = new BrushConverter();
                    ColorResult3 = conv.ConvertFromString("LightGray") as SolidColorBrush;

                }
                else
                {
                    ColorResult3 = new SolidColorBrush();
                }

                if (resGnd > Math.Abs(RelativeError25V) + measVal25V || resGnd < measVal25V - Math.Abs(RelativeError25V))
                {
                    conv = new BrushConverter();

                    ColorResultTab15_25V = conv.ConvertFromString("LightGray") as SolidColorBrush;
                }
                else
                {
                    ColorResultTab15_25V = new SolidColorBrush();
                }

                if (idealVal > Math.Abs(RelativeError) + measVal25V || idealVal < measVal25V - Math.Abs(RelativeError))
                {
                    conv = new BrushConverter();
                    ColorResult3 = conv.ConvertFromString("LightGray") as SolidColorBrush;

                }
                else
                {
                    ColorResult3 = new SolidColorBrush();
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
                }
                errorInValuev2 = value; OnPropertyChanged("ErrorInValuev2");
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
                }
                errorInValuev3 = value; OnPropertyChanged("ErrorInValuev3");
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
                }
                errorInPercentv2 = value; OnPropertyChanged("ErrorInPercentv2");
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
                }
                errorInPercentv3 = value; OnPropertyChanged("ErrorInPercentv3");
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
                }
                differenceResistancev2 = value; OnPropertyChanged("DifferenceResistancev2");
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
                }
                symulatedResistance = value; OnPropertyChanged("SymulatedResistance");
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
                }
                resistanceMeasure = value; OnPropertyChanged("ResistanceMeasure");
            }
        }
        private double multiples;

        public double Multiples
        {
            get { return multiples; }
            set
            {



                multiples = value;
                OnPropertyChanged("Multiples");
                
                string tmpResOfGnd = (Multiples * 1 * 2 * Math.PI).ToString(); //table 15
                if (tmpResOfGnd.Contains(","))
                {
                    int index = tmpResOfGnd.IndexOf(",");
                    ResistanceOfGround = tmpResOfGnd.Substring(0, index + 3);
                }
                string tmpResOfGndv2 = (Multiples * 10 * 2 * Math.PI).ToString();
                if(tmpResOfGndv2.Contains(","))
                {
                    int index = tmpResOfGndv2.IndexOf(",");
                    ResistanceOfGroundv2 = tmpResOfGndv2.Substring(0, index + 3);
                }
                
                //for table 15 
                double resGnd = 0;
                try
                {
                    resGnd = Convert.ToDouble(this.ResistanceOfGround.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }
                double resGndv2 = 0;
                try
                {
                    resGndv2 = Convert.ToDouble(this.ResistanceOfGroundv2.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }

                this.ErrorInValuev2 = resGnd * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercentv2 = ErrorInValuev2 / resGnd * 100;
                //for table 16
                this.ErrorInValuev3 = resGndv2 * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercentv3 = ErrorInValuev3 / resGndv2 * 100;
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

        private double admissibleDiffrentOfPressures;
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
                }
                maxError = value; OnPropertyChanged("MaxError");

                if (RelativeErrorTab11Impedancja > MaxError ||
                    RelativeErrorTab11Reaktancja != null && !RelativeErrorTab11Reaktancja.Contains("x") && Double.Parse(RelativeErrorTab11Reaktancja) > MaxError ||
                    RelativeErrorTab11Rezystancja != null && !RelativeErrorTab11Rezystancja.Contains("x") && Double.Parse(RelativeErrorTab11Rezystancja) > MaxError)
                {
                    BrushConverter conv = new BrushConverter();

                    conv = new BrushConverter();
                    ColorResult4 = conv.ConvertFromString("LightGray") as SolidColorBrush;
                }
                else
                {
                    ColorResult4 = new SolidColorBrush();
                }
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
                }
                maxError25V = value; OnPropertyChanged("MaxError25V");
            }
        }
        private string resistanceOfGround;

        public string ResistanceOfGround
        {
            get { return resistanceOfGround; }
            set
            {

                resistanceOfGround = value;
                OnPropertyChanged("ResistanceOfGround");

                double resGnd = 0;
                try
                {
                    resGnd = Convert.ToDouble(this.ResistanceOfGround.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }
                double resGndv2 = 0;
                try
                {
                    resGnd = Convert.ToDouble(this.ResistanceOfGroundv2.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }


                this.ErrorInValuev2 = resGnd * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercentv2 = ErrorInValuev2 / resGnd * 100;
                this.ErrorInValuev3 = resGndv2 * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercentv3 = ErrorInValuev3 / resGndv2 * 100;
            }
        }
        private string resistanceOfGroundv2;

        public string ResistanceOfGroundv2
        {
            get { return resistanceOfGroundv2; }
            set
            {

                resistanceOfGroundv2 = value;
                OnPropertyChanged("ResistanceOfGroundv2");

                double resGnd = 0;
                try
                {
                    resGnd = Convert.ToDouble(this.ResistanceOfGround.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }

                double resGndv2 = 0;
                try
                {
                    resGnd = Convert.ToDouble(this.ResistanceOfGroundv2.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }


                this.ErrorInValuev2 = resGnd * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercentv2 = ErrorInValuev2 / resGnd * 100;
                this.ErrorInValuev3 = resGndv2 * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercentv3 = ErrorInValuev3 / resGndv2 * 100;

                BrushConverter conv = new BrushConverter();

                //if (ResistanceOfGroundv2 > Math.Abs(RelativeError25V) + MeasureValue25VTab16 || ResistanceOfGroundv2 < MeasureValue25VTab16 - Math.Abs(RelativeError25V))
                //{
                //    conv = new BrushConverter();

                //    ColorResultTab16_25V = conv.ConvertFromString("LightGray") as SolidColorBrush;
                //}
                //else
                //{
                //    ColorResultTab16_25V = new SolidColorBrush();
                //}

                //if (ResistanceOfGroundv2 > Math.Abs(RelativeError) + MeasureValueTab16 || ResistanceOfGroundv2 < MeasureValueTab16 - Math.Abs(RelativeError))
                //{
                //    conv = new BrushConverter();
                //    ColorResultTab16_50V = conv.ConvertFromString("LightGray") as SolidColorBrush;
                //}
                //else
                //{
                //    ColorResultTab16_50V = new SolidColorBrush();
                //}
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

#endregion
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
                }
                downMeasureErrorResistance = value; OnPropertyChanged("DownMeasureErrorResistance");
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
                }
                upMeasureErrorResistance = value; OnPropertyChanged("UpMeasureErrorResistance");
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
                }
                relativeError = value; OnPropertyChanged("RelativeError");
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
                }
                relativeError25V = value; OnPropertyChanged("RelativeError25V");
            }
        }

        private double relativeErrorTab16;

        public double RelativeErrorTab16
        {
            get { return relativeErrorTab16; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                }
                relativeErrorTab16 = value; OnPropertyChanged("RelativeErrorTab16");
            }
        }
        private double relativeError25VTab16;

        public double RelativeError25VTab16
        {
            get { return relativeError25VTab16; }
            set
            {
                double number;
                if (value is double)
                {
                    number = (double)value;
                    number = Math.Round(number, 4);
                    value = number;
                }
                relativeError25VTab16 = value; OnPropertyChanged("RelativeError25VTab16");
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
                }
                maxDifference = value; OnPropertyChanged("MaxDifference");
            }
        }
        private string realValue = "";

        public string RealValue
        {
            get { return realValue; }
            set { realValue = value; OnPropertyChanged("RealValue"); }
        }
        private string recommendValue = "";

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
                }
                referenceVoltage = value; OnPropertyChanged("ReferenceVoltage");
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
                }
                errorInValue = value; OnPropertyChanged("ErrorInValue");
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
                }
                errorInPercent = value; OnPropertyChanged("ErrorInPercent");
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
                }
                valueOfIsolation = value; OnPropertyChanged("ValueOfIsolation");
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
                double measVal = 0;
                double idealVal = 0;
                try
                {
                    measVal = Convert.ToDouble(this.MeasureValue.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }
                try
                {
                    idealVal = Convert.ToDouble(this.IdealValue.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }

                this.DownMeasureError = measVal - measVal * this.Percent * 0.01 - this.ImportantNumber - this.Constant;
                this.UpMeasureError = measVal + measVal * this.Percent * 0.01 + this.ImportantNumber + this.Constant;
                this.MaxError = measVal * this.Percent * 0.01 + this.ImportantNumber + this.Constant;

                BrushConverter conv = new BrushConverter();

                if (idealVal > UpMeasureError || idealVal < DownMeasureError)
                {
                    conv = new BrushConverter();
                    ColorResult = conv.ConvertFromString("LightGray") as SolidColorBrush;
                }
                else
                {
                    ColorResult = new SolidColorBrush();
                }


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
                double measVal = 0;
                double idealVal = 0;
                try
                {
                    measVal = Convert.ToDouble(this.MeasureValue.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }
                try
                {
                    idealVal = Convert.ToDouble(this.IdealValue.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }

                this.DownMeasureError = measVal - measVal * this.Percent * 0.01 - this.ImportantNumber - this.Constant;
                this.UpMeasureError = measVal + measVal * this.Percent * 0.01 + this.ImportantNumber + this.Constant;
                this.MaxError = measVal * this.Percent * 0.01 + this.ImportantNumber + this.Constant;

                BrushConverter conv = new BrushConverter();                

                if (idealVal > UpMeasureError || idealVal < DownMeasureError)
                {
                    conv = new BrushConverter();
                    ColorResult = conv.ConvertFromString("LightGray") as SolidColorBrush;
                }
                else
                {
                    ColorResult = new SolidColorBrush();
                }

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
                double measVal = 0;
                double idealVal = 0;
                try
                {
                    measVal = Convert.ToDouble(this.MeasureValue.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }
                try
                {
                    idealVal = Convert.ToDouble(this.IdealValue.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }

                this.DownMeasureError = measVal - measVal * this.Percent * 0.01 - this.ImportantNumber - this.Constant;
                this.UpMeasureError = measVal + measVal * this.Percent * 0.01 + this.ImportantNumber + this.Constant;
                this.MaxError = measVal * this.Percent * 0.01 + this.ImportantNumber + this.Constant;


                BrushConverter conv = new BrushConverter();
                
                if ( idealVal > UpMeasureError || idealVal < DownMeasureError)
                {
                    conv = new BrushConverter();
                    ColorResult = conv.ConvertFromString("LightGray") as SolidColorBrush;
                }
                else
                {
                    ColorResult = new SolidColorBrush();
                }

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
                }
                percentIdeal = value;
                OnPropertyChanged("PercentIdeal");

                double idealVal = 0;

                try
                {
                    idealVal = Convert.ToDouble(this.IdealValue.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }

                this.ErrorInValue = idealVal * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercent = ErrorInValue / idealVal * 100;
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
                }
                importantNumberIdeal = value;
                OnPropertyChanged("ImportantNumberIdeal");
                double idealVal = 0;

                try
                {
                    idealVal = Convert.ToDouble(this.IdealValue.Replace(".", ","));

                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }

                this.ErrorInValue = idealVal * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                this.ErrorInPercent = ErrorInValue / idealVal * 100;
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
                }
                constantIdeal = value;
                OnPropertyChanged("ConstantIdeal");
                if (!String.IsNullOrEmpty(IdealValue))
                {
                    double idealVal = 0;

                    try
                    {
                        idealVal = Convert.ToDouble(this.IdealValue.Replace(".", ","));

                    }
                    catch (Exception e)
                    {
                        System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                    }
                    this.ErrorInValue = idealVal * this.PercentIdeal * 0.01 + this.ImportantNumberIdeal + this.ConstantIdeal;
                    this.ErrorInPercent = ErrorInValue / idealVal * 100;
                }
            }
        }

        public double AdmissibleDiffrentOfPressures
        {
            get
            {
                return admissibleDiffrentOfPressures;
            }

            set
            {
                admissibleDiffrentOfPressures = value;
                OnPropertyChanged("AdmissibleDiffrentOfPressures");
            }
        }

        public Measure1()
        {
            //Percent = NewWindowTableTemplate.percent;
            //PercentIdeal = NewWindowTableTemplate.percentIdeal;
            //ImportantNumber = NewWindowTableTemplate.importantNumber;
            //ImportantNumberIdeal = NewWindowTableTemplate.importantNumberIdeal;
            //Constant = NewWindowTableTemplate.constant;
            //ConstantIdeal = NewWindowTableTemplate.constantIdeal;


        }
    }
}
