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
    public class NewWindowTable1 : ObservableObject,IEnumerableTable
    {

        public NewWindowTable1()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);

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

        public static string tablePath;
        public string TablePath
        {
            get { return tablePath; }
            set
            {
                tablePath = value;
                OnPropertyChanged("TablePath");
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
                Difference = this.MeasureValue - this.IdealValue;
                this.DownMeasureError = this.MeasureValue - this.MeasureValue * this.Percent*0.01 - this.ImportantNumber - this.Constant;
                this.UpMeasureError = this.MeasureValue + this.MeasureValue * this.Percent*0.01 + this.ImportantNumber + this.Constant;

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
