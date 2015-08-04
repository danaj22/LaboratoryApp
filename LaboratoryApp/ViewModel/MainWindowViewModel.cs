using LaboratoryApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LaboratoryApp
{
    public class MainWindowViewModel : ObservableObject
    {
        private string nameAndSurname = "Janina Powygina";

        public string NameAndSurname
        {
            get { return nameAndSurname; }
            set { nameAndSurname = value; }
        }
        
        
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

        private ObservableCollection<client> allItems = new ObservableCollection<client>();

        public ObservableCollection<client> AllItems
        {
            get { return allItems; }
            set { allItems = value; }
        }

        private object selectedNode = 0;

        public object SelectedNode
        {
            get { return selectedNode; }
            set
            {
                selectedNode = value;

                if ((SelectedNode as client) != null)
                {
                    client selectedClient = selectedNode as client;
                    CurrentViewModel = new InformationAboutClient()
                                                                    { ClientId = selectedClient.clientId,
                                                                      Name = selectedClient.name, 
                                                                      Address = selectedClient.adress, 
                                                                      NIP = selectedClient.NIP, 
                                                                      Telephone = selectedClient.tel,
                                                                      ContactPerson = selectedClient.contact_person_name,
                                                                      Comment = selectedClient.comments,
                                                                      Email = selectedClient.mail};
                }
                if((SelectedNode as office)!=null)
                {
                    office selectedOffice = selectedNode as office;
                    CurrentViewModel = new InformationAboutOffice()
                                                                    {
                                                                      OfficeId = selectedOffice.officeId,
                                                                      Name = selectedOffice.name,
                                                                      Address = selectedOffice.adress,
                                                                      Telephone = selectedOffice.tel,
                                                                      ContactPerson = selectedOffice.contact_person_name,
                                                                      Email = selectedOffice.mail};
                }
                if ((SelectedNode as product) != null)
                {
                    product selectedProduct = selectedNode as product;
                    CurrentViewModel = new ViewModel.InformationAboutProduct() {
                                                                      ProductId = selectedProduct.productId,
                                                                      SerialNumber = selectedProduct.serial_number,
                                                                      Gauge = selectedProduct.gauge,
                                                                      Office = selectedProduct.office
                                                                      };
                }
                OnPropertyChanged("SelectedNode");
            }
        }

        private ObservableObject currentViewModel;

        public ObservableObject CurrentViewModel
        {
            get { return currentViewModel; }
            set 
            {
                currentViewModel = value;
                this.OnPropertyChanged("CurrentViewModel");
            }
        }
      
        private void LoadView()
        {
            
            data = new LoadData(AllItems);
        }

        public MainWindowViewModel()
        {
            CurrentViewModel = null;
            userInput = new UserInput();
            LoadView();
           
        }
       
        public int SearchItem { get; set; }
        public ICommand LoadContent { get; set; }
        public ICommand SearchCommand 
        {
            get { return new SimpleRelayCommand(SearchGauge); }
        }
        private void SearchGauge()
        {
            laboratoryEntities context = new laboratoryEntities();

            var tmp = (from searchedGauge in context.gauges
                       where SearchItem == searchedGauge.gaugeId
                       select new { searchedGauge.model }).ToList();

            //trzeba dopisać wyszukiwanie
            
        }
        private bool CanSearchGauge()
        {
            return true; 
        }

        /// <summary>
        /// command to show modal window where we can add new Gauge
        /// </summary>
        public ICommand AddNewGaugeCommand
        { get { return new SimpleRelayCommand(AddGauge); } }

        private void AddGauge()
        {
            //create a new modal window

            View.ModalWindowGauge newModal = new View.ModalWindowGauge();

            //set owner of this window
            newModal.Owner = Application.Current.MainWindow;
            newModal.ShowDialog();
            
            if (newModal.DialogResult == true)
            {
                MessageBox.Show(newModal.DialogResult.ToString());
                var newGauge = new gauge();
                newGauge.manufacturer_name = newModal.infoGauge.ManufacturerName;
                newGauge.model = newModal.infoGauge.Model;
                newGauge.type_id = 1;
                newGauge.usage_id = 1;

                using (laboratoryEntities context = new laboratoryEntities())
                {

                    context.gauges.Add(newGauge);
                    context.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show(newModal.DialogResult.ToString());
            }
            
        }
        /// <summary>
        /// command to show modal window where we can add new Client
        /// </summary>
        public ICommand AddNewClientCommand
        {
            get
            {
                return new SimpleRelayCommand(AddClient);
            }
        }

        //public View.ModalWindowClient NClient = new View.ModalWindowClient();
        
        private void changeResult(View.ModalWindowClient cli)
        {
            cli.DialogResult = true;
        }

        
        //
        private void AddClient()
        {
            View.ModalWindowClient newModal;
            //create a new modal window

            newModal = new View.ModalWindowClient() {};

            //set owner of this window

            newModal.Owner = Application.Current.MainWindow;
            newModal.ShowDialog();

            //when we click OK button we add client to database 
            if (newModal.DialogResult == true)
            {
                client newClient = new client();
                newClient.name = newModal.infoClient.Name;
                newClient.adress = newModal.infoClient.Address;
                newClient.mail = newModal.infoClient.Email;
                newClient.tel = newModal.infoClient.Telephone;
                newClient.NIP = newModal.infoClient.NIP;
                newClient.contact_person_name = newModal.infoClient.ContactPerson;
                newClient.comments = newModal.infoClient.Comment;

                using (laboratoryEntities context = new laboratoryEntities())
                {
                    context.clients.Add(newClient);
                    context.SaveChanges();
                    //if (Name != "" && Address != "" && ContactPerson != "" && Email != "" && Telephone != "" && NIP != "" && Comment != "")
                    //{
                    //    clientToEdit.name = Name;
                    //    clientToEdit.adress = Address;
                    //    clientToEdit.contact_person_name = ContactPerson;
                    //    clientToEdit.mail = Email;
                    //    clientToEdit.tel = Telephone;
                    //    clientToEdit.NIP = NIP;
                    //    clientToEdit.comments = Comment;

                    //    context.SaveChanges();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Wypełnij wszystkie pola");
                    //}

                }
            }
            else
            {
                MessageBox.Show(newModal.DialogResult.ToString());
            }
            
        }


        private bool CanAddClient()
        { 
            return true; 
        }


        public bool? WindowCloseResult
        { get;
            set; }
   
    }
}
