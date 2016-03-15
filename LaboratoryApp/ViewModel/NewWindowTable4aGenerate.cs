using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowTable4aGenerate : ObservableObject
    {
         public NewWindowTable4aGenerate()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            GenerateRandomValuesCommand = new SimpleRelayCommand(GenerateRandomValues);
            ColumnNames.Add("Rzeczywista nastawiona wartość rezystancji na dekadzie kontrolnej [Ω]");

            ColumnNames.Add("Odczytana wartość rezystancji na mierniku sprawdzanym przy napięciu 50V [Ω]");
            ColumnNames.Add("Odczytana wartość rezystancji na mierniku sprawdzanym przy napięciu 100V [Ω]");
            ColumnNames.Add("Odczytana wartość rezystancji na mierniku sprawdzanym przy napięciu 250V [Ω]");

            ColumnNames.Add("Różnica wartości kontrolnej i sprawdzanej przy napięciu 50V [Ω]");
            ColumnNames.Add("Różnica wartości kontrolnej i sprawdzanej przy napięciu 100V [Ω]");
            ColumnNames.Add("Różnica wartości kontrolnej i sprawdzanej przy napięciu 250V [Ω]");

            ColumnNames.Add("Niepewność całkowita rozszerzona typu B przy napięciu 50V [Ω]");
            ColumnNames.Add("Niepewność całkowita rozszerzona typu B przy napięciu 100V [Ω]");
            ColumnNames.Add("Niepewność całkowita rozszerzona typu B przy napięciu 250V [Ω]");
        }
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
        void GenerateRandomValues()
        {
            Random rnd = new Random();

            double MinimalValue, MaximalValue;

            foreach (var element in Tab)
            {
                
                if (string.IsNullOrEmpty(element.MeasureValue))
                {
                    double idealVal = Convert.ToDouble(element.IdealValue.Replace(".", ","));
                    if (HighLevel == true)
                    {

                        MinimalValue = idealVal + idealVal * 0.01 * MinValue;
                        MaximalValue = idealVal + idealVal * 0.01 * MaxValue;
                        element.MeasureValue = (rnd.NextDouble() * (MaximalValue - MinimalValue) + MinimalValue).ToString();
                    }
                    if (LowLevel == true)
                    {
                        MinimalValue = idealVal - idealVal * 0.01 * MinValue;
                        MaximalValue = idealVal - idealVal * 0.01 * MaxValue;
                        element.MeasureValue = (rnd.NextDouble() * (MinimalValue - MaximalValue) + MaximalValue).ToString();
                    }
                    if (CenterLevel == true)
                    {
                        MinimalValue = idealVal - idealVal * 0.01 * MinValue;
                        MaximalValue = idealVal + idealVal * 0.01 * MaxValue;
                        element.MeasureValue = (rnd.NextDouble() * (MaximalValue - MinimalValue) + MinimalValue).ToString();
                    }

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
