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
        public void GenerateRandomValues()
        {
            Random rnd = new Random();

            double MinimalValue, MaximalValue,MaximalValuev2,MinimalValuev2,MinimalValueTab16,MaximalValueTab16;

            foreach (var element in Tab)
            {


                if (element.MeasureValue == 0 )
                {
                    if (HighLevel == true)
                    {
                        if(element.IdealValue == 0)
                        {
                            MinimalValuev2 = element.ResistanceOfGround + element.ResistanceOfGround * 0.01 * MinValue;
                            MaximalValuev2 = element.ResistanceOfGround + element.ResistanceOfGround * 0.01 * MaxValue;

                            element.MeasureValue = rnd.NextDouble() * (MaximalValuev2 - MinimalValuev2) + MinimalValuev2;
                            element.MeasureValue25V = rnd.NextDouble() * (MaximalValuev2 - MinimalValuev2) + MinimalValuev2;

                            MinimalValueTab16 = element.ResistanceOfGroundv2 + element.ResistanceOfGroundv2 * 0.01 * MinValue;
                            MaximalValueTab16 = element.ResistanceOfGroundv2 + element.ResistanceOfGroundv2 * 0.01 * MaxValue;

                            element.MeasureValueTab16 = rnd.NextDouble() * (MaximalValueTab16 - MinimalValueTab16) + MinimalValueTab16;
                            element.MeasureValue25VTab16 = rnd.NextDouble() * (MaximalValueTab16 - MinimalValueTab16) + MinimalValueTab16;
                        }
                        else
                        {
                            MinimalValue = element.IdealValue + element.IdealValue * 0.01 * MinValue;
                            MaximalValue = element.IdealValue + element.IdealValue * 0.01 * MaxValue;

                            element.MeasureValue = rnd.NextDouble() * (MaximalValue - MinimalValue) + MinimalValue;
                        }
                    }
                    if (LowLevel == true)
                    {
                        if(element.IdealValue == 0)
                        {
                            MinimalValuev2 = element.ResistanceOfGround - element.ResistanceOfGround * 0.01 * MinValue;
                            MaximalValuev2 = element.ResistanceOfGround - element.ResistanceOfGround * 0.01 * MaxValue;

                            element.MeasureValue = rnd.NextDouble() * ( MinimalValuev2- MaximalValuev2 ) + MaximalValuev2;
                            element.MeasureValue25V = rnd.NextDouble() * (MinimalValuev2 - MaximalValuev2) + MaximalValuev2;

                            MinimalValueTab16 = element.ResistanceOfGroundv2 - element.ResistanceOfGroundv2 * 0.01 * MinValue;
                            MaximalValueTab16 = element.ResistanceOfGroundv2 - element.ResistanceOfGroundv2 * 0.01 * MaxValue;

                            element.MeasureValueTab16 = rnd.NextDouble() * (MinimalValueTab16 - MaximalValueTab16) + MaximalValueTab16;
                            element.MeasureValue25VTab16 = rnd.NextDouble() * (MinimalValueTab16 - MaximalValueTab16) + MaximalValueTab16;
                        }
                        else
                        {
                            MinimalValue = element.IdealValue - element.IdealValue * 0.01 * MinValue;
                            MaximalValue = element.IdealValue - element.IdealValue * 0.01 * MaxValue;
                            element.MeasureValue = rnd.NextDouble() * (MinimalValue - MaximalValue) + MaximalValue;
                        }
                    }
                    if (CenterLevel == true)
                    {
                        if(element.IdealValue == 0)
                        {
                            MinimalValuev2 = element.ResistanceOfGround - element.ResistanceOfGround * 0.01 * MinValue;
                            MaximalValuev2 = element.ResistanceOfGround + element.ResistanceOfGround * 0.01 * MaxValue;

                            element.MeasureValue = rnd.NextDouble() * (MaximalValuev2 - MinimalValuev2) + MinimalValuev2;
                            element.MeasureValue25V = rnd.NextDouble() * (MaximalValuev2 - MinimalValuev2) + MinimalValuev2;

                            MinimalValueTab16 = element.ResistanceOfGroundv2 - element.ResistanceOfGroundv2 * 0.01 * MinValue;
                            MaximalValueTab16 = element.ResistanceOfGroundv2 + element.ResistanceOfGroundv2 * 0.01 * MaxValue;

                            element.MeasureValueTab16 = rnd.NextDouble() * (MaximalValueTab16 - MinimalValueTab16) + MinimalValueTab16;
                            element.MeasureValue25VTab16 = rnd.NextDouble() * (MaximalValueTab16 - MinimalValueTab16) + MinimalValueTab16;
                        }
                        else
                        {
                            MinimalValue = element.IdealValue - element.IdealValue * 0.01 * MinValue;
                            MaximalValue = element.IdealValue + element.IdealValue * 0.01 * MaxValue;
                            element.MeasureValue = rnd.NextDouble() * (MaximalValue - MinimalValue) + MinimalValue;
                        }
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
