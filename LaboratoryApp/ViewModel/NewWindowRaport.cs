using LaboratoryApp.Models;
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
    public class NewWindowRaport : ObservableObject
    {
        private gauge aboutGauge = new gauge();
        public gauge AboutGauge
        {
            get { return aboutGauge; }
            set
            {
                aboutGauge = value;
                OnPropertyChanged("AboutGauge");
            }
        }
        private ObservableCollection<function> collectionOfCheckedFunction;

        public ObservableCollection<function> CollectionOfCheckedFunction
        {
            get { return collectionOfCheckedFunction; }
            set 
            {
                collectionOfCheckedFunction = value;
                OnPropertyChanged("CollectionOfCheckedFunction");
            }
        }

        private float cost;
        public float Cost
        {
            get { return cost; }
            set
            {
                cost = value;
                OnPropertyChanged("Cost");
            }
        }
        private string footer;

        public string Footer
        {
            get { return footer; }
            set
            {
                footer = value;
                OnPropertyChanged("Footer");
            }
        }

        private string recommendations;

        public string Recommendations
        {
            get { return recommendations; }
            set
            {
                recommendations = value;
                OnPropertyChanged("Recommendations");
            }
        }
        private string dateSurvey;

        public string DateSurvey
        {
            get { return dateSurvey; }
            set
            {
                dateSurvey = value;
                OnPropertyChanged("DateSurvey");
            }
        }

        private string numberOfCertificate;

        public string NumberOfCertificate
        {
            get { return numberOfCertificate; }
            set
            {
                numberOfCertificate = value;
                OnPropertyChanged("NumberOfCertificate");
            }
        }
        private string uncertainty;

        public string Uncertainty
        {
            get { return uncertainty; }
            set
            {
                uncertainty = value;
                OnPropertyChanged("Uncertainty");
            }
        }
        private string theCalibrationMethod;

        public string TheCalibrationMethod
        {
            get { return theCalibrationMethod; }
            set
            {
                theCalibrationMethod = value;
                OnPropertyChanged("TheCalibrationMethod");
            }
        }

        private string nationalPattern;

        public string NationalPattern
        {
            get { return nationalPattern; }
            set
            {
                nationalPattern = value;
                OnPropertyChanged("NationalPattern");
            }
        }
        private string temperature;

        public string Temperature
        {
            get { return temperature; }
            set
            {
                temperature = value;
                OnPropertyChanged("Temperature");
            }
        }
        private string humidity;

        public string Humidity
        {
            get { return humidity; }
            set
            {
                humidity = value;
                OnPropertyChanged("Humidity");
            }
        }
        private List<string> compatibility;

        public List<string> Compatibility
        {
            get { return compatibility; }
            set
            {
                compatibility = value;
                OnPropertyChanged("Compability");
            }
        }
        private string selectedCompatibility;

        public string SelectedCompatibility
        {
            get { return selectedCompatibility; }
            set
            {
                selectedCompatibility = value;
                OnPropertyChanged("SelectedCompatibility");
            }
        }

        private List<string> stamp;

        public List<string> Stamp
        {
            get { return stamp; }
            set
            {
                stamp = value;
                OnPropertyChanged("Stamp");
            }
        }
        private string printStamp;

        public string PrintStamp
        {
            get { return printStamp; }
            set
            {
                printStamp = value;
                OnPropertyChanged("PrintStamp");
            }
        }

        private string checkedFunction;


        public string CheckedFunction
        {
            get { return checkedFunction; }
            set
            {
                checkedFunction = value;
                OnPropertyChanged("CheckedFunction");
            }
        }
        private string author;

        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                OnPropertyChanged("Author");
            }
        }

        private ObservableCollection<calibrator> collectionOfCalibrators;

        public ObservableCollection<calibrator> CollectionOfCalibrators
        {
            get { return collectionOfCalibrators; }
            set
            {
                collectionOfCalibrators = value;
                OnPropertyChanged("collectionOfCalibrators");
            }
        }

        private ICommand addCalibratorCommand;
        public ICommand AddCalibratorCommand
        {
            get { return addCalibratorCommand; }
            set
            {
                addCalibratorCommand = value;
                base.OnPropertyChanged("AddCalibratorCommand");
            }
        }
        private ICommand addFunctionCommand;
        public ICommand AddFunctionCommand
        {
            get { return addFunctionCommand; }
            set
            {
                addFunctionCommand = value;
                base.OnPropertyChanged("AddFunctionCommand");
            }
        }

        private NewWindowCalibrator messageWindowCalibrator;

        public NewWindowCalibrator MessageWindowCalibrator
        {
            get { return messageWindowCalibrator; }
            set
            {
                messageWindowCalibrator = value;
                OnPropertyChanged("MessageWindowCalibrator");
            }
        }
        private NewWindowFunction messageWindowFunction;

        public NewWindowFunction MessageWindowFunction
        {
            get { return messageWindowFunction; }
            set
            {
                messageWindowFunction = value;
                OnPropertyChanged("MessageWindowFunction");
            }
        }

        public void AddCalibrator()
        {
            MessageWindowCalibrator = new NewWindowCalibrator();
            MessageWindowCalibrator.IsOpen = true;

            if (MessageWindowCalibrator.ToConfirm)
            {
                if (!string.IsNullOrEmpty(MessageWindowCalibrator.NameOfCalibrator))
                {
                    using (LaboratoryEntities context = new LaboratoryEntities())
                    {
                        calibrator CalibratorToAdd = new calibrator();
                        CalibratorToAdd.name = MessageWindowCalibrator.NameOfCalibrator;

                        context.calibrators.Add(CalibratorToAdd);
                        context.SaveChanges();

                        CollectionOfCalibrators.Add(CalibratorToAdd);
                    }
                }

            }
            MessageWindowCalibrator.ToConfirm = false;
        }

        public void AddFunction()
        {
            MessageWindowFunction = new NewWindowFunction();
            MessageWindowFunction.IsOpen = true;

            if (MessageWindowFunction.ToConfirm)
            {
                
                    using (LaboratoryEntities context = new LaboratoryEntities())
                    {
                        function FunctionToAdd = new function();
                        FunctionToAdd.name = MessageWindowFunction.NameOfFunction;

                        context.functions.Add(FunctionToAdd);
                        context.SaveChanges();

                        CollectionOfCheckedFunction.Add(FunctionToAdd);
                    }
                

            }
            MessageWindowFunction.ToConfirm = false;
        }



        public NewWindowRaport(gauge NewGauge)
        {
            AddCalibratorCommand = new SimpleRelayCommand(AddCalibrator);
            AddFunctionCommand = new SimpleRelayCommand(AddFunction);

            CollectionOfCheckedFunction = new ObservableCollection<function>();
            CollectionOfCalibrators = new ObservableCollection<calibrator>();
            
            LaboratoryEntities context = MainWindowViewModel.Context;
            AboutGauge = NewGauge;


            var ListOfFunctions = (from f in context.functions select f).ToList();
            foreach (function fun in ListOfFunctions)
            {
                fun.IsChecked = false;
            }

            var bbbb = (from mf in context.model_of_gauges_functions where mf.model_of_gauge_id == AboutGauge.model_of_gauge_id select mf.function_Id).ToList();

            foreach (var item in ListOfFunctions)
            {
                if (bbbb.Contains(item.functionId))
                {
                    item.IsChecked = true;
                }

                CollectionOfCheckedFunction.Add(item);
            }


            ///
            ////                |||||||
            ////ZLE PODEJSCIE!! VVVVVVV
            ///
            ///



            //var ListOfFunctions = (from f in context.functions select f).ToList();
            //foreach(function fun in ListOfFunctions)
            //{
            //    fun.IsChecked = false;
            //}
            //if (File.Exists(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\model\" + NewGauge.model_of_gauges.model + ".txt"))
            //{
            //    string[] listOfFunctionFromFile = File.ReadAllLines(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\model\" + NewGauge.model_of_gauges.model + ".txt");


            //        foreach (string str in listOfFunctionFromFile)
            //        {
            //            ListOfFunctions[Convert.ToInt16(str) - 1].IsChecked = true;
            //        }


            //}

            //foreach(function f in ListOfFunctions)
            //{
            //   // if(f.IsChecked)
            //   // {
            //        CollectionOfCheckedFunction.Add(f);
            //    //}
            //}





            var ListOfCalibrators = (from c in context.calibrators select c).ToList();
            
            foreach(var item in ListOfCalibrators)
            {
                item.IsChecked = false; 
            }

            var rrrr = (from cm in context.calibrators_model_of_gauges where cm.model_of_gaug_id == AboutGauge.model_of_gauge_id select cm.calibrator_id).ToList();

            foreach (var item in ListOfCalibrators)
            {
                if (rrrr.Contains(item.calibratorId))
                {
                    item.IsChecked = true;
                }

                CollectionOfCalibrators.Add(item);
            }


            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            Footer = "Świadectwo składa się z 1 strony. Może być okazywane lub kopiowane tylko w całości.";
            TheCalibrationMethod = "Porównanie wartości mierzonej miernikiem sprawdzanym z wielkością wzorcową na podstawie instrukcji IZ/001/DASL i pozostałych";
            NationalPattern = "Wyniki wzorcowania zostały odniesione do państwowych wzorców jednostek miar poprzez zastosowanie:\n\n";

            Temperature = MainWindowViewModel.temperature;
            Humidity = "(30-60) %";

            Compatibility = new List<string>();
            Compatibility.Add("Zgodny");
            Compatibility.Add("Niezgodny");
            SelectedCompatibility = Compatibility.First();

            Stamp = new List<string>();
            Stamp.Add("Nie");
            Stamp.Add("Tak");
            PrintStamp = Stamp.First();

            DateSurvey = DateTime.Now.ToString("dd'/'MM'/'yyyy");

            Uncertainty = "Maksymalna niepewność odwzorowania wartości poprawnej wynosi +/- 0,5 % przy poziomie ufności 95 % na podstawie Publikacji EA-4/02";

            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            //System.Windows.MessageBox.Show(firstDayOfMonth.ToString());

            gauge SelectedGauge = (gauge)MainWindowViewModel.selectedNode;
            if (SelectedGauge.model_of_gauges.type.name == "Elektryczny")
            {
                var count = (from c in context.certificates where c.date >= firstDayOfMonth && c.date <= lastDayOfMonth && c.gauge.model_of_gauges.type.name == "Elektryczny" select c).Count();
                NumberOfCertificate = DateTime.Now.ToString("yyyy'/'MM") + "/" + (count+1) + "/E/DASL";
            }
            else if (SelectedGauge.model_of_gauges.type.name == "Manometr")
            {
                var count = (from c in context.certificates where c.date >= firstDayOfMonth && c.date <= lastDayOfMonth && c.gauge.model_of_gauges.type.name == "Manometr" select c).Count();

                NumberOfCertificate = DateTime.Now.ToString("yyyy'/'MM") + "/" + (count+1) + "/M/DASL";
            }
            else if (SelectedGauge.model_of_gauges.type.name == "Luksomierz")
            {
                var count = (from c in context.certificates where c.date >= firstDayOfMonth && c.date <= lastDayOfMonth && c.gauge.model_of_gauges.type.name == "Luksomierz" select c).Count();
                NumberOfCertificate = DateTime.Now.ToString("yyyy'/'MM") + "/" + (count+1) + "/L/DASL";
            }
            else
            {
                var count = (from c in context.certificates where c.date >= firstDayOfMonth && c.date <= lastDayOfMonth && c.gauge.model_of_gauges.type.name != "Luksomierz" && c.gauge.model_of_gauges.type.name != "Manometr" && c.gauge.model_of_gauges.type.name != "Elektryczny" select c).Count();

                NumberOfCertificate = DateTime.Now.ToString("yyyy'/'MM") + "/" + (count+1) + "/DASL";
            }

            Recommendations = "Jeśli harmonogram Zleceniodawcy nie przewiduje inaczej, to następne wzorcowanie zaleca się przeprowadzić przed upływem ostatniego dnia analogicznego miesiąca następnego roku (w stosunku do daty wystawienia) lub w przypadku uszkodzenia";
            Author = MainWindowViewModel.nameAndSurname;



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
            if (!ToConfirm) ToConfirm = true;
            IsOpen = false;

        }
        public void Close()
        {
            IsOpen = false;
        }

    }
}

