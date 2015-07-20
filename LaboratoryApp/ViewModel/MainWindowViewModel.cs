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
            ObservableCollection<Item> items = new ObservableCollection<Item>();
            Item item1 = new Item() {Name = "Item 1"};
            items.Add(item1);

           
            item1.IsExpanded = true;
        }

        public MainWindowViewModel()
        {
            userInput = new UserInput();
            LoadView();
        }

        private object selectedNode = 0;

        public object SelectedNode
        {
            get { return selectedNode; }
            set 
            {
                selectedNode = value;
                Clients InstanceOfClientNode = new Clients();
                InstanceOfClientNode = (Clients)selectedNode;
                System.Windows.MessageBox.Show(InstanceOfClientNode.Key.ToString());
                System.Windows.MessageBox.Show(InstanceOfClientNode.Name);
                System.Windows.MessageBox.Show(InstanceOfClientNode.ToString());
                
                System.Windows.MessageBox.Show(selectedNode.ToString());
                OnPropertyChanged("SelectedNode");
            }
        }
        
    }
}
