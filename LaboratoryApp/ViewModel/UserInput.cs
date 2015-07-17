using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp.ViewModel
{
    class UserInput : ObservableObject
    {
        private int temperature;
        private string nameAndSurname;
        
        public int Temperature
        {
            get { return temperature; }
            set 
            {
                temperature = value;
                OnPropertyChanged("Temperature");
            }
        }

        public string NameAndSurname
        {
            get { return nameAndSurname; }
            set 
            {
                nameAndSurname = value;
                OnPropertyChanged("NameAndSurname");
            }
        }


    }
}
