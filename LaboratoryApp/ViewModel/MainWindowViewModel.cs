using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp
{
    public class MainWindowViewModel : ObservableObject
    {
       
        private LoadData data;

        public LoadData Data
        {
            get { return data; }
            set 
            { 
                data = value;
                OnPropertyChanged("Data");
            }
        }
        
        private UserInput userInput;

        public UserInput UserInput
        {
            get { return userInput; }
            set { userInput = value; }
        }

        private void LoadView()
        {
            data = new LoadData();
        }

        public MainWindowViewModel()
        {
            userInput = new UserInput();
            LoadView();
        }
    }
}
