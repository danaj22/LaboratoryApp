using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowTableGenerate : ObservableObject
    {
        private List<string> columnNames = new List<string>();
        public List<string> ColumnNames
        {
            get { return columnNames; }
            set { columnNames = value; }
        }

        private string nameOfFile;
        public string NameOfFile
        {
            get { return nameOfFile; }
            set
            {
                nameOfFile = value;
                OnPropertyChanged("NameOfFile");
            }
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
                OnPropertyChanged("CancelCommand");
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
        private ICommand generateRandomValuesCommand;

        public ICommand GenerateRandomValuesCommand
        {
            get { return generateRandomValuesCommand; }
            set { generateRandomValuesCommand = value; OnPropertyChanged("GenerateRandomValuesCommand"); }
        }
        private double minValue;

        public double MinValue
        {
            get { return minValue; }
            set
            {
                minValue = value;
                OnPropertyChanged("MinValue");
            }
        }
        private double maxValue;

        public double MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; OnPropertyChanged("MaxValue"); }
        }

        public void Confirm()
        {
            if (!this.ToConfirm) ToConfirm = true;

            IsOpen = false;

        }
        public void Close()
        {
            IsOpen = false;
        }

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public static string table1Path;
        public string Table1Path
        {
            get { return table1Path; }
            set
            {
                table1Path = value;
                OnPropertyChanged("Table1Path");
            }
        }

        public static double constant;
        public double Constant
        {
            get { return constant; }
            set
            {
                constant = value;
                OnPropertyChanged("Constant");
            }
        }

        public static double importantNumber;
        public double ImportantNumber
        {
            get { return importantNumber; }
            set
            {
                importantNumber = value;
                OnPropertyChanged("ImportantNumber");

            }
        }

        public static double percent;
        public double Percent
        {
            get { return percent; }
            set
            {
                percent = value;
                OnPropertyChanged("Percent");

            }
        }

        private bool highLevel;
        public bool HighLevel
        {
            get { return highLevel; }
            set { highLevel = value; OnPropertyChanged("HighLevel"); }
        }

        private bool lowLevel;

        public bool LowLevel
        {
            get { return lowLevel; }
            set { lowLevel = value; OnPropertyChanged("LowLevel"); }
        }
        private bool centerLevel;

        public bool CenterLevel
        {
            get { return centerLevel; }
            set { centerLevel = value; OnPropertyChanged("CenterLevel"); }
        }
        private int CountDigitsAfterDecimal(string IdealValue)
        {

            string TemporaryIdealValue = IdealValue;

            int digitsAfterDecimal = 0;

            if (TemporaryIdealValue.Contains(","))
            {
                int index = TemporaryIdealValue.IndexOf(",");
                TemporaryIdealValue = TemporaryIdealValue.Substring(index + 1);
                digitsAfterDecimal = TemporaryIdealValue.Length;
            }
            if(TemporaryIdealValue.Contains("."))
            {
                int index = TemporaryIdealValue.IndexOf(".");
                TemporaryIdealValue = TemporaryIdealValue.Substring(index + 1);
                digitsAfterDecimal = TemporaryIdealValue.Length;
            }

            return digitsAfterDecimal;
        }
        public void GenerateRandomValues()
        {
            Random rnd = new Random();

            double MinimalValue, MaximalValue,MaximalValuev2,MinimalValuev2,MinimalValueTab16,MaximalValueTab16;
            double MinimalValueTab11, MaximalValueTab11;

            foreach (var element in Tab)
            {


                if (string.IsNullOrEmpty(element.MeasureValue))
                {
                    double idealVal = 0;
                    double resGnd = 0;
                    double resGndv2 = 0;
                    try {
                        idealVal = Convert.ToDouble(element.IdealValue.Replace(".", ","));
                    }
                    catch(Exception e)
                    {
                        System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                    }
                    
                    try
                    {
                        resGnd = Convert.ToDouble(element.ResistanceOfGround.Replace(".", ","));

                    }
                    catch (Exception e)
                    {
                        System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                    }
                    try
                    {
                        resGndv2 = Convert.ToDouble(element.ResistanceOfGroundv2.Replace(".", ","));

                    }
                    catch (Exception e)
                    {
                        System.IO.File.AppendAllText(MainWindowViewModel.path, e.ToString());
                    }

                    if (HighLevel == true)
                    {
                        if(idealVal == 0)
                        {
                            MinimalValuev2 = resGnd + resGnd * 0.01 * MinValue;
                            MaximalValuev2 = resGnd + resGnd * 0.01 * MaxValue;

                            element.MeasureValue = (rnd.NextDouble() * (MaximalValuev2 - MinimalValuev2) + MinimalValuev2).ToString();
                            element.MeasureValue25V = (rnd.NextDouble() * (MaximalValuev2 - MinimalValuev2) + MinimalValuev2).ToString();

                            //how many number shoud be after comma
                            int count = CountDigitsAfterDecimal(element.ResistanceOfGround);
                            element.MeasureValue = (Math.Round(Convert.ToDouble(element.MeasureValue.Replace(".", ",")), count)).ToString();
                            element.MeasureValue25V = (Math.Round(Convert.ToDouble(element.MeasureValue25V.Replace(".", ",")), count)).ToString();

                            MinimalValueTab16 = resGndv2 + resGndv2 * 0.01 * MinValue;
                            MaximalValueTab16 = resGndv2 + resGndv2 * 0.01 * MaxValue;

                            element.MeasureValueTab16 = (rnd.NextDouble() * (MaximalValueTab16 - MinimalValueTab16) + MinimalValueTab16).ToString();
                            element.MeasureValue25VTab16 = (rnd.NextDouble() * (MaximalValueTab16 - MinimalValueTab16) + MinimalValueTab16).ToString();

                            count = CountDigitsAfterDecimal(element.ResistanceOfGroundv2);
                            element.MeasureValueTab16 = (Math.Round(Convert.ToDouble(element.MeasureValueTab16.Replace(".", ",")), count)).ToString();
                            element.MeasureValue25VTab16 = (Math.Round(Convert.ToDouble(element.MeasureValue25VTab16.Replace(".", ",")), count)).ToString();

                            //element.MeasureValue = Math.Round(element.MeasureValue
                        }
                        else
                        {
                            MinimalValue = idealVal + idealVal * 0.01 * MinValue;
                            MaximalValue = idealVal + idealVal * 0.01 * MaxValue;

                            element.MeasureValue = (rnd.NextDouble() * (MaximalValue - MinimalValue) + MinimalValue).ToString();

                            //how many number shoud be after comma
                            int count = CountDigitsAfterDecimal(element.IdealValue);
                            element.MeasureValue = (Math.Round(Convert.ToDouble(element.MeasureValue.Replace(".", ",")), count)).ToString();


                            
                            MinimalValuev2 = resGnd + resGnd * 0.01 * MinValue;
                            MaximalValuev2 = resGnd + resGnd * 0.01 * MaxValue;
                            if (MinimalValuev2 == 0)
                            {
                                element.MeasureValue25V = (rnd.NextDouble() * (MaximalValue - MinimalValue) + MinimalValue).ToString();
                                
                            }
                            else
                            {
                                element.MeasureValue25V = (rnd.NextDouble() * (MaximalValuev2 - MinimalValuev2) + MinimalValuev2).ToString();
                            }
                            
                            //how many number shoud be after comma
                            element.MeasureValue25V = (Math.Round(Convert.ToDouble(element.MeasureValue25V.Replace(".", ",")), count)).ToString();
                        }
                    }
                    if (LowLevel == true)
                    {
                        if(idealVal == 0)
                        {
                            MinimalValuev2 = resGnd - resGnd * 0.01 * MinValue;
                            MaximalValuev2 = resGnd - resGnd * 0.01 * MaxValue;

                            element.MeasureValue = (rnd.NextDouble() * ( MinimalValuev2- MaximalValuev2 ) + MaximalValuev2).ToString();
                            element.MeasureValue25V = (rnd.NextDouble() * (MinimalValuev2 - MaximalValuev2) + MaximalValuev2).ToString();

                            //how many number shoud be after comma
                            int count = CountDigitsAfterDecimal(element.ResistanceOfGround);
                            element.MeasureValue = (Math.Round(Convert.ToDouble(element.MeasureValue.Replace(".", ",")), count)).ToString();
                            element.MeasureValue25V = (Math.Round(Convert.ToDouble(element.MeasureValue25V.Replace(".", ",")), count)).ToString();

                            MinimalValueTab16 = resGndv2 - resGndv2 * 0.01 * MinValue;
                            MaximalValueTab16 = resGndv2 - resGndv2 * 0.01 * MaxValue;

                            element.MeasureValueTab16 = (rnd.NextDouble() * (MinimalValueTab16 - MaximalValueTab16) + MaximalValueTab16).ToString();
                            element.MeasureValue25VTab16 = (rnd.NextDouble() * (MinimalValueTab16 - MaximalValueTab16) + MaximalValueTab16).ToString();

                            count = CountDigitsAfterDecimal(element.ResistanceOfGroundv2);
                            element.MeasureValueTab16 = (Math.Round(Convert.ToDouble(element.MeasureValueTab16.Replace(".", ",")), count)).ToString();
                            element.MeasureValue25VTab16 = (Math.Round(Convert.ToDouble(element.MeasureValue25VTab16.Replace(".", ",")), count)).ToString();

                        }
                        else
                        {
                            MinimalValue = idealVal + idealVal * 0.01 * MinValue;
                            MaximalValue = idealVal + idealVal * 0.01 * MaxValue;
                            element.MeasureValue = (rnd.NextDouble() * (MinimalValue - MaximalValue) + MaximalValue).ToString();

                            //how many number shoud be after comma
                            int count = CountDigitsAfterDecimal(element.IdealValue);
                            element.MeasureValue = (Math.Round(Convert.ToDouble(element.MeasureValue.Replace(".", ",")), count)).ToString();
                        }
                    }
                    if (CenterLevel == true)
                    {
                        if(idealVal == 0)
                        {
                            MinimalValuev2 = resGnd - resGnd * 0.01 * MinValue;
                            MaximalValuev2 = resGnd + resGnd * 0.01 * MaxValue;

                            element.MeasureValue = (rnd.NextDouble() * (MaximalValuev2 - MinimalValuev2) + MinimalValuev2).ToString();
                            element.MeasureValue25V = (rnd.NextDouble() * (MaximalValuev2 - MinimalValuev2) + MinimalValuev2).ToString();

                            //how many number shoud be after comma
                            int count = CountDigitsAfterDecimal(element.ResistanceOfGround);
                            element.MeasureValue = (Math.Round(Convert.ToDouble(element.MeasureValue.Replace(".", ",")), count)).ToString();
                            element.MeasureValue25V = (Math.Round(Convert.ToDouble(element.MeasureValue25V.Replace(".", ",")), count)).ToString();

                            MinimalValueTab16 = resGndv2 - resGndv2 * 0.01 * MinValue;
                            MaximalValueTab16 = resGndv2 + resGndv2 * 0.01 * MaxValue;

                            element.MeasureValueTab16 = (rnd.NextDouble() * (MaximalValueTab16 - MinimalValueTab16) + MinimalValueTab16).ToString();
                            element.MeasureValue25VTab16 = (rnd.NextDouble() * (MaximalValueTab16 - MinimalValueTab16) + MinimalValueTab16).ToString();

                            count = CountDigitsAfterDecimal(element.ResistanceOfGroundv2);
                            element.MeasureValueTab16 = (Math.Round(Convert.ToDouble(element.MeasureValueTab16.Replace(".", ",")), count)).ToString();
                            element.MeasureValue25VTab16 = (Math.Round(Convert.ToDouble(element.MeasureValue25VTab16.Replace(".", ",")), count)).ToString();

                        }
                        else
                        {
                            MinimalValue = idealVal + idealVal * 0.01 * MinValue;
                            MaximalValue = idealVal + idealVal * 0.01 * MaxValue;
                            element.MeasureValue = (rnd.NextDouble() * (MaximalValue - MinimalValue) + MinimalValue).ToString();

                            //how many number shoud be after comma
                            int count = CountDigitsAfterDecimal(element.IdealValue);
                            element.MeasureValue = (Math.Round(Convert.ToDouble(element.MeasureValue.Replace(".", ",")), count)).ToString();
                        }
                    }

                }
                if(String.IsNullOrEmpty(element.MeasureValueTab11Rezystancja)  && !String.IsNullOrEmpty(element.IdealValueTab11Rezystancja))
                {

                    if (HighLevel == true)
                    {
                        //for table 11 generate resistance and reactance
                        MinimalValueTab11 = Convert.ToDouble(element.IdealValueTab11Rezystancja.Replace(".", ",")) + Convert.ToDouble(element.IdealValueTab11Rezystancja.Replace(".", ",")) * 0.01 * MinValue;
                        MaximalValueTab11 = Convert.ToDouble(element.IdealValueTab11Rezystancja.Replace(".", ",")) + Convert.ToDouble(element.IdealValueTab11Rezystancja.Replace(".", ",")) * 0.01 * MaxValue;

                        element.MeasureValueTab11Rezystancja = (rnd.NextDouble() * (MaximalValueTab11 - MinimalValueTab11) + MinimalValueTab11).ToString();
                        int count = CountDigitsAfterDecimal(element.IdealValueTab11Rezystancja);

                        if (count > 1)
                        {
                            element.MeasureValueTab11Rezystancja = (Math.Round(Convert.ToDouble(element.MeasureValueTab11Rezystancja.Replace(".", ",")), count)).ToString();
                        }
                        else
                        {
                            element.MeasureValueTab11Rezystancja = (Math.Round(Convert.ToDouble(element.MeasureValueTab11Rezystancja.Replace(".", ",")), 2)).ToString();
                        }

                    }

                    else if (LowLevel == true)
                    {
                        MinimalValueTab11 = Convert.ToDouble(element.IdealValueTab11Rezystancja.Replace(".", ",")) - Convert.ToDouble(element.IdealValueTab11Rezystancja.Replace(".", ",")) * 0.01 * MinValue;
                        MaximalValueTab11 = Convert.ToDouble(element.IdealValueTab11Rezystancja.Replace(".", ",")) - Convert.ToDouble(element.IdealValueTab11Rezystancja.Replace(".", ",")) * 0.01 * MaxValue;

                        element.MeasureValueTab11Rezystancja = (rnd.NextDouble() * (MinimalValueTab11 - MaximalValueTab11) + MaximalValueTab11).ToString();
                        int count = CountDigitsAfterDecimal(element.IdealValueTab11Rezystancja);
                        if (count > 1)
                        {
                            element.MeasureValueTab11Rezystancja = (Math.Round(Convert.ToDouble(element.MeasureValueTab11Rezystancja.Replace(".", ",")), count)).ToString();
                        }
                        else
                        {
                            element.MeasureValueTab11Rezystancja = (Math.Round(Convert.ToDouble(element.MeasureValueTab11Rezystancja.Replace(".", ",")), 2)).ToString();
                        }
                    }

                    else if (CenterLevel == true)
                    {
                        MinimalValueTab11 = Convert.ToDouble(element.IdealValueTab11Rezystancja.Replace(".", ",")) - Convert.ToDouble(element.IdealValueTab11Rezystancja.Replace(".", ",")) * 0.01 * MinValue;
                        MaximalValueTab11 = Convert.ToDouble(element.IdealValueTab11Rezystancja.Replace(".", ",")) + Convert.ToDouble(element.IdealValueTab11Rezystancja.Replace(".", ",")) * 0.01 * MaxValue;

                        element.MeasureValueTab11Rezystancja = (rnd.NextDouble() * (MaximalValueTab11 - MinimalValueTab11) + MinimalValueTab11).ToString();
                        int count = CountDigitsAfterDecimal(element.IdealValueTab11Rezystancja);
                        if (count > 1)
                        {
                            element.MeasureValueTab11Rezystancja = (Math.Round(Convert.ToDouble(element.MeasureValueTab11Rezystancja.Replace(".", ",")), count)).ToString();
                        }
                        else
                        {
                            element.MeasureValueTab11Rezystancja = (Math.Round(Convert.ToDouble(element.MeasureValueTab11Rezystancja.Replace(".", ",")), 2)).ToString();
                        }
                    }

                }

                if (String.IsNullOrEmpty(element.MeasureValueTab11Reaktancja) && !String.IsNullOrEmpty(element.IdealValueTab11Reaktancja))
                {

                    if (HighLevel == true)
                    {
                        //for table 11 generate resistance and reactance
                        MinimalValueTab11 = Convert.ToDouble(element.IdealValueTab11Reaktancja.Replace(".", ",")) + Convert.ToDouble(element.IdealValueTab11Reaktancja.Replace(".", ",")) * 0.01 * MinValue;
                        MaximalValueTab11 = Convert.ToDouble(element.IdealValueTab11Reaktancja.Replace(".", ",")) + Convert.ToDouble(element.IdealValueTab11Reaktancja.Replace(".", ",")) * 0.01 * MaxValue;

                        element.MeasureValueTab11Reaktancja = (rnd.NextDouble() * (MaximalValueTab11 - MinimalValueTab11) + MinimalValueTab11).ToString();
                        int count = CountDigitsAfterDecimal(element.IdealValueTab11Reaktancja);
                        if (count > 1)
                        {
                            element.MeasureValueTab11Reaktancja = (Math.Round(Convert.ToDouble(element.MeasureValueTab11Reaktancja.Replace(".", ",")), count)).ToString();
                        }
                        else
                        {
                            element.MeasureValueTab11Reaktancja = (Math.Round(Convert.ToDouble(element.MeasureValueTab11Reaktancja.Replace(".", ",")), 2)).ToString();
                        }

                    }

                    else if (LowLevel == true)
                    {
                        MinimalValueTab11 = Convert.ToDouble(element.IdealValueTab11Reaktancja.Replace(".", ",")) - Convert.ToDouble(element.IdealValueTab11Reaktancja.Replace(".", ",")) * 0.01 * MinValue;
                        MaximalValueTab11 = Convert.ToDouble(element.IdealValueTab11Reaktancja.Replace(".", ",")) - Convert.ToDouble(element.IdealValueTab11Reaktancja.Replace(".", ",")) * 0.01 * MaxValue;

                        element.MeasureValueTab11Reaktancja = (rnd.NextDouble() * (MinimalValueTab11 - MaximalValueTab11) + MaximalValueTab11).ToString();
                        int count = CountDigitsAfterDecimal(element.IdealValueTab11Reaktancja);

                        if (count > 1)
                        {
                            element.MeasureValueTab11Reaktancja = (Math.Round(Convert.ToDouble(element.MeasureValueTab11Reaktancja.Replace(".", ",")), count)).ToString();
                        }
                        else
                        {
                            element.MeasureValueTab11Reaktancja = (Math.Round(Convert.ToDouble(element.MeasureValueTab11Reaktancja.Replace(".", ",")), 2)).ToString();
                        }
                    }

                    else if (CenterLevel == true)
                    {
                        MinimalValueTab11 = Convert.ToDouble(element.IdealValueTab11Reaktancja.Replace(".", ",")) - Convert.ToDouble(element.IdealValueTab11Reaktancja.Replace(".", ",")) * 0.01 * MinValue;
                        MaximalValueTab11 = Convert.ToDouble(element.IdealValueTab11Reaktancja.Replace(".", ",")) + Convert.ToDouble(element.IdealValueTab11Reaktancja.Replace(".", ",")) * 0.01 * MaxValue;

                        element.MeasureValueTab11Reaktancja = (rnd.NextDouble() * (MaximalValueTab11 - MinimalValueTab11) + MinimalValueTab11).ToString();
                        int count = CountDigitsAfterDecimal(element.IdealValueTab11Reaktancja);

                        if (count > 1)
                        {
                            element.MeasureValueTab11Reaktancja = (Math.Round(Convert.ToDouble(element.MeasureValueTab11Reaktancja.Replace(".", ",")), count)).ToString();
                        }
                        else
                        {
                            element.MeasureValueTab11Reaktancja = (Math.Round(Convert.ToDouble(element.MeasureValueTab11Reaktancja.Replace(".", ",")), 2)).ToString();
                        }
                    }

                }

                // element.ErrorInValue = element.IdealValue * element.PercentIdeal * 0.01 + element.ImportantNumberIdeal + element.ConstantIdeal;
                //element.ErrorInPercent = element.ErrorInValue / element.IdealValue * 100;



                if (element.MeasureValueTab11Reaktancja != null &&
                    element.MeasureValueTab11Rezystancja != null &&
                    !element.MeasureValueTab11Reaktancja.Contains("x") &&
                    !element.MeasureValueTab11Rezystancja.Contains("x"))
                {
                    double idealValu = Convert.ToDouble(element.IdealValue.Replace(".", ","));
                    element.RelativeErrorTab11Reaktancja = Math.Round(Math.Abs(Double.Parse(element.MeasureValueTab11Reaktancja.Replace(".", ",")) - Double.Parse(element.IdealValueTab11Reaktancja.Replace(".", ","))),4).ToString().Replace(".",",");
                    element.RelativeErrorTab11Rezystancja = Math.Round(Math.Abs(Double.Parse(element.MeasureValueTab11Rezystancja.Replace(".", ",")) - Double.Parse(element.IdealValueTab11Rezystancja.Replace(".", ","))),4).ToString().Replace(".", ",");
                    element.RelativeErrorTab11Impedancja = Math.Round(Math.Abs(Convert.ToDouble(element.MeasureValue.Replace(".", ",")) - idealValu),4);
                }
            }
        }

        private ObservableCollection<Measure1> tab = new ObservableCollection<Measure1>();
        public ObservableCollection<Measure1> Tab
        {
            get { return tab; }
            set
            {
                tab = value;
                OnPropertyChanged("Tab");
            }
        }
    }
}
