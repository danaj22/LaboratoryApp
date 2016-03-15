using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class ValuesToTable11 : ObservableObject
    {
        Stream stream;
        BinaryFormatter bformatter = new BinaryFormatter();

        public ValuesToTable11()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            CollectionOfValuesToTable11 = new ObservableCollection<ResistanceImpedanceReactance>();

            if (File.Exists(@"C:\ProgramData\DASLSystems\LaboratoryApp\Val.Values11"))
            {
                try
                {
                    stream = File.Open(@"C:\ProgramData\DASLSystems\LaboratoryApp\Val.Values11", FileMode.Open);
                    CollectionOfValuesToTable11 = (ObservableCollection<ResistanceImpedanceReactance>)bformatter.Deserialize(stream);
                    stream.Close();

                }
                catch(Exception e)
                {
                    File.AppendAllText(MainWindowViewModel.path, e.ToString());
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

        private ICommand selectPathCommand;

        public ICommand SelectPathCommand
        {
            get { return selectPathCommand; }
            set
            {
                selectPathCommand = value;
                OnPropertyChanged("SelectPathCommand");
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

        public ObservableCollection<ResistanceImpedanceReactance> CollectionOfValuesToTable11
        {
            get
            {
                return collectionOfValuesToTable11;
            }

            set
            {
                collectionOfValuesToTable11 = value;
                OnPropertyChanged("CollectionOfValuesToTable11");
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

        ObservableCollection<ResistanceImpedanceReactance> collectionOfValuesToTable11;
    }
    
    [Serializable()]
    public class ResistanceImpedanceReactance : ObservableObject, ISerializable
    {

        public ResistanceImpedanceReactance()
        { }
        //Deserialization constructor.
        public ResistanceImpedanceReactance(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            IdealValue = (string)info.GetValue("IdealVal", typeof(string));
            IdealValueTab11Reaktancja = (string)info.GetValue("IdealValReaktancja", typeof(string));
            IdealValueTab11Rezystancja = (string)info.GetValue("IdealValRezystancja", typeof(string));


        }

        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"


            info.AddValue("IdealVal", IdealValue);
            info.AddValue("IdealValReaktancja", IdealValueTab11Reaktancja);
            info.AddValue("IdealValRezystancja", IdealValueTab11Rezystancja);



        }

        private string idealValueTab11Rezystancja;
        private string idealValueTab11Reaktancja;
        private string idealValue;
        
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
            }
        }
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
            }
        }
        public string IdealValue
        {
            get
            {
                return idealValue;
            }

            set
            {
                idealValue = value;
                OnPropertyChanged("IdealValue");
            }
        }
    }


}
