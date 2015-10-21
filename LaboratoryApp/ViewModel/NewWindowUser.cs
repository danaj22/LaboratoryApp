using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowUser:ObservableObject
    {
        public NewWindowUser()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            SelectPathCommand = new SimpleRelayCommand(SelectPath);
            PathIsSelected = "Nie wybrano pieczątki.";
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

        public void Confirm()
        {
            if (!this.ToConfirm) ToConfirm = true;

            IsOpen = false;

        }
        public void Close()
        {
            IsOpen = false;
        }

        private string nameOfUser;

        public string NameOfUser
        {
            get { return nameOfUser; }
            set 
            {
                nameOfUser = value;
                OnPropertyChanged("NameOfUser");
            }
        }
        private string pathOfStamp;

        public string PathOfStamp
        {
            get { return pathOfStamp; }
            set 
            {
                pathOfStamp = value;
                OnPropertyChanged("PathOfStamp");
            }
        }
        private string pathIsSelected;

        public string PathIsSelected
        {
            get { return pathIsSelected; }
            set 
            {
                pathIsSelected = value;
                OnPropertyChanged("PathIsSelected");
            }
        }
       
        private void SelectPath()
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            bool? userClickedOK = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                if (!string.IsNullOrEmpty(openFileDialog1.FileName))
                {
                    PathOfStamp = openFileDialog1.FileName;
                    PathIsSelected = "Wybrano pieczątkę.";
                }
                
                
            }
        }
    }
    
}
