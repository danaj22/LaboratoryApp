using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowTableTemplate : ObservableObject
    {

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

       
        private Measure1 selectedData;

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

        public Measure1 SelectedData
        {
            get
            {
                return selectedData;
            }

            set
            {
                selectedData = value;
                OnPropertyChanged("SelectedData");
            }
        }
    }
    
}
