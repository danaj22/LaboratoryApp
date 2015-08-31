using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowRaport : ObservableObject
    {
        private gauge aboutGauge;

        public gauge AboutGauge
        {
            get { return aboutGauge; }
            set
            {
                aboutGauge = value;
                OnPropertyChanged("AboutGauge");
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




        public NewWindowRaport()
        {
            CollectionOfCalibrators = new ObservableCollection<calibrator>();
            LaboratoryEntities context = new LaboratoryEntities();
            var ListOfCalibrators = (from c in context.calibrators select c).ToList();

            foreach(var item in ListOfCalibrators)
            {
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

            DateSurvey = DateTime.Now.ToString("dd'/'MM'/'yyyy");

            CheckedFunction = "[Wpisz sprawdzane funkcje funkcje]";
            Uncertainty = "Maksymalna niepewność odwzorowania wartości poprawnej wynosi +/- 0,5 % przy poziomie ufności 95 % na podstawie Publikacji EA-4/02";

            gauge SelectedGauge = (gauge)MainWindowViewModel.selectedNode;
            if ( SelectedGauge.model_of_gauges.type.name == "Elektryczny")
            {
                NumberOfCertificate = DateTime.Now.ToString("yyyy'/'MM") + "/E/DASL";
            }
            else if (SelectedGauge.model_of_gauges.type.name == "Manometr")
            {
                NumberOfCertificate = DateTime.Now.ToString("yyyy'/'MM") + "/M/DASL";
            }
            else if (SelectedGauge.model_of_gauges.type.name == "Luksomierz")
            {
                NumberOfCertificate = DateTime.Now.ToString("yyyy'/'MM") + "/L/DASL";
            }
            else
            {
                NumberOfCertificate = DateTime.Now.ToString("yyyy'/'MM") + "/DASL";
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

