using LaboratoryApp.View;
using LaboratoryApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
//using System.Windows;
//using System.Windows.Input;
//todelet 2 lib^^
namespace LaboratoryApp.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        private string nameAndSurname = "Janina Powygina";

        public string NameAndSurname
        {
            get { return nameAndSurname; }
            set { nameAndSurname = value; }
        }
        
        
        static private LoadData data;

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

        static public MenuItem rootElement = new MenuItem();

        //static public List<client> ListOfClient = new List<client>();

        public MenuItem RootElement
        {
            get { return rootElement; }
            set 
            { 
                rootElement = value;
                OnPropertyChanged("RootElement");
            }
        }

        static public ObservableCollection<client> allItems = new ObservableCollection<client>();

        public ObservableCollection<client> AllItems
        {
            get { return allItems; }
            set {
                allItems = value;
                OnPropertyChanged("AllItems");
            }
        }

        static public MenuItem selectedNode = new MenuItem();

        public MenuItem SelectedNode
        {
            get { return selectedNode; }
            set
            {
                selectedNode = value;

                if ((SelectedNode as client) != null)
                
                {
                    CurrentViewModel = new InformationAboutClient(SelectedNode);
                }

                if((SelectedNode as office)!=null)
                {
                    office selectedOffice = SelectedNode as office;
                    CurrentViewModel = new InformationAboutOffice(SelectedNode);
                }
                if ((SelectedNode as gauge) != null)
                {
                    gauge selectedGauge = SelectedNode as gauge;
                    CurrentViewModel = new InformationAboutGauge(SelectedNode);
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
      
        static public void LoadView()
        {            
            data = new LoadData(rootElement);            
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
            try
            {
                LaboratoryEntities context = new LaboratoryEntities();

                //var tmp = (from searchedGauge in context.model_of_gauges
                //           where SearchItem == searchedGauge.gaugeId
                //           select new { searchedGauge. }).ToList();

                //trzeba dopisać wyszukiwanie
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        private bool CanSearchGauge()
        {
            return true; 
        }

        /// <summary>
        /// command to show modal window where we can add new ModelOfGaugeItem
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
            MessageWindowModelOfGauge = new NewWindowModelOfGauge 
            { AboutModelOfGauge = new InformationAboutModelOfGauge() };
            
            MessageWindowModelOfGauge.IsOpen = true;

            if (MessageWindowModelOfGauge.ToConfirm)
            {
                if (!String.IsNullOrEmpty(MessageWindowModelOfGauge.AboutModelOfGauge.ManufacturerName)
                    && !String.IsNullOrEmpty(MessageWindowModelOfGauge.AboutModelOfGauge.Model)
                    && !String.IsNullOrEmpty(MessageWindowModelOfGauge.AboutModelOfGauge.SelectedUsage)
                    && !String.IsNullOrEmpty(MessageWindowModelOfGauge.AboutModelOfGauge.SelectedType)
                    )
                {
                    var newGauge = new model_of_gauges();
                    newGauge.Manufacturer_name = MessageWindowModelOfGauge.AboutModelOfGauge.ManufacturerName;
                    newGauge.Model = MessageWindowModelOfGauge.AboutModelOfGauge.Model;

                    try
                    {
                        using (LaboratoryEntities context = new LaboratoryEntities())
                        {
                            newGauge.type_id = (from t in context.types where t.name == MessageWindowModelOfGauge.AboutModelOfGauge.SelectedType select t.typeId).FirstOrDefault();
                            newGauge.usage_id = (from u in context.usages where u.description == MessageWindowModelOfGauge.AboutModelOfGauge.SelectedUsage select u.usageId).FirstOrDefault();
                        }
                    }
                    catch(Exception ex)
                    { 
                        MessageBox.Show(ex.ToString());
                    }
                    try
                    {
                        using (LaboratoryEntities context = new LaboratoryEntities())
                        {

                            context.model_of_gauges.Add(newGauge);
                            context.SaveChanges();
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

            }
            MessageWindowModelOfGauge.ToConfirm = false;

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
            //    var gaugeToAddToDatabase = new modelOfGaugeItem();

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
            //    var newGauge = new modelOfGaugeItem();
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
            MessageWindowClient = new NewWindowClient { AboutClient = new client() };
            MessageWindowClient.IsOpen = true;

            if(MessageWindowClient.ToConfirm)
            {
                if (MessageWindowClient.AboutClient.name != null && MessageWindowClient.AboutClient.NIP != null)
                {

                    client newClient = new client();
                    newClient.name = MessageWindowClient.AboutClient.name;
                    newClient.adress = MessageWindowClient.AboutClient.adress;
                    newClient.mail = MessageWindowClient.AboutClient.mail;
                    newClient.tel = MessageWindowClient.AboutClient.tel;
                    newClient.NIP = MessageWindowClient.AboutClient.NIP;
                    newClient.contact_person_name = MessageWindowClient.AboutClient.contact_person_name;
                    newClient.comments = MessageWindowClient.AboutClient.comments;
                    

                    try
                    {
                        using (LaboratoryEntities context = new LaboratoryEntities())
                        {
                            context.clients.Add(newClient);
                            context.SaveChanges();
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    
                    //var index = RootElement.Items.IndexOf(RootElement.Items.Last())+1;
                    //AllItems.Remove((client)SelectedNode);
                    //Add new client to TreeView
                    RootElement.Children.Add(newClient);
                    RootElement.Children.Last().NameOfItem = newClient.name;

                    MessageBox.Show("dodanie użytkownika do bazy");
                    
                }
                
            }
            MessageWindowClient.ToConfirm = false;


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
                base.OnPropertyChanged("TitleOfItem");
            }
        }

        private NewWindowClient messageWindowClient;

        public NewWindowClient MessageWindowClient
        {
            get { return messageWindowClient; }
            set
            {
                
                messageWindowClient = value;
                base.OnPropertyChanged("MessageWindowClient");
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
