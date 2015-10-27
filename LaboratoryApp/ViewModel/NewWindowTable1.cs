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
    public class NewWindowTable1 : ObservableObject
    {
        string line, ValueOfCell;
        double cons, percnt, impNum, idealVal;

        public NewWindowTable1()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);

            Table1Path = @"C:\ProgramData\DASLSystems\LaboratoryApp\pomiar_MPI-525.txt";

            if (!File.Exists(Table1Path))
            {
                File.Create(Table1Path);
            }
            else
            {
                System.Windows.MessageBox.Show("Taka tabela już istnieje.");

                string[] s = File.ReadAllLines(Table1Path);

                foreach (string str in s)
                {
                    line = str;

                    //read IdealValue
                    int index = str.IndexOf("\t");
                    ValueOfCell = str.Substring(0, index);
                    idealVal = Convert.ToDouble(ValueOfCell);

                    //read Percent
                    line = str.Substring(index + 1);
                    index = line.IndexOf("\t");
                    ValueOfCell = line.Substring(0, index);
                    percnt = Convert.ToDouble(ValueOfCell);

                    //read ImportantNumber
                    line = line.Substring(index + 1);
                    index = line.IndexOf("\t");
                    ValueOfCell = line.Substring(0, index);
                    impNum = Convert.ToDouble(ValueOfCell);

                    //read Constant
                    line = line.Substring(index + 1);
                    ValueOfCell = line;
                    cons = Convert.ToDouble(ValueOfCell);

                    Measure1 m = new Measure1();
                    m.ImportantNumber = impNum;
                    m.Constant = cons;
                    m.Percent = percnt;
                    m.IdealValue = idealVal;
                    Tab.Add(m);
                }
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
                Difference = this.IdealValue - this.MeasureValue;
                this.DownMeasureError = this.MeasureValue - this.MeasureValue * this.Percent - this.ImportantNumber - this.Constant;
                this.UpMeasureError = this.MeasureValue + this.MeasureValue * this.Percent + this.ImportantNumber + this.Constant;

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
                Difference = this.IdealValue - this.MeasureValue;
                this.DownMeasureError = this.MeasureValue - this.MeasureValue * this.Percent - this.ImportantNumber - this.Constant;
                this.UpMeasureError = this.MeasureValue + this.MeasureValue * this.Percent + this.ImportantNumber + this.Constant;

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

        public string ErrorInValue { get; set; }
        public string ErrorInPercent { get; set; }

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


        public Measure1()
        {
            Percent = NewWindowTable1.percent;
            ImportantNumber = NewWindowTable1.importantNumber;
            Constant = NewWindowTable1.constant;
        }

    }
}
