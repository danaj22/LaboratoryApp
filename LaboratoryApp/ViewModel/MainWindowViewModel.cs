using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp.ViewModel
{
    class MainWindowViewModel : ObservableObject
    {
        private ObservableCollection<client> collectionOfClients = new ObservableCollection<client>();

        public ObservableCollection<client> CollectionOfClients
        {
            get { return collectionOfClients; }
            set 
            {
                collectionOfClients = value;
                OnPropertyChanged("CollectionOfClients");
            }
        }
        private UserInput userInput;

        public UserInput UserInput
        {
            get { return userInput; }
            set { userInput = value; }
        }

        public MainWindowViewModel()
        {
            userInput = new UserInput();

        }
    }
}
