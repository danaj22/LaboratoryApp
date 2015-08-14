using LaboratoryApp.View;
using LaboratoryApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
//todelet 2 lib^^
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
            set {
                allItems = value;
                OnPropertyChanged("AllItems");
            }
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
                                                                    { 
                                                                      ClientId = selectedClient.clientId,
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
                                                                      ClientId = selectedOffice.client_id,
                                                                      Name = selectedOffice.name,
                                                                      Address = selectedOffice.adress,
                                                                      Telephone = selectedOffice.tel,
                                                                      ContactPerson = selectedOffice.contact_person_name,
                                                                      Email = selectedOffice.mail};
                }
                if ((SelectedNode as product) != null)
                {
                    product selectedProduct = selectedNode as product;
                    CurrentViewModel = new ViewModel.InformationAboutGauge() {
                                                                      GaugeId = selectedProduct.productId,
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

            //TaskCommand = new SimpleRelayCommand(TaskCom);
            Title = "Laboratorium";
            AddNewClientCommand = new SimpleRelayCommand(AddClient);
            AddNewGaugeCommand = new SimpleRelayCommand(AddGauge);
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
            LaboratoryEntities context = new LaboratoryEntities();

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
        /// 
        private ICommand addNewGaugeCommand;
        public ICommand AddNewGaugeCommand
        { 

            get 
            { 
                return addNewGaugeCommand;
            } 
            set
            {
                addNewGaugeCommand = value;
                OnPropertyChanged("AddNewGaugeCommand");
            }
        }

        private void AddGauge()
        {
            MessageWindowModelOfGauge = new NewWindowModelOfGauge() { AboutModelOfGauge = new InformationAboutModelOfGauge() };
            MessageWindowModelOfGauge.IsOpen = true;

            //DialogWindowBase newBaseWindow = new DialogWindowBase();
            //NewWindowModelOfGauge gaugeDialogWindow = new NewWindowModelOfGauge() { AboutModelOfGauge = new InformationAboutModelOfGauge() };

            //newBaseWindow.BaseContent = gaugeDialogWindow;

            //WindowService w = new WindowService();
            //w.DataContext = newBaseWindow;
            //w.Owner = Application.Current.MainWindow;
            //w.ShowDialog();

            //bool? result = w.DialogResult;

            //if (result == true)
            //{
            //    MessageBox.Show(result.ToString());
            //    var gaugeToAddToDatabase = new gauge();

            //    gaugeToAddToDatabase.manufacturer_name = gaugeDialogWindow.AboutModelOfGauge.ManufacturerName;
            //    gaugeToAddToDatabase.model = gaugeDialogWindow.AboutModelOfGauge.Model;
                
            //    //trzeba dorobić wyszukiwanie w bazie "po nazwie znajdź ID"
            //    gaugeToAddToDatabase.type_id = 1;
            //    gaugeToAddToDatabase.usage_id = 1;

            //    using (LaboratoryEntities context = new LaboratoryEntities())
            //    {
            //        context.gauges.Add(gaugeToAddToDatabase);
            //        context.SaveChanges();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show(w.DialogResult.ToString());
            //}
            //create a new modal window

            //View.ModalWindowModelOfGauge newModal = new View.ModalWindowModelOfGauge();

            ////set owner of this window
            //newModal.Owner = Application.Current.MainWindow;
            //newModal.ShowDialog();
            
            //if (newModal.DialogResult == true)
            //{
            //    MessageBox.Show(newModal.DialogResult.ToString());
            //    var newGauge = new gauge();
            //    newGauge.manufacturer_name = newModal.infoGauge.ManufacturerName;
            //    newGauge.model = newModal.infoGauge.Model;
            //    newGauge.type_id = 1;
            //    newGauge.usage_id = 1;

            //    using (LaboratoryEntities context = new LaboratoryEntities())
            //    {

            //        context.gauges.Add(newGauge);
            //        context.SaveChanges();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show(newModal.DialogResult.ToString());
            //}
        }
        /// <summary>
        /// command to show modal window where we can add new Client
        /// </summary>
        /// 
        private ICommand addNewClientCommand;
        public ICommand AddNewClientCommand
        {

            get
            {
                return addNewClientCommand;
            }
            set 
            { 
                addNewClientCommand = value;
                OnPropertyChanged("AddNewClientCommand");
            }
        }

        //public View.ModalWindowClient NClient = new View.ModalWindowClient();
        
        private bool? dialogResultValue;

        public bool? DialogResultValue
        {
            get { return dialogResultValue; }
            set 
            { 
                dialogResultValue = value;
                OnPropertyChanged("DialogResultValue");
            }
        }


        private DialogWindowBase dialogWindow;
        public DialogWindowBase DialogWindow
        {
            get { return dialogWindow; }
            set 
            {
                dialogWindow = value;
                OnPropertyChanged("DialogWindow");
            }
        }

            
        
        private void AddClient()
        {
            MessageWindow = new NewWindowClient { AboutClient = new InformationAboutClient() };
            MessageWindow.IsOpen = true;

            if(MessageWindow.ToConfirm == true)
            {
                MessageBox.Show("dodanie użytkownika do bazy");
                if (MessageWindow.AboutClient.Name != null
                && MessageWindow.AboutClient.Address != null
                && MessageWindow.AboutClient.Email != null
                && MessageWindow.AboutClient.Telephone != null
                && MessageWindow.AboutClient.NIP != null
                && MessageWindow.AboutClient.ContactPerson != null)
                {

                    client newClient = new client();
                    newClient.name = MessageWindow.AboutClient.Name;
                    newClient.adress = MessageWindow.AboutClient.Address;
                    newClient.mail = MessageWindow.AboutClient.Email;
                    newClient.tel = MessageWindow.AboutClient.Telephone;
                    newClient.NIP = MessageWindow.AboutClient.NIP;
                    newClient.contact_person_name = MessageWindow.AboutClient.ContactPerson;
                    newClient.comments = MessageWindow.AboutClient.Comment;

                    using (LaboratoryEntities context = new LaboratoryEntities())
                    {
                        context.clients.Add(newClient);
                        context.SaveChanges();
                    }

                    
                    var index = AllItems.IndexOf(AllItems.Last())+1;
                    //AllItems.Remove((client)SelectedNode);
                    //Add new client to TreeView
                    AllItems.Insert(index, newClient);
                }
            }


            //DialogWindowBase newBaseWindow = new DialogWindowBase();
            //NewWindowClient newBaseClient = new NewWindowClient() { AboutClient = new InformationAboutClient() };

            //newBaseWindow.BaseContent = newBaseClient;

            //WindowService w = new WindowService();
            //w.DataContext = newBaseWindow;

            //w.Owner = Application.Current.MainWindow;

            //w.ShowDialog();

            ////w.SetBinding(Window.ContentProperty, "");

            //var result = w.DialogResult;

            //if (result == true)
            //{
            //    MessageBox.Show(result.ToString());

            //    client newClient = new client();
            //    newClient.name = newBaseClient.AboutClient.Name;
            //    newClient.adress = newBaseClient.AboutClient.Address;
            //    newClient.mail = newBaseClient.AboutClient.Email;
            //    newClient.tel = newBaseClient.AboutClient.Telephone;
            //    newClient.NIP = newBaseClient.AboutClient.NIP;
            //    newClient.contact_person_name = newBaseClient.AboutClient.ContactPerson;
            //    newClient.comments = newBaseClient.AboutClient.Comment;

            //    using (LaboratoryEntities context = new LaboratoryEntities())
            //    {
            //        context.clients.Add(newClient);
            //        context.SaveChanges();
            //        //if (Name != "" && Address != "" && ContactPerson != "" && Email != "" && Telephone != "" && NIP != "" && Comment != "")
            //        //{
            //        //    clientToEdit.name = Name;
            //        //    clientToEdit.adress = Address;
            //        //    clientToEdit.contact_person_name = ContactPerson;
            //        //    clientToEdit.mail = Email;
            //        //    clientToEdit.tel = Telephone;
            //        //    clientToEdit.NIP = NIP;
            //        //    clientToEdit.comments = Comment;

            //        //    context.SaveChanges();
            //        //}
            //        //else
            //        //{
            //        //    MessageBox.Show("Wypełnij wszystkie pola");
            //        //}

            //    }
            //}
            //else
            //{

            //}

        }

        private NewWindowModelOfGauge messageWindowModelOfGauge;

        public NewWindowModelOfGauge MessageWindowModelOfGauge
        {
            get { return messageWindowModelOfGauge; }
            set 
            {
                messageWindowModelOfGauge = value;
                base.OnPropertyChanged("MessageWindowModelOfGauge");
            }
        }


        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                base.OnPropertyChanged("Title");
            }
        }

        private NewWindowClient messageWindow;

        public NewWindowClient MessageWindow
        {
            get { return messageWindow; }
            set
            {
                
                messageWindow = value;
                base.OnPropertyChanged("MessageWindow");
            }
        }

       
        private string status;

        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                base.OnPropertyChanged("Status");
            }
        }
    }
}
